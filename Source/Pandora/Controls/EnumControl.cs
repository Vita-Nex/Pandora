#region Header
// /*
//  *    2018 - Pandora - EnumControl.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Data;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for EnumControl.
	/// </summary>
	public class EnumControl : UserControl
	{
		private Label label1;
		private ComboBox cmb;
		private Label lab;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public EnumControl()
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
			this.cmb = new System.Windows.Forms.ComboBox();
			this.lab = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "Props.SelectEnum";
			// 
			// cmb
			// 
			this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb.Location = new System.Drawing.Point(4, 52);
			this.cmb.Name = "cmb";
			this.cmb.Size = new System.Drawing.Size(96, 21);
			this.cmb.TabIndex = 1;
			this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
			// 
			// lab
			// 
			this.lab.Location = new System.Drawing.Point(4, 76);
			this.lab.Name = "lab";
			this.lab.Size = new System.Drawing.Size(96, 36);
			this.lab.TabIndex = 2;
			this.lab.Text = "label2";
			// 
			// EnumControl
			// 
			this.Controls.Add(this.lab);
			this.Controls.Add(this.cmb);
			this.Controls.Add(this.label1);
			this.Name = "EnumControl";
			this.Size = new System.Drawing.Size(104, 116);
			this.ResumeLayout(false);
		}
		#endregion

		private void cmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			Pandora.Prop.DisplayedValue = cmb.Text;
		}

		/// <summary>
		///     Sets the BoxEnum currently displayed
		/// </summary>
		public BoxEnum DisplayedEnum
		{
			set
			{
				lab.Text = value.Name;

				cmb.BeginUpdate();
				cmb.Items.Clear();
				var items = new string[value.Values.Count];
				value.Values.CopyTo(items);
				cmb.Items.AddRange(items);
				cmb.SelectedIndex = 0;
				cmb.EndUpdate();
			}
		}
	}
}