#region Header
// /*
//  *    2018 - Pandora - pwStep7End.cs
//  */
#endregion

#region References
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace TheBox.Forms.ProfileWizard
{
	public class pwStep7End : BaseExteriorStep
	{
		private CheckBox chkDefault;
		private readonly IContainer components = null;

		public pwStep7End()
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

		private void pwStep7End_ValidateStep(object sender, CancelEventArgs e)
		{
			var wiz = Wizard as ProfileWizard;
			wiz.UseProfileAsDefault = chkDefault.Checked;
			wiz.Succesful = true;

			/*
			if (chkDefault.Checked)
			{
				// Default profile
				_profileManager.DefaultProfile = wiz.Profile.Name;
			}*/

			Pandora.Log.WriteEntry("pwStep7End_ValidateStep not saving the porfile now!");
			/*
			profile = wiz.Profile;
			profile.Save();
			profile.CreateData();
			 * */
		}

		#region Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chkDefault = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Size = new System.Drawing.Size(308, 72);
			this.Description.Text = "WizProfile.EndDescription";
			// 
			// chkDefault
			// 
			this.chkDefault.Location = new System.Drawing.Point(40, 272);
			this.chkDefault.Name = "chkDefault";
			this.chkDefault.Size = new System.Drawing.Size(248, 24);
			this.chkDefault.TabIndex = 1;
			this.chkDefault.Text = "WizProfile.DefaultProfile";
			// 
			// pwStep7End
			// 
			this.Controls.Add(this.chkDefault);
			this.IsFinished = true;
			this.Name = "pwStep7End";
			this.NextStep = "FINISHED";
			this.PreviousStep = "Step6Images";
			this.StepDescription = "WizProfile.EndDescription";
			this.StepTitle = "WizProfile.EndTitle";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.pwStep7End_ValidateStep);
			this.Controls.SetChildIndex(this.chkDefault, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.ResumeLayout(false);
		}
		#endregion
	}
}