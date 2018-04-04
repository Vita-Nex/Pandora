using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Reflection;

using TheBox.Common;

namespace TheBox.Data
{
	/// <summary>
	/// Contains data used for display of items and mobiles in PB
	/// </summary>
	[ Serializable ]
	[ XmlInclude( typeof( BoxMobile ) ) ]
	[ XmlInclude( typeof( BoxItem ) ) ]
	[ XmlInclude( typeof( GenericNode ) ) ]
	public class BoxData
	{
		private ArrayList m_Items;
		private ArrayList m_Mobiles;

		/// <summary>
		/// Creates a new BoxData object
		/// </summary>
		public BoxData()
		{
			m_Items = new ArrayList();
			m_Mobiles = new ArrayList();
		}

		/// <summary>
		/// Gets or sets the Items structure
		/// </summary>
		public ArrayList Items
		{
			get { return m_Items; }
			set { m_Items = value; }
		}

		/// <summary>
		/// Gets or sets the Mobiles structure
		/// </summary>
		public ArrayList Mobiles
		{
			get { return m_Mobiles; }
			set { m_Mobiles = value; }
		}

		/// <summary>
		/// Creates a BoxData object provided the items and mobiles
		/// </summary>
		/// <param name="boxItems">A list of BoxItem objects</param>
		/// <param name="boxMobiles">A list of BoxMobile objects</param>
		/// <returns>A BoxData object containing a categories structure</returns>
		public static BoxData Create( ArrayList boxItems, ArrayList boxMobiles )
		{
			BoxData data = new BoxData();

			// Items
			foreach ( BoxItem item in boxItems )
			{
				GenericNode node = data.GetNode( data.m_Items, item.Path );
				node.Elements.Add( item );
			}

			// Mobiles
			foreach ( BoxMobile mobile in boxMobiles )
			{
				GenericNode node = data.GetNode( data.m_Mobiles, mobile.Path );
				node.Elements.Add( mobile );
			}

			return data;
		}

		/// <summary>
		/// Gets a GenericNode corresponding to the provided path
		/// </summary>
		/// <param name="where">The list to search for the node</param>
		/// <param name="path"></param>
		/// <returns></returns>
		private GenericNode GetNode( ArrayList where, StringCollection path )
		{
			ArrayList list = where;
			GenericNode node = null;

			foreach ( string s in path )
			{
				node = FindNode( list, s );

				if ( node == null )
				{
					node = new GenericNode( s );
					list.Add( node );
				}

				list = node.Elements;
			}

			if ( node == null )
			{
				node = FindNode( where, "Uncategorized" );
				
				if ( node == null )
				{
					node = new GenericNode( "Uncategorized" );
					where.Add( node );
				}
			}

			return node;
		}

		/// <summary>
		/// Finds a GenericNode in a list of items
		/// </summary>
		/// <param name="where">The list of items to search for the node</param>
		/// <param name="name">The name of the node to search for</param>
		/// <returns>The node, if found. Null otherwise.</returns>
		private GenericNode FindNode( ArrayList where, string name )
		{
			name = name.ToLower();

			foreach ( object o in where )
			{
				if ( o is GenericNode )
				{
					GenericNode node = o as GenericNode;

					if ( node.Name.ToLower() == name )
						return node;
				}
			}

			return null;
		}

		/// <summary>
		/// Loads the BoxData from file
		/// </summary>
		/// <returns></returns>
		public static BoxData Load()
		{
			BoxData data = new BoxData();

			string filename = Path.Combine( Pandora.Profile.BaseFolder, "BoxData.xml" );

			if ( File.Exists( filename ) )
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer( typeof( BoxData ) );
					FileStream stream = new FileStream( filename, FileMode.Open, FileAccess.Read, FileShare.Read );
					data = serializer.Deserialize( stream ) as BoxData;
					stream.Close();
					Pandora.Log.WriteEntry( string.Format( "BoxData read correctly from file: {0}", filename ) );
				}
				catch ( Exception err )
				{
					Pandora.Log.WriteError( err, string.Format( "Cannot read BoxData from file {0}", filename ) );
				}
			}

