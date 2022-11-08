#region Header
// /*
//  *    2018 - Pandora - MulManagerForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Common.Localization;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for MulManagerForm.
	/// </summary>
	public class MulManagerForm : Form
	{
		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private ListBox lst;
		private GroupBox groupBox1;
		private Label labDefFolder;
		private GroupBox groupBox2;
		private Label labCustFolder;
		private Button bSetCust;
		private Button bClearCust;
		private FolderBrowserDialog FolderBrowser;
		private OpenFileDialog FileBrowser;
		private Label labFile;
		private Button bChangeFile;
		private Button bDefaulFile;
		private Button bClose;
		private GroupBox grp;
		private Label label1;

		private readonly MulManager m_Manager;
		private readonly TextProvider m_Text;

		public MulManagerForm(MulManager manager)
		{
			InitializeComponent();
			m_Text = Pandora.Localization.TextProvider;
			Pandora.Localization.LocalizeControl(this);
			m_Manager = manager;
		}

		public MulManagerForm(MulManager manager, TextProvider tp)
		{
			InitializeComponent();
			m_Text = tp;

			Text = m_Text[Text];

			foreach (Control c in Controls)
			{
				c.Text = m_Text[c.Text];

				foreach (Control c2 in c.Controls)
				{
					c2.Text = m_Text[c2.Text];
				}
			}

			m_Manager = manager;
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
			var resources = new System.Resources.ResourceManager(typeof(MulManagerForm));
			this.lst = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labDefFolder = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bClearCust = new System.Windows.Forms.Button();
			this.bSetCust = new System.Windows.Forms.Button();
			this.labCustFolder = new System.Windows.Forms.Label();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
			this.grp = new System.Windows.Forms.GroupBox();
			this.bDefaulFile = new System.Windows.Forms.Button();
			this.bChangeFile = new System.Windows.Forms.Button();
			this.labFile = new System.Windows.Forms.Label();
			this.bClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grp.SuspendLayout();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.Location = new System.Drawing.Point(8, 8);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(120, 277);
			this.lst.TabIndex = 0;
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labDefFolder);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(136, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 40);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mul.DefFolder";
			// 
			// labDefFolder
			// 
			this.labDefFolder.Location = new System.Drawing.Point(8, 16);
			this.labDefFolder.Name = "labDefFolder";
			this.labDefFolder.Size = new System.Drawing.Size(312, 16);
			this.labDefFolder.TabIndex = 0;
			this.labDefFolder.Text = "label1";
			this.labDefFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bClearCust);
			this.groupBox2.Controls.Add(this.bSetCust);
			this.groupBox2.Controls.Add(this.labCustFolder);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(136, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 72);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mul.CustFolder";
			// 
			// bClearCust
			// 
			this.bClearCust.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClearCust.Location = new System.Drawing.Point(248, 40);
			this.bClearCust.Name = "bClearCust";
			this.bClearCust.TabIndex = 3;
			this.bClearCust.Text = "Common.Clear";
			this.bClearCust.Click += new System.EventHandler(this.bClearCust_Click);
			// 
			// bSetCust
			// 
			this.bSetCust.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSetCust.Location = new System.Drawing.Point(4, 40);
			this.bSetCust.Name = "bSetCust";
			this.bSetCust.TabIndex = 2;
			this.bSetCust.Text = "Common.Set";
			this.bSetCust.Click += new System.EventHandler(this.bSetCust_Click);
			// 
			// labCustFolder
			// 
			this.labCustFolder.Location = new System.Drawing.Point(8, 16);
			this.labCustFolder.Name = "labCustFolder";
			this.labCustFolder.Size = new System.Drawing.Size(312, 16);
			this.labCustFolder.TabIndex = 1;
			this.labCustFolder.Text = "label1";
			this.labCustFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FileBrowser
			// 
			this.FileBrowser.Filter = "Mul Files (*.mul)|*.mul|Idx Files (*.idx)|*.idx|Def Files (*.def)|*.def|All files" +
									  " (*.*)|*.*";
			// 
			// grp
			// 
			this.grp.Controls.Add(this.bDefaulFile);
			this.grp.Controls.Add(this.bChangeFile);
			this.grp.Controls.Add(this.labFile);
			this.grp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grp.Location = new System.Drawing.Point(136, 120);
			this.grp.Name = "grp";
			this.grp.Size = new System.Drawing.Size(328, 96);
			this.grp.TabIndex = 3;
			this.grp.TabStop = false;
			this.grp.Text = "Mul.SelFile";
			// 
			// bDefaulFile
			// 
			this.bDefaulFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDefaulFile.Location = new System.Drawing.Point(248, 64);
			this.bDefaulFile.Name = "bDefaulFile";
			this.bDefaulFile.TabIndex = 4;
			this.bDefaulFile.Text = "Common.Default";
			this.bDefaulFile.Click += new System.EventHandler(this.bDefaulFile_Click);
			// 
			// bChangeFile
			// 
			this.bChangeFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bChangeFile.Location = new System.Drawing.Point(8, 64);
			this.bChangeFile.Name = "bChangeFile";
			this.bChangeFile.TabIndex = 3;
			this.bChangeFile.Text = "Common.Change";
			this.bChangeFile.Click += new System.EventHandler(this.bChangeFile_Click);
			// 
			// labFile
			// 
			this.labFile.Location = new System.Drawing.Point(8, 16);
			this.labFile.Name = "labFile";
			this.labFile.Size = new System.Drawing.Size(312, 40);
			this.labFile.TabIndex = 0;
			this.labFile.Text = "label1";
			this.labFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labFile.Paint += new System.Windows.Forms.PaintEventHandler(this.labFile_Paint);
			// 
			// bClose
			// 
			this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClose.Location = new System.Drawing.Point(392, 264);
			this.bClose.Name = "bClose";
			this.bClose.TabIndex = 5;
			this.bClose.Text = "Common.Close";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(136, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(328, 32);
			this.label1.TabIndex = 6;
			this.label1.Text = "In order for these changes to take effect you must restart Pandora\'s Box.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// MulManagerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 290);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grp);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.bClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "MulManagerForm";
			this.ShowInTaskbar = false;
			this.Text = "Mul.Title";
			this.Load += new System.EventHandler(this.MulManagerForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.grp.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void MulManagerForm_Load(object sender, EventArgs e)
		{
			foreach (var s in m_Manager.SupportedFiles)
			{
				_ = lst.Items.Add(s);
			}

			if (m_Manager.DefaultFolder != null)
			{
				labDefFolder.Text = m_Manager.DefaultFolder;
			}
			else
			{
				labDefFolder.Text = m_Text["Options.NOUOFolder"];
			}

			if (m_Manager.CustomFolder != null)
			{
				labCustFolder.Text = m_Manager.CustomFolder;
			}
			else
			{
				labCustFolder.Text = m_Text["Common.None"];
			}
		}

		private string m_File;

		private string File
		{
			get => m_File;
			set
			{
				m_File = value;

				grp.Enabled = m_File != null;

				if (m_File != null)
				{
					var file = m_Manager[m_File];

					if (file == null)
					{
						labFile.Text = m_Text["Mul.NotFound"];
					}
					else
					{
						labFile.Text = file;
					}
				}
			}
		}

		private void bSetCust_Click(object sender, EventArgs e)
		{
			if (FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				m_Manager.CustomFolder = FolderBrowser.SelectedPath;
				labCustFolder.Text = FolderBrowser.SelectedPath;
			}
		}

		private void bClearCust_Click(object sender, EventArgs e)
		{
			m_Manager.CustomFolder = null;
			labCustFolder.Text = m_Text["Common.None"];
		}

		private void labFile_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(labFile, e.Graphics);
		}

		private void bClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lst.SelectedIndex > -1)
			{
				File = lst.SelectedItem as string;
			}
			else
			{
				File = null;
			}
		}

		private void bChangeFile_Click(object sender, EventArgs e)
		{
			if (FileBrowser.ShowDialog() == DialogResult.OK)
			{
				m_Manager[File] = FileBrowser.FileName;
				File = m_File;
			}
		}

		private void bDefaulFile_Click(object sender, EventArgs e)
		{
			m_Manager[File] = null;
			File = m_File;
		}

		private void label1_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(label1, e.Graphics);
		}
	}
}