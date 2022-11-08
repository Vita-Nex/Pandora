#region Header
// /*
//  *    2018 - MapViewer - MapViewer.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.MapViewer.DrawObjects;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
// Issues 43 - Problems when the client path isn't found - http://code.google.com/p/pandorasbox3/issues/detail?id=43 - Smjert
#endregion

// Issues 43 - End

namespace TheBox.MapViewer
{
	/// <summary>
	///     List of supported maps as of Age of Shadows
	/// </summary>
	public enum Maps
	{
		/// <summary>
		///     This identifies all the maps. Should be used only to create draw objects that display on all maps
		/// </summary>
		AllMaps = -1,

		/// <summary>
		///     Map defined by index 0
		/// </summary>
		Felucca = 0,

		/// <summary>
		///     Map defined by index 0 for the base files and 1 for the patch files
		/// </summary>
		Trammel = 1,

		/// <summary>
		///     Map defined by index 2
		/// </summary>
		Ilshenar = 2,

		/// <summary>
		///     Map defined by index 3
		/// </summary>
		Malas = 3,

		/// <summary>
		///     Map defined by index 4
		/// </summary>
		Tokuno = 4,

		/// <summary>
		///     Map defined by index 5
		/// </summary>
		TerMur = 5
	}

	/// <summary>
	///     Specifies the map navigation mode
	/// </summary>
	public enum MapNavigation
	{
		/// <summary>
		///     No built in navigation is used
		/// </summary>
		None,

		/// <summary>
		///     Navigation by left mouse button
		/// </summary>
		LeftMouseButton,

		/// <summary>
		///     Navigation by right mouse button
		/// </summary>
		RightMouseButton,

		/// <summary>
		///     Navigation by middle mouse button
		/// </summary>
		MiddleMouseButton,

		/// <summary>
		///     Navigation by any mouse button
		/// </summary>
		AnyMouseButton
	}

	/// <summary>
	///     Ultima Online map viewer
	/// </summary>
	public class MapViewer : Control
	{
		/// <summary>
		///     Creates a MapViewer control
		/// </summary>
		public MapViewer()
		{
			// Set styles needed to reduce flickering
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			// Initialize variables
			DrawObjects = new List<IMapDrawable>();

			// Create the default view. This will be most likely changed by the frame
			m_ViewInfo = new MapViewInfo(this);
		}

		static MapViewer()
		{
			m_MulManager = new MulManager();
		}

		#region Events
		/// <summary>
		///     The coordinates of the center of the control have been changed
		/// </summary>
		public event EventHandler MapLocationChanged;

		/// <summary>
		///     The map displayed by the control has changed
		/// </summary>
		public event EventHandler MapChanged;

		/// <summary>
		///     Occurs when the zoom level in the map viewer has been changed
		/// </summary>
		public event EventHandler ZoomLevelChanged;

		/// <summary>
		///     Occurs when the location corresponding to the center of the control changes
		/// </summary>
		/// <param name="e">Standard EventArgs</param>
		protected virtual void OnMapLocationChanged(EventArgs e)
		{
			MapLocationChanged?.Invoke(this, e);
		}

		/// <summary>
		///     Occurs when the map is changed
		/// </summary>
		/// <param name="e">Standard EventArgs</param>
		protected virtual void OnMapChanged(EventArgs e)
		{
			MapChanged?.Invoke(this, e);
		}

		/// <summary>
		///     Fires the ZoomLevelChanged event
		/// </summary>
		protected virtual void OnZoomLevelChanged(EventArgs e)
		{
			ZoomLevelChanged?.Invoke(this, e);
		}
		#endregion

		#region Extract Map Image
		/// <summary>
		///     Scale for the extracted image from the map
		/// </summary>
		public enum MapScale
		{
			/// <summary>
			///     Each pixel is extracted
			/// </summary>
			Full = 1,

			/// <summary>
			///     One pixel in two is drawn
			/// </summary>
			Half = 2,

			/// <summary>
			///     One pixel in four is drawn
			/// </summary>
			Fourth = 4,

			/// <summary>
			///     One pixel in eight is drawn
			/// </summary>
			Eigth = 8,

			/// <summary>
			///     One pixel in two blocks is drawn
			/// </summary>
			Sixteenth = 16
		}

