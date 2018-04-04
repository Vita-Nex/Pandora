using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Box.Misc;

namespace Box.Tabs
{
	/// <summary>
	/// Summary description for Roofing.
	/// </summary>
	public class Roofing
	{
		private const string NoticeText = "Note: Depending on the size of your roof, it might take up to a few minutes for the process to complete. You can move around during the generation, but you can't speak or use any commands. Also, once it started, the only way to stop it is to close the client.";
		private enum TestMode
		{
			NoTest,
			Test,
			Rest
		}

		private enum RoofFlag
		{
			Lower = 1,
			Higher = 2,
			Even = 4,
			Empty = 8
		}
		private TileSet tileset;
		private System.Drawing.Point BasePoint;
		private RoofImage roofimage;
		private short x1;
		private short x2;
		private short y1;
		private short y2;
		private short z = 0;
		private ArrayList Edges;
		private ArrayList TileSets;
		private System.Windows.Forms.PictureBox Preview;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox X1;
		private System.Windows.Forms.TextBox Y1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox Y2;
		private System.Windows.Forms.TextBox X2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox CheckGoesUp;
		private System.Windows.Forms.CheckBox CheckTent;
		private System.Windows.Forms.Button ButtonRemoveLast;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.Button ButtonClear;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button ButtonCreate;
		private System.Windows.Forms.Button ButtonTest;
		private System.Windows.Forms.TextBox AtHeight;
		private System.Windows.Forms.ComboBox RoofType;
		private System.Windows.Forms.Button ButtonWipe;
		private System.Windows.Forms.Label Notice;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Roofing( bool vertical )
		{
			if ( vertical )
				// This call is required by the Windows.Forms Form Designer.
				InitializeComponent();
			else
				InitializeComponentHorizontal();

			Text = "Roofing";

			// Init variables

			this.TileSets = new ArrayList();
			this.Edges = new ArrayList();
			this.roofimage = new RoofImage();

			// Read rooftiles.cfg
			ReadRoofTiles();

			// Read the tilesets into the RoofType list
			RoofType.BeginUpdate();

			foreach ( TileSet ts in TileSets )
				RoofType.Items.Add( ts.Name );

			RoofType.EndUpdate();

			// Selecte first
			RoofType.SelectedIndex = 0;

			// Set notice text
			Notice.Text = NoticeText;
			
		}

