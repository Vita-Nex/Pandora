#region Header
// /*
//  *    2018 - Pandora - TextParam.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Summary description for TextParam.
	/// </summary>
	public class TextParam : UserControl, IParam
	{
		private static string m_Text = "";
		private static string m_Other = "";

		private bool m_IsOther;

		private Label labName;
		private TextBox tx;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public TextParam()
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
			this.tx = new System.Windows.Forms.TextBox();
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
			// tx
			// 
			this.tx.Location = new System.Drawing.Point(0, 16);
			this.tx.Name = "tx";
			this.tx.Size = new System.Drawing.Size(96, 20);
			this.tx.TabIndex = 1;
			this.tx.Text = "";
			this.tx.TextChanged += new System.EventHandler(this.tx_TextChanged);
			// 
			// TextParam
			// 
			this.Controls.Add(this.tx);
			this.Controls.Add(this.labName);
			this.Name = "TextParam";
			this.Size = new System.Drawing.Size(96, 36);
			this.Load += new System.EventHandler(this.TextParam_Load);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     States whether this control is used for text, or a generic and undefined input
		/// </summary>
		public bool IsOther { set { m_IsOther = value; } }

		private void TextParam_Load(object sender, EventArgs e)
		{
			if (m_IsOther)
			{
				tx.Text = m_Other;
			}
			else
			{
				tx.Text = m_Text;
			}
		}

		private void tx_TextChanged(object sender, EventArgs e)
		{
			if (m_IsOther)
			{
				m_Other = tx.Text;
			}
			else
			{
				m_Text = tx.Text;
			}
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

		public string Value { get { return tx.Text; } }

		public bool IsDefined { get { return true; } }
		#endregion
	}
}