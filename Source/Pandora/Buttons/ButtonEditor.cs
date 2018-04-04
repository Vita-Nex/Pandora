#region Header
// /*
//  *    2018 - Pandora - ButtonEditor.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Summary description for ButtonEditor.
	/// </summary>
	public class ButtonEditor : Form
	{
		private BoxButton bPreview;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private LinkLabel linkLeft;
		private LinkLabel linkRight;
		private TextBox textBox1;
		private Button bCancel;
		private Button bOk;
		private Label label1;
		private TextBox txCaption;
		private MenuItem mNone;
		private MenuItem mSingleCommand;
		private MenuItem mMenu;
		private MenuItem mLastCommand;
		private MenuItem mMultiCommand;
		private ContextMenu cMenu;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private ButtonDef m_Def;
		private ButtonDef m_Backup;
		private bool m_EditLeft;
		private MenuItem mModifiersCommand;
		private readonly SendCommandEventHandler m_SendHandler;

		public ButtonEditor()
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);
			Pandora.Localization.LocalizeMenu(cMenu);

			m_Def = new ButtonDef();
			bPreview.Def = m_Def;

			m_SendHandler = bPreview_SendCommand;
			bPreview.SendCommand += m_SendHandler;
		}

		/// <summary>
		///     Gets or sets the def object governing this button
		/// </summary>
		public ButtonDef Def
		{
			get { return m_Def; }
			set
			{
				if (m_Def != null)
				{
					m_Def.Dispose();
				}

				m_Backup = value;
				m_Def = value.Clone() as ButtonDef;

				bPreview.Def = m_Def;

				FixText();
			}
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
			var resources = new System.Resources.ResourceManager(typeof(ButtonEditor));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkLeft = new System.Windows.Forms.LinkLabel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.linkRight = new System.Windows.Forms.LinkLabel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.bPreview = new TheBox.Buttons.BoxButton();
			this.bCancel = new System.Windows.Forms.Button();
			this.bOk = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txCaption = new System.Windows.Forms.TextBox();
			this.cMenu = new System.Windows.Forms.ContextMenu();
			this.mNone = new System.Windows.Forms.MenuItem();
			this.mSingleCommand = new System.Windows.Forms.MenuItem();
			this.mMenu = new System.Windows.Forms.MenuItem();
			this.mLastCommand = new System.Windows.Forms.MenuItem();
			this.mMultiCommand = new System.Windows.Forms.MenuItem();
			this.mModifiersCommand = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.linkLeft);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Buttons.LeftMouse";
			// 
			// linkLeft
			// 
			this.linkLeft.Location = new System.Drawing.Point(16, 32);
			this.linkLeft.Name = "linkLeft";
			this.linkLeft.Size = new System.Drawing.Size(176, 23);
			this.linkLeft.TabIndex = 0;
			this.linkLeft.TabStop = true;
			this.linkLeft.Text = "Common.None";
			this.linkLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.linkLeft_MouseDown);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.linkRight);
			this.groupBox2.Location = new System.Drawing.Point(240, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 80);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Buttons.RightMouse";
			// 
			// linkRight
			// 
			this.linkRight.Location = new System.Drawing.Point(16, 32);
			this.linkRight.Name = "linkRight";
			this.linkRight.Size = new System.Drawing.Size(176, 23);
			this.linkRight.TabIndex = 0;
			this.linkRight.TabStop = true;
			this.linkRight.Text = "Common.None";
			this.linkRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.linkRight_MouseDown);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.bPreview);
			this.groupBox3.Location = new System.Drawing.Point(16, 96);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Common.Preview";
			// 
			// bPreview
			// 
			this.bPreview.AllowEdit = false;
			this.bPreview.ButtonID = -1;
			this.bPreview.Def = null;
			this.bPreview.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bPreview.IsActive = false;
			this.bPreview.Location = new System.Drawing.Point(64, 40);
			this.bPreview.Name = "bPreview";
			this.bPreview.Size = new System.Drawing.Size(80, 23);
			this.bPreview.TabIndex = 0;
			this.bPreview.Text = "Common.Preview";
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(288, 384);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 2;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(376, 384);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 1;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 208);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(432, 168);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "Buttons.Intstructions";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(240, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "ButtonMenuEditor.Caption";
			// 
			// txCaption
			// 
			this.txCaption.Location = new System.Drawing.Point(240, 128);
			this.txCaption.Name = "txCaption";
			this.txCaption.Size = new System.Drawing.Size(200, 20);
			this.txCaption.TabIndex = 5;
			this.txCaption.Text = "";
			this.txCaption.TextChanged += new System.EventHandler(this.txCaption_TextChanged);
			// 
			// cMenu
			// 
			this.cMenu.MenuItems.AddRange(
				new System.Windows.Forms.MenuItem[]
					{this.mNone, this.mSingleCommand, this.mMenu, this.mLastCommand, this.mMultiCommand, this.mModifiersCommand});
			this.cMenu.Popup += new System.EventHandler(this.cMenu_Popup);
			// 
			// mNone
			// 
			this.mNone.Index = 0;
			this.mNone.Text = "Common.None";
			this.mNone.Click += new System.EventHandler(this.mNone_Click);
			// 
			// mSingleCommand
			// 
			this.mSingleCommand.Index = 1;
			this.mSingleCommand.Text = "Buttons.Single";
			this.mSingleCommand.Click += new System.EventHandler(this.mSingleCommand_Click);
			// 
			// mMenu
			// 
			this.mMenu.Index = 2;
			this.mMenu.Text = "Common.Menu";
			this.mMenu.Click += new System.EventHandler(this.mMenu_Click);
			// 
			// mLastCommand
			// 
			this.mLastCommand.Index = 3;
			this.mLastCommand.Text = "Buttons.LastCommand";
			this.mLastCommand.Click += new System.EventHandler(this.mLastCommand_Click);
			// 
			// mMultiCommand
			// 
			this.mMultiCommand.Index = 4;
			this.mMultiCommand.Text = "Buttons.Multi";
			this.mMultiCommand.Click += new System.EventHandler(this.mMultiCommand_Click);
			// 
			// mModifiersCommand
			// 
			this.mModifiersCommand.Index = 5;
			this.mModifiersCommand.Text = "Buttons.Modifiers";
			this.mModifiersCommand.Click += new System.EventHandler(this.mModifiersCommand_Click);
			// 
			// ButtonEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 416);
			this.Controls.Add(this.txCaption);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ButtonEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buttons.Title";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ButtonEditor_Closing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Button send preview
		/// </summary>
		private void bPreview_SendCommand(object sender, SendCommandEventArgs e)
		{
			var cmd = "";
			if (e.UsePrefix)
				cmd += Pandora.Profile.General.CommandPrefix;
			cmd += e.Command;

			MessageBox.Show(string.Format(Pandora.Localization.TextProvider["ButtonMenuEditor.PreviewMsg"], cmd));
		}

		/// <summary>
		///     Caption change
		/// </summary>
		private void txCaption_TextChanged(object sender, EventArgs e)
		{
			m_Def.Caption = txCaption.Text;
		}

		/// <summary>
		///     Asks the user if they want to go on and erase the previous item
		/// </summary>
		/// <returns>True if the user wants to preceed</returns>
		private bool ConfirmErase()
		{
			if (m_EditLeft)
			{
				if (m_Def.Left == null)
					return true;
			}
			else
			{
				if (m_Def.Right == null)
					return true;
			}

			if (MessageBox.Show(this, Pandora.Localization.TextProvider["Buttons.ErasePrevious"], "", MessageBoxButtons.YesNo) ==
				DialogResult.Yes)
				return true;
			return false;
		}

		/// <summary>
		///     Show menu for left button
		/// </summary>
		private void linkLeft_MouseDown(object sender, MouseEventArgs e)
		{
			m_EditLeft = true;

			if (e.Button == MouseButtons.Right && m_Def.Left != null)
				EditDef();
			else
				cMenu.Show(linkLeft, new Point(e.X, e.Y));
		}

		/// <summary>
		///     Show menu for right button
		/// </summary>
		private void linkRight_MouseDown(object sender, MouseEventArgs e)
		{
			m_EditLeft = false;

			if (e.Button == MouseButtons.Right && m_Def.Right != null)
				EditDef();
			else
				cMenu.Show(linkRight, new Point(e.X, e.Y));
		}

		/// <summary>
		///     Popup menu, verify available options
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cMenu_Popup(object sender, EventArgs e)
		{
			if (m_EditLeft)
			{
				// Left button
				mNone.Enabled = (m_Def.Left != null);

				mSingleCommand.Enabled = m_Def.TryLeft(new MenuCommand());
				mMenu.Enabled = m_Def.TryLeft(new MenuDef());
				mLastCommand.Enabled = m_Def.TryLeft(new LastCommand());
				mMultiCommand.Enabled = m_Def.TryLeft(new MultiCommandDef());
				mModifiersCommand.Enabled = m_Def.TryLeft(new ModifierCommand());
			}
			else
			{
				// Right button
				mNone.Enabled = (m_Def.Right != null);

				mSingleCommand.Enabled = m_Def.TryRight(new MenuCommand());
				mMenu.Enabled = m_Def.TryRight(new MenuDef());
				mLastCommand.Enabled = m_Def.TryRight(new LastCommand());
				mMultiCommand.Enabled = m_Def.TryRight(new MultiCommandDef());
				mModifiersCommand.Enabled = m_Def.TryRight(new ModifierCommand());
			}
		}

		/// <summary>
		///     Set a mouse button to NONE
		/// </summary>
		private void mNone_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				if (m_EditLeft)
				{
					m_Def.Left = null;
					linkLeft.Text = Pandora.Localization.TextProvider["Common.None"];
				}
				else
				{
					m_Def.Right = null;
					linkRight.Text = Pandora.Localization.TextProvider["Common.None"];
				}
			}
		}

		/// <summary>
		///     Edits the existing item on a button slot
		/// </summary>
		private void EditDef()
		{
			IButtonFunction function = null;

			if (m_EditLeft)
				function = m_Def.Left;
			else
				function = m_Def.Right;

			if (function is MenuCommand)
			{
				var mc = function as MenuCommand;

				// Single command
				var sc = new SimpleCommand();

				sc.Command = mc.Command;
				sc.UsePrefix = mc.UsePrefix;

				if (sc.ShowDialog() == DialogResult.OK)
				{
					mc.Command = sc.Command;
					mc.UsePrefix = sc.UsePrefix;
				}
			}
			else if (function is ModifierCommand)
			{
				var mc = function as ModifierCommand;

				var sc = new SimpleCommand(true);

				sc.Command = mc.Command;

				if (sc.ShowDialog() == DialogResult.OK)
				{
					mc.Command = sc.Command;
				}
			}
			else if (function is MenuDef)
			{
				var md = function as MenuDef;

				// Menu
				var me = new BoxMenuEditor();
				me.MenuDefinition = md;

				if (me.ShowDialog() == DialogResult.OK)
				{
					if (m_EditLeft)
						m_Def.Left = me.MenuDefinition;
					else
						m_Def.Right = me.MenuDefinition;
				}
			}
			else if (function is MultiCommandDef)
			{
				var mcd = function as MultiCommandDef;

				// Multi Command
				var mce = new MultiCommandEditor();
				mce.MultiDef = mcd;

				if (mce.ShowDialog() == DialogResult.OK)
				{
					if (m_EditLeft)
						m_Def.Left = mce.MultiDef;
					else
						m_Def.Right = mce.MultiDef;
				}
			}
		}

		/// <summary>
		///     Single command
		/// </summary>
		private void mSingleCommand_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				var sc = new SimpleCommand();

				if (sc.ShowDialog() == DialogResult.OK)
				{
					var mc = new MenuCommand();
					mc.Command = sc.Command;
					mc.UsePrefix = sc.UsePrefix;

					if (m_EditLeft)
					{
						m_Def.Left = mc;
						linkLeft.Text = Pandora.Localization.TextProvider["Buttons.Single"];
					}
					else
					{
						m_Def.Right = mc;
						linkRight.Text = Pandora.Localization.TextProvider["Buttons.Single"];
					}
				}
			}
		}

		/// <summary>
		///     New modifiers command
		/// </summary>
		private void mModifiersCommand_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				var sc = new SimpleCommand(true);

				if (sc.ShowDialog() == DialogResult.OK)
				{
					var mc = new ModifierCommand();
					mc.Command = sc.Command;

					if (m_EditLeft)
					{
						m_Def.Left = mc;
						linkLeft.Text = Pandora.Localization.TextProvider["Buttons.Modifiers"];
					}
					else
					{
						m_Def.Right = mc;
						linkRight.Text = Pandora.Localization.TextProvider["Buttons.Modifiers"];
					}
				}
			}
		}

		/// <summary>
		///     MENU
		/// </summary>
		private void mMenu_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				var bme = new BoxMenuEditor();

				if (bme.ShowDialog() == DialogResult.OK)
				{
					if (m_EditLeft)
					{
						m_Def.Left = bme.MenuDefinition;
						linkLeft.Text = Pandora.Localization.TextProvider["ButtonMenuEditor.Menu"];
					}
					else
					{
						m_Def.Right = bme.MenuDefinition;
						linkRight.Text = Pandora.Localization.TextProvider["ButtonMenuEditor.Menu"];
					}
				}
			}
		}

		/// <summary>
		///     LAST COMMAND
		/// </summary>
		private void mLastCommand_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				if (m_EditLeft)
				{
					m_Def.Left = new LastCommand();
					linkLeft.Text = Pandora.Localization.TextProvider["Buttons.LastCommand"];
				}
				else
				{
					m_Def.Right = new LastCommand();
					linkRight.Text = Pandora.Localization.TextProvider["Buttons.LastCommand"];
				}
			}
		}

		/// <summary>
		///     MULTI DEF COMMAND
		/// </summary>
		private void mMultiCommand_Click(object sender, EventArgs e)
		{
			if (ConfirmErase())
			{
				var mce = new MultiCommandEditor();

				if (mce.ShowDialog() == DialogResult.OK)
				{
					if (m_EditLeft)
					{
						m_Def.Left = mce.MultiDef;
						linkLeft.Text = Pandora.Localization.TextProvider["Buttons.Multi"];
						bPreview.Text = m_Def.Caption;
					}
					else
					{
						m_Def.Right = mce.MultiDef;
						linkRight.Text = Pandora.Localization.TextProvider["Buttons.Multi"];
					}

					bPreview.Text = m_Def.Caption;
				}
			}
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			m_Def.Dispose();
			m_Def = m_Backup;
			Close();
		}

		private void ButtonEditor_Closing(object sender, CancelEventArgs e)
		{
			bPreview.SendCommand -= m_SendHandler;
		}

		private void FixText()
		{
			if (m_Def != null)
			{
				if (m_Def.Left != null)
				{
					linkLeft.Text = Pandora.Localization.TextProvider[m_Def.Left.Name];
				}
				if (m_Def.Right != null)
				{
					linkRight.Text = Pandora.Localization.TextProvider[m_Def.Right.Name];
				}
			}
		}
	}
}