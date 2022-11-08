#region References
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
#endregion

namespace Ultima
{
	public sealed class RadarCol
	{
		static RadarCol()
		{
			Initialize();
		}

		public static short[] Colors { get; private set; }

		public static short GetItemColor(int index)
		{
			if (index + 0x4000 < Colors.Length)
			{
				return Colors[index + 0x4000];
			}
			return 0;
		}

		public static short GetLandColor(int index)
		{
			if (index < Colors.Length)
			{
				return Colors[index];
			}
			return 0;
		}

		public static void SetItemColor(int index, short value)
		{
			Colors[index + 0x4000] = value;
		}

		public static void SetLandColor(int index, short value)
		{
			Colors[index] = value;
		}

		public static void Initialize()
		{
			var path = Files.GetFilePath("radarcol.mul");
			if (path != null)
			{
				using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					Colors = new short[fs.Length / 2];
					var gc = GCHandle.Alloc(Colors, GCHandleType.Pinned);
					var buffer = new byte[(int)fs.Length];
					_ = fs.Read(buffer, 0, (int)fs.Length);
					Marshal.Copy(buffer, 0, gc.AddrOfPinnedObject(), (int)fs.Length);
					gc.Free();
				}
			}
			else
			{
				Colors = new short[0x8000];
			}
		}

		public static void Save(string FileName)
		{
			using (var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Write))
			{
				using (var bin = new BinaryWriter(fs))
				{
					for (var i = 0; i < Colors.Length; ++i)
					{
						bin.Write(Colors[i]);
					}
				}
			}
		}

		public static void ExportToCSV(string FileName)
		{
			using (
				var Tex = new StreamWriter(
					new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite), Encoding.GetEncoding(1252)))
			{
				Tex.WriteLine("ID;Color");

				for (var i = 0; i < Colors.Length; ++i)
				{
					Tex.WriteLine(String.Format("0x{0:X4};{1}", i, Colors[i]));
				}
			}
		}

		public static void ImportFromCSV(string FileName)
		{
			if (!File.Exists(FileName))
			{
				return;
			}
			using (var sr = new StreamReader(FileName))
			{
				string line;
				var count = 0;
				while ((line = sr.ReadLine()) != null)
				{
					if ((line = line.Trim()).Length == 0 || line.StartsWith("#"))
					{
						continue;
					}
					if (line.StartsWith("ID;"))
					{
						continue;
					}
					++count;
				}
				Colors = new short[count];
			}
			using (var sr = new StreamReader(FileName))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if ((line = line.Trim()).Length == 0 || line.StartsWith("#"))
					{
						continue;
					}
					if (line.StartsWith("ID;"))
					{
						continue;
					}
					try
					{
						var split = line.Split(';');
						if (split.Length < 2)
						{
							continue;
						}

						var id = ConvertStringToInt(split[0]);
						var color = ConvertStringToInt(split[1]);
						Colors[id] = (short)color;
					}
					catch
					{ }
				}
			}
		}

		private static int ConvertStringToInt(string text)
		{
			int result;
			if (text.Contains("0x"))
			{
				var convert = text.Replace("0x", "");
				_ = Int32.TryParse(convert, NumberStyles.HexNumber, null, out result);
			}
			else
			{
				_ = Int32.TryParse(text, NumberStyles.Integer, null, out result);
			}

			return result;
		}
	}
}