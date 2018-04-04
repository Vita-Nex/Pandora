#region Header
// /*
//  *    2018 - Pandora - StringListForm.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for StringListForm.
	/// </summary>
	public class StringListForm : Form
	{
		private TextBox tx;
		private Label label1;
		private Button bOk;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public StringListForm()
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
			var resources = new System.Resources.ResourceManager(typeof(StringListForm));
			this.tx = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tx
			// 
			this.tx.Location = new System.Drawing.Point(8, 32);
			this.tx.Multiline = true;
			this.tx.Name = "tx";
			this.tx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tx.Size = new System.Drawing.Size(320, 192);
			this.tx.TabIndex = 0;
			this.tx.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Misc.StringList";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(256, 232);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 2;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// StringListForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 258);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tx);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StringListForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Misc.StringListTitle";
			this.ResumeLayout(false);
		}
		#endregion

		private void bOk_Click(object sender, EventArgs e)
		{
			Close();
		}

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<string> Strings
			// Issue 10 - End
		{
			get
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var list = new List<string>();
				// Issue 10 - End

				foreach (var s in tx.Lines)
				{
					var add = s.Trim();
					if (add.Length > 0)
						list.Add(add);
				}

				return list;
			}
			set
			{
				var list = new string[value.Count];

				for (var i = 0; i < list.Length; i++)
				{
					list[i] = value[i];
				}

				tx.Lines = list;
			}
		}
	}
}