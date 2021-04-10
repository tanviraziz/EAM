namespace StoreManagement.UI
{
    partial class FSDInspectionSummeryActionUI
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
            this.createSummeryButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.printSummeryTaskItem = new XPExplorerBar.TaskItem();
            this.printCertificateTaskItem = new XPExplorerBar.TaskItem();
            this.expando3 = new XPExplorerBar.Expando();
            this.referenceListView = new XPExplorerBar.XPListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.summeryListView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detailListView = new System.Windows.Forms.ListView();
            this.printSummeryDetailTaskItem = new XPExplorerBar.TaskItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando3)).BeginInit();
            this.expando3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 34);
            this.panel1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSummeryButton,
            this.refreshButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(675, 34);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createSummeryButton
            // 
            this.createSummeryButton.AutoSize = false;
            this.createSummeryButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createSummeryButton.ForeColor = System.Drawing.Color.White;
            this.createSummeryButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.createSummeryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createSummeryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createSummeryButton.Name = "createSummeryButton";
            this.createSummeryButton.Size = new System.Drawing.Size(280, 32);
            this.createSummeryButton.Text = "  Create Summery";
            this.createSummeryButton.Visible = false;
            this.createSummeryButton.Click += new System.EventHandler(this.createSummeryButton_Click);
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
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2,
            this.expando3});
            this.taskPane1.Location = new System.Drawing.Point(441, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(234, 407);
            this.taskPane1.TabIndex = 7;
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
            this.expando1.Visible = false;
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
            this.expando2.ExpandedHeight = 101;
            this.expando2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.printSummeryTaskItem,
            this.printSummeryDetailTaskItem,
            this.printCertificateTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 124);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(210, 101);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // printSummeryTaskItem
            // 
            this.printSummeryTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printSummeryTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.printSummeryTaskItem.Image = null;
            this.printSummeryTaskItem.Location = new System.Drawing.Point(12, 33);
            this.printSummeryTaskItem.Name = "printSummeryTaskItem";
            this.printSummeryTaskItem.Size = new System.Drawing.Size(184, 16);
            this.printSummeryTaskItem.TabIndex = 0;
            this.printSummeryTaskItem.Text = "Print Summery";
            this.printSummeryTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printSummeryTaskItem.UseVisualStyleBackColor = false;
            this.printSummeryTaskItem.Click += new System.EventHandler(this.printSummeryTaskItem_Click);
            // 
            // printCertificateTaskItem
            // 
            this.printCertificateTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printCertificateTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.printCertificateTaskItem.Image = null;
            this.printCertificateTaskItem.Location = new System.Drawing.Point(12, 73);
            this.printCertificateTaskItem.Name = "printCertificateTaskItem";
            this.printCertificateTaskItem.Size = new System.Drawing.Size(184, 16);
            this.printCertificateTaskItem.TabIndex = 1;
            this.printCertificateTaskItem.Text = "Print Certificate";
            this.printCertificateTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printCertificateTaskItem.UseVisualStyleBackColor = false;
            this.printCertificateTaskItem.Click += new System.EventHandler(this.printCertificateTaskItem_Click);
            // 
            // expando3
            // 
            this.expando3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expando3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando3.Items.AddRange(new System.Windows.Forms.Control[] {
            this.referenceListView});
            this.expando3.Location = new System.Drawing.Point(12, 237);
            this.expando3.Name = "expando3";
            this.expando3.Size = new System.Drawing.Size(210, 100);
            this.expando3.TabIndex = 2;
            this.expando3.Text = "expando3";
            this.expando3.Visible = false;
            // 
            // referenceListView
            // 
            this.referenceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referenceListView.GridLines = true;
            this.referenceListView.Location = new System.Drawing.Point(1, 23);
            this.referenceListView.Name = "referenceListView";
            this.referenceListView.Size = new System.Drawing.Size(208, 76);
            this.referenceListView.TabIndex = 0;
            this.referenceListView.UseCompatibleStateImageBehavior = false;
            this.referenceListView.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.splitContainer1.Size = new System.Drawing.Size(441, 407);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.summeryListView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Summery Of Current Year";
            // 
            // summeryListView
            // 
            this.summeryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summeryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summeryListView.FullRowSelect = true;
            this.summeryListView.GridLines = true;
            this.summeryListView.Location = new System.Drawing.Point(3, 17);
            this.summeryListView.Name = "summeryListView";
            this.summeryListView.Size = new System.Drawing.Size(425, 150);
            this.summeryListView.TabIndex = 1;
            this.summeryListView.UseCompatibleStateImageBehavior = false;
            this.summeryListView.View = System.Windows.Forms.View.Details;
            this.summeryListView.SelectedIndexChanged += new System.EventHandler(this.summeryListView_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(130)))), ((int)(((byte)(232)))));
            this.groupBox1.Controls.Add(this.detailListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summery Details";
            // 
            // detailListView
            // 
            this.detailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailListView.FullRowSelect = true;
            this.detailListView.GridLines = true;
            this.detailListView.Location = new System.Drawing.Point(3, 17);
            this.detailListView.Name = "detailListView";
            this.detailListView.Size = new System.Drawing.Size(425, 197);
            this.detailListView.TabIndex = 0;
            this.detailListView.UseCompatibleStateImageBehavior = false;
            this.detailListView.View = System.Windows.Forms.View.Details;
            // 
            // printSummeryDetailTaskItem
            // 
            this.printSummeryDetailTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printSummeryDetailTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.printSummeryDetailTaskItem.Image = null;
            this.printSummeryDetailTaskItem.Location = new System.Drawing.Point(12, 53);
            this.printSummeryDetailTaskItem.Name = "printSummeryDetailTaskItem";
            this.printSummeryDetailTaskItem.Size = new System.Drawing.Size(184, 16);
            this.printSummeryDetailTaskItem.TabIndex = 2;
            this.printSummeryDetailTaskItem.Text = "Print Summery Detail";
            this.printSummeryDetailTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printSummeryDetailTaskItem.UseVisualStyleBackColor = false;
            this.printSummeryDetailTaskItem.Click += new System.EventHandler(this.printSummeryDetailTaskItem_Click);
            // 
            // FSDInspectionSummeryActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "FSDInspectionSummeryActionUI";
            this.Text = "Inspection Summery";
            this.Load += new System.EventHandler(this.FSDInspectionSummeryActionUI_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.expando3)).EndInit();
            this.expando3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton createSummeryButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.Expando expando2;
        private XPExplorerBar.TaskItem printSummeryTaskItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView summeryListView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView detailListView;
        private XPExplorerBar.TaskItem printCertificateTaskItem;
        private XPExplorerBar.Expando expando3;
        private XPExplorerBar.XPListView referenceListView;
        private XPExplorerBar.TaskItem printSummeryDetailTaskItem;
    }
}