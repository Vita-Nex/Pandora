#region Header
// /*
//  *    2018 - MapViewer - Args.cs
//  */
#endregion

#region References
using System;
using System.Drawing;

using TheBox.MapViewer.DrawObjects;
#endregion

namespace TheBox.MapViewer
{
	/// <summary>
	///     Occurs when a mouse pointer hovers over a draw object
	/// </summary>
	public delegate void MouseOnDrawObjectEventHandler(object sender, DrawObjectEventArgs e);

	/// <summary>
	///     Contains data for events related to map draw objects
	/// </summary>
	public class DrawObjectEventArgs : EventArgs
	{
		private readonly IMapDrawable m_DrawObject;
		private readonly Point m_Point;

		/// <summary>
		///     Gets the IMapDrawable object contained in this args
		/// </summary>
		public IMapDrawable DrawObject { get { return m_DrawObject; } }

		/// <summary>
		///     Gets the location on the control surface of the draw object
		/// </summary>
		public Point Point { get { return m_Point; } }

		/// <summary>
		///     Creates a new EventArgs for use with draw objects
		/// </summary>
		/// <param name="drawobject">The IMapDrawable object used as data for this args</param>
		/// <param name="point">The point that originated the event</param>
		public DrawObjectEventArgs(IMapDrawable drawobject, Point point)
		{
			m_DrawObject = drawobject;
			m_Point = point;
		}
	}
}