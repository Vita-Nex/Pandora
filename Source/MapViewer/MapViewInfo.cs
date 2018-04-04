#region Header
// /*
//  *    2018 - MapViewer - MapViewInfo.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
#endregion

namespace TheBox.MapViewer
{
	/// <summary>
	///     Provides information about the current view provided by the MapViewer control
	/// </summary>
	public class MapViewInfo
	{
		/// <summary>
		///     Creates a new MapViewInfo object
		/// </summary>
		/// <param name="map">The map currently displayed</param>
		/// <param name="controlSize">The size of the control</param>
		/// <param name="center">The location of the center of the control</param>
		/// <param name="zoomLevel">The current zoom level</param>
		/// <param name="viewer">The MapViewer owner of this view</param>
		public MapViewInfo(Maps map, Size controlSize, Point center, int zoomLevel, MapViewer viewer)
		{
			m_Map = map;
			m_ControlSize = controlSize;
			m_Center = center;
			m_ZoomLevel = zoomLevel;
			m_Viewer = viewer;

			Calculate();
		}

		/// <summary>
		///     Creates a new MapViewInfo object with default values
		/// </summary>
		/// <param name="viewer">The MapViewer owner of this view</param>
		public MapViewInfo(MapViewer viewer)
		{
			m_Map = Maps.Felucca;
			m_ControlSize = new Size(20, 20);
			m_Center = new Point(0, 0);
			m_ZoomLevel = 0;
			m_Viewer = viewer;

			Calculate();
		}

		#region Variables
		/// <summary>
		///     The Size of the control visible area
		/// </summary>
		private Size m_ControlSize;

		/// <summary>
		///     The size of the current map
		/// </summary>
		private Size m_MapSize;

		/// <summary>
		///     The map coordinates of center of the control
		/// </summary>
		private Point m_Center;

		/// <summary>
		///     The coordinates of the center of the control
		/// </summary>
		private Point m_ControlCenter;

		/// <summary>
		///     The zoom level of the control
		/// </summary>
		private int m_ZoomLevel;

		/// <summary>
		///     The number of cells used (horizontally or vertically) to display each block
		/// </summary>
		private int m_CellsPerBlock;

		/// <summary>
		///     The number of pixels used to display each cell
		/// </summary>
		private int m_PixelsPerCell;

		/// <summary>
		///     The map currently displayed by the control
		/// </summary>
		private Maps m_Map;

		/// <summary>
		///     Represents the number of map units included in each pixel
		/// </summary>
		private double m_CellsPerPixel;

		/// <summary>
		///     The top left block information
		/// </summary>
		private BlockInfo m_Start;

		/// <summary>
		///     The bottom right block information
		/// </summary>
		private BlockInfo m_End;

		/// <summary>
		///     The first valid top left block
		/// </summary>
		private BlockInfo m_ValidStart;

		/// <summary>
		///     The last valid bottom right block
		/// </summary>
		private BlockInfo m_ValidEnd;

		/// <summary>
		///     The number of pixels needed to represent the topmost cell
		/// </summary>
		private int m_TopPixels;

		/// <summary>
		///     The number of pixels needed to represent the leftmost cell
		/// </summary>
		private int m_LeftPixels;

		/// <summary>
		///     The current point being drawn on the control
		/// </summary>
		private Point m_CurrentPoint;

		/// <summary>
		///     The X coordinate for the current block
		/// </summary>
		private int m_CurrentXBlock;

		/// <summary>
		///     The Y coordinate for the current block
		/// </summary>
		private int m_CurrentYBlock;

		/// <summary>
		///     The X coordinate for the current cell
		/// </summary>
		private int m_CurrentXCell;

		/// <summary>
		///     The Y coordinate for the current cell
		/// </summary>
		private int m_CurrentYCell;

		/// <summary>
		///     The number of X blocks read into the array
		/// </summary>
		private int m_ValidXBlocks;

		/// <summary>
		///     The number of Y blocks read into the array
		/// </summary>
		private int m_ValidYBlocks;

		/// <summary>
		///     The visible area of the map
		/// </summary>
		private Rectangle m_Bounds;
		
		/// <summary>
		///     The MapViewer owner of this view info
		/// </summary>
		private readonly MapViewer m_Viewer;

