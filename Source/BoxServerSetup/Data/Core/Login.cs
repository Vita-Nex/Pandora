using System;

namespace TheBox.BoxServer
{
	/// <summary>
	/// The message used to login into the BoxServer
	/// </summary>
	public class LoginMessage : BoxMessage
	{
		/// <summary>
		/// Creates a new login message
		/// </summary>
		public LoginMessage()
		{
		}

		public override BoxMessage Perform()
		{
			return new LoginSuccess();
		}
	}

	/// <summary>
	/// The message confirming the login into the BoxServer
	/// </summary>
	public class LoginSuccess : BoxMessage
	{
		public LoginSuccess()
		{
		}
	}
}