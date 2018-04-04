#region Header
// /*
//  *    2018 - Pandora - Delegates.cs
//  */
#endregion

#region References
using System;

using TheBox.Buttons;
#endregion

namespace TheBox
{
	#region SendCommand
	/// <summary>
	///     The delegate used when sending commands to UO
	/// </summary>
	public delegate void SendCommandEventHandler(object sender, SendCommandEventArgs e);

	/// <summary>
	///     The event args used when sending commands to UO
	/// </summary>
	public class SendCommandEventArgs : EventArgs
	{
		private readonly string m_Command;
		private readonly bool m_UsePrefix;

		/// <summary>
		///     Gets or sets a value stating whether this command has been sent or not
		/// </summary>
		public bool Sent { get; set; }

		/// <summary>
		///     Gets the full command, including the command prefix
		/// </summary>
		public string FullCommand
		{
			get
			{
				return string.Format("{0}{1}", m_UsePrefix ? Pandora.Profile.General.CommandPrefix : string.Empty, m_Command);
			}
		}

		/// <summary>
		///     Gets the command that is being sent to UO
		/// </summary>
		public string Command { get { return m_Command; } }

		/// <summary>
		///     States whether the command prefix should be used
		/// </summary>
		public bool UsePrefix { get { return m_UsePrefix; } }

		/// <summary>
		///     Creates a new SendCommandEventArgs object
		/// </summary>
		/// <param name="command">The command being sent to UO</param>
		/// <param name="useprefix">States whether the command prefix should be used</param>
		public SendCommandEventArgs(string command, bool useprefix)
		{
			Sent = false;
			m_Command = command;
			m_UsePrefix = useprefix;
		}
	}
	#endregion

	#region CommandChanged
	/// <summary>
	///     The delegate for the CommandChanged event
	/// </summary>
	public delegate void CommandChangedEventHandler(object sender, CommandChangedEventArgs e);

	public class CommandChangedEventArgs : EventArgs
	{
		private readonly MenuCommand m_Command;

		/// <summary>
		///     Gets the new command for the button
		/// </summary>
		public MenuCommand Command { get { return m_Command; } }

		/// <summary>
		///     Creates a new CommandChangedEventArgs object
		/// </summary>
		/// <param name="command">The command that should be applied to the button</param>
		public CommandChangedEventArgs(MenuCommand command)
		{
			m_Command = command;
		}
	}
	#endregion

	#region ToolTipChanged
	/// <summary>
	///     Occurs when the tool tip on a control must be changed
	/// </summary>
	public delegate void ToolTipChangedEventHandler(object sender, ToolTipEventArgs e);

	public class ToolTipEventArgs : EventArgs
	{
		private readonly string m_Text;

		/// <summary>
		///     Gets the new text for the tool tip
		/// </summary>
		public string Text { get { return m_Text; } }

		/// <summary>
		///     Gets a value stating whether the control has a tool tip or not
		/// </summary>
		public bool HasToolTip { get { return m_Text != null; } }

		/// <summary>
		///     Creates a new ToolTipEventArgs object
		/// </summary>
		/// <param name="tooltip">The new tool tip text. Use null for no tool tip.</param>
		public ToolTipEventArgs(string tooltip)
		{
			m_Text = tooltip;
		}
	}
	#endregion

	#region Modifiers enabled commands
	public delegate void CommandCallback(string modifier);
	#endregion

	// Issue 1 - CrossThread operation exception - http://code.google.com/p/pandorasbox3/issues/detail?id=1 - Smjert
	public delegate void SetText(string text);

	// Issue 1 - End
}