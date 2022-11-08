#region Header
// /*
//  *    2018 - BoxServerSetup - S1_Folder.cs
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
	public class S1_Folder : BaseInteriorStep
	{
		private Label labPath;
		private Button button1;
		private OpenFileDialog OpenFile;
		private readonly IContainer components = null;

		public S1_Folder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Description.Text = "Please browse and locate the RunUO executable.";
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
			this.labPath = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			// 
			// labPath
			// 
			this.labPath.Location = new System.Drawing.Point(48, 8);
			this.labPath.Name = "labPath";
			this.labPath.Size = new System.Drawing.Size(280, 23);
			this.labPath.TabIndex = 1;
			this.labPath.Text = "Please hit browse to select";
			this.labPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labPath.Paint += new System.Windows.Forms.PaintEventHandler(this.labPath_Paint);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(344, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Browse";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// OpenFile
			// 
			this.OpenFile.Filter = "RunUO Executable (*.exe)|*.exe";
			// 
			// S1_Folder
			// 
			this.Controls.Add(this.button1);
			this.Controls.Add(this.labPath);
			this.Name = "S1_Folder";
			this.NextStep = "S2_BoxFolder";
			this.PreviousStep = "Introduction";
			this.StepTitle = "Find the RunUO executable";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.S1_Folder_ValidateStep);
			this.Controls.SetChildIndex(this.labPath, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.Description, 0);
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
			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				Setup.RunUOFolder = Path.GetDirectoryName(OpenFile.FileName);

				var assemblies = Path.Combine(Setup.RunUOFolder, @"Data\Assemblies.cfg");

				if (!File.Exists(assemblies))
				{
					_ = MessageBox.Show(
						"The selected file doesn't appear to be a valid RunUO executable, or doesn't belong to a valid RunUO installation. Please select the Server.exe, Service.exe or RunUO.exe files as they are found in the default RunUO distribution.");
					Setup.RunUOFolder = null;

					labPath.Text = "Please hit browse to select";
				}
				else
				{
					labPath.Text = OpenFile.FileName;
				}
			}
		}

		private void S1_Folder_ValidateStep(object sender, CancelEventArgs e)
		{
			if (Setup.RunUOFolder == null)
			{
				_ = MessageBox.Show("Please select a RunUO executable before proceeding.");
				e.Cancel = true;
			}
		}
	}
}