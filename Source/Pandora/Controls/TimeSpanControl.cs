#region Header
// /*
//  *    2018 - Pandora - TimeSpanControl.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for TimeSpanControl.
	/// </summary>
	public class TimeSpanControl : UserControl
	{
		private NumericUpDown numSeconds;
		private NumericUpDown numMins;
		private NumericUpDown numHours;
		private NumericUpDown numDays;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Button bSet;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public TimeSpanControl()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numSeconds = new System.Windows.Forms.NumericUpDown();
			this.numMins = new System.Windows.Forms.NumericUpDown();
			this.numHours = new System.Windows.Forms.NumericUpDown();
			this.numDays = new System.Windows.Forms.NumericUpDown();
			this.bSet = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.numSeconds).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMins).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numDays).BeginInit();
			this.SuspendLayout();
			// 
			// numSeconds
			// 
			this.numSeconds.Location = new System.Drawing.Point(52, 64);
			this.numSeconds.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numSeconds.Name = "numSeconds";
			this.numSeconds.Size = new System.Drawing.Size(52, 20);
			this.numSeconds.TabIndex = 1;
			this.numSeconds.ValueChanged += new System.EventHandler(this.numSeconds_ValueChanged);
			// 
			// numMins
			// 
			this.numMins.Location = new System.Drawing.Point(52, 44);
			this.numMins.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numMins.Name = "numMins";
			this.numMins.Size = new System.Drawing.Size(52, 20);
			this.numMins.TabIndex = 2;
			this.numMins.ValueChanged += new System.EventHandler(this.numMins_ValueChanged);
			// 
			// numHours
			// 
			this.numHours.Location = new System.Drawing.Point(52, 24);
			this.numHours.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numHours.Name = "numHours";
			this.numHours.Size = new System.Drawing.Size(52, 20);
			this.numHours.TabIndex = 3;
			this.numHours.ValueChanged += new System.EventHandler(this.numHours_ValueChanged);
			// 
			// numDays
			// 
			this.numDays.Location = new System.Drawing.Point(52, 4);
			this.numDays.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numDays.Name = "numDays";
			this.numDays.Size = new System.Drawing.Size(52, 20);
			this.numDays.TabIndex = 4;
			this.numDays.ValueChanged += new System.EventHandler(this.numDays_ValueChanged);
			// 
			// bSet
			// 
			this.bSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSet.Location = new System.Drawing.Point(60, 92);
			this.bSet.Name = "bSet";
			this.bSet.Size = new System.Drawing.Size(36, 16);
			this.bSet.TabIndex = 5;
			this.bSet.Text = "->";
			this.bSet.Click += new System.EventHandler(this.bSet_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Props.TimeSpan";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Props.Days";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Props.Hours";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Props.Minutes";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Props.Seconds";
			// 
			// TimeSpanControl
			// 
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bSet);
			this.Controls.Add(this.numDays);
			this.Controls.Add(this.numHours);
			this.Controls.Add(this.numMins);
			this.Controls.Add(this.numSeconds);
			this.Name = "TimeSpanControl";
			this.Size = new System.Drawing.Size(104, 116);
			this.Load += new System.EventHandler(this.TimeSpanControl_Load);
			((System.ComponentModel.ISupportInitialize)this.numSeconds).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMins).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numHours).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numDays).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		#region Update Options
		private void numDays_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.Days = (int)numDays.Value;
		}

		private void numHours_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.Hours = (int)numHours.Value;
		}

		private void numMins_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.Minutes = (int)numMins.Value;
		}

		private void numSeconds_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.Seconds = (int)numSeconds.Value;
		}
		#endregion

		private void TimeSpanControl_Load(object sender, EventArgs e)
		{
			try
			{
				var p = Pandora.Profile.Props;

				numDays.Value = p.Days;
				numHours.Value = p.Hours;
				numMins.Value = p.Minutes;
				numSeconds.Value = p.Seconds;
			}
			catch
			{
				// Avoid conflicts with VS
			}
		}

		/// <summary>
		///     Gets the TimeSpan selected on the control
		/// </summary>
		public TimeSpan SelectedTimeSpan
		{
			get
			{
				var p = Pandora.Profile.Props;

				return new TimeSpan(p.Days, p.Hours, p.Minutes, p.Seconds, 0);
			}
		}

		private void bSet_Click(object sender, EventArgs e)
		{
			Pandora.Prop.DisplayedValue = SelectedTimeSpan.ToString();
			Pandora.BoxForm.SelectSmallTab(SmallTabs.Props);
		}
	}
}