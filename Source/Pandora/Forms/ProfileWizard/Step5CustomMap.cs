#region Header
// /*
//  *    2018 - Pandora - Step5CustomMap.cs
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
	public class pwStep5CustomMap : BaseInteriorStep
	{
		private RadioButton rYes;
		private RadioButton rNo;
		private readonly IContainer components = null;

		public pwStep5CustomMap()
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
			this.rYes = new System.Windows.Forms.RadioButton();
			this.rNo = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "WizProfile.CustomMaps";
			// 
			// rYes
			// 
			this.rYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rYes.Location = new System.Drawing.Point(40, 16);
			this.rYes.Name = "rYes";
			this.rYes.TabIndex = 1;
			this.rYes.Text = "Common.Yes";
			this.rYes.CheckedChanged += new System.EventHandler(this.rYes_CheckedChanged);
			// 
			// rNo
			// 
			this.rNo.Checked = true;
			this.rNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rNo.Location = new System.Drawing.Point(40, 40);
			this.rNo.Name = "rNo";
			this.rNo.TabIndex = 2;
			this.rNo.TabStop = true;
			this.rNo.Text = "Common.No";
			this.rNo.CheckedChanged += new System.EventHandler(this.rNo_CheckedChanged);
			// 
			// pwStep5CustomMap
			// 
			this.Controls.Add(this.rNo);
			this.Controls.Add(this.rYes);
			this.Name = "pwStep5CustomMap";
			this.NextStep = "Step6Images";
			this.PreviousStep = "Step4Folder";
			this.StepDescription = "WizProfile.CustomMaps";
			this.StepTitle = "WizProfile.CustomMapTitle";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.pwStep5CustomMap_ValidateStep);
			this.Controls.SetChildIndex(this.rYes, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.rNo, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void rYes_CheckedChanged(object sender, EventArgs e)
		{
			NextStep = "Step5aMapNames";
		}

		private void rNo_CheckedChanged(object sender, EventArgs e)
		{
			NextStep = "Step6Images";
		}

		private void pwStep5CustomMap_ValidateStep(object sender, CancelEventArgs e)
		{
			(Wizard as ProfileWizard).Profile.Travel.CustomMaps = rYes.Checked;
		}
	}
}