		/// <summary>
		///     The transform matrix applied to the MapViewer
		/// </summary>
		private Matrix m_Transform;

		/// <summary>
		///     The size of the image calculated by the map viewer
		/// </summary>
		private Size m_ImageSize;
		#endregion

		#region Properties
		/// <summary>
		///     Gets the bounds of the visible map region
		/// </summary>
		internal Rectangle Bounds { get { return m_Bounds; } }

		/// <summary>
		///     Gets the width in pixels of the leftmost cell on the control
		/// </summary>
		internal int LeftCell { get { return m_LeftPixels; } }

		/// <summary>
		///     Gets the height in pixels of the topmost cell on the control
		/// </summary>
		internal int TopCell { get { return m_TopPixels; } }

		/// <summary>
		///     Gets the number of cells displayed for each block
		/// </summary>
		internal int CellsPerBlock { get { return m_CellsPerBlock; } }

		/// <summary>
		///     Gets the number of pixels used to display each cell
		/// </summary>
		internal int PixelsPerCell { get { return m_PixelsPerCell; } }

		/// <summary>
		///     Gets the number of X blocks read into the array
		/// </summary>
		internal int ValidXBlocks { get { return m_ValidXBlocks; } }

		/// <summary>
		///     Gets the number of Y blocks read into the array
		/// </summary>
		internal int ValidYBlocks { get { return m_ValidYBlocks; } }

		/// <summary>
		///     Sets the point corresponding to the center of the control
		/// </summary>
		internal Point Center
		{
			set
			{
				if (value != m_Center)
				{
					m_Center = value;
					Calculate();
				}
			}
			get { return m_Center; }
		}

		/// <summary>
		///     Sets the map currently displayed by the control
		/// </summary>
		internal Maps Map
		{
			set
			{
				if (value != m_Map)
				{
					m_Map = value;
					Calculate();
				}
			}
		}

		/// <summary>
		///     Sets the size of the control
		/// </summary>
		internal Size ControlSize
		{
			set
			{
				if (value != m_ControlSize)
				{
					m_ControlSize = value;
					Calculate();
				}
			}
			get { return m_ControlSize; }
		}

		/// <summary>
		///     Gets or sets the zoom level on the control
		/// </summary>
		internal int ZoomLevel
		{
			set
			{
				if (value != m_ZoomLevel)
				{
					m_ZoomLevel = value;
					Calculate();
				}
			}
			get { return m_ZoomLevel; }
		}

		/// <summary>
		///     Gets the zoom level for the current map view
		/// </summary>
		public int Zoom { get { return m_ZoomLevel; } }

		/// <summary>
		///     Gets the size of the map currently displayed
		/// </summary>
		public Size MapSize { get { return m_MapSize; } }

		/// <summary>
		///     Gets the BlockInfo for the top left corner of the control
		/// </summary>
		internal BlockInfo TopLeft { get { return m_Start; } }

		/// <summary>
		///     Gets the BlockInfo for the bottom right corner of the control
		/// </summary>
		internal BlockInfo BottomRight { get { return m_End; } }
		
		/// <summary>
		///     Gets the size of the image needed to produce the control output
		/// </summary>
		internal Size ImageSize { get { return m_ImageSize; } }
		#endregion

