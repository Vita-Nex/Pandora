#region Header
// /*
//  *    2018 - Pandora - TimeSpanParam.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Summary description for TimeSpanParam.
	/// </summary>
	public class TimeSpanParam : UserControl, IParam
	{
		private Label labName;
		private LinkLabel lnk;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private static TimeSpan m_TimeSpan = TimeSpan.Zero;
		private TimeSpanForm m_Form;

		public TimeSpanParam()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
				Pandora.ToolTip.SetToolTip(labName, null);
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
			this.labName = new System.Windows.Forms.Label();
			this.lnk = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// labName
			// 
			this.labName.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.labName.Location = new System.Drawing.Point(0, 0);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(96, 16);
			this.labName.TabIndex = 0;
			// 
			// lnk
			// 
			this.lnk.Location = new System.Drawing.Point(0, 16);
			this.lnk.Name = "lnk";
			this.lnk.Size = new System.Drawing.Size(100, 20);
			this.lnk.TabIndex = 1;
			this.lnk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
			// 
			// TimeSpanParam
			// 
			this.Controls.Add(this.lnk);
			this.Controls.Add(this.labName);
			this.Name = "TimeSpanParam";
			this.Size = new System.Drawing.Size(96, 36);
			this.Load += new System.EventHandler(this.TimeSpanParam_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void TimeSpanParam_Load(object sender, EventArgs e)
		{
			lnk.Text = m_TimeSpan.ToString();
		}

		private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_Form = new TimeSpanForm();
			m_Form.TimeSpan = m_TimeSpan;

			m_Form.Location = PointToScreen(new Point(0, Height - m_Form.Height));

			m_Form.Closed += m_Form_Closed;
			m_Form.Show();
		}

		#region IParam Members
		public string ParamName
		{
			set
			{
				labName.Text = value;
				Pandora.ToolTip.SetToolTip(labName, value);
			}
		}

		public string Value { get { return m_TimeSpan.ToString(); } }

		public bool IsDefined { get { return true; } }
		#endregion

		private void m_Form_Closed(object sender, EventArgs e)
		{
			m_TimeSpan = m_Form.TimeSpan;
			lnk.Text = m_TimeSpan.ToString();
		}
	}
}