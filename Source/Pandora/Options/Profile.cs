#region Header
// /*
//  *    2018 - Pandora - Profile.cs
//  */
#endregion

#region References
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Data;
using TheBox.MapViewer;
#endregion

namespace TheBox.Options
{
	[Serializable]
	/// <summary>
	/// Defines a profile for Pandora's Box
	/// </summary>
	public class Profile
	{
		#region Options
		private GeneralOptions m_General;
		private TravelOptions m_Travel;
		private HuesOptions m_Hues;
		private CommandsOptions m_Commands;
		private MobilesOptions m_Mobiles;
		private PropsOptions m_Props;
		private ServerOptions m_Server;
		private DecoOptions m_Deco;
		private ItemsOptions m_Items;
		private Notes m_Notes;
		private AdminOptions m_Admin;
		private LauncherOptions m_Launcher;
		private ScreenshotOptions m_Screenshots;

		/// <summary>
		///     Gets or sets the general options for this profile
		/// </summary>
		public GeneralOptions General { get => m_General; set => m_General = value; }

		/// <summary>
		///     Gets or sets travel related options
		/// </summary>
		public TravelOptions Travel { get => m_Travel; set => m_Travel = value; }

		/// <summary>
		///     Gets or sets the hues options
		/// </summary>
		public HuesOptions Hues { get => m_Hues; set => m_Hues = value; }

		/// <summary>
		///     Gets or sets the commands options
		/// </summary>
		public CommandsOptions Commands { get => m_Commands; set => m_Commands = value; }

		/// <summary>
		///     Gets or sets options related to mobiles
		/// </summary>
		public MobilesOptions Mobiles { get => m_Mobiles; set => m_Mobiles = value; }

		/// <summary>
		///     Gets or sets options related to properties
		/// </summary>
		public PropsOptions Props { get => m_Props; set => m_Props = value; }

		/// <summary>
		///     Gets or sets BoxServer options
		/// </summary>
		public ServerOptions Server { get => m_Server; set => m_Server = value; }

		/// <summary>
		///     Gets or sets the deco options
		/// </summary>
		public DecoOptions Deco { get => m_Deco; set => m_Deco = value; }

		/// <summary>
		///     Gets or sets the options for the Items tab
		/// </summary>
		public ItemsOptions Items { get => m_Items; set => m_Items = value; }

		/// <summary>
		///     Gets or sets the notes collection
		/// </summary>
		public Notes Notes { get => m_Notes; set => m_Notes = value; }

		/// <summary>
		///     Gets or sets admin options
		/// </summary>
		public AdminOptions Admin { get => m_Admin; set => m_Admin = value; }

		/// <summary>
		///     Gets or sets the launcher options
		/// </summary>
		public LauncherOptions Launcher { get => m_Launcher; set => m_Launcher = value; }

		/// <summary>
		///     Gets or sets the launcher options
		/// </summary>
		public ScreenshotOptions Screenshots { get => m_Screenshots; set => m_Screenshots = value; }
		#endregion

		/// <summary>
		///     Creates a new Profile object
		/// </summary>
		public Profile()
		{
			m_Travel = new TravelOptions();
			m_General = new GeneralOptions();
			m_Hues = new HuesOptions();
			m_Commands = new CommandsOptions();
			m_Mobiles = new MobilesOptions();
			m_Props = new PropsOptions();
			m_Server = new ServerOptions();
			m_Deco = new DecoOptions();
			m_Items = new ItemsOptions();
			m_Notes = new Notes();
			m_Admin = new AdminOptions();
			m_Launcher = new LauncherOptions();
			m_Screenshots = new ScreenshotOptions();
		}

		private string m_Name = "Default";
		private string m_Language = "English";
		private string m_CustomClient;
		private string m_DefaultFolder;

