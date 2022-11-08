#region Header
// /*
//  *    2018 - Pandora - BoxConnection.cs
//  */
#endregion

#region References
using System;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Forms;
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     Provides methods for managing interaction with the BoxServer
	/// </summary>
	public class BoxConnection
	{
		/// <summary>
		///     Occurs when the online state of Pandora's Box is changed
		/// </summary>
		public event EventHandler OnlineChanged;

		private BoxRemote m_Remote;
		private readonly ProfileManager m_Profiles;

		/// <summary>
		///     Specifies whether Pandora is connected to the BoxServer
		/// </summary>
		private static bool m_Connected;

		/// <summary>
		///     States whether Pandora is connected to the BoxServer
		/// </summary>
		public bool Connected
		{
			get => m_Connected;
			private set
			{
				if (m_Connected != value)
				{
					m_Connected = value;

					OnlineChanged?.Invoke(null, new EventArgs());
				}
			}
		}

		public BoxConnection(ProfileManager profiles)
		{
			m_Profiles = profiles;
		}

		public void RequestConnection()
		{
			if (Pandora.Profile.Server.Enabled)
			{
				if (MessageBox.Show(
						Pandora.BoxForm as Form,
						Pandora.Localization.TextProvider["Misc.RequestConnection"],
						null,
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Disconnect();

					var form = new BoxServerForm(false);
					_ = form.ShowDialog();
				}
			}
			else
			{
				_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.NoServer"]);
			}
		}

		/// <summary>
		///     Checks a BoxMessage and processes any errors occurred
		/// </summary>
		/// <param name="msg">The BoxMessage returned by the server</param>
		/// <returns>True if the message is OK, false if errors have been found</returns>
		public bool CheckErrors(BoxMessage msg)
		{
			if (msg == null)
			{
				return true; // null message means no error
			}

			if (msg is ErrorMessage)
			{
				// Generic error message
				_ = MessageBox.Show(
					String.Format(Pandora.Localization.TextProvider["Errors.GenServErr"], (msg as ErrorMessage).Message));
				return false;
			}
			if (msg is LoginError)
			{
				var logErr = msg as LoginError;

				string err = null;

				switch (logErr.Error)
				{
					case AuthenticationResult.AccessLevelError:

						err = Pandora.Localization.TextProvider["Errors.LoginAccess"];
						break;

					case AuthenticationResult.OnlineMobileRequired:

						err = Pandora.Localization.TextProvider["Errors.NotOnline"];
						break;

					case AuthenticationResult.UnregisteredUser:

						err = Pandora.Localization.TextProvider["Errors.LogUnregistered"];
						break;

					case AuthenticationResult.WrongCredentials:

						err = Pandora.Localization.TextProvider["Errors.WrongCredentials"];
						break;

					case AuthenticationResult.Success:

						return true;
				}

				_ = MessageBox.Show(err);
				return false;
			}
			if (msg is FeatureNotSupported)
			{
				_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.NotSupported"]);
				return false;
			}

			return true;
		}

		/// <summary>
		///     Tries to connect to the BoxServer
		/// </summary>
		/// <returns>True if succesful</returns>
		public bool Connect()
		{
			return Connect(true);
		}

		/// <summary>
		///     Tries to connect to the BoxServer
		/// </summary>
		/// <param name="ProcessErrors">Specifies whether to process errors and display them to the user</param>
		/// <returns>True if succesful</returns>
		public bool Connect(bool ProcessErrors)
		{
			try
			{
				var ConnectionString = String.Format(
					"tcp://{0}:{1}/BoxRemote",
					Pandora.Profile.Server.Address,
					Pandora.Profile.Server.Port);

				m_Remote = Activator.GetObject(typeof(BoxRemote), ConnectionString) as BoxRemote;

				// Perform Login
				BoxMessage msg = new LoginMessage
				{
					Username = Pandora.Profile.Server.Username,
					Password = Pandora.Profile.Server.Password
				};
				var data = msg.Compress();

				var result = m_Remote.PerformRemoteRequest(msg.GetType().FullName, data, out var outType);

				if (result == null)
				{
					_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.ServerError"]);
					Connected = false;
					return false;
				}

				var t = Type.GetType(outType);

				var outcome = BoxMessage.Decompress(result, t);

				if (ProcessErrors)
				{
					if (!CheckErrors(outcome))
					{
						Connected = false;
						return false;
					}
				}

				if (outcome is LoginSuccess)
				{
					Connected = true;
					return true;
				}
				Connected = false;
				return false;
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Connection failed to box server");
				Connected = false;
			}

			return false;
		}

		/// <summary>
		///     Closes the connection with the server
		/// </summary>
		public void Disconnect()
		{
			if (m_Remote != null)
			{
				m_Remote = null;
				Connected = false;
			}
		}

		/// <summary>
		///     Sends a message to the server
		/// </summary>
		/// <param name="msg">The message being sent to the server</param>
		/// <param name="window">Specifies whether to use the connection form</param>
		/// <returns>The outcome of the transaction</returns>
		public BoxMessage ProcessMessage(BoxMessage msg, bool window)
		{
			if (window)
			{
				var form = new BoxServerForm(msg);
				_ = form.ShowDialog();
				return form.Response;
			}
			return ProcessMessage(msg);
		}

		/// <summary>
		///     Sends a message to the server. Processes errors too.
		/// </summary>
		/// <param name="msg">The message to send to the server</param>
		/// <returns>A BoxMessage if there is one</returns>
		public BoxMessage ProcessMessage(BoxMessage msg)
		{
			if (!Connected)
			{
				_ = Connect();
			}

			if (!Connected)
			{
				return null;
			}

			var data = msg.Compress();
			BoxMessage outcome;
			try
			{
				var result = m_Remote.PerformRemoteRequest(msg.GetType().FullName, data, out var outType);

				if (result == null)
				{
					return null;
				}

				var t = Type.GetType(outType);
				outcome = BoxMessage.Decompress(result, t);

				if (!CheckErrors(outcome))
				{
					outcome = null;
				}
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Error when processing a BoxMessage of type: {0}", msg.GetType().FullName);
				_ = MessageBox.Show(Pandora.Localization.TextProvider["Errors.ConnectionLost"]);
				Connected = false;
				outcome = null;
			}

			return outcome;
		}

		/// <summary>
		///     Sends a message to the BoxServer
		/// </summary>
		/// <param name="message">The message that must be sent</param>
		/// <returns>The message outcome</returns>
		public BoxMessage SendToServer(BoxMessage message)
		{
			if (!Connected)
			{
				// Not connected, request connection
				if (MessageBox.Show(
						null,
						Pandora.Localization.TextProvider["Misc.RequestConnection"],
						"",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					var form = new BoxServerForm(false);
					_ = form.ShowDialog();
				}

				if (!Connected)
				{
					return null;
				}
			}

			Pandora.Profile.Server.FillBoxMessage(message);

			var msgForm = new BoxServerForm(message);
			_ = msgForm.ShowDialog();

			Utility.BringClientToFront();

			return msgForm.Response;
		}
	}
}