#region Header
// /*
//  *    2018 - Pandora - BoxMenuEditor.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Summary description for BoxMenuEditor.
	/// </summary>
	public class BoxMenuEditor : Form
	{
		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public BoxMenuEditor()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			m_MenuNode = new TreeNode(Pandora.Localization.TextProvider["ButtonMenuEditor.Menu"]);
			Tree.Nodes.Add(m_MenuNode);
		}

		private TextBox txSubmenu;
		private Button bNewSubmenu;
		private Label label1;
		private TextBox txCaption;
		private TextBox txCommand;
		private Label label2;
		private CheckBox chkPrefix;
		private Button bNewCommand;
		private LinkLabel linkLabel1;
		private Button bOk;
		private Button bCancel;
		private Label label3;
		private TreeView Tree;

		private MenuDef m_Def;
		private MenuDef m_Backup;
		private GroupBox GroupSubmenu;
		private GroupBox GroupCommand;
		private readonly TreeNode m_MenuNode;

		/// <summary>
		///     Gets or sets the MenuDef object edited by this form
		/// </summary>
		public MenuDef MenuDefinition
		{
			get { return m_Def; }
			set
			{
				m_Backup = value;
				m_Def = value;
				DoTree();
			}
		}

		/// <summary>
		///     Creates the tree according to the current menu definition
		/// </summary>
		private void DoTree()
		{
			Tree.BeginUpdate();

			m_MenuNode.Nodes.Clear();

			m_MenuNode.Nodes.AddRange(DoNodes(m_Def.Items));

			Tree.EndUpdate();
		}

		/// <summary>
		///     Converts a List of objects to tree nodes
		/// </summary>
		/// <param name="items">The list of items to convert</param>
		/// <returns>A collection of corresponding TreeNode objects</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private TreeNode[] DoNodes(List<object> items)
			// Issue 10 - End
		{
			var nodes = new TreeNode[items.Count];

			for (var i = 0; i < nodes.Length; i++)
			{
				if (items[i] is MenuCommand)
				{
					var mc = items[i] as MenuCommand;

					var newMc = mc.Clone() as MenuCommand;

					nodes[i] = new TreeNode(newMc.Caption);
					nodes[i].Tag = newMc;
				}
				else if (items[i] is GenericNode)
				{
					var gnode = items[i] as GenericNode;

					nodes[i] = new TreeNode(gnode.Name);
					nodes[i].Nodes.AddRange(DoNodes(gnode.Elements));
				}
			}

			return nodes;
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
			var resources = new System.Resources.ResourceManager(typeof(BoxMenuEditor));
			this.Tree = new System.Windows.Forms.TreeView();
			this.GroupSubmenu = new System.Windows.Forms.GroupBox();
			this.bNewSubmenu = new System.Windows.Forms.Button();
			this.txSubmenu = new System.Windows.Forms.TextBox();
			this.GroupCommand = new System.Windows.Forms.GroupBox();
			this.bNewCommand = new System.Windows.Forms.Button();
			this.chkPrefix = new System.Windows.Forms.CheckBox();
			this.txCommand = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txCaption = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.GroupSubmenu.SuspendLayout();
			this.GroupCommand.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tree
			// 
			this.Tree.HideSelection = false;
			this.Tree.ImageIndex = -1;
			this.Tree.Location = new System.Drawing.Point(8, 8);
			this.Tree.Name = "Tree";
			this.Tree.SelectedImageIndex = -1;
			this.Tree.Size = new System.Drawing.Size(320, 408);
			this.Tree.TabIndex = 0;
			this.Tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tree_KeyDown);
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
			this.Tree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.Tree_AfterLabelEdit);
			// 
			// GroupSubmenu
			// 
			this.GroupSubmenu.Controls.Add(this.bNewSubmenu);
			this.GroupSubmenu.Controls.Add(this.txSubmenu);
			this.GroupSubmenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.GroupSubmenu.Location = new System.Drawing.Point(336, 8);
			this.GroupSubmenu.Name = "GroupSubmenu";
			this.GroupSubmenu.Size = new System.Drawing.Size(304, 56);
			this.GroupSubmenu.TabIndex = 1;
			this.GroupSubmenu.TabStop = false;
			this.GroupSubmenu.Text = "ButtonMenuEditor.NewSubText";
			// 
			// bNewSubmenu
			// 
			this.bNewSubmenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNewSubmenu.Location = new System.Drawing.Point(240, 24);
			this.bNewSubmenu.Name = "bNewSubmenu";
			this.bNewSubmenu.Size = new System.Drawing.Size(56, 23);
			this.bNewSubmenu.TabIndex = 1;
			this.bNewSubmenu.Text = "Common.Add";
			this.bNewSubmenu.Click += new System.EventHandler(this.bNewSubmenu_Click);
			// 
			// txSubmenu
			// 
			this.txSubmenu.Location = new System.Drawing.Point(16, 24);
			this.txSubmenu.Name = "txSubmenu";
			this.txSubmenu.Size = new System.Drawing.Size(216, 20);
			this.txSubmenu.TabIndex = 0;
			this.txSubmenu.Text = "";
			this.txSubmenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txSubmenu_KeyDown);
			// 
			// GroupCommand
			// 
			this.GroupCommand.Controls.Add(this.bNewCommand);
			this.GroupCommand.Controls.Add(this.chkPrefix);
			this.GroupCommand.Controls.Add(this.txCommand);
			this.GroupCommand.Controls.Add(this.label2);
			this.GroupCommand.Controls.Add(this.txCaption);
			this.GroupCommand.Controls.Add(this.label1);
			this.GroupCommand.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.GroupCommand.Location = new System.Drawing.Point(336, 72);
			this.GroupCommand.Name = "GroupCommand";
			this.GroupCommand.Size = new System.Drawing.Size(304, 112);
			this.GroupCommand.TabIndex = 2;
			this.GroupCommand.TabStop = false;
			this.GroupCommand.Text = "ButtonMenuEditor.NewComText";
			// 
			// bNewCommand
			// 
			this.bNewCommand.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNewCommand.Location = new System.Drawing.Point(240, 80);
			this.bNewCommand.Name = "bNewCommand";
			this.bNewCommand.Size = new System.Drawing.Size(56, 23);
			this.bNewCommand.TabIndex = 5;
			this.bNewCommand.Text = "Common.Add";
			this.bNewCommand.Click += new System.EventHandler(this.bNewCommand_Click);
			// 
			// chkPrefix
			// 
			this.chkPrefix.Checked = true;
			this.chkPrefix.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPrefix.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkPrefix.Location = new System.Drawing.Point(8, 80);
			this.chkPrefix.Name = "chkPrefix";
			this.chkPrefix.Size = new System.Drawing.Size(200, 24);
			this.chkPrefix.TabIndex = 4;
			this.chkPrefix.Text = "ButtonMenuEditor.UsePrefix";
			this.chkPrefix.CheckedChanged += new System.EventHandler(this.chkPrefix_CheckedChanged);
			// 
			// txCommand
			// 
			this.txCommand.Location = new System.Drawing.Point(64, 48);
			this.txCommand.Name = "txCommand";
			this.txCommand.Size = new System.Drawing.Size(232, 20);
			this.txCommand.TabIndex = 3;
			this.txCommand.Text = "";
			this.txCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txCommand_KeyDown);
			this.txCommand.TextChanged += new System.EventHandler(this.txCommand_TextChanged);
			this.txCommand.Enter += new System.EventHandler(this.txCommand_Enter);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "ButtonMenuEditor.Command";
			// 
			// txCaption
			// 
			this.txCaption.Location = new System.Drawing.Point(64, 16);
			this.txCaption.Name = "txCaption";
			this.txCaption.Size = new System.Drawing.Size(232, 20);
			this.txCaption.TabIndex = 1;
			this.txCaption.Text = "";
			this.txCaption.TextChanged += new System.EventHandler(this.txCaption_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "ButtonMenuEditor.Caption";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(336, 192);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(304, 23);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "ButtonMenuEditor.Preview";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.linkLabel1_MouseDown);
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(568, 392);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 4;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(480, 392);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 5;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(336, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(304, 144);
			this.label3.TabIndex = 6;
			this.label3.Text = "ButtonMenuEditor.Instructions";
			// 
			// BoxMenuEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(650, 424);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.GroupCommand);
			this.Controls.Add(this.GroupSubmenu);
			this.Controls.Add(this.Tree);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BoxMenuEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ButtonMenuEditor.Title";
			this.GroupSubmenu.ResumeLayout(false);
			this.GroupCommand.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Tree : AfterSelect
		/// </summary>
		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var n = Tree.SelectedNode;

			if (n == m_MenuNode)
			{
				// Menu node: Enable both
				GroupCommand.Enabled = true;
				GroupSubmenu.Enabled = true;

				txCaption.Text = "";
				txCommand.Text = "";
			}
			else if (n.Tag is MenuCommand)
			{
				// Menu command
				GroupSubmenu.Enabled = false;
				GroupCommand.Enabled = true;

				var mc = n.Tag as MenuCommand;

				txCaption.Text = mc.Caption;
				txCommand.Text = mc.Command;
				chkPrefix.Checked = mc.UsePrefix;
			}
			else
			{
				// Submenu node
				GroupSubmenu.Enabled = true;
				GroupCommand.Enabled = true;
			}

			if (!(n.Tag is MenuCommand))
			{
				txCaption.Text = "";
				txCommand.Text = "";
			}
		}

		/// <summary>
		///     Add a new command (disabled when a command node is selected)
		/// </summary>
		private void bNewCommand_Click(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && Tree.SelectedNode.Tag is MenuCommand)
				return;

			if (Tree.SelectedNode != null)
			{
				if (txCaption.Text.Length == 0 || txCommand.Text.Length == 0)
				{
					MessageBox.Show(Pandora.Localization.TextProvider["ButtonMenuEditor.ErrCommand"]);
					return;
				}

				var node = new TreeNode(txCaption.Text);

				var mc = new MenuCommand();
				mc.Caption = txCaption.Text;
				mc.Command = txCommand.Text;
				mc.UsePrefix = chkPrefix.Checked;

				node.Tag = mc;

				Tree.SelectedNode.Nodes.Add(node);
				Tree.SelectedNode.Expand();

				txCaption.Text = "";
				txCommand.Text = "";

				txCaption.Focus();
			}
		}

		/// <summary>
		///     Add a new submenu
		/// </summary>
		private void bNewSubmenu_Click(object sender, EventArgs e)
		{
			if (txSubmenu.Text.Length == 0)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["ButtonMenuEditor.ErrSub"]);
				return;
			}

			var node = new TreeNode(txSubmenu.Text);

			Tree.SelectedNode.Nodes.Add(node);
			Tree.SelectedNode = node.Parent;
			Tree.SelectedNode.Expand();

			txSubmenu.Text = "";
		}

		/// <summary>
		///     Monitors changes in the caption text (and updates the command when a command node is selected)
		/// </summary>
		private void txCaption_TextChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && Tree.SelectedNode.Tag is MenuCommand && txCaption.Text.Length > 0)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.Caption = txCaption.Text;
				Tree.SelectedNode.Text = txCaption.Text;
			}
		}

		/// <summary>
		///     Monitors changes in the command text and updates the command when a command node is selected
		/// </summary>
		private void txCommand_TextChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && Tree.SelectedNode.Tag is MenuCommand && txCommand.Text.Length > 0)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.Command = txCommand.Text;
			}
		}

		/// <summary>
		///     Monitors and updates on the command the use prefix value
		/// </summary>
		private void chkPrefix_CheckedChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && Tree.SelectedNode.Tag is MenuCommand)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.UsePrefix = chkPrefix.Checked;
			}
		}

		/// <summary>
		///     Creates the menu def from the current tree structure
		/// </summary>
		private void DoDef()
		{
			m_Def = new MenuDef();
			m_Def.Items = ProcessTreeNode(m_MenuNode);
		}

		/// <summary>
		///     Reads a tree node and converts its child nodes to data used in menu defs
		/// </summary>
		/// <param name="node">The tree node to examine</param>
		/// <returns>An array list of generic nodes and box menu items</returns>

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> ProcessTreeNode(TreeNode node)
		{
			var list = new List<object>();
			// Issue 10 - End

			foreach (TreeNode n in node.Nodes)
			{
				if (n.Tag is MenuCommand)
				{
					list.Add(n.Tag as MenuCommand);
				}
				else if (n.Nodes.Count > 0)
				{
					var gn = new GenericNode(n.Text);

					gn.Elements = ProcessTreeNode(n);

					if (gn.Elements.Count > 0)
						list.Add(gn);
				}
			}

			return list;
		}

		/// <summary>
		///     Testing command sending
		/// </summary>
		private void m_Def_SendCommand(object sender, SendCommandEventArgs e)
		{
			var cmd = "";

			if (e.UsePrefix)
				cmd += Pandora.Profile.General.CommandPrefix;
			cmd += e.Command;

			MessageBox.Show(string.Format(Pandora.Localization.TextProvider["ButtonMenuEditor.PreviewMsg"], cmd));
		}

		/// <summary>
		///     Preview label clicked: compute and display the menu
		/// </summary>
		private void linkLabel1_MouseDown(object sender, MouseEventArgs e)
		{
			DoDef();

			m_Def.SendCommand += m_Def_SendCommand;

			m_Def.Menu.Show(linkLabel1, new Point(e.X, e.Y));
		}

		/// <summary>
		///     Close - Cancel
		/// </summary>
		private void bCancel_Click(object sender, EventArgs e)
		{
			m_Def = m_Backup;
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		///     Close - Ok
		/// </summary>
		private void bOk_Click(object sender, EventArgs e)
		{
			DoDef();
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		///     Hotkeys managment on the Tree
		/// </summary>
		private void Tree_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:

					if (Tree.SelectedNode != null && Tree.SelectedNode != m_MenuNode && !(Tree.SelectedNode.Tag is MenuCommand))
					{
						Tree.LabelEdit = true;
						Tree.SelectedNode.BeginEdit();
					}
					e.Handled = true;

					break;

				case Keys.Delete:

					if (Tree.SelectedNode != null && Tree.SelectedNode != m_MenuNode)
					{
						if (MessageBox.Show(
								this,
								Pandora.Localization.TextProvider["Messages.DelConfirm"],
								"",
								MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							var n = Tree.SelectedNode;
							Tree.SelectedNode = n.Parent;

							var nextNode = n.NextNode;

							if (nextNode == null)
								nextNode = n.PrevNode;

							if (nextNode != null)
								Tree.SelectedNode = nextNode;
							else
								Tree.SelectedNode = n.Parent;

							Tree.Nodes.Remove(n);
						}
					}
					e.Handled = true;

					break;

				case Keys.Up:

					e.Handled = true;

					if (Tree.SelectedNode != null && Tree.SelectedNode != m_MenuNode)
					{
						var node = Tree.SelectedNode;
						var parent = node.Parent;

						var index = parent.Nodes.IndexOf(node);

						if (index == 0)
							break;

						var prev = parent.Nodes[index - 1];

						parent.Nodes.Remove(node);
						parent.Nodes.Remove(prev);

						parent.Nodes.Insert(index - 1, prev);
						parent.Nodes.Insert(index - 1, node);

						Tree.SelectedNode = node;
					}

					break;

				case Keys.Down:

					e.Handled = true;

					if (Tree.SelectedNode != null && Tree.SelectedNode != m_MenuNode)
					{
						var node = Tree.SelectedNode;
						var parent = node.Parent;

						var index = parent.Nodes.IndexOf(node);

						if (index == parent.Nodes.Count - 1)
							break;

						var next = parent.Nodes[index + 1];

						parent.Nodes.Remove(node);
						parent.Nodes.Remove(next);

						parent.Nodes.Insert(index, node);
						parent.Nodes.Insert(index, next);

						Tree.SelectedNode = node;
					}

					break;
			}
		}

		/// <summary>
		///     End of node edit: reset LabelEdit to false
		/// </summary>
		private void Tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			Tree.LabelEdit = false;
		}

		private void txCommand_Enter(object sender, EventArgs e)
		{
			if (txCaption.Text.Length > 0 && txCommand.Text.Length == 0)
			{
				txCommand.Text = txCaption.Text;
				txCommand.SelectAll();
			}
		}

		private void txCommand_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;

				bNewCommand_Click(sender, new EventArgs());
			}
		}

		private void txSubmenu_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;

				bNewSubmenu_Click(sender, new EventArgs());
			}
		}
	}
}