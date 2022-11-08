#region Header
// /*
//  *    2018 - Pandora - ProfileManager.cs
//  */
#endregion

#region References
using System;
using System.IO;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Forms;
using TheBox.Forms.ProfileWizard;
using TheBox.Options;
#endregion

namespace TheBox
{
	/// <summary>
	///     Class to handle the Profilemanagement
	/// </summary>
	public class ProfileManager
	{
		// Issue 28:  	 Refactoring Pandora.cs - Tarion
		// This whole class contains code from Pandora.cs ans some other code from the refactoring

		private readonly ISplash _splash;

		/*
		private static ProfileManager instance = null;

		public static ProfileManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ProfileManager();
				}

				return instance;
			}
		}
		*/

		// Maybe a solution
		//public event EventHandler CreateNewProfile;

		public bool ProfileLoaded => Profile != null;

		/// <summary>
		///     Gets the profile currently loaded
		/// </summary>
		public Profile Profile { get; private set; }

		/// <summary>
		///     Gets the location of the Profiles folder for this machine
		/// </summary>
		private static string profilesFoler = String.Empty;

		public static string ProfilesFolder
		{
			get
			{
				// Tarion: speed up the property by caching the folder in a local variable
				if (profilesFoler == String.Empty)
				{
					var folder = Path.Combine(Pandora.ApplicationDataFolder, "Profiles");

					Utility.EnsureDirectory(folder);
					profilesFoler = folder;
				}

				return profilesFoler;
			}
		}

		/// <summary>
		///     Gets or sets the default profile
		/// </summary>
		public string DefaultProfile
		{
			get
			{
				var ini = Path.Combine(Pandora.ApplicationDataFolder, "Pandora.ini");

				if (File.Exists(ini))
				{
					var reader = new StreamReader(ini);

					try
					{
						var defaultprofile = reader.ReadLine();
						reader.Close();

						var args = defaultprofile.Split('=');

						if (args.Length == 2 && args[0].ToLower() == "defaultprofile")
						{
							if (args[1].Length > 0)
							{
								return args[1];
							}

							return null;
						}
					}
					catch
					{ }
				}

				return null;
			}
			set
			{
				var ini = Path.Combine(Pandora.ApplicationDataFolder, "Pandora.ini");

				var writer = new StreamWriter(ini);

				writer.WriteLine("DefaultProfile={0}", value);

				writer.Close();
			}
		}

		public string[] ProfileNames
		{
			get
			{
				var profileDirs = Directory.GetDirectories(ProfilesFolder);

				var pnames = new string[profileDirs.Length];

				for (var i = 0; i < profileDirs.Length; i++)
				{
					var items = profileDirs[i].Split(Path.DirectorySeparatorChar);
					pnames[i] = items[items.Length - 1];
				}

				return pnames;
			}
		}

		/// <summary>
		///     Gets an array of string representing the names of the existing profiles
		/// </summary>
		public string[] ExistingProfiles
		{
			get
			{
				var dirs = Directory.GetDirectories(ProfilesFolder);

				var profiles = new string[dirs.Length];

				for (var i = 0; i < dirs.Length; i++)
				{
					var path = dirs[i].Split(Path.DirectorySeparatorChar);

					profiles[i] = path[path.Length - 1];
				}

				return profiles;
			}
		}

		public ProfileManager(ISplash splash)
		{
			_splash = splash;
		}

		public void CreateNewProfile()
		{
			// Temporarly deisabled
			//_context.MainForm = null;

			if (Pandora.BoxForm != null)
			{
				Pandora.BoxForm.Close();
				Pandora.BoxForm.Dispose();
			}

			// Temporarly deisabled
			//_context.MakeNewProfile();
		}

		/// <summary>
		///     Closes Pandora's Box and creates a new profile
		/// </summary>
		public void CreateNewProfile(string language)
		{
			var profile = new Profile
			{
				Language = language
			};
			// TODO: Display GUI to create a new profile. 
			var wiz = new ProfileWizard(profile);
			if (wiz.ShowDialog() != DialogResult.OK)
			{
				_splash.Close();
				return;
			}
			profile = wiz.Profile;

			if (wiz.UseProfileAsDefault)
			{
				DefaultProfile = wiz.Profile.Name;
			}

			profile.Save();
			profile.CreateData();
			Profile = profile;
		}

		public void LoadProfile(string name)
		{
			Profile = Profile.Load(name);
		}

		/// <summary>
		///     Delete the current profile
		/// </summary>
		public void DeleteCurrentProfile()
		{
			// Have to be refactored when we have a more global GUI handling - Tarion
			// Temporarly deisabled
			//_context.MainForm = null;

			if (Pandora.BoxForm != null)
			{
				Pandora.BoxForm.Close();
				Pandora.BoxForm.Dispose();
			}

			Profile.DeleteProfile(Profile.Name);
			Profile = null;

			// Temporarly deisabled
			//_context.DoProfile();
		}

