#region Header
// /*
//  *    2018 - Pandora - Doors.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.ArtViewer;
using TheBox.Buttons;
using TheBox.Data;
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Doors.
	/// </summary>
	public class Doors : UserControl
	{
		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private LinkLabel lnkDoor;
		private Label WestCCW;
		private Label EastCW;
		private Label WestCW;
		private Label EastCCW;
		private Label NorthCW;
		private Label SouthCCW;
		private Label NorthCCW;
		private Label SouthCW;

		private Label m_LabelFocus;

		private DoorEventArgs m_Door;
		private PortcullisEventArgs m_Portcullis;
		private Button bLock;
		private Button bUnlock;
		private BoxButton boxButton1;
		private BoxButton boxButton2;

		/// <summary>
		///     The list of all labels that hide/show
		/// </summary>
		private readonly Label[] m_AllLabels;

		/// <summary>
		///     Gets or sets the selected door
		/// </summary>
		private DoorEventArgs Door
		{
			get => m_Door;
			set
			{
				if (m_Portcullis != null)
				{
					m_Portcullis = null;

					foreach (var lab in m_AllLabels)
					{
						lab.Visible = true;
					}
				}

				m_Door = value;

				Pandora.Art.Art = Art.Items;
				Pandora.Art.Hue = 0;
				Pandora.Art.ArtIndex = m_Door.BaseID;
				Pandora.BoxForm.SelectSmallTab(SmallTabs.Art);

				lnkDoor.Text = m_Door.Name;
			}
		}

		/// <summary>
		///     Gets or sets the selected portcullis
		/// </summary>
		private PortcullisEventArgs Portcullis
		{
			get => m_Portcullis;
			set
			{
				if (m_Door != null)
				{
					m_Door = null;
				}

				foreach (var lab in m_AllLabels)
				{
					lab.Visible = false;
				}

				m_Portcullis = value;

				Pandora.Art.Art = Art.Items;
				Pandora.Art.Hue = 0;
				Pandora.Art.ArtIndex = m_Portcullis.ArtEW;
				Pandora.BoxForm.SelectSmallTab(SmallTabs.Art);

				lnkDoor.Text = m_Portcullis.Name;
			}
		}

		public Doors()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			try
			{
				m_AllLabels = new[] { WestCW, EastCW, EastCCW, SouthCCW, NorthCCW, SouthCW };

				// Set callbacks
				WestCW.Tag = new CommandCallback(PerformWestCW);
				WestCCW.Tag = new CommandCallback(PerformWestCCW);
				EastCCW.Tag = new CommandCallback(PerformEastCCW);
				EastCW.Tag = new CommandCallback(PerformEastCW);
				NorthCW.Tag = new CommandCallback(PerformNorthCW);
				NorthCCW.Tag = new CommandCallback(PerformNorthCCW);
				SouthCW.Tag = new CommandCallback(PerformSouthCW);
				SouthCCW.Tag = new CommandCallback(PerformSouthCCW);
			}
			catch
			{ } // VS
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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			var resources = new System.Resources.ResourceManager(typeof(Doors));
			this.WestCCW = new System.Windows.Forms.Label();
			this.EastCW = new System.Windows.Forms.Label();
			this.WestCW = new System.Windows.Forms.Label();
			this.EastCCW = new System.Windows.Forms.Label();
			this.NorthCW = new System.Windows.Forms.Label();
			this.SouthCCW = new System.Windows.Forms.Label();
			this.NorthCCW = new System.Windows.Forms.Label();
			this.SouthCW = new System.Windows.Forms.Label();
			this.lnkDoor = new System.Windows.Forms.LinkLabel();
			this.bLock = new System.Windows.Forms.Button();
			this.bUnlock = new System.Windows.Forms.Button();
			this.boxButton1 = new TheBox.Buttons.BoxButton();
			this.boxButton2 = new TheBox.Buttons.BoxButton();
			this.SuspendLayout();
			// 
			// WestCCW
			// 
			this.WestCCW.BackColor = System.Drawing.Color.White;
			this.WestCCW.Image = (System.Drawing.Image)resources.GetObject("WestCCW.Image");
			this.WestCCW.Location = new System.Drawing.Point(72, 0);
			this.WestCCW.Name = "WestCCW";
			this.WestCCW.Size = new System.Drawing.Size(68, 68);
			this.WestCCW.TabIndex = 0;
			this.WestCCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.WestCCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.WestCCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.WestCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// EastCW
			// 
			this.EastCW.BackColor = System.Drawing.Color.White;
			this.EastCW.Image = (System.Drawing.Image)resources.GetObject("EastCW.Image");
			this.EastCW.Location = new System.Drawing.Point(124, 72);
			this.EastCW.Name = "EastCW";
			this.EastCW.Size = new System.Drawing.Size(68, 68);
			this.EastCW.TabIndex = 1;
			this.EastCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.EastCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.EastCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.EastCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// WestCW
			// 
			this.WestCW.BackColor = System.Drawing.Color.White;
			this.WestCW.Image = (System.Drawing.Image)resources.GetObject("WestCW.Image");
			this.WestCW.Location = new System.Drawing.Point(0, 0);
			this.WestCW.Name = "WestCW";
			this.WestCW.Size = new System.Drawing.Size(68, 68);
			this.WestCW.TabIndex = 2;
			this.WestCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.WestCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.WestCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.WestCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// EastCCW
			// 
			this.EastCCW.BackColor = System.Drawing.Color.White;
			this.EastCCW.Image = (System.Drawing.Image)resources.GetObject("EastCCW.Image");
			this.EastCCW.Location = new System.Drawing.Point(52, 72);
			this.EastCCW.Name = "EastCCW";
			this.EastCCW.Size = new System.Drawing.Size(68, 68);
			this.EastCCW.TabIndex = 3;
			this.EastCCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.EastCCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.EastCCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.EastCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// NorthCW
			// 
			this.NorthCW.BackColor = System.Drawing.Color.White;
			this.NorthCW.Image = (System.Drawing.Image)resources.GetObject("NorthCW.Image");
			this.NorthCW.Location = new System.Drawing.Point(356, 0);
			this.NorthCW.Name = "NorthCW";
			this.NorthCW.Size = new System.Drawing.Size(68, 68);
			this.NorthCW.TabIndex = 4;
			this.NorthCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.NorthCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.NorthCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.NorthCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// SouthCCW
			// 
			this.SouthCCW.BackColor = System.Drawing.Color.White;
			this.SouthCCW.Image = (System.Drawing.Image)resources.GetObject("SouthCCW.Image");
			this.SouthCCW.Location = new System.Drawing.Point(304, 72);
			this.SouthCCW.Name = "SouthCCW";
			this.SouthCCW.Size = new System.Drawing.Size(68, 68);
			this.SouthCCW.TabIndex = 5;
			this.SouthCCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.SouthCCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.SouthCCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.SouthCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// NorthCCW
			// 
			this.NorthCCW.BackColor = System.Drawing.Color.White;
			this.NorthCCW.Image = (System.Drawing.Image)resources.GetObject("NorthCCW.Image");
			this.NorthCCW.Location = new System.Drawing.Point(428, 0);
			this.NorthCCW.Name = "NorthCCW";
			this.NorthCCW.Size = new System.Drawing.Size(68, 68);
			this.NorthCCW.TabIndex = 6;
			this.NorthCCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.NorthCCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.NorthCCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.NorthCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// SouthCW
			// 
			this.SouthCW.BackColor = System.Drawing.Color.White;
			this.SouthCW.Image = (System.Drawing.Image)resources.GetObject("SouthCW.Image");
			this.SouthCW.Location = new System.Drawing.Point(376, 72);
			this.SouthCW.Name = "SouthCW";
			this.SouthCW.Size = new System.Drawing.Size(68, 68);
			this.SouthCW.TabIndex = 7;
			this.SouthCW.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
			this.SouthCW.MouseEnter += new System.EventHandler(this.LabelEnter);
			this.SouthCW.MouseLeave += new System.EventHandler(this.LabelLeave);
			this.SouthCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WestCCW_MouseDown);
			// 
			// lnkDoor
			// 
			this.lnkDoor.Location = new System.Drawing.Point(180, 4);
			this.lnkDoor.Name = "lnkDoor";
			this.lnkDoor.Size = new System.Drawing.Size(136, 32);
			this.lnkDoor.TabIndex = 8;
			this.lnkDoor.TabStop = true;
			this.lnkDoor.Text = "Doors.Select";
			this.lnkDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkDoor.Paint += new System.Windows.Forms.PaintEventHandler(this.lnkDoor_Paint);
			this.lnkDoor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkDoor_MouseDown);
			// 
			// bLock
			// 
			this.bLock.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bLock.Location = new System.Drawing.Point(148, 44);
			this.bLock.Name = "bLock";
			this.bLock.Size = new System.Drawing.Size(96, 23);
			this.bLock.TabIndex = 9;
			this.bLock.Text = "Doors.Lock";
			this.bLock.Click += new System.EventHandler(this.bLock_Click);
			// 
			// bUnlock
			// 
			this.bUnlock.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bUnlock.Location = new System.Drawing.Point(252, 44);
			this.bUnlock.Name = "bUnlock";
			this.bUnlock.Size = new System.Drawing.Size(96, 23);
			this.bUnlock.TabIndex = 10;
			this.bUnlock.Text = "Doors.Unlock";
			this.bUnlock.Click += new System.EventHandler(this.bUnlock_Click);
			// 
			// boxButton1
			// 
			this.boxButton1.AllowEdit = true;
			this.boxButton1.ButtonID = 76;
			this.boxButton1.Def = null;
			this.boxButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton1.IsActive = true;
			this.boxButton1.Location = new System.Drawing.Point(204, 80);
			this.boxButton1.Name = "boxButton1";
			this.boxButton1.Size = new System.Drawing.Size(88, 23);
			this.boxButton1.TabIndex = 11;
			this.boxButton1.Text = "boxButton1";
			// 
			// boxButton2
			// 
			this.boxButton2.AllowEdit = true;
			this.boxButton2.ButtonID = 77;
			this.boxButton2.Def = null;
			this.boxButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton2.IsActive = true;
			this.boxButton2.Location = new System.Drawing.Point(204, 112);
			this.boxButton2.Name = "boxButton2";
			this.boxButton2.Size = new System.Drawing.Size(88, 23);
			this.boxButton2.TabIndex = 12;
			this.boxButton2.Text = "boxButton2";
			// 
			// Doors
			// 
			this.Controls.Add(this.boxButton2);
			this.Controls.Add(this.boxButton1);
			this.Controls.Add(this.bUnlock);
			this.Controls.Add(this.bLock);
			this.Controls.Add(this.lnkDoor);
			this.Controls.Add(this.SouthCW);
			this.Controls.Add(this.NorthCCW);
			this.Controls.Add(this.SouthCCW);
			this.Controls.Add(this.NorthCW);
			this.Controls.Add(this.EastCCW);
			this.Controls.Add(this.WestCW);
			this.Controls.Add(this.EastCW);
			this.Controls.Add(this.WestCCW);
			this.Name = "Doors";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Doors_Load);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Image label paint
		/// </summary>
		private void LabelPaint(object sender, PaintEventArgs e)
		{
			var label = sender as Label;
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, label.Width - 1, label.Height - 1);

			if (m_LabelFocus != null && m_LabelFocus == label)
			{
				e.Graphics.DrawRectangle(pen, 2, 2, label.Width - 5, label.Height - 5);
			}

			pen.Dispose();
		}

		/// <summary>
		///     Mouse enters a label
		/// </summary>
		private void LabelEnter(object sender, EventArgs e)
		{
			m_LabelFocus = sender as Label;
			(sender as Label).Refresh();

			var id = 0;

			if (m_Portcullis != null)
			{
				if (m_LabelFocus == WestCCW)
				{
					id = m_Portcullis.ArtNS;
				}
				else if (m_LabelFocus == NorthCW)
				{
					id = m_Portcullis.ArtEW;
				}
			}
			else if (m_Door != null)
			{
				id = m_Door.BaseID + GetDoorOffset(m_LabelFocus);
			}

			Pandora.BoxForm.SelectSmallTab(SmallTabs.Art);
			Pandora.Art.RoomView = true;
			Pandora.Art.Hue = 0;
			Pandora.Art.Art = Art.Items;
			Pandora.Art.ArtIndex = id;
		}

		/// <summary>
		///     Mouse leaves a label
		/// </summary>
		private void LabelLeave(object sender, EventArgs e)
		{
			m_LabelFocus = null;
			(sender as Label).Refresh();
		}

		/// <summary>
		///     Paint the border for the door selector
		/// </summary>
		private void lnkDoor_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, lnkDoor.Width - 1, lnkDoor.Height - 1);
			pen.Dispose();
		}

		/// <summary>
		///     Link clicked: show menu
		/// </summary>
		private void lnkDoor_MouseDown(object sender, MouseEventArgs e)
		{
			Pandora.Doors.Menu.Show(lnkDoor, new Point(e.X, e.Y));
		}

		/// <summary>
		///     OnLoad
		/// </summary>
		private void Doors_Load(object sender, EventArgs e)
		{
			try
			{
				Pandora.Doors.DoorSelected += Doors_DoorSelected;
				Pandora.Doors.PortcullisSelected += Doors_PortcullisSelected;

				WestCW.ContextMenu = Pandora.cmModifiers;
				WestCCW.ContextMenu = Pandora.cmModifiers;
				EastCW.ContextMenu = Pandora.cmModifiers;
				EastCCW.ContextMenu = Pandora.cmModifiers;
				NorthCW.ContextMenu = Pandora.cmModifiers;
				NorthCCW.ContextMenu = Pandora.cmModifiers;
				SouthCW.ContextMenu = Pandora.cmModifiers;
				SouthCCW.ContextMenu = Pandora.cmModifiers;
			}
			catch
			{ } // VS
		}

		/// <summary>
		///     Handles the DoorSelected event
		/// </summary>
		private void Doors_DoorSelected(DoorEventArgs e)
		{
			Door = e;
		}

		/// <summary>
		///     Handles the PortcullisSelected event
		/// </summary>
		private void Doors_PortcullisSelected(PortcullisEventArgs e)
		{
			Portcullis = e;
		}

		/// <summary>
		///     Gets the ID offset for a given label
		/// </summary>
		/// <param name="lab">The label the mouse is on</param>
		/// <returns>The offset that must be added to the base of the item</returns>
		private int GetDoorOffset(Label lab)
		{
			var offset = 0;

			if (lab == WestCW)
			{
				offset = 0;
			}
			else if (lab == EastCCW)
			{
				offset = 2;
			}
			else if (lab == WestCCW)
			{
				offset = 4;
			}
			else if (lab == EastCW)
			{
				offset = 6;
			}
			else if (lab == NorthCW)
			{
				offset = 14;
			}
			else if (lab == SouthCCW)
			{
				offset = 8;
			}
			else if (lab == NorthCCW)
			{
				offset = 10;
			}
			else if (lab == SouthCW)
			{
				offset = 12;
			}

			return offset;
		}

		/// <summary>
		///     Performs the add door command
		/// </summary>
		/// <param name="facing">The facing parameter of the door</param>
		/// <param name="modifier">The modifier for the command</param>
		private void Perform(string facing, string modifier)
		{
			if (m_Portcullis != null)
			{
				string item;
				if (facing == "WestCCW")
				{
					item = m_Portcullis.ItemNS;
				}
				else
				{
					item = m_Portcullis.ItemEW;
				}

				Pandora.Profile.Commands.DoAddItem(item, modifier);
			}
			else if (m_Door != null)
			{
				var item = String.Format("{0} {1}", m_Door.Item, facing);
				Pandora.Profile.Commands.DoAddItem(item, modifier);
			}
		}

		#region Callbacks for commands
		private void PerformWestCW(string modifier)
		{
			Perform("WestCW", modifier);
		}

		private void PerformWestCCW(string modifier)
		{
			Perform("WestCCW", modifier);
		}

		private void PerformEastCW(string modifier)
		{
			Perform("EastCW", modifier);
		}

		private void PerformEastCCW(string modifier)
		{
			Perform("EastCCW", modifier);
		}

		private void PerformNorthCW(string modifier)
		{
			Perform("NorthCW", modifier);
		}

		private void PerformNorthCCW(string modifier)
		{
			Perform("NorthCCW", modifier);
		}

		private void PerformSouthCW(string modifier)
		{
			Perform("SouthCW", modifier);
		}

		private void PerformSouthCCW(string modifier)
		{
			Perform("SouthCCW", modifier);
		}
		#endregion

		/// <summary>
		///     Labels mouse down
		/// </summary>
		private void WestCCW_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is Label lab)
			{
				_ = (lab.Tag as CommandCallback).DynamicInvoke(new object[] { null });
			}
		}

		private void bLock_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoSet("locked", "true", null);
			Pandora.Prop.SetProperty("locked", "true", null);
		}

		private void bUnlock_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoSet("locked", "false", null);
			Pandora.Prop.SetProperty("locked", "false", null);
		}
	}
}