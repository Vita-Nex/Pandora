using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox;
using TheBox.Common;

namespace TheBox.Data
{
	/// <summary>
	/// Manages the locations for Pandora's box
	/// </summary>
	public class TravelAgent
	{
		private Facet[] m_Facets;
		private string m_BaseFolder;
		private string[] m_FacetNames;

		/// <summary>
		/// Creates a TravelAgent, provider of travel data for Pandora
		/// </summary>
		public TravelAgent()
		{
			m_BaseFolder = Path.Combine( Pandora.Profile.BaseFolder, "Locations" );
			m_FacetNames = Pandora.Profile.Travel.MapNames;

			m_Facets = new Facet[ 4 ];

			Load();
		}

		private string GetFile( int Index )
		{
			string filename = Path.Combine( m_BaseFolder, string.Format( "map{0}.xml", Index ) );

			return filename;
		}

		private void SaveFile( int index )
		{
			string file = GetFile( index );

			Pandora.Log.WriteEntry( string.Format( "Saving file: {0}", file ) );

			XmlSerializer serializer = new XmlSerializer( typeof( Facet ) );

			try
			{
				FileStream stream = new FileStream( file, FileMode.Create );

				serializer.Serialize( stream, m_Facets[ index ] );

				stream.Close();
			}
			catch ( Exception err )
			{
				Pandora.Log.WriteError( err, string.Format( "Updates for map file {0} have not been recorded.", index ) );
			}
		}

		private void Load()
		{
			XmlSerializer serializer = new XmlSerializer( typeof( Facet ) );

			for ( int i = 0; i < 4; i++ )
			{
				Pandora.Log.WriteEntry( string.Format( "Reading locations file {0}: {1}", i, GetFile( i ) ) );

				FileStream stream = null;

				try
				{
					stream = new FileStream( GetFile( i ), FileMode.Open );
				}
				catch ( System.IO.FileNotFoundException )
				{
					Pandora.Log.WriteError( null, "File not found" );
					continue;
				}
				catch ( Exception err )
				{
					Pandora.Log.WriteError( err, null );
					continue;
				}

				try
				{
					m_Facets[ i ] = ( Facet ) serializer.Deserialize( stream );
				}
				catch ( Exception err )
				{
					Pandora.Log.WriteError( err, null );
					continue;
				}

				m_Facets[ i ].MapValue = (byte) i;
				stream.Close();
			}
		}

		/// <summary>
		/// Gets a TreeNode array for the full version of the tree
		/// </summary>
		/// <returns>A TreeNode arraylist. Each node is a facet node</returns>
		public TreeNode[] GetFullTree()
		{
			TreeNode[] nodes = new TreeNode[ 4 ];

			for ( int i = 0; i < 4; i++ )
			{
				nodes[ i ] = m_Facets[ i ].GetTreeNode( m_FacetNames[ i ] );
				nodes[ i ].Tag = (int) m_Facets[ i ].MapValue;
			}

			return nodes;
		}

		/// <summary>
		/// Gets the tree nodes for a single facet
		/// </summary>
		/// <param name="mapfile">The ID of the facet</param>
		/// <returns>The array of nodes corresponding to the categories of the facet</returns>
		public TreeNode[] GetNode( int mapfile )
		{
			TreeNode facet = m_Facets[ mapfile ].GetTreeNode( "" );

			TreeNode[] nodes = new TreeNode[ facet.Nodes.Count ];

			for ( int i = 0; i < facet.Nodes.Count; i++ )
			{
				nodes[ i ] = facet.Nodes[ i ];
			}

			return nodes;
		}

		/// <summary>
		/// Converts an array list of locations into tree nodes
		/// </summary>
		/// <param name="locations">The list of locations</param>
		/// <returns>An array of TreeNode objects corresponding to the locations supplied</returns>
		public TreeNode[] GetLocationNodes( ArrayList locations )
		{
			TreeNode[] nodes = new TreeNode[ locations.Count ];

			for ( int i = 0; i < nodes.Length; i++ )
			{
				Location loc = locations[ i ] as Location;

				nodes[ i ] = new TreeNode( loc.Name );
				nodes[ i ].Tag = loc;
			}

			return nodes;
		}

		/// <summary>
		/// Searches a tree
		/// </summary>
		/// <param name="text">The text to search for</param>
		/// <param name="nodes">The nodes to search</param>
		/// <param name="singlefacet">States whether the nodes correspond to a single facet, or to more than one facet</param>
		/// <returns>The SearchResult object with the results</returns>
		public SearchResults SearchFor( string text, TreeNodeCollection nodes, bool singlefacet )
		{
			if ( singlefacet )
			{
				return Facet.Search( nodes, text );
			}
			else
			{
				SearchResults results = Facet.Search( nodes[ 0 ].Nodes, text );

				for ( int i = 1; i < nodes.Count; i++ )
				{
					results.MergeWith( Facet.Search( nodes[ i ].Nodes, text ) );
				}

				return results;
			}
		}

		/// <summary>
		/// Updates the datafile for a given map
		/// </summary>
		/// <param name="map">The map index</param>
		/// <param name="nodes">The TreeNodeCollection representing the map</param>
		public void UpdateMap( int map, TreeNodeCollection nodes )
		{
			m_Facets[ map ] = Facet.FromTreeNodes( nodes, (byte) map );
			SaveFile( map );
		}
	}
}