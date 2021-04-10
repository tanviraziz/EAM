using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.UTILITY;
using StoreManagement.Reports.Purchase.Order;
using CrystalDecisions;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;


namespace StoreManagement.UI
{
    public partial class CashPurchaseOrderActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private MasterSetupManager settingsManager = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public CashPurchaseOrderActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            settingsManager = new MasterSetupManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void emargPurOrderButton_Click(object sender, EventArgs e)
        {
            //new PurchaseOrderEmrgEntryUI().ShowDialog();
            if (emargOrderListView.SelectedIndices.Count > 0)
            {
                string reqNo, reqStatus;
                reqNo = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].Text.Trim();
                reqStatus = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].SubItems[9].Text.Trim();
                if (reqStatus.Trim() == "30")
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

        private void PurchaseOrderEmergActionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the months
            fillControll.FillMonth(monthComboBox);

            //fill the stationery category
            fillControll.fillCombo(categoryComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            categoryComboBox.SelectedIndex = -1;

            ShowList();
        }

        private void ShowList()
        {
            switch (purchaseOrderTabControl.SelectedIndex)
            {
                case 0:
                    taskPane1.Visible = false;
                    confirmRequisitionButton.Visible = true;
                    purOrderButton.Visible = true;
                    editButton.Visible = false;
                    refreshButton.Visible = true;
                    printButton.Visible = false;
                    purOrderButton.Visible = false;
                    //fillControll.fillListView(emargOrderListView, purchaseManager.GetCashPruchaseOrderList("1", null), "Order No, Order Date,Delivery Date,Cep No.,Cep Date,Supplier,", "100,100,100,100,100,200,");
                    fillControll.fillListView(emargOrderListView, purchaseManager.GetCashPruchaseOrderList("1", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Status,Process Type,,", "100,100,140,120,100,100,250,250,,","7");
                    ColorEmergencyRequisition();
                    orderDetailListView.Items.Clear();
                    taskPane1.Visible = false;
                    break;
                case 1:
                    taskPane1.Visible = true;
                    confirmRequisitionButton.Visible = false;
                    purOrderButton.Visible = false;
                    editButton.Visible = false;
                    refreshButton.Visible = true;
                    printButton.Visible = true;
                    fillControll.fillListView(completeListView, purchaseManager.GetCashPruchaseOrderList("2", null), "Order No, Order Date,Delivery Date,Cep No.,Cep Date,Category,Supplier,,", "100,100,100,100,100,120,200,,");
                    ColorOrderOnState();
                    cOrderDetailListView.Items.Clear();
                    taskPane1.Visible = true;
                    break;
            }
            
        }

        //color the new order
        private void ColorOrderOnState()
        {
            try
            {
                foreach (ListViewItem lstItem in completeListView.Items)
                {
                    if (lstItem.SubItems[8].Text.Trim().ToUpper() == "1")
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

        private void ColorEmergencyRequisition()
        {
            foreach (ListViewItem lstItem in emargOrderListView.Items)
            {
                if (lstItem.SubItems[8].Text.Trim().ToUpper() == "Y")
                {
                    lstItem.UseItemStyleForSubItems = true;
                    if (lstItem.SubItems[9].Text.Trim().ToUpper() == "30")
                    {
                        lstItem.BackColor = Color.FromArgb(127, 0, 255);   
                    }
                    else
                    {
                        lstItem.BackColor = Color.FromArgb(255, 0, 170);                        
                    }
                    lstItem.ForeColor = Color.White;
                    lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
            }
        }

        //private void emargOrderListView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (emargOrderListView.SelectedIndices.Count > 0)
        //    {
        //        string orderNO = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].SubItems[7].Text.Trim();
        //        ShowOrderDetail(orderNO);
        //        //orderDetailGroupBox.Text = "Order No. : " + orderNO + " detail";
        //        //fillControll.fillListView(orderDetailListView, purchaseManager.GetEmargencyPurchaseOrderList("3", orderNO), "Item,Unit,Required Qty, Ordered Qty", "250,120,120,120");
        //        editButton.Visible = true;
        //    }
        //}

        //Show the selected order detail
        private void ShowOrderDetail(string orderNO)
        {
            orderDetailGroupBox.Text = "Order No. : " + orderNO + " detail";
            fillControll.fillListView(orderDetailListView, purchaseManager.GetCashPruchaseOrderList("4", orderNO), "Item,Unit,Required Qty, Ordered Qty", "250,120,120,120");
            
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string orderNO = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[7].Text.Trim();
                orderDetailGroupBox.Text = "Order No. : " + orderNO + " detail";
                fillControll.fillListView(cOrderDetailListView, purchaseManager.GetCashPruchaseOrderList("4", orderNO), "Item,Unit,Required Qty, Ordered Qty", "250,120,120,120");                
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (emargOrderListView.SelectedIndices.Count > 0)
            {
                string emarOrder = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].SubItems[7].Text.Trim();

                new PurchaseOrderEmrgEntryUI(emarOrder).ShowDialog();
                
                ShowOrderDetail(emarOrder);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowList();            
        }

        private void purchaseOrderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ShowList();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string reqNo = null;
            ReportViwer reportViewer = null;
                
                        
            switch (purchaseOrderTabControl.SelectedIndex)
            {
                case 0:
                    reqNo = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].SubItems[7].Text.Trim();
                    break;
                case 1:
                    reqNo = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[7].Text.Trim();
                    break;
            }

            if (string.IsNullOrEmpty(reqNo))
            {
                MessageBox.Show("Select a order from list.");
            }
            else
            {
                new CashPurchaseOrderPrint(reqNo).ShowDialog();                
            }
        }

        private void ShowSearchResult(string choice, string condition1, string condition2)
        {
            fillControll.fillListView(completeListView, purchaseManager.GetEmargencyPurchaseOrderReport(choice, condition1,condition2), "Order No, Order Date,Delivery Date,Cep No.,Cep Date,Supplier,", "100,100,100,100,100,200,");
            ColorOrderOnState();
        }

        private void emargOrderInMonthTaskItem_Click(object sender, EventArgs e)
        {
            ShowSearchResult("1", monthYearConvert.getMonthYear("2", monthComboBox.Text, yearPicker.Text), null);
        }

        private void categoryWiseInMonthTaskItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(categoryComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a ctegory");
                categoryComboBox.Focus();
            }
            else
            {
                ShowSearchResult("2", categoryComboBox.SelectedValue.ToString(), monthYearConvert.getMonthYear("2", monthComboBox.Text, yearPicker.Text));
            }
        }

        private void emargOrderInYearTaskItem_Click(object sender, EventArgs e)
        {
            ShowSearchResult("3",monthYearConvert.getMonthYear("3", monthComboBox.Text, yearPicker.Text), null);
        }

        private void emargOrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (emargOrderListView.SelectedIndices.Count > 0)
            {
                string reqNO = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].Text.Trim();
                orderDetailGroupBox.Text = "Req No. : " + reqNO + " detail";
                fillControll.fillListView(orderDetailListView, purchaseManager.GetCashPruchaseOrderList("3", reqNO), "Item, Unit,Current Stock,Required Qty,Confirmed Qty,Remarks", "250,100,140,140,140,200");


                //Check the requisition status for cash purchase order
                //if status = 30 then enable the cash purchase order button
                if (emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].SubItems[9].Text.ToString().Trim() == "30")
                {
                    purOrderButton.Visible = true;
                }
                else
                {
                    purOrderButton.Visible = false;
                }
            }            
        }

