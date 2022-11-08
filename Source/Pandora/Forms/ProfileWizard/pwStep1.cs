#region Header
// /*
//  *    2018 - Pandora - pwStep1.cs
//  */
#endregion

#region References
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace TheBox.Forms.ProfileWizard
{
	public class pwStep1 : BaseExteriorStep
	{
		private Label label1;
		private readonly IContainer components = null;

		public pwStep1()
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
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "WizProfile.Welcome";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 192);
			this.label1.TabIndex = 1;
			this.label1.Text = "WizProfile.Explanation";
			// 
			// pwStep1
			// 
			this.Controls.Add(this.label1);
			this.Name = "pwStep1";
			this.NextStep = "Step3Name";
			this.StepDescription = "WizProfile.Welcome";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.ResumeLayout(false);
		}
		#endregion
	}
}