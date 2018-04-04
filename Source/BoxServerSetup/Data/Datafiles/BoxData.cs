using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Reflection;

using TheBox.Common;
using TheBox.BoxServer;

using Server;

namespace TheBox.Data
{
	/// <summary>
	/// Provides the logic used to generate the information for the BoxData object
	/// </summary>
	public class BoxDataGenerator
	{
		#region [GenBoxData

		public static void Initialize()
		{
			Server.Commands.Register( "GenBoxData", AccessLevel.Administrator, new CommandEventHandler( GenBoxData_OnCommand ) );
		}

		private static void GenBoxData_OnCommand( CommandEventArgs e )
		{
			GenerateData();
		}

		#endregion

		/// <summary>
		/// Generates the BoxData.xml for the current configuration
		/// </summary>
		public static void GenerateData()
		{
			World.Broadcast( BoxConfig.MessageHue, false, "Generating datafile for Pandora's Box. Please wait." );
			DateTime start = DateTime.Now;

			StringDictionary classes = CategorizeClasses();
			ArrayList types = LoadTypes();

			ArrayList items = new ArrayList();
			ArrayList mobiles = new ArrayList();

			ProcessTypes( types, items, mobiles, classes );

			BoxData data = BoxData.Create( items, mobiles );

			data.Items.Sort();
			data.Mobiles.Sort();

			Save( data );

			TimeSpan duration = DateTime.Now - start;
			World.Broadcast( BoxConfig.MessageHue, false, "Generation complete. The process took {0} seconds.", duration.TotalSeconds );
		}

		#region Types processing

		/// <summary>
		/// Processes the types and extracts item and mobile information
		/// </summary>
		/// <param name="types">A list of types to process</param>
		/// <param name="items">An array list that will hold the extracted items</param>
		/// <param name="mobiles">An array list that will hold the extracted mobiles</param>
		/// <param name="table">The StringDictionary item providing information about the classes location</param>
		private static void ProcessTypes( ArrayList types, ArrayList items, ArrayList mobiles, StringDictionary table )
		{
			foreach ( Type t in types )
			{
				if ( t.IsSpecialName )
					continue;

				if ( ( typeof( Item ) ).IsAssignableFrom( t ) )
				{
					// Item
					BoxItem item = BoxItem.FromType( t );

					if ( item != null )
					{
						item.FileName = table[ item.Name.ToLower() ];
						items.Add( item );
					}
				}
				else if ( ( typeof( Mobile ) ).IsAssignableFrom( t ) )
				{
					// Mobile
					BoxMobile mobile = BoxMobile.FromType( t );

					if ( mobile != null )
					{
						mobile.FileName = table[ mobile.Name.ToLower() ];
						mobiles.Add( mobile );
					}
				}
			}
		}

		/// <summary>
		/// Creates a list of types existing in the server
		/// </summary>
		/// <returns>An ArrayList of Type objects</returns>
		public static ArrayList LoadTypes()
		{
			ArrayList asms = new ArrayList();
			ArrayList types = new ArrayList();

			asms.Add( Core.Assembly );
			asms.AddRange( ScriptCompiler.Assemblies );

			foreach ( Assembly asm in asms )
			{
				types.AddRange( asm.GetTypes() );
			}

			return types;
		}

		#endregion

		#region Classes search

		/// <summary>
		/// Reads the script folder and collects information about classes
		/// </summary>
		/// <returns>The table including information about the classes found</returns>
		private static StringDictionary CategorizeClasses()
		{
			string ScriptsFolder = Path.Combine( BoxUtil.RunUOFolder, "Scripts" );

			StringDictionary table = new StringDictionary();

			SearchForClasses( ScriptsFolder, table );

			return table;
		}

		/// <summary>
		/// Searches a folder for cs files containing classes
		/// </summary>
		/// <param name="folder">The path to a folder</param>
		/// <param name="table">The StringDictionary to fill with the results</param>
		private static void SearchForClasses( string folder, StringDictionary table )
		{
			string[] subFolders = Directory.GetDirectories( folder );

			foreach ( string s in subFolders )
				SearchForClasses( s, table );

			string[] files = Directory.GetFiles( folder );

			foreach ( string s in files )
				SearchFileForClasses( s, table );
		}

