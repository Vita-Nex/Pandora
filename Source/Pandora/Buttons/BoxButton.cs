#region Header
// /*
//  *    2018 - Pandora - BoxButton.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Summary description for BoxButton.
	/// </summary>
	public class BoxButton : Button
	{
		#region Configuration Menu
		private ContextMenu m_Menu;
		private MenuItem mEdit;
		private MenuItem mClear;
		private MenuItem mImport;
		private MenuItem mExport;
		private OpenFileDialog OpenFile;
		private SaveFileDialog SaveFile;
		private MenuItem mRestore;

		private void BuildMenu()
		{
			if (Pandora.Localization.TextProvider != null)
			{
				mEdit = new MenuItem(Pandora.Localization.TextProvider["Common.Edit"], EditButton);
				mEdit = new MenuItem(Pandora.Localization.TextProvider["Common.Edit"], EditButton);
				mClear = new MenuItem(Pandora.Localization.TextProvider["Common.Clear"], ClearButton);
				mImport = new MenuItem(Pandora.Localization.TextProvider["Common.Import"], ImportButton);
				mExport = new MenuItem(Pandora.Localization.TextProvider["Common.Export"], ExportButton);
				mRestore = new MenuItem(Pandora.Localization.TextProvider["Common.RestoreDefault"], RestoreDefault);

				m_Menu = new ContextMenu(new[] { mEdit, mClear, new MenuItem("-"), mImport, mExport, new MenuItem("-"), mRestore });

				m_Menu.Popup += MenuPopup;
			}
		}

		private void MenuPopup(object sender, EventArgs e)
		{
			mClear.Enabled = m_Def != null;
		}

		/// <summary>
		///     Bring up the customization form
		/// </summary>
		private void EditButton(object sender, EventArgs e)
		{
			var editor = new ButtonEditor();

			if (m_Def != null)
			{
				editor.Def = m_Def;
			}

			if (editor.ShowDialog() == DialogResult.OK)
			{
				Pandora.Buttons[this] = editor.Def;
				Text = m_Def.Caption;

				if (HasToolTip)
				{
					Pandora.ToolTip.SetToolTip(this, ToolTipText);
				}
			}

			editor.Dispose();
		}

		/// <summary>
		///     Clear up the button
		/// </summary>
		private void ClearButton(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, Pandora.Localization.TextProvider["Buttons.ConfirmClear"], "", MessageBoxButtons.YesNo) ==
				DialogResult.Yes)
			{
				Pandora.Buttons.ClearButton(this);
				Pandora.ToolTip.SetToolTip(this, null);
			}
		}

		/// <summary>
		///     Import the button from an Xml file
		/// </summary>
		private void ImportButton(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, Pandora.Localization.TextProvider["Buttons.ImportConfirm"], "", MessageBoxButtons.YesNo) ==
				DialogResult.Yes)
			{
				if (OpenFile.ShowDialog() == DialogResult.OK)
				{
					var def = ButtonDef.Load(OpenFile.FileName);

					if (def != null)
					{
						Pandora.Buttons[this] = def;
					}
					else
					{
						_ = MessageBox.Show(Pandora.Localization.TextProvider["Buttons.LoadFail"]);
					}
				}
			}
		}

		/// <summary>
		///     Export the button to an Xml file
		/// </summary>
		private void ExportButton(object sender, EventArgs e)
		{
			if (SaveFile.ShowDialog() == DialogResult.OK)
			{
				if (!m_Def.Save(SaveFile.FileName))
				{
					_ = MessageBox.Show(Pandora.Localization.TextProvider["Buttons.SaveFail"]);
				}
			}
		}

		/// <summary>
		///     Restores the default values
		/// </summary>
		private void RestoreDefault(object sender, EventArgs e)
		{
			Pandora.Buttons.ResetDefault(this);
		}
		#endregion

		private void InitializeComponent()
		{
			OpenFile = new OpenFileDialog();
			SaveFile = new SaveFileDialog();
			// 
			// OpenFile
			// 
			OpenFile.Filter = "Xml files (*.xml)|*.xml";
			// 
			// SaveFile
			// 
			SaveFile.Filter = "Xml files (*.xml)|*.xml";
		}

		private int m_ButtonID = -1;
		private bool m_IDSet;

		/// <summary>
		///     Gets or sets a value stating whether the button can be edited
		/// </summary>
		public bool AllowEdit { get; set; } = true;

		/// <summary>
		///     Gets or sets a value stating whether the button will actually send commands
		/// </summary>
		public bool IsActive { get; set; } = true;

		/// <summary>
		///     Gets the unique ID for this customizable button
		/// </summary>
		public int ButtonID
		{
			get
			{
				if (!Created && !m_IDSet)
				{
					return -1;
				}

				if (!m_IDSet && m_ButtonID == -1)
				{
					m_ButtonID = ButtonIDs.NextID;
				}

				return m_ButtonID;
			}
			set
			{
				m_ButtonID = value;
				m_IDSet = true;
			}
		}

		private ButtonDef m_Def;

		/// <summary>
		///     Gets or sets the definition object for this button
		/// </summary>
		public ButtonDef Def
		{
			get => m_Def;
			set
			{
				m_Def = value;
				if (m_Def != null)
				{
					m_Def.CaptionChanged += m_Def_CaptionChanged;
					m_Def.SendCommand += m_Def_SendCommand;
					m_Def.ToolTipChanged += m_Def_ToolTipChanged;
					Text = m_Def.Caption;

					Pandora.ToolTip.SetToolTip(this, m_Def.ToolTipText);

					Tag = m_Def.CommandCallback;
				}
				else
				{
					Text = "";
					Pandora.ToolTip.SetToolTip(this, null);
				}
			}
		}

		/// <summary>
		///     Creates a new BoxButton
		/// </summary>
		public BoxButton()
		{
			InitializeComponent();

			FlatStyle = FlatStyle.System;

			try
			{
				BuildMenu();
			}
			catch (Exception ex)
			{
				// Issue 6:  	 Improve error management - Tarion
				//Pandora.Log.WriteError(ex, "BuildMenu() failed");
				throw new Exception("BuildMenu() failed", ex);
				// End Issue 6
			}
		}

		#region Control key managment
		[DllImport("User32")]
		private static extern short GetKeyState(int nVirtKey);

		private static readonly int VK_CONTROL = 0x11;

		/// <summary>
		///     Gets a value stating whether the Control key is pressed or not
		/// </summary>
		private bool CtrlPressed
		{
			get
			{
				var control = GetKeyState(VK_CONTROL);

				if (control < -100)
				{
					return true;
				}

				return false;
			}
		}
		#endregion

		/// <summary>
		///     Caption changed
		/// </summary>
		private void m_Def_CaptionChanged(object sender, EventArgs e)
		{
			Text = m_Def.Caption;

			if (m_Def.MultiDef != null)
			{
				Pandora.Profile.ButtonIndex[m_ButtonID] = m_Def.MultiDef.DefaultIndex;
			}
		}

		/// <summary>
		///     Send command
		/// </summary>
		private void m_Def_SendCommand(object sender, SendCommandEventArgs e)
		{
			OnSendCommand(e);

			if (IsActive && !e.Sent)
			{
				Pandora.SendToUO(e.Command, e.UsePrefix);
			}
		}

		/// <summary>
		///     Occurs when the button is sending a command to UO
		/// </summary>
		public event SendCommandEventHandler SendCommand;

		protected virtual void OnSendCommand(SendCommandEventArgs e)
		{
			SendCommand?.Invoke(this, e);
		}

		/// <summary>
		///     Mouse Down
		/// </summary>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (AllowEdit && (m_Def == null || (m_Def.Left == null && m_Def.Right == null)))
			{
				EditButton(this, new EventArgs());
				return;
			}

			if (CtrlPressed && AllowEdit)
			{
				// Configure: show context menu
				m_Menu.Show(this, new Point(e.X, e.Y));
			}
			else
			{
				// Not pressed, do normal button
				if (m_Def != null)
				{
					m_Def.DoAction(this, new Point(e.X, e.Y), e.Button);
				}
			}
		}

		/// <summary>
		///     Gets the tool tip text for this button
		/// </summary>
		public string ToolTipText
		{
			get
			{
				if (m_Def != null)
				{
					return m_Def.ToolTipText;
				}

				return null;
			}
		}

		/// <summary>
		///     Gets a value stating whether this button has a tool tip
		/// </summary>
		public bool HasToolTip => m_Def != null && (m_Def.Left != null || m_Def.Right != null);

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				if (m_Def != null)
				{
					m_Def.Dispose();
				}
			}
		}

		private void m_Def_ToolTipChanged(object sender, ToolTipEventArgs e)
		{
			Pandora.ToolTip.SetToolTip(this, e.Text);
		}
	}
}