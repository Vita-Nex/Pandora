#region Header
// /*
//  *    2018 - BoxEdit - TravelEditor.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Data;
using TheBox.MapViewer;

using Ultima;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Editors
{
	/// <summary>
	///     Summary description for TravelEditor.
	/// </summary>
	public class TravelEditor : Form
	{
		private bool m_Updated;
		private Facet m_Facet;
		private TreeNode m_FacetNode;

		private Location m_CurrentLocation;

		private Location CurrentLocation
		{
			get { return m_CurrentLocation; }
			set
			{
				m_CurrentLocation = value;

				if (value == null)
				{
					LocationControls(false);
					return;
				}
				LocationControls(true);

				nX.Value = value.X;
				nY.Value = value.Y;
				nZ.Value = value.Z;

				if (value.X != 0 || value.Y != 0)
					Map.Center = new Point(value.X, value.Y);

				m_CurrentLocation = value;
			}
		}

		private TreeView tCat;
		private TreeView tLoc;
		private TextBox txNewCat;
		private TextBox txNewLoc;
		private Button bAddCat;
		private Button bAddLoc;
		private Button bSetCoordinates;
		private NumericUpDown nX;
		private NumericUpDown nY;
		private NumericUpDown nZ;
		private Button bTest;
		private MenuItem menuItem5;
		private MapViewer.MapViewer Map;
		private Button bFromClient;
		private Button bCalibrate;
		private OpenFileDialog OpenFile;
		private SaveFileDialog SaveFile;
		private MenuItem mFile;
		private MenuItem miFileNew;
		private MenuItem miFileOpen;
		private MenuItem miFileSave;
		private MenuItem miFileExit;
		private MenuItem mMap;
		private MenuItem miMap0;
		private MenuItem miMap1;
		private MenuItem miMap2;
		private MenuItem miMap3;
		private MainMenu mMain;
		private ContextMenu cmMap;
		private MenuItem miZoomIn;
		private MenuItem miZoomOut;
		private MenuItem menuItem1;
		private MenuItem menuItem2;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public TravelEditor()
		{
			InitializeComponent();

			NewDocument();
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
			this.tCat = new System.Windows.Forms.TreeView();
			this.tLoc = new System.Windows.Forms.TreeView();
			this.txNewCat = new System.Windows.Forms.TextBox();
			this.txNewLoc = new System.Windows.Forms.TextBox();
			this.bAddCat = new System.Windows.Forms.Button();
			this.bAddLoc = new System.Windows.Forms.Button();
			this.bSetCoordinates = new System.Windows.Forms.Button();
			this.nX = new System.Windows.Forms.NumericUpDown();
			this.nY = new System.Windows.Forms.NumericUpDown();
			this.nZ = new System.Windows.Forms.NumericUpDown();
			this.bTest = new System.Windows.Forms.Button();
			this.mMain = new System.Windows.Forms.MainMenu();
			this.mFile = new System.Windows.Forms.MenuItem();
			this.miFileNew = new System.Windows.Forms.MenuItem();
			this.miFileOpen = new System.Windows.Forms.MenuItem();
			this.miFileSave = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miFileExit = new System.Windows.Forms.MenuItem();
			this.mMap = new System.Windows.Forms.MenuItem();
			this.miMap0 = new System.Windows.Forms.MenuItem();
			this.miMap1 = new System.Windows.Forms.MenuItem();
			this.miMap2 = new System.Windows.Forms.MenuItem();
			this.miMap3 = new System.Windows.Forms.MenuItem();
			this.Map = new TheBox.MapViewer.MapViewer();
			this.bFromClient = new System.Windows.Forms.Button();
			this.bCalibrate = new System.Windows.Forms.Button();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.cmMap = new System.Windows.Forms.ContextMenu();
			this.miZoomIn = new System.Windows.Forms.MenuItem();
			this.miZoomOut = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.nX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nZ)).BeginInit();
			this.SuspendLayout();
			// 
			// tCat
			// 
			this.tCat.ImageIndex = -1;
			this.tCat.LabelEdit = true;
			this.tCat.Location = new System.Drawing.Point(8, 8);
			this.tCat.Name = "tCat";
			this.tCat.SelectedImageIndex = -1;
			this.tCat.Size = new System.Drawing.Size(200, 336);
			this.tCat.Sorted = true;
			this.tCat.TabIndex = 0;
			this.tCat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tCat_KeyDown);
			this.tCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tCat_AfterSelect);
			this.tCat.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tCat_BeforeSelect);
			// 
			// tLoc
			// 
			this.tLoc.ImageIndex = -1;
			this.tLoc.LabelEdit = true;
			this.tLoc.Location = new System.Drawing.Point(216, 8);
			this.tLoc.Name = "tLoc";
			this.tLoc.SelectedImageIndex = -1;
			this.tLoc.Size = new System.Drawing.Size(200, 336);
			this.tLoc.Sorted = true;
			this.tLoc.TabIndex = 1;
			this.tLoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tLoc_KeyDown);
			this.tLoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tLoc_AfterSelect);
			this.tLoc.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tLoc_BeforeSelect);
			this.tLoc.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tLoc_AfterLabelEdit);
			// 
			// txNewCat
			// 
			this.txNewCat.Location = new System.Drawing.Point(8, 352);
			this.txNewCat.Name = "txNewCat";
			this.txNewCat.Size = new System.Drawing.Size(136, 20);
			this.txNewCat.TabIndex = 3;
			this.txNewCat.Text = "";
			this.txNewCat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txNewCat_KeyDown);
			// 
			// txNewLoc
			// 
			this.txNewLoc.Enabled = false;
			this.txNewLoc.Location = new System.Drawing.Point(216, 352);
			this.txNewLoc.Name = "txNewLoc";
			this.txNewLoc.Size = new System.Drawing.Size(136, 20);
			this.txNewLoc.TabIndex = 4;
			this.txNewLoc.Text = "";
			this.txNewLoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txNewLoc_KeyDown);
			// 
			// bAddCat
			// 
			this.bAddCat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAddCat.Location = new System.Drawing.Point(152, 352);
			this.bAddCat.Name = "bAddCat";
			this.bAddCat.Size = new System.Drawing.Size(56, 23);
			this.bAddCat.TabIndex = 5;
			this.bAddCat.Text = "Add";
			this.bAddCat.Click += new System.EventHandler(this.bAddCat_Click);
			// 
			// bAddLoc
			// 
			this.bAddLoc.Enabled = false;
			this.bAddLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAddLoc.Location = new System.Drawing.Point(360, 352);
			this.bAddLoc.Name = "bAddLoc";
			this.bAddLoc.Size = new System.Drawing.Size(56, 23);
			this.bAddLoc.TabIndex = 6;
			this.bAddLoc.Text = "Add";
			this.bAddLoc.Click += new System.EventHandler(this.bAddLoc_Click);
			// 
			// bSetCoordinates
			// 
			this.bSetCoordinates.Enabled = false;
			this.bSetCoordinates.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSetCoordinates.Location = new System.Drawing.Point(424, 328);
			this.bSetCoordinates.Name = "bSetCoordinates";
			this.bSetCoordinates.Size = new System.Drawing.Size(288, 23);
			this.bSetCoordinates.TabIndex = 7;
			this.bSetCoordinates.Text = "Set as value for the current location";
			this.bSetCoordinates.Click += new System.EventHandler(this.bSetCoordinates_Click);
			// 
			// nX
			// 
			this.nX.Enabled = false;
			this.nX.Location = new System.Drawing.Point(504, 8);
			this.nX.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.nX.Name = "nX";
			this.nX.Size = new System.Drawing.Size(64, 20);
			this.nX.TabIndex = 8;
			this.nX.ValueChanged += new System.EventHandler(this.nX_ValueChanged);
			// 
			// nY
			// 
			this.nY.Enabled = false;
			this.nY.Location = new System.Drawing.Point(576, 8);
			this.nY.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.nY.Name = "nY";
			this.nY.Size = new System.Drawing.Size(64, 20);
			this.nY.TabIndex = 9;
			this.nY.ValueChanged += new System.EventHandler(this.nY_ValueChanged);
			// 
			// nZ
			// 
			this.nZ.Enabled = false;
			this.nZ.Location = new System.Drawing.Point(648, 8);
			this.nZ.Maximum = new System.Decimal(new int[] {128, 0, 0, 0});
			this.nZ.Minimum = new System.Decimal(new int[] {128, 0, 0, -2147483648});
			this.nZ.Name = "nZ";
			this.nZ.Size = new System.Drawing.Size(64, 20);
			this.nZ.TabIndex = 10;
			this.nZ.ValueChanged += new System.EventHandler(this.nZ_ValueChanged);
			// 
			// bTest
			// 
			this.bTest.Enabled = false;
			this.bTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTest.Location = new System.Drawing.Point(424, 8);
			this.bTest.Name = "bTest";
			this.bTest.Size = new System.Drawing.Size(72, 23);
			this.bTest.TabIndex = 11;
			this.bTest.Text = "Test";
			this.bTest.Click += new System.EventHandler(this.bTest_Click);
			// 
			// mMain
			// 
			this.mMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mFile, this.mMap});
			// 
			// mFile
			// 
			this.mFile.Index = 0;
			this.mFile.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[]
					{this.miFileNew, this.miFileOpen, this.miFileSave, this.menuItem5, this.miFileExit});
			this.mFile.Text = "&File";
			// 
			// miFileNew
			// 
			this.miFileNew.Index = 0;
			this.miFileNew.Text = "&New";
			this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
			// 
			// miFileOpen
			// 
			this.miFileOpen.Index = 1;
			this.miFileOpen.Text = "&Open";
			this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
			// 
			// miFileSave
			// 
			this.miFileSave.Index = 2;
			this.miFileSave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem1, this.menuItem2});
			this.miFileSave.Text = "&Save";
			this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// miFileExit
			// 
			this.miFileExit.Index = 4;
			this.miFileExit.Text = "E&xit";
			// 
			// mMap
			// 
			this.mMap.Index = 1;
			this.mMap.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[] {this.miMap0, this.miMap1, this.miMap2, this.miMap3});
			this.mMap.Text = "&Map";
			this.mMap.Popup += new System.EventHandler(this.mMap_Popup);
			// 
			// miMap0
			// 
			this.miMap0.Index = 0;
			this.miMap0.Text = "&0";
			this.miMap0.Click += new System.EventHandler(this.SelectMap);
			// 
			// miMap1
			// 
			this.miMap1.Index = 1;
			this.miMap1.Text = "&1";
			this.miMap1.Click += new System.EventHandler(this.SelectMap);
			// 
			// miMap2
			// 
			this.miMap2.Index = 2;
			this.miMap2.Text = "&2";
			this.miMap2.Click += new System.EventHandler(this.SelectMap);
			// 
			// miMap3
			// 
			this.miMap3.Index = 3;
			this.miMap3.Text = "&3";
			this.miMap3.Click += new System.EventHandler(this.SelectMap);
			// 
			// Map
			// 
			this.Map.Center = new System.Drawing.Point(0, 0);
			this.Map.DisplayErrors = true;
			this.Map.DrawStatics = true;
			this.Map.Location = new System.Drawing.Point(424, 40);
			this.Map.Map = TheBox.MapViewer.Maps.Felucca;
			this.Map.Name = "Map";
			this.Map.ShowCross = false;
			this.Map.Size = new System.Drawing.Size(288, 280);
			this.Map.TabIndex = 12;
			this.Map.Text = "mapViewer1";
			this.Map.ZoomLevel = 0;
			this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
			// 
			// bFromClient
			// 
			this.bFromClient.Enabled = false;
			this.bFromClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bFromClient.Location = new System.Drawing.Point(424, 352);
			this.bFromClient.Name = "bFromClient";
			this.bFromClient.Size = new System.Drawing.Size(192, 23);
			this.bFromClient.TabIndex = 13;
			this.bFromClient.Text = "Get coordinates from client";
			this.bFromClient.Click += new System.EventHandler(this.bFromClient_Click);
			// 
			// bCalibrate
			// 
			this.bCalibrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCalibrate.Location = new System.Drawing.Point(616, 352);
			this.bCalibrate.Name = "bCalibrate";
			this.bCalibrate.Size = new System.Drawing.Size(96, 23);
			this.bCalibrate.TabIndex = 14;
			this.bCalibrate.Text = "Calibrate";
			this.bCalibrate.Click += new System.EventHandler(this.bCalibrate_Click);
			// 
			// OpenFile
			// 
			this.OpenFile.Filter = "Xml Files (*.xml)|*.xml";
			// 
			// SaveFile
			// 
			this.SaveFile.Filter = "Xml Files (*.xml)|*.xml";
			// 
			// cmMap
			// 
			this.cmMap.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.miZoomIn, this.miZoomOut});
			// 
			// miZoomIn
			// 
			this.miZoomIn.Index = 0;
			this.miZoomIn.Text = "Zoom In";
			this.miZoomIn.Click += new System.EventHandler(this.miZoomIn_Click);
			// 
			// miZoomOut
			// 
			this.miZoomOut.Index = 1;
			this.miZoomOut.Text = "Zoom Out";
			this.miZoomOut.Click += new System.EventHandler(this.miZoomOut_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Pandora\'s Box 1";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Pandora\'s Box 2";
			// 
			// TravelEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 381);
			this.Controls.Add(this.bCalibrate);
			this.Controls.Add(this.bFromClient);
			this.Controls.Add(this.Map);
			this.Controls.Add(this.bTest);
			this.Controls.Add(this.nZ);
			this.Controls.Add(this.nY);
			this.Controls.Add(this.nX);
			this.Controls.Add(this.bSetCoordinates);
			this.Controls.Add(this.bAddLoc);
			this.Controls.Add(this.bAddCat);
			this.Controls.Add(this.txNewLoc);
			this.Controls.Add(this.txNewCat);
			this.Controls.Add(this.tLoc);
			this.Controls.Add(this.tCat);
			this.Menu = this.mMain;
			this.Name = "TravelEditor";
			this.Text = "Travel Editor";
			((System.ComponentModel.ISupportInitialize)(this.nX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nZ)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void Map_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				cmMap.Show((Control)sender, new Point(e.X, e.Y));
			}
			else
			{
				Map.Center = Map.ControlToMap(new Point(e.X, e.Y));
			}
		}

		private void NewDocument()
		{
			tCat.Nodes.Clear();
			tLoc.Nodes.Clear();
			Map.Map = Maps.Felucca;

			m_Facet = new Facet();
			m_Facet.MapValue = 0;

			m_FacetNode = new TreeNode("Facet");
			tCat.Nodes.Add(m_FacetNode);

			LocationControls(false);
		}

		private void LocationControls(bool selected)
		{
			bTest.Enabled = selected;
			nX.Enabled = selected;
			nY.Enabled = selected;
			nZ.Enabled = selected;
			bSetCoordinates.Enabled = selected;
			bFromClient.Enabled = selected;
		}

		private void NewLocationControls(bool enabled)
		{
			txNewLoc.Enabled = enabled;
			bAddLoc.Enabled = enabled;
		}

		private void mMap_Popup(object sender, EventArgs e)
		{
			miMap0.Checked = false;
			miMap1.Checked = false;
			miMap2.Checked = false;
			miMap3.Checked = false;

			switch (Map.Map)
			{
				case Maps.Felucca:

					miMap0.Checked = true;
					break;

				case Maps.Trammel:

					miMap1.Checked = true;
					break;

				case Maps.Ilshenar:

					miMap2.Checked = true;
					break;

				case Maps.Malas:

					miMap3.Checked = true;
					break;
			}
		}

		private void SelectMap(object sender, EventArgs e)
		{
			if ((MenuItem)sender == miMap0)
			{
				m_Facet.MapValue = 0;
			}
			else if ((MenuItem)sender == miMap1)
			{
				m_Facet.MapValue = 1;
			}
			else if ((MenuItem)sender == miMap2)
			{
				m_Facet.MapValue = 2;
			}
			else if ((MenuItem)sender == miMap3)
			{
				m_Facet.MapValue = 3;
			}

			Map.Map = (Maps)m_Facet.MapValue;
		}

		private void miZoomIn_Click(object sender, EventArgs e)
		{
			Map.ZoomIn();
		}

		private void miZoomOut_Click(object sender, EventArgs e)
		{
			Map.ZoomOut();
		}

		private void bCalibrate_Click(object sender, EventArgs e)
		{
			Client.Calibrate();
		}

		private bool CheckForDuplicates(TreeNodeCollection nodes, string text)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Text.ToLower() == text.ToLower())
					return true;
			}

			return false;
		}

		private void bAddCat_Click(object sender, EventArgs e)
		{
			var newSection = txNewCat.Text;

			if (newSection.Length == 0)
			{
				MessageBox.Show("You can't create an empty category");
				return;
			}

			var currentNode = tCat.SelectedNode;

			if ((currentNode.Parent != null) && (currentNode.Parent != m_FacetNode) && (currentNode.Parent.Parent != null))
			{
				MessageBox.Show("No further subsections are allowed");
				return;
			}

			if (CheckForDuplicates(currentNode.Nodes, newSection))
			{
				MessageBox.Show(string.Format("An entry called {0} already exists.", newSection));
				return;
			}

			var tNode = new TreeNode(newSection);

			if (currentNode.Parent != null && currentNode.Parent == m_FacetNode)
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				tNode.Tag = new List<object>();
			// Issue 10 - End

			currentNode.Nodes.Add(tNode);

			tCat.SelectedNode = tNode.Parent;

			txNewCat.Text = "";
			txNewCat.Focus();

			m_Updated = true;
		}

		private void tCat_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (tCat.SelectedNode != null)
			{
				tCat.SelectedNode.BackColor = SystemColors.Window;
				tCat.SelectedNode.ForeColor = SystemColors.WindowText;
			}
		}

		private void tCat_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tCat.SelectedNode.BackColor = SystemColors.Highlight;
			tCat.SelectedNode.ForeColor = SystemColors.HighlightText;

			if (tCat.SelectedNode.Parent != null && tCat.SelectedNode.Parent != m_FacetNode)
			{
				NewLocationControls(true);

				tLoc.BeginUpdate();
				tLoc.Nodes.Clear();
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				tLoc.Nodes.AddRange(Data.Location.ArrayToNodes((List<object>)tCat.SelectedNode.Tag));
				// Issue 10 - End
				tLoc.EndUpdate();

				if (tLoc.Nodes.Count > 0)
				{
					tLoc.SelectedNode = tLoc.Nodes[0];
					CurrentLocation = tLoc.SelectedNode.Tag as Location;
					LocationControls(true);
				}
				else
				{
					LocationControls(false);
				}
			}
			else
			{
				tLoc.Nodes.Clear();

				NewLocationControls(false);

				LocationControls(false);
			}
		}

		private void bAddLoc_Click(object sender, EventArgs e)
		{
			var name = txNewLoc.Text;

			if (name.Length == 0)
			{
				MessageBox.Show("Please enter a name for the new location");
				return;
			}

			if (CheckForDuplicates(tLoc.Nodes, name))
			{
				MessageBox.Show(string.Format("A location called {0} already exists", name));
				return;
			}

			var loc = new Location();
			loc.Name = name;

			var tNode = new TreeNode(name);
			tNode.Tag = loc;

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			((List<object>)tCat.SelectedNode.Tag).Add(loc);
			// Issue 10 - End

			tLoc.Nodes.Add(tNode);

			tLoc.SelectedNode = tNode;

			txNewLoc.Text = "";
			txNewLoc.Focus();

			m_Updated = true;
		}

		private void tLoc_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (tLoc.SelectedNode != null)
			{
				tLoc.SelectedNode.BackColor = SystemColors.Window;
				tLoc.SelectedNode.ForeColor = SystemColors.WindowText;
			}
		}

		private void tLoc_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tLoc.SelectedNode.BackColor = SystemColors.Highlight;
			tLoc.SelectedNode.ForeColor = SystemColors.HighlightText;

			CurrentLocation = tLoc.SelectedNode.Tag as Location;
		}

		private void bTest_Click(object sender, EventArgs e)
		{
			Utility.SendToUO(string.Format("[Go {0} {1} {2}\n", CurrentLocation.X, CurrentLocation.Y, CurrentLocation.Z));
		}

		private void bSetCoordinates_Click(object sender, EventArgs e)
		{
			CurrentLocation.X = (short)Map.Center.X;
			CurrentLocation.Y = (short)Map.Center.Y;
			CurrentLocation.Z = (sbyte)Map.GetMapHeight(Map.Center);

			SynchData();
		}

		private void SaveAs(string FileName)
		{
			m_Facet = Facet.FromTreeNodes(m_FacetNode.Nodes, (byte)Map.Map);

			try
			{
				var serializer = new XmlSerializer(typeof(Facet));
				var stream = new FileStream(FileName, FileMode.Create);
				serializer.Serialize(stream, m_Facet);
				stream.Close();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.ToString());
			}
		}

		private void miFileSave_Click(object sender, EventArgs e)
		{
			if (SaveFile.ShowDialog() == DialogResult.OK)
			{
				SaveAs(SaveFile.FileName);
			}
		}

		private void LoadFile(string FileName)
		{
			var serializer = new XmlSerializer(typeof(Facet));
			var stream = new FileStream(FileName, FileMode.Open);
			m_Facet = (Facet)serializer.Deserialize(stream);
			stream.Close();

			tCat.BeginUpdate();
			tCat.Nodes.Clear();

			m_FacetNode = m_Facet.GetTreeNode("Facet");

			tCat.Nodes.Add(m_FacetNode);
			tCat.SelectedNode = m_FacetNode;

			tCat.EndUpdate();
		}

		private void miFileOpen_Click(object sender, EventArgs e)
		{
			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				LoadFile(OpenFile.FileName);
			}
		}

		private void bFromClient_Click(object sender, EventArgs e)
		{
			var x = 0;
			var y = 0;
			var z = 0;
			var facet = 0;

			Client.FindLocation(ref x, ref y, ref z, ref facet);

			if (x != 0 || y != 0 || z != 0)
			{
				CurrentLocation.X = (short)x;
				CurrentLocation.Y = (short)y;
				CurrentLocation.Z = (sbyte)z;

				Map.Center = new Point(x, y);

				SynchData();

				txNewLoc.Focus();
			}
			else
			{
				MessageBox.Show("Please calibrate your client. If you're at 0,0,0 this method won't work");
			}
		}

		private void SynchData()
		{
			nX.Value = CurrentLocation.X;
			nY.Value = CurrentLocation.Y;
			nZ.Value = CurrentLocation.Z;
		}

		private void nX_ValueChanged(object sender, EventArgs e)
		{
			CurrentLocation.X = (short)nX.Value;

			Map.Center = new Point(CurrentLocation.X, CurrentLocation.Y);
		}

		private void nY_ValueChanged(object sender, EventArgs e)
		{
			CurrentLocation.Y = (short)nY.Value;

			Map.Center = new Point(CurrentLocation.X, CurrentLocation.Y);
		}

		private void nZ_ValueChanged(object sender, EventArgs e)
		{
			CurrentLocation.Z = (sbyte)nZ.Value;
		}

		private void tCat_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					if (tCat.SelectedNode != null)
					{
						if (tCat.SelectedNode == m_FacetNode)
						{
							MessageBox.Show("You can't delete the facet node");
						}
						else
						{
							tCat.Nodes.Remove(tCat.SelectedNode);
							m_Updated = true;
						}
					}
					break;

				case Keys.F2:
					if (tCat.SelectedNode != null && tCat.SelectedNode != m_FacetNode)
					{
						tCat.SelectedNode.BeginEdit();
					}
					break;
			}
		}

		private void tLoc_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Label.Length == 0)
			{
				e.CancelEdit = true;
			}
			else
			{
				((Location)e.Node.Tag).Name = e.Label;
				e.CancelEdit = false;
				m_Updated = true;
			}
		}

		private void tLoc_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F12:

					if (tLoc.SelectedNode != null)
					{
						tLoc.SelectedNode.BeginEdit();
					}
					break;

				case Keys.Delete:

					if (tLoc.SelectedNode != null)
					{
						var loc = tLoc.SelectedNode.Tag as Location;
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						((List<object>)tCat.SelectedNode.Tag).Remove(loc);
						// Issue 10 - End

						tLoc.Nodes.Remove(tLoc.SelectedNode);

						m_Updated = true;
					}

					break;
			}
		}

		private void txNewCat_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				bAddCat.PerformClick();
			}
		}

		private void txNewLoc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				bAddLoc.PerformClick();
			}
		}

		private void miFileNew_Click(object sender, EventArgs e)
		{
			if (m_Updated)
			{
				if (MessageBox.Show(
						this,
						"The current document hasn't been saved. If you create a new document you will loose all the current data.\n\nAre you sure you wish to proceed?",
						"",
						MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			m_Updated = false;
		}
	}
}