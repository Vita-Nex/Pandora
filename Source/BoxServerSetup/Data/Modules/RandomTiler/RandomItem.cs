using System;
using System.Collections;
using System.Xml.Serialization;
using TheBox.Data;
using Server;
using Server.Targeting;

namespace TheBox.BoxServer
{
	[ Serializable, XmlInclude( typeof( RandomTile ) ) ]
	/// <summary>
	/// Allows the user to click multiple times and add a different item each time
	/// </summary>
	public class RandomItem : BoxMessage, IAuthenticable
	{
		private ArrayList m_Hues;
		private ArrayList m_Items;

		/// <summary>
		/// Gets or sets the list of hues to be used for the tiled items
		/// </summary>
		public ArrayList Hues
		{
			get { return m_Hues; }
			set { m_Hues = value; }
		}

		/// <summary>
		/// Gets or sets the list of items that can be randomly picked
		/// </summary>
		public ArrayList Items
		{
			get { return m_Items; }
			set { m_Items = value; }
		}

		public RandomItem()
		{
			m_Hues = new ArrayList();
			m_Items = new ArrayList();
		}

		public override BoxMessage Perform()
		{
			Mobile m = Authentication.GetOnlineMobile( this.Username );

			if ( m != null )
			{
				m.SendMessage( BoxConfig.MessageHue, "Starting random items creation session. Please target the locations where you wish to add the items." );
				m.Target = new InternalTarget( m_Items, m_Hues );
			}

			return null;
		}	

		private class InternalTarget : Target
		{
			private ArrayList m_Items;
			private ArrayList m_Hues;

			public InternalTarget( ArrayList items, ArrayList hues ) : base ( 30, true, TargetFlags.None )
			{
				m_Items = items;
				m_Hues = hues;				
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				IPoint3D point = targeted as IPoint3D;

				if ( point != null )
				{
					ArrayList items = RandomItems;

					foreach( Item item in items )
					{
						item.MoveToWorld( new Point3D( point ), from.Map );
					}

					from.SendMessage( BoxConfig.MessageHue, "{0} items have been created.", items.Count );
				}
				
				from.Target = new InternalTarget( m_Items, m_Hues );
			}

			/// <summary>
			/// Generates the random items that should be placed on target
			/// </summary>
			private ArrayList RandomItems
			{
				get
				{
					ArrayList items = new ArrayList();
					Random rnd = new Random();

					RandomTile tile = m_Items[ rnd.Next( m_Items.Count ) ] as RandomTile;
					int hue = (int) m_Hues[ rnd.Next( m_Hues.Count ) ];

					foreach( int id in tile.Items )
					{
						Item item = new Server.Items.Static( id );
						item.Movable = false;
						item.Hue = hue;

						items.Add( item );
					}

					return items;
				}
			}

		}


		#region IAuthenticable Members

		public Server.AccessLevel MinAccessLevel
		{
			get
			{
				return AccessLevel.GameMaster;
			}
		}

		public bool RequireOnlineMobile
		{
			get
			{
				return true;
			}
		}

		#endregion
	}
}
