#region Header
// /*
//  *    2018 - Ultima - Art.cs
//  */
#endregion

#region References
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
#endregion

namespace Ultima
{
	public sealed class Art
	{
		private static FileIndex m_FileIndex = new FileIndex(
			"Artidx.mul",
			"Art.mul",
			"artLegacyMUL.uop",
			0x10000 /*0x13FDC*/,
			4,
			".tga",
			0x13FDC,
			false);

		private static Bitmap[] m_Cache;
		private static bool[] m_Removed;
		private static readonly Hashtable m_patched = new Hashtable();
		public static bool Modified;

		private static byte[] m_StreamBuffer;
		private static byte[] Validbuffer;

		private struct CheckSums
		{
			public byte[] checksum;
			public int pos;
			public int length;
			public int index;
		}

		private static List<CheckSums> checksumsLand;
		private static List<CheckSums> checksumsStatic;

		static Art()
		{
			m_Cache = new Bitmap[0x10000];
			m_Removed = new bool[0x10000];
		}

		public static int GetMaxItemID()
		{
			if (GetIdxLength() >= 0x13FDC)
			{
				return 0x10000;
			}

			if (GetIdxLength() == 0xC000)
			{
				return 0x7FFF;
			}

			return 0x3FFF;
		}

		public static bool IsUOAHS()
		{
			return GetIdxLength() >= 0x13FDC;
		}

		public static ushort GetLegalItemID(int itemID, bool checkmaxid = true)
		{
			if (itemID < 0)
			{
				return 0;
			}

			if (checkmaxid)
			{
				var max = GetMaxItemID();
				if (itemID > max)
				{
					return 0;
				}
			}
			return (ushort)itemID;
		}

		public static int GetIdxLength()
		{
			return (int)(m_FileIndex.IdxLength / 12);
		}

		/// <summary>
		///     ReReads Art.mul
		/// </summary>
		public static void Reload()
		{
			m_FileIndex = new FileIndex(
				"Artidx.mul",
				"Art.mul",
				"artLegacyMUL.uop",
				0x10000 /*0x13FDC*/,
				4,
				".tga",
				0x13FDC,
				false);
			m_Cache = new Bitmap[0x10000];
			m_Removed = new bool[0x10000];
			m_patched.Clear();
			Modified = false;
		}

		/// <summary>
		///     Sets bmp of index in <see cref="m_Cache" /> of Static
		/// </summary>
		/// <param name="index"></param>
		/// <param name="bmp"></param>
		public static void ReplaceStatic(int index, Bitmap bmp)
		{
			index = GetLegalItemID(index);
			index += 0x4000;

			m_Cache[index] = bmp;
			m_Removed[index] = false;
			if (m_patched.Contains(index))
			{
				m_patched.Remove(index);
			}
			Modified = true;
		}

		/// <summary>
		///     Sets bmp of index in <see cref="m_Cache" /> of Land
		/// </summary>
		/// <param name="index"></param>
		/// <param name="bmp"></param>
		public static void ReplaceLand(int index, Bitmap bmp)
		{
			index &= 0x3FFF;
			m_Cache[index] = bmp;
			m_Removed[index] = false;
			if (m_patched.Contains(index))
			{
				m_patched.Remove(index);
			}
			Modified = true;
		}

		/// <summary>
		///     Removes Static index <see cref="m_Removed" />
		/// </summary>
		/// <param name="index"></param>
		public static void RemoveStatic(int index)
		{
			index = GetLegalItemID(index);
			index += 0x4000;

			m_Removed[index] = true;
			Modified = true;
		}

		/// <summary>
		///     Removes Land index <see cref="m_Removed" />
		/// </summary>
		/// <param name="index"></param>
		public static void RemoveLand(int index)
		{
			index &= 0x3FFF;
			m_Removed[index] = true;
			Modified = true;
		}

