#region Header
// /*
//  *    2018 - BoxServerSetup - S4_Modules.cs
//  */
#endregion

#region References
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace BoxServerSetup
{
	public class S4_Modules : BaseInteriorStep
	{
		private Label labDescription;
		private TreeView tree;
		private readonly IContainer components = null;

		public S4_Modules()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		#region Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tree = new System.Windows.Forms.TreeView();
			this.labDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "Please select which features of BoxServer you wish to install on your server.";
			// 
			// tree
			// 
			this.tree.CheckBoxes = true;
			this.tree.FullRowSelect = true;
			this.tree.HideSelection = false;
			this.tree.ImageIndex = -1;
			this.tree.Location = new System.Drawing.Point(72, 8);
			this.tree.Name = "tree";
			this.tree.SelectedImageIndex = -1;
			this.tree.ShowLines = false;
			this.tree.ShowRootLines = false;
			this.tree.Size = new System.Drawing.Size(160, 160);
			this.tree.Sorted = true;
			this.tree.TabIndex = 1;
			this.tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCheck);
			this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
			// 
			// labDescription
			// 
			this.labDescription.Location = new System.Drawing.Point(72, 176);
			this.labDescription.Name = "labDescription";
			this.labDescription.Size = new System.Drawing.Size(344, 56);
			this.labDescription.TabIndex = 2;
			this.labDescription.Paint += new System.Windows.Forms.PaintEventHandler(this.labDescription_Paint);
			// 
			// S4_Modules
			// 
			this.Controls.Add(this.labDescription);
			this.Controls.Add(this.tree);
			this.Name = "S4_Modules";
			this.NextStep = "S5_Install";
			this.PreviousStep = "S3_Spawner";
			this.StepDescription = "Please select which features of BoxServer you wish to install on your server.";
			this.StepTitle = "Features selection";
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.S4_Modules_ShowStep);
			this.Controls.SetChildIndex(this.tree, 0);
			this.Controls.SetChildIndex(this.labDescription, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void labDescription_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, labDescription.Width - 1, labDescription.Height - 1);
			pen.Dispose();
		}

		private BoxModule m_Module;

		private void S4_Modules_ShowStep(object sender, ShowStepEventArgs e)
		{
			tree.BeginUpdate();
			tree.Nodes.Clear();

			foreach (var module in Setup.Modules)
			{
				var node = new TreeNode(module.Name);
				node.Tag = module;
				node.Checked = true;

				tree.Nodes.Add(node);
			}

			tree.EndUpdate();
		}

		private void tree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			(e.Node.Tag as BoxModule).Install = e.Node.Checked;
		}

		private void tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SelectedModule = e.Node.Tag as BoxModule;
		}

		private BoxModule SelectedModule
		{
			get { return m_Module; }
			set
			{
				m_Module = value;

				labDescription.Text = m_Module.Description;
			}
		}
	}
}