namespace Winform_Framework
{
    partial class FrmMain
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
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem4 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem5 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem6 = new AntdUI.MenuItem();
            AntdUI.Tabs.StyleCard styleCard1 = new AntdUI.Tabs.StyleCard();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.titlebar = new AntdUI.PageHeader();
            this.dropTranslate = new AntdUI.Dropdown();
            this.panLeft = new AntdUI.Panel();
            this.menuLeft = new AntdUI.Menu();
            this.btnCollapse = new AntdUI.Button();
            this.tabsMain = new AntdUI.Tabs();
            this.pageMain = new AntdUI.TabPage();
            this.flpan2 = new AntdUI.In.FlowLayoutPanel();
            this.panel3 = new AntdUI.Panel();
            this.flpan1 = new AntdUI.In.FlowLayoutPanel();
            this.titlebar.SuspendLayout();
            this.panLeft.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(137)))), ((int)(((byte)(237)))));
            this.titlebar.Controls.Add(this.dropTranslate);
            this.titlebar.DividerShow = true;
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.ForeColor = System.Drawing.Color.White;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.ShowButton = true;
            this.titlebar.ShowIcon = true;
            this.titlebar.Size = new System.Drawing.Size(1024, 40);
            this.titlebar.SubText = "Demo";
            this.titlebar.TabIndex = 0;
            this.titlebar.Text = "Main Window";
            // 
            // dropTranslate
            // 
            this.dropTranslate.Dock = System.Windows.Forms.DockStyle.Right;
            this.dropTranslate.Ghost = true;
            this.dropTranslate.IconRatio = 0.8F;
            this.dropTranslate.IconSvg = "TranslationOutlined";
            this.dropTranslate.Items.AddRange(new object[] {
            "简体中文",
            "English"});
            this.dropTranslate.Location = new System.Drawing.Point(830, 0);
            this.dropTranslate.Name = "dropTranslate";
            this.dropTranslate.Placement = AntdUI.TAlignFrom.BR;
            this.dropTranslate.Size = new System.Drawing.Size(50, 40);
            this.dropTranslate.TabIndex = 0;
            this.dropTranslate.Trigger = AntdUI.Trigger.Hover;
            this.dropTranslate.WaveSize = 0;
            // 
            // panLeft
            // 
            this.panLeft.Back = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(188)))), ((int)(((byte)(236)))));
            this.panLeft.Controls.Add(this.menuLeft);
            this.panLeft.Controls.Add(this.btnCollapse);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 40);
            this.panLeft.Name = "panLeft";
            this.panLeft.Radius = 0;
            this.panLeft.Size = new System.Drawing.Size(50, 600);
            this.panLeft.TabIndex = 1;
            this.panLeft.Text = "panel1";
            // 
            // menuLeft
            // 
            this.menuLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(188)))), ((int)(((byte)(236)))));
            this.menuLeft.Collapsed = true;
            this.menuLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuLeft.Indent = true;
            menuItem1.IconSvg = "AppstoreOutlined";
            menuItem2.Text = "菜单1-1";
            menuItem3.Text = "菜单1-2";
            menuItem1.Sub.Add(menuItem2);
            menuItem1.Sub.Add(menuItem3);
            menuItem1.Text = "菜单1";
            menuItem4.IconSvg = "LayoutOutlined";
            menuItem5.Text = "菜单2-1";
            menuItem6.Text = "菜单2-2";
            menuItem4.Sub.Add(menuItem5);
            menuItem4.Sub.Add(menuItem6);
            menuItem4.Text = "菜单2";
            this.menuLeft.Items.Add(menuItem1);
            this.menuLeft.Items.Add(menuItem4);
            this.menuLeft.Location = new System.Drawing.Point(0, 0);
            this.menuLeft.Name = "menuLeft";
            this.menuLeft.Padding = new System.Windows.Forms.Padding(4);
            this.menuLeft.Size = new System.Drawing.Size(50, 560);
            this.menuLeft.TabIndex = 1;
            this.menuLeft.Text = "menu1";
            this.menuLeft.SelectChanged += new AntdUI.SelectEventHandler(this.menuLeft_SelectChanged);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCollapse.Ghost = true;
            this.btnCollapse.IconRatio = 1F;
            this.btnCollapse.IconSvg = "MenuUnfoldOutlined";
            this.btnCollapse.Location = new System.Drawing.Point(0, 560);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Radius = 0;
            this.btnCollapse.Size = new System.Drawing.Size(50, 40);
            this.btnCollapse.TabIndex = 3;
            this.btnCollapse.ToggleIconSvg = "MenuFoldOutlined";
            this.btnCollapse.WaveSize = 0;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.pageMain);
            this.tabsMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.Gap = 12;
            this.tabsMain.Location = new System.Drawing.Point(50, 40);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.Pages.Add(this.pageMain);
            this.tabsMain.Size = new System.Drawing.Size(974, 600);
            styleCard1.Closable = true;
            styleCard1.Gap = 6;
            this.tabsMain.Style = styleCard1;
            this.tabsMain.TabIndex = 2;
            this.tabsMain.Text = "tabs1";
            this.tabsMain.Type = AntdUI.TabType.Card;
            // 
            // pageMain
            // 
            this.pageMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pageMain.Controls.Add(this.flpan2);
            this.pageMain.Controls.Add(this.panel3);
            this.pageMain.Controls.Add(this.flpan1);
            this.pageMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageMain.IconSvg = "HomeOutlined";
            this.pageMain.Location = new System.Drawing.Point(3, 35);
            this.pageMain.Margin = new System.Windows.Forms.Padding(4);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(4);
            this.pageMain.Size = new System.Drawing.Size(968, 562);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "主页";
            // 
            // flpan2
            // 
            this.flpan2.BackColor = System.Drawing.SystemColors.Control;
            this.flpan2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpan2.Location = new System.Drawing.Point(4, 164);
            this.flpan2.Name = "flpan2";
            this.flpan2.Size = new System.Drawing.Size(960, 150);
            this.flpan2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Back = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 10);
            this.panel3.TabIndex = 3;
            this.panel3.Text = "panel3";
            // 
            // flpan1
            // 
            this.flpan1.BackColor = System.Drawing.SystemColors.Control;
            this.flpan1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpan1.Location = new System.Drawing.Point(4, 4);
            this.flpan1.Name = "flpan1";
            this.flpan1.Size = new System.Drawing.Size(960, 150);
            this.flpan1.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.ControlBox = false;
            this.Controls.Add(this.tabsMain);
            this.Controls.Add(this.panLeft);
            this.Controls.Add(this.titlebar);
            this.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.titlebar.ResumeLayout(false);
            this.panLeft.ResumeLayout(false);
            this.tabsMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader titlebar;
        private AntdUI.Panel panLeft;
        private AntdUI.Tabs tabsMain;
        private AntdUI.TabPage pageMain;
        private AntdUI.Menu menuLeft;
        private AntdUI.Button btnCollapse;
        private AntdUI.Dropdown dropTranslate;
        private AntdUI.Panel panel3;
        private AntdUI.In.FlowLayoutPanel flpan2;
        private AntdUI.In.FlowLayoutPanel flpan1;
    }
}