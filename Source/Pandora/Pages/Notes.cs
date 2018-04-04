#region Header
// /*
//  *    2018 - Pandora - Notes.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Data;
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Notes.
	/// </summary>
	public class Notes : UserControl
	{
		private Panel panel1;
		private TreeView tNotes;
		private Splitter splitter1;
		private Panel panel2;
		private ComboBox cmbPriority;
		private TextBox txName;
		private GroupBox groupBox1;
		private Button bAdd;
		private Button bDelete;
		private ComboBox cmbAscending;
		private ComboBox cmbType;
		private IContainer components;
		private Label labCreated;

		private Note m_Note;
		private ImageList imgPriority;
		private TextBox txText;
		private Panel panel3;
		private LinkLabel lnkLocations;
		private bool m_Running;

		/// <summary>
		///     Gets or sets the currently selected node
		/// </summary>
		private Note SelectedNote
		{
			get { return m_Note; }
			set
			{
				m_Note = value;

				txName.Enabled = m_Note != null;
				txText.Enabled = m_Note != null;
				cmbPriority.Enabled = m_Note != null;
				bDelete.Enabled = m_Note != null;
				lnkLocations.Enabled = m_Note != null;

				if (m_Note == null)
				{
					txName.Text = "";
					txText.Text = "";
					labCreated.Text = "";
				}
				else
				{
					txName.Text = m_Note.Name;
					cmbPriority.SelectedIndex = (int)m_Note.Priority;
					txText.Lines = m_Note.Text;
					labCreated.Text = m_Note.CreatedString;

					txText.Focus();
				}
			}
		}

		public Notes()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(Notes));
			this.panel1 = new System.Windows.Forms.Panel();
			this.txText = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labCreated = new System.Windows.Forms.Label();
			this.lnkLocations = new System.Windows.Forms.LinkLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txName = new System.Windows.Forms.TextBox();
			this.cmbPriority = new System.Windows.Forms.ComboBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tNotes = new System.Windows.Forms.TreeView();
			this.imgPriority = new System.Windows.Forms.ImageList(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.cmbAscending = new System.Windows.Forms.ComboBox();
			this.bAdd = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txText);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.tNotes);
			this.panel1.Location = new System.Drawing.Point(112, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(382, 138);
			this.panel1.TabIndex = 1;
			// 
			// txText
			// 
			this.txText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txText.Enabled = false;
			this.txText.Location = new System.Drawing.Point(124, 24);
			this.txText.Multiline = true;
			this.txText.Name = "txText";
			this.txText.Size = new System.Drawing.Size(258, 94);
			this.txText.TabIndex = 8;
			this.txText.TextChanged += new System.EventHandler(this.txText_TextChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.labCreated);
			this.panel3.Controls.Add(this.lnkLocations);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(124, 118);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(258, 20);
			this.panel3.TabIndex = 9;
			// 
			// labCreated
			// 
			this.labCreated.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labCreated.Location = new System.Drawing.Point(0, 0);
			this.labCreated.Name = "labCreated";
			this.labCreated.Size = new System.Drawing.Size(202, 20);
			this.labCreated.TabIndex = 7;
			this.labCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lnkLocations
			// 
			this.lnkLocations.Dock = System.Windows.Forms.DockStyle.Right;
			this.lnkLocations.Location = new System.Drawing.Point(202, 0);
			this.lnkLocations.Name = "lnkLocations";
			this.lnkLocations.Size = new System.Drawing.Size(56, 20);
			this.lnkLocations.TabIndex = 8;
			this.lnkLocations.TabStop = true;
			this.lnkLocations.Text = "Notes.Locs";
			this.lnkLocations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkLocations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkLocations_MouseDown);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txName);
			this.panel2.Controls.Add(this.cmbPriority);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(124, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(258, 24);
			this.panel2.TabIndex = 5;
			// 
			// txName
			// 
			this.txName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txName.Enabled = false;
			this.txName.Location = new System.Drawing.Point(0, 0);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(174, 20);
			this.txName.TabIndex = 4;
			this.txName.TextChanged += new System.EventHandler(this.txName_TextChanged);
			// 
			// cmbPriority
			// 
			this.cmbPriority.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPriority.Enabled = false;
			this.cmbPriority.Location = new System.Drawing.Point(174, 0);
			this.cmbPriority.Name = "cmbPriority";
			this.cmbPriority.Size = new System.Drawing.Size(84, 21);
			this.cmbPriority.TabIndex = 3;
			this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(121, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 138);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
			// 
			// tNotes
			// 
			this.tNotes.Dock = System.Windows.Forms.DockStyle.Left;
			this.tNotes.HideSelection = false;
			this.tNotes.ImageIndex = 0;
			this.tNotes.ImageList = this.imgPriority;
			this.tNotes.Location = new System.Drawing.Point(0, 0);
			this.tNotes.Name = "tNotes";
			this.tNotes.SelectedImageIndex = 0;
			this.tNotes.ShowLines = false;
			this.tNotes.ShowPlusMinus = false;
			this.tNotes.ShowRootLines = false;
			this.tNotes.Size = new System.Drawing.Size(121, 138);
			this.tNotes.TabIndex = 1;
			this.tNotes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tNotes_AfterSelect);
			// 
			// imgPriority
			// 
			this.imgPriority.ImageStream =
				((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPriority.ImageStream")));
			this.imgPriority.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPriority.Images.SetKeyName(0, "");
			this.imgPriority.Images.SetKeyName(1, "");
			this.imgPriority.Images.SetKeyName(2, "");
			this.imgPriority.Images.SetKeyName(3, "");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbType);
			this.groupBox1.Controls.Add(this.cmbAscending);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(4, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(104, 68);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sorting";
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Location = new System.Drawing.Point(4, 44);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(96, 21);
			this.cmbType.TabIndex = 1;
			this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
			// 
			// cmbAscending
			// 
			this.cmbAscending.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAscending.Location = new System.Drawing.Point(4, 16);
			this.cmbAscending.Name = "cmbAscending";
			this.cmbAscending.Size = new System.Drawing.Size(96, 21);
			this.cmbAscending.TabIndex = 0;
			this.cmbAscending.SelectedIndexChanged += new System.EventHandler(this.cmbAscending_SelectedIndexChanged);
			// 
			// bAdd
			// 
			this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAdd.Location = new System.Drawing.Point(20, 8);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(72, 23);
			this.bAdd.TabIndex = 3;
			this.bAdd.Text = "Notes.New";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// bDelete
			// 
			this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDelete.Location = new System.Drawing.Point(20, 40);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(72, 23);
			this.bDelete.TabIndex = 4;
			this.bDelete.Text = "Common.Delete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// Notes
			// 
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "Notes";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Notes_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void Notes_Load(object sender, EventArgs e)
		{
			try
			{
				if (Pandora.Profile.General.NotesSplitter > 0)
				{
					splitter1.SplitPosition = Pandora.Profile.General.NotesSplitter;
				}

				cmbAscending.Items.Add(Pandora.Localization.TextProvider["Notes.Ascending"]);
				cmbAscending.Items.Add(Pandora.Localization.TextProvider["Notes.Descending"]);

				cmbType.Items.Add(Pandora.Localization.TextProvider["Common.Name"]);
				cmbType.Items.Add(Pandora.Localization.TextProvider["Notes.Date"]);
				cmbType.Items.Add(Pandora.Localization.TextProvider["Notes.Priority"]);

				cmbPriority.Items.Add(Pandora.Localization.TextProvider["Notes.Low"]);
				cmbPriority.Items.Add(Pandora.Localization.TextProvider["Notes.Normal"]);
				cmbPriority.Items.Add(Pandora.Localization.TextProvider["Notes.High"]);
				cmbPriority.Items.Add(Pandora.Localization.TextProvider["Notes.Urgent"]);
				cmbPriority.SelectedIndex = 1;

				// Read the stored notes
				RefreshNotes(null);

				if (Pandora.Profile.Notes.AscendingSorting)
					cmbAscending.SelectedIndex = 0;
				else
					cmbAscending.SelectedIndex = 1;

				cmbType.SelectedIndex = (int)Pandora.Profile.Notes.NoteSorting;
			}
			catch
			{ } // VS

			m_Running = true;
		}

		/// <summary>
		///     Refreshes the list of notes
		/// </summary>
		/// <param name="select">The note that should be selected after the refresh</param>
		private void RefreshNotes(Note select)
		{
			tNotes.BeginUpdate();
			tNotes.Nodes.Clear();

			tNotes.Nodes.AddRange(Pandora.Profile.Notes.TreeNodes);

			tNotes.EndUpdate();

			if (select != null)
			{
				foreach (TreeNode node in tNotes.Nodes)
				{
					if ((node.Tag as Note) == select)
					{
						tNotes.SelectedNode = node;
						break;
					}
				}
			}
		}

		/// <summary>
		///     Changes the priority of the current note
		/// </summary>
		/// <param name="priority">The new priority</param>
		private void ChangePriority(NotePriority priority)
		{
			if (!m_Running)
				return;

			if (SelectedNote != null && SelectedNote.Priority != priority)
			{
				SelectedNote.Priority = priority;
				tNotes.SelectedNode.ImageIndex = (int)priority;
				tNotes.SelectedNode.SelectedImageIndex = (int)priority;

				if (Pandora.Profile.Notes.NoteSorting == NoteSorting.Priority)
				{
					Pandora.Profile.Notes.NotesList.Sort();
					RefreshNotes(SelectedNote);
				}
			}
		}

		/// <summary>
		///     Changing the priority for the current note
		/// </summary>
		private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!m_Running)
				return;

			ChangePriority((NotePriority)cmbPriority.SelectedIndex);
		}

		/// <summary>
		///     Update the name of the selected note
		/// </summary>
		private void txName_TextChanged(object sender, EventArgs e)
		{
			if (!m_Running || SelectedNote == null)
				return;

			SelectedNote.Name = txName.Text;
			tNotes.SelectedNode.Text = txName.Text;
		}

		/// <summary>
		///     Update the text of the note
		/// </summary>
		private void txText_TextChanged(object sender, EventArgs e)
		{
			if (!m_Running || SelectedNote == null)
				return;

			SelectedNote.Text = txText.Lines;
		}

		/// <summary>
		///     Create a new note
		/// </summary>
		private void bAdd_Click(object sender, EventArgs e)
		{
			var note = new Note("Note");
			var node = new TreeNode("Note");
			node.Tag = note;

			node.ImageIndex = (int)NotePriority.Normal;
			node.SelectedImageIndex = (int)NotePriority.Normal;

			Pandora.Profile.Notes.NotesList.Add(note);

			tNotes.Nodes.Add(node);
			tNotes.SelectedNode = node;

			txName.Text = "Note";
		}

		/// <summary>
		///     Selection of a note on the tree
		/// </summary>
		private void tNotes_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				SelectedNote = e.Node.Tag as Note;
			}
		}

		/// <summary>
		///     Delete the selected note
		/// </summary>
		private void bDelete_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Notes.NotesList.Remove(SelectedNote);
			tNotes.Nodes.Remove(tNotes.SelectedNode);

			if (tNotes.SelectedNode == null)
			{
				SelectedNote = null;
			}
		}

		/// <summary>
		///     Changed sorting type
		/// </summary>
		private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Running)
			{
				Pandora.Profile.Notes.NoteSorting = (NoteSorting)cmbType.SelectedIndex;

				RefreshNotes(SelectedNote);
			}
		}

		/// <summary>
		///     Changed sorting order
		/// </summary>
		private void cmbAscending_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Running)
			{
				Pandora.Profile.Notes.AscendingSorting = cmbAscending.SelectedIndex == 0;

				RefreshNotes(SelectedNote);
			}
		}

		private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			Pandora.Profile.General.NotesSplitter = splitter1.SplitPosition;
		}

		private void lnkLocations_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_Note != null)
			{
				m_Note.LocationsMenu.Show(lnkLocations, new Point(e.X, e.Y));
			}
		}
	}
}