		private void ReadRoofTiles()
		{
			// Read TheBox.Embedded.rooftiles.cfg
			System.Reflection.Assembly theExe = this.GetType().Assembly;

			System.IO.Stream theStream = null;

			try
			{
				theStream = theExe.	GetManifestResourceStream( "TheBox.Embedded.rooftiles.cfg" );
			}
			catch ( Exception )
			{
				throw new Exception("The roofing tab could not find the rooftiles.cfg component");
			}

			// Get a stream reader
			System.IO.StreamReader sr = new System.IO.StreamReader( theStream );

			string line;

			// Create new tileset
			TileSet ts = null;

			while ( ( line = sr.ReadLine() ) != null )
			{
				if ( line.Length == 0 )
					continue;

				// Line to process
				if ( line[0] == '[' )
				{
					// New tileset starts here
					ts = new TileSet();
					string name = "";

					// Remove the first [
					line = line.Substring( 1 );
					while ( line[0] != ']' )
					{
						name += line[0];
						line = line.Substring( 1 );
					}

					ts.Name = name;
					this.TileSets.Add( ts );
				}
				else
				{
					if ( ts != null )
					{
						// We have a tile set to add to
						TileMask tm = new TileMask();
						// If we have a valid tile line add it to the set
						if ( tm.FromLine( line ) )
							ts.Tiles.Add( tm );
					}							
				}
			}

			// Close streams
			sr.Close();
			theStream.Close();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Preview = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Y1 = new System.Windows.Forms.TextBox();
			this.X1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Y2 = new System.Windows.Forms.TextBox();
			this.X2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.CheckGoesUp = new System.Windows.Forms.CheckBox();
			this.CheckTent = new System.Windows.Forms.CheckBox();
			this.ButtonRemoveLast = new System.Windows.Forms.Button();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.ButtonClear = new System.Windows.Forms.Button();
			this.AtHeight = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.RoofType = new System.Windows.Forms.ComboBox();
			this.ButtonCreate = new System.Windows.Forms.Button();
			this.ButtonTest = new System.Windows.Forms.Button();
			this.ButtonWipe = new System.Windows.Forms.Button();
			this.Notice = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Preview
			// 
			this.Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Preview.Location = new System.Drawing.Point(0, 0);
			this.Preview.Name = "Preview";
			this.Preview.Size = new System.Drawing.Size(200, 200);
			this.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Preview.TabIndex = 0;
			this.Preview.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.CheckGoesUp);
			this.groupBox1.Controls.Add(this.CheckTent);
			this.groupBox1.Location = new System.Drawing.Point(0, 204);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(196, 104);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add section";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Y1);
			this.groupBox2.Controls.Add(this.X1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(22, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(60, 64);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Point 1";
			// 
			// Y1
			// 
			this.Y1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Y1.Location = new System.Drawing.Point(20, 40);
			this.Y1.Name = "Y1";
			this.Y1.Size = new System.Drawing.Size(36, 20);
			this.Y1.TabIndex = 4;
			this.Y1.Text = "";
			this.Y1.TextChanged += new System.EventHandler(this.Y1_TextChanged);
			this.Y1.Leave += new System.EventHandler(this.Y1_Leave);
			// 
			// X1
			// 
			this.X1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.X1.Location = new System.Drawing.Point(20, 16);
			this.X1.Name = "X1";
			this.X1.Size = new System.Drawing.Size(36, 20);
			this.X1.TabIndex = 3;
			this.X1.Text = "";
			this.X1.TextChanged += new System.EventHandler(this.X1_TextChanged);
			this.X1.Leave += new System.EventHandler(this.X1_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Y";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "X";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Y2);
			this.groupBox3.Controls.Add(this.X2);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(118, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(60, 64);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Point 2";
			// 
			// Y2
			// 
			this.Y2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Y2.Location = new System.Drawing.Point(20, 40);
			this.Y2.Name = "Y2";
			this.Y2.Size = new System.Drawing.Size(36, 20);
			this.Y2.TabIndex = 4;
			this.Y2.Text = "";
			this.Y2.TextChanged += new System.EventHandler(this.Y2_TextChanged);
			this.Y2.Leave += new System.EventHandler(this.Y2_Leave);
			// 
			// X2
			// 
			this.X2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.X2.Location = new System.Drawing.Point(20, 16);
			this.X2.Name = "X2";
			this.X2.Size = new System.Drawing.Size(36, 20);
			this.X2.TabIndex = 3;
			this.X2.Text = "";
			this.X2.TextChanged += new System.EventHandler(this.X2_TextChanged);
			this.X2.Leave += new System.EventHandler(this.X2_Leave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "X";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CheckGoesUp
			// 
			this.CheckGoesUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CheckGoesUp.Location = new System.Drawing.Point(4, 80);
			this.CheckGoesUp.Name = "CheckGoesUp";
			this.CheckGoesUp.Size = new System.Drawing.Size(88, 20);
			this.CheckGoesUp.TabIndex = 2;
			this.CheckGoesUp.Text = "Goes up";
			// 
			// CheckTent
			// 
			this.CheckTent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CheckTent.Location = new System.Drawing.Point(108, 80);
			this.CheckTent.Name = "CheckTent";
			this.CheckTent.Size = new System.Drawing.Size(72, 20);
			this.CheckTent.TabIndex = 3;
			this.CheckTent.Text = "Tent";
			// 
			// ButtonRemoveLast
			// 
			this.ButtonRemoveLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonRemoveLast.Location = new System.Drawing.Point(0, 308);
			this.ButtonRemoveLast.Name = "ButtonRemoveLast";
			this.ButtonRemoveLast.Size = new System.Drawing.Size(80, 23);
			this.ButtonRemoveLast.TabIndex = 2;
			this.ButtonRemoveLast.Text = "Remove Last";
			this.ButtonRemoveLast.Click += new System.EventHandler(this.ButtonRemoveLast_Click);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonAdd.Location = new System.Drawing.Point(120, 308);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size(76, 23);
			this.ButtonAdd.TabIndex = 3;
			this.ButtonAdd.Text = "Add";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// ButtonClear
			// 
			this.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonClear.Location = new System.Drawing.Point(60, 332);
			this.ButtonClear.Name = "ButtonClear";
			this.ButtonClear.TabIndex = 4;
			this.ButtonClear.Text = "Clear";
			this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// AtHeight
			// 
			this.AtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AtHeight.Location = new System.Drawing.Point(80, 388);
			this.AtHeight.Name = "AtHeight";
			this.AtHeight.Size = new System.Drawing.Size(36, 20);
			this.AtHeight.TabIndex = 6;
			this.AtHeight.Text = "";
			this.AtHeight.TextChanged += new System.EventHandler(this.AtHeight_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 392);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Height";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// RoofType
			// 
			this.RoofType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RoofType.Location = new System.Drawing.Point(0, 360);
			this.RoofType.Name = "RoofType";
			this.RoofType.Size = new System.Drawing.Size(200, 21);
			this.RoofType.TabIndex = 7;
			// 
			// ButtonCreate
			// 
			this.ButtonCreate.Enabled = false;
			this.ButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonCreate.Location = new System.Drawing.Point(124, 384);
			this.ButtonCreate.Name = "ButtonCreate";
			this.ButtonCreate.TabIndex = 8;
			this.ButtonCreate.Text = "Create";
			this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// ButtonTest
			// 
			this.ButtonTest.Enabled = false;
			this.ButtonTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonTest.Location = new System.Drawing.Point(124, 412);
			this.ButtonTest.Name = "ButtonTest";
			this.ButtonTest.TabIndex = 9;
			this.ButtonTest.Text = "Test";
			this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
			// 
			// ButtonWipe
			// 
			this.ButtonWipe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonWipe.Location = new System.Drawing.Point(0, 412);
			this.ButtonWipe.Name = "ButtonWipe";
			this.ButtonWipe.Size = new System.Drawing.Size(116, 23);
			this.ButtonWipe.TabIndex = 10;
			this.ButtonWipe.Text = "Wipe Items";
			this.ButtonWipe.Click += new System.EventHandler(this.ButtonWipe_Click);
			// 
			// Notice
			// 
			this.Notice.Location = new System.Drawing.Point(0, 440);
			this.Notice.Name = "Notice";
			this.Notice.Size = new System.Drawing.Size(200, 92);
			this.Notice.TabIndex = 11;
			// 
			// Roofing
			// 
			this.Controls.Add(this.Notice);
			this.Controls.Add(this.ButtonWipe);
			this.Controls.Add(this.ButtonTest);
			this.Controls.Add(this.ButtonCreate);
			this.Controls.Add(this.RoofType);
			this.Controls.Add(this.AtHeight);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ButtonClear);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonRemoveLast);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Preview);
			this.Name = "Roofing";
			this.Size = new System.Drawing.Size(200, 532);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private void InitializeComponentHorizontal()
		{
			this.Preview = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Y1 = new System.Windows.Forms.TextBox();
			this.X1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Y2 = new System.Windows.Forms.TextBox();
			this.X2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.CheckGoesUp = new System.Windows.Forms.CheckBox();
			this.CheckTent = new System.Windows.Forms.CheckBox();
			this.ButtonRemoveLast = new System.Windows.Forms.Button();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.ButtonClear = new System.Windows.Forms.Button();
			this.AtHeight = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.RoofType = new System.Windows.Forms.ComboBox();
			this.ButtonCreate = new System.Windows.Forms.Button();
			this.ButtonTest = new System.Windows.Forms.Button();
			this.ButtonWipe = new System.Windows.Forms.Button();
			this.Notice = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Preview
			// 
			this.Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Preview.Location = new System.Drawing.Point(0, 0);
			this.Preview.Name = "Preview";
			this.Preview.Size = new System.Drawing.Size(156, 156);
			this.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Preview.TabIndex = 0;
			this.Preview.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.CheckGoesUp);
			this.groupBox1.Controls.Add(this.CheckTent);
			this.groupBox1.Location = new System.Drawing.Point(164, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 120);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add section";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Y1);
			this.groupBox2.Controls.Add(this.X1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(16, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(60, 64);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Point 1";
			// 
			// Y1
			// 
			this.Y1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Y1.Location = new System.Drawing.Point(20, 40);
			this.Y1.Name = "Y1";
			this.Y1.Size = new System.Drawing.Size(36, 20);
			this.Y1.TabIndex = 4;
			this.Y1.Text = "";
			this.Y1.TextChanged += new System.EventHandler(this.Y1_TextChanged);
			this.Y1.Leave += new System.EventHandler(this.Y1_Leave);
			// 
			// X1
			// 
			this.X1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.X1.Location = new System.Drawing.Point(20, 16);
			this.X1.Name = "X1";
			this.X1.Size = new System.Drawing.Size(36, 20);
			this.X1.TabIndex = 3;
			this.X1.Text = "";
			this.X1.TextChanged += new System.EventHandler(this.X1_TextChanged);
			this.X1.Leave += new System.EventHandler(this.X1_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Y";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "X";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Y2);
			this.groupBox3.Controls.Add(this.X2);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(92, 24);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(60, 64);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Point 2";
			// 
			// Y2
			// 
			this.Y2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Y2.Location = new System.Drawing.Point(20, 40);
			this.Y2.Name = "Y2";
			this.Y2.Size = new System.Drawing.Size(36, 20);
			this.Y2.TabIndex = 4;
			this.Y2.Text = "";
			this.Y2.TextChanged += new System.EventHandler(this.Y2_TextChanged);
			this.Y2.Leave += new System.EventHandler(this.Y2_Leave);
			// 
			// X2
			// 
			this.X2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.X2.Location = new System.Drawing.Point(20, 16);
			this.X2.Name = "X2";
			this.X2.Size = new System.Drawing.Size(36, 20);
			this.X2.TabIndex = 3;
			this.X2.Text = "";
			this.X2.TextChanged += new System.EventHandler(this.X2_TextChanged);
			this.X2.Leave += new System.EventHandler(this.X2_Leave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "X";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CheckGoesUp
			// 
			this.CheckGoesUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CheckGoesUp.Location = new System.Drawing.Point(8, 96);
			this.CheckGoesUp.Name = "CheckGoesUp";
			this.CheckGoesUp.Size = new System.Drawing.Size(64, 20);
			this.CheckGoesUp.TabIndex = 2;
			this.CheckGoesUp.Text = "Goes up";
			// 
			// CheckTent
			// 
			this.CheckTent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CheckTent.Location = new System.Drawing.Point(100, 96);
			this.CheckTent.Name = "CheckTent";
			this.CheckTent.Size = new System.Drawing.Size(60, 20);
			this.CheckTent.TabIndex = 3;
			this.CheckTent.Text = "Tent";
			// 
			// ButtonRemoveLast
			// 
			this.ButtonRemoveLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonRemoveLast.Location = new System.Drawing.Point(164, 132);
			this.ButtonRemoveLast.Name = "ButtonRemoveLast";
			this.ButtonRemoveLast.Size = new System.Drawing.Size(80, 23);
			this.ButtonRemoveLast.TabIndex = 2;
			this.ButtonRemoveLast.Text = "Remove Last";
			this.ButtonRemoveLast.Click += new System.EventHandler(this.ButtonRemoveLast_Click);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonAdd.Location = new System.Drawing.Point(248, 132);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size(84, 23);
			this.ButtonAdd.TabIndex = 3;
			this.ButtonAdd.Text = "Add";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// ButtonClear
			// 
			this.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonClear.Location = new System.Drawing.Point(568, 132);
			this.ButtonClear.Name = "ButtonClear";
			this.ButtonClear.TabIndex = 4;
			this.ButtonClear.Text = "Clear";
			this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// AtHeight
			// 
			this.AtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AtHeight.Location = new System.Drawing.Point(528, 32);
			this.AtHeight.Name = "AtHeight";
			this.AtHeight.Size = new System.Drawing.Size(36, 20);
			this.AtHeight.TabIndex = 6;
			this.AtHeight.Text = "";
			this.AtHeight.TextChanged += new System.EventHandler(this.AtHeight_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(480, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 23);
			this.label5.TabIndex = 5;
			this.label5.Text = "Height";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// RoofType
			// 
			this.RoofType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RoofType.Location = new System.Drawing.Point(336, 4);
			this.RoofType.Name = "RoofType";
			this.RoofType.Size = new System.Drawing.Size(228, 21);
			this.RoofType.TabIndex = 7;
			// 
			// ButtonCreate
			// 
			this.ButtonCreate.Enabled = false;
			this.ButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonCreate.Location = new System.Drawing.Point(568, 4);
			this.ButtonCreate.Name = "ButtonCreate";
			this.ButtonCreate.TabIndex = 8;
			this.ButtonCreate.Text = "Create";
			this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// ButtonTest
			// 
			this.ButtonTest.Enabled = false;
			this.ButtonTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonTest.Location = new System.Drawing.Point(568, 32);
			this.ButtonTest.Name = "ButtonTest";
			this.ButtonTest.TabIndex = 9;
			this.ButtonTest.Text = "Test";
			this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
			// 
			// ButtonWipe
			// 
			this.ButtonWipe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonWipe.Location = new System.Drawing.Point(336, 132);
			this.ButtonWipe.Name = "ButtonWipe";
			this.ButtonWipe.Size = new System.Drawing.Size(228, 23);
			this.ButtonWipe.TabIndex = 10;
			this.ButtonWipe.Text = "Wipe Items";
			this.ButtonWipe.Click += new System.EventHandler(this.ButtonWipe_Click);
			// 
			// Notice
			// 
			this.Notice.Location = new System.Drawing.Point(336, 60);
			this.Notice.Name = "Notice";
			this.Notice.Size = new System.Drawing.Size(308, 68);
			this.Notice.TabIndex = 11;
			// 
			// Roofing
			// 
			this.Controls.Add(this.Notice);
			this.Controls.Add(this.ButtonWipe);
			this.Controls.Add(this.ButtonTest);
			this.Controls.Add(this.ButtonCreate);
			this.Controls.Add(this.RoofType);
			this.Controls.Add(this.AtHeight);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ButtonClear);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonRemoveLast);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Preview);
			this.Name = "Roofing";
			this.Size = new System.Drawing.Size(648, 160);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			// Create a new edge
			Edge edge = new Edge();

			if ( this.x1 < this.x2 )
			{
				edge.Rect.X = x1;
				edge.Rect.Width = x2 - x1;
			}
			else
			{
				edge.Rect.X = x2;
				edge.Rect.Width = x1 - x2;
			}

			if ( this.y1 < this.y2 )
			{
				edge.Rect.Y = y1;
				edge.Rect.Height = y2 - y1;
			}
			else
			{
				edge.Rect.Y = y2;
				edge.Rect.Height = y1 - y2;
			}

			edge.Up = this.CheckGoesUp.Checked;
			edge.Tent = this.CheckTent.Checked;

			if ( ( edge.Rect.Height > 0 ) && ( edge.Rect.Width > 0 ) )
			{
				if ( ( !edge.Up && ( ( edge.Rect.Height ) % 2 > 0 ) ) || ( edge.Up && ( ( edge.Rect.Width % 2 > 0 ) ) ) )
				{
					if ( MessageBox.Show("This roof isn't odd wide and it will look wierd. Are you sure you want to add it?", "Roof not odd wide", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
					{
						return;
					}
				}
			}
			else if ( ( edge.Rect.Height == 0 ) && ( edge.Rect.Width == 0 ) )
			{
				MessageBox.Show( "Can't add an empty roof" );
				return;
			}
			else if ( ( edge.Rect.Height > 0 ) && ( edge.Rect.Height % 2 > 0 ) || ( edge.Rect.Width > 0 ) && ( edge.Rect.Width % 2 > 0 ) )
			{
				if ( MessageBox.Show("This roof isn't odd wide and it will look wierd. Are you sure you want to add it?", "Roof not odd wide", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
				{
					return;
				}
			}

			foreach ( Edge ed in this.Edges )
				if ( ( ed.Rect.Equals( edge.Rect ) ) && ( ed.Up == edge.Up ) ) 
				{
					MessageBox.Show( "You have already added those coordinates" );
					return;
				}

			this.Edges.Add( edge );

			if ( !Calculate() )
			{
				MessageBox.Show("Can't roof those coordinates");
				this.Edges.Remove( edge );
				Calculate();
			}

			CheckRemove();
			CheckGenerate();

			this.roofimage.MakeBitmap(100, 100);

			this.Preview.Image = this.roofimage.Img;
		}

		private void CheckAdd()
		{
			if ( 
				( this.X1.Text.Length > 0 ) &&
				( this.Y1.Text.Length > 0 ) &&
				( this.X2.Text.Length > 0 ) &&
				( this.Y2.Text.Length > 0 ) )
				this.ButtonAdd.Enabled = true;
			else
				this.ButtonAdd.Enabled = false;
		}

		private void CheckRemove()
		{
			if ( this.Edges.Count == 0 )
			{
				this.ButtonRemoveLast.Enabled = false;
				this.ButtonClear.Enabled = false;
			}
			else
			{
				this.ButtonRemoveLast.Enabled = true;
				this.ButtonClear.Enabled = true;
			}
		}

		private void CheckGenerate()
		{
			if ( ( this.roofimage.Width > 0 ) &&
				( this.roofimage.Height > 0 ) &&
				( this.roofimage.Data.Count > 0 ) &&
				( this.AtHeight.Text.Length > 0 ) )
			{
				this.ButtonCreate.Enabled = true;
				this.ButtonTest.Enabled = true;
			}
			else
			{
				this.ButtonCreate.Enabled = false;
				this.ButtonTest.Enabled = false;
			}
		}

		// OK
		private bool Calculate()
		{
			int i;
			Rectangle bounds;
			if ( this.roofimage.Data.Count > 0 )
				this.roofimage.Data.Clear();

			if ( this.Edges.Count == 0 )
				return true;

			Edge temp = ((Edge)this.Edges[0]);
			bounds = new Rectangle( temp.Rect.Location, temp.Rect.Size );

			for ( int j = 1; j < this.Edges.Count; j++ )
			{
				Edge cfr = (Edge) this.Edges[j];

				if ( bounds.Left > cfr.Rect.Left )
					bounds.X = cfr.Rect.X;
				if ( bounds.Top > cfr.Rect.Top )
					bounds.Y = cfr.Rect.Y;
				if ( bounds.Right < cfr.Rect.Right )
					bounds.Width = ( cfr.Rect.Right - bounds.Left );
				if ( bounds.Bottom < cfr.Rect.Bottom )
					bounds.Height = ( cfr.Rect.Bottom - bounds.Top );
			}

			if ( ( bounds.Width > 150 ) || ( bounds.Height > 150 ) )
				return false;

			this.roofimage.Width = bounds.Width + 3;
			this.roofimage.Height = bounds.Height + 3;
			this.roofimage.Data = new ArrayList( this.roofimage.Width * this.roofimage.Height );
			for ( int k = 0; k < ( this.roofimage.Width * this.roofimage.Height ); k++ )
			{
				short ne = 0;
				this.roofimage.Data.Add( ne );
			}
			
			this.BasePoint = new Point( bounds.X - 1, bounds.Y - 1 );

			bounds.X -= this.BasePoint.X;
			bounds.Y -= this.BasePoint.Y;

			foreach ( Edge ed in this.Edges )
			{
				Edge e = new Edge( ed.Rect, ed.Up, ed.Tent );
				e.Rect.X -= this.BasePoint.X;
				e.Rect.Y -= this.BasePoint.Y;
				if ( ( e.Rect.Width > 0 ) && ( e.Rect.Height > 0 ) )
				{
					if ( e.Up )
					{
						for ( i = 0; i < e.Rect.Height + 1; i++ )
							AddVX ( e.Rect.Left, e.Rect.Right, e.Rect.Top + i, e.Tent ? System.Math.Min( i + 1, e.Rect.Height + 1 - i ) : 1000 );
					}
					else
					{
						for ( i = 0; i < e.Rect.Width + 1; i++ )
							AddVY( e.Rect.Top, e.Rect.Bottom, e.Rect.Left + i, e.Tent ? System.Math.Min( i + 1, e.Rect.Width + 1 - i ) : 1000 );
					}
				}
				else if ( e.Rect.Width > 0 )
				{
					int maxh = e.Tent ? 1 : 1000;
					if ( e.Up )
					{
						while ( true )
						{
							if ( !AddVX ( e.Rect.Left, e.Rect.Right, e.Rect.Top, maxh ) )
								break;
							maxh++;
							if ( ++e.Rect.Y >= bounds.Bottom )
								return false;
						}
					}
					else
					{
						while ( true )
						{
							if ( !AddVX ( e.Rect.Left, e.Rect.Right, e.Rect.Top, maxh ) )
								break;
							maxh++;
							if ( -- e.Rect.Y < 0 )
								return false;
						}
					}
				}
				else
				{
					int maxh = e.Tent ? 1 : 1000;
					if ( e.Up )
					{
						while ( true )
						{
							if ( !AddVY( e.Rect.Top, e.Rect.Bottom, e.Rect.Left, maxh ) )
								break;
							maxh++;
							if ( ++e.Rect.X >= bounds.Right )
								return false;
						}
					}
					else
					{
						while ( true )
						{
							if ( !AddVY( e.Rect.Top, e.Rect.Bottom, e.Rect.Left, maxh ) )
								break;
							maxh++;
							if ( --e.Rect.X < 0 )
								return false;
						}
					}
				}
			}
			return true;
		}


		// OK
		private bool AddVX( int mx1, int mx2, int my, int hlimit )
		{
			bool added = false;
			int h = 1;
			while ( mx2 >= mx1 )
			{
				if ( (short) this.roofimage.Data[ mx2 + my*this.roofimage.Width] < h )
				{
					this.roofimage.Data[ mx2 + my*this.roofimage.Width ] = (short) h;
					added = true;
				}
				if ( (short) this.roofimage.Data[ mx1 + my*this.roofimage.Width ] < h )
				{
					this.roofimage.Data[ mx1 + my*this.roofimage.Width ] = (short) h;
					added = true;
				}
				mx1++;
				mx2--;
				if ( h < hlimit )
					h++;
			}
			return added;
		}

		// OK
		private bool AddVY( int my1, int my2, int mx, int hlimit )
		{
			bool added = false;
			int h = 1;
			while ( my2 >= my1 )
			{
				if ( (short) this.roofimage.Data[ mx + my2*this.roofimage.Width ] < h )
				{
					this.roofimage.Data[ mx + my2*this.roofimage.Width ] = (short) h;
					added = true;
				}
				if ( (short) this.roofimage.Data[ mx + my1*this.roofimage.Width ] < h )
				{
					this.roofimage.Data[mx + my1*this.roofimage.Width ] = (short) h;
					added = true;
				}
				my1++;
				my2--;
				if ( h < hlimit )
					h++;
			}
			return added;
		}

		private void X1_Leave(object sender, System.EventArgs e)
		{
			try
			{
				this.x1 = System.Convert.ToInt16( this.X1.Text );
			}
			catch ( Exception )
			{
				this.x1 = -1;
				this.X1.Text = "";
			}
		}

		private void X2_Leave(object sender, System.EventArgs e)
		{
			try
			{
				this.x2 = System.Convert.ToInt16( this.X2.Text );
			}
			catch ( Exception )
			{
				this.x2 = -1;
				this.X2.Text = "";
			}
		}

		private void Y1_Leave(object sender, System.EventArgs e)
		{
			try
			{
				this.y1 = System.Convert.ToInt16( this.Y1.Text );
			}
			catch ( Exception )
			{
				this.y1 = -1;
				this.Y1.Text = "";
			}	
		}

		private void Y2_Leave(object sender, System.EventArgs e)
		{
			try
			{
				this.y2 = System.Convert.ToInt16( this.Y2.Text );
			}
			catch ( Exception )
			{
				this.y2 = -1;
				this.Y2.Text = "";
			}
		}

		private void ButtonRemoveLast_Click(object sender, System.EventArgs e)
		{
			if ( Edges.Count == 0 )
				return;

			this.Edges.RemoveAt( this.Edges.Count - 1 );
			Calculate();
			CheckRemove();
			this.roofimage.MakeBitmap( this.Preview.Width, this.Preview.Height );
			this.Preview.Image = this.roofimage.Img;

			if ( Edges.Count == 0 )
			{
				// Grey out the buttons
				this.ButtonCreate.Enabled = false;
				this.ButtonTest.Enabled = false;
			}
		}

		private void ButtonClear_Click(object sender, System.EventArgs e)
		{
			this.Edges.Clear();
			Calculate();
			CheckRemove();
			CheckGenerate();
			this.roofimage.MakeBitmap( this.Preview.Width, this.Preview.Height );
			this.Preview.Image = this.roofimage.Img;
		}

		private void X1_TextChanged(object sender, System.EventArgs e)
		{
			CheckAdd();
		}

		private void Y1_TextChanged(object sender, System.EventArgs e)
		{
			CheckAdd();
		}

		private void X2_TextChanged(object sender, System.EventArgs e)
		{
			CheckAdd();
		}

		private void Y2_TextChanged(object sender, System.EventArgs e)
		{
			CheckAdd();
		}

		private void ButtonCreate_Click(object sender, System.EventArgs e)
		{
			Generate( TestMode.NoTest );
		}

		private void AtHeight_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.z = System.Convert.ToInt16( AtHeight.Text );
			}
			catch
			{
				AtHeight.Text = "0";
				z = 0;
			}
			CheckGenerate();
		}

		private short LookupID( uint flags )
		{
			foreach ( TileMask tm in tileset.Tiles )
			{
				if (( flags & ~tm.Flags ) == 0 )
					return tm.Id;
			}
			return 0;
		}

		private Roofing.RoofFlag Compare( int middle, int relative )
		{
			if ( relative == 0 )
				return RoofFlag.Empty;
			if ( relative < 0 )
				relative = -relative;
			if ( relative == middle )
				return RoofFlag.Even;
			if ( relative < middle )
				return RoofFlag.Lower;
			if ( relative > middle )
				return RoofFlag.Higher;
			throw new Exception("Can't compare");
		}

		private bool Generate( TestMode testmode )
		{
			string seltypename = (string)this.RoofType.SelectedItem;

			foreach ( TileSet ts in this.TileSets )
			{
				if ( seltypename == ts.Name )
				{
					this.tileset = ts;
					break;
				}
			}

			short[] roofids = new short[ this.roofimage.Width * this.roofimage.Height ];
			int i;
			bool fail = false;

			for ( i = 0; i < this.roofimage.Width * this.roofimage.Height; i++ )
			{
				if ( (short)this.roofimage.Data[i] < 0 )
					this.roofimage.Data[i] = (short)( - (short)this.roofimage.Data[i] );
			}
			
			for ( i = 0; i < this.roofimage.Width * this.roofimage.Height ; i++ )
			{
				if ( (short)this.roofimage.Data[i] == (short) 0 )
					roofids[i] = 0;
				else
				{
					uint flags;
					flags =  GetFlags(
						MakeLine( i - this.roofimage.Width ),
						MakeLine( i ),
						MakeLine( i + this.roofimage.Width ) );

					roofids[i] = LookupID(flags);

					if ( roofids[i] == 0 )
					{
						this.roofimage.Data[i] = (short)( - ( (short) this.roofimage.Data[i] ) );
						fail = true;
					}

					if ( testmode != TestMode.NoTest )
					{
						bool corner = !((flags & ~0x88878778) != 0) ||
							!((flags & ~0x88887877) != 0) ||
							!((flags & ~0x77878888) != 0) ||
							!((flags & ~0x87787888) != 0) ||
							!((flags & ~0x87777777) != 0) ||
							!((flags & ~0x77877777) != 0) ||
							!((flags & ~0x77777877) != 0) ||
							!((flags & ~0x77777778) != 0);

						if ( testmode == TestMode.Test && !corner )
							roofids[i] = 0;
						if ( testmode == TestMode.Rest && corner )
							roofids[i] = 0;
					}
				}
			}

			if ( fail )
			{
				// Redraw image
				this.roofimage.MakeBitmap(100, 100);
				this.Preview.Image = this.roofimage.Img;

				if ( MessageBox.Show( this,
					"This tileset cannot generate the roof you requested. Missing pieces are marked in red. Would you like to generate this roof anyway?",
					"Generation failed",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question )
					== DialogResult.No )
				{
					return false;
				}
			}

			int j = 0;
			int p = 0;
			int dx;
			int dy = 0;

			int tilex = 0;
			int tiley = 0;
			int tilew = 0;
			int tileh = 0;

			int tilez = 0;
			int tileid = 0;

			string cmd;

			for ( j = 0; j < this.roofimage.Height; j++ )
			{
				for ( i = 0; i < this.roofimage.Width; i++, p++ )
				{
					if ( roofids[p] == 0 )
						continue;

					for ( dx = 1; dx + i < this.roofimage.Width; dx++ )
					{
						if ( ( ((short)roofids[ p + dx ]) != roofids[ p ] ) || ( ((short)roofimage.Data[p]) != ((short)roofimage.Data[p + dx]) ) )
							break;
					}

					for ( dy = 1; dy + j < this.roofimage.Height; dy++ )
					{
						if ( ( ((short)roofids[ p + roofimage.Width * dy ]) != roofids[p] ) || ( ((short) roofimage.Data[p]) != ((short)roofimage.Data[p + roofimage.Width * dy]) ) )
							break;
					}

					dx--;
					dy--;

					tilez = z + ( 3 * (short)roofimage.Data[p] ) - 3;
					tileid = roofids[p];

					if ( ( dx > 0 ) || ( dy > 0 ) )
					{
						tilex = BasePoint.X + i;
						tiley = BasePoint.Y + j;

						if ( dy > dx )
						{
							tilew = 1;
							tileh = dy + 1;

							while ( dy >= 0 )
							{
								roofids[p + roofimage.Width * dy ] = 0;
								dy--;
							}
						}
						else
						{
							tilew = dx + 1;
							tileh = 1;

							while ( dx >= 0 )
							{
								roofids[ p + dx ] = 0;
								dx--;
							}
						}
						i += dx;
						p += dx;
					}
					else
					{
						tilex = BasePoint.X + i;
						tiley = BasePoint.Y + j;
						tilew = 1;
						tileh = 1;
					}

					// Ok now send
					cmd = string.Format( "TileXYZ {0} {1} {2} {3} {4} static {5}\n",
						tilex, tiley, tilew, tileh, tilez, tileid );
					SendToUO( cmd );
				}
			}
			return true;
		}

		private short[] MakeLine( int index )
		{
			short[] line = new short[3];
			line[0] = (short) this.roofimage.Data[ index - 1 ];
			line[1] = (short) this.roofimage.Data[ index ];
			line[2] = (short) this.roofimage.Data[ index + 1 ];
			return line;
		}

		// OK
		private uint GetFlags( short[] pline, short[] line, short[] nline )
		{
			uint flags = 0;

			flags |= Compare(line[1], pline[0]);
			flags <<= 4;
			flags |= Compare(line[1], pline[1]);
			flags <<= 4;
			flags |= Compare(line[1], pline[2]);
			flags <<= 4;
			flags |= Compare(line[1], line[0]);
			flags <<= 4;
			flags |= Compare(line[1], line[2]);
			flags <<= 4;
			flags |= Compare(line[1], nline[0]);
			flags <<= 4;
			flags |= Compare(line[1], nline[1]);
			flags <<= 4;
			flags |= Compare(line[1], nline[2]);

			return flags;
		}

		// OK
		private uint Compare( short middle, short relative )
		{
			if ( relative == 0 )
				return 8; // empty
			if ( relative < 0 )
				relative = (short)-relative;

			if ( relative == middle )
				return 4; // Even

			if ( relative < middle )
				return 1; // Lower

			if ( relative > middle )
				return 2; // Higher

			return 0;
		}

		private void SendToUO( string command )
		{
			string prefix = ((TheBox)FindForm()).Options.CommandPrefix;
			TheBox.SendToUO( prefix + command );
		}

		private void ButtonTest_Click(object sender, System.EventArgs e)
		{
			if ( Generate( TestMode.Test ) )
			{
				if ( MessageBox.Show( this, "Would you like to generate the remaining pieces?", "Go on?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
					Generate( TestMode.Rest );
			}
		}

		private void ButtonWipe_Click(object sender, System.EventArgs e)
		{
			string prefix = ((TheBox)FindForm()).Options.CommandPrefix;
			TheBox.SendToUO( prefix + "WipeItems\n" );
		}
	}
}

namespace Box.Misc
{

	public class RoofImage
	{
		public ArrayList Data;
		public int Height;
		public int Width;

		public Bitmap Img;

		public RoofImage()
		{
			Data = new ArrayList();
			Height = 0;
			Width = 0;
			Img = new Bitmap(200,200);
		}

		private void PaintRect( System.Drawing.Rectangle rect, System.Drawing.Color color )
		{
			for ( int i = rect.Left; i <= rect.Right; i++ )
				for ( int j = rect.Top; j <= rect.Bottom; j++ )
					this.Img.SetPixel( i, j, color );
		}

		public void MakeBitmap(int width, int height)
		{
			// Make the whole Img blank
			for ( int x = 0; x < Img.Width; x++ )
				for ( int y = 0; y < Img.Height; y++ )
					Img.SetPixel( x, y, System.Drawing.Color.Silver );

			if ( this.Data.Count < 1 )
				return;

			int dw = 200 / this.Width;
			int dh = 200 / this.Height;

			if ( dh > dw )
				dh = dw;
			else
				dw = dh;

			System.Drawing.Point Base = Point.Empty;

			Base.X = ( 200 - this.Width * dw ) / 2;
			Base.Y = ( 200 - this.Height *  dh ) / 2;

			int i, j, p = 0;

			System.Drawing.Rectangle rc = Rectangle.Empty;

			for ( j = 0; j < this.Height; j++ )
			{
				rc.Y = j * dh + Base.Y ;
				rc.Height = (j+1) * dh + Base.Y - rc.Y ;

				for ( i = 0; i < this.Width; i++ )
				{
					rc.X = i * dw + Base.X;
					rc.Width = (i+1) * dw + Base.X - rc.X;

					if ( (short) this.Data[ p ] > 0 )
					{
						this.PaintRect( rc, Color.FromArgb( 0, 0, Math.Min(255,( (short)this.Data[p] * 10 ) + 100 )));
					}
					else if ( (short)this.Data[ p ] < 0 )
					{
						this.PaintRect ( rc, System.Drawing.Color.FromArgb((Math.Max(-255, (-(short)this.Data[p] * 10 ) + 100)), 0, 0 ) );
					}
					p++;
				}
			}
		}
	}
	public class TileMask
	{
		public uint Flags;
		public short Id;

		public TileMask()
		{
		}

		public TileMask( ushort f, short i )
		{
			Flags = f;
			Id = i;
		}

		public bool FromLine( string line )
		{
			try
			{
				int length = line.Length;

				string first = "";

				while ( line[0] != ' ' )
				{
					first += line[0];
					line = line.Substring( 1 );
				}

				// Remove any empty spaces in the middle
				while ( line[0] == ' ' )
					line = line.Substring ( 1 );

				// Make sure there's still text
				if ( line.Length < 1 )
					return false;

				string second = line;

				this.Flags = System.Convert.ToUInt32( first, 16 );
				this.Id = System.Convert.ToInt16( second, 16 );

				return true;
			}
			catch ( Exception )
			{
				return false;
			}
		}
	}

	public class TileSet
	{
		public string Name;
		public ArrayList Tiles;

		public TileSet()
		{
			Tiles = new ArrayList();
		}

		public TileSet( string name )
		{
			Name = name;
			Tiles = new ArrayList();
		}
	}

	public class Edge
	{
		public System.Drawing.Rectangle Rect;
		public bool Up;
		public bool Tent;

		public Edge ( Rectangle r, bool up, bool tent )
		{
			Rect = r;
			Up = up;
			Tent = tent;
		}

		public Edge()
		{
		}
	}
}
