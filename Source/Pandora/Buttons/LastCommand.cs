#region Header
// /*
//  *    2018 - Pandora - LastCommand.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Summary description for LastCommand.
	/// </summary>
	public class LastCommand : IButtonFunction, ICloneable
	{
		#region IButtonFunction Members
		public string Name { get { return "Buttons.LastCommand"; } }

		public bool AllowsSecondButton { get { return true; } }

		public bool RequiresSecondButton { get { return true; } }

		public void DoAction(BoxButton button, Point clickPoint, MouseButtons mouseButton)
		{
			OnSendLastCommand(new EventArgs());
		}

		/// <summary>
		///     Not used in this class
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
		///     Occurs when the button should send the last command
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
		///     Not used in this class
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

		#region ICloneable Members
		public object Clone()
		{
			return new LastCommand();
		}
		#endregion
	}
}