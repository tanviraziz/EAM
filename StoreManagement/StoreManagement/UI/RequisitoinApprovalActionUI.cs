using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class RequisitoinApprovalActionUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private SRRManager srrManager = null;
            private DynamicControlFill fillControll = null;
        #endregion

        public RequisitoinApprovalActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            srrManager = new SRRManager();
            fillControll = new DynamicControlFill();
        }

        private void RequisitoinApprovalListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the month combo wiht month name
            fillControll.FillMonth(monthComboBox);
            monthComboBox.Text = DateTime.Now.ToString("MMMM");

            //fill the current year
            yearDatePicker.Value = DateTime.Now;

            ShowData();
        }

        private void requisitionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            switch (requisitionTabControl.SelectedIndex)
            {
                case 0:
                    taskPane1.Visible = false;
                    fillControll.fillListView(pendingListView, srrManager.GetAuthoritySRRList("1", LoginUser.UserDepartment, LoginUser.UserID), "Requisition No, Req. Date,Purpose,Department", "100,100,250,250");
                    break;
                case 1:
                    //taskPane1.Visible = true;
                    addButton.Visible = false;
                    editButton.Visible = false;
                    fillControll.fillListView(completeListView, srrManager.GetAuthoritySRRList("2", LoginUser.UserDepartment, LoginUser.UserID), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,100,100,250,250");
                    break;
            }
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim());
                editButton.Visible = true;
            }
        }

        private void ShowRequisitonDetail(string srrNo)
        {
            switch (requisitionTabControl.SelectedIndex)
            {
                case 0:
                    pendingGroupBox.Text = "Requistion No. : " + srrNo + " detail";
                    fillControll.fillListView(pDetailListView, srrManager.GetAuthoritySRRList("4", srrNo, null), "Item,Unit,Req Qty,Apprv. Qty,Issued,Remarks", "250,60,60,60,60,400");
                    break;
                case 1:
                    completeGroupBox.Text = "Requistion No. : " + srrNo + " detail";
                    fillControll.fillListView(cDetailListView, srrManager.GetAuthoritySRRList("4", srrNo, null), "Item,Unit,Req Qty,Apprv. Qty,Issued,Remarks", "250,60,60,60,60,400");
                    break;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                new UserSRREntryUI(false,pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text);
            }
        }

        private void pendingListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                new UserSRREntryUI(false, pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text);
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim());
            }
        }

        
    }
}