		#region Methods
		/// <summary>
		///     Calculates all the parameters needed for this class to function. It assumes Center, ZoomLevel, ControlSize and Map
		///     as given.
		/// </summary>
		private void Calculate()
		{
			// Determine the size of the map first of all
			m_MapSize = MapSizes.GetSize((int)m_Map);

			m_ControlSize = m_Viewer.Size;

			m_ImageSize = m_ControlSize;
			m_Transform = null;
			
			// Calculate the number of cells displayed for each block
			m_CellsPerBlock = 8;

			if (m_ZoomLevel < 0)
			{
				m_CellsPerBlock = 8 / ((int)Math.Pow(2, Math.Abs(m_ZoomLevel)));

				if (m_CellsPerBlock < 1)
					m_CellsPerBlock = 1;
			}

			// Calculate the number of pixels used to display each block
			m_PixelsPerCell = 1;

			if (m_ZoomLevel > 0)
				m_PixelsPerCell = (int)Math.Pow(2, m_ZoomLevel);

			// Calculate the number of cells in each pixel
			m_CellsPerPixel = 1.0 / m_PixelsPerCell;

			// Calculate the center of the control
			m_ControlCenter = new Point(m_Viewer.Width / 2, m_Viewer.Height / 2);

			// Calculate the BlockInfo
			var tl = InternalControlToMap(new Point(0, 0));
			var br = InternalControlToMap(new Point(m_ImageSize.Width - 1, m_ImageSize.Height - 1));

			m_Start = new BlockInfo(tl, m_MapSize);
			m_End = new BlockInfo(br, m_MapSize);

			// Calculate the valid blocks
			var start = m_Start;
			var end = m_End;

			start.Validate();
			end.Validate();

			m_ValidXBlocks = end.XBlock - start.XBlock + 1;
			m_ValidYBlocks = end.YBlock - start.YBlock + 1;

			// Calculate the number of pixels needed to represent the left and top cells
			if (m_PixelsPerCell > 1)
			{
				var yDiff = (m_ImageSize.Height / 2) % m_PixelsPerCell;
				var xDiff = (m_ImageSize.Width / 2) % m_PixelsPerCell;

				if (yDiff == 0)
					m_TopPixels = m_PixelsPerCell;
				else
					m_TopPixels = yDiff;

				if (xDiff == 0)
					m_LeftPixels = m_PixelsPerCell;
				else
					m_LeftPixels = xDiff;
			}
			else
			{
				m_TopPixels = 1;
				m_LeftPixels = 1;
			}

			// Calculate the bounds
			m_Bounds = new Rectangle(tl.X, tl.Y, br.X - tl.X, br.Y - tl.Y);
		}

		/// <summary>
		///     Converts a point of the map image to map coordinates
		/// </summary>
		/// <param name="screenPoint">The point on the non rotaded image</param>
		/// <returns>The point on the map</returns>
		private Point InternalControlToMap(Point screenPoint)
		{
			// Calculate the difference on both axis
			var xDelta = screenPoint.X - m_ControlCenter.X;
			var yDelta = screenPoint.Y - m_ControlCenter.Y;

			// Calculate the difference in map points
			var xMapDelta = ((int)Math.Floor(xDelta * m_CellsPerPixel)) * 8 / m_CellsPerBlock;
			var yMapDelta = ((int)Math.Floor(yDelta * m_CellsPerPixel)) * 8 / m_CellsPerBlock;

			return new Point(m_Center.X + xMapDelta, m_Center.Y + yMapDelta);
		}

		/// <summary>
		///     Converts a point on the screen to map coordinates
		/// </summary>
		/// <param name="screenPoint">The point on the surface of the control</param>
		/// <returns>A point on the map. This value can be outside the bounds of the map</returns>
		public Point ControlToMap(Point screenPoint)
		{
			// Calculate the difference on both axis
			var xDelta = screenPoint.X - m_ControlCenter.X;
			var yDelta = screenPoint.Y - m_ControlCenter.Y;

			// Calculate the difference in map points
			var xMapDelta = ((int)Math.Floor(xDelta * m_CellsPerPixel)) * 8 / m_CellsPerBlock;
			var yMapDelta = ((int)Math.Floor(yDelta * m_CellsPerPixel)) * 8 / m_CellsPerBlock;

			return new Point(m_Center.X + xMapDelta, m_Center.Y + yMapDelta);
		}

		/// <summary>
		///     Converts a distance from screen units to map units
		/// </summary>
		/// <param name="screenDistance">A length in screen units</param>
		/// <returns>The corresponding length in map units</returns>
		public int ControlToMap(int screenDistance)
		{
			return ((int)Math.Floor(m_CellsPerPixel * screenDistance)) * 8 / m_CellsPerBlock;
		}

