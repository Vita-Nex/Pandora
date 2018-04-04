#region Header
// /*
//  *    2018 - Pandora - MultiCommandDef.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Buttons
{
	[Serializable]
	/// <summary>
	/// Defines a button that can configure its command from a number of menu entries
	/// </summary>
	public class MultiCommandDef : IButtonFunction, IDisposable, ICloneable
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<MenuCommand> m_Commands;

		// Issue 10 - End
		private int m_DefaultIndex = -1;

		private ContextMenu m_Menu;

		/// <summary>
		///     Gets or sets the available commands
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<MenuCommand> Commands
			// Issue 10 - End
		{
			get { return m_Commands; }
			set { m_Commands = value; }
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the default command index
		/// </summary>
		public int DefaultIndex
		{
			get { return m_DefaultIndex; }
			set
			{
				m_DefaultIndex = value;

				OnCommandChanged(new CommandChangedEventArgs(DefaultCommand));
			}
		}

		/// <summary>
		///     Gets the default menu command
		/// </summary>
		public MenuCommand DefaultCommand
		{
			get
			{
				if (m_DefaultIndex >= 0 && m_DefaultIndex < m_Commands.Count)
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					return m_Commands[m_DefaultIndex];
					// Issue 10 - End
				}
				return MenuCommand.Empty;
			}
		}

		/// <summary>
		///     Creates a new MultiCommandDef object defining a multi command button
		/// </summary>
		public MultiCommandDef()
		{
			m_Commands = new List<MenuCommand>();
		}

		/// <summary>
		///     Gets the menu associated with this buttons
		/// </summary>
		public ContextMenu Menu
		{
			get
			{
				if (m_Menu == null)
					DoMenu();

				return m_Menu;
			}
		}

		/// <summary>
		///     Computes the context menu
		/// </summary>
		private void DoMenu()
		{
			if (m_Menu != null)
			{
				m_Menu.Dispose();
			}

			m_Menu = new ContextMenu();

			for (var i = 0; i < m_Commands.Count; i++)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var bmi = (m_Commands[i]).MenuItem;
				// Issue 10 - End

				bmi.Checked = (m_DefaultIndex == i);
				bmi.Click += bmi_Click;

				m_Menu.MenuItems.Add(bmi);
			}

			m_Menu.Popup += m_Menu_Popup;
		}

		/// <summary>
		///     A menu item has been clicked and the default index should be changed
		/// </summary>
		private void bmi_Click(object sender, EventArgs e)
		{
			var bmi = sender as BoxMenuItem;

			if (bmi != null)
			{
				m_DefaultIndex = m_Commands.IndexOf(bmi.Command);

				OnCommandChanged(new CommandChangedEventArgs(DefaultCommand));
				OnSendCommand(new SendCommandEventArgs(DefaultCommand.Command, true));
			}
		}

		/// <summary>
		///     Set the correct default value
		/// </summary>
		private void m_Menu_Popup(object sender, EventArgs e)
		{
			for (var i = 0; i < m_Menu.MenuItems.Count; i++)
			{
				m_Menu.MenuItems[i].Checked = (i == m_DefaultIndex);
			}
		}

		#region IButtonFunction Members
		public string Name { get { return "Buttons.Multi"; } }

		/// <summary>
		///     States whether a second function is allowed on the button
		/// </summary>
		public bool AllowsSecondButton { get { return false; } }

		/// <summary>
		///     States whether a second function is required on the button
		/// </summary>
		public bool RequiresSecondButton { get { return false; } }

		/// <summary>
		///     Does the action specified by the function
		/// </summary>
		/// <param name="button">The button owner of the action</param>
		/// <param name="clickPoint">The location of the user click on the button</param>
		/// <param name="mouseButton">The mouse button clicked</param>
		public void DoAction(BoxButton button, Point clickPoint, MouseButtons mouseButton)
		{
			if (mouseButton == MouseButtons.Left)
			{
				OnSendCommand(new SendCommandEventArgs(DefaultCommand.Command, DefaultCommand.UsePrefix));
			}
			else if (mouseButton == MouseButtons.Right)
			{
				Menu.Show(button, clickPoint);
			}
		}

		/// <summary>
		///     Occurs when a command must be sent to UO
		/// </summary>
		public event SendCommandEventHandler SendCommand;

		protected virtual void OnSendCommand(SendCommandEventArgs e)
		{
			if (SendCommand != null)
			{
				SendCommand(this, e);
			}
		}

		/// <summary>
		///     Not used in this class
		/// </summary>
		public event EventHandler SendLastCommand;

		protected virtual void OnSendLastCommand(EventArgs e)
		{
			if (SendLastCommand != null)
			{
				SendLastCommand(this, e);
			}
		}

		/// <summary>
		///     Occurs when the default command for the button changes
		/// </summary>
		public event CommandChangedEventHandler CommandChanged;

		protected virtual void OnCommandChanged(CommandChangedEventArgs e)
		{
			if (CommandChanged != null)
			{
				CommandChanged(this, e);
			}
		}
		#endregion

		#region IDisposable Members
		public void Dispose()
		{
			if (m_Menu != null)
			{
				m_Menu.Dispose();
			}
		}
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			var mcd = new MultiCommandDef();

			mcd.m_DefaultIndex = m_DefaultIndex;

			foreach (var mc in m_Commands)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				mcd.m_Commands.Add(mc.Clone() as MenuCommand);
				// Issue 10 - End
			}

			return mcd;
		}
		#endregion
	}
}