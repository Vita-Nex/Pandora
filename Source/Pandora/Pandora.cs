#region Header
// /*
//  *    2018 - Pandora - Pandora.cs
//  */
#endregion

#region References
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

using LightCore;

using TheBox.BoxServer;
using TheBox.Common;
using TheBox.Controls;
using TheBox.Data;
using TheBox.Forms;
using TheBox.Localization;
using TheBox.Mul;
using TheBox.Options;
#endregion

namespace TheBox
{
	public class Pandora
	{
		#region Log
		/// <summary>
		///     Gets the Log provider for Pandora's Box
		/// </summary>
		public static BoxLog Log
		{
			get
			{
				if (m_Log == null)
				{
					m_Log = new BoxLog(Path.Combine(ApplicationDataFolder, "Log.txt"));
				}

				return m_Log;
			}
		}
		#endregion

		#region Map, Art, Hues, Props (Data & GUI)
		/// <summary>
		///     Gets or sets the Property manager panel
		/// </summary>
		public static PropManager Prop
		{
			set => m_Prop = value;
			get
			{
				if (m_Prop == null)
				{
					throw new NullReferenceException("Trying to access static field Pandora.Prop without initlizing it first.");
				}
				return m_Prop;
			}
		}

		/// <summary>
		///     Gets the MapViewer control used to display the map in Pandora's Box
		/// </summary>
		public static MapViewer.MapViewer Map
		{
			set => m_Map = value;
			get
			{
				if (m_Map == null)
				{
					throw new NullReferenceException("Trying to access the static field Pandora.Map without initializing it first.");
				}
				return m_Map;
			}
		}

		// Issue 31:  	 Pandora.Art exception on null - Tarion
		/// <summary>
		///     To check if the Art property is null
		/// </summary>
		public static bool ArtLoaded => m_Art != null;

		/// <summary>
		///     Gets or sets the ArtViewer control used to display the art in Pandora's Box
		/// </summary>
		public static ArtViewer.ArtViewer Art
		{
			set => m_Art = value;
			get
			{
				if (m_Art == null)
				{
					throw new NullReferenceException("Trying to access the static field Pandora.Art without initializing it first.");
				}
				return m_Art;
			}
		}

		/// <summary>
		///     Gets the loaded hues
		/// </summary>
		public static Hues Hues
		{
			get
			{
				if (m_Hues == null)
				{
					if (Profile.MulManager["hues.mul"] != null)
					{
						m_Hues = Hues.Load(Profile.MulManager["hues.mul"]);
					}
				}

				return m_Hues;
			}
		}
		#endregion

		#region Localization
		public static LocalizationHelper Localization
		{
			get
			{
				if (m_Localization == null)
				{
					m_Localization = new LocalizationHelper();
				}
				return m_Localization;
			}
		}
		#endregion

		#region ToolTip
		/// <summary>
		///     Gets the tool tip provider for this instance of Pandora
		/// </summary>
		public static ToolTip ToolTip
		{
			get
			{
				if (m_ToolTip == null)
				{
					m_ToolTip = new ToolTip
					{
						Active = true,
						ShowAlways = true
					};
				}

				return m_ToolTip;
			}
		}
		#endregion

		#region Local Variables
		/// <summary>
		///     The log provider for Pandora
		/// </summary>
		private static BoxLog m_Log;

		/// <summary>
		///     The MapViewer control
		/// </summary>
		private static MapViewer.MapViewer m_Map;

		/// <summary>
		///     The ArtViewer control
		/// </summary>
		private static ArtViewer.ArtViewer m_Art;

		/// <summary>
		///     The localization provider
		/// </summary>
		private static LocalizationHelper m_Localization;

		/// <summary>
		///     The working folder for the program
		/// </summary>
		private static string m_Folder;

		/// <summary>
		///     The loaded hues
		/// </summary>
		private static Hues m_Hues;

		/// <summary>
		///     The data provider for travel locations
		/// </summary>
		private static TravelAgent m_TravelAgent;

		/// <summary>
		///     The data provider for custom buttons
		/// </summary>
		private static ButtonManager m_ButtonManager;

		/// <summary>
		///     The tool tips provider
		/// </summary>
		private static ToolTip m_ToolTip;

