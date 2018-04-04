using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

using Server;

using TheBox.BoxServer;
using TheBox.Common;

namespace TheBox.Data
{
	[ Serializable, XmlInclude( typeof( BoxProp ) ), XmlInclude( typeof( BoxEnum ) ), XmlInclude( typeof( GenericNode ) ) ]
	/// <summary>
	/// Provides data about props for all mobiles and items
	/// </summary>
	public class PropsData
	{
		private ArrayList m_Structure;
		private ArrayList m_Enums;
		private Hashtable m_Constructables;

		/// <summary>
		/// Gets or sets the structure of the classes tree
		/// </summary>
		public ArrayList Structure
		{
			get { return m_Structure; }
			set { m_Structure = value; }
		}

		/// <summary>
		/// Gets or sets the enumerations used by the propertied
		/// </summary>
		public ArrayList Enums
		{
			get { return m_Enums; }
			set { m_Enums = value; }
		}

		/// <summary>
		/// Creares a new PropsData object
		/// </summary>
		public PropsData()
		{
			m_Structure = new ArrayList();
			m_Enums = new ArrayList();
			m_Constructables = new Hashtable();
		}

		/// <summary>
		/// Registers the GenPropsData command
		/// </summary>
		public static void Initialize()
		{
			Server.Commands.Register( "GenPropsData", AccessLevel.Administrator, new CommandEventHandler( OnPropsData ) );
		}

		/// <summary>
		/// Callback for the GenPropsData command
		/// </summary>
		/// <param name="e"></param>
		private static void OnPropsData( CommandEventArgs e )
		{
			DateTime start = DateTime.Now;
			DateTime end;
			TimeSpan duration;

			World.Broadcast( BoxConfig.MessageHue, false, "Pandora's Box is collecting property data. Please wait..." );
			PropsData p = new PropsData();

			p.CreateMasterTable();
			p.CreateStructure();
			p.Save();

			end = DateTime.Now;
			duration = end - start;
			World.Broadcast( BoxConfig.MessageHue, false, "Generation complete. The process took {0} seconds.", duration.TotalSeconds );
		}

		/// <summary>
		/// Saves the PropsData to an xml file in the RunUO\TheBox folder
		/// </summary>
		public void Save()
		{
			string file = Path.Combine( BoxUtil.BoxFolder, "PropsData.xml" );
			BoxUtil.XmlSave( this, file );
		}

		/// <summary>
		/// Creates the classes structure
		/// </summary>
		private void CreateStructure()
		{
			GenericNode items = new GenericNode( "Item" );
			GenericNode mobiles = new GenericNode( "Mobile" );

			items.Elements.AddRange( m_Constructables[ "Item" ] as ArrayList );
			mobiles.Elements.AddRange( m_Constructables[ "Mobile" ] as ArrayList );

			m_Constructables.Remove( "Item" );
			m_Constructables.Remove( "Mobile" );

			FindSubTypes( "Item", items );
			FindSubTypes( "Mobile", mobiles );

			m_Structure.Add( items );
			m_Structure.Add( mobiles );
		}

		/// <summary>
		/// Loads a PropsData object from an xml file
		/// </summary>
		/// <param name="file">The xml file containing the PropsData object</param>
		/// <returns>The loaded PropsData</returns>
		public static PropsData Load( string file )
		{
			return BoxUtil.XmlLoad( file, typeof( PropsData ) ) as PropsData;
		}

		/// <summary>
		/// Finds the subtypes for a given type
		/// </summary>
		/// <param name="type">The type to search for subtypes</param>
		/// <param name="parent">The parent node that will hold the subtypes</param>
		private void FindSubTypes( string type, GenericNode parent )
		{
			GenericNode sType = new GenericNode( type );

			ArrayList list = m_Constructables[ type ] as ArrayList;
			m_Constructables.Remove( type );

			if ( list != null && list.Count > 0 )
			{
				parent.Elements.AddRange( list );
			}

			ArrayList subTypes = GetSubTypes( type );

			foreach ( string sub in subTypes )
			{
				GenericNode node = new GenericNode( sub );
				FindSubTypes( sub, node );

				parent.Elements.Add( node );
			}
		}

