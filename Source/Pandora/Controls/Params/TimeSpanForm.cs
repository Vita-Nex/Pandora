#region Header
// /*
//  *    2018 - Pandora - TimeSpanForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Summary description for TimeSpanForm.
	/// </summary>
	public class TimeSpanForm : Form
	{
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private NumericUpDown numDays;
		private NumericUpDown numHours;
		private NumericUpDown numMins;
		private NumericUpDown numSeconds;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public TimeSpanForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numDays = new System.Windows.Forms.NumericUpDown();
			this.numHours = new System.Windows.Forms.NumericUpDown();
			this.numMins = new System.Windows.Forms.NumericUpDown();
			this.numSeconds = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)this.numDays).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMins).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numSeconds).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 16);
			this.label5.TabIndex = 18;
			this.label5.Text = "Props.Seconds";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 16);
			this.label4.TabIndex = 17;
			this.label4.Text = "Props.Minutes";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Props.Hours";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "Props.Days";
			// 
			// numDays
			// 
			this.numDays.Location = new System.Drawing.Point(56, 4);
			this.numDays.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numDays.Name = "numDays";
			this.numDays.Size = new System.Drawing.Size(52, 20);
			this.numDays.TabIndex = 14;
			this.numDays.ValueChanged += new System.EventHandler(this.numDays_ValueChanged);
			// 
			// numHours
			// 
			this.numHours.Location = new System.Drawing.Point(56, 24);
			this.numHours.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numHours.Name = "numHours";
			this.numHours.Size = new System.Drawing.Size(52, 20);
			this.numHours.TabIndex = 13;
			this.numHours.ValueChanged += new System.EventHandler(this.numHours_ValueChanged);
			// 
			// numMins
			// 
			this.numMins.Location = new System.Drawing.Point(56, 44);
			this.numMins.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numMins.Name = "numMins";
			this.numMins.Size = new System.Drawing.Size(52, 20);
			this.numMins.TabIndex = 12;
			this.numMins.ValueChanged += new System.EventHandler(this.numMins_ValueChanged);
			// 
			// numSeconds
			// 
			this.numSeconds.Location = new System.Drawing.Point(56, 64);
			this.numSeconds.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			this.numSeconds.Name = "numSeconds";
			this.numSeconds.Size = new System.Drawing.Size(52, 20);
			this.numSeconds.TabIndex = 11;
			this.numSeconds.ValueChanged += new System.EventHandler(this.numSeconds_ValueChanged);
			// 
			// TimeSpanForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(112, 88);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numDays);
			this.Controls.Add(this.numHours);
			this.Controls.Add(this.numMins);
			this.Controls.Add(this.numSeconds);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "TimeSpanForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeSpanForm_Paint);
			this.Leave += new System.EventHandler(this.TimeSpanForm_Leave);
			this.Deactivate += new System.EventHandler(this.TimeSpanForm_Deactivate);
			((System.ComponentModel.ISupportInitialize)this.numDays).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numHours).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMins).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numSeconds).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private int m_Days;
		private int m_Hours;
		private int m_Minutes;
		private int m_Seconds;

		/// <summary>
		///     Gets the selected TimeSpan
		/// </summary>
		public TimeSpan TimeSpan
		{
			get => new TimeSpan(m_Days, m_Hours, m_Minutes, m_Seconds, 0);
			set
			{
				numDays.Value = value.Days;
				m_Days = value.Days;

				numHours.Value = value.Hours;
				m_Hours = value.Hours;

				numMins.Value = value.Minutes;
				m_Minutes = value.Minutes;

				numSeconds.Value = value.Seconds;
				m_Seconds = value.Seconds;
			}
		}

		private void numDays_ValueChanged(object sender, EventArgs e)
		{
			m_Days = (int)numDays.Value;
		}

		private void numHours_ValueChanged(object sender, EventArgs e)
		{
			m_Hours = (int)numHours.Value;
		}

		private void numMins_ValueChanged(object sender, EventArgs e)
		{
			m_Minutes = (int)numMins.Value;
		}

		private void numSeconds_ValueChanged(object sender, EventArgs e)
		{
			m_Seconds = (int)numSeconds.Value;
		}

		private void TimeSpanForm_Deactivate(object sender, EventArgs e)
		{
			Close();
		}

		private void TimeSpanForm_Leave(object sender, EventArgs e)
		{
			Close();
		}

		private void TimeSpanForm_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			pen.Dispose();
		}
	}
}