		/// <summary>
		///     The BoxData holding the information about scripted objects
		/// </summary>
		private static BoxData m_BoxData;

		/// <summary>
		///     The list of scripted mobiles
		/// </summary>
		private static ScriptList m_Mobiles;

		/// <summary>
		///     The list of scripted items
		/// </summary>
		private static ScriptList m_Items;

		/// <summary>
		///     The property panel
		/// </summary>
		private static PropManager m_Prop;

		/// <summary>
		///     The spawn groups loaded by the profile
		/// </summary>
		private static SpawnGroups m_SpawnGroups;

		/// <summary>
		///     The context governing the application
		/// </summary>
		private static readonly StartingContext m_Context;

		/// <summary>
		///     The assembly containing general purpose data
		/// </summary>
		private static Assembly m_DataAssembly;

		/// <summary>
		///     The form used to manipulate builder structures on the server
		/// </summary>
		private static BuilderControl m_BuilderControl;

		/// <summary>
		///     The connection handler to the BoxServer
		/// </summary>
		private static BoxConnection m_BoxConnection;
		#endregion

		#region Misc properties and methods
		/// <summary>
		///     Gets the instance of Pandora that is already running
		/// </summary>
		public static Process ExistingInstance
		{
			get
			{
				// Issue 6:  	 Improve error management - Tarion
				// Catch a possible exception here and return null.
				try
				{
					_splash.SetStatusText("Searching existing instances");

					var current = Process.GetCurrentProcess();

					var processes = Process.GetProcessesByName(current.ProcessName);

					//Loop through the running processes in with the same name 
					foreach (var process in processes)
					{
						//Ignore the current process 
						if (process.Id != current.Id)
						{
							return process;
						}
					}
				}
				catch (Exception err)
				{
					Log.WriteError(err, "Error when enumerating instances");
				}

				return null;
			}
		}

		/// <summary>
		///     Gets the working folder for Pandora's Box
		/// </summary>
		public static string Folder
		{
			get
			{
				if (m_Folder == null)
				{
					var file = Environment.GetCommandLineArgs()[0];

					m_Folder = Path.GetDirectoryName(file);
				}

				return m_Folder;
			}
		}

		/// <summary>
		///     Gets the Box form
		/// </summary>
		public static IBoxForm BoxForm { get; set; }

		/// <summary>
		///     Gets the version of this assembly
		/// </summary>
		public static string Version => Application.ProductVersion;

		/// <summary>
		///     Sends text to UO automatically adding the \n at the end of the line
		/// </summary>
		/// <param name="text">The text that must be sent</param>
		/// <param name="UsePrefix">Specifies whether to send the command prefix in front of the text</param>
		// Issue 38:  	 Message when client not found - Tarion
		// Use SendToUO return value, and warn user if false
		// End Issue 38
		public static void SendToUO(string text, bool UsePrefix)
		{
			var success = false;

			if (Profile != null)
			{
				if (UsePrefix)
				{
					success = Utility.SendToUO(String.Format("{0}{1}\r\n", Profile.General.CommandPrefix, text));
				}
				else
				{
					success = Utility.SendToUO(String.Format("{0}\r\n", text));
				}
			}

			if (!success)
			{
				_ = MessageBox.Show(
					"Client handle not found. If UO is running, try to set Tools -> Options -> Advanced -> Use a custom client");
			}
		}

		public static void ClosePandora()
		{
			var process = Process.GetCurrentProcess();
			process.Kill();
		}

		/// <summary>
		///     Gets the assembly containing the program data
		/// </summary>
		public static Assembly DataAssembly
		{
			get
			{
				if (m_DataAssembly == null)
				{
					var filename = Path.Combine(Folder, "Data");
					filename = Path.Combine(filename, "Data.dll");

					if (!File.Exists(filename))
					{
						Log.WriteError(null, "Data file {0} doesn't exist", filename);
						throw new FileNotFoundException("A required file could not be found, please reinstall", filename);
					}

					m_DataAssembly = Assembly.LoadFile(filename);
				}

				return m_DataAssembly;
			}
		}

		/// <summary>
		///     Shows the Builder Control form
		/// </summary>
		public static void ShowBuilderControl()
		{
			if (m_BuilderControl == null)
			{
				m_BuilderControl = new BuilderControl();
			}

			m_BuilderControl.Visible = true;
		}