		/// <summary>
		///     Imports a new profile
		/// </summary>
		/// <param name="filename">The filename to the .pbp file</param>
		/// <returns>True if the profile has been imported and loaded successfully</returns>
		public bool ImportProfile(string filename)
		{
			Pandora.Log.WriteEntry("Importing Profile...");
			_splash.SetStatusText("Importing profile");

			Profile p = null;

			try
			{
				p = ProfileIO.Load(filename);
			}
			catch (Exception err)
			{
				_ = MessageBox.Show(err.ToString());
			}

			if (p == null)
			{
				return false;
			}
			Profile = p;

			var run = false;

			if (Pandora.ExistingInstance != null)
			{
				// Already running: Close?

				if (MessageBox.Show(
						null,
						"Another instance of Pandora's Box is currently running. Would you like to close it and load the profile you have just imported?",
						"Profile import succesful",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (Pandora.ExistingInstance != null)
					{
						Pandora.ExistingInstance.Close();
					}

					run = true;
				}
			}
			else
			{
				run = true;
			}

			if (run)
			{
				_ = MessageBox.Show("Profile imported correctly.");
			}

			if (!run)
			{
				Profile = null;
			}

			return run;
		}

		#region Profile Import/Export
		/// <summary>
		///     Exports a Pandora's Box profile
		/// </summary>
		/// <param name="p">The profile to export</param>
		public void ExportProfile()
		{
			var dlg = new SaveFileDialog
			{
				Filter = "Pandora's Box Profile (*.pbp)|*.pbp"
			};

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var pio = new ProfileIO(Profile);
				pio.Save(dlg.FileName);
			}

			dlg.Dispose();
		}

		/// <summary>
		///     Imports a profile from a PBP file
		/// </summary>
		/// <returns>The Profile object imported</returns>
		public Profile ImportProfile()
		{
			var dlg = new OpenFileDialog
			{
				Filter = "Pandora's Box Profile (*.pbp)|*.pbp"
			};
			Profile p = null;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				p = ProfileIO.Load(dlg.FileName);
			}

			dlg.Dispose();

			return p;
		}
		#endregion

		/// <summary>
		///     Moves the profiles from the old program file based profiles folder to the application data folder
		/// </summary>
		public void MoveOldProfiles()
		{
			#region Move Log.txt
			var log = Path.Combine(Pandora.Folder, "Log.txt");

			if (File.Exists(log))
			{
				_splash.SetStatusText("Removing old log file");
				try
				{
					File.Delete(log);
				}
				catch
				{ }
			}
			#endregion

			#region Move INI file
			var iniFile = Path.Combine(Pandora.Folder, "Pandora.ini");

			if (File.Exists(iniFile))
			{
				_splash.SetStatusText("Removing old ini file");

				var newIni = Path.Combine(Pandora.ApplicationDataFolder, "Pandora.ini");

				if (!File.Exists(newIni))
				{
					try
					{
						File.Move(iniFile, newIni);
						Pandora.Log.WriteEntry("Ini file moved to application data folder");
					}
					catch (Exception err)
					{
						Pandora.Log.WriteError(err, "Couldn't move ini file from {0} to {1}", iniFile, newIni);
					}
				}
				else
				{
					try
					{
						File.Delete(iniFile);
						Pandora.Log.WriteEntry("Ini file {0} deleted", iniFile);
					}
					catch (Exception err)
					{
						Pandora.Log.WriteError(err, "Couldn't delete ini file {0}", iniFile);
					}
				}
			}
			#endregion

			var oldFolder = Path.Combine(Pandora.Folder, "Profiles");

			if (!Directory.Exists(oldFolder))
			{
				return;
			}

			var profiles = Directory.GetDirectories(oldFolder);

			if (profiles.Length == 0)
			{
				return;
			}

			_splash.SetStatusText("Moving old profiles");

			Pandora.Log.WriteEntry("Found {0} profiles in the old profiles folder", profiles.Length);

			foreach (var profile in profiles)
			{
				var name = Utility.GetDirectoryName(profile);
				var newFolder = Path.Combine(ProfilesFolder, name);

				var index = 1; // Adjust name if there's already a match
				while (Directory.Exists(newFolder))
				{
					newFolder = Path.Combine(ProfilesFolder, String.Format("{0} {1}", name, index++));
				}

				try
				{
					if (Utility.CopyDirectory(profile, newFolder))
					{
						Pandora.Log.WriteEntry("Profile {0} copied from {1} to {2}", name, profile, newFolder);

						// Profile copied. Now delete.
						try
						{
							Directory.Delete(profile, true);
							Pandora.Log.WriteEntry("Old profile folder deleted: {0}", profile);
						}
						catch (Exception err)
						{
							Pandora.Log.WriteError(err, "Couldn't delete old profile folder: {0}", profile);
						}
					}
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, "Couldn't move profile {0} to {1}", name, newFolder);
				}
			}

			// Finally delete folder (if empty)
			try
			{
				if (Directory.GetDirectories(oldFolder).Length == 0)
				{
					Directory.Delete(oldFolder, true);
					Pandora.Log.WriteEntry("Deleted old profile directory: {0}", oldFolder);
				}
				else
				{
					Pandora.Log.WriteEntry("Can't delete profiles folder because some profiles hasn't been moved");
				}
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't delete old profiles folder: {0}", oldFolder);
			}
		}
	}
}
