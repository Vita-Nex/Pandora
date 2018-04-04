#region Header
// /*
//  *    2018 - Pandora - ServerOptions.cs
//  */
#endregion

#region References
using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

using TheBox.BoxServer;
#endregion

namespace TheBox.Options
{
	[Serializable]
	/// <summary>
	/// Provides options for BoxServer
	/// </summary>
	public class ServerOptions
	{
		private string m_Address = "";
		private int m_Port = 8035;
		private string m_Username = "";
		private string m_Password = "";
		private bool m_ConnectOnStartup;
		private bool m_Enabled;
		private bool m_UseSHA1Crypt;

		/// <summary>
		///     Gets or sets a value stating whether Pandora should use BoxServer
		/// </summary>
		public bool Enabled { get { return m_Enabled; } set { m_Enabled = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the server address
		/// </summary>
		public string Address { get { return m_Address; } set { m_Address = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Port number
		/// </summary>
		public int Port { get { return m_Port; } set { m_Port = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Username
		/// </summary>
		public string Username { get { return m_Username; } set { m_Username = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Password
		/// </summary>
		public string Password { get { return m_Password; } set { m_Password = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets a value stating whether Pandora should connect on startup
		/// </summary>
		public bool ConnectOnStartup { get { return m_ConnectOnStartup; } set { m_ConnectOnStartup = value; } }

		/// <summary>
		///     Specifies whether the server uses the SHA1 crypt to perform hashing
		/// </summary>
		public bool UseSHA1Crypt { get { return m_UseSHA1Crypt; } set { m_UseSHA1Crypt = value; } }

		/// <summary>
		///     Sets the correct username and password for an outgoing BoxMessage
		/// </summary>
		/// <param name="msg">The BoxMessage that needs authentication values set</param>
		public void FillBoxMessage(BoxMessage msg)
		{
			msg.Username = m_Username;
			msg.Password = m_Password;
		}

		/// <summary>
		///     Sets the password by performing the M5D hash
		/// </summary>
		/// <param name="password">The password value</param>
		public void SetPassword(string password)
		{
			if (!m_UseSHA1Crypt)
			{
				var encoding = Encoding.ASCII;

				var dataIn = new byte[256];

				MD5 md5 = new MD5CryptoServiceProvider();

				var length = Encoding.ASCII.GetBytes(password, 0, password.Length > 256 ? 235 : password.Length, dataIn, 0);

				var hashed = md5.ComputeHash(dataIn, 0, length);

				m_Password = BitConverter.ToString(hashed);
			}
			else
			{
				m_Password = ComputeSHA1PasswordHash(password, m_Username);
			}
		}

		/// <summary>
		///     Apllied the fix from "Issue 56:  	 BoxServer Work with PD 3.0.0.4" without testing it yet.
		///     The lines are just commented out until it is tested.
		/// </summary>
		/// <param name="password"></param>
		/// <param name="username"></param>
		/// <returns></returns>
		private static string ComputeSHA1PasswordHash(string password, string username)
		{
			HashAlgorithm hash = new SHA1CryptoServiceProvider();
			var buffer = new byte[256];

			var sb = new StringBuilder();

			sb.Append(username);
			// Issue 56:  	 BoxServer Work with PD 3.0.0.4 - Tarion
			//sb.Append( username.Length );
			sb.Append(password);

			password = sb.ToString(); // Salted

			var length = Encoding.ASCII.GetBytes(password, 0, password.Length > 256 ? 256 : password.Length, buffer, 0);
			var hashed = hash.ComputeHash(buffer, 0, length);
			// Issue 56:  	 BoxServer Work with PD 3.0.0.4 - Tarion
			//hashed = hash.ComputeHash( hashed, 0, hashed.Length );

			return BitConverter.ToString(hashed);
		}
	}
}