        private void confirmRequisitionButton_Click(object sender, EventArgs e)
        {
            if (emargOrderListView.SelectedIndices.Count > 0)
            {
                string requisitionNo = emargOrderListView.Items[emargOrderListView.SelectedIndices[0]].Text.Trim();
                new PurRequisitionConfirmEntryUI(requisitionNo).ShowDialog();
                ShowList();
            }
        }

        //#region Get Month/Year
        //private string getMonthYear(string choice, string month, string year)
        //{
        //    string strMonth = null, strYear = null, yearMonth = null;

        //    try
        //    {
        //        //get the month
        //        if (string.IsNullOrEmpty(month))
        //        {
        //            strMonth = monthToNumber(DateTime.Now.ToString("MMMM").Trim());
        //        }
        //        else
        //        {
        //            strMonth = monthToNumber(month);
        //        }

        //        //get the year
        //        if (string.IsNullOrEmpty(year))
        //        {
        //            strYear = DateTime.Now.ToString("yy");
        //        }
        //        else if (year.Length < 4)
        //        {
        //            strYear = DateTime.Now.ToString("yy");
        //        }
        //        else
        //        {
        //            strYear = year.Trim().Substring(2);
        //        }

        //        switch (choice.Trim())
        //        {
        //            case "1":
        //                //format yymm(1308)
        //                yearMonth = strYear + strMonth;
        //                break;
        //            case "2":
        //                //format yyyymm (201308)
        //                yearMonth = year + strMonth;
        //                break;
        //            case "3":
        //                //format yyyy (2013)
        //                yearMonth = year;
        //                break;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return yearMonth;
        //}

        //private string monthToNumber(string str_Month)
        //{
        //    string monthNo = DateTime.ParseExact(str_Month, "MMMM", CultureInfo.CurrentCulture).Month.ToString();
        //    try
        //    {
        //        if (monthNo.Length == 1)
        //        {
        //            return "0" + monthNo;
        //        }
        //        else if (monthNo.Length > 1)
        //        {
        //            return monthNo;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return null;
        //}
        //#endregion

        
       
    }
}
