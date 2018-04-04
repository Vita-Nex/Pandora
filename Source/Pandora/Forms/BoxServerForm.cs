#region Header
// /*
//  *    2018 - Pandora - BoxServerForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

using TheBox.BoxServer;

using Timer = System.Windows.Forms.Timer;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for BoxServerForm.
	/// </summary>
	public class BoxServerForm : Form
	{
		private readonly bool m_Login;
		private readonly bool m_Silent;
		private readonly BoxMessage m_Message;

		/// <summary>
		///     Gets or sets the message returned by the server
		/// </summary>
		public BoxMessage Response { get; set; }

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		/// <summary>
		///     Creates a new BoxServerForm object use to login into a BoxServer
		/// </summary>
		/// <param name="silent">Specifies whether to display error messages or not</param>
		public BoxServerForm(bool silent)
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			m_Login = true;
			m_Silent = silent;
		}

		public BoxServerForm(BoxMessage message)
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			m_Message = message;
			m_Login = false;
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
			var resources = new System.Resources.ResourceManager(typeof(BoxServerForm));
			// 
			// BoxServerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(158, 23);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BoxServerForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Misc.Connecting";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.BoxServerForm_Closing);
			this.Load += new System.EventHandler(this.BoxServerForm_Load);
		}
		#endregion

		#region Painting
		private int m_Progress;
		private const int m_Step = 5;

		private readonly Color m_StartColor = Color.MediumVioletRed;
		private readonly Color m_EndColor = SystemColors.Control;

		private Timer m_Timer;

		private int m_MaxProgress { get { return Size.Width - 10; } }

		private Point m_Start { get { return new Point(5, 5); } }

		private Point m_GradientEnd { get { return new Point(5 + m_Progress, 5); } }

		private LinearGradientBrush m_Brush
		{
			get { return new LinearGradientBrush(m_Start, m_GradientEnd, m_StartColor, m_EndColor); }
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (m_Progress == 150)
			{
				m_Progress = 0;
			}

			m_Progress += m_Step;
			Brush brush = m_Brush;

			e.Graphics.FillRectangle(brush, 5, 5, m_Progress, 15);

			var pen = new Pen(Color.Black);
			e.Graphics.DrawRectangle(pen, 5, 5, 150, 15);

			pen.Dispose();
			brush.Dispose();
		}

		private void m_Timer_Tick(object sender, EventArgs e)
		{
			Refresh();
		}

		private void BoxServerForm_Closing(object sender, CancelEventArgs e)
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
				m_Timer.Dispose();
			}
		}
		#endregion

		private void BoxServerForm_Load(object sender, EventArgs e)
		{
			m_Timer = new Timer();
			m_Timer.Interval = 200;
			m_Timer.Tick += m_Timer_Tick;
			m_Timer.Start();

			if (m_Login)
			{
				ThreadPool.QueueUserWorkItem(Connect);
			}
			else
			{
				ThreadPool.QueueUserWorkItem(SendMessage);
			}
		}

		private delegate void CloseForm();

		private void Connect(object o)
		{
			var response = Pandora.BoxConnection.Connect(!m_Silent);
			Invoke(new CloseForm(Close));
		}

		private void SendMessage(object o)
		{
			var result = Pandora.BoxConnection.ProcessMessage(m_Message);

			if (result != null)
			{
				if (Pandora.BoxConnection.CheckErrors(result))
				{
					DialogResult = DialogResult.OK;
					Response = result;
				}
				else
				{
					DialogResult = DialogResult.Cancel;
				}
			}

			if (!Pandora.BoxConnection.Connected)
				DialogResult = DialogResult.Cancel; // Account for communication error

			Close();
		}
	}
}