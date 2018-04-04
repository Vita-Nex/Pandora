using System;
using System.IO;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Uploads a file to the server or downloads a file to Pandora
	/// </summary>
	public class FileTransport : ExplorerMessage
	{
		private string m_Filename;
		private string m_Text;

		/// <summary>
		/// Gets or sets the path to the file relative to the RunUO folder
		/// </summary>
		public string Filename
		{
			get { return m_Filename; }
			set { m_Filename = value; }
		}

		/// <summary>
		/// Gets or sets the content of the file
		/// </summary>
		public string Text
		{
			get { return m_Text; }
			set { m_Text = value; }
		}

		/// <summary>
		/// Gets the full system path to the file
		/// </summary>
		public string FullPath
		{
			get
			{
				return System.IO.Path.Combine( BoxUtil.RunUOFolder, m_Filename );
			}
		}

		/// <summary>
		/// Creates a new FileTransport message
		/// </summary>
		public FileTransport()
		{
		}

		public override BoxMessage Perform()
		{
			BoxMessage msg = null;

			if ( RemoteExplorerConfig.AllowAccess( Username, Path.GetDirectoryName( m_Filename ) ) )
			{
				if ( RemoteExplorerConfig.VeirfyExtension( m_Filename ) )
				{
					try
					{
						StreamWriter writer = new StreamWriter( FullPath, false );
						writer.Write( m_Text );
						writer.Close();

						msg = new GenericOK();
					}
					catch ( Exception err )
					{
						msg = new ErrorMessage( "An I/O error occurred when writing the file.\n\n{0}", err.ToString() );
					}
				}
				else
				{
					// Extension not supported
					msg = new ErrorMessage( "File type not allowed." );
				}
			}
			else
			{
				// Trying to upload to a folder that isn't registered for the user
				msg = new ErrorMessage( "You aren't allowed to manipulate that folder." );
			}

			return msg;
		}
	}
}