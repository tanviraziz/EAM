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
using StoreManagement.Reports.Purchase.Tender;
using CrystalDecisions;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace StoreManagement.UI
{
    public partial class PurchaseOrderActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private MonthYearConvertion monthYearConvert = null;
            private MasterSetupManager settingsManager = null;
        #endregion

        public PurchaseOrderActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            monthYearConvert = new MonthYearConvertion();
            settingsManager = new MasterSetupManager();
        }

        private void ShowList()
        {
            switch (purchaseOrderTabControl.SelectedIndex)
            {
                case 0:
                    purOrderButton.Visible = true;
                    editButton.Visible = false;
                    printButton.Visible = false;
                    taskPane1.Visible = false;
                    tenderListView.Items.Clear();
                    reqOrderDetailListView.Items.Clear();

                    fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseOrderList("1", null), "Requisition No.,Date,Total Item,Ordered Qty,", "100,100,100,100,");
                    break;
                case 1:
                    purOrderButton.Visible = false;
                    //editButton.Visible = true;
                    printButton.Visible = true;
                    taskPane1.Visible = true;
                    orderDetailListView.Items.Clear();

                    fillControll.fillListView(completeListView, purchaseManager.GetPurchaseOrderList("5", null), "Order No.,Order Date,Delivery Date,Supplier,Total Item,,,", "100,100,100,250,100,,,");
                    ColorOrderOnState();
                    break;
            }
        }

        private void ColorOrderOnState()
        {
            foreach (ListViewItem lstItem in completeListView.Items)
            {
                if (lstItem.SubItems[7].Text.Trim().ToUpper() == "1")
                {
                    lstItem.UseItemStyleForSubItems = true;

                    lstItem.BackColor = Color.FromArgb(255, 0, 170);
                    lstItem.ForeColor = Color.White;
                    lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
            }
        }

        private void PurchaseOrderListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the months
            fillControll.FillMonth(monthComboBox);

            fillControll.fillCombo(supplierComboBox, settingsManager.GetSupplierList("3",null), "Supplier", "Code");

            ShowList();
        }

        private void purchaseOrderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pendingListView.SelectedIndices.Count > 0)
            //{
            //    new PurchaseOrderEntryUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
                ShowList();
           // }                     
        }

        private void pendingListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNo, reqStatus;
                reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                reqStatus = pendingListView.Items[pendingListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                new PurchaseOrderEntryUI(reqNo, reqStatus).ShowDialog();
                ShowList();
            }            
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();

                tenderGroupBox.Text = "Req No. : " + reqNo + " Pending Tenders";
                fillControll.fillListView(tenderListView, purchaseManager.GetPurchaseOrderList("3", reqNo), "Supplier,Rate,", "250,100,", false);
                fillControll.BuildGroups(2, tenderListView, true);

                orderGroupBox.Text = "Req No. : " + reqNo + " Orders Detail";
                fillControll.fillListView(reqOrderDetailListView, purchaseManager.GetPurchaseOrderList("4", reqNo), "Item,Order Qty,Unit Price,VAT,", "500,120,120,120,", false);
                fillControll.BuildGroups(4, reqOrderDetailListView, true);
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string pid = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[5].Text.Trim();
                ShowOrderDetail(pid);
            }
        }

        private void ShowOrderDetail(string ordID)
        {
            fillControll.fillListView(orderDetailListView, purchaseManager.GetPurchaseOrderList("7", ordID), "Code,Item,Unit,Qty,Price", "100,300,60,80,80", true);
        }

        //private void tenderAddButton_Click(object sender, EventArgs e)
        //{
        //    if (pendingListView.SelectedIndices.Count > 0)
        //    {
        //        new SupplierTenderEntryUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
        //        //ShowList();
        //    } 
        //}

        //private void reqMailButton_Click(object sender, EventArgs e)
        //{
        //    if (pendingListView.SelectedIndices.Count > 0)
        //    {
        //        new PurchaseRequisitionMailUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
        //    } 
        //}

        //private void emargPurOrderButton_Click(object sender, EventArgs e)
        //{
        //    new PurchaseOrderEmrgEntryUI().ShowDialog();
        //}

        

        private void purOrderButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNo, reqStatus;
                reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                reqStatus = pendingListView.Items[pendingListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                new PurchaseOrderEntryUI(reqNo, reqStatus).ShowDialog();

                ShowList();
            }
            else
            {
                MessageBox.Show("Select a requisition from list to create order.");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string ordID = null;
            if (completeListView.SelectedIndices.Count > 0)
            {
                string status = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[6].Text.Trim();
                if (status == "1")
                {
                    ordID = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                    //if (completeListView.Items[completeListView.SelectedIndices[0]].SubItems[5].Text.Trim().ToUpper() == "Y")
                    //{
                    //    //new PurchaseOrderEmrgEntryUI(completeListView.Items[completeListView.SelectedIndices[0]].SubItems[4].Text.Trim(), true).ShowDialog();
                    //    new PurchaseOrderEmrgEntryUI(ordID, true).ShowDialog();
                    //}
                    //else
                    //{
                        //new PurchaseOrderEntryUI(completeListView.Items[completeListView.SelectedIndices[0]].SubItems[4].Text.Trim(), true).ShowDialog();
                        new PurchaseOrderEntryUI(ordID, true).ShowDialog();
                    //}
                    ShowOrderDetail(ordID);
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string reqNo = null;
            ReportViwer reportViewer = null;


            switch (purchaseOrderTabControl.SelectedIndex)
            {
                case 0:
                    reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();

                    if (string.IsNullOrEmpty(reqNo))
                    {
                        MessageBox.Show("Select a requisition from list.");
                    }
                    else
                    {
                        dt = purchaseManager.GetPruchaseOrderPrint("1", reqNo);
                        reportViewer = new ReportViwer(dt, new TenderRequisitionReport());
                        reportViewer.Show();
                    }
                    break;
                case 1:
                    reqNo = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[5].Text.Trim();

                    if (string.IsNullOrEmpty(reqNo))
                    {
                        MessageBox.Show("Select an order from list.");
                    }
                    else
                    {
                        new PurchaseOrderPrintUI(reqNo,"1").ShowDialog();
                        
                    }
                    ShowList();
                    break;
            }            
        }

        #region Search

        private void ShowSearchDate(string choice1, string choice2, string condition1, string condition2)
        {
            DataTable dt = null;
            orderDetailListView.Items.Clear();
            try
            {
                dt = purchaseManager.GetPurchaseOrderReport(choice1, choice2, condition1, condition2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fillControll.fillListView(completeListView, dt, "Order No.,Order Date,Delivery Date,Supplier,Total Item,,,,", "100,100,100,250,100,,,,");
                    ColorOrderOnState();
                }
                else
                {
                    completeListView.Items.Clear(); 
                    MessageBox.Show("No data found");                    
                }                
            }
            catch(Exception ex)
            {
                completeListView.Items.Clear(); 
                MessageBox.Show(ex.ToString());                
            }
        }

        private void ordInMonthTaskItem_Click(object sender, EventArgs e)
        {
            //show all orders in a selected month
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchDate("1", "1", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
            }
            
        }

        private void monthWiseOrdInYearTaskItem_Click(object sender, EventArgs e)
        {
            //show all orders in a selected year
            ShowSearchDate("1", "2", monthYearConvert.getMonthYear("3", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
            fillControll.BuildGroups(8, completeListView, false);
        }

        private void supplierWiseOrdInMonthTaskItem_Click(object sender, EventArgs e)
        {
            //show all supplier wise orders in a selected month
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchDate("1", "3", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
                fillControll.BuildGroups(8, completeListView, false);
            }
        }

        private void supplierMonthWiseOrdInYearTaskItem_Click(object sender, EventArgs e)
        {
            //show all orders of selected supplier monthwise in a selected year
            if(string.IsNullOrEmpty(supplierComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a supplier");
                supplierComboBox.Focus();
            }
            else 
            {
                ShowSearchDate("1", "4", monthYearConvert.getMonthYear("3", monthComboBox.Text.Trim(), yearPicker.Text.Trim()),supplierComboBox.SelectedValue.ToString());
                fillControll.BuildGroups(8, completeListView, false);
            }
        }

        private void orderDeliveryDateExpiredTaskItem_Click(object sender, EventArgs e)
        {
            ShowSearchDate("1", "5", null, null);
        }

        #endregion
        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        private void orderTermsTaskItem_Click(object sender, EventArgs e)
        {
            new PurchaseTermsConditionEntryUI("2").ShowDialog();
        }

        
        
    }
}
