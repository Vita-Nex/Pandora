using System;
using System.IO;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Requests to download a file from the server
	/// </summary>
	public class DownloadRequest : ExplorerMessage
	{
		private string m_Filename;

		/// <summary>
		/// Gets or sets the filename to be retrieved, relative to the RunUO path
		/// </summary>
		public string Filename
		{
			get { return m_Filename; }
			set { m_Filename = value; }
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
		
		public DownloadRequest()
		{
		}

		public override BoxMessage Perform()
		{
			string folder = Path.GetDirectoryName( m_Filename );
			BoxMessage msg = null;

			if ( RemoteExplorerConfig.AllowAccess( Username, folder ) )
			{
				if ( File.Exists( FullPath ) )
				{
					FileInfo info = new FileInfo( FullPath );

					if ( info.Length <= RemoteExplorerConfig.MaxFileSize )
					{
						try
						{
							msg = new FileTransport();

							StreamReader reader = new StreamReader( info.FullName );
							( msg as FileTransport ).Text = reader.ReadToEnd();
							reader.Close();
						}
						catch ( Exception err )
						{
							msg = new ErrorMessage( "An I/O error occurred when reading the file:\n\n", err.ToString() );
						}
					}
					else
					{
						// File is too big
						msg = new ErrorMessage( "The requested file is too big." );
					}
				}
				else
				{
					// File not found
					msg = new ErrorMessage( "The requested file could not be found" );
				}
			}
			else
			{
				// Trying to request a file from a folder that isn't registered
				msg = new ErrorMessage( "The requested resource isn't available to you." );
			}

			return msg;
		}
	}
}