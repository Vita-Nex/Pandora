using System;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

using TheBox.MapViewer;
using TheBox.MapViewer.DrawObjects;

using Rilling.Common.UI.Forms;

namespace TheBox.Data
{
	[ Serializable ]
	[ XmlInclude( typeof( SpawnEntry ) ) ]
	public class SpawnData
	{
		public static SpawnData SpawnProvider
		{
			get
			{
				if ( m_SpawnProvider == null )
				{
					m_SpawnProvider = Load();
				}
				return m_SpawnProvider;
			}
		}

		private static SpawnData m_SpawnProvider;

		// If this is set to true, information about the spawns like creatures list, range, and respawn times
		// will be exported. If set to false only location and spawn type will be exported.
		public static bool m_ExportSpawnInfo = true;

		private ArrayList m_Spawns;

		public static bool ExportSpawnInfo
		{
			get { return m_ExportSpawnInfo; }
			set { m_ExportSpawnInfo = value; }
		}

		[ XmlAttribute ]
		public bool Detailed
		{
			get { return m_ExportSpawnInfo; }
			set { m_ExportSpawnInfo = value; }
		}

		public ArrayList Spawns
		{
			get { return m_Spawns; }
			set { m_Spawns = value; }
		}

		public SpawnData()
		{
			m_Spawns = new ArrayList();
		}

		private static SpawnData Load()
		{
			string path = Path.Combine( Pandora.Profile.BaseFolder, "SpawnData.xml" );

			if ( File.Exists( path ) )
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer( typeof( SpawnData ) );
					FileStream stream = new FileStream( path, FileMode.Open, FileAccess.Read, FileShare.Read );
					SpawnData data = serializer.Deserialize( stream ) as SpawnData;
					stream.Close();

					Pandora.Log.WriteEntry( string.Format( "Read spawn data from {0} succesful", path ) );

					return data;
				}
				catch ( Exception err )
				{
					Pandora.Log.WriteError( err, string.Format( "Couldn't read spawn data from {0}", path ) );
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		#region Tool Tips

		private MessageBalloon m_Balloon = null;
		private EventHandler m_HoverHandler;

		/// <summary>
		/// Initializes the system that displays tooltips for
		/// </summary>
		public void DoToolTips( bool display )
		{
			if ( display )
			{
				m_HoverHandler = new EventHandler( Map_MouseHover );
				Pandora.Map.MouseHover += m_HoverHandler;
			}
			else
			{
				if ( m_HoverHandler != null )
				{
					Pandora.Map.MouseHover -= m_HoverHandler;
				}
			}
		}

		/// <summary>
		/// When the mouse hovers display the balooon tool tip
		/// </summary>
		private void Map_MouseHover(object sender, EventArgs e)
		{
			if ( m_Balloon == null )
			{
				System.Drawing.Point location = Pandora.Map.PointToClient( System.Windows.Forms.Control.MousePosition );

				IMapDrawable obj = Pandora.Map.FindDrawObject( location, 5 );

				if ( obj != null && obj is SpawnDrawObject )
				{
					SpawnDrawObject spawn = obj as SpawnDrawObject;

					m_Balloon = MessageBalloon.Show( spawn.Spawn.ToolTipDetailed, Pandora.TextProvider[ "Travel.SpawnDetails" ],
						null,
						MessageBalloonOptions.All,
						MessageBalloon.MousePosition );
					m_Balloon.VisibleChanged += new EventHandler(m_Balloon_VisibleChanged);
				}
			}
		}

		/// <summary>
		/// When the balloon is hidden reset our internal reference to null
		/// </summary>
		private void m_Balloon_VisibleChanged(object sender, EventArgs e)
		{
			if ( !( sender as System.Windows.Forms.Control ).Visible )
			{
				m_Balloon = null;
			}
		}

		#endregion
	}

	public enum SpawnType
	{
		Friendly,
		Aggressive,
		Mixed
	}

	[ Serializable ]
	public class SpawnEntry
	{
		// Always exported
		private SpawnType m_SpawnType;
		private int m_Map;
		private int m_X;
		private int m_Y;
		private int m_Z;

		// Exported only if  ExportSpawnInfo is set to true
		private int m_Team;
		private int m_Count;
		private int m_Range;
		private TimeSpan m_MinDelay;
		private TimeSpan m_MaxDelay;
		private string m_Names;

		#region Properties

		[ XmlAttribute ]
		public SpawnType SpawnType
		{
			get { return m_SpawnType; }
			set { m_SpawnType = value; }
		}

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
				if ( SpawnData.ExportSpawnInfo )
					return m_Count;
				else
					return -1;
			}
			set { m_Count = value; }
		}

		[ XmlAttribute ]
		public int Range
		{
			get
			{
				if ( SpawnData.ExportSpawnInfo )
					return m_Range;
				else
					return -1;
			}
			set { m_Range = value; }
		}

		[ XmlAttribute ]
		public double MinDelay
		{
			get
			{
				if ( SpawnData.ExportSpawnInfo )
					return m_MinDelay.TotalSeconds;
				else
					return -1;
			}
			set { m_MinDelay = TimeSpan.FromSeconds( value ); }
		}

		[ XmlAttribute ]
		public double MaxDelay
		{
			get
			{
				if ( SpawnData.ExportSpawnInfo )
					return m_MaxDelay.TotalSeconds;
				else
					return -1;
			}
			set { m_MaxDelay = TimeSpan.FromSeconds( value ); }
		}

		[ XmlAttribute ]
		public int Team
		{
			get
			{
				if ( SpawnData.ExportSpawnInfo )
					return m_Team;
				else
					return -1;
			}
			set { m_Team = value; }
		}

		[ XmlAttribute ]
		public string CreaturesList
		{
			get
			{
				if ( SpawnData.ExportSpawnInfo )
				{
					return m_Names;
				}

				return null;
			}
			set
			{
				if ( value.Length > 0 )
				{
					m_Names = value.Replace( "|", ", " );
				}
				else
				{
					m_Names = "";
				}
			}
		}

		[ XmlIgnore ]
		public string Names
		{
			get { return m_Names; }
			set { m_Names = value; }
		}

		#endregion

		public SpawnEntry()
		{
		}

		public string ToolTipDetailed
		{
			get
			{
				return 
					string.Format( Pandora.TextProvider[ "Travel.SpawnTipDetailed" ],
					m_SpawnType.ToString(),
					m_Count,
					m_Range,
					m_Team,
					m_MinDelay.Hours, m_MinDelay.Minutes, m_MinDelay.Seconds, m_MaxDelay.Hours, m_MaxDelay.Minutes, m_MaxDelay.Seconds,
					m_Names );
			}
		}
	}
}