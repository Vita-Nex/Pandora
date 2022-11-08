#region Header
// /*
//  *    2018 - Pandora - QuickLocation.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Data;
using TheBox.MapViewer;

using Ultima;
#endregion

namespace TheBox.Forms.Editors
{
	/// <summary>
	///     Quick new location dialog
	/// </summary>
	public class QuickLocation : Form
	{
		private MapViewer.MapViewer Map;
		private TextBox txName;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private NumericUpDown nX;
		private NumericUpDown nY;
		private NumericUpDown nZ;
		private Button bFromClient;
		private Button bOK;
		private Button bCancel;

		private Location m_CurrentLocation;
		private Button bTest;
		private Location m_Backup;
		private Button button1;
		private Button button2;

		private bool m_Updating;

		/// <summary>
		///     Gets or sets the location edited by the control
		/// </summary>
		public Location CurrentLocation
		{
			get => m_CurrentLocation;
			set
			{
				m_CurrentLocation = value;

				m_Backup = new Location
				{
					Name = value.Name,
					X = value.X,
					Y = value.Y,
					Z = value.Z
				};

				Map.Center = new Point(value.X, value.Y);

				m_Updating = true;

				txName.Text = value.Name;

				nX.Value = value.X;
				nY.Value = value.Y;
				nZ.Value = value.Z;

				m_Updating = false;
			}
		}

