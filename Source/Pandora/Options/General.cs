#region Header
// /*
//  *    2018 - Pandora - General.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Data;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Options
{
	[Serializable]
	/// <summary>
	/// Summary description for General.
	/// </summary>
	public class GeneralOptions
	{
		/// <summary>
		///     Occurs when the modifier list is changed
		/// </summary>
		public event EventHandler ModifiersChanged;

		#region Variables
		private bool m_FlatButtons;
		private bool m_TopMost;
		private bool m_ShowInTaskBar = true;
		private bool m_MinimizeToTray = true;
		private bool m_XMinimize;
		private int m_Opacity = 100;
		private string m_CommandPrefix = "[";
		private bool m_Animate = true;
		private bool m_RoomView = true;
		private bool m_Scale = true;
		private ColorDef m_ArtBackground;
		private Point m_WindowLocation;
		private ColorDef m_Links;

		// Splitters
		private int m_TravelSplitter;

		private int m_DecoSplitter;
		private int m_MobilesSplitter;
		private int m_PropsSplitter;
		private int m_NotesSplitter;

		private string[] m_Modifiers = { "Single", "Self", "Multi", "Contained", "Area", "Region", "Online", "Global" };
		private bool[] m_ModifiersWarnings = { false, false, false, false, false, true, true, true };

		// General tab
		private UOSound m_Sound;

		private bool m_AllSkills;
		private string m_Skill;
		private string m_SkillName;
		private decimal m_SkillValue;
		private bool m_DupeCheck;
		private int m_DupeAmount = 1;
		private int m_LightLevel;
		private RecentStringList m_SpeechList;

		private RecentStringList m_WebList;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<string> m_SpeechPresets;

		private List<string> m_WebPresets;
		// Issue 10 - End

		private string m_StartupTab;
		#endregion

		/// <summary>
		///     States whether to display flat or system buttons
		/// </summary>
		public bool FlatButtons
		{
			get => m_FlatButtons;
			set
			{
				if (m_FlatButtons != value)
				{
					m_FlatButtons = value;

					if (Pandora.BoxForm != null)
					{
						Pandora.BoxForm.UpdateButtonStyle();
					}
				}
			}
		}

		/// <summary>
		///     Gets or sets the web presets
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<string> WebPresets
		// Issue 10 - End
		{
			get => m_WebPresets;
			set => m_WebPresets = value;
		}

		/// <summary>
		///     Gets or sets the speech presets
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<string> SpeechPresets
		// Issue 10 - End
		{
			get => m_SpeechPresets;
			set => m_SpeechPresets = value;
		}

		/// <summary>
		///     Gets or sets the list of recently used speech
		/// </summary>
		public RecentStringList SpeechList { get => m_SpeechList; set => m_SpeechList = value; }

		/// <summary>
		///     Gets or sets the list of recently used web sites
		/// </summary>
		public RecentStringList WebList { get => m_WebList; set => m_WebList = value; }

		/// <summary>
		///     Gets or sets the light level
		/// </summary>
		public int LightLevel { get => m_LightLevel; set => m_LightLevel = value; }

		/// <summary>
		///     States whether the user wishes to specify an amount for duping
		/// </summary>
		public bool DupeCheck { get => m_DupeCheck; set => m_DupeCheck = value; }

		/// <summary>
		///     Gets or sets the dupe amount
		/// </summary>
		public int DupeAmount { get => m_DupeAmount; set => m_DupeAmount = value; }

		/// <summary>
		///     Gets or sets the value of the skill set section
		/// </summary>
		public decimal SkillValue { get => m_SkillValue; set => m_SkillValue = value; }

		/// <summary>
		///     States whether the selected skill is All Skills
		/// </summary>
		public bool AllSkills { get => m_AllSkills; set => m_AllSkills = value; }

		/// <summary>
		///     Gets or sets the selected skill
		/// </summary>
		public string Skill { get => m_Skill; set => m_Skill = value; }

		/// <summary>
		///     Gets or sets the display name of the selected skill
		/// </summary>
		public string SkillName { get => m_SkillName; set => m_SkillName = value; }

		/// <summary>
		///     Gets or sets the currently selected sound
		/// </summary>
		public UOSound Sound { get => m_Sound; set => m_Sound = value; }

		/// <summary>
		///     Gets or sets the modifiers list
		/// </summary>
		public string[] Modifiers
		{
			get => m_Modifiers;
			set
			{
				m_Modifiers = value;

				ModifiersChanged?.Invoke(this, new EventArgs());
			}
		}

		/// <summary>
		///     Specifies which modifiers must use a warning
		/// </summary>
		public bool[] ModifiersWarnings { get => m_ModifiersWarnings; set => m_ModifiersWarnings = value; }

		/// <summary>
		///     Gets or sets the color used to display links
		/// </summary>
		public ColorDef Links { get => m_Links; set => m_Links = value; }

		/// <summary>
		///     Gets or sets the ColorDef object representing the background color for the art viewer
		/// </summary>
		public ColorDef ArtBackground { get => m_ArtBackground; set => m_ArtBackground = value; }

		/// <summary>
		///     Gets or sets a value stating whether tall items should be scaled to fit the display area
		/// </summary>
		public bool Scale { get => m_Scale; set => m_Scale = value; }

		/// <summary>
		///     Gets or sets a value stating whether items should be displayed using the room view
		/// </summary>
		public bool RoomView { get => m_RoomView; set => m_RoomView = value; }

		/// <summary>
		///     Gets or sets a value stating whether the NPCs should be animated or not
		/// </summary>
		public bool Animate { get => m_Animate; set => m_Animate = value; }

		/// <summary>
		///     Gets or sets the command prefix
		/// </summary>
		public string CommandPrefix { get => m_CommandPrefix; set => m_CommandPrefix = value; }

		/// <summary>
		///     Gets or sets a value stating whether the Box window stays always on top
		/// </summary>
		public bool TopMost
		{
			get => m_TopMost;
			set
			{
				m_TopMost = value;

				if (Pandora.BoxForm != null)
				{
					Pandora.BoxForm.TopMost = m_TopMost;
				}
			}
		}

		/// <summary>
		///     Gets or sets a value stating whether the window is displayed on the taskbar when opened
		/// </summary>
		public bool ShowInTaskBar
		{
			get => m_ShowInTaskBar;
			set
			{
				m_ShowInTaskBar = value;

				if (Pandora.BoxForm != null)
				{
					Pandora.BoxForm.ShowInTaskbar = m_ShowInTaskBar;
				}
			}
		}

		/// <summary>
		///     Gets or sets a value stating whether the window will minimize to the system tray
		/// </summary>
		public bool MinimizeToTray { get => m_MinimizeToTray; set => m_MinimizeToTray = value; }

		/// <summary>
		///     Gets or sets a value stating whether the window X button will minimize the Box window
		/// </summary>
		public bool XMinimize { get => m_XMinimize; set => m_XMinimize = value; }

		public int Opacity
		{
			get => m_Opacity;
			set
			{
				m_Opacity = value;
				if (m_Opacity < 40)
				{
					m_Opacity = 40;
				}

				if (m_Opacity > 100)
				{
					m_Opacity = 100;
				}

				if (Pandora.BoxForm != null)
				{
					Pandora.BoxForm.Opacity = m_Opacity / 100.0;
				}
			}
		}

		/// <summary>
		///     Gets or sets the position of the deco page splitter
		/// </summary>
		public int DecoSplitter { get => m_DecoSplitter; set => m_DecoSplitter = value; }

		/// <summary>
		///     Gets or sets the position of the Mobiles page splitter
		/// </summary>
		public int MobilesSplitter { get => m_MobilesSplitter; set => m_MobilesSplitter = value; }

		/// <summary>
		///     Gets or sets the position of the Props page splitter
		/// </summary>
		public int PropsSplitter { get => m_PropsSplitter; set => m_PropsSplitter = value; }

		/// <summary>
		///     Gets or sets the position of the Travel page splitter
		/// </summary>
		public int TravelSplitter { get => m_TravelSplitter; set => m_TravelSplitter = value; }

		/// <summary>
		///     Gets or sets the window location on the screen
		/// </summary>
		public Point WindowLocation { get => m_WindowLocation; set => m_WindowLocation = value; }

		/// <summary>
		///     Gets or sets the location of the splitter on the notes page
		/// </summary>
		public int NotesSplitter { get => m_NotesSplitter; set => m_NotesSplitter = value; }

		/// <summary>
		///     Gets or sets the tab that will be displayed on startup
		/// </summary>
		public string StartupTab { get => m_StartupTab; set => m_StartupTab = value; }

		public GeneralOptions()
		{
			m_ArtBackground = new ColorDef
			{
				Color = Color.White
			};

			m_Links = new ColorDef
			{
				Color = Color.BlueViolet
			};

			m_WindowLocation.X = (SystemInformation.PrimaryMonitorSize.Width - 694) / 2;
			m_WindowLocation.Y = (SystemInformation.PrimaryMonitorSize.Height - 210) / 2;

			m_SpeechList = new RecentStringList();
			m_WebList = new RecentStringList();
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_SpeechPresets = new List<string>();
			m_WebPresets = new List<string>();
			// Issue 10 - End
		}
	}
}