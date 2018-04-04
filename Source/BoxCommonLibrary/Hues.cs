#region Header
// /*
//  *    2018 - BoxCommonLibrary - Hues.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
#endregion

namespace TheBox.Mul
{
	/// <summary>
	///     Summary description for Hues.
	/// </summary>
	public class Hues
	{
		[DllImport("kernel32", SetLastError = true)]
		private static extern unsafe bool ReadFile(
			IntPtr hFile, // handle to file
			void* pBuffer, // data buffer
			int NumberOfBytesToRead, // number of bytes to read
			int* pNumberOfBytesRead, // number of bytes read
			int Overlapped // overlapped buffer
		);

		private readonly HueGroup[] m_Groups;

		/// <summary>
		///     Gets the hue groups
		/// </summary>
		public HueGroup[] Groups { get { return m_Groups; } }

		/// <summary>
		///     Creates an empty Hues object
		/// </summary>
		private Hues()
		{
			m_Groups = new HueGroup[375];
		}

		/// <summary>
		///     Loads a Hues object from a file
		/// </summary>
		/// <param name="FileName">The hues.mul file to read from</param>
		/// <returns>A Hues object</returns>
		public static Hues Load(string FileName)
		{
			if (!File.Exists(FileName))
				return null;

			try
			{
				var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				var reader = new BinaryReader(stream, Encoding.ASCII);

				var hues = new Hues();

				for (var i = 0; i < 375; i++)
				{
					hues.m_Groups[i] = HueGroup.Read(reader);
				}
				stream.Close();

				return hues;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		///     Gets or sets a hue
		/// </summary>
		public Hue this[int index]
		{
			get
			{
				if (index < 1 || index > 3000)
					return null;

				index--;

				var group = index / 8;
				var entry = index % 8;

				return m_Groups[group].HueList[entry];
			}
			set
			{
				if (index < 1 || index > 3000)
					return;

				var group = index / 8;
				var entry = index & 8;

				m_Groups[group].HueList[entry] = value;
			}
		}
	}

	#region Internal Data
	/// <summary>
	///     A group of 8 hues
	/// </summary>
	public class HueGroup
	{
		private int m_Header;

		/// <summary>
		///     Gets the list of hues in this groupd
		/// </summary>
		public Hue[] HueList { get; set; }

		/// <summary>
		///     Reads a HueGroup
		/// </summary>
		/// <param name="reader">The reader of the data stream</param>
		/// <returns>A HueGroupd item</returns>
		public static HueGroup Read(BinaryReader reader)
		{
			var group = new HueGroup();

			group.m_Header = reader.ReadInt32();
			group.HueList = new Hue[8];

			for (var i = 0; i < 8; i++)
				group.HueList[i] = Hue.Read(reader);

			return group;
		}
	}

	/// <summary>
	///     A UO Hue
	/// </summary>
	public class Hue
	{
		private short m_TableStart;
		private short m_TableEnd;
		private char[] m_Name;

		/// <summary>
		///     Gets or sets the color table for the hue
		/// </summary>
		public short[] ColorTable { get; set; }

		/// <summary>
		///     Reads a Hue
		/// </summary>
		/// <param name="reader">The data reader</param>
		/// <returns>The hue read</returns>
		public static Hue Read(BinaryReader reader)
		{
			var hue = new Hue();

			hue.ColorTable = new short[32];
			hue.m_Name = new char[20];

			for (var i = 0; i < 32; i++)
				hue.ColorTable[i] = reader.ReadInt16();

			hue.m_TableStart = reader.ReadInt16();
			hue.m_TableEnd = reader.ReadInt16();

			hue.m_Name = reader.ReadChars(20);

			return hue;
		}

		/// <summary>
		///     Gets or sets the
		/// </summary>
		public string Name
		{
			get { return new string(m_Name); }
			set
			{
				var name = value;
				if (name.Length > 20)
				{
					name.Substring(0, 20);
				}

				m_Name = name.ToCharArray();
			}
		}

		/// <summary>
		///     Writes the hue to a stream
		/// </summary>
		/// <param name="writer">The writer used to write the hue</param>
		private void Write(BinaryWriter writer)
		{
			for (var i = 0; i < 32; i++)
				writer.Write(ColorTable[i]);

			writer.Write(m_TableStart);
			writer.Write(m_TableEnd);

			for (var i = 0; i < 20; i++)
				writer.Write(m_Name[i]);
		}

		/// <summary>
		///     Converts a RGB 555 value to a Color object
		/// </summary>
		/// <param name="rgb555color">The RGB 555 value to convert</param>
		/// <returns>A Color corresponding to the value</returns>
		public static Color ToColor(short rgb555color)
		{
			var Red = ((rgb555color >> 10) & 0x1F) * 8;
			var Green = ((rgb555color >> 5) & 0x1F) * 8;
			var Blue = (rgb555color & 0x1F) * 8;

			return Color.FromArgb(Red, Green, Blue);
		}

		/// <summary>
		///     Gets a spectrum corresponding to this hue
		/// </summary>
		/// <param name="imgSize">The size of the spectrum</param>
		/// <returns>A 32x1 bitmap with the spectrum</returns>
		public Bitmap GetSpectrum(Size imgSize)
		{
			var bmp = new Bitmap(128, 10);

			for (var i = 0; i < 32; i++)
			{
				for (var x = 0; x < 4; x++)
				for (var y = 0; y < 10; y++)
				{
					bmp.SetPixel(i * 4 + x, y, ToColor(ColorTable[i]));
				}
			}

			var bmp1 = new Bitmap(bmp, imgSize);

			return bmp1;
		}
	}
	#endregion
}