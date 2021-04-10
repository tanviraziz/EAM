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
    public partial class FSDInspectionRemarksEntryUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private MasterSetupManager settingManager = null;
            private bool IsEdit = false;
            private string remarksToEdit = null;
            private InspectionRemarks remark = null;
        #endregion
        
        public FSDInspectionRemarksEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            settingManager = new MasterSetupManager();
        }

        private void FSDInspectionRemarksEntryUI_Load(object sender, EventArgs e)
        {
            fillControll.fillListView(remarksListView,settingManager.GetInspectionRemarksList("1",null),"Remarks,","280,");
        }

        private void remarksListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remarksListView.SelectedIndices.Count > 0)
            {
                dataGroupBox.Text = "Edit";
                remarksTextBox.Text = remarksListView.Items[remarksListView.SelectedIndices[0]].Text.Trim();
                remarksToEdit = remarksListView.Items[remarksListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                IsEdit = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            remarksTextBox.Clear();
            IsEdit = false;
            remarksToEdit = null;
            dataGroupBox.Text = "New";
            fillControll.fillListView(remarksListView, settingManager.GetInspectionRemarksList("1", null), "Remarks,", "280,");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (settingManager.InspecRemarksManagement(remark))
                {
                   // MessageBox.Show("Saved successfully.");
                    ClearAllFields();
                }
            }
            remark = null;
        }

        private bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(remarksTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter remarks.");
                    return false;
                }
                else
                {
                    SetValues();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SetValues()
        {
            if (remark == null)
            {
                remark = new InspectionRemarks();
            }

            remark.Remarks = remarksTextBox.Text.Trim();

            if (IsEdit)
            {
                remark.RemarksID = remarksToEdit.Trim();
                remark.Condition = "2";
            }
        }
    }
}
