#region Header
// /*
//  *    2018 - BoxCommonLibrary - MulManager.cs
//  */
#endregion

#region References
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Microsoft.Win32;

using TheBox.CustomMessageBox;

// Issues 43 - Problems when the client path isn't found - http://code.google.com/p/pandorasbox3/issues/detail?id=43 - Smjert
#endregion

// Issues 43 - End

namespace TheBox.Common
{
	/// <summary>
	///     Provides access to mul file locations
	/// </summary>
	public class MulManager
	{
		private static readonly string[] m_Files =
		{
			"hues.mul", "radarcol.mul", "map0.mul", "mapdif0.mul", "mapdifl0.mul", "mapdif1.mul", "mapdifl1.mul", "map2.mul",
			"mapdif2.mul", "mapdifl2.mul", "map3.mul", "mapdif3.mul", "mapdifl3.mul", "staidx0.mul", "statics0.mul",
			"stadif0.mul", "stadifl0.mul", "stadifi0.mul", "stadif1.mul", "stadifl1.mul", "stadifi1.mul", "staidx2.mul",
			"statics2.mul", "stadif2.mul", "stadifl2.mul", "stadifi2.mul", "staidx3.mul", "statics3.mul", "stadif3.mul",
			"stadifl3.mul", "stadifi3.mul", "artidx.mul", "art.mul", "anim.idx", "anim.mul", "anim2.idx", "anim2.mul",
			"anim3.idx", "anim3.mul", "body.def", "bodyconv.def", "gumpidx.mul", "gumpart.mul", "verdata.mul", "map4.mul",
			"mapdif4.mul", "mapdifl4.mul", "staidx4.mul", "statics4.mul", "stadif4.mul", "stadifl4.mul", "stadifi4.mul",
			"anim4.idx", "anim4.mul",
			// UOP
			"artLegacyMUL.uop", "soundLegacyMUL.uop", "gumpartLegacyMUL.uop",
			// UOP MAPS
			"map0LegacyMUL.uop", "map0xLegacyMUL.uop", //
			"map1LegacyMUL.uop", "map1xLegacyMUL.uop", //
			"map2LegacyMUL.uop", "map2xLegacyMUL.uop", //
			"map3LegacyMUL.uop", //
			"map4LegacyMUL.uop", //
			"map5LegacyMUL.uop", "map5xLegacyMUL.uop"
		};

		// Issues 43 - Problems when the client path isn't found - http://code.google.com/p/pandorasbox3/issues/detail?id=43 - Smjert
		public static bool FixClientPath()
		{
			var reply = ErrMsgBox.Show(
				"The client path has not been found, maybe your registry key is corrupted or is missing, choose a way to fix it:" +
				"\n\n Yes: Pandora will try to search where you installed the client automatically" +
				"\n No: You manually specify the client path",
				"Client path not found",
				MessageBoxButtons.YesNo);

			if (reply == DialogResult.Yes)
			{
				var directory = @"C:\\Program Files\\EA Games\\Ultima Online 2D Client\\";

				if (Directory.Exists(directory))
				{
					if (File.Exists(directory + @"\client.exe"))
					{
						WriteRegistryKey(directory);
					}
				}
				else
				{
					directory = @"C:\Programmi\EA Games\Ultima Online 2D Client";
					if (Directory.Exists(directory + @"\client.exe"))
					{
						WriteRegistryKey(directory);
					}
					else
					{
						_ = ErrMsgBox.Show(
							"The automatic search failed to find the folder, please specify the path manually",
							"Folder not found");
						if (!SetCustomPath())
						{
							return false;
						}
					}
				}
				return true;
			}
			if (reply == DialogResult.No && SetCustomPath())
			{
				return true;
			}

			return false;
		}

		private static bool SetCustomPath()
		{
			var fdialog = new FolderBrowserDialog();
			var result = fdialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (Directory.Exists(fdialog.SelectedPath) && File.Exists(fdialog.SelectedPath + @"\client.exe"))
				{
					WriteRegistryKey(fdialog.SelectedPath);
					return true;
				}
				result = ErrMsgBox.Show(
					"You selected the wrong folder, do you want to retry?",
					"Wrong Folder",
					MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					return SetCustomPath();
				}
			}
			return false;
		}

