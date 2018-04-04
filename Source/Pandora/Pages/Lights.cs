#region Header
// /*
//  *    2018 - Pandora - Lights.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for Lights.
	/// </summary>
	public class Lights : UserControl
	{
		private Button b0;
		private Button b1;
		private Button b2;
		private Button b3;
		private Button b4;
		private Button b5;
		private Button b6;
		private Button b7;
		private Button b8;
		private Button b9;
		private ComboBox cmbCategories;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private Label labLight;

		private readonly Button[] m_Buttons;
		private Button bNoLight;
		private LinkLabel lnkDecoLight;
		private GroupBox groupBox1;
		private Image[] m_Images;
		private bool m_SelectingDecoLight;

		public Lights()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			try
			{
				m_Buttons = new[] {b0, b1, b2, b3, b4, b5, b6, b7, b8, b9};

				b0.Tag = new CommandCallback(Perform0);
				b1.Tag = new CommandCallback(Perform1);
				b2.Tag = new CommandCallback(Perform2);
				b3.Tag = new CommandCallback(Perform3);
				b4.Tag = new CommandCallback(Perform4);
				b5.Tag = new CommandCallback(Perform5);
				b6.Tag = new CommandCallback(Perform6);
				b7.Tag = new CommandCallback(Perform7);
				b8.Tag = new CommandCallback(Perform8);
				b9.Tag = new CommandCallback(Perform9);

				b0.ContextMenu = Pandora.cmModifiers;
				b1.ContextMenu = Pandora.cmModifiers;
				b2.ContextMenu = Pandora.cmModifiers;
				b3.ContextMenu = Pandora.cmModifiers;
				b4.ContextMenu = Pandora.cmModifiers;
				b5.ContextMenu = Pandora.cmModifiers;
				b6.ContextMenu = Pandora.cmModifiers;
				b7.ContextMenu = Pandora.cmModifiers;
				b8.ContextMenu = Pandora.cmModifiers;
				b9.ContextMenu = Pandora.cmModifiers;

				bNoLight.Tag = new CommandCallback(PerformNoLight);
				bNoLight.ContextMenu = Pandora.cmModifiers;
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
			this.b0 = new System.Windows.Forms.Button();
			this.b1 = new System.Windows.Forms.Button();
			this.b2 = new System.Windows.Forms.Button();
			this.b3 = new System.Windows.Forms.Button();
			this.b4 = new System.Windows.Forms.Button();
			this.b5 = new System.Windows.Forms.Button();
			this.b6 = new System.Windows.Forms.Button();
			this.b7 = new System.Windows.Forms.Button();
			this.b8 = new System.Windows.Forms.Button();
			this.b9 = new System.Windows.Forms.Button();
			this.cmbCategories = new System.Windows.Forms.ComboBox();
			this.bNoLight = new System.Windows.Forms.Button();
			this.labLight = new System.Windows.Forms.Label();
			this.lnkDecoLight = new System.Windows.Forms.LinkLabel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// b0
			// 
			this.b0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b0.Location = new System.Drawing.Point(0, 0);
			this.b0.Name = "b0";
			this.b0.Size = new System.Drawing.Size(68, 68);
			this.b0.TabIndex = 0;
			this.b0.MouseEnter += new System.EventHandler(this.OnButton);
			this.b0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b1
			// 
			this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b1.Location = new System.Drawing.Point(72, 0);
			this.b1.Name = "b1";
			this.b1.Size = new System.Drawing.Size(68, 68);
			this.b1.TabIndex = 1;
			this.b1.MouseEnter += new System.EventHandler(this.OnButton);
			this.b1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b2
			// 
			this.b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b2.Location = new System.Drawing.Point(144, 0);
			this.b2.Name = "b2";
			this.b2.Size = new System.Drawing.Size(68, 68);
			this.b2.TabIndex = 2;
			this.b2.MouseEnter += new System.EventHandler(this.OnButton);
			this.b2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b3
			// 
			this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b3.Location = new System.Drawing.Point(216, 0);
			this.b3.Name = "b3";
			this.b3.Size = new System.Drawing.Size(68, 68);
			this.b3.TabIndex = 3;
			this.b3.MouseEnter += new System.EventHandler(this.OnButton);
			this.b3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b4
			// 
			this.b4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b4.Location = new System.Drawing.Point(288, 0);
			this.b4.Name = "b4";
			this.b4.Size = new System.Drawing.Size(68, 68);
			this.b4.TabIndex = 4;
			this.b4.MouseEnter += new System.EventHandler(this.OnButton);
			this.b4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b5
			// 
			this.b5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b5.Location = new System.Drawing.Point(0, 72);
			this.b5.Name = "b5";
			this.b5.Size = new System.Drawing.Size(68, 68);
			this.b5.TabIndex = 5;
			this.b5.MouseEnter += new System.EventHandler(this.OnButton);
			this.b5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b6
			// 
			this.b6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b6.Location = new System.Drawing.Point(72, 72);
			this.b6.Name = "b6";
			this.b6.Size = new System.Drawing.Size(68, 68);
			this.b6.TabIndex = 6;
			this.b6.MouseEnter += new System.EventHandler(this.OnButton);
			this.b6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b7
			// 
			this.b7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b7.Location = new System.Drawing.Point(144, 72);
			this.b7.Name = "b7";
			this.b7.Size = new System.Drawing.Size(68, 68);
			this.b7.TabIndex = 7;
			this.b7.MouseEnter += new System.EventHandler(this.OnButton);
			this.b7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b8
			// 
			this.b8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b8.Location = new System.Drawing.Point(216, 72);
			this.b8.Name = "b8";
			this.b8.Size = new System.Drawing.Size(68, 68);
			this.b8.TabIndex = 8;
			this.b8.MouseEnter += new System.EventHandler(this.OnButton);
			this.b8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// b9
			// 
			this.b9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.b9.Location = new System.Drawing.Point(288, 72);
			this.b9.Name = "b9";
			this.b9.Size = new System.Drawing.Size(68, 68);
			this.b9.TabIndex = 9;
			this.b9.MouseEnter += new System.EventHandler(this.OnButton);
			this.b9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnButtonDown);
			// 
			// cmbCategories
			// 
			this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategories.DropDownWidth = 132;
			this.cmbCategories.Location = new System.Drawing.Point(360, 36);
			this.cmbCategories.MaxDropDownItems = 10;
			this.cmbCategories.Name = "cmbCategories";
			this.cmbCategories.Size = new System.Drawing.Size(132, 21);
			this.cmbCategories.TabIndex = 10;
			this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
			// 
			// bNoLight
			// 
			this.bNoLight.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNoLight.Location = new System.Drawing.Point(360, 64);
			this.bNoLight.Name = "bNoLight";
			this.bNoLight.Size = new System.Drawing.Size(132, 23);
			this.bNoLight.TabIndex = 11;
			this.bNoLight.Text = "Lights.NoLight";
			this.bNoLight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bNoLight_MouseDown);
			// 
			// labLight
			// 
			this.labLight.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.labLight.Location = new System.Drawing.Point(360, 0);
			this.labLight.Name = "labLight";
			this.labLight.Size = new System.Drawing.Size(132, 32);
			this.labLight.TabIndex = 12;
			this.labLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labLight.Paint += new System.Windows.Forms.PaintEventHandler(this.labLight_Paint);
			// 
			// lnkDecoLight
			// 
			this.lnkDecoLight.Location = new System.Drawing.Point(12, 16);
			this.lnkDecoLight.Name = "lnkDecoLight";
			this.lnkDecoLight.Size = new System.Drawing.Size(108, 28);
			this.lnkDecoLight.TabIndex = 14;
			this.lnkDecoLight.TabStop = true;
			this.lnkDecoLight.Text = "linkLabel1";
			this.lnkDecoLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkDecoLight.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDecoLight_LinkClicked);
			this.lnkDecoLight.Paint += new System.Windows.Forms.PaintEventHandler(this.linkLabel1_Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lnkDecoLight);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(360, 92);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(132, 48);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lights.SetDeco";
			// 
			// Lights
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labLight);
			this.Controls.Add(this.bNoLight);
			this.Controls.Add(this.cmbCategories);
			this.Controls.Add(this.b9);
			this.Controls.Add(this.b8);
			this.Controls.Add(this.b7);
			this.Controls.Add(this.b6);
			this.Controls.Add(this.b5);
			this.Controls.Add(this.b4);
			this.Controls.Add(this.b3);
			this.Controls.Add(this.b2);
			this.Controls.Add(this.b1);
			this.Controls.Add(this.b0);
			this.Name = "Lights";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.Lights_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void Lights_Load(object sender, EventArgs e)
		{
			try
			{
				// Add categories
				cmbCategories.Items.AddRange(Pandora.Lights.Categories);
				cmbCategories.SelectedIndex = 0;
				lnkDecoLight.Text = Pandora.Profile.Deco.Light;
			}
			catch
			{ } // VS
		}

		/// <summary>
		///     Category index changed
		/// </summary>
		private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Pandora.Lights.SelectedCategory = cmbCategories.Text;
				UpdateImages();
			}
			catch
			{ } // VS
		}

		/// <summary>
		///     Updates the images displayed on the buttons
		/// </summary>
		private void UpdateImages()
		{
			if (m_Images != null)
			{
				foreach (var img in m_Images)
				{
					img.Dispose();
				}
			}

			m_Images = Pandora.Lights.Images;

			for (var i = 0; i < m_Images.Length; i++)
			{
				m_Buttons[i].Visible = true;

				m_Buttons[i].Image = new Bitmap(m_Images[i], m_Buttons[i].Size);
			}

			for (var i = m_Images.Length; i < 10; i++)
			{
				m_Buttons[i].Visible = false;
			}
		}

		#region Button Callbacks
		/// <summary>
		///     Sets the Light
		/// </summary>
		/// <param name="index">The index of the button pressed</param>
		/// <param name="modifier">The command modifier</param>
		private void PerformCommand(int index, string modifier)
		{
			Pandora.Profile.Commands.DoSet("Light", Pandora.Lights.Names[index], modifier);
			Pandora.Prop.SetProperty("Light", Pandora.Lights.Names[index], "");
		}

		private void Perform0(string modifier)
		{
			PerformCommand(0, modifier);
		}

		private void Perform1(string modifier)
		{
			PerformCommand(1, modifier);
		}

		private void Perform2(string modifier)
		{
			PerformCommand(2, modifier);
		}

		private void Perform3(string modifier)
		{
			PerformCommand(3, modifier);
		}

		private void Perform4(string modifier)
		{
			PerformCommand(4, modifier);
		}

		private void Perform5(string modifier)
		{
			PerformCommand(5, modifier);
		}

		private void Perform6(string modifier)
		{
			PerformCommand(6, modifier);
		}

		private void Perform7(string modifier)
		{
			PerformCommand(7, modifier);
		}

		private void Perform8(string modifier)
		{
			PerformCommand(8, modifier);
		}

		private void Perform9(string modifier)
		{
			PerformCommand(9, modifier);
		}

		private void PerformNoLight(string modifier)
		{
			Pandora.Profile.Commands.DoSet("Light", "Empty", modifier);
			Pandora.Prop.SetProperty("Light", "Empty", "");
		}
		#endregion

		/// <summary>
		///     Mouse enters a button
		/// </summary>
		private void OnButton(object sender, EventArgs e)
		{
			var b = sender as Button;
			var index = 0;

			for (var i = 0; i < m_Buttons.Length; i++)
			{
				if (m_Buttons[i] == b)
				{
					index = i;
					break;
				}
			}

			Pandora.BoxForm.SelectSmallTab(SmallTabs.Art);
			Pandora.Art.DisplayedImage = m_Images[index];

			labLight.Text = Pandora.Lights.Names[index];
		}

		/// <summary>
		///     Button pressed
		/// </summary>
		private void OnButtonDown(object sender, MouseEventArgs e)
		{
			var b = sender as Button;

			if (m_SelectingDecoLight)
			{
				var index = 0;

				for (var i = 0; i < 10; i++)
					if (m_Buttons[i] == b)
					{
						index = i;
						break;
					}

				Pandora.Profile.Deco.Light = Pandora.Lights.Names[index];
				lnkDecoLight.Text = Pandora.Lights.Names[index];
			}
			else
			{
				var callback = b.Tag as CommandCallback;

				callback.DynamicInvoke(new object[] {null});
			}
		}

		/// <summary>
		///     Paint the border for the light name
		/// </summary>
		private void labLight_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, labLight.Width - 1, labLight.Height - 1);
			pen.Dispose();
		}

		/// <summary>
		///     No light button
		/// </summary>
		private void bNoLight_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_SelectingDecoLight)
			{
				Pandora.Profile.Deco.Light = "Empty";
				lnkDecoLight.Text = "Empty";
			}
			else
			{
				PerformNoLight(null);
			}
		}

		/// <summary>
		///     Paint the border of the link
		/// </summary>
		private void linkLabel1_Paint(object sender, PaintEventArgs e)
		{
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, lnkDecoLight.Width - 1, lnkDecoLight.Height - 1);
			pen.Dispose();
		}

		/// <summary>
		///     Light Link clicked
		/// </summary>
		private void lnkDecoLight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show(Pandora.Localization.TextProvider["Lights.SetMsg"]);
			m_SelectingDecoLight = true;
		}
	}
}