#region Header
// /*
//  *    2018 - Pandora - OptionsForm.cs
//  */
#endregion

#region References
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Data;
using TheBox.Options;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for OptionsForm.
	/// </summary>
	public class OptionsForm : Form
	{
		private TabControl tabControl1;
		private GroupBox groupBox1;
		private CheckBox chkTopmost;
		private CheckBox chkTaskbar;
		private CheckBox chkTray;
		private CheckBox chkXMin;
		private GroupBox groupBox2;
		private Label label1;
		private Label labUOFolder;
		private Button bBrowseUOFolder;
		private FolderBrowserDialog FolderBrowser;
		private TrackBar barOpacity;
		private Label label2;
		private GroupBox groupBox3;
		private TextBox txCmdPrefix;
		private Label label3;
		private CheckBox chkDrawStatics;
		private CheckBox chkSelectedMapLocations;
		private CheckBox chkScale;
		private CheckBox chkRoomView;
		private CheckBox chkAnimate;
		private GroupBox groupBox4;
		private TextBox txArtBackground;
		private ColorDialog ColorChooser;
		private LinkLabel linkLabel1;
		private TabPage pCommands;
		private PropertyGrid propCommands;
		private CheckBox chkShowSpawns;
		private Label SpawnColorPreview;
		private LinkLabel linkSpawnColor;
		private TabPage pGeneral;
		private TabPage pTravel;
		private TabPage pServer;
		private CheckBox chkUseServer;
		private GroupBox grpServer;
		private Label label4;
		private Label label5;
		private TextBox txAddress;
		private Label label6;
		private Label label7;
		private CheckBox chkConnStartup;
		private NumericUpDown numPort;
		private TextBox txUser;
		private TextBox txPass;
		private GroupBox groupBox5;
		private CheckBox chkMap0;
		private CheckBox chkMap1;
		private CheckBox chkMap2;
		private CheckBox chkMap3;
		private CheckBox chkMap4;
		private CheckBox chkMap5;
		private TextBox txMap0;
		private TextBox txMap1;
		private TextBox txMap2;
		private TextBox txMap3;
		private TextBox txMap4;
		private TextBox txMap5;
		private Button bImport0;
		private Button bImport1;
		private Button bImport2;
		private Button bImport3;
		private Button bImport4;
		private Button bImport5;
		private OpenFileDialog OpenFile;
		private Button bCalcMaps;
		private LinkLabel lnkImportData;
		private ContextMenu cmImport;
		private MenuItem cmImportBoxData;
		private MenuItem cmImportSpawnData;
		private MenuItem cmImportSpawnGroups;
		private MenuItem cmImportPropsData;
		private TabPage pProfiles;
		private GroupBox groupBox6;
		private Label label8;
		private TextBox txProfName;
		private Label label9;
		private ComboBox cmbLang;
		private Button bExportProfile;
		private ListBox lstProfiles;
		private Label label10;
		private Button bNewProfile;
		private Button bImportProfile;
		private Button bDeleteProfile;
		private Button bDefaultProfile;
		private Button bResetDefaultProfile;
		private Label labDefaultProfile;
		private CheckBox chkShowCustom;
		private Button button1;
		private Button bUpdatePassword;
		private LinkLabel lnkLinkColor;
		private TextBox txLinkColor;
		private TabPage pAdv;
		private GroupBox groupBox7;
		private Label labCustomClient;
		private Button bClearCustClient;
		private Button bBrowseCustomClient;
		private Label labSelTab;
		private ComboBox cmbTabs;
		private GroupBox groupBox8;
		private TreeView tModifiers;
		private Button bAddModifier;
		private Button bDeleteModifier;
		private Button bMoveDownModifier;
		private Button bMoveUpModifier;
		private TextBox txModifier;
		private Label label11;
		private Button bLoad;
		private Button bRestoreDefLocations;
		private LinkLabel lnkViewDataFolder;
		private CheckBox chkFlat;
		private CheckBox chkSHA1;
		private CheckBox chkXRay;

		private bool m_ApplyOptions;
		private readonly ProfileManager _profileManager;

		public OptionsForm(ProfileManager profileManager)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);
			_profileManager = profileManager;
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pGeneral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txArtBackground = new System.Windows.Forms.TextBox();
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.chkRoomView = new System.Windows.Forms.CheckBox();
            this.chkScale = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lnkLinkColor = new System.Windows.Forms.LinkLabel();
            this.txLinkColor = new System.Windows.Forms.TextBox();
            this.lnkImportData = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txCmdPrefix = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkXMin = new System.Windows.Forms.CheckBox();
            this.chkTray = new System.Windows.Forms.CheckBox();
            this.chkTaskbar = new System.Windows.Forms.CheckBox();
            this.chkTopmost = new System.Windows.Forms.CheckBox();
            this.barOpacity = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bBrowseUOFolder = new System.Windows.Forms.Button();
            this.labUOFolder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pTravel = new System.Windows.Forms.TabPage();
            this.chkXRay = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bRestoreDefLocations = new System.Windows.Forms.Button();
            this.bCalcMaps = new System.Windows.Forms.Button();
            this.bImport5 = new System.Windows.Forms.Button();
            this.bImport4 = new System.Windows.Forms.Button();
            this.bImport3 = new System.Windows.Forms.Button();
            this.bImport2 = new System.Windows.Forms.Button();
            this.bImport1 = new System.Windows.Forms.Button();
            this.bImport0 = new System.Windows.Forms.Button();
            this.txMap5 = new System.Windows.Forms.TextBox();
            this.txMap4 = new System.Windows.Forms.TextBox();
            this.txMap3 = new System.Windows.Forms.TextBox();
            this.txMap2 = new System.Windows.Forms.TextBox();
            this.txMap1 = new System.Windows.Forms.TextBox();
            this.txMap0 = new System.Windows.Forms.TextBox();
            this.chkMap5 = new System.Windows.Forms.CheckBox();
            this.chkMap4 = new System.Windows.Forms.CheckBox();
            this.chkMap3 = new System.Windows.Forms.CheckBox();
            this.chkMap2 = new System.Windows.Forms.CheckBox();
            this.chkMap1 = new System.Windows.Forms.CheckBox();
            this.chkMap0 = new System.Windows.Forms.CheckBox();
            this.linkSpawnColor = new System.Windows.Forms.LinkLabel();
            this.SpawnColorPreview = new System.Windows.Forms.Label();
            this.chkShowSpawns = new System.Windows.Forms.CheckBox();
            this.chkDrawStatics = new System.Windows.Forms.CheckBox();
            this.chkSelectedMapLocations = new System.Windows.Forms.CheckBox();
            this.pServer = new System.Windows.Forms.TabPage();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.chkSHA1 = new System.Windows.Forms.CheckBox();
            this.bUpdatePassword = new System.Windows.Forms.Button();
            this.chkConnStartup = new System.Windows.Forms.CheckBox();
            this.txPass = new System.Windows.Forms.TextBox();
            this.txUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txAddress = new System.Windows.Forms.TextBox();
            this.chkUseServer = new System.Windows.Forms.CheckBox();
            this.pAdv = new System.Windows.Forms.TabPage();
            this.chkFlat = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txModifier = new System.Windows.Forms.TextBox();
            this.bMoveUpModifier = new System.Windows.Forms.Button();
            this.bMoveDownModifier = new System.Windows.Forms.Button();
            this.bDeleteModifier = new System.Windows.Forms.Button();
            this.bAddModifier = new System.Windows.Forms.Button();
            this.tModifiers = new System.Windows.Forms.TreeView();
            this.cmbTabs = new System.Windows.Forms.ComboBox();
            this.labSelTab = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bBrowseCustomClient = new System.Windows.Forms.Button();
            this.bClearCustClient = new System.Windows.Forms.Button();
            this.labCustomClient = new System.Windows.Forms.Label();
            this.chkShowCustom = new System.Windows.Forms.CheckBox();
            this.lnkViewDataFolder = new System.Windows.Forms.LinkLabel();
            this.pCommands = new System.Windows.Forms.TabPage();
            this.propCommands = new System.Windows.Forms.PropertyGrid();
            this.pProfiles = new System.Windows.Forms.TabPage();
            this.bLoad = new System.Windows.Forms.Button();
            this.labDefaultProfile = new System.Windows.Forms.Label();
            this.bResetDefaultProfile = new System.Windows.Forms.Button();
            this.bDefaultProfile = new System.Windows.Forms.Button();
            this.bDeleteProfile = new System.Windows.Forms.Button();
            this.bImportProfile = new System.Windows.Forms.Button();
            this.bNewProfile = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txProfName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bExportProfile = new System.Windows.Forms.Button();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ColorChooser = new System.Windows.Forms.ColorDialog();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.cmImport = new System.Windows.Forms.ContextMenu();
            this.cmImportBoxData = new System.Windows.Forms.MenuItem();
            this.cmImportPropsData = new System.Windows.Forms.MenuItem();
            this.cmImportSpawnData = new System.Windows.Forms.MenuItem();
            this.cmImportSpawnGroups = new System.Windows.Forms.MenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.pGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pTravel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pServer.SuspendLayout();
            this.grpServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.pAdv.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.pCommands.SuspendLayout();
            this.pProfiles.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pGeneral);
            this.tabControl1.Controls.Add(this.pTravel);
            this.tabControl1.Controls.Add(this.pServer);
            this.tabControl1.Controls.Add(this.pAdv);
            this.tabControl1.Controls.Add(this.pCommands);
            this.tabControl1.Controls.Add(this.pProfiles);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 392);
            this.tabControl1.TabIndex = 0;
            // 
            // pGeneral
            // 
            this.pGeneral.Controls.Add(this.groupBox4);
            this.pGeneral.Controls.Add(this.groupBox3);
            this.pGeneral.Controls.Add(this.groupBox1);
            this.pGeneral.Controls.Add(this.groupBox2);
            this.pGeneral.Location = new System.Drawing.Point(4, 22);
            this.pGeneral.Name = "pGeneral";
            this.pGeneral.Size = new System.Drawing.Size(392, 366);
            this.pGeneral.TabIndex = 0;
            this.pGeneral.Text = "Tabs.General";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.txArtBackground);
            this.groupBox4.Controls.Add(this.chkAnimate);
            this.groupBox4.Controls.Add(this.chkRoomView);
            this.groupBox4.Controls.Add(this.chkScale);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(8, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 72);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options.ArtPreview";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(216, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(152, 23);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Options.ArtBack";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txArtBackground
            // 
            this.txArtBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txArtBackground.Enabled = false;
            this.txArtBackground.Location = new System.Drawing.Point(192, 40);
            this.txArtBackground.Name = "txArtBackground";
            this.txArtBackground.ReadOnly = true;
            this.txArtBackground.Size = new System.Drawing.Size(20, 20);
            this.txArtBackground.TabIndex = 5;
            // 
            // chkAnimate
            // 
            this.chkAnimate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAnimate.Location = new System.Drawing.Point(192, 16);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(176, 24);
            this.chkAnimate.TabIndex = 4;
            this.chkAnimate.Text = "Options.Animate";
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.chkAnimate_CheckedChanged);
            // 
            // chkRoomView
            // 
            this.chkRoomView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRoomView.Location = new System.Drawing.Point(8, 16);
            this.chkRoomView.Name = "chkRoomView";
            this.chkRoomView.Size = new System.Drawing.Size(168, 24);
            this.chkRoomView.TabIndex = 3;
            this.chkRoomView.Text = "Options.RoomView";
            this.chkRoomView.CheckedChanged += new System.EventHandler(this.chkRoomView_CheckedChanged);
            // 
            // chkScale
            // 
            this.chkScale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkScale.Location = new System.Drawing.Point(8, 40);
            this.chkScale.Name = "chkScale";
            this.chkScale.Size = new System.Drawing.Size(168, 24);
            this.chkScale.TabIndex = 2;
            this.chkScale.Text = "Options.Scale";
            this.chkScale.CheckedChanged += new System.EventHandler(this.chkScale_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lnkLinkColor);
            this.groupBox3.Controls.Add(this.txLinkColor);
            this.groupBox3.Controls.Add(this.lnkImportData);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txCmdPrefix);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(8, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 80);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Common.Miscellaneous";
            // 
            // lnkLinkColor
            // 
            this.lnkLinkColor.LinkColor = System.Drawing.Color.BlueViolet;
            this.lnkLinkColor.Location = new System.Drawing.Point(32, 36);
            this.lnkLinkColor.Name = "lnkLinkColor";
            this.lnkLinkColor.Size = new System.Drawing.Size(96, 16);
            this.lnkLinkColor.TabIndex = 8;
            this.lnkLinkColor.TabStop = true;
            this.lnkLinkColor.Text = "Options.LinkColor";
            this.lnkLinkColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkLinkColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkColor_LinkClicked);
            // 
            // txLinkColor
            // 
            this.txLinkColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txLinkColor.Enabled = false;
            this.txLinkColor.Location = new System.Drawing.Point(8, 36);
            this.txLinkColor.Name = "txLinkColor";
            this.txLinkColor.ReadOnly = true;
            this.txLinkColor.Size = new System.Drawing.Size(20, 20);
            this.txLinkColor.TabIndex = 7;
            // 
            // lnkImportData
            // 
            this.lnkImportData.Location = new System.Drawing.Point(8, 60);
            this.lnkImportData.Name = "lnkImportData";
            this.lnkImportData.Size = new System.Drawing.Size(112, 16);
            this.lnkImportData.TabIndex = 2;
            this.lnkImportData.TabStop = true;
            this.lnkImportData.Text = "Options.ImportData";
            this.lnkImportData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkImportData_MouseDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Options.CmdPrefix";
            // 
            // txCmdPrefix
            // 
            this.txCmdPrefix.Location = new System.Drawing.Point(104, 12);
            this.txCmdPrefix.Name = "txCmdPrefix";
            this.txCmdPrefix.Size = new System.Drawing.Size(32, 20);
            this.txCmdPrefix.TabIndex = 0;
            this.txCmdPrefix.TextChanged += new System.EventHandler(this.txCmdPrefix_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkXMin);
            this.groupBox1.Controls.Add(this.chkTray);
            this.groupBox1.Controls.Add(this.chkTaskbar);
            this.groupBox1.Controls.Add(this.chkTopmost);
            this.groupBox1.Controls.Add(this.barOpacity);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options.Window";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Options.Opacity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkXMin
            // 
            this.chkXMin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkXMin.Location = new System.Drawing.Point(200, 40);
            this.chkXMin.Name = "chkXMin";
            this.chkXMin.Size = new System.Drawing.Size(152, 24);
            this.chkXMin.TabIndex = 3;
            this.chkXMin.Text = "Options.XClose";
            this.chkXMin.CheckedChanged += new System.EventHandler(this.chkXMin_CheckedChanged);
            // 
            // chkTray
            // 
            this.chkTray.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTray.Location = new System.Drawing.Point(8, 40);
            this.chkTray.Name = "chkTray";
            this.chkTray.Size = new System.Drawing.Size(152, 24);
            this.chkTray.TabIndex = 2;
            this.chkTray.Text = "Options.Tray";
            this.chkTray.CheckedChanged += new System.EventHandler(this.chkTray_CheckedChanged);
            // 
            // chkTaskbar
            // 
            this.chkTaskbar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTaskbar.Location = new System.Drawing.Point(200, 16);
            this.chkTaskbar.Name = "chkTaskbar";
            this.chkTaskbar.Size = new System.Drawing.Size(104, 24);
            this.chkTaskbar.TabIndex = 1;
            this.chkTaskbar.Text = "Options.Taskbar";
            this.chkTaskbar.CheckedChanged += new System.EventHandler(this.chkTaskbar_CheckedChanged);
            // 
            // chkTopmost
            // 
            this.chkTopmost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTopmost.Location = new System.Drawing.Point(8, 16);
            this.chkTopmost.Name = "chkTopmost";
            this.chkTopmost.Size = new System.Drawing.Size(104, 24);
            this.chkTopmost.TabIndex = 0;
            this.chkTopmost.Text = "Options.Topmost";
            this.chkTopmost.CheckedChanged += new System.EventHandler(this.chkTopmost_CheckedChanged);
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Location = new System.Drawing.Point(96, 64);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 40;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Size = new System.Drawing.Size(272, 30);
            this.barOpacity.TabIndex = 4;
            this.barOpacity.TabStop = false;
            this.barOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barOpacity.Value = 100;
            this.barOpacity.Scroll += new System.EventHandler(this.barOpacity_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bBrowseUOFolder);
            this.groupBox2.Controls.Add(this.labUOFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(8, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options.UOFolder";
            // 
            // bBrowseUOFolder
            // 
            this.bBrowseUOFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bBrowseUOFolder.Location = new System.Drawing.Point(11, 42);
            this.bBrowseUOFolder.Name = "bBrowseUOFolder";
            this.bBrowseUOFolder.Size = new System.Drawing.Size(75, 23);
            this.bBrowseUOFolder.TabIndex = 3;
            this.bBrowseUOFolder.Text = "Common.Browse";
            this.bBrowseUOFolder.Click += new System.EventHandler(this.bBrowseUOFolder_Click);
            // 
            // labUOFolder
            // 
            this.labUOFolder.Location = new System.Drawing.Point(88, 16);
            this.labUOFolder.Name = "labUOFolder";
            this.labUOFolder.Size = new System.Drawing.Size(280, 23);
            this.labUOFolder.TabIndex = 1;
            this.labUOFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labUOFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.labUOFolder_Paint);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Common.Default";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pTravel
            // 
            this.pTravel.Controls.Add(this.chkXRay);
            this.pTravel.Controls.Add(this.groupBox5);
            this.pTravel.Controls.Add(this.linkSpawnColor);
            this.pTravel.Controls.Add(this.SpawnColorPreview);
            this.pTravel.Controls.Add(this.chkShowSpawns);
            this.pTravel.Controls.Add(this.chkDrawStatics);
            this.pTravel.Controls.Add(this.chkSelectedMapLocations);
            this.pTravel.Location = new System.Drawing.Point(4, 22);
            this.pTravel.Name = "pTravel";
            this.pTravel.Size = new System.Drawing.Size(392, 366);
            this.pTravel.TabIndex = 1;
            this.pTravel.Text = "Common.Maps";
            // 
            // chkXRay
            // 
            this.chkXRay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkXRay.Location = new System.Drawing.Point(208, 8);
            this.chkXRay.Name = "chkXRay";
            this.chkXRay.Size = new System.Drawing.Size(176, 24);
            this.chkXRay.TabIndex = 9;
            this.chkXRay.Text = "X-Ray View";
            this.chkXRay.CheckedChanged += new System.EventHandler(this.chkXRay_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bRestoreDefLocations);
            this.groupBox5.Controls.Add(this.bCalcMaps);
            this.groupBox5.Controls.Add(this.bImport5);
            this.groupBox5.Controls.Add(this.bImport4);
            this.groupBox5.Controls.Add(this.bImport3);
            this.groupBox5.Controls.Add(this.bImport2);
            this.groupBox5.Controls.Add(this.bImport1);
            this.groupBox5.Controls.Add(this.bImport0);
            this.groupBox5.Controls.Add(this.txMap5);
            this.groupBox5.Controls.Add(this.txMap4);
            this.groupBox5.Controls.Add(this.txMap3);
            this.groupBox5.Controls.Add(this.txMap2);
            this.groupBox5.Controls.Add(this.txMap1);
            this.groupBox5.Controls.Add(this.txMap0);
            this.groupBox5.Controls.Add(this.chkMap5);
            this.groupBox5.Controls.Add(this.chkMap4);
            this.groupBox5.Controls.Add(this.chkMap3);
            this.groupBox5.Controls.Add(this.chkMap2);
            this.groupBox5.Controls.Add(this.chkMap1);
            this.groupBox5.Controls.Add(this.chkMap0);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Location = new System.Drawing.Point(8, 118);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(376, 245);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Common.Maps";
            // 
            // bRestoreDefLocations
            // 
            this.bRestoreDefLocations.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bRestoreDefLocations.Location = new System.Drawing.Point(24, 182);
            this.bRestoreDefLocations.Name = "bRestoreDefLocations";
            this.bRestoreDefLocations.Size = new System.Drawing.Size(328, 20);
            this.bRestoreDefLocations.TabIndex = 13;
            this.bRestoreDefLocations.Text = "Options.DefLoc";
            this.bRestoreDefLocations.Click += new System.EventHandler(this.bRestoreDefLocations_Click);
            // 
            // bCalcMaps
            // 
            this.bCalcMaps.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCalcMaps.Location = new System.Drawing.Point(24, 206);
            this.bCalcMaps.Name = "bCalcMaps";
            this.bCalcMaps.Size = new System.Drawing.Size(328, 20);
            this.bCalcMaps.TabIndex = 12;
            this.bCalcMaps.Text = "Options.CalcMaps";
            this.bCalcMaps.Click += new System.EventHandler(this.bCalcMaps_Click);
            // 
            // bImport5
            // 
            this.bImport5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport5.Location = new System.Drawing.Point(280, 146);
            this.bImport5.Name = "bImport5";
            this.bImport5.Size = new System.Drawing.Size(72, 20);
            this.bImport5.TabIndex = 19;
            this.bImport5.Text = "Common.Import";
            this.bImport5.Click += new System.EventHandler(this.bImport5_Click);
            // 
            // bImport4
            // 
            this.bImport4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport4.Location = new System.Drawing.Point(280, 120);
            this.bImport4.Name = "bImport4";
            this.bImport4.Size = new System.Drawing.Size(72, 20);
            this.bImport4.TabIndex = 16;
            this.bImport4.Text = "Common.Import";
            this.bImport4.Click += new System.EventHandler(this.bImport4_Click);
            // 
            // bImport3
            // 
            this.bImport3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport3.Location = new System.Drawing.Point(280, 96);
            this.bImport3.Name = "bImport3";
            this.bImport3.Size = new System.Drawing.Size(72, 20);
            this.bImport3.TabIndex = 11;
            this.bImport3.Text = "Common.Import";
            this.bImport3.Click += new System.EventHandler(this.bImport3_Click);
            // 
            // bImport2
            // 
            this.bImport2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport2.Location = new System.Drawing.Point(280, 72);
            this.bImport2.Name = "bImport2";
            this.bImport2.Size = new System.Drawing.Size(72, 20);
            this.bImport2.TabIndex = 10;
            this.bImport2.Text = "Common.Import";
            this.bImport2.Click += new System.EventHandler(this.bImport2_Click);
            // 
            // bImport1
            // 
            this.bImport1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport1.Location = new System.Drawing.Point(280, 48);
            this.bImport1.Name = "bImport1";
            this.bImport1.Size = new System.Drawing.Size(72, 20);
            this.bImport1.TabIndex = 9;
            this.bImport1.Text = "Common.Import";
            this.bImport1.Click += new System.EventHandler(this.bImport1_Click);
            // 
            // bImport0
            // 
            this.bImport0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImport0.Location = new System.Drawing.Point(280, 24);
            this.bImport0.Name = "bImport0";
            this.bImport0.Size = new System.Drawing.Size(72, 20);
            this.bImport0.TabIndex = 8;
            this.bImport0.Text = "Common.Import";
            this.bImport0.Click += new System.EventHandler(this.bImport0_Click);
            // 
            // txMap5
            // 
            this.txMap5.Location = new System.Drawing.Point(56, 146);
            this.txMap5.Name = "txMap5";
            this.txMap5.Size = new System.Drawing.Size(208, 20);
            this.txMap5.TabIndex = 18;
            this.txMap5.TextChanged += new System.EventHandler(this.txMap5_TextChanged);
            // 
            // txMap4
            // 
            this.txMap4.Location = new System.Drawing.Point(56, 120);
            this.txMap4.Name = "txMap4";
            this.txMap4.Size = new System.Drawing.Size(208, 20);
            this.txMap4.TabIndex = 15;
            this.txMap4.TextChanged += new System.EventHandler(this.txMap4_TextChanged);
            // 
            // txMap3
            // 
            this.txMap3.Location = new System.Drawing.Point(56, 96);
            this.txMap3.Name = "txMap3";
            this.txMap3.Size = new System.Drawing.Size(208, 20);
            this.txMap3.TabIndex = 7;
            this.txMap3.TextChanged += new System.EventHandler(this.txMap3_TextChanged);
            // 
            // txMap2
            // 
            this.txMap2.Location = new System.Drawing.Point(56, 72);
            this.txMap2.Name = "txMap2";
            this.txMap2.Size = new System.Drawing.Size(208, 20);
            this.txMap2.TabIndex = 6;
            this.txMap2.TextChanged += new System.EventHandler(this.txMap2_TextChanged);
            // 
            // txMap1
            // 
            this.txMap1.Location = new System.Drawing.Point(56, 48);
            this.txMap1.Name = "txMap1";
            this.txMap1.Size = new System.Drawing.Size(208, 20);
            this.txMap1.TabIndex = 5;
            this.txMap1.TextChanged += new System.EventHandler(this.txMap1_TextChanged);
            // 
            // txMap0
            // 
            this.txMap0.Location = new System.Drawing.Point(56, 24);
            this.txMap0.Name = "txMap0";
            this.txMap0.Size = new System.Drawing.Size(208, 20);
            this.txMap0.TabIndex = 4;
            this.txMap0.TextChanged += new System.EventHandler(this.txMap0_TextChanged);
            // 
            // chkMap5
            // 
            this.chkMap5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap5.Location = new System.Drawing.Point(24, 146);
            this.chkMap5.Name = "chkMap5";
            this.chkMap5.Size = new System.Drawing.Size(32, 24);
            this.chkMap5.TabIndex = 17;
            this.chkMap5.Text = "5";
            this.chkMap5.CheckedChanged += new System.EventHandler(this.chkMap5_CheckedChanged);
            // 
            // chkMap4
            // 
            this.chkMap4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap4.Location = new System.Drawing.Point(24, 120);
            this.chkMap4.Name = "chkMap4";
            this.chkMap4.Size = new System.Drawing.Size(32, 24);
            this.chkMap4.TabIndex = 14;
            this.chkMap4.Text = "4";
            this.chkMap4.CheckedChanged += new System.EventHandler(this.chkMap4_CheckedChanged);
            // 
            // chkMap3
            // 
            this.chkMap3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap3.Location = new System.Drawing.Point(24, 96);
            this.chkMap3.Name = "chkMap3";
            this.chkMap3.Size = new System.Drawing.Size(32, 24);
            this.chkMap3.TabIndex = 3;
            this.chkMap3.Text = "3";
            this.chkMap3.CheckedChanged += new System.EventHandler(this.chkMap3_CheckedChanged);
            // 
            // chkMap2
            // 
            this.chkMap2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap2.Location = new System.Drawing.Point(24, 72);
            this.chkMap2.Name = "chkMap2";
            this.chkMap2.Size = new System.Drawing.Size(32, 24);
            this.chkMap2.TabIndex = 2;
            this.chkMap2.Text = "2";
            this.chkMap2.CheckedChanged += new System.EventHandler(this.chkMap2_CheckedChanged);
            // 
            // chkMap1
            // 
            this.chkMap1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap1.Location = new System.Drawing.Point(24, 48);
            this.chkMap1.Name = "chkMap1";
            this.chkMap1.Size = new System.Drawing.Size(32, 24);
            this.chkMap1.TabIndex = 1;
            this.chkMap1.Text = "1";
            this.chkMap1.CheckedChanged += new System.EventHandler(this.chkMap1_CheckedChanged);
            // 
            // chkMap0
            // 
            this.chkMap0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMap0.Location = new System.Drawing.Point(24, 24);
            this.chkMap0.Name = "chkMap0";
            this.chkMap0.Size = new System.Drawing.Size(32, 24);
            this.chkMap0.TabIndex = 0;
            this.chkMap0.Text = "0";
            this.chkMap0.CheckedChanged += new System.EventHandler(this.chkMap0_CheckedChanged);
            // 
            // linkSpawnColor
            // 
            this.linkSpawnColor.Location = new System.Drawing.Point(40, 86);
            this.linkSpawnColor.Name = "linkSpawnColor";
            this.linkSpawnColor.Size = new System.Drawing.Size(344, 23);
            this.linkSpawnColor.TabIndex = 6;
            this.linkSpawnColor.TabStop = true;
            this.linkSpawnColor.Text = "Options.SpawnColor";
            this.linkSpawnColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkSpawnColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // SpawnColorPreview
            // 
            this.SpawnColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SpawnColorPreview.Location = new System.Drawing.Point(8, 86);
            this.SpawnColorPreview.Name = "SpawnColorPreview";
            this.SpawnColorPreview.Size = new System.Drawing.Size(24, 24);
            this.SpawnColorPreview.TabIndex = 5;
            // 
            // chkShowSpawns
            // 
            this.chkShowSpawns.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowSpawns.Location = new System.Drawing.Point(8, 62);
            this.chkShowSpawns.Name = "chkShowSpawns";
            this.chkShowSpawns.Size = new System.Drawing.Size(376, 24);
            this.chkShowSpawns.TabIndex = 4;
            this.chkShowSpawns.Text = "Options.ShowSpawns";
            this.chkShowSpawns.CheckedChanged += new System.EventHandler(this.chkShowSpawns_CheckedChanged);
            // 
            // chkDrawStatics
            // 
            this.chkDrawStatics.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDrawStatics.Location = new System.Drawing.Point(8, 32);
            this.chkDrawStatics.Name = "chkDrawStatics";
            this.chkDrawStatics.Size = new System.Drawing.Size(376, 24);
            this.chkDrawStatics.TabIndex = 3;
            this.chkDrawStatics.Text = "Options.DrawStatics";
            this.chkDrawStatics.CheckedChanged += new System.EventHandler(this.chkDrawStatics_CheckedChanged);
            // 
            // chkSelectedMapLocations
            // 
            this.chkSelectedMapLocations.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSelectedMapLocations.Location = new System.Drawing.Point(8, 8);
            this.chkSelectedMapLocations.Name = "chkSelectedMapLocations";
            this.chkSelectedMapLocations.Size = new System.Drawing.Size(176, 24);
            this.chkSelectedMapLocations.TabIndex = 2;
            this.chkSelectedMapLocations.Text = "Options.SelectedMapLocations";
            this.chkSelectedMapLocations.CheckedChanged += new System.EventHandler(this.chkSelectedMapLocations_CheckedChanged);
            // 
            // pServer
            // 
            this.pServer.Controls.Add(this.grpServer);
            this.pServer.Controls.Add(this.chkUseServer);
            this.pServer.Location = new System.Drawing.Point(4, 22);
            this.pServer.Name = "pServer";
            this.pServer.Size = new System.Drawing.Size(392, 366);
            this.pServer.TabIndex = 3;
            this.pServer.Text = "Tabs.Server";
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.chkSHA1);
            this.grpServer.Controls.Add(this.bUpdatePassword);
            this.grpServer.Controls.Add(this.chkConnStartup);
            this.grpServer.Controls.Add(this.txPass);
            this.grpServer.Controls.Add(this.txUser);
            this.grpServer.Controls.Add(this.label7);
            this.grpServer.Controls.Add(this.label6);
            this.grpServer.Controls.Add(this.numPort);
            this.grpServer.Controls.Add(this.label5);
            this.grpServer.Controls.Add(this.label4);
            this.grpServer.Controls.Add(this.txAddress);
            this.grpServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpServer.Location = new System.Drawing.Point(8, 32);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(376, 328);
            this.grpServer.TabIndex = 1;
            this.grpServer.TabStop = false;
            // 
            // chkSHA1
            // 
            this.chkSHA1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSHA1.Location = new System.Drawing.Point(8, 136);
            this.chkSHA1.Name = "chkSHA1";
            this.chkSHA1.Size = new System.Drawing.Size(360, 24);
            this.chkSHA1.TabIndex = 10;
            this.chkSHA1.Text = "Options.SHA1";
            this.chkSHA1.CheckedChanged += new System.EventHandler(this.chkSHA1_CheckedChanged);
            // 
            // bUpdatePassword
            // 
            this.bUpdatePassword.Enabled = false;
            this.bUpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bUpdatePassword.Location = new System.Drawing.Point(280, 88);
            this.bUpdatePassword.Name = "bUpdatePassword";
            this.bUpdatePassword.Size = new System.Drawing.Size(88, 23);
            this.bUpdatePassword.TabIndex = 9;
            this.bUpdatePassword.Text = "Common.Update";
            this.bUpdatePassword.Click += new System.EventHandler(this.bUpdatePassword_Click);
            // 
            // chkConnStartup
            // 
            this.chkConnStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkConnStartup.Location = new System.Drawing.Point(8, 112);
            this.chkConnStartup.Name = "chkConnStartup";
            this.chkConnStartup.Size = new System.Drawing.Size(360, 24);
            this.chkConnStartup.TabIndex = 8;
            this.chkConnStartup.Text = "Options.ConnStartup";
            this.chkConnStartup.CheckedChanged += new System.EventHandler(this.chkConnStartup_CheckedChanged);
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(96, 88);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(176, 20);
            this.txPass.TabIndex = 7;
            this.txPass.TextChanged += new System.EventHandler(this.txPass_TextChanged);
            // 
            // txUser
            // 
            this.txUser.Location = new System.Drawing.Point(96, 64);
            this.txUser.Name = "txUser";
            this.txUser.Size = new System.Drawing.Size(176, 20);
            this.txUser.TabIndex = 6;
            this.txUser.TextChanged += new System.EventHandler(this.txUser_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Options.Pw";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Options.User";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(96, 40);
            this.numPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(72, 20);
            this.numPort.TabIndex = 3;
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Options.ServPort";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Options.ServAddress";
            // 
            // txAddress
            // 
            this.txAddress.Location = new System.Drawing.Point(96, 16);
            this.txAddress.Name = "txAddress";
            this.txAddress.Size = new System.Drawing.Size(272, 20);
            this.txAddress.TabIndex = 0;
            this.txAddress.TextChanged += new System.EventHandler(this.txAddress_TextChanged);
            // 
            // chkUseServer
            // 
            this.chkUseServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseServer.Location = new System.Drawing.Point(8, 8);
            this.chkUseServer.Name = "chkUseServer";
            this.chkUseServer.Size = new System.Drawing.Size(376, 24);
            this.chkUseServer.TabIndex = 0;
            this.chkUseServer.Text = "Options.UseBoxServer";
            this.chkUseServer.CheckedChanged += new System.EventHandler(this.chkUseServer_CheckedChanged);
            // 
            // pAdv
            // 
            this.pAdv.Controls.Add(this.chkFlat);
            this.pAdv.Controls.Add(this.groupBox8);
            this.pAdv.Controls.Add(this.cmbTabs);
            this.pAdv.Controls.Add(this.labSelTab);
            this.pAdv.Controls.Add(this.groupBox7);
            this.pAdv.Controls.Add(this.chkShowCustom);
            this.pAdv.Controls.Add(this.lnkViewDataFolder);
            this.pAdv.Location = new System.Drawing.Point(4, 22);
            this.pAdv.Name = "pAdv";
            this.pAdv.Size = new System.Drawing.Size(392, 366);
            this.pAdv.TabIndex = 5;
            this.pAdv.Text = "Tabs.Adv";
            // 
            // chkFlat
            // 
            this.chkFlat.Location = new System.Drawing.Point(188, 224);
            this.chkFlat.Name = "chkFlat";
            this.chkFlat.Size = new System.Drawing.Size(196, 24);
            this.chkFlat.TabIndex = 6;
            this.chkFlat.Text = "Options.FlatBtn";
            this.chkFlat.CheckedChanged += new System.EventHandler(this.chkFlat_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.txModifier);
            this.groupBox8.Controls.Add(this.bMoveUpModifier);
            this.groupBox8.Controls.Add(this.bMoveDownModifier);
            this.groupBox8.Controls.Add(this.bDeleteModifier);
            this.groupBox8.Controls.Add(this.bAddModifier);
            this.groupBox8.Controls.Add(this.tModifiers);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.Location = new System.Drawing.Point(8, 120);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(176, 240);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Options.Modifiers";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 40);
            this.label11.TabIndex = 6;
            this.label11.Text = "Options.ModWarn";
            // 
            // txModifier
            // 
            this.txModifier.Location = new System.Drawing.Point(8, 116);
            this.txModifier.Name = "txModifier";
            this.txModifier.Size = new System.Drawing.Size(160, 20);
            this.txModifier.TabIndex = 5;
            this.txModifier.TextChanged += new System.EventHandler(this.txModifier_TextChanged);
            // 
            // bMoveUpModifier
            // 
            this.bMoveUpModifier.Enabled = false;
            this.bMoveUpModifier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bMoveUpModifier.Location = new System.Drawing.Point(92, 168);
            this.bMoveUpModifier.Name = "bMoveUpModifier";
            this.bMoveUpModifier.Size = new System.Drawing.Size(76, 23);
            this.bMoveUpModifier.TabIndex = 4;
            this.bMoveUpModifier.Text = "Options.Moveup";
            this.bMoveUpModifier.Click += new System.EventHandler(this.bMoveUpModifier_Click);
            // 
            // bMoveDownModifier
            // 
            this.bMoveDownModifier.Enabled = false;
            this.bMoveDownModifier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bMoveDownModifier.Location = new System.Drawing.Point(8, 168);
            this.bMoveDownModifier.Name = "bMoveDownModifier";
            this.bMoveDownModifier.Size = new System.Drawing.Size(76, 23);
            this.bMoveDownModifier.TabIndex = 3;
            this.bMoveDownModifier.Text = "Options.Movedown";
            this.bMoveDownModifier.Click += new System.EventHandler(this.bMoveDownModifier_Click);
            // 
            // bDeleteModifier
            // 
            this.bDeleteModifier.Enabled = false;
            this.bDeleteModifier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDeleteModifier.Location = new System.Drawing.Point(92, 140);
            this.bDeleteModifier.Name = "bDeleteModifier";
            this.bDeleteModifier.Size = new System.Drawing.Size(76, 23);
            this.bDeleteModifier.TabIndex = 2;
            this.bDeleteModifier.Text = "Common.Delete";
            this.bDeleteModifier.Click += new System.EventHandler(this.bDeleteModifier_Click);
            // 
            // bAddModifier
            // 
            this.bAddModifier.Enabled = false;
            this.bAddModifier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bAddModifier.Location = new System.Drawing.Point(8, 140);
            this.bAddModifier.Name = "bAddModifier";
            this.bAddModifier.Size = new System.Drawing.Size(76, 23);
            this.bAddModifier.TabIndex = 1;
            this.bAddModifier.Text = "Common.Add";
            this.bAddModifier.Click += new System.EventHandler(this.bAddModifier_Click);
            // 
            // tModifiers
            // 
            this.tModifiers.CheckBoxes = true;
            this.tModifiers.FullRowSelect = true;
            this.tModifiers.HideSelection = false;
            this.tModifiers.Location = new System.Drawing.Point(8, 16);
            this.tModifiers.Name = "tModifiers";
            this.tModifiers.ShowLines = false;
            this.tModifiers.ShowPlusMinus = false;
            this.tModifiers.ShowRootLines = false;
            this.tModifiers.Size = new System.Drawing.Size(160, 97);
            this.tModifiers.TabIndex = 0;
            this.tModifiers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tModifiers_AfterSelect);
            // 
            // cmbTabs
            // 
            this.cmbTabs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabs.Location = new System.Drawing.Point(196, 140);
            this.cmbTabs.Name = "cmbTabs";
            this.cmbTabs.Size = new System.Drawing.Size(180, 21);
            this.cmbTabs.TabIndex = 3;
            this.cmbTabs.SelectedIndexChanged += new System.EventHandler(this.cmbTabs_SelectedIndexChanged);
            // 
            // labSelTab
            // 
            this.labSelTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labSelTab.Location = new System.Drawing.Point(188, 124);
            this.labSelTab.Name = "labSelTab";
            this.labSelTab.Size = new System.Drawing.Size(196, 40);
            this.labSelTab.TabIndex = 2;
            this.labSelTab.Text = "Options.TabStartup";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bBrowseCustomClient);
            this.groupBox7.Controls.Add(this.bClearCustClient);
            this.groupBox7.Controls.Add(this.labCustomClient);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox7.Location = new System.Drawing.Point(8, 32);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(376, 88);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Options.CustomClient";
            // 
            // bBrowseCustomClient
            // 
            this.bBrowseCustomClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bBrowseCustomClient.Location = new System.Drawing.Point(288, 56);
            this.bBrowseCustomClient.Name = "bBrowseCustomClient";
            this.bBrowseCustomClient.Size = new System.Drawing.Size(75, 23);
            this.bBrowseCustomClient.TabIndex = 2;
            this.bBrowseCustomClient.Text = "Common.Browse";
            this.bBrowseCustomClient.Click += new System.EventHandler(this.bBrowseCustomClient_Click);
            // 
            // bClearCustClient
            // 
            this.bClearCustClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearCustClient.Location = new System.Drawing.Point(8, 56);
            this.bClearCustClient.Name = "bClearCustClient";
            this.bClearCustClient.Size = new System.Drawing.Size(75, 23);
            this.bClearCustClient.TabIndex = 1;
            this.bClearCustClient.Text = "Common.Clear";
            this.bClearCustClient.Click += new System.EventHandler(this.bClearCustClient_Click);
            // 
            // labCustomClient
            // 
            this.labCustomClient.Location = new System.Drawing.Point(16, 24);
            this.labCustomClient.Name = "labCustomClient";
            this.labCustomClient.Size = new System.Drawing.Size(344, 23);
            this.labCustomClient.TabIndex = 0;
            this.labCustomClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labCustomClient.Paint += new System.Windows.Forms.PaintEventHandler(this.labCustomClient_Paint);
            // 
            // chkShowCustom
            // 
            this.chkShowCustom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowCustom.Location = new System.Drawing.Point(8, 8);
            this.chkShowCustom.Name = "chkShowCustom";
            this.chkShowCustom.Size = new System.Drawing.Size(304, 24);
            this.chkShowCustom.TabIndex = 0;
            this.chkShowCustom.Text = "Options.CustomDeco";
            this.chkShowCustom.CheckedChanged += new System.EventHandler(this.chkShowCustom_CheckedChanged);
            // 
            // lnkViewDataFolder
            // 
            this.lnkViewDataFolder.Location = new System.Drawing.Point(188, 332);
            this.lnkViewDataFolder.Name = "lnkViewDataFolder";
            this.lnkViewDataFolder.Size = new System.Drawing.Size(200, 28);
            this.lnkViewDataFolder.TabIndex = 0;
            this.lnkViewDataFolder.TabStop = true;
            this.lnkViewDataFolder.Text = "Options.DataFolder";
            this.lnkViewDataFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewDataFolder_LinkClicked);
            this.lnkViewDataFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.lnkViewDataFolder_Paint);
            // 
            // pCommands
            // 
            this.pCommands.Controls.Add(this.propCommands);
            this.pCommands.Location = new System.Drawing.Point(4, 22);
            this.pCommands.Name = "pCommands";
            this.pCommands.Size = new System.Drawing.Size(392, 366);
            this.pCommands.TabIndex = 2;
            this.pCommands.Text = "Options.Commands";
            // 
            // propCommands
            // 
            this.propCommands.HelpVisible = false;
            this.propCommands.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propCommands.Location = new System.Drawing.Point(8, 8);
            this.propCommands.Name = "propCommands";
            this.propCommands.Size = new System.Drawing.Size(376, 352);
            this.propCommands.TabIndex = 0;
            this.propCommands.ToolbarVisible = false;
            // 
            // pProfiles
            // 
            this.pProfiles.Controls.Add(this.bLoad);
            this.pProfiles.Controls.Add(this.labDefaultProfile);
            this.pProfiles.Controls.Add(this.bResetDefaultProfile);
            this.pProfiles.Controls.Add(this.bDefaultProfile);
            this.pProfiles.Controls.Add(this.bDeleteProfile);
            this.pProfiles.Controls.Add(this.bImportProfile);
            this.pProfiles.Controls.Add(this.bNewProfile);
            this.pProfiles.Controls.Add(this.label10);
            this.pProfiles.Controls.Add(this.groupBox6);
            this.pProfiles.Controls.Add(this.lstProfiles);
            this.pProfiles.Location = new System.Drawing.Point(4, 22);
            this.pProfiles.Name = "pProfiles";
            this.pProfiles.Size = new System.Drawing.Size(392, 366);
            this.pProfiles.TabIndex = 4;
            this.pProfiles.Text = "Tabs.Profiles";
            // 
            // bLoad
            // 
            this.bLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bLoad.Location = new System.Drawing.Point(176, 136);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(88, 23);
            this.bLoad.TabIndex = 9;
            this.bLoad.Text = "Common.Load";
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // labDefaultProfile
            // 
            this.labDefaultProfile.Location = new System.Drawing.Point(176, 112);
            this.labDefaultProfile.Name = "labDefaultProfile";
            this.labDefaultProfile.Size = new System.Drawing.Size(208, 23);
            this.labDefaultProfile.TabIndex = 8;
            this.labDefaultProfile.Text = "Options.DefaultProf";
            // 
            // bResetDefaultProfile
            // 
            this.bResetDefaultProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bResetDefaultProfile.Location = new System.Drawing.Point(8, 328);
            this.bResetDefaultProfile.Name = "bResetDefaultProfile";
            this.bResetDefaultProfile.Size = new System.Drawing.Size(256, 23);
            this.bResetDefaultProfile.TabIndex = 7;
            this.bResetDefaultProfile.Text = "Options.ResetDefault";
            this.bResetDefaultProfile.Click += new System.EventHandler(this.bResetDefaultProfile_Click);
            // 
            // bDefaultProfile
            // 
            this.bDefaultProfile.Enabled = false;
            this.bDefaultProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDefaultProfile.Location = new System.Drawing.Point(176, 264);
            this.bDefaultProfile.Name = "bDefaultProfile";
            this.bDefaultProfile.Size = new System.Drawing.Size(88, 23);
            this.bDefaultProfile.TabIndex = 6;
            this.bDefaultProfile.Text = "Common.Default";
            this.bDefaultProfile.Click += new System.EventHandler(this.bDefaultProfile_Click);
            // 
            // bDeleteProfile
            // 
            this.bDeleteProfile.Enabled = false;
            this.bDeleteProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDeleteProfile.Location = new System.Drawing.Point(176, 232);
            this.bDeleteProfile.Name = "bDeleteProfile";
            this.bDeleteProfile.Size = new System.Drawing.Size(88, 23);
            this.bDeleteProfile.TabIndex = 5;
            this.bDeleteProfile.Text = "Common.Delete";
            this.bDeleteProfile.Click += new System.EventHandler(this.bDeleteProfile_Click);
            // 
            // bImportProfile
            // 
            this.bImportProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImportProfile.Location = new System.Drawing.Point(176, 200);
            this.bImportProfile.Name = "bImportProfile";
            this.bImportProfile.Size = new System.Drawing.Size(88, 23);
            this.bImportProfile.TabIndex = 4;
            this.bImportProfile.Text = "Common.Import";
            this.bImportProfile.Click += new System.EventHandler(this.bImportProfile_Click);
            // 
            // bNewProfile
            // 
            this.bNewProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bNewProfile.Location = new System.Drawing.Point(176, 168);
            this.bNewProfile.Name = "bNewProfile";
            this.bNewProfile.Size = new System.Drawing.Size(88, 23);
            this.bNewProfile.TabIndex = 3;
            this.bNewProfile.Text = "Common.New";
            this.bNewProfile.Click += new System.EventHandler(this.bNewProfile_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tabs.Profiles";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmbLang);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txProfName);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.bExportProfile);
            this.groupBox6.Location = new System.Drawing.Point(8, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(376, 96);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Options.CurrProf";
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.Location = new System.Drawing.Point(88, 56);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(160, 21);
            this.cmbLang.Sorted = true;
            this.cmbLang.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Common.Lang";
            // 
            // txProfName
            // 
            this.txProfName.Location = new System.Drawing.Point(88, 24);
            this.txProfName.Name = "txProfName";
            this.txProfName.Size = new System.Drawing.Size(160, 20);
            this.txProfName.TabIndex = 1;
            this.txProfName.TextChanged += new System.EventHandler(this.txProfName_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Common.Name";
            // 
            // bExportProfile
            // 
            this.bExportProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bExportProfile.Location = new System.Drawing.Point(288, 24);
            this.bExportProfile.Name = "bExportProfile";
            this.bExportProfile.Size = new System.Drawing.Size(75, 23);
            this.bExportProfile.TabIndex = 2;
            this.bExportProfile.Text = "Common.Export";
            this.bExportProfile.Click += new System.EventHandler(this.bExportProfile_Click);
            // 
            // lstProfiles
            // 
            this.lstProfiles.Location = new System.Drawing.Point(8, 136);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(152, 186);
            this.lstProfiles.TabIndex = 0;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            // 
            // OpenFile
            // 
            this.OpenFile.Filter = "Xml Files (*.xml)|*.xml";
            // 
            // cmImport
            // 
            this.cmImport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmImportBoxData,
            this.cmImportPropsData,
            this.cmImportSpawnData,
            this.cmImportSpawnGroups});
            // 
            // cmImportBoxData
            // 
            this.cmImportBoxData.Index = 0;
            this.cmImportBoxData.Text = "Common.BoxData";
            this.cmImportBoxData.Click += new System.EventHandler(this.cmImportBoxData_Click);
            // 
            // cmImportPropsData
            // 
            this.cmImportPropsData.Index = 1;
            this.cmImportPropsData.Text = "Common.PropsData";
            this.cmImportPropsData.Click += new System.EventHandler(this.cmImportPropsData_Click);
            // 
            // cmImportSpawnData
            // 
            this.cmImportSpawnData.Index = 2;
            this.cmImportSpawnData.Text = "Common.SpawnData";
            this.cmImportSpawnData.Click += new System.EventHandler(this.cmImportSpawnData_Click);
            // 
            // cmImportSpawnGroups
            // 
            this.cmImportSpawnGroups.Index = 3;
            this.cmImportSpawnGroups.Text = "NPCs.SpawnGroups";
            this.cmImportSpawnGroups.Click += new System.EventHandler(this.cmImportSpawnGroups_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(320, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Common.Ok";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(402, 431);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options.Title";
            this.Closed += new System.EventHandler(this.OptionsForm_Closed);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.pGeneral.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pTravel.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pServer.ResumeLayout(false);
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.pAdv.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.pCommands.ResumeLayout(false);
            this.pProfiles.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			Pandora.Localization.LocalizeMenu(cmImport);

			SetOptions();

			// Commands properties
			propCommands.ToolbarVisible = true;
			propCommands.HelpVisible = true;
			propCommands.SelectedObject = Pandora.Profile.Commands;
		}

		/// <summary>
		///     Sets the options to correspond to the default values
		/// </summary>
		private void SetOptions()
		{
			m_ApplyOptions = false;

			var general = Pandora.Profile.General;
			var travel = Pandora.Profile.Travel;
			var server = Pandora.Profile.Server;

			// General
			chkTray.Checked = general.MinimizeToTray;
			chkTaskbar.Checked = general.ShowInTaskBar;
			chkTopmost.Checked = general.TopMost;
			chkXMin.Checked = general.XMinimize;

			chkScale.Checked = general.Scale;
			chkRoomView.Checked = general.RoomView;
			chkAnimate.Checked = general.Animate;

			txArtBackground.BackColor = general.ArtBackground.Color;

			// UO Folder
			if (Pandora.Profile.DefaultFolder == null)
			{
				labUOFolder.Text = Pandora.Localization.TextProvider["Options.NOUOFolder"];
			}
			else
			{
				labUOFolder.Text = Pandora.Profile.DefaultFolder;
			}

			// Opacity
			barOpacity.Value = general.Opacity;
			Opacity = general.Opacity / 100.0;

			// Links color
			txLinkColor.BackColor = Pandora.Profile.General.Links.Color;

			// Command Prefix
			txCmdPrefix.Text = Pandora.Profile.General.CommandPrefix;

			// Travel
			chkSelectedMapLocations.Checked = travel.SelectedMapLocations;
			chkDrawStatics.Checked = travel.DrawStatics;
			chkShowSpawns.Checked = travel.ShowSpawns;
			SpawnColorPreview.BackColor = travel.SpawnColor;
			chkXRay.Checked = travel.XRayView;

			chkShowSpawns.Enabled = SpawnData.SpawnProvider != null;
			linkSpawnColor.Enabled = SpawnData.SpawnProvider != null;
			SpawnColorPreview.Enabled = SpawnData.SpawnProvider != null;

			// Map names
			chkMap0.Checked = travel.EnabledMaps[0];
			chkMap1.Checked = travel.EnabledMaps[1];
			chkMap2.Checked = travel.EnabledMaps[2];
			chkMap3.Checked = travel.EnabledMaps[3];
			chkMap4.Checked = travel.EnabledMaps[4];

			txMap0.Text = travel.MapNames[0];
			txMap0.Enabled = travel.EnabledMaps[0];
			bImport0.Enabled = travel.EnabledMaps[0];

			txMap1.Text = travel.MapNames[1];
			txMap1.Enabled = travel.EnabledMaps[1];
			bImport1.Enabled = travel.EnabledMaps[1];

			txMap2.Text = travel.MapNames[2];
			txMap2.Enabled = travel.EnabledMaps[2];
			bImport2.Enabled = travel.EnabledMaps[2];

			txMap3.Text = travel.MapNames[3];
			txMap3.Enabled = travel.EnabledMaps[3];
			bImport3.Enabled = travel.EnabledMaps[3];

			txMap4.Text = travel.MapNames[4];
			txMap4.Enabled = travel.EnabledMaps[4];
			bImport4.Enabled = travel.EnabledMaps[4];

			// Server
			chkUseServer.Checked = server.Enabled;
			grpServer.Enabled = server.Enabled;
			txAddress.Text = server.Address;
			numPort.Value = server.Port;
			txUser.Text = server.Username;
			txPass.Text = ""; // Password is stored as hash
			chkConnStartup.Checked = server.ConnectOnStartup;
			chkSHA1.Checked = server.UseSHA1Crypt;

			// Profile
			txProfName.Text = Pandora.Profile.Name;

			var langs = new string[Pandora.Localization.SupportedLanguages.Count];
			Pandora.Localization.SupportedLanguages.CopyTo(langs, 0);
			cmbLang.Items.AddRange(langs);
			cmbLang.SelectedItem = Pandora.Profile.Language;

			// Profiles list
			DisplayProfiles();

			// Default profile
			SetDefaultProfile();

			// Advanced
			chkShowCustom.Checked = Pandora.Profile.Deco.ShowCustomDeco;
			if (Pandora.Profile.CustomClient != null)
			{
				labCustomClient.Text = Pandora.Profile.CustomClient;
			}
			chkFlat.Checked = Pandora.Profile.General.FlatButtons;

			// Startup tab
			cmbTabs.Items.AddRange(Pandora.BoxForm.GetTabNames());
			cmbTabs.SelectedIndex = 0;

			if (Pandora.Profile.General.StartupTab != null)
			{
				foreach (string s in cmbTabs.Items)
				{
					if (s == Pandora.Profile.General.StartupTab)
					{
						cmbTabs.SelectedItem = s;
						break;
					}
				}
			}

			// Modifiers
			tModifiers.BeginUpdate();

			for (var i = 0; i < Pandora.Profile.General.Modifiers.Length; i++)
			{
				var mod = Pandora.Profile.General.Modifiers[i];
				var warn = Pandora.Profile.General.ModifiersWarnings[i];

				var node = new TreeNode(mod)
				{
					Checked = warn
				};
				_ = tModifiers.Nodes.Add(node);
			}

			tModifiers.EndUpdate();

			m_ApplyOptions = true;
		}

		/// <summary>
		///     Resets the text corresponding to the default profile currently selected
		/// </summary>
		private void SetDefaultProfile()
		{
			var defProf = _profileManager.DefaultProfile;

			if (defProf != null && defProf.Length > 0)
			{
				labDefaultProfile.Text = String.Format(Pandora.Localization.TextProvider["Options.DefaultProf"], defProf);
			}
			else
			{
				labDefaultProfile.Text = String.Format(
					Pandora.Localization.TextProvider["Options.DefaultProf"],
					Pandora.Localization.TextProvider["Common.None"]);
			}
		}

		/// <summary>
		///     Displays the existing profiles
		/// </summary>
		private void DisplayProfiles()
		{
			lstProfiles.BeginUpdate();
			lstProfiles.Items.Clear();

			lstProfiles.Items.AddRange(_profileManager.ExistingProfiles);
			lstProfiles.SelectedItem = Pandora.Profile.Name;

			lstProfiles.EndUpdate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		#region Options applied when closing
		/// <summary>
		///     Show in task bar has been updated
		/// </summary>
		private bool m_TaskBarChanged;

		private bool m_ChangeUOFolder;
		private bool m_ChangeOpacity;
		private bool m_ServerChanged;

		private void OptionsForm_Closed(object sender, EventArgs e)
		{
			if (Pandora.Profile == null)
			{
				return;
			}

			if (m_TaskBarChanged)
			{
				Pandora.Profile.General.ShowInTaskBar = chkTaskbar.Checked;
			}

			if (m_ChangeUOFolder)
			{
				Pandora.Profile.DefaultFolder = labUOFolder.Text;
			}

			if (m_ChangeOpacity)
			{
				Pandora.Profile.General.Opacity = barOpacity.Value;
			}

			if (m_ServerChanged && Pandora.Profile.Server.Enabled)
			{
				if (MessageBox.Show(
						this,
						Pandora.Localization.TextProvider["Misc.ServerChanged"],
						null,
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					// Connect
					Pandora.BoxConnection.Disconnect();
					_ = Pandora.BoxConnection.Connect();
				}
			}

			// Update the modifiers

			var modifiers = new string[tModifiers.Nodes.Count];
			var modwarn = new bool[tModifiers.Nodes.Count];

			for (var i = 0; i < modifiers.Length; i++)
			{
				var node = tModifiers.Nodes[i];

				modifiers[i] = node.Text;
				modwarn[i] = node.Checked;
			}

			Pandora.Profile.General.ModifiersWarnings = modwarn;
			Pandora.Profile.General.Modifiers = modifiers;

			// Save the profile
			Pandora.Profile.Save();
		}
		#endregion

		#region General
		// Show in taskbar
		private void chkTaskbar_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkTaskbar.Checked)
			{
				// Show in task bar: disable option for minimize to tray and make it checked
				chkTray.Checked = true;
				chkTray.Enabled = false;
			}
			else
			{
				chkTray.Checked = Pandora.Profile.General.MinimizeToTray;
				chkTray.Enabled = true;
			}

			m_TaskBarChanged = true;
		}

		// Minimize to tray
		private void chkTray_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.MinimizeToTray = chkTray.Checked;
			}
		}

		// Topmost
		private void chkTopmost_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.TopMost = chkTopmost.Checked;
			}
		}

		// Minimize with X button
		private void chkXMin_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.XMinimize = chkXMin.Checked;
			}
		}

		/// <summary>
		///     Scroll the opacity slider
		/// </summary>
		private void barOpacity_Scroll(object sender, EventArgs e)
		{
			Opacity = barOpacity.Value / 100.0;

			if (m_ApplyOptions)
			{
				m_ChangeOpacity = true;
			}
		}

		/// <summary>
		///     Change the command prefix
		/// </summary>
		private void txCmdPrefix_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions && txCmdPrefix.Text.Length > 0)
			{
				Pandora.Profile.General.CommandPrefix = txCmdPrefix.Text;
			}
		}

		/// <summary>
		///     Browse for a custom UO folder
		/// </summary>
		private void bBrowseUOFolder_Click(object sender, EventArgs e)
		{
			if (FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				labUOFolder.Text = FolderBrowser.SelectedPath;
				m_ChangeUOFolder = true;
			}
		}

		/// <summary>
		///     Room View
		/// </summary>
		private void chkRoomView_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.RoomView = chkRoomView.Checked;
				Pandora.Art.RoomView = chkRoomView.Checked;
			}
		}

		/// <summary>
		///     Resize tall items
		/// </summary>
		private void chkScale_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.Scale = chkScale.Checked;
				Pandora.Art.ResizeTallItems = chkScale.Checked;
			}
		}

		/// <summary>
		///     Animate NPCs
		/// </summary>
		private void chkAnimate_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.Animate = chkAnimate.Checked;
				Pandora.Art.Animate = chkAnimate.Checked;
			}
		}

		/// <summary>
		///     Change background color for the art preview
		/// </summary>
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ColorChooser.Color = Pandora.Profile.General.ArtBackground.Color;

			if (ColorChooser.ShowDialog() == DialogResult.OK)
			{
				Pandora.Profile.General.ArtBackground.Color = ColorChooser.Color;
				Pandora.Art.BackColor = ColorChooser.Color;
				txArtBackground.BackColor = ColorChooser.Color;
			}
		}

		/// <summary>
		///     Import a custom BoxData
		/// </summary>
		private void ImportBoxData()
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.OverwriteBoxData"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					BoxData bd;
					try
					{
						// Try reading the XML file
						var stream = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						var serializer = new XmlSerializer(typeof(BoxData));
						bd = serializer.Deserialize(stream) as BoxData;
						stream.Close();
					}
					catch
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.WrongFile"]);
						return;
					}

					Pandora.BoxData = bd;
					Pandora.BoxData.Save();

					// This will refresh the values on first use
					Pandora.Mobiles = null;
					Pandora.Items = null;

					Pandora.BoxForm.Mobiles.RefreshData();
				}
			}
		}

		private void ImportPropsData()
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.OverwriteProps"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					PropsData p;
					try
					{
						// Try reading the XML file
						var stream = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						var serializer = new XmlSerializer(typeof(PropsData));
						p = serializer.Deserialize(stream) as PropsData;
						stream.Close();
					}
					catch
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.WrongFile"]);
						return;
					}

					PropsData.Props = p;
				}
			}
		}

		/// <summary>
		///     Import SpawnData
		/// </summary>
		private void ImportSpawnData()
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.OverwriteSpawns"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					SpawnData sd;
					try
					{
						// Try reading the XML file
						var stream = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						var serializer = new XmlSerializer(typeof(SpawnData));
						sd = serializer.Deserialize(stream) as SpawnData;
						stream.Close();
					}
					catch
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.WrongFile"]);
						return;
					}

					SpawnData.SpawnProvider = sd;

					chkShowSpawns.Enabled = true;
					chkShowSpawns.Checked = true;
					Pandora.Profile.Travel.ShowSpawns = true;

					linkSpawnColor.Enabled = true;
				}
			}
		}

		/// <summary>
		///     Import spawn groups
		/// </summary>
		private void ImportSpawnGroups()
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.OverwriteGroups"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					SpawnGroups sg;
					try
					{
						// Try reading the XML file
						var stream = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						var serializer = new XmlSerializer(typeof(SpawnGroups));
						sg = serializer.Deserialize(stream) as SpawnGroups;
						stream.Close();
					}
					catch
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.WrongFile"]);
						return;
					}

					Pandora.SpawnGroups = sg;
					Pandora.BoxForm.Mobiles.RefreshData();
				}
			}
		}

		/// <summary>
		///     Menu option to import boxdata
		/// </summary>
		private void cmImportBoxData_Click(object sender, EventArgs e)
		{
			ImportBoxData();
		}

		/// <summary>
		///     Menu option to import propsdata
		/// </summary>
		private void cmImportPropsData_Click(object sender, EventArgs e)
		{
			ImportPropsData();
		}

		/// <summary>
		///     Menu option to import SpawnData
		/// </summary>
		private void cmImportSpawnData_Click(object sender, EventArgs e)
		{
			ImportSpawnData();
		}

		/// <summary>
		///     Menu option to import SpawnGroups
		/// </summary>
		private void cmImportSpawnGroups_Click(object sender, EventArgs e)
		{
			ImportSpawnGroups();
		}

		/// <summary>
		///     User clicked the Import Data link: show context menu
		/// </summary>
		private void lnkImportData_MouseDown(object sender, MouseEventArgs e)
		{
			cmImport.Show(lnkImportData, new Point(e.X, e.Y));
		}

		/// <summary>
		///     Changes the default color used to display links
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lnkLinkColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ColorChooser.Color = Pandora.Profile.General.Links.Color;

			if (ColorChooser.ShowDialog() == DialogResult.OK)
			{
				Pandora.Profile.General.Links.Color = ColorChooser.Color;
				txLinkColor.BackColor = ColorChooser.Color;

				UpdateLinks(this);
				UpdateLinks(Pandora.BoxForm as Form);
			}
		}

		//  Issue 28:  	 Refactoring Pandora.cs - Tarion
		/// <summary>
		///     Updates the color used to display links
		/// </summary>
		/// <param name="c">The Control that contains links to be changed</param>
		private void UpdateLinks(Control control)
		{
			if (control is LinkLabel)
			{
				(control as LinkLabel).LinkColor = Pandora.Profile.General.Links.Color;
				(control as LinkLabel).VisitedLinkColor = Pandora.Profile.General.Links.Color;
			}

			foreach (Control c in control.Controls)
			{
				UpdateLinks(c);
			}
		}

		/// <summary>
		///     Draw border
		/// </summary>
		private void labUOFolder_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labUOFolder, e.Graphics);
		}
		#endregion

		#region Travel
		/// <summary>
		///     Selected map locations only
		/// </summary>
		private void chkSelectedMapLocations_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.SelectedMapLocations = chkSelectedMapLocations.Checked;
			}
		}

		private void chkXRay_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.XRayView = chkXRay.Checked;
				Pandora.Map.XRayView = chkXRay.Checked;
			}
		}

		/// <summary>
		///     DRAW STATICS
		/// </summary>
		private void chkDrawStatics_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.DrawStatics = chkDrawStatics.Checked;
				Pandora.Map.DrawStatics = chkDrawStatics.Checked;
			}
		}

		/// <summary>
		///     Choose new spawn color
		/// </summary>
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ColorChooser.Color = Pandora.Profile.Travel.SpawnColor;

			if (ColorChooser.ShowDialog() == DialogResult.OK)
			{
				Pandora.Profile.Travel.SpawnColor = ColorChooser.Color;
				SpawnColorPreview.BackColor = ColorChooser.Color;

				SpawnData.SpawnProvider.RefreshSpawns();
			}
		}

		/// <summary>
		///     Show or hide spawns on the map
		/// </summary>
		private void chkShowSpawns_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.DoSpawns(chkShowSpawns.Checked);
			}
		}

		/// <summary>
		///     Map0 Check Change
		/// </summary>
		private void chkMap0_CheckedChanged(object sender, EventArgs e)
		{
			txMap0.Enabled = chkMap0.Checked;
			bImport0.Enabled = chkMap0.Checked;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[0] = chkMap0.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map1 Check Change
		/// </summary>
		private void chkMap1_CheckedChanged(object sender, EventArgs e)
		{
			txMap1.Enabled = chkMap1.Checked;
			bImport1.Enabled = chkMap1.Checked;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[1] = chkMap1.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map2 Check Change
		/// </summary>
		private void chkMap2_CheckedChanged(object sender, EventArgs e)
		{
			txMap2.Enabled = chkMap2.Checked;
			bImport2.Enabled = chkMap2.Checked;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[2] = chkMap2.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map3 Check Change
		/// </summary>
		private void chkMap3_CheckedChanged(object sender, EventArgs e)
		{
			txMap3.Enabled = chkMap3.Checked;
			bImport3.Enabled = chkMap3.Checked;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[3] = chkMap3.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map4 Check Change
		/// </summary>
		private void chkMap4_CheckedChanged(object sender, EventArgs e)
		{
			txMap4.Enabled = chkMap4.Checked;
			bImport4.Enabled = chkMap4.Enabled;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[4] = chkMap4.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map5 Check Change
		/// </summary>
		private void chkMap5_CheckedChanged(object sender, EventArgs e)
		{
			txMap5.Enabled = chkMap5.Checked;
			bImport5.Enabled = chkMap5.Enabled;

			if (m_ApplyOptions)
			{
				Pandora.Profile.Travel.EnabledMaps[5] = chkMap5.Checked;
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map0 Text Change
		/// </summary>
		private void txMap0_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap0.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[0] = txMap0.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map1 Text Change
		/// </summary>
		private void txMap1_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap1.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[1] = txMap1.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map2 Text Change
		/// </summary>
		private void txMap2_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap2.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[2] = txMap2.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map3 Text Change
		/// </summary>
		private void txMap3_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap3.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[3] = txMap3.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map4 Text Change
		/// </summary>
		private void txMap4_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap4.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[4] = txMap4.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		/// <summary>
		///     Map5 Text Change
		/// </summary>
		private void txMap5_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txMap5.Text.Length > 0)
				{
					Pandora.Profile.Travel.MapNames[5] = txMap5.Text;
				}

				Pandora.BoxForm.Travel.ResetMaps();
			}
		}

		#region Import Map Files
		/// <summary>
		///     Imports a datafile for a specified map
		/// </summary>
		/// <param name="map"></param>
		private void ImportMap(int map)
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.OverwriteMap"],
					null,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					Facet facet;
					try
					{
						// Try reading the XML file
						var stream = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						var serializer = new XmlSerializer(typeof(Facet));
						facet = serializer.Deserialize(stream) as Facet;
						stream.Close();
					}
					catch
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.WrongFile"]);
						return;
					}

					Pandora.TravelAgent.UpdateFacet(facet, map);
					Pandora.BoxForm.Travel.ResetMaps();
				}
			}
		}

		private void bImport0_Click(object sender, EventArgs e)
		{
			ImportMap(0);
		}

		private void bImport1_Click(object sender, EventArgs e)
		{
			ImportMap(1);
		}

		private void bImport2_Click(object sender, EventArgs e)
		{
			ImportMap(2);
		}

		private void bImport3_Click(object sender, EventArgs e)
		{
			ImportMap(3);
		}

		private void bImport4_Click(object sender, EventArgs e)
		{
			ImportMap(4);
		}

		private void bImport5_Click(object sender, EventArgs e)
		{
			ImportMap(5);
		}
		#endregion

		/// <summary>
		///     Extract map images
		/// </summary>
		private void bCalcMaps_Click(object sender, EventArgs e)
		{
			if (Pandora.Profile.Travel.IsEnabled)
			{
				var form = new MapFilesForm();
				_ = form.ShowDialog();
			}
		}

		/// <summary>
		///     Restore default locations files
		/// </summary>
		private void bRestoreDefLocations_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Options.DefLocWarn"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Pandora.TravelAgent.Reset();
				Pandora.BoxForm.Travel.ResetMaps();
			}
		}
		#endregion

		#region Commands
		/// <summary>
		///     Gets the command options
		/// </summary>
		private CommandsOptions Commands => Pandora.Profile.Commands;
		#endregion

		#region Server
		/// <summary>
		///     Enable or disable use of BoxServer
		/// </summary>
		private void chkUseServer_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				grpServer.Enabled = chkUseServer.Enabled;
				Pandora.Profile.Server.Enabled = chkUseServer.Enabled;
			}
		}

		/// <summary>
		///     Changes the address for the server
		/// </summary>
		private void txAddress_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Server.Address = txAddress.Text;
				m_ServerChanged = true;
			}
		}

		/// <summary>
		///     Change the server port
		/// </summary>
		private void numPort_ValueChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Server.Port = (int)numPort.Value;
				m_ServerChanged = true;
			}
		}

		/// <summary>
		///     Changes the username
		/// </summary>
		private void txUser_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Server.Username = txUser.Text;
				m_ServerChanged = true;
			}
		}

		/// <summary>
		///     Changes the password: enable the update button when needed
		/// </summary>
		private void txPass_TextChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				if (txPass.Text != null && txPass.Text.Length > 0)
				{
					bUpdatePassword.Enabled = true;
				}
				else
				{
					bUpdatePassword.Enabled = false;
				}
			}
		}

		private void bUpdatePassword_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Server.SetPassword(txPass.Text);
			txPass.Text = "";
			_ = MessageBox.Show(Pandora.Localization.TextProvider["Options.PassUpdated"]);
		}

		/// <summary>
		///     Change: connect to server on startup
		/// </summary>
		private void chkConnStartup_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Server.ConnectOnStartup = chkConnStartup.Checked;
			}
		}

		private void chkSHA1_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Server.UseSHA1Crypt = chkSHA1.Checked;

				_ = MessageBox.Show(Pandora.Localization.TextProvider["Options.SHA1CheckWarn"]);
			}
		}
		#endregion

		#region Profiles
		/// <summary>
		///     Change Profile Name: change folder name!!
		/// </summary>
		private void txProfName_TextChanged(object sender, EventArgs e)
		{
			if (txProfName.Text.Length > 0 && m_ApplyOptions && !txProfName.Text.EndsWith(" "))
			{
				string old = null;
				string newFolder = null;

				try
				{
					old = Pandora.Profile.BaseFolder;
					newFolder = Path.Combine(ProfileManager.ProfilesFolder, txProfName.Text);

					if (old == newFolder)
					{
						return; // This would only give an unnecessary warning
					}

					if (Directory.Exists(newFolder))
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.ProfExists"]);
						return;
					}

					Directory.Move(old, newFolder);
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, "Can't move profile from {0} to {1}", old, newFolder);
					return;
				}

				Pandora.Profile.Name = txProfName.Text;
				Pandora.Profile.Save();
			}
		}

		/// <summary>
		///     Selection changed on the profile list: if valid enable delete/default buttons
		/// </summary>
		private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstProfiles.SelectedIndex > -1)
			{
				bDeleteProfile.Enabled = true;
				bDefaultProfile.Enabled = true;

				if ((lstProfiles.SelectedItem as string) == Pandora.Profile.Name)
				{
					bLoad.Enabled = false;
				}
				else
				{
					bLoad.Enabled = true;
				}
			}
		}

		/// <summary>
		///     Set the Default Profile to null
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bResetDefaultProfile_Click(object sender, EventArgs e)
		{
			_profileManager.DefaultProfile = null;
			SetDefaultProfile();
		}

		/// <summary>
		///     Set the default profile to the selected one
		/// </summary>
		private void bDefaultProfile_Click(object sender, EventArgs e)
		{
			if (lstProfiles.SelectedIndex > -1)
			{
				_profileManager.DefaultProfile = lstProfiles.Text;
				SetDefaultProfile();
			}
		}

		/// <summary>
		///     Create a new profile: close Pandora and run the profile wizard
		/// </summary>
		private void bNewProfile_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Save();
			Pandora.CreateNewProfile();
		}

		/// <summary>
		///     Deletes the selected profile
		/// </summary>
		private void bDeleteProfile_Click(object sender, EventArgs e)
		{
			if (lstProfiles.SelectedIndex > -1)
			{
				var profile = lstProfiles.Text;

				if (profile == Pandora.Profile.Name)
				{
					if (MessageBox.Show(
							this,
							Pandora.Localization.TextProvider["Messages.DelCurrentProfile"],
							"",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Close();
						Pandora.DeleteCurrentProfile();
					}
				}
				else
				{
					if (MessageBox.Show(
							this,
							Pandora.Localization.TextProvider["Messages.DelProfile"],
							"",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Profile.DeleteProfile(profile);
						DisplayProfiles();
					}
				}
			}
		}

		/// <summary>
		///     Export profile button
		/// </summary>
		private void bExportProfile_Click(object sender, EventArgs e)
		{
			_profileManager.ExportProfile();
		}

		/// <summary>
		///     Import profile button
		/// </summary>
		private void bImportProfile_Click(object sender, EventArgs e)
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
					Close();
					Pandora.BoxForm.ChangeProfile(p.Name);
				}
			}
			else
			{
				DisplayProfiles();
			}
		}

		/// <summary>
		///     Load the selected profile
		/// </summary>
		private void bLoad_Click(object sender, EventArgs e)
		{
			var p = lstProfiles.SelectedItem as string;
			Close();
			Pandora.BoxForm.ChangeProfile(p);
		}
		#endregion

		#region Advanced
		/// <summary>
		///     Show Custom Deco changed
		/// </summary>
		private void chkShowCustom_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.Deco.ShowCustomDeco = chkShowCustom.Checked;
			}
		}

		/// <summary>
		///     Draw the border around the custom client label
		/// </summary>
		private void labCustomClient_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labCustomClient, e.Graphics);
		}

		/// <summary>
		///     Clears the custom client path
		/// </summary>
		private void bClearCustClient_Click(object sender, EventArgs e)
		{
			labCustomClient.Text = "";
			Pandora.Profile.CustomClient = null;
		}

		/// <summary>
		///     Browse for a new custom client
		/// </summary>
		private void bBrowseCustomClient_Click(object sender, EventArgs e)
		{
			var oldFilter = OpenFile.Filter;
			OpenFile.Filter = "Programs (*.exe)|*.exe";

			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				Pandora.Profile.CustomClient = OpenFile.FileName;
				labCustomClient.Text = OpenFile.FileName;
			}

			OpenFile.Filter = oldFilter;
		}

		/// <summary>
		///     User changes the tab that should be displayed on startup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.StartupTab = cmbTabs.Text;
			}
		}

		/// <summary>
		///     Enables the buttons related to the modifiers
		/// </summary>
		private void EnableModifiers()
		{
			bAddModifier.Enabled = txModifier.Text.Length > 0;
			bDeleteModifier.Enabled = tModifiers.SelectedNode != null;

			bMoveUpModifier.Enabled = tModifiers.SelectedNode != null && tModifiers.Nodes.IndexOf(tModifiers.SelectedNode) > 0;

			bMoveDownModifier.Enabled = tModifiers.SelectedNode != null &&
										tModifiers.Nodes.IndexOf(tModifiers.SelectedNode) < (tModifiers.Nodes.Count - 1);
		}

		/// <summary>
		///     User types in the new modifier text field
		/// </summary>
		private void txModifier_TextChanged(object sender, EventArgs e)
		{
			EnableModifiers();
		}

		/// <summary>
		///     User changes the selected modifier
		/// </summary>
		private void tModifiers_AfterSelect(object sender, TreeViewEventArgs e)
		{
			EnableModifiers();
		}

		/// <summary>
		///     Add a new modifier
		/// </summary>
		private void bAddModifier_Click(object sender, EventArgs e)
		{
			var node = new TreeNode(txModifier.Text);
			_ = tModifiers.Nodes.Add(node);
		}

		/// <summary>
		///     Delete a modifier
		/// </summary>
		private void bDeleteModifier_Click(object sender, EventArgs e)
		{
			tModifiers.Nodes.Remove(tModifiers.SelectedNode);
		}

		/// <summary>
		///     Move down a modifier
		/// </summary>
		private void bMoveDownModifier_Click(object sender, EventArgs e)
		{
			var node = tModifiers.SelectedNode;

			var index = tModifiers.Nodes.IndexOf(node);

			tModifiers.Nodes.RemoveAt(index);
			tModifiers.Nodes.Insert(index + 1, node);
			tModifiers.SelectedNode = node;

			EnableModifiers();
		}

		/// <summary>
		///     Move up a modifier
		/// </summary>
		private void bMoveUpModifier_Click(object sender, EventArgs e)
		{
			var node = tModifiers.SelectedNode;

			var index = tModifiers.Nodes.IndexOf(node);

			tModifiers.Nodes.RemoveAt(index);
			tModifiers.Nodes.Insert(index - 1, node);
			tModifiers.SelectedNode = node;

			EnableModifiers();
		}

		/// <summary>
		///     View the data folder
		/// </summary>
		private void lnkViewDataFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				_ = Process.Start(Pandora.ApplicationDataFolder);
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't open the application data folder: {0}", Pandora.ApplicationDataFolder);
			}
		}

		/// <summary>
		///     Paint border of data folder label
		/// </summary>
		private void lnkViewDataFolder_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(lnkViewDataFolder, e.Graphics);
		}

		/// <summary>
		///     Flat buttons check
		/// </summary>
		private void chkFlat_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyOptions)
			{
				Pandora.Profile.General.FlatButtons = chkFlat.Checked;
			}
		}
		#endregion
	}
}
