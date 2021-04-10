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
using System.Text.RegularExpressions;
using StoreManagement.Properties;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class PurRequisitionConfirmEntryUI : Form
    {
        #region Veriables
            private PurchaseManager purchaseReqManager = null;
            private string reqToEdit = null;
            private Requisition requisition = null;
            private bool IsEdit = false;
        #endregion
        

        public PurRequisitionConfirmEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            purchaseReqManager = new PurchaseManager();
        }

        public PurRequisitionConfirmEntryUI(string reqNO):this()
        {
            reqToEdit = reqNO;
        }

        private void PurRequisitionConfirmEntryUI_Load(object sender, EventArgs e)
        {
            SetUpdateData();
        }

        private void SetUpdateData()
        {
            DataTable dt;
            int n;

            try
            {
                dt = purchaseReqManager.GetPurchaseRequistionProcessList("4", reqToEdit);

                //initialize the requisition 
                if (requisition == null)
                {
                    requisition = new Requisition();
                }

                storeReqDataGridView.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    reqNoTextBox.Text = dt.Rows[0]["ReqNo"].ToString();
                    reqDateTextBox.Text = dt.Rows[0]["ReqDate"].ToString();                    


                    foreach (DataRow dr in dt.Rows)
                    {
                        //fill the Requisition  GridView
                        n = storeReqDataGridView.Rows.Add();
                        storeReqDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                        storeReqDataGridView.Rows[n].Cells[2].Value = dr["Unit"].ToString();
                        storeReqDataGridView.Rows[n].Cells[3].Value = dr["Required"].ToString();
                        storeReqDataGridView.Rows[n].Cells[4].Value = dr["Required"].ToString();
                        storeReqDataGridView.Rows[n].Cells[5].Value = dr["GoodsID"].ToString();
                        storeReqDataGridView.Rows[n].Cells[6].Value = dr["ReqID"].ToString();

                        //fill the requisition item in dictionery
                        Product prrProduct = new Product();
                        prrProduct.ReqQty = Convert.ToDecimal(dr["Required"].ToString());
                        prrProduct.PID = dr["ReqID"].ToString();
                        requisition.Items.Add(dr["ReqID"].ToString(), prrProduct);
                    }
                }
            }
            catch
            {

            }
        }

        private void storeReqDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (storeReqDataGridView.Rows[e.RowIndex].Cells[6].Value != null && requisition.Items.ContainsKey(storeReqDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)requisition.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString().Trim()];
                        deletedItem.Condition = "3";
                        requisition.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString().Trim()] = deletedItem;
                    }
                    storeReqDataGridView.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseReqManager.PrrManagement(requisition))
                {
                    MessageBox.Show("Saved Successfully.");
                    if (cepRadioButton.Checked)
                    {
                        new SendMail().SendCEPMail(purchaseReqManager.GetPurchaseRequistionProcessList("3", reqToEdit));
                    }
                    this.Close();                                     
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }

            }            
            //requisition = null;
        }

        //validation
        private bool IsValid()
        {
            DataTable dt = null;
            try
            {
                if (string.IsNullOrEmpty(cepNoTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter CEP No.");
                    cepNoTextBox.Focus();
                    return false;
                }
                else if (storeReqDataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Enter a requisition item.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (CheckRequisition("4"))
                {
                    MessageBox.Show("Fill all approved quantity.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (!tenderRadioButton.Checked && !orderRadioButton.Checked && !cepRadioButton.Checked)
                {
                    MessageBox.Show("Select a process type.");
                    processTypeGroupBox.Focus();
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

        private bool CheckRequisition(string choice)
        {
            try
            {
                if (storeReqDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in storeReqDataGridView.Rows)
                    {
                        switch (choice)
                        {
                            case "4":
                                if (string.IsNullOrEmpty(dgRow.Cells[4].Value.ToString().Trim()))
                                {
                                    return true;
                                }
                                break;
                            
                        }
                    }
                }
            }
            catch
            {
                return true;
            }
            return false;
        }

        //set the input data
        private void SetValues()
        {
            if (requisition == null)
            {
                requisition = new Requisition();
            }

            requisition.PrrNo = reqToEdit.Trim();
            requisition.CepNO = cepNoTextBox.Text.Trim();
            requisition.CepDate = cepDate.Value;
            if(tenderRadioButton.Checked)
            {
                requisition.Status = "21";
            }
            else if(orderRadioButton.Checked)
            {
                requisition.Status = "30";
            }
            else if (cepRadioButton.Checked)
            {
                requisition.Status = "200";
            }
            

            foreach (DataGridViewRow gridItem in storeReqDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    //Initialize a new PRR product
                    Product prrProduct = new Product();

                    prrProduct.PID = requisition.Items[gridItem.Cells[6].Value.ToString()].PID;
                    prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                    prrProduct.Condition = "4";
                    requisition.Items[gridItem.Cells[6].Value.ToString().Trim()] = prrProduct;  
                }
            }

            requisition.Condition = "5";
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            cepNoTextBox.Clear();
            cepDate.Value = DateTime.Now;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void storeReqDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (storeReqDataGridView.CurrentRow != null)
            {
                if (storeReqDataGridView.CurrentCell.ColumnIndex == 4 )
                {
                    txtEdit.KeyPress += IsNumber_Keypress;
                }
                else
                {
                    txtEdit.KeyPress += IsText_Keypress;
                }
            }
        }

        private void IsNumber_Keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

        private void IsText_Keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void storeReqDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

    }
}
