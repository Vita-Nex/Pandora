#region Header
// /*
//  *    2018 - Pandora - DateTimeControl.cs
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
	///     Summary description for DateTimeControl.
	/// </summary>
	public class DateTimeControl : UserControl
	{
		private DateTimePicker dateTimePicker1;
		private Button button1;
		private Label label1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public DateTimeControl()
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1.Location = new System.Drawing.Point(8, 40);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(88, 20);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(16, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "->";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Props.DateTime";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// DateTimeControl
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "DateTimeControl";
			this.Size = new System.Drawing.Size(104, 116);
			this.ResumeLayout(false);
		}
		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			Pandora.Prop.DisplayedValue = dateTimePicker1.Value.ToString();
		}
	}
}