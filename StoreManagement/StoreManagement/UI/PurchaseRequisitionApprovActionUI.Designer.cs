namespace StoreManagement.UI
{
    partial class PurchaseRequisitionApprovActionUI
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
            this.confirmButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.reqInMonthTaskItem = new XPExplorerBar.TaskItem();
            this.purReqTabControl = new FlatTabControl.FlatTabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pendingListView = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pendingGroupBox = new System.Windows.Forms.GroupBox();
            this.pReqDetailListView = new System.Windows.Forms.ListView();
            this.completeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.completeListView = new System.Windows.Forms.ListView();
            this.completeGroupBox = new System.Windows.Forms.GroupBox();
            this.cReqDetailListView = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.purReqTabControl.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pendingGroupBox.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(674, 34);
            this.panel1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmButton,
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
            // confirmButton
            // 
            this.confirmButton.AutoSize = false;
            this.confirmButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.confirmButton.Image = global::StoreManagement.Properties.Resources.complete24;
            this.confirmButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.confirmButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(80, 32);
            this.confirmButton.Text = "Confirm";
            this.confirmButton.ToolTipText = "Approve Purchase Requisition";
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
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
            this.printButton.ToolTipText = "Print Requisition";
            this.printButton.Visible = false;
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
            this.refreshButton.Size = new System.Drawing.Size(120, 32);
            this.refreshButton.Text = " Refresh List";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2});
            this.taskPane1.Location = new System.Drawing.Point(487, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(187, 353);
            this.taskPane1.TabIndex = 7;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.ExpandedHeight = 87;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.label1,
            this.label2,
            this.monthComboBox,
            this.yearPicker});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(163, 87);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 11);
            this.label1.TabIndex = 15;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 11);
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
            // expando2
            // 
            this.expando2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando2.Animate = true;
            this.expando2.AutoLayout = true;
            this.expando2.ExpandedHeight = 60;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.reqInMonthTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 111);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(163, 60);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // reqInMonthTaskItem
            // 
            this.reqInMonthTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reqInMonthTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.reqInMonthTaskItem.Image = null;
            this.reqInMonthTaskItem.Location = new System.Drawing.Point(12, 33);
            this.reqInMonthTaskItem.Name = "reqInMonthTaskItem";
            this.reqInMonthTaskItem.Size = new System.Drawing.Size(137, 16);
            this.reqInMonthTaskItem.TabIndex = 0;
            this.reqInMonthTaskItem.Text = "Requisition In a Month";
            this.reqInMonthTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reqInMonthTaskItem.UseVisualStyleBackColor = false;
            this.reqInMonthTaskItem.Click += new System.EventHandler(this.ordInMonthTaskItem_Click);
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
            this.purReqTabControl.Size = new System.Drawing.Size(487, 353);
            this.purReqTabControl.TabIndex = 8;
            this.purReqTabControl.SelectedIndexChanged += new System.EventHandler(this.purReqTabControl_SelectedIndexChanged);
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.splitContainer1);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 25);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(479, 324);
            this.pendingTabPage.TabIndex = 0;
            this.pendingTabPage.Text = "Pending for Approval";
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
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pendingGroupBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(473, 318);
            this.splitContainer1.SplitterDistance = 176;
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
            this.pendingListView.Size = new System.Drawing.Size(469, 146);
            this.pendingListView.TabIndex = 5;
            this.pendingListView.UseCompatibleStateImageBehavior = false;
            this.pendingListView.View = System.Windows.Forms.View.Details;
            this.pendingListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.pendingListView_ColumnClick);
            this.pendingListView.SelectedIndexChanged += new System.EventHandler(this.pendingListView_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 146);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.TabIndex = 4;
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
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel7.Text = "     ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel8.Text = "   Normal Requisition";
            // 
            // pendingGroupBox
            // 
            this.pendingGroupBox.Controls.Add(this.pReqDetailListView);
            this.pendingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingGroupBox.Location = new System.Drawing.Point(0, 2);
            this.pendingGroupBox.Name = "pendingGroupBox";
            this.pendingGroupBox.Size = new System.Drawing.Size(469, 132);
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
            this.pReqDetailListView.Size = new System.Drawing.Size(463, 112);
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
            this.completeTabPage.Size = new System.Drawing.Size(479, 324);
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
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.completeGroupBox);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.splitContainer2.Size = new System.Drawing.Size(473, 318);
            this.splitContainer2.SplitterDistance = 161;
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
            this.completeListView.Size = new System.Drawing.Size(469, 153);
            this.completeListView.TabIndex = 2;
            this.completeListView.UseCompatibleStateImageBehavior = false;
            this.completeListView.View = System.Windows.Forms.View.Details;
            this.completeListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.completeListView_ColumnClick);
            this.completeListView.SelectedIndexChanged += new System.EventHandler(this.completeListView_SelectedIndexChanged);
            // 
            // completeGroupBox
            // 
            this.completeGroupBox.Controls.Add(this.cReqDetailListView);
            this.completeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeGroupBox.Location = new System.Drawing.Point(0, 4);
            this.completeGroupBox.Name = "completeGroupBox";
            this.completeGroupBox.Size = new System.Drawing.Size(469, 145);
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
            this.cReqDetailListView.Size = new System.Drawing.Size(463, 125);
            this.cReqDetailListView.TabIndex = 2;
            this.cReqDetailListView.UseCompatibleStateImageBehavior = false;
            this.cReqDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // PurchaseRequisitionApprovActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 387);
            this.Controls.Add(this.purReqTabControl);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "PurchaseRequisitionApprovActionUI";
            this.Text = "Purchase Requisitions";
            this.Load += new System.EventHandler(this.PurchaseRequisitionAppActionUI_Load);
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
            this.purReqTabControl.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pendingGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton confirmButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.Expando expando2;
        private XPExplorerBar.TaskItem reqInMonthTaskItem;
        private FlatTabControl.FlatTabControl purReqTabControl;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox pendingGroupBox;
        private System.Windows.Forms.ListView pReqDetailListView;
        private System.Windows.Forms.TabPage completeTabPage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView completeListView;
        private System.Windows.Forms.GroupBox completeGroupBox;
        private System.Windows.Forms.ListView cReqDetailListView;
        private System.Windows.Forms.ListView pendingListView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
    }
}