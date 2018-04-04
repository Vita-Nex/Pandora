#region Header
// /*
//  *    2018 - Pandora - Travel.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Data;
#endregion

namespace TheBox.Options
{
	[Serializable]
	/// <summary>
	/// Provides options related to travel
	/// </summary>
	public class TravelOptions
	{
		public TravelOptions()
		{
			m_SpawnColor = new ColorDef();
			m_SpawnColor.Color = Color.Green;
		}

		/// <summary>
		///     The number of maps currently supported
		/// </summary>
		public readonly int MapCount = 5;

		#region Variables
		private bool m_WorldMapBig;

		private string[] m_MapNames = {"Felucca", "Trammel", "Ilshenar", "Malas", "Tokuno"};

		public readonly string[] DefaultMaps = {"Felucca", "Trammel", "Ilshenar", "Malas", "Tokuno"};

		private bool[] m_EnabledMaps = {true, true, true, true, true};

		private bool m_SelectedMapLocations;
		private bool m_DrawStatics = true;
		private Point m_MapCenter = Point.Empty;
		private int m_Map;
		private int m_Zoom;
		private bool m_ShowSpawns;
		private bool m_CustomMaps;
		private ColorDef m_SpawnColor;
		private bool m_RotateMap = true;
		private bool m_XRayView;
		private bool m_FollowClient;
		#endregion

		#region Events
		/// <summary>
		///     Occurs when the the setting for the display of the locations of the different map changed
		/// </summary>
		public event EventHandler TreeDisplayChanged;

		/// <summary>
		///     Occurs when the user toggles the option to display spawns
		/// </summary>
		public event EventHandler ShowSpawnsChanged;

		protected virtual void OnTreeDisplayChanged(EventArgs e)
		{
			if (TreeDisplayChanged != null)
				TreeDisplayChanged(this, e);
		}
		#endregion

		[XmlIgnore]
		/// <summary>
		/// Gets or sets the color used to display spawns on the map
		/// </summary>
		public Color SpawnColor { get { return m_SpawnColor.Color; } set { m_SpawnColor.Color = value; } }

		[XmlIgnore]
		/// <summary>
		/// Gets the classical name for the selected map
		/// </summary>
		public string SelectedMapName
		{
			get
			{
				switch (m_Map)
				{
					case 0:
						return "Felucca";
					case 1:
						return "Trammel";
					case 2:
						return "Ilshenar";
					case 3:
						return "Malas";
					case 4:
						return "Tokuno";
				}

				return "Felucca";
			}
		}

		/// <summary>
		///     Gets or sets the object that defines the color used to display spawns
		/// </summary>
		public ColorDef SpawnObjColor { get { return m_SpawnColor; } set { m_SpawnColor = value; } }

		/// <summary>
		///     Gets or sets the zoom level on the Map viewer
		/// </summary>
		public int Zoom { get { return m_Zoom; } set { m_Zoom = value; } }

		/// <summary>
		///     Gets or sets the map displayed on the viewer
		/// </summary>
		public int Map { get { return m_Map; } set { m_Map = value; } }

		/// <summary>
		///     Gets or sets the point displayed on the map
		/// </summary>
		public Point MapCenter { get { return m_MapCenter; } set { m_MapCenter = value; } }

		/// <summary>
		///     Gets or sets a value stating whether the map viewer will display statics
		/// </summary>
		public bool DrawStatics { get { return m_DrawStatics; } set { m_DrawStatics = value; } }

		/// <summary>
		///     Gets or sets a value stating whether the travel tab should display locations only for the selected map
		/// </summary>
		public bool SelectedMapLocations
		{
			get { return m_SelectedMapLocations; }
			set
			{
				if (m_SelectedMapLocations != value)
				{
					m_SelectedMapLocations = value;

					OnTreeDisplayChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		///     Gets or sets a value stating whether the world map will display big images
		/// </summary>
		public bool WorldMapBig { get { return m_WorldMapBig; } set { m_WorldMapBig = value; } }

		/// <summary>
		///     Gets or sets a string containing the names of the maps on this profile
		/// </summary>
		public string[] MapNames { get { return m_MapNames; } set { m_MapNames = value; } }

		/// <summary>
		///     Gets or sets the enabled state for the maps in this profile
		/// </summary>
		public bool[] EnabledMaps { get { return m_EnabledMaps; } set { m_EnabledMaps = value; } }

		/// <summary>
		///     States whether the profile uses custom maps
		/// </summary>
		public bool CustomMaps { get { return m_CustomMaps; } set { m_CustomMaps = value; } }

		/// <summary>
		///     States whether the map should display spawns
		/// </summary>
		public bool ShowSpawns
		{
			get { return m_ShowSpawns; }
			set
			{
				m_ShowSpawns = value;

				if (ShowSpawnsChanged != null)
				{
					ShowSpawnsChanged(this, new EventArgs());
				}
			}
		}
		
		/// <summary>
		///     States whether the map should display statics under ground
		/// </summary>
		public bool XRayView { get { return m_XRayView; } set { m_XRayView = value; } }

		/// <summary>
		///     States whether the map should follow client movements on the map
		/// </summary>
		public bool FollowClient { get { return m_FollowClient; } set { m_FollowClient = value; } }

		/// <summary>
		///     Gets an image for the world map
		/// </summary>
		/// <param name="index">The index of the map file</param>
		/// <param name="big">Value stating whether the method should return the big or small version of the map</param>
		/// <returns>A bitmap containing the map</returns>
		public Bitmap GetMapImage(int index, bool big)
		{
			var FileName = string.Format(
				"{0}{1}Maps{1}map{2}{3}.jpg",
				Pandora.Profile.BaseFolder,
				Path.DirectorySeparatorChar,
				index,
				big ? "big" : "small");

			if (File.Exists(FileName))
			{
				try
				{
					var bmp = new Bitmap(FileName);
					return bmp;
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(
						err,
						string.Format("Unable to read map {0} ({1}) from location {2}", index, big ? "big" : "small", FileName));
					return null;
				}
			}
			return null;
		}

		/// <summary>
		///     Gets a value stating whether there is at least one enabled map
		/// </summary>
		public bool IsEnabled { get { return m_EnabledMaps[0] || m_EnabledMaps[1] || m_EnabledMaps[2] || m_EnabledMaps[3]; } }

		/// <summary>
		///     Shows or hides the spawns on the map
		/// </summary>
		/// <param name="visible">States whether the spawns should be seen or not</param>
		public void DoSpawns(bool visible)
		{
			ShowSpawns = visible;

			if (visible)
			{
				SpawnData.SpawnProvider.RefreshSpawns();
			}
			else
			{
				Pandora.Map.RemoveAllDrawObjects();
			}
		}

		/// <summary>
		///     Gets the index used in mul files for the specified map
		/// </summary>
		/// <param name="index">The index of the map in the configured map list</param>
		/// <returns>The real index of the mul file</returns>
		public int GetRealMapIndex(int index)
		{
			var ind = 0;

			for (var i = 0; i < 5; i++)
			{
				if (ind == index)
				{
					return i;
				}

				if (m_EnabledMaps[i])
				{
					ind++;
				}
			}

			return 0;
		}
	}
}