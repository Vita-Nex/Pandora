using System;
using System.Drawing;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
using System.Collections.Generic;
// Issue 10 - End
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using TheBox.Roofing;

namespace RoofEditor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox cmbList;
		private System.Windows.Forms.ListBox lst;
		private System.Windows.Forms.CheckBox l1;
		private System.Windows.Forms.CheckBox h1;
		private System.Windows.Forms.CheckBox e1;
		private System.Windows.Forms.CheckBox e2;
		private System.Windows.Forms.CheckBox h2;
		private System.Windows.Forms.CheckBox l2;
		private System.Windows.Forms.CheckBox e3;
		private System.Windows.Forms.CheckBox h3;
		private System.Windows.Forms.CheckBox l3;
		private System.Windows.Forms.CheckBox e4;
		private System.Windows.Forms.CheckBox h4;
		private System.Windows.Forms.CheckBox l4;
		private System.Windows.Forms.CheckBox e5;
		private System.Windows.Forms.CheckBox h5;
		private System.Windows.Forms.CheckBox l5;
		private System.Windows.Forms.CheckBox e6;
		private System.Windows.Forms.CheckBox h6;
		private System.Windows.Forms.CheckBox l6;
		private System.Windows.Forms.CheckBox e7;
		private System.Windows.Forms.CheckBox h7;
		private System.Windows.Forms.CheckBox l7;
		private System.Windows.Forms.CheckBox h8;
		private System.Windows.Forms.CheckBox l8;
		private System.Windows.Forms.CheckBox p1;
		private System.Windows.Forms.CheckBox p2;
		private System.Windows.Forms.CheckBox p3;
		private System.Windows.Forms.CheckBox p4;
		private System.Windows.Forms.CheckBox p5;
		private System.Windows.Forms.CheckBox p6;
		private System.Windows.Forms.CheckBox p7;
		private System.Windows.Forms.CheckBox p8;
		private System.Windows.Forms.CheckBox e8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private CheckBox[] m_1;
		private CheckBox[] m_2;
		private CheckBox[] m_3;
		private CheckBox[] m_4;
		private CheckBox[] m_5;
		private CheckBox[] m_6;
		private CheckBox[] m_7;
		private CheckBox[] m_8;
		private TheBox.ArtViewer.ArtViewer art;
		private System.Windows.Forms.GroupBox g1;
		private System.Windows.Forms.GroupBox g2;
		private System.Windows.Forms.GroupBox g3;
		private System.Windows.Forms.GroupBox g4;
		private System.Windows.Forms.GroupBox g5;
		private System.Windows.Forms.GroupBox g6;
		private System.Windows.Forms.GroupBox g7;
		private System.Windows.Forms.GroupBox g8;

		private CheckBox[][] m_Boxes;
		private GroupBox[] m_Groups;

		public Form1()
		{
			InitializeComponent();

			m_1 = new CheckBox[] { l1, h1, e1, p1 };
			m_2 = new CheckBox[] { l2, h2, e2, p2 };
			m_3 = new CheckBox[] { l3, h3, e3, p3 };
			m_4 = new CheckBox[] { l4, h4, e4, p4 };
			m_5 = new CheckBox[] { l5, h5, e5, p5 };
			m_6 = new CheckBox[] { l6, h6, e6, p6 };
			m_7 = new CheckBox[] { l7, h7, e7, p7 };
			m_8 = new CheckBox[] { l8, h8, e8, p8 };

			m_Boxes = new CheckBox[][] { m_1, m_2, m_3, m_4, m_5, m_6, m_7, m_8 };

			m_Groups = new GroupBox[] { g1, g2, g3, g4, g5, g6, g7, g8 };
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
			this.lst = new System.Windows.Forms.ListBox();
			this.art = new TheBox.ArtViewer.ArtViewer();
			this.g1 = new System.Windows.Forms.GroupBox();
			this.p1 = new System.Windows.Forms.CheckBox();
			this.e1 = new System.Windows.Forms.CheckBox();
			this.h1 = new System.Windows.Forms.CheckBox();
			this.l1 = new System.Windows.Forms.CheckBox();
			this.g2 = new System.Windows.Forms.GroupBox();
			this.p2 = new System.Windows.Forms.CheckBox();
			this.e2 = new System.Windows.Forms.CheckBox();
			this.h2 = new System.Windows.Forms.CheckBox();
			this.l2 = new System.Windows.Forms.CheckBox();
			this.g3 = new System.Windows.Forms.GroupBox();
			this.p3 = new System.Windows.Forms.CheckBox();
			this.e3 = new System.Windows.Forms.CheckBox();
			this.h3 = new System.Windows.Forms.CheckBox();
			this.l3 = new System.Windows.Forms.CheckBox();
			this.g4 = new System.Windows.Forms.GroupBox();
			this.p4 = new System.Windows.Forms.CheckBox();
			this.e4 = new System.Windows.Forms.CheckBox();
			this.h4 = new System.Windows.Forms.CheckBox();
			this.l4 = new System.Windows.Forms.CheckBox();
			this.g5 = new System.Windows.Forms.GroupBox();
			this.p5 = new System.Windows.Forms.CheckBox();
			this.e5 = new System.Windows.Forms.CheckBox();
			this.h5 = new System.Windows.Forms.CheckBox();
			this.l5 = new System.Windows.Forms.CheckBox();
			this.g6 = new System.Windows.Forms.GroupBox();
			this.p6 = new System.Windows.Forms.CheckBox();
			this.e6 = new System.Windows.Forms.CheckBox();
			this.h6 = new System.Windows.Forms.CheckBox();
			this.l6 = new System.Windows.Forms.CheckBox();
			this.g7 = new System.Windows.Forms.GroupBox();
			this.p7 = new System.Windows.Forms.CheckBox();
			this.e7 = new System.Windows.Forms.CheckBox();
			this.h7 = new System.Windows.Forms.CheckBox();
			this.l7 = new System.Windows.Forms.CheckBox();
			this.g8 = new System.Windows.Forms.GroupBox();
			this.p8 = new System.Windows.Forms.CheckBox();
			this.e8 = new System.Windows.Forms.CheckBox();
			this.h8 = new System.Windows.Forms.CheckBox();
			this.l8 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbList = new System.Windows.Forms.ComboBox();
			this.g1.SuspendLayout();
			this.g2.SuspendLayout();
			this.g3.SuspendLayout();
			this.g4.SuspendLayout();
			this.g5.SuspendLayout();
			this.g6.SuspendLayout();
			this.g7.SuspendLayout();
			this.g8.SuspendLayout();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.Location = new System.Drawing.Point(8, 40);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(120, 329);
			this.lst.Sorted = true;
			this.lst.TabIndex = 1;
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// art
			// 
			this.art.Animate = false;
			this.art.Art = TheBox.ArtViewer.Art.Items;
			this.art.ArtIndex = 0;
			this.art.Hue = 0;
			this.art.Location = new System.Drawing.Point(232, 144);
			this.art.Name = "art";
			this.art.ResizeTallItems = false;
			this.art.RoomView = true;
			this.art.ShowID = false;
			this.art.Size = new System.Drawing.Size(88, 88);
			this.art.TabIndex = 2;
			this.art.Text = "artViewer1";
			// 
			// g1
			// 
			this.g1.Controls.Add(this.p1);
			this.g1.Controls.Add(this.e1);
			this.g1.Controls.Add(this.h1);
			this.g1.Controls.Add(this.l1);
			this.g1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g1.Location = new System.Drawing.Point(136, 8);
			this.g1.Name = "g1";
			this.g1.Size = new System.Drawing.Size(88, 120);
			this.g1.TabIndex = 3;
			this.g1.TabStop = false;
			// 
			// p1
			// 
			this.p1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p1.Location = new System.Drawing.Point(8, 88);
			this.p1.Name = "p1";
			this.p1.Size = new System.Drawing.Size(64, 24);
			this.p1.TabIndex = 3;
			this.p1.Text = "Empty";
			this.p1.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e1
			// 
			this.e1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e1.Location = new System.Drawing.Point(8, 64);
			this.e1.Name = "e1";
			this.e1.Size = new System.Drawing.Size(64, 24);
			this.e1.TabIndex = 2;
			this.e1.Text = "Even";
			this.e1.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h1
			// 
			this.h1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h1.Location = new System.Drawing.Point(8, 40);
			this.h1.Name = "h1";
			this.h1.Size = new System.Drawing.Size(64, 24);
			this.h1.TabIndex = 1;
			this.h1.Text = "Higher";
			this.h1.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l1
			// 
			this.l1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l1.Location = new System.Drawing.Point(8, 16);
			this.l1.Name = "l1";
			this.l1.Size = new System.Drawing.Size(72, 24);
			this.l1.TabIndex = 0;
			this.l1.Text = "Lower";
			this.l1.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g2
			// 
			this.g2.Controls.Add(this.p2);
			this.g2.Controls.Add(this.e2);
			this.g2.Controls.Add(this.h2);
			this.g2.Controls.Add(this.l2);
			this.g2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g2.Location = new System.Drawing.Point(232, 8);
			this.g2.Name = "g2";
			this.g2.Size = new System.Drawing.Size(88, 120);
			this.g2.TabIndex = 4;
			this.g2.TabStop = false;
			// 
			// p2
			// 
			this.p2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p2.Location = new System.Drawing.Point(8, 88);
			this.p2.Name = "p2";
			this.p2.Size = new System.Drawing.Size(64, 24);
			this.p2.TabIndex = 3;
			this.p2.Text = "Empty";
			this.p2.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e2
			// 
			this.e2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e2.Location = new System.Drawing.Point(8, 64);
			this.e2.Name = "e2";
			this.e2.Size = new System.Drawing.Size(64, 24);
			this.e2.TabIndex = 2;
			this.e2.Text = "Even";
			this.e2.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h2
			// 
			this.h2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h2.Location = new System.Drawing.Point(8, 40);
			this.h2.Name = "h2";
			this.h2.Size = new System.Drawing.Size(64, 24);
			this.h2.TabIndex = 1;
			this.h2.Text = "Higher";
			this.h2.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l2
			// 
			this.l2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l2.Location = new System.Drawing.Point(8, 16);
			this.l2.Name = "l2";
			this.l2.Size = new System.Drawing.Size(72, 24);
			this.l2.TabIndex = 0;
			this.l2.Text = "Lower";
			this.l2.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g3
			// 
			this.g3.Controls.Add(this.p3);
			this.g3.Controls.Add(this.e3);
			this.g3.Controls.Add(this.h3);
			this.g3.Controls.Add(this.l3);
			this.g3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g3.Location = new System.Drawing.Point(328, 8);
			this.g3.Name = "g3";
			this.g3.Size = new System.Drawing.Size(88, 120);
			this.g3.TabIndex = 5;
			this.g3.TabStop = false;
			// 
			// p3
			// 
			this.p3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p3.Location = new System.Drawing.Point(8, 88);
			this.p3.Name = "p3";
			this.p3.Size = new System.Drawing.Size(64, 24);
			this.p3.TabIndex = 3;
			this.p3.Text = "Empty";
			this.p3.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e3
			// 
			this.e3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e3.Location = new System.Drawing.Point(8, 64);
			this.e3.Name = "e3";
			this.e3.Size = new System.Drawing.Size(64, 24);
			this.e3.TabIndex = 2;
			this.e3.Text = "Even";
			this.e3.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h3
			// 
			this.h3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h3.Location = new System.Drawing.Point(8, 40);
			this.h3.Name = "h3";
			this.h3.Size = new System.Drawing.Size(64, 24);
			this.h3.TabIndex = 1;
			this.h3.Text = "Higher";
			this.h3.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l3
			// 
			this.l3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l3.Location = new System.Drawing.Point(8, 16);
			this.l3.Name = "l3";
			this.l3.Size = new System.Drawing.Size(72, 24);
			this.l3.TabIndex = 0;
			this.l3.Text = "Lower";
			this.l3.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g4
			// 
			this.g4.Controls.Add(this.p4);
			this.g4.Controls.Add(this.e4);
			this.g4.Controls.Add(this.h4);
			this.g4.Controls.Add(this.l4);
			this.g4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g4.Location = new System.Drawing.Point(136, 128);
			this.g4.Name = "g4";
			this.g4.Size = new System.Drawing.Size(88, 120);
			this.g4.TabIndex = 6;
			this.g4.TabStop = false;
			// 
			// p4
			// 
			this.p4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p4.Location = new System.Drawing.Point(8, 88);
			this.p4.Name = "p4";
			this.p4.Size = new System.Drawing.Size(64, 24);
			this.p4.TabIndex = 3;
			this.p4.Text = "Empty";
			this.p4.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e4
			// 
			this.e4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e4.Location = new System.Drawing.Point(8, 64);
			this.e4.Name = "e4";
			this.e4.Size = new System.Drawing.Size(64, 24);
			this.e4.TabIndex = 2;
			this.e4.Text = "Even";
			this.e4.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h4
			// 
			this.h4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h4.Location = new System.Drawing.Point(8, 40);
			this.h4.Name = "h4";
			this.h4.Size = new System.Drawing.Size(64, 24);
			this.h4.TabIndex = 1;
			this.h4.Text = "Higher";
			this.h4.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l4
			// 
			this.l4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l4.Location = new System.Drawing.Point(8, 16);
			this.l4.Name = "l4";
			this.l4.Size = new System.Drawing.Size(72, 24);
			this.l4.TabIndex = 0;
			this.l4.Text = "Lower";
			this.l4.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g5
			// 
			this.g5.Controls.Add(this.p5);
			this.g5.Controls.Add(this.e5);
			this.g5.Controls.Add(this.h5);
			this.g5.Controls.Add(this.l5);
			this.g5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g5.Location = new System.Drawing.Point(328, 128);
			this.g5.Name = "g5";
			this.g5.Size = new System.Drawing.Size(88, 120);
			this.g5.TabIndex = 7;
			this.g5.TabStop = false;
			// 
			// p5
			// 
			this.p5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p5.Location = new System.Drawing.Point(8, 88);
			this.p5.Name = "p5";
			this.p5.Size = new System.Drawing.Size(64, 24);
			this.p5.TabIndex = 3;
			this.p5.Text = "Empty";
			this.p5.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e5
			// 
			this.e5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e5.Location = new System.Drawing.Point(8, 64);
			this.e5.Name = "e5";
			this.e5.Size = new System.Drawing.Size(64, 24);
			this.e5.TabIndex = 2;
			this.e5.Text = "Even";
			this.e5.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h5
			// 
			this.h5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h5.Location = new System.Drawing.Point(8, 40);
			this.h5.Name = "h5";
			this.h5.Size = new System.Drawing.Size(64, 24);
			this.h5.TabIndex = 1;
			this.h5.Text = "Higher";
			this.h5.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l5
			// 
			this.l5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l5.Location = new System.Drawing.Point(8, 16);
			this.l5.Name = "l5";
			this.l5.Size = new System.Drawing.Size(72, 24);
			this.l5.TabIndex = 0;
			this.l5.Text = "Lower";
			this.l5.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g6
			// 
			this.g6.Controls.Add(this.p6);
			this.g6.Controls.Add(this.e6);
			this.g6.Controls.Add(this.h6);
			this.g6.Controls.Add(this.l6);
			this.g6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g6.Location = new System.Drawing.Point(136, 248);
			this.g6.Name = "g6";
			this.g6.Size = new System.Drawing.Size(88, 120);
			this.g6.TabIndex = 8;
			this.g6.TabStop = false;
			// 
			// p6
			// 
			this.p6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p6.Location = new System.Drawing.Point(8, 88);
			this.p6.Name = "p6";
			this.p6.Size = new System.Drawing.Size(64, 24);
			this.p6.TabIndex = 3;
			this.p6.Text = "Empty";
			this.p6.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e6
			// 
			this.e6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e6.Location = new System.Drawing.Point(8, 64);
			this.e6.Name = "e6";
			this.e6.Size = new System.Drawing.Size(64, 24);
			this.e6.TabIndex = 2;
			this.e6.Text = "Even";
			this.e6.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h6
			// 
			this.h6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h6.Location = new System.Drawing.Point(8, 40);
			this.h6.Name = "h6";
			this.h6.Size = new System.Drawing.Size(64, 24);
			this.h6.TabIndex = 1;
			this.h6.Text = "Higher";
			this.h6.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l6
			// 
			this.l6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l6.Location = new System.Drawing.Point(8, 16);
			this.l6.Name = "l6";
			this.l6.Size = new System.Drawing.Size(72, 24);
			this.l6.TabIndex = 0;
			this.l6.Text = "Lower";
			this.l6.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g7
			// 
			this.g7.Controls.Add(this.p7);
			this.g7.Controls.Add(this.e7);
			this.g7.Controls.Add(this.h7);
			this.g7.Controls.Add(this.l7);
			this.g7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g7.Location = new System.Drawing.Point(232, 248);
			this.g7.Name = "g7";
			this.g7.Size = new System.Drawing.Size(88, 120);
			this.g7.TabIndex = 9;
			this.g7.TabStop = false;
			// 
			// p7
			// 
			this.p7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p7.Location = new System.Drawing.Point(8, 88);
			this.p7.Name = "p7";
			this.p7.Size = new System.Drawing.Size(64, 24);
			this.p7.TabIndex = 3;
			this.p7.Text = "Empty";
			this.p7.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e7
			// 
			this.e7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e7.Location = new System.Drawing.Point(8, 64);
			this.e7.Name = "e7";
			this.e7.Size = new System.Drawing.Size(64, 24);
			this.e7.TabIndex = 2;
			this.e7.Text = "Even";
			this.e7.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h7
			// 
			this.h7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h7.Location = new System.Drawing.Point(8, 40);
			this.h7.Name = "h7";
			this.h7.Size = new System.Drawing.Size(64, 24);
			this.h7.TabIndex = 1;
			this.h7.Text = "Higher";
			this.h7.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l7
			// 
			this.l7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l7.Location = new System.Drawing.Point(8, 16);
			this.l7.Name = "l7";
			this.l7.Size = new System.Drawing.Size(72, 24);
			this.l7.TabIndex = 0;
			this.l7.Text = "Lower";
			this.l7.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// g8
			// 
			this.g8.Controls.Add(this.p8);
			this.g8.Controls.Add(this.e8);
			this.g8.Controls.Add(this.h8);
			this.g8.Controls.Add(this.l8);
			this.g8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.g8.Location = new System.Drawing.Point(328, 248);
			this.g8.Name = "g8";
			this.g8.Size = new System.Drawing.Size(88, 120);
			this.g8.TabIndex = 10;
			this.g8.TabStop = false;
			// 
			// p8
			// 
			this.p8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.p8.Location = new System.Drawing.Point(8, 88);
			this.p8.Name = "p8";
			this.p8.Size = new System.Drawing.Size(64, 24);
			this.p8.TabIndex = 3;
			this.p8.Text = "Empty";
			this.p8.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// e8
			// 
			this.e8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.e8.Location = new System.Drawing.Point(8, 64);
			this.e8.Name = "e8";
			this.e8.Size = new System.Drawing.Size(64, 24);
			this.e8.TabIndex = 2;
			this.e8.Text = "Even";
			this.e8.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// h8
			// 
			this.h8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.h8.Location = new System.Drawing.Point(8, 40);
			this.h8.Name = "h8";
			this.h8.Size = new System.Drawing.Size(64, 24);
			this.h8.TabIndex = 1;
			this.h8.Text = "Higher";
			this.h8.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// l8
			// 
			this.l8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.l8.Location = new System.Drawing.Point(8, 16);
			this.l8.Name = "l8";
			this.l8.Size = new System.Drawing.Size(72, 24);
			this.l8.TabIndex = 0;
			this.l8.Text = "Lower";
			this.l8.CheckedChanged += new System.EventHandler(this.l1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(424, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 11;
			this.button1.Text = "Load";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(424, 48);
			this.button2.Name = "button2";
			this.button2.TabIndex = 12;
			this.button2.Text = "Save";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cmbList
			// 
			this.cmbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbList.Location = new System.Drawing.Point(8, 16);
			this.cmbList.Name = "cmbList";
			this.cmbList.Size = new System.Drawing.Size(120, 21);
			this.cmbList.TabIndex = 13;
			this.cmbList.SelectedIndexChanged += new System.EventHandler(this.cmbList_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 378);
			this.Controls.Add(this.cmbList);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.g8);
			this.Controls.Add(this.g7);
			this.Controls.Add(this.g6);
			this.Controls.Add(this.g5);
			this.Controls.Add(this.g4);
			this.Controls.Add(this.g3);
			this.Controls.Add(this.g2);
			this.Controls.Add(this.g1);
			this.Controls.Add(this.art);
			this.Controls.Add(this.lst);
			this.Name = "Form1";
			this.Text = "Tiles Editor";
			this.g1.ResumeLayout(false);
			this.g2.ResumeLayout(false);
			this.g3.ResumeLayout(false);
			this.g4.ResumeLayout(false);
			this.g5.ResumeLayout(false);
			this.g6.ResumeLayout(false);
			this.g7.ResumeLayout(false);
			this.g8.ResumeLayout(false);
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
		private List<TileSet> m_TileSets;
		// Issue 10 - End
		private TileSet m_Set;

		private TileMask m_Mask;
		private bool m_Setting = false;

		private TileMask Mask
		{
			get { return m_Mask; }
			set
			{
				m_Mask = value;
				art.ArtIndex = m_Mask.ID;
				SetFlags();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			m_TileSets = TileSet.Load();
			button1.Enabled = false;

			foreach( TileSet tileset in m_TileSets )
			{
				cmbList.Items.Add( tileset );
			}

			cmbList.SelectedIndex = 0;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			TileSet.Save( m_TileSets );
		}

		private void cmbList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Set = cmbList.SelectedItem as TileSet;

			lst.BeginUpdate();
			lst.Items.Clear();

			foreach ( TileMask mask in m_Set.Tiles )
			{
				lst.Items.Add( mask );
			}

			lst.EndUpdate();
		}

		private void SetFlags()
		{
			m_Setting = true;

			uint flags = m_Mask.Flags;

			for ( int i = 7; i >= 0; i-- )
			{
				uint flag = (uint) ( flags & 0xF );
				flags = flags >> 4;

				m_Groups[ i ].Text = flag.ToString( "X" );

				CheckBox[] boxes = m_Boxes[ i ];

				boxes[ 0 ].Checked = ( flag & (uint) 0x1 ) == 0x1;
				boxes[ 1 ].Checked = ( flag & (uint) 0x2 ) == 0x2;
				boxes[ 2 ].Checked = ( flag & (uint) 0x4 ) == 0x4;
				boxes[ 3 ].Checked = ( flag & (uint) 0x8 ) == 0x8;
			}

			m_Setting = false;
		}

		private void UpdateFlags()
		{
			// Crashfix - Smjert
			if (m_Mask == null)
				return; 

			uint flags = (uint) 0;

			for ( int i = 0; i < 8; i++ )
			{
				uint flag = (uint) 0;

				CheckBox[] boxes = m_Boxes[ i ];

				flag |= boxes[ 3 ].Checked ? (uint) 1 : (uint) 0;
				flag = flag << 1;
				flag |= boxes[ 2 ].Checked ? (uint) 1 : (uint) 0;
				flag = flag << 1;
				flag |= boxes[ 1 ].Checked ? (uint) 1 : (uint) 0;
				flag = flag << 1;
				flag |= boxes[ 0 ].Checked ? (uint) 1 : (uint) 0;

				m_Groups[ i ].Text = flag.ToString( "X" );

				flags |= flag;

				if ( i < 7 )
				{
					flags = flags << 4;
				}
			}

			m_Mask.Flags = flags;
		}

		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Mask = lst.SelectedItem as TileMask;
		}

		private void l1_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( ! m_Setting )
			{
				UpdateFlags();
			}
		}
	}
}