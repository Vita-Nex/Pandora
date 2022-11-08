#region Header
// /*
//  *    2018 - Pandora - ProfileChooser.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Common;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for ProfileChooser.
	/// </summary>
	public class ProfileChooser : Form, IProfileChooser
	{
		/// <summary>
		///     The action selected by the user
		/// </summary>
		public enum Actions
		{
			/// <summary>
			///     Abore the action and exit
			/// </summary>
			Exit,

			/// <summary>
			///     Load a new profile
			/// </summary>
			LoadProfile,

			/// <summary>
			///     Create a new profile
			/// </summary>
			MakeNewProfile
		}

		/// <summary>
		///     Gets the profile selected by the user
		/// </summary>
		public string SelectedProfile { get; private set; }

		public bool UseDefault => chkDefault.Checked;

		/// <summary>
		///     Gets the action that should be performed after the chooser form is closed
		/// </summary>
		public Actions Action { get; private set; } = Actions.Exit;

		private Button bNew;
		private Button bChoose;
		private Button bExit;
		private ListBox list;
		private CheckBox chkDefault;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		/// <summary>
		///     Creates a new profile chooser form
		/// </summary>
		/// <param name="profiles">The list of profiles available</param>
		public ProfileChooser(ProfileManager profileManager)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			foreach (var s in profileManager.ProfileNames)
			{
				_ = list.Items.Add(s);
			}
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileChooser));
			this.bNew = new System.Windows.Forms.Button();
			this.bChoose = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.list = new System.Windows.Forms.ListBox();
			this.chkDefault = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// bNew
			// 
			this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNew.Location = new System.Drawing.Point(168, 40);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(72, 23);
			this.bNew.TabIndex = 1;
			this.bNew.Text = "New";
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bChoose
			// 
			this.bChoose.Enabled = false;
			this.bChoose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bChoose.Location = new System.Drawing.Point(168, 8);
			this.bChoose.Name = "bChoose";
			this.bChoose.Size = new System.Drawing.Size(72, 23);
			this.bChoose.TabIndex = 2;
			this.bChoose.Text = "Select";
			this.bChoose.Click += new System.EventHandler(this.bChoose_Click);
			// 
			// bExit
			// 
			this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bExit.Location = new System.Drawing.Point(168, 160);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(72, 23);
			this.bExit.TabIndex = 3;
			this.bExit.Text = "Exit";
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// list
			// 
			this.list.Location = new System.Drawing.Point(8, 8);
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(152, 147);
			this.list.TabIndex = 4;
			this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
			this.list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_MouseDown);
			// 
			// chkDefault
			// 
			this.chkDefault.Enabled = false;
			this.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkDefault.Location = new System.Drawing.Point(8, 160);
			this.chkDefault.Name = "chkDefault";
			this.chkDefault.Size = new System.Drawing.Size(144, 24);
			this.chkDefault.TabIndex = 5;
			this.chkDefault.Text = "Set as Default";
			// 
			// ProfileChooser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 189);
			this.Controls.Add(this.chkDefault);
			this.Controls.Add(this.list);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.bChoose);
			this.Controls.Add(this.bNew);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "ProfileChooser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Profile Chooser";
			// Issue 5 - Choosing profile box appears behind splash screen - http://code.google.com/p/pandorasbox3/issues/detail?id=5 - Kons
			this.TopMost = true;
			// Issue 5 - End
			this.Load += new System.EventHandler(this.ProfileChooser_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void list_SelectedIndexChanged(object sender, EventArgs e)
		{
			bChoose.Enabled = list.SelectedIndex != -1;
			chkDefault.Enabled = list.SelectedIndex != -1;
		}

		private void bChoose_Click(object sender, EventArgs e)
		{
			SelectedProfile = (string)list.SelectedItem;
			Action = Actions.LoadProfile;

			// Must be handled from dialog user
			//if ( chkDefault.Checked )
			//    ProfileManager.Instance.DefaultProfile = m_SelectedProfile;

			Close();
		}

		private void bNew_Click(object sender, EventArgs e)
		{
			Action = Actions.MakeNewProfile;
			Close();
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			Action = Actions.Exit;
			Close();
		}

		private void list_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks > 1 && list.SelectedItem != null && bChoose.Enabled)
			{
				bChoose.PerformClick();
			}
		}

		private void ProfileChooser_Load(object sender, EventArgs e)
		{
			Utility.BringWindowToFront(Handle);
		}
	}
}