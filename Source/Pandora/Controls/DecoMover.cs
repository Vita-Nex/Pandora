#region Header
// /*
//  *    2018 - Pandora - DecoMover.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for DecoMover.
	/// </summary>
	public class DecoMover : UserControl
	{
		private NumericUpDown num;
		private Button bUpLeft;
		private Button bUp;
		private Button bUpRight;
		private Button bLeft;
		private Button bDownLeft;
		private Button bDown;
		private Button bDownRight;
		private Button bRight;
		private PictureBox pictureBox1;

		public delegate void DecoMoveEventHandler(int xOffset, int yOffset);

		public event DecoMoveEventHandler OnDecoMove;

		/// <summary>
		///     States whether the mover should launch an event rather than sending the command
		/// </summary>
		public bool EventMode { get; set; }

		public DecoMover()
		{
			EventMode = false;
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Flickering fix
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			var resources = new System.Resources.ResourceManager(typeof(DecoMover));
			this.num = new System.Windows.Forms.NumericUpDown();
			this.bUpLeft = new System.Windows.Forms.Button();
			this.bUp = new System.Windows.Forms.Button();
			this.bUpRight = new System.Windows.Forms.Button();
			this.bLeft = new System.Windows.Forms.Button();
			this.bDownLeft = new System.Windows.Forms.Button();
			this.bDown = new System.Windows.Forms.Button();
			this.bDownRight = new System.Windows.Forms.Button();
			this.bRight = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)this.num).BeginInit();
			this.SuspendLayout();
			// 
			// num
			// 
			this.num.Location = new System.Drawing.Point(16, 0);
			this.num.Maximum = new decimal(new int[] { 7000, 0, 0, 0 });
			this.num.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.num.Name = "num";
			this.num.Size = new System.Drawing.Size(44, 20);
			this.num.TabIndex = 1;
			this.num.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// bUpLeft
			// 
			this.bUpLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bUpLeft.Image = (System.Drawing.Image)resources.GetObject("bUpLeft.Image");
			this.bUpLeft.Location = new System.Drawing.Point(0, 20);
			this.bUpLeft.Name = "bUpLeft";
			this.bUpLeft.Size = new System.Drawing.Size(22, 22);
			this.bUpLeft.TabIndex = 2;
			this.bUpLeft.Click += new System.EventHandler(this.bUpLeft_Click);
			this.bUpLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bUp
			// 
			this.bUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bUp.Image = (System.Drawing.Image)resources.GetObject("bUp.Image");
			this.bUp.Location = new System.Drawing.Point(24, 20);
			this.bUp.Name = "bUp";
			this.bUp.Size = new System.Drawing.Size(22, 22);
			this.bUp.TabIndex = 3;
			this.bUp.Click += new System.EventHandler(this.bUp_Click);
			this.bUp.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bUpRight
			// 
			this.bUpRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bUpRight.Image = (System.Drawing.Image)resources.GetObject("bUpRight.Image");
			this.bUpRight.Location = new System.Drawing.Point(48, 20);
			this.bUpRight.Name = "bUpRight";
			this.bUpRight.Size = new System.Drawing.Size(22, 22);
			this.bUpRight.TabIndex = 4;
			this.bUpRight.Click += new System.EventHandler(this.bUpRight_Click);
			this.bUpRight.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bLeft
			// 
			this.bLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bLeft.Image = (System.Drawing.Image)resources.GetObject("bLeft.Image");
			this.bLeft.Location = new System.Drawing.Point(0, 44);
			this.bLeft.Name = "bLeft";
			this.bLeft.Size = new System.Drawing.Size(22, 22);
			this.bLeft.TabIndex = 5;
			this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
			this.bLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bDownLeft
			// 
			this.bDownLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bDownLeft.Image = (System.Drawing.Image)resources.GetObject("bDownLeft.Image");
			this.bDownLeft.Location = new System.Drawing.Point(0, 68);
			this.bDownLeft.Name = "bDownLeft";
			this.bDownLeft.Size = new System.Drawing.Size(22, 22);
			this.bDownLeft.TabIndex = 6;
			this.bDownLeft.Click += new System.EventHandler(this.bDownLeft_Click);
			this.bDownLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bDown
			// 
			this.bDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bDown.Image = (System.Drawing.Image)resources.GetObject("bDown.Image");
			this.bDown.Location = new System.Drawing.Point(24, 68);
			this.bDown.Name = "bDown";
			this.bDown.Size = new System.Drawing.Size(22, 22);
			this.bDown.TabIndex = 7;
			this.bDown.Click += new System.EventHandler(this.bDown_Click);
			this.bDown.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bDownRight
			// 
			this.bDownRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bDownRight.Image = (System.Drawing.Image)resources.GetObject("bDownRight.Image");
			this.bDownRight.Location = new System.Drawing.Point(48, 68);
			this.bDownRight.Name = "bDownRight";
			this.bDownRight.Size = new System.Drawing.Size(22, 22);
			this.bDownRight.TabIndex = 8;
			this.bDownRight.Click += new System.EventHandler(this.bDownRight_Click);
			this.bDownRight.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// bRight
			// 
			this.bRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bRight.Image = (System.Drawing.Image)resources.GetObject("bRight.Image");
			this.bRight.Location = new System.Drawing.Point(48, 44);
			this.bRight.Name = "bRight";
			this.bRight.Size = new System.Drawing.Size(22, 22);
			this.bRight.TabIndex = 9;
			this.bRight.Click += new System.EventHandler(this.bRight_Click);
			this.bRight.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(24, 44);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// DecoMover
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.bRight);
			this.Controls.Add(this.bDownRight);
			this.Controls.Add(this.bDown);
			this.Controls.Add(this.bDownLeft);
			this.Controls.Add(this.bLeft);
			this.Controls.Add(this.bUpRight);
			this.Controls.Add(this.bUp);
			this.Controls.Add(this.bUpLeft);
			this.Controls.Add(this.num);
			this.Name = "DecoMover";
			this.Size = new System.Drawing.Size(72, 92);
			this.Load += new System.EventHandler(this.DecoMover_Load);
			((System.ComponentModel.ISupportInitialize)this.num).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void ButtonPaint(object sender, PaintEventArgs e)
		{
			var b = sender as Button;

			var pen = new Pen(SystemColors.Control);
			e.Graphics.DrawRectangle(pen, 0, 0, b.Width - 1, b.Height - 1);
			pen.Dispose();
		}

		private void PerformMove(string modifier, int xMultiplier, int yMultiplier)
		{
			Pandora.Profile.Deco.MoveAmount = (int)num.Value;

			var x = xMultiplier * Pandora.Profile.Deco.MoveAmount;
			var y = yMultiplier * Pandora.Profile.Deco.MoveAmount;

			if (EventMode)
			{
				OnDecoMove?.Invoke(x, y);
			}
			else
			{
				Pandora.Profile.Commands.DoMove(modifier, x, y);
			}
		}

		private void DecoMover_Load(object sender, EventArgs e)
		{
			try
			{
				num.Value = Pandora.Profile.Deco.MoveAmount;

				if (!EventMode)
				{
					bUpLeft.Tag = new CommandCallback(UpLeft);
					bUp.Tag = new CommandCallback(Up);
					bUpRight.Tag = new CommandCallback(UpRight);
					bLeft.Tag = new CommandCallback(DoLeft);
					bRight.Tag = new CommandCallback(DoRight);
					bDownLeft.Tag = new CommandCallback(DownLeft);
					bDown.Tag = new CommandCallback(Down);
					bDownRight.Tag = new CommandCallback(DownRight);

					bUpLeft.ContextMenu = Pandora.cmModifiers;
					bUp.ContextMenu = Pandora.cmModifiers;
					bUpRight.ContextMenu = Pandora.cmModifiers;
					bLeft.ContextMenu = Pandora.cmModifiers;
					bRight.ContextMenu = Pandora.cmModifiers;
					bDownLeft.ContextMenu = Pandora.cmModifiers;
					bDown.ContextMenu = Pandora.cmModifiers;
					bDownRight.ContextMenu = Pandora.cmModifiers;
				}
			}
			catch
			{ }
		}

		private void num_ValueChanged(object sender, EventArgs e)
		{
			Pandora.Profile.Deco.MoveAmount = (int)num.Value;
		}

		private void UpLeft(string modifier)
		{
			PerformMove(modifier, -1, 0);
		}

		private void Up(string modifier)
		{
			PerformMove(modifier, -1, -1);
		}

		private void UpRight(string modifier)
		{
			PerformMove(modifier, 0, -1);
		}

		private void DoLeft(string modifier)
		{
			PerformMove(modifier, -1, 1);
		}

		private void DoRight(string modifier)
		{
			PerformMove(modifier, 1, -1);
		}

		private void DownLeft(string modifier)
		{
			PerformMove(modifier, 0, 1);
		}

		private void Down(string modifier)
		{
			PerformMove(modifier, 1, 1);
		}

		private void DownRight(string modifier)
		{
			PerformMove(modifier, 1, 0);
		}

		private void bUpLeft_Click(object sender, EventArgs e)
		{
			UpLeft(null);
		}

		private void bUp_Click(object sender, EventArgs e)
		{
			Up(null);
		}

		private void bUpRight_Click(object sender, EventArgs e)
		{
			UpRight(null);
		}

		private void bLeft_Click(object sender, EventArgs e)
		{
			DoLeft(null);
		}

		private void bRight_Click(object sender, EventArgs e)
		{
			DoRight(null);
		}

		private void bDownLeft_Click(object sender, EventArgs e)
		{
			DownLeft(null);
		}

		private void bDown_Click(object sender, EventArgs e)
		{
			Down(null);
		}

		private void bDownRight_Click(object sender, EventArgs e)
		{
			DownRight(null);
		}
	}
}