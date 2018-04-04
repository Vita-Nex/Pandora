#region Header
// /*
//  *    2018 - Pandora - Point3DForm.cs
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
	///     Summary description for Point3DForm.
	/// </summary>
	public class Point3DForm : Form
	{
		private static int m_X;
		private static int m_Y;
		private static int m_Z;

		private Label label1;
		private NumericUpDown numX;
		private NumericUpDown numY;
		private Label label2;
		private Label label3;
		private NumericUpDown numZ;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public Point3DForm(int x, int y, int z)
			: this()
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public Point3DForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Issue 27:  	 Designer warnings - Tarion
			try
			{
				Pandora.Localization.LocalizeControl(this);
			}
			catch
			{ } // VS
			// End Issue 27
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
			this.label1 = new System.Windows.Forms.Label();
			this.numX = new System.Windows.Forms.NumericUpDown();
			this.numY = new System.Windows.Forms.NumericUpDown();
			this.numZ = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "X";
			// 
			// numX
			// 
			this.numX.Location = new System.Drawing.Point(28, 4);
			this.numX.Maximum = new System.Decimal(new int[] {7000, 0, 0, 0});
			this.numX.Name = "numX";
			this.numX.Size = new System.Drawing.Size(56, 20);
			this.numX.TabIndex = 1;
			this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
			// 
			// numY
			// 
			this.numY.Location = new System.Drawing.Point(28, 28);
			this.numY.Maximum = new System.Decimal(new int[] {7000, 0, 0, 0});
			this.numY.Name = "numY";
			this.numY.Size = new System.Drawing.Size(56, 20);
			this.numY.TabIndex = 2;
			this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
			// 
			// numZ
			// 
			this.numZ.Location = new System.Drawing.Point(28, 52);
			this.numZ.Maximum = new System.Decimal(new int[] {127, 0, 0, 0});
			this.numZ.Minimum = new System.Decimal(new int[] {128, 0, 0, -2147483648});
			this.numZ.Name = "numZ";
			this.numZ.Size = new System.Drawing.Size(56, 20);
			this.numZ.TabIndex = 3;
			this.numZ.ValueChanged += new System.EventHandler(this.numZ_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Y";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Z";
			// 
			// Point3DForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(88, 76);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numZ);
			this.Controls.Add(this.numY);
			this.Controls.Add(this.numX);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(88, 76);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(88, 76);
			this.Name = "Point3DForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.Point3DForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Point3DForm_Paint);
			this.Leave += new System.EventHandler(this.Point3DForm_Leave);
			this.Deactivate += new System.EventHandler(this.Point3DForm_Deactivate);
			((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void Point3DForm_Load(object sender, EventArgs e)
		{
			PointX = m_X;
			PointY = m_Y;
			PointZ = m_Z;

			Focus();
		}

		private void Point3DForm_Leave(object sender, EventArgs e)
		{
			Close();
		}

		private void Point3DForm_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			pen.Dispose();
		}

		private void Point3DForm_Deactivate(object sender, EventArgs e)
		{
			Close();
		}

		private void numX_ValueChanged(object sender, EventArgs e)
		{
			m_X = (int)numX.Value;
		}

		private void numY_ValueChanged(object sender, EventArgs e)
		{
			m_Y = (int)numY.Value;
		}

		private void numZ_ValueChanged(object sender, EventArgs e)
		{
			m_Z = (int)numZ.Value;
		}

		/// <summary>
		///     Gets or sets the X coordinate
		/// </summary>
		public int PointX { get { return (int)numX.Value; } set { numX.Value = value; } }

		/// <summary>
		///     Gets or sets the Y coordinate
		/// </summary>
		public int PointY { get { return (int)numY.Value; } set { numY.Value = value; } }

		/// <summary>
		///     Gets or sets the Z coordinate
		/// </summary>
		public int PointZ { get { return (int)numZ.Value; } set { numZ.Value = value; } }

		/// <summary>
		///     Gets the point selected by the user
		/// </summary>
		public string SelectedPoint { get { return string.Format("({0},{1},{2})", PointX, PointY, PointZ); } }
	}
}