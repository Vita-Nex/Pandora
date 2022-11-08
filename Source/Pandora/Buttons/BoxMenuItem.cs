#region Header
// /*
//  *    2018 - Pandora - BoxMenuItem.cs
//  */
#endregion

#region References
using System;
using System.Windows.Forms;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     A menu item used in Pandora's Box custom buttons
	/// </summary>
	public class BoxMenuItem : MenuItem, ICloneable
	{
		/// <summary>
		///     Gets the menu command associated with this menu item
		/// </summary>
		public MenuCommand Command { get; }

		/// <summary>
		///     Creates a new BoxMenuItem that can be used to send a command to UO
		/// </summary>
		/// <param name="command">The MenuCommand object that defines the command that should be sent to UO</param>
		public BoxMenuItem(MenuCommand command)
		{
			Command = command;
			Text = Command.Caption;
		}

		/// <summary>
		///     Occurs when a command is sent to UO
		/// </summary>
		public event SendCommandEventHandler SendCommand;

		protected virtual void OnSendCommand(SendCommandEventArgs e)
		{
			SendCommand?.Invoke(this, e);
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);

			OnSendCommand(new SendCommandEventArgs(Command.Command, Command.UsePrefix));
		}

		#region ICloneable Members
		public object Clone()
		{
			return new BoxMenuItem(Command.Clone() as MenuCommand);
		}
		#endregion
	}
}