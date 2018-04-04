#region Header
// /*
//  *    2018 - Pandora - QuickMobile.cs
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
	///     Summary description for QuickMobile.
	/// </summary>
	public class QuickMobile : Form
	{
		private PropertyGrid pGrid;
		private ArtViewer.ArtViewer m_Preview;
		private Button bOk;
		private Button bCancel;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public QuickMobile()
		{
			//
			// Required for Windows Form Designer support
			//
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
			var resources = new System.Resources.ResourceManager(typeof(QuickMobile));
			this.pGrid = new System.Windows.Forms.PropertyGrid();
			this.m_Preview = new TheBox.ArtViewer.ArtViewer();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pGrid
			// 
			this.pGrid.CommandsVisibleIfAvailable = true;
			this.pGrid.LargeButtons = false;
			this.pGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pGrid.Location = new System.Drawing.Point(8, 8);
			this.pGrid.Name = "pGrid";
			this.pGrid.Size = new System.Drawing.Size(208, 248);
			this.pGrid.TabIndex = 0;
			this.pGrid.Text = "propertyGrid1";
			this.pGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.pGrid.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(this.pGrid_PropertyValueChanged);
			// 
			// m_Preview
			// 
			this.m_Preview.Animate = true;
			this.m_Preview.Art = TheBox.ArtViewer.Art.NPCs;
			this.m_Preview.ArtIndex = 0;
			this.m_Preview.Hue = 0;
			this.m_Preview.Location = new System.Drawing.Point(224, 8);
			this.m_Preview.Name = "m_Preview";
			this.m_Preview.ResizeTallItems = false;
			this.m_Preview.RoomView = true;
			this.m_Preview.ShowID = false;
			this.m_Preview.Size = new System.Drawing.Size(216, 216);
			this.m_Preview.TabIndex = 1;
			this.m_Preview.Text = "artViewer1";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(360, 232);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 2;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(224, 232);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 3;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// QuickMobile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 261);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.m_Preview);
			this.Controls.Add(this.pGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "QuickMobile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "QuickMobile";
			this.Load += new System.EventHandler(this.QuickMobile_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private BoxMobile m_Mobile;
		private BoxMobile m_Backup;

		/// <summary>
		///     Gets or set the BoxMobile edited
		/// </summary>
		public BoxMobile Mobile
		{
			get
			{
				if (m_Mobile == null)
				{
					m_Mobile = new BoxMobile();
				}

				return m_Mobile;
			}
			set
			{
				m_Backup = new BoxMobile();
				m_Backup.Art = value.Art;
				m_Backup.CanBeNamed = value.CanBeNamed;
				m_Backup.Hue = value.Hue;
				m_Backup.Name = value.Name;

				m_Mobile = value;
				pGrid.SelectedObject = m_Mobile;

				UpdatePreview();
			}
		}

		private void QuickMobile_Load(object sender, EventArgs e)
		{
			m_Preview.BackColor = Pandora.Profile.General.ArtBackground.Color;
			pGrid.SelectedObject = Mobile;
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			if (m_Mobile.Name.Length == 0)
			{
				MessageBox.Show(Pandora.Localization.TextProvider["NPCs.NameError"]);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

			if (m_Backup != null)
			{
				m_Mobile.Art = m_Backup.Art;
				m_Mobile.CanBeNamed = m_Backup.CanBeNamed;
				m_Mobile.Hue = m_Backup.Hue;
				m_Mobile.Name = m_Backup.Name;
			}

			Close();
		}

		private void UpdatePreview()
		{
			m_Preview.ArtIndex = m_Mobile.Art;
			m_Preview.Hue = m_Mobile.Hue;
		}

		private void pGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			UpdatePreview();
		}
	}
}