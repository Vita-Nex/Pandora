using System;
using System.Drawing;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
using System.Collections.Generic;
// Issue 10 - End
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using TheBox.Common;
using TheBox.Data;

namespace Decorator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.NumericUpDown numFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numUp;
		private TheBox.ArtViewer.ArtViewer artViewer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox lst;
		private System.Windows.Forms.ProgressBar pBar;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txCat;
		private System.Windows.Forms.TextBox txSub;
		private System.Windows.Forms.TextBox txName;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numFrom = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numUp = new System.Windows.Forms.NumericUpDown();
			this.artViewer1 = new TheBox.ArtViewer.ArtViewer();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.lst = new System.Windows.Forms.ListBox();
			this.pBar = new System.Windows.Forms.ProgressBar();
			this.button3 = new System.Windows.Forms.Button();
			this.txCat = new System.Windows.Forms.TextBox();
			this.txSub = new System.Windows.Forms.TextBox();
			this.txName = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).BeginInit();
			this.SuspendLayout();
			// 
			// numFrom
			// 
			this.numFrom.Location = new System.Drawing.Point(48, 8);
			this.numFrom.Maximum = new System.Decimal(new int[] {
																	30000,
																	0,
																	0,
																	0});
			this.numFrom.Name = "numFrom";
			this.numFrom.Size = new System.Drawing.Size(64, 20);
			this.numFrom.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "From";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(120, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "To";
			// 
			// numUp
			// 
			this.numUp.Location = new System.Drawing.Point(144, 8);
			this.numUp.Maximum = new System.Decimal(new int[] {
																  30000,
																  0,
																  0,
																  0});
			this.numUp.Name = "numUp";
			this.numUp.Size = new System.Drawing.Size(64, 20);
			this.numUp.TabIndex = 3;
			// 
			// artViewer1
			// 
			this.artViewer1.Animate = false;
			this.artViewer1.Art = TheBox.ArtViewer.Art.Items;
			this.artViewer1.ArtIndex = 0;
			this.artViewer1.BackColor = System.Drawing.Color.White;
			this.artViewer1.Hue = 0;
			this.artViewer1.Location = new System.Drawing.Point(152, 264);
			this.artViewer1.Name = "artViewer1";
			this.artViewer1.ResizeTallItems = true;
			this.artViewer1.RoomView = true;
			this.artViewer1.ShowHexID = true;
			this.artViewer1.ShowID = true;
			this.artViewer1.Size = new System.Drawing.Size(184, 184);
			this.artViewer1.TabIndex = 4;
			this.artViewer1.Text = "art";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(216, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Load BoxData";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(8, 32);
			this.button2.Name = "button2";
			this.button2.TabIndex = 6;
			this.button2.Text = "Find";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lst
			// 
			this.lst.Location = new System.Drawing.Point(8, 64);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(136, 407);
			this.lst.TabIndex = 7;
			this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// pBar
			// 
			this.pBar.Location = new System.Drawing.Point(88, 32);
			this.pBar.Name = "pBar";
			this.pBar.Size = new System.Drawing.Size(248, 23);
			this.pBar.TabIndex = 8;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 456);
			this.button3.Name = "button3";
			this.button3.TabIndex = 9;
			this.button3.Text = "Save";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// txCat
			// 
			this.txCat.Location = new System.Drawing.Point(152, 64);
			this.txCat.Name = "txCat";
			this.txCat.Size = new System.Drawing.Size(184, 20);
			this.txCat.TabIndex = 10;
			this.txCat.Text = "";
			// 
			// txSub
			// 
			this.txSub.Location = new System.Drawing.Point(152, 88);
			this.txSub.Name = "txSub";
			this.txSub.Size = new System.Drawing.Size(184, 20);
			this.txSub.TabIndex = 11;
			this.txSub.Text = "";
			// 
			// txName
			// 
			this.txName.Location = new System.Drawing.Point(152, 112);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(184, 20);
			this.txName.TabIndex = 12;
			this.txName.Text = "";
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(192, 232);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 13;
			this.button4.Text = "Save BoxData";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button5.Location = new System.Drawing.Point(184, 136);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 14;
			this.button5.Text = "Add";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 485);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.txName);
			this.Controls.Add(this.txSub);
			this.Controls.Add(this.txCat);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.pBar);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.artViewer1);
			this.Controls.Add(this.numUp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numFrom);
			this.Name = "Form1";
			this.Text = "Form1";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.numFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<int> m_IDs;
		// Issue 10 - End
		private BoxDecoList m_Deco;
		private const string m_File = @"D:\Dev\Pandora 2.0\Data\Deco.xml";

		private void button1_Click(object sender, System.EventArgs e)
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_IDs = new List<int>();
			// Issue 10 - End
			m_Deco = BoxDecoList.FromFile( m_File );

			foreach ( GenericNode g in m_Deco.Structure )
			{
				foreach ( GenericNode g2 in g.Elements )
				{
					foreach ( BoxDeco deco in g2.Elements )
					{
						m_IDs.Add( deco.ID );
					}
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			int from = (int) numFrom.Value;
			int to = (int) numUp.Value;

			lst.BeginUpdate();
			lst.Items.Clear();

			pBar.Minimum = from;
			pBar.Maximum = to;
			pBar.Value = from;

			for ( int i = from; i <= to; i++ )
			{
				pBar.Value = i;
				if ( ! m_IDs.Contains( i ) )
				{
					Bitmap bmp = null;
					try
					{
						bmp = Ultima.Art.GetStatic( i );
					}
					catch
					{
						continue;
					}

					if ( bmp != null )
					{
						lst.Items.Add( i );
					}
				}
			}

			lst.EndUpdate();
		}

		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( lst.SelectedItem == null )
				return;

			int i = (int) lst.SelectedItem;
			artViewer1.ArtIndex = i;
			string name = Ultima.TileData.ItemTable[ i ].Name;

			if ( name == null || name == "" )
			{
				txName.Text = "";
				return;
			}

			char first = char.ToUpper( name[ 0 ] );
			name = string.Concat( new string( first,1 ), name.Substring( 1, name.Length - 1 ) );
			txName.Text = name;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			BoxDecoList list = BoxDecoList.FromFile( m_File );

			foreach ( GenericNode g in list.Structure )
			{
				foreach ( GenericNode g2 in g.Elements )
				{
					g2.Elements.Sort();
				}
			}

			list.Save( m_File );
		}

		private bool Add( string cat, string sub, string name, int ID )
		{
			if ( cat == null || cat == "" || sub == null || sub == "" || name == null || name == "" )
				return false;

			BoxDeco deco = new BoxDeco();
			deco.ID = ID;
			deco.Name = name;

			GenericNode cNode = null;
			GenericNode sNode = null;

			foreach( GenericNode c in m_Deco.Structure )
				if ( c.Name.ToLower() == cat.ToLower() )
				{
					cNode = c;
					break;
				}

			if ( cNode == null )
			{
				cNode = new GenericNode( cat );
				m_Deco.Structure.Add( cNode );
			}

			foreach( GenericNode s in cNode.Elements )
				if ( s.Name.ToLower() == sub.ToLower() )
				{
					sNode = s;
					break;
				}

			if ( sNode == null )
			{
				sNode = new GenericNode( sub );
				cNode.Elements.Add( sNode );
			}

			sNode.Elements.Add( deco );
			return true;
		}

		private void lst_DoubleClick(object sender, System.EventArgs e)
		{
			int id = -1;

			if ( lst.SelectedIndex != -1 )
			{
				try
				{
					id = (int) lst.SelectedItem;
				}
				catch
				{
				}
			}

			if ( id == -1 )
				return;

			if ( Add( txCat.Text, txSub.Text, txName.Text, id ) )
			{
				int index = lst.SelectedIndex;
				lst.Items.RemoveAt( index );

				try { lst.SelectedIndex = index; }
				catch{}
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			m_Deco.Structure.Sort();

			foreach ( GenericNode cat in m_Deco.Structure )
			{
				cat.Elements.Sort();

				foreach ( GenericNode sub in cat.Elements )
				{
					sub.Elements.Sort();
				}
			}

			m_Deco.Save( m_File );
		}

		private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string data = e.Data.GetData( typeof( string ) ) as string;
			string cat = null;
			string sub = null;

			if ( data.IndexOf( "|" ) == -1 )
			{
				cat = data;
				sub = null;
			}
			else
			{
				string[] split = data.Split( '|' );
				cat = split[ 0 ];
				sub = split[ 1 ];
			}

			if ( cat != null )
				txCat.Text = cat;

			if ( sub != null )
				txSub.Text = sub;
		
		}

		private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			 lst_DoubleClick( sender, e );
		}
	}
}