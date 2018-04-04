#region Header
// /*
//  *    2018 - Pandora - LanguageSelector.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms.ProfileWizard
{
	/// <summary>
	///     Summary description for LanguageSelector.
	/// </summary>
	public class LanguageSelector : Form, ILanguageSelector
	{
		private Button btnOK;
		private ComboBox cmbLang;
		private readonly ProfileManager _profileManager;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public LanguageSelector(ProfileManager profileManager)
		{
			InitializeComponent();
			_profileManager = profileManager;
			DialogResult = DialogResult.Cancel;
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageSelector));
			this.cmbLang = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbLang
			// 
			this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLang.Location = new System.Drawing.Point(24, 16);
			this.cmbLang.Name = "cmbLang";
			this.cmbLang.Size = new System.Drawing.Size(152, 21);
			this.cmbLang.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(64, 48);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// LanguageSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(202, 82);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbLang);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LanguageSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pandora\'s Box";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.LanguageSelector_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void LanguageSelector_Load(object sender, EventArgs e)
		{
			// Read available languages
			var path = Path.Combine(Pandora.Folder, "Lang");

			var files = Directory.GetFiles(path);

			foreach (var s in files)
			{
				if (s.ToLower().EndsWith(".dll"))
				{
					// Possible language file
					var lang = Path.GetFileNameWithoutExtension(s);

					cmbLang.Items.Add(lang);
				}
			}

			cmbLang.SelectedIndex = 0;

			BringToFront();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			// Close and run the profile wizard
			Visible = false;
			_profileManager.CreateNewProfile(cmbLang.Text);

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}