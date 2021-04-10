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
    public partial class AccountsOrderPaymentConfirmActionUI : Form
    {
        #region Veriables
            private PurchaseManager purchaseManager = null;
            private DynamicControlFill fillControll = null;
            private FSDCertificate certificate = null;
            private FSDManager paymentManager = null;
            private MonthYearConvertion monthYearConvert = null;
            private string UserState = null;
        #endregion

        public AccountsOrderPaymentConfirmActionUI()
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

        private void AccountsOrderPaymentConfirmActionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            fillControll.FillMonth(monthComboBox);
            ShowData();
        }

        private void ShowData()
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    confirmedButton.Visible = true;
                    taskPane1.Visible = false;
                    fillControll.fillListView(pendingListView, purchaseManager.GetAccountsPurchaseOrderPaymentList("1", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "3,4");
                    break;
                case 1:
                    confirmedButton.Visible = false;
                    taskPane1.Visible = true;
                    fillControll.fillListView(completeListView, purchaseManager.GetAccountsPurchaseOrderPaymentList("2", null, null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "3,4");
                    break;
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
                certificate.Condition = "5";

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

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string cerNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                ShowOrderDetails(cerNo);
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

        private void ShowOrderDetails(string cerNo)
        {
            switch (purReqTabControl.SelectedIndex)
            {
                case 0:
                    pendingGroupBox.Text = "Detail of certificate no. : " + cerNo;
                    fillControll.fillListView(pDetailListView, purchaseManager.GetAccountsPurchaseOrderPaymentList("3", cerNo, null), "Code, Item, Unit, Order Qty, Qty Before Insp.,Qty After Insp.", "100,250,100,120,150,150");
                    break;
                case 1:
                    completeGroupBox.Text = "Detail of certificate no. : " + cerNo;
                    fillControll.fillListView(cDetailListView, purchaseManager.GetAccountsPurchaseOrderPaymentList("3", cerNo, null), "Code, Item, Unit, Order Qty, Qty Before Insp.,Qty After Insp.", "100,250,100,120,150,150");
                    break;
            }
        }        

        private void purReqTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void orderMonthWiseTaskItem_Click(object sender, EventArgs e)
        {
            fillControll.fillListView(completeListView, purchaseManager.GetAccountsPurchaseOrderPaymentList("4", monthYearConvert.getMonthYear("2",monthComboBox.Text.Trim(),yearPicker.Text.Trim()), null), "Certificate No.,Inspection Date,Approved Date,Order No.,Order Type,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,140,100,100,200,200,250,100,100,100,", "3,4");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
