#region Header
// /*
//  *    2018 - Pandora - MultiCommandEditor.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Summary description for MultiCommandEditor.
	/// </summary>
	public class MultiCommandEditor : Form
	{
		private GroupBox groupBox1;
		private Label label1;
		private Label label2;
		private TextBox txCaption;
		private TextBox txCommand;
		private CheckBox chkPrefix;
		private Button bAdd;
		private LinkLabel linkPreview;
		private Label label3;
		private Button bOk;
		private Button bCancel;
		private TreeView Tree;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public MultiCommandEditor()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			m_Def = new MultiCommandDef();
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
			var resources = new System.Resources.ResourceManager(typeof(MultiCommandEditor));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkPrefix = new System.Windows.Forms.CheckBox();
			this.txCommand = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txCaption = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bAdd = new System.Windows.Forms.Button();
			this.linkPreview = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.Tree = new System.Windows.Forms.TreeView();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkPrefix);
			this.groupBox1.Controls.Add(this.txCommand);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txCaption);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.bAdd);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(208, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 128);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ButtonMenuEditor.NewComText";
			// 
			// chkPrefix
			// 
			this.chkPrefix.Checked = true;
			this.chkPrefix.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPrefix.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkPrefix.Location = new System.Drawing.Point(8, 96);
			this.chkPrefix.Name = "chkPrefix";
			this.chkPrefix.Size = new System.Drawing.Size(152, 24);
			this.chkPrefix.TabIndex = 3;
			this.chkPrefix.Text = "ButtonMenuEditor.UsePrefix";
			this.chkPrefix.CheckedChanged += new System.EventHandler(this.chkPrefix_CheckedChanged);
			// 
			// txCommand
			// 
			this.txCommand.Location = new System.Drawing.Point(72, 64);
			this.txCommand.Name = "txCommand";
			this.txCommand.Size = new System.Drawing.Size(184, 20);
			this.txCommand.TabIndex = 2;
			this.txCommand.Text = "";
			this.txCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txCommand_KeyDown);
			this.txCommand.TextChanged += new System.EventHandler(this.txCommand_TextChanged);
			this.txCommand.Enter += new System.EventHandler(this.txCommand_Enter);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "ButtonMenuEditor.Command";
			// 
			// txCaption
			// 
			this.txCaption.Location = new System.Drawing.Point(72, 24);
			this.txCaption.Name = "txCaption";
			this.txCaption.Size = new System.Drawing.Size(184, 20);
			this.txCaption.TabIndex = 1;
			this.txCaption.Text = "";
			this.txCaption.TextChanged += new System.EventHandler(this.txCaption_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "ButtonMenuEditor.Caption";
			// 
			// bAdd
			// 
			this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAdd.Location = new System.Drawing.Point(200, 96);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(56, 23);
			this.bAdd.TabIndex = 4;
			this.bAdd.Text = "Common.Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// linkPreview
			// 
			this.linkPreview.Location = new System.Drawing.Point(208, 152);
			this.linkPreview.Name = "linkPreview";
			this.linkPreview.Size = new System.Drawing.Size(264, 23);
			this.linkPreview.TabIndex = 2;
			this.linkPreview.TabStop = true;
			this.linkPreview.Text = "MultiCmd.Preview";
			this.linkPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.linkPreview_MouseDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(208, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 112);
			this.label3.TabIndex = 3;
			this.label3.Text = "MultiCmd.Instructions";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(408, 304);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(64, 23);
			this.bOk.TabIndex = 4;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(336, 304);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(64, 23);
			this.bCancel.TabIndex = 5;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// Tree
			// 
			this.Tree.CheckBoxes = true;
			this.Tree.FullRowSelect = true;
			this.Tree.HideSelection = false;
			this.Tree.ImageIndex = -1;
			this.Tree.Location = new System.Drawing.Point(8, 8);
			this.Tree.Name = "Tree";
			this.Tree.SelectedImageIndex = -1;
			this.Tree.ShowLines = false;
			this.Tree.ShowPlusMinus = false;
			this.Tree.ShowRootLines = false;
			this.Tree.Size = new System.Drawing.Size(192, 320);
			this.Tree.TabIndex = 6;
			this.Tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tree_KeyDown);
			this.Tree.Click += new System.EventHandler(this.Tree_Click);
			this.Tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterCheck);
			this.Tree.DoubleClick += new System.EventHandler(this.Tree_DoubleClick);
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
			// 
			// MultiCommandEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 336);
			this.Controls.Add(this.Tree);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkPreview);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "MultiCommandEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MultiCmd.Title";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private MultiCommandDef m_Def;
		private MultiCommandDef m_Backup;
		private bool m_Edit;

		/// <summary>
		///     Gets or sets the definition object edited
		/// </summary>
		public MultiCommandDef MultiDef
		{
			get => m_Def;
			set
			{
				m_Backup = value;
				m_Def = value.Clone() as MultiCommandDef;

				DoList();
			}
		}

		/// <summary>
		///     Populates the tree with nodes corresponding to the menu items
		/// </summary>
		private void DoList()
		{
			for (var i = 0; i < m_Def.Commands.Count; i++)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var mc = m_Def.Commands[i];
				// Issue 10 - End

				var node = new TreeNode(mc.Caption)
				{
					Tag = mc,
					Checked = i == m_Def.DefaultIndex
				};

				_ = Tree.Nodes.Add(node);
			}
		}

		/// <summary>
		///     Manage the checks on the tree
		/// </summary>
		private void Tree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				// Uncheck previous default node
				if (m_Def.DefaultIndex >= 0 && m_Def.DefaultIndex < Tree.Nodes.Count)
				{
					if (m_Def.DefaultIndex != Tree.Nodes.IndexOf(e.Node))
					{
						var node = Tree.Nodes[m_Def.DefaultIndex];

						if (node.Checked)
						{
							node.Checked = false;
						}
					}
				}

				m_Def.DefaultIndex = Tree.Nodes.IndexOf(e.Node);

				linkPreview.Text = (e.Node.Tag as MenuCommand).Caption;
			}
		}

		/// <summary>
		///     Selecting an item on the tree: display it in the edit field if in edit mode
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (m_Edit)
			{
				var mc = e.Node.Tag as MenuCommand;

				txCaption.Text = mc.Caption;
				txCommand.Text = mc.Command;
				chkPrefix.Checked = mc.UsePrefix;
			}
			else
			{
				txCaption.Text = "";
				txCommand.Text = "";
			}
		}

		/// <summary>
		///     Edit caption
		/// </summary>
		private void txCaption_TextChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && m_Edit && txCaption.Text.Length > 0)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.Caption = txCaption.Text;
				Tree.SelectedNode.Text = txCaption.Text;
			}
		}

		/// <summary>
		///     Edit command text
		/// </summary>
		private void txCommand_TextChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && m_Edit)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.Command = txCommand.Text;
			}
		}

		/// <summary>
		///     Edit check for using the prefix
		/// </summary>
		private void chkPrefix_CheckedChanged(object sender, EventArgs e)
		{
			if (Tree.SelectedNode != null && m_Edit)
			{
				var mc = Tree.SelectedNode.Tag as MenuCommand;

				mc.UsePrefix = chkPrefix.Checked;
			}
		}

		/// <summary>
		///     Add new menu command
		/// </summary>
		private void bAdd_Click(object sender, EventArgs e)
		{
			if (txCaption.Text.Length == 0 || txCommand.Text.Length == 0)
			{
				_ = MessageBox.Show(Pandora.Localization.TextProvider["ButtonMenuEditor.ErrCommand"]);
				return;
			}

			var mc = new MenuCommand
			{
				Caption = txCaption.Text,
				Command = txCommand.Text,
				UsePrefix = chkPrefix.Checked
			};

			var node = new TreeNode(mc.Caption)
			{
				Tag = mc
			};

			_ = Tree.Nodes.Add(node);

			m_Edit = false;
			txCaption.Text = "";
			txCommand.Text = "";

			if (Tree.Nodes.Count == 1)
			{
				// First node, make it default
				Tree.Nodes[0].Checked = true;
			}

			_ = txCaption.Focus();
		}

		/// <summary>
		///     Creates the def object
		/// </summary>
		private void DoDef()
		{
			m_Def = new MultiCommandDef();

			foreach (TreeNode node in Tree.Nodes)
			{
				var mc = node.Tag as MenuCommand;

				m_Def.Commands.Add(mc);

				if (node.Checked)
				{
					m_Def.DefaultIndex = Tree.Nodes.IndexOf(node);
				}
			}
		}

		/// <summary>
		///     Preview the menu
		/// </summary>
		private void linkPreview_MouseDown(object sender, MouseEventArgs e)
		{
			DoDef();

			linkPreview.Text = m_Def.DefaultCommand.Caption;

			if (e.Button == MouseButtons.Left)
			{
				var cmd = "";

				if (m_Def.DefaultCommand.UsePrefix)
				{
					cmd += Pandora.Profile.General.CommandPrefix;
				}

				cmd += m_Def.DefaultCommand.Command;

				_ = MessageBox.Show(String.Format(Pandora.Localization.TextProvider["ButtonMenuEditor.PreviewMsg"], cmd));
			}
			else
			{
				m_Def.Menu.Show(linkPreview, new Point(e.X, e.Y));
			}
		}

		/// <summary>
		///     Tree dbl click: Edit/Not edit
		/// </summary>
		private void Tree_DoubleClick(object sender, EventArgs e)
		{
			m_Edit = !m_Edit;

			if (m_Edit)
			{
				// Now editing
				if (Tree.SelectedNode != null)
				{
					var mc = Tree.SelectedNode.Tag as MenuCommand;

					txCaption.Text = mc.Caption;
					txCommand.Text = mc.Command;
					chkPrefix.Checked = mc.UsePrefix;
				}
				else
				{
					m_Edit = false;
				}
			}
			else
			{
				// End editing
				txCaption.Text = "";
				txCommand.Text = "";
			}
		}

		/// <summary>
		///     Clicking the tree goes out of edit mode and resets fields
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tree_Click(object sender, EventArgs e)
		{
			m_Edit = false;

			txCaption.Text = "";
			txCommand.Text = "";
		}

		/// <summary>
		///     Manages the keys pressed on the tree
		/// </summary>
		private void Tree_KeyDown(object sender, KeyEventArgs e)
		{
			if (Tree.SelectedNode == null)
			{
				return;
			}

			var node = Tree.SelectedNode;
			int index;
			switch (e.KeyCode)
			{
				case Keys.Delete:

					e.Handled = true;

					var nextnode = node.NextNode;

					if (nextnode == null)
					{
						nextnode = node.PrevNode;
					}

					var checknextnode = false;
					if (node.Checked && nextnode != null)
					{
						checknextnode = true;
					}

					Tree.Nodes.Remove(node);

					if (nextnode != null)
					{
						Tree.SelectedNode = nextnode;
					}

					if (checknextnode)
					{
						nextnode.Checked = true;
					}

					break;

				case Keys.Up:

					e.Handled = true;

					var prev = node.PrevNode;

					if (prev == null)
					{
						break;
					}

					index = Tree.Nodes.IndexOf(prev);

					Tree.Nodes.Remove(node);
					Tree.Nodes.Remove(prev);

					Tree.Nodes.Insert(index, prev);
					Tree.Nodes.Insert(index, node);

					Tree.SelectedNode = node;
					break;

				case Keys.Down:

					e.Handled = true;

					var next = node.NextNode;

					if (next == null)
					{
						break;
					}

					index = Tree.Nodes.IndexOf(node);

					Tree.Nodes.Remove(node);
					Tree.Nodes.Insert(index + 1, node);

					Tree.SelectedNode = node;
					break;
			}
		}

		/// <summary>
		///     CANCEL
		/// </summary>
		private void bCancel_Click(object sender, EventArgs e)
		{
			if (m_Backup != null)
			{
				m_Def = m_Backup;
			}
			else
			{
				m_Def = null;
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		///     OK
		/// </summary>
		private void bOk_Click(object sender, EventArgs e)
		{
			DoDef();
			DialogResult = DialogResult.OK;
			Close();
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

				bAdd_Click(sender, new EventArgs());
			}
		}
	}
}