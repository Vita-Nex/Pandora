#region Header
// /*
//  *    2018 - Pandora - Travel.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Buttons;
using TheBox.Common;
using TheBox.Data;
using TheBox.Forms;
using TheBox.Forms.Editors;
using TheBox.MapViewer;

using Ultima;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Travel.
	/// </summary>
	public class Travel : UserControl
	{
		private LinkLabel lnkPoint;
		private LinkLabel lnkZoomIn;
		private LinkLabel lnkZoomOut;
		private LinkLabel lnkWorld;
		private Button bGo;
		private Button bSend;
		private LinkLabel linkLabel1;
		private ListBox listMaps;
		private TreeView tCat;
		private TreeView tLoc;
		private ContextMenu LocMenu;
		private ContextMenu CatMenu;
		private MenuItem mLocEdit;
		private MenuItem mLocDel;
		private MenuItem menuItem3;
		private MenuItem mLocNew;
		private MenuItem mCatNewCat;
		private MenuItem mCatNewSub;
		private MenuItem menuItem7;
		private MenuItem mCatDelete;
		private MenuItem mCatRename;
		private BoxButton boxButton1;
		private MenuItem menuItem1;
		private MenuItem mCatUp;
		private MenuItem mCatDown;
		private Panel panel1;
		private Splitter splitter;
		private Button bSetMap;
		private CheckBox chkSynch;
		private Button bSynch;
		private Timer tmr;
		private IContainer components;

		public Travel()
		{
			InitializeComponent();
		}

		#region Variables
		/// <summary>
		///     String format for the display of a map point
		/// </summary>
		private const string m_Point = "({0},{1},{2})";

		/// <summary>
		///     The maps corresponding to the listMaps items
		/// </summary>
		private readonly int[] m_Maps = {-1, -1, -1, -1, -1};

		private int m_X;
		private int m_Y;
		private int m_Z;
		private int m_Map;

		/// <summary>
		///     The search results
		/// </summary>
		private SearchResults m_Results;

		/// <summary>
		///     Flag for updating values without firing events
		/// </summary>
		private bool m_StopMessages;
		#endregion

		#region Methods
		/// <summary>
		///     Sets the text on the page according to the selected location
		/// </summary>
		private void SetLocationText()
		{
			lnkPoint.Text = string.Format(m_Point, m_X, m_Y, m_Z);
		}
		#endregion

		#region Properties
		public Location SelectedLocation
		{
			set
			{
				m_X = value.X;
				m_Y = value.Y;

				Pandora.Map.Center = new Point(m_X, m_Y);

				m_Z = value.Z;
				SetLocationText();
			}
		}
		#endregion

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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tCat = new System.Windows.Forms.TreeView();
			this.tLoc = new System.Windows.Forms.TreeView();
			this.bGo = new System.Windows.Forms.Button();
			this.bSend = new System.Windows.Forms.Button();
			this.bSetMap = new System.Windows.Forms.Button();
			this.lnkPoint = new System.Windows.Forms.LinkLabel();
			this.lnkZoomIn = new System.Windows.Forms.LinkLabel();
			this.lnkZoomOut = new System.Windows.Forms.LinkLabel();
			this.lnkWorld = new System.Windows.Forms.LinkLabel();
			this.listMaps = new System.Windows.Forms.ListBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.LocMenu = new System.Windows.Forms.ContextMenu();
			this.mLocEdit = new System.Windows.Forms.MenuItem();
			this.mLocDel = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mLocNew = new System.Windows.Forms.MenuItem();
			this.CatMenu = new System.Windows.Forms.ContextMenu();
			this.mCatNewCat = new System.Windows.Forms.MenuItem();
			this.mCatNewSub = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.mCatRename = new System.Windows.Forms.MenuItem();
			this.mCatDelete = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mCatUp = new System.Windows.Forms.MenuItem();
			this.mCatDown = new System.Windows.Forms.MenuItem();
			this.boxButton1 = new TheBox.Buttons.BoxButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter = new System.Windows.Forms.Splitter();
			this.chkSynch = new System.Windows.Forms.CheckBox();
			this.bSynch = new System.Windows.Forms.Button();
			this.tmr = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tCat
			// 
			this.tCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.tCat.HideSelection = false;
			this.tCat.ImageIndex = -1;
			this.tCat.Location = new System.Drawing.Point(0, 0);
			this.tCat.Name = "tCat";
			this.tCat.SelectedImageIndex = -1;
			this.tCat.Size = new System.Drawing.Size(152, 140);
			this.tCat.TabIndex = 0;
			this.tCat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			this.tCat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tCat_MouseDown);
			this.tCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tCat_AfterSelect);
			this.tCat.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tCat_AfterLabelEdit);
			// 
			// tLoc
			// 
			this.tLoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tLoc.HideSelection = false;
			this.tLoc.ImageIndex = -1;
			this.tLoc.Location = new System.Drawing.Point(155, 0);
			this.tLoc.Name = "tLoc";
			this.tLoc.SelectedImageIndex = -1;
			this.tLoc.ShowLines = false;
			this.tLoc.ShowPlusMinus = false;
			this.tLoc.ShowRootLines = false;
			this.tLoc.Size = new System.Drawing.Size(161, 140);
			this.tLoc.TabIndex = 1;
			this.tLoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			this.tLoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tLoc_MouseDown);
			this.tLoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tLoc_AfterSelect);
			// 
			// bGo
			// 
			this.bGo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bGo.Location = new System.Drawing.Point(320, 0);
			this.bGo.Name = "bGo";
			this.bGo.Size = new System.Drawing.Size(96, 24);
			this.bGo.TabIndex = 3;
			this.bGo.Text = "Travel.Go";
			this.bGo.Click += new System.EventHandler(this.bGo_Click);
			this.bGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			// 
			// bSend
			// 
			this.bSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSend.Location = new System.Drawing.Point(420, 0);
			this.bSend.Name = "bSend";
			this.bSend.Size = new System.Drawing.Size(75, 24);
			this.bSend.TabIndex = 4;
			this.bSend.Text = "Travel.Send";
			this.bSend.Click += new System.EventHandler(this.bSend_Click);
			this.bSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			// 
			// bSetMap
			// 
			this.bSetMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSetMap.Location = new System.Drawing.Point(420, 28);
			this.bSetMap.Name = "bSetMap";
			this.bSetMap.Size = new System.Drawing.Size(76, 23);
			this.bSetMap.TabIndex = 6;
			this.bSetMap.Text = "Travel.SetMap";
			this.bSetMap.Click += new System.EventHandler(this.bSetMap_Click);
			this.bSetMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			// 
			// lnkPoint
			// 
			this.lnkPoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkPoint.LinkColor = System.Drawing.Color.Navy;
			this.lnkPoint.Location = new System.Drawing.Point(320, 104);
			this.lnkPoint.Name = "lnkPoint";
			this.lnkPoint.Size = new System.Drawing.Size(88, 16);
			this.lnkPoint.TabIndex = 12;
			this.lnkPoint.TabStop = true;
			this.lnkPoint.Text = "5555,5555,555";
			this.lnkPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkPoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPoint_LinkClicked);
			// 
			// lnkZoomIn
			// 
			this.lnkZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lnkZoomIn.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				14.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.lnkZoomIn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkZoomIn.LinkColor = System.Drawing.Color.Red;
			this.lnkZoomIn.Location = new System.Drawing.Point(476, 112);
			this.lnkZoomIn.Name = "lnkZoomIn";
			this.lnkZoomIn.Size = new System.Drawing.Size(16, 16);
			this.lnkZoomIn.TabIndex = 13;
			this.lnkZoomIn.TabStop = true;
			this.lnkZoomIn.Text = "+";
			this.lnkZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkZoomIn.VisitedLinkColor = System.Drawing.Color.Red;
			this.lnkZoomIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkZoomIn_LinkClicked);
			// 
			// lnkZoomOut
			// 
			this.lnkZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lnkZoomOut.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				24F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.lnkZoomOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkZoomOut.LinkColor = System.Drawing.Color.Red;
			this.lnkZoomOut.Location = new System.Drawing.Point(476, 128);
			this.lnkZoomOut.Name = "lnkZoomOut";
			this.lnkZoomOut.Size = new System.Drawing.Size(16, 16);
			this.lnkZoomOut.TabIndex = 14;
			this.lnkZoomOut.TabStop = true;
			this.lnkZoomOut.Text = "-";
			this.lnkZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkZoomOut.VisitedLinkColor = System.Drawing.Color.Red;
			this.lnkZoomOut.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkZoomOut_LinkClicked);
			// 
			// lnkWorld
			// 
			this.lnkWorld.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkWorld.LinkColor = System.Drawing.Color.Red;
			this.lnkWorld.Location = new System.Drawing.Point(416, 120);
			this.lnkWorld.Name = "lnkWorld";
			this.lnkWorld.Size = new System.Drawing.Size(60, 16);
			this.lnkWorld.TabIndex = 15;
			this.lnkWorld.TabStop = true;
			this.lnkWorld.Text = "Travel.World";
			this.lnkWorld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkWorld.VisitedLinkColor = System.Drawing.Color.Red;
			this.lnkWorld.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWorld_LinkClicked);
			// 
			// listMaps
			// 
			this.listMaps.Location = new System.Drawing.Point(320, 28);
			this.listMaps.Name = "listMaps";
			this.listMaps.Size = new System.Drawing.Size(96, 69);
			this.listMaps.TabIndex = 16;
			this.listMaps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			this.listMaps.DoubleClick += new System.EventHandler(this.listMaps_DoubleClick);
			this.listMaps.SelectedIndexChanged += new System.EventHandler(this.listMaps_SelectedIndexChanged);
			// 
			// linkLabel1
			// 
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = System.Drawing.Color.Navy;
			this.linkLabel1.Location = new System.Drawing.Point(320, 120);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(80, 16);
			this.linkLabel1.TabIndex = 17;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Travel.Find";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// LocMenu
			// 
			this.LocMenu.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[] {this.mLocEdit, this.mLocDel, this.menuItem3, this.mLocNew});
			// 
			// mLocEdit
			// 
			this.mLocEdit.Index = 0;
			this.mLocEdit.Text = "Common.Edit";
			this.mLocEdit.Click += new System.EventHandler(this.mLocEdit_Click);
			// 
			// mLocDel
			// 
			this.mLocDel.Index = 1;
			this.mLocDel.Text = "Common.Delete";
			this.mLocDel.Click += new System.EventHandler(this.mLocDel_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// mLocNew
			// 
			this.mLocNew.Index = 3;
			this.mLocNew.Text = "Travel.NewLoc";
			this.mLocNew.Click += new System.EventHandler(this.mLocNew_Click);
			// 
			// CatMenu
			// 
			this.CatMenu.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[]
				{
					this.mCatNewCat, this.mCatNewSub, this.menuItem7, this.mCatRename, this.mCatDelete, this.menuItem1, this.mCatUp,
					this.mCatDown
				});
			// 
			// mCatNewCat
			// 
			this.mCatNewCat.Index = 0;
			this.mCatNewCat.Text = "Travel.NewCat";
			this.mCatNewCat.Click += new System.EventHandler(this.mCatNewCat_Click);
			// 
			// mCatNewSub
			// 
			this.mCatNewSub.Index = 1;
			this.mCatNewSub.Text = "Travel.NewSub";
			this.mCatNewSub.Click += new System.EventHandler(this.mCatNewSub_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// mCatRename
			// 
			this.mCatRename.Index = 3;
			this.mCatRename.Text = "Common.Rename";
			this.mCatRename.Click += new System.EventHandler(this.mCatRename_Click);
			// 
			// mCatDelete
			// 
			this.mCatDelete.Index = 4;
			this.mCatDelete.Text = "Common.Delete";
			this.mCatDelete.Click += new System.EventHandler(this.mCatDelete_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.Text = "-";
			// 
			// mCatUp
			// 
			this.mCatUp.Index = 6;
			this.mCatUp.Text = "Move node up";
			this.mCatUp.Click += new System.EventHandler(this.mCatUp_Click);
			// 
			// mCatDown
			// 
			this.mCatDown.Index = 7;
			this.mCatDown.Text = "Move node down";
			this.mCatDown.Click += new System.EventHandler(this.mCatDown_Click);
			// 
			// boxButton1
			// 
			this.boxButton1.AllowEdit = true;
			this.boxButton1.ButtonID = 35;
			this.boxButton1.Def = null;
			this.boxButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton1.IsActive = true;
			this.boxButton1.Location = new System.Drawing.Point(420, 56);
			this.boxButton1.Name = "boxButton1";
			this.boxButton1.Size = new System.Drawing.Size(76, 23);
			this.boxButton1.TabIndex = 18;
			this.boxButton1.Text = "boxButton1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tLoc);
			this.panel1.Controls.Add(this.splitter);
			this.panel1.Controls.Add(this.tCat);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 140);
			this.panel1.TabIndex = 19;
			// 
			// splitter
			// 
			this.splitter.Location = new System.Drawing.Point(152, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(3, 140);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			this.splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoved);
			// 
			// chkSynch
			// 
			this.chkSynch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkSynch.Location = new System.Drawing.Point(420, 86);
			this.chkSynch.Name = "chkSynch";
			this.chkSynch.Size = new System.Drawing.Size(16, 16);
			this.chkSynch.TabIndex = 20;
			this.chkSynch.CheckedChanged += new System.EventHandler(this.chkSynch_CheckedChanged);
			// 
			// bSynch
			// 
			this.bSynch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSynch.Location = new System.Drawing.Point(436, 84);
			this.bSynch.Name = "bSynch";
			this.bSynch.Size = new System.Drawing.Size(60, 20);
			this.bSynch.TabIndex = 21;
			this.bSynch.Text = "Synch";
			this.bSynch.Click += new System.EventHandler(this.bSynch_Click);
			// 
			// tmr
			// 
			this.tmr.Enabled = true;
			this.tmr.Interval = 2000;
			this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
			// 
			// Travel
			// 
			this.Controls.Add(this.bSynch);
			this.Controls.Add(this.chkSynch);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.boxButton1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.listMaps);
			this.Controls.Add(this.lnkWorld);
			this.Controls.Add(this.lnkZoomOut);
			this.Controls.Add(this.lnkZoomIn);
			this.Controls.Add(this.lnkPoint);
			this.Controls.Add(this.bSetMap);
			this.Controls.Add(this.bSend);
			this.Controls.Add(this.bGo);
			this.Name = "Travel";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Travel_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeys);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Handles changes of the map coordinates
		/// </summary>
		private void Map_MapLocationChanged(object sender, EventArgs e)
		{
			m_X = Pandora.Map.Center.X;
			m_Y = Pandora.Map.Center.Y;
			m_Z = Pandora.Map.GetMapHeight();

			SetLocationText();

			Pandora.Profile.Travel.MapCenter = Pandora.Map.Center;
		}

		/// <summary>
		///     Handles changes of the map plane
		/// </summary>
		private void Map_MapChanged(object sender, EventArgs e)
		{
			m_Map = (int)Pandora.Map.Map;
			Pandora.Profile.Travel.Map = m_Map;

			// Update Z coordinate
			m_Z = Pandora.Map.GetMapHeight();

			SetMapList(m_Map);
		}

		/// <summary>
		///     Performs initialization depending on the options
		/// </summary>
		public void Init()
		{
			if (Pandora.Profile.Travel.IsEnabled)
			{
				// Enabled maps
				var index = 0;

				for (var i = 0; i < Pandora.Profile.Travel.MapNames.Length; i++)
				{
					if (Pandora.Profile.Travel.EnabledMaps[i])
					{
						listMaps.Items.Add(Pandora.Profile.Travel.MapNames[i]);
						m_Maps[index++] = i;
					}
				}

				// Set the correct map
				m_Map = Pandora.Profile.Travel.Map;

				if (!Pandora.Profile.Travel.EnabledMaps[m_Map])
					m_Map = m_Maps[0];

				var mapIndex = GetMapIndex(m_Map);

				// Set the viewer
				Pandora.Map.MapLocationChanged += Map_MapLocationChanged;
				Pandora.Map.MapChanged += Map_MapChanged;
				Pandora.Map.Center = Pandora.Profile.Travel.MapCenter;
				Pandora.Map.Map = (Maps)m_Map;
				Pandora.Map.ZoomLevel = Pandora.Profile.Travel.Zoom;

				// Location
				m_X = Pandora.Profile.Travel.MapCenter.X;
				m_Y = Pandora.Profile.Travel.MapCenter.Y;
				m_Z = Pandora.Map.GetMapHeight(Pandora.Profile.Travel.MapCenter);

				DoTree();

				// Set this only after do tree
				listMaps.SelectedIndex = mapIndex;
			}
			else
			{
				// Travel disabled
				Pandora.Log.WriteEntry(string.Format("No maps enabled on profile {0}", Pandora.Profile.Name));
			}

			// Set handlers for the options
			Pandora.Profile.Travel.TreeDisplayChanged += Travel_TreeDisplayChanged;
		}

		/// <summary>
		///     Creates the tree
		/// </summary>
		private void DoTree()
		{
			tCat.BeginUpdate();
			tLoc.BeginUpdate();

			tCat.Nodes.Clear();
			tLoc.Nodes.Clear();

			tLoc.EndUpdate();

			if (Pandora.Profile.Travel.IsEnabled)
			{
				if (Pandora.Profile.Travel.SelectedMapLocations)
				{
					tCat.Nodes.AddRange(Pandora.TravelAgent.GetNode(m_Map));
				}
				else
				{
					tCat.Nodes.AddRange(Pandora.TravelAgent.GetFullTree());
					tCat.SelectedNode = tCat.Nodes[GetMapIndex(m_Map)];
				}
			}

			tCat.EndUpdate();
		}

		/// <summary>
		///     Gets the index of a given map in the list of enabled maps list
		/// </summary>
		/// <param name="map">The ID of the map</param>
		/// <returns>The index of the given map in the enabled maps list. -1 if it's not enabled</returns>
		private int GetMapIndex(int map)
		{
			for (var i = 0; i < Pandora.Profile.Travel.MapCount; i++)
			{
				if (map == m_Maps[i])
					return i;
			}

			return -1;
		}

		/// <summary>
		///     ZOOM IN
		/// </summary>
		private void lnkZoomIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Pandora.Map.ZoomIn();
			Pandora.Profile.Travel.Zoom = Pandora.Map.ZoomLevel;
		}

		/// <summary>
		///     ZOOM OUT
		/// </summary>
		private void lnkZoomOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Pandora.Map.ZoomOut();
			Pandora.Profile.Travel.Zoom = Pandora.Map.ZoomLevel;
		}

		/// <summary>
		///     WORLD MAP
		/// </summary>
		private void lnkWorld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Pandora.Profile.Travel.IsEnabled)
			{
				var wm = new WorldMap();
				wm.Show();
			}
			else
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Travel.NoMaps"]);
			}
		}

		/// <summary>
		///     GO
		/// </summary>
		private void bGo_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoGo(m_X, m_Y, m_Z, m_Map);
		}

		/// <summary>
		///     MAPS LIST: INDEX CHANGED
		/// </summary>
		private void listMaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_StopMessages)
				return;

			if (listMaps.SelectedIndex != -1)
			{
				Pandora.Map.Map = (Maps)m_Maps[listMaps.SelectedIndex];
				chkSynch.Checked = false;

				if (Pandora.Profile.Travel.SelectedMapLocations)
				{
					DoTree();
				}
				else
				{
					tCat.SelectedNode = tCat.Nodes[listMaps.SelectedIndex];
				}
			}
		}

		/// <summary>
		///     Sets the map value on the map lists without firing any further events
		/// </summary>
		/// <param name="mapIndex">The map to set</param>
		private void SetMapList(int mapIndex)
		{
			var index = GetMapIndex(mapIndex);

			m_StopMessages = true;

			listMaps.SelectedIndex = index;

			m_StopMessages = false;
		}

		/// <summary>
		///     MAPS LIST: DOUBLE CLICK
		/// </summary>
		private void listMaps_DoubleClick(object sender, EventArgs e)
		{
			if (listMaps.SelectedIndex != -1)
			{
				Pandora.SendToUO(string.Format("Set Map {0}", m_Map), true);
			}
		}

		/// <summary>
		///     SEND
		/// </summary>
		private void bSend_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoSend(m_X, m_Y, m_Z, m_Map);
		}

		/// <summary>
		///     CAT TREE: After select
		/// </summary>
		private void tCat_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tLoc.BeginUpdate();
			tLoc.Nodes.Clear();
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			if (tCat.SelectedNode.Tag is List<object>)
			{
				tLoc.Nodes.AddRange(Pandora.TravelAgent.GetLocationNodes(tCat.SelectedNode.Tag as List<object>));
				// Issue 10 - End
			}

			tLoc.EndUpdate();
		}

		/// <summary>
		///     LOC TREE: After select
		/// </summary>
		private void tLoc_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (tLoc.SelectedNode == null)
			{
				return;
			}

			//			// Verify the currently loaded list corresponds to the node selected on the category
			//			if ( tCat.SelectedNode == null || tCat.SelectedNode.Tag == null || ! ( tCat.SelectedNode.Tag is ArrayList ) )
			//			{
			//				return;
			//			}
			//			else
			//			{
			//				int index = tLoc.Nodes.IndexOf( tLoc.SelectedNode );
			//
			//				if ( ( ( ( tCat.SelectedNode.Tag as ArrayList )[ index ] ) as Location ) != ( tLoc.SelectedNode.Tag as Location ) )
			//				{
			//					return;
			//				}
			//			}

			if (!Pandora.Profile.Travel.SelectedMapLocations)
			{
				var node = tCat.SelectedNode;

				while (node.Tag == null || node.Tag.GetType() != typeof(int))
				{
					node = node.Parent;
				}

				Pandora.Map.Map = (Maps)m_Maps[tCat.Nodes.IndexOf(node)];
			}

			SelectedLocation = tLoc.SelectedNode.Tag as Location;
			chkSynch.Checked = false;
		}

		/// <summary>
		///     OPTION CHANGED: SELECTED MAP ONLY
		/// </summary>
		private void Travel_TreeDisplayChanged(object sender, EventArgs e)
		{
			DoTree();
			listMaps.SelectedIndex = listMaps.SelectedIndex;
		}

		#region Searching
		/// <summary>
		///     FIND LINK
		/// </summary>
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var sf = new SearchForm(SearchForm.SearchType.Location);

			if (sf.ShowDialog() == DialogResult.OK)
			{
				if (sf.SearchString != null)
				{
					DoSearch(sf.SearchString);
				}
			}
		}

		/// <summary>
		///     Performs a search
		/// </summary>
		/// <param name="text">The text to search for</param>
		private void DoSearch(string text)
		{
			m_Results = Pandora.TravelAgent.SearchFor(text, tCat.Nodes, Pandora.Profile.Travel.SelectedMapLocations);

			if (m_Results.Count == 0)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Misc.NoResults"]);
				m_Results = null;
			}
			else
			{
				NextSearchResult();
			}
		}

		/// <summary>
		///     Displays the next result in the list
		/// </summary>
		private void NextSearchResult()
		{
			if (m_Results != null)
			{
				var res = m_Results.GetNext();

				if (res != null)
				{
					DisplayResult(res);
				}
			}
		}

		/// <summary>
		///     Displays the previous result in the list
		/// </summary>
		private void PrevSearchResult()
		{
			if (m_Results != null)
			{
				var res = m_Results.GetPrevious();

				if (res != null)
				{
					DisplayResult(res);
				}
			}
		}

		/// <summary>
		///     Displays a search result
		/// </summary>
		/// <param name="res"></param>
		private void DisplayResult(Result res)
		{
			try
			{
				tCat.SelectedNode = res.Node;
				tLoc.SelectedNode = tLoc.Nodes[res.Index];
			}
			catch
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Misc.SearchError"]);
				m_Results = null;
			}
		}

		/// <summary>
		///     Processes the usage of keys to perform actions on the travel tab
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void DoKeys(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:

					PrevSearchResult();
					break;

				case Keys.F8:

					NextSearchResult();
					break;
			}
		}
		#endregion

		/// <summary>
		///     Find location by specifying a point
		/// </summary>
		private void lnkPoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var pf = new PointForm();

			if (pf.ShowDialog() == DialogResult.OK)
			{
				Pandora.Map.Center = new Point(pf.PointX, pf.PointY);

				m_Z = pf.PointZ;

				SetLocationText();
			}
		}

		/// <summary>
		///     Selects the appropriate map according to the node selected on the tCat
		/// </summary>
		private void EnsureMap()
		{
			if (Pandora.Profile.Travel.SelectedMapLocations)
			{
				// Only one facet, do nothing
			}
			else
			{
				var node = tCat.SelectedNode;

				if (node == null)
					return;

				while (node.Parent != null)
					node = node.Parent;

				var index = tCat.Nodes.IndexOf(node);

				var map = m_Maps[index];

				Pandora.Map.Map = (Maps)map;
			}
		}

		#region Data Editing
		/// <summary>
		///     Updates the map information in the travel agent for the selected map
		/// </summary>
		private void UpdateMap()
		{
			EnsureMap();

			// Update map
			TreeNodeCollection nodes = null;

			if (Pandora.Profile.Travel.SelectedMapLocations)
			{
				// Only one facet displayed
				nodes = tCat.Nodes;
			}
			else
			{
				nodes = tCat.Nodes[GetMapIndex(m_Map)].Nodes;
			}

			Pandora.TravelAgent.UpdateMap(m_Map, nodes);
		}

		/// <summary>
		///     Location context menu
		/// </summary>
		private void tLoc_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (tCat.SelectedNode == null)
					return;
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				if (tCat.SelectedNode.Tag == null || !(tCat.SelectedNode.Tag is List<object>))
					// Issue 10 - End
					return;

				var onNode = tLoc.GetNodeAt(e.X, e.Y);

				if (onNode == null)
				{
					mLocDel.Enabled = false;
					mLocEdit.Enabled = false;
				}
				else
				{
					if (onNode != tLoc.SelectedNode)
					{
						tLoc.SelectedNode = onNode;
					}

					mLocEdit.Enabled = true;
					mLocDel.Enabled = true;
				}

				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				// Enable new location only if the selected node is a subsection node
				if (tCat.SelectedNode.Tag != null && tCat.SelectedNode.Tag is List<object>)
					// Issue 10 - End
				{
					mLocNew.Enabled = true;
				}
				else
				{
					mLocNew.Enabled = false;
				}

				LocMenu.Show(tLoc, new Point(e.X, e.Y));
			}
		}

		/// <summary>
		///     Delete location
		/// </summary>
		private void mLocDel_Click(object sender, EventArgs e)
		{
			// A location and category is selected
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Travel.ConfirmDelLoc"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					var sub = tCat.SelectedNode;

					var index = tLoc.Nodes.IndexOf(tLoc.SelectedNode);

					var next = tLoc.SelectedNode.NextNode;

					if (next == null)
						next = tLoc.SelectedNode.PrevNode;

					var nextIndex = -1;

					tLoc.Nodes.Remove(tLoc.SelectedNode);

					if (next != null)
						nextIndex = tLoc.Nodes.IndexOf(next);
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					(sub.Tag as List<object>).RemoveAt(index);
					// Issue 10 - End

					var node = tCat.SelectedNode;
					tCat.SelectedNode = null;
					tCat.SelectedNode = node;

					if (nextIndex > -1)
						tLoc.SelectedNode = tLoc.Nodes[nextIndex];

					UpdateMap();
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, "Deleting location");
					MessageBox.Show(Pandora.Localization.TextProvider["Messages.GenericError"]);
				}
			}
		}

		/// <summary>
		///     Create a new location. It's assumed a cat/subsection is already selected
		/// </summary>
		private void mLocNew_Click(object sender, EventArgs e)
		{
			var location = new Location();
			location.X = (short)m_X;
			location.Y = (short)m_Y;
			location.Z = (sbyte)m_Z;

			var quickLoc = new QuickLocation();

			EnsureMap();

			quickLoc.MapFile = m_Map;
			quickLoc.CurrentLocation = location;

			if (quickLoc.ShowDialog() == DialogResult.OK)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var list = tCat.SelectedNode.Tag as List<object>;
				// Issue 10 - End

				if (list != null)
				{
					list.Add(quickLoc.CurrentLocation);
					list.Sort();

					var index = list.IndexOf(quickLoc.CurrentLocation);

					var node = tCat.SelectedNode;
					tCat.SelectedNode = null;
					tCat.SelectedNode = node;

					tLoc.SelectedNode = tLoc.Nodes[index];

					UpdateMap();
				}
				else
				{
					Pandora.Log.WriteError(null, "Couldn\'t add location because the tCat node wasn\'t a subsection node");
					MessageBox.Show(Pandora.Localization.TextProvider["Messages.NewLocErr"]);
				}
			}
		}

		/// <summary>
		///     Edit selected location
		/// </summary>
		private void mLocEdit_Click(object sender, EventArgs e)
		{
			var location = tLoc.SelectedNode.Tag as Location;

			var quickLoc = new QuickLocation();

			EnsureMap();

			quickLoc.MapFile = m_Map;
			quickLoc.CurrentLocation = location;

			if (quickLoc.ShowDialog() == DialogResult.OK)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				(tCat.SelectedNode.Tag as List<object>).Sort();

				var index = (tCat.SelectedNode.Tag as List<object>).IndexOf(location);
				// Issue 10 - End

				var node = tCat.SelectedNode;
				tCat.SelectedNode = null;
				tCat.SelectedNode = node;

				tLoc.SelectedNode = tLoc.Nodes[index];

				UpdateMap();
			}
		}

		/// <summary>
		///     Category context menu
		/// </summary>
		private void tCat_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (tCat.Nodes.Count == 0)
					return;

				var node = tCat.GetNodeAt(e.X, e.Y);

				tCat.SelectedNode = node;

				if (Pandora.Profile.Travel.SelectedMapLocations)
				{
					// Only one facet shown
					if (tCat.SelectedNode == null)
					{
						mCatNewCat.Enabled = true;
						mCatNewSub.Enabled = false;
						mCatDelete.Enabled = false;
						mCatRename.Enabled = false;
						mCatDown.Enabled = false;
						mCatUp.Enabled = false;
					}
					else
					{
						mCatNewCat.Enabled = true;
						mCatNewSub.Enabled = true;
						mCatRename.Enabled = true;
						mCatDelete.Enabled = true;

						node = tCat.SelectedNode;

						if (node.NextNode != null)
							mCatDown.Enabled = true;
						else
							mCatDown.Enabled = false;

						if (node.PrevNode != null)
							mCatUp.Enabled = true;
						else
							mCatUp.Enabled = false;
					}
				}
				else
				{
					// All facets shown
					if (tCat.SelectedNode == null)
					{
						mCatNewCat.Enabled = false;
						mCatNewSub.Enabled = false;
						mCatDelete.Enabled = false;
						mCatRename.Enabled = false;

						mCatDown.Enabled = false;
						mCatUp.Enabled = false;
					}
					else
					{
						if (tCat.SelectedNode.Parent == null)
						{
							// Map node
							mCatNewCat.Enabled = true;
							mCatNewSub.Enabled = false;
							mCatDelete.Enabled = false;
							mCatRename.Enabled = false;

							mCatDown.Enabled = false;
							mCatUp.Enabled = false;
						}
						else
						{
							mCatNewCat.Enabled = true;
							mCatNewSub.Enabled = true;
							mCatRename.Enabled = true;
							mCatDelete.Enabled = true;

							node = tCat.SelectedNode;

							if (node.NextNode != null)
								mCatDown.Enabled = true;
							else
								mCatDown.Enabled = false;

							if (node.PrevNode != null)
								mCatUp.Enabled = true;
							else
								mCatUp.Enabled = false;
						}
					}
				}

				CatMenu.Show(tCat, new Point(e.X, e.Y));
			}
		}

		/// <summary>
		///     Rename a category or subsection
		/// </summary>
		private void mCatRename_Click(object sender, EventArgs e)
		{
			tCat.LabelEdit = true;

			tCat.SelectedNode.BeginEdit();
		}

		/// <summary>
		///     End ranming of category or subsection
		/// </summary>
		private void tCat_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			var updated = false;

			if (e.Label != null || e.Label.Length > 0)
			{
				e.Node.Text = e.Label;
				updated = true;
			}

			tCat.LabelEdit = false;
			e.CancelEdit = true;

			if (updated)
			{
				UpdateMap();
			}
		}

		/// <summary>
		///     Delete a category or subsection
		/// </summary>
		private void mCatDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Travel.ConfirmDelCat"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				tCat.Nodes.Remove(tCat.SelectedNode);
				UpdateMap();
			}
		}

		/// <summary>
		///     Add a new category
		/// </summary>
		private void mCatNewCat_Click(object sender, EventArgs e)
		{
			var node = new TreeNode("NewCategory");

			if (Pandora.Profile.Travel.SelectedMapLocations)
			{
				tCat.Nodes.Add(node);
			}
			else
			{
				tCat.Nodes[GetMapIndex(m_Map)].Nodes.Add(node);
			}
		}

		/// <summary>
		///     Add a new subsection
		/// </summary>
		private void mCatNewSub_Click(object sender, EventArgs e)
		{
			var node = new TreeNode("NewSubsection");
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			node.Tag = new List<object>();

			if (tCat.SelectedNode.Tag != null && tCat.SelectedNode.Tag is List<object>)
				// Issue 10 - End
				tCat.SelectedNode.Parent.Nodes.Add(node);
			else
				tCat.SelectedNode.Nodes.Add(node);
		}

		/// <summary>
		///     Moves a node up one position in the tree. Assumes it is a valid move.
		/// </summary>
		private void mCatUp_Click(object sender, EventArgs e)
		{
			var node = tCat.SelectedNode;
			var parent = node.Parent;

			var index = 0;

			if (parent != null)
			{
				index = parent.Nodes.IndexOf(node);
				parent.Nodes.Remove(node);
				index--;
				parent.Nodes.Insert(index, node);
			}
			else
			{
				index = tCat.Nodes.IndexOf(node);
				tCat.Nodes.Remove(node);
				index--;
				tCat.Nodes.Insert(index, node);
			}

			tCat.SelectedNode = node;

			UpdateMap();
		}

		/// <summary>
		///     Moves a node down. Assumes the operation is valid.
		/// </summary>
		private void mCatDown_Click(object sender, EventArgs e)
		{
			var node = tCat.SelectedNode;
			var parent = node.Parent;

			var index = 0;

			if (parent != null)
			{
				index = parent.Nodes.IndexOf(node);
				parent.Nodes.Remove(node);
				index++;
				parent.Nodes.Insert(index, node);
			}
			else
			{
				index = tCat.Nodes.IndexOf(node);
				tCat.Nodes.Remove(node);
				index++;
				tCat.Nodes.Insert(index, node);
			}

			tCat.SelectedNode = node;

			UpdateMap();
		}
		#endregion

		/// <summary>
		///     OnLoad
		/// </summary>
		private void Travel_Load(object sender, EventArgs e)
		{
			try
			{
				Pandora.Localization.LocalizeMenu(CatMenu);
				Pandora.Localization.LocalizeMenu(LocMenu);

				if (Pandora.Profile.General.TravelSplitter > 0)
				{
					splitter.SplitPosition = Pandora.Profile.General.TravelSplitter;
				}

				chkSynch.Checked = Pandora.Profile.Travel.FollowClient;
				Pandora.Map.MouseDown += Map_MouseDown;
			}
			catch
			{
				// Avoid issues with VS
			}
		}

		/// <summary>
		///     Resets the display of maps according to the options
		/// </summary>
		public void ResetMaps()
		{
			// Enabled maps
			var index = 0;

			listMaps.Items.Clear();

			for (var i = 0; i < Pandora.Profile.Travel.MapCount; i++)
			{
				if (Pandora.Profile.Travel.EnabledMaps[i])
				{
					listMaps.Items.Add(Pandora.Profile.Travel.MapNames[i]);
					m_Maps[index++] = i;
				}
			}

			if (index == 0)
			{
				tCat.Nodes.Clear();
				tLoc.Nodes.Clear();

				return;
			}

			if (!Pandora.Profile.Travel.EnabledMaps[m_Map])
				m_Map = m_Maps[0];

			DoTree();
		}

		/// <summary>
		///     Splitter Changed
		/// </summary>
		private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			Pandora.Profile.General.TravelSplitter = splitter.SplitPosition;
		}

		private void bSetMap_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoSet("Map", Pandora.Profile.Travel.SelectedMapName, null);
		}

		/// <summary>
		///     Synchs the travel map with the client
		/// </summary>
		private void Synch()
		{
			try
			{
				Client.Calibrate();

				var x = 0;
				var y = 0;
				var z = 0;
				var map = -1;

				var found = Client.FindLocation(ref x, ref y, ref z, ref map);

				if (map != -1)
				{
					Pandora.Map.Map = (Maps)map;
					Pandora.Map.Center = new Point(x, y);
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.ToString());
			}
		}

		private void bSynch_Click(object sender, EventArgs e)
		{
			Synch();
		}

		private void tmr_Tick(object sender, EventArgs e)
		{
			if (Pandora.Profile != null)
			{
				if (Pandora.Profile.Travel.FollowClient)
					Synch();
			}
		}

		private void chkSynch_CheckedChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Travel.FollowClient = chkSynch.Checked;
		}

		private void Map_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				chkSynch.Checked = false;
		}
	}
}