#region Header
// /*
//  *    2018 - TravelAgent - TravelAgentForm.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Box.Misc;

using TheBox.Common;
using TheBox.Data;
using TheBox.MapViewer;

using Ultima;

using Location = TheBox.Data.Location;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.TravelAgent
{
	/// <summary>
	///     Summary description for Form1.
	/// </summary>
	public class TravelAgentForm : Form
	{
		private MainMenu mMain;
		private MenuItem menuItem1;
		private MenuItem menuItem4;
		private MenuItem menuItem7;
		private MenuItem menuItem9;
		private Label label2;
		private Label label1;
		private Label label3;
		private MenuItem miNew;
		private MenuItem miOpen;
		private MenuItem miSave;
		private MenuItem miImport;
		private MenuItem miExit;
		private TreeView tCat;
		private TreeView tLoc;
		private TextBox txCat;
		private TextBox txLoc;
		private Button bAddCat;
		private Button bAddLoc;
		private LinkLabel lnk0;
		private LinkLabel lnk1;
		private LinkLabel lnk2;
		private LinkLabel lnk3;
		private RadioButton rClient;
		private RadioButton rMap;
		private RadioButton rManually;
		private GroupBox groupBox1;
		private GroupBox grpPoint;
		private NumericUpDown nX;
		private NumericUpDown nY;
		private NumericUpDown nZ;
		private Label label4;
		private Label label5;
		private Label label6;
		private MapViewer.MapViewer m_Map;
		private ContextMenu cmCat;
		private ContextMenu cmLoc;
		private MenuItem miCatRename;
		private MenuItem miCatDelete;
		private MenuItem miLocRename;
		private MenuItem miLocDelete;
		private MenuItem menuItem2;
		private MenuItem miUpdateClient;
		private MenuItem miUpdateMap;
		private FolderBrowserDialog BrowseFolder;
		private OpenFileDialog OpenFile;
		private MenuItem miLocUpdate;
		private MenuItem miMerge;
		private LinkLabel lnk4;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public TravelAgentForm()
		{
			InitializeComponent();
			m_FacetNode = new TreeNode("Facet");

			tCat.Nodes.Add(m_FacetNode);
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
			var resources = new System.Resources.ResourceManager(typeof(TravelAgentForm));
			this.mMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miNew = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.miMerge = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miImport = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.tCat = new System.Windows.Forms.TreeView();
			this.cmCat = new System.Windows.Forms.ContextMenu();
			this.miCatRename = new System.Windows.Forms.MenuItem();
			this.miCatDelete = new System.Windows.Forms.MenuItem();
			this.tLoc = new System.Windows.Forms.TreeView();
			this.cmLoc = new System.Windows.Forms.ContextMenu();
			this.miLocRename = new System.Windows.Forms.MenuItem();
			this.miLocDelete = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miLocUpdate = new System.Windows.Forms.MenuItem();
			this.miUpdateClient = new System.Windows.Forms.MenuItem();
			this.miUpdateMap = new System.Windows.Forms.MenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txCat = new System.Windows.Forms.TextBox();
			this.txLoc = new System.Windows.Forms.TextBox();
			this.bAddCat = new System.Windows.Forms.Button();
			this.bAddLoc = new System.Windows.Forms.Button();
			this.m_Map = new TheBox.MapViewer.MapViewer();
			this.label3 = new System.Windows.Forms.Label();
			this.lnk0 = new System.Windows.Forms.LinkLabel();
			this.lnk1 = new System.Windows.Forms.LinkLabel();
			this.lnk2 = new System.Windows.Forms.LinkLabel();
			this.lnk3 = new System.Windows.Forms.LinkLabel();
			this.rClient = new System.Windows.Forms.RadioButton();
			this.rMap = new System.Windows.Forms.RadioButton();
			this.rManually = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grpPoint = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nZ = new System.Windows.Forms.NumericUpDown();
			this.nY = new System.Windows.Forms.NumericUpDown();
			this.nX = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.BrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.lnk4 = new System.Windows.Forms.LinkLabel();
			this.groupBox1.SuspendLayout();
			this.grpPoint.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nX)).BeginInit();
			this.SuspendLayout();
			// 
			// mMain
			// 
			this.mMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[]
				{
					this.miNew, this.miOpen, this.miMerge, this.miSave, this.menuItem7, this.menuItem4, this.menuItem9, this.miExit
				});
			this.menuItem1.Text = "File";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// miNew
			// 
			this.miNew.Index = 0;
			this.miNew.Text = "New";
			this.miNew.Click += new System.EventHandler(this.miNew_Click);
			// 
			// miOpen
			// 
			this.miOpen.Index = 1;
			this.miOpen.Text = "Open";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miMerge
			// 
			this.miMerge.Index = 2;
			this.miMerge.Text = "Merge";
			this.miMerge.Click += new System.EventHandler(this.miMerge_Click);
			// 
			// miSave
			// 
			this.miSave.Index = 3;
			this.miSave.Text = "Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 5;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.miImport});
			this.menuItem4.Text = "Import";
			// 
			// miImport
			// 
			this.miImport.Index = 0;
			this.miImport.Text = "Pandora\'s Box 1";
			this.miImport.Click += new System.EventHandler(this.miImport_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 6;
			this.menuItem9.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 7;
			this.miExit.Text = "Exit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// tCat
			// 
			this.tCat.ContextMenu = this.cmCat;
			this.tCat.HideSelection = false;
			this.tCat.ImageIndex = -1;
			this.tCat.LabelEdit = true;
			this.tCat.Location = new System.Drawing.Point(4, 16);
			this.tCat.Name = "tCat";
			this.tCat.SelectedImageIndex = -1;
			this.tCat.Size = new System.Drawing.Size(132, 192);
			this.tCat.Sorted = true;
			this.tCat.TabIndex = 0;
			this.tCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tCat_AfterSelect);
			// 
			// cmCat
			// 
			this.cmCat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.miCatRename, this.miCatDelete});
			this.cmCat.Popup += new System.EventHandler(this.cmCat_Popup);
			// 
			// miCatRename
			// 
			this.miCatRename.Index = 0;
			this.miCatRename.Text = "Rename";
			this.miCatRename.Click += new System.EventHandler(this.miCatRename_Click);
			// 
			// miCatDelete
			// 
			this.miCatDelete.Index = 1;
			this.miCatDelete.Text = "Delete";
			this.miCatDelete.Click += new System.EventHandler(this.miCatDelete_Click);
			// 
			// tLoc
			// 
			this.tLoc.ContextMenu = this.cmLoc;
			this.tLoc.HideSelection = false;
			this.tLoc.ImageIndex = -1;
			this.tLoc.LabelEdit = true;
			this.tLoc.Location = new System.Drawing.Point(140, 16);
			this.tLoc.Name = "tLoc";
			this.tLoc.SelectedImageIndex = -1;
			this.tLoc.ShowLines = false;
			this.tLoc.ShowPlusMinus = false;
			this.tLoc.ShowRootLines = false;
			this.tLoc.Size = new System.Drawing.Size(128, 192);
			this.tLoc.Sorted = true;
			this.tLoc.TabIndex = 2;
			this.tLoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tLoc_AfterSelect);
			this.tLoc.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tLoc_AfterLabelEdit);
			// 
			// cmLoc
			// 
			this.cmLoc.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[] {this.miLocRename, this.miLocDelete, this.menuItem2, this.miLocUpdate});
			this.cmLoc.Popup += new System.EventHandler(this.cmLoc_Popup);
			// 
			// miLocRename
			// 
			this.miLocRename.Index = 0;
			this.miLocRename.Text = "Rename";
			this.miLocRename.Click += new System.EventHandler(this.miLocRename_Click);
			// 
			// miLocDelete
			// 
			this.miLocDelete.Index = 1;
			this.miLocDelete.Text = "Delete";
			this.miLocDelete.Click += new System.EventHandler(this.miLocDelete_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// miLocUpdate
			// 
			this.miLocUpdate.Index = 3;
			this.miLocUpdate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.miUpdateClient, this.miUpdateMap});
			this.miLocUpdate.Text = "Update Location";
			// 
			// miUpdateClient
			// 
			this.miUpdateClient.Index = 0;
			this.miUpdateClient.Text = "From the Client";
			this.miUpdateClient.Click += new System.EventHandler(this.miUpdateClient_Click);
			// 
			// miUpdateMap
			// 
			this.miUpdateMap.Index = 1;
			this.miUpdateMap.Text = "From the Map";
			this.miUpdateMap.Click += new System.EventHandler(this.miUpdateMap_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 14);
			this.label2.TabIndex = 3;
			this.label2.Text = "Locations";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Categories";
			// 
			// txCat
			// 
			this.txCat.Location = new System.Drawing.Point(4, 212);
			this.txCat.Name = "txCat";
			this.txCat.Size = new System.Drawing.Size(132, 20);
			this.txCat.TabIndex = 4;
			this.txCat.Text = "";
			this.txCat.TextChanged += new System.EventHandler(this.txCat_TextChanged);
			this.txCat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txCat_KeyUp);
			// 
			// txLoc
			// 
			this.txLoc.Location = new System.Drawing.Point(140, 212);
			this.txLoc.Name = "txLoc";
			this.txLoc.Size = new System.Drawing.Size(128, 20);
			this.txLoc.TabIndex = 5;
			this.txLoc.Text = "";
			this.txLoc.TextChanged += new System.EventHandler(this.txLoc_TextChanged);
			this.txLoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txLoc_KeyUp);
			// 
			// bAddCat
			// 
			this.bAddCat.Enabled = false;
			this.bAddCat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAddCat.Location = new System.Drawing.Point(92, 236);
			this.bAddCat.Name = "bAddCat";
			this.bAddCat.Size = new System.Drawing.Size(44, 23);
			this.bAddCat.TabIndex = 6;
			this.bAddCat.Text = "Add";
			this.bAddCat.Click += new System.EventHandler(this.bAddCat_Click);
			// 
			// bAddLoc
			// 
			this.bAddLoc.Enabled = false;
			this.bAddLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAddLoc.Location = new System.Drawing.Point(216, 236);
			this.bAddLoc.Name = "bAddLoc";
			this.bAddLoc.Size = new System.Drawing.Size(52, 23);
			this.bAddLoc.TabIndex = 7;
			this.bAddLoc.Text = "Add";
			this.bAddLoc.Click += new System.EventHandler(this.bAddLoc_Click);
			// 
			// m_Map
			// 
			this.m_Map.Center = new System.Drawing.Point(0, 0);
			this.m_Map.DisplayErrors = true;
			this.m_Map.DrawStatics = true;
			this.m_Map.Location = new System.Drawing.Point(272, 16);
			this.m_Map.Map = TheBox.MapViewer.Maps.Felucca;
			this.m_Map.Name = "m_Map";
			this.m_Map.Navigation = TheBox.MapViewer.MapNavigation.None;
			this.m_Map.ShowCross = true;
			this.m_Map.Size = new System.Drawing.Size(192, 192);
			this.m_Map.TabIndex = 8;
			this.m_Map.Text = "mapViewer1";
			this.m_Map.WheelZoom = false;
			this.m_Map.XRayView = false;
			this.m_Map.ZoomLevel = 0;
			this.m_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_Map_MouseDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(272, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "View Map:";
			// 
			// lnk0
			// 
			this.lnk0.Location = new System.Drawing.Point(332, 0);
			this.lnk0.Name = "lnk0";
			this.lnk0.Size = new System.Drawing.Size(16, 16);
			this.lnk0.TabIndex = 10;
			this.lnk0.TabStop = true;
			this.lnk0.Text = "0";
			this.lnk0.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk0_LinkClicked);
			// 
			// lnk1
			// 
			this.lnk1.Location = new System.Drawing.Point(356, 0);
			this.lnk1.Name = "lnk1";
			this.lnk1.Size = new System.Drawing.Size(16, 16);
			this.lnk1.TabIndex = 11;
			this.lnk1.TabStop = true;
			this.lnk1.Text = "1";
			this.lnk1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk1_LinkClicked);
			// 
			// lnk2
			// 
			this.lnk2.Location = new System.Drawing.Point(380, 0);
			this.lnk2.Name = "lnk2";
			this.lnk2.Size = new System.Drawing.Size(16, 16);
			this.lnk2.TabIndex = 12;
			this.lnk2.TabStop = true;
			this.lnk2.Text = "2";
			this.lnk2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk2_LinkClicked);
			// 
			// lnk3
			// 
			this.lnk3.Location = new System.Drawing.Point(404, 0);
			this.lnk3.Name = "lnk3";
			this.lnk3.Size = new System.Drawing.Size(16, 16);
			this.lnk3.TabIndex = 13;
			this.lnk3.TabStop = true;
			this.lnk3.Text = "3";
			this.lnk3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk3_LinkClicked);
			// 
			// rClient
			// 
			this.rClient.Checked = true;
			this.rClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rClient.Location = new System.Drawing.Point(8, 20);
			this.rClient.Name = "rClient";
			this.rClient.Size = new System.Drawing.Size(164, 16);
			this.rClient.TabIndex = 14;
			this.rClient.TabStop = true;
			this.rClient.Text = "Get location from the client";
			// 
			// rMap
			// 
			this.rMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rMap.Location = new System.Drawing.Point(8, 40);
			this.rMap.Name = "rMap";
			this.rMap.Size = new System.Drawing.Size(164, 16);
			this.rMap.TabIndex = 15;
			this.rMap.Text = "Get location from the map";
			// 
			// rManually
			// 
			this.rManually.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rManually.Location = new System.Drawing.Point(8, 60);
			this.rManually.Name = "rManually";
			this.rManually.Size = new System.Drawing.Size(164, 16);
			this.rManually.TabIndex = 16;
			this.rManually.Text = "Set location manually";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rManually);
			this.groupBox1.Controls.Add(this.rMap);
			this.groupBox1.Controls.Add(this.rClient);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(272, 212);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 84);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "When adding new locations:";
			// 
			// grpPoint
			// 
			this.grpPoint.Controls.Add(this.label6);
			this.grpPoint.Controls.Add(this.label5);
			this.grpPoint.Controls.Add(this.nZ);
			this.grpPoint.Controls.Add(this.nY);
			this.grpPoint.Controls.Add(this.nX);
			this.grpPoint.Controls.Add(this.label4);
			this.grpPoint.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpPoint.Location = new System.Drawing.Point(4, 260);
			this.grpPoint.Name = "grpPoint";
			this.grpPoint.Size = new System.Drawing.Size(264, 36);
			this.grpPoint.TabIndex = 18;
			this.grpPoint.TabStop = false;
			this.grpPoint.Text = "Point Edit";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(184, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 14);
			this.label6.TabIndex = 21;
			this.label6.Text = "Z";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(96, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 14);
			this.label5.TabIndex = 20;
			this.label5.Text = "Y";
			// 
			// nZ
			// 
			this.nZ.Location = new System.Drawing.Point(204, 12);
			this.nZ.Maximum = new System.Decimal(new int[] {127, 0, 0, 0});
			this.nZ.Minimum = new System.Decimal(new int[] {127, 0, 0, -2147483648});
			this.nZ.Name = "nZ";
			this.nZ.Size = new System.Drawing.Size(52, 20);
			this.nZ.TabIndex = 2;
			this.nZ.ValueChanged += new System.EventHandler(this.nZ_ValueChanged);
			// 
			// nY
			// 
			this.nY.Location = new System.Drawing.Point(116, 12);
			this.nY.Maximum = new System.Decimal(new int[] {5000, 0, 0, 0});
			this.nY.Name = "nY";
			this.nY.Size = new System.Drawing.Size(52, 20);
			this.nY.TabIndex = 1;
			this.nY.ValueChanged += new System.EventHandler(this.nY_ValueChanged);
			// 
			// nX
			// 
			this.nX.Location = new System.Drawing.Point(28, 12);
			this.nX.Maximum = new System.Decimal(new int[] {6500, 0, 0, 0});
			this.nX.Name = "nX";
			this.nX.Size = new System.Drawing.Size(52, 20);
			this.nX.TabIndex = 0;
			this.nX.ValueChanged += new System.EventHandler(this.nX_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 14);
			this.label4.TabIndex = 19;
			this.label4.Text = "X";
			// 
			// OpenFile
			// 
			this.OpenFile.Filter = "Xml Files (*.xml)|*.xml";
			// 
			// lnk4
			// 
			this.lnk4.Location = new System.Drawing.Point(428, 0);
			this.lnk4.Name = "lnk4";
			this.lnk4.Size = new System.Drawing.Size(16, 16);
			this.lnk4.TabIndex = 19;
			this.lnk4.TabStop = true;
			this.lnk4.Text = "4";
			this.lnk4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk4_LinkClicked);
			// 
			// TravelAgentForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 298);
			this.Controls.Add(this.lnk4);
			this.Controls.Add(this.grpPoint);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lnk3);
			this.Controls.Add(this.lnk2);
			this.Controls.Add(this.lnk1);
			this.Controls.Add(this.lnk0);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_Map);
			this.Controls.Add(this.bAddLoc);
			this.Controls.Add(this.bAddCat);
			this.Controls.Add(this.txLoc);
			this.Controls.Add(this.txCat);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tLoc);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tCat);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mMain;
			this.Name = "TravelAgentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Travel Agent for Pandora\'s Box";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.TravelAgentForm_Closing);
			this.groupBox1.ResumeLayout(false);
			this.grpPoint.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nX)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new TravelAgentForm());
		}

		private bool m_Changed;
		private Location m_Location;
		private readonly TreeNode m_FacetNode;
		private bool m_SettingLocation;

		#region Numeric Up and Downs, Map Links
		private void nX_ValueChanged(object sender, EventArgs e)
		{
			if (CurrentLocation != null && !m_SettingLocation)
			{
				CurrentLocation.X = (short)nX.Value;
				m_Changed = true;
			}
		}

		private void nY_ValueChanged(object sender, EventArgs e)
		{
			if (CurrentLocation != null && !m_SettingLocation)
			{
				CurrentLocation.X = (short)nY.Value;
				m_Changed = true;
			}
		}

		private void nZ_ValueChanged(object sender, EventArgs e)
		{
			if (CurrentLocation != null && !m_SettingLocation)
			{
				CurrentLocation.X = (short)nZ.Value;
				m_Changed = true;
			}
		}

		private void lnk0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Map.Map = Maps.Felucca;
		}

		private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Map.Map = Maps.Trammel;
		}

		private void lnk2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Map.Map = Maps.Ilshenar;
		}

		private void lnk3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Map.Map = Maps.Ilshenar;
		}

		private void lnk4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Map.Map = Maps.Tokuno;
		}
		#endregion

		#region Adding and trees
		private void txCat_TextChanged(object sender, EventArgs e)
		{
			EnableButtons();
		}

		private void txLoc_TextChanged(object sender, EventArgs e)
		{
			EnableButtons();
		}

		private void EnableButtons()
		{
			var addCat = txCat.Text.Length > 0;

			if (addCat)
			{
				var node = tCat.SelectedNode;

				addCat = node != null && (node == m_FacetNode || (node.Parent != null && node.Parent == m_FacetNode));
			}

			var addLoc = txLoc.Text.Length > 0;

			if (addLoc)
			{
				var node = tCat.SelectedNode;

				addLoc = node != null && node != m_FacetNode && node.Parent != null && node.Parent != m_FacetNode;
			}

			bAddCat.Enabled = addCat;
			bAddLoc.Enabled = addLoc;
		}

		private void bAddCat_Click(object sender, EventArgs e)
		{
			var node = new TreeNode(txCat.Text);

			var parent = tCat.SelectedNode;

			if (parent == null)
				return;

			if (parent != m_FacetNode)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				node.Tag = new List<object>();
				// Issue 10 - End
			}

			parent.Nodes.Add(node);
			parent.Expand();

			txCat.Clear();
			txCat.Focus();

			m_Changed = true;
			EnableButtons();
		}

		private void bAddLoc_Click(object sender, EventArgs e)
		{
			var parent = tCat.SelectedNode;

			if (parent.Tag == null)
				return;

			var x = 0;
			var y = 0;
			var z = 0;
			var map = 0;

			var loc = new Location();
			loc.Name = txLoc.Text;

			if (rClient.Checked)
			{
				Client.Calibrate();
				Client.FindLocation(ref x, ref y, ref z, ref map);
			}
			else if (rMap.Checked)
			{
				map = (int)m_Map.Map;
				x = m_Map.Center.X;
				y = m_Map.Center.Y;
				z = m_Map.GetMapHeight();
			}

			loc.X = (short)x;
			loc.Y = (short)y;
			loc.Z = (sbyte)z;
			loc.Map = map;

			var node = new TreeNode(loc.Name);
			node.Tag = loc;
			tLoc.Nodes.Add(node);
			tLoc.SelectedNode = node;

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert	
			(parent.Tag as List<object>).Add(loc);
			// Issue 10 - End

			txLoc.Clear();
			txLoc.Focus();

			m_Changed = true;
			EnableButtons();
		}

		private void txCat_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && bAddCat.Enabled)
				bAddCat.PerformClick();
		}

		private void txLoc_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && bAddLoc.Enabled)
				bAddLoc.PerformClick();
		}

		private void tCat_AfterSelect(object sender, TreeViewEventArgs e)
		{
			CurrentLocation = null;

			tLoc.BeginUpdate();
			tLoc.Nodes.Clear();

			if (e.Node != null && e.Node.Tag != null)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				foreach (Location loc in e.Node.Tag as List<object>)
					// Issue 10 - End
				{
					var node = new TreeNode(loc.Name);
					node.Tag = loc;
					tLoc.Nodes.Add(node);
				}
			}

			tLoc.EndUpdate();

			EnableButtons();
		}

		private void tLoc_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				CurrentLocation = e.Node.Tag as Location;
			}
			else
			{
				CurrentLocation = null;
			}
		}
		#endregion

		private void m_Map_MouseDown(object sender, MouseEventArgs e)
		{
			m_Map.Center = m_Map.ControlToMap(new Point(e.X, e.Y));
		}

		private void tLoc_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Label != null && e.Label.Length > 0)
			{
				(e.Node.Tag as Location).Name = e.Label;
			}
			else
			{
				e.CancelEdit = true;
			}
		}

		/// <summary>
		///     Gets or sets the currently selected location
		/// </summary>
		private Location CurrentLocation
		{
			get { return m_Location; }
			set
			{
				m_SettingLocation = true;

				m_Location = value;

				if (m_Location != null)
				{
					nX.Value = m_Location.X;
					nY.Value = m_Location.Y;
					nZ.Value = m_Location.Z;

					m_Map.Center = new Point(m_Location.X, m_Location.Y);
				}
				else
				{
					nX.Value = 0;
					nY.Value = 0;
					nZ.Value = 0;
				}

				nX.Enabled = m_Location != null;
				nY.Enabled = m_Location != null;
				nZ.Enabled = m_Location != null;

				m_SettingLocation = false;
			}
		}

		/// <summary>
		///     Gets or sets the facet being edited
		/// </summary>
		private Facet CurrentFacet
		{
			get
			{
				var f = new Facet();

				// Create facet
				foreach (TreeNode cat in m_FacetNode.Nodes)
				{
					var gCat = new GenericNode(cat.Text);

					foreach (TreeNode sub in cat.Nodes)
					{
						var gSub = new GenericNode(sub.Text);

						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						foreach (Location loc in sub.Tag as List<object>)
							// Issue 10 - End
						{
							gSub.Elements.Add(loc);
						}

						gCat.Elements.Add(gSub);
					}

					f.Nodes.Add(gCat);
				}

				return f;
			}
			set
			{
				tCat.BeginUpdate();
				tLoc.BeginUpdate();

				tCat.Nodes.Clear();
				tLoc.Nodes.Clear();

				m_FacetNode.Nodes.Clear();

				foreach (var gCat in value.Nodes)
				{
					var cat = new TreeNode(gCat.Name);

					foreach (GenericNode gSub in gCat.Elements)
					{
						var sub = new TreeNode(gSub.Name);
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						sub.Tag = new List<object>();
						// Issue 10 - End

						foreach (Location loc in gSub.Elements)
						{
							// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
							(sub.Tag as List<object>).Add(loc);
							// Issue 10 - End
						}

						cat.Nodes.Add(sub);
					}

					m_FacetNode.Nodes.Add(cat);
				}

				tCat.Nodes.Add(m_FacetNode);

				tCat.EndUpdate();
				tLoc.EndUpdate();
			}
		}

		private void Save()
		{
			var f = CurrentFacet;

			var mapindex = new MapIndexForm();
			mapindex.ShowDialog();

			var index = mapindex.MapFile;
			f.MapValue = (byte)index;

			if (BrowseFolder.ShowDialog() == DialogResult.OK)
			{
				var filename = Path.Combine(BrowseFolder.SelectedPath, string.Format("map{0}.xml", index));
				Utility.SaveXml(f, filename);

				MessageBox.Show(string.Format("This facet has been saved to:\n\n{0}", filename));
				m_Changed = false;
			}
		}

		private void CheckModified()
		{
			if (!m_Changed)
				return;

			if (MessageBox.Show(
					this,
					"The current document has been modified but hasn't been saved. Would you like to save it?",
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Save();
			}
		}

		private void miNew_Click(object sender, EventArgs e)
		{
			CheckModified();

			tCat.BeginUpdate();
			tCat.Nodes.Clear();
			tCat.EndUpdate();

			tLoc.BeginUpdate();
			tLoc.Nodes.Clear();
			tLoc.EndUpdate();

			m_Changed = false;
		}

		private void miOpen_Click(object sender, EventArgs e)
		{
			CheckModified();

			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				var f = Utility.LoadXml(typeof(Facet), OpenFile.FileName) as Facet;

				if (f != null)
				{
					CurrentFacet = f;
					m_Changed = false;
					m_Map.Map = (Maps)f.MapValue;
				}
				else
				{
					MessageBox.Show("Couldn't load the selected file");
				}
			}
		}

		private void miSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void miExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void miCatRename_Click(object sender, EventArgs e)
		{
			tCat.SelectedNode.BeginEdit();
		}

		private void cmCat_Popup(object sender, EventArgs e)
		{
			miCatRename.Enabled = tCat.SelectedNode != null && tCat.SelectedNode != m_FacetNode;
			miCatDelete.Enabled = tCat.SelectedNode != null && tCat.SelectedNode != m_FacetNode;
		}

		private void miCatDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					this,
					"This action will delete all the locations under the current category.\n\nAre you sure you wish to proceed?",
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				tCat.Nodes.Remove(tCat.SelectedNode);

				CurrentLocation = null;
				tLoc.BeginUpdate();
				tLoc.Nodes.Clear();
				tLoc.EndUpdate();
			}

			m_Changed = true;
		}

		private void cmLoc_Popup(object sender, EventArgs e)
		{
			miLocRename.Enabled = CurrentLocation != null;
			miLocDelete.Enabled = CurrentLocation != null;
			miUpdateClient.Enabled = CurrentLocation != null;
			miUpdateMap.Enabled = CurrentLocation != null;
			miLocUpdate.Enabled = CurrentLocation != null;
		}

		private void miLocRename_Click(object sender, EventArgs e)
		{
			tLoc.SelectedNode.BeginEdit();
		}

		private void miLocDelete_Click(object sender, EventArgs e)
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			(tCat.SelectedNode.Tag as List<object>).Remove(CurrentLocation);
			// Issue 10 - End
			tLoc.Nodes.Remove(tLoc.SelectedNode);
			CurrentLocation = null;

			m_Changed = true;
		}

		private void miUpdateClient_Click(object sender, EventArgs e)
		{
			if (CurrentLocation == null)
				return;

			var x = 0;
			var y = 0;
			var z = 0;
			var map = 0;

			Client.Calibrate();
			Client.FindLocation(ref x, ref y, ref z, ref map);

			CurrentLocation.X = (short)x;
			CurrentLocation.Y = (short)y;
			CurrentLocation.Z = (sbyte)z;
			CurrentLocation.Map = map;

			m_Changed = true;
		}

		private void miUpdateMap_Click(object sender, EventArgs e)
		{
			CurrentLocation.X = (short)m_Map.Center.X;
			CurrentLocation.Y = (short)m_Map.Center.Y;
			CurrentLocation.Z = (sbyte)m_Map.GetMapHeight();
			CurrentLocation.Map = (int)m_Map.Map;

			m_Changed = true;
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			miSave.Enabled = m_Changed;
		}

		private void miMerge_Click(object sender, EventArgs e)
		{
			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				var f = Utility.LoadXml(typeof(Facet), OpenFile.FileName) as Facet;

				if (f != null)
				{
					m_Changed = true;
					Merge(f);
				}
				else
				{
					MessageBox.Show("Couldn't load the selected file");
				}
			}
		}

		private void Merge(Facet f)
		{
			tCat.BeginUpdate();

			foreach (var cat in f.Nodes)
			{
				TreeNode catNode = null;

				foreach (TreeNode n in m_FacetNode.Nodes)
				{
					if (cat.Name.ToLower() == n.Text.ToLower())
					{
						catNode = n;
						break;
					}
				}

				if (catNode == null)
				{
					catNode = new TreeNode(cat.Name);
					m_FacetNode.Nodes.Add(catNode);
				}

				foreach (GenericNode sub in cat.Elements)
				{
					TreeNode subNode = null;

					foreach (TreeNode n in catNode.Nodes)
					{
						if (sub.Name.ToLower() == n.Text.ToLower())
						{
							subNode = n;
							break;
						}
					}

					if (subNode == null)
					{
						subNode = new TreeNode(sub.Name);
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						subNode.Tag = new List<object>();
						// Issue 10 - End
					}

					catNode.Nodes.Add(subNode);

					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					(subNode.Tag as List<object>).AddRange(sub.Elements);
					// Issue 10 - End
				}
			}

			CurrentLocation = null;
			tLoc.Nodes.Clear();

			tCat.EndUpdate();
		}

		private void TravelAgentForm_Closing(object sender, CancelEventArgs e)
		{
			CheckModified();
		}

		private void miImport_Click(object sender, EventArgs e)
		{
			CheckModified();

			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				var f = PB1Import.Convert(OpenFile.FileName);

				if (f != null)
				{
					if (m_FacetNode.Nodes.Count > 0)
					{
						// Merge?
						if (MessageBox.Show(
								this,
								"You can add the new locations to the current project, or delete all exisitng entires and add the imported file to a blank project.\n\nYes: Merge the new locations with the existing project\nNo: Create a new blank project and add the imported locations",
								"Import Succesful",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
						{
							// Merge
							Merge(f);
							m_Changed = true;
						}
						else
						{
							CurrentFacet = f;
							m_Changed = true;
						}
					}
					else
					{
						CurrentFacet = f;
						m_Changed = true;
					}
				}
				else
				{
					MessageBox.Show("Import failed");
				}
			}
		}
	}
}