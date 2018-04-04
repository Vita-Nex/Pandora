#region Header
// /*
//  *    2018 - Pandora - ModifierCommand.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
#endregion

namespace TheBox.Buttons
{
	/// <summary>
	///     Defines the function of a button that uses modifiers
	/// </summary>
	public class ModifierCommand : IButtonFunction, ICloneable
	{
		[XmlAttribute]
		/// <summary>
		/// Gets or sets the base command used by this button
		/// </summary>
		public string Command { get; set; }

		/// <summary>
		///     Performs the command
		/// </summary>
		/// <param name="modifier">Specifies the modifier</param>
		private void PerformCommand(string modifier)
		{
			var cmd = Command;

			if (modifier != null)
				cmd = string.Format("{0} {1}", modifier, cmd);

			if (SendCommand != null)
			{
				SendCommand(this, new SendCommandEventArgs(cmd, true));
			}
		}

		[XmlIgnore]
		/// <summary>
		/// Gets the command callback for this button
		/// </summary>
		public CommandCallback CommandCallback { get { return PerformCommand; } }

		#region IButtonFunction Members
		public string Name { get { return "Buttons.Modifiers"; } }

		public bool AllowsSecondButton { get { return false; } }

		public bool RequiresSecondButton { get { return false; } }

		public void DoAction(BoxButton button, Point clickPoint, MouseButtons mouseButton)
		{
			if (mouseButton == MouseButtons.Left)
			{
				if (SendCommand != null)
				{
					SendCommand(this, new SendCommandEventArgs(Command, true));
				}
			}
			else
			{
				Pandora.cmModifiers.Show(button, clickPoint);
			}
		}

		//  Issue 9:  	 Warnings - Interface - Tarion
		protected virtual void OnSendLastCommand(EventArgs e)
		{
			if (SendLastCommand != null)
			{
				SendLastCommand(this, e);
			}
		}

		//  Issue 9:  	 Warnings - Interface - Tarion
		protected virtual void OnCommandChanged(CommandChangedEventArgs e)
		{
			if (CommandChanged != null)
			{
				CommandChanged(this, e);
			}
		}

		public event SendCommandEventHandler SendCommand;

		public event EventHandler SendLastCommand;

		public event CommandChangedEventHandler CommandChanged;
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			var cmd = new ModifierCommand();
			cmd.Command = Command;

			return cmd;
		}
		#endregion
	}
}