		/// <summary>
		/// Searches a file for the classes it contains
		/// </summary>
		/// <param name="file">The name of the file to search</param>
		/// <param name="table">The StringDictionary to fill with the results</param>
		private static void SearchFileForClasses( string file, StringDictionary table )
		{
			if ( ! file.ToLower().EndsWith( ".cs" ) )
				return;

			string script = null;

			// .cs File
			try
			{
				StreamReader reader = new StreamReader( file );
				script = reader.ReadToEnd();
				reader.Close();
			}
			catch
			{
				return;
			}

			string path = Path.GetDirectoryName( file );
			path = path.Substring( BoxUtil.ScriptsFolder.Length );
			path = path.Trim( new char[] { Path.DirectorySeparatorChar } );

			Regex theReg = new Regex( "\\s*class\\s*" );

			MatchCollection theMatches = theReg.Matches( script );

			foreach ( Match match in theMatches )
			{
				string block = script.Substring( match.Index + match.Length );

				block.TrimStart( new char[] { ' ' } );
				int endIndex = block.IndexOfAny( new char[] { ' ', '(', ':', '\n', '\t', '\r', '/' } );

				if ( endIndex == 0 )
					continue;

				string className = block.Substring( 0, endIndex );

				table[ className ] = path;
			}
		}

		#endregion

		/// <summary>
		/// Saves the box data to file
		/// </summary>
		private static void Save( BoxData data )
		{
			string path = Path.Combine( BoxUtil.BoxFolder, "BoxData.xml" );
			BoxUtil.XmlSave( data, path );
		}
	}

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
		/// Reads a BoxData object from a file
		/// </summary>
		/// <param name="filename">The filename containing the BoxData object</param>
		/// <returns>The BoxData object read from file, or null if not succesful</returns>
		public static BoxData Load( string filename )
		{
			return BoxUtil.XmlLoad( filename, typeof( BoxData ) ) as BoxData;
		}
	}

	#region BoxMobile

	/// <summary>
	/// Contains data used to describe a mobile in PB
	/// </summary>
	[ Serializable ]
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

		/// <summary>
		/// Gets or sets the name of the mobile (Type name)
		/// </summary>
		[ XmlAttribute ]
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the ID used to display the mobile
		/// </summary>
		[ XmlAttribute ]
		public int Art
		{
			get { return m_Art; }
			set { m_Art = value; }
		}

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

		/// <summary>
		/// Gets or sets a value stating whether the mobile has a constructor allowing to name it
		/// </summary>
		[ XmlAttribute ]
		public bool CanBeNamed
		{
			get { return m_CanBeNamed; }
			set { m_CanBeNamed = value; }
		}

		/// <summary>
		/// Gets the list of strings defining the path to 
		/// </summary>
		[ XmlIgnore ]
		public StringCollection Path
		{
			get { return m_Path; }
		}

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

		/// <summary>
		/// Gets a BoxMobile object from a type
		/// </summary>
		/// <param name="t">The type to evaluate</param>
		/// <returns>A BoxMobile object or null if the type can't be constructed properly</returns>
		public static BoxMobile FromType( Type t )
		{
			ConstructorInfo[] ctors = t.GetConstructors();

			bool constructable = false;
			BoxMobile mobile = null;

			foreach ( ConstructorInfo c in ctors )
			{
				if ( BoxUtil.IsConstructable( c ) )
				{
					constructable = true;
					break;
				}
			}

			if ( constructable )
			{
				mobile = new BoxMobile();
				mobile.m_Name = t.Name;

				foreach ( ConstructorInfo c in ctors )
				{
					if ( BoxUtil.IsConstructable( c ) )
					{
						ParameterInfo[] pms = c.GetParameters();

						if ( pms.Length == 0 )
						{
							try
							{
								Mobile theMobile = (Mobile) Activator.CreateInstance( t );

								mobile.m_Art = theMobile.Body.BodyID;
								mobile.Hue = theMobile.Hue;

								if ( theMobile != null )
								{
									theMobile.Delete();
								}
							}
							catch
							{
								// TODO : Logging?
								return null;
							}
						}
						else if ( pms.Length == 1 && ( pms[ 0 ].ParameterType == typeof( string ) ) )
						{
							mobile.CanBeNamed = true;
						}
					}
				}
			}

			return mobile;
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			BoxMobile mob = obj as BoxMobile;

			if ( mob != null )
			{
				return m_Name.CompareTo( mob.m_Name );
			}
			else
			{
				return 0;
			}
		}

		#endregion
	}

	#endregion
}