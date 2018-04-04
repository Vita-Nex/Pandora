using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Xml.Serialization

using Server;

namespace TheBox.Data
{
	[ Serializable ]
	/// <summary>
	/// Defines the art and hue of an item
	/// </summary>
	public class ItemDef : ICloneable
	{
		private int m_Art = 0;
		private int m_Hue = 0;

		/// <summary>
		/// Creates a new ItemAppearance object
		/// </summary>
		public ItemDef()
		{
		}

		/// <summary>
		/// Creates a new ItemAppearance object
		/// </summary>
		/// <param name="art">The ID of the art corresponding to the item</param>
		/// <param name="hue">The hue of the item</param>
		public ItemDef( int art, int hue )
		{
			m_Art = art;
			m_Hue = hue;
		}

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the item ID
		/// </summary>
		public int Art
		{
			get { return m_Art; }
			set { m_Art = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the hue
			/// </summary>
		public int Hue
		{
			get { return m_Hue; }
			set { m_Hue = value; }
		}

		/// <summary>
		/// Collects appearance data of an item using a specific constructor and parameters list
		/// </summary>
		/// <param name="type">The Type that's being instantiated</param>
		/// <param name="parameters">An array of parameters</param>
		/// <returns>An ItemDef object describing the item created, null in case of failure</returns>
		public static ItemDef GetItemDef( Type type, params object[] parameters )
		{
			ItemDef def = null;

			try
			{
				Item item = Activator.CreateInstance( type, parameters ) as Item;

				if ( item != null )
				{
					def = new ItemDef( item.ItemID, item.Hue );
					item.Internalize();
					item.Delete();
				}
			}
			catch {}

			return def;
		}

		#region ICloneable Members

		/// <summary>
		/// Clones this ItemDef object
		/// </summary>
		/// <returns>A new ItemDef object with the same values</returns>
		public object Clone()
		{
			return new ItemDef( this.m_Art, this.m_Hue );
		}

		#endregion
	}

	[ Serializable ]
	/// <summary>
	/// Defines a parameter used in an additional constructor
	/// </summary>
	public class ParamDef
	{
		private string m_Name;
		private BoxPropType m_ParamType;
		private ArrayList m_EnumValues;

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the parameter name
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the type of this parameter
		/// </summary>
		public BoxPropType ParamType
		{
			get { return m_ParamType; }
			set { m_ParamType = value; }
		}

		/// <summary>
		/// Gets or sets the list of values for an enum parameter
		/// </summary>
		public ArrayList EnumValues
		{
			get { return m_EnumValues; }
			set { m_EnumValues = value; }
		}

		/// <summary>
		/// Creates a new ParamDef object
		/// </summary>
		public ParamDef()
		{
		}

		/// <summary>
		/// Extracts a ParamDef object from a ParameterInfo
		/// </summary>
		/// <param name="pInfo">The ParameterInfo object containing information about a constructor parameter</param>
		/// <returns>A ParamDef object</returns>
		public static ParamDef FromParameterInfo( ParameterInfo pInfo )
		{
			ParamDef def = new ParamDef();

			def.m_Name = pInfo.Name;
			def.m_ParamType = BoxProp.GetPropType( pInfo.ParameterType );

			if ( pInfo.ParameterType.IsEnum )
			{
				def.m_EnumValues = new ArrayList();
				def.m_EnumValues.AddRange( Enum.GetNames( pInfo.ParameterType ) );
			}

			return def;
		}
	}

	[ Serializable, XmlInclude( typeof( ParamDef ) ) ]
	/// <summary>
	/// Defines an additional constructor available for an item
	/// </summary>
	public class ConstructorDef
	{
		private ItemDef m_DefaultArt;
		private ParamDef m_Param1;
		private ParamDef m_Param2;
		private ArrayList m_List1;
		private ArrayList m_List2;

		/// <summary>
		/// Gets or sets the appearance of the item created by the constructor with default parameters
		/// </summary>
		public ItemDef DefaultArt
		{
			get { return m_DefaultArt; }
			set { m_DefaultArt = value; }
		}

		/// <summary>
		/// Gets or sets the first parameter of the constructor
		/// </summary>
		public ParamDef Param1
		{
			get { return m_Param1; }
			set { m_Param1 = value; }
		}

		/// <summary>
		/// Gets or sets the second parameter of the constructor (if any)
		/// </summary>
		public ParamDef Param2
		{
			get { return m_Param2; }
			set { m_Param2 = value; }
		}

		/// <summary>
		/// Gets or sets the list of item definitions corresponding to the first parameter (if appliable)
		/// </summary>
		public ArrayList List1
		{
			get { return m_List1; }
			set { m_List1 = value; }
		}

		/// <summary>
		/// Gets or sets the list of item definitions for the second parameter (if appliable)
		/// </summary>
		public ArrayList List2
		{
			get { return m_List2; }
			set { m_List2 = value; }
		}

		/// <summary>
		/// Creates a new constructor definition
		/// </summary>
		public ConstructorDef()
		{
		}

		/// <summary>
		/// Extracts a ConstructorDef from a ConstructorInfo. Assumes the constructor has at least one and not more than two parameters.
		/// </summary>
		/// <param name="info">The ConstructorInfo object to evaluate</param>
		/// <returns>A ConsturctorDef object defining the constructor in PB</returns>
		public static ConstructorDef FromConstructorInfo( ConstructorInfo ctor )
		{
			ConstructorDef def = new ConstructorDef();

			ParameterInfo[] parameters = ctor.GetParameters();

			def.m_Param1 = ParamDef.FromParameterInfo( parameters[ 0 ] );

			if ( parameters.Length > 1 )
			{
				def.m_Param2 = ParamDef.FromParameterInfo( parameters[ 1 ] );
			}

			// Get the default appearance for this constructor
			object def1 = null;
			object def2 = null;

			try
			{
				def1 = Activator.CreateInstance( parameters[ 0 ].ParameterType );

				if ( parameters.Length > 1 )
				{
					def2 = Activator.CreateInstance( parameters[ 1 ].ParameterType );
					def.m_DefaultArt = ItemDef.GetItemDef( ctor.DeclaringType, def1, def2 );
				}
				else
				{
					def.m_DefaultArt = ItemDef.GetItemDef( ctor.DeclaringType, def1 );
				}
			}
			catch
			{
				def.m_DefaultArt = null;
			}

			// Collect enum data if needed

			if ( def.m_Param1.ParamType == BoxPropType.Enumeration )
			{
				object default2 = null;
				def.m_List1 = new ArrayList();
				bool requireSecondParam = false;

				if ( def.m_Param2 != null )
				{
					requireSecondParam = true;

					try
					{
						default2 = Activator.CreateInstance( parameters[ 1 ].ParameterType );
					}
					catch
					{
						default2 = null;
					}
				}

				if ( !requireSecondParam || default2 != null )
				{
					foreach ( object obj in Enum.GetValues( parameters[ 0 ].ParameterType ) )
					{
						if ( default2 != null )
						{
							def.m_List1.Add( ItemDef.GetItemDef( ctor.DeclaringType, obj, default2 ) );
						}
						else
						{
							def.m_List1.Add( ItemDef.GetItemDef( ctor.DeclaringType, obj ) );
						}
					}
				}
			}

			// Check param 2
			if ( def.m_Param2 != null && def.m_Param2.ParamType == BoxPropType.Enumeration )
			{
				// Collect information on enumeration for parameter1
				object default1 = null;

				try
				{
					default1 = Activator.CreateInstance( parameters[ 0 ].ParameterType );
				}
				catch
				{
					default1 = null;
				}

				if ( default1 != null )
				{
					def.m_List2 = new ArrayList();

					foreach ( object obj in Enum.GetValues( parameters[ 1 ].ParameterType ) )
					{
						def.m_List2.Add( ItemDef.GetItemDef( ctor.DeclaringType, default1, obj ) );
					}
				}
			}

			return def;
		}
	}

	[ Serializable, XmlInclude( typeof( ConstructorDef ) ) ]
	/// <summary>
	/// Defines an item that can be added through Pandora's Box
	/// </summary>
	public class BoxItem : IComparable
	{
		private bool m_EmptyCtor = false;
		private ItemDef m_Item;
		private string m_Name;
		private ArrayList m_AdditionalCtors;

		private StringCollection m_Path;

		[ XmlAttribute ]
		/// <summary>
		/// Get or sets the name of the item
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		[ XmlAttribute ]
		/// <summary>
		/// States whether the item has a default constructor
		/// </summary>
		public bool EmptyCtor
		{
			get { return m_EmptyCtor; }
			set { m_EmptyCtor = value; }
		}

		/// <summary>
		/// Gets or sets the appearance of the item
		/// </summary>
		public ItemDef Item
		{
			get { return m_Item; }
			set { m_Item = value; }
		}

		/// <summary>
		/// Lists the additional constructors available for this item
		/// </summary>
		public ArrayList AdditionalCtors
		{
			get { return m_AdditionalCtors; }
			set { m_AdditionalCtors = value; }
		}

		/// <summary>
		/// Sets the filename of the file that holds this item
		/// </summary>
		[ XmlIgnore ]
		public string FileName
		{
			set
			{
				if ( m_Path == null )
				{
					m_Path = new StringCollection();
				}

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
		[ XmlIgnore ]
		public StringCollection Path
		{
			get
			{
				return m_Path;
			}
		}

		/// <summary>
		/// Creates a new BoxItem object
		/// </summary>
		public BoxItem()
		{
			m_Item = new ItemDef();
		}

		/// <summary>
		/// Creates a BoxItem definition from a type
		/// </summary>
		/// <param name="type">The type that will be analyzed</param>
		/// <returns>The corresponding BoxItem object, null if the object can't be constructed</returns>
		public static BoxItem FromType( Type type )
		{
			BoxItem item = new BoxItem();
			ConstructorInfo[] ctors = type.GetConstructors();

			item.m_Name = type.Name;

			foreach ( ConstructorInfo ctor in ctors )
			{
				if ( BoxUtil.IsConstructable( ctor ) )
				{
					int NumOfParams = ctor.GetParameters().Length;

					if ( NumOfParams == 0 )
					{
						item.m_EmptyCtor = true;
						item.m_Item = ItemDef.GetItemDef( type );
					}
					else if ( NumOfParams <= 2 )
					{
						if ( item.m_AdditionalCtors == null )
						{
							item.m_AdditionalCtors = new ArrayList();
						}

						item.m_AdditionalCtors.Add( ConstructorDef.FromConstructorInfo( ctor ) );
					}
				}
			}

			if ( item.m_EmptyCtor || item.m_AdditionalCtors != null )
			{
				// If there's no default constructor, try to get the ItemDef from the additional constructors
				if ( ! item.m_EmptyCtor )
				{
					// Get the first available def
					foreach ( ConstructorDef cDef in item.m_AdditionalCtors )
					{
						if ( cDef.DefaultArt != null )
						{
							item.m_Item = cDef.DefaultArt.Clone() as ItemDef;
							break;
						}
					}
				}

				return item;
			}
			else
			{
				return null;
			}
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if ( obj is BoxItem )
			{
				BoxItem item = obj as BoxItem;

				return m_Name.CompareTo( item.m_Name );
			}
			else
			{
				return 0;
			}
		}

		#endregion
	}
}