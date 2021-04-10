namespace StoreManagement.UI
{
    partial class PurchaseRequisitionActionUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseRequisitionActionUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newRequisitonButton = new System.Windows.Forms.ToolStripButton();
            this.editRequisitonButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.confirmedButton = new System.Windows.Forms.ToolStripButton();
            this.purReqTabControl = new FlatTabControl.FlatTabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pendingListView = new System.Windows.Forms.ListView();
            this.pendingGroupBox = new System.Windows.Forms.GroupBox();
            this.pReqDetailListView = new System.Windows.Forms.ListView();
            this.completeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.completeListView = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.completeGroupBox = new System.Windows.Forms.GroupBox();
            this.cReqDetailListView = new System.Windows.Forms.ListView();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.reqReadyForTenderTaskItem = new XPExplorerBar.TaskItem();
            this.reqTenderAppTaskItem = new XPExplorerBar.TaskItem();
            this.reqMonthWiseTaskItem = new XPExplorerBar.TaskItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.purReqTabControl.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pendingGroupBox.SuspendLayout();
            this.completeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.completeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 34);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRequisitonButton,
            this.editRequisitonButton,
            this.refreshButton,
            this.printButton,
            this.confirmedButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(679, 34);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newRequisitonButton
            // 
            this.newRequisitonButton.AutoSize = false;
            this.newRequisitonButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRequisitonButton.ForeColor = System.Drawing.Color.White;
            this.newRequisitonButton.Image = ((System.Drawing.Image)(resources.GetObject("newRequisitonButton.Image")));
            this.newRequisitonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newRequisitonButton.Name = "newRequisitonButton";
            this.newRequisitonButton.Size = new System.Drawing.Size(60, 32);
            this.newRequisitonButton.Text = " New";
            this.newRequisitonButton.ToolTipText = " New Requisition";
            this.newRequisitonButton.Click += new System.EventHandler(this.newRequisitonButton_Click);
            // 
            // editRequisitonButton
            // 
            this.editRequisitonButton.AutoSize = false;
            this.editRequisitonButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRequisitonButton.ForeColor = System.Drawing.Color.White;
            this.editRequisitonButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editRequisitonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editRequisitonButton.Name = "editRequisitonButton";
            this.editRequisitonButton.Size = new System.Drawing.Size(60, 32);
            this.editRequisitonButton.Text = " Edit";
            this.editRequisitonButton.ToolTipText = " Edit Requisition";
            this.editRequisitonButton.Visible = false;
            this.editRequisitonButton.Click += new System.EventHandler(this.editRequisitonButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = false;
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::StoreManagement.Properties.Resources.refresh24;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 32);
            this.refreshButton.Text = " Refresh";
            this.refreshButton.ToolTipText = " Refresh List";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // printButton
            // 
            this.printButton.AutoSize = false;
            this.printButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.ForeColor = System.Drawing.Color.White;
            this.printButton.Image = global::StoreManagement.Properties.Resources.Print_icon32;
            this.printButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(72, 32);
            this.printButton.Text = " Print";
            this.printButton.ToolTipText = " Print Requisition";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // confirmedButton
            // 
            this.confirmedButton.AutoSize = false;
            this.confirmedButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmedButton.ForeColor = System.Drawing.Color.White;
            this.confirmedButton.Image = global::StoreManagement.Properties.Resources.complete24;
            this.confirmedButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.confirmedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.confirmedButton.Name = "confirmedButton";
            this.confirmedButton.Size = new System.Drawing.Size(90, 32);
            this.confirmedButton.Text = " Confirmed";
            this.confirmedButton.ToolTipText = "Confirme Requisition";
            this.confirmedButton.Click += new System.EventHandler(this.confirmedButton_Click);
            // 
            // purReqTabControl
            // 
            this.purReqTabControl.Controls.Add(this.pendingTabPage);
            this.purReqTabControl.Controls.Add(this.completeTabPage);
            this.purReqTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purReqTabControl.Location = new System.Drawing.Point(0, 34);
            this.purReqTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.purReqTabControl.Name = "purReqTabControl";
            this.purReqTabControl.SelectedIndex = 0;
            this.purReqTabControl.Size = new System.Drawing.Size(494, 365);
            this.purReqTabControl.TabIndex = 6;
            this.purReqTabControl.SelectedIndexChanged += new System.EventHandler(this.purReqTabControl_SelectedIndexChanged);
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.splitContainer1);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 25);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(486, 336);
            this.pendingTabPage.TabIndex = 0;
            this.pendingTabPage.Text = "Pending";
            this.pendingTabPage.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.pendingListView);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pendingGroupBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(480, 330);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 1;
            // 
            // pendingListView
            // 
            this.pendingListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pendingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingListView.FullRowSelect = true;
            this.pendingListView.GridLines = true;
            this.pendingListView.Location = new System.Drawing.Point(0, 0);
            this.pendingListView.Name = "pendingListView";
            this.pendingListView.Size = new System.Drawing.Size(476, 175);
            this.pendingListView.TabIndex = 1;
            this.pendingListView.UseCompatibleStateImageBehavior = false;
            this.pendingListView.View = System.Windows.Forms.View.Details;
            this.pendingListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.pendingListView_ColumnClick);
            this.pendingListView.SelectedIndexChanged += new System.EventHandler(this.pendingListView_SelectedIndexChanged);
            this.pendingListView.DoubleClick += new System.EventHandler(this.pendingListView_DoubleClick);
            // 
            // pendingGroupBox
            // 
            this.pendingGroupBox.Controls.Add(this.pReqDetailListView);
            this.pendingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingGroupBox.Location = new System.Drawing.Point(0, 2);
            this.pendingGroupBox.Name = "pendingGroupBox";
            this.pendingGroupBox.Size = new System.Drawing.Size(476, 137);
            this.pendingGroupBox.TabIndex = 0;
            this.pendingGroupBox.TabStop = false;
            this.pendingGroupBox.Text = "Requisition Detail";
            // 
            // pReqDetailListView
            // 
            this.pReqDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pReqDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pReqDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pReqDetailListView.FullRowSelect = true;
            this.pReqDetailListView.GridLines = true;
            this.pReqDetailListView.Location = new System.Drawing.Point(3, 17);
            this.pReqDetailListView.Name = "pReqDetailListView";
            this.pReqDetailListView.Size = new System.Drawing.Size(470, 117);
            this.pReqDetailListView.TabIndex = 2;
            this.pReqDetailListView.UseCompatibleStateImageBehavior = false;
            this.pReqDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // completeTabPage
            // 
            this.completeTabPage.Controls.Add(this.splitContainer2);
            this.completeTabPage.Location = new System.Drawing.Point(4, 25);
            this.completeTabPage.Name = "completeTabPage";
            this.completeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completeTabPage.Size = new System.Drawing.Size(486, 336);
            this.completeTabPage.TabIndex = 1;
            this.completeTabPage.Text = "Confirmed Requisition";
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
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.completeGroupBox);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.splitContainer2.Size = new System.Drawing.Size(186, 65);
            this.splitContainer2.SplitterDistance = 36;
            this.splitContainer2.TabIndex = 2;
            // 
            // completeListView
            // 
            this.completeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.completeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeListView.FullRowSelect = true;
            this.completeListView.GridLines = true;
            this.completeListView.Location = new System.Drawing.Point(0, 0);
            this.completeListView.Name = "completeListView";
            this.completeListView.Size = new System.Drawing.Size(182, 6);
            this.completeListView.TabIndex = 5;
            this.completeListView.UseCompatibleStateImageBehavior = false;
            this.completeListView.View = System.Windows.Forms.View.Details;
            this.completeListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.completeListView_ColumnClick);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 6);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(182, 22);
            this.statusStrip1.TabIndex = 2;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(145, 17);
            this.toolStripStatusLabel2.Text = "   Emargency Requisition";
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
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel5.Text = "   Normal Requisition";
            // 
            // completeGroupBox
            // 
            this.completeGroupBox.Controls.Add(this.cReqDetailListView);
            this.completeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeGroupBox.Location = new System.Drawing.Point(0, 4);
            this.completeGroupBox.Name = "completeGroupBox";
            this.completeGroupBox.Size = new System.Drawing.Size(182, 17);
            this.completeGroupBox.TabIndex = 1;
            this.completeGroupBox.TabStop = false;
            this.completeGroupBox.Text = "Requisiton Detail";
            // 
            // cReqDetailListView
            // 
            this.cReqDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cReqDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cReqDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cReqDetailListView.FullRowSelect = true;
            this.cReqDetailListView.GridLines = true;
            this.cReqDetailListView.Location = new System.Drawing.Point(3, 17);
            this.cReqDetailListView.Name = "cReqDetailListView";
            this.cReqDetailListView.Size = new System.Drawing.Size(176, 0);
            this.cReqDetailListView.TabIndex = 2;
            this.cReqDetailListView.UseCompatibleStateImageBehavior = false;
            this.cReqDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2});
            this.taskPane1.Location = new System.Drawing.Point(494, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(185, 365);
            this.taskPane1.TabIndex = 5;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.ExpandedHeight = 117;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.label1,
            this.label2,
            this.monthComboBox,
            this.yearPicker});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(161, 117);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Year";
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(46, 32);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(108, 21);
            this.monthComboBox.TabIndex = 6;
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(46, 56);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(79, 21);
            this.yearPicker.TabIndex = 8;
            // 
            // expando2
            // 
            this.expando2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando2.Animate = true;
            this.expando2.AutoLayout = true;
            this.expando2.ExpandedHeight = 124;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.reqReadyForTenderTaskItem,
            this.reqTenderAppTaskItem,
            this.reqMonthWiseTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 141);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(161, 124);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            this.expando2.TitleImage = global::StoreManagement.Properties.Resources.search;
            // 
            // reqReadyForTenderTaskItem
            // 
            this.reqReadyForTenderTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reqReadyForTenderTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.reqReadyForTenderTaskItem.Image = null;
            this.reqReadyForTenderTaskItem.Location = new System.Drawing.Point(12, 33);
            this.reqReadyForTenderTaskItem.Name = "reqReadyForTenderTaskItem";
            this.reqReadyForTenderTaskItem.Size = new System.Drawing.Size(135, 28);
            this.reqReadyForTenderTaskItem.TabIndex = 1;
            this.reqReadyForTenderTaskItem.Text = "Requisitions Ready for Tender";
            this.reqReadyForTenderTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reqReadyForTenderTaskItem.UseVisualStyleBackColor = false;
            this.reqReadyForTenderTaskItem.Click += new System.EventHandler(this.reqReadyForTenderTaskItem_Click);
            // 
            // reqTenderAppTaskItem
            // 
            this.reqTenderAppTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reqTenderAppTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.reqTenderAppTaskItem.Image = null;
            this.reqTenderAppTaskItem.Location = new System.Drawing.Point(12, 65);
            this.reqTenderAppTaskItem.Name = "reqTenderAppTaskItem";
            this.reqTenderAppTaskItem.Size = new System.Drawing.Size(135, 28);
            this.reqTenderAppTaskItem.TabIndex = 0;
            this.reqTenderAppTaskItem.Text = "Requisitions Tender Approved in Month";
            this.reqTenderAppTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reqTenderAppTaskItem.UseVisualStyleBackColor = false;
            this.reqTenderAppTaskItem.Click += new System.EventHandler(this.reqTenderAppTaskItem_Click);
            // 
            // reqMonthWiseTaskItem
            // 
            this.reqMonthWiseTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reqMonthWiseTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.reqMonthWiseTaskItem.Image = null;
            this.reqMonthWiseTaskItem.Location = new System.Drawing.Point(12, 97);
            this.reqMonthWiseTaskItem.Name = "reqMonthWiseTaskItem";
            this.reqMonthWiseTaskItem.Size = new System.Drawing.Size(135, 16);
            this.reqMonthWiseTaskItem.TabIndex = 2;
            this.reqMonthWiseTaskItem.Text = "Month Wise Requisitions";
            this.reqMonthWiseTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reqMonthWiseTaskItem.UseVisualStyleBackColor = false;
            this.reqMonthWiseTaskItem.Click += new System.EventHandler(this.reqMonthWiseTaskItem_Click);
            // 
            // PurchaseRequisitionActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 399);
            this.Controls.Add(this.purReqTabControl);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(687, 433);
            this.Name = "PurchaseRequisitionActionUI";
            this.Text = "Purchase Requisitions";
            this.Load += new System.EventHandler(this.PurchaseRequisitionListUI_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.purReqTabControl.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pendingGroupBox.ResumeLayout(false);
            this.completeTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.completeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.taskPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).EndInit();
            this.expando1.ResumeLayout(false);
            this.expando1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).EndInit();
            this.expando2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private XPExplorerBar.TaskPane taskPane1;
        private FlatTabControl.FlatTabControl purReqTabControl;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.TabPage completeTabPage;
        private XPExplorerBar.Expando expando1;
        private XPExplorerBar.Expando expando2;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView pendingListView;
        private System.Windows.Forms.GroupBox pendingGroupBox;
        private System.Windows.Forms.ListView pReqDetailListView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox completeGroupBox;
        private System.Windows.Forms.ListView cReqDetailListView;
        private System.Windows.Forms.ToolStripButton confirmedButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.TaskItem reqReadyForTenderTaskItem;
        private XPExplorerBar.TaskItem reqTenderAppTaskItem;
        private XPExplorerBar.TaskItem reqMonthWiseTaskItem;
        private System.Windows.Forms.ToolStripButton newRequisitonButton;
        private System.Windows.Forms.ToolStripButton editRequisitonButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ListView completeListView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
    }
}