		/// <summary>
		///     Gets the location of the PB2 application data folder
		/// </summary>
		public static string ApplicationDataFolder
		{
			get
			{
				var folder = "State";

				Utility.EnsureDirectory(folder);

				return folder;
			}
		}
		#endregion

		#region Profile managment
		/// <summary>
		///     Gets the profile currently loaded
		/// </summary>
		//[Obsolete("ProfileManager.Profile should be used")]
		public static Profile Profile
			// Workaround, there are over 640 refferences... - Tarion
			=> _profileManager.Profile;

		/// <summary>
		///     Closes Pandora's Box and creates a new profile
		/// </summary>
		public static void CreateNewProfile()
		{
			Container.Resolve<ProfileManager>().CreateNewProfile();

			/* Now handled by ProfileManager
			m_Context.MainForm = null;

			if (m_TheBox != null)
			{
				m_TheBox.Close();
				m_TheBox.Dispose();
			}

			m_Context.MakeNewProfile();
			 * */
		}

		/// <summary>
		///     Closes the current application, deletes the current profile and restarts Pandora
		/// </summary>
		public static void DeleteCurrentProfile()
		{
			Container.Resolve<ProfileManager>().DeleteCurrentProfile();

			/* Now handled by ProfileManager
			// Have to be refactored when we have a more global GUI handling - Tarion
			m_Context.MainForm = null;

			if (m_TheBox != null)
			{
				m_TheBox.Close();
				m_TheBox.Dispose();
			}

			ProfileManager.Instance.DeleteCurrentProfile();
			m_Context.DoProfile();
			 * */
		}
		#endregion

		#region Data
		#region Travel Agent
		/// <summary>
		///     Gets or sets the travel data provider
		/// </summary>
		public static TravelAgent TravelAgent
		{
			get
			{
				if (m_TravelAgent == null)
				{
					Log.WriteEntry("Creating Travel Agent");
					m_TravelAgent = new TravelAgent();
				}

				return m_TravelAgent;
			}
			set => m_TravelAgent = value;
		}
		#endregion

		#region Button Manager
		/// <summary>
		///     Gets the data provider for custom buttons
		/// </summary>
		public static ButtonManager Buttons
		{
			get
			{
				if (m_ButtonManager == null)
				{
					m_ButtonManager = new ButtonManager();
				}

				return m_ButtonManager;
			}
		}
		#endregion

		#region BoxData, Mobiles and Items
		/// <summary>
		///     Gets or sets a new BoxData object
		/// </summary>
		public static BoxData BoxData
		{
			get
			{
				if (m_BoxData == null)
				{
					m_BoxData = BoxData.Load();
				}

				return m_BoxData;
			}
			set
			{
				m_BoxData = value;
				m_Mobiles = null;
				m_Items = null;
			}
		}

		/// <summary>
		///     Gets the object representing the scripted mobiles
		/// </summary>
		public static ScriptList Mobiles
		{
			get
			{
				if (m_BoxData == null)
				{
					m_BoxData = BoxData.Load();
				}

				if (m_Mobiles == null)
				{
					m_Mobiles = new ScriptList(m_BoxData.Mobiles);
					m_Mobiles.Saving += m_Mobiles_Saving;
				}

				return m_Mobiles;
			}
			set => m_Mobiles = value;
		}

		/// <summary>
		///     Handles the updating of the Mobiles list
		/// </summary>
		private static void m_Mobiles_Saving(object sender, EventArgs e)
		{
			m_BoxData.Mobiles = m_Mobiles.List;
			m_BoxData.Save();
		}

		/// <summary>
		///     Gets the object representing the scripted items
		/// </summary>
		public static ScriptList Items
		{
			get
			{
				if (m_BoxData == null)
				{
					m_BoxData = BoxData.Load();
				}

				if (m_Items == null)
				{
					m_Items = new ScriptList(m_BoxData.Items);
					m_Items.Saving += m_Items_Saving;
				}

				return m_Items;
			}
			set => m_Items = value;
		}

		/// <summary>
		///     Handles the updating of the Items list
		/// </summary>
		private static void m_Items_Saving(object sender, EventArgs e)
		{
			m_BoxData.Items = m_Items.List;
			m_BoxData.Save();
		}
		#endregion