			return data;
		}

		/// <summary>
		/// Saves the BoxData object to the xml file
		/// </summary>
		public void Save()
		{
			string filename = Path.Combine( Pandora.Profile.BaseFolder, "BoxData.xml" );

			try
			{
				XmlSerializer serializer = new XmlSerializer( typeof( BoxData ) );
				FileStream stream = new FileStream( filename, FileMode.Create, FileAccess.Write, FileShare.None );
				serializer.Serialize( stream, this );
				stream.Close();

				Pandora.Log.WriteEntry( string.Format( "BoxData saved correctly to {0}", filename ) );
			}
			catch ( Exception err )
			{
				Pandora.Log.WriteError( err, "Couldn't save BoxData to file: {0}", filename );
			}
		}
	}

	#region BoxItem

	/// <summary>
	/// Contains data used to display an item in PB
	/// </summary>
	[ Serializable ]
	public class BoxItem : IComparable
	{
		private string m_Name;
		private int m_Art = 0;
		private int m_Hue = 0;

		private bool m_DefaultCtor = false;

		private StringCollection m_Path;

		/// <summary>
		/// Creates a new BoxItem object
		/// </summary>
		public BoxItem()
		{
			m_Path = new StringCollection();
		}

		/// <summary>
		/// Gets or sets the item name (Type name)
		/// </summary>
		[ XmlAttribute, Description( "The name of the item. This should not contain any spaces." ), Category( "Item" ) ]
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the ID for the item display
		/// </summary>
		[ XmlAttribute, Description( "The id of the art used to display the item" ), Category( "Item") ]
		public int Art
		{
			get { return m_Art; }
			set { m_Art = value; }
		}

		/// <summary>
		/// Gets or sets the Hue for the item
		/// </summary>
		[ XmlAttribute, Description( "The hue used to color the item." ), Category( "Item" ) ]
		public int Hue
		{
			get { return m_Hue; }
			set
			{
				m_Hue = value;
				if ( m_Hue >= 3000 )
					m_Hue = 0;
			}
		}

		/// <summary>
		/// Gets or sets a value stating whether this item has a default constructor
		/// </summary>
		[ XmlAttribute, Browsable( false ) ]
		public bool DefaultCtor
		{
			get { return m_DefaultCtor; }
			set { m_DefaultCtor = value; }
		}

		/// <summary>
		/// Sets the filename of the file that holds this item
		/// </summary>
		[ XmlIgnore, Browsable( false ) ]
		public string FileName
		{
			set
			{
				if ( value != null )
				{
					m_Path.AddRange( value.Split( new char[] { System.IO.Path.DirectorySeparatorChar } ) );

					if ( m_Path.Count > 0 )
					{
						if ( m_Path[ 0 ].ToLower() == "items" )
							m_Path.RemoveAt( 0 );
					}

					if ( m_Path.Count == 0 )
						m_Path.Add( "Uncategorized" );
				}
				else
				{
					m_Path.Add( "Uncategorized" );
				}
			}
		}

		/// <summary>
		/// Gets the tree path used to categorize this item
		/// </summary>
		[ XmlIgnore, Browsable( false ) ]
		public StringCollection Path
		{
			get
			{
				return m_Path;
			}
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			BoxItem cmp = obj as BoxItem;

			return m_Name.CompareTo( cmp.m_Name );
		}

		#endregion
	}

	#endregion

	#region BoxMobile

	/// <summary>
	/// Contains data used to describe a mobile in PB
	/// </summary>
	[ Serializable	]
	public class BoxMobile : IComparable
	{
		private string m_Name;
		private int m_Art;
		private int m_Hue;

		private bool m_CanBeNamed = false;

		private StringCollection m_Path;

		/// <summary>
		/// Creates a new BoxMobile object
		/// </summary>
		public BoxMobile()
		{
			m_Path = new StringCollection();
		}

		[ Description( "The name of the mobile. This must not include spaces" ),
			Category( "Mobile" ) ]
		/// <summary>
		/// Gets or sets the name of the mobile (Type name)
		/// </summary>
		[ XmlAttribute ]
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		[ Description( "The number corresponding to the body of this mobile" ), Category( "Mobile" ) ]
		/// <summary>
		/// Gets or sets the ID used to display the mobile
		/// </summary>
		[ XmlAttribute ]
		public int Art
		{
			get { return m_Art; }
			set { m_Art = value; }
		}

		[ Description( "The number corresponding to the hue of this mobile" ), Category( "Mobile" ) ]
		/// <summary>
		/// Gets or sets the hue number
		/// </summary>
		[ XmlAttribute ]
		public int Hue
		{
			get { return m_Hue; }
			set
			{
				m_Hue = value;
				if ( m_Hue >= 3000 )
					m_Hue = 0;
			}
		}

		[ Description( "Specifies whether this mobile accepts a name as additional parameter" ), Category( "Mobile" ) ]
		/// <summary>
		/// Gets or sets a value stating whether the mobile has a constructor allowing to name it
		/// </summary>
		[ XmlAttribute ]
		public bool CanBeNamed
		{
			get { return m_CanBeNamed; }
			set { m_CanBeNamed = value; }
		}

		[ Browsable( false ) ]
		/// <summary>
		/// Gets the list of strings defining the path to 
		/// </summary>
		[ XmlIgnore ]
		public StringCollection Path
		{
			get { return m_Path; }
		}

		[ Browsable ( false ) ]
		/// <summary>
		/// Sets the file path for this mobile
		/// </summary>
		[ XmlIgnore ]
		public string FileName
		{
			set
			{
				if ( value != null )
				{
					m_Path.AddRange( value.Split( new char[] { System.IO.Path.DirectorySeparatorChar } ) );

					if ( m_Path.Count > 0 )
					{
						if ( m_Path[ 0 ].ToLower() == "mobiles" )
							m_Path.RemoveAt( 0 );
					}

					if ( m_Path.Count == 0 )
						m_Path.Add( "Uncategorized" );
				}
				else
				{
					m_Path.Add( "Uncategorized" );
				}
			}
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			BoxMobile cmp = obj as BoxMobile;

			return m_Name.CompareTo( cmp.m_Name );
		}

		#endregion
	}

	#endregion
}