		/// <summary>
		///     Converts a point on the map to a point on the control
		/// </summary>
		/// <param name="mapPoint">The point in map coordinates</param>
		/// <returns>A point on the control. This value can be outside the bounds of the control.</returns>
		public Point MapToControl(Point mapPoint)
		{
			// Calculate the difference on the axis
			var xDelta = mapPoint.X - m_Center.X;
			var yDelta = mapPoint.Y - m_Center.Y;

			// Calculate the difference in pixels
			var xScreenDelta = xDelta * m_PixelsPerCell / (8 / m_CellsPerBlock);
			var yScreenDelta = yDelta * m_PixelsPerCell / (8 / m_CellsPerBlock);

			var p = new Point(m_ControlCenter.X + xScreenDelta, m_ControlCenter.Y + yScreenDelta);

			//			if ( m_RotateView )
			//			{
			//				Graphics g = m_Viewer.CreateGraphics();
			//				Point[] pts = new Point[ 1 ];
			//				pts[ 0 ] = p;
			//
			//				g.TransformPoints( CoordinateSpace.Page, CoordinateSpace.World, pts );
			//
			//				p = pts[ 0 ];
			//				g.Dispose();
			//			}

			return p;
		}

		/// <summary>
		///     Converts a distance from map units to screen units
		/// </summary>
		/// <param name="mapDistance"></param>
		/// <returns></returns>
		public int MapToControl(int mapDistance)
		{
			return m_PixelsPerCell * mapDistance / (8 / m_CellsPerBlock);
		}

		/// <summary>
		///     Initializes the object to provide information for the image drawing
		/// </summary>
		internal void Initialize()
		{
			m_CurrentPoint = new Point(0, 0);

			m_CurrentXBlock = m_Start.XBlock;
			m_CurrentYBlock = m_Start.YBlock;

			m_CurrentXCell = m_Start.XCell;
			m_CurrentYCell = m_Start.YCell;

			m_ValidStart = m_Start;
			m_ValidEnd = m_End;

			m_ValidStart.Validate();
			m_ValidEnd.Validate();
		}

		/// <summary>
		///     Gets the BlockInformation for the current pixel
		/// </summary>
		/// <returns>The BlockInfo for the current view</returns>
		internal PixelCoordinate GetInfo()
		{
			PixelCoordinate coordinate;

			if (!CurrentBlockIsValid())
			{
				coordinate = new PixelCoordinate(-1, -1);
			}
			else
			{
				coordinate = new PixelCoordinate(
					m_CurrentXBlock - m_ValidStart.XBlock,
					m_CurrentYBlock - m_ValidStart.YBlock,
					m_CurrentXCell,
					m_CurrentYCell,
					m_ValidYBlocks);
			}

			m_CurrentPoint.X++;

			//if ( m_CurrentPoint.X == ( m_RotateView ? m_ImageSize.Width + 1 : m_ImageSize.Width ) )
			if (m_CurrentPoint.X == m_ImageSize.Width)
			{
				// move one line down
				m_CurrentPoint.X = 0;
				m_CurrentPoint.Y++;

				m_CurrentXBlock = m_Start.XBlock;
				m_CurrentXCell = m_Start.XCell;

				// Move one cell down
				if (m_CurrentPoint.Y < m_TopPixels)
				{
					m_CurrentYCell = m_Start.YCell;
					m_CurrentYBlock = m_Start.YBlock;
				}
				else
				{
					if ((m_CurrentPoint.Y - m_TopPixels) % m_PixelsPerCell == 0)
					{
						m_CurrentYCell += (8 / m_CellsPerBlock);

						if (m_CurrentYCell > 7)
						{
							m_CurrentYCell %= 8;
							m_CurrentYBlock++;
						}
					}
				}
			}
			else
			{
				if ((m_CurrentPoint.X - m_LeftPixels) % m_PixelsPerCell == 0)
				{
					// move one step right
					m_CurrentXCell += (8 / m_CellsPerBlock);

					if (m_CurrentXCell > 7)
					{
						m_CurrentXCell %= 8;
						m_CurrentXBlock++;
					}
				}
			}

			return coordinate;
		}

		/// <summary>
		///     Verifies whether the current block is valid or is outside the bounds of the map
		/// </summary>
		/// <returns>True if the block should be displayed, false if it's outside the bounds</returns>
		private bool CurrentBlockIsValid()
		{
			if (m_CurrentXBlock < 0)
				return false;

			if (m_CurrentXBlock >= m_MapSize.Width / 8)
				return false;

			if (m_CurrentYBlock < 0)
				return false;

			if (m_CurrentYBlock >= m_MapSize.Height / 8)
				return false;

			return true;
		}
		#endregion
	}