		public QuickLocation()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			txName.Text = "";
			m_CurrentLocation = new Location();
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
			var resources = new System.Resources.ResourceManager(typeof(QuickLocation));
			this.Map = new TheBox.MapViewer.MapViewer();
			this.txName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nX = new System.Windows.Forms.NumericUpDown();
			this.nY = new System.Windows.Forms.NumericUpDown();
			this.nZ = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.bTest = new System.Windows.Forms.Button();
			this.bFromClient = new System.Windows.Forms.Button();
			this.bOK = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.nX).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nY).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nZ).BeginInit();
			this.SuspendLayout();
			// 
			// Map
			// 
			this.Map.Center = new System.Drawing.Point(0, 0);
			this.Map.DisplayErrors = false;
			this.Map.DrawStatics = true;
			this.Map.Location = new System.Drawing.Point(240, 8);
			this.Map.Map = TheBox.MapViewer.Maps.Felucca;
			this.Map.Name = "Map";
			this.Map.ShowCross = true;
			this.Map.Size = new System.Drawing.Size(216, 216);
			this.Map.TabIndex = 0;
			this.Map.Text = "mapViewer1";
			this.Map.ZoomLevel = 0;
			this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
			// 
			// txName
			// 
			this.txName.Location = new System.Drawing.Point(48, 8);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(184, 20);
			this.txName.TabIndex = 1;
			this.txName.Text = "";
			this.txName.TextChanged += new System.EventHandler(this.txName_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Common.Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nX
			// 
			this.nX.Location = new System.Drawing.Point(24, 40);
			this.nX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nX.Name = "nX";
			this.nX.Size = new System.Drawing.Size(64, 20);
			this.nX.TabIndex = 3;
			this.nX.ValueChanged += new System.EventHandler(this.nX_ValueChanged);
			// 
			// nY
			// 
			this.nY.Location = new System.Drawing.Point(104, 40);
			this.nY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.nY.Name = "nY";
			this.nY.Size = new System.Drawing.Size(56, 20);
			this.nY.TabIndex = 4;
			this.nY.ValueChanged += new System.EventHandler(this.nY_ValueChanged);
			// 
			// nZ
			// 
			this.nZ.Location = new System.Drawing.Point(184, 40);
			this.nZ.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
			this.nZ.Minimum = new decimal(new int[] { 128, 0, 0, -2147483648 });
			this.nZ.Name = "nZ";
			this.nZ.Size = new System.Drawing.Size(48, 20);
			this.nZ.TabIndex = 5;
			this.nZ.ValueChanged += new System.EventHandler(this.nZ_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Common.X";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(88, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Common.Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(168, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Common.Z";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bTest
			// 
			this.bTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTest.Location = new System.Drawing.Point(160, 72);
			this.bTest.Name = "bTest";
			this.bTest.Size = new System.Drawing.Size(72, 23);
			this.bTest.TabIndex = 9;
			this.bTest.Text = "Common.Test";
			// 
			// bFromClient
			// 
			this.bFromClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bFromClient.Location = new System.Drawing.Point(8, 72);
			this.bFromClient.Name = "bFromClient";
			this.bFromClient.Size = new System.Drawing.Size(144, 23);
			this.bFromClient.TabIndex = 11;
			this.bFromClient.Text = "Travel.GetFromClient";
			this.bFromClient.Click += new System.EventHandler(this.bFromClient_Click);
			// 
			// bOK
			// 
			this.bOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOK.Location = new System.Drawing.Point(160, 200);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(72, 23);
			this.bOK.TabIndex = 12;
			this.bOK.Text = "Common.Ok";
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(8, 200);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(72, 23);
			this.bCancel.TabIndex = 13;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(160, 120);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Travel.ZoomIN";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(160, 152);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "Travel.ZoomOut";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// QuickLocation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(462, 230);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.bFromClient);
			this.Controls.Add(this.bTest);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nZ);
			this.Controls.Add(this.nY);
			this.Controls.Add(this.nX);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txName);
			this.Controls.Add(this.Map);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuickLocation";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Travel.NewLoc";
			((System.ComponentModel.ISupportInitialize)this.nX).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nY).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nZ).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void Map_MouseDown(object sender, MouseEventArgs e)
		{
			Map.Center = Map.ControlToMap(new Point(e.X, e.Y));

			m_Updating = true;

			m_CurrentLocation.X = (short)Map.Center.X;
			m_CurrentLocation.Y = (short)Map.Center.Y;
			m_CurrentLocation.Z = (sbyte)Map.GetMapHeight();

			nX.Value = m_CurrentLocation.X;
			nY.Value = m_CurrentLocation.Y;
			nZ.Value = m_CurrentLocation.Z;

			m_Updating = false;
		}

		private void bOK_Click(object sender, EventArgs e)
		{
			if (m_CurrentLocation.Name == null || m_CurrentLocation.Name.Length == 0)
			{
				_ = MessageBox.Show("The location name can't be empty");
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

			if (m_Backup != null)
			{
				m_CurrentLocation.X = m_Backup.X;
				m_CurrentLocation.Y = m_Backup.Y;
				m_CurrentLocation.Z = m_Backup.Z;
				m_CurrentLocation.Name = m_Backup.Name;
			}

			Close();
		}

		private void bFromClient_Click(object sender, EventArgs e)
		{
			Client.Calibrate();

			var x = 0;
			var y = 0;
			var z = 0;
			var facet = 0;

			_ = Client.FindLocation(ref x, ref y, ref z, ref facet);

			if (x == 0 && y == 0 && z == 0)
			{
				return;
			}

			if (facet != (int)Map.Map)
			{
				_ = MessageBox.Show(Pandora.Localization.TextProvider["Travel.WrongMap"]);
			}

			m_CurrentLocation.X = (short)x;
			nX.Value = x;
			m_CurrentLocation.Y = (short)y;
			nY.Value = y;
			m_CurrentLocation.Z = (sbyte)z;
			nZ.Value = z;
		}

		private void txName_TextChanged(object sender, EventArgs e)
		{
			if (!m_Updating)
			{
				m_CurrentLocation.Name = txName.Text;
			}
		}

		private void nX_ValueChanged(object sender, EventArgs e)
		{
			if (!m_Updating)
			{
				m_CurrentLocation.X = (short)nX.Value;
				Map.Center = new Point(m_CurrentLocation.X, m_CurrentLocation.Y);
			}
		}

		private void nY_ValueChanged(object sender, EventArgs e)
		{
			if (!m_Updating)
			{
				m_CurrentLocation.Y = (short)nY.Value;
				Map.Center = new Point(m_CurrentLocation.X, m_CurrentLocation.Y);
			}
		}

		private void nZ_ValueChanged(object sender, EventArgs e)
		{
			if (!m_Updating)
			{
				m_CurrentLocation.Z = (sbyte)nZ.Value;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Map.ZoomIn();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Map.ZoomOut();
		}

		/// <summary>
		///     Sets the map displayed on the control
		/// </summary>
		public int MapFile { set => Map.Map = (Maps)value; }
	}
}