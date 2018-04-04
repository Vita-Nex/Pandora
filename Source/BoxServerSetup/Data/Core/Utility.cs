using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

using Server;

namespace TheBox
{
	/// <summary>
	/// Provides general purpose methods for BoxServer
	/// </summary>
	public class BoxUtil
	{
		/// <summary>
		/// Gets the RunUO folder
		/// </summary>
		public static string RunUOFolder
		{
			get
			{
				return Path.GetDirectoryName( Environment.GetCommandLineArgs()[ 0 ] );
			}
		}

		/// <summary>
		/// Gets the base scripts folder
		/// </summary>
		public static string ScriptsFolder
		{
			get
			{
				return Path.Combine( RunUOFolder, "Scripts" );
			}
		}

		/// <summary>
		/// Gets the ..RunUO\TheBox\ folder
		/// </summary>
		public static string BoxFolder
		{
			get
			{
				string box =  Path.Combine( RunUOFolder, "TheBox" );

				if ( ! Directory.Exists( box ) )
					Directory.CreateDirectory( box );

				return box;
			}
		}

		/// <summary>
		/// Verifies is a constructor is defined as [Constructable]
		/// </summary>
		/// <param name="ctor">The constructor info to evaluate</param>
		/// <returns>True if the constructor is constructable</returns>
		public static bool IsConstructable( ConstructorInfo ctor )
		{
			return ctor.IsDefined( typeof( ConstructableAttribute ), false );
		}

		/// <summary>
		/// Verifies if a type has a [Constructable] constructor
		/// </summary>
		/// <param name="t">The type to evaluate</param>
		/// <returns>True if the type is constructable</returns>
		public static bool IsConstructable( Type t )
		{
			ConstructorInfo[] ctors = t.GetConstructors();

			foreach ( ConstructorInfo c in ctors )
			{
				if ( IsConstructable( c ) )
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Verifies if a type is derived from Item
		/// </summary>
		/// <param name="t">The type to evaluate</param>
		/// <returns>True if the type is derived from Item</returns>
		public static bool IsItem( Type t )
		{
			return typeof( Item ).IsAssignableFrom( t );
		}

		/// <summary>
		/// Verifies if a type is derived from Mobile
		/// </summary>
		/// <param name="t">The type to evaluate</param>
		/// <returns>True if the type is derived from Mobile</returns>
		public static bool IsMobile( Type t )
		{
			return typeof( Mobile ).IsAssignableFrom( t );
		}

		/// <summary>
		/// Makes sure a folder exists, and if it doesn't it creates it
		/// </summary>
		/// <param name="folder">The folder to ensure</param>
		public static void EnsureFolder( string folder )
		{
			if ( !Directory.Exists( folder ) )
			{
				Directory.CreateDirectory( folder );
			}
		}

		/// <summary>
		/// Serializes an object to a XML file
		/// </summary>
		/// <param name="obj">The serializable object</param>
		/// <param name="filename">The filename to save to</param>
		/// <returns>True if the save is succesful</returns>
		public static bool XmlSave( object obj, string filename )
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer( obj.GetType() );
				FileStream stream = new FileStream( filename, FileMode.Create, FileAccess.Write, FileShare.None );
				serializer.Serialize( stream, obj );
				stream.Close();

				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Deserializes an object from a XML file
		/// </summary>
		/// <param name="filename">The path to the filename</param>
		/// <param name="type">The Type of the object that's being loaded</param>
		/// <returns>The loaded object, null if the file is not found or an error occurs</returns>
		public static object XmlLoad( string filename, Type type )
		{
			if ( File.Exists( filename ) )
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer( type );
					FileStream stream = new FileStream( filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
					object obj = serializer.Deserialize( stream );
					stream.Close();

					return obj;
				}
				catch {}
			}

			return null;
		}
	}
}
