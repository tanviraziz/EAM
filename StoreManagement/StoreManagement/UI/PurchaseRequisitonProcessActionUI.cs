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
    public partial class PurchaseRequisitonProcessActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControl = null;
            private PurchaseManager purchaseManager = null;
            private MonthYearConvertion monthYearConvert = null;
            private bool IsPurchaseOrMIS = true; //true for purchase and false for MIS
        #endregion

        public PurchaseRequisitonProcessActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseRequisitonProcessActionUI(bool purchaseOrMIS):this()
        {
            IsPurchaseOrMIS = purchaseOrMIS;
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void PurchaseRequisitonProcessActionUI_Load(object sender, EventArgs e)
        {
            reportTaskPane.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowData();
            fillControl.FillMonth(monthComboBox);
        }

        private void ShowData()
        {
            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    confirmRequisitionButton.Visible = true;
                    printButton.Visible = true;
                    reportTaskPane.Visible = false;
                    requisitionDetailListView.Items.Clear();

                    if (IsPurchaseOrMIS)
                    {
                        fillControl.fillListView(pendingListView, purchaseManager.GetPurchaseRequistionProcessList("1", null), "Requisition No.,Date,Req. Month,Category,Total Item,,", "100,100,140,120,100,,");
                    }
                    else
                    {
                        fillControl.fillListView(pendingListView, purchaseManager.GetPurchaseRequistionProcessList("11", null), "Requisition No.,Date,Req. Month,Category,Total Item,,", "100,100,140,120,100,,");
                    }

                    ColorEmergencyRequisition("1");
                    break;
                case 1:
                    confirmRequisitionButton.Visible = false;
                    printButton.Visible = false;
                    reportTaskPane.Visible = false;
                    cepDetailListView.Items.Clear();

                    if (IsPurchaseOrMIS)
                    {
                        //fillControl.fillListView(completeListView, purchaseManager.GetPurchaseRequistionProcessList("2", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,120,100,100,250,");
                    }
                    else
                    {
                        fillControl.fillListView(cepListView, purchaseManager.GetPurchaseRequistionProcessList("220", null), "Requisition No.,Date,Req. Month,CEP No.,CEP Date,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,100,100,120,100,100,300,");
                    }

                    ColorEmergencyRequisition("2");
                    break;
                case 2:
                    confirmRequisitionButton.Visible = false;
                    printButton.Visible = true;
                    reportTaskPane.Visible = true;
                    appRequisitionDetailListView.Items.Clear();

                    if (IsPurchaseOrMIS)
                    {
                        fillControl.fillListView(completeListView, purchaseManager.GetPurchaseRequistionProcessList("2", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,120,100,100,250,");
                    }
                    else
                    {
                        fillControl.fillListView(completeListView, purchaseManager.GetPurchaseRequistionProcessList("22", null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,120,100,100,250,");
                    }

                    ColorEmergencyRequisition("3");
                    break;
            }
        }

        private void ColorEmergencyRequisition(string choice)
        {
            switch(choice.Trim())
            {
                case "1":
                    foreach (ListViewItem lstItem in pendingListView.Items)
                    {
                        if (lstItem.SubItems[6].Text.Trim().ToUpper() == "Y")
                        {
                            lstItem.UseItemStyleForSubItems = true;
                            lstItem.BackColor = Color.FromArgb(255, 0, 170);
                    
                            lstItem.ForeColor = Color.White;
                            lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                        }
                    }
                   break;
                case "2":
                   foreach (ListViewItem lstItem in cepListView.Items)
                   {
                       if (lstItem.SubItems[9].Text.Trim().ToUpper() == "Y")
                       {
                           lstItem.UseItemStyleForSubItems = true;
                           lstItem.BackColor = Color.FromArgb(255, 0, 170);

                           lstItem.ForeColor = Color.White;
                           lstItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                       }
                   }
                   break;
                case "3":
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
                    break;
            }
        }

        private void pendingListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string requisitionNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                new PurRequisitionConfirmEntryUI(requisitionNo).ShowDialog();
                ShowData();
            }
        }

        private void confirmRequisitionButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string requisitionNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                new PurRequisitionConfirmEntryUI(requisitionNo).ShowDialog();
                ShowData();
            }
        }

        private void purchaseTenderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim());                
            }
        }

        private void cepListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cepListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(cepListView.Items[cepListView.SelectedIndices[0]].Text.Trim());                
            }
        }

        private void ShowRequisitonDetail(string reqNo)
        {
            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    pendingGroupBox.Text = "Requistion No. : " + reqNo + " detail";
                    fillControl.fillListView(requisitionDetailListView, purchaseManager.GetPurchaseRequistionProcessList("3", reqNo), "Item,Unit,Stock,Req Qty,Ordered Qty,Remarks", "250,60,100,100,100,400");
                    break;
                case 1:
                    cepGroupBox.Text = "Requistion No. : " + reqNo + " detail";
                    fillControl.fillListView(cepDetailListView, purchaseManager.GetPurchaseRequistionProcessList("3", reqNo), "Item,Unit,Stock,Req Qty,Ordered Qty,Remarks", "250,60,100,100,100,400");
                    break;
                case 2:
                    completeGroupBox.Text = "Requistion No. : " + reqNo + " detail";
                    fillControl.fillListView(appRequisitionDetailListView, purchaseManager.GetPurchaseRequistionProcessList("3", reqNo), "Item,Unit,Stock,Req Qty,Ordered Qty,Remarks", "250,60,100,100,100,400");
                    break;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim());                
            }
        }

        private void PrintRequisition()
        {
            ReportViwer reportViewer = null;
            string reqNO = null;

            switch (purchaseTenderTabControl.SelectedIndex)
            {
                case 0:
                    if (pendingListView.SelectedIndices.Count > 0)
                    {
                        reqNO = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                    }
                    break;
                case 1:
                    
                    break;
                case 2:
                    if (completeListView.SelectedIndices.Count > 0)
                    {
                        reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text;
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(reqNO))
            {
                reportViewer = new ReportViwer(purchaseManager.GetPurchaseRequistionProcessReport("1", reqNO, null), new TenderRequisitionReport());
                reportViewer.Show();
            }
            else
            {
                MessageBox.Show("Select a requisition.");
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintRequisition();
        }

         private void reqInMonthTaskItem_Click(object sender, EventArgs e)
         {
             if (IsPurchaseOrMIS)
             {
                 fillControl.fillListView(completeListView, purchaseManager.GetPurchaseRequistionProcessReport("2", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,120,100,100,250,");
             }
             else
             {
                 fillControl.fillListView(completeListView, purchaseManager.GetPurchaseRequistionProcessReport("22", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null), "Requisition No.,Date,Req. Month,Category,Total Item,Ordered Qty,Requisition Status,", "100,100,100,120,100,100,250,");
             }
         }

         private void requisitonPrintTaskItem_Click(object sender, EventArgs e)
         {
             PrintRequisition();
         }

         private void termsConditionTaskItem_Click(object sender, EventArgs e)
         {
             new PurchaseTermsConditionEntryUI("1").ShowDialog();
         }

         private void tenderSchedulePtintTaskItem_Click(object sender, EventArgs e)
         {
             if (completeListView.SelectedIndices.Count > 0)
             {
                 new PurchaseReqTenderSchedulePrintUI(completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim()).ShowDialog();
             }
             else
             {
                 MessageBox.Show("Select a requisition from list");
             }
         }

         
         

         

         

        

        
    }
}
