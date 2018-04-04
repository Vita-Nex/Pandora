#region Header
// /*
//  *    2018 - Pandora - QuickSpawnGroup.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Data;
#endregion

namespace TheBox.Forms.Editors
{
	/// <summary>
	///     Summary description for QuickSpawnGroup.
	/// </summary>
	public class QuickSpawnGroup : Form
	{
		private Button bOk;
		private Button bCancel;
		private Label label1;
		private TextBox txType;
		private Button bAddType;
		private PropertyGrid pGrid;
		private DataGrid dGrid;
		private Button bClear;
		private Button bDelete;
		private DataGridTableStyle dataGridTableStyle1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public QuickSpawnGroup()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			dGrid.CaptionText = Pandora.Localization.TextProvider["Spawns.List"];
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
			var resources = new System.Resources.ResourceManager(typeof(QuickSpawnGroup));
			this.pGrid = new System.Windows.Forms.PropertyGrid();
			this.dGrid = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txType = new System.Windows.Forms.TextBox();
			this.bAddType = new System.Windows.Forms.Button();
			this.bClear = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// pGrid
			// 
			this.pGrid.CommandsVisibleIfAvailable = true;
			this.pGrid.LargeButtons = false;
			this.pGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pGrid.Location = new System.Drawing.Point(8, 8);
			this.pGrid.Name = "pGrid";
			this.pGrid.Size = new System.Drawing.Size(208, 264);
			this.pGrid.TabIndex = 0;
			this.pGrid.Text = "PropertyGrid";
			this.pGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// dGrid
			// 
			this.dGrid.AllowDrop = true;
			this.dGrid.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dGrid.BackColor = System.Drawing.Color.Gainsboro;
			this.dGrid.BackgroundColor = System.Drawing.Color.Silver;
			this.dGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dGrid.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dGrid.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dGrid.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dGrid.DataMember = "";
			this.dGrid.FlatMode = true;
			this.dGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dGrid.ForeColor = System.Drawing.Color.Black;
			this.dGrid.GridLineColor = System.Drawing.Color.DimGray;
			this.dGrid.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dGrid.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dGrid.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dGrid.HeaderForeColor = System.Drawing.Color.White;
			this.dGrid.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dGrid.Location = new System.Drawing.Point(224, 40);
			this.dGrid.Name = "dGrid";
			this.dGrid.ParentRowsBackColor = System.Drawing.Color.DarkGray;
			this.dGrid.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dGrid.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dGrid.SelectionForeColor = System.Drawing.Color.White;
			this.dGrid.Size = new System.Drawing.Size(208, 232);
			this.dGrid.TabIndex = 1;
			this.dGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {this.dataGridTableStyle1});
			this.dGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.dGrid_DragDrop);
			this.dGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.dGrid_DragEnter);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dGrid;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "List";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(360, 320);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 3;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(280, 320);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 4;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 280);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 64);
			this.label1.TabIndex = 5;
			this.label1.Text = "Spawns.Instructions";
			// 
			// txType
			// 
			this.txType.AllowDrop = true;
			this.txType.Location = new System.Drawing.Point(224, 280);
			this.txType.Name = "txType";
			this.txType.Size = new System.Drawing.Size(144, 20);
			this.txType.TabIndex = 7;
			this.txType.Text = "";
			this.txType.DragDrop += new System.Windows.Forms.DragEventHandler(this.txType_DragDrop);
			this.txType.DragEnter += new System.Windows.Forms.DragEventHandler(this.dGrid_DragEnter);
			// 
			// bAddType
			// 
			this.bAddType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAddType.Location = new System.Drawing.Point(376, 280);
			this.bAddType.Name = "bAddType";
			this.bAddType.Size = new System.Drawing.Size(56, 23);
			this.bAddType.TabIndex = 8;
			this.bAddType.Text = "Common.Add";
			this.bAddType.Click += new System.EventHandler(this.bAddType_Click);
			// 
			// bClear
			// 
			this.bClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClear.Location = new System.Drawing.Point(224, 8);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(80, 23);
			this.bClear.TabIndex = 9;
			this.bClear.Text = "Spawns.mClear";
			this.bClear.Click += new System.EventHandler(this.bClear_Click);
			// 
			// bDelete
			// 
			this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDelete.Location = new System.Drawing.Point(352, 8);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(80, 23);
			this.bDelete.TabIndex = 10;
			this.bDelete.Text = "Spawns.mDelete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// QuickSpawnGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 349);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.bAddType);
			this.Controls.Add(this.txType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.dGrid);
			this.Controls.Add(this.pGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "QuickSpawnGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Spawns.Title";
			this.Load += new System.EventHandler(this.QuickSpawnGroup_Load);
			((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private BoxSpawn m_Spawn;
		private BoxSpawn m_Backup;

		/// <summary>
		///     Occurs when the user is done with creating or editing a spawn
		/// </summary>
		public event EventHandler SpawnReady;

		protected virtual void OnSpawnReady(EventArgs e)
		{
			if (SpawnReady != null)
			{
				SpawnReady(this, e);
			}
		}

		/// <summary>
		///     Load: arrange all data
		/// </summary>
		private void QuickSpawnGroup_Load(object sender, EventArgs e)
		{
			pGrid.SelectedObject = Spawn;
			dGrid.DataSource = Spawn.Entries;
			dGrid.Refresh();
		}

		private void bAddType_Click(object sender, EventArgs e)
		{
			if (txType.Text.Length > 0)
			{
				var type = txType.Text;
				var exists = false;

				foreach (var entry in Spawn.Entries)
				{
					if (entry.Type.ToLower() == type.ToLower())
					{
						exists = true;
						return;
					}
				}

				if (exists)
				{
					MessageBox.Show(Pandora.Localization.TextProvider["Spawns.Exists"]);
				}
				else
				{
					// Actually add
					var entry = new BoxSpawnEntry();
					entry.Type = type;

					Spawn.Entries.Add(entry);

					dGrid.DataSource = null;
					dGrid.DataSource = Spawn.Entries;
					dGrid.Refresh();
				}

				txType.Text = "";
			}
		}

		private void dGrid_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				var type = e.Data.GetData(DataFormats.Text).ToString();

				var exists = false;

				foreach (var entry in Spawn.Entries)
				{
					if (entry.Type.ToLower() == type.ToLower())
					{
						exists = true;
						break;
					}
				}

				if (exists)
				{
					e.Effect = DragDropEffects.None;
				}
				else
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		private void dGrid_DragDrop(object sender, DragEventArgs e)
		{
			var type = e.Data.GetData(DataFormats.Text).ToString();

			var entry = new BoxSpawnEntry();
			entry.Type = type;

			Spawn.Entries.Add(entry);

			dGrid.DataSource = null;
			dGrid.DataSource = Spawn.Entries;
			dGrid.Refresh();
		}

		private void txType_DragDrop(object sender, DragEventArgs e)
		{
			var type = e.Data.GetData(DataFormats.Text).ToString();
			txType.Text = type;
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			if (Spawn.Entries.Count > 0)
			{
				var index = dGrid.CurrentCell.RowNumber;

				if (index > -1 && index < Spawn.Entries.Count)
				{
					dGrid.DataSource = null;

					Spawn.Entries.RemoveAt(index);

					dGrid.DataSource = Spawn.Entries;
					dGrid.Refresh();
				}
			}
		}

		private void bClear_Click(object sender, EventArgs e)
		{
			Spawn.Entries.Clear();

			dGrid.DataSource = null;
			dGrid.DataSource = Spawn.Entries;
			dGrid.Refresh();
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			if (m_Spawn.Name == null || m_Spawn.Name.Length == 0)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Spawns.NoName"]);
			}
			else if (m_Spawn.Entries.Count == 0)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Spawns.Empty"]);
			}
			else
			{
				DialogResult = DialogResult.OK;
				OnSpawnReady(new EventArgs());
				Close();
			}
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

			if (m_Backup != null)
			{
				// Only if there's a backup
				m_Spawn.Count = m_Backup.Count;
				m_Spawn.Entries.Clear();
				m_Spawn.Entries.AddRange(m_Backup.Entries);
				m_Spawn.Extra = m_Backup.Extra;
				m_Spawn.Group = m_Backup.Group;
				m_Spawn.HomeRange = m_Backup.HomeRange;
				m_Spawn.MaxDelay = m_Backup.MaxDelay;
				m_Spawn.MinDelay = m_Backup.MinDelay;
				m_Spawn.Name = m_Backup.Name;
				m_Spawn.Team = m_Backup.Team;
			}

			Close();
		}

		/// <summary>
		///     Gets or sets the spawn group edited
		/// </summary>
		public BoxSpawn Spawn
		{
			get
			{
				if (m_Spawn == null)
				{
					m_Spawn = new BoxSpawn();
				}

				return m_Spawn;
			}
			set
			{
				m_Backup = value.Clone() as BoxSpawn;
				m_Spawn = value;
			}
		}
	}
}