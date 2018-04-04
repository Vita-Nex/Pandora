#region Header
// /*
//  *    2018 - Pandora - Props.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Controls;
using TheBox.Data;
using TheBox.Forms;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Props.
	/// </summary>
	public class Props : UserControl
	{
		private TreeView tProps;
		private TreeView tClasses;
		private ComboBox cmbFilter;
		private CheckBox chkAllClasses;
		private CheckBox chkAllProps;
		private Button bFind;
		private ComboBox cmbSearch;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private GroupBox grpProp;
		private TimeSpanControl cTimeSpan;

		#region Variables
		/// <summary>
		///     Specifies when the options are being applied to the page
		/// </summary>
		private bool m_ApplyingOptions;

		/// <summary>
		///     The property currently selected
		/// </summary>
		private BoxProp m_SelectedProperty;

		private Label labMsg;
		private BooleanControl cBoolean;
		private DateTimeControl cDateTime;
		private Point3DControl cPoint3D;
		private EnumControl cEnum;
		private TextBox txGet;
		private TextBox txSet;
		private Panel panel1;
		private Splitter splitter;

		/// <summary>
		///     The control currently displayed
		/// </summary>
		private Control m_VisibleControl;
		#endregion

		public Props()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		///     Gets or sets the control that should be visible
		/// </summary>
		private Control VisibleControl
		{
			get { return m_VisibleControl; }
			set
			{
				if (m_VisibleControl != null)
				{
					m_VisibleControl.Visible = false;
				}

				m_VisibleControl = value;

				if (m_VisibleControl != null)
				{
					m_VisibleControl.Visible = true;
				}
			}
		}

		/// <summary>
		///     Gets or sets the property currently selected
		/// </summary>
		public BoxProp SelectedProperty
		{
			get { return m_SelectedProperty; }
			set
			{
				m_SelectedProperty = value;

				if (value != null)
				{
					Pandora.Prop.DisplayedProp = value.Name;
					grpProp.Text = value.Name;

					txGet.ForeColor = value.CanGet ? Color.Black : Color.White;
					txSet.ForeColor = value.CanSet ? Color.Black : Color.White;

					switch (value.ValueType)
					{
						case BoxPropType.TimeSpan:

							VisibleControl = cTimeSpan;
							break;

						case BoxPropType.Numeric:

							VisibleControl = labMsg;
							labMsg.Text = Pandora.Localization.TextProvider["Props.Numeric"];
							break;

						case BoxPropType.Other:

							VisibleControl = labMsg;
							labMsg.Text = Pandora.Localization.TextProvider["Props.Other"];
							break;

						case BoxPropType.Text:

							VisibleControl = labMsg;
							labMsg.Text = Pandora.Localization.TextProvider["Props.Text"];
							break;

						case BoxPropType.Boolean:

							VisibleControl = cBoolean;
							break;

						case BoxPropType.DateTime:

							VisibleControl = cDateTime;
							break;

						case BoxPropType.Point3D:

							VisibleControl = cPoint3D;
							break;

						case BoxPropType.Enumeration:

							VisibleControl = cEnum;
							cEnum.DisplayedEnum = PropsData.Props.FindEnum(value.EnumName);
							break;
					}
				}
				else
				{
					grpProp.Text = "";
					VisibleControl = null;
					txGet.ForeColor = Color.White;
					txSet.ForeColor = Color.White;
				}
			}
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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tProps = new System.Windows.Forms.TreeView();
			this.tClasses = new System.Windows.Forms.TreeView();
			this.cmbFilter = new System.Windows.Forms.ComboBox();
			this.chkAllClasses = new System.Windows.Forms.CheckBox();
			this.chkAllProps = new System.Windows.Forms.CheckBox();
			this.bFind = new System.Windows.Forms.Button();
			this.cmbSearch = new System.Windows.Forms.ComboBox();
			this.grpProp = new System.Windows.Forms.GroupBox();
			this.cEnum = new TheBox.Controls.EnumControl();
			this.cPoint3D = new TheBox.Controls.Point3DControl();
			this.cDateTime = new TheBox.Controls.DateTimeControl();
			this.cTimeSpan = new TheBox.Controls.TimeSpanControl();
			this.labMsg = new System.Windows.Forms.Label();
			this.cBoolean = new TheBox.Controls.BooleanControl();
			this.txGet = new System.Windows.Forms.TextBox();
			this.txSet = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter = new System.Windows.Forms.Splitter();
			this.grpProp.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tProps
			// 
			this.tProps.AllowDrop = true;
			this.tProps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tProps.HideSelection = false;
			this.tProps.ImageIndex = -1;
			this.tProps.Location = new System.Drawing.Point(0, 0);
			this.tProps.Name = "tProps";
			this.tProps.SelectedImageIndex = -1;
			this.tProps.ShowLines = false;
			this.tProps.ShowPlusMinus = false;
			this.tProps.ShowRootLines = false;
			this.tProps.Size = new System.Drawing.Size(276, 140);
			this.tProps.Sorted = true;
			this.tProps.TabIndex = 0;
			this.tProps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tClasses_MouseDown);
			this.tProps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tProps_AfterSelect);
			// 
			// tClasses
			// 
			this.tClasses.AllowDrop = true;
			this.tClasses.Dock = System.Windows.Forms.DockStyle.Left;
			this.tClasses.HideSelection = false;
			this.tClasses.ImageIndex = -1;
			this.tClasses.Indent = 15;
			this.tClasses.Location = new System.Drawing.Point(0, 0);
			this.tClasses.Name = "tClasses";
			this.tClasses.SelectedImageIndex = -1;
			this.tClasses.Size = new System.Drawing.Size(160, 140);
			this.tClasses.Sorted = true;
			this.tClasses.TabIndex = 1;
			this.tClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tClasses_MouseDown);
			this.tClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tClasses_AfterSelect);
			// 
			// cmbFilter
			// 
			this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFilter.Items.AddRange(new object[] {"Administrator", "Seer", "GameMaster", "Councelor"});
			this.cmbFilter.Location = new System.Drawing.Point(4, 28);
			this.cmbFilter.Name = "cmbFilter";
			this.cmbFilter.Size = new System.Drawing.Size(92, 21);
			this.cmbFilter.TabIndex = 2;
			this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
			// 
			// chkAllClasses
			// 
			this.chkAllClasses.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAllClasses.Location = new System.Drawing.Point(4, 52);
			this.chkAllClasses.Name = "chkAllClasses";
			this.chkAllClasses.Size = new System.Drawing.Size(96, 20);
			this.chkAllClasses.TabIndex = 3;
			this.chkAllClasses.Text = "Props.AllClasses";
			this.chkAllClasses.CheckedChanged += new System.EventHandler(this.chkAllClasses_CheckedChanged);
			// 
			// chkAllProps
			// 
			this.chkAllProps.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAllProps.Location = new System.Drawing.Point(4, 72);
			this.chkAllProps.Name = "chkAllProps";
			this.chkAllProps.Size = new System.Drawing.Size(96, 20);
			this.chkAllProps.TabIndex = 4;
			this.chkAllProps.Text = "Props.AllProps";
			this.chkAllProps.CheckedChanged += new System.EventHandler(this.chkAllProps_CheckedChanged);
			// 
			// bFind
			// 
			this.bFind.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bFind.Location = new System.Drawing.Point(16, 116);
			this.bFind.Name = "bFind";
			this.bFind.Size = new System.Drawing.Size(68, 23);
			this.bFind.TabIndex = 6;
			this.bFind.Text = "Common.Find";
			this.bFind.Click += new System.EventHandler(this.bFind_Click);
			// 
			// cmbSearch
			// 
			this.cmbSearch.Location = new System.Drawing.Point(4, 92);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(92, 21);
			this.cmbSearch.TabIndex = 7;
			this.cmbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSearch_KeyDown);
			// 
			// grpProp
			// 
			this.grpProp.Controls.Add(this.cEnum);
			this.grpProp.Controls.Add(this.cPoint3D);
			this.grpProp.Controls.Add(this.cDateTime);
			this.grpProp.Controls.Add(this.cTimeSpan);
			this.grpProp.Controls.Add(this.labMsg);
			this.grpProp.Controls.Add(this.cBoolean);
			this.grpProp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpProp.Location = new System.Drawing.Point(380, 4);
			this.grpProp.Name = "grpProp";
			this.grpProp.Size = new System.Drawing.Size(112, 136);
			this.grpProp.TabIndex = 8;
			this.grpProp.TabStop = false;
			// 
			// cEnum
			// 
			this.cEnum.Location = new System.Drawing.Point(4, 16);
			this.cEnum.Name = "cEnum";
			this.cEnum.Size = new System.Drawing.Size(104, 116);
			this.cEnum.TabIndex = 5;
			this.cEnum.Visible = false;
			// 
			// cPoint3D
			// 
			this.cPoint3D.Location = new System.Drawing.Point(4, 16);
			this.cPoint3D.Name = "cPoint3D";
			this.cPoint3D.Size = new System.Drawing.Size(104, 116);
			this.cPoint3D.TabIndex = 4;
			this.cPoint3D.Visible = false;
			// 
			// cDateTime
			// 
			this.cDateTime.Location = new System.Drawing.Point(4, 16);
			this.cDateTime.Name = "cDateTime";
			this.cDateTime.Size = new System.Drawing.Size(104, 116);
			this.cDateTime.TabIndex = 3;
			this.cDateTime.Visible = false;
			// 
			// cTimeSpan
			// 
			this.cTimeSpan.Location = new System.Drawing.Point(4, 16);
			this.cTimeSpan.Name = "cTimeSpan";
			this.cTimeSpan.Size = new System.Drawing.Size(104, 116);
			this.cTimeSpan.TabIndex = 0;
			this.cTimeSpan.Visible = false;
			// 
			// labMsg
			// 
			this.labMsg.Location = new System.Drawing.Point(4, 16);
			this.labMsg.Name = "labMsg";
			this.labMsg.Size = new System.Drawing.Size(104, 116);
			this.labMsg.TabIndex = 1;
			this.labMsg.Text = "label1";
			this.labMsg.Visible = false;
			// 
			// cBoolean
			// 
			this.cBoolean.Location = new System.Drawing.Point(4, 16);
			this.cBoolean.Name = "cBoolean";
			this.cBoolean.Size = new System.Drawing.Size(104, 116);
			this.cBoolean.TabIndex = 2;
			this.cBoolean.Visible = false;
			// 
			// txGet
			// 
			this.txGet.BackColor = System.Drawing.Color.White;
			this.txGet.ForeColor = System.Drawing.Color.White;
			this.txGet.Location = new System.Drawing.Point(4, 4);
			this.txGet.Name = "txGet";
			this.txGet.ReadOnly = true;
			this.txGet.Size = new System.Drawing.Size(44, 20);
			this.txGet.TabIndex = 9;
			this.txGet.Text = "Props.Get";
			this.txGet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txSet
			// 
			this.txSet.BackColor = System.Drawing.Color.White;
			this.txSet.ForeColor = System.Drawing.Color.White;
			this.txSet.Location = new System.Drawing.Point(52, 4);
			this.txSet.Name = "txSet";
			this.txSet.ReadOnly = true;
			this.txSet.Size = new System.Drawing.Size(44, 20);
			this.txSet.TabIndex = 10;
			this.txSet.Text = "Props.Set";
			this.txSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tProps);
			this.panel1.Controls.Add(this.splitter);
			this.panel1.Controls.Add(this.tClasses);
			this.panel1.Location = new System.Drawing.Point(100, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(276, 140);
			this.panel1.TabIndex = 11;
			// 
			// splitter
			// 
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter.Location = new System.Drawing.Point(160, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(3, 140);
			this.splitter.TabIndex = 2;
			this.splitter.TabStop = false;
			this.splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoved);
			// 
			// Props
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.txSet);
			this.Controls.Add(this.txGet);
			this.Controls.Add(this.grpProp);
			this.Controls.Add(this.cmbSearch);
			this.Controls.Add(this.bFind);
			this.Controls.Add(this.chkAllProps);
			this.Controls.Add(this.chkAllClasses);
			this.Controls.Add(this.cmbFilter);
			this.Name = "Props";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Props_Load);
			this.grpProp.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     OnLoad : Set all the options
		/// </summary>
		private void Props_Load(object sender, EventArgs e)
		{
			try
			{
				if (Pandora.Profile.General.PropsSplitter > 0)
				{
					splitter.SplitPosition = Pandora.Profile.General.PropsSplitter;
				}

				m_ApplyingOptions = true;

				chkAllProps.Checked = Pandora.Profile.Props.ShowAllProps;
				chkAllClasses.Checked = Pandora.Profile.Props.ShowAllTypes;

				cmbFilter.SelectedItem = Pandora.Profile.Props.Filter.ToString();
				cmbSearch.Items.AddRange(Pandora.Profile.Props.RecentClasses.GetArray());

				// Load properties
				RefreshTrees();

				RefreshSearches();

				m_ApplyingOptions = false;

				PropsData.PropsChanged += PropsData_PropsChanged;
			}
			catch
			{ }
		}

		/// <summary>
		///     User has clicked a class, display properties
		/// </summary>
		private void tClasses_AfterSelect(object sender, TreeViewEventArgs e)
		{
			RefreshPropsTree();
			SelectedProperty = null;
		}

		#region Trees Creation
		/// <summary>
		///     Gets the TreeNodes representing the properties for a given type on the classes tree
		/// </summary>
		/// <param name="cNode">The TreeNode on the classes tree currently selected</param>
		/// <returns>An array of TreeNode objects representing the properties for the currently selected class</returns>
		private TreeNode[] GetPropNodes(TreeNode cNode)
		{
			if (cNode == null)
			{
				return new TreeNode[0];
			}

			if (Pandora.Profile.Props.ShowAllProps)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var nodes = new List<TreeNode>();
				// Issue 10 - End

				nodes.AddRange(GetDeclaredProps(cNode));

				var parent = cNode.Parent;

				while (parent != null)
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					var newNodes = new List<TreeNode>(GetDeclaredProps(parent));
					// Issue 10 - End
					RemoveDuplicates(newNodes, nodes);

					if (newNodes.Count > 0)
					{
						nodes.AddRange(newNodes);
					}

					parent = parent.Parent;
				}

				var tNodes = new TreeNode[nodes.Count];
				nodes.CopyTo(0, tNodes, 0, nodes.Count);

				return tNodes;
			}
			return GetDeclaredProps(cNode);
		}

		/// <summary>
		///     Removes the duplicates in a List of TreeNode
		/// </summary>
		/// <param name="from">The List from which the duplicates should be removed</param>
		/// <param name="existing">The List the should be used as comparison</param>
		/// // Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private void RemoveDuplicates(List<TreeNode> from, List<TreeNode> existing)
			// Issue 10 - End
		{
			foreach (var n in existing)
			{
				var found = NodeExists(n.Text, from);

				if (found != null)
				{
					from.Remove(found);
				}
			}
		}

		/// <summary>
		///     Verifies if a treenode with a given text exists in an array list of treenodes
		/// </summary>
		/// <param name="text">The text to search for</param>
		/// <param name="nodes">The collection of nodes to search</param>
		/// <returns>The TreeNode if found, null otherwise</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private TreeNode NodeExists(string text, List<TreeNode> nodes)
			// Issue 10 - End
		{
			foreach (var node in nodes)
			{
				if (node.Text == text)
				{
					return node;
				}
			}

			return null;
		}

		/// <summary>
		///     Gets the declared props for a class
		/// </summary>
		/// <param name="cNode">The TreeNode for the class</param>
		/// <returns>An array of TreeNodes</returns>
		private TreeNode[] GetDeclaredProps(TreeNode cNode)
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			var props = cNode.Tag as List<object>;

			var nodes = new List<TreeNode>();
			// Issue 10 - End

			foreach (BoxProp p in props)
			{
				if (p.SetAccess <= Pandora.Profile.Props.Filter)
				{
					var n = new TreeNode(p.Name);
					n.Tag = p;

					nodes.Add(n);
				}
			}

			var tNodes = new TreeNode[nodes.Count];
			nodes.CopyTo(tNodes);

			return tNodes;
		}
		#endregion

		/// <summary>
		///     Refresh both treenodes
		/// </summary>
		private void RefreshTrees()
		{
			tClasses.BeginUpdate();
			tProps.BeginUpdate();

			tClasses.Nodes.Clear();
			tProps.Nodes.Clear();

			tClasses.Nodes.AddRange(PropsData.Props.TreeNodes);

			tClasses.EndUpdate();
			tProps.EndUpdate();
		}

		/// <summary>
		///     Refreshes the properties displayed
		/// </summary>
		private void RefreshPropsTree()
		{
			tProps.BeginUpdate();
			tProps.Nodes.Clear();

			if (tClasses.SelectedNode != null)
			{
				tProps.Nodes.AddRange(GetPropNodes(tClasses.SelectedNode));
			}

			tProps.EndUpdate();
		}

		#region Options
		/// <summary>
		///     Refreshes the combo box used to search
		/// </summary>
		private void RefreshSearches()
		{
			cmbSearch.BeginUpdate();
			cmbSearch.Items.Clear();

			cmbSearch.Items.AddRange(Pandora.Profile.Props.RecentClasses.GetArray());

			cmbSearch.EndUpdate();
		}

		/// <summary>
		///     Show All Classes check changed: refresh the classes tree
		/// </summary>
		private void chkAllClasses_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyingOptions)
				return;

			Pandora.Profile.Props.ShowAllTypes = chkAllClasses.Checked;
			RefreshTrees();
		}

		/// <summary>
		///     Show All Props check changed: refresh the props tree
		/// </summary>
		private void chkAllProps_CheckedChanged(object sender, EventArgs e)
		{
			if (m_ApplyingOptions)
				return;

			Pandora.Profile.Props.ShowAllProps = chkAllProps.Checked;
			RefreshPropsTree();
		}

		/// <summary>
		///     Filter changed: refresh the props tree
		/// </summary>
		private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ApplyingOptions)
				return;

			Pandora.Profile.Props.Filter = (AccessLevel)(4 - cmbFilter.SelectedIndex);
			RefreshPropsTree();
		}
		#endregion

		#region Searching
		/// <summary>
		///     Button find clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bFind_Click(object sender, EventArgs e)
		{
			if (cmbSearch.Text != null && cmbSearch.Text.Length > 0)
			{
				var search = cmbSearch.Text;
				Pandora.Profile.Props.RecentClasses.AddString(search);
				RefreshSearches();

				// Do the search
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var results = PropsData.Props.FindClass(search);
				// Issue 10 - End

				if (results.Count == 0)
				{
					MessageBox.Show(Pandora.Localization.TextProvider["Props.NoClassMatch"]);
				}
				else if (results.Count == 1)
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					DisplaySearchResult(results[0]);
					// Issue 10 - End
				}
				else
				{
					var selector = new SearchResultsSelector();

					selector.Paths = results;

					var loc = PointToScreen(Point.Empty);
					selector.Location = loc;

					selector.ShowDialog();

					var index = selector.SelectedClass;
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					DisplaySearchResult(results[index]);
					// Issue 10 - End
				}

				cmbSearch.Text = "";
			}
		}

		/// <summary>
		///     Displays a search result given a path
		/// </summary>
		/// <param name="path">The path to search for</param>
		private void DisplaySearchResult(string path)
		{
			var NodePath = path.Split('.');

			var PreviousNode = FindNode(NodePath[0], tClasses.Nodes);

			for (var i = 1; i < NodePath.Length; i++)
			{
				var node = FindNode(NodePath[i], PreviousNode.Nodes);

				if (node != null)
				{
					PreviousNode = node;
				}
				else
				{
					break;
				}
			}

			tClasses.SelectedNode = PreviousNode;
		}

		/// <summary>
		///     Finds a TreeNode given its name
		/// </summary>
		/// <param name="name">The text to search for</param>
		/// <param name="nodes">The collection of nodes to search</param>
		/// <returns>The TreeNode if found, null otherwise</returns>
		private TreeNode FindNode(string name, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (name == node.Text)
				{
					return node;
				}
			}

			return null;
		}
		#endregion

		/// <summary>
		///     User has selected a property
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tProps_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null && e.Node.Tag != null)
			{
				SelectedProperty = e.Node.Tag as BoxProp;
			}
			else
			{
				SelectedProperty = null;
			}
		}

		private void cmbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				bFind.PerformClick();
			}
		}

		private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			Pandora.Profile.General.PropsSplitter = splitter.SplitPosition;
		}

		private void PropsData_PropsChanged(object sender, EventArgs e)
		{
			RefreshPropsTree();
		}

		private void tClasses_MouseDown(object sender, MouseEventArgs e)
		{
			var view = sender as TreeView;

			view.SelectedNode = view.GetNodeAt(view.PointToClient(MousePosition));

			if (view != null && view.SelectedNode != null)
			{
				view.DoDragDrop(view.SelectedNode.Text, DragDropEffects.Copy);
			}
		}
	}
}