		/// <summary>
		/// Gets the subtypes for a given type
		/// </summary>
		/// <param name="type">The type to search for subtypes</param>
		/// <returns>An ArrayList of Type objects</returns>
		private ArrayList GetSubTypes( string type )
		{
			Type parent = ScriptCompiler.FindTypeByName( type, false );
			
			ArrayList list = new ArrayList();

			foreach ( string s in m_Constructables.Keys )
			{
				Type t = ScriptCompiler.FindTypeByName( s, false );

				if ( t.BaseType == parent )
				{
					list.Add( s );
				}
			}

			return list;
		}

		/// <summary>
		/// Creates the types master list
		/// </summary>
		private void CreateMasterTable()
		{
			ArrayList types = BoxDataGenerator.LoadTypes();

			foreach ( Type t in types )
			{
				ProcessType( t );
			}
		}

		/// <summary>
		/// Processes a type and collects information about its properties
		/// </summary>
		/// <param name="t">The Type to examine</param>
		private void ProcessType( Type t )
		{
			ArrayList list = new ArrayList();

			if ( ( BoxUtil.IsItem( t ) || BoxUtil.IsMobile( t ) ) )
			{
				PropertyInfo[] props = t.GetProperties( BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly );

				if ( props.Length > 0 )
				{
					foreach( PropertyInfo info in props )
					{
						BoxProp p = BoxProp.FromPropertyInfo( info );

						if ( p != null )
						{
							list.Add( p );

							if ( p.ValueType == BoxPropType.Enumeration )
							{
								if ( !EnumListed( p.EnumName ) )
								{
									BoxEnum e = BoxEnum.FromPropertyInfo( info );
									m_Enums.Add( e );
								}
							}
						}
					}
				}
			}

			if ( list.Count > 0 )
			{
				m_Constructables[ t.Name ] = list;
			}
			else
			{
				m_Constructables[ t.Name ] = null;
			}
		}

		/// <summary>
		/// Verifies if a given enumeration has already been recorded
		/// </summary>
		/// <param name="name">The enumeration name</param>
		/// <returns>True if the enumeration has been already collected</returns>
		private bool EnumListed( string name )
		{
			foreach ( BoxEnum e in m_Enums )
			{
				if ( e.Name == name )
				{
					return true;
				}
			}

			return false;
		}
	}

	/// <summary>
	/// Defines the type of the value of a property
	/// </summary>
	public enum BoxPropType
	{
		Boolean,
		Numeric,
		Text,
		TimeSpan,
		DateTime,
		Enumeration,
		Point3D,
		Map,
		Other
	}

	/// <summary>
	/// Defines a command property
	/// </summary>
	public class BoxProp
	{
		private string m_Name;
		private AccessLevel m_GetAccess;
		private AccessLevel m_SetAccess;
		private bool m_CanGet;
		private bool m_CanSet;
		private BoxPropType m_ValueType;
		private string m_EnumName;

		/// <summary>
		/// Gets or sets the property name
		/// </summary>
		[ XmlAttribute ]
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the AccessLevel needed to get the property
		/// </summary>
		[ XmlAttribute ]
		public AccessLevel GetAccess
		{
			get { return m_GetAccess; }
			set { m_GetAccess = value; }
		}

		/// <summary>
		/// Gets or sets the AccessLevel needed to set the property
		/// </summary>
		[ XmlAttribute ]
		public AccessLevel SetAccess
		{
			get { return m_SetAccess; }
			set { m_SetAccess = value; }
		}

		/// <summary>
		/// States whether the property has the get method
		/// </summary>
		[ XmlAttribute ]
		public bool CanGet
		{
			get { return m_CanGet; }
			set { m_CanGet = value; }
		}

		/// <summary>
		/// States whether the property has the set method
		/// </summary>
		[ XmlAttribute ]
		public bool CanSet
		{
			get { return m_CanSet; }
			set { m_CanSet = value; }
		}

