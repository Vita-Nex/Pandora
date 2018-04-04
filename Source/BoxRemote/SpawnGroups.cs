using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;

namespace TheBox.Data
{
	[ Serializable, XmlInclude( typeof( GenericNode ) ) ]
	/// <summary>
	/// Summary description for SpawnGroups.
	/// </summary>
	public class SpawnGroups
	{
		private ArrayList m_Structure;

		public SpawnGroups()
		{
			m_Structure = new ArrayList();
		}

		/// <summary>
		/// Gets or sets the groups structure
		/// </summary>
		public ArrayList Structure
		{
			get { return m_Structure; }
			set { m_Structure = value; }
		}

		/// <summary>
		/// Gets the nodes representing the spawns
		/// </summary>
		/// <returns>An array of TreeNode items</returns>
		public TreeNode[] GetNodes()
		{
			TreeNode[] nodes = new TreeNode[ m_Structure.Count ];
			int i = 0;

			foreach ( GenericNode gNode in m_Structure )
			{
				TreeNode node = new TreeNode( gNode.Name );
				node.Tag = gNode.Elements;

				nodes[ i++ ] = node;
			}

			return nodes;
		}

		/// <summary>
		/// Updates the spawn groups and saves them to disk
		/// </summary>
		/// <param name="nodes"></param>
		public void Update( TreeNodeCollection nodes )
		{
			m_Structure.Clear();

			foreach ( TreeNode node in nodes )
			{
				GenericNode gNode = new GenericNode( node.Text );
				gNode.Elements = node.Tag as ArrayList;

				m_Structure.Add( gNode );
			}

			Save();
		}

		/// <summary>
		/// Saves the spawn groups to file
		/// </summary>
		public void Save()
		{
			string filename = Path.Combine( Pandora.Profile.BaseFolder, "SpawnGroups.xml" );

			try
			{
				XmlSerializer serializer = new XmlSerializer( typeof( SpawnGroups ) );
				FileStream stream = new FileStream( filename, FileMode.Create, FileAccess.Write, FileShare.Read);
				serializer.Serialize( stream, this );
				stream.Close();
				Pandora.Log.WriteEntry( "Spawn Groups saved to {0}", filename );
			}
			catch ( Exception err )
			{
				Pandora.Log.WriteError( err, "Couldn't save spawn groups to {0}", filename );
			}
		}

		/// <summary>
		/// Loads the spawn groups according to the current profile
		/// </summary>
		/// <returns>A SpawnGroups object</returns>
		public static SpawnGroups Load()
		{
			string filename = Path.Combine( Pandora.Profile.BaseFolder, "SpawnGroups.xml" );

			SpawnGroups sg = null;

			if ( File.Exists( filename ) )
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer( typeof( SpawnGroups ) );
					FileStream stream = new FileStream( filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
					sg = serializer.Deserialize( stream ) as SpawnGroups;
					stream.Close();
					Pandora.Log.WriteEntry( "Spawn groups loaded correctly from {0}", filename );
				}
				catch ( Exception err )
				{
					Pandora.Log.WriteError( err, "Couldn't read spawn groups from {0}", filename );
					sg = new SpawnGroups();
				}
			}
			else
			{
				sg = new SpawnGroups();
			}

			return sg;
		}
	}
}
