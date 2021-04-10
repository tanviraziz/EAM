namespace StoreManagement.UI
{
    partial class SummeryNoteSettingsUI
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
            this.summeryNoteTabControl = new FlatTabControl.FlatTabControl();
            this.noteTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.noteListView = new System.Windows.Forms.ListView();
            this.noteGroupBox = new System.Windows.Forms.GroupBox();
            this.clearNoteButton = new System.Windows.Forms.Button();
            this.saveNoteButton = new System.Windows.Forms.Button();
            this.referenceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.referenceTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.referenceListView = new System.Windows.Forms.ListView();
            this.referenceGroupBox = new System.Windows.Forms.GroupBox();
            this.clearReferenceButton = new System.Windows.Forms.Button();
            this.saveReferenceButton = new System.Windows.Forms.Button();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.summeryNoteTabControl.SuspendLayout();
            this.noteTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.noteGroupBox.SuspendLayout();
            this.referenceTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.referenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // summeryNoteTabControl
            // 
            this.summeryNoteTabControl.Controls.Add(this.noteTabPage);
            this.summeryNoteTabControl.Controls.Add(this.referenceTabPage);
            this.summeryNoteTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summeryNoteTabControl.Location = new System.Drawing.Point(0, 0);
            this.summeryNoteTabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.summeryNoteTabControl.Name = "summeryNoteTabControl";
            this.summeryNoteTabControl.SelectedIndex = 0;
            this.summeryNoteTabControl.Size = new System.Drawing.Size(388, 422);
            this.summeryNoteTabControl.TabIndex = 11;
            this.summeryNoteTabControl.SelectedIndexChanged += new System.EventHandler(this.summeryNoteTabControl_SelectedIndexChanged);
            // 
            // noteTabPage
            // 
            this.noteTabPage.Controls.Add(this.groupBox2);
            this.noteTabPage.Controls.Add(this.noteGroupBox);
            this.noteTabPage.Location = new System.Drawing.Point(4, 25);
            this.noteTabPage.Name = "noteTabPage";
            this.noteTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.noteTabPage.Size = new System.Drawing.Size(380, 393);
            this.noteTabPage.TabIndex = 0;
            this.noteTabPage.Text = "Notes";
            this.noteTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.groupBox2.Controls.Add(this.noteListView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 272);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // noteListView
            // 
            this.noteListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noteListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteListView.FullRowSelect = true;
            this.noteListView.GridLines = true;
            this.noteListView.Location = new System.Drawing.Point(3, 16);
            this.noteListView.Name = "noteListView";
            this.noteListView.Size = new System.Drawing.Size(368, 253);
            this.noteListView.TabIndex = 0;
            this.noteListView.UseCompatibleStateImageBehavior = false;
            this.noteListView.View = System.Windows.Forms.View.Details;
            this.noteListView.SelectedIndexChanged += new System.EventHandler(this.noteListView_SelectedIndexChanged);
            // 
            // noteGroupBox
            // 
            this.noteGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.noteGroupBox.Controls.Add(this.clearNoteButton);
            this.noteGroupBox.Controls.Add(this.saveNoteButton);
            this.noteGroupBox.Controls.Add(this.referenceComboBox);
            this.noteGroupBox.Controls.Add(this.label1);
            this.noteGroupBox.Controls.Add(this.label2);
            this.noteGroupBox.Controls.Add(this.noteTextBox);
            this.noteGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteGroupBox.ForeColor = System.Drawing.Color.Yellow;
            this.noteGroupBox.Location = new System.Drawing.Point(3, 3);
            this.noteGroupBox.Name = "noteGroupBox";
            this.noteGroupBox.Padding = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.noteGroupBox.Size = new System.Drawing.Size(374, 115);
            this.noteGroupBox.TabIndex = 3;
            this.noteGroupBox.TabStop = false;
            this.noteGroupBox.Text = "New";
            // 
            // clearNoteButton
            // 
            this.clearNoteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.clearNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearNoteButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearNoteButton.ForeColor = System.Drawing.Color.White;
            this.clearNoteButton.Location = new System.Drawing.Point(302, 84);
            this.clearNoteButton.Name = "clearNoteButton";
            this.clearNoteButton.Size = new System.Drawing.Size(52, 24);
            this.clearNoteButton.TabIndex = 13;
            this.clearNoteButton.Text = "Clear";
            this.clearNoteButton.UseVisualStyleBackColor = false;
            // 
            // saveNoteButton
            // 
            this.saveNoteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.saveNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNoteButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNoteButton.ForeColor = System.Drawing.Color.White;
            this.saveNoteButton.Location = new System.Drawing.Point(244, 84);
            this.saveNoteButton.Name = "saveNoteButton";
            this.saveNoteButton.Size = new System.Drawing.Size(52, 24);
            this.saveNoteButton.TabIndex = 12;
            this.saveNoteButton.Text = "Save";
            this.saveNoteButton.UseVisualStyleBackColor = false;
            // 
            // referenceComboBox
            // 
            this.referenceComboBox.FormattingEnabled = true;
            this.referenceComboBox.Location = new System.Drawing.Point(84, 48);
            this.referenceComboBox.Name = "referenceComboBox";
            this.referenceComboBox.Size = new System.Drawing.Size(270, 21);
            this.referenceComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reference";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Note";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(84, 21);
            this.noteTextBox.MaxLength = 2;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(58, 21);
            this.noteTextBox.TabIndex = 0;
            // 
            // referenceTabPage
            // 
            this.referenceTabPage.Controls.Add(this.groupBox1);
            this.referenceTabPage.Controls.Add(this.referenceGroupBox);
            this.referenceTabPage.Location = new System.Drawing.Point(4, 25);
            this.referenceTabPage.Name = "referenceTabPage";
            this.referenceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.referenceTabPage.Size = new System.Drawing.Size(380, 393);
            this.referenceTabPage.TabIndex = 1;
            this.referenceTabPage.Text = "Note Reference";
            this.referenceTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.groupBox1.Controls.Add(this.referenceListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 289);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // referenceListView
            // 
            this.referenceListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.referenceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referenceListView.FullRowSelect = true;
            this.referenceListView.GridLines = true;
            this.referenceListView.Location = new System.Drawing.Point(3, 16);
            this.referenceListView.Name = "referenceListView";
            this.referenceListView.Size = new System.Drawing.Size(368, 270);
            this.referenceListView.TabIndex = 0;
            this.referenceListView.UseCompatibleStateImageBehavior = false;
            this.referenceListView.View = System.Windows.Forms.View.Details;
            this.referenceListView.SelectedIndexChanged += new System.EventHandler(this.referenceListView_SelectedIndexChanged);
            // 
            // referenceGroupBox
            // 
            this.referenceGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.referenceGroupBox.Controls.Add(this.clearReferenceButton);
            this.referenceGroupBox.Controls.Add(this.saveReferenceButton);
            this.referenceGroupBox.Controls.Add(this.referenceTextBox);
            this.referenceGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.referenceGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceGroupBox.ForeColor = System.Drawing.Color.White;
            this.referenceGroupBox.Location = new System.Drawing.Point(3, 3);
            this.referenceGroupBox.Name = "referenceGroupBox";
            this.referenceGroupBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.referenceGroupBox.Size = new System.Drawing.Size(374, 98);
            this.referenceGroupBox.TabIndex = 5;
            this.referenceGroupBox.TabStop = false;
            this.referenceGroupBox.Text = "New";
            // 
            // clearReferenceButton
            // 
            this.clearReferenceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.clearReferenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearReferenceButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearReferenceButton.ForeColor = System.Drawing.Color.White;
            this.clearReferenceButton.Location = new System.Drawing.Point(310, 66);
            this.clearReferenceButton.Name = "clearReferenceButton";
            this.clearReferenceButton.Size = new System.Drawing.Size(52, 24);
            this.clearReferenceButton.TabIndex = 15;
            this.clearReferenceButton.Text = "Clear";
            this.clearReferenceButton.UseVisualStyleBackColor = false;
            // 
            // saveReferenceButton
            // 
            this.saveReferenceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(130)))), ((int)(((byte)(176)))));
            this.saveReferenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveReferenceButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveReferenceButton.ForeColor = System.Drawing.Color.White;
            this.saveReferenceButton.Location = new System.Drawing.Point(252, 66);
            this.saveReferenceButton.Name = "saveReferenceButton";
            this.saveReferenceButton.Size = new System.Drawing.Size(52, 24);
            this.saveReferenceButton.TabIndex = 14;
            this.saveReferenceButton.Text = "Save";
            this.saveReferenceButton.UseVisualStyleBackColor = false;
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(5, 21);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(362, 21);
            this.referenceTextBox.TabIndex = 0;
            // 
            // SummeryNoteSettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 422);
            this.Controls.Add(this.summeryNoteTabControl);
            this.Name = "SummeryNoteSettingsUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summery Note Settings";
            this.Load += new System.EventHandler(this.SummeryNoteSettingsUI_Load);
            this.summeryNoteTabControl.ResumeLayout(false);
            this.noteTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.noteGroupBox.ResumeLayout(false);
            this.noteGroupBox.PerformLayout();
            this.referenceTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.referenceGroupBox.ResumeLayout(false);
            this.referenceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatTabControl.FlatTabControl summeryNoteTabControl;
        private System.Windows.Forms.TabPage noteTabPage;
        private System.Windows.Forms.TabPage referenceTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView noteListView;
        private System.Windows.Forms.GroupBox noteGroupBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ComboBox referenceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView referenceListView;
        private System.Windows.Forms.GroupBox referenceGroupBox;
        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.Button clearNoteButton;
        private System.Windows.Forms.Button saveNoteButton;
        private System.Windows.Forms.Button clearReferenceButton;
        private System.Windows.Forms.Button saveReferenceButton;
    }
}