#region Header
// /*
//  *    2018 - Pandora - AboutForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for AboutForm.
	/// </summary>
	public class AboutForm : Form
	{
		private Button bClose;
		private PictureBox pictureBox1;
		private Panel pnl;
		private Panel panel1;
		private Label label2;
		private Label labVersion;
		private LinkLabel linkLabel1;
		private GroupBox groupBox1;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private GroupBox groupBox2;
		private Label label1;
		private LinkLabel Arya;
		private LinkLabel linkLabelTarion;
		private Label lblLog4Net;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			labVersion.Text = Application.ProductVersion;
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.bClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnl = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Arya = new System.Windows.Forms.LinkLabel();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.labVersion = new System.Windows.Forms.Label();
			this.linkLabelTarion = new System.Windows.Forms.LinkLabel();
			this.lblLog4Net = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pnl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bClose
			// 
			this.bClose.Anchor =
			((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom |
												  System.Windows.Forms.AnchorStyles.Right)));
			this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClose.Location = new System.Drawing.Point(346, 152);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(75, 23);
			this.bClose.TabIndex = 7;
			this.bClose.Text = "Close";
			this.bClose.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(446, 55);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// pnl
			// 
			this.pnl.Anchor =
			((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
													System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) |
												  System.Windows.Forms.AnchorStyles.Right)));
			this.pnl.BackColor = System.Drawing.Color.Black;
			this.pnl.Controls.Add(this.panel1);
			this.pnl.Location = new System.Drawing.Point(12, 89);
			this.pnl.Name = "pnl";
			this.pnl.Size = new System.Drawing.Size(446, 215);
			this.pnl.TabIndex = 11;
			this.pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Paint);
			// 
			// panel1
			// 
			this.panel1.Anchor =
			((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
													System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) |
												  System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.bClose);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(431, 194);
			this.panel1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor =
			((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
												   System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.linkLabelTarion);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(8, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(124, 146);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pandora\'s 3.0 staff:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 65);
			this.label1.TabIndex = 0;
			this.label1.Text = "- Smjert\r\n- Kons\r\n- Neo\r\n- Dies Irae\r\n- Tarion";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor =
			((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
												   System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.lblLog4Net);
			this.groupBox1.Controls.Add(this.Arya);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(149, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 146);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Credits till 2.0";
			// 
			// Arya
			// 
			this.Arya.AutoSize = true;
			this.Arya.Location = new System.Drawing.Point(9, 32);
			this.Arya.Name = "Arya";
			this.Arya.Size = new System.Drawing.Size(126, 13);
			this.Arya.TabIndex = 9;
			this.Arya.TabStop = true;
			this.Arya.Text = "http://arya.altervista.org/";
			this.Arya.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Arya_LinkClicked);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label14.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))),
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.label14.Location = new System.Drawing.Point(9, 112);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 13);
			this.label14.TabIndex = 11;
			this.label14.Text = "ZLib";
			this.label14.Click += new System.EventHandler(this.label14_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label13.Location = new System.Drawing.Point(80, 99);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(93, 13);
			this.label13.TabIndex = 10;
			this.label13.Text = "James T. Johnson";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.label12.Location = new System.Drawing.Point(6, 99);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 13);
			this.label12.TabIndex = 9;
			this.label12.Text = "TSWizard";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label6.Location = new System.Drawing.Point(76, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Knightshade";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label11.Location = new System.Drawing.Point(80, 86);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(84, 13);
			this.label11.TabIndex = 8;
			this.label11.Text = "Krrios - Malganis";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Underline,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label10.Location = new System.Drawing.Point(6, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(144, 16);
			this.label10.TabIndex = 7;
			this.label10.Text = "Third party libraries";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.label9.Location = new System.Drawing.Point(6, 86);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Ultima.dll";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label8.Location = new System.Drawing.Point(80, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 5;
			this.label8.Text = "Arya";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "Code";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.label5.Location = new System.Drawing.Point(9, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Artwork:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(128)))),
				((int)(((byte)(128)))),
				((int)(((byte)(255)))));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.linkLabel1.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(41, 38);
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.linkLabel1.Location = new System.Drawing.Point(8, 6);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(413, 17);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Tag = "http://code.google.com/p/pandorasbox3/";
			this.linkLabel1.Text = "Updates-bugs report-features requests :  http://code.google.com/p/pandorasbox3/";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(141, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "Version :";
			// 
			// labVersion
			// 
			this.labVersion.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.labVersion.Location = new System.Drawing.Point(210, 70);
			this.labVersion.Name = "labVersion";
			this.labVersion.Size = new System.Drawing.Size(109, 16);
			this.labVersion.TabIndex = 13;
			this.labVersion.Text = "9.0.21022.8";
			// 
			// linkLabelTarion
			// 
			this.linkLabelTarion.AutoSize = true;
			this.linkLabelTarion.Location = new System.Drawing.Point(68, 70);
			this.linkLabelTarion.Name = "linkLabelTarion";
			this.linkLabelTarion.Size = new System.Drawing.Size(43, 13);
			this.linkLabelTarion.TabIndex = 10;
			this.linkLabelTarion.TabStop = true;
			this.linkLabelTarion.Text = "website";
			this.linkLabelTarion.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTarion_LinkClicked);
			// 
			// lblLog4Net
			// 
			this.lblLog4Net.AutoSize = true;
			this.lblLog4Net.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLog4Net.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))),
				System.Drawing.GraphicsUnit.Point,
				((byte)(0)));
			this.lblLog4Net.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(192)))));
			this.lblLog4Net.Location = new System.Drawing.Point(9, 125);
			this.lblLog4Net.Name = "lblLog4Net";
			this.lblLog4Net.Size = new System.Drawing.Size(55, 13);
			this.lblLog4Net.TabIndex = 12;
			this.lblLog4Net.Text = "Log4Net";
			this.lblLog4Net.Click += new System.EventHandler(this.lblLog4Net_Click);
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(473, 315);
			this.Controls.Add(this.labVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnl);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pandora\'s Box";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.AboutForm_Paint);
			this.Closed += new System.EventHandler(this.AboutForm_Closed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pnl.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AboutForm_Paint(object sender, PaintEventArgs e)
		{
			using (var pen = new Pen(Color.Black))
			{
				e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			}
		}

		private void pnl_Paint(object sender, PaintEventArgs e)
		{
			using (var pen = new Pen(Color.White))
			{
				e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 3, pnl.Height - 3);
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var lnk = sender as LinkLabel;

			if (lnk == null || lnk.Tag == null || !(lnk.Tag is string))
				return;

			var url = lnk.Tag as string;

			Process.Start(url);
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.servuo.com/");
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.vita-nex.com/");
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.uogateway.com/");
		}

		private void label14_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.gzip.org/zlib/");
		}

		private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.phantasya.org/");
		}

		private void Arya_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Issue 34:  	 Visit Website - Tarion
			Process.Start("http://www.github.com/vita-nex/pandora");
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			if (Pandora.BoxForm != null)
				Pandora.BoxForm.Visible = false;
		}

		private void AboutForm_Closed(object sender, EventArgs e)
		{
			if (Pandora.BoxForm != null)
				Pandora.BoxForm.Visible = true;
		}

		private void linkLabelTarion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.niondir.de/");
		}

		private void lblLog4Net_Click(object sender, EventArgs e)
		{
			Process.Start("http://logging.apache.org/log4net/index.html");
		}
	}
}