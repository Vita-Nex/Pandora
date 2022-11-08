#region Header
// /*
//  *    2018 - Pandora - WorldMap.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Data;
using TheBox.MapViewer;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for WorldMap.
	/// </summary>
	public class WorldMap : Form
	{
		private ToolBar tBar;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private ToolBarButton bBig;
		private ToolBarButton bMap0;
		private ToolBarButton bMap1;
		private ToolBarButton bMap2;
		private ToolBarButton bMap3;
		private ToolBarButton bClose;

		private Maps m_Map;
		private bool m_Big;
		private PictureBox Img;
		private ToolBarButton bMap4;
		private readonly ToolBarButton[] m_Buttons;

		public WorldMap()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_Big = Pandora.Profile.Travel.WorldMapBig;
			m_Map = Pandora.Map.Map;

			bClose.Text = Pandora.Localization.TextProvider["Common.Exit"];

			tBar.ImageList = new ImageList
			{
				ImageSize = new Size(1, 1)
			};

			Pandora.Localization.LocalizeControl(this);

			m_Buttons = new[] { bMap0, bMap1, bMap2, bMap3, bMap4 };

			InitToolBar();
			DoDisplay();
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
			var resources = new System.Resources.ResourceManager(typeof(WorldMap));
			this.tBar = new System.Windows.Forms.ToolBar();
			this.bBig = new System.Windows.Forms.ToolBarButton();
			this.bMap0 = new System.Windows.Forms.ToolBarButton();
			this.bMap1 = new System.Windows.Forms.ToolBarButton();
			this.bMap2 = new System.Windows.Forms.ToolBarButton();
			this.bMap3 = new System.Windows.Forms.ToolBarButton();
			this.bClose = new System.Windows.Forms.ToolBarButton();
			this.Img = new System.Windows.Forms.PictureBox();
			this.bMap4 = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// tBar
			// 
			this.tBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBar.Buttons.AddRange(
				new System.Windows.Forms.ToolBarButton[]
					{this.bBig, this.bMap0, this.bMap1, this.bMap2, this.bMap3, this.bMap4, this.bClose});
			this.tBar.ButtonSize = new System.Drawing.Size(58, 18);
			this.tBar.DropDownArrows = true;
			this.tBar.Location = new System.Drawing.Point(0, 0);
			this.tBar.Name = "tBar";
			this.tBar.ShowToolTips = true;
			this.tBar.Size = new System.Drawing.Size(736, 29);
			this.tBar.TabIndex = 0;
			this.tBar.Wrappable = false;
			this.tBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tBar_ButtonClick);
			// 
			// bBig
			// 
			this.bBig.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.bBig.Text = "World.Big";
			// 
			// bClose
			// 
			this.bClose.Text = "Common.Exit";
			// 
			// Img
			// 
			this.Img.Location = new System.Drawing.Point(0, 26);
			this.Img.Name = "Img";
			this.Img.Size = new System.Drawing.Size(736, 448);
			this.Img.TabIndex = 1;
			this.Img.TabStop = false;
			this.Img.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Img_MouseDown);
			// 
			// WorldMap
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 479);
			this.Controls.Add(this.Img);
			this.Controls.Add(this.tBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "WorldMap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "World.WorldMap";
			this.Load += new System.EventHandler(this.WorldMap_Load);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Initializes the tool bar hiding the buttons corresponding to disabled maps
		/// </summary>
		private void InitToolBar()
		{
			if (m_Big)
			{
				bBig.Pushed = true;
				bBig.Text = Pandora.Localization.TextProvider["World.Big"];
			}
			else
			{
				bBig.Pushed = false;
				bBig.Text = Pandora.Localization.TextProvider["World.Small"];
			}

			for (var i = 0; i < Pandora.Profile.Travel.MapCount; i++)
			{
				if (Pandora.Profile.Travel.EnabledMaps[i])
				{
					m_Buttons[i].Visible = true;
					m_Buttons[i].Text = Pandora.Profile.Travel.MapNames[i];
				}
				else
				{
					m_Buttons[i].Visible = false;
				}
			}
		}

		/// <summary>
		///     Displays the selected image and resizes the form accordingly
		/// </summary>
		private void DoDisplay()
		{
			var bmp = Pandora.Profile.Travel.GetMapImage((int)m_Map, m_Big);

			if (bmp == null)
			{
				m_Buttons[(int)m_Map].Enabled = false;
				Pandora.Log.WriteError(null, String.Format("Display of enabled map {0} failed.", (int)m_Map));

				_ = MessageBox.Show(Pandora.Localization.TextProvider["World.NoImage"]);
			}
			else
			{
				if (Pandora.Profile.Travel.ShowSpawns)
				{
					AddSpawns(bmp);
				}

				Width = bmp.Width + (SystemInformation.BorderSize.Width * 2);
				Height = bmp.Height + tBar.Height + SystemInformation.BorderSize.Height + SystemInformation.CaptionHeight;

				Img.Width = bmp.Width;
				Img.Height = bmp.Height;

				Img.Image = bmp;
			}
		}

		private void AddSpawns(Bitmap bmp)
		{
			var xscale = bmp.Width / (double)MapSizes.GetSize((int)m_Map).Width;
			var yscale = bmp.Height / (double)MapSizes.GetSize((int)m_Map).Height;

			var color = Pandora.Profile.Travel.SpawnColor;

			foreach (SpawnEntry spawn in SpawnData.SpawnProvider.Spawns)
			{
				if (spawn.Map == (int)m_Map)
				{
					var x = (int)(spawn.X * xscale);
					var y = (int)(spawn.Y * yscale);

					if (x >= 0 && y >= 0 && x < bmp.Width && y < bmp.Height)
					{
						bmp.SetPixel(x, y, color);
					}
				}
			}
		}

		private void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == bBig)
			{
				m_Big = bBig.Pushed;

				Pandora.Profile.Travel.WorldMapBig = m_Big;

				bBig.Text = m_Big
					? Pandora.Localization.TextProvider["World.Big"]
					: Pandora.Localization.TextProvider["World.Small"];
			}
			else if (e.Button == bClose)
			{
				Close();
			}
			else if (e.Button == bMap0)
			{
				m_Map = Maps.Felucca;
			}
			else if (e.Button == bMap1)
			{
				m_Map = Maps.Trammel;
			}
			else if (e.Button == bMap2)
			{
				m_Map = Maps.Ilshenar;
			}
			else if (e.Button == bMap3)
			{
				m_Map = Maps.Malas;
			}
			else if (e.Button == bMap4)
			{
				m_Map = Maps.Tokuno;
			}

			DoDisplay();
		}

		private void Img_MouseDown(object sender, MouseEventArgs e)
		{
			var mapSize = MapSizes.GetSize((int)m_Map);

			var x = e.X * mapSize.Width / Img.Width;
			var y = e.Y * mapSize.Height / Img.Height;

			Pandora.Map.Map = m_Map;
			Pandora.Map.Center = new Point(x, y);
		}

		private void WorldMap_Load(object sender, EventArgs e)
		{
			Pandora.Profile.Travel.ShowSpawnsChanged += Travel_ShowSpawnsChanged;
		}

		private void Travel_ShowSpawnsChanged(object sender, EventArgs e)
		{
			DoDisplay();
		}
	}
}