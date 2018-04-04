#region Header
// /*
//  *    2018 - Pandora - RemoteEditor.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using TheBox.BoxServer;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for RemoteEditor.
	/// </summary>
	public class RemoteEditor : Form
	{
		private StatusBar sBar;
		private RichTextBox tb;
		private MainMenu mainMenu1;
		private MenuItem menuItem1;
		private MenuItem menuItem4;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private readonly string m_File;
		private string m_Text;
		private MenuItem miRemoteSave;
		private MenuItem miLocalSave;
		private MenuItem miExit;

		private SaveFileDialog SaveFile;
		// Issue 3 - Obsolete interface - Useless code - http://code.google.com/p/pandorasbox3/issues/detail?id=3&can=1 - Kons
		//private bool m_Modified = false;
		// Issue 3 - End

		public RemoteEditor(string file, string text)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_File = file;
			m_Text = text;
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
			this.sBar = new System.Windows.Forms.StatusBar();
			this.tb = new System.Windows.Forms.RichTextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miRemoteSave = new System.Windows.Forms.MenuItem();
			this.miLocalSave = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// sBar
			// 
			this.sBar.Location = new System.Drawing.Point(0, 371);
			this.sBar.Name = "sBar";
			this.sBar.Size = new System.Drawing.Size(536, 22);
			this.sBar.TabIndex = 0;
			// 
			// tb
			// 
			this.tb.AcceptsTab = true;
			this.tb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb.Font = new System.Drawing.Font(
				"Courier New",
				9F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.tb.HideSelection = false;
			this.tb.Location = new System.Drawing.Point(0, 0);
			this.tb.Name = "tb";
			this.tb.Size = new System.Drawing.Size(536, 371);
			this.tb.TabIndex = 1;
			this.tb.Text = "";
			this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[] {this.miRemoteSave, this.miLocalSave, this.menuItem4, this.miExit});
			this.menuItem1.Text = "File";
			// 
			// miRemoteSave
			// 
			this.miRemoteSave.Index = 0;
			this.miRemoteSave.Text = "Remote Save";
			this.miRemoteSave.Click += new System.EventHandler(this.miRemoteSave_Click);
			// 
			// miLocalSave
			// 
			this.miLocalSave.Index = 1;
			this.miLocalSave.Text = "Local Save";
			this.miLocalSave.Click += new System.EventHandler(this.miLocalSave_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 3;
			this.miExit.Text = "Exit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// RemoteEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 393);
			this.Controls.Add(this.tb);
			this.Controls.Add(this.sBar);
			this.Menu = this.mainMenu1;
			this.Name = "RemoteEditor";
			this.Text = "RemoteEditor";
			this.Load += new System.EventHandler(this.RemoteEditor_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void RemoteEditor_Load(object sender, EventArgs e)
		{
			tb.Text = m_Text;
		}

		private void tb_TextChanged(object sender, EventArgs e)
		{
			// Issue 3 - useless - http://code.google.com/p/pandorasbox3/issues/detail?id=3 - Kons
			//m_Modified = true;
			// Issue 3 - End
			m_Text = tb.Text;
		}

		private void miRemoteSave_Click(object sender, EventArgs e)
		{
			var msg = new FileTransport();
			msg.Filename = m_File;

			Pandora.Profile.Server.FillBoxMessage(msg);
			msg.Text = m_Text;

			var response = Pandora.BoxConnection.ProcessMessage(msg, true) as GenericOK;

			if (response != null)
			{
				// Success
				sBar.Text = "Remote save succesful";
			}
			else
			{
				sBar.Text = "Remote save failed";
			}
		}

		/// <summary>
		///     Gets the appropriate filter for a filename
		/// </summary>
		/// <param name="filename">The file to find the filter for</param>
		/// <returns>The string that can be used as filter in an open or save dialog</returns>
		private string GetFilter(string filename)
		{
			filename = filename.ToLower();

			if (filename.EndsWith(".cs"))
			{
				return "C# Files (*.cs)|*.cs";
			}
			if (filename.EndsWith(".vb"))
			{
				return "Visaul Basic Files (*.vb)|*.cs";
			}
			if (filename.EndsWith(".txt"))
			{
				return "Text Files (*.txt)|*.txt";
			}
			if (filename.EndsWith(".xml"))
			{
				return "Xml Files (*.xml)|*.xml";
			}

			return null;
		}

		private void miLocalSave_Click(object sender, EventArgs e)
		{
			SaveFile.Filter = GetFilter(m_File);
			SaveFile.FileName = Path.GetFileNameWithoutExtension(m_File);

			if (SaveFile.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				var writer = new StreamWriter(SaveFile.FileName, false);
				writer.Write(m_Text);
				writer.Close();

				sBar.Text = "File saved";
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Can't write file {0} to {1}", m_File, SaveFile.FileName);

				sBar.Text = "Save failed";
			}
		}

		private void miExit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}