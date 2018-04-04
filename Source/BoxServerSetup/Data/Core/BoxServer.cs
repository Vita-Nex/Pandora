using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Server;
using Server.Accounting;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Summary description for BoxServer.
	/// </summary>
	public class BoxServer
	{
		private const string m_Version = "0.3";

		/// <summary>
		/// Creates a new BoxServer object that will answer to remote calls
		/// </summary>
		public BoxServer()
		{
			BoxRemote.OnMessage += new TheBox.BoxServer.BoxRemote.Message(BoxRemote_OnMessage);
		}

		/// <summary>
		/// Called at startup
		/// </summary>
		public static void Initialize()
		{
			BoxServer server = new BoxServer();
			ThreadPool.QueueUserWorkItem( new WaitCallback( StartServer ) );
		}

		/// <summary>
		/// Registers the BoxRemote class for remote access on the server system
		/// </summary>
		private static void StartServer( object obj )
		{
			TcpServerChannel channel = new TcpServerChannel( "boxserver", BoxConfig.Port );
			ChannelServices.RegisterChannel( channel );

			RemotingConfiguration.RegisterWellKnownServiceType( typeof( BoxRemote ), "BoxRemote", WellKnownObjectMode.Singleton );

			Console.WriteLine( "Pandora is listening on port {0} - BoxServer version {1}", BoxConfig.Port, m_Version );

			while ( true )
			{
				Thread.Sleep( 30000 );
			}
		}

		/// <summary>
		/// Handles incoming messages
		/// </summary>
		/// <param name="typeName">The name of the type of the message</param>
		/// <param name="data">The byte array representing the message</param>
		/// <param name="answerType">Will hold the name of the type of the answer message</param>
		/// <returns>A stream of bytes</returns>
		private byte[] BoxRemote_OnMessage( string typeName, byte[] data, out string answerType )
		{
			answerType = null;
			BoxMessage inMsg = null;
			BoxMessage outMsg = null;

			Type type = Type.GetType( typeName );

			if ( type != null )
			{
				inMsg = BoxMessage.Decompress( data, type );

				if ( inMsg != null )
				{
					// Authenticate
					AuthenticationResult auth = Authentication.Authenticate( inMsg );

					if ( auth == AuthenticationResult.Success )
					{
						// Perform message
						outMsg = inMsg.Perform();
					}
					else
					{
						// Return authentication error
						outMsg = new LoginError( auth );
					}
				}
				else
				{
					// Send generic server error
					outMsg = new ErrorMessage( "An error occurred when decompressing the incoming message." );
				}
			}
			else
			{
				outMsg = new FeatureNotSupported();
			}

			if ( outMsg != null )
			{
				answerType = outMsg.GetType().FullName;
				return outMsg.Compress();
			}
			else
			{
				// Actions that don't require an answer
				answerType = null;
				return null;
			}
		}
	}
}