#region Header
// /*
//  *    2018 - Pandora - QuickItem.cs
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
	///     Summary description for QuickItem.
	/// </summary>
	public class QuickItem : Form
	{
		private Button bCancel;
		private Button bOk;
		private ArtViewer.ArtViewer m_Preview;
		private PropertyGrid pGrid;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private BoxItem m_Item;
		private BoxItem m_Backup;

		/// <summary>
		///     Gets or sets the object being edited
		/// </summary>
		public BoxItem Item
		{
			get { return m_Item; }
			set
			{
				m_Backup = value.Clone() as BoxItem;
				m_Item = value;

				pGrid.SelectedObject = m_Item;
			}
		}

		public QuickItem()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			m_Preview.MulFileManager = Pandora.Profile.MulManager;
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
			var resources = new System.Resources.ResourceManager(typeof(QuickItem));
			this.bCancel = new System.Windows.Forms.Button();
			this.bOk = new System.Windows.Forms.Button();
			this.m_Preview = new TheBox.ArtViewer.ArtViewer();
			this.pGrid = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(224, 232);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 7;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(360, 232);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 6;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// m_Preview
			// 
			this.m_Preview.Animate = true;
			this.m_Preview.Art = TheBox.ArtViewer.Art.Items;
			this.m_Preview.ArtIndex = 0;
			this.m_Preview.Hue = 0;
			this.m_Preview.Location = new System.Drawing.Point(224, 8);
			this.m_Preview.Name = "m_Preview";
			this.m_Preview.ResizeTallItems = false;
			this.m_Preview.RoomView = true;
			this.m_Preview.ShowID = false;
			this.m_Preview.Size = new System.Drawing.Size(216, 216);
			this.m_Preview.TabIndex = 5;
			this.m_Preview.Text = "artViewer1";
			// 
			// pGrid
			// 
			this.pGrid.CommandsVisibleIfAvailable = true;
			this.pGrid.LargeButtons = false;
			this.pGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pGrid.Location = new System.Drawing.Point(8, 8);
			this.pGrid.Name = "pGrid";
			this.pGrid.Size = new System.Drawing.Size(208, 248);
			this.pGrid.TabIndex = 4;
			this.pGrid.Text = "propertyGrid1";
			this.pGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.pGrid.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(this.pGrid_PropertyValueChanged);
			// 
			// QuickItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 261);
			this.ControlBox = false;
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.m_Preview);
			this.Controls.Add(this.pGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "QuickItem";
			this.ShowInTaskbar = false;
			this.Text = "QuickItem";
			this.Load += new System.EventHandler(this.QuickItem_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void QuickItem_Load(object sender, EventArgs e)
		{
			m_Preview.BackColor = Pandora.Profile.General.ArtBackground.Color;

			if (m_Item == null)
			{
				m_Item = new BoxItem();
				m_Item.EmptyCtor = true;

				pGrid.SelectedObject = m_Item;

				m_Backup = new BoxItem();
			}
			else
			{
				m_Preview.ArtIndex = m_Item.Item.Art;
				m_Preview.Hue = m_Item.Item.Hue;
			}
		}

		private void pGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			m_Preview.ArtIndex = m_Item.Item.Art;
			m_Preview.Hue = m_Item.Item.Hue;
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			if (m_Item.Name != null && m_Item.Name.Length > 0)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show(Pandora.Localization.TextProvider["Items.NoName"]);
			}
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			m_Item.Name = m_Backup.Name;
			m_Item.Item.Art = m_Backup.Item.Art;
			m_Item.Item.Hue = m_Backup.Item.Hue;

			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}