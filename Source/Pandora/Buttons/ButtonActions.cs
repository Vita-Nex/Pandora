#region Header
// /*
//  *    2018 - Pandora - ButtonActions.cs
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
	///     Provides implementation details on functions supported by customizable buttons
	/// </summary>
	public interface IButtonFunction
	{
		/// <summary>
		///     Gets the localized name of this function
		/// </summary>
		string Name { get; }

		/// <summary>
		///     Verifies if this action allows a second button definition
		/// </summary>
		bool AllowsSecondButton { get; }

		/// <summary>
		///     Verifies if this action requires another button definition to function
		/// </summary>
		bool RequiresSecondButton { get; }

		/// <summary>
		///     Does the action specified by the button
		/// </summary>
		/// <param name="button">The button owner of the action</param>
		/// <param name="clickPoint">The location of the user click on the button</param>
		/// <param name="mouseButton">The mouse button clicked</param>
		void DoAction(BoxButton button, Point clickPoint, MouseButtons mouseButton);

		/// <summary>
		///     Occurs when a command must be sent to UO
		/// </summary>
		event SendCommandEventHandler SendCommand;

		/// <summary>
		///     Occurs when the button should send the last command again
		/// </summary>
		event EventHandler SendLastCommand;

		/// <summary>
		///     Occurs when the default command for the button changes
		/// </summary>
		event CommandChangedEventHandler CommandChanged;
	}
}