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
    public partial class PurchaseOrderPayamentConfirmActionUI : Form
    {
        #region Veriables
            private PurchaseManager purchaseManager = null;
            private DynamicControlFill fillControll = null;
            private FSDCertificate certificate = null;
            private FSDManager paymentManager = null;
            private MonthYearConvertion monthYearConvert = null;
            private string UserState = null;
        #endregion

        public PurchaseOrderPayamentConfirmActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            fillControll = new DynamicControlFill();
            paymentManager = new FSDManager();
            monthYearConvert = new MonthYearConvertion();
        }

        public PurchaseOrderPayamentConfirmActionUI(string state):this()
        {
            UserState = state.Trim();
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string cerNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                ShowOrderDetails(cerNo);                
            }
        }

        private void PurchaseOrderPayamentConfirmActionUI_Load(object sender, EventArgs e)
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
                    taskPane1.Visible = false;
                    switch (UserState.Trim())
                    {
                        //Pending Orders
                        case "1":
                            //Purchase Orders "Stationary and Printings - Normal,Post Facto
                            fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseOrderPaymentList("1", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,","4");
                            break;
                        case "2":
                            //MIS Orders "Computer Items - Normal,Post Facto
                            fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseOrderPaymentList("2", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                            break;
                        case "3":
                            //Store Orders "Cash Purchase"
                            fillControll.fillListView(pendingListView, purchaseManager.GetPurchaseOrderPaymentList("3", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                            break;
                    }                    
                    break;
                case 1:
                    //Confirmed Orders
                    taskPane1.Visible = true;
                    switch (UserState.Trim())
                    {
                        case "1":
                            //Purchase Orders "Stationary and Printings - Normal,Post Facto
                            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseOrderPaymentList("4", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                            break;
                        case "2":
                            //MIS Orders "Computer Items - Normal,Post Facto
                            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseOrderPaymentList("5", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                            break;
                        case "3":
                            //Store Orders "Cash Purchase"
                            fillControll.fillListView(completeListView, purchaseManager.GetPurchaseOrderPaymentList("6", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                            break;
                    }
                    break;
            }
        }

        private void ShowOrderDetails(string cerNo)
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:                    
                    pendingGroupBox.Text = "Detail of certificate no. : " + cerNo;
                    fillControll.fillListView(pDetailListView, purchaseManager.GetPurchaseOrderPaymentList("7", cerNo, null), "Code, Item, Unit, Order Qty, Qty Before Insp,Qty After Insp.", "100,250,100,120,150,150");
                    break;
                case 1:
                    completeGroupBox.Text = "Detail of certificate no. : " + cerNo;
                    fillControll.fillListView(cDetailListView, purchaseManager.GetPurchaseOrderPaymentList("7", cerNo, null), "Code, Item, Unit, Order Qty, Qty Before Insp,Qty After Insp.", "100,250,100,120,150,150");
                    break;
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string cerNo = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                ShowOrderDetails(cerNo);
            }
        }

        private void confirmedButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                if (certificate == null)
                {
                    certificate = new FSDCertificate();
                }
                certificate.CertificateID = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                certificate.Condition = "4";

                if (paymentManager.CertificateApproved(certificate))
                {
                    ShowData();
                }
            }
            else
            {
                MessageBox.Show("Select a certificate from list");
            }
        }

        private void purReqTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void orderMonthWiseTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            { 
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                string strMonth = monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim());
                DataTable searchDT = null;

                switch (UserState.Trim())
                {
                    case "1":
                        //Purchase Orders "Stationary and Printings - Normal,Post Facto
                        searchDT = purchaseManager.GetPurchaseOrderPaymentReport("1", strMonth, null);                        
                        break;
                    case "2":
                        //MIS Orders "Computer Items - Normal,Post Facto
                        searchDT = purchaseManager.GetPurchaseOrderPaymentReport("1", strMonth, null);
                        break;
                    case "3":
                        //Store Orders "Cash Purchase"
                        searchDT = purchaseManager.GetPurchaseOrderPaymentReport("1", strMonth, null);
                        break;
                }

                if (searchDT != null && searchDT.Rows.Count > 0)
                {
                    fillControll.fillListView(completeListView, searchDT, "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "4");
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
        }   
    }
}
