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
using StoreManagement.UI;
using StoreManagement.Reports.Purchase.Tender;

namespace StoreManagement.UI
{
    public partial class MISTenderQuotationActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControl = null;
            private PurchaseManager tenderManager = null;
            private string requisitionNo = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public MISTenderQuotationActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            tenderManager = new PurchaseManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void MISTenderQuotationActionUI_Load(object sender, EventArgs e)
        {
            reportTaskPane.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            //fill the months
            fillControl.FillMonth(monthComboBox);

            RefreshAll();
        }

        private void RefreshAll()
        {
            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    reportTaskPane.Visible = false;
                    tenderAddButton.Visible = true;
                    editButton.Visible = false;
                    printButton.Visible = true;
                    requisitionDetailListView.Items.Clear();
                    tenderListView.Items.Clear();
                    tenderdetailListView.Items.Clear();
                    requisitionDetailsGroupBox.Text = "";
                    tenderDetailsGroupBox.Text = "";
                    fillControl.fillListView(pendingRequisitionListView, tenderManager.GetPurchaseTenderList("2", null), "Req No.,Req Date,Requisition For,Total Item", "100,100,150,100", true);
                    break;
                case 1:
                    reportTaskPane.Visible = true;
                    tenderAddButton.Visible = false;
                    editButton.Visible = false;
                    printButton.Visible = false;
                    completeListView.Items.Clear();
                    appTenderDetailListView.Items.Clear();
                    approvedTenderDetailGroupBox.Text = "Approved Tender Detail";
                    fillControl.fillListView(completeListView, tenderManager.GetPurchaseTenderList("22", null), "Req No.,Req Date,Requisition For,Total Item", "100,100,150,100", true);
                    break;
            }
        }         

        private void pendingRequisitionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshAll();
            //ClearDetails();
            string reqNO;
            try
            {
                if (pendingRequisitionListView.SelectedIndices.Count > 0)
                {
                    reqNO = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text;
                    requisitionDetailsGroupBox.Text = "Price Comparative of Requisition no. : " + reqNO;

                    //Fill the tender of selected requisition
                    //fillControl.fillListView(tenderListView, tenderManager.GetPurchaseTenderList("4", reqNO), "Tender No.,Tender Date,Supplier", "100,100,250", true);
                    ShowRequisitionDetail(reqNO);
                }
            }
            catch { }
        }

        private void ShowRequisitionDetail(string reqNo)
        {
            //Start: Clear details
            editButton.Visible = false;
            requisitionDetailListView.Items.Clear();
            tenderListView.Items.Clear();
            tenderdetailListView.Items.Clear();
            requisitionDetailsGroupBox.Text = "";
            tenderDetailsGroupBox.Text = "";
            //End: Clear details

            //fill the Tender comparative
            fillControl.fillListView(requisitionDetailListView, tenderManager.GetPurchaseTenderList("8", reqNo), "Supplier,Unit Price,,,,,", "300,100,,,,,", false);
            fillControl.BuildGroups(6, requisitionDetailListView, false);
            ColorLowestPriceSupplier();

            //Fill the tender of selected requisition
            fillControl.fillListView(tenderListView, tenderManager.GetPurchaseTenderList("4", reqNo), "Tender No.,Tender Date,Supplier", "100,100,250", true);
        }

        private void ColorLowestPriceSupplier()
        {
            if (requisitionDetailListView.Items.Count > 0)
            {
                foreach (ListViewItem item in requisitionDetailListView.Items)
                {
                    switch (item.SubItems[5].Text.Trim())
                    {
                        case "1":
                            item.BackColor = Color.FromArgb(87, 130, 176);
                            item.ForeColor = Color.White;
                            item.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                            break;
                    }
                }
            }
        }

        //private void ShowRequisitionComparative(string reqNO)
        //{
        //    //fill the Tender comparative
        //    fillControl.fillListView(requisitionDetailListView, tenderManager.GetPurchaseTenderList("8", reqNO), "Supplier,Unit Price,,,,,", "300,100,,,,,", false);
        //    fillControl.BuildGroups(6, requisitionDetailListView, false);
        //    ColorLowestPriceSupplier();
        //}

        private void ClearDetails()
        {
            //Start: Clear details
            editButton.Visible = false;
            requisitionDetailListView.Items.Clear();
            tenderListView.Items.Clear();
            tenderdetailListView.Items.Clear();
            requisitionDetailsGroupBox.Text = "";
            tenderDetailsGroupBox.Text = "";
            //End: Clear details
        }

               

        private void tenderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tenderListView.SelectedIndices.Count > 0)
            {
                editButton.Visible = true;
                tenderDetailsGroupBox.Text = "Detail of Tender no. : " + tenderListView.Items[tenderListView.SelectedIndices[0]].Text.Trim();
                fillControl.fillListView(tenderdetailListView, tenderManager.GetPurchaseTenderList("7", tenderListView.Items[tenderListView.SelectedIndices[0]].Text.Trim()), "Item,Unit,Required,Rate,Remarks", "250,60,60,60,150", true);
            }
        }

        private void tenderAddButton_Click(object sender, EventArgs e)
        {
            if (pendingRequisitionListView.SelectedIndices.Count > 0)
            {
                requisitionNo = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text.Trim();
                new SupplierTenderEntryUI(requisitionNo).ShowDialog();
                ShowRequisitionDetail(requisitionNo);
            }
            else 
            {
                MessageBox.Show("Select a requisition from list.");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (tenderListView.SelectedIndices.Count > 0)
            {
                requisitionNo = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text.Trim();
                string tenderNo = tenderListView.Items[tenderListView.SelectedIndices[0]].Text.Trim();

                new SupplierTenderEntryUI(requisitionNo, tenderNo).ShowDialog();

                ShowRequisitionDetail(requisitionNo);
                fillControl.fillListView(tenderdetailListView, tenderManager.GetPurchaseTenderList("7", tenderNo), "Item,Unit,Required,Rate,Remarks", "250,60,60,60,150", true);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }       

        private void printButton_Click(object sender, EventArgs e)
        {
            ReportViwer reportViewer = null;
            string reqNO = null;

            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    reqNO = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text;
                    break;
                case 1:
                    reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                    break;
            }

            if (!string.IsNullOrEmpty(reqNO))
            {
                reportViewer = new ReportViwer(tenderManager.GetPurchaseRequisitionReport("1", reqNO,null), new TenderRequisitionReport());
                reportViewer.Show();
            }
            else
            {
                MessageBox.Show("Select a requisition.");
            }

            
        }

        private void purchaseTenderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                approvedTenderDetailGroupBox.Text = "Tender approval detail of requisition no. : " + reqNO;

                //fill the Tender comparative
                fillControl.fillListView(appTenderDetailListView, tenderManager.GetPurchaseTenderList("10", reqNO), "Code,Item,Required,Rate,", "100,300,100,100,", false);
                fillControl.BuildGroups(4, appTenderDetailListView, false);                
            }
        }

        #region Search

        private void ShowSearchResult(string choice,string condition1,string condition2)
        {
            DataTable dt = null;
            appTenderDetailListView.Items.Clear();
            try
            {
                dt = tenderManager.GetTenderReport(choice, condition1, condition2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fillControl.fillListView(completeListView, dt, "Req No.,Req Date,Requisition For,Total Item", "100,100,150,100", true);
                }
                else
                {
                    completeListView.Items.Clear();
                    MessageBox.Show("No data found");
                }

            }
            catch (Exception ex)
            {
                completeListView.Items.Clear();
                MessageBox.Show(ex.ToString());
            }
        }

        private void tendersInMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchResult("2", monthYearConvert.getMonthYear("2", monthComboBox.Text, yearPicker.Text), null);
            }
        }

        private void tenderPrintTaskItem_Click(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                new ReportViwer(tenderManager.GetTenderReport("3", reqNO,null), new ApprovedTenderDetailReport()).Show();
            }
            else
            {
                MessageBox.Show("Select a requisiton.");
            }
        }

        #endregion

        private void comparativePrintButton_Click(object sender, EventArgs e)
        {
            ReportViwer reportViewer = null;
            string reqNO = null;

            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    reqNO = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text;
                    break;
                case 1:
                    reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                    break;
            }

            if (!string.IsNullOrEmpty(reqNO))
            {
                reportViewer = new ReportViwer(tenderManager.GetTenderReport("4", reqNO, null), new TenderComparetiveReport());
                reportViewer.Show();
            }
            else
            {
                MessageBox.Show("Select a requisition.");
            }
        }
    }
}
