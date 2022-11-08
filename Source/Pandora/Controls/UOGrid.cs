#region Header
// /*
//  *    2018 - Pandora - UOGrid.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Data;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for UOGrid.
	/// </summary>
	public class UOGrid : Control
	{
		public UOGrid()
		{
			// Flickering fix
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Selection = new List<Point>();
			// Issue 10 - End
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Variables
		/// <summary>
		///     The current drawing mode
		/// </summary>
		protected GridMode m_GridMode = GridMode.Rectanlge;

		/// <summary>
		///     The spacing of the grid in pixels
		/// </summary>
		protected int m_GridSpacing = 16;

		/// <summary>
		///     The matrix representing the selected cells
		/// </summary>
		protected UOMatrix m_Matrix;

		/// <summary>
		///     The X coordinate of the cell the mouse is over
		/// </summary>
		protected int m_X;

		/// <summary>
		///     The X coordinate of the cell the mouse is over
		/// </summary>
		protected int m_Y;

		/// <summary>
		///     Contains the cells currently selected on the control
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		protected List<Point> m_Selection;
		// Issue 10 - End

		/// <summary>
		///     The starting point of the rectangle
		/// </summary>
		private Point m_RectStart;

		/// <summary>
		///     The ending point of the rectanlge
		/// </summary>
		private Point m_RectEnd;

		/// <summary>
		///     States whether a rectangle is being drawn
		/// </summary>
		private bool m_DrawingRect;

		/// <summary>
		///     The color table used in conjunction with the Tile Matrix
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private Dictionary<int, int> m_ColorTable;

		// Issue 10 - End
		#endregion

		#region Events
		/// <summary>
		///     Occurs when the user clicks a cell in Single mode
		/// </summary>
		public event GridClickEventHandler GridClick;

		/// <summary>
		///     Occurs when the user draws a rectangle in Rectangle mode
		/// </summary>
		public event GridRectEventHandler GridRect;
		#endregion

		#region Colors
		protected Color m_GridColor = Color.LightGray;
		protected Color m_SelectedCellColor = Color.Teal;
		protected Color m_MouseOverColor = Color.Red;

		/// <summary>
		///     Gets or sets the color of the grid lines
		/// </summary>
		[Category("UOGrid"), Description("The color of the grid lines")]
		public virtual Color GridColor
		{
			get => m_GridColor;
			set
			{
				if (m_GridColor != value)
				{
					m_GridColor = value;
					Refresh();
				}
			}
		}

		/// <summary>
		///     Gets or sets the color of a selected cell
		/// </summary>
		[Category("UOGrid"), Description("The color for a cell when it's in selected state")]
		public virtual Color SelectedCellColor
		{
			get => m_SelectedCellColor;
			set
			{
				if (m_SelectedCellColor == value)
				{
					m_SelectedCellColor = value;
					Refresh();
				}
			}
		}

		/// <summary>
		///     Gets or sets the color used to highlight cells when the mouse is moving on the grid
		/// </summary>
		[Category("UOGrid"), Description("The color used for a cell when the mouse is moving over it")]
		public virtual Color MouseOverColor
		{
			get => m_MouseOverColor;
			set
			{
				if (m_MouseOverColor != value)
				{
					m_MouseOverColor = value;
					Refresh();
				}
			}
		}

		[Category("UOGrid"), Description("The color used to draw the selection rectangle")]
		/// <summary>
		/// Gets or sets the color used to draw the selection rectanlge
		/// </summary>
		public Color RectColor { get; set; } = Color.Red;
		#endregion

		#region Public Properties
		[Category("UOGrid"), Description("The width and height of each cell in pixels")]
		/// <summary>
		/// Gets or sets the Grid Spacing
		/// </summary>
		public virtual int GridSpacing
		{
			get => m_GridSpacing;
			set
			{
				if (m_GridSpacing != value)
				{
					m_GridSpacing = value;

					ResizeMatrix();

					Refresh();
				}
			}
		}

		[Browsable(false)]
		/// <summary>
		/// Gets or sets the current drawing mode
		/// </summary>
		public GridMode GridMode { get => m_GridMode; set => m_GridMode = value; }

		/// <summary>
		///     Gets or sets the color table used for the display of the items in the matrix
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public virtual Dictionary<int, int> ColorTable
		// Issue 10 - End
		{
			get => m_ColorTable;
			set => m_ColorTable = value;
		}
		#endregion

		#region Protected Properties
		/// <summary>
		///     Gets the matrix representing the map cells
		/// </summary>
		protected virtual UOMatrix Matrix
		{
			get
			{
				if (m_Matrix == null)
				{
					var width = (Width / m_GridSpacing) + 1;
					var height = (Height / m_GridSpacing) + 1;

					m_Matrix = new UOMatrix(width, height);
				}
				return m_Matrix;
			}
		}

		/// <summary>
		///     Gets the size in pixels of a cell
		/// </summary>
		protected virtual Size CellSize => new Size(m_GridSpacing, m_GridSpacing);
		#endregion

		/// <summary>
		///     The control is being painted: review the matrix to apply the correct color
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			var size = CellSize;

			Brush SelectedBrush = new SolidBrush(m_SelectedCellColor);
			Brush HighlightBrush =
				new SolidBrush(Color.FromArgb(150, m_MouseOverColor.R, m_MouseOverColor.G, m_MouseOverColor.B));

			for (var x = 0; x < Matrix.Width; x++)
			{
				for (var y = 0; y < Matrix.Height; y++)
				{
					var p = new Point(x * m_GridSpacing, y * m_GridSpacing);
					var rect = new Rectangle(p, size);

					if (m_Selection.Contains(new Point(x, y)))
					{
						e.Graphics.FillRectangle(SelectedBrush, rect);
					}
					else if (m_ColorTable != null)
					{
						var item = Matrix[x, y];

						if (item != 0)
						{
							// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert

							if (m_ColorTable.TryGetValue(item, out var c))
							{
								return;
							}

							object o = c;
							if (o == null)
							{
								Brush colorBrush = new SolidBrush((Color)o);
								// Issue 10 - End

								e.Graphics.FillRectangle(colorBrush, rect);
							}
						}
					}

					// Highlight cell: alpha blended over anything below
					if (x == m_X && y == m_Y)
					{
						// Mouse over this cell
						e.Graphics.FillRectangle(HighlightBrush, rect);
					}
				}
			}

			SelectedBrush.Dispose();
			HighlightBrush.Dispose();

			DrawGrid(e.Graphics);
			DrawSelectionRect(e.Graphics);
		}

		/// <summary>
		///     Draws the selection rectangle
		/// </summary>
		/// <param name="g">The graphics to draw on</param>
		protected void DrawSelectionRect(Graphics g)
		{
			// Draw selection rectangle
			if (m_DrawingRect)
			{
				var r = GetRect(m_RectStart, m_RectEnd);

				var x = r.X * m_GridSpacing;
				var y = r.Y * m_GridSpacing;
				var w = (r.Width + 1) * m_GridSpacing;
				var h = (r.Height + 1) * m_GridSpacing;

				var rectPen = new Pen(RectColor);

				g.DrawRectangle(rectPen, x, y, w, h);

				rectPen.Dispose();
			}
		}

		/// <summary>
		///     Draws the grid for the current control
		/// </summary>
		/// <param name="g">The graphics to draw on</param>
		protected virtual void DrawGrid(Graphics g)
		{
			var GridPen = new Pen(m_GridColor);

			// Draw grid: coulmns
			for (var x = 0; x < Width; x += m_GridSpacing)
			{
				g.DrawLine(GridPen, x, 0, x, Height - 1);
			}

			// Draw grid: rows
			for (var y = 0; y < Height; y += m_GridSpacing)
			{
				g.DrawLine(GridPen, 0, y, Width - 1, y);
			}

			GridPen.Dispose();
		}

		/// <summary>
		///     The control's size has changed, update the matrix and refresh
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			ResizeMatrix();
		}

		/// <summary>
		///     Mouse moves on the control: update the highlighted cell if needed and refresh
		/// </summary>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (e.Button == MouseButtons.Left && m_GridMode == GridMode.Rectanlge)
			{
				// Do drawing here
				var cell = GetCellAt(new Point(e.X, e.Y));

				if (m_RectEnd != cell)
				{
					m_RectEnd = cell;
					Refresh();
				}
			}
			else
			{
				var loc = PointToClient(MousePosition);

				var x = loc.X / m_GridSpacing;
				var y = loc.Y / m_GridSpacing;

				if (x != m_X || y != m_Y)
				{
					m_X = x;
					m_Y = y;

					Refresh();
				}
			}
		}

		/// <summary>
		///     Mouse leaves the control: remove any highlight
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			m_X = -1;
			m_Y = -1;

			Refresh();
		}

		/// <summary>
		///     Resizes the matrix accordingly to the current size of the control
		/// </summary>
		protected void ResizeMatrix()
		{
			var width = (Width / m_GridSpacing) + 1;
			var height = (Height / m_GridSpacing) + 1;

			Matrix.Width = width;
			Matrix.Height = height;
		}

		/// <summary>
		///     Gets the matrix cell at the given control coordinate
		/// </summary>
		/// <param name="loc">The point on the control</param>
		/// <returns>The point on the matrix</returns>
		protected Point GetCellAt(Point loc)
		{
			var x = loc.X / m_GridSpacing;
			var y = loc.Y / m_GridSpacing;

			return new Point(x, y);
		}

		/// <summary>
		///     Mouse down: either click or select a rectanlge
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			var cell = GetCellAt(new Point(e.X, e.Y));

			if (m_GridMode == GridMode.Single)
			{
				GridClick?.Invoke(this, new GridClickEventArgs(cell));
			}
			else if (m_GridMode == GridMode.Rectanlge)
			{
				// User starts drawing a rectangle
				m_RectStart = cell;
				m_RectEnd = cell;

				m_DrawingRect = true;

				Refresh();
			}
		}

		/// <summary>
		///     Mouse up: finalize rectangle if in rectangle mode
		/// </summary>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (e.Button == MouseButtons.Left && m_GridMode == GridMode.Rectanlge)
			{
				m_DrawingRect = false;

				// End rectangle drawing
				if (m_RectStart != m_RectEnd)
				{
					GridRect?.Invoke(this, new GridRectEventArgs(GetRect(m_RectStart, m_RectEnd)));
				}
			}
		}

		/// <summary>
		///     Gets the normalized rectangle from two points
		/// </summary>
		/// <param name="p1">Point 1</param>
		/// <param name="p2">Point 2</param>
		/// <returns>The resulting rectanlge</returns>
		private Rectangle GetRect(Point p1, Point p2)
		{
			var x = Math.Min(p1.X, p2.X);
			var y = Math.Min(p1.Y, p2.Y);

			var w = Math.Abs(p1.X - p2.X);
			var h = Math.Abs(p1.Y - p2.Y);

			return new Rectangle(x, y, w, h);
		}
	}

	/// <summary>
	///     Delegates handling of a single click on the UOGrid
	/// </summary>
	public delegate void GridClickEventHandler(object sender, GridClickEventArgs e);

	public delegate void GridRectEventHandler(object sender, GridRectEventArgs e);

	public class GridClickEventArgs : EventArgs
	{
		/// <summary>
		///     Gets the cell that has been clicked
		/// </summary>
		public Point Cell { get; }

		public GridClickEventArgs(Point cell)
		{
			Cell = cell;
		}
	}

	public class GridRectEventArgs : EventArgs
	{
		/// <summary>
		///     Gets the Rectangle selected
		/// </summary>
		public Rectangle Rect { get; }

		public GridRectEventArgs(Rectangle rect)
		{
			Rect = rect;
		}
	}

	/// <summary>
	///     The interaction modes for the GridCell
	/// </summary>
	public enum GridMode
	{
		/// <summary>
		///     The grid reacts to a click by selecting a single cell
		/// </summary>
		Single,

		/// <summary>
		///     The grid reacts to a click by selecting a range of cells
		/// </summary>
		Rectanlge
	}
}