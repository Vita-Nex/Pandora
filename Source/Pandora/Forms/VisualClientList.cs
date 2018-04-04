#region Header
// /*
//  *    2018 - Pandora - VisualClientList.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using TheBox.BoxServer;
using TheBox.MapViewer;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for VisualClientList.
	/// </summary>
	public class VisualClientList : Form
	{
		private ToolBar tBar;
		private ToolBarButton map0;
		private ToolBarButton map1;
		private ToolBarButton map2;
		private ToolBarButton map3;
		private ToolBarButton bExit;
		private ToolBarButton bRefresh;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public VisualClientList()
		{
			InitializeComponent();
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Table = new Dictionary<Point, List<ClientEntry>>();
			// Issue 10 - End
			Pandora.Localization.LocalizeControl(this);

			tBar.ImageList = new ImageList();
			tBar.ImageList.ImageSize = new Size(1, 1);

			bExit.Text = Pandora.Localization.TextProvider["Common.Exit"];
			bRefresh.Text = Pandora.Localization.TextProvider["Common.Refresh"];

			// Flickering fix
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		private int m_Map;

		private Image m_Image;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<ClientEntry> m_Clients;

		private readonly Dictionary<Point, List<ClientEntry>> m_Table;

		// Issue 10 - End
		private bool[,] m_Grid;

		private Point m_GoPoint = Point.Empty;

		private int Map
		{
			set
			{
				if (m_Image != null)
				{
					m_Image.Dispose();
				}

				m_Map = value;

				var filename = Path.Combine(Pandora.Profile.BaseFolder, "Maps");
				filename = Path.Combine(filename, string.Format("map{0}big.jpg", value));

				if (!File.Exists(filename))
				{
					m_Image = null;
					return;
				}

				try
				{
					m_Image = Image.FromFile(filename);
				}
				catch
				{
					return;
				}

				// Resize
				Size = new Size(m_Image.Width + 28, m_Image.Height + 76);
				Refresh();
			}
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			var resources = new System.Resources.ResourceManager(typeof(VisualClientList));
			this.tBar = new System.Windows.Forms.ToolBar();
			this.map0 = new System.Windows.Forms.ToolBarButton();
			this.map1 = new System.Windows.Forms.ToolBarButton();
			this.map2 = new System.Windows.Forms.ToolBarButton();
			this.map3 = new System.Windows.Forms.ToolBarButton();
			this.bRefresh = new System.Windows.Forms.ToolBarButton();
			this.bExit = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// tBar
			// 
			this.tBar.Buttons.AddRange(
				new System.Windows.Forms.ToolBarButton[] {this.map0, this.map1, this.map2, this.map3, this.bRefresh, this.bExit});
			this.tBar.DropDownArrows = true;
			this.tBar.Location = new System.Drawing.Point(0, 0);
			this.tBar.Name = "tBar";
			this.tBar.ShowToolTips = true;
			this.tBar.Size = new System.Drawing.Size(424, 28);
			this.tBar.TabIndex = 0;
			this.tBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.tBar.Wrappable = false;
			this.tBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tBar_ButtonClick);
			// 
			// map0
			// 
			this.map0.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.map0.Tag = "0";
			this.map0.Text = "One";
			// 
			// map1
			// 
			this.map1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.map1.Tag = "1";
			// 
			// map2
			// 
			this.map2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.map2.Tag = "2";
			// 
			// map3
			// 
			this.map3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.map3.Tag = "3";
			// 
			// VisualClientList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 357);
			this.Controls.Add(this.tBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VisualClientList";
			this.Text = "VisualClientList";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VisualClientList_MouseDown);
			this.Load += new System.EventHandler(this.VisualClientList_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VisualClientList_MouseMove);
			this.ResumeLayout(false);
		}
		#endregion

		private void VisualClientList_Load(object sender, EventArgs e)
		{
			var buttons = new[] {map0, map1, map2, map3};

			for (var i = 0; i < 4; i++)
			{
				buttons[i].Visible = Pandora.Profile.Travel.EnabledMaps[i];

				if (Pandora.Profile.Travel.EnabledMaps[i])
				{
					buttons[i].Text = Pandora.Profile.Travel.MapNames[i];
				}
			}

			var msg = Pandora.BoxConnection.SendToServer(new ClientListRequest());

			var list = msg as ClientListMessage;

			if (list != null)
			{
				m_Clients = list.Clients;
			}
			else
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				m_Clients = new List<ClientEntry>();
				// Issue 10 - End
			}

			for (var i = 0; i < 4; i++)
			{
				if (Pandora.Profile.Travel.EnabledMaps[i])
				{
					tBar.Buttons[i].Pushed = true;
					Map = i;
					return;
				}
			}

			Close();
		}

		/// <summary>
		///     Paint the image and the clients
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (m_Image == null)
			{
				return;
			}

			var xBlocks = MapSizes.GetSize(m_Map).Width / 32;
			var yBlocks = MapSizes.GetSize(m_Map).Height / 32;

			m_Grid = new bool[xBlocks, yBlocks];
			m_Table.Clear();

			foreach (var client in m_Clients)
			{
				if (client.Map == m_Map)
				{
					var x = client.X / 32;
					var y = client.Y / 32;

					m_Grid[x, y] = true;

					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					List<ClientEntry> current;
					m_Table.TryGetValue(new Point(x, y), out current);
					// Issue 10 - End

					if (current != null)
					{
						current.Add(client);
					}
					else
					{
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						current = new List<ClientEntry>();
						current.Add(client);
						// Issue 10 - End

						m_Table[new Point(x, y)] = current;
					}
				}
			}

			// Draw the image
			e.Graphics.DrawImage(m_Image, 8, 40, m_Image.Width, m_Image.Height);

			// Draw the backgrounds
			for (var x = 0; x < xBlocks; x++)
			{
				for (var y = 0; y < yBlocks; y++)
				{
					if (m_Grid[x, y])
					{
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						Point p;
						if (m_Table.ContainsKey(p = new Point(x, y)))
						{
							var count = m_Table[p].Count;
							Brush backGridBrush = new SolidBrush(Color.Yellow);

							// Draw this background
							e.Graphics.FillRectangle(backGridBrush, 8 + x * 4, 40 + y * 4, 4, 4);

							backGridBrush.Dispose();
						}
						// Issue 10 - End
					}
				}
			}
		}

		private void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == bExit)
			{
				Close();
				return;
			}

			if (e.Button == bRefresh)
			{
				var msg = Pandora.BoxConnection.SendToServer(new ClientListRequest());
				var list = msg as ClientListMessage;

				if (msg != null)
				{
					m_Clients.Clear();
					m_Clients.AddRange(list.Clients);
				}

				Refresh();
				return;
			}

			foreach (ToolBarButton b in tBar.Buttons)
			{
				b.Pushed = false;
			}

			e.Button.Pushed = true;

			Map = int.Parse(e.Button.Tag as string);
		}

		private void VisualClientList_MouseMove(object sender, MouseEventArgs e)
		{
			// Show arrow hand for valid locations

			var x = e.X - 8;
			var y = e.Y - 40;

			if (x < 0 || y < 0 || x >= m_Image.Width - 1 || y >= m_Image.Height - 1)
				return;

			var xBlock = x / 4;
			var yBlock = y / 4;

			if (m_Grid == null)
				return;

			if (m_Grid[xBlock, yBlock])
			{
				Cursor = Cursors.Hand;
			}
			else
			{
				Cursor = Cursors.Arrow;
			}
		}

		private void VisualClientList_MouseDown(object sender, MouseEventArgs e)
		{
			var x = e.X - 8;
			var y = e.Y - 40;

			var xBlock = x / 4;
			var yBlock = y / 4;

			if (m_Grid[xBlock, yBlock])
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				List<ClientEntry> clients;
				m_Table.TryGetValue(new Point(xBlock, yBlock), out clients);
				// Issue 10 - End

				if (clients == null || clients.Count == 0)
					return;

				m_GoPoint = new Point(xBlock * 32 + 16, yBlock * 32 + 16);

				var title = string.Format("{0} clients - Go there", clients.Count);
				var sb = new StringBuilder();

				foreach (var entry in clients)
				{
					sb.AppendFormat("{0} [Acc: {1}]\r\n", entry.Name, entry.Account);
				}

				PopUpForm.PopUp(this, title, sb.ToString(), false, OnGo);
			}
		}

		private void OnGo()
		{
			if (m_GoPoint == Point.Empty)
				return;

			Pandora.Profile.Commands.DoGo(m_GoPoint.X, m_GoPoint.Y, Pandora.Map.GetMapHeight(m_GoPoint, m_Map), m_Map);
		}
	}
}