		private static void WriteRegistryKey(string path)
		{
			var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Origin Worlds Online\Ultima Online\1.0");

			key.SetValue("ExePath", path + @"\client.exe");
			key.SetValue("InstCDPath", path);
			key.SetValue("PatchExePath", path + @"\uopatch.exe");
			key.SetValue("StartExeParg", path + @"\uo.exe");
		}
		// Issues 43 - End

		/// <summary>
		///     Gets the files supported by Pandora's Box
		/// </summary>
		public string[] SupportedFiles => m_Files;

		private readonly string m_2DFolder;
		private readonly string m_3DFolder;
		private readonly NameValueCollection m_Table;

		/// <summary>
		///     Creates a new MulManager object reading initial data from the registry
		/// </summary>
		public MulManager()
		{
			m_2DFolder = GetExePath("Ultima Online");
			m_3DFolder = GetExePath("Ultima Online Third Dawn");

			// Issues 43 - Problems when the client path isn't found - http://code.google.com/p/pandorasbox3/issues/detail?id=43 - Smjert
			if (m_2DFolder == null && !FixClientPath())
			{
				_ = ErrMsgBox.Show("Impossible to load game files", "Error");
				Environment.Exit(1);
			}
			// Issues 43 - End

			m_Table = new NameValueCollection();
		}

		/// <summary>
		///     Gets or sets the custom UO installation folder
		/// </summary>
		[XmlAttribute]
		public string CustomFolder { get; set; }

		/// <summary>
		///     Gets the default UO folder as found in the registry
		/// </summary>
		[XmlIgnore]
		public string DefaultFolder
		{
			get
			{
				if (m_2DFolder != null)
				{
					return m_2DFolder;
				}
				if (m_3DFolder != null)
				{
					return m_3DFolder;
				}

				return null;
			}
		}

		/// <summary>
		///     Gets or sets the current list of key/values
		/// </summary>
		public string[] Table
		{
			get
			{
				if (m_Table.Keys.Count == 0)
				{
					return null;
				}

				var nodes = new string[m_Table.Keys.Count * 2];

				for (var i = 0; i < nodes.Length; i += 2)
				{
					var key = m_Table.Keys[i / 2];
					var file = m_Table[key];

					nodes[i] = key;
					nodes[i + 1] = file;
				}

				return nodes;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					return;
				}

				for (var i = 0; i < value.Length; i += 2)
				{
					var key = value[i];
					var file = value[i + 1];

					m_Table.Add(key, file);
				}
			}
		}

		/// <summary>
		///     Gets the path to the UO exe from the registry
		/// </summary>
		/// <param name="subName">The class name of the UO installation</param>
		/// <returns>A path to the installation folder, null if none is found</returns>
		private static string GetExePath(string subName)
		{
			try
			{
				using (var key = Registry.LocalMachine.OpenSubKey(String.Format(@"SOFTWARE\Origin Worlds Online\{0}\1.0", subName)))
				{
					if (key == null)
					{
						return null;
					}

					if (!(key.GetValue("ExePath") is string v) || v.Length <= 0 || !File.Exists(v))
					{
						return null;
					}

					v = Path.GetDirectoryName(v);

					if (v == null)
					{
						return null;
					}

					return v;
				}
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		///     Gets the file corresponding to the specified file name
		/// </summary>
		[XmlIgnore]
		public string this[string multype]
		{
			get
			{
				multype = multype.ToLower();

				var file = m_Table[multype];

				if (file != null && File.Exists(file))
				{
					return file;
				}

				if (CustomFolder != null)
				{
					file = Path.Combine(CustomFolder, multype);

					if (File.Exists(file))
					{
						return file;
					}
				}

				if (m_2DFolder != null)
				{
					file = Path.Combine(m_2DFolder, multype);

					if (File.Exists(file))
					{
						return file;
					}
				}

				if (m_3DFolder != null)
				{
					file = Path.Combine(m_3DFolder, multype);

					if (File.Exists(file))
					{
						return file;
					}
				}

				return null;
			}
			set
			{
				multype = multype.ToLower();

				if (value == null)
				{
					m_Table.Remove(multype);
				}
				else if (File.Exists(value))
				{
					m_Table[multype] = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets a mul file, using string.Format() notation
		/// </summary>
		[XmlIgnore]
		public string this[string format, params object[] args]
		{
			get => this[String.Format(format, args)];
			set => this[String.Format(format, args)] = value;
		}
	}
}