		/// <summary>
		///     Tests if Static is definied (width and hight check)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static unsafe bool IsValidStatic(int index)
		{
			index = GetLegalItemID(index);
			index += 0x4000;

			if (m_Removed[index])
			{
				return false;
			}
			if (m_Cache[index] != null)
			{
				return true;
			}

			var stream = m_FileIndex.Seek(index, out var length, out var extra, out var patched);

			if (stream == null)
			{
				return false;
			}

			if (Validbuffer == null)
			{
				Validbuffer = new byte[4];
			}
			_ = stream.Seek(4, SeekOrigin.Current);
			_ = stream.Read(Validbuffer, 0, 4);
			fixed (byte* b = Validbuffer)
			{
				var dat = (short*)b;
				if (*dat++ <= 0 || *dat <= 0)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///     Tests if LandTile is definied
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static bool IsValidLand(int index)
		{
			index &= 0x3FFF;
			if (m_Removed[index])
			{
				return false;
			}
			if (m_Cache[index] != null)
			{
				return true;
			}

			return m_FileIndex.Valid(index, out _, out _, out _);
		}

		/// <summary>
		///     Returns Bitmap of LandTile (with Cache)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static Bitmap GetLand(int index)
		{
			return GetLand(index, out _);
		}

		/// <summary>
		///     Returns Bitmap of LandTile (with Cache) and verdata bool
		/// </summary>
		/// <param name="index"></param>
		/// <param name="patched"></param>
		/// <returns></returns>
		public static Bitmap GetLand(int index, out bool patched)
		{
			index &= 0x3FFF;
			if (m_patched.Contains(index))
			{
				patched = (bool)m_patched[index];
			}
			else
			{
				patched = false;
			}

			if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}

			var stream = m_FileIndex.Seek(index, out var length, out _, out patched);
			if (stream == null)
			{
				return null;
			}
			if (patched)
			{
				m_patched[index] = true;
			}

			if (Files.CacheData)
			{
				return m_Cache[index] = LoadLand(stream, length);
			}
			return LoadLand(stream, length);
		}

		public static byte[] GetRawLand(int index)
		{
			index &= 0x3FFF;
			var stream = m_FileIndex.Seek(index, out var length, out _, out _);
			if (stream == null)
			{
				return null;
			}
			var buffer = new byte[length];
			_ = stream.Read(buffer, 0, length);
			stream.Close();
			return buffer;
		}

		/// <summary>
		///     Returns Bitmap of Static (with Cache)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static Bitmap GetStatic(int index, bool checkmaxid = true)
		{
			return GetStatic(index, out _, checkmaxid);
		}

		/// <summary>
		///     Returns Bitmap of Static (with Cache) and verdata bool
		/// </summary>
		/// <param name="index"></param>
		/// <param name="patched"></param>
		/// <returns></returns>
		public static Bitmap GetStatic(int index, out bool patched, bool checkmaxid = true)
		{
			index = GetLegalItemID(index, checkmaxid);
			index += 0x4000;

			if (m_patched.Contains(index))
			{
				patched = (bool)m_patched[index];
			}
			else
			{
				patched = false;
			}

			if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}

			var stream = m_FileIndex.Seek(index, out var length, out _, out patched);
			if (stream == null)
			{
				return null;
			}
			if (patched)
			{
				m_patched[index] = true;
			}

			if (Files.CacheData)
			{
				return m_Cache[index] = LoadStatic(stream, length);
			}
			return LoadStatic(stream, length);
		}

		public static byte[] GetRawStatic(int index)
		{
			index = GetLegalItemID(index);
			index += 0x4000;
			var stream = m_FileIndex.Seek(index, out var length, out _, out _);
			if (stream == null)
			{
				return null;
			}
			var buffer = new byte[length];
			_ = stream.Read(buffer, 0, length);
			stream.Close();
			return buffer;
		}

		public static unsafe void Measure(Bitmap bmp, out int xMin, out int yMin, out int xMax, out int yMax)
		{
			xMin = yMin = 0;
			xMax = yMax = -1;

			if (bmp == null || bmp.Width <= 0 || bmp.Height <= 0)
			{
				return;
			}

			var bd = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height),
				ImageLockMode.ReadOnly,
				PixelFormat.Format16bppArgb1555);

