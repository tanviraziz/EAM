namespace StoreManagement.UI
{
    partial class AccountsMAPICsPostingUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.consumptionGroupBox = new System.Windows.Forms.GroupBox();
            this.consumptionGridView = new System.Windows.Forms.DataGridView();
            this.CompColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtDescColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrCrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VcNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createExcelButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.consumptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consumptionGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // consumptionGroupBox
            // 
            this.consumptionGroupBox.Controls.Add(this.consumptionGridView);
            this.consumptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumptionGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consumptionGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.consumptionGroupBox.Location = new System.Drawing.Point(0, 121);
            this.consumptionGroupBox.Name = "consumptionGroupBox";
            this.consumptionGroupBox.Size = new System.Drawing.Size(1163, 346);
            this.consumptionGroupBox.TabIndex = 245;
            this.consumptionGroupBox.TabStop = false;
            this.consumptionGroupBox.Text = "Consumption";
            // 
            // consumptionGridView
            // 
            this.consumptionGridView.AllowUserToAddRows = false;
            this.consumptionGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.consumptionGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.consumptionGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.consumptionGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(192)))), ((int)(((byte)(196)))));
            this.consumptionGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(133)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.consumptionGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.consumptionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consumptionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompColumn,
            this.CodeColumn,
            this.RefColumn,
            this.DateColumn,
            this.AmountColumn,
            this.DamtColumn,
            this.DescColumn,
            this.ExtDescColumn,
            this.DrCrColumn,
            this.VcNoColumn});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.consumptionGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.consumptionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumptionGridView.EnableHeadersVisualStyles = false;
            this.consumptionGridView.Location = new System.Drawing.Point(3, 17);
            this.consumptionGridView.Name = "consumptionGridView";
            this.consumptionGridView.RowHeadersVisible = false;
            this.consumptionGridView.Size = new System.Drawing.Size(1157, 326);
            this.consumptionGridView.TabIndex = 234;            
            this.consumptionGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.consumptionGridView_CellEndEdit);
            // 
            // CompColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CompColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.CompColumn.HeaderText = "Comp";
            this.CompColumn.Name = "CompColumn";
            this.CompColumn.Width = 50;
            // 
            // CodeColumn
            // 
            this.CodeColumn.HeaderText = "Code";
            this.CodeColumn.MaxInputLength = 25;
            this.CodeColumn.Name = "CodeColumn";
            this.CodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CodeColumn.Width = 120;
            // 
            // RefColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RefColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.RefColumn.HeaderText = "Ref";
            this.RefColumn.MaxInputLength = 10;
            this.RefColumn.Name = "RefColumn";
            this.RefColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RefColumn.Width = 70;
            // 
            // DateColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.MaxInputLength = 10;
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateColumn.Width = 80;
            // 
            // AmountColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.AmountColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.MaxInputLength = 15;
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AmountColumn.Width = 140;
            // 
            // DamtColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.DamtColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.DamtColumn.HeaderText = "Damt";
            this.DamtColumn.MaxInputLength = 2;
            this.DamtColumn.Name = "DamtColumn";
            this.DamtColumn.Width = 140;
            // 
            // DescColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.DescColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.DescColumn.HeaderText = "Desc";
            this.DescColumn.MaxInputLength = 200;
            this.DescColumn.Name = "DescColumn";
            this.DescColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DescColumn.Width = 120;
            // 
            // ExtDescColumn
            // 
            this.ExtDescColumn.HeaderText = "ExtDesc";
            this.ExtDescColumn.Name = "ExtDescColumn";
            this.ExtDescColumn.Width = 200;
            // 
            // DrCrColumn
            // 
            this.DrCrColumn.HeaderText = "DRCR";
            this.DrCrColumn.Name = "DrCrColumn";
            // 
            // VcNoColumn
            // 
            this.VcNoColumn.HeaderText = "VcNo";
            this.VcNoColumn.Name = "VcNoColumn";
            this.VcNoColumn.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.groupBox2.Controls.Add(this.createExcelButton);
            this.groupBox2.Controls.Add(this.showButton);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.monthComboBox);
            this.groupBox2.Controls.Add(this.yearPicker);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1163, 121);
            this.groupBox2.TabIndex = 244;
            this.groupBox2.TabStop = false;
            // 
            // createExcelButton
            // 
            this.createExcelButton.Location = new System.Drawing.Point(133, 68);
            this.createExcelButton.Name = "createExcelButton";
            this.createExcelButton.Size = new System.Drawing.Size(75, 23);
            this.createExcelButton.TabIndex = 13;
            this.createExcelButton.Text = "Create File";
            this.createExcelButton.UseVisualStyleBackColor = true;
            this.createExcelButton.Click += new System.EventHandler(this.createExcelButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(52, 68);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 12;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Year";
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(52, 18);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(108, 21);
            this.monthComboBox.TabIndex = 6;
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(52, 42);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(79, 20);
            this.yearPicker.TabIndex = 8;
            // 
            // AccountsMAPICsPostingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 467);
            this.Controls.Add(this.consumptionGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "AccountsMAPICsPostingUI";
            this.Text = "MAPICS Posting";
            this.Load += new System.EventHandler(this.AccountsMAPICsPostingUI_Load);
            this.consumptionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.consumptionGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox consumptionGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.DateTimePicker yearPicker;
        private System.Windows.Forms.DataGridView consumptionGridView;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button createExcelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtDescColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrCrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VcNoColumn;
    }
}