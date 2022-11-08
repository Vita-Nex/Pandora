#region Header
// /*
//  *    2018 - Pandora - Tools.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.BoxServer;
using TheBox.Data;
using TheBox.Forms;
using TheBox.Options;
using TheBox.Roofing;
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Tools.
	/// </summary>
	public class Tools : UserControl
	{
		private GroupBox groupBox1;
		private TreeView tProgs;
		private Button bRun;
		private Button bAdd;
		private Button bEdit;
		private Button bDelete;
		private Button bAbout;
		private Button bExit;
		private Button bRoofing;
		private Button bOptions;
		private Button bLogin;
		private Button bScriptExplorer;
		private Button bRndTile;
		private GroupBox grpServer;
		private ContextMenu cmDatafiles;
		private MenuItem miBoxData;
		private MenuItem miProps;
		private MenuItem miSpawn;
		private Button bDatafiles;
		private Button bClientMap;
		private Button bClientList;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public Tools()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		private RoofingForm m_Roofing;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bDelete = new System.Windows.Forms.Button();
			this.bEdit = new System.Windows.Forms.Button();
			this.bAdd = new System.Windows.Forms.Button();
			this.bRun = new System.Windows.Forms.Button();
			this.tProgs = new System.Windows.Forms.TreeView();
			this.grpServer = new System.Windows.Forms.GroupBox();
			this.bRndTile = new System.Windows.Forms.Button();
			this.bScriptExplorer = new System.Windows.Forms.Button();
			this.bDatafiles = new System.Windows.Forms.Button();
			this.bLogin = new System.Windows.Forms.Button();
			this.bClientMap = new System.Windows.Forms.Button();
			this.bAbout = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.bRoofing = new System.Windows.Forms.Button();
			this.bOptions = new System.Windows.Forms.Button();
			this.cmDatafiles = new System.Windows.Forms.ContextMenu();
			this.miBoxData = new System.Windows.Forms.MenuItem();
			this.miProps = new System.Windows.Forms.MenuItem();
			this.miSpawn = new System.Windows.Forms.MenuItem();
			this.bClientList = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.grpServer.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bDelete);
			this.groupBox1.Controls.Add(this.bEdit);
			this.groupBox1.Controls.Add(this.bAdd);
			this.groupBox1.Controls.Add(this.bRun);
			this.groupBox1.Controls.Add(this.tProgs);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(264, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 140);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tools.Launcher";
			// 
			// bDelete
			// 
			this.bDelete.Enabled = false;
			this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDelete.Location = new System.Drawing.Point(160, 112);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(68, 23);
			this.bDelete.TabIndex = 4;
			this.bDelete.Text = "Common.Delete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// bEdit
			// 
			this.bEdit.Enabled = false;
			this.bEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bEdit.Location = new System.Drawing.Point(160, 80);
			this.bEdit.Name = "bEdit";
			this.bEdit.Size = new System.Drawing.Size(68, 23);
			this.bEdit.TabIndex = 3;
			this.bEdit.Text = "Common.Edit";
			this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
			// 
			// bAdd
			// 
			this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAdd.Location = new System.Drawing.Point(160, 48);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(68, 23);
			this.bAdd.TabIndex = 2;
			this.bAdd.Text = "Common.Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// bRun
			// 
			this.bRun.Enabled = false;
			this.bRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRun.Location = new System.Drawing.Point(160, 16);
			this.bRun.Name = "bRun";
			this.bRun.Size = new System.Drawing.Size(68, 23);
			this.bRun.TabIndex = 1;
			this.bRun.Text = "Common.Run";
			this.bRun.Click += new System.EventHandler(this.bRun_Click);
			// 
			// tProgs
			// 
			this.tProgs.HideSelection = false;
			this.tProgs.ImageIndex = -1;
			this.tProgs.Location = new System.Drawing.Point(8, 16);
			this.tProgs.Name = "tProgs";
			this.tProgs.SelectedImageIndex = -1;
			this.tProgs.ShowLines = false;
			this.tProgs.ShowPlusMinus = false;
			this.tProgs.ShowRootLines = false;
			this.tProgs.Size = new System.Drawing.Size(148, 120);
			this.tProgs.Sorted = true;
			this.tProgs.TabIndex = 0;
			this.tProgs.DoubleClick += new System.EventHandler(this.tProgs_DoubleClick);
			this.tProgs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tProgs_AfterSelect);
			// 
			// grpServer
			// 
			this.grpServer.Controls.Add(this.bClientList);
			this.grpServer.Controls.Add(this.bRndTile);
			this.grpServer.Controls.Add(this.bScriptExplorer);
			this.grpServer.Controls.Add(this.bDatafiles);
			this.grpServer.Controls.Add(this.bLogin);
			this.grpServer.Controls.Add(this.bClientMap);
			this.grpServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpServer.Location = new System.Drawing.Point(84, 0);
			this.grpServer.Name = "grpServer";
			this.grpServer.Size = new System.Drawing.Size(176, 140);
			this.grpServer.TabIndex = 2;
			this.grpServer.TabStop = false;
			this.grpServer.Text = "Common.Server";
			// 
			// bRndTile
			// 
			this.bRndTile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRndTile.Location = new System.Drawing.Point(92, 64);
			this.bRndTile.Name = "bRndTile";
			this.bRndTile.Size = new System.Drawing.Size(80, 23);
			this.bRndTile.TabIndex = 4;
			this.bRndTile.Text = "Server.RndTile";
			this.bRndTile.Click += new System.EventHandler(this.bRndTile_Click);
			// 
			// bScriptExplorer
			// 
			this.bScriptExplorer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bScriptExplorer.Location = new System.Drawing.Point(4, 64);
			this.bScriptExplorer.Name = "bScriptExplorer";
			this.bScriptExplorer.Size = new System.Drawing.Size(80, 23);
			this.bScriptExplorer.TabIndex = 3;
			this.bScriptExplorer.Text = "Server.ScriptEx";
			this.bScriptExplorer.Click += new System.EventHandler(this.bScriptExplorer_Click);
			// 
			// bDatafiles
			// 
			this.bDatafiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDatafiles.Location = new System.Drawing.Point(92, 24);
			this.bDatafiles.Name = "bDatafiles";
			this.bDatafiles.Size = new System.Drawing.Size(80, 23);
			this.bDatafiles.TabIndex = 2;
			this.bDatafiles.Text = "Server.Datafiles";
			this.bDatafiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bDatafiles_MouseDown);
			// 
			// bLogin
			// 
			this.bLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bLogin.Location = new System.Drawing.Point(4, 24);
			this.bLogin.Name = "bLogin";
			this.bLogin.Size = new System.Drawing.Size(80, 23);
			this.bLogin.TabIndex = 1;
			this.bLogin.Text = "Server.Login";
			this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
			// 
			// bClientMap
			// 
			this.bClientMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClientMap.Location = new System.Drawing.Point(92, 104);
			this.bClientMap.Name = "bClientMap";
			this.bClientMap.Size = new System.Drawing.Size(80, 23);
			this.bClientMap.TabIndex = 5;
			this.bClientMap.Text = "Tools.ClientMap";
			this.bClientMap.Click += new System.EventHandler(this.button1_Click);
			// 
			// bAbout
			// 
			this.bAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAbout.Location = new System.Drawing.Point(4, 88);
			this.bAbout.Name = "bAbout";
			this.bAbout.TabIndex = 3;
			this.bAbout.Text = "Common.About";
			this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
			// 
			// bExit
			// 
			this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bExit.Location = new System.Drawing.Point(4, 116);
			this.bExit.Name = "bExit";
			this.bExit.TabIndex = 5;
			this.bExit.Text = "Common.Exit";
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// bRoofing
			// 
			this.bRoofing.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRoofing.Location = new System.Drawing.Point(4, 4);
			this.bRoofing.Name = "bRoofing";
			this.bRoofing.TabIndex = 0;
			this.bRoofing.Text = "Roofing.Roofing";
			this.bRoofing.Click += new System.EventHandler(this.bRoofing_Click);
			// 
			// bOptions
			// 
			this.bOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOptions.Location = new System.Drawing.Point(4, 32);
			this.bOptions.Name = "bOptions";
			this.bOptions.Size = new System.Drawing.Size(75, 52);
			this.bOptions.TabIndex = 6;
			this.bOptions.Text = "Common.Options";
			this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
			// 
			// cmDatafiles
			// 
			this.cmDatafiles.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[] { this.miBoxData, this.miProps, this.miSpawn });
			// 
			// miBoxData
			// 
			this.miBoxData.Index = 0;
			this.miBoxData.Text = "Server.GetBox";
			this.miBoxData.Click += new System.EventHandler(this.miBoxData_Click);
			// 
			// miProps
			// 
			this.miProps.Index = 1;
			this.miProps.Text = "Server.GetProps";
			this.miProps.Click += new System.EventHandler(this.miProps_Click);
			// 
			// miSpawn
			// 
			this.miSpawn.Index = 2;
			this.miSpawn.Text = "Server.GetSpawn";
			this.miSpawn.Click += new System.EventHandler(this.miSpawn_Click);
			// 
			// bClientList
			// 
			this.bClientList.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClientList.Location = new System.Drawing.Point(4, 104);
			this.bClientList.Name = "bClientList";
			this.bClientList.Size = new System.Drawing.Size(80, 23);
			this.bClientList.TabIndex = 6;
			this.bClientList.Text = "ClientList.Title";
			this.bClientList.Click += new System.EventHandler(this.bClientList_Click);
			// 
			// Tools
			// 
			this.Controls.Add(this.bOptions);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.bAbout);
			this.Controls.Add(this.grpServer);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bRoofing);
			this.Name = "Tools";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Tools_Load);
			this.groupBox1.ResumeLayout(false);
			this.grpServer.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void bRoofing_Click(object sender, EventArgs e)
		{
			if (m_Roofing == null)
			{
				m_Roofing = new RoofingForm();
				m_Roofing.Closed += m_Roofing_Closed;
			}

			m_Roofing.Show();
		}

		private void m_Roofing_Closed(object sender, EventArgs e)
		{
			m_Roofing.Dispose();
			m_Roofing = null;
		}

		/// <summary>
		///     Perform initialization on load
		/// </summary>
		private void Tools_Load(object sender, EventArgs e)
		{
			try
			{
				Pandora.Profile.Launcher.OnEntriesChanged += Launcher_OnEntriesChanged;
				RefreshPrograms();
				EnableServer();

				Pandora.BoxConnection.OnlineChanged += Pandora_OnlineChanged;
				Pandora.Localization.LocalizeMenu(cmDatafiles);
			}
			catch
			{ } // VS
		}

		/// <summary>
		///     Entries have been changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Launcher_OnEntriesChanged(object sender, EventArgs e)
		{
			RefreshPrograms();
		}

		/// <summary>
		///     Refreshes the programs tree
		/// </summary>
		private void RefreshPrograms()
		{
			tProgs.BeginUpdate();
			tProgs.Nodes.Clear();

			var img = new ImageList();

			tProgs.Nodes.AddRange(Pandora.Profile.Launcher.GetTreeNodes(img));
			tProgs.EndUpdate();

			if (tProgs.ImageList != null)
			{
				tProgs.ImageList.Dispose();
				tProgs.ImageList = null;
			}

			if (tProgs.Nodes.Count > 0)
			{
				tProgs.ImageList = img;
			}

			tProgs.SelectedNode = null;
			SelectedEntry = null;
		}

		private LauncherEntry m_Entry;

		/// <summary>
		///     Sets the currently selected entry
		/// </summary>
		private LauncherEntry SelectedEntry
		{
			set
			{
				m_Entry = value;

				bRun.Enabled = m_Entry != null && m_Entry.Valid;
				bEdit.Enabled = m_Entry != null;
				bDelete.Enabled = m_Entry != null;
			}
		}

		/// <summary>
		///     Item selected on the tree
		/// </summary>
		private void tProgs_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				SelectedEntry = e.Node.Tag as LauncherEntry;
			}
			else
			{
				SelectedEntry = null;
			}
		}

		private void bRun_Click(object sender, EventArgs e)
		{
			if (m_Entry != null)
			{
				m_Entry.Run();
			}
		}

		private void bAdd_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Launcher.CreateNewEntry();
		}

		private void bEdit_Click(object sender, EventArgs e)
		{
			if (m_Entry != null)
			{
				Pandora.Profile.Launcher.EditEntry(m_Entry);
			}
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			if (m_Entry != null)
			{
				Pandora.Profile.Launcher.DeleteEntry(m_Entry);
			}
		}

		private void tProgs_DoubleClick(object sender, EventArgs e)
		{
			if (m_Entry != null)
			{
				m_Entry.Run();
			}
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			Pandora.BoxForm.Close();
		}

		private void bOptions_Click(object sender, EventArgs e)
		{
			// Do not acces the container from a static refference, should be solved better
			var form = new OptionsForm(Pandora.Container.Resolve<ProfileManager>());
			_ = form.ShowDialog();
		}

		/// <summary>
		///     Enables the buttons managing BoxServer
		/// </summary>
		private void EnableServer()
		{
			foreach (Control c in grpServer.Controls)
			{
				c.Enabled = Pandora.Profile.Server.Enabled && Pandora.BoxConnection.Connected;
			}

			bLogin.Enabled = Pandora.Profile.Server.Enabled && !Pandora.BoxConnection.Connected;
		}

		private void Pandora_OnlineChanged(object sender, EventArgs e)
		{
			EnableServer();
		}

		private void bLogin_Click(object sender, EventArgs e)
		{
			var form = new BoxServerForm(false);
			_ = form.ShowDialog();
		}

		private ScriptViewer m_ScriptExplorer;

		private void bScriptExplorer_Click(object sender, EventArgs e)
		{
			if (m_ScriptExplorer == null)
			{
				m_ScriptExplorer = new ScriptViewer();

				if (m_ScriptExplorer.GetFolderInfo())
				{
					m_ScriptExplorer.Closed += m_ScriptExplorer_Closed;
					m_ScriptExplorer.Show();
				}
				else
				{
					m_ScriptExplorer.Dispose();
					m_ScriptExplorer = null;
				}
			}
			else
			{
				m_ScriptExplorer.BringToFront();
			}
		}

		private void m_ScriptExplorer_Closed(object sender, EventArgs e)
		{
			m_ScriptExplorer.Dispose();
			m_ScriptExplorer = null;
		}

		private RandomTiler m_RandomTiler;

		private void bRndTile_Click(object sender, EventArgs e)
		{
			if (m_RandomTiler == null)
			{
				m_RandomTiler = new RandomTiler();
				m_RandomTiler.Closed += m_RandomTiler_Closed;
				m_RandomTiler.Show();
			}
			else
			{
				m_RandomTiler.BringToFront();
			}
		}

		private void m_RandomTiler_Closed(object sender, EventArgs e)
		{
			m_RandomTiler.Dispose();
			m_RandomTiler = null;
		}

		private void bDatafiles_MouseDown(object sender, MouseEventArgs e)
		{
			cmDatafiles.Show(bDatafiles, new Point(e.X, e.Y));
		}

		private void miBoxData_Click(object sender, EventArgs e)
		{
			var msg = new GetDatafile();
			Pandora.Profile.Server.FillBoxMessage(msg);
			msg.DataType = BoxDatafile.BoxData;

			var form = new BoxServerForm(msg);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				if (form.Response is ReturnDatafile data)
				{
					if (data.Data is BoxData bdata)
					{
						Pandora.BoxData = bdata;
						Pandora.BoxForm.UpdateBoxData();
						Pandora.BoxData.Save();
					}
				}
			}
		}

		private void miProps_Click(object sender, EventArgs e)
		{
			var msg = new GetDatafile();
			Pandora.Profile.Server.FillBoxMessage(msg);
			msg.DataType = BoxDatafile.PropsData;

			var form = new BoxServerForm(msg);

			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.Response is ReturnDatafile data)
				{
					if (data.Data is PropsData props)
					{
						PropsData.Props = props;
					}
				}
			}
		}

		private void miSpawn_Click(object sender, EventArgs e)
		{
			var msg = new GetDatafile();
			Pandora.Profile.Server.FillBoxMessage(msg);
			msg.DataType = BoxDatafile.SpawnData;

			var form = new BoxServerForm(msg);

			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.Response is ReturnDatafile data)
				{
					if (data.Data is SpawnData sdata)
					{
						SpawnData.SpawnProvider = sdata;
						Pandora.Profile.Travel.ShowSpawns = true;
						SpawnData.SpawnProvider.RefreshSpawns();
					}
				}
			}
		}

		private VisualClientList m_ClientMap;

		private void button1_Click(object sender, EventArgs e)
		{
			if (m_ClientMap == null)
			{
				m_ClientMap = new VisualClientList();
				m_ClientMap.Closed += m_ClientMap_Closed;
				m_ClientMap.Show();
			}
			else
			{
				m_ClientMap.BringToFront();
			}
		}

		private void m_ClientMap_Closed(object sender, EventArgs e)
		{
			m_ClientMap.Dispose();
			m_ClientMap = null;
		}

		private void bAbout_Click(object sender, EventArgs e)
		{
			var form = new AboutForm();
			_ = form.ShowDialog();
		}

		private ClientListForm m_ClientList;

		private void bClientList_Click(object sender, EventArgs e)
		{
			if (m_ClientList == null)
			{
				m_ClientList = new ClientListForm();
				m_ClientList.Closed += m_ClientList_Closed;
				m_ClientList.Show();
			}
			else
			{
				m_ClientList.BringToFront();
			}
		}

		private void m_ClientList_Closed(object sender, EventArgs e)
		{
			m_ClientList.Dispose();
			m_ClientList = null;
		}
	}
}