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
using StoreManagement.Reports.Purchase.Order;
using CrystalDecisions;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class CashPurchaseOrderPrint : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private MasterSetupManager settingsManager = null;
            private Printer fillPrinter = null;
            string orderToPrint = null;
            private Order purchaseOrder = null;
            private bool IsNew = false;
            DataTable purchaseOrdDT;
            private Int16 orderItems = 0;
        #endregion

        public CashPurchaseOrderPrint()
        {
            InitializeComponent();
            SetObjects();
        }

        public CashPurchaseOrderPrint(string orderNo)
            : this()
        {
            orderToPrint = orderNo;
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            settingsManager = new MasterSetupManager();
            fillPrinter = new Printer();
        }

        private void CashPurchaseOrderPrint_Load(object sender, EventArgs e)
        {
            ShowPrintData();
            fillPrinter.FillLocalPrinters(printerComboBox);
        }

        private void ShowPrintData()
        {
            purchaseOrdDT = purchaseManager.GetPruchaseOrderPrint("1", orderToPrint);

            if (purchaseOrdDT.Rows.Count > 0)
            {
                int n;

                //Start : Vendor Reference
                supplierIDLabel.Text = purchaseOrdDT.Rows[0]["SupplierID"].ToString();
                SupplierNameLabel.Text = purchaseOrdDT.Rows[0]["SupplierName"].ToString();
                supplierAddressLabel.Text = purchaseOrdDT.Rows[0]["SupplierAdd"].ToString();
                //End : Vendor Reference

                //Start: Order Reference
                orderNoLabel.Text = purchaseOrdDT.Rows[0]["orderNo"].ToString();
                orderDateLabel.Text = purchaseOrdDT.Rows[0]["orderDate"].ToString();
                reqNoLabel.Text = purchaseOrdDT.Rows[0]["PReqNo"].ToString();
                reqDateLabel.Text = purchaseOrdDT.Rows[0]["ReqDate"].ToString();
                cepNoLabel.Text = purchaseOrdDT.Rows[0]["CepNo"].ToString();
                cepDateLabel.Text = purchaseOrdDT.Rows[0]["CepDate"].ToString();
                reqByTextBox.Text = purchaseOrdDT.Rows[0]["ReqRaisedBy"].ToString();
                endUserTextBox.Text = purchaseOrdDT.Rows[0]["EndUser"].ToString();
                //End: Order Reference

                //Start : Other Data
                purchaseRefTextBox.Text = purchaseOrdDT.Rows[0]["PurchaseRef"].ToString();
                advanceAmtTextBox.Text = purchaseOrdDT.Rows[0]["AdvanceAmt"].ToString();
                discountTextBox.Text = purchaseOrdDT.Rows[0]["Discount"].ToString();
                //End: Other Data

                if (purchaseOrdDT.Rows[0]["Status"].ToString().Trim() == "1")
                {
                    IsNew = true;
                }
                else
                {
                    IsNew = false;
                    termsDataGridView.AllowUserToAddRows = false;
                    SetTermsConditions(purchaseOrdDT.Rows[0]["TermsConditions"].ToString().Trim());
                }

                //Start: fill the ordItemsDataGridView 
                foreach (DataRow dr in purchaseOrdDT.Rows)
                {
                    n = ordItemsDataGridView.Rows.Add();
                    ordItemsDataGridView.Rows[n].Cells[0].Value = n + 1;
                    ordItemsDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                    ordItemsDataGridView.Rows[n].Cells[2].Value = dr["Unit"].ToString();
                    ordItemsDataGridView.Rows[n].Cells[3].Value = dr["Required"].ToString();
                    ordItemsDataGridView.Rows[n].Cells[4].Value = dr["Price"].ToString();
                    ordItemsDataGridView.Rows[n].Cells[5].Value = dr["OrderedQty"].ToString();
                    ordItemsDataGridView.Rows[n].Cells[6].Value = (Convert.ToDecimal(dr["OrderedQty"].ToString()) * Convert.ToDecimal(dr["Price"].ToString())).ToString("#.00");
                    ordItemsDataGridView.Rows[n].Cells[7].Value = dr["VAt"].ToString();
                    orderItems++;
                }
                //Start: fill the ordItemsDataGridView 
            }

            CalculateToatal();  //Calculate total payment, vat and net value
        }

        //Calculate total payment, vat and net value
        private void CalculateToatal()
        {
            decimal totalPay = 0, totalVat = 0;

            foreach (DataGridViewRow gridItem in ordItemsDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    totalPay += Convert.ToDecimal(gridItem.Cells[6].Value.ToString().Trim());
                    totalVat += (((Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim()) * Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim())) * Convert.ToDecimal(gridItem.Cells[7].Value.ToString().Trim())) / 100);
                }
            }

            totalAmtLabel.Text = totalPay.ToString("#.00");
            totalVATLabel.Text = totalVat.ToString("#.00");
            netValueLabel.Text = (totalPay + totalVat).ToString("#.00");
        }

        private void termsDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;

            }
        }

        private void termsDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            termsDataGridView.Rows[e.Row.Index - 1].Cells[0].Value = e.Row.Index;

            if (e.Row.Index.ToString().Trim() == "6")
            {
                termsDataGridView.AllowUserToAddRows = false;
            }
        }

        //Get the terms and condition when Print
        private string GetTermsConditionsToPrint()
        {
            string strTermsConditions = null;
            int n = 0;
            try
            {
                foreach (DataGridViewRow gridItem in termsDataGridView.Rows)
                {
                    if (gridItem.Cells[1].Value != null)
                    {
                        if (string.IsNullOrEmpty(strTermsConditions))
                        {
                            strTermsConditions = n.ToString() + ".   " + gridItem.Cells[1].Value.ToString().Trim();
                            n++;
                        }
                        else
                        {
                            strTermsConditions += "' +  ChrW(13)  + '" + n.ToString() + ".   " + gridItem.Cells[1].Value.ToString().Trim();
                            n++;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return strTermsConditions;
        }

        private void PrintReport()
        {
            //reqToPrint
            PurOrderPrintReport rpt = new PurOrderPrintReport();

            //Start:instentiate the report formula fields
            FormulaFieldDefinitions ffds = rpt.DataDefinition.FormulaFields;

            //get the formula definition
            FormulaFieldDefinition ffd1 = ffds["TermsConditionFormula"];
            FormulaFieldDefinition ffd2 = ffds["PrintCopyFormula"];
            

            //set the formula with value
            ffd1.Text = "'" + GetTermsConditionsToPrint() + "'";         //Terms and Conditions

            ffd2.Text = '"' + "Copy of Purchase" + '"';             //Department Print Copy            

            new ReportViwer(purchaseManager.GetPruchaseOrderPrint("1", orderToPrint), rpt).ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (IsNew)
                {
                    if (purchaseManager.PurOrderPrintManagement(purchaseOrder))
                    {
                        //MessageBox.Show("Saved Successfully.");
                        //this.Close();
                    }
                }
                this.Close();
                //ReportViwer reportViewer = new ReportViwer(purchaseManager.GetPruchaseOrderPrint("1", orderToPrint), new PurchaseOrderPrintReport());
                //reportViewer.Show();

                PrintReport();
            }

            purchaseOrder = null;
        }

        private bool IsValid()
        {
            try
            {
                if (IsNew && string.IsNullOrEmpty(reqByTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter requisition raised by.");
                    reqByTextBox.Focus();
                    return false;
                }
                else if (IsNew && string.IsNullOrEmpty(endUserTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter end user dept, company, location.");
                    endUserTextBox.Focus();
                    return false;
                }
                else if (IsNew && string.IsNullOrEmpty(purchaseRefTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter purchase reference.");
                    purchaseRefTextBox.Focus();
                    return false;
                }
                else if (IsNew && string.IsNullOrEmpty(advanceAmtTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter advance amount.");
                    advanceAmtTextBox.Focus();
                    return false;
                }
                else if (IsNew && termsDataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Enter terms and conditions.");
                    termsDataGridView.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(printerComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select printer.");
                    printerComboBox.Focus();
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
            if (purchaseOrder == null)
            {
                purchaseOrder = new Order();
            }
            purchaseOrder.PurOrdID = Convert.ToInt64(orderToPrint);
            purchaseOrder.ReqRaisedBy = reqByTextBox.Text.Trim();
            purchaseOrder.EndUser = endUserTextBox.Text.Trim();
            purchaseOrder.PurchaseRef = purchaseRefTextBox.Text.Trim();
            purchaseOrder.AdvanceAmt = Convert.ToDecimal(advanceAmtTextBox.Text.Trim());
            purchaseOrder.Discount = Convert.ToDecimal(discountTextBox.Text.Trim());
            purchaseOrder.TermsAndConditions = GetTermsConditions();
        }

        private string GetTermsConditions()
        {
            string termsConditions = null;
            try
            {
                foreach (DataGridViewRow gridItem in termsDataGridView.Rows)
                {
                    if (gridItem.Cells[1].Value != null)
                    {
                        if (string.IsNullOrEmpty(termsConditions))
                        {
                            termsConditions = gridItem.Cells[1].Value.ToString().Trim();
                        }
                        else
                        {
                            termsConditions += " | " + gridItem.Cells[1].Value.ToString().Trim();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return termsConditions;
        }

        private void SetTermsConditions(string termsConditons)
        {
            string[] termCondition = termsConditons.Split('|');
            int n;
            try
            {
                foreach (string terms in termCondition)
                {
                    n = termsDataGridView.Rows.Add();
                    termsDataGridView.Rows[n].Cells[0].Value = (n + 1).ToString();
                    termsDataGridView.Rows[n].Cells[1].Value = terms.Trim();
                }
            }
            catch
            {
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advanceAmtTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\x08\x2E\d]"))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
            }
        }

        private void discountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\x08\x2E\d]"))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
            }
        }        
    }
}
