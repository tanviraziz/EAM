namespace StoreManagement.UI
{
    partial class GrrReceiveActionUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.stockPostButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.grrInaMonthTaskItem = new XPExplorerBar.TaskItem();
            this.supplierWiseInaMonthTaskItem = new XPExplorerBar.TaskItem();
            this.monthWiseGrrsInaYearTaskItem = new XPExplorerBar.TaskItem();
            this.grrTabControl = new FlatTabControl.FlatTabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pendingOrdersListView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderDetailListView = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grrGroupBox = new System.Windows.Forms.GroupBox();
            this.grrListView = new System.Windows.Forms.ListView();
            this.grrDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.grrDetailListView = new System.Windows.Forms.ListView();
            this.completeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.completeListView = new System.Windows.Forms.ListView();
            this.completeGroupBox = new System.Windows.Forms.GroupBox();
            this.cDetailListView = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.grrTabControl.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grrGroupBox.SuspendLayout();
            this.grrDetailGroupBox.SuspendLayout();
            this.completeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.completeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 34);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.refreshButton,
            this.stockPostButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(651, 34);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.AutoSize = false;
            this.addButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(54, 32);
            this.addButton.Text = " New";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = false;
            this.editButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(54, 32);
            this.editButton.Text = " Edit";
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = false;
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(80, 32);
            this.refreshButton.Text = " Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // stockPostButton
            // 
            this.stockPostButton.AutoSize = false;
            this.stockPostButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.stockPostButton.Enabled = false;
            this.stockPostButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockPostButton.ForeColor = System.Drawing.Color.White;
            this.stockPostButton.Image = global::StoreManagement.Properties.Resources.complete32;
            this.stockPostButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stockPostButton.Name = "stockPostButton";
            this.stockPostButton.Size = new System.Drawing.Size(120, 31);
            this.stockPostButton.Text = "Send to Stock";
            this.stockPostButton.Click += new System.EventHandler(this.stockPostButton_Click);
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2});
            this.taskPane1.Location = new System.Drawing.Point(417, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(234, 414);
            this.taskPane1.TabIndex = 6;
            this.taskPane1.Text = "taskPane1";
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.label1,
            this.label2,
            this.monthComboBox,
            this.yearPicker});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(210, 100);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Year";
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(60, 33);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(108, 21);
            this.monthComboBox.TabIndex = 18;
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(60, 57);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(79, 21);
            this.yearPicker.TabIndex = 20;
            // 
            // expando2
            // 
            this.expando2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando2.Animate = true;
            this.expando2.AutoLayout = true;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.grrInaMonthTaskItem,
            this.supplierWiseInaMonthTaskItem,
            this.monthWiseGrrsInaYearTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 124);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(210, 100);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // grrInaMonthTaskItem
            // 
            this.grrInaMonthTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grrInaMonthTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.grrInaMonthTaskItem.Image = null;
            this.grrInaMonthTaskItem.Location = new System.Drawing.Point(12, 33);
            this.grrInaMonthTaskItem.Name = "grrInaMonthTaskItem";
            this.grrInaMonthTaskItem.Size = new System.Drawing.Size(184, 16);
            this.grrInaMonthTaskItem.TabIndex = 0;
            this.grrInaMonthTaskItem.Text = "GRRs In a Month";
            this.grrInaMonthTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.grrInaMonthTaskItem.UseVisualStyleBackColor = false;
            this.grrInaMonthTaskItem.Click += new System.EventHandler(this.grrInaMonthTaskItem_Click);
            // 
            // supplierWiseInaMonthTaskItem
            // 
            this.supplierWiseInaMonthTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierWiseInaMonthTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.supplierWiseInaMonthTaskItem.Image = null;
            this.supplierWiseInaMonthTaskItem.Location = new System.Drawing.Point(12, 53);
            this.supplierWiseInaMonthTaskItem.Name = "supplierWiseInaMonthTaskItem";
            this.supplierWiseInaMonthTaskItem.Size = new System.Drawing.Size(184, 16);
            this.supplierWiseInaMonthTaskItem.TabIndex = 1;
            this.supplierWiseInaMonthTaskItem.Text = "Supplier Wise GRRs In a Month";
            this.supplierWiseInaMonthTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.supplierWiseInaMonthTaskItem.UseVisualStyleBackColor = false;
            this.supplierWiseInaMonthTaskItem.Click += new System.EventHandler(this.supplierWiseInaMonthTaskItem_Click);
            // 
            // monthWiseGrrsInaYearTaskItem
            // 
            this.monthWiseGrrsInaYearTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthWiseGrrsInaYearTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.monthWiseGrrsInaYearTaskItem.Image = null;
            this.monthWiseGrrsInaYearTaskItem.Location = new System.Drawing.Point(12, 73);
            this.monthWiseGrrsInaYearTaskItem.Name = "monthWiseGrrsInaYearTaskItem";
            this.monthWiseGrrsInaYearTaskItem.Size = new System.Drawing.Size(184, 16);
            this.monthWiseGrrsInaYearTaskItem.TabIndex = 2;
            this.monthWiseGrrsInaYearTaskItem.Text = "Month Wise GRRs In a Year";
            this.monthWiseGrrsInaYearTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.monthWiseGrrsInaYearTaskItem.UseVisualStyleBackColor = false;
            this.monthWiseGrrsInaYearTaskItem.Click += new System.EventHandler(this.monthWiseGrrsInaYearTaskItem_Click);
            // 
            // grrTabControl
            // 
            this.grrTabControl.Controls.Add(this.pendingTabPage);
            this.grrTabControl.Controls.Add(this.completeTabPage);
            this.grrTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grrTabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grrTabControl.Location = new System.Drawing.Point(0, 34);
            this.grrTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.grrTabControl.Name = "grrTabControl";
            this.grrTabControl.SelectedIndex = 0;
            this.grrTabControl.Size = new System.Drawing.Size(417, 414);
            this.grrTabControl.TabIndex = 7;
            this.grrTabControl.SelectedIndexChanged += new System.EventHandler(this.grrTabControl_SelectedIndexChanged);
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.splitContainer1);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 25);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(409, 385);
            this.pendingTabPage.TabIndex = 0;
            this.pendingTabPage.Text = "Pending Orders";
            this.pendingTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.splitContainer1.Size = new System.Drawing.Size(403, 379);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pendingOrdersListView);
            this.splitContainer4.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer4.Size = new System.Drawing.Size(184, 379);
            this.splitContainer4.SplitterDistance = 226;
            this.splitContainer4.TabIndex = 2;
            // 
            // pendingOrdersListView
            // 
            this.pendingOrdersListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pendingOrdersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingOrdersListView.FullRowSelect = true;
            this.pendingOrdersListView.GridLines = true;
            this.pendingOrdersListView.Location = new System.Drawing.Point(3, 3);
            this.pendingOrdersListView.Name = "pendingOrdersListView";
            this.pendingOrdersListView.Size = new System.Drawing.Size(174, 216);
            this.pendingOrdersListView.TabIndex = 2;
            this.pendingOrdersListView.UseCompatibleStateImageBehavior = false;
            this.pendingOrdersListView.View = System.Windows.Forms.View.Details;
            this.pendingOrdersListView.SelectedIndexChanged += new System.EventHandler(this.pendingOrdersListView_SelectedIndexChanged);
            this.pendingOrdersListView.DoubleClick += new System.EventHandler(this.pendingOrdersListView_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.groupBox1.Controls.Add(this.orderDetailListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(174, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Detail";
            // 
            // orderDetailListView
            // 
            this.orderDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderDetailListView.FullRowSelect = true;
            this.orderDetailListView.GridLines = true;
            this.orderDetailListView.Location = new System.Drawing.Point(3, 14);
            this.orderDetailListView.Name = "orderDetailListView";
            this.orderDetailListView.Size = new System.Drawing.Size(168, 122);
            this.orderDetailListView.TabIndex = 4;
            this.orderDetailListView.UseCompatibleStateImageBehavior = false;
            this.orderDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.grrGroupBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.grrDetailGroupBox);
            this.splitContainer3.Size = new System.Drawing.Size(209, 377);
            this.splitContainer3.SplitterDistance = 230;
            this.splitContainer3.TabIndex = 5;
            // 
            // grrGroupBox
            // 
            this.grrGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(130)))), ((int)(((byte)(232)))));
            this.grrGroupBox.Controls.Add(this.grrListView);
            this.grrGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grrGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grrGroupBox.ForeColor = System.Drawing.Color.White;
            this.grrGroupBox.Location = new System.Drawing.Point(0, 0);
            this.grrGroupBox.Name = "grrGroupBox";
            this.grrGroupBox.Padding = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.grrGroupBox.Size = new System.Drawing.Size(205, 226);
            this.grrGroupBox.TabIndex = 5;
            this.grrGroupBox.TabStop = false;
            this.grrGroupBox.Text = "GRR List";
            // 
            // grrListView
            // 
            this.grrListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grrListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grrListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grrListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grrListView.FullRowSelect = true;
            this.grrListView.GridLines = true;
            this.grrListView.Location = new System.Drawing.Point(5, 19);
            this.grrListView.Name = "grrListView";
            this.grrListView.Size = new System.Drawing.Size(195, 204);
            this.grrListView.TabIndex = 1;
            this.grrListView.UseCompatibleStateImageBehavior = false;
            this.grrListView.View = System.Windows.Forms.View.Details;
            this.grrListView.SelectedIndexChanged += new System.EventHandler(this.grrListView_SelectedIndexChanged);
            // 
            // grrDetailGroupBox
            // 
            this.grrDetailGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(130)))), ((int)(((byte)(232)))));
            this.grrDetailGroupBox.Controls.Add(this.grrDetailListView);
            this.grrDetailGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grrDetailGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grrDetailGroupBox.ForeColor = System.Drawing.Color.White;
            this.grrDetailGroupBox.Location = new System.Drawing.Point(0, 0);
            this.grrDetailGroupBox.Name = "grrDetailGroupBox";
            this.grrDetailGroupBox.Padding = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.grrDetailGroupBox.Size = new System.Drawing.Size(205, 139);
            this.grrDetailGroupBox.TabIndex = 6;
            this.grrDetailGroupBox.TabStop = false;
            this.grrDetailGroupBox.Text = "GRR Detail";
            // 
            // grrDetailListView
            // 
            this.grrDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grrDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grrDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grrDetailListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grrDetailListView.FullRowSelect = true;
            this.grrDetailListView.GridLines = true;
            this.grrDetailListView.Location = new System.Drawing.Point(5, 19);
            this.grrDetailListView.Name = "grrDetailListView";
            this.grrDetailListView.Size = new System.Drawing.Size(195, 117);
            this.grrDetailListView.TabIndex = 1;
            this.grrDetailListView.UseCompatibleStateImageBehavior = false;
            this.grrDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // completeTabPage
            // 
            this.completeTabPage.Controls.Add(this.splitContainer2);
            this.completeTabPage.Location = new System.Drawing.Point(4, 25);
            this.completeTabPage.Name = "completeTabPage";
            this.completeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completeTabPage.Size = new System.Drawing.Size(409, 385);
            this.completeTabPage.TabIndex = 1;
            this.completeTabPage.Text = "Received GRR";
            this.completeTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.completeListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.completeGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(403, 379);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 2;
            // 
            // completeListView
            // 
            this.completeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.completeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeListView.FullRowSelect = true;
            this.completeListView.GridLines = true;
            this.completeListView.Location = new System.Drawing.Point(0, 0);
            this.completeListView.Name = "completeListView";
            this.completeListView.Size = new System.Drawing.Size(399, 291);
            this.completeListView.TabIndex = 2;
            this.completeListView.UseCompatibleStateImageBehavior = false;
            this.completeListView.View = System.Windows.Forms.View.Details;
            this.completeListView.SelectedIndexChanged += new System.EventHandler(this.completeListView_SelectedIndexChanged);
            // 
            // completeGroupBox
            // 
            this.completeGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(130)))), ((int)(((byte)(232)))));
            this.completeGroupBox.Controls.Add(this.cDetailListView);
            this.completeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeGroupBox.ForeColor = System.Drawing.Color.White;
            this.completeGroupBox.Location = new System.Drawing.Point(0, 0);
            this.completeGroupBox.Name = "completeGroupBox";
            this.completeGroupBox.Padding = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.completeGroupBox.Size = new System.Drawing.Size(399, 76);
            this.completeGroupBox.TabIndex = 4;
            this.completeGroupBox.TabStop = false;
            // 
            // cDetailListView
            // 
            this.cDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDetailListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cDetailListView.FullRowSelect = true;
            this.cDetailListView.GridLines = true;
            this.cDetailListView.Location = new System.Drawing.Point(5, 19);
            this.cDetailListView.Name = "cDetailListView";
            this.cDetailListView.Size = new System.Drawing.Size(389, 54);
            this.cDetailListView.TabIndex = 1;
            this.cDetailListView.UseCompatibleStateImageBehavior = false;
            this.cDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // GrrReceiveActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 448);
            this.Controls.Add(this.grrTabControl);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "GrrReceiveActionUI";
            this.Text = "GRR Receive";
            this.Load += new System.EventHandler(this.GrrReceiveListUI_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.taskPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).EndInit();
            this.expando1.ResumeLayout(false);
            this.expando1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).EndInit();
            this.expando2.ResumeLayout(false);
            this.grrTabControl.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grrGroupBox.ResumeLayout(false);
            this.grrDetailGroupBox.ResumeLayout(false);
            this.completeTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.completeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private XPExplorerBar.Expando expando2;
        private FlatTabControl.FlatTabControl grrTabControl;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.TabPage completeTabPage;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripButton stockPostButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView completeListView;
        private System.Windows.Forms.GroupBox completeGroupBox;
        private System.Windows.Forms.ListView cDetailListView;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox grrGroupBox;
        private System.Windows.Forms.ListView grrListView;
        private System.Windows.Forms.GroupBox grrDetailGroupBox;
        private System.Windows.Forms.ListView grrDetailListView;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView pendingOrdersListView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView orderDetailListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.TaskItem grrInaMonthTaskItem;
        private XPExplorerBar.TaskItem supplierWiseInaMonthTaskItem;
        private XPExplorerBar.TaskItem monthWiseGrrsInaYearTaskItem;
    }
}