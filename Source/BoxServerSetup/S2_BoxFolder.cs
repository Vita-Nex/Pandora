#region Header
// /*
//  *    2018 - BoxServerSetup - S2_BoxFolder.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace BoxServerSetup
{
	public class S2_BoxFolder : BaseInteriorStep
	{
		private Button button1;
		private Label labPath;
		private FolderBrowserDialog FolderBrowser;
		private readonly IContainer components = null;

		public S2_BoxFolder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Description.Text = "Please select the desitnation folder for the BoxServer scripts.";
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
			this.button1 = new System.Windows.Forms.Button();
			this.labPath = new System.Windows.Forms.Label();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(344, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "Browse";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// labPath
			// 
			this.labPath.Location = new System.Drawing.Point(48, 8);
			this.labPath.Name = "labPath";
			this.labPath.Size = new System.Drawing.Size(280, 23);
			this.labPath.TabIndex = 3;
			this.labPath.Text = "Please hit browse to select";
			this.labPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labPath.Paint += new System.Windows.Forms.PaintEventHandler(this.labPath_Paint);
			// 
			// S2_BoxFolder
			// 
			this.Controls.Add(this.button1);
			this.Controls.Add(this.labPath);
			this.Name = "S2_BoxFolder";
			this.NextStep = "S3_Spawner";
			this.PreviousStep = "S1_Folder";
			this.StepTitle = "BoxServer Installation Folder";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.S2_BoxFolder_ValidateStep);
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.S2_BoxFolder_ShowStep);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.labPath, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void labPath_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, labPath.Size.Width - 1, labPath.Size.Height - 1);
			pen.Dispose();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				Setup.BoxFolder = FolderBrowser.SelectedPath;
				var scripts = Path.Combine(Setup.RunUOFolder, "Scripts");

				if (Setup.BoxFolder.IndexOf(scripts) == -1)
				{
					MessageBox.Show(
						"The BoxServer folder must be located within the scripts folder of the RunUO installation specified in the previous step.");
					Setup.BoxFolder = null;
				}
				else if (Directory.GetDirectories(Setup.BoxFolder).Length > 0 || Directory.GetFiles(Setup.BoxFolder).Length > 0)
				{
					if (MessageBox.Show(
							this,
							"The selected folder already exists. Files within this folder might be overwritten. Are you sure you wish to proceed?",
							"Folder already exists",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Warning) == DialogResult.No)
					{
						Setup.BoxFolder = null;
					}
				}

				labPath.Text = Setup.BoxFolder != null ? Setup.BoxFolder : "Please hit browse to select.";
			}
		}

		private void S2_BoxFolder_ShowStep(object sender, ShowStepEventArgs e)
		{
			FolderBrowser.SelectedPath = Path.Combine(Setup.RunUOFolder, "Scripts");
		}

		private void S2_BoxFolder_ValidateStep(object sender, CancelEventArgs e)
		{
			e.Cancel = Setup.BoxFolder == null;
		}
	}
}