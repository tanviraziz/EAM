namespace StoreManagement.UI
{
    partial class SupplierSettingsUI
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
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.taskPane1 = new XPExplorerBar.TaskPane();
            this.suppliersListView = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(82)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 34);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(82)))), ((int)(((byte)(97)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.refreshButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(594, 34);
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
            this.addButton.Size = new System.Drawing.Size(64, 34);
            this.addButton.Text = "New";
            this.addButton.ToolTipText = " Add New Supplier";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = false;
            this.editButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Image = global::StoreManagement.Properties.Resources.edit24;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(64, 34);
            this.editButton.Text = " Edit";
            this.editButton.ToolTipText = " Edit a Supplier";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
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
            // taskPane1
            // 
            this.taskPane1.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskPane1.Location = new System.Drawing.Point(473, 34);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(121, 373);
            this.taskPane1.TabIndex = 4;
            this.taskPane1.Text = "taskPane1";
            this.taskPane1.Visible = false;
            // 
            // suppliersListView
            // 
            this.suppliersListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suppliersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suppliersListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersListView.FullRowSelect = true;
            this.suppliersListView.GridLines = true;
            this.suppliersListView.Location = new System.Drawing.Point(0, 34);
            this.suppliersListView.Name = "suppliersListView";
            this.suppliersListView.Size = new System.Drawing.Size(473, 373);
            this.suppliersListView.TabIndex = 5;
            this.suppliersListView.UseCompatibleStateImageBehavior = false;
            this.suppliersListView.View = System.Windows.Forms.View.Details;
            this.suppliersListView.DoubleClick += new System.EventHandler(this.suppliersListView_DoubleClick);
            // 
            // SupplierSettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 407);
            this.Controls.Add(this.suppliersListView);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierSettingsUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers Management";
            this.Load += new System.EventHandler(this.SupplierSettingsUI_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPane1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private XPExplorerBar.TaskPane taskPane1;
        private System.Windows.Forms.ListView suppliersListView;
        private System.Windows.Forms.ToolStripButton refreshButton;
    }
}