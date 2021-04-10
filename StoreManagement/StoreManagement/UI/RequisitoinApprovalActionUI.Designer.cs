namespace StoreManagement.UI
{
    partial class RequisitoinApprovalActionUI
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
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearDatePicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.requisitionTabControl = new FlatTabControl.FlatTabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pendingListView = new System.Windows.Forms.ListView();
            this.pendingGroupBox = new System.Windows.Forms.GroupBox();
            this.pDetailListView = new System.Windows.Forms.ListView();
            this.completeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.completeListView = new System.Windows.Forms.ListView();
            this.completeGroupBox = new System.Windows.Forms.GroupBox();
            this.cDetailListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.requisitionTabControl.SuspendLayout();
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
            this.completeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2});
            this.taskPane1.Location = new System.Drawing.Point(389, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(185, 406);
            this.taskPane1.TabIndex = 8;
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
            this.yearDatePicker});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(161, 100);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Year";
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(48, 29);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(108, 21);
            this.monthComboBox.TabIndex = 6;
            // 
            // yearDatePicker
            // 
            this.yearDatePicker.CustomFormat = "yyyy";
            this.yearDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearDatePicker.Location = new System.Drawing.Point(48, 53);
            this.yearDatePicker.Name = "yearDatePicker";
            this.yearDatePicker.ShowUpDown = true;
            this.yearDatePicker.Size = new System.Drawing.Size(76, 21);
            this.yearDatePicker.TabIndex = 8;
            // 
            // expando2
            // 
            this.expando2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando2.Animate = true;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Location = new System.Drawing.Point(12, 124);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(161, 100);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Reports";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 34);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(257, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 0);
            this.panel2.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.refreshButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(574, 35);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.AutoSize = false;
            this.addButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(64, 32);
            this.addButton.Text = "  New";
            this.addButton.ToolTipText = "  New Requisition";
            this.addButton.Visible = false;
            // 
            // editButton
            // 
            this.editButton.AutoSize = false;
            this.editButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(84, 32);
            this.editButton.Text = "Approved";
            this.editButton.ToolTipText = " Edit Requisition";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = false;
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::StoreManagement.Properties.Resources.refresh32;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(80, 32);
            this.refreshButton.Text = " Refresh";
            this.refreshButton.ToolTipText = " Refresh List";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // requisitionTabControl
            // 
            this.requisitionTabControl.Controls.Add(this.pendingTabPage);
            this.requisitionTabControl.Controls.Add(this.completeTabPage);
            this.requisitionTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requisitionTabControl.Location = new System.Drawing.Point(0, 34);
            this.requisitionTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.requisitionTabControl.Name = "requisitionTabControl";
            this.requisitionTabControl.SelectedIndex = 0;
            this.requisitionTabControl.Size = new System.Drawing.Size(389, 406);
            this.requisitionTabControl.TabIndex = 9;
            this.requisitionTabControl.SelectedIndexChanged += new System.EventHandler(this.requisitionTabControl_SelectedIndexChanged);
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.splitContainer1);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 25);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(381, 377);
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
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pendingGroupBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(375, 371);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 4;
            // 
            // pendingListView
            // 
            this.pendingListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pendingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingListView.FullRowSelect = true;
            this.pendingListView.GridLines = true;
            this.pendingListView.Location = new System.Drawing.Point(0, 0);
            this.pendingListView.Name = "pendingListView";
            this.pendingListView.Size = new System.Drawing.Size(371, 226);
            this.pendingListView.TabIndex = 3;
            this.pendingListView.UseCompatibleStateImageBehavior = false;
            this.pendingListView.View = System.Windows.Forms.View.Details;
            this.pendingListView.SelectedIndexChanged += new System.EventHandler(this.pendingListView_SelectedIndexChanged);
            this.pendingListView.DoubleClick += new System.EventHandler(this.pendingListView_DoubleClick);
            // 
            // pendingGroupBox
            // 
            this.pendingGroupBox.Controls.Add(this.pDetailListView);
            this.pendingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingGroupBox.Location = new System.Drawing.Point(0, 5);
            this.pendingGroupBox.Name = "pendingGroupBox";
            this.pendingGroupBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pendingGroupBox.Size = new System.Drawing.Size(371, 123);
            this.pendingGroupBox.TabIndex = 2;
            this.pendingGroupBox.TabStop = false;
            // 
            // pDetailListView
            // 
            this.pDetailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pDetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetailListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDetailListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pDetailListView.FullRowSelect = true;
            this.pDetailListView.GridLines = true;
            this.pDetailListView.Location = new System.Drawing.Point(3, 14);
            this.pDetailListView.Name = "pDetailListView";
            this.pDetailListView.Size = new System.Drawing.Size(365, 106);
            this.pDetailListView.TabIndex = 1;
            this.pDetailListView.UseCompatibleStateImageBehavior = false;
            this.pDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // completeTabPage
            // 
            this.completeTabPage.Controls.Add(this.splitContainer2);
            this.completeTabPage.Location = new System.Drawing.Point(4, 25);
            this.completeTabPage.Name = "completeTabPage";
            this.completeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completeTabPage.Size = new System.Drawing.Size(381, 377);
            this.completeTabPage.TabIndex = 1;
            this.completeTabPage.Text = "Approved SRR";
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
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.completeGroupBox);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.splitContainer2.Size = new System.Drawing.Size(186, 65);
            this.splitContainer2.SplitterDistance = 34;
            this.splitContainer2.TabIndex = 4;
            // 
            // completeListView
            // 
            this.completeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.completeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeListView.FullRowSelect = true;
            this.completeListView.GridLines = true;
            this.completeListView.Location = new System.Drawing.Point(0, 0);
            this.completeListView.Name = "completeListView";
            this.completeListView.Size = new System.Drawing.Size(182, 25);
            this.completeListView.TabIndex = 3;
            this.completeListView.UseCompatibleStateImageBehavior = false;
            this.completeListView.View = System.Windows.Forms.View.Details;
            this.completeListView.SelectedIndexChanged += new System.EventHandler(this.completeListView_SelectedIndexChanged);
            // 
            // completeGroupBox
            // 
            this.completeGroupBox.Controls.Add(this.cDetailListView);
            this.completeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeGroupBox.Location = new System.Drawing.Point(0, 5);
            this.completeGroupBox.Name = "completeGroupBox";
            this.completeGroupBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.completeGroupBox.Size = new System.Drawing.Size(182, 18);
            this.completeGroupBox.TabIndex = 2;
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
            this.cDetailListView.Location = new System.Drawing.Point(3, 14);
            this.cDetailListView.Name = "cDetailListView";
            this.cDetailListView.Size = new System.Drawing.Size(176, 1);
            this.cDetailListView.TabIndex = 1;
            this.cDetailListView.UseCompatibleStateImageBehavior = false;
            this.cDetailListView.View = System.Windows.Forms.View.Details;
            // 
            // RequisitoinApprovalActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 440);
            this.Controls.Add(this.requisitionTabControl);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "RequisitoinApprovalActionUI";
            this.Text = "Requisitoin Approval";
            this.Load += new System.EventHandler(this.RequisitoinApprovalListUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.taskPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).EndInit();
            this.expando1.ResumeLayout(false);
            this.expando1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.requisitionTabControl.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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

        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private XPExplorerBar.Expando expando2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private FlatTabControl.FlatTabControl requisitionTabControl;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView pendingListView;
        private System.Windows.Forms.GroupBox pendingGroupBox;
        private System.Windows.Forms.ListView pDetailListView;
        private System.Windows.Forms.TabPage completeTabPage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView completeListView;
        private System.Windows.Forms.GroupBox completeGroupBox;
        private System.Windows.Forms.ListView cDetailListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearDatePicker;
    }
}