#region Header
// /*
//  *    2018 - Pandora - pwStep5aMapNames.cs
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
	public class pwStep5MapNames : BaseInteriorStep
	{
		private Label label1;
		private CheckBox chk0;
		private CheckBox chk1;
		private CheckBox chk2;
		private CheckBox chk3;
		private TextBox tx0;
		private TextBox tx1;
		private TextBox tx2;
		private TextBox tx3;
		private CheckBox chk4;
		private TextBox tx4;
		private readonly IContainer components = null;

		public pwStep5MapNames()
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
			this.chk0 = new System.Windows.Forms.CheckBox();
			this.chk1 = new System.Windows.Forms.CheckBox();
			this.chk2 = new System.Windows.Forms.CheckBox();
			this.chk3 = new System.Windows.Forms.CheckBox();
			this.tx0 = new System.Windows.Forms.TextBox();
			this.tx1 = new System.Windows.Forms.TextBox();
			this.tx2 = new System.Windows.Forms.TextBox();
			this.tx3 = new System.Windows.Forms.TextBox();
			this.chk4 = new System.Windows.Forms.CheckBox();
			this.tx4 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Name = "Description";
			this.Description.Text = "WizProfile.NamesDescription";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 64);
			this.label1.TabIndex = 1;
			this.label1.Text = "WizProfile.NameMaps";
			// 
			// chk0
			// 
			this.chk0.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk0.Location = new System.Drawing.Point(40, 80);
			this.chk0.Name = "chk0";
			this.chk0.Size = new System.Drawing.Size(40, 24);
			this.chk0.TabIndex = 2;
			this.chk0.Text = "0";
			this.chk0.CheckedChanged += new System.EventHandler(this.chk0_CheckedChanged);
			// 
			// chk1
			// 
			this.chk1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk1.Location = new System.Drawing.Point(40, 104);
			this.chk1.Name = "chk1";
			this.chk1.Size = new System.Drawing.Size(40, 24);
			this.chk1.TabIndex = 3;
			this.chk1.Text = "1";
			this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
			// 
			// chk2
			// 
			this.chk2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk2.Location = new System.Drawing.Point(40, 128);
			this.chk2.Name = "chk2";
			this.chk2.Size = new System.Drawing.Size(40, 24);
			this.chk2.TabIndex = 4;
			this.chk2.Text = "2";
			this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
			// 
			// chk3
			// 
			this.chk3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk3.Location = new System.Drawing.Point(40, 152);
			this.chk3.Name = "chk3";
			this.chk3.Size = new System.Drawing.Size(40, 24);
			this.chk3.TabIndex = 5;
			this.chk3.Text = "3";
			this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
			// 
			// tx0
			// 
			this.tx0.Enabled = false;
			this.tx0.Location = new System.Drawing.Point(80, 80);
			this.tx0.Name = "tx0";
			this.tx0.Size = new System.Drawing.Size(152, 20);
			this.tx0.TabIndex = 6;
			this.tx0.Text = "Felucca";
			this.tx0.TextChanged += new System.EventHandler(this.tx0_TextChanged);
			// 
			// tx1
			// 
			this.tx1.Enabled = false;
			this.tx1.Location = new System.Drawing.Point(80, 104);
			this.tx1.Name = "tx1";
			this.tx1.Size = new System.Drawing.Size(152, 20);
			this.tx1.TabIndex = 7;
			this.tx1.Text = "Trammel";
			this.tx1.TextChanged += new System.EventHandler(this.tx1_TextChanged);
			// 
			// tx2
			// 
			this.tx2.Enabled = false;
			this.tx2.Location = new System.Drawing.Point(80, 128);
			this.tx2.Name = "tx2";
			this.tx2.Size = new System.Drawing.Size(152, 20);
			this.tx2.TabIndex = 8;
			this.tx2.Text = "Ilshenar";
			this.tx2.TextChanged += new System.EventHandler(this.tx2_TextChanged);
			// 
			// tx3
			// 
			this.tx3.Enabled = false;
			this.tx3.Location = new System.Drawing.Point(80, 152);
			this.tx3.Name = "tx3";
			this.tx3.Size = new System.Drawing.Size(152, 20);
			this.tx3.TabIndex = 9;
			this.tx3.Text = "Malas";
			this.tx3.TextChanged += new System.EventHandler(this.tx3_TextChanged);
			// 
			// chk4
			// 
			this.chk4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk4.Location = new System.Drawing.Point(40, 176);
			this.chk4.Name = "chk4";
			this.chk4.Size = new System.Drawing.Size(40, 24);
			this.chk4.TabIndex = 10;
			this.chk4.Text = "4";
			this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
			// 
			// tx4
			// 
			this.tx4.Enabled = false;
			this.tx4.Location = new System.Drawing.Point(80, 176);
			this.tx4.Name = "tx4";
			this.tx4.Size = new System.Drawing.Size(152, 20);
			this.tx4.TabIndex = 11;
			this.tx4.Text = "Tokuno";
			this.tx4.TextChanged += new System.EventHandler(this.tx4_TextChanged);
			// 
			// pwStep5MapNames
			// 
			this.Controls.Add(this.tx4);
			this.Controls.Add(this.chk4);
			this.Controls.Add(this.tx3);
			this.Controls.Add(this.tx2);
			this.Controls.Add(this.tx1);
			this.Controls.Add(this.tx0);
			this.Controls.Add(this.chk3);
			this.Controls.Add(this.chk2);
			this.Controls.Add(this.chk1);
			this.Controls.Add(this.chk0);
			this.Controls.Add(this.label1);
			this.Name = "pwStep5MapNames";
			this.NextStep = "Step6Images";
			this.PreviousStep = "Step5CustomMap";
			this.StepDescription = "WizProfile.NamesDescription";
			this.StepTitle = "WizProfile.NamesTitle";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.pwStep6Images_ValidateStep);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.chk0, 0);
			this.Controls.SetChildIndex(this.chk1, 0);
			this.Controls.SetChildIndex(this.chk2, 0);
			this.Controls.SetChildIndex(this.chk3, 0);
			this.Controls.SetChildIndex(this.tx0, 0);
			this.Controls.SetChildIndex(this.Description, 0);
			this.Controls.SetChildIndex(this.tx1, 0);
			this.Controls.SetChildIndex(this.tx2, 0);
			this.Controls.SetChildIndex(this.tx3, 0);
			this.Controls.SetChildIndex(this.chk4, 0);
			this.Controls.SetChildIndex(this.tx4, 0);
			this.ResumeLayout(false);
		}
		#endregion

		private void chk0_CheckedChanged(object sender, EventArgs e)
		{
			tx0.Enabled = chk0.Checked;
			m_EnabledMaps[0] = chk0.Checked;
		}

		private void chk1_CheckedChanged(object sender, EventArgs e)
		{
			tx1.Enabled = chk1.Checked;
			m_EnabledMaps[1] = chk1.Checked;
		}

		private void chk2_CheckedChanged(object sender, EventArgs e)
		{
			tx2.Enabled = chk2.Checked;
			m_EnabledMaps[2] = chk2.Checked;
		}

		private void chk3_CheckedChanged(object sender, EventArgs e)
		{
			tx3.Enabled = chk3.Checked;
			m_EnabledMaps[3] = chk3.Checked;
		}

		private readonly bool[] m_EnabledMaps = {false, false, false, false, false};
		private readonly string[] m_MapNames = {"Felucca", "Trammel", "Ilshenar", "Malas", "Tokuno"};

		public bool[] EnabledMaps { get { return m_EnabledMaps; } }

		public string[] MapNames { get { return m_MapNames; } }

		private void pwStep6Images_ValidateStep(object sender, CancelEventArgs e)
		{
			var wiz = Wizard as ProfileWizard;

			for (var i = 0; i < 5; i++)
			{
				wiz.Profile.Travel.EnabledMaps[i] = m_EnabledMaps[i];
				wiz.Profile.Travel.MapNames[i] = m_MapNames[i];

				if (m_EnabledMaps[i])
				{
					if (m_MapNames[i] == "")
					{
						e.Cancel = true;
						MessageBox.Show(ProfileWizard.TextProvider["WizProfile.NeedMapName"]);
						break;
					}
				}
			}
		}

		private void tx0_TextChanged(object sender, EventArgs e)
		{
			m_MapNames[0] = tx0.Text;
		}

		private void tx1_TextChanged(object sender, EventArgs e)
		{
			m_MapNames[1] = tx1.Text;
		}

		private void tx2_TextChanged(object sender, EventArgs e)
		{
			m_MapNames[2] = tx2.Text;
		}

		private void tx3_TextChanged(object sender, EventArgs e)
		{
			m_MapNames[3] = tx3.Text;
		}

		private void chk4_CheckedChanged(object sender, EventArgs e)
		{
			tx4.Enabled = chk4.Checked;
			m_EnabledMaps[4] = chk4.Checked;
		}

		private void tx4_TextChanged(object sender, EventArgs e)
		{
			m_MapNames[4] = tx4.Text;
		}
	}
}