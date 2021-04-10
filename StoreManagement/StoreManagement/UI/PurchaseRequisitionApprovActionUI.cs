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
using System.Globalization;

namespace StoreManagement.UI
{
    public partial class PurchaseRequisitionApprovActionUI : Form
    {
        #region Variables
        private PurchaseManager purchaseManager = null;
            private DynamicControlFill fillControll = null;
            private string authorityState = null;
            private MonthYearConvertion convertMonthYear = null;
        #endregion

        public PurchaseRequisitionApprovActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            fillControll = new DynamicControlFill();
            convertMonthYear = new MonthYearConvertion();
        }

        public PurchaseRequisitionApprovActionUI(String authority):this()
        {
            authorityState = authority.Trim();
        }

        private void PurchaseRequisitionAppActionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowData();
            fillControll.FillMonth(monthComboBox);
        }

        private void ShowData()
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    confirmButton.Visible = true;
                    pReqDetailListView.Items.Clear();

                    switch (authorityState.Trim())
                    {
                        case "1":
                            fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseRequisitonApprovalList("1", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,", "100,100,140,120,100,100,");
                            break;
                        case "2":
                            fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseRequisitonApprovalList("11", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,", "100,100,140,120,100,100,");
                            break;
                    }
                    break;
                case 1:
                    taskPane1.Visible = true;
                    confirmButton.Visible = false;
                    cReqDetailListView.Items.Clear();

                    switch (authorityState.Trim())
                    {
                        case "1":
                            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseRequisitonApprovalList("2", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status,", "100,100,140,120,100,100,250,");
                            break;
                        case "2":
                            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseRequisitonApprovalList("21", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status,", "100,100,140,120,100,100,250,");
                            break;
                    }

                    ColorEmergencyRequisition();
                    break;
                    
            }
        }

        private void ColorEmergencyRequisition()
        {
            foreach (ListViewItem lstItem in completeListView.Items)
            {
                if (lstItem.SubItems[7].Text.Trim().ToUpper() == "Y")
                {
                    lstItem.UseItemStyleForSubItems = true;

                    lstItem.BackColor = Color.FromArgb(255, 0, 170);                    
                    lstItem.ForeColor = Color.White;
                    lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
            }
        }

        private void purReqTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Requisition requisition = null;
            if (pendingListView.SelectedIndices.Count > 0)
            {
                if (requisition == null)
                {
                    requisition = new Requisition();
                }

                requisition.PrrNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                switch (authorityState.Trim())
                {
                    case "1":
                        requisition.Condition = "41";
                        break;
                    case "2":
                        requisition.Condition = "42";
                        break;
                }                

                if (purchaseManager.PrrConfirmedAndVerified(requisition))
                {
                    ShowData();
                }
                requisition = null;
            }
            else
            {
                MessageBox.Show("Select a requisition from list");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNO = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                pendingGroupBox.Text = "Req No. : " + reqNO + " detail";
                ShowReqDetail(reqNO);
            }
        }

        private void ShowReqDetail(string reqNo)
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    fillControll.fillListView(pReqDetailListView, purchaseManager.GetPurchaseRequisitonApprovalList("3", reqNo), "Item, Unit,Current Stock,Required Qty,Remarks", "250,100,140,140,200");
                    break;
                case 1:
                    fillControll.fillListView(cReqDetailListView, purchaseManager.GetPurchaseRequisitonApprovalList("3", reqNo), "Item, Unit,Current Stock,Required Qty,Remarks", "250,100,140,140,200");
                    break;
            }
        }

        private void pendingListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            fillControll.ListViewSort(pendingListView, e.Column);
        }

        private void completeListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            fillControll.ListViewSort(completeListView, e.Column);
        }

        private void ordInMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                string strMonth = convertMonthYear.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim());
                ShowSearchResult("1", strMonth, null);
            }
        }

        private void ShowSearchResult(string choice, string condition1, string condition2)
        {
            fillControll.fillListView(completeListView, purchaseManager.GetStoreAuthorityReportList(choice, condition1, condition2), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status", "100,100,140,120,100,100,250");
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                pendingGroupBox.Text = "Req No. : " + reqNO + " detail";
                ShowReqDetail(reqNO);
            }
        }      
    }
}
