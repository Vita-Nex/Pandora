#region Header
// /*
//  *    2018 - TravelAgent - MapIndexForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.TravelAgent
{
	/// <summary>
	///     Summary description for MapIndexForm.
	/// </summary>
	public class MapIndexForm : Form
	{
		private Label label1;
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private RadioButton radioButton3;
		private RadioButton radioButton4;
		private Button button1;
		private RadioButton radioButton5;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public MapIndexForm()
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
			var resources = new System.Resources.ResourceManager(typeof(MapIndexForm));
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please select the map ID for this datafile.";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(32, 48);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "0 : Felucca";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton2.Location = new System.Drawing.Point(32, 72);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "1: Trammel";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton3.Location = new System.Drawing.Point(32, 96);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 3;
			this.radioButton3.Text = "2: Ilshenar";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton4.Location = new System.Drawing.Point(32, 120);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.TabIndex = 4;
			this.radioButton4.Text = "3: Malas";
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(144, 184);
			this.button1.Name = "button1";
			this.button1.TabIndex = 5;
			this.button1.Text = "Select";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// radioButton5
			// 
			this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton5.Location = new System.Drawing.Point(32, 144);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.TabIndex = 6;
			this.radioButton5.Text = "4: Tokuno";
			this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// MapIndexForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 224);
			this.Controls.Add(this.radioButton5);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.radioButton4);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MapIndexForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MapIndexForm";
			this.ResumeLayout(false);
		}
		#endregion

		private int m_MapFile;

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			m_MapFile = 0;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			m_MapFile = 1;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			m_MapFile = 2;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			m_MapFile = 3;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			m_MapFile = 4;
		}

		public int MapFile { get { return m_MapFile; } }
	}
}