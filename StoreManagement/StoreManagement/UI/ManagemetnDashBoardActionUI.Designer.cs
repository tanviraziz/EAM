namespace StoreManagement.UI
{
    partial class ManagemetnDashBoardActionUI
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
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.expando2 = new XPExplorerBar.Expando();
            this.monthlyConsumptionTaskItem = new XPExplorerBar.TaskItem();
            this.consumptionGroupBox = new System.Windows.Forms.GroupBox();
            this.srrItemListView = new System.Windows.Forms.ListView();
            this.expando3 = new XPExplorerBar.Expando();
            this.expando4 = new XPExplorerBar.Expando();
            this.consumptionListView = new XPExplorerBar.XPListView();
            this.yearlyConsumptionListView = new XPExplorerBar.XPListView();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.taskPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).BeginInit();
            this.expando1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).BeginInit();
            this.expando2.SuspendLayout();
            this.consumptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando3)).BeginInit();
            this.expando3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando4)).BeginInit();
            this.expando4.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.expando1,
            this.expando2,
            this.expando3,
            this.expando4});
            this.taskPane1.Location = new System.Drawing.Point(335, 0);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(200, 583);
            this.taskPane1.TabIndex = 9;
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
            this.expando1.Size = new System.Drawing.Size(176, 100);
            this.expando1.TabIndex = 0;
            this.expando1.Text = "Filter";
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
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(48, 53);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(76, 21);
            this.yearPicker.TabIndex = 8;
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
            this.monthlyConsumptionTaskItem});
            this.expando2.Location = new System.Drawing.Point(12, 124);
            this.expando2.Name = "expando2";
            this.expando2.Size = new System.Drawing.Size(176, 60);
            this.expando2.TabIndex = 1;
            this.expando2.Text = "Search";
            // 
            // monthlyConsumptionTaskItem
            // 
            this.monthlyConsumptionTaskItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.monthlyConsumptionTaskItem.BackColor = System.Drawing.Color.Transparent;
            this.monthlyConsumptionTaskItem.Image = null;
            this.monthlyConsumptionTaskItem.Location = new System.Drawing.Point(12, 33);
            this.monthlyConsumptionTaskItem.Name = "monthlyConsumptionTaskItem";
            this.monthlyConsumptionTaskItem.Size = new System.Drawing.Size(150, 16);
            this.monthlyConsumptionTaskItem.TabIndex = 0;
            this.monthlyConsumptionTaskItem.Text = "Monthly Consumption";
            this.monthlyConsumptionTaskItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.monthlyConsumptionTaskItem.UseVisualStyleBackColor = false;
            this.monthlyConsumptionTaskItem.Click += new System.EventHandler(this.monthlyConsumptionTaskItem_Click);
            // 
            // consumptionGroupBox
            // 
            this.consumptionGroupBox.Controls.Add(this.srrItemListView);
            this.consumptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumptionGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consumptionGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.consumptionGroupBox.Location = new System.Drawing.Point(5, 0);
            this.consumptionGroupBox.Name = "consumptionGroupBox";
            this.consumptionGroupBox.Size = new System.Drawing.Size(330, 583);
            this.consumptionGroupBox.TabIndex = 10;
            this.consumptionGroupBox.TabStop = false;
            // 
            // srrItemListView
            // 
            this.srrItemListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.srrItemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srrItemListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srrItemListView.FullRowSelect = true;
            this.srrItemListView.GridLines = true;
            this.srrItemListView.Location = new System.Drawing.Point(3, 17);
            this.srrItemListView.Name = "srrItemListView";
            this.srrItemListView.Size = new System.Drawing.Size(324, 563);
            this.srrItemListView.TabIndex = 4;
            this.srrItemListView.UseCompatibleStateImageBehavior = false;
            this.srrItemListView.View = System.Windows.Forms.View.Details;
            // 
            // expando3
            // 
            this.expando3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expando3.Animate = true;
            this.expando3.AutoLayout = true;
            this.expando3.ExpandedHeight = 110;
            this.expando3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando3.Items.AddRange(new System.Windows.Forms.Control[] {
            this.yearlyConsumptionListView});
            this.expando3.Location = new System.Drawing.Point(12, 196);
            this.expando3.Name = "expando3";
            this.expando3.Size = new System.Drawing.Size(176, 110);
            this.expando3.TabIndex = 2;
            this.expando3.Text = "Yearly Consumption";
            // 
            // expando4
            // 
            this.expando4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expando4.ExpandedHeight = 108;
            this.expando4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expando4.Items.AddRange(new System.Windows.Forms.Control[] {
            this.consumptionListView});
            this.expando4.Location = new System.Drawing.Point(12, 318);
            this.expando4.Name = "expando4";
            this.expando4.Size = new System.Drawing.Size(176, 108);
            this.expando4.TabIndex = 3;
            this.expando4.Text = "Monthly Consumption";
            // 
            // consumptionListView
            // 
            this.consumptionListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consumptionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumptionListView.Location = new System.Drawing.Point(1, 23);
            this.consumptionListView.Name = "consumptionListView";
            this.consumptionListView.Size = new System.Drawing.Size(174, 84);
            this.consumptionListView.TabIndex = 1;
            this.consumptionListView.UseCompatibleStateImageBehavior = false;
            // 
            // yearlyConsumptionListView
            // 
            this.yearlyConsumptionListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearlyConsumptionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearlyConsumptionListView.Location = new System.Drawing.Point(1, 23);
            this.yearlyConsumptionListView.Name = "yearlyConsumptionListView";
            this.yearlyConsumptionListView.Size = new System.Drawing.Size(174, 86);
            this.yearlyConsumptionListView.TabIndex = 1;
            this.yearlyConsumptionListView.UseCompatibleStateImageBehavior = false;
            // 
            // ManagemetnDashBoardActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 588);
            this.Controls.Add(this.consumptionGroupBox);
            this.Controls.Add(this.taskPane1);
            this.Name = "ManagemetnDashBoardActionUI";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.Text = "Management DashBoard";
            this.Load += new System.EventHandler(this.ManagemetnDashBoardUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.taskPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando1)).EndInit();
            this.expando1.ResumeLayout(false);
            this.expando1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expando2)).EndInit();
            this.expando2.ResumeLayout(false);
            this.consumptionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando3)).EndInit();
            this.expando3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expando4)).EndInit();
            this.expando4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XPExplorerBar.TaskPane taskPane1;
        private XPExplorerBar.Expando expando1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private XPExplorerBar.Expando expando2;
        private System.Windows.Forms.GroupBox consumptionGroupBox;
        private System.Windows.Forms.ListView srrItemListView;
        private XPExplorerBar.TaskItem monthlyConsumptionTaskItem;
        private XPExplorerBar.Expando expando3;
        private XPExplorerBar.XPListView yearlyConsumptionListView;
        private XPExplorerBar.Expando expando4;
        private XPExplorerBar.XPListView consumptionListView;

    }
}