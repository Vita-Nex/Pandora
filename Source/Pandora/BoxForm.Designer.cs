namespace TheBox
{
    partial class BoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bigTabControl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabDeco = new System.Windows.Forms.TabPage();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.tabTravel = new System.Windows.Forms.TabPage();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.tabNpcs = new System.Windows.Forms.TabPage();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.tabDoors = new System.Windows.Forms.TabPage();
            this.tabLights = new System.Windows.Forms.TabPage();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.smallTabControl = new System.Windows.Forms.TabControl();
            this.tabArt = new System.Windows.Forms.TabPage();
            this.artViewer = new TheBox.ArtViewer.ArtViewer();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSmallProps = new System.Windows.Forms.TabPage();
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.generalPage = new TheBox.Pages.General();
            this.decoPage = new TheBox.Pages.Deco();
            this.propsPage = new TheBox.Pages.Props();
            this.travelPage = new TheBox.Pages.Travel();
            this.itemsPage = new TheBox.Pages.Items();
            this.mobilesPage = new TheBox.Pages.Mobiles();
            this.adminPage = new TheBox.Pages.Admin();
            this.doorsPage = new TheBox.Pages.Doors();
            this.lightsPage = new TheBox.Pages.Lights();
            this.notesPage = new TheBox.Pages.Notes();
            this.propManager = new TheBox.Controls.PropManager();
            this.topBar = new TheBox.Controls.TopBar();
            this.tableLayoutPanel.SuspendLayout();
            this.bigTabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDeco.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabTravel.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabNpcs.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.tabDoors.SuspendLayout();
            this.tabLights.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.smallTabControl.SuspendLayout();
            this.tabArt.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabSmallProps.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.Controls.Add(this.bigTabControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.smallTabControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.topBar, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(811, 350);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // bigTabControl
            // 
            this.bigTabControl.Controls.Add(this.tabGeneral);
            this.bigTabControl.Controls.Add(this.tabDeco);
            this.bigTabControl.Controls.Add(this.tabProperties);
            this.bigTabControl.Controls.Add(this.tabTravel);
            this.bigTabControl.Controls.Add(this.tabItems);
            this.bigTabControl.Controls.Add(this.tabNpcs);
            this.bigTabControl.Controls.Add(this.tabAdmin);
            this.bigTabControl.Controls.Add(this.tabDoors);
            this.bigTabControl.Controls.Add(this.tabLights);
            this.bigTabControl.Controls.Add(this.tabNotes);
            this.bigTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigTabControl.Location = new System.Drawing.Point(3, 22);
            this.bigTabControl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.bigTabControl.Name = "bigTabControl";
            this.bigTabControl.SelectedIndex = 0;
            this.bigTabControl.Size = new System.Drawing.Size(605, 325);
            this.bigTabControl.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.generalPage);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(597, 299);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Tabs.General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabDeco
            // 
            this.tabDeco.Controls.Add(this.decoPage);
            this.tabDeco.Location = new System.Drawing.Point(4, 22);
            this.tabDeco.Name = "tabDeco";
            this.tabDeco.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeco.Size = new System.Drawing.Size(670, 292);
            this.tabDeco.TabIndex = 1;
            this.tabDeco.Text = "Tabs.Deco";
            this.tabDeco.UseVisualStyleBackColor = true;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.propsPage);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(670, 292);
            this.tabProperties.TabIndex = 9;
            this.tabProperties.Text = "Tabs.Props";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // tabTravel
            // 
            this.tabTravel.Controls.Add(this.travelPage);
            this.tabTravel.Location = new System.Drawing.Point(4, 22);
            this.tabTravel.Name = "tabTravel";
            this.tabTravel.Padding = new System.Windows.Forms.Padding(3);
            this.tabTravel.Size = new System.Drawing.Size(670, 292);
            this.tabTravel.TabIndex = 2;
            this.tabTravel.Text = "Tabs.Travel";
            this.tabTravel.UseVisualStyleBackColor = true;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.itemsPage);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(670, 292);
            this.tabItems.TabIndex = 3;
            this.tabItems.Text = "Tabs.Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // tabNpcs
            // 
            this.tabNpcs.Controls.Add(this.mobilesPage);
            this.tabNpcs.Location = new System.Drawing.Point(4, 22);
            this.tabNpcs.Name = "tabNpcs";
            this.tabNpcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabNpcs.Size = new System.Drawing.Size(670, 292);
            this.tabNpcs.TabIndex = 4;
            this.tabNpcs.Text = "Tabs.NPCs";
            this.tabNpcs.UseVisualStyleBackColor = true;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.adminPage);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(670, 292);
            this.tabAdmin.TabIndex = 5;
            this.tabAdmin.Text = "Tabs.Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabDoors
            // 
            this.tabDoors.Controls.Add(this.doorsPage);
            this.tabDoors.Location = new System.Drawing.Point(4, 22);
            this.tabDoors.Name = "tabDoors";
            this.tabDoors.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoors.Size = new System.Drawing.Size(670, 292);
            this.tabDoors.TabIndex = 6;
            this.tabDoors.Text = "Tabs.Doors";
            this.tabDoors.UseVisualStyleBackColor = true;
            // 
            // tabLights
            // 
            this.tabLights.Controls.Add(this.lightsPage);
            this.tabLights.Location = new System.Drawing.Point(4, 22);
            this.tabLights.Name = "tabLights";
            this.tabLights.Padding = new System.Windows.Forms.Padding(3);
            this.tabLights.Size = new System.Drawing.Size(670, 292);
            this.tabLights.TabIndex = 7;
            this.tabLights.Text = "Tabs.Lights";
            this.tabLights.UseVisualStyleBackColor = true;
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.notesPage);
            this.tabNotes.Location = new System.Drawing.Point(4, 22);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(670, 292);
            this.tabNotes.TabIndex = 8;
            this.tabNotes.Text = "Tabs.Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // smallTabControl
            // 
            this.smallTabControl.Controls.Add(this.tabArt);
            this.smallTabControl.Controls.Add(this.tabMap);
            this.smallTabControl.Controls.Add(this.tabSmallProps);
            this.smallTabControl.Controls.Add(this.tabCustom);
            this.smallTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallTabControl.Location = new System.Drawing.Point(614, 22);
            this.smallTabControl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.smallTabControl.Name = "smallTabControl";
            this.smallTabControl.SelectedIndex = 0;
            this.smallTabControl.Size = new System.Drawing.Size(194, 325);
            this.smallTabControl.TabIndex = 1;
            // 
            // tabArt
            // 
            this.tabArt.Controls.Add(this.artViewer);
            this.tabArt.Location = new System.Drawing.Point(4, 22);
            this.tabArt.Name = "tabArt";
            this.tabArt.Padding = new System.Windows.Forms.Padding(3);
            this.tabArt.Size = new System.Drawing.Size(186, 299);
            this.tabArt.TabIndex = 0;
            this.tabArt.Text = "Tabs.Art";
            this.tabArt.UseVisualStyleBackColor = true;
            // 
            // artViewer
            // 
            this.artViewer.Animate = false;
            this.artViewer.Art = TheBox.ArtViewer.Art.Items;
            this.artViewer.ArtIndex = 0;
            this.artViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artViewer.Hue = 0;
            this.artViewer.Location = new System.Drawing.Point(3, 3);
            this.artViewer.Name = "artViewer";
            this.artViewer.ResizeTallItems = false;
            this.artViewer.RoomView = true;
            this.artViewer.ShowHexID = true;
            this.artViewer.ShowID = true;
            this.artViewer.Size = new System.Drawing.Size(180, 293);
            this.artViewer.TabIndex = 0;
            this.artViewer.Text = "artViewer1";
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.label1);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(186, 299);
            this.tabMap.TabIndex = 1;
            this.tabMap.Text = "Tabs.Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MapViewer has designer problems";
            // 
            // tabSmallProps
            // 
            this.tabSmallProps.Controls.Add(this.propManager);
            this.tabSmallProps.Location = new System.Drawing.Point(4, 22);
            this.tabSmallProps.Name = "tabSmallProps";
            this.tabSmallProps.Size = new System.Drawing.Size(186, 299);
            this.tabSmallProps.TabIndex = 2;
            this.tabSmallProps.Text = "Tabs.Props";
            this.tabSmallProps.UseVisualStyleBackColor = true;
            // 
            // tabCustom
            // 
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Size = new System.Drawing.Size(223, 292);
            this.tabCustom.TabIndex = 3;
            this.tabCustom.Text = "Tabs.Custom";
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // generalPage
            // 
            this.generalPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalPage.Location = new System.Drawing.Point(3, 3);
            this.generalPage.Name = "generalPage";
            this.generalPage.Size = new System.Drawing.Size(591, 293);
            this.generalPage.TabIndex = 0;
            // 
            // decoPage
            // 
            this.decoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decoPage.Location = new System.Drawing.Point(3, 3);
            this.decoPage.Name = "decoPage";
            this.decoPage.Size = new System.Drawing.Size(664, 286);
            this.decoPage.TabIndex = 1;
            // 
            // propsPage
            // 
            this.propsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propsPage.Location = new System.Drawing.Point(3, 3);
            this.propsPage.Name = "propsPage";
            this.propsPage.SelectedProperty = null;
            this.propsPage.Size = new System.Drawing.Size(664, 286);
            this.propsPage.TabIndex = 0;
            // 
            // travelPage
            // 
            this.travelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelPage.Location = new System.Drawing.Point(3, 3);
            this.travelPage.Name = "travelPage";
            this.travelPage.Size = new System.Drawing.Size(664, 286);
            this.travelPage.TabIndex = 0;
            // 
            // itemsPage
            // 
            this.itemsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsPage.Location = new System.Drawing.Point(3, 3);
            this.itemsPage.Name = "itemsPage";
            this.itemsPage.Size = new System.Drawing.Size(664, 286);
            this.itemsPage.TabIndex = 0;
            // 
            // mobilesPage
            // 
            this.mobilesPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobilesPage.Location = new System.Drawing.Point(3, 3);
            this.mobilesPage.Name = "mobilesPage";
            this.mobilesPage.Size = new System.Drawing.Size(664, 286);
            this.mobilesPage.TabIndex = 0;
            // 
            // adminPage
            // 
            this.adminPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPage.Location = new System.Drawing.Point(3, 3);
            this.adminPage.Name = "adminPage";
            this.adminPage.Size = new System.Drawing.Size(664, 286);
            this.adminPage.TabIndex = 0;
            // 
            // doorsPage
            // 
            this.doorsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doorsPage.Location = new System.Drawing.Point(3, 3);
            this.doorsPage.Name = "doorsPage";
            this.doorsPage.Size = new System.Drawing.Size(664, 286);
            this.doorsPage.TabIndex = 0;
            // 
            // lightsPage
            // 
            this.lightsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightsPage.Location = new System.Drawing.Point(3, 3);
            this.lightsPage.Name = "lightsPage";
            this.lightsPage.Size = new System.Drawing.Size(664, 286);
            this.lightsPage.TabIndex = 0;
            // 
            // notesPage
            // 
            this.notesPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesPage.Location = new System.Drawing.Point(3, 3);
            this.notesPage.Name = "notesPage";
            this.notesPage.Size = new System.Drawing.Size(664, 286);
            this.notesPage.TabIndex = 0;
            // 
            // propManager
            // 
            this.propManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propManager.Location = new System.Drawing.Point(0, 0);
            this.propManager.Name = "propManager";
            this.propManager.Size = new System.Drawing.Size(186, 299);
            this.propManager.TabIndex = 0;
            // 
            // topBar
            // 
            this.tableLayoutPanel.SetColumnSpan(this.topBar, 2);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Margin = new System.Windows.Forms.Padding(0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(811, 22);
            this.topBar.TabIndex = 2;
            // 
            // BoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 350);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "BoxForm";
            this.Text = "BoxForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.bigTabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabDeco.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabTravel.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabNpcs.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.tabDoors.ResumeLayout(false);
            this.tabLights.ResumeLayout(false);
            this.tabNotes.ResumeLayout(false);
            this.smallTabControl.ResumeLayout(false);
            this.tabArt.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            this.tabMap.PerformLayout();
            this.tabSmallProps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl bigTabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDeco;
        private System.Windows.Forms.TabPage tabTravel;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabNpcs;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabDoors;
        private System.Windows.Forms.TabPage tabLights;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.TabControl smallTabControl;
        private System.Windows.Forms.TabPage tabArt;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TabPage tabSmallProps;
        private System.Windows.Forms.TabPage tabCustom;
        private TheBox.Pages.General generalPage;
        private TheBox.Pages.Deco decoPage;
        private TheBox.Pages.Props propsPage;
        private TheBox.Pages.Travel travelPage;
        private TheBox.Pages.Items itemsPage;
        private TheBox.Pages.Mobiles mobilesPage;
        private TheBox.Pages.Admin adminPage;
        private TheBox.Pages.Doors doorsPage;
        private TheBox.Pages.Lights lightsPage;
        private TheBox.Pages.Notes notesPage;
        private TheBox.ArtViewer.ArtViewer artViewer;
        private TheBox.Controls.PropManager propManager;
        private System.Windows.Forms.Label label1;
        private TheBox.Controls.TopBar topBar;
    }
}