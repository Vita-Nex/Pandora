#region Header
// /*
//  *    2018 - Pandora - ScreenshotOptions.cs
//  */
#endregion

#region References
using System;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using TheBox.Common;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Summary description for ScreenshotOptions.
	/// </summary>
	public class ScreenshotOptions
	{
		[XmlIgnore]
		/// <summary>
		/// Gets or sets the base folder for the screenshots
		/// </summary>
		public string BaseFolder
		{
			get
			{
				if (CustomFolder == null)
				{
					var path = Path.Combine(Pandora.Profile.BaseFolder, "Screenshots");

					Utility.EnsureDirectory(path);

					return path;
				}

				Utility.EnsureDirectory(CustomFolder);

				return CustomFolder;
			}
			set { CustomFolder = value; }
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the custom folder
		/// </summary>
		public string CustomFolder { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the base name for the screenshots files
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     Converts an integer to a string representation
		/// </summary>
		/// <param name="value">The integer to convert to string</param>
		/// <returns></returns>
		private string ConvertToString(int value)
		{
			var count = value / 10 + 1;

			if (count > 3)
				return value.ToString();

			var sb = new StringBuilder("0000", 4);
			sb.Remove(0, count);
			sb.Append(value);

			return sb.ToString();
		}

		/// <summary>
		///     Gets the file name for the screenshot given the index
		/// </summary>
		/// <param name="index">The index of the screenshot</param>
		/// <returns>The file name for the speicified index</returns>
		private string GetFileName(int index)
		{
			return string.Format("{0}{1}.jpg", Name, ConvertToString(index));
		}

		/// <summary>
		///     Gets the next available screenshot name
		/// </summary>
		private string NextScreenshotName
		{
			get
			{
				var files = new StringCollection();
				files.AddRange(Directory.GetFiles(BaseFolder, string.Format("{0}*.jpg", Name)));

				var index = 1;

				while (files.Contains(Path.Combine(BaseFolder, GetFileName(index))))
				{
					if (index < int.MaxValue)
					{
						index++;
					}
					else
					{
						Pandora.Log.WriteError(null, "Too many screenshots");
						return "DeleteSomeScreenshotsSilly.jpg";
					}
				}

				return GetFileName(index);
			}
		}

		/// <summary>
		///     Captures a screenshot of the UO window
		/// </summary>
		public void Capture()
		{
			var img = ScreenCapture.Capture();

			if (img == null)
			{
				Pandora.Log.WriteEntry("Screenshot attempt failed");
				return;
			}

			var file = Path.Combine(BaseFolder, NextScreenshotName);

			try
			{
				img.Save(file, ImageFormat.Jpeg);
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't save a screenshot to disk");
			}

			img.Dispose();
		}
	}
}