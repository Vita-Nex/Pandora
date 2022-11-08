#region Header
// /*
//  *    2018 - TravelAgent - PB1ImportForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace Box.Misc
{
	/// <summary>
	///     Summary description for PB1ImportForm.
	/// </summary>
	public class PB1ImportForm : Form
	{
		private Label label1;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public PB1ImportForm()
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
			var resources = new System.Resources.ResourceManager(typeof(PB1ImportForm));
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "You are importing a file from Pandora\'s Box 1 that doesn\'t contain map informatio" +
							   "n or that contains locations for different maps. Please select which map should " + "be extracted.";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(8, 56);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "Felucca";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(88, 56);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "Trammel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(168, 56);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "Ilshenar";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(248, 56);
			this.button4.Name = "button4";
			this.button4.TabIndex = 4;
			this.button4.Text = "Malas";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// PB1ImportForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 85);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "PB1ImportForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PB1ImportForm";
			this.ResumeLayout(false);
		}
		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			Map = 0;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Map = 1;
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Map = 2;
			Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Map = 3;
			Close();
		}

		public int Map { get; private set; }
	}
}