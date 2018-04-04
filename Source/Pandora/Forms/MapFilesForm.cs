#region Header
// /*
//  *    2018 - Pandora - MapFilesForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for MapFilesForm.
	/// </summary>
	public class MapFilesForm : Form
	{
		private ProgressBar pBar;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public MapFilesForm()
		{
			InitializeComponent();
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
			var resources = new System.Resources.ResourceManager(typeof(MapFilesForm));
			this.pBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// pBar
			// 
			this.pBar.Location = new System.Drawing.Point(8, 8);
			this.pBar.Name = "pBar";
			this.pBar.Size = new System.Drawing.Size(440, 23);
			this.pBar.TabIndex = 0;
			// 
			// MapFilesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 37);
			this.ControlBox = false;
			this.Controls.Add(this.pBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MapFilesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.MapFilesForm_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void MapFilesForm_Load(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(DoWork);
		}

		private void DoWork(object o)
		{
			Pandora.Profile.GenerateMaps(pBar);

			Close();
		}
	}
}