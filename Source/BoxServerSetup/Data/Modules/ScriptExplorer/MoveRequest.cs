using System;
using System.IO;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Requests a rename or move action on the server
	/// </summary>
	public class MoveRequest : ExplorerMessage
	{
		private string m_OldPath;

		/// <summary>
		/// Gets or sets the previous name of location to move
		/// </summary>
		public string OldPath
		{
			get
			{
				return m_OldPath;
			}
			set
			{
				m_OldPath = value;
			}
		}

		private string m_NewPath;

		/// <summary>
		/// Gets or sets the new location of the object
		/// </summary>
		public string NewPath
		{
			get
			{
				return m_NewPath;
			}
			set
			{
				m_NewPath = value;
			}
		}

		/// <summary>
		/// Creates a new MoveRequest object
		/// </summary>
		public MoveRequest()
		{
		}

		public override BoxMessage Perform()
		{
			BoxMessage msg = null;
			
			string folderOld = Path.GetDirectoryName( m_OldPath );
			string folderNew = Path.GetDirectoryName( m_NewPath );

			string from = Path.Combine( BoxUtil.RunUOFolder, m_OldPath );
			string to = Path.Combine( BoxUtil.RunUOFolder, m_NewPath );

			if ( RemoteExplorerConfig.AllowAccess( Username, folderOld ) && RemoteExplorerConfig.AllowAccess( Username, folderNew ) )
			{
				try
				{
					if ( File.Exists( from ) )
					{
						File.Move( from, to );
						msg = null;
					}
					else if ( Directory.Exists( from ) )
					{
						Directory.Move( from, to );
						msg = new GenericOK();
					}
					else
					{
						msg = new ErrorMessage( "The requested object could not be found ({0})", m_OldPath );
					}
				}
				catch ( Exception err )
				{
					msg = new ErrorMessage( "An error occurred while processing the move request :\n\n{0}", err.ToString() );
				}
			}
			else
			{
				msg = new ErrorMessage( "You aren't allowed to access that." );
			}

			return msg;
		}
	}
}