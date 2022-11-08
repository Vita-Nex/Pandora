#region Header
// /*
//  *    2018 - Pandora - Point3DControl.cs
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
	///     Summary description for Point3DControl.
	/// </summary>
	public class Point3DControl : UserControl
	{
		private Label label1;
		private Button button1;
		private Label label2;
		private Label label3;
		private Label label4;
		private NumericUpDown numX;
		private NumericUpDown numY;
		private NumericUpDown numZ;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public Point3DControl()
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
			this.label1 = new System.Windows.Forms.Label();
			this.numX = new System.Windows.Forms.NumericUpDown();
			this.numY = new System.Windows.Forms.NumericUpDown();
			this.numZ = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.numX).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numY).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numZ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Common.Location";
			// 
			// numX
			// 
			this.numX.Location = new System.Drawing.Point(40, 24);
			this.numX.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
			this.numX.Name = "numX";
			this.numX.Size = new System.Drawing.Size(56, 20);
			this.numX.TabIndex = 1;
			this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
			// 
			// numY
			// 
			this.numY.Location = new System.Drawing.Point(40, 48);
			this.numY.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
			this.numY.Name = "numY";
			this.numY.Size = new System.Drawing.Size(56, 20);
			this.numY.TabIndex = 2;
			this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
			// 
			// numZ
			// 
			this.numZ.Location = new System.Drawing.Point(40, 72);
			this.numZ.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
			this.numZ.Minimum = new decimal(new int[] { 128, 0, 0, -2147483648 });
			this.numZ.Name = "numZ";
			this.numZ.Size = new System.Drawing.Size(56, 20);
			this.numZ.TabIndex = 3;
			this.numZ.ValueChanged += new System.EventHandler(this.numZ_ValueChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(48, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "->";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Common.X";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Common.Y";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Common.Z";
			// 
			// Point3DControl
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.numZ);
			this.Controls.Add(this.numY);
			this.Controls.Add(this.numX);
			this.Controls.Add(this.label1);
			this.Name = "Point3DControl";
			this.Size = new System.Drawing.Size(104, 116);
			this.Load += new System.EventHandler(this.Point3DControl_Load);
			((System.ComponentModel.ISupportInitialize)this.numX).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numY).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numZ).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void Point3DControl_Load(object sender, EventArgs e)
		{
			try
			{
				numX.Value = Pandora.Profile.Props.PointX;
				numY.Value = Pandora.Profile.Props.PointY;
				numZ.Value = Pandora.Profile.Props.PointZ;
			}
			catch
			{ }
		}

		private void numX_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.PointX = (int)numX.Value;
		}

		private void numY_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.PointY = (int)numY.Value;
		}

		private void numZ_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Props.PointZ = (int)numZ.Value;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var s = String.Format(
				"{0} {1} {2}",
				Pandora.Profile.Props.PointX,
				Pandora.Profile.Props.PointY,
				Pandora.Profile.Props.PointZ);
			Pandora.Prop.DisplayedValue = s;
		}
	}
}