		#region Spawn Groups
		/// <summary>
		///     Gets or sets the Spawn Groups for the current profile
		/// </summary>
		public static SpawnGroups SpawnGroups
		{
			get
			{
				if (m_SpawnGroups == null)
				{
					m_SpawnGroups = SpawnGroups.Load();
				}

				return m_SpawnGroups;
			}
			set
			{
				m_SpawnGroups = value;
				m_SpawnGroups.Save();
			}
		}
		#endregion

		#region Sounds
		/// <summary>
		///     The SoundData object providing information about UO Sounds
		/// </summary>
		private static SoundData m_SoundData;

		/// <summary>
		///     Gets the SoundData object providing information about the UO Sounds
		/// </summary>
		public static SoundData SoundData
		{
			get
			{
				if (m_SoundData == null)
				{
					var stream = DataAssembly.GetManifestResourceStream("Data.SoundData.xml");
					var serializer = new XmlSerializer(typeof(SoundData));
					m_SoundData = serializer.Deserialize(stream) as SoundData;
					stream.Close();

					/*SupportSound s = new SupportSound();
					s.StructureS = new List<GenericNode>();

					for(int i = 0; i < m_SoundData.Structure.Count; i++)
					{
						GenericNode n = m_SoundData.Structure[i] as GenericNode;
						s.StructureS.Add(n);
					}
					
					TextWriter w = new StreamWriter(@"C:\SoundData.xml");
					try
					{
					XmlSerializer ser = new XmlSerializer(typeof(SupportSound));
					
						ser.Serialize(w, s);
					}
					catch (System.Exception e)
					{
						MessageBox.Show(e.ToString());
					}
					
					w.Close();*/
				}

				return m_SoundData;
			}
		}
		#endregion

		#region Skills
		/// <summary>
		///     The skills list
		/// </summary>
		private static SkillsData m_Skills;

		/// <summary>
		///     Gets the skills list
		/// </summary>
		public static SkillsData Skills
		{
			get
			{
				if (m_Skills == null)
				{
					m_Skills = new SkillsData();
				}

				return m_Skills;
			}
		}
		#endregion

		#region Lights
		/// <summary>
		///     The lights provides
		/// </summary>
		private static LightsData m_Lights;

		/// <summary>
		///     Gets the lights provides
		/// </summary>
		public static LightsData Lights
		{
			get
			{
				if (m_Lights == null)
				{
					m_Lights = new LightsData();
				}

				return m_Lights;
			}
		}
		#endregion

		#region Doors
		private static DoorsData m_Doors;

		/// <summary>
		///     Gets the data provider for doors
		/// </summary>
		public static DoorsData Doors
		{
			get
			{
				if (m_Doors == null)
				{
					m_Doors = new DoorsData();
				}

				return m_Doors;
			}
		}
		#endregion
		#endregion

		#region Modifiers
		/// <summary>
		///     The modifiers menu
		/// </summary>
		private static ContextMenu m_cmModifiers;

		/// <summary>
		///     Refreshes the modifiers menu
		/// </summary>
		public static void RefreshModifiersMenu()
		{
			if (m_cmModifiers == null)
			{
				MakeModifiersMenu();
				return;
			}

			m_cmModifiers.MenuItems.Clear();

			foreach (var modifier in Profile.General.Modifiers)
			{
				var item = new MenuItem(modifier);
				item.Click += OnModifierMenu;

				_ = m_cmModifiers.MenuItems.Add(item);
			}
		}

		/// <summary>
		///     Creates the modifiers menu according to the options
		/// </summary>
		private static void MakeModifiersMenu()
		{
			if (m_cmModifiers != null)
			{
				m_cmModifiers.Dispose();
			}

			m_cmModifiers = new ContextMenu();

			foreach (var modifier in Profile.General.Modifiers)
			{
				var item = new MenuItem(modifier);
				item.Click += OnModifierMenu;

				_ = m_cmModifiers.MenuItems.Add(item);
			}
		}

