namespace StoreManagement.UI
{
    partial class FSDInspectionRemarksEntryUI
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
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.remarksTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remarksListView = new System.Windows.Forms.ListView();
            this.dataGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.dataGroupBox.Controls.Add(this.clearButton);
            this.dataGroupBox.Controls.Add(this.saveButton);
            this.dataGroupBox.Controls.Add(this.remarksTextBox);
            this.dataGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGroupBox.ForeColor = System.Drawing.Color.Yellow;
            this.dataGroupBox.Location = new System.Drawing.Point(4, 4);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.dataGroupBox.Size = new System.Drawing.Size(286, 77);
            this.dataGroupBox.TabIndex = 0;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "New";
            // 
            // clearButton
            // 
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(224, 46);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(53, 22);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(158, 46);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(57, 22);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // remarksTextBox
            // 
            this.remarksTextBox.Location = new System.Drawing.Point(9, 21);
            this.remarksTextBox.Name = "remarksTextBox";
            this.remarksTextBox.Size = new System.Drawing.Size(270, 21);
            this.remarksTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.groupBox2.Controls.Add(this.remarksListView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 247);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // remarksListView
            // 
            this.remarksListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remarksListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remarksListView.FullRowSelect = true;
            this.remarksListView.GridLines = true;
            this.remarksListView.Location = new System.Drawing.Point(3, 16);
            this.remarksListView.Name = "remarksListView";
            this.remarksListView.Size = new System.Drawing.Size(280, 228);
            this.remarksListView.TabIndex = 0;
            this.remarksListView.UseCompatibleStateImageBehavior = false;
            this.remarksListView.View = System.Windows.Forms.View.Details;
            this.remarksListView.SelectedIndexChanged += new System.EventHandler(this.remarksListView_SelectedIndexChanged);
            // 
            // FSDInspectionRemarksEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 332);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(310, 331);
            this.Name = "FSDInspectionRemarksEntryUI";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspection Remarks ";
            this.Load += new System.EventHandler(this.FSDInspectionRemarksEntryUI_Load);
            this.dataGroupBox.ResumeLayout(false);
            this.dataGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox remarksTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView remarksListView;
    }
}