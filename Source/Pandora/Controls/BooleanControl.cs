#region Header
// /*
//  *    2018 - Pandora - BooleanControl.cs
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
	///     Summary description for BooleanControl.
	/// </summary>
	public class BooleanControl : UserControl
	{
		private Button bTrue;
		private Button bFlase;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public BooleanControl()
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
			this.bTrue = new System.Windows.Forms.Button();
			this.bFlase = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bTrue
			// 
			this.bTrue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTrue.Location = new System.Drawing.Point(16, 32);
			this.bTrue.Name = "bTrue";
			this.bTrue.TabIndex = 0;
			this.bTrue.Text = "Common.True";
			this.bTrue.Click += new System.EventHandler(this.bTrue_Click);
			// 
			// bFlase
			// 
			this.bFlase.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bFlase.Location = new System.Drawing.Point(16, 64);
			this.bFlase.Name = "bFlase";
			this.bFlase.TabIndex = 1;
			this.bFlase.Text = "Common.False";
			this.bFlase.Click += new System.EventHandler(this.bFlase_Click);
			// 
			// BooleanControl
			// 
			this.Controls.Add(this.bFlase);
			this.Controls.Add(this.bTrue);
			this.Name = "BooleanControl";
			this.Size = new System.Drawing.Size(104, 116);
			this.ResumeLayout(false);
		}
		#endregion

		private void bTrue_Click(object sender, EventArgs e)
		{
			Pandora.Prop.DisplayedValue = "true";
		}

		private void bFlase_Click(object sender, EventArgs e)
		{
			Pandora.Prop.DisplayedValue = "false";
		}
	}
}