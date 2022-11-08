#region Header
// /*
//  *    2018 - Pandora - Box.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using TheBox.Buttons;
using TheBox.Common;
using TheBox.Controls;
using TheBox.Data;
using TheBox.Forms;
using TheBox.MapViewer.DrawObjects;
using TheBox.Options;
using TheBox.Pages;

using Notes = TheBox.Pages.Notes;
#endregion

namespace TheBox
{
	/// <summary>
	///     Lists the small tabs available on the box form
	/// </summary>
	public enum SmallTabs
	{
		/// <summary>
		///     The art preview
		/// </summary>
		Art,

		/// <summary>
		///     The map preview
		/// </summary>
		Map,

		/// <summary>
		///     The props editor
		/// </summary>
		Props,

		/// <summary>
		///     The custom buttons tab
		/// </summary>
		Custom
	}

	/// <summary>
	///     Summary description for Box.
	/// </summary>
	public class Box : Form, IBoxForm
	{
		private TabControl SmallTab;
		private NotifyIcon Tray;
		private ContextMenu TrayMenu;
		private MenuItem menuItem2;
		private MenuItem TrayBox;
		private MenuItem TrayOptions;
		private MenuItem TrayExit;
		private Button bSetHue;
		private PictureBox imgHue;
		private NumericUpDown numHue;
		private TabPage tabArt;
		private TabPage tabMap;
		private TabPage tabProps;
		private TabControl BigTab;
		private TabPage TabTravel;
		private BoxButton boxButton1;
		private BoxButton boxButton2;
		private BoxButton boxButton3;
		private BoxButton boxButton4;
		private BoxButton boxButton5;
		private BoxButton boxButton6;
		private BoxButton boxButton7;
		private BoxButton boxButton8;
		private TabPage TabNPCs;
		private PropManager ucPropManager;
		private TabPage TabProperties;
		private TabPage TabDeco;
		private TabPage TabItems;
		private TabPage TabNotes;
		private Notes m_NotesTab;
		private Items m_ItemsTab;
		private TabPage TabAdmin;
		private Admin m_TabAdmin;
		private TabPage TabGeneral;
		private General general1;
		private TabPage TabLights;
		private TabPage TabDoors;
		private Doors DoorsTab;
		private Lights LightsTab;
		private TabPage TabTools;
		private PictureBox pctCap;
		private Tools m_Tools;
		private TabPage tabCustom;
		private BoxButton boxButton9;
		private BoxButton boxButton10;
		private BoxButton boxButton11;
		private BoxButton boxButton12;
		private BoxButton boxButton13;
		private BoxButton boxButton14;
		private BoxButton boxButton15;
		private BoxButton boxButton16;
		private BoxButton boxButton17;
		private BoxButton boxButton18;
		private BoxButton boxButton19;
		private BoxButton boxButton20;
		private BoxButton boxButton21;
		private BoxButton boxButton22;
		private BoxButton boxButton23;
		private MenuItem miProfile;
		private Label bMenu;
		private ImageList boxImgLst;
		private MenuItem miAbout;
		private MenuItem menuItem1;
		private Deco m_TabDeco;
		private MenuItem menuItem3;
		private MenuItem miViewDataFolder;
		private MenuItem miViewLog;
		private ArtViewer.ArtViewer Art;
		private MapViewer.MapViewer Map;
		private IContainer components;

		#region Pages
		/// <summary>
		///     Gets the travel user control
		/// </summary>
		public Travel Travel { get; private set; }

		/// <summary>
		///     Gets the Mobiles user control
		/// </summary>
		public Mobiles Mobiles { get; private set; }

		/// <summary>
		///     Gets the page displaying all the properties
		/// </summary>
		public Props Properties { get; private set; }
		#endregion

		private readonly ProfileManager _profileManager;
		private readonly ISplash _splash;

		public Box()
		{
			InitializeComponent();
		}

		public Box(ProfileManager profileManager, ISplash splash)
		{
			_profileManager = profileManager;
			_splash = splash;

			_splash.SetStatusText("Loading appearance");
			InitializeComponent();

			_splash.SetStatusText("Initializing maps and artwork");
			Map.MulManager = _profileManager.Profile.MulManager;
			Art.MulFileManager = _profileManager.Profile.MulManager;

			Pandora.Map = Map;
			Pandora.Art = Art;
			Pandora.Prop = ucPropManager;

			if (Pandora.Hues != null)
			{
				_splash.SetStatusText("Reading hues");
				m_HuePicker = new HuePicker();
			}

			_splash.SetStatusText("Restoring options");
			ApplyOptions();

			_splash.SetStatusText("Building travel destinations");
			InitPages();

			// Update Title when online change!
			Pandora.BoxConnection.OnlineChanged += delegate
			{
				Text = String.Format(
					Pandora.Localization.TextProvider["Misc.BoxTitle"],
					_profileManager.Profile.Name,
					Pandora.BoxConnection.Connected
						? Pandora.Localization.TextProvider["Misc.Online"]
						: Pandora.Localization.TextProvider["Misc.Offline"]);
			};
		}

		/// <summary>
		///     Applies the options in the profile
		/// </summary>
		private void ApplyOptions()
		{
			var p = _profileManager.Profile;

			TopMost = p.General.TopMost;
			Opacity = p.General.Opacity / 100.0;

			// Hue
			if (Pandora.Hues != null)
			{
				numHue.Value = p.Hues.SelectedIndex;

				if (p.Hues.SelectedIndex != 0)
				{
					imgHue.Image = Pandora.Hues[p.Hues.SelectedIndex].GetSpectrum(imgHue.Size);
				}

				m_HuesMenu = new RecentHuesMenu(p.Hues.RecentHues);
				m_HuesMenu.HueClicked += m_HuesMenu_HueClicked;
			}
			else
			{
				imgHue.Enabled = false;
				numHue.Enabled = false;
				bSetHue.Enabled = false;
			}

			// Map
			Map.DrawStatics = p.Travel.DrawStatics;
			Map.XRayView = p.Travel.XRayView;
		}

