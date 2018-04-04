#region Header
// /*
//  *    2018 - Pandora - RoofRect.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Defines the slope location for a roof piece
	/// </summary>
	public enum Slope
	{
		Left,
		Right,
		Top,
		Bottom,
		None
	}

	/// <summary>
	///     Defines a rectangle added to the roof
	/// </summary>
	public class RoofRect : ICloneable
	{
		private readonly bool m_GoesUp;
		private readonly bool m_Tent;
		private readonly bool m_Sloped;
		private readonly Slope m_Slope;

		/// <summary>
		///     Gets or sets the rectangle bounds
		/// </summary>
		public Rectangle Rectangle { get; set; }

		/// <summary>
		///     Gets the orientation of the rectangle
		/// </summary>
		public bool GoesUp { get { return m_GoesUp; } }

		/// <summary>
		///     States whether the rectangle represents a tent roof
		/// </summary>
		public bool Tent { get { return m_Tent; } }

		/// <summary>
		///     States whether the roof is sloped (half roof)
		/// </summary>
		public bool Sloped { get { return m_Sloped; } }

		/// <summary>
		///     Gets the slope type for this roof
		/// </summary>
		public Slope Slope { get { return m_Slope; } }

		/// <summary>
		///     Creates a new roofing section rectangle
		/// </summary>
		/// <param name="rect">The bounds of the rectangle</param>
		/// <param name="goesUp">Specifies the orientation of the rectangle</param>
		/// <param name="tent">Specifies that the rectangle is tent shaped</param>
		/// <param name="sloped">Specifies that the rectangle is sloped (half roof)</param>
		/// <param name="slope">The slope side if the piece is sloped</param>
		public RoofRect(Rectangle rect, bool goesUp, bool tent, bool sloped, Slope slope)
		{
			Rectangle = rect;
			m_GoesUp = goesUp;
			m_Tent = tent;
			m_Sloped = sloped;
			m_Slope = slope;
		}

		#region ICloneable Members
		public object Clone()
		{
			return new RoofRect(Rectangle, m_GoesUp, m_Tent, m_Sloped, m_Slope);
		}
		#endregion
	}
}