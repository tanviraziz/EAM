namespace StoreManagement.UI
{
    partial class DeptBudgetSettingsActionUI
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
            this.allDeptBudget = new System.Windows.Forms.ToolStripButton();
            this.budgetCloseButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.expando1 = new XPExplorerBar.Expando();
            this.label2 = new System.Windows.Forms.Label();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.printCertificateTaskItem = new XPExplorerBar.TaskItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.budgetListView = new System.Windows.Forms.ListView();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 34);
            this.panel1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allDeptBudget,
            this.budgetCloseButton,
            this.refreshButton,
            this.addButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(646, 35);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // allDeptBudget
            // 
            this.allDeptBudget.AutoSize = false;
            this.allDeptBudget.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allDeptBudget.ForeColor = System.Drawing.Color.White;
            this.allDeptBudget.Image = global::StoreManagement.Properties.Resources.add;
            this.allDeptBudget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allDeptBudget.Name = "allDeptBudget";
            this.allDeptBudget.Size = new System.Drawing.Size(140, 32);
            this.allDeptBudget.Text = "All Department";
            this.allDeptBudget.Click += new System.EventHandler(this.allDeptBudget_Click);
            // 
            // budgetCloseButton
            // 
            this.budgetCloseButton.AutoSize = false;
            this.budgetCloseButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetCloseButton.ForeColor = System.Drawing.Color.White;
            this.budgetCloseButton.Image = global::StoreManagement.Properties.Resources.dSAVE_24;
            this.budgetCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.budgetCloseButton.Name = "budgetCloseButton";
            this.budgetCloseButton.Size = new System.Drawing.Size(180, 32);
            this.budgetCloseButton.Text = "  Close Budget";
            this.budgetCloseButton.Visible = false;
            this.budgetCloseButton.Click += new System.EventHandler(this.budgetCloseButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = false;
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::StoreManagement.Properties.Resources.refresh32;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 32);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // addButton
            // 
            this.addButton.AutoSize = false;
            this.addButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 32);
            this.addButton.Text = " Add";
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
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
            this.taskPane1.Size = new System.Drawing.Size(234, 370);
            this.taskPane1.TabIndex = 7;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // expando1
            // 
            this.expando1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expando1.Animate = true;
            this.expando1.ExpandedHeight = 68;
            this.expando1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.label2,
            this.yearPicker});
            this.expando1.Location = new System.Drawing.Point(12, 12);
            this.expando1.Name = "expando1";
            this.expando1.Size = new System.Drawing.Size(210, 68);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Year";
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(57, 33);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(79, 21);
            this.yearPicker.TabIndex = 22;
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
            this.printCertificateTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 92);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(210, 60);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // printCertificateTaskItem
            // 
            this.printCertificateTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printCertificateTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.printCertificateTaskItem.Image = null;
            this.printCertificateTaskItem.Location = new System.Drawing.Point(12, 33);
            this.printCertificateTaskItem.Name = "printCertificateTaskItem";
            this.printCertificateTaskItem.Size = new System.Drawing.Size(184, 16);
            this.printCertificateTaskItem.TabIndex = 4;
            this.printCertificateTaskItem.Text = "Budget";
            this.printCertificateTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printCertificateTaskItem.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.budgetListView);
            this.groupBox1.Controls.Add(this.budgetLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(412, 370);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // budgetListView
            // 
            this.budgetListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.budgetListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.budgetListView.FullRowSelect = true;
            this.budgetListView.GridLines = true;
            this.budgetListView.Location = new System.Drawing.Point(3, 36);
            this.budgetListView.Name = "budgetListView";
            this.budgetListView.Size = new System.Drawing.Size(406, 331);
            this.budgetListView.TabIndex = 5;
            this.budgetListView.UseCompatibleStateImageBehavior = false;
            this.budgetListView.View = System.Windows.Forms.View.Details;
            // 
            // budgetLabel
            // 
            this.budgetLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(136)))), ((int)(((byte)(221)))));
            this.budgetLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.budgetLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetLabel.ForeColor = System.Drawing.Color.White;
            this.budgetLabel.Location = new System.Drawing.Point(3, 13);
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Size = new System.Drawing.Size(406, 23);
            this.budgetLabel.TabIndex = 4;
            this.budgetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeptBudgetSettingsActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "DeptBudgetSettingsActionUI";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.Text = "Budget Settings";
            this.Load += new System.EventHandler(this.DeptBudgetSettingsActionUI_Load);
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
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton budgetCloseButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.Expando expando2;
        private XPExplorerBar.TaskItem printCertificateTaskItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton allDeptBudget;
        private System.Windows.Forms.ListView budgetListView;
        private System.Windows.Forms.Label budgetLabel;
    }
}