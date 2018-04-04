#region Header
// /*
//  *    2018 - MapViewer - DrawObject.cs
//  */
#endregion

#region References
using System.Drawing;
#endregion

namespace TheBox.MapViewer.DrawObjects
{
	#region IMapDrawable
	/// <summary>
	///     The interface that must be implemented by any draw object used on a MapViewer
	/// </summary>
	public interface IMapDrawable
	{
		/// <summary>
		///     Evaluates the visibility of the object on the portion of the map currently displayed
		/// </summary>
		/// <param name="bounds">The bounds of the current map view</param>
		/// <param name="map">The current map</param>
		/// <returns></returns>
		bool IsVisible(Rectangle bounds, Maps map);

		/// <summary>
		///     Draws a draw object on the map viewer
		/// </summary>
		/// <param name="g">The graphics object on which the drawing happens</param>
		/// <param name="ViewInfo">Information about the map view currently used on the control</param>
		void Draw(Graphics g, MapViewInfo ViewInfo);
	}
	#endregion

	#region MapRectangle
	/// <summary>
	///     A rectangle displayed on the map
	/// </summary>
	public class MapRectangle : IMapDrawable
	{
		/// <summary>
		///     The rectangle coordinates (on the map)
		/// </summary>
		private Rectangle m_Location;

		/// <summary>
		///     The map on which the object is drawn
		/// </summary>
		private readonly Maps m_Map;

		/// <summary>
		///     The color for the rectangle border
		/// </summary>
		private Color m_Color;

		/// <summary>
		///     The color for the fill of the rectangle
		/// </summary>
		private Color m_FillColor;

		/// <summary>
		///     States whether to fill the rectangle or not
		/// </summary>
		private readonly bool m_Fill;

		/// <summary>
		///     The rectangle coordinates (in map units)
		/// </summary>
		public Rectangle Rectangle { get { return m_Location; } set { m_Location = value; } }

		/// <summary>
		///     Gets or sets the color of the border
		/// </summary>
		public Color Color { get { return m_Color; } set { m_Color = value; } }

		/// <summary>
		///     Gets or sets the color of the fill
		/// </summary>
		public Color FillColor { get { return m_FillColor; } set { m_FillColor = value; } }

		/// <summary>
		///     Creates a new Rectangle object that can be drawn on the mapviewer and that is filled inside
		/// </summary>
		/// <param name="location">The rectangle in map coordinates</param>
		/// <param name="map"></param>
		/// <param name="color">The color for the border of the rectangle</param>
		/// <param name="fillColor">The color for the fill of the rectangle</param>
		public MapRectangle(Rectangle location, Maps map, Color color, Color fillColor)
		{
			m_Location = location;
			m_Color = color;
			m_FillColor = fillColor;
			m_Fill = true;
			m_Map = map;
		}

		/// <summary>
		///     Creates a non-filled rectangle that can be drawn on the map viewer
		/// </summary>
		/// <param name="location">The rectangle in map coordinates</param>
		/// <param name="map">The map on which this object is drawn</param>
		/// <param name="color">The color for the border</param>
		public MapRectangle(Rectangle location, Maps map, Color color)
		{
			m_Location = location;
			m_Color = color;
			m_Fill = false;
			m_Map = map;
		}

		#region IMapDrawable Members
		/// <summary>
		///     Calculates whether the rectangle is visible on the given map portion
		/// </summary>
		/// <param name="bounds">A rectangle object describing the bounds of the map portion currently displayed</param>
		/// <param name="map">The map on which the rectangle is drawn</param>
		/// <returns>True if the object is visible on the map porion or not</returns>
		public bool IsVisible(Rectangle bounds, Maps map)
		{
			if ((m_Map != map) && (m_Map != Maps.AllMaps))
				return false;

			if ((m_Location.Left > bounds.Right) || (m_Location.Right < bounds.Left) || (m_Location.Top > bounds.Bottom) ||
				(m_Location.Bottom < bounds.Top))
				return false;
			return true;
		}

