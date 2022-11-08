#region Header
// /*
//  *    2018 - Pandora - QuickHue.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Controls;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for QuickHue.
	/// </summary>
	public class QuickHue : Form
	{
		private HuesChart huesChart1;
		public ArtViewer.ArtViewer Art;
		private Button button1;
		private Label label1;
		private Button button2;
		private Button button3;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public QuickHue()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);
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
			var resources = new System.Resources.ResourceManager(typeof(QuickHue));
			this.huesChart1 = new TheBox.Controls.HuesChart();
			this.Art = new TheBox.ArtViewer.ArtViewer();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// huesChart1
			// 
			this.huesChart1.ColorTableIndex = 28;
			this.huesChart1.Location = new System.Drawing.Point(8, 8);
			this.huesChart1.Name = "huesChart1";
			this.huesChart1.SelectedIndex = 1;
			this.huesChart1.Size = new System.Drawing.Size(452, 302);
			this.huesChart1.TabIndex = 0;
			this.huesChart1.Text = "huesChart1";
			this.huesChart1.HueChanged += new System.EventHandler(this.huesChart1_HueChanged);
			// 
			// Art
			// 
			this.Art.Animate = true;
			this.Art.Art = TheBox.ArtViewer.Art.Items;
			this.Art.ArtIndex = 0;
			this.Art.Hue = 0;
			this.Art.Location = new System.Drawing.Point(472, 160);
			this.Art.Name = "Art";
			this.Art.ResizeTallItems = true;
			this.Art.RoomView = false;
			this.Art.ShowID = false;
			this.Art.Size = new System.Drawing.Size(160, 152);
			this.Art.TabIndex = 1;
			this.Art.Text = "artViewer1";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(560, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Common.Ok";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(472, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "HuePicker.SelHue";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(472, 40);
			this.button2.Name = "button2";
			this.button2.TabIndex = 4;
			this.button2.Text = "Common.Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(472, 128);
			this.button3.Name = "button3";
			this.button3.TabIndex = 5;
			this.button3.Text = "Common.None";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// QuickHue
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 317);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Art);
			this.Controls.Add(this.huesChart1);
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "QuickHue";
			this.Text = "HuePicker.Title";
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Gets the hue selected by the user
		/// </summary>
		public int Hue { get; private set; }

		private void huesChart1_HueChanged(object sender, EventArgs e)
		{
			Art.Hue = huesChart1.SelectedIndex;
			Hue = huesChart1.SelectedIndex;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Art.Hue = 0;
			Hue = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
