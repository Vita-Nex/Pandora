using System;
using System.Collections;
using Server;
using Server.Items;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Manages building sessions
	/// </summary>
	public class BuilderCore
	{
		private static Hashtable m_UserData;

		static BuilderCore()
		{
			m_UserData = new Hashtable();
		}

		/// <summary>
		/// Builds a structure received from PB
		/// </summary>
		/// <param name="account">The account name for the user requesting the builder</param>
		/// <param name="items">An ArrayList of BuiltItem objects</param>
		/// <param name="map">The map on which the generation occurs</param>
		public static void Build( string account, ArrayList items, Map map )
		{
			ArrayList worldItems = new ArrayList();

			m_UserData[ account ] = worldItems;

			foreach( BuildItem bItem in items )
			{
				Static item = new Static( bItem.ID );
				item.Hue = bItem.Hue;

				item.MoveToWorld( new Point3D( bItem.X, bItem.Y, bItem.Z ), map );

				worldItems.Add( item );
			}
		}

		/// <summary>
		/// Moves the items in the build structure
		/// </summary>
		/// <param name="account">The account name for the build structure</param>
		/// <param name="xOffset">X Offset</param>
		/// <param name="yOffset">Y Offset</param>
		/// <param name="zOffset">Z Offset</param>
		public static void Offset( string account, int xOffset, int yOffset, int zOffset )
		{
			ArrayList items = m_UserData[ account ] as ArrayList;

			if ( items != null )
			{
				foreach ( Item item in items )
				{
					if ( ! item.Deleted )
					{
						item.X += xOffset;
						item.Y += yOffset;
						item.Z += zOffset;
					}
				}
			}
		}

		/// <summary>
		/// Hues all the items in the build structure
		/// </summary>
		/// <param name="account">The account owner of the structure</param>
		/// <param name="hue">The new hue</param>
		public static void Hue( string account, int hue )
		{
			ArrayList items = m_UserData[ account ] as ArrayList;

			if ( items != null )
			{
				foreach( Item item in items )
				{
					if ( !item.Deleted )
					{
						item.Hue = hue;
					}
				}
			}
		}

		/// <summary>
		/// Deletes all the items in the structure
		/// </summary>
		/// <param name="account">The owner of the structure</param>
		public static void Delete( string account )
		{
			ArrayList items = m_UserData[ account ] as ArrayList;

			if ( items != null )
			{
				foreach( Item item in items )
				{
					if ( !item.Deleted )
					{
						item.Delete();
					}
				}
			}

			m_UserData[ account ] = null;
		}
	}
}