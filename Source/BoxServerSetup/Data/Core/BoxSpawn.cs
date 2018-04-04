using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TheBox.Data
{
	[ Serializable, XmlInclude( typeof( BoxSpawnEntry ) ) ]
	/// <summary>
	/// Describes a spawn group created in Pandora's Box
	/// </summary>
	public class BoxSpawn : IComparable, ICloneable
	{
		private string m_Name;
		private ArrayList m_Entries;
		private bool m_Group = false;
		private int m_Count = 1;
		private int m_MinDelay = 5;
		private int m_MaxDelay = 15;
		private int m_HomeRange = 5;
		private int m_Team = 0;
		private string m_Extra = string.Empty;

		public BoxSpawn()
		{
			m_Entries = new ArrayList();
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "The name of this spawn group" ) ]
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		[ Browsable( false ) ]
		public ArrayList Entries
		{
			get { return m_Entries; }
			set { m_Entries = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "Specifies whether the spawn should respawn creatures only when the total count is zero" ) ]
		public bool Group
		{
			get { return m_Group; }
			set { m_Group = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "The maximum number of creatures produced by the spawn" ) ]
		public int Count
		{
			get { return m_Count; }
			set { m_Count = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "Minumum number of minutes before the spawn respawns." ) ]
		public int MinDelay
		{
			get { return m_MinDelay; }
			set { m_MinDelay = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "Maximum number of minutes before before the spawn respawns." ) ]
		public int MaxDelay
		{
			get { return m_MaxDelay; }
			set { m_MaxDelay = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "The spawning distance." ) ]
		public int HomeRange
		{
			get { return m_HomeRange; }
			set { m_HomeRange = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "The Team the mobiles will belong to. Should be set to zero unless specified by the shard admins." ) ]
		public int Team
		{
			get { return m_Team; }
			set { m_Team = value; }
		}

		[ XmlAttribute, Category( "Spawn" ), Description( "Additional information that can be used to set custom spawner scripts." ) ]
		public string Extra
		{
			get { return m_Extra; }
			set { m_Extra = value; }
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			BoxSpawn cmp = obj as BoxSpawn;

			if ( cmp != null )
			{
				return m_Name.CompareTo( cmp.m_Name );
			}
			else
			{
				return 0;
			}
		}

		#endregion

		#region ICloneable Members

		public object Clone()
		{
			BoxSpawn s = new BoxSpawn();

			s.m_Count = this.m_Count;
			s.m_Extra = this.m_Extra;
			s.m_Group = this.m_Group;
			s.m_HomeRange = this.m_HomeRange;
			s.m_MaxDelay = this.m_MaxDelay;
			s.m_MinDelay = this.m_MinDelay;
			s.m_Name = this.m_Name;
			s.m_Team = this.m_Team;

			s.m_Entries = new ArrayList();

			foreach ( BoxSpawnEntry e in this.m_Entries )
			{
				s.m_Entries.Add( e.Clone() );
			}

			return s;
		}

		#endregion
	}

	[ Serializable ]
	/// <summary>
	/// Defines a single entry in a BoxSpawn
	/// </summary>
	public class BoxSpawnEntry : ICloneable
	{
		private string m_Type;
		private int m_MaxCount = 1;

		/// <summary>
		/// Creates a new BoxSpawnEntry object
		/// </summary>
		public BoxSpawnEntry()
		{
		}

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the Type created through this spawn entry
		/// </summary>
		public string Type
		{
			get { return m_Type; }
			set { m_Type = value; }
		}

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the max amount of creatures produced by an XmlSpawner
		/// </summary>
		public int MaxCount
		{
			get { return m_MaxCount; }
			set { m_MaxCount = value; }
		}

		#region ICloneable Members

		public object Clone()
		{
			BoxSpawnEntry entry = new BoxSpawnEntry();
			entry.m_Type = this.m_Type;
			entry.m_MaxCount = this.m_MaxCount;

			return entry;
		}

		#endregion
	}
}
