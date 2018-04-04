using System;
using System.Collections;
using System.Xml.Serialization;

using Server;
using Server.Items;
using Server.Targeting;

namespace TheBox.BoxServer
{
	[ Serializable, XmlInclude( typeof( BuildItem ) ) ]
	/// <summary>
	/// Summary description for RandomBrush.
	/// </summary>
	public class RandomBrushMessage : BoxMessage, IAuthenticable
	{
		private ArrayList m_Items;

		/// <summary>
		/// Gets or sets the list of items that will be created
		/// </summary>
		public ArrayList Items
		{
			get { return m_Items; }
			set { m_Items = value; }
		}

		public RandomBrushMessage()
		{
			m_Items = new ArrayList();
		}

		public override BoxMessage Perform()
		{
			Mobile m = Authentication.GetOnlineMobile( this.Username );

			if ( m != null )
			{
				m.Target = new InternalTarget( m_Items );
				m.SendMessage( BoxConfig.MessageHue, "Where do you wish to place the items?" );
			}

			return null;
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

		private class InternalTarget : Target
		{
			private ArrayList m_Items;

			public InternalTarget( ArrayList items ) : base( 30, true, TargetFlags.None )
			{
				m_Items = items;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				IPoint3D p = targeted as IPoint3D;

				if ( p != null )
				{
					foreach( BuildItem bItem in m_Items )
					{
						Static item = new Static( bItem.ID );
						item.Hue = bItem.Hue;
						
						int x = p.X + bItem.X;
						int y = p.Y + bItem.Y;
						
						Map map = from.Map;
						int z = map.Tiles.GetLandTile( x, y ).Z;
						
						item.MoveToWorld( new Point3D( x, y, z ), map );
					}

					from.SendMessage( BoxConfig.MessageHue, "{0} items created.", m_Items.Count );
				}
			}
		}
	}
}
