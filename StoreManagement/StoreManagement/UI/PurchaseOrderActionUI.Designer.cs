namespace StoreManagement.UI
{
    partial class PurchaseOrderActionUI
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
            this.purOrderButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.expando2 = new XPExplorerBar.Expando();
            this.ordInMonthTaskItem = new XPExplorerBar.TaskItem();
            this.monthWiseOrdInYearTaskItem = new XPExplorerBar.TaskItem();
            this.supplierWiseOrdInMonthTaskItem = new XPExplorerBar.TaskItem();
            this.supplierMonthWiseOrdInYearTaskItem = new XPExplorerBar.TaskItem();
            this.orderDeliveryDateExpiredTaskItem = new XPExplorerBar.TaskItem();
            this.purchaseOrderTabControl = new FlatTabControl.FlatTabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pendingListView = new System.Windows.Forms.ListView();
            this.tenderGroupBox = new System.Windows.Forms.GroupBox();
            this.tenderListView = new System.Windows.Forms.ListView();
            this.orderGroupBox = new System.Windows.Forms.GroupBox();
            this.reqOrderDetailListView = new System.Windows.Forms.ListView();
            this.completeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.completeListView = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.orderDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.orderDetailListView = new System.Windows.Forms.ListView();
            this.orderTermsTaskItem = new XPExplorerBar.TaskItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.purchaseOrderTabControl.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tenderGroupBox.SuspendLayout();
            this.orderGroupBox.SuspendLayout();
            this.completeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.orderDetailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 34);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purOrderButton,
            this.editButton,
            this.printButton,
            this.refreshButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(674, 34);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // purOrderButton
            // 
            this.purOrderButton.AutoSize = false;
            this.purOrderButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.purOrderButton.Image = global::StoreManagement.Properties.Resources.PurOrder32;
            this.purOrderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.purOrderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.purOrderButton.Name = "purOrderButton";
            this.purOrderButton.Size = new System.Drawing.Size(100, 32);
            this.purOrderButton.Text = "New Order";
            this.purOrderButton.ToolTipText = "New Purchase Order";
            this.purOrderButton.Click += new System.EventHandler(this.purOrderButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = false;
            this.editButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.editButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(60, 32);
            this.editButton.Text = "Edit";
            this.editButton.ToolTipText = "Edit Purchase Order";
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // printButton
            // 
            this.printButton.AutoSize = false;
            this.printButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.printButton.Image = global::StoreManagement.Properties.Resources.Printicon32;
            this.printButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(70, 32);
            this.printButton.Text = "Print";
            this.printButton.Visible = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = false;
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.refreshButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 32);
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2});
            this.taskPane1.Location = new System.Drawing.Point(440, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(234, 353);
            this.taskPane1.TabIndex = 6;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.ExpandedHeight = 107;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.label1,
            this.label2,
            this.monthComboBox,
            this.yearPicker,
            this.label3,
            this.supplierComboBox});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(210, 107);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 11);
            this.label1.TabIndex = 15;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 11);
            this.label2.TabIndex = 17;
            this.label2.Text = "Year";
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(48, 32);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(108, 21);
            this.monthComboBox.TabIndex = 14;
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(48, 56);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(79, 21);
            this.yearPicker.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 11);
            this.label3.TabIndex = 19;
            this.label3.Text = "Suppliers";
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplierComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplierComboBox.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(48, 80);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(154, 19);
            this.supplierComboBox.TabIndex = 18;
            // 
            // expando2
            // 
            this.expando2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando2.Animate = true;
            this.expando2.AutoLayout = true;
            this.expando2.ExpandedHeight = 196;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.ordInMonthTaskItem,
            this.monthWiseOrdInYearTaskItem,
            this.supplierWiseOrdInMonthTaskItem,
            this.supplierMonthWiseOrdInYearTaskItem,
            this.orderDeliveryDateExpiredTaskItem,
            this.orderTermsTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 131);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(210, 196);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // ordInMonthTaskItem
            // 
            this.ordInMonthTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordInMonthTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.ordInMonthTaskItem.Image = null;
            this.ordInMonthTaskItem.Location = new System.Drawing.Point(12, 33);
            this.ordInMonthTaskItem.Name = "ordInMonthTaskItem";
            this.ordInMonthTaskItem.Size = new System.Drawing.Size(184, 16);
            this.ordInMonthTaskItem.TabIndex = 0;
            this.ordInMonthTaskItem.Text = "Orders In a Month";
            this.ordInMonthTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ordInMonthTaskItem.UseVisualStyleBackColor = false;
            this.ordInMonthTaskItem.Click += new System.EventHandler(this.ordInMonthTaskItem_Click);
            // 
            // monthWiseOrdInYearTaskItem
            // 
            this.monthWiseOrdInYearTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthWiseOrdInYearTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.monthWiseOrdInYearTaskItem.Image = null;
            this.monthWiseOrdInYearTaskItem.Location = new System.Drawing.Point(12, 53);
            this.monthWiseOrdInYearTaskItem.Name = "monthWiseOrdInYearTaskItem";
            this.monthWiseOrdInYearTaskItem.Size = new System.Drawing.Size(184, 16);
            this.monthWiseOrdInYearTaskItem.TabIndex = 1;
            this.monthWiseOrdInYearTaskItem.Text = "Month Wise Orders In a Year";
            this.monthWiseOrdInYearTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.monthWiseOrdInYearTaskItem.UseVisualStyleBackColor = false;
            this.monthWiseOrdInYearTaskItem.Click += new System.EventHandler(this.monthWiseOrdInYearTaskItem_Click);
            // 
            // supplierWiseOrdInMonthTaskItem
            // 
            this.supplierWiseOrdInMonthTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierWiseOrdInMonthTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.supplierWiseOrdInMonthTaskItem.Image = null;
            this.supplierWiseOrdInMonthTaskItem.Location = new System.Drawing.Point(12, 73);
            this.supplierWiseOrdInMonthTaskItem.Name = "supplierWiseOrdInMonthTaskItem";
            this.supplierWiseOrdInMonthTaskItem.Size = new System.Drawing.Size(184, 16);
            this.supplierWiseOrdInMonthTaskItem.TabIndex = 2;
            this.supplierWiseOrdInMonthTaskItem.Text = "Supplier Wise Orders In a Month";
            this.supplierWiseOrdInMonthTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.supplierWiseOrdInMonthTaskItem.UseVisualStyleBackColor = false;
            this.supplierWiseOrdInMonthTaskItem.Click += new System.EventHandler(this.supplierWiseOrdInMonthTaskItem_Click);
            // 
            // supplierMonthWiseOrdInYearTaskItem
            // 
            this.supplierMonthWiseOrdInYearTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierMonthWiseOrdInYearTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.supplierMonthWiseOrdInYearTaskItem.Image = null;
            this.supplierMonthWiseOrdInYearTaskItem.Location = new System.Drawing.Point(12, 93);
            this.supplierMonthWiseOrdInYearTaskItem.Name = "supplierMonthWiseOrdInYearTaskItem";
            this.supplierMonthWiseOrdInYearTaskItem.Size = new System.Drawing.Size(184, 28);
            this.supplierMonthWiseOrdInYearTaskItem.TabIndex = 3;
            this.supplierMonthWiseOrdInYearTaskItem.Text = "Supplier Month Wise Orders In a Year";
            this.supplierMonthWiseOrdInYearTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.supplierMonthWiseOrdInYearTaskItem.UseVisualStyleBackColor = false;
            this.supplierMonthWiseOrdInYearTaskItem.Click += new System.EventHandler(this.supplierMonthWiseOrdInYearTaskItem_Click);
            // 
            // orderDeliveryDateExpiredTaskItem
            // 
            this.orderDeliveryDateExpiredTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDeliveryDateExpiredTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.orderDeliveryDateExpiredTaskItem.Image = null;
            this.orderDeliveryDateExpiredTaskItem.Location = new System.Drawing.Point(12, 125);
            this.orderDeliveryDateExpiredTaskItem.Name = "orderDeliveryDateExpiredTaskItem";
            this.orderDeliveryDateExpiredTaskItem.Size = new System.Drawing.Size(184, 28);
            this.orderDeliveryDateExpiredTaskItem.TabIndex = 4;
            this.orderDeliveryDateExpiredTaskItem.Text = "Incomplete Orders Delivery Date Expired";
            this.orderDeliveryDateExpiredTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.orderDeliveryDateExpiredTaskItem.UseVisualStyleBackColor = false;
            this.orderDeliveryDateExpiredTaskItem.Click += new System.EventHandler(this.orderDeliveryDateExpiredTaskItem_Click);
            // 
            // purchaseOrderTabControl
            // 
            this.purchaseOrderTabControl.Controls.Add(this.pendingTabPage);
            this.purchaseOrderTabControl.Controls.Add(this.completeTabPage);
            this.purchaseOrderTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseOrderTabControl.Location = new System.Drawing.Point(0, 34);
            this.purchaseOrderTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.purchaseOrderTabControl.Name = "purchaseOrderTabControl";
            this.purchaseOrderTabControl.SelectedIndex = 0;
            this.purchaseOrderTabControl.Size = new System.Drawing.Size(440, 353);
            this.purchaseOrderTabControl.TabIndex = 7;
            this.purchaseOrderTabControl.SelectedIndexChanged += new System.EventHandler(this.purchaseOrderTabControl_SelectedIndexChanged);
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.splitContainer2);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 25);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(432, 324);
            this.pendingTabPage.TabIndex = 0;
            this.pendingTabPage.Text = "Pending Requisitions";
            this.pendingTabPage.UseVisualStyleBackColor = true;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.orderGroupBox);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer2.Size = new System.Drawing.Size(426, 318);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pendingListView);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tenderGroupBox);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer3.Size = new System.Drawing.Size(420, 186);
            this.splitContainer3.SplitterDistance = 231;
            this.splitContainer3.TabIndex = 2;
            // 
            // pendingListView
            // 
            this.pendingListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pendingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingListView.FullRowSelect = true;
            this.pendingListView.GridLines = true;
            this.pendingListView.Location = new System.Drawing.Point(3, 3);
            this.pendingListView.Name = "pendingListView";
            this.pendingListView.Size = new System.Drawing.Size(221, 176);
            this.pendingListView.TabIndex = 2;
            this.pendingListView.UseCompatibleStateImageBehavior = false;
            this.pendingListView.View = System.Windows.Forms.View.Details;
            this.pendingListView.SelectedIndexChanged += new System.EventHandler(this.pendingListView_SelectedIndexChanged);
            this.pendingListView.DoubleClick += new System.EventHandler(this.pendingListView_DoubleClick);
            // 
            // tenderGroupBox
            // 
            this.tenderGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.tenderGroupBox.Controls.Add(this.tenderListView);
            this.tenderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenderGroupBox.ForeColor = System.Drawing.Color.Yellow;
            this.tenderGroupBox.Location = new System.Drawing.Point(3, 3);
            this.tenderGroupBox.Name = "tenderGroupBox";
            this.tenderGroupBox.Size = new System.Drawing.Size(175, 176);
            this.tenderGroupBox.TabIndex = 1;
            this.tenderGroupBox.TabStop = false;
            this.tenderGroupBox.Text = "Pending Tenders";
            // 
            // tenderListView
            // 
            this.tenderListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tenderListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenderListView.FullRowSelect = true;
            this.tenderListView.GridLines = true;
            this.tenderListView.Location = new System.Drawing.Point(3, 17);
            this.tenderListView.Name = "tenderListView";
            this.tenderListView.Size = new System.Drawing.Size(169, 156);
            this.tenderListView.TabIndex = 0;
            this.tenderListView.UseCompatibleStateImageBehavior = false;
            this.tenderListView.View = System.Windows.Forms.View.Details;
            // 
            // orderGroupBox
            // 
            this.orderGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.orderGroupBox.Controls.Add(this.reqOrderDetailListView);
            this.orderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderGroupBox.ForeColor = System.Drawing.Color.Yellow;
            this.orderGroupBox.Location = new System.Drawing.Point(3, 3);
            this.orderGroupBox.Name = "orderGroupBox";
            this.orderGroupBox.Size = new System.Drawing.Size(416, 112);
            this.orderGroupBox.TabIndex = 0;
            this.orderGroupBox.TabStop = false;
            this.orderGroupBox.Text = "Requisition Order Detail";
            // 
            // reqOrderDetailListView
            // 
            this.reqOrderDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reqOrderDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reqOrderDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqOrderDetailListView.FullRowSelect = true;
            this.reqOrderDetailListView.GridLines = true;
            this.reqOrderDetailListView.Location = new System.Drawing.Point(3, 17);
            this.reqOrderDetailListView.Name = "reqOrderDetailListView";
            this.reqOrderDetailListView.Size = new System.Drawing.Size(410, 92);
            this.reqOrderDetailListView.TabIndex = 0;
            this.reqOrderDetailListView.UseCompatibleStateImageBehavior = false;
            this.reqOrderDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // completeTabPage
            // 
            this.completeTabPage.Controls.Add(this.splitContainer1);
            this.completeTabPage.Location = new System.Drawing.Point(4, 25);
            this.completeTabPage.Name = "completeTabPage";
            this.completeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completeTabPage.Size = new System.Drawing.Size(432, 324);
            this.completeTabPage.TabIndex = 1;
            this.completeTabPage.Text = "Purchase Orders";
            this.completeTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Panel1.Controls.Add(this.completeListView);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.orderDetailGroupBox);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 90;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(426, 318);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 2;
            // 
            // completeListView
            // 
            this.completeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.completeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeListView.FullRowSelect = true;
            this.completeListView.GridLines = true;
            this.completeListView.Location = new System.Drawing.Point(0, 0);
            this.completeListView.Name = "completeListView";
            this.completeListView.Size = new System.Drawing.Size(422, 198);
            this.completeListView.TabIndex = 4;
            this.completeListView.UseCompatibleStateImageBehavior = false;
            this.completeListView.View = System.Windows.Forms.View.Details;
            this.completeListView.SelectedIndexChanged += new System.EventHandler(this.completeListView_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 198);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(422, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel1.Text = "     ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(243, 17);
            this.toolStripStatusLabel2.Text = " New Order, Pending to Print/Confirmation";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabel3.Text = "  |  ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel4.Text = "     ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(156, 13);
            this.toolStripStatusLabel5.Text = "   Confirmed/Printed Order";
            // 
            // orderDetailGroupBox
            // 
            this.orderDetailGroupBox.Controls.Add(this.orderDetailListView);
            this.orderDetailGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderDetailGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderDetailGroupBox.Location = new System.Drawing.Point(0, 0);
            this.orderDetailGroupBox.Name = "orderDetailGroupBox";
            this.orderDetailGroupBox.Size = new System.Drawing.Size(422, 86);
            this.orderDetailGroupBox.TabIndex = 0;
            this.orderDetailGroupBox.TabStop = false;
            this.orderDetailGroupBox.Text = "Order Detail";
            // 
            // orderDetailListView
            // 
            this.orderDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderDetailListView.FullRowSelect = true;
            this.orderDetailListView.GridLines = true;
            this.orderDetailListView.Location = new System.Drawing.Point(3, 17);
            this.orderDetailListView.Name = "orderDetailListView";
            this.orderDetailListView.Size = new System.Drawing.Size(416, 66);
            this.orderDetailListView.TabIndex = 3;
            this.orderDetailListView.UseCompatibleStateImageBehavior = false;
            this.orderDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // orderTermsTaskItem
            // 
            this.orderTermsTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderTermsTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.orderTermsTaskItem.Image = null;
            this.orderTermsTaskItem.Location = new System.Drawing.Point(12, 157);
            this.orderTermsTaskItem.Name = "orderTermsTaskItem";
            this.orderTermsTaskItem.Size = new System.Drawing.Size(184, 28);
            this.orderTermsTaskItem.TabIndex = 5;
            this.orderTermsTaskItem.Text = "Purchase Order Terms and Conditions";
            this.orderTermsTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.orderTermsTaskItem.UseVisualStyleBackColor = false;
            this.orderTermsTaskItem.Click += new System.EventHandler(this.orderTermsTaskItem_Click);
            // 
            // PurchaseOrderActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 387);
            this.Controls.Add(this.purchaseOrderTabControl);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "PurchaseOrderActionUI";
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.PurchaseOrderListUI_Load);
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
            this.purchaseOrderTabControl.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tenderGroupBox.ResumeLayout(false);
            this.orderGroupBox.ResumeLayout(false);
            this.completeTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.orderDetailGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton purOrderButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private XPExplorerBar.Expando expando2;
        private FlatTabControl.FlatTabControl purchaseOrderTabControl;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.TabPage completeTabPage;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox orderDetailGroupBox;
        private System.Windows.Forms.ListView orderDetailListView;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox orderGroupBox;
        private System.Windows.Forms.ListView reqOrderDetailListView;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView pendingListView;
        private System.Windows.Forms.GroupBox tenderGroupBox;
        private System.Windows.Forms.ListView tenderListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.TaskItem ordInMonthTaskItem;
        private XPExplorerBar.TaskItem monthWiseOrdInYearTaskItem;
        private XPExplorerBar.TaskItem supplierWiseOrdInMonthTaskItem;
        private XPExplorerBar.TaskItem supplierMonthWiseOrdInYearTaskItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.ListView completeListView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private XPExplorerBar.TaskItem orderDeliveryDateExpiredTaskItem;
        private XPExplorerBar.TaskItem orderTermsTaskItem;
    }
}