			var delta = (bd.Stride >> 1) - bd.Width;
			var lineDelta = bd.Stride >> 1;

			var pBuffer = (ushort*)bd.Scan0;
			var pLineEnd = pBuffer + bd.Width;
			var pEnd = pBuffer + (bd.Height * lineDelta);

			var foundPixel = false;

			int x = 0, y = 0;

			while (pBuffer < pEnd)
			{
				while (pBuffer < pLineEnd)
				{
					var c = *pBuffer++;

					if ((c & 0x8000) != 0)
					{
						if (!foundPixel)
						{
							foundPixel = true;
							xMin = xMax = x;
							yMin = yMax = y;
						}
						else
						{
							if (x < xMin)
							{
								xMin = x;
							}

							if (y < yMin)
							{
								yMin = y;
							}

							if (x > xMax)
							{
								xMax = x;
							}

							if (y > yMax)
							{
								yMax = y;
							}
						}
					}
					++x;
				}

				pBuffer += delta;
				pLineEnd += lineDelta;
				++y;
				x = 0;
			}

			bmp.UnlockBits(bd);
		}

		private static unsafe Bitmap LoadStatic(Stream stream, int length)
		{
			Bitmap bmp;
			if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			_ = stream.Read(m_StreamBuffer, 0, length);
			stream.Close();

			fixed (byte* data = m_StreamBuffer)
			{
				var bindata = (ushort*)data;
				var count = 2;
				//bin.ReadInt32();
				int width = bindata[count++];
				int height = bindata[count++];

				if (width <= 0 || height <= 0)
				{
					return null;
				}

				var lookups = new int[height];

				var start = height + 4;

				for (var i = 0; i < height; ++i)
				{
					lookups[i] = start + bindata[count++];
				}

				bmp = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
				var bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);

				var line = (ushort*)bd.Scan0;
				var delta = bd.Stride >> 1;

				for (var y = 0; y < height; ++y, line += delta)
				{
					count = lookups[y];

					var cur = line;
					ushort* end;
					int xOffset, xRun;

					while (((xOffset = bindata[count++]) + (xRun = bindata[count++])) != 0)
					{
						if (xOffset > delta)
						{
							break;
						}
						cur += xOffset;
						if (xOffset + xRun > delta)
						{
							break;
						}
						end = cur + xRun;

						while (cur < end)
						{
							*cur++ = (ushort)(bindata[count++] ^ 0x8000);
						}
					}
				}
				bmp.UnlockBits(bd);
			}
			return bmp;
		}

		private static unsafe Bitmap LoadLand(Stream stream, int length)
		{
			var bmp = new Bitmap(44, 44, PixelFormat.Format16bppArgb1555);
			var bd = bmp.LockBits(new Rectangle(0, 0, 44, 44), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
			if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			_ = stream.Read(m_StreamBuffer, 0, length);
			stream.Close();
			fixed (byte* bindata = m_StreamBuffer)
			{
				var bdata = (ushort*)bindata;
				var xOffset = 21;
				var xRun = 2;

				var line = (ushort*)bd.Scan0;
				var delta = bd.Stride >> 1;

				for (var y = 0; y < 22; ++y, --xOffset, xRun += 2, line += delta)
				{
					var cur = line + xOffset;
					var end = cur + xRun;

					while (cur < end)
					{
						*cur++ = (ushort)(*bdata++ | 0x8000);
					}
				}

				xOffset = 0;
				xRun = 44;

				for (var y = 0; y < 22; ++y, ++xOffset, xRun -= 2, line += delta)
				{
					var cur = line + xOffset;
					var end = cur + xRun;

					while (cur < end)
					{
						*cur++ = (ushort)(*bdata++ | 0x8000);
					}
				}
			}
			bmp.UnlockBits(bd);
			return bmp;
		}

		/// <summary>
		///     Saves mul
		/// </summary>
		/// <param name="path"></param>
		public static unsafe void Save(string path)
		{
			checksumsLand = new List<CheckSums>();
			checksumsStatic = new List<CheckSums>();
			var idx = Path.Combine(path, "artidx.mul");
			var mul = Path.Combine(path, "art.mul");
			using (FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
							  fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write))
			{
				var memidx = new MemoryStream();
				var memmul = new MemoryStream();
				var sha = new SHA256Managed();
				//StreamWriter Tex = new StreamWriter(new FileStream("d:/artlog.txt", FileMode.Create, FileAccess.ReadWrite));

				using (BinaryWriter binidx = new BinaryWriter(memidx), binmul = new BinaryWriter(memmul))
				{
					for (var index = 0; index < GetIdxLength(); index++)
					{
						Files.FireFileSaveEvent();
						if (m_Cache[index] == null)
						{
							if (index < 0x4000)
							{
								m_Cache[index] = GetLand(index);
							}
							else
							{
								m_Cache[index] = GetStatic(index - 0x4000, false);
							}
						}
						var bmp = m_Cache[index];
						if ((bmp == null) || m_Removed[index])
						{
							binidx.Write(-1); // lookup
							binidx.Write(0); // length
							binidx.Write(-1); // extra
											  //Tex.WriteLine(System.String.Format("0x{0:X4} : 0x{1:X4} 0x{2:X4}", index, (int)-1, (int)-1));
						}
						else if (index < 0x4000)
						{
							var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Bmp);
							var checksum = sha.ComputeHash(ms.ToArray());
							if (compareSaveImagesLand(checksum, out var sum))
							{
								binidx.Write(sum.pos); //lookup
								binidx.Write(sum.length);
								binidx.Write(0);
								//Tex.WriteLine(System.String.Format("0x{0:X4} : 0x{1:X4} 0x{2:X4}", index, (int)sum.pos, (int)sum.length));
								//Tex.WriteLine(System.String.Format("0x{0:X4} -> 0x{1:X4}", sum.index, index));
								continue;
							}
							//land
							var bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height),
								ImageLockMode.ReadOnly,
								PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							var delta = bd.Stride >> 1;
							binidx.Write((int)binmul.BaseStream.Position); //lookup
							var length = (int)binmul.BaseStream.Position;
							var x = 22;
							var y = 0;
							var linewidth = 2;
							for (var m = 0; m < 22; ++m, ++y, line += delta, linewidth += 2)
							{
								--x;
								var cur = line;
								for (var n = 0; n < linewidth; ++n)
								{
									binmul.Write((ushort)(cur[x + n] ^ 0x8000));
								}
							}
							x = 0;
							linewidth = 44;
							y = 22;
							line = (ushort*)bd.Scan0;
							line += delta * 22;
							for (var m = 0; m < 22; m++, y++, line += delta, ++x, linewidth -= 2)
							{
								var cur = line;
								for (var n = 0; n < linewidth; n++)
								{
									binmul.Write((ushort)(cur[x + n] ^ 0x8000));
								}
							}
							var start = length;
							length = (int)binmul.BaseStream.Position - length;
							binidx.Write(length);
							binidx.Write(0);
							bmp.UnlockBits(bd);
							var s = new CheckSums
							{
								pos = start,
								length = length,
								checksum = checksum,
								index = index
							};
							//Tex.WriteLine(System.String.Format("0x{0:X4} : 0x{1:X4} 0x{2:X4}", index, start, length));
							checksumsLand.Add(s);
						}
						else
						{
							var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Bmp);
							var checksum = sha.ComputeHash(ms.ToArray());
							if (compareSaveImagesStatic(checksum, out var sum))
							{
								binidx.Write(sum.pos); //lookup
								binidx.Write(sum.length);
								binidx.Write(0);
								//Tex.WriteLine(System.String.Format("0x{0:X4} -> 0x{1:X4}", sum.index, index));
								//Tex.WriteLine(System.String.Format("0x{0:X4} : 0x{1:X4} 0x{2:X4}", index, sum.pos, sum.length));
								continue;
							}

							// art
							var bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height),
								ImageLockMode.ReadOnly,
								PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							var delta = bd.Stride >> 1;
							binidx.Write((int)binmul.BaseStream.Position); //lookup
							var length = (int)binmul.BaseStream.Position;
							binmul.Write(1234); // header
							binmul.Write((short)bmp.Width);
							binmul.Write((short)bmp.Height);
							var lookup = (int)binmul.BaseStream.Position;
							var streamloc = lookup + (bmp.Height * 2);
							var width = 0;
							for (var i = 0; i < bmp.Height; ++i) // fill lookup
							{
								binmul.Write(width);
							}
							var X = 0;
							for (var Y = 0; Y < bmp.Height; ++Y, line += delta)
							{
								var cur = line;
								width = (int)(binmul.BaseStream.Position - streamloc) / 2;
								_ = binmul.BaseStream.Seek(lookup + (Y * 2), SeekOrigin.Begin);
								binmul.Write(width);
								_ = binmul.BaseStream.Seek(streamloc + (width * 2), SeekOrigin.Begin);
								var i = 0;
								var j = 0;
								X = 0;
								while (i < bmp.Width)
								{
									i = X;
									for (i = X; i <= bmp.Width; ++i)
									{
										//first pixel set
										if (i < bmp.Width)
										{
											if (cur[i] != 0)
											{
												break;
											}
										}
									}
									if (i < bmp.Width)
									{
										for (j = i + 1; j < bmp.Width; ++j)
										{
											//next non set pixel
											if (cur[j] == 0)
											{
												break;
											}
										}
										binmul.Write((short)(i - X)); //xoffset
										binmul.Write((short)(j - i)); //run
										for (var p = i; p < j; ++p)
										{
											binmul.Write((ushort)(cur[p] ^ 0x8000));
										}
										X = j;
									}
								}
								binmul.Write((short)0); //xOffset
								binmul.Write((short)0); //Run
							}
							var start = length;
							length = (int)binmul.BaseStream.Position - length;
							binidx.Write(length);
							binidx.Write(0);
							bmp.UnlockBits(bd);
							var s = new CheckSums
							{
								pos = start,
								length = length,
								checksum = checksum,
								index = index
							};
							//Tex.WriteLine(System.String.Format("0x{0:X4} : 0x{1:X4} 0x{2:X4}", index, start, length));
							checksumsStatic.Add(s);
						}
					}
					memidx.WriteTo(fsidx);
					memmul.WriteTo(fsmul);
				}
			}
		}

		private static bool compareSaveImagesLand(byte[] newchecksum, out CheckSums sum)
		{
			sum = new CheckSums();
			for (var i = 0; i < checksumsLand.Count; ++i)
			{
				var cmp = checksumsLand[i].checksum;
				if ((cmp == null) || (newchecksum == null) || (cmp.Length != newchecksum.Length))
				{
					return false;
				}
				var valid = true;
				for (var j = 0; j < cmp.Length; ++j)
				{
					if (cmp[j] != newchecksum[j])
					{
						valid = false;
						break;
					}
				}
				if (valid)
				{
					sum = checksumsLand[i];
					return true;
				}
			}
			return false;
		}

		private static bool compareSaveImagesStatic(byte[] newchecksum, out CheckSums sum)
		{
			sum = new CheckSums();
			for (var i = 0; i < checksumsStatic.Count; ++i)
			{
				var cmp = checksumsStatic[i].checksum;
				if ((cmp == null) || (newchecksum == null) || (cmp.Length != newchecksum.Length))
				{
					return false;
				}
				var valid = true;
				for (var j = 0; j < cmp.Length; ++j)
				{
					if (cmp[j] != newchecksum[j])
					{
						valid = false;
						break;
					}
				}
				if (valid)
				{
					sum = checksumsStatic[i];
					return true;
				}
			}
			return false;
		}
	}
}