		/// <summary>
		///     Draws the rectangle on the provided Graphics
		/// </summary>
		/// <param name="g">The graphics on which the drawing happens</param>
		/// <param name="ViewInfo">Information about the current map view</param>
		public void Draw(Graphics g, MapViewInfo ViewInfo)
		{
			var p1 = ViewInfo.MapToControl(new Point(m_Location.X, m_Location.Y));
			var p2 = ViewInfo.MapToControl(new Point(m_Location.Right, m_Location.Bottom));

			Brush borderBrush = new SolidBrush(m_Color);
			var borderPen = new Pen(borderBrush);

			g.DrawRectangle(borderPen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);

			if (m_Fill)
			{
				Brush fillBrush = new SolidBrush(m_FillColor);

				g.FillRectangle(fillBrush, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
			}
		}
		#endregion
	}
	#endregion

	#region MapCross
	/// <summary>
	///     A cross displayed either at a given location or at the center of the screen
	/// </summary>
	public class MapCross : IMapDrawable
	{
		/// <summary>
		///     The map coordinates at which the cross is drawn
		/// </summary>
		private Point m_Location;

		/// <summary>
		///     The color that the cross should use
		/// </summary>
		private Color m_Color;

		/// <summary>
		///     The map on which the object is drawn
		/// </summary>
		private readonly Maps m_Map;

		/// <summary>
		///     The length of a segment composing the cross in pixels
		/// </summary>
		private int m_Length;

		/// <summary>
		///     The color of the cross
		/// </summary>
		public Color Color { get { return m_Color; } set { m_Color = value; } }

		/// <summary>
		///     The length of each segment composing the cross ( in pixels )
		/// </summary>
		public int Length { get { return m_Length; } set { m_Length = value; } }

		/// <summary>
		///     The point at which the cross is drawn
		/// </summary>
		public Point Location { get { return m_Location; } set { m_Location = value; } }

		/// <summary>
		///     Creates a cross that is displayed at a given location on a given map
		/// </summary>
		/// <param name="segmentLength">The length of each cross segment</param>
		/// <param name="color">The color of the cross</param>
		/// <param name="location">The location of the cross</param>
		/// <param name="map">The map on which the cross lies on</param>
		public MapCross(int segmentLength, Color color, Point location, Maps map)
		{
			m_Length = segmentLength;
			m_Color = color;
			m_Location = location;
			m_Map = map;
		}

		#region IMapDrawable Members
		/// <summary>
		///     Evaluates whether the cross is visible on the given view
		/// </summary>
		/// <param name="bounds">The bounds of the map view (in map coordinates)</param>
		/// <param name="map">The map displayed</param>
		/// <returns>True is the cross is visible, false otherwise</returns>
		public bool IsVisible(Rectangle bounds, Maps map)
		{
			if ((m_Map != map) && (m_Map != Maps.AllMaps))
				return false;

			if ((m_Location.X > bounds.Left) && (m_Location.X < bounds.Right) && (m_Location.Y > bounds.Top) &&
				(m_Location.Y < bounds.Bottom))
				return true;

			return false;
		}

		/// <summary>
		///     Draws the rectangle on the provided Graphics
		/// </summary>
		/// <param name="g">The graphics on which the drawing happens</param>
		/// <param name="ViewInfo">Information about the current map view</param>
		public void Draw(Graphics g, MapViewInfo ViewInfo)
		{
			var p = ViewInfo.MapToControl(m_Location);

			var x = p.X;
			var y = p.Y;

			Brush brush = new SolidBrush(m_Color);
			var pen = new Pen(brush);

			g.DrawLine(pen, x - m_Length, y, x + m_Length, y);
			g.DrawLine(pen, x, y - m_Length, x, y + m_Length);
		}
		#endregion
	}
	#endregion

