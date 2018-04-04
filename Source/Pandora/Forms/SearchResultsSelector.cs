#region Header
// /*
//  *    2018 - Pandora - SearchResultsSelector.cs
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
	///     Summary description for SearchResultsSelector.
	/// </summary>
	public class SearchResultsSelector : Form
	{
		private ListBox lst;
		private Button button1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public SearchResultsSelector()
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

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lst = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.Location = new System.Drawing.Point(4, 4);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(132, 108);
			this.lst.TabIndex = 0;
			this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(8, 114);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Common.Select";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// SearchResultsSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(138, 140);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lst);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SearchResultsSelector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Sets the paths available for selection
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<string> Paths
			// Issue 10 - End
		{
			set
			{
				lst.BeginUpdate();
				lst.Items.Clear();

				foreach (var s in value)
				{
					var path = s.Split('.');

					lst.Items.Add(path[path.Length - 1]);
				}

				lst.EndUpdate();
			}
		}

		private int m_SelectedClass;

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_SelectedClass = lst.SelectedIndex;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			if (lst.SelectedIndex > -1)
			{
				Close();
			}
		}

		/// <summary>
		///     Gets the index of the class selected
		/// </summary>
		public int SelectedClass { get { return m_SelectedClass; } }
	}
}