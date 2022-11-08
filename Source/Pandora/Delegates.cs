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

		/// <summary>
		///     Gets or sets a value stating whether this command has been sent or not
		/// </summary>
		public bool Sent { get; set; }

		/// <summary>
		///     Gets the full command, including the command prefix
		/// </summary>
		public string FullCommand => String.Format("{0}{1}", UsePrefix ? Pandora.Profile.General.CommandPrefix : String.Empty, Command);

		/// <summary>
		///     Gets the command that is being sent to UO
		/// </summary>
		public string Command { get; }

		/// <summary>
		///     States whether the command prefix should be used
		/// </summary>
		public bool UsePrefix { get; }

		/// <summary>
		///     Creates a new SendCommandEventArgs object
		/// </summary>
		/// <param name="command">The command being sent to UO</param>
		/// <param name="useprefix">States whether the command prefix should be used</param>
		public SendCommandEventArgs(string command, bool useprefix)
		{
			Sent = false;
			Command = command;
			UsePrefix = useprefix;
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
		/// <summary>
		///     Gets the new command for the button
		/// </summary>
		public MenuCommand Command { get; }

		/// <summary>
		///     Creates a new CommandChangedEventArgs object
		/// </summary>
		/// <param name="command">The command that should be applied to the button</param>
		public CommandChangedEventArgs(MenuCommand command)
		{
			Command = command;
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
		/// <summary>
		///     Gets the new text for the tool tip
		/// </summary>
		public string Text { get; }

		/// <summary>
		///     Gets a value stating whether the control has a tool tip or not
		/// </summary>
		public bool HasToolTip => Text != null;

		/// <summary>
		///     Creates a new ToolTipEventArgs object
		/// </summary>
		/// <param name="tooltip">The new tool tip text. Use null for no tool tip.</param>
		public ToolTipEventArgs(string tooltip)
		{
			Text = tooltip;
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