		/// <summary>
		///     Initializes the pages that require a special initialization
		/// </summary>
		private void InitPages()
		{
			Travel.Init();
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(Box));
			var mulManager1 = new TheBox.Common.MulManager();
			this.BigTab = new System.Windows.Forms.TabControl();
			this.TabGeneral = new System.Windows.Forms.TabPage();
			this.TabDeco = new System.Windows.Forms.TabPage();
			this.TabTravel = new System.Windows.Forms.TabPage();
			this.TabProperties = new System.Windows.Forms.TabPage();
			this.TabItems = new System.Windows.Forms.TabPage();
			this.TabNPCs = new System.Windows.Forms.TabPage();
			this.TabAdmin = new System.Windows.Forms.TabPage();
			this.TabTools = new System.Windows.Forms.TabPage();
			this.TabDoors = new System.Windows.Forms.TabPage();
			this.TabLights = new System.Windows.Forms.TabPage();
			this.TabNotes = new System.Windows.Forms.TabPage();
			this.SmallTab = new System.Windows.Forms.TabControl();
			this.tabArt = new System.Windows.Forms.TabPage();
			this.Art = new TheBox.ArtViewer.ArtViewer();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.Map = new TheBox.MapViewer.MapViewer();
			this.tabProps = new System.Windows.Forms.TabPage();
			this.tabCustom = new System.Windows.Forms.TabPage();
			this.bSetHue = new System.Windows.Forms.Button();
			this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
			this.TrayMenu = new System.Windows.Forms.ContextMenu();
			this.TrayBox = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.TrayOptions = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miViewDataFolder = new System.Windows.Forms.MenuItem();
			this.miViewLog = new System.Windows.Forms.MenuItem();
			this.miProfile = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miAbout = new System.Windows.Forms.MenuItem();
			this.TrayExit = new System.Windows.Forms.MenuItem();
			this.numHue = new System.Windows.Forms.NumericUpDown();
			this.boxImgLst = new System.Windows.Forms.ImageList(this.components);
			this.bMenu = new System.Windows.Forms.Label();
			this.pctCap = new System.Windows.Forms.PictureBox();
			this.imgHue = new System.Windows.Forms.PictureBox();
			this.boxButton8 = new TheBox.Buttons.BoxButton();
			this.boxButton7 = new TheBox.Buttons.BoxButton();
			this.boxButton6 = new TheBox.Buttons.BoxButton();
			this.boxButton5 = new TheBox.Buttons.BoxButton();
			this.boxButton4 = new TheBox.Buttons.BoxButton();
			this.boxButton3 = new TheBox.Buttons.BoxButton();
			this.boxButton2 = new TheBox.Buttons.BoxButton();
			this.boxButton1 = new TheBox.Buttons.BoxButton();
			this.ucPropManager = new TheBox.Controls.PropManager();
			this.boxButton23 = new TheBox.Buttons.BoxButton();
			this.boxButton22 = new TheBox.Buttons.BoxButton();
			this.boxButton21 = new TheBox.Buttons.BoxButton();
			this.boxButton20 = new TheBox.Buttons.BoxButton();
			this.boxButton19 = new TheBox.Buttons.BoxButton();
			this.boxButton18 = new TheBox.Buttons.BoxButton();
			this.boxButton17 = new TheBox.Buttons.BoxButton();
			this.boxButton16 = new TheBox.Buttons.BoxButton();
			this.boxButton15 = new TheBox.Buttons.BoxButton();
			this.boxButton14 = new TheBox.Buttons.BoxButton();
			this.boxButton13 = new TheBox.Buttons.BoxButton();
			this.boxButton12 = new TheBox.Buttons.BoxButton();
			this.boxButton11 = new TheBox.Buttons.BoxButton();
			this.boxButton10 = new TheBox.Buttons.BoxButton();
			this.boxButton9 = new TheBox.Buttons.BoxButton();
			this.general1 = new TheBox.Pages.General();
			this.m_TabDeco = new TheBox.Pages.Deco();
			this.Travel = new TheBox.Pages.Travel();
			this.Properties = new TheBox.Pages.Props();
			this.m_ItemsTab = new TheBox.Pages.Items();
			this.Mobiles = new TheBox.Pages.Mobiles();
			this.m_TabAdmin = new TheBox.Pages.Admin();
			this.m_Tools = new TheBox.Pages.Tools();
			this.DoorsTab = new TheBox.Pages.Doors();
			this.LightsTab = new TheBox.Pages.Lights();
			this.m_NotesTab = new TheBox.Pages.Notes();
			this.BigTab.SuspendLayout();
			this.TabGeneral.SuspendLayout();
			this.TabDeco.SuspendLayout();
			this.TabTravel.SuspendLayout();
			this.TabProperties.SuspendLayout();
			this.TabItems.SuspendLayout();
			this.TabNPCs.SuspendLayout();
			this.TabAdmin.SuspendLayout();
			this.TabTools.SuspendLayout();
			this.TabDoors.SuspendLayout();
			this.TabLights.SuspendLayout();
			this.TabNotes.SuspendLayout();
			this.SmallTab.SuspendLayout();
			this.tabArt.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabProps.SuspendLayout();
			this.tabCustom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numHue).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pctCap).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.imgHue).BeginInit();
			this.SuspendLayout();
			// 
			// BigTab
			// 
			this.BigTab.Controls.Add(this.TabGeneral);
			this.BigTab.Controls.Add(this.TabDeco);
			this.BigTab.Controls.Add(this.TabTravel);
			this.BigTab.Controls.Add(this.TabProperties);
			this.BigTab.Controls.Add(this.TabItems);
			this.BigTab.Controls.Add(this.TabNPCs);
			this.BigTab.Controls.Add(this.TabAdmin);
			this.BigTab.Controls.Add(this.TabTools);
			this.BigTab.Controls.Add(this.TabDoors);
			this.BigTab.Controls.Add(this.TabLights);
			this.BigTab.Controls.Add(this.TabNotes);
			this.BigTab.ItemSize = new System.Drawing.Size(42, 16);
			this.BigTab.Location = new System.Drawing.Point(0, 20);
			this.BigTab.Name = "BigTab";
			this.BigTab.SelectedIndex = 0;
			this.BigTab.Size = new System.Drawing.Size(504, 166);
			this.BigTab.TabIndex = 0;
			this.BigTab.SelectedIndexChanged += new System.EventHandler(this.BigTab_SelectedIndexChanged);
			this.BigTab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Box_KeyDown);
			// 
			// TabGeneral
			// 
			this.TabGeneral.Controls.Add(this.general1);
			this.TabGeneral.Location = new System.Drawing.Point(4, 20);
			this.TabGeneral.Name = "TabGeneral";
			this.TabGeneral.Size = new System.Drawing.Size(496, 142);
			this.TabGeneral.TabIndex = 7;
			this.TabGeneral.Text = "Tabs.General";
			// 
			// TabDeco
			// 
			this.TabDeco.Controls.Add(this.m_TabDeco);
			this.TabDeco.Location = new System.Drawing.Point(4, 20);
			this.TabDeco.Name = "TabDeco";
			this.TabDeco.Size = new System.Drawing.Size(496, 142);
			this.TabDeco.TabIndex = 3;
			this.TabDeco.Text = "Tabs.Deco";
			// 
			// TabTravel
			// 
			this.TabTravel.Controls.Add(this.Travel);
			this.TabTravel.Location = new System.Drawing.Point(4, 20);
			this.TabTravel.Name = "TabTravel";
			this.TabTravel.Size = new System.Drawing.Size(496, 142);
			this.TabTravel.TabIndex = 0;
			this.TabTravel.Text = "Tabs.Travel";
			// 
			// TabProperties
			// 
			this.TabProperties.Controls.Add(this.Properties);
			this.TabProperties.Location = new System.Drawing.Point(4, 20);
			this.TabProperties.Name = "TabProperties";
			this.TabProperties.Size = new System.Drawing.Size(496, 142);
			this.TabProperties.TabIndex = 2;
			this.TabProperties.Text = "Tabs.Props";
			// 
			// TabItems
			// 
			this.TabItems.Controls.Add(this.m_ItemsTab);
			this.TabItems.Location = new System.Drawing.Point(4, 20);
			this.TabItems.Name = "TabItems";
			this.TabItems.Size = new System.Drawing.Size(496, 142);
			this.TabItems.TabIndex = 4;
			this.TabItems.Text = "Tabs.Items";
			// 
			// TabNPCs
			// 
			this.TabNPCs.Controls.Add(this.Mobiles);
			this.TabNPCs.Location = new System.Drawing.Point(4, 20);
			this.TabNPCs.Name = "TabNPCs";
			this.TabNPCs.Size = new System.Drawing.Size(496, 142);
			this.TabNPCs.TabIndex = 1;
			this.TabNPCs.Text = "Tabs.NPCs";
			// 
			// TabAdmin
			// 
			this.TabAdmin.Controls.Add(this.m_TabAdmin);
			this.TabAdmin.Location = new System.Drawing.Point(4, 20);
			this.TabAdmin.Name = "TabAdmin";
			this.TabAdmin.Size = new System.Drawing.Size(496, 142);
			this.TabAdmin.TabIndex = 6;
			this.TabAdmin.Text = "Tabs.Admin";
			// 
			// TabTools
			// 
			this.TabTools.Controls.Add(this.m_Tools);
			this.TabTools.Location = new System.Drawing.Point(4, 20);
			this.TabTools.Name = "TabTools";
			this.TabTools.Size = new System.Drawing.Size(496, 142);
			this.TabTools.TabIndex = 10;
			this.TabTools.Text = "Tabs.Tools";
			// 
			// TabDoors
			// 
			this.TabDoors.Controls.Add(this.DoorsTab);
			this.TabDoors.Location = new System.Drawing.Point(4, 20);
			this.TabDoors.Name = "TabDoors";
			this.TabDoors.Size = new System.Drawing.Size(496, 142);
			this.TabDoors.TabIndex = 9;
			this.TabDoors.Text = "Tabs.Doors";
			// 
			// TabLights
			// 
			this.TabLights.Controls.Add(this.LightsTab);
			this.TabLights.Location = new System.Drawing.Point(4, 20);
			this.TabLights.Name = "TabLights";
			this.TabLights.Size = new System.Drawing.Size(496, 142);
			this.TabLights.TabIndex = 8;
			this.TabLights.Text = "Tabs.Lights";
			// 
			// TabNotes
			// 
			this.TabNotes.Controls.Add(this.m_NotesTab);
			this.TabNotes.Location = new System.Drawing.Point(4, 20);
			this.TabNotes.Name = "TabNotes";
			this.TabNotes.Size = new System.Drawing.Size(496, 142);
			this.TabNotes.TabIndex = 5;
			this.TabNotes.Text = "Tabs.Notes";
			// 
			// SmallTab
			// 
			this.SmallTab.Controls.Add(this.tabArt);
			this.SmallTab.Controls.Add(this.tabMap);
			this.SmallTab.Controls.Add(this.tabProps);
			this.SmallTab.Controls.Add(this.tabCustom);
			this.SmallTab.ItemSize = new System.Drawing.Size(42, 16);
			this.SmallTab.Location = new System.Drawing.Point(504, 20);
			this.SmallTab.Name = "SmallTab";
			this.SmallTab.SelectedIndex = 0;
			this.SmallTab.Size = new System.Drawing.Size(184, 166);
			this.SmallTab.TabIndex = 1;
			this.SmallTab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Box_KeyDown);
			// 
			// tabArt
			// 
			this.tabArt.Controls.Add(this.Art);
			this.tabArt.Location = new System.Drawing.Point(4, 20);
			this.tabArt.Name = "tabArt";
			this.tabArt.Size = new System.Drawing.Size(176, 142);
			this.tabArt.TabIndex = 0;
			this.tabArt.Text = "Tabs.Art";
			// 
			// Art
			// 
			this.Art.Animate = false;
			this.Art.Art = TheBox.ArtViewer.Art.Items;
			this.Art.ArtIndex = 0;
			this.Art.BackColor = System.Drawing.Color.White;
			this.Art.Hue = 0;
			this.Art.Location = new System.Drawing.Point(1, 1);
			this.Art.Name = "Art";
			this.Art.ResizeTallItems = false;
			this.Art.RoomView = true;
			this.Art.ShowHexID = true;
			this.Art.ShowID = true;
			this.Art.Size = new System.Drawing.Size(174, 140);
			this.Art.TabIndex = 0;
			this.Art.Text = "artViewer1";
			// 
			// tabMap
			// 
			this.tabMap.Controls.Add(this.Map);
			this.tabMap.Location = new System.Drawing.Point(4, 20);
			this.tabMap.Name = "tabMap";
			this.tabMap.Size = new System.Drawing.Size(176, 142);
			this.tabMap.TabIndex = 1;
			this.tabMap.Text = "Tabs.Map";
			// 
			// Map
			// 
			this.Map.Center = new System.Drawing.Point(0, 0);
			this.Map.DisplayErrors = true;
			this.Map.DrawObjects =
			(System.Collections.Generic.List<TheBox.MapViewer.DrawObjects.IMapDrawable>)
				resources.GetObject("Map.DrawObjects");
			this.Map.DrawStatics = false;
			this.Map.Location = new System.Drawing.Point(1, 1);
			this.Map.Map = TheBox.MapViewer.Maps.Felucca;
			mulManager1.CustomFolder = null;
			mulManager1.Table = null;
			this.Map.MulManager = mulManager1;
			this.Map.Name = "Map";
			this.Map.Navigation = TheBox.MapViewer.MapNavigation.LeftMouseButton;
			this.Map.ShowCross = true;
			this.Map.Size = new System.Drawing.Size(174, 140);
			this.Map.TabIndex = 0;
			this.Map.Text = "mapViewer1";
			this.Map.WheelZoom = true;
			this.Map.XRayView = false;
			this.Map.ZoomLevel = 0;
			this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
			// 
			// tabProps
			// 
			this.tabProps.Controls.Add(this.ucPropManager);
			this.tabProps.Location = new System.Drawing.Point(4, 20);
			this.tabProps.Name = "tabProps";
			this.tabProps.Size = new System.Drawing.Size(176, 142);
			this.tabProps.TabIndex = 2;
			this.tabProps.Text = "Tabs.Props";
			// 
			// tabCustom
			// 
			this.tabCustom.Controls.Add(this.boxButton23);
			this.tabCustom.Controls.Add(this.boxButton22);
			this.tabCustom.Controls.Add(this.boxButton21);
			this.tabCustom.Controls.Add(this.boxButton20);
			this.tabCustom.Controls.Add(this.boxButton19);
			this.tabCustom.Controls.Add(this.boxButton18);
			this.tabCustom.Controls.Add(this.boxButton17);
			this.tabCustom.Controls.Add(this.boxButton16);
			this.tabCustom.Controls.Add(this.boxButton15);
			this.tabCustom.Controls.Add(this.boxButton14);
			this.tabCustom.Controls.Add(this.boxButton13);
			this.tabCustom.Controls.Add(this.boxButton12);
			this.tabCustom.Controls.Add(this.boxButton11);
			this.tabCustom.Controls.Add(this.boxButton10);
			this.tabCustom.Controls.Add(this.boxButton9);
			this.tabCustom.Location = new System.Drawing.Point(4, 20);
			this.tabCustom.Name = "tabCustom";
			this.tabCustom.Size = new System.Drawing.Size(176, 142);
			this.tabCustom.TabIndex = 3;
			this.tabCustom.Text = "Tabs.Custom";
			// 
			// bSetHue
			// 
			this.bSetHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSetHue.Location = new System.Drawing.Point(112, 0);
			this.bSetHue.Name = "bSetHue";
			this.bSetHue.Size = new System.Drawing.Size(32, 20);
			this.bSetHue.TabIndex = 3;
			this.bSetHue.Text = "Common.Set";
			this.bSetHue.Click += new System.EventHandler(this.bSetHue_Click);
			// 
			// Tray
			// 
			this.Tray.ContextMenu = this.TrayMenu;
			this.Tray.Icon = (System.Drawing.Icon)resources.GetObject("Tray.Icon");
			this.Tray.Text = "Pandora\'s Box";
			this.Tray.Visible = true;
			this.Tray.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDown);
			// 
			// TrayMenu
			// 
			this.TrayMenu.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[]
				{
					this.TrayBox, this.menuItem2, this.TrayOptions, this.menuItem3, this.miProfile, this.menuItem1, this.miAbout,
					this.TrayExit
				});
			// 
			// TrayBox
			// 
			this.TrayBox.Index = 0;
			this.TrayBox.Text = "Misc.www";
			this.TrayBox.Click += new System.EventHandler(this.TrayBox_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// TrayOptions
			// 
			this.TrayOptions.Index = 2;
			this.TrayOptions.Text = "Common.Options";
			this.TrayOptions.Click += new System.EventHandler(this.TrayOptions_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.miViewDataFolder, this.miViewLog });
			this.menuItem3.Text = "Common.View";
			// 
			// miViewDataFolder
			// 
			this.miViewDataFolder.Index = 0;
			this.miViewDataFolder.Text = "Misc.DataFolder";
			this.miViewDataFolder.Click += new System.EventHandler(this.miViewDataFolder_Click);
			// 
			// miViewLog
			// 
			this.miViewLog.Index = 1;
			this.miViewLog.Text = "Misc.Log";
			this.miViewLog.Click += new System.EventHandler(this.miViewLog_Click);
			// 
			// miProfile
			// 
			this.miProfile.Index = 4;
			this.miProfile.Text = "Common.Profile";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.Text = "-";
			// 
			// miAbout
			// 
			this.miAbout.Index = 6;
			this.miAbout.Text = "Common.About";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// TrayExit
			// 
			this.TrayExit.Index = 7;
			this.TrayExit.Text = "Common.Exit";
			this.TrayExit.Click += new System.EventHandler(this.TrayExit_Click);
			// 
			// numHue
			// 
			this.numHue.Location = new System.Drawing.Point(24, 0);
			this.numHue.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
			this.numHue.Name = "numHue";
			this.numHue.Size = new System.Drawing.Size(48, 20);
			this.numHue.TabIndex = 6;
			this.numHue.ValueChanged += new System.EventHandler(this.numHue_ValueChanged);
			// 
			// boxImgLst
			// 
			this.boxImgLst.ImageStream =
				(System.Windows.Forms.ImageListStreamer)resources.GetObject("boxImgLst.ImageStream");
			this.boxImgLst.TransparentColor = System.Drawing.Color.Transparent;
			this.boxImgLst.Images.SetKeyName(0, "");
			this.boxImgLst.Images.SetKeyName(1, "");
			this.boxImgLst.Images.SetKeyName(2, "");
			// 
			// bMenu
			// 
			this.bMenu.ImageIndex = 0;
			this.bMenu.ImageList = this.boxImgLst;
			this.bMenu.Location = new System.Drawing.Point(3, 2);
			this.bMenu.Name = "bMenu";
			this.bMenu.Size = new System.Drawing.Size(16, 16);
			this.bMenu.TabIndex = 16;
			this.bMenu.MouseLeave += new System.EventHandler(this.bMenu_MouseLeave);
			this.bMenu.Click += new System.EventHandler(this.bMenu_Click);
			this.bMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMenu_MouseDown_1);
			this.bMenu.MouseEnter += new System.EventHandler(this.bMenu_MouseEnter);
			// 
			// pctCap
			// 
			this.pctCap.Image = (System.Drawing.Image)resources.GetObject("pctCap.Image");
			this.pctCap.Location = new System.Drawing.Point(656, 0);
			this.pctCap.Name = "pctCap";
			this.pctCap.Size = new System.Drawing.Size(32, 20);
			this.pctCap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pctCap.TabIndex = 15;
			this.pctCap.TabStop = false;
			this.pctCap.MouseLeave += new System.EventHandler(this.pctCap_MouseLeave);
			this.pctCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctCap_MouseDown);
			this.pctCap.Paint += new System.Windows.Forms.PaintEventHandler(this.pctCap_Paint);
			this.pctCap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctCap_MouseUp);
			this.pctCap.MouseEnter += new System.EventHandler(this.pctCap_MouseEnter);
			// 
			// imgHue
			// 
			this.imgHue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgHue.Location = new System.Drawing.Point(72, 2);
			this.imgHue.Name = "imgHue";
			this.imgHue.Size = new System.Drawing.Size(38, 16);
			this.imgHue.TabIndex = 5;
			this.imgHue.TabStop = false;
			this.imgHue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgHue_MouseDown);
			// 
			// boxButton8
			// 
			this.boxButton8.AllowEdit = true;
			this.boxButton8.ButtonID = 34;
			this.boxButton8.Def = null;
			this.boxButton8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton8.IsActive = true;
			this.boxButton8.Location = new System.Drawing.Point(592, 0);
			this.boxButton8.Name = "boxButton8";
			this.boxButton8.Size = new System.Drawing.Size(64, 20);
			this.boxButton8.TabIndex = 14;
			this.boxButton8.Text = "boxButton8";
			// 
			// boxButton7
			// 
			this.boxButton7.AllowEdit = true;
			this.boxButton7.ButtonID = 33;
			this.boxButton7.Def = null;
			this.boxButton7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton7.IsActive = true;
			this.boxButton7.Location = new System.Drawing.Point(528, 0);
			this.boxButton7.Name = "boxButton7";
			this.boxButton7.Size = new System.Drawing.Size(64, 20);
			this.boxButton7.TabIndex = 13;
			this.boxButton7.Text = "boxButton7";
			// 
			// boxButton6
			// 
			this.boxButton6.AllowEdit = true;
			this.boxButton6.ButtonID = 32;
			this.boxButton6.Def = null;
			this.boxButton6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton6.IsActive = true;
			this.boxButton6.Location = new System.Drawing.Point(464, 0);
			this.boxButton6.Name = "boxButton6";
			this.boxButton6.Size = new System.Drawing.Size(64, 20);
			this.boxButton6.TabIndex = 12;
			this.boxButton6.Text = "boxButton6";
			// 
			// boxButton5
			// 
			this.boxButton5.AllowEdit = true;
			this.boxButton5.ButtonID = 31;
			this.boxButton5.Def = null;
			this.boxButton5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton5.IsActive = true;
			this.boxButton5.Location = new System.Drawing.Point(400, 0);
			this.boxButton5.Name = "boxButton5";
			this.boxButton5.Size = new System.Drawing.Size(64, 20);
			this.boxButton5.TabIndex = 11;
			this.boxButton5.Text = "boxButton5";
			// 
			// boxButton4
			// 
			this.boxButton4.AllowEdit = true;
			this.boxButton4.ButtonID = 30;
			this.boxButton4.Def = null;
			this.boxButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton4.IsActive = true;
			this.boxButton4.Location = new System.Drawing.Point(336, 0);
			this.boxButton4.Name = "boxButton4";
			this.boxButton4.Size = new System.Drawing.Size(64, 20);
			this.boxButton4.TabIndex = 10;
			this.boxButton4.Text = "boxButton4";
			// 
			// boxButton3
			// 
			this.boxButton3.AllowEdit = true;
			this.boxButton3.ButtonID = 29;
			this.boxButton3.Def = null;
			this.boxButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton3.IsActive = true;
			this.boxButton3.Location = new System.Drawing.Point(272, 0);
			this.boxButton3.Name = "boxButton3";
			this.boxButton3.Size = new System.Drawing.Size(64, 20);
			this.boxButton3.TabIndex = 9;
			this.boxButton3.Text = "boxButton3";
			// 
			// boxButton2
			// 
			this.boxButton2.AllowEdit = true;
			this.boxButton2.ButtonID = 28;
			this.boxButton2.Def = null;
			this.boxButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton2.IsActive = true;
			this.boxButton2.Location = new System.Drawing.Point(208, 0);
			this.boxButton2.Name = "boxButton2";
			this.boxButton2.Size = new System.Drawing.Size(64, 20);
			this.boxButton2.TabIndex = 8;
			this.boxButton2.Text = "boxButton2";
			// 
			// boxButton1
			// 
			this.boxButton1.AllowEdit = true;
			this.boxButton1.ButtonID = 9;
			this.boxButton1.Def = null;
			this.boxButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton1.IsActive = true;
			this.boxButton1.Location = new System.Drawing.Point(144, 0);
			this.boxButton1.Name = "boxButton1";
			this.boxButton1.Size = new System.Drawing.Size(64, 20);
			this.boxButton1.TabIndex = 7;
			this.boxButton1.Text = "boxButton1";
			this.boxButton1.Click += new System.EventHandler(this.boxButton1_Click);
			// 
			// ucPropManager
			// 
			this.ucPropManager.Location = new System.Drawing.Point(0, 0);
			this.ucPropManager.Name = "ucPropManager";
			this.ucPropManager.Size = new System.Drawing.Size(176, 144);
			this.ucPropManager.TabIndex = 0;
			// 
			// boxButton23
			// 
			this.boxButton23.AllowEdit = true;
			this.boxButton23.ButtonID = 118;
			this.boxButton23.Def = null;
			this.boxButton23.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton23.IsActive = true;
			this.boxButton23.Location = new System.Drawing.Point(120, 116);
			this.boxButton23.Name = "boxButton23";
			this.boxButton23.Size = new System.Drawing.Size(56, 23);
			this.boxButton23.TabIndex = 14;
			this.boxButton23.Text = "boxButton23";
			// 
			// boxButton22
			// 
			this.boxButton22.AllowEdit = true;
			this.boxButton22.ButtonID = 117;
			this.boxButton22.Def = null;
			this.boxButton22.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton22.IsActive = true;
			this.boxButton22.Location = new System.Drawing.Point(120, 88);
			this.boxButton22.Name = "boxButton22";
			this.boxButton22.Size = new System.Drawing.Size(56, 23);
			this.boxButton22.TabIndex = 13;
			this.boxButton22.Text = "boxButton22";
			// 
			// boxButton21
			// 
			this.boxButton21.AllowEdit = true;
			this.boxButton21.ButtonID = 116;
			this.boxButton21.Def = null;
			this.boxButton21.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton21.IsActive = true;
			this.boxButton21.Location = new System.Drawing.Point(120, 60);
			this.boxButton21.Name = "boxButton21";
			this.boxButton21.Size = new System.Drawing.Size(56, 23);
			this.boxButton21.TabIndex = 12;
			this.boxButton21.Text = "boxButton21";
			// 
			// boxButton20
			// 
			this.boxButton20.AllowEdit = true;
			this.boxButton20.ButtonID = 115;
			this.boxButton20.Def = null;
			this.boxButton20.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton20.IsActive = true;
			this.boxButton20.Location = new System.Drawing.Point(120, 32);
			this.boxButton20.Name = "boxButton20";
			this.boxButton20.Size = new System.Drawing.Size(56, 23);
			this.boxButton20.TabIndex = 11;
			this.boxButton20.Text = "boxButton20";
			// 
			// boxButton19
			// 
			this.boxButton19.AllowEdit = true;
			this.boxButton19.ButtonID = 114;
			this.boxButton19.Def = null;
			this.boxButton19.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton19.IsActive = true;
			this.boxButton19.Location = new System.Drawing.Point(60, 60);
			this.boxButton19.Name = "boxButton19";
			this.boxButton19.Size = new System.Drawing.Size(56, 23);
			this.boxButton19.TabIndex = 10;
			this.boxButton19.Text = "boxButton19";
			// 
			// boxButton18
			// 
			this.boxButton18.AllowEdit = true;
			this.boxButton18.ButtonID = 113;
			this.boxButton18.Def = null;
			this.boxButton18.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton18.IsActive = true;
			this.boxButton18.Location = new System.Drawing.Point(60, 116);
			this.boxButton18.Name = "boxButton18";
			this.boxButton18.Size = new System.Drawing.Size(56, 23);
			this.boxButton18.TabIndex = 9;
			this.boxButton18.Text = "boxButton18";
			// 
			// boxButton17
			// 
			this.boxButton17.AllowEdit = true;
			this.boxButton17.ButtonID = 112;
			this.boxButton17.Def = null;
			this.boxButton17.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton17.IsActive = true;
			this.boxButton17.Location = new System.Drawing.Point(60, 88);
			this.boxButton17.Name = "boxButton17";
			this.boxButton17.Size = new System.Drawing.Size(56, 23);
			this.boxButton17.TabIndex = 8;
			this.boxButton17.Text = "boxButton17";
			// 
			// boxButton16
			// 
			this.boxButton16.AllowEdit = true;
			this.boxButton16.ButtonID = 111;
			this.boxButton16.Def = null;
			this.boxButton16.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton16.IsActive = true;
			this.boxButton16.Location = new System.Drawing.Point(0, 116);
			this.boxButton16.Name = "boxButton16";
			this.boxButton16.Size = new System.Drawing.Size(56, 23);
			this.boxButton16.TabIndex = 7;
			this.boxButton16.Text = "boxButton16";
			// 
			// boxButton15
			// 
			this.boxButton15.AllowEdit = true;
			this.boxButton15.ButtonID = 110;
			this.boxButton15.Def = null;
			this.boxButton15.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton15.IsActive = true;
			this.boxButton15.Location = new System.Drawing.Point(60, 32);
			this.boxButton15.Name = "boxButton15";
			this.boxButton15.Size = new System.Drawing.Size(56, 23);
			this.boxButton15.TabIndex = 6;
			this.boxButton15.Text = "boxButton15";
			// 
			// boxButton14
			// 
			this.boxButton14.AllowEdit = true;
			this.boxButton14.ButtonID = 109;
			this.boxButton14.Def = null;
			this.boxButton14.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton14.IsActive = true;
			this.boxButton14.Location = new System.Drawing.Point(0, 88);
			this.boxButton14.Name = "boxButton14";
			this.boxButton14.Size = new System.Drawing.Size(56, 23);
			this.boxButton14.TabIndex = 5;
			this.boxButton14.Text = "boxButton14";
			// 
			// boxButton13
			// 
			this.boxButton13.AllowEdit = true;
			this.boxButton13.ButtonID = 108;
			this.boxButton13.Def = null;
			this.boxButton13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton13.IsActive = true;
			this.boxButton13.Location = new System.Drawing.Point(0, 60);
			this.boxButton13.Name = "boxButton13";
			this.boxButton13.Size = new System.Drawing.Size(56, 23);
			this.boxButton13.TabIndex = 4;
			this.boxButton13.Text = "boxButton13";
			// 
			// boxButton12
			// 
			this.boxButton12.AllowEdit = true;
			this.boxButton12.ButtonID = 107;
			this.boxButton12.Def = null;
			this.boxButton12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton12.IsActive = true;
			this.boxButton12.Location = new System.Drawing.Point(0, 32);
			this.boxButton12.Name = "boxButton12";
			this.boxButton12.Size = new System.Drawing.Size(56, 23);
			this.boxButton12.TabIndex = 3;
			this.boxButton12.Text = "boxButton12";
			// 
			// boxButton11
			// 
			this.boxButton11.AllowEdit = true;
			this.boxButton11.ButtonID = 106;
			this.boxButton11.Def = null;
			this.boxButton11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton11.IsActive = true;
			this.boxButton11.Location = new System.Drawing.Point(120, 4);
			this.boxButton11.Name = "boxButton11";
			this.boxButton11.Size = new System.Drawing.Size(56, 23);
			this.boxButton11.TabIndex = 2;
			this.boxButton11.Text = "boxButton11";
			// 
			// boxButton10
			// 
			this.boxButton10.AllowEdit = true;
			this.boxButton10.ButtonID = 105;
			this.boxButton10.Def = null;
			this.boxButton10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton10.IsActive = true;
			this.boxButton10.Location = new System.Drawing.Point(60, 4);
			this.boxButton10.Name = "boxButton10";
			this.boxButton10.Size = new System.Drawing.Size(56, 23);
			this.boxButton10.TabIndex = 1;
			this.boxButton10.Text = "boxButton10";
			// 
			// boxButton9
			// 
			this.boxButton9.AllowEdit = true;
			this.boxButton9.ButtonID = 104;
			this.boxButton9.Def = null;
			this.boxButton9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton9.IsActive = true;
			this.boxButton9.Location = new System.Drawing.Point(0, 4);
			this.boxButton9.Name = "boxButton9";
			this.boxButton9.Size = new System.Drawing.Size(56, 23);
			this.boxButton9.TabIndex = 0;
			this.boxButton9.Text = "boxButton9";
			// 
			// general1
			// 
			this.general1.Location = new System.Drawing.Point(0, 0);
			this.general1.Name = "general1";
			this.general1.Size = new System.Drawing.Size(496, 142);
			this.general1.TabIndex = 0;
			// 
			// m_TabDeco
			// 
			this.m_TabDeco.Location = new System.Drawing.Point(0, 0);
			this.m_TabDeco.Name = "m_TabDeco";
			this.m_TabDeco.Size = new System.Drawing.Size(496, 142);
			this.m_TabDeco.TabIndex = 0;
			// 
			// m_TravelTab
			// 
			this.Travel.Location = new System.Drawing.Point(0, 0);
			this.Travel.Name = "m_TravelTab";
			this.Travel.Size = new System.Drawing.Size(496, 142);
			this.Travel.TabIndex = 0;
			// 
			// m_PageProperties
			// 
			this.Properties.Location = new System.Drawing.Point(0, 0);
			this.Properties.Name = "m_PageProperties";
			this.Properties.SelectedProperty = null;
			this.Properties.Size = new System.Drawing.Size(496, 142);
			this.Properties.TabIndex = 0;
			// 
			// m_ItemsTab
			// 
			this.m_ItemsTab.Location = new System.Drawing.Point(0, 0);
			this.m_ItemsTab.Name = "m_ItemsTab";
			this.m_ItemsTab.Size = new System.Drawing.Size(496, 142);
			this.m_ItemsTab.TabIndex = 0;
			// 
			// m_PageMobiles
			// 
			this.Mobiles.Location = new System.Drawing.Point(0, 0);
			this.Mobiles.Name = "m_PageMobiles";
			this.Mobiles.Size = new System.Drawing.Size(496, 142);
			this.Mobiles.TabIndex = 0;
			// 
			// m_TabAdmin
			// 
			this.m_TabAdmin.Location = new System.Drawing.Point(0, 0);
			this.m_TabAdmin.Name = "m_TabAdmin";
			this.m_TabAdmin.Size = new System.Drawing.Size(496, 142);
			this.m_TabAdmin.TabIndex = 0;
			// 
			// m_Tools
			// 
			this.m_Tools.Location = new System.Drawing.Point(0, 0);
			this.m_Tools.Name = "m_Tools";
			this.m_Tools.Size = new System.Drawing.Size(496, 142);
			this.m_Tools.TabIndex = 0;
			// 
			// DoorsTab
			// 
			this.DoorsTab.Location = new System.Drawing.Point(0, 0);
			this.DoorsTab.Name = "DoorsTab";
			this.DoorsTab.Size = new System.Drawing.Size(496, 142);
			this.DoorsTab.TabIndex = 0;
			// 
			// LightsTab
			// 
			this.LightsTab.Location = new System.Drawing.Point(0, 0);
			this.LightsTab.Name = "LightsTab";
			this.LightsTab.Size = new System.Drawing.Size(496, 142);
			this.LightsTab.TabIndex = 0;
			// 
			// m_NotesTab
			// 
			this.m_NotesTab.Location = new System.Drawing.Point(0, 0);
			this.m_NotesTab.Name = "m_NotesTab";
			this.m_NotesTab.Size = new System.Drawing.Size(496, 142);
			this.m_NotesTab.TabIndex = 0;
			// 
			// Box
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 185);
			this.Controls.Add(this.bMenu);
			this.Controls.Add(this.pctCap);
			this.Controls.Add(this.boxButton8);
			this.Controls.Add(this.boxButton7);
			this.Controls.Add(this.boxButton6);
			this.Controls.Add(this.boxButton5);
			this.Controls.Add(this.boxButton4);
			this.Controls.Add(this.boxButton3);
			this.Controls.Add(this.boxButton2);
			this.Controls.Add(this.boxButton1);
			this.Controls.Add(this.numHue);
			this.Controls.Add(this.imgHue);
			this.Controls.Add(this.bSetHue);
			this.Controls.Add(this.SmallTab);
			this.Controls.Add(this.BigTab);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "Box";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Box";
			this.Load += new System.EventHandler(this.Box_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Box_Closing);
			this.Resize += new System.EventHandler(this.Box_Resize);
			this.LocationChanged += new System.EventHandler(this.Box_LocationChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Box_KeyDown);
			this.BigTab.ResumeLayout(false);
			this.TabGeneral.ResumeLayout(false);
			this.TabDeco.ResumeLayout(false);
			this.TabTravel.ResumeLayout(false);
			this.TabProperties.ResumeLayout(false);
			this.TabItems.ResumeLayout(false);
			this.TabNPCs.ResumeLayout(false);
			this.TabAdmin.ResumeLayout(false);
			this.TabTools.ResumeLayout(false);
			this.TabDoors.ResumeLayout(false);
			this.TabLights.ResumeLayout(false);
			this.TabNotes.ResumeLayout(false);
			this.SmallTab.ResumeLayout(false);
			this.tabArt.ResumeLayout(false);
			this.tabMap.ResumeLayout(false);
			this.tabProps.ResumeLayout(false);
			this.tabCustom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.numHue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pctCap).EndInit();
			((System.ComponentModel.ISupportInitialize)this.imgHue).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		#region Variables
		/// <summary>
		///     When using the XMinimize option, this bypasses the closing check
		/// </summary>
		private bool m_Exit;

		/// <summary>
		///     The hue picker
		/// </summary>
		private readonly HuePicker m_HuePicker;

		/// <summary>
		///     The recent hues menu
		/// </summary>
		private RecentHuesMenu m_HuesMenu;

		/// <summary>
		///     Gets the name of the profile that should be loaded after this instance is closed
		/// </summary>
		public string NextProfile { get; private set; }
		#endregion

		/// <summary>
		///     Display tool tips on the map
		/// </summary>
		private void Map_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				// Do spawn tool tip
				var loc = Pandora.Map.PointToClient(MousePosition);
				var obj = Pandora.Map.FindDrawObject(loc, 6);

				if (obj != null && obj is SpawnDrawObject)
				{
					var spawn = obj as SpawnDrawObject;

					PopUpForm.PopUp(Pandora.BoxForm as Form, "Spawn Details", spawn.Spawn.ToolTipDetailed, true, null);
				}
				else
				{
					PopUpForm.PopUp(Pandora.BoxForm as Form, "No Spawn", "Nothing spawns here", true, null);
				}
			}
		}

		#region Minimizing, closing and tray behaviour
		/// <summary>
		///     OnClosing handler
		/// </summary>
		private void Box_Closing(object sender, CancelEventArgs e)
		{
			if (_profileManager.Profile.General.XMinimize)
			{
				if (!m_Exit)
				{
					e.Cancel = true;
					WindowState = FormWindowState.Minimized;
					return;
				}
			}

			// Save position
			if (WindowState == FormWindowState.Normal)
			{
				_profileManager.Profile.General.WindowLocation = Location;
			}

			// Save options
			_profileManager.Profile.Save();
		}

		/// <summary>
		///     Resizing: minimizing behaviour
		/// </summary>
		private void Box_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized && _profileManager.Profile.General.MinimizeToTray)
			{
				//ShowInTaskbar = true;
				ShowInTaskbar = false;
			}

			TopMost = _profileManager.Profile.General.TopMost;
		}

		/// <summary>
		///     Box site from the tray menu
		/// </summary>
		private void TrayBox_Click(object sender, EventArgs e)
		{
			// Issue 34:  	 Visit Website - Tarion
			_ = Process.Start("http://code.google.com/p/pandorasbox3/");
		}

		/// <summary>
		///     Options form from the tray menu
		/// </summary>
		private void TrayOptions_Click(object sender, EventArgs e)
		{
			var of = new OptionsForm(_profileManager);
			_ = of.ShowDialog(this);
		}

		/// <summary>
		///     Exiting from the tray
		/// </summary>
		private void TrayExit_Click(object sender, EventArgs e)
		{
			m_Exit = true;
			Close();
		}

		/// <summary>
		///     Occurs when the user changes the current profile through the menu
		/// </summary>
		private void ChangeProfile(object sender, EventArgs e)
		{
			if (!(sender is MenuItem mi))
			{
				return;
			}

			NextProfile = mi.Text;
			m_Exit = true;
			Close();
		}

		/// <summary>
		///     User creates a new profile through the menu
		/// </summary>
		private void miNewProfile_Click(object sender, EventArgs e)
		{
			_profileManager.Profile.Save();
			Pandora.CreateNewProfile();
		}

		/// <summary>
		///     Export profile
		/// </summary>
		private void miExportProfile_Click(object sender, EventArgs e)
		{
			_profileManager.ExportProfile();
		}

		/// <summary>
		///     Import profile
		/// </summary>
		private void miImportProfile_Click(object sender, EventArgs e)
		{
			var p = _profileManager.ImportProfile();

			if (p != null)
			{
				if (MessageBox.Show(
						this,
						Pandora.Localization.TextProvider["Misc.ProfileImport"],
						"",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ChangeProfile(p.Name);
				}
			}
		}

		/// <summary>
		///     Show about form
		/// </summary>
		private void miAbout_Click(object sender, EventArgs e)
		{
			var form = new AboutForm();
			_ = form.ShowDialog();
		}

		#region Box Menu
		private void bMenu_MouseEnter(object sender, EventArgs e)
		{
			bMenu.ImageIndex = 1;
		}

		private void bMenu_MouseLeave(object sender, EventArgs e)
		{
			bMenu.ImageIndex = 0;
		}

		private void bMenu_MouseDown_1(object sender, MouseEventArgs e)
		{
			TrayMenu.Show(bMenu, new Point(e.X, e.Y));
		}
		#endregion
		#endregion

		#region Hues
		/// <summary>
		///     Sets the correct value for the hue picker
		/// </summary>
		public int SelectedHue
		{
			set
			{
				if (value >= 0 && value <= 3000)
				{
					_profileManager.Profile.Hues.SelectedIndex = value;
					numHue.Value = value;
				}
			}
		}

		/// <summary>
		///     Hue numeric up and down: value changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numHue_ValueChanged(object sender, EventArgs e)
		{
			if (!Created)
			{
				return;
			}

			if (numHue.Value != 0)
			{
				m_HuePicker.SelectedHue = (int)numHue.Value;
				imgHue.Image = Pandora.Hues[(int)numHue.Value].GetSpectrum(imgHue.Size);
			}
			else
			{
				imgHue.Image.Dispose();
				imgHue.Image = null;
			}

			_profileManager.Profile.Hues.SelectedIndex = (int)numHue.Value;
		}

		/// <summary>
		///     Send Set Hue command
		/// </summary>
		private void bSetHue_Click(object sender, EventArgs e)
		{
			SetHue(null);
		}

		private void SetHue(string modifier)
		{
			_profileManager.Profile.Hues.SelectedIndex = (int)numHue.Value;

			_profileManager.Profile.Commands.DoSet("Hue", _profileManager.Profile.Hues.SelectedIndex.ToString(), modifier);
			Pandora.Prop.SetProperty("Hue", _profileManager.Profile.Hues.SelectedIndex.ToString(), null);
			_profileManager.Profile.Hues.RecentHues.Add(_profileManager.Profile.Hues.SelectedIndex);
		}

		/// <summary>
		///     Mouse down on the Hue Preview (open picker/menu)
		/// </summary>
		private void imgHue_MouseDown(object sender, MouseEventArgs e)
		{
			if (!imgHue.Enabled)
			{
				return;
			}

			if (e.Button == MouseButtons.Left)
			{
				m_HuePicker.Visible = !m_HuePicker.Visible;
				// m_HuePicker.ShowDialog();
				// numHue.Value = m_HuePicker.SelectedHue;
			}
			else if (e.Button == MouseButtons.Right)
			{
				m_HuesMenu.Show(imgHue, new Point(e.X, e.Y));
			}
		}

		/// <summary>
		///     A hue has been selected by the recent hues menu
		/// </summary>
		private void m_HuesMenu_HueClicked(object sender, EventArgs e)
		{
			numHue.Value = m_HuesMenu.SelectedHue;
		}
		#endregion

		#region Tabs managment
		/// <summary>
		///     Gets the names of the tabs displayed
		/// </summary>
		/// <returns>An array of strings containing the names of the tabs in the Box form</returns>
		public string[] GetTabNames()
		{
			var names = new string[BigTab.TabCount];

			for (var i = 0; i < names.Length; i++)
			{
				names[i] = BigTab.TabPages[i].Text;
			}

			return names;
		}

		/// <summary>
		///     Selects the tab displayed by the smaller tab
		/// </summary>
		/// <param name="tab">The SmallTabs value representing the small tab that should be selected</param>
		public void SelectSmallTab(SmallTabs tab)
		{
			TabPage page = null;

			switch (tab)
			{
				case SmallTabs.Art:
					page = tabArt;
					break;
				case SmallTabs.Map:
					page = tabMap;
					break;
				case SmallTabs.Props:
					page = tabProps;
					break;
			}

			if (SmallTab.SelectedTab != page)
			{
				SmallTab.SelectedTab = page;
			}
		}

		/// <summary>
		///     When something uses the map, bring it to front
		/// </summary>
		private void MapUsed(object sender, EventArgs e)
		{
			SmallTab.SelectedTab = tabMap;
		}

		/// <summary>
		///     Updates the zoom level in the options
		/// </summary>
		private void Map_ZoomLevelChanged(object sender, EventArgs e)
		{
			_profileManager.Profile.Travel.Zoom = Map.ZoomLevel;
		}
		#endregion

		#region Misc Methods
		/// <summary>
		///     KEYS
		/// </summary>
		private void Box_KeyDown(object sender, KeyEventArgs e)
		{
			if (BigTab.SelectedTab == TabTravel)
			{
				Travel.DoKeys(this, e);
			}
			else if (BigTab.SelectedTab == TabNPCs)
			{
				Mobiles.DoKeys(this, e);
			}
			else if (BigTab.SelectedTab == TabDeco)
			{
				m_TabDeco.DoKeys(this, e);
			}
			else if (BigTab.SelectedTab == TabItems)
			{
				m_ItemsTab.DoKeys(this, e);
			}
		}

		private void Box_Load(object sender, EventArgs e)
		{
			_splash.SetStatusText("Choosing language");
			Pandora.Localization.LocalizeControl(this);
			Pandora.Localization.LocalizeMenu(TrayMenu);

			_splash.SetStatusText("Repositioning");
			// Set position
			Location = _profileManager.Profile.General.WindowLocation;
			VerifyVisibility();
			ShowInTaskbar = _profileManager.Profile.General.ShowInTaskBar;

			// Display spawns
			if (_profileManager.Profile.Travel.ShowSpawns && SpawnData.SpawnProvider != null)
			{
				_splash.SetStatusText("Spawning...");
				SpawnData.SpawnProvider.RefreshSpawns();
			}

			_splash.SetStatusText("Artwork setup");
			// Set options on the art viewer
			Pandora.Art.RoomView = _profileManager.Profile.General.RoomView;
			Pandora.Art.ResizeTallItems = _profileManager.Profile.General.Scale;
			Pandora.Art.Animate = _profileManager.Profile.General.Animate;
			Pandora.Art.BackColor = _profileManager.Profile.General.ArtBackground.Color;

			// Go online
			if (_profileManager.Profile.Server.Enabled && _profileManager.Profile.Server.ConnectOnStartup)
			{
				_splash.SetStatusText("Connecting to BoxServer");
				var form = new BoxServerForm(true);
				_ = form.ShowDialog();
			}

			// Startup programs
			_splash.SetStatusText("Launching startup programs");
			_profileManager.Profile.Launcher.PerformStartup();

			Text = String.Format(
				Pandora.Localization.TextProvider["Misc.BoxTitle"],
				_profileManager.Profile.Name,
				Pandora.BoxConnection.Connected
					? Pandora.Localization.TextProvider["Misc.Online"]
					: Pandora.Localization.TextProvider["Misc.Offline"]);

			// Set startup tab
			if (_profileManager.Profile.General.StartupTab != null)
			{
				foreach (TabPage page in BigTab.TabPages)
				{
					if (page.Text == _profileManager.Profile.General.StartupTab)
					{
						BigTab.SelectedTab = page;
						break;
					}
				}
			}

			_splash.SetStatusText("Building tips and menus");

			// Tooltips
			Pandora.ToolTip.SetToolTip(pctCap, Pandora.Localization.TextProvider["Tips.Screenshot"]);

			// Build profiles menu items
			var miNewProfile = new MenuItem(Pandora.Localization.TextProvider["Common.New"]);
			miNewProfile.Click += miNewProfile_Click;
			_ = miProfile.MenuItems.Add(miNewProfile);

			var miExportProfile = new MenuItem(Pandora.Localization.TextProvider["Common.Export"]);
			miExportProfile.Click += miExportProfile_Click;
			_ = miProfile.MenuItems.Add(miExportProfile);

			var miImportProfile = new MenuItem(Pandora.Localization.TextProvider["Common.Import"]);
			miImportProfile.Click += miImportProfile_Click;
			_ = miProfile.MenuItems.Add(miImportProfile);

			_ = miProfile.MenuItems.Add(new MenuItem("-"));

			foreach (var s in Profile.ExistingProfiles)
			{
				var mi = new MenuItem(s)
				{
					Checked = s == _profileManager.Profile.Name
				};
				if (!mi.Checked)
				{
					mi.Click += ChangeProfile;
				}
				else
				{
					mi.Enabled = false;
				}

				_ = miProfile.MenuItems.Add(mi);
			}

			bSetHue.Tag = new CommandCallback(SetHue);
			bSetHue.ContextMenu = Pandora.cmModifiers;

			_splash.Close();
			Utility.BringWindowToFront(Handle);
		}

		/// <summary>
		///     Manage the small tab accordingly
		/// </summary>
		private void BigTab_SelectedIndexChanged(object sender, EventArgs e)
		{
			var page = BigTab.SelectedTab;

			if (page == TabTravel)
			{
				SmallTab.SelectedTab = tabMap;
			}
			else if (page == TabNPCs)
			{
				SmallTab.SelectedTab = tabArt;

				Pandora.Art.Art = ArtViewer.Art.NPCs;
				Pandora.Art.ArtIndex = _profileManager.Profile.Mobiles.ArtIndex;
				Mobiles.RefreshArt();
			}
			else if (page == TabProperties)
			{
				SmallTab.SelectedTab = tabProps;
			}
			else if (page == TabDeco)
			{
				SmallTab.SelectedTab = tabArt;

				Pandora.Art.Art = ArtViewer.Art.Items;
				Pandora.Art.ArtIndex = _profileManager.Profile.Deco.ArtIndex;

				if (_profileManager.Profile.Deco.Hued)
				{
					Pandora.Art.Hue = _profileManager.Profile.Hues.SelectedIndex;
				}
				else
				{
					Pandora.Art.Hue = 0;
				}
			}
			else if (page == TabItems)
			{
				SmallTab.SelectedTab = tabArt;

				Pandora.Art.Art = ArtViewer.Art.Items;

				Pandora.Art.ArtIndex = _profileManager.Profile.Items.ArtIndex;
				Pandora.Art.Hue = _profileManager.Profile.Items.ArtHue;
			}
		}

		/// <summary>
		///     Moves the window if it doesn't fit correctly
		/// </summary>
		private void VerifyVisibility()
		{
			if (Left < 0)
			{
				Left = 0;
			}

			if (Top < 0)
			{
				Top = 0;
			}

			double xdelta = Right - SystemInformation.WorkingArea.Width;
			double ydelta = Bottom - SystemInformation.WorkingArea.Height;

			if (xdelta > 0)
			{
				var xPercentage = xdelta / Width;

				if (xPercentage > .30)
				{
					Left = SystemInformation.WorkingArea.Width - Width;
				}
			}

			if (ydelta > 0)
			{
				var yPercentage = ydelta / Height;

				if (yPercentage > .30)
				{
					Top = SystemInformation.WorkingArea.Height - Height;
				}
			}
		}

		/// <summary>
		///     Updates all the views using BoxData as data source
		/// </summary>
		public void UpdateBoxData()
		{
			Mobiles.RefreshData();
			m_ItemsTab.UpdateBoxData();
		}

		/// <summary>
		///     Click the tray menu brings up the window
		/// </summary>
		private void Tray_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (WindowState == FormWindowState.Minimized)
				{
					WindowState = FormWindowState.Normal;
					ShowInTaskbar = _profileManager.Profile.General.ShowInTaskBar;
				}

				Activate();
			}
		}

		/// <summary>
		///     Box Form moved: save the location in the options
		/// </summary>
		private void Box_LocationChanged(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
			{
				_profileManager.Profile.General.WindowLocation = Location;
			}
		}

		/// <summary>
		///     Closes the current form and switches to a different profile
		/// </summary>
		/// <param name="nextProfile">The name of the next profile</param>
		public void ChangeProfile(string nextProfile)
		{
			NextProfile = nextProfile;
			m_Exit = true;
			Close();
		}
		#endregion

		#region Screen Capture
		/// <summary>
		///     Draw border
		/// </summary>
		private void pctCap_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(pctCap, e.Graphics);
		}

		private void pctCap_MouseEnter(object sender, EventArgs e)
		{
			pctCap.BackColor = SystemColors.ControlLightLight;
		}

		private void pctCap_MouseLeave(object sender, EventArgs e)
		{
			pctCap.BackColor = SystemColors.Control;
		}

		private void pctCap_MouseDown(object sender, MouseEventArgs e)
		{
			pctCap.BackColor = SystemColors.Window;

			if (e.Button == MouseButtons.Left)
			{
				// Take screenie
				_profileManager.Profile.Screenshots.Capture();
			}
			else
			{
				// Show screenshot control
				var form = new CapForm();
				_ = form.ShowDialog();
			}
		}

		private void pctCap_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.X >= 0 && e.X < pctCap.Right && e.Y >= 0 && e.Y <= pctCap.Bottom)
			{
				pctCap.BackColor = SystemColors.ControlLightLight;
			}
			else
			{
				pctCap.BackColor = SystemColors.Control;
			}
		}
		#endregion

		/// <summary>
		///     Show the application data folder
		/// </summary>
		private void miViewDataFolder_Click(object sender, EventArgs e)
		{
			try
			{
				_ = Process.Start(Pandora.ApplicationDataFolder);
			}
			catch
			{ }
		}

		/// <summary>
		///     Show the log file
		/// </summary>
		private void miViewLog_Click(object sender, EventArgs e)
		{
			var log = Path.Combine(Pandora.ApplicationDataFolder, "Log.txt");

			if (File.Exists(log))
			{
				try
				{
					_ = Process.Start(log);
				}
				catch
				{ }
			}
		}

		/// <summary>
		///     Updates the button style according to the options
		/// </summary>
		public void UpdateButtonStyle()
		{
			var flat = FlatStyle.System;

			if (_profileManager.Profile.General.FlatButtons)
			{
				flat = FlatStyle.Flat;
			}

			SetButtonStyle(this, flat);
		}

		/// <summary>
		///     Sets a style on the buttons on a control
		/// </summary>
		/// <param name="c">The control that should have the style set</param>
		/// <param name="style">The style being applied</param>
		private void SetButtonStyle(Control c, FlatStyle style)
		{
			if (c is ButtonBase b)
			{
				b.FlatStyle = style;
			}

			foreach (Control child in c.Controls)
			{
				SetButtonStyle(child, style);
			}
		}

		private void bMenu_Click(object sender, EventArgs e)
		{ }

		private void boxButton1_Click(object sender, EventArgs e)
		{ }
	}
}