	#region PixelCoordinate
	internal struct PixelCoordinate
	{
		private readonly int m_Block;
		private readonly int m_Cell;

		/// <summary>
		///     Gets the number of the block in the array stored in memory
		/// </summary>
		public int Block { get { return m_Block; } }

		/// <summary>
		///     Gets the number of the cell correpsonding to the pixl in the block
		/// </summary>
		public int Cell { get { return m_Cell; } }

		public PixelCoordinate(int block, int cell)
		{
			m_Block = block;
			m_Cell = cell;
		}

		public PixelCoordinate(int xblock, int yblock, int xcell, int ycell, int yblocks)
		{
			m_Block = xblock * (yblocks) + yblock;
			m_Cell = ycell * 8 + xcell;
		}
	}
	#endregion

	#region BlockInfo
	/// <summary>
	///     Provides information about block and cell location of a given point on a map.
	/// </summary>
	internal struct BlockInfo
	{
		private int m_BlockNumber;

		/// <summary>
		///     Gets the map file block number for the referenced point
		/// </summary>
		public int BlockNumber { get { return m_BlockNumber; } }

		private int m_XBlock;

		/// <summary>
		///     Gets the X coordinate of the block in a block matrix
		/// </summary>
		public int XBlock { get { return m_XBlock; } }

		private int m_YBlock;

		/// <summary>
		///     Gets the Y coordinate of the block in a block matrix
		/// </summary>
		public int YBlock { get { return m_YBlock; } }

		private int m_Cell;

		/// <summary>
		///     Gets the number of the cell representing the referenced point
		/// </summary>
		public int Cell { get { return m_Cell; } }

		private int m_XCell;

		/// <summary>
		///     Gets the X coordinate of the referenced point in the cells matrix
		/// </summary>
		public int XCell { get { return m_XCell; } }

		private int m_YCell;

		/// <summary>
		///     Gets the Y coordinate of the referenced point in the cells matrix
		/// </summary>
		public int YCell { get { return m_YCell; } }

		private Size m_MapSize;

		/// <summary>
		///     Creates a new BlockInfo structure that provides information for file access to a given point
		/// </summary>
		/// <param name="point">The point referenced by this BlockInfo structure</param>
		/// <param name="mapSize">The size of the map file in cells</param>
		public BlockInfo(Point point, Size mapSize)
		{
			m_XBlock = point.X / 8;
			m_YBlock = point.Y / 8;

			if (point.X < 0)
				m_XBlock--;
			if (point.Y < 0)
				m_YBlock--;

			m_BlockNumber = m_XBlock * (mapSize.Height / 8) + m_YBlock;

			m_XCell = point.X % 8;
			m_YCell = point.Y % 8;

			if (m_XCell < 0)
				m_XCell = 8 + m_XCell;
			if (m_YCell < 0)
				m_YCell = 8 + m_YCell;

			m_Cell = m_YCell * 8 + m_XCell;

			m_MapSize = mapSize;
		}

		/// <summary>
		///     Verifies the block information to make sure it's a valid block for the map
		/// </summary>
		internal void Validate()
		{
			var changed = false;

			if (m_XBlock < 0)
			{
				m_XBlock = 0;
				m_XCell = 0;

				changed = true;
			}

			if (m_XBlock > (m_MapSize.Width / 8) - 1)
			{
				m_XBlock = m_MapSize.Width / 8 - 1;
				m_XCell = 7;

				changed = true;
			}

			if (m_YBlock < 0)
			{
				m_YBlock = 0;
				m_YCell = 0;

				changed = true;
			}

			if (m_YBlock > (m_MapSize.Height / 8) - 1)
			{
				m_YBlock = m_MapSize.Height / 8 - 1;
				m_YCell = 7;

				changed = true;
			}

			if (changed)
			{
				m_BlockNumber = m_XBlock * m_MapSize.Height + m_YBlock;
				m_Cell = m_YCell * 8 + m_XCell;
			}
		}
	}
	#endregion
}