		/// <summary>
		/// Gets or sets the type of the value of the property
		/// </summary>
		[ XmlAttribute ]
		public BoxPropType ValueType
		{
			get { return m_ValueType; }
			set { m_ValueType = value; }
		}

		/// <summary>
		/// Gets or sets the name of the enumeration used by the value of the property (if appliable)
		/// </summary>
		[ XmlAttribute ]
		public string EnumName
		{
			get { return m_EnumName; }
			set { m_EnumName = value; }
		}

		/// <summary>
		/// Creates a new BoxProp object
		/// </summary>
		public BoxProp()
		{
		}

		/// <summary>
		/// Creates a BoxProp object from a PropertyInfo
		/// </summary>
		/// <param name="info">The PropertyInfo used to extract the BoxProp object</param>
		/// <returns>The extracted BoxProp object</returns>
		public static BoxProp FromPropertyInfo( PropertyInfo info )
		{
			object[] cpa = info.GetCustomAttributes( typeof( CommandPropertyAttribute ), false );

			if ( cpa.Length > 0 )
			{
				BoxProp prop = new BoxProp();

				prop.Name = info.Name;
				prop.CanGet = info.CanRead;
				prop.CanSet = info.CanWrite;

				CommandPropertyAttribute attr = cpa[ 0 ] as CommandPropertyAttribute;

				prop.GetAccess = attr.ReadLevel;
				prop.SetAccess = attr.WriteLevel;

				if ( prop.SetAccess.ToString() == "5" ) // Weird access level on Account property
				{
					prop.SetAccess = AccessLevel.Administrator;
					prop.CanSet = false;
				}

				prop.ValueType = GetPropType( info.PropertyType );

				if ( prop.ValueType == BoxPropType.Enumeration )
				{
					prop.EnumName = info.PropertyType.Name;
				}
				
				return prop;
			}

			return null;
		}

		/// <summary>
		/// The list of types that represent numeric values
		/// </summary>
		private static Type[] m_NumericTypes = 
			{
				typeof( long ), typeof( ulong ), typeof( int ), typeof( uint ), typeof( short ), typeof( ushort ), typeof( byte ), typeof( sbyte ), typeof( float ), typeof( double ), typeof( decimal )
			};

		/// <summary>
		/// Gets the BoxPropType enumeration for a given type
		/// </summary>
		/// <param name="t">The Type to convert</param>
		/// <returns>The corresponding BoxPropType</returns>
		public static BoxPropType GetPropType( Type t )
		{
			foreach ( Type n in m_NumericTypes )
			{
				if ( n == t )
				{
					return BoxPropType.Numeric;
				}
			}

			if ( t == typeof( bool ) )
			{
				return BoxPropType.Boolean;
			}
			else if ( t == typeof( string ) )
			{
				return BoxPropType.Text;
			}
			else if ( t == typeof( TimeSpan ) )
			{
				return BoxPropType.TimeSpan;
			}
			else if ( t == typeof( DateTime ) )
			{
				return BoxPropType.DateTime;
			}
			else if ( t == typeof( Point3D ) )
			{
				return BoxPropType.Point3D;
			}
			else if ( typeof( Enum ).IsAssignableFrom( t ) )
			{
				return BoxPropType.Enumeration;
			}
			else if ( t == typeof( Server.Map ) )
			{
				return BoxPropType.Map;
			}
			else
			{
				return BoxPropType.Other;
			}
		}
	}

	/// <summary>
	/// Defines an enumeration used on the server
	/// </summary>
	public class BoxEnum
	{
		private string m_Name;
		private ArrayList m_Values;

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the name of the enum
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the possible values for this enum
		/// </summary>
		public ArrayList Values
		{
			get { return m_Values; }
			set { m_Values = value; }
		}

		/// <summary>
		/// Creates a new BoxEnum object
		/// </summary>
		public BoxEnum()
		{
			m_Values = new ArrayList();
		}

		public static BoxEnum FromPropertyInfo( PropertyInfo info )
		{
			BoxEnum e = new BoxEnum();

			e.Name = info.PropertyType.Name;
			e.Values.AddRange( Enum.GetNames( info.PropertyType ) );

			return e;
		}
	}
}
