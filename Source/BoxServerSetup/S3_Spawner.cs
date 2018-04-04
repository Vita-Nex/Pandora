#region Header
// /*
//  *    2018 - BoxServerSetup - S3_Spawner.cs
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
	public class S3_Spawner : BaseInteriorStep
	{
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private RadioButton radioButton3;
		private Label labOther;
		private readonly IContainer components = null;

		public S3_Spawner()
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
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.labOther = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "Some parts of BoxServer are Spawner specific. Please select the spawner used on y" +
									"our shard:";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(56, 8);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(256, 24);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "RunUO default Spawner";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton2.Location = new System.Drawing.Point(56, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(256, 24);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "XmlSpawner";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton3.Location = new System.Drawing.Point(56, 56);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 3;
			this.radioButton3.Text = "Other spawner";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// labOther
			// 
			this.labOther.Location = new System.Drawing.Point(120, 88);
			this.labOther.Name = "labOther";
			this.labOther.Size = new System.Drawing.Size(304, 80);
			this.labOther.TabIndex = 4;
			this.labOther.Text = "This option will provide you with a template file located in [BoxServer]\\Core\\Spa" +
								 "wnerHelper.cs. You will have to review this file and follow the TODO comments in" +
								 " order for the Spawner related functions to behave properly.";
			this.labOther.Visible = false;
			// 
			// S3_Spawner
			// 
			this.Controls.Add(this.labOther);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Name = "S3_Spawner";
			this.NextStep = "S4_Modules";
			this.PreviousStep = "S2_BoxFolder";
			this.StepDescription = "Some parts of BoxServer are Spawner specific. Please select the spawner used on y" +
								   "our shard:";
			this.StepTitle = "Spawner selection";
			this.Controls.SetChildIndex(this.radioButton1, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.radioButton2, 0);
			this.Controls.SetChildIndex(this.radioButton3, 0);
			this.Controls.SetChildIndex(this.labOther, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
				Setup.Spawner = "Spawner";
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
				Setup.Spawner = "XmlSpawner";
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
				Setup.Spawner = "Other";

			labOther.Visible = radioButton3.Checked;
		}
	}
}