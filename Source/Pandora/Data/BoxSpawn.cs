#region Header
// /*
//  *    2018 - Pandora - BoxSpawn.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	[Serializable, XmlInclude(typeof(BoxSpawnEntry))]
	/// <summary>
	/// Summary description for BoxSpawn.
	/// </summary>
	public class BoxSpawn : IComparable, ICloneable
	{
		private string m_Name;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<BoxSpawnEntry> m_Entries;

		// Issue 10 - End
		private bool m_Group;

		private int m_Count = 1;
		private int m_MinDelay = 5;
		private int m_MaxDelay = 15;
		private int m_HomeRange = 5;
		private int m_Team;
		private string m_Extra = string.Empty;

		public BoxSpawn()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Entries = new List<BoxSpawnEntry>();
			// Issue 10 - End
		}

		[XmlAttribute, Category("Spawn"), Description("The name of this spawn group")]
		public string Name { get { return m_Name; } set { m_Name = value; } }

		[Browsable(false)]
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<BoxSpawnEntry> Entries
			// Issue 10 - End
		{
			get { return m_Entries; }
			set { m_Entries = value; }
		}

		[XmlAttribute, Category("Spawn"),
		 Description("Specifies whether the spawn should respawn creatures only when the total count is zero")]
		public bool Group { get { return m_Group; } set { m_Group = value; } }

		[XmlAttribute, Category("Spawn"), Description("The maximum number of creatures produced by the spawn")]
		public int Count { get { return m_Count; } set { m_Count = value; } }

		[XmlAttribute, Category("Spawn"), Description("Minumum number of minutes before the spawn respawns.")]
		public int MinDelay { get { return m_MinDelay; } set { m_MinDelay = value; } }

		[XmlAttribute, Category("Spawn"), Description("Maximum number of minutes before before the spawn respawns.")]
		public int MaxDelay { get { return m_MaxDelay; } set { m_MaxDelay = value; } }

		[XmlAttribute, Category("Spawn"), Description("The spawning distance.")]
		public int HomeRange { get { return m_HomeRange; } set { m_HomeRange = value; } }

		[XmlAttribute, Category("Spawn"),
		 Description("The Team the mobiles will belong to. Should be set to zero unless specified by the shard admins.")]
		public int Team { get { return m_Team; } set { m_Team = value; } }

		[XmlAttribute, Category("Spawn"),
		 Description("Additional information that can be used to set custom spawner scripts.")]
		public string Extra { get { return m_Extra; } set { m_Extra = value; } }

		#region IComparable Members
		public int CompareTo(object obj)
		{
			var cmp = obj as BoxSpawn;

			if (cmp != null)
			{
				return m_Name.CompareTo(cmp.m_Name);
			}
			return 0;
		}
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			var s = new BoxSpawn();

			s.m_Count = m_Count;
			s.m_Extra = m_Extra;
			s.m_Group = m_Group;
			s.m_HomeRange = m_HomeRange;
			s.m_MaxDelay = m_MaxDelay;
			s.m_MinDelay = m_MinDelay;
			s.m_Name = m_Name;
			s.m_Team = m_Team;

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			s.m_Entries = new List<BoxSpawnEntry>();
			// Issue 10 - End

			foreach (var e in m_Entries)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				s.m_Entries.Add(e.Clone() as BoxSpawnEntry);
				// Issue 10 - End
			}

			return s;
		}
		#endregion
	}

	[Serializable]
	/// <summary>
	/// Defines a single entry in a BoxSpawn
	/// </summary>
	public class BoxSpawnEntry : ICloneable
	{
		private string m_Type;
		private int m_MaxCount = 1;

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Type created through this spawn entry
		/// </summary>
		public string Type { get { return m_Type; } set { m_Type = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the max amount of creatures produced by an XmlSpawner
		/// </summary>
		public int MaxCount { get { return m_MaxCount; } set { m_MaxCount = value; } }

		#region ICloneable Members
		public object Clone()
		{
			var entry = new BoxSpawnEntry();
			entry.m_Type = m_Type;
			entry.m_MaxCount = m_MaxCount;

			return entry;
		}
		#endregion
	}
}