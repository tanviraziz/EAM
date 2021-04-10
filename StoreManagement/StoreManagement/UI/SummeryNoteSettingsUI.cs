using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class SummeryNoteSettingsUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private InspectionNotes summeryNote = null;
            private bool IsEdit = false;
            private string noteToEdit = null;
            private DynamicControlFill fillControl = null;
        #endregion

        public SummeryNoteSettingsUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            fillControl = new DynamicControlFill();
        }

        private void SummeryNoteSettingsUI_Load(object sender, EventArgs e)
        {
            this.saveNoteButton.Click += new EventHandler(this.saveButton_Click);
            this.clearNoteButton.Click += new EventHandler(this.cleareButton_Click);
            this.saveReferenceButton.Click += new EventHandler(this.saveButton_Click);
            this.clearReferenceButton.Click += new EventHandler(this.cleareButton_Click);

            FillData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(IsValid(summeryNoteTabControl.SelectedIndex))
            {
                if (settingsManager.SummeryNoteManagement(summeryNote))
                {
                    ClearAllFields();
                }
            }

            summeryNote = null;
        }

        private bool IsValid(int choice)
        {
            try
            {
                switch (choice)
                {
                    case 0:
                        if(string.IsNullOrEmpty(noteTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter Note");
                            return false;
                        }
                        else if (NoteExists())
                        {
                            MessageBox.Show("Note already exist");
                            return false;
                        }
                        else if (string.IsNullOrEmpty(referenceComboBox.Text.Trim()))
                        {
                            MessageBox.Show("Select note reference");
                            return false;
                        }
                        break;
                    case 1:
                        if (string.IsNullOrEmpty(referenceTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter reference");
                            return false;
                        }                        
                        break;
                }

                SetValues(choice);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool NoteExists()
        {
            try
            {
                foreach (ListViewItem item in noteListView.Items)
                {
                    if (item.Text.Trim().ToUpper() == noteTextBox.Text.Trim().ToUpper())
                    {
                        return true;
                    }   
                }
            }
            catch 
            {
                return true;
            }
            return false;
        }

        private void SetValues(int choice)
        {
            if (summeryNote == null)
            {
                summeryNote = new InspectionNotes();
            }

            switch (choice)
            {
                case 0:
                    summeryNote.Note = noteTextBox.Text.Trim().ToUpper();
                    summeryNote.RefID = referenceComboBox.SelectedValue.ToString();
                    if (IsEdit)
                    {
                        summeryNote.refNoteID = noteToEdit;
                        summeryNote.Condition = "4";
                    }
                    else
                    {
                        summeryNote.Condition = "3";
                    }
                    break;
                case 1:
                    summeryNote.Note = referenceTextBox.Text.Trim();
                    if (IsEdit)
                    {
                        summeryNote.refNoteID = noteToEdit;
                        summeryNote.Condition = "2";
                    }                    
                    break;
            }
        }

        private void cleareButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            switch (summeryNoteTabControl.SelectedIndex)
            {
                case 0:
                    noteTextBox.Clear();
                    noteGroupBox.Text = "New";
                    break;
                case 1:
                    referenceTextBox.Clear();
                    referenceGroupBox.Text = "New";
                    break;
            }

            FillData();
            IsEdit = false;
            noteToEdit = null;
        }

        private void summeryNoteTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            switch (summeryNoteTabControl.SelectedIndex)
            {
                case 0:
                    fillControl.fillListView(noteListView, settingsManager.GetSummeryNoteList("2", null), "Note,Reference,", "100,200,");
                    fillControl.fillCombo(referenceComboBox, settingsManager.GetSummeryNoteList("1", null), "NoteRef", "Code");
                    referenceComboBox.SelectedIndex = -1;
                    break;
                case 1:
                    fillControl.fillListView(referenceListView, settingsManager.GetSummeryNoteList("1", null), "Note,", "300,");
                    break;
            }
        }

        private void referenceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (referenceListView.SelectedIndices.Count > 0)
            {
                IsEdit = true;
                referenceGroupBox.Text = "Edit";
                referenceTextBox.Text = referenceListView.Items[referenceListView.SelectedIndices[0]].Text.Trim();
                noteToEdit = referenceListView.Items[referenceListView.SelectedIndices[0]].SubItems[1].Text.Trim();
            }
        }

        private void noteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noteListView.SelectedIndices.Count > 0)
            {
                IsEdit = true;
                noteGroupBox.Text = "Edit";
                noteTextBox.Text = noteListView.Items[noteListView.SelectedIndices[0]].Text.Trim();
                referenceComboBox.Text = noteListView.Items[noteListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                noteToEdit = noteListView.Items[noteListView.SelectedIndices[0]].SubItems[2].Text.Trim();
            }
        }

    }
}
