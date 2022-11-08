#region Header
// /*
//  *    2018 - Pandora - pwStep4Folder.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace TheBox.Forms.ProfileWizard
{
	public class pwStep4Folder : BaseInteriorStep
	{
		private Label labMessage;
		private Label labFolder;
		private Button bBrowse;
		private FolderBrowserDialog FolderBrowse;
		private LinkLabel linkLabel1;
		private readonly IContainer components = null;

		public pwStep4Folder()
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
			this.labMessage = new System.Windows.Forms.Label();
			this.labFolder = new System.Windows.Forms.Label();
			this.bBrowse = new System.Windows.Forms.Button();
			this.FolderBrowse = new System.Windows.Forms.FolderBrowserDialog();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "WizProfile.FolderDescription";
			// 
			// labMessage
			// 
			this.labMessage.Location = new System.Drawing.Point(48, 16);
			this.labMessage.Name = "labMessage";
			this.labMessage.Size = new System.Drawing.Size(384, 88);
			this.labMessage.TabIndex = 1;
			this.labMessage.Text = "label1";
			// 
			// labFolder
			// 
			this.labFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labFolder.Location = new System.Drawing.Point(48, 120);
			this.labFolder.Name = "labFolder";
			this.labFolder.Size = new System.Drawing.Size(304, 24);
			this.labFolder.TabIndex = 2;
			this.labFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bBrowse
			// 
			this.bBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bBrowse.Location = new System.Drawing.Point(360, 120);
			this.bBrowse.Name = "bBrowse";
			this.bBrowse.Size = new System.Drawing.Size(72, 23);
			this.bBrowse.TabIndex = 3;
			this.bBrowse.Text = "Common.Browse";
			this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(48, 192);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(376, 32);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "WizProfile.MulManage";
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// pwStep4Folder
			// 
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.bBrowse);
			this.Controls.Add(this.labFolder);
			this.Controls.Add(this.labMessage);
			this.Name = "pwStep4Folder";
			this.NextStep = "Step5CustomMap";
			this.PreviousStep = "Step3Name";
			this.StepDescription = "WizProfile.FolderDescription";
			this.StepTitle = "WizProfile.FolderTitle";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.pwStep4Folder_ValidateStep);
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.pwStep4Folder_ShowStep);
			this.Controls.SetChildIndex(this.labMessage, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.labFolder, 0);
			this.Controls.SetChildIndex(this.bBrowse, 0);
			this.Controls.SetChildIndex(this.linkLabel1, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void pwStep4Folder_ShowStep(object sender, ShowStepEventArgs e)
		{
			var wiz = Wizard as ProfileWizard;

			if (wiz.Profile.MulManager.DefaultFolder == null)
			{
				// No folder found
				labMessage.Text = ProfileWizard.TextProvider["WizProfile.FolderNotFound"];
			}
			else
			{
				// Folder found
				labMessage.Text = ProfileWizard.TextProvider["WizProfile.FolderFound"];
				labFolder.Text = wiz.Profile.MulManager.DefaultFolder;
			}
		}

		private string m_CustomFolder;

		private void bBrowse_Click(object sender, EventArgs e)
		{
			if (FolderBrowse.ShowDialog() == DialogResult.OK)
			{
				m_CustomFolder = FolderBrowse.SelectedPath;
				labFolder.Text = m_CustomFolder;
			}
		}

		private void pwStep4Folder_ValidateStep(object sender, CancelEventArgs e)
		{
			var wiz = Wizard as ProfileWizard;

			wiz.Profile.MulManager.CustomFolder = m_CustomFolder;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new MulManagerForm((Wizard as ProfileWizard).Profile.MulManager, ProfileWizard.TextProvider);
			_ = form.ShowDialog();
		}
	}
}