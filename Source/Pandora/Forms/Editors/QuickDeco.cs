#region Header
// /*
//  *    2018 - Pandora - QuickDeco.cs
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
	///     Summary description for QuickDeco.
	/// </summary>
	public class QuickDeco : Form
	{
		private PropertyGrid pGrid;
		private ArtViewer.ArtViewer art;
		private Button bOk;
		private Button bCancel;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public QuickDeco()
		{
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
			var resources = new System.Resources.ResourceManager(typeof(QuickDeco));
			this.pGrid = new System.Windows.Forms.PropertyGrid();
			this.art = new TheBox.ArtViewer.ArtViewer();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pGrid
			// 
			this.pGrid.CommandsVisibleIfAvailable = true;
			this.pGrid.HelpVisible = false;
			this.pGrid.LargeButtons = false;
			this.pGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pGrid.Location = new System.Drawing.Point(8, 8);
			this.pGrid.Name = "pGrid";
			this.pGrid.Size = new System.Drawing.Size(208, 40);
			this.pGrid.TabIndex = 0;
			this.pGrid.Text = "propertyGrid1";
			this.pGrid.ToolbarVisible = false;
			this.pGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.pGrid.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(this.pGrid_PropertyValueChanged);
			// 
			// art
			// 
			this.art.Animate = false;
			this.art.Art = TheBox.ArtViewer.Art.Items;
			this.art.ArtIndex = 0;
			this.art.BackColor = System.Drawing.Color.White;
			this.art.Hue = 0;
			this.art.Location = new System.Drawing.Point(8, 56);
			this.art.Name = "art";
			this.art.ResizeTallItems = true;
			this.art.RoomView = true;
			this.art.ShowID = false;
			this.art.Size = new System.Drawing.Size(208, 152);
			this.art.TabIndex = 1;
			this.art.Text = "artViewer1";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(160, 216);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(56, 23);
			this.bOk.TabIndex = 2;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(96, 216);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(56, 23);
			this.bCancel.TabIndex = 3;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// QuickDeco
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 250);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.art);
			this.Controls.Add(this.pGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "QuickDeco";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Deco.Title";
			this.Load += new System.EventHandler(this.QuickDeco_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private BoxDeco m_Deco;
		private BoxDeco m_Backup;

		private void QuickDeco_Load(object sender, EventArgs e)
		{
			pGrid.SelectedObject = Deco;
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			if (Deco.Name == null || Deco.Name.Length == 0)
			{
				_ = MessageBox.Show(Pandora.Localization.TextProvider["Deco.NoName"]);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			if (m_Backup != null)
			{
				m_Deco.Name = m_Backup.Name;
				m_Deco.ID = m_Backup.ID;
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void pGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			art.ArtIndex = m_Deco.ID;
		}

		/// <summary>
		///     Gets or sets the BoxDeco item edited by this form
		/// </summary>
		public BoxDeco Deco
		{
			get
			{
				if (m_Deco == null)
				{
					m_Deco = new BoxDeco();
				}

				return m_Deco;
			}
			set
			{
				m_Backup = new BoxDeco
				{
					ID = value.ID,
					Name = value.Name
				};

				m_Deco = value;
			}
		}
	}
}
