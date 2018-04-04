using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

using Server;
using Server.Mobiles;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Provides data about the spawns that can be used to display them on the PB map
	/// </summary>
	[ Serializable ]
	[ XmlInclude( typeof( SpawnEntry ) ) ]
	public class SpawnData
	{
		private ArrayList m_Spawns;

		/// <summary>
		/// Gets or sets the list of spawns
		/// </summary>
		public ArrayList Spawns
		{
			get { return m_Spawns; }
			set { m_Spawns = value; }
		}

		/// <summary>
		/// Creates a new SpawnData object
		/// </summary>
		public SpawnData()
		{
			m_Spawns = new ArrayList();
		}

		/// <summary>
		/// Saves the SpawnData to the TheBox folder
		/// </summary>
		private void Save()
		{
			string filename = System.IO.Path.Combine( BoxUtil.BoxFolder, "SpawnData.xml" );
			BoxUtil.XmlSave( this, filename );
		}

		/// <summary>
		/// Registers the GenSpawnData command
		/// </summary>
		public static void Initialize()
		{
			Server.Commands.Register( "GenSpawnData", AccessLevel.Administrator, new CommandEventHandler( OnGenSpawnData ) );
		}

		/// <summary>
		/// Handler for the GenSpawnData command
		/// </summary>
		private static void OnGenSpawnData( CommandEventArgs e )
		{
			World.Broadcast( BoxConfig.MessageHue, false, "Generating spawn data for Pandora's Box" );

			DateTime start = DateTime.Now;

			SpawnData data = new SpawnData();

			ArrayList Items = new ArrayList( World.Items.Values );

			foreach ( Item item in Items )
			{
				if ( item.GetType() == SpawnerHelper.SpawnerType )
				{
					SpawnEntry entry = SpawnerHelper.SpawnerToData( item );

					if ( entry != null )
						data.m_Spawns.Add( entry );
				}
			}

			data.Save();

			TimeSpan duration = DateTime.Now - start;

			World.Broadcast( BoxConfig.MessageHue, false, string.Format( "Generation complete. The process took {0} seconds", duration.TotalSeconds ) );
		}
	}

	/// <summary>
	/// Defines a spawner for display on the PB map
	/// </summary>
	[ Serializable ]
	public class SpawnEntry
	{
		private int m_Map;
		private int m_X;
		private int m_Y;
		private int m_Z;

		private int m_Team;
		private int m_Count;
		private int m_Range;
		private TimeSpan m_MinDelay;
		private TimeSpan m_MaxDelay;
		private ArrayList m_Names;

		#region Properties

		[ XmlAttribute ]
		public int Map
		{
			get { return m_Map; }
			set { m_Map = value; }
		}

		[ XmlAttribute ]
		public int X
		{
			get { return m_X; }
			set { m_X = value; }
		}

		[ XmlAttribute ]
		public int Y
		{
			get { return m_Y; }
			set { m_Y = value; }
		}

		[ XmlAttribute ]
		public int Z
		{
			get { return m_Z; }
			set { m_Z = value; }
		}

		[ XmlAttribute ]
		public int Count
		{
			get
			{
				return m_Count;
			}
			set { m_Count = value; }
		}

		[ XmlAttribute ]
		public int Range
		{
			get
			{
				return m_Range;
			}
			set { m_Range = value; }
		}

		[ XmlAttribute ]
		public double MinDelay
		{
			get
			{
				return m_MinDelay.TotalSeconds;
			}
			set { m_MinDelay = TimeSpan.FromSeconds( value ); }
		}

		[ XmlAttribute ]
		public double MaxDelay
		{
			get
			{
				return m_MaxDelay.TotalSeconds;
			}
			set { m_MaxDelay = TimeSpan.FromSeconds( value ); }
		}

		[ XmlAttribute ]
		public int Team
		{
			get
			{
				return m_Team;
			}
			set { m_Team = value; }
		}

		[ XmlAttribute ]
		public string CreaturesList
		{
			get
			{
				if ( m_Names.Count > 0 )
				{
					string list = m_Names[ 0 ] as string;

					for ( int i = 1; i < m_Names.Count; i++ )
					{
						list += "|" + m_Names[ i ] as string;
					}

					return list;
				}
				return null;
			}
			set
			{
				if ( value.Length > 0 )
				{
					string[] names = value.Split( new char[] { '|' } );

					m_Names.Clear();
					m_Names.AddRange( names );
				}
			}
		}

		[ XmlIgnore ]
		public ArrayList Names
		{
			get { return m_Names; }
			set { m_Names = value; }
		}

		#endregion

		public SpawnEntry()
		{
			m_Names = new ArrayList();
		}
	}
}