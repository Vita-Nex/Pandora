#region Header
// /*
//  *    2018 - Pandora - RandomTiler.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.BoxServer;
using TheBox.Common;
using TheBox.Data;

using Ultima;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for RandomTiler.
	/// </summary>
	public class RandomTiler : Form
	{
		private ComboBox cmbTileSet;
		private Label label1;
		private GroupBox groupBox1;
		private LinkLabel lnkEditTile;
		private RadioButton rNoHue;
		private RadioButton rSelectedHue;
		private RadioButton rRandomHue;
		private ComboBox cmbHues;
		private LinkLabel linkLabel1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private RandomTileTemplate m_TileForm;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private Label label2;
		private Button bRunSingle;
		private GroupBox groupBox3;
		private LinkLabel lnkFromClient2;
		private Label label4;
		private Label label3;
		private NumericUpDown n2Y;
		private NumericUpDown n2X;
		private GroupBox groupBox2;
		private LinkLabel lnkFromClient1;
		private Label label5;
		private Label label6;
		private NumericUpDown n1Y;
		private NumericUpDown n1X;
		private Label label7;
		private Label labFill;
		private TrackBar slideFill;
		private Button bAreaRun;
		private Button button1;
		private ComboBox cmbMap;
		private Label label8;
		private Label labWidth;
		private NumericUpDown nWidth;
		private NumericUpDown nHeight;
		private Label label9;
		private TrackBar pBarFill2;
		private Label labFill2;
		private Button bRunBrush;
		private CheckBox chkZ;
		private NumericUpDown numZ;
		private HueSelector m_HueForm;

		public RandomTiler()
		{
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
			var resources = new System.Resources.ResourceManager(typeof(RandomTiler));
			this.cmbTileSet = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.cmbHues = new System.Windows.Forms.ComboBox();
			this.rRandomHue = new System.Windows.Forms.RadioButton();
			this.rSelectedHue = new System.Windows.Forms.RadioButton();
			this.rNoHue = new System.Windows.Forms.RadioButton();
			this.lnkEditTile = new System.Windows.Forms.LinkLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cmbMap = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.bAreaRun = new System.Windows.Forms.Button();
			this.labFill = new System.Windows.Forms.Label();
			this.slideFill = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lnkFromClient1 = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.n1Y = new System.Windows.Forms.NumericUpDown();
			this.n1X = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lnkFromClient2 = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.n2Y = new System.Windows.Forms.NumericUpDown();
			this.n2X = new System.Windows.Forms.NumericUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.bRunSingle = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.bRunBrush = new System.Windows.Forms.Button();
			this.labFill2 = new System.Windows.Forms.Label();
			this.pBarFill2 = new System.Windows.Forms.TrackBar();
			this.nHeight = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.nWidth = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.labWidth = new System.Windows.Forms.Label();
			this.chkZ = new System.Windows.Forms.CheckBox();
			this.numZ = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.slideFill)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.n1Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.n1X)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.n2Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.n2X)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pBarFill2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbTileSet
			// 
			this.cmbTileSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTileSet.Location = new System.Drawing.Point(8, 32);
			this.cmbTileSet.Name = "cmbTileSet";
			this.cmbTileSet.Size = new System.Drawing.Size(121, 21);
			this.cmbTileSet.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Random.TileSet";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.cmbHues);
			this.groupBox1.Controls.Add(this.rRandomHue);
			this.groupBox1.Controls.Add(this.rSelectedHue);
			this.groupBox1.Controls.Add(this.rNoHue);
			this.groupBox1.Location = new System.Drawing.Point(8, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 136);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Common.Hue";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(8, 112);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(104, 16);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Random.EditHue";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// cmbHues
			// 
			this.cmbHues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHues.Enabled = false;
			this.cmbHues.Location = new System.Drawing.Point(8, 88);
			this.cmbHues.Name = "cmbHues";
			this.cmbHues.Size = new System.Drawing.Size(104, 21);
			this.cmbHues.TabIndex = 3;
			// 
			// rRandomHue
			// 
			this.rRandomHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rRandomHue.Location = new System.Drawing.Point(8, 64);
			this.rRandomHue.Name = "rRandomHue";
			this.rRandomHue.TabIndex = 2;
			this.rRandomHue.Text = "Random.RndHue";
			this.rRandomHue.CheckedChanged += new System.EventHandler(this.rRandomHue_CheckedChanged);
			// 
			// rSelectedHue
			// 
			this.rSelectedHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rSelectedHue.Location = new System.Drawing.Point(8, 40);
			this.rSelectedHue.Name = "rSelectedHue";
			this.rSelectedHue.TabIndex = 1;
			this.rSelectedHue.Text = "Random.SelHue";
			// 
			// rNoHue
			// 
			this.rNoHue.Checked = true;
			this.rNoHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rNoHue.Location = new System.Drawing.Point(8, 16);
			this.rNoHue.Name = "rNoHue";
			this.rNoHue.TabIndex = 0;
			this.rNoHue.TabStop = true;
			this.rNoHue.Text = "Random.NoHue";
			// 
			// lnkEditTile
			// 
			this.lnkEditTile.Location = new System.Drawing.Point(8, 56);
			this.lnkEditTile.Name = "lnkEditTile";
			this.lnkEditTile.Size = new System.Drawing.Size(120, 23);
			this.lnkEditTile.TabIndex = 3;
			this.lnkEditTile.TabStop = true;
			this.lnkEditTile.Text = "Random.EditTile";
			this.lnkEditTile.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditTile_LinkClicked);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(136, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(352, 208);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.numZ);
			this.tabPage1.Controls.Add(this.chkZ);
			this.tabPage1.Controls.Add(this.cmbMap);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.bAreaRun);
			this.tabPage1.Controls.Add(this.labFill);
			this.tabPage1.Controls.Add(this.slideFill);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(344, 182);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Random.Area";
			// 
			// cmbMap
			// 
			this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMap.Location = new System.Drawing.Point(240, 124);
			this.cmbMap.Name = "cmbMap";
			this.cmbMap.Size = new System.Drawing.Size(96, 21);
			this.cmbMap.TabIndex = 12;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(264, 152);
			this.button1.Name = "button1";
			this.button1.TabIndex = 11;
			this.button1.Text = "Roofing.ServCP";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// bAreaRun
			// 
			this.bAreaRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAreaRun.Location = new System.Drawing.Point(160, 152);
			this.bAreaRun.Name = "bAreaRun";
			this.bAreaRun.TabIndex = 10;
			this.bAreaRun.Text = "Common.Run";
			this.bAreaRun.Click += new System.EventHandler(this.bAreaRun_Click);
			// 
			// labFill
			// 
			this.labFill.Location = new System.Drawing.Point(164, 96);
			this.labFill.Name = "labFill";
			this.labFill.Size = new System.Drawing.Size(172, 23);
			this.labFill.TabIndex = 9;
			this.labFill.Text = "Random.labFill";
			this.labFill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labFill.Paint += new System.Windows.Forms.PaintEventHandler(this.labFill_Paint);
			// 
			// slideFill
			// 
			this.slideFill.LargeChange = 10;
			this.slideFill.Location = new System.Drawing.Point(160, 48);
			this.slideFill.Maximum = 100;
			this.slideFill.Name = "slideFill";
			this.slideFill.Size = new System.Drawing.Size(176, 45);
			this.slideFill.TabIndex = 8;
			this.slideFill.Value = 50;
			this.slideFill.Scroll += new System.EventHandler(this.slideFill_Scroll);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(328, 40);
			this.label7.TabIndex = 7;
			this.label7.Text = "Random.AreaDesc";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lnkFromClient1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.n1Y);
			this.groupBox2.Controls.Add(this.n1X);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 60);
			this.groupBox2.TabIndex = 5;
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
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(72, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Common.Y";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 20);
			this.label6.TabIndex = 2;
			this.label6.Text = "Common.X";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lnkFromClient2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.n2Y);
			this.groupBox3.Controls.Add(this.n2X);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(8, 112);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(144, 60);
			this.groupBox3.TabIndex = 6;
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
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFromClient2_LinkClicked);
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
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.bRunSingle);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(344, 182);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Random.ItemRnd";
			// 
			// bRunSingle
			// 
			this.bRunSingle.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRunSingle.Location = new System.Drawing.Point(136, 120);
			this.bRunSingle.Name = "bRunSingle";
			this.bRunSingle.TabIndex = 1;
			this.bRunSingle.Text = "Common.Run";
			this.bRunSingle.Click += new System.EventHandler(this.bRunSingle_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(328, 104);
			this.label2.TabIndex = 0;
			this.label2.Text = "Random.SingleDesc";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.bRunBrush);
			this.tabPage3.Controls.Add(this.labFill2);
			this.tabPage3.Controls.Add(this.pBarFill2);
			this.tabPage3.Controls.Add(this.nHeight);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.nWidth);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.labWidth);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(344, 182);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Random.Brush";
			// 
			// bRunBrush
			// 
			this.bRunBrush.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRunBrush.Location = new System.Drawing.Point(136, 152);
			this.bRunBrush.Name = "bRunBrush";
			this.bRunBrush.TabIndex = 8;
			this.bRunBrush.Text = "Common.Run";
			this.bRunBrush.Click += new System.EventHandler(this.bRunBrush_Click);
			// 
			// labFill2
			// 
			this.labFill2.Location = new System.Drawing.Point(160, 112);
			this.labFill2.Name = "labFill2";
			this.labFill2.Size = new System.Drawing.Size(152, 23);
			this.labFill2.TabIndex = 7;
			this.labFill2.Text = "label10";
			this.labFill2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labFill2.Paint += new System.Windows.Forms.PaintEventHandler(this.labFill2_Paint);
			// 
			// pBarFill2
			// 
			this.pBarFill2.LargeChange = 10;
			this.pBarFill2.Location = new System.Drawing.Point(144, 64);
			this.pBarFill2.Maximum = 100;
			this.pBarFill2.Name = "pBarFill2";
			this.pBarFill2.Size = new System.Drawing.Size(192, 45);
			this.pBarFill2.TabIndex = 6;
			this.pBarFill2.Value = 50;
			this.pBarFill2.Scroll += new System.EventHandler(this.pBarFill2_Scroll);
			// 
			// nHeight
			// 
			this.nHeight.Location = new System.Drawing.Point(72, 112);
			this.nHeight.Maximum = new System.Decimal(new int[] {15, 0, 0, 0});
			this.nHeight.Minimum = new System.Decimal(new int[] {1, 0, 0, 0});
			this.nHeight.Name = "nHeight";
			this.nHeight.Size = new System.Drawing.Size(48, 20);
			this.nHeight.TabIndex = 4;
			this.nHeight.Value = new System.Decimal(new int[] {1, 0, 0, 0});
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 32);
			this.label9.TabIndex = 5;
			this.label9.Text = "Random.Hgt";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Paint += new System.Windows.Forms.PaintEventHandler(this.label9_Paint);
			// 
			// nWidth
			// 
			this.nWidth.Location = new System.Drawing.Point(72, 72);
			this.nWidth.Maximum = new System.Decimal(new int[] {15, 0, 0, 0});
			this.nWidth.Minimum = new System.Decimal(new int[] {1, 0, 0, 0});
			this.nWidth.Name = "nWidth";
			this.nWidth.Size = new System.Drawing.Size(48, 20);
			this.nWidth.TabIndex = 1;
			this.nWidth.Value = new System.Decimal(new int[] {1, 0, 0, 0});
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(328, 48);
			this.label8.TabIndex = 0;
			this.label8.Text = "Random.BrushDesc";
			// 
			// labWidth
			// 
			this.labWidth.Location = new System.Drawing.Point(16, 64);
			this.labWidth.Name = "labWidth";
			this.labWidth.Size = new System.Drawing.Size(112, 32);
			this.labWidth.TabIndex = 3;
			this.labWidth.Text = "Random.Wdth";
			this.labWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labWidth.Paint += new System.Windows.Forms.PaintEventHandler(this.labWidth_Paint);
			// 
			// chkZ
			// 
			this.chkZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkZ.Location = new System.Drawing.Point(160, 120);
			this.chkZ.Name = "chkZ";
			this.chkZ.Size = new System.Drawing.Size(32, 24);
			this.chkZ.TabIndex = 13;
			this.chkZ.Text = "Z";
			// 
			// numZ
			// 
			this.numZ.Location = new System.Drawing.Point(192, 124);
			this.numZ.Maximum = new System.Decimal(new int[] {127, 0, 0, 0});
			this.numZ.Minimum = new System.Decimal(new int[] {128, 0, 0, -2147483648});
			this.numZ.Name = "numZ";
			this.numZ.Size = new System.Drawing.Size(48, 20);
			this.numZ.TabIndex = 14;
			// 
			// RandomTiler
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 222);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lnkEditTile);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbTileSet);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RandomTiler";
			this.Text = "RandomTiler";
			this.Load += new System.EventHandler(this.RandomTiler_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.slideFill)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.n1Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.n1X)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.n2Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.n2X)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pBarFill2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void RandomTiler_Load(object sender, EventArgs e)
		{
			var tiles = RandomTiles.Load();

			cmbTileSet.BeginUpdate();

			foreach (RandomTilesList tileset in tiles.List)
			{
				cmbTileSet.Items.Add(tileset);
			}

			cmbTileSet.EndUpdate();

			if (cmbTileSet.Items.Count > 0)
				cmbTileSet.SelectedIndex = 0;

			var hues = HueGroups.Load();

			cmbHues.BeginUpdate();

			foreach (var huelist in hues.Groups)
			{
				cmbHues.Items.Add(huelist);
			}

			cmbHues.EndUpdate();

			if (cmbHues.Items.Count > 0)
				cmbHues.SelectedIndex = 0;

			UpdateFillText();

			// Maps
			cmbMap.BeginUpdate();

			for (var i = 0; i < 4; i++)
			{
				if (Pandora.Profile.Travel.EnabledMaps[i])
				{
					cmbMap.Items.Add(Pandora.Profile.Travel.MapNames[i]);
				}
			}

			cmbMap.EndUpdate();

			if (cmbMap.Items.Count > 0)
			{
				cmbMap.SelectedIndex = 0;
			}
		}

		private void UpdateFillText()
		{
			labFill.Text = string.Format(Pandora.Localization.TextProvider["Random.labFill"], slideFill.Value);
			labFill2.Text = string.Format(Pandora.Localization.TextProvider["Random.labFill"], pBarFill2.Value);
		}

		private void rRandomHue_CheckedChanged(object sender, EventArgs e)
		{
			cmbHues.Enabled = rRandomHue.Checked;
		}

		private void lnkEditTile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_TileForm = new RandomTileTemplate();
			m_TileForm.Closed += m_TileForm_Closed;
			lnkEditTile.Enabled = false;
			m_TileForm.Show();
		}

		private void m_TileForm_Closed(object sender, EventArgs e)
		{
			lnkEditTile.Enabled = true;

			// Update the tiles
			var tiles = RandomTiles.Load();

			cmbTileSet.BeginUpdate();
			cmbTileSet.Items.Clear();

			foreach (RandomTilesList tileset in tiles.List)
			{
				cmbTileSet.Items.Add(tileset);
			}

			cmbTileSet.EndUpdate();

			if (cmbTileSet.Items.Count > 0)
				cmbTileSet.SelectedIndex = 0;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_HueForm = new HueSelector();
			m_HueForm.Closed += m_HueForm_Closed;
			linkLabel1.Enabled = false;
			m_HueForm.Show();
		}

		private void m_HueForm_Closed(object sender, EventArgs e)
		{
			linkLabel1.Enabled = true;

			// Update hues
			var hues = HueGroups.Load();

			cmbHues.BeginUpdate();
			cmbHues.Items.Clear();

			foreach (var hc in hues.Groups)
			{
				cmbHues.Items.Add(hc);
			}

			cmbHues.EndUpdate();

			if (cmbHues.Items.Count > 0)
				cmbHues.SelectedIndex = 0;
		}

		private bool EnsureConditions()
		{
			if (!Pandora.BoxConnection.Connected)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Server.PleaseConnect"]);
				return false;
			}

			var tileset = cmbTileSet.SelectedItem as RandomTilesList;

			if (tileset == null)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Random.NoTile"]);
				return false;
			}

			var hues = cmbHues.SelectedItem as HuesCollection;

			if (rRandomHue.Checked && hues == null)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Random.NoRndHue"]);
				return false;
			}

			return true;
		}

		private void bRunSingle_Click(object sender, EventArgs e)
		{
			if (!EnsureConditions())
				return;

			var tileset = cmbTileSet.SelectedItem as RandomTilesList;

			var hues = cmbHues.SelectedItem as HuesCollection;

			RandomItem msg = null;
			;

			if (rNoHue.Checked)
			{
				msg = new RandomItem(tileset);
			}
			else if (rSelectedHue.Checked)
			{
				msg = new RandomItem(tileset, Pandora.Profile.Hues.SelectedIndex);
			}
			else
			{
				msg = new RandomItem(tileset, hues);
			}

			Pandora.BoxConnection.SendToServer(msg);
		}

		private void labFill_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labFill, e.Graphics);
		}

		private void slideFill_Scroll(object sender, EventArgs e)
		{
			UpdateFillText();
		}

		private void lnkFromClient1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Client.Calibrate();

			var x = 0;
			var y = 0;
			var z = 0;
			var map = 0;

			if (Client.FindLocation(ref x, ref y, ref z, ref map))
			{
				n1X.Value = x;
				n1Y.Value = y;
			}
		}

		private void lnkFromClient2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Client.Calibrate();

			var x = 0;
			var y = 0;
			var z = 0;
			var map = 0;

			if (Client.FindLocation(ref x, ref y, ref z, ref map))
			{
				n2X.Value = x;
				n2Y.Value = y;
			}
		}

		private void bAreaRun_Click(object sender, EventArgs e)
		{
			if (!EnsureConditions())
				return;

			if (cmbMap.SelectedIndex == -1)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Random.NoMap"]);
				return;
			}

			var tileset = cmbTileSet.SelectedItem as RandomTilesList;

			var hues = cmbHues.SelectedItem as HuesCollection;

			var x1 = Math.Min((int)n1X.Value, (int)n2X.Value);
			var x2 = Math.Max((int)n1X.Value, (int)n2X.Value);
			var y1 = Math.Min((int)n1Y.Value, (int)n2Y.Value);
			var y2 = Math.Max((int)n1Y.Value, (int)n2Y.Value);

			var rect = new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
			var fill = slideFill.Value / 100d;

			var map = Pandora.Profile.Travel.GetRealMapIndex(cmbMap.SelectedIndex);

			var rnd = new RandomRectangle(tileset, rect, fill, map);

			if (rNoHue.Checked)
				rnd.Hue = 0;
			else if (rSelectedHue.Checked)
				rnd.Hue = Pandora.Profile.Hues.SelectedIndex;
			else
				rnd.RandomHues = hues;

			if (chkZ.Checked)
				rnd.Z = (int)numZ.Value;

			BoxMessage msg = rnd.CreateMessage();

			Pandora.BoxConnection.SendToServer(msg);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Pandora.ShowBuilderControl();
		}

		private void labWidth_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labWidth, e.Graphics);
		}

		private void pBarFill2_Scroll(object sender, EventArgs e)
		{
			UpdateFillText();
		}

		private void labFill2_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labFill2, e.Graphics);
		}

		private void label9_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(label9, e.Graphics);
		}

		private void bRunBrush_Click(object sender, EventArgs e)
		{
			if (!EnsureConditions())
				return;

			var fill = pBarFill2.Value / 100d;
			var width = (int)nWidth.Value;
			var height = (int)nHeight.Value;

			var brush = new RandomBrush(width, height);
			var tileset = cmbTileSet.SelectedItem as RandomTilesList;
			RandomBrushMessage msg = null;

			if (rRandomHue.Checked)
			{
				var hues = cmbHues.SelectedItem as HuesCollection;

				msg = brush.CreateMessage(tileset, hues, fill);
			}
			else
			{
				if (rNoHue.Checked)
				{
					msg = brush.CreateMessage(tileset, 0, fill);
				}
				else
				{
					msg = brush.CreateMessage(tileset, Pandora.Profile.Hues.SelectedIndex, fill);
				}
			}

			Pandora.BoxConnection.SendToServer(msg);
		}
	}
}