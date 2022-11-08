#region Header
// /*
//  *    2018 - Pandora - SpawnDrawObject.cs
//  */
#endregion

#region References
using System.Drawing;

using TheBox.Data;
#endregion

namespace TheBox.MapViewer.DrawObjects
{
	/// <summary>
	///     Summary description for SpawnDrawObject.
	/// </summary>
	public class SpawnDrawObject : IMapDrawable
	{
		/// <summary>
		///     Gets or sets the SpawnEntry represented by this spawn draw object
		/// </summary>
		public SpawnEntry Spawn { get; set; }

		public SpawnDrawObject(SpawnEntry spawn)
		{
			Spawn = spawn;
		}

		#region IMapDrawable Members
		public bool IsVisible(Rectangle bounds, Maps map)
		{
			if (Spawn.Map != (int)map)
			{
				return false;
			}

			if (Spawn.X >= bounds.Left && Spawn.X <= bounds.Right && Spawn.Y >= bounds.Top && Spawn.Y <= bounds.Bottom)
			{
				return true;
			}

			return false;
		}

		public void Draw(Graphics g, MapViewInfo ViewInfo)
		{
			var c = ViewInfo.MapToControl(new Point(Spawn.X, Spawn.Y));

			var x1 = c.X - 3;
			var x2 = c.X + 3;
			var y1 = c.Y - 3;
			var y2 = c.Y + 3;

			var color = Pandora.Profile.Travel.SpawnColor;

			var pen = new Pen(color);

			g.DrawLine(pen, x1, y1, x2, y2);
			g.DrawLine(pen, x1, y2, x2, y1);
			g.DrawLine(pen, c.X, y1, c.X, y2);
			g.DrawLine(pen, x1, c.Y, x2, c.Y);

			pen.Dispose();
		}
		#endregion
	}
}