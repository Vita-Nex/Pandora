#region Header
// /*
//  *    2018 - Pandora - SpawnData.cs
//  */
#endregion

#region References
using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

using TheBox.MapViewer.DrawObjects;
#endregion

namespace TheBox.Data
{
	[Serializable]
	[XmlInclude(typeof(SpawnEntry))]
	public class SpawnData
	{
		/// <summary>
		///     Gets or sets the SpawnData object used to display spawns on the map
		/// </summary>
		public static SpawnData SpawnProvider
		{
			get
			{
				if (m_SpawnProvider == null)
				{
					m_SpawnProvider = Load();
				}
				return m_SpawnProvider;
			}
			set
			{
				m_SpawnProvider = value;
				m_SpawnProvider.RefreshSpawns();
				m_SpawnProvider.Save();
			}
		}

		private static SpawnData m_SpawnProvider;

		// If this is set to true, information about the spawns like creatures list, range, and respawn times
		// will be exported. If set to false only location and spawn type will be exported.
		public static bool m_ExportSpawnInfo = true;

		private ArrayList m_Spawns;

		public static bool ExportSpawnInfo { get => m_ExportSpawnInfo; set => m_ExportSpawnInfo = value; }

		[XmlAttribute]
		public bool Detailed { get => m_ExportSpawnInfo; set => m_ExportSpawnInfo = value; }

		public ArrayList Spawns { get => m_Spawns; set => m_Spawns = value; }

		public SpawnData()
		{
			m_Spawns = new ArrayList();
		}

		/// <summary>
		///     Loads a SpawnData from file
		/// </summary>
		/// <returns>The loaded SpawnData object</returns>
		private static SpawnData Load()
		{
			var path = Path.Combine(Pandora.Profile.BaseFolder, "SpawnData.xml");

			if (File.Exists(path))
			{
				try
				{
					var serializer = new XmlSerializer(typeof(SpawnData));
					var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
					var data = serializer.Deserialize(stream) as SpawnData;
					stream.Close();

					Pandora.Log.WriteEntry(String.Format("Read spawn data from {0} succesful", path));

					return data;
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, String.Format("Couldn't read spawn data from {0}", path));
					return null;
				}
			}
			return null;
		}

		/// <summary>
		///     Saves the spawn data to file
		/// </summary>
		public void Save()
		{
			var path = Path.Combine(Pandora.Profile.BaseFolder, "SpawnData.xml");

			try
			{
				var serializer = new XmlSerializer(typeof(SpawnData));
				var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
				serializer.Serialize(stream, this);
				stream.Close();

				Pandora.Log.WriteEntry("Spawn data saved");
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't save spawndata to {0}", path);
			}
		}

		/// <summary>
		///     Shows the spawns
		/// </summary>
		public void RefreshSpawns()
		{
			Pandora.Map.RemoveAllDrawObjects();

			foreach (SpawnEntry entry in m_SpawnProvider.Spawns)
			{
				var spawn = new SpawnDrawObject(entry);
				Pandora.Map.AddDrawObject(spawn, false);
			}

			Pandora.Map.Refresh();
		}
	}

	[Serializable]
	public class SpawnEntry
	{
		// Always exported
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
		[XmlAttribute]
		public int Map { get => m_Map; set => m_Map = value; }

		[XmlAttribute]
		public int X { get => m_X; set => m_X = value; }

		[XmlAttribute]
		public int Y { get => m_Y; set => m_Y = value; }

		[XmlAttribute]
		public int Z { get => m_Z; set => m_Z = value; }

		[XmlAttribute]
		public int Count
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_Count;
				}

				return -1;
			}
			set => m_Count = value;
		}

		[XmlAttribute]
		public int Range
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_Range;
				}

				return -1;
			}
			set => m_Range = value;
		}

		[XmlAttribute]
		public double MinDelay
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_MinDelay.TotalSeconds;
				}

				return -1;
			}
			set => m_MinDelay = TimeSpan.FromSeconds(value);
		}

		[XmlAttribute]
		public double MaxDelay
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_MaxDelay.TotalSeconds;
				}

				return -1;
			}
			set => m_MaxDelay = TimeSpan.FromSeconds(value);
		}

		[XmlAttribute]
		public int Team
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_Team;
				}

				return -1;
			}
			set => m_Team = value;
		}

		[XmlAttribute]
		public string CreaturesList
		{
			get
			{
				if (SpawnData.ExportSpawnInfo)
				{
					return m_Names;
				}

				return null;
			}
			set
			{
				if (value.Length > 0)
				{
					m_Names = value.Replace("|", ", ");
				}
				else
				{
					m_Names = "";
				}
			}
		}

		[XmlIgnore]
		public string Names { get => m_Names; set => m_Names = value; }
		#endregion

		public string ToolTipDetailed => String.Format(
					Pandora.Localization.TextProvider["Travel.SpawnTipDetailed"],
					m_Count,
					m_Range,
					m_Team,
					m_MinDelay.Hours,
					m_MinDelay.Minutes,
					m_MinDelay.Seconds,
					m_MaxDelay.Hours,
					m_MaxDelay.Minutes,
					m_MaxDelay.Seconds,
					m_Names);
	}
}