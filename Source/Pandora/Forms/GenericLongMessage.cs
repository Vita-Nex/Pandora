#region Header
// /*
//  *    2018 - Pandora - GenericLongMessage.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for GenericLongMessage.
	/// </summary>
	public class GenericLongMessage : Form
	{
		private TextBox tx;
		private Button bClose;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public GenericLongMessage(string text)
		{
			InitializeComponent();

			tx.Text = text;
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
			var resources = new System.Resources.ResourceManager(typeof(GenericLongMessage));
			this.tx = new System.Windows.Forms.TextBox();
			this.bClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tx
			// 
			this.tx.Anchor =
			System.Windows.Forms.AnchorStyles.Top |
													System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left |
												  System.Windows.Forms.AnchorStyles.Right;
			this.tx.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.tx.Location = new System.Drawing.Point(8, 8);
			this.tx.Multiline = true;
			this.tx.Name = "tx";
			this.tx.ReadOnly = true;
			this.tx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tx.Size = new System.Drawing.Size(280, 216);
			this.tx.TabIndex = 0;
			this.tx.Text = "textBox1";
			// 
			// bClose
			// 
			this.bClose.Anchor =
			System.Windows.Forms.AnchorStyles.Bottom |
												  System.Windows.Forms.AnchorStyles.Left;
			this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClose.Location = new System.Drawing.Point(118, 232);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(67, 23);
			this.bClose.TabIndex = 1;
			this.bClose.Text = "Exit";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// GenericLongMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 261);
			this.Controls.Add(this.bClose);
			this.Controls.Add(this.tx);
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "GenericLongMessage";
			this.SizeChanged += new System.EventHandler(this.GenericLongMessage_SizeChanged);
			this.Load += new System.EventHandler(this.GenericLongMessage_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void bClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void GenericLongMessage_SizeChanged(object sender, EventArgs e)
		{
			var left = (Width - bClose.Width) / 2;
			bClose.Location = new Point(left, bClose.Location.Y);
		}

		private void GenericLongMessage_Load(object sender, EventArgs e)
		{
			tx.Select(0, 0);
			_ = bClose.Focus();
		}
	}
}