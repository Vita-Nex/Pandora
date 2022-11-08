#region Header
// /*
//  *    2018 - BoxServerSetup - Introduction.cs
//  */
#endregion

#region References
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace BoxServerSetup
{
	public class Introduction : BaseExteriorStep
	{
		private Label label1;
		private readonly IContainer components = null;

		public Introduction()
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
			this.Description.Text = "Welcome to the BoxServer installation wizard.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 216);
			this.label1.TabIndex = 1;
			this.label1.Text =
				@"This wizard will guide you through the installation process for BoxServer, a set of scripts designed for the RunUO platform. These scripts are provided with no warranties, even if they are believed to be stable. For more information on BoxServer stability, security and features, please review the documentation in the installation folder.";
			// 
			// Introduction
			// 
			this.Controls.Add(this.label1);
			this.Name = "Introduction";
			this.NextStep = "S1_Folder";
			this.StepDescription = "Welcome to the BoxServer installation wizard.";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.ResumeLayout(false);
		}
		#endregion
	}
}