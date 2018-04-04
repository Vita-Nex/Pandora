#region Header
// /*
//  *    2018 - Pandora - pwStep6bServer.cs
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
	public class pwStep6bServer : BaseInteriorStep
	{
		private CheckBox chkUseServer;
		private GroupBox grpServer;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private TextBox txPass;
		private TextBox txUser;
		private NumericUpDown numPort;
		private TextBox txAddress;
		private LinkLabel linkLabel1;
		private readonly IContainer components = null;

		public pwStep6bServer()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
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
			this.chkUseServer = new System.Windows.Forms.CheckBox();
			this.grpServer = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txPass = new System.Windows.Forms.TextBox();
			this.txUser = new System.Windows.Forms.TextBox();
			this.numPort = new System.Windows.Forms.NumericUpDown();
			this.txAddress = new System.Windows.Forms.TextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.grpServer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			// 
			// chkUseServer
			// 
			this.chkUseServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkUseServer.Location = new System.Drawing.Point(56, 8);
			this.chkUseServer.Name = "chkUseServer";
			this.chkUseServer.Size = new System.Drawing.Size(360, 32);
			this.chkUseServer.TabIndex = 1;
			this.chkUseServer.Text = "WizProfile.BoxServer";
			this.chkUseServer.CheckedChanged += new System.EventHandler(this.chkUseServer_CheckedChanged);
			// 
			// grpServer
			// 
			this.grpServer.Controls.Add(this.label4);
			this.grpServer.Controls.Add(this.label3);
			this.grpServer.Controls.Add(this.label2);
			this.grpServer.Controls.Add(this.label1);
			this.grpServer.Controls.Add(this.txPass);
			this.grpServer.Controls.Add(this.txUser);
			this.grpServer.Controls.Add(this.numPort);
			this.grpServer.Controls.Add(this.txAddress);
			this.grpServer.Enabled = false;
			this.grpServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpServer.Location = new System.Drawing.Point(88, 48);
			this.grpServer.Name = "grpServer";
			this.grpServer.Size = new System.Drawing.Size(296, 144);
			this.grpServer.TabIndex = 10;
			this.grpServer.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "Options.Pw";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "Options.User";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "Options.ServPort";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Options.ServAddress";
			// 
			// txPass
			// 
			this.txPass.Location = new System.Drawing.Point(112, 112);
			this.txPass.Name = "txPass";
			this.txPass.PasswordChar = '*';
			this.txPass.Size = new System.Drawing.Size(168, 20);
			this.txPass.TabIndex = 13;
			this.txPass.Text = "";
			// 
			// txUser
			// 
			this.txUser.Location = new System.Drawing.Point(112, 80);
			this.txUser.Name = "txUser";
			this.txUser.Size = new System.Drawing.Size(168, 20);
			this.txUser.TabIndex = 12;
			this.txUser.Text = "";
			// 
			// numPort
			// 
			this.numPort.Location = new System.Drawing.Point(112, 48);
			this.numPort.Maximum = new System.Decimal(new int[] {100000, 0, 0, 0});
			this.numPort.Name = "numPort";
			this.numPort.Size = new System.Drawing.Size(64, 20);
			this.numPort.TabIndex = 11;
			this.numPort.Value = new System.Decimal(new int[] {8035, 0, 0, 0});
			// 
			// txAddress
			// 
			this.txAddress.Location = new System.Drawing.Point(112, 16);
			this.txAddress.Name = "txAddress";
			this.txAddress.Size = new System.Drawing.Size(168, 20);
			this.txAddress.TabIndex = 10;
			this.txAddress.Text = "";
			// 
			// linkLabel1
			// 
			this.linkLabel1.BackColor = System.Drawing.SystemColors.Control;
			this.linkLabel1.Location = new System.Drawing.Point(88, 200);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(296, 32);
			this.linkLabel1.TabIndex = 11;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "WizProfile.PassSecurity";
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// pwStep6bServer
			// 
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.grpServer);
			this.Controls.Add(this.chkUseServer);
			this.Name = "pwStep6bServer";
			this.NextStep = "Step7End";
			this.PreviousStep = "Step6Images";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.pwStep6bServer_ValidateStep);
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.pwStep6bServer_ShowStep);
			this.Controls.SetChildIndex(this.chkUseServer, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.grpServer, 0);
			this.Controls.SetChildIndex(this.linkLabel1, 0);
			this.grpServer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void pwStep6bServer_ValidateStep(object sender, CancelEventArgs e)
		{
			var profile = (Wizard as ProfileWizard).Profile;

			profile.Server.Enabled = chkUseServer.Checked;

			if (profile.Server.Enabled)
			{
				profile.Server.Address = txAddress.Text;
				profile.Server.Username = txUser.Text;
				profile.Server.SetPassword(txPass.Text);
				profile.Server.Port = (int)numPort.Value;
			}
		}

		private void chkUseServer_CheckedChanged(object sender, EventArgs e)
		{
			grpServer.Enabled = chkUseServer.Checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var glm = new GenericLongMessage(ProfileWizard.TextProvider["Misc.PassSecurity"]);
			glm.ShowDialog();
		}

		private void pwStep6bServer_ShowStep(object sender, ShowStepEventArgs e)
		{
			linkLabel1.Text = ProfileWizard.TextProvider["WizProfile.PassSecurity"];
		}
	}
}