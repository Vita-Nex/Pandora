using System;
using System.Xml.Serialization;
using Server;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Deletes all the items in the build structure
	/// </summary>
	public class BuilderDeleteMessage : BoxMessage, IAuthenticable
	{
		public BuilderDeleteMessage()
		{
		}

		public override BoxMessage Perform()
		{
			BuilderCore.Delete( Username );
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
	}

	[ Serializable ]
	/// <summary>
	/// Hues all the items in the build structure
	/// </summary>
	public class HueMessage : BoxMessage, IAuthenticable
	{
		private int m_Hue;

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the new hue for the items
		/// </summary>
		public int Hue
		{
			get { return m_Hue; }
			set { m_Hue = value; }
		}

		public HueMessage()
		{
		}

		public HueMessage( int hue )
		{
			m_Hue = hue;
		}

		public override BoxMessage Perform()
		{
			BuilderCore.Hue( Username, m_Hue );
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
	}

	[ Serializable ]
	/// <summary>
	/// Moves the items in the structure
	/// </summary>
	public class OffsetMessage : BoxMessage, IAuthenticable
	{
		private int m_X;
		private int m_Y;
		private int m_Z;

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the X offset
		/// </summary>
		public int XOffset
		{
			get { return m_X; }
			set { m_X = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the Y offset
			/// </summary>
		public int YOffset
		{
			get { return m_Y; }
			set { m_Y = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the Z offset
			/// </summary>
		public int ZOffset
		{
			get { return m_Z; }
			set { m_Z = value; }
		}

		public OffsetMessage()
		{
		}

		public OffsetMessage( int xOffset, int yOffset, int zOffset )
		{
			m_X = xOffset;
			m_Y = yOffset;
			m_Z = zOffset;
		}

		public override BoxMessage Perform()
		{
			BuilderCore.Offset( Username, m_X, m_Y, m_Z );
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
	}
}