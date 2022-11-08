#region Header
// /*
//  *    2018 - BoxServerSetup - S5_Install.cs
//  */
#endregion

#region References
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace BoxServerSetup
{
	public class S5_Install : BaseInteriorStep
	{
		private ProgressBar PBar;
		private readonly IContainer components = null;

		public S5_Install()
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
			this.PBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "The wizard has finished collecting information and is now ready to update your sy" +
									"stem. Press Next to continue.";
			// 
			// PBar
			// 
			this.PBar.Location = new System.Drawing.Point(40, 200);
			this.PBar.Maximum = 7;
			this.PBar.Name = "PBar";
			this.PBar.Size = new System.Drawing.Size(392, 23);
			this.PBar.Step = 1;
			this.PBar.TabIndex = 2;
			// 
			// S5_Install
			// 
			this.Controls.Add(this.PBar);
			this.Name = "S5_Install";
			this.NextStep = "Finish";
			this.PreviousStep = "S4_Modules";
			this.StepDescription = "The wizard has finished collecting information and is now ready to update your sy" +
								   "stem. Press Next to continue.";
			this.StepTitle = "Install";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.S5_Install_ValidateStep);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.PBar, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void S5_Install_ValidateStep(object sender, CancelEventArgs e)
		{
			Setup.PerformInstall(PBar);
		}
	}
}