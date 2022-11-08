#region Header
// /*
//  *    2018 - Pandora - PointForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for PointForm.
	/// </summary>
	public class PointForm : Form
	{
		private NumericUpDown numX;
		private NumericUpDown numY;
		private NumericUpDown numZ;
		private Button bOk;
		private Button bCancel;
		private Label label1;
		private Label label2;
		private Label label3;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public PointForm()
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

		/// <summary>
		///     Gets the X coordinate of the selected point
		/// </summary>
		public int PointX => (int)numX.Value;

		/// <summary>
		///     Gets the Y coordinate of the selected point
		/// </summary>
		public int PointY => (int)numY.Value;

		/// <summary>
		///     Gets the Z coordinate of the selected point
		/// </summary>
		public int PointZ => (int)numZ.Value;

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			var resources = new System.Resources.ResourceManager(typeof(PointForm));
			this.numX = new System.Windows.Forms.NumericUpDown();
			this.numY = new System.Windows.Forms.NumericUpDown();
			this.numZ = new System.Windows.Forms.NumericUpDown();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.numX).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numY).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numZ).BeginInit();
			this.SuspendLayout();
			// 
			// numX
			// 
			this.numX.Location = new System.Drawing.Point(32, 8);
			this.numX.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
			this.numX.Name = "numX";
			this.numX.Size = new System.Drawing.Size(56, 20);
			this.numX.TabIndex = 0;
			// 
			// numY
			// 
			this.numY.Location = new System.Drawing.Point(120, 8);
			this.numY.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
			this.numY.Name = "numY";
			this.numY.Size = new System.Drawing.Size(56, 20);
			this.numY.TabIndex = 1;
			// 
			// numZ
			// 
			this.numZ.Location = new System.Drawing.Point(208, 8);
			this.numZ.Name = "numZ";
			this.numZ.Size = new System.Drawing.Size(56, 20);
			this.numZ.TabIndex = 2;
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(192, 40);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 3;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(104, 40);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 4;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Common.X";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(96, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Common.Y";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(184, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Common.Z";
			// 
			// PointForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 69);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.numZ);
			this.Controls.Add(this.numY);
			this.Controls.Add(this.numX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "PointForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Misc.FindLoc";
			((System.ComponentModel.ISupportInitialize)this.numX).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numY).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numZ).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void bOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}