#region Header
// /*
//  *    2018 - Pandora - Login.cs
//  */
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     The message used to login into the BoxServer
	/// </summary>
	public class LoginMessage : BoxMessage
	{
		public override BoxMessage Perform()
		{
			return null;
		}
	}

	/// <summary>
	///     The message confirming the login into the BoxServer
	/// </summary>
	public class LoginSuccess : BoxMessage
	{ }
}