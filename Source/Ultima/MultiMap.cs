#region Header
// /*
//  *    2018 - Ultima - MultiMap.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
#endregion

namespace Ultima
{
	public sealed class MultiMap
	{
		private static byte[] m_StreamBuffer;

		/// <summary>
		///     Returns Bitmap
		/// </summary>
		/// <returns></returns>
		public static unsafe Bitmap GetMultiMap()
		{
			var path = Files.GetFilePath("Multimap.rle");
			if (path != null)
			{
				using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (var bin = new BinaryReader(fs))
					{
						int width, height;
						byte pixel;
						int count;
						int x, i;
						x = 0;
						ushort c = 0;
						width = bin.ReadInt32();
						height = bin.ReadInt32();
						var multimap = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
						var bd = multimap.LockBits(
							new Rectangle(0, 0, multimap.Width, multimap.Height),
							ImageLockMode.WriteOnly,
							PixelFormat.Format16bppArgb1555);
						var line = (ushort*)bd.Scan0;
						var delta = bd.Stride >> 1;

						var cur = line;
						var len = (int)(bin.BaseStream.Length - bin.BaseStream.Position);
						if (m_StreamBuffer == null || m_StreamBuffer.Length < len)
						{
							m_StreamBuffer = new byte[len];
						}
						_ = bin.Read(m_StreamBuffer, 0, len);
						var j = 0;
						while (j != len)
						{
							pixel = m_StreamBuffer[j++];
							count = pixel & 0x7f;

							if ((pixel & 0x80) != 0)
							{
								c = 0x8000; //Color.Black;
							}
							else
							{
								c = 0xffff; //Color.White;
							}
							for (i = 0; i < count; ++i)
							{
								cur[x++] = c;
								if (x >= width)
								{
									cur += delta;
									x = 0;
								}
							}
						}
						multimap.UnlockBits(bd);
						return multimap;
					}
				}
			}
			return null;
		}

		/// <summary>
		///     Saves Bitmap to rle Format
		/// </summary>
		/// <param name="image"></param>
		/// <param name="bin"></param>
		public static unsafe void SaveMultiMap(Bitmap image, BinaryWriter bin)
		{
			bin.Write(2560); // width
			bin.Write(2048); // height
			byte data = 1;
			byte mask = 0x0;
			ushort curcolor = 0;
			var bd = image.LockBits(
				new Rectangle(0, 0, image.Width, image.Height),
				ImageLockMode.ReadOnly,
				PixelFormat.Format16bppArgb1555);
			var line = (ushort*)bd.Scan0;
			var delta = bd.Stride >> 1;
			var cur = line;
			curcolor = cur[0]; //init
			for (var y = 0; y < image.Height; ++y, line += delta)
			{
				cur = line;
				for (var x = 0; x < image.Width; ++x)
				{
					var c = cur[x];

					if (c == curcolor)
					{
						++data;
						if (data == 0x7f)
						{
							if (curcolor == 0xffff)
							{
								mask = 0x0;
							}
							else
							{
								mask = 0x80;
							}
							data |= mask;
							bin.Write(data);
							data = 1;
						}
					}
					else
					{
						if (curcolor == 0xffff)
						{
							mask = 0x0;
						}
						else
						{
							mask = 0x80;
						}
						data |= mask;
						bin.Write(data);
						curcolor = c;
						data = 1;
					}
				}
			}
			if (curcolor == 0xffff)
			{
				mask = 0x0;
			}
			else
			{
				mask = 0x80;
			}
			data |= mask;
			bin.Write(data);
			image.UnlockBits(bd);
		}

		/// <summary>
		///     reads facet0*.mul into Bitmap
		/// </summary>
		/// <param name="id">facet id</param>
		/// <returns>Bitmap</returns>
		public static unsafe Bitmap GetFacetImage(int id)
		{
			Bitmap bmp;
			var path = Files.GetFilePath(String.Format("facet0{0}.mul", id));
			if (path != null)
			{
				using (var reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
				{
					int width = reader.ReadInt16();
					int height = reader.ReadInt16();

					bmp = new Bitmap(width, height);
					var bd = bmp.LockBits(
						new Rectangle(0, 0, bmp.Width, bmp.Height),
						ImageLockMode.WriteOnly,
						PixelFormat.Format16bppArgb1555);
					var line = (ushort*)bd.Scan0;
					var delta = bd.Stride >> 1;

					for (var y = 0; y < height; y++, line += delta)
					{
						var colorsCount = reader.ReadInt32() / 3;
						var endline = line + delta;
						var cur = line;
						ushort* end;
						for (var c = 0; c < colorsCount; c++)
						{
							var count = reader.ReadByte();
							var color = reader.ReadInt16();
							end = cur + count;
							while (cur < end)
							{
								if (cur > endline)
								{
									break;
								}
								*cur++ = (ushort)(color ^ 0x8000);
							}
						}
					}
					bmp.UnlockBits(bd);
				}
				return bmp;
			}
			return null;
		}

		/// <summary>
		///     Stores Image into facet.mul format
		/// </summary>
		/// <param name="path"></param>
		/// <param name="sourceBitmap"></param>
		public static unsafe void SaveFacetImage(string path, Bitmap sourceBitmap)
		{
			var width = sourceBitmap.Width;
			var height = sourceBitmap.Height;

			using (var writer =
				new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
			{
				writer.Write((short)width);
				writer.Write((short)height);
				var bd = sourceBitmap.LockBits(
					new Rectangle(0, 0, width, height),
					ImageLockMode.ReadOnly,
					PixelFormat.Format16bppArgb1555);
				var line = (ushort*)bd.Scan0;
				var delta = bd.Stride >> 1;
				for (var y = 0; y < height; y++, line += delta)
				{
					var pos = writer.BaseStream.Position;
					writer.Write(0); //bytes count for current line

					var colorsAtLine = 0;
					var colorsCount = 0;
					var x = 0;

					while (x < width)
					{
						var hue = line[x];
						while (x < width && colorsCount < Byte.MaxValue && hue == line[x])
						{
							++colorsCount;
							++x;
						}
						writer.Write((byte)colorsCount);
						writer.Write((ushort)(hue ^ 0x8000));

						colorsAtLine++;
						colorsCount = 0;
					}
					var currpos = writer.BaseStream.Position;
					_ = writer.BaseStream.Seek(pos, SeekOrigin.Begin);
					writer.Write(colorsAtLine * 3); //byte count
					_ = writer.BaseStream.Seek(currpos, SeekOrigin.Begin);
				}
			}
		}
	}
}