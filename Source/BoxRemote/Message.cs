#region Header
// /*
//  *    2018 - BoxServer - Message.cs
//  */
#endregion

#region References
using System;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace TheBox.BoxServer
{
	public enum AuthenticationResult
	{
		Success,
		WrongCredentials,
		OnlineMobileRequired,
		AccessLevelError,
		UnregisteredUser
	}

	/// <summary>
	///     Base class for a message exchanged between Pandora and RunUO
	/// </summary>
	public class BoxMessage
	{
		/// <summary>
		///     Gets or sets the username
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		///     Gets or sets the password hash
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		///     Creates a new Message object
		/// </summary>
		public BoxMessage()
		{ }

		/// <summary>
		///     Creates a new Message object
		/// </summary>
		/// <param name="username">The username of the user</param>
		/// <param name="password">The password hash of the user</param>
		public BoxMessage(string username, string password)
		{
			Username = username;
			Password = password;
		}

		/// <summary>
		///     Performs password authentication
		/// </summary>
		/// <param name="password">The password as it's extracted from the server</param>
		/// <param name="hashed">Specifies whether the password is hashed or not</param>
		/// <returns>True if the authentication is succesful</returns>
		public virtual AuthenticationResult Authenticate(string password, bool hashed)
		{
			var cmp = password;

			if (!hashed)
			{
				cmp = ComputePasswordHash(password.ToLower());
			}

			if (cmp == Password)
				return AuthenticationResult.Success;
			return AuthenticationResult.WrongCredentials;
		}

		/// <summary>
		///     Performs the action specified by the message
		/// </summary>
		/// <returns>The answer message</returns>
		public virtual BoxMessage Perform()
		{
			return null;
		}

		/// <summary>
		///     Converts a string into a hash code according to the MD5 algorithm
		/// </summary>
		/// <param name="password">The password to convert</param>
		/// <returns>The MD5 hash corresponding to the password</returns>
		private static string ComputePasswordHash(string password)
		{
			var encoding = Encoding.ASCII;

			var dataIn = new byte[256];

			MD5 md5 = new MD5CryptoServiceProvider();

			var length = Encoding.ASCII.GetBytes(password, 0, password.Length > 256 ? 235 : password.Length, dataIn, 0);

			var hashed = md5.ComputeHash(dataIn, 0, length);

			return BitConverter.ToString(hashed);
		}

		/// <summary>
		///     Compresses the message and prepares it for transport
		/// </summary>
		/// <returns>A byte array representing the compressed message</returns>
		public virtual byte[] Compress()
		{
			return BoxZLib.Compress(this);
		}

		/// <summary>
		///     Decompresses a message from a stream of bytes
		/// </summary>
		/// <param name="data">The byte array representing the message</param>
		/// <param name="type">The type corresponding to the message</param>
		/// <returns>The uncompressed Message object</returns>
		public static BoxMessage Decompress(byte[] data, Type type)
		{
			return BoxZLib.Decompress(data, type) as BoxMessage;
		}
	}
}