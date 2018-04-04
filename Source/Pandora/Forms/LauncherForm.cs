#region Header
// /*
//  *    2018 - Pandora - LauncherForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Options;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for LauncherForm.
	/// </summary>
	public class LauncherForm : Form
	{
		private Button bBrowse;
		private Label labFile;
		private Label label1;
		private TextBox txName;
		private CheckBox chkStartup;
		private Button bOk;
		private Button bCancel;
		private Label label2;
		private TextBox txArgs;
		private OpenFileDialog OpenFile;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public LauncherForm()
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
			var resources = new System.Resources.ResourceManager(typeof(LauncherForm));
			this.bBrowse = new System.Windows.Forms.Button();
			this.labFile = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txName = new System.Windows.Forms.TextBox();
			this.chkStartup = new System.Windows.Forms.CheckBox();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txArgs = new System.Windows.Forms.TextBox();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// bBrowse
			// 
			this.bBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bBrowse.Location = new System.Drawing.Point(8, 64);
			this.bBrowse.Name = "bBrowse";
			this.bBrowse.TabIndex = 0;
			this.bBrowse.Text = "Common.Browse";
			this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
			// 
			// labFile
			// 
			this.labFile.Location = new System.Drawing.Point(8, 40);
			this.labFile.Name = "labFile";
			this.labFile.Size = new System.Drawing.Size(360, 23);
			this.labFile.TabIndex = 1;
			this.labFile.Text = "Tools.Browse";
			this.labFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labFile.Paint += new System.Windows.Forms.PaintEventHandler(this.labFile_Paint);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tools.Desc";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txName
			// 
			this.txName.Location = new System.Drawing.Point(248, 8);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(120, 20);
			this.txName.TabIndex = 3;
			this.txName.Text = "";
			this.txName.TextChanged += new System.EventHandler(this.txName_TextChanged);
			// 
			// chkStartup
			// 
			this.chkStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkStartup.Location = new System.Drawing.Point(88, 64);
			this.chkStartup.Name = "chkStartup";
			this.chkStartup.Size = new System.Drawing.Size(280, 24);
			this.chkStartup.TabIndex = 4;
			this.chkStartup.Text = "Tools.Startup";
			// 
			// bOk
			// 
			this.bOk.Enabled = false;
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(184, 136);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 5;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(96, 136);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 6;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(360, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Tools.Args";
			// 
			// txArgs
			// 
			this.txArgs.Location = new System.Drawing.Point(8, 112);
			this.txArgs.Name = "txArgs";
			this.txArgs.Size = new System.Drawing.Size(360, 20);
			this.txArgs.TabIndex = 8;
			this.txArgs.Text = "";
			// 
			// OpenFile
			// 
			this.OpenFile.Filter = "All files (*.*)|*.*";
			// 
			// LauncherForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 165);
			this.ControlBox = false;
			this.Controls.Add(this.txArgs);
			this.Controls.Add(this.txName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.chkStartup);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labFile);
			this.Controls.Add(this.bBrowse);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LauncherForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tools.FormTitle";
			this.ResumeLayout(false);
		}
		#endregion

		private void labFile_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labFile, e.Graphics);
		}

		private void EnableButton()
		{
			bOk.Enabled = txName.Text.Length > 0 && labFile.Text != Pandora.Localization.TextProvider["Tools.Browse"] &&
						  labFile.Text.Length > 0;
		}

		private LauncherEntry m_Entry;

		private void bBrowse_Click(object sender, EventArgs e)
		{
			if (OpenFile.ShowDialog() == DialogResult.OK)
			{
				labFile.Text = OpenFile.FileName;
			}

			EnableButton();
		}

		private void txName_TextChanged(object sender, EventArgs e)
		{
			EnableButton();
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			if (m_Entry == null)
				m_Entry = new LauncherEntry();

			m_Entry.Path = labFile.Text;
			m_Entry.Name = txName.Text;

			if (txArgs.Text.Length > 0)
				m_Entry.Arguments = txArgs.Text;

			m_Entry.RunOnStartup = chkStartup.Checked;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///     Gets or sets the launcher entry edited by this form
		/// </summary>
		public LauncherEntry SelectedEntry
		{
			get { return m_Entry; }
			set
			{
				m_Entry = value;

				labFile.Text = m_Entry.Path;
				txName.Text = m_Entry.Name;
				txArgs.Text = m_Entry.Arguments;
				chkStartup.Checked = m_Entry.RunOnStartup;
			}
		}
	}
}