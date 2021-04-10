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
using StoreManagement.Properties;

namespace StoreManagement.UI
{
    public partial class PurchaseTermsConditionEntryUI : Form
    {
        #region Variables
            private PurchaseManager purchaseManager = null;
            private Requisition termsConditions = null;
            private bool IsEdit = false;
            private string StrChoice = null;
        #endregion

        public PurchaseTermsConditionEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseTermsConditionEntryUI(string choice):this()
        {
            //Choice 1 for Tender Terms and condition
            //Choice 2 for Purchase Dept. Order Terms and condition
            //Choice 3 for MIS Dept. Order Terms and Condition
            StrChoice = choice;
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            termsConditions = new Requisition();
        }

        private void PurchaseTenderTermsConditionEntryUI_Load(object sender, EventArgs e)
        {
            termsDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(termsDataGridView_CellFormatting);

            ShowTermsConditions();
        }

        private void ShowTermsConditions()
        {
            DataTable dt = null;

            switch(StrChoice)
            {
                case "1":   //Tender Terms & Condition
                    dt = purchaseManager.GetTermsConditionsList("1", null);
                    headerLabel.Text = "Tender Schedule Terms and Conditions";
                    break;
                case "2":   //Purchase Dept. Order Terms & Condition
                    dt = purchaseManager.GetTermsConditionsList("2", null);
                    headerLabel.Text = "Order Terms and Conditions";
                    break;
                case "3":   //MIS Dept. Order Terms & Condition
                    dt = purchaseManager.GetTermsConditionsList("3", null);
                    headerLabel.Text = "Order Terms and Conditions";
                    break;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                IsEdit = true;

                int n;
                foreach (DataRow dr in dt.Rows)
                {
                    //fill the Department GridView
                    n = termsDataGridView.Rows.Add();
                    termsDataGridView.Rows[n].Cells[1].Value = (n + 1).ToString();
                    termsDataGridView.Rows[n].Cells[2].Value = dr["Terms"].ToString();
                    termsDataGridView.Rows[n].Cells[3].Value = dr["TermsConID"].ToString();    
                }
            }
            else
            {
                termsDataGridView.AllowUserToAddRows = true;
            }
        }

        private void storeReqDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            termsDataGridView.Rows[e.Row.Index - 1].Cells[1].Value = e.Row.Index;
        }

        private void storeReqDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 1)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseManager.TermsConditionsManagement(termsConditions))
                {
                    MessageBox.Show("Saved Successfully.");
                }
                else
                {
                    MessageBox.Show("Faield to save.");
                }
            }
            termsConditions = null;
        }

        private bool IsValid()
        {
            if (termsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Enter terms and conditions");
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
            if (termsConditions == null)
            {
                termsConditions = new Requisition();
            }

            foreach (DataGridViewRow gridItem in termsDataGridView.Rows)
            {
                //loop through the Datagrid to get all terms and conditions
                //deptUID = null;
                if (gridItem.Cells[1].Value != null)
                {
                    TermsCondition terms = new TermsCondition();
                    terms.Description = gridItem.Cells[2].Value.ToString().Trim();

                    if (IsEdit)
                    {
                        if (gridItem.Cells[3].Value== null && string.IsNullOrEmpty(gridItem.Cells[3].Value.ToString()))
                        {
                            switch (StrChoice)
                            {
                                case "1":
                                    terms.Status = "T";
                                    break;
                                case "2":
                                    terms.Status = "PO";
                                    break;
                                case "3":
                                    terms.Status = "MO";
                                    break;
                            }
                            termsConditions.TenderTerms.Add(gridItem.Cells[1].Value.ToString().Trim(), terms);                            
                        }
                        else
                        {
                            terms.Condition = "2";
                            terms.ID = gridItem.Cells[3].Value.ToString().Trim();
                            termsConditions.TenderTerms.Add(terms.ID.ToString(), terms);
                        }
                    }
                    else
                    {
                        switch (StrChoice)
                        {
                            case "1":
                                terms.Status = "T";
                                break;
                            case "2":
                                terms.Status = "PO";
                                break;
                            case "3":
                                terms.Status = "MO";
                                break;
                        }
                        termsConditions.TenderTerms.Add(gridItem.Cells[1].Value.ToString().Trim(), terms);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                ShowTermsConditions();
            }
            else
            {
                termsDataGridView.Rows.Clear();
                IsEdit = false;
            }
            termsConditions = null;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void termsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }
    }
}
