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
using CrystalDecisions.CrystalReports.Engine;

namespace StoreManagement.UI
{
    public partial class PurchaseReqTenderSchedulePrintUI : Form
    {
        #region Variables
            private DynamicControlFill fillControl = null;
            private PurchaseManager purchaseManager = null;
            DataTable purchaseReqDT = null;
            private bool IsNew = false;
            private string reqToPrint = null;
            private Requisition requisition = null;
            private string strTermsConditions = null;
        #endregion

        public PurchaseReqTenderSchedulePrintUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseReqTenderSchedulePrintUI(string reqNo):this()
        {
            reqToPrint = reqNo;
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
        }

        private void PurchaseReqTenderSchedulePrintUI_Load(object sender, EventArgs e)
        {
            ShowPrintData();
        }

        private void ShowPrintData()
        {
            purchaseReqDT = purchaseManager.GetPurchaseRequistionProcessReport("4", reqToPrint,null);

            if (purchaseReqDT.Rows.Count > 0)
            {
                              

                if (string.IsNullOrEmpty(purchaseReqDT.Rows[0]["TermsConditions"].ToString().Trim()))
                {
                    IsNew = true;
                    refTextBox.Text = reqToPrint.Trim();  
                    ShowTermsConditions();
                }
                else
                {
                    IsNew = false;
                    termsDataGridView.AllowUserToAddRows = false;
                    refTextBox.Text = purchaseReqDT.Rows[0]["TenderRef"].ToString();  
                    SetTermsConditions(purchaseReqDT.Rows[0]["TermsConditions"].ToString().Trim());
                }

                int n;
                foreach (DataRow dr in purchaseReqDT.Rows)
                {
                    //fill the MRR GridView
                    n = reqItemsDataGridView.Rows.Add();
                    reqItemsDataGridView.Rows[n].Cells[0].Value = n + 1;
                    reqItemsDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                    reqItemsDataGridView.Rows[n].Cells[2].Value = dr["Unit"].ToString();
                    reqItemsDataGridView.Rows[n].Cells[3].Value = dr["OrderedQty"].ToString();
                }
            }            
        }

        private void ShowTermsConditions()
        {
            DataTable dt = null;

            dt = purchaseManager.GetTermsConditionsList("1", null);
            if (dt != null && dt.Rows.Count > 0)
            {
                int n;
                foreach (DataRow dr in dt.Rows)
                {
                    //fill the Department GridView
                    n = termsDataGridView.Rows.Add();
                    termsDataGridView.Rows[n].Cells[0].Value = (n + 1).ToString();
                    termsDataGridView.Rows[n].Cells[1].Value = dr["Terms"].ToString();

                    //if (n == 1)
                    //{
                    //    strTermsConditions = dr["Terms"].ToString().Trim();
                    //}
                    //else
                    //{
                    //    strTermsConditions = "' & Chr(10) & Chr(13) & '" + dr["Terms"].ToString().Trim();
                    //}
                }
            }
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
                    //"' & Chr(10) & Chr(13) & '"
                    if (string.IsNullOrEmpty(strTermsConditions))
                    {
                        strTermsConditions = (n + 1).ToString() + ".   " + terms.Trim();
                    }
                    else
                    {
                        //strTermsConditions += "' & Chr(10) & Chr(13) & '" + (n + 1).ToString() + "  " + terms.Trim();
                        strTermsConditions += "' + ChrW(13) + '" + (n + 1).ToString() + ".   " + terms.Trim();
                        //strTermsConditions += Environment.NewLine + (n + 1).ToString() + "  " + terms.Trim();
                    }
                }
            }
            catch
            {

            }

        }

        private void PrintReport()
        {
            //reqToPrint
            TenderScheduleReport rpt = new TenderScheduleReport();

            //Start:instentiate the report formula fields
            FormulaFieldDefinitions ffds = rpt.DataDefinition.FormulaFields;

            //get the formula definition
            FormulaFieldDefinition ffd1 = ffds["HeadingFormula"];
            FormulaFieldDefinition ffd2 = ffds["refFormula"];
            FormulaFieldDefinition ffd3 = ffds["HeadingDateFormula"];
            FormulaFieldDefinition ffd4 = ffds["termsFormula"];

            //set the formula with value
            //ffd1.Text = '"' + headingTextBox.Text.Trim() + '"';         //heading
            ffd2.Text = '"' + refTextBox.Text.Trim() + '"';             //schedule reference
            ffd3.Text = '"' + scheduleDatePicker.Text.Trim() + '"';     //schedule date
            ffd4.Text = "'" + strTermsConditions.Trim() + "'";          // terms and conditions

            new ReportViwer(purchaseManager.GetPurchaseRequistionProcessReport("3", reqToPrint, null), rpt).Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if(IsNew)
                {
                    if (purchaseManager.TenderSchedulePrintManagement(requisition))
                    {

                    }
                }

                PrintReport();
                this.Close();
            }
        }

        private bool IsValid()
        {
            if(string.IsNullOrEmpty(refTextBox.Text.Trim()))
            {
                MessageBox.Show("Enter reference");
                refTextBox.Focus();
                return false;
            }
            else if(termsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Enter terms conditions");
                return false;
            }
            else
            {
                SetValues();
            }
            return true;
        }

        private void SetValues()
        {
            if (requisition == null)
            {
                requisition = new Requisition();
            }

            requisition.PrrId = Convert.ToInt64(reqToPrint.Trim());
            requisition.TenderReferecne = refTextBox.Text.Trim();
            requisition.TermsConditions = GetTermsConditions();
        }

        private string GetTermsConditions()
        {
            string termsConditions = null;
            int n = 1;
            try
            {
                foreach (DataGridViewRow gridItem in termsDataGridView.Rows)
                {
                    if (gridItem.Cells[1].Value != null)
                    {
                        if (string.IsNullOrEmpty(termsConditions))
                        {
                            termsConditions = gridItem.Cells[1].Value.ToString().Trim();
                            strTermsConditions =  n.ToString() + ".   " + gridItem.Cells[1].Value.ToString().Trim();
                            n++;
                        }
                        else
                        {
                            termsConditions += " | " + gridItem.Cells[1].Value.ToString().Trim();
                            //strTermsConditions += "' & ChrW(10) & Chr(13) & '" + n.ToString() + "  " + gridItem.Cells[1].Value.ToString().Trim() + "'";
                            strTermsConditions += "' +  ChrW(13)  + '" + n.ToString() + ".   " + gridItem.Cells[1].Value.ToString().Trim() ;
                            //strTermsConditions += Environment.NewLine + n.ToString() + "  " + gridItem.Cells[1].Value.ToString().Trim() + "'";
                            n++;
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
    }
}
