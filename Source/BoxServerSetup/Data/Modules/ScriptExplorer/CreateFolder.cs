using System;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Creates a new folder on the server
	/// </summary>
	public class CreateFolder : ExplorerMessage
	{
		private string m_Folder;

		/// <summary>
		/// Gets or sets the name of the new folder
		/// </summary>
		public string Folder
		{
			get { return m_Folder; }
			set { m_Folder = value; }
		}

		/// <summary>
		/// Creates a new CreateFolder message
		/// </summary>
		public CreateFolder()
		{
		}

		public override BoxMessage Perform()
		{
			BoxMessage msg = null;

			if ( RemoteExplorerConfig.AllowAccess( Username, m_Folder ) )
			{
				try
				{
					string path = System.IO.Path.Combine( BoxUtil.RunUOFolder, m_Folder );

					System.IO.Directory.CreateDirectory( path );
					msg = new GenericOK();
				}
				catch ( Exception err )
				{
					msg = new ErrorMessage( "An error occurred when creating the folder:\n\n{0}", err.ToString() );
				}
			}
			else
			{
				msg = new ErrorMessage( "You can't create folders there" );
			}

			return msg;
		}

	}
}
