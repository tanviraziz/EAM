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
using StoreManagement.UI;
using StoreManagement.UTILITY;
using StoreManagement.Reports.Purchase.Tender;
using System.Globalization;

namespace StoreManagement.UI
{
    public partial class PurchaseRequisitionActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public PurchaseRequisitionActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void PurchaseRequisitionListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowList();
            fillControll.FillMonth(monthComboBox);
        }

        private void ShowList()
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseRequistionList("1", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,", "100,100,180,120,100,100,");
                    break;
                case 1:
                    fillControll.fillListView(completeListView, purchaseManager.GetPurchaseRequistionList("2", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status,,", "100,100,180,120,100,100,250,,","6");

                    ColorEmergencyRequisition();
                    break;
            }
        }

        private void ColorEmergencyRequisition()
        {
            try
            {
                foreach (ListViewItem lstItem in completeListView.Items)
                {
                    if (lstItem.SubItems[8].Text.Trim().ToUpper() == "Y")
                    {
                        lstItem.UseItemStyleForSubItems = true;

                        lstItem.BackColor = Color.FromArgb(255, 0, 170);
                        lstItem.ForeColor = Color.White;
                        lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                    }
                }
            }
            catch { }
        }

        private void purReqTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    taskPane1.Visible = false;
                    newRequisitonButton.Visible = true;
                    editRequisitonButton.Visible = false;
                    refreshButton.Visible = true;
                    printButton.Visible = true;
                    confirmedButton.Visible = true;
                    break;
                case 1:
                    taskPane1.Visible = true;
                    newRequisitonButton.Visible = false;
                    editRequisitonButton.Visible = false;
                    refreshButton.Visible = true;
                    printButton.Visible = true;
                    confirmedButton.Visible = false;
                    break;
            }
            ShowList();
        }

        #region Requistion Management

        //New requistion 
        private void newRequisitonButton_Click(object sender, EventArgs e)
        {
            new PurchaseRequisitionEntryUI().ShowDialog();
            ShowList();
        }

        private void ShowEntryForm(Form frm)
        {
            //frm.MdiParent = MdiParent;
            frm.ShowDialog();
        }

        //Edit requistion
        private void editRequisitonButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                new PurchaseRequisitionEntryUI(reqNo).ShowDialog();
                ShowReqDetail(reqNo);
            }            
        }

        //Refresh the list
        private void refreshButton_Click(object sender, EventArgs e)
        {
            editRequisitonButton.Visible = false;
            pendingGroupBox.Text = "Requisition Detail";
            pReqDetailListView.Items.Clear();
            cReqDetailListView.Items.Clear();
            ShowList();
        }

        #endregion

        private void pendingListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                new PurchaseRequisitionEntryUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
            }
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNO = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                editRequisitonButton.Visible = true;
                pendingGroupBox.Text = "Req No. : " + reqNO + " detail";
                ShowReqDetail(reqNO);
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                completeGroupBox.Text = "Req No. : " + reqNO + " detail";
                ShowReqDetail(completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim());
            }
        }

        private void ShowReqDetail(string reqNo)
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    fillControll.fillListView(pReqDetailListView, purchaseManager.GetPurchaseRequistionList("3", reqNo), "Item, Unit,Current Stock,Required Qty,Remarks", "250,100,140,140,200");
                    break;
                case 1:
                    fillControll.fillListView(cReqDetailListView, purchaseManager.GetPurchaseRequistionList("3", reqNo), "Item, Unit,Current Stock,Required Qty,Remarks", "250,100,140,140,200");
                    break;
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            string reqNO = null;
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    reqNO = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                    break;
                case 1:
                    reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                    break;
            }

            if (!string.IsNullOrEmpty(reqNO))
            {                
                ReportViwer reportViewer = null;
                reportViewer = new ReportViwer(purchaseManager.GetPurchaseRequisitionReport("1", reqNO,null), new TenderRequisitionReport());
                reportViewer.Show();
            }
            else
            {
                MessageBox.Show("Select a requisition from list.");
            }    
        }

        private void confirmedButton_Click(object sender, EventArgs e)
        {
            Requisition requisition = null;
            if (pendingListView.SelectedIndices.Count > 0)
            {
                if (requisition == null)
                {
                    requisition = new Requisition();
                }

                requisition.PrrNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                requisition.Condition = "4";

                if (purchaseManager.PrrConfirmedAndVerified(requisition))
                {
                    ShowList();
                }

                //else
                //{
                //    MessageBox.Show("Failed to save");
                //}
                requisition = null;
                
            }
            else
            {
                MessageBox.Show("Select a requisition from list");
            }
        }

        private void ShowSearchResult(string choice, string condition1, string condition2)
        {
            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseRequisitionReport(choice, condition1,condition2), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status", "100,100,140,120,100,100,250");
            cReqDetailListView.Items.Clear();
            
        }

        private void reqReadyForTenderTaskItem_Click(object sender, EventArgs e)
        {
            ShowSearchResult("2", null,null);
        }

        private void reqTenderAppTaskItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                string strMonth = monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim());
                ShowSearchResult("3", strMonth, null);            
            }
        }

        private void reqMonthWiseTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                string strMonth = monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim());
                ShowSearchResult("4", strMonth, null);
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

        private void purOrderButton_Click(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string reqNo, reqStatus;
                reqNo = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                reqStatus = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[7].Text.Trim();
                if (reqStatus.Trim() == "2")
                {
                    new PurchaseOrderEntryUI(reqNo, reqStatus).ShowDialog();
                    ShowList();
                }
                else
                {
                    MessageBox.Show("Invalid requisition");
                }                
            }
            else
            {
                MessageBox.Show("Select a requistion from the list");
            }
        }
    }
}
