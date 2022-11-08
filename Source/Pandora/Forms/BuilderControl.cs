#region Header
// /*
//  *    2018 - Pandora - BuilderControl.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.BoxServer;
using TheBox.Controls;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for BuilderControl.
	/// </summary>
	public class BuilderControl : Form
	{
		private Button bDelete;
		private Button bHue;
		private Button bRemoveHue;
		private NumericUpDown numNudge;
		private Button bNudgeUp;
		private Button bNudgeDown;
		private DecoMover dMover;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public BuilderControl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);
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
			var resources = new System.Resources.ResourceManager(typeof(BuilderControl));
			this.bDelete = new System.Windows.Forms.Button();
			this.dMover = new TheBox.Controls.DecoMover();
			this.bHue = new System.Windows.Forms.Button();
			this.bRemoveHue = new System.Windows.Forms.Button();
			this.numNudge = new System.Windows.Forms.NumericUpDown();
			this.bNudgeUp = new System.Windows.Forms.Button();
			this.bNudgeDown = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.numNudge).BeginInit();
			this.SuspendLayout();
			// 
			// bDelete
			// 
			this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDelete.Location = new System.Drawing.Point(4, 4);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(80, 23);
			this.bDelete.TabIndex = 0;
			this.bDelete.Text = "Common.Delete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// dMover
			// 
			this.dMover.BackColor = System.Drawing.SystemColors.Control;
			this.dMover.EventMode = true;
			this.dMover.Location = new System.Drawing.Point(8, 116);
			this.dMover.Name = "dMover";
			this.dMover.Size = new System.Drawing.Size(72, 92);
			this.dMover.TabIndex = 1;
			this.dMover.OnDecoMove += new TheBox.Controls.DecoMover.DecoMoveEventHandler(this.dMover_OnDecoMove);
			// 
			// bHue
			// 
			this.bHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bHue.Location = new System.Drawing.Point(4, 32);
			this.bHue.Name = "bHue";
			this.bHue.Size = new System.Drawing.Size(80, 23);
			this.bHue.TabIndex = 2;
			this.bHue.Text = "Common.Hue";
			this.bHue.Click += new System.EventHandler(this.bHue_Click);
			// 
			// bRemoveHue
			// 
			this.bRemoveHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bRemoveHue.Location = new System.Drawing.Point(4, 60);
			this.bRemoveHue.Name = "bRemoveHue";
			this.bRemoveHue.Size = new System.Drawing.Size(80, 23);
			this.bRemoveHue.TabIndex = 3;
			this.bRemoveHue.Text = "Misc.RemoveHue";
			this.bRemoveHue.Click += new System.EventHandler(this.bRemoveHue_Click);
			// 
			// numNudge
			// 
			this.numNudge.Location = new System.Drawing.Point(24, 88);
			this.numNudge.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
			this.numNudge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.numNudge.Name = "numNudge";
			this.numNudge.Size = new System.Drawing.Size(44, 20);
			this.numNudge.TabIndex = 4;
			this.numNudge.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// bNudgeUp
			// 
			this.bNudgeUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bNudgeUp.Image = (System.Drawing.Image)resources.GetObject("bNudgeUp.Image");
			this.bNudgeUp.Location = new System.Drawing.Point(68, 88);
			this.bNudgeUp.Name = "bNudgeUp";
			this.bNudgeUp.Size = new System.Drawing.Size(16, 23);
			this.bNudgeUp.TabIndex = 5;
			this.bNudgeUp.Click += new System.EventHandler(this.bNudgeUp_Click);
			// 
			// bNudgeDown
			// 
			this.bNudgeDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bNudgeDown.Image = (System.Drawing.Image)resources.GetObject("bNudgeDown.Image");
			this.bNudgeDown.Location = new System.Drawing.Point(4, 88);
			this.bNudgeDown.Name = "bNudgeDown";
			this.bNudgeDown.Size = new System.Drawing.Size(16, 23);
			this.bNudgeDown.TabIndex = 6;
			this.bNudgeDown.Click += new System.EventHandler(this.bNudgeDown_Click);
			// 
			// BuilderControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(86, 212);
			this.Controls.Add(this.bNudgeDown);
			this.Controls.Add(this.bNudgeUp);
			this.Controls.Add(this.numNudge);
			this.Controls.Add(this.bRemoveHue);
			this.Controls.Add(this.bHue);
			this.Controls.Add(this.dMover);
			this.Controls.Add(this.bDelete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "BuilderControl";
			this.Text = "Common.Server";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.BuilderControl_Closing);
			((System.ComponentModel.ISupportInitialize)this.numNudge).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private void bDelete_Click(object sender, EventArgs e)
		{
			var msg = new BuilderDeleteMessage();
			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void dMover_OnDecoMove(int xOffset, int yOffset)
		{
			var msg = new OffsetMessage
			{
				XOffset = xOffset,
				YOffset = yOffset
			};

			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void bNudgeUp_Click(object sender, EventArgs e)
		{
			var msg = new OffsetMessage
			{
				ZOffset = (int)numNudge.Value
			};

			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void bNudgeDown_Click(object sender, EventArgs e)
		{
			var msg = new OffsetMessage
			{
				ZOffset = -(int)numNudge.Value
			};

			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void bHue_Click(object sender, EventArgs e)
		{
			var msg = new HueMessage(Pandora.Profile.Hues.SelectedIndex);

			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void bRemoveHue_Click(object sender, EventArgs e)
		{
			var msg = new HueMessage(0);

			_ = Pandora.BoxConnection.SendToServer(msg);
		}

		private void BuilderControl_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			Visible = false;
		}
	}
}