using System;
using System.IO;
using System.Xml.Serialization;

using TheBox.Common;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Provides Pandora with information about files and folders on the server
	/// </summary>
	[ Serializable, XmlInclude( typeof( GenericNode ) ) ]
	public class FolderInfo : ExplorerMessage
	{
		private GenericNode m_Structure;

		/// <summary>
		/// Gets or sets the Structure of the allowed folders on the server
		/// </summary>
		public GenericNode Structure
		{
			get
			{
				return m_Structure;
			}
			set
			{
				m_Structure = value;
			}
		}

		/// <summary>
		/// Creates a new FolderInfo object
		/// </summary>
		public FolderInfo()
		{
		}

		/// <summary>
		/// Creates a new BoxFolderInfo object
		/// </summary>
		/// <param name="username">The username of the user registered for acess to the explorer</param>
		public FolderInfo( string username )
		{
			m_Structure = new GenericNode();
			m_Folders = new System.Collections.ArrayList( RemoteExplorerConfig.GetExplorerFolder( username ) );
			
			// Create the folders structure
			foreach ( string folder in m_Folders )
			{
				BoxUtil.EnsureFolder( folder );

				GenericNode fNode = new GenericNode( folder );

				DoFolder( Path.Combine( BoxUtil.RunUOFolder, folder ), fNode);

				m_Structure.Elements.Add( fNode );
			}
		}

		/// <summary>
		/// Processes a folder for script files and subfolders
		/// </summary>
		/// <param name="folder">The folder to process</param>
		/// <param name="parent">The GenericNode that will be hosting the information</param>
		private static void DoFolder( string folder, GenericNode parent )
		{
			string[] dirs = Directory.GetDirectories( folder );

			foreach( string dir in dirs )
			{
				string[] path = dir.Split( Path.DirectorySeparatorChar );
				GenericNode dirNode = new GenericNode( path[ path.Length - 1 ] );

				DoFolder( dir, dirNode );

				parent.Elements.Add( dirNode );
			}

			string[] files = Directory.GetFiles( folder );

			foreach ( string file in files )
			{
				string t = file.ToLower();

				if ( t.EndsWith( ".cs" ) || t.EndsWith( ".txt" ) || t.EndsWith( ".xml" ) || t.EndsWith( ".vb" ) )
				{
					System.IO.FileInfo info = new System.IO.FileInfo( file );

					if ( info.Length <= RemoteExplorerConfig.MaxFileSize )
						parent.Elements.Add( Path.GetFileName( file ) );
				}
			}
		}
	}
}