		/// <summary>
		///     Handles the selection of a specific modifier
		/// </summary>
		private static void OnModifierMenu(object sender, EventArgs e)
		{
			if (m_cmModifiers.SourceControl.Tag != null)
			{
				if (m_cmModifiers.SourceControl.Tag is CommandCallback callback)
				{
					var mi = sender as MenuItem;

					var index = m_cmModifiers.MenuItems.IndexOf(mi);

					if (Profile.General.ModifiersWarnings[index])
					{
						if (MessageBox.Show(
								BoxForm as Form,
								String.Format(Localization.TextProvider["Errors.ModifierWarn"], mi.Text),
								"",
								MessageBoxButtons.YesNo) == DialogResult.No)
						{
							return;
						}
					}

					// Do
					_ = callback.DynamicInvoke(mi.Text);
				}
			}
		}

		/// <summary>
		///     Gets the modifiers menu
		/// </summary>
		public static ContextMenu cmModifiers
		{
			get
			{
				if (m_cmModifiers == null)
				{
					MakeModifiersMenu();
					Profile.General.ModifiersChanged += OnModifiersChanged;
				}

				return m_cmModifiers;
			}
		}

		/// <summary>
		///     Handles changes in the list of modifiers
		/// </summary>
		private static void OnModifiersChanged(object sender, EventArgs e)
		{
			RefreshModifiersMenu();
		}
		#endregion

		#region Pandoras Box
		public static BoxConnection BoxConnection
		{
			get
			{
				if (m_BoxConnection == null)
				{
					m_BoxConnection = new BoxConnection(_profileManager);
				}
				return m_BoxConnection;
			}
		}
		#endregion

		public static IContainer Container { get; set; }
		private static ProfileManager _profileManager;
		private static ISplash _splash;

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Log.WriteEntry("Starting");

				var builder = new LightCoreBuilder();
				Container = builder.BuildContainer();
				_splash = Container.Resolve<ISplash>();

				_splash.Show();
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

				// Delete any temp files created during compilation of profile IO
				var temp = Path.Combine(Folder, "temp.dll");

				if (File.Exists(temp))
				{
					_splash.SetStatusText("Deleting temporary files");
					File.Delete(temp);
				}

				_profileManager = Container.Resolve<ProfileManager>();
				// Issue 28:  	 Refactoring Pandora.cs - Tarion
				// Move any profiles resulting from previous versions
				_profileManager.MoveOldProfiles();
				//ProfileManager.Instance.MoveOldProfiles();
				// End Issue 28:

				if (args.Length == 1 && File.Exists(args[0]) && Path.GetExtension(args[0]).ToLower() == ".pbp")
				{
					_ = _profileManager.ImportProfile(args[0]);
				}

				var context = Container.Resolve<StartingContext>();
				Application.Run(context);

				// the following code is replaced, logic moved into StartingContext
				/*
				if (profileManager.ProfileLoaded)
				{
					Pandora.Log.WriteEntry("Import startup initiated");
					m_Context = new StartingContext(profileManager.Profile.Name);
					Application.Run(m_Context);
				}
				else
				{
					Pandora.Log.WriteEntry("Normal startup initiated");

					// Move on with normal startup
					Process proc = Pandora.ExistingInstance;
					if (proc != null) // Single instance check
					{
						Pandora.Log.WriteError(null, "Double instance detected");
						System.Windows.Forms.MessageBox.Show("You can't run two instances of Pandora's Box at the same time");
						//  Issue 33:  	 Bring to front if already started - Tarion
						ProcessExtension.BringToFront(proc);
					}
					else
					{
						Pandora.Log.WriteEntry("Double instances check passed");

						m_Context = new StartingContext();
						Application.Run(m_Context);
					}
				}
				*/
			}
			catch (Exception err)
			{
				Clipboard.SetDataObject(err.ToString(), true);
				_ = MessageBox.Show(
					"An error occurred. The error text has been placed on your clipboard, use CTRL+V to paste it in a text file.");
				// Issue 6:  	 Improve error management - Tarion
				Environment.Exit(1);
				// End Issue 6:
			}
		}

		// Issue 6:  	 Improve error management - Tarion
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Clipboard.SetDataObject("UnhandledException: \n" + e, true);
			_ = MessageBox.Show(
				"An error occurred. The error text has been placed on your clipboard, use CTRL+V to paste it in a text file.");
			Environment.Exit(1);
		}
	}
}