	#region MapCircle
	/// <summary>
	///     A circle displayed ont he map
	/// </summary>
	public class MapCircle : IMapDrawable
	{
		/// <summary>
		///     The map on which the circle is drawn
		/// </summary>
		private readonly Maps m_Map;

		/// <summary>
		///     The location at which the circle is drawn
		/// </summary>
		private Point m_Location;

		/// <summary>
		///     The radius of the circle
		/// </summary>
		private int m_Radius;

		/// <summary>
		///     The color of the border
		/// </summary>
		private Color m_Color;

		/// <summary>
		///     The color of the fill
		/// </summary>
		private Color m_FillColor;

		/// <summary>
		///     States whether the circle should be filled or not
		/// </summary>
		private readonly bool m_Fill;

		/// <summary>
		///     The location of the center of the circle
		/// </summary>
		public Point Location { get { return m_Location; } set { m_Location = value; } }

		/// <summary>
		///     The radius of the circle in map units
		/// </summary>
		public int Radius { get { return m_Radius; } set { m_Radius = value; } }

		/// <summary>
		///     Gets or sets the color for circle border
		/// </summary>
		public Color Color { get { return m_Color; } set { m_Color = value; } }

		/// <summary>
		///     Gets or sets the fill color of the circle
		/// </summary>
		public Color FillColor { get { return m_FillColor; } set { m_FillColor = value; } }

		/// <summary>
		///     Creates a MapCircle object at a given location, without any fill
		/// </summary>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="location">The location at which the circle is displayed</param>
		/// <param name="map">The map on which the circle is displayed</param>
		/// <param name="color">The color of the border</param>
		public MapCircle(int radius, Point location, Maps map, Color color)
		{
			m_Radius = radius;
			m_Map = map;
			m_Location = location;
			m_Color = color;
			m_Fill = false;
		}

		/// <summary>
		///     Creates a MapCircle object at a given location, filled inside
		/// </summary>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="location">The location at which the circle is displayed</param>
		/// <param name="map">The map on which the circle is displayed</param>
		/// <param name="color">The color of the border</param>
		/// <param name="fillColor">The color of the fill</param>
		public MapCircle(int radius, Point location, Maps map, Color color, Color fillColor)
		{
			m_Radius = radius;
			m_Map = map;
			m_Location = location;
			m_Color = color;
			m_FillColor = fillColor;
			m_Fill = true;
		}

		#region IMapDrawable Members
		/// <summary>
		///     Decided whether the circle is visible on the specified map view
		/// </summary>
		/// <param name="bounds">The bounds of the map portion currently displayed</param>
		/// <param name="map">The map currently displayed</param>
		/// <returns>True if the circle is visible, false otherwise</returns>
		public bool IsVisible(Rectangle bounds, Maps map)
		{
			if ((m_Map != map) && (m_Map != Maps.AllMaps))
				return false;

			if ((m_Location.X - m_Radius > bounds.Right) || (m_Location.X + m_Radius < bounds.Left) ||
				(m_Location.Y - m_Radius > bounds.Bottom) || (m_Location.Y + m_Radius < bounds.Top))
				return false;

			return true;
		}

		/// <summary>
		///     Draws the circle
		/// </summary>
		/// <param name="g">The Graphics object used for the drawing</param>
		/// <param name="ViewInfo">Information about the current map view</param>
		public void Draw(Graphics g, MapViewInfo ViewInfo)
		{
			// Draw at specified location
			var p = ViewInfo.MapToControl(m_Location);

			var x = p.X;
			var y = p.Y;

			Brush brush = new SolidBrush(m_Color);
			var pen = new Pen(brush);

			// Change radius accordingly to zoom level
			var radius = ViewInfo.MapToControl(m_Radius);

			// Draw the circle
			g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);

			if (m_Fill)
			{
				// Fill it
				brush = new SolidBrush(m_FillColor);
				g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
			}
		}
		#endregion
	}
	#endregion
}