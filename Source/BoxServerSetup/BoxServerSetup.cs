#region Header
// /*
//  *    2018 - BoxServerSetup - BoxServerSetup.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TSWizards;
#endregion

namespace BoxServerSetup
{
	public class BoxServerSetup : BaseWizard
	{
		private readonly IContainer components = null;

		public BoxServerSetup()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			AddStep("Introduction", new Introduction());
			AddStep("S1_Folder", new S1_Folder());
			AddStep("S2_BoxFolder", new S2_BoxFolder());
			AddStep("S3_Spawner", new S3_Spawner());
			AddStep("S4_Modules", new S4_Modules());
			AddStep("S5_Install", new S5_Install());
			AddStep("Finish", new Finish());
		}

		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.Run(new BoxServerSetup());
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
			var resources = new System.Resources.ResourceManager(typeof(BoxServerSetup));
			// 
			// wizardTop
			// 
			this.wizardTop.Name = "wizardTop";
			// 
			// cancel
			// 
			this.cancel.Name = "cancel";
			// 
			// back
			// 
			this.back.Name = "back";
			// 
			// next
			// 
			this.next.Name = "next";
			// 
			// panelStep
			// 
			this.panelStep.BackColor = System.Drawing.SystemColors.Control;
			this.panelStep.DockPadding.All = 8;
			this.panelStep.Location = new System.Drawing.Point(0, 66);
			this.panelStep.Name = "panelStep";
			this.panelStep.Size = new System.Drawing.Size(488, 249);
			// 
			// BoxServerSetup
			// 
			this.AllowClose = TSWizards.AllowClose.Ask;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 355);
			this.FirstStepName = "Introduction";
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "BoxServerSetup";
			this.SideBarImage = (System.Drawing.Image)resources.GetObject("$this.SideBarImage");
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BoxServer Installation";
		}
		#endregion
	}
}