		/// <summary>
		///     Extracts an image displaying the full map
		/// </summary>
		/// <param name="map">The map that should be extracted</param>
		/// <param name="scale">The scale value</param>
		/// <param name="FileName">The target filename</param>
		public static void ExtractMap(Maps map, MapScale scale, string FileName)
		{
			if (map == Maps.AllMaps)
			{
				throw new Exception("Cannot extract image for Maps.AllMaps");
			}

			var index = (int)map;

			var umap = Ultima.Map.Maps[index];

			if (umap == null)
			{
				throw new FileNotFoundException(String.Format("File {0} doens't exist. Impossible to extract the map.", map));
			}

			var step = (int)scale;
			var size = new Size(umap.Width, umap.Height);

			using (var bmp = new Bitmap(umap.Width, umap.Height, PixelFormat.Format16bppRgb555))
			{
				var b = new Rectangle(0, 0, size.Width >> 3, size.Height >> 3);

				umap.GetImage(0, 0, b.Width, b.Height, bmp, true);

				using (var tmp = new Bitmap(size.Width / step, size.Height / step))
				{
					using (var g = Graphics.FromImage(tmp))
					{
						g.DrawImage(bmp, new Rectangle(0, 0, tmp.Width, tmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
					}
				}

				bmp.Save(FileName, ImageFormat.Jpeg);
			}
		}
		#endregion

		#region Drawing

		private void CreateImage()
		{
			if (m_Map == Maps.AllMaps)
			{
				m_Image = null;
				return;
			}

			var umap = Ultima.Map.Maps[(int)m_Map];

			if (umap == null)
			{
				m_Image = null;
				return;
			}

			var b = m_ViewInfo.Bounds;

			var map = new Bitmap(b.Width, b.Height, PixelFormat.Format16bppRgb555);

			b = new Rectangle(b.X >> 3, b.Y >> 3, b.Width >> 3, b.Height >> 3);

			umap.GetImage(b.X, b.Y, b.Width, b.Height, map, true);

			m_Image = map;
		}

		/// <summary>
		///     This does the actual drawing of the control
		/// </summary>
		/// <param name="e">The Event Args for the OnPaint event</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (!m_isRefreshed)
			{
				try
				{
					CalculateMap();
				}
				catch (Exception err)
				{
					base.OnPaint(e);

					// Create a log and write the exception
					var filename = GetType().Assembly.Location;
					var folder = Path.GetDirectoryName(filename);
					var crashlog = Path.Combine(folder, "MapViewer crashlog.txt");

					using (var writer = new StreamWriter(crashlog))
					{
						writer.WriteLine("Log generated on {0}", DateTime.Now.ToString());
						writer.WriteLine(err.ToString());
					}

					// Display the error message
					var font = new Font(FontFamily.GenericSansSerif, 8);
					var color = SystemColors.ControlText;
					Brush brush = new SolidBrush(color);
					var format = new StringFormat
					{
						LineAlignment = StringAlignment.Center
					};

					var error = String.Format(
						"An unexpected error occurred. A crash log has been generated at {0}.",
						crashlog);

					e.Graphics.DrawString(error, font, brush, Bounds, format);

					return;
				}
			}

			e.Graphics.DrawImage(m_Image, 0, 0);

			//
			// DRAW OBJECTS
			//
			foreach (var drawObject in DrawObjects)
			{
				if (drawObject.IsVisible(m_ViewInfo.Bounds, m_Map))
				{
					drawObject.Draw(e.Graphics, m_ViewInfo);
				}
			}

			//
			// CROSS
			//
			if (m_ShowCross)
			{
				Brush crossBrush = new SolidBrush(Color.FromArgb(180, Color.White));
				var crossPen = new Pen(crossBrush);

				var xc = Size.Width / 2;
				var yc = Size.Height / 2;

				e.Graphics.DrawLine(crossPen, xc - 4, yc, xc + 4, yc);
				e.Graphics.DrawLine(crossPen, xc, yc - 4, xc, yc + 4);

				crossBrush.Dispose();
				crossPen.Dispose();
			}
		}

		/// <summary>
		///     Specifies whether the control has been refreshed and doesn't need to be redrawn
		/// </summary>
		private bool m_isRefreshed;

		/// <summary>
		///     Specifies whether the map should draw statics or not
		/// </summary>
		private bool m_drawStatics;

		/// <summary>
		///     The image used to draw the control
		/// </summary>
		private Bitmap m_Image;

		/// <summary>
		///		The currently displayed map
		/// </summary>
		private Maps m_Map;

		/// <summary>
		///     The leftmost valid block read from file
		/// </summary>
		private int m_LeftBlock;

		/// <summary>
		///     The rightmost block read from file
		/// </summary>
		private int m_RightBlock;

		/// <summary>
		///     The topmost block read from file
		/// </summary>
		private int m_TopBlock;

		/// <summary>
		///     The bottom block read from file
		/// </summary>
		private int m_BottomBlock;

		/// <summary>
		///     Displays the cross at the center of the map
		/// </summary>
		private bool m_ShowCross;

		/// <summary>
		///     Contains all the information about the current view of the map on the control
		/// </summary>
		private readonly MapViewInfo m_ViewInfo;

		/// <summary>
		///     The file manager to use with Pandora's Box
		/// </summary>
		private static MulManager m_MulManager;

		/// <summary>
		///     Specifies the X-Ray mode where statics below the map are displayed
		/// </summary>
		private bool m_XRayView;
		#endregion

		#region Properties
		/// <summary>
		///     Gets or sets the navigation style
		/// </summary>
		[Category("Settings"), Description("Specifies the navigation style on the map viewer")]
		public MapNavigation Navigation { get; set; } = MapNavigation.None;

		/// <summary>
		///     The zoom level of the map. Acceptable values are from -3 to 4.
		/// </summary>
		[Category("Settings"), Description("The zoom level for the map. Values range from -3 to 4.")]
		public int ZoomLevel
		{
			get => m_ViewInfo.ZoomLevel;
			set
			{
				if (m_ViewInfo.ZoomLevel == value)
				{
					return;
				}

				var zoomLevel = value;

				if (zoomLevel > 4)
				{
					zoomLevel = 4;
				}

				if (zoomLevel < -3)
				{
					zoomLevel = -3;
				}

				// Calculate the map view
				m_ViewInfo.ZoomLevel = zoomLevel;

				InvalidateMap();

				OnZoomLevelChanged(new EventArgs());
			}
		}

		/// <summary>
		///     Gets or sets a value specifying whether the map viewer should display statics or not
		/// </summary>
		[Category("Settings"), Description("Controls the display of statics on the control.")]
		public bool DrawStatics
		{
			get => m_drawStatics;
			set
			{
				if (m_drawStatics != value)
				{
					m_drawStatics = value;

					InvalidateMap();
				}
			}
		}

		/// <summary>
		///     Gets the width of the current map
		/// </summary>
		[Browsable(false)]
		public int MapWidth => m_ViewInfo.MapSize.Width;

		/// <summary>
		///     Gets the height of the current map
		/// </summary>
		[Browsable(false)]
		public int MapHeight => m_ViewInfo.MapSize.Height;

		/// <summary>
		///     Gets the number of horizontal map blocks for the current map
		/// </summary>
		[Browsable(false)]
		private int XBlocks => m_ViewInfo.MapSize.Width / 8;

		/// <summary>
		///     Gets the number of vertical map blocks for the current map
		/// </summary>
		[Browsable(false)]
		private int YBlocks => m_ViewInfo.MapSize.Height / 8;

		/// <summary>
		///     Gets or sets the coordinates of the center of the map
		/// </summary>
		[Category("Settings"), Description("The map coordinates of the center point of the control.")]
		public Point Center
		{
			set
			{
				if ((m_ViewInfo.Center.X != value.X) || m_ViewInfo.Center.Y != value.Y)
				{
					m_ViewInfo.Center = value;
					InvalidateMap();

					OnMapLocationChanged(new EventArgs());
				}
			}
			get => m_ViewInfo.Center;
		}

		/// <summary>
		///     Gets or sets the displayed map
		/// </summary>
		[Category("Settings"), Description("The map type displayed.")]
		public Maps Map
		{
			get => m_Map;
			set
			{
				if (value != m_Map)
				{
					m_Map = value;

					m_ViewInfo.Map = m_Map;

					InvalidateMap();

					OnMapChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		///     Gets or sets a value stating whether error messages get displayed on the control surface
		/// </summary>
		[Category("Settings"), Description("Specifies whether the control displays error messages on its surface")]
		public bool DisplayErrors { get; set; } = true;

		/// <summary>
		///     Controls the display of a small cross at the center of the control
		/// </summary>
		[Category("Settings"), Description("Controls the display of a small cross at the center of the control")]
		public bool ShowCross
		{
			get => m_ShowCross;
			set
			{
				if (m_ShowCross != value)
				{
					m_ShowCross = value;
					Refresh();
				}
			}
		}

		/// <summary>
		///     Gets or sets the list of drawing objects on the map
		/// </summary>
		[Browsable(false)]
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<IMapDrawable> DrawObjects
		// Issue 10 - End
		{ get; set; }

		/// <summary>
		///     Gets or sets the mul file manager
		/// </summary>
		[Browsable(false)]
		public MulManager MulManager
		{
			get
			{
				if (m_MulManager == null)
				{
					m_MulManager = new MulManager();
				}

				return m_MulManager;
			}
			set => m_MulManager = value;
		}

		/// <summary>
		///     Gets the mul file manager
		/// </summary>
		[Browsable(false)]
		public static MulManager MulFileManager
		{
			get
			{
				if (m_MulManager == null)
				{
					m_MulManager = new MulManager();
				}

				return m_MulManager;
			}
			set => m_MulManager = value;
		}

		/// <summary>
		///     States whether the map viewer can use the mouse wheel for zoom purposes
		/// </summary>
		[Category("Settings"), Description("States whether the map viewer will use mouse wheel zoom input for zooming.")]
		public bool WheelZoom { get; set; }

		/// <summary>
		///     Specifies the X-Ray view mode
		/// </summary>
		[Category("Settings"), Description("Enables X-Ray view where statics below the ground are displayed")]
		public bool XRayView
		{
			get => m_XRayView;
			set
			{
				if (m_XRayView != value)
				{
					m_XRayView = value;

					InvalidateMap();
				}
			}
		}
		#endregion

		#region Handlers
		/// <summary>
		///     Overriden OnResize event handler
		/// </summary>
		/// <param name="e">Provided by the framework</param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			// Update the size on the view
			m_ViewInfo.ControlSize = Size;

			if (Created)
			{
				InvalidateMap();
			}
		}

		/// <summary>
		///     Handles zooming with the wheel
		/// </summary>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (WheelZoom)
			{
				if (e.Delta > 0)
				{
					ZoomIn();
				}
				else if (e.Delta < 0)
				{
					ZoomOut();
				}
			}
		}

		/// <summary>
		///     Handles the mouse down event to provide built in map navigation
		/// </summary>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			var navigate = false;

			switch (Navigation)
			{
				case MapNavigation.AnyMouseButton:

					navigate = e.Button != MouseButtons.None;
					break;

				case MapNavigation.LeftMouseButton:

					navigate = e.Button == MouseButtons.Left;
					break;

				case MapNavigation.RightMouseButton:

					navigate = e.Button == MouseButtons.Right;
					break;

				case MapNavigation.MiddleMouseButton:

					navigate = e.Button == MouseButtons.Middle;
					break;
			}

			if (navigate)
			{
				var c = m_ViewInfo.ControlToMap(new Point(e.X, e.Y));
				Center = c;
			}

			base.OnMouseDown(e);
		}
		#endregion

		/// <summary>
		///     Converts a point on the control surface to map coordinates
		/// </summary>
		/// <param name="point">A point on the surface of the control</param>
		/// <returns>The point in map coordinates</returns>
		public Point ControlToMap(Point point)
		{
			return m_ViewInfo.ControlToMap(point);
		}

		/// <summary>
		///     Converts a horizontal coordinate from the control to map
		/// </summary>
		/// <param name="x">The x coordinate on the control</param>
		/// <returns>The x coordinate on the map</returns>
		public int ControlToMapX(int x)
		{
			return m_ViewInfo.ControlToMap(new Point(x, 0)).X;
		}

		/// <summary>
		///     Converts a vertical coordinate on the control to map coordinates
		/// </summary>
		/// <param name="y">The y coordinate on the control</param>
		/// <returns>The corresponding y coordinate on the map</returns>
		public int ControlToMapY(int y)
		{
			return m_ViewInfo.ControlToMap(new Point(0, y)).Y;
		}

		private void CalculateMap()
		{
			// Get the pixel info for the left-top and right-bottom points

			var TopLeft = m_ViewInfo.TopLeft;
			var BottomRight = m_ViewInfo.BottomRight;

			// Verify if the blocks are valid and there's a portion of map actually visible
			if ((BottomRight.XBlock < 0) || (BottomRight.YBlock < 0) || (TopLeft.XBlock >= XBlocks) ||
				(TopLeft.YBlock >= YBlocks))
			{
				CreateImage();
				return;
			}

			TopLeft.Validate();
			BottomRight.Validate();

			m_LeftBlock = TopLeft.XBlock;
			m_RightBlock = BottomRight.XBlock;
			m_TopBlock = TopLeft.YBlock;
			m_BottomBlock = BottomRight.YBlock;

			CreateImage();

			// Set the refreshed flag to true
			m_isRefreshed = true;
		}

		/// <summary>
		///     Invalidates the control and forces it to redraw
		/// </summary>
		private void InvalidateMap()
		{
			m_isRefreshed = false;
			Refresh();
		}

		/// <summary>
		///     Increases the zoom level by one point
		/// </summary>
		public void ZoomIn()
		{
			ZoomLevel++;
		}

		/// <summary>
		///     Decreases the zoom level by one point
		/// </summary>
		public void ZoomOut()
		{
			ZoomLevel--;
		}

		/// <summary>
		///     Adds a new draw object to the map and redraws the map
		/// </summary>
		/// <param name="drawObject">The IMapDrawable object that should be added</param>
		public void AddDrawObject(IMapDrawable drawObject)
		{
			DrawObjects.Add(drawObject);

			// Redraw the map
			Refresh();
		}

		/// <summary>
		///     Adds a new draw object to the map
		/// </summary>
		/// <param name="drawObject">The IMapDrawable object that is being added to the map</param>
		/// <param name="refresh">Specifies whether the map should be redrawn after the object is added</param>
		public void AddDrawObject(IMapDrawable drawObject, bool refresh)
		{
			DrawObjects.Add(drawObject);

			if (refresh)
			{
				Refresh();
			}
		}

		/// <summary>
		///     Removes a draw object from the list of displayed objects
		/// </summary>
		/// <param name="drawObject">The draw object to be removed</param>
		public void RemoveDrawObject(IMapDrawable drawObject)
		{
			if (DrawObjects.Contains(drawObject))
			{
				_ = DrawObjects.Remove(drawObject);
			}
		}

		/// <summary>
		///     Removes all draw objects
		/// </summary>
		public void RemoveAllDrawObjects()
		{
			DrawObjects.Clear();
			Refresh();
		}

		/// <summary>
		///     Gets the height of the map at the center point of the control
		/// </summary>
		/// <returns>The height of the map at its center location</returns>
		public int GetMapHeight()
		{
			return GetMapHeight(m_ViewInfo.Center);
		}

		/// <summary>
		///     Calculates the height of the map at a given location
		/// </summary>
		/// <param name="point">The point of the map (in map units)</param>
		/// <returns>The height of the given point</returns>
		public int GetMapHeight(Point point)
		{
			return GetMapHeight(point, (int)m_Map);
		}

		/// <summary>
		///     Gets the height of the map at a given point in the control and on a given map
		/// </summary>
		/// <param name="point">The point to search for height</param>
		/// <param name="mapIndex">The map on which the point is</param>
		/// <returns>The height corresponding to the point</returns>
		public int GetMapHeight(Point point, int mapIndex)
		{
			var umap = Ultima.Map.Maps[mapIndex];

			if (umap == null || point.X < 0 || point.X > umap.Height || point.Y < 0 || point.Y > umap.Height)
			{
				return 0;
			}

			var lt = umap.Tiles.GetLandTile(point.X, point.Y);

			return lt.Z;
		}

		/// <summary>
		///     Finds the draw object located at a given spot
		/// </summary>
		/// <param name="location">A point on the control surface</param>
		/// <param name="range">The number of pixels to consider as range for the search</param>
		/// <returns>A IMapDrawable object, or null</returns>
		public IMapDrawable FindDrawObject(Point location, int range)
		{
			var c = ControlToMap(location);

			var rect = new Rectangle(c.X - (range / 2), c.Y - (range / 2), range, range);

			foreach (var obj in DrawObjects)
			{
				if (obj.IsVisible(rect, m_Map))
				{
					return obj;
				}
			}

			return null;
		}
	}
}