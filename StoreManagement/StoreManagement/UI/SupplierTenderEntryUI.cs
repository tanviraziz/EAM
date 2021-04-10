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
using StoreManagement.DAL.GATEWAY;
using StoreManagement.UTILITY;
using StoreManagement.Properties;
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class SupplierTenderEntryUI : Form
    {
        #region Veriables
        private PurchaseManager purchaseManager = null;
        private MasterSetupManager settingsManager = null;
        private DynamicControlFill fillControll = null;
        private Requisition requisition = null;
        private string reqToTender = null,tenderToEdit = null;
        private bool IsEdit = false;
        #endregion


        public SupplierTenderEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            settingsManager = new MasterSetupManager();
            fillControll = new DynamicControlFill();
        }

        public SupplierTenderEntryUI(string reqNo):this()
        {
            reqToTender = reqNo;
        }

        public SupplierTenderEntryUI(string reqNo, string tenderID): this()
        {
            reqToTender = reqNo;
            tenderToEdit = tenderID;
            IsEdit = true;
        }

        private void SupplierTenderEntryUI_Load(object sender, EventArgs e)
        {
            fillControll.fillCombo(supplierComboBox, settingsManager.GetSupplierList("3", null), "Supplier", "Code");
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            
            ChangeView();
            SetUpdateData(reqToTender);
        }

        private void ChangeView()
        {
            if (IsEdit)
            {
                this.supplierComboBox.SelectedIndexChanged -= new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
                supplierComboBox.DropDownStyle = ComboBoxStyle.Simple;

                supplierTextBox.Click -= new System.EventHandler(this.supplierTextBox_Click);

                //chnage the GridView 
                tenderDataGridView.Columns[0].Visible = false;
                tenderDataGridView.Columns[1].Visible = true;

                //Change the form
                this.Size = new Size(925, 579);
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                CheckedDefault();
            }
        }

        private void CheckedDefault()
        {
            foreach (DataGridViewRow gridItem in tenderDataGridView.Rows)
            {
                if (gridItem.Cells[0].Value == null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    gridItem.Cells[0].Value = true;
                }
            }
        }

        private void SetUpdateData(string reqNo)
        {
            DataTable purchaseReq = null;
            
            if (IsEdit)
            {
                //fill the listview and gridview when edit a tender
                fillControll.fillListView(requisitionListView, purchaseManager.GetPurchaseTenderList("9", tenderToEdit), "Item, Unit, Required,,", "250,60,80,,", true);
                purchaseReq = purchaseManager.GetPurchaseTenderList("6", tenderToEdit);

                if (requisition == null)
                {
                    requisition = new Requisition();
                }
            }
            else
            {
                //fill the gridview when enter a new supplier tender
                purchaseReq = purchaseManager.GetPurchaseTenderList("5", reqNo);
            }

            try
            {
                if (purchaseReq.Rows.Count > 0)
                {
                    if (IsEdit)
                    {
                        //supplierComboBox.Text = purchaseReq.Rows[0]["Supplier"].ToString();
                        supplierTextBox.Text = purchaseReq.Rows[0]["Supplier"].ToString();                          
                    }

                    int n;
                    foreach (DataRow dr in purchaseReq.Rows)
                    {
                        //fill the Tender GridView
                        n = tenderDataGridView.Rows.Add();
                        tenderDataGridView.Rows[n].Cells[2].Value = dr["Item"].ToString();
                        tenderDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                        tenderDataGridView.Rows[n].Cells[4].Value = dr["Required"].ToString();
                        tenderDataGridView.Rows[n].Cells[8].Value = dr["GoodsID"].ToString();
                        tenderDataGridView.Rows[n].Cells[9].Value = dr["ReqID"].ToString();

                        if (IsEdit)
                        {
                            tenderDataGridView.Rows[n].Cells[5].Value = dr["Rate"].ToString();
                            tenderDataGridView.Rows[n].Cells[10].Value = dr["PTDId"].ToString();
                            Product tenderProduct = new Product();
                            tenderProduct.PID = dr["PTDId"].ToString();

                            requisition.Items.Add(dr["PTDId"].ToString(), tenderProduct);
                        }
                    }
                }
            }
            catch { }
        }

        private void addSupplierLabel_Click(object sender, EventArgs e)
        {
            new SupplierEntryUI().ShowDialog();
            fillControll.fillCombo(supplierComboBox, settingsManager.GetSupplierList("3", null), "Supplier", "Code");
        }

        private void supplierTextBox_Click(object sender, EventArgs e)
        {
            supplierPanel.Visible = true;
        }

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplierComboBox.Text))
            {
                supplierTextBox.Text = supplierComboBox.Text;
                supplierPanel.Visible = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseManager.TenderManagement(requisition))
                {
                    MessageBox.Show("Saved successfully.");
                    if (IsEdit)
                    {
                        this.Close();
                    }
                    else
                    {
                        ClearAllFields();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }
            }
            requisition = null;
        }

        private bool CheckRequisition(string choice)
        {
            bool flag = true;
            try
            {
                if (tenderDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in tenderDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRow.Cells[0];

                        switch (choice)
                        {
                            case "0":
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    flag = false;
                                    break;
                                }
                                break;

                            case "5":
                                flag = false;
                                if (IsEdit)
                                {
                                    if (string.IsNullOrEmpty(dgRow.Cells[5].Value.ToString().Trim()))
                                    {
                                        flag = true;
                                        break;
                                    }  
                                }
                                else 
                                {
                                    if((chk.Value != null && (bool)chk.Value) && string.IsNullOrEmpty(dgRow.Cells[5].Value.ToString().Trim()))
                                    {
                                        flag = true;
                                        break;
                                    }  
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
            return flag;
        }

        private bool HaveNoItem()
        {
            foreach (DataGridViewRow gridItem in tenderDataGridView.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridItem.Cells[1];
                if (chk.Value != null && (bool)chk.Value)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(supplierTextBox.Text.Trim()))
            {
                MessageBox.Show("Select a supplier");
                supplierTextBox.Focus();
                return false;
            }
            else if (!IsEdit && CheckRequisition("0"))
            {
                MessageBox.Show("Select an item");
                return false;
            }
            else if (IsEdit && tenderDataGridView.Rows.Count <=0)
            {
                MessageBox.Show("Select an item");
                return false;
            }
            else if (CheckRequisition("5"))
            {
                MessageBox.Show("Enter all selected item price");
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

            requisition.PrrNo = reqToTender.Trim();
            requisition.SupplierID = Convert.ToInt32(supplierComboBox.SelectedValue.ToString());
            int totalItem = 0;

            foreach (DataGridViewRow gridItem in tenderDataGridView.Rows)
            {
                if (gridItem.Cells[2].Value != null)
                {
                    if (IsEdit)
                    {
                        //edit a tender
                        //Initialize a new Tender product
                        Product tenderProduct = new Product();

                        if (gridItem.Cells[10].Value != null && !string.IsNullOrEmpty(gridItem.Cells[10].Value.ToString()))
                        {
                            //update previous data
                            tenderProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            tenderProduct.Remarks = (gridItem.Cells[7].Value == null ? string.Empty : gridItem.Cells[7].Value.ToString().Trim());
                            tenderProduct.PID = gridItem.Cells[10].Value.ToString().Trim();
                            tenderProduct.Condition = "2";
                            requisition.Items[gridItem.Cells[10].Value.ToString().Trim()] = tenderProduct;

                            totalItem++;
                        }
                        else
                        {
                            //enter new data
                            tenderProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            tenderProduct.Remarks = (gridItem.Cells[7].Value == null ? string.Empty : gridItem.Cells[7].Value.ToString().Trim());
                            tenderProduct.PCode = gridItem.Cells[8].Value.ToString().Trim();
                            tenderProduct.ReqPID = gridItem.Cells[9].Value.ToString().Trim();
                            tenderProduct.PTDId = tenderToEdit.Trim();
                            requisition.Items.Add(gridItem.Cells[9].Value.ToString().Trim(), tenderProduct);

                            totalItem++;
                        }
                    }
                    else
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridItem.Cells[0];
                        if (chk.Value != null && (bool)chk.Value)
                        {
                            //enter tender data
                            //Initialize a new Tender product
                            Product tenderProduct = new Product();
                            
                            tenderProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            tenderProduct.Remarks = (gridItem.Cells[7].Value == null ? string.Empty : gridItem.Cells[7].Value.ToString().Trim());
                            tenderProduct.PCode = gridItem.Cells[8].Value.ToString().Trim();
                            tenderProduct.ReqPID = gridItem.Cells[9].Value.ToString().Trim();
                            requisition.Items.Add(gridItem.Cells[9].Value.ToString().Trim(), tenderProduct);

                            totalItem++;                           
                        }
                    }
                }
            }

            requisition.TotalItem = totalItem;

            if (IsEdit)
            {
                requisition.Condition = "2";
            }
        }

        private void tenderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (HaveNoSelection())
            {
                MessageBox.Show("Select an item.");
            }
            else
            {
                AddItemInRequisition();
            }
        }

        //check any item selected or no
        private bool HaveNoSelection()
        {
            foreach (ListViewItem item in requisitionListView.Items)
            {
                if (item.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddItemInRequisition()
        {
            foreach (ListViewItem item in requisitionListView.Items)
            {
                if (item.Checked)
                {
                    if (!itemExist(item.SubItems[4].Text.Trim()))
                    {
                        int newRow = tenderDataGridView.Rows.Add();
                        tenderDataGridView.Rows[newRow].Cells[2].Value = item.Text.Trim();
                        tenderDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
                        tenderDataGridView.Rows[newRow].Cells[4].Value = item.SubItems[2].Text.Trim();
                        tenderDataGridView.Rows[newRow].Cells[8].Value = item.SubItems[3].Text.Trim();
                        tenderDataGridView.Rows[newRow].Cells[9].Value = item.SubItems[4].Text.Trim();
                    }
                    item.Remove();
                }
            }
        }

        //wheather the item already exists or not
        private bool itemExist(string code)
        {
            if (tenderDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tenderDataGridView.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[8].Value.ToString().Trim().ToUpper() == code.ToUpper())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            supplierComboBox.SelectedIndex = -1;
            tenderDataGridView.Rows.Clear();
            supplierTextBox.Clear();
            SetUpdateData(reqToTender);
        }

        private void tenderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    if (tenderDataGridView.Rows[e.RowIndex].Cells[10].Value != null && requisition.Items.ContainsKey(tenderDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)requisition.Items[tenderDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString().Trim()];
                        deletedItem.Condition = "3";
                        requisition.Items[tenderDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString().Trim()] = deletedItem;
                    }
                    tenderDataGridView.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }

        private void tenderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (tenderDataGridView.CurrentRow != null)
            {
                if (tenderDataGridView.CurrentCell.ColumnIndex == 5)
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
