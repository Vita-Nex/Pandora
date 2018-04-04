#region Header
// /*
//  *    2018 - Pandora - RoofingForm.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Ultima;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Summary description for RoofingForm.
	/// </summary>
	public class RoofingForm : Form
	{
		private PictureBox pctImage;
		private GroupBox groupBox1;
		private CheckBox chkUp;
		private CheckBox chkTent;
		private CheckBox chkSlope;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private NumericUpDown n1X;
		private NumericUpDown n1Y;
		private NumericUpDown n2X;
		private NumericUpDown n2Y;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private LinkLabel lnkFromClient1;
		private LinkLabel lnkFromClient2;
		private ComboBox cmbSlope;
		private Button bAdd;
		private Button bRemove;
		private GroupBox groupBox4;
		private Label label5;
		private ComboBox cmbTiles;
		private Button bGenerate;
		private Button bTest;
		private Button bServerGenerate;
		private Button bServerControl;
		private Label label6;
		private Label label7;
		private Label label8;
		private NumericUpDown numHeight;
		private CheckBox chkHue;
		private Button bClearAll;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public RoofingForm()
		{
			InitializeComponent();
			Pandora.Localization.LocalizeControl(this);

			m_Roof = new Roof();
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_RoofTiles = new List<TileSet>();
			// Issue 10 - End
		}

		private readonly Roof m_Roof;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<TileSet> m_RoofTiles;
		// Issue 10 - End

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
			var resources = new System.Resources.ResourceManager(typeof(RoofingForm));
			this.pctImage = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bRemove = new System.Windows.Forms.Button();
			this.bAdd = new System.Windows.Forms.Button();
			this.cmbSlope = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lnkFromClient2 = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.n2Y = new System.Windows.Forms.NumericUpDown();
			this.n2X = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lnkFromClient1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.n1Y = new System.Windows.Forms.NumericUpDown();
			this.n1X = new System.Windows.Forms.NumericUpDown();
			this.chkSlope = new System.Windows.Forms.CheckBox();
			this.chkTent = new System.Windows.Forms.CheckBox();
			this.chkUp = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkHue = new System.Windows.Forms.CheckBox();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.bServerControl = new System.Windows.Forms.Button();
			this.bServerGenerate = new System.Windows.Forms.Button();
			this.bTest = new System.Windows.Forms.Button();
			this.bGenerate = new System.Windows.Forms.Button();
			this.cmbTiles = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.bClearAll = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.n2Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.n2X)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.n1Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.n1X)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// pctImage
			// 
			this.pctImage.BackColor = System.Drawing.Color.White;
			this.pctImage.Location = new System.Drawing.Point(4, 4);
			this.pctImage.Name = "pctImage";
			this.pctImage.Size = new System.Drawing.Size(240, 240);
			this.pctImage.TabIndex = 0;
			this.pctImage.TabStop = false;
			this.pctImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pctImage_Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bRemove);
			this.groupBox1.Controls.Add(this.bAdd);
			this.groupBox1.Controls.Add(this.cmbSlope);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.chkSlope);
			this.groupBox1.Controls.Add(this.chkTent);
			this.groupBox1.Controls.Add(this.chkUp);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(248, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(304, 136);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Roofing.NewSection";
			// 
			// bRemove
			// 
			this.bRemove.Enabled = false;
			this.bRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRemove.Location = new System.Drawing.Point(204, 108);
			this.bRemove.Name = "bRemove";
			this.bRemove.Size = new System.Drawing.Size(96, 23);
			this.bRemove.TabIndex = 7;
			this.bRemove.Text = "Roofing.Remove";
			this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
			// 
			// bAdd
			// 
			this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAdd.Location = new System.Drawing.Point(8, 108);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(96, 23);
			this.bAdd.TabIndex = 6;
			this.bAdd.Text = "Roofing.Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// cmbSlope
			// 
			this.cmbSlope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSlope.Enabled = false;
			this.cmbSlope.Location = new System.Drawing.Point(216, 80);
			this.cmbSlope.Name = "cmbSlope";
			this.cmbSlope.Size = new System.Drawing.Size(84, 21);
			this.cmbSlope.TabIndex = 5;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lnkFromClient2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.n2Y);
			this.groupBox3.Controls.Add(this.n2X);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(156, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(144, 60);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Roofing.Point2";
			// 
			// lnkFromClient2
			// 
			this.lnkFromClient2.Location = new System.Drawing.Point(4, 40);
			this.lnkFromClient2.Name = "lnkFromClient2";
			this.lnkFromClient2.Size = new System.Drawing.Size(136, 16);
			this.lnkFromClient2.TabIndex = 5;
			this.lnkFromClient2.TabStop = true;
			this.lnkFromClient2.Text = "Roofing.FromCli";
			this.lnkFromClient2.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFromClient1_LinkClicked);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "Common.X";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Common.Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// n2Y
			// 
			this.n2Y.Location = new System.Drawing.Point(88, 16);
			this.n2Y.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.n2Y.Name = "n2Y";
			this.n2Y.Size = new System.Drawing.Size(52, 20);
			this.n2Y.TabIndex = 2;
			// 
			// n2X
			// 
			this.n2X.Location = new System.Drawing.Point(20, 16);
			this.n2X.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.n2X.Name = "n2X";
			this.n2X.Size = new System.Drawing.Size(52, 20);
			this.n2X.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lnkFromClient1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.n1Y);
			this.groupBox2.Controls.Add(this.n1X);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 60);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Roofing.Point1";
			// 
			// lnkFromClient1
			// 
			this.lnkFromClient1.Location = new System.Drawing.Point(4, 40);
			this.lnkFromClient1.Name = "lnkFromClient1";
			this.lnkFromClient1.Size = new System.Drawing.Size(136, 16);
			this.lnkFromClient1.TabIndex = 4;
			this.lnkFromClient1.TabStop = true;
			this.lnkFromClient1.Text = "Roofing.FromCli";
			this.lnkFromClient1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFromClient1_LinkClicked);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Common.Y";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Common.X";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// n1Y
			// 
			this.n1Y.Location = new System.Drawing.Point(88, 16);
			this.n1Y.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.n1Y.Name = "n1Y";
			this.n1Y.Size = new System.Drawing.Size(52, 20);
			this.n1Y.TabIndex = 1;
			// 
			// n1X
			// 
			this.n1X.Location = new System.Drawing.Point(20, 16);
			this.n1X.Maximum = new System.Decimal(new int[] {10000, 0, 0, 0});
			this.n1X.Name = "n1X";
			this.n1X.Size = new System.Drawing.Size(52, 20);
			this.n1X.TabIndex = 0;
			// 
			// chkSlope
			// 
			this.chkSlope.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkSlope.Location = new System.Drawing.Point(148, 80);
			this.chkSlope.Name = "chkSlope";
			this.chkSlope.Size = new System.Drawing.Size(68, 24);
			this.chkSlope.TabIndex = 2;
			this.chkSlope.Text = "Roofing.Slope";
			this.chkSlope.CheckedChanged += new System.EventHandler(this.chkSlope_CheckedChanged);
			// 
			// chkTent
			// 
			this.chkTent.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkTent.Location = new System.Drawing.Point(80, 80);
			this.chkTent.Name = "chkTent";
			this.chkTent.Size = new System.Drawing.Size(64, 24);
			this.chkTent.TabIndex = 1;
			this.chkTent.Text = "Roofing.Tent";
			// 
			// chkUp
			// 
			this.chkUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkUp.Location = new System.Drawing.Point(8, 80);
			this.chkUp.Name = "chkUp";
			this.chkUp.Size = new System.Drawing.Size(68, 24);
			this.chkUp.TabIndex = 0;
			this.chkUp.Text = "Roofing.Up";
			this.chkUp.CheckedChanged += new System.EventHandler(this.chkUp_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkHue);
			this.groupBox4.Controls.Add(this.numHeight);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.bServerControl);
			this.groupBox4.Controls.Add(this.bServerGenerate);
			this.groupBox4.Controls.Add(this.bTest);
			this.groupBox4.Controls.Add(this.bGenerate);
			this.groupBox4.Controls.Add(this.cmbTiles);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Location = new System.Drawing.Point(248, 140);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(304, 132);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Roofing.Generate";
			// 
			// chkHue
			// 
			this.chkHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkHue.Location = new System.Drawing.Point(196, 44);
			this.chkHue.Name = "chkHue";
			this.chkHue.Size = new System.Drawing.Size(76, 24);
			this.chkHue.TabIndex = 12;
			this.chkHue.Text = "Common.Hue";
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(116, 44);
			this.numHeight.Maximum = new System.Decimal(new int[] {127, 0, 0, 0});
			this.numHeight.Minimum = new System.Decimal(new int[] {128, 0, 0, -2147483648});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(48, 20);
			this.numHeight.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 44);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 23);
			this.label8.TabIndex = 10;
			this.label8.Text = "Roofing.Height";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "Roofing.UseSer";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Roofing.UseCli";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bServerControl
			// 
			this.bServerControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bServerControl.Location = new System.Drawing.Point(196, 100);
			this.bServerControl.Name = "bServerControl";
			this.bServerControl.TabIndex = 7;
			this.bServerControl.Text = "Roofing.ServCP";
			this.bServerControl.Click += new System.EventHandler(this.bServerControl_Click);
			// 
			// bServerGenerate
			// 
			this.bServerGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bServerGenerate.Location = new System.Drawing.Point(116, 100);
			this.bServerGenerate.Name = "bServerGenerate";
			this.bServerGenerate.TabIndex = 6;
			this.bServerGenerate.Text = "Roofing.Gen";
			this.bServerGenerate.Click += new System.EventHandler(this.bServerGenerate_Click);
			// 
			// bTest
			// 
			this.bTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTest.Location = new System.Drawing.Point(196, 68);
			this.bTest.Name = "bTest";
			this.bTest.TabIndex = 5;
			this.bTest.Text = "Roofing.Test";
			this.bTest.Click += new System.EventHandler(this.bTest_Click);
			// 
			// bGenerate
			// 
			this.bGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bGenerate.Location = new System.Drawing.Point(116, 68);
			this.bGenerate.Name = "bGenerate";
			this.bGenerate.TabIndex = 4;
			this.bGenerate.Text = "Roofing.Gen";
			this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
			// 
			// cmbTiles
			// 
			this.cmbTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTiles.Location = new System.Drawing.Point(116, 16);
			this.cmbTiles.Name = "cmbTiles";
			this.cmbTiles.Size = new System.Drawing.Size(156, 21);
			this.cmbTiles.TabIndex = 1;
			this.cmbTiles.SelectedIndexChanged += new System.EventHandler(this.cmbTiles_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Roofing.TileSet";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bClearAll
			// 
			this.bClearAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClearAll.Location = new System.Drawing.Point(4, 248);
			this.bClearAll.Name = "bClearAll";
			this.bClearAll.TabIndex = 3;
			this.bClearAll.Text = "Common.Clear";
			this.bClearAll.Click += new System.EventHandler(this.bClearAll_Click);
			// 
			// RoofingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(556, 276);
			this.Controls.Add(this.bClearAll);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pctImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "RoofingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Roofing.Title";
			this.Load += new System.EventHandler(this.RoofingForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.n2Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.n2X)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.n1Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.n1X)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Draw border for the image
		/// </summary>
		private void pctImage_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, pctImage.Width - 1, pctImage.Height - 1);
			pen.Dispose();
		}

		/// <summary>
		///     Updates the slope combo box with the appropriate values to the selected situation
		/// </summary>
		private void UpdateSlopeCombo()
		{
			cmbSlope.Enabled = chkSlope.Checked;

			if (chkSlope.Checked)
			{
				cmbSlope.Items.Clear();

				if (chkUp.Checked)
				{
					// Goes up: Left/Right
					cmbSlope.Items.Add(Pandora.Localization.TextProvider["Roofing.Left"]);
					cmbSlope.Items.Add(Pandora.Localization.TextProvider["Roofing.Right"]);
				}
				else
				{
					// NO Goes up: // Top Bottom
					cmbSlope.Items.Add(Pandora.Localization.TextProvider["Roofing.Top"]);
					cmbSlope.Items.Add(Pandora.Localization.TextProvider["Roofing.Bottom"]);
				}

				cmbSlope.SelectedIndex = 0;
			}
		}

		/// <summary>
		///     Goes Up check changed
		/// </summary>
		private void chkUp_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSlopeCombo();
		}

		/// <summary>
		///     Slope check changed
		/// </summary>
		private void chkSlope_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSlopeCombo();
		}

		/// <summary>
		///     Gets the new rectangle currently created
		/// </summary>
		private RoofRect CurrentRect
		{
			get
			{
				var slope = Slope.None;

				if (chkSlope.Checked)
				{
					if (chkUp.Checked)
					{
						if (cmbSlope.SelectedIndex == 0)
						{
							slope = Slope.Left;
						}
						else
						{
							slope = Slope.Right;
						}
					}
					else
					{
						if (cmbSlope.SelectedIndex == 0)
						{
							slope = Slope.Top;
						}
						else
						{
							slope = Slope.Bottom;
						}
					}
				}

				var x1 = (int)n1X.Value;
				var y1 = (int)n1Y.Value;
				var x2 = (int)n2X.Value;
				var y2 = (int)n2Y.Value;

				var rect = new Rectangle(Math.Min(x1, x2), Math.Min(y1, y2), Math.Abs(x2 - x1), Math.Abs(y2 - y1));

				return new RoofRect(rect, chkUp.Checked, chkTent.Checked, chkSlope.Checked, slope);
			}
		}

		/// <summary>
		///     Enables or disables buttons appropriate to the current situation
		/// </summary>
		private void EnableButtons()
		{
			bRemove.Enabled = m_Roof.Rectangles.Count > 0;
			bGenerate.Enabled = m_Roof.Rectangles.Count > 0;
			bTest.Enabled = m_Roof.Rectangles.Count > 0;

			bServerGenerate.Enabled = m_Roof.Rectangles.Count > 0 && Pandora.BoxConnection.Connected;
			bServerControl.Enabled = m_Roof.Rectangles.Count > 0 && Pandora.BoxConnection.Connected;
		}

		/// <summary>
		///     Button add roof piece
		/// </summary>
		private void bAdd_Click(object sender, EventArgs e)
		{
			var rect = CurrentRect;

			if (m_Roof.AddRectangle(rect))
			{
				pctImage.Image = m_Roof.Image;
			}

			EnableButtons();
		}

		/// <summary>
		///     Remove last roof piece
		/// </summary>
		private void bRemove_Click(object sender, EventArgs e)
		{
			m_Roof.RemoveLastRectangle();

			pctImage.Image = m_Roof.Image;
			EnableButtons();
		}

		/// <summary>
		///     Gets a point from the client
		/// </summary>
		private void lnkFromClient1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var x = 0;
			var y = 0;
			var z = 0;
			var map = 0;

			Client.Calibrate();

			if (Client.FindLocation(ref x, ref y, ref z, ref map))
			{
				if (sender as LinkLabel == lnkFromClient1)
				{
					n1X.Value = x;
					n1Y.Value = y;
				}
				else if (sender as LinkLabel == lnkFromClient2)
				{
					n2X.Value = x;
					n2Y.Value = y;
				}
			}
		}

		/// <summary>
		///     Updates the server buttons according to the online status
		/// </summary>
		private void UpdateServerButtons()
		{
			bServerGenerate.Enabled = Pandora.BoxConnection.Connected && m_Roof.Rectangles.Count > 0;
			bServerControl.Enabled = Pandora.BoxConnection.Connected && m_Roof.Rectangles.Count > 0;
		}

		/// <summary>
		///     On Load
		/// </summary>
		private void RoofingForm_Load(object sender, EventArgs e)
		{
			UpdateServerButtons();
			Pandora.BoxConnection.OnlineChanged += Pandora_OnlineChanged;

			// Load the rooftiles
			m_RoofTiles = TileSet.Load();

			foreach (var tileset in m_RoofTiles)
			{
				cmbTiles.Items.Add(tileset);
			}

			cmbTiles.SelectedIndex = 0;

			m_Roof.RoofImageChanged += m_Roof_RoofImageChanged;
		}

		/// <summary>
		///     Handles online changed events in Pandora
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Pandora_OnlineChanged(object sender, EventArgs e)
		{
			UpdateServerButtons();
		}

		/// <summary>
		///     User changes the tileset
		/// </summary>
		private void cmbTiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Roof.TileSet = cmbTiles.SelectedItem as TileSet;
		}

		/// <summary>
		///     Generate classic
		/// </summary>
		private void bGenerate_Click(object sender, EventArgs e)
		{
			m_Roof.GenerateClassic(
				Roof.TestMode.NoTest,
				(int)numHeight.Value,
				chkHue.Checked ? Pandora.Profile.Hues.SelectedIndex : 0);
		}

		/// <summary>
		///     Redraw the image
		/// </summary>
		private void m_Roof_RoofImageChanged(object sender, EventArgs e)
		{
			pctImage.Image = m_Roof.Image;
		}

		/// <summary>
		///     Classic test
		/// </summary>
		private void bTest_Click(object sender, EventArgs e)
		{
			if (m_Roof.GenerateClassic(
				Roof.TestMode.Test,
				(int)numHeight.Value,
				chkHue.Checked ? Pandora.Profile.Hues.SelectedIndex : 0))
			{
				if (MessageBox.Show(
						this,
						Pandora.Localization.TextProvider["Roofing.TestRest"],
						"",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					m_Roof.GenerateClassic(
						Roof.TestMode.Rest,
						(int)numHeight.Value,
						chkHue.Checked ? Pandora.Profile.Hues.SelectedIndex : 0);
				}
			}
		}

		/// <summary>
		///     Generate through server
		/// </summary>
		private void bServerGenerate_Click(object sender, EventArgs e)
		{
			m_Roof.GenerateThroughServer((int)numHeight.Value, chkHue.Checked ? Pandora.Profile.Hues.SelectedIndex : 0);
		}

		private void bServerControl_Click(object sender, EventArgs e)
		{
			Pandora.ShowBuilderControl();
		}

		private void bClearAll_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					this,
					Pandora.Localization.TextProvider["Roofing.ClearAll"],
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				m_Roof.Rectangles.Clear();
				pctImage.Image = null;
				EnableButtons();
			}
		}
	}
}