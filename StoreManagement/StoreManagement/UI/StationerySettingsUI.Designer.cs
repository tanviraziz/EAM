namespace StoreManagement.UI
{
    partial class StationerySettingsUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationerySettingsUI));
            this.stationarySettingsTabControl = new FlatTabControl.FlatTabControl();
            this.itemTabPage = new System.Windows.Forms.TabPage();
            this.itemListView = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.addItemButton = new System.Windows.Forms.ToolStripButton();
            this.editItemButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mainCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.categoryTabPage = new System.Windows.Forms.TabPage();
            this.itemCategoryGroupBox = new System.Windows.Forms.GroupBox();
            this.subCategoryListView = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.itemSubCategoryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.addItemSubCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.refreshItemSubCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.itemCategoryListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.itemCategoryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.addItemCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.refreshItamCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stationaryCategoryListView = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.stationaryCategoryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.addStationaryCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.refreshStaionaryCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.stationarySettingsTabControl.SuspendLayout();
            this.itemTabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.categoryTabPage.SuspendLayout();
            this.itemCategoryGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.itemGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.SuspendLayout();
            // 
            // stationarySettingsTabControl
            // 
            this.stationarySettingsTabControl.Controls.Add(this.itemTabPage);
            this.stationarySettingsTabControl.Controls.Add(this.categoryTabPage);
            this.stationarySettingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationarySettingsTabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationarySettingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.stationarySettingsTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.stationarySettingsTabControl.Name = "stationarySettingsTabControl";
            this.stationarySettingsTabControl.SelectedIndex = 0;
            this.stationarySettingsTabControl.Size = new System.Drawing.Size(663, 551);
            this.stationarySettingsTabControl.TabIndex = 12;
            this.stationarySettingsTabControl.SelectedIndexChanged += new System.EventHandler(this.stationarySettingsTabControl_SelectedIndexChanged);
            // 
            // itemTabPage
            // 
            this.itemTabPage.Controls.Add(this.itemListView);
            this.itemTabPage.Controls.Add(this.panel3);
            this.itemTabPage.Location = new System.Drawing.Point(4, 25);
            this.itemTabPage.Name = "itemTabPage";
            this.itemTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemTabPage.Size = new System.Drawing.Size(655, 522);
            this.itemTabPage.TabIndex = 0;
            this.itemTabPage.Text = "Items";
            this.itemTabPage.UseVisualStyleBackColor = true;
            // 
            // itemListView
            // 
            this.itemListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemListView.FullRowSelect = true;
            this.itemListView.GridLines = true;
            this.itemListView.Location = new System.Drawing.Point(3, 37);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(649, 482);
            this.itemListView.TabIndex = 14;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            this.itemListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.itemListView_ColumnClick);
            this.itemListView.DoubleClick += new System.EventHandler(this.itemListView_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel3.Controls.Add(this.toolStrip3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 34);
            this.panel3.TabIndex = 13;
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemButton,
            this.editItemButton,
            this.toolStripDropDownButton1,
            this.toolStripButton1});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip3.Size = new System.Drawing.Size(649, 34);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // addItemButton
            // 
            this.addItemButton.AutoSize = false;
            this.addItemButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemButton.ForeColor = System.Drawing.Color.White;
            this.addItemButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(64, 32);
            this.addItemButton.Text = " New";
            this.addItemButton.ToolTipText = " Add New Item";
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // editItemButton
            // 
            this.editItemButton.AutoSize = false;
            this.editItemButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItemButton.ForeColor = System.Drawing.Color.White;
            this.editItemButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editItemButton.Name = "editItemButton";
            this.editItemButton.Size = new System.Drawing.Size(64, 32);
            this.editItemButton.Text = " Edit";
            this.editItemButton.ToolTipText = " Edit an Item";
            this.editItemButton.Click += new System.EventHandler(this.editItemButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainCategoryToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.subCategoryToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(77, 31);
            this.toolStripDropDownButton1.Text = " Group By ";
            // 
            // mainCategoryToolStripMenuItem
            // 
            this.mainCategoryToolStripMenuItem.Name = "mainCategoryToolStripMenuItem";
            this.mainCategoryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mainCategoryToolStripMenuItem.Text = "Main Category";
            this.mainCategoryToolStripMenuItem.Click += new System.EventHandler(this.mainCategoryToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // subCategoryToolStripMenuItem
            // 
            this.subCategoryToolStripMenuItem.Name = "subCategoryToolStripMenuItem";
            this.subCategoryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.subCategoryToolStripMenuItem.Text = "Sub Category";
            this.subCategoryToolStripMenuItem.Click += new System.EventHandler(this.subCategoryToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = global::StoreManagement.Properties.Resources.refresh32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(90, 32);
            this.toolStripButton1.Text = " Refresh";
            this.toolStripButton1.ToolTipText = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // categoryTabPage
            // 
            this.categoryTabPage.Controls.Add(this.itemCategoryGroupBox);
            this.categoryTabPage.Controls.Add(this.itemGroupBox);
            this.categoryTabPage.Controls.Add(this.groupBox1);
            this.categoryTabPage.Location = new System.Drawing.Point(4, 25);
            this.categoryTabPage.Name = "categoryTabPage";
            this.categoryTabPage.Size = new System.Drawing.Size(655, 522);
            this.categoryTabPage.TabIndex = 2;
            this.categoryTabPage.Text = "Category & Sub Category";
            // 
            // itemCategoryGroupBox
            // 
            this.itemCategoryGroupBox.Controls.Add(this.subCategoryListView);
            this.itemCategoryGroupBox.Controls.Add(this.panel2);
            this.itemCategoryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemCategoryGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCategoryGroupBox.Location = new System.Drawing.Point(367, 159);
            this.itemCategoryGroupBox.Name = "itemCategoryGroupBox";
            this.itemCategoryGroupBox.Size = new System.Drawing.Size(288, 363);
            this.itemCategoryGroupBox.TabIndex = 17;
            this.itemCategoryGroupBox.TabStop = false;
            this.itemCategoryGroupBox.Text = "Item Category";
            // 
            // subCategoryListView
            // 
            this.subCategoryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subCategoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subCategoryListView.FullRowSelect = true;
            this.subCategoryListView.GridLines = true;
            this.subCategoryListView.Location = new System.Drawing.Point(3, 51);
            this.subCategoryListView.Name = "subCategoryListView";
            this.subCategoryListView.Size = new System.Drawing.Size(282, 309);
            this.subCategoryListView.TabIndex = 13;
            this.subCategoryListView.UseCompatibleStateImageBehavior = false;
            this.subCategoryListView.View = System.Windows.Forms.View.Details;
            this.subCategoryListView.SelectedIndexChanged += new System.EventHandler(this.subCategoryListView_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel2.Controls.Add(this.toolStrip4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 34);
            this.panel2.TabIndex = 12;
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSubCategoryTextBox,
            this.addItemSubCategoryButton,
            this.refreshItemSubCategoryButton});
            this.toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip4.Size = new System.Drawing.Size(282, 34);
            this.toolStrip4.TabIndex = 3;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // itemSubCategoryTextBox
            // 
            this.itemSubCategoryTextBox.MaxLength = 250;
            this.itemSubCategoryTextBox.Name = "itemSubCategoryTextBox";
            this.itemSubCategoryTextBox.Size = new System.Drawing.Size(250, 21);
            // 
            // addItemSubCategoryButton
            // 
            this.addItemSubCategoryButton.AutoSize = false;
            this.addItemSubCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemSubCategoryButton.ForeColor = System.Drawing.Color.White;
            this.addItemSubCategoryButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addItemSubCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addItemSubCategoryButton.Name = "addItemSubCategoryButton";
            this.addItemSubCategoryButton.Size = new System.Drawing.Size(54, 32);
            this.addItemSubCategoryButton.Text = " New";
            this.addItemSubCategoryButton.ToolTipText = "Add  New";
            this.addItemSubCategoryButton.Click += new System.EventHandler(this.addItemSubCategoryButton_Click);
            // 
            // refreshItemSubCategoryButton
            // 
            this.refreshItemSubCategoryButton.AutoSize = false;
            this.refreshItemSubCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshItemSubCategoryButton.ForeColor = System.Drawing.Color.White;
            this.refreshItemSubCategoryButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshItemSubCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshItemSubCategoryButton.Name = "refreshItemSubCategoryButton";
            this.refreshItemSubCategoryButton.Size = new System.Drawing.Size(70, 31);
            this.refreshItemSubCategoryButton.Text = " Refresh";
            this.refreshItemSubCategoryButton.ToolTipText = " Refresh List";
            this.refreshItemSubCategoryButton.Click += new System.EventHandler(this.refreshItemSubCategoryButton_Click);
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.itemCategoryListView);
            this.itemGroupBox.Controls.Add(this.panel1);
            this.itemGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemGroupBox.Location = new System.Drawing.Point(0, 159);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(367, 363);
            this.itemGroupBox.TabIndex = 16;
            this.itemGroupBox.TabStop = false;
            this.itemGroupBox.Text = "Items ";
            // 
            // itemCategoryListView
            // 
            this.itemCategoryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemCategoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemCategoryListView.FullRowSelect = true;
            this.itemCategoryListView.GridLines = true;
            this.itemCategoryListView.Location = new System.Drawing.Point(3, 51);
            this.itemCategoryListView.Name = "itemCategoryListView";
            this.itemCategoryListView.Size = new System.Drawing.Size(361, 309);
            this.itemCategoryListView.TabIndex = 13;
            this.itemCategoryListView.UseCompatibleStateImageBehavior = false;
            this.itemCategoryListView.View = System.Windows.Forms.View.Details;
            this.itemCategoryListView.SelectedIndexChanged += new System.EventHandler(this.itemCategoryListView_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 34);
            this.panel1.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCategoryTextBox,
            this.addItemCategoryButton,
            this.refreshItamCategoryButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(361, 34);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // itemCategoryTextBox
            // 
            this.itemCategoryTextBox.MaxLength = 100;
            this.itemCategoryTextBox.Name = "itemCategoryTextBox";
            this.itemCategoryTextBox.Size = new System.Drawing.Size(200, 34);
            // 
            // addItemCategoryButton
            // 
            this.addItemCategoryButton.AutoSize = false;
            this.addItemCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemCategoryButton.ForeColor = System.Drawing.Color.White;
            this.addItemCategoryButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addItemCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addItemCategoryButton.Name = "addItemCategoryButton";
            this.addItemCategoryButton.Size = new System.Drawing.Size(54, 32);
            this.addItemCategoryButton.Text = " New";
            this.addItemCategoryButton.ToolTipText = " Add New";
            this.addItemCategoryButton.Click += new System.EventHandler(this.addItemCategoryButton_Click);
            // 
            // refreshItamCategoryButton
            // 
            this.refreshItamCategoryButton.AutoSize = false;
            this.refreshItamCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshItamCategoryButton.ForeColor = System.Drawing.Color.White;
            this.refreshItamCategoryButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshItamCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshItamCategoryButton.Name = "refreshItamCategoryButton";
            this.refreshItamCategoryButton.Size = new System.Drawing.Size(70, 31);
            this.refreshItamCategoryButton.Text = " Refresh";
            this.refreshItamCategoryButton.ToolTipText = " Refresh List";
            this.refreshItamCategoryButton.Click += new System.EventHandler(this.refreshItamCategoryButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stationaryCategoryListView);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 159);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stationary Category";
            // 
            // stationaryCategoryListView
            // 
            this.stationaryCategoryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stationaryCategoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationaryCategoryListView.FullRowSelect = true;
            this.stationaryCategoryListView.GridLines = true;
            this.stationaryCategoryListView.Location = new System.Drawing.Point(3, 51);
            this.stationaryCategoryListView.Name = "stationaryCategoryListView";
            this.stationaryCategoryListView.Size = new System.Drawing.Size(649, 105);
            this.stationaryCategoryListView.TabIndex = 13;
            this.stationaryCategoryListView.UseCompatibleStateImageBehavior = false;
            this.stationaryCategoryListView.View = System.Windows.Forms.View.Details;
            this.stationaryCategoryListView.SelectedIndexChanged += new System.EventHandler(this.stationaryCategoryListView_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(649, 34);
            this.panel4.TabIndex = 12;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stationaryCategoryTextBox,
            this.addStationaryCategoryButton,
            this.refreshStaionaryCategoryButton});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip2.Size = new System.Drawing.Size(649, 34);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // stationaryCategoryTextBox
            // 
            this.stationaryCategoryTextBox.MaxLength = 250;
            this.stationaryCategoryTextBox.Name = "stationaryCategoryTextBox";
            this.stationaryCategoryTextBox.Size = new System.Drawing.Size(250, 21);
            // 
            // addStationaryCategoryButton
            // 
            this.addStationaryCategoryButton.AutoSize = false;
            this.addStationaryCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStationaryCategoryButton.ForeColor = System.Drawing.Color.White;
            this.addStationaryCategoryButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addStationaryCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addStationaryCategoryButton.Name = "addStationaryCategoryButton";
            this.addStationaryCategoryButton.Size = new System.Drawing.Size(54, 32);
            this.addStationaryCategoryButton.Text = " New";
            this.addStationaryCategoryButton.ToolTipText = " Add New";
            this.addStationaryCategoryButton.Click += new System.EventHandler(this.addStationaryCategoryButton_Click);
            // 
            // refreshStaionaryCategoryButton
            // 
            this.refreshStaionaryCategoryButton.AutoSize = false;
            this.refreshStaionaryCategoryButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshStaionaryCategoryButton.ForeColor = System.Drawing.Color.White;
            this.refreshStaionaryCategoryButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshStaionaryCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshStaionaryCategoryButton.Name = "refreshStaionaryCategoryButton";
            this.refreshStaionaryCategoryButton.Size = new System.Drawing.Size(70, 31);
            this.refreshStaionaryCategoryButton.Text = " Refresh";
            this.refreshStaionaryCategoryButton.ToolTipText = " Refresh List";
            this.refreshStaionaryCategoryButton.Click += new System.EventHandler(this.refreshStaionaryCategoryButton_Click);
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1});
            this.taskPane1.Location = new System.Drawing.Point(663, 0);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(115, 551);
            this.taskPane1.TabIndex = 11;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(91, 100);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Search";
            // 
            // StationerySettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(73)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(778, 551);
            this.Controls.Add(this.stationarySettingsTabControl);
            this.Controls.Add(this.taskPane1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(625, 585);
            this.Name = "StationerySettingsUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Management";
            this.Load += new System.EventHandler(this.StationarySettingsUI_Load);
            this.stationarySettingsTabControl.ResumeLayout(false);
            this.itemTabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.categoryTabPage.ResumeLayout(false);
            this.itemCategoryGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.itemGroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.taskPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatTabControl.FlatTabControl stationarySettingsTabControl;
        private System.Windows.Forms.TabPage itemTabPage;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton addItemButton;
        private System.Windows.Forms.ToolStripButton editItemButton;
        private System.Windows.Forms.TabPage categoryTabPage;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private System.Windows.Forms.GroupBox itemCategoryGroupBox;
        private System.Windows.Forms.ListView subCategoryListView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton addItemSubCategoryButton;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private System.Windows.Forms.ListView itemCategoryListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addItemCategoryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView stationaryCategoryListView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton addStationaryCategoryButton;
        private System.Windows.Forms.ToolStripButton refreshItemSubCategoryButton;
        private System.Windows.Forms.ToolStripButton refreshItamCategoryButton;
        private System.Windows.Forms.ToolStripButton refreshStaionaryCategoryButton;
        private System.Windows.Forms.ToolStripTextBox itemSubCategoryTextBox;
        private System.Windows.Forms.ToolStripTextBox itemCategoryTextBox;
        private System.Windows.Forms.ToolStripTextBox stationaryCategoryTextBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mainCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;








    }
}