		/// <summary>
		///     Gets a list of all the existing profiles
		/// </summary>
		public static StringCollection ExistingProfiles
		{
			get
			{
				var profilesFolder = ProfileManager.ProfilesFolder;
				var list = new StringCollection();

				if (Directory.Exists(profilesFolder))
				{
					var profiles = Directory.GetDirectories(profilesFolder);

					var index = profilesFolder.Length + 1;

					foreach (var pro in profiles)
					{
						_ = list.Add(pro.Substring(index, pro.Length - index));
					}
				}

				return list;
			}
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name of the profile
		/// </summary>
		public string Name { get => m_Name; set => m_Name = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the language used by this instance of Pandora
		/// </summary>
		public string Language { get => m_Language; set => m_Language = value; }

		public string CustomClient
		{
			get => m_CustomClient;
			set
			{
				if (value == null || File.Exists(value))
				{
					m_CustomClient = value;

					Utility.CustomClientPath = m_CustomClient;
				}
			}
		}

		public string DefaultFolder
		{
			get => m_DefaultFolder;
			set
			{
				if (value == null || Directory.Exists(value))
				{
					m_DefaultFolder = value;

					Ultima.Files.SetMulPath(value);
				}
			}
		}

		/// <summary>
		///     Gets the base folder for this profile
		/// </summary>
		public string BaseFolder => Path.Combine(ProfileManager.ProfilesFolder, m_Name);

		private ButtonIndex m_ButtonIndex;

		[XmlIgnore]
		/// <summary>
		/// Gets the ButtonIndex provider
		/// </summary>
		public ButtonIndex ButtonIndex
		{
			get
			{
				if (m_ButtonIndex == null)
				{
					m_ButtonIndex = ButtonIndex.Load();

					if (m_ButtonIndex == null)
					{
						m_ButtonIndex = new ButtonIndex();
					}
				}
				return m_ButtonIndex;
			}
		}

		#region Methods
		/// <summary>
		///     Resets the Maps folder by deleting it and creating it again
		/// </summary>
		private void ResetMaps()
		{
			var MapsFolder = Path.Combine(BaseFolder, "Maps");

			if (Directory.Exists(MapsFolder))
			{
				try
				{
					Directory.Delete(MapsFolder);
				}
				catch
				{ }
			}

			if (!Directory.Exists(MapsFolder))
			{
				_ = Directory.CreateDirectory(MapsFolder);
			}
		}

		/// <summary>
		///     Generates the map images used for the world map
		/// </summary>
		/// <param name="bar">A progress bar that can be used to display progress</param>
		public void GenerateMaps(ProgressBar bar)
		{
			ResetMaps();

			Pandora.Log.WriteEntry(String.Format("Profile {0} is generating the images for world map", m_Name));

			var count = 0;
			foreach (var b in m_Travel.EnabledMaps)
			{
				if (b)
				{
					count++;
				}
			}

			if (count == 0)
			{
				Pandora.Log.WriteEntry("No maps have been enabled. Skipping.");
				return;
			}

			if (bar != null)
			{
				bar.Minimum = 0;
				bar.Maximum = count * 2;
				bar.Step = 1;
				bar.Value = 0;
			}

			for (var i = 0; i < m_Travel.MapCount; i++)
			{
				if (m_Travel.EnabledMaps[i])
				{
					// Enabled
					var scales = MapViewer.MapViewer.MapScale.Sixteenth;
					var scaleb = MapViewer.MapViewer.MapScale.Eigth;

					if (i == 4)
					{
						scales = MapViewer.MapViewer.MapScale.Fourth;
						scaleb = MapViewer.MapViewer.MapScale.Half;
					}
					else if (i > 1)
					{
						scales = MapViewer.MapViewer.MapScale.Eigth;
						scaleb = MapViewer.MapViewer.MapScale.Fourth;
					}

					var FileSmall = String.Format("map{0}small.jpg", i);
					var FileBig = String.Format("map{0}big.jpg", i);

					try
					{
						bar.Value++;
						MapViewer.MapViewer.ExtractMap(
							(Maps)i,
							scales,
							Path.Combine(BaseFolder, String.Format("Maps{0}{1}", Path.DirectorySeparatorChar, FileSmall)));
						bar.Value++;
						MapViewer.MapViewer.ExtractMap(
							(Maps)i,
							scaleb,
							Path.Combine(BaseFolder, String.Format("Maps{0}{1}", Path.DirectorySeparatorChar, FileBig)));
						Pandora.Log.WriteEntry(String.Format("Images for map {0} generated correctly", i));
					}
					catch (Exception err)
					{
						Pandora.Log.WriteError(err, String.Format("Couldn't extract images for map {0}: map disabled in the profile", i));
						_ = MessageBox.Show(
							String.Format(
								"An error has occurred and map {0} has been disabled in this profile. Please review the log for further information on the error.",
								i));

						m_Travel.EnabledMaps[i] = false;
					}
				}
				else
				{
					// Disabled
					Pandora.Log.WriteEntry(String.Format("Map {0} is disabled. Skipping.", m_Travel.MapNames[i]));
				}
			}
		}

		/// <summary>
		///     Saves the profile and all the options
		/// </summary>
		public void Save()
		{
			if (!Directory.Exists(BaseFolder))
			{
				_ = Directory.CreateDirectory(BaseFolder);
			}

			var file = Path.Combine(BaseFolder, "Profile.xml");

			var serializer = new XmlSerializer(typeof(Profile));
			var stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
			serializer.Serialize(stream, this);
			stream.Close();

			Pandora.Log.WriteEntry(String.Format("Profile {0} save succesfully", m_Name));
		}

		/// <summary>
		///     Loads a profile from its folder
		/// </summary>
		/// <param name="name">The profile name</param>
		/// <returns>The profile loaded. Null if the profile was not found</returns>
		public static Profile Load(string name)
		{
			var file = Path.Combine(Path.Combine(ProfileManager.ProfilesFolder, name), "Profile.xml");

			if (!File.Exists(file))
			{
				throw new FileNotFoundException(String.Format("Profile {0} not found.", name), file);
			}

			Pandora.Log.WriteEntry(String.Format("Reading profile {0}", name));
			FileStream stream = null;
			Profile p = null;

			try
			{
				var serializer = new XmlSerializer(typeof(Profile));
				stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				p = (Profile)serializer.Deserialize(stream);
				stream.Close();

				Pandora.Log.WriteEntry("Profile read succesfully");

				// Set static options
				Utility.CustomClientPath = p.CustomClient;
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, String.Format("Can't read profile {0}", name));
			}

			// Close the already closed stream if there is no error... Can be better ;) - Tarion
			if (stream != null)
			{
				stream.Close();
			}

			if (p != null)
			{
				p.ValidateMaps();
			}

			return p;
		}

		/// <summary>
		///     Ensures the map arrays are updated for the current version
		/// </summary>
		private void ValidateMaps()
		{
			if (m_Travel.EnabledMaps.Length == m_Travel.MapCount)
			{
				return;
			}

			var names = new string[m_Travel.MapCount];
			var enabled = new bool[m_Travel.MapCount];

			for (var i = 0; i < m_Travel.MapNames.Length; i++)
			{
				names[i] = m_Travel.MapNames[i];
				enabled[i] = m_Travel.EnabledMaps[i];
			}

			for (var i = m_Travel.MapNames.Length; i < m_Travel.MapCount; i++)
			{
				names[i] = m_Travel.DefaultMaps[i];
				enabled[i] = false;
			}

			m_Travel.MapNames = names;
			m_Travel.EnabledMaps = enabled;

			Pandora.Log.WriteEntry("Succesfully updated map count");
		}

		/// <summary>
		///     Creates the datafiles for the default locations
		/// </summary>
		public void CreateMapFiles()
		{
			if (!Travel.CustomMaps)
			{
				var res = "Data.map{0}.xml";
				var dest = Path.Combine(BaseFolder, "Locations");

				Utility.EnsureDirectory(dest);

				dest = Path.Combine(dest, "map{0}.xml");

				// Import default files
				var asm = Pandora.DataAssembly;

				for (var i = 0; i < 5; i++)
				{
					var stream = asm.GetManifestResourceStream(String.Format(res, i));
					var fStream = new FileStream(String.Format(dest, i), FileMode.Create, FileAccess.Write, FileShare.Read);

					var data = new byte[stream.Length];

					_ = stream.Read(data, 0, (int)stream.Length);

					fStream.Write(data, 0, data.Length);

					stream.Close();
					fStream.Flush();
					fStream.Close();
				}
			}
		}

		private static readonly string[] m_EmbeddedData =
			{"BoxData.xml", "RandomTiles.xml", "PropsData.xml", "Skills.ini", "HueGroups.xml"};

		/// <summary>
		///     Creates the datafiles
		/// </summary>
		public void CreateData()
		{
			foreach (var data in m_EmbeddedData)
			{
				var dest = Path.Combine(BaseFolder, data);
				var resource = String.Format("Data.{0}", data);

				Utility.ExtractEmbeddedResource(Pandora.DataAssembly, resource, dest);
			}
		}

		public static void DeleteProfile(string profile)
		{
			var folder = Path.Combine(ProfileManager.ProfilesFolder, profile);

			if (Directory.Exists(folder))
			{
				try
				{
					Directory.Delete(folder, true);
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, "Couldn't delete profile {0}.", profile);
					_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.DelProfileErr"]);
				}
			}
		}
		#endregion
	}
}
