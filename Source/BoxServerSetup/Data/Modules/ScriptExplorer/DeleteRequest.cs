using System;
using System.IO;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Processes a request to delete a file or a folder
	/// </summary>
	public class DeleteRequest : ExplorerMessage
	{
		private string m_Path;

		/// <summary>
		/// Gets or sets the path that must be deleted
		/// </summary>
		public string Path
		{
			get { return m_Path; }
			set { m_Path = value; }
		}

		/// <summary>
		/// Gets the full path to the element that must be deleted
		/// </summary>
		public string FullPath
		{
			get
			{
				return System.IO.Path.Combine( BoxUtil.RunUOFolder, m_Path );
			}
		}

		/// <summary>
		/// Creates a new delete request
		/// </summary>
		public DeleteRequest()
		{
		}

		/// <summary>
		/// Creates a new DeleteRequest
		/// </summary>
		/// <param name="path">The relative path that should be deleted</param>
		public DeleteRequest( string path )
		{
			m_Path = path;
		}

		public override BoxMessage Perform()
		{
			BoxMessage msg = null;

			if ( RemoteExplorerConfig.AllowAccess( Username, System.IO.Path.GetDirectoryName( m_Path ) ) )
			{
				if ( Directory.Exists( FullPath ) )
				{
					try
					{
						Directory.Delete( FullPath, true );
						msg = new GenericOK();
					}
					catch ( Exception err )
					{
						msg = new ErrorMessage( "Couldn't delete the directory {0}. The following error occurred:\n\n{1}", m_Path, err.ToString() );
					}
				}
				else if ( File.Exists( FullPath ) )
				{
					try
					{
						File.Delete( FullPath );
						msg = null;
					}
					catch ( Exception err )
					{
						msg = new ErrorMessage( "Couldn't delete the file {0}. The following error occurred:\n\n{1}", m_Path, err.ToString() );
					}
				}
				else
				{
					// Not found
					msg = new ErrorMessage( "The requested resource could not be found on the server, please refresh your view." );
				}
			}
			else
			{
				// Can't manipulate that folder
				msg = new ErrorMessage( "You aren't allowed to manipulate the folder : {0}", m_Path );
			}

			return msg;
		}

	}
}