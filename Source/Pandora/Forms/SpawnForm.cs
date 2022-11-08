#region Header
// /*
//  *    2018 - Pandora - SpawnForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for SpawnForm.
	/// </summary>
	public class SpawnForm : Form
	{
		private NumericUpDown nRange2;
		private NumericUpDown nTeam;
		private NumericUpDown nMaxDelay;
		private NumericUpDown nMinDelay;
		private NumericUpDown nRange;
		private NumericUpDown nAmount;
		private Label label5;
		private Label label4;
		private Label label2;
		private Label label1;
		private Label label6;
		private Button button1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public SpawnForm()
		{
			InitializeComponent();
			Pandora.Localization.LocalizeControl(this);
		}

		/// <summary>
		///     Gets or sets the spawn amount
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		///     Gets or sets the spawn range
		/// </summary>
		public int Range { get; set; }

		/// <summary>
		///     Gets or sets the spawn min delay
		/// </summary>
		public int MinDelay { get; set; }

		/// <summary>
		///     Gets or sets the spawn max delay
		/// </summary>
		public int MaxDelay { get; set; }

		/// <summary>
		///     Gets or sets the spawn team
		/// </summary>
		public int Team { get; set; }

		/// <summary>
		///     Gets or sets the spawn extra value
		/// </summary>
		public int Extra { get; set; }

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

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			var resources = new System.Resources.ResourceManager(typeof(SpawnForm));
			this.nRange2 = new System.Windows.Forms.NumericUpDown();
			this.nTeam = new System.Windows.Forms.NumericUpDown();
			this.nMaxDelay = new System.Windows.Forms.NumericUpDown();
			this.nMinDelay = new System.Windows.Forms.NumericUpDown();
			this.nRange = new System.Windows.Forms.NumericUpDown();
			this.nAmount = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.nRange2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nTeam).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nMaxDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nMinDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nRange).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nAmount).BeginInit();
			this.SuspendLayout();
			// 
			// nRange2
			// 
			this.nRange2.Location = new System.Drawing.Point(60, 88);
			this.nRange2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nRange2.Name = "nRange2";
			this.nRange2.Size = new System.Drawing.Size(48, 20);
			this.nRange2.TabIndex = 30;
			this.nRange2.ValueChanged += new System.EventHandler(this.nRange2_ValueChanged);
			// 
			// nTeam
			// 
			this.nTeam.Location = new System.Drawing.Point(4, 88);
			this.nTeam.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nTeam.Name = "nTeam";
			this.nTeam.Size = new System.Drawing.Size(48, 20);
			this.nTeam.TabIndex = 29;
			this.nTeam.ValueChanged += new System.EventHandler(this.nTeam_ValueChanged);
			// 
			// nMaxDelay
			// 
			this.nMaxDelay.Location = new System.Drawing.Point(60, 52);
			this.nMaxDelay.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.nMaxDelay.Name = "nMaxDelay";
			this.nMaxDelay.Size = new System.Drawing.Size(48, 20);
			this.nMaxDelay.TabIndex = 28;
			this.nMaxDelay.ValueChanged += new System.EventHandler(this.nMaxDelay_ValueChanged);
			// 
			// nMinDelay
			// 
			this.nMinDelay.Location = new System.Drawing.Point(4, 52);
			this.nMinDelay.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.nMinDelay.Name = "nMinDelay";
			this.nMinDelay.Size = new System.Drawing.Size(48, 20);
			this.nMinDelay.TabIndex = 27;
			this.nMinDelay.ValueChanged += new System.EventHandler(this.nMinDelay_ValueChanged);
			// 
			// nRange
			// 
			this.nRange.Location = new System.Drawing.Point(60, 16);
			this.nRange.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nRange.Name = "nRange";
			this.nRange.Size = new System.Drawing.Size(48, 20);
			this.nRange.TabIndex = 26;
			this.nRange.ValueChanged += new System.EventHandler(this.nRange_ValueChanged);
			// 
			// nAmount
			// 
			this.nAmount.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0);
			this.nAmount.Location = new System.Drawing.Point(4, 16);
			this.nAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nAmount.Name = "nAmount";
			this.nAmount.Size = new System.Drawing.Size(48, 20);
			this.nAmount.TabIndex = 25;
			this.nAmount.ValueChanged += new System.EventHandler(this.nAmount_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 76);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 24;
			this.label5.Text = "NPCs.Team";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(60, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = "NPCs.Range";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 22;
			this.label2.Text = "NPCs.MinTime";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "NPCs.Amount";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(60, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 31;
			this.label6.Text = "NPCs.SpawnRange";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(20, 112);
			this.button1.Name = "button1";
			this.button1.TabIndex = 32;
			this.button1.Text = "NPCs.Spawn";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// SpawnForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(112, 140);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.nRange2);
			this.Controls.Add(this.nTeam);
			this.Controls.Add(this.nMaxDelay);
			this.Controls.Add(this.nMinDelay);
			this.Controls.Add(this.nRange);
			this.Controls.Add(this.nAmount);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "SpawnForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "SpawnForm";
			this.Load += new System.EventHandler(this.SpawnForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpawnForm_Paint);
			this.Leave += new System.EventHandler(this.SpawnForm_Leave);
			this.Deactivate += new System.EventHandler(this.SpawnForm_Deactivate);
			((System.ComponentModel.ISupportInitialize)this.nRange2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nTeam).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nMaxDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nMinDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nRange).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nAmount).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void SpawnForm_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			pen.Dispose();
		}

		private void nAmount_ValueChanged(object sender, EventArgs e)
		{
			Amount = (int)nAmount.Value;
		}

		private void nRange_ValueChanged(object sender, EventArgs e)
		{
			Range = (int)nRange.Value;
		}

		private void nMinDelay_ValueChanged(object sender, EventArgs e)
		{
			MinDelay = (int)nMinDelay.Value;
		}

		private void nMaxDelay_ValueChanged(object sender, EventArgs e)
		{
			MaxDelay = (int)nMaxDelay.Value;
		}

		private void nTeam_ValueChanged(object sender, EventArgs e)
		{
			Team = (int)nTeam.Value;
		}

		private void nRange2_ValueChanged(object sender, EventArgs e)
		{
			Extra = (int)nRange2.Value;
		}

		private void SpawnForm_Load(object sender, EventArgs e)
		{
			nAmount.Value = Amount;
			nRange.Value = Range;
			nMinDelay.Value = MinDelay;
			nMaxDelay.Value = MaxDelay;
			nTeam.Value = Team;
			nRange2.Value = Extra;
		}

		private void SpawnForm_Leave(object sender, EventArgs e)
		{
			Close();
		}

		private void SpawnForm_Deactivate(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		///     Occurs when the user clicks the Spawn button
		/// </summary>
		public event EventHandler OnSpawn;

		private void button1_Click(object sender, EventArgs e)
		{
			OnSpawn?.Invoke(this, new EventArgs());

			Close();
		}
	}
}