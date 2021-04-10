namespace StoreManagement.UI
{
    partial class SupplierTenderEntryUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierPanel = new System.Windows.Forms.Panel();
            this.addSupplierLabel = new System.Windows.Forms.Label();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.supplierTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.totalItemLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.requisitionListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tenderDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnSlno = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.removeColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQtyBfrInsp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReqID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.supplierPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel4.Size = new System.Drawing.Size(665, 70);
            this.panel4.TabIndex = 241;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supplierPanel);
            this.groupBox1.Controls.Add(this.supplierTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(303, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 60);
            this.groupBox1.TabIndex = 244;
            this.groupBox1.TabStop = false;
            // 
            // supplierPanel
            // 
            this.supplierPanel.Controls.Add(this.addSupplierLabel);
            this.supplierPanel.Controls.Add(this.supplierComboBox);
            this.supplierPanel.Location = new System.Drawing.Point(73, 16);
            this.supplierPanel.Name = "supplierPanel";
            this.supplierPanel.Size = new System.Drawing.Size(277, 32);
            this.supplierPanel.TabIndex = 246;
            this.supplierPanel.Visible = false;
            // 
            // addSupplierLabel
            // 
            this.addSupplierLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.addSupplierLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplierLabel.ForeColor = System.Drawing.Color.White;
            this.addSupplierLabel.Image = global::StoreManagement.Properties.Resources.addB24;
            this.addSupplierLabel.Location = new System.Drawing.Point(247, 3);
            this.addSupplierLabel.Name = "addSupplierLabel";
            this.addSupplierLabel.Size = new System.Drawing.Size(25, 25);
            this.addSupplierLabel.TabIndex = 247;
            this.addSupplierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addSupplierLabel.Click += new System.EventHandler(this.addSupplierLabel_Click);
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplierComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplierComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(4, 5);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(234, 21);
            this.supplierComboBox.TabIndex = 246;
            // 
            // supplierTextBox
            // 
            this.supplierTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(130)))));
            this.supplierTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.supplierTextBox.Location = new System.Drawing.Point(68, 11);
            this.supplierTextBox.Multiline = true;
            this.supplierTextBox.Name = "supplierTextBox";
            this.supplierTextBox.ReadOnly = true;
            this.supplierTextBox.Size = new System.Drawing.Size(284, 41);
            this.supplierTextBox.TabIndex = 239;
            this.supplierTextBox.Click += new System.EventHandler(this.supplierTextBox_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 240;
            this.label4.Text = "Supplier";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(2, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 13);
            this.label6.TabIndex = 242;
            this.label6.Text = "17, Dhanmondi R/A Road No.2, Dhaka-1205";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(2, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 25);
            this.label5.TabIndex = 241;
            this.label5.Text = "Baximco Chemical Division\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.totalItemLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 504);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel2.Size = new System.Drawing.Size(665, 41);
            this.panel2.TabIndex = 242;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clearButton);
            this.panel3.Controls.Add(this.closeButton);
            this.panel3.Controls.Add(this.saveButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(303, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 37);
            this.panel3.TabIndex = 10;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(130)))));
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clearButton.Location = new System.Drawing.Point(144, 7);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(60, 23);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(130)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.closeButton.Location = new System.Drawing.Point(225, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(130)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saveButton.Location = new System.Drawing.Point(61, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(62, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // totalItemLabel
            // 
            this.totalItemLabel.AutoSize = true;
            this.totalItemLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalItemLabel.ForeColor = System.Drawing.Color.Yellow;
            this.totalItemLabel.Location = new System.Drawing.Point(3, 5);
            this.totalItemLabel.Name = "totalItemLabel";
            this.totalItemLabel.Size = new System.Drawing.Size(0, 13);
            this.totalItemLabel.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 70);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.requisitionListView);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 14, 4, 14);
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(665, 434);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 244;
            // 
            // requisitionListView
            // 
            this.requisitionListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.requisitionListView.CheckBoxes = true;
            this.requisitionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requisitionListView.Location = new System.Drawing.Point(4, 46);
            this.requisitionListView.Name = "requisitionListView";
            this.requisitionListView.Size = new System.Drawing.Size(244, 36);
            this.requisitionListView.TabIndex = 1;
            this.requisitionListView.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 14);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel1.Size = new System.Drawing.Size(244, 32);
            this.panel1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(160, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(84, 28);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Item";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.tenderDataGridView);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBox4.Size = new System.Drawing.Size(661, 430);
            this.groupBox4.TabIndex = 244;
            this.groupBox4.TabStop = false;
            // 
            // tenderDataGridView
            // 
            this.tenderDataGridView.AllowUserToAddRows = false;
            this.tenderDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.tenderDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tenderDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.tenderDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(192)))), ((int)(((byte)(196)))));
            this.tenderDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(133)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tenderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tenderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tenderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSlno,
            this.removeColumn,
            this.ColumnDescription,
            this.ColumnUnit,
            this.ColumnOrdered,
            this.ColumnQtyBfrInsp,
            this.ColumnAmounts,
            this.ColumnRemarks,
            this.code,
            this.ReqID,
            this.ID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tenderDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.tenderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderDataGridView.EnableHeadersVisualStyles = false;
            this.tenderDataGridView.Location = new System.Drawing.Point(3, 16);
            this.tenderDataGridView.Name = "tenderDataGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tenderDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tenderDataGridView.RowHeadersVisible = false;
            this.tenderDataGridView.Size = new System.Drawing.Size(655, 404);
            this.tenderDataGridView.TabIndex = 232;
            this.tenderDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tenderDataGridView_CellClick);
            this.tenderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tenderDataGridView_CellFormatting);
            this.tenderDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tenderDataGridView_EditingControlShowing);
            // 
            // ColumnSlno
            // 
            this.ColumnSlno.HeaderText = "";
            this.ColumnSlno.Name = "ColumnSlno";
            this.ColumnSlno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSlno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSlno.Width = 25;
            // 
            // removeColumn
            // 
            this.removeColumn.HeaderText = "";
            this.removeColumn.Name = "removeColumn";
            this.removeColumn.ReadOnly = true;
            this.removeColumn.Visible = false;
            this.removeColumn.Width = 40;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Name of the Items";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 200;
            // 
            // ColumnUnit
            // 
            this.ColumnUnit.HeaderText = "Unit";
            this.ColumnUnit.Name = "ColumnUnit";
            this.ColumnUnit.ReadOnly = true;
            this.ColumnUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnUnit.Width = 50;
            // 
            // ColumnOrdered
            // 
            this.ColumnOrdered.HeaderText = "Required Qty";
            this.ColumnOrdered.Name = "ColumnOrdered";
            this.ColumnOrdered.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnOrdered.Width = 60;
            // 
            // ColumnQtyBfrInsp
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnQtyBfrInsp.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnQtyBfrInsp.HeaderText = "Rate";
            this.ColumnQtyBfrInsp.MaxInputLength = 8;
            this.ColumnQtyBfrInsp.Name = "ColumnQtyBfrInsp";
            this.ColumnQtyBfrInsp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnQtyBfrInsp.Width = 80;
            // 
            // ColumnAmounts
            // 
            this.ColumnAmounts.HeaderText = "Amount";
            this.ColumnAmounts.Name = "ColumnAmounts";
            this.ColumnAmounts.ReadOnly = true;
            this.ColumnAmounts.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnRemarks
            // 
            this.ColumnRemarks.HeaderText = "Remarks";
            this.ColumnRemarks.MaxInputLength = 1000;
            this.ColumnRemarks.Name = "ColumnRemarks";
            this.ColumnRemarks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRemarks.Width = 130;
            // 
            // code
            // 
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Visible = false;
            // 
            // ReqID
            // 
            this.ReqID.HeaderText = "ReqID";
            this.ReqID.Name = "ReqID";
            this.ReqID.ReadOnly = true;
            this.ReqID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "PTDId";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // SupplierTenderEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 545);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierTenderEntryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tender Entry";
            this.Load += new System.EventHandler(this.SupplierTenderEntryUI_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.supplierPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tenderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel supplierPanel;
        private System.Windows.Forms.Label addSupplierLabel;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.TextBox supplierTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label totalItemLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView tenderDataGridView;
        private System.Windows.Forms.ListView requisitionListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSlno;
        private System.Windows.Forms.DataGridViewImageColumn removeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQtyBfrInsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReqID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}