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
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class PurchaseOrderEntryUI : Form
    {
        #region Veriables
            private PurchaseManager purchaseManager = null;
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControll = null;
            private Requisition requisition = null;
            private string reqToOrder = null;
            private bool IsEdit = false,IsTenderOrDirect = true;
            private string orderType = null;
            private bool IsVatIncluded = false;
        #endregion        

        public PurchaseOrderEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseOrderEntryUI(string reqNo,string TenderOrDirect):this()
        {
            reqToOrder = reqNo.Trim();

            if (TenderOrDirect.Trim() == "3")
            {
                //set flag when requisition complete the tender process
                IsTenderOrDirect = true;
                orderType = "N";
            }
            else if (TenderOrDirect.Trim() == "30")
            {
                //set flag for direct/cash order skiping tender process(30)
                IsTenderOrDirect = false;
                switch (TenderOrDirect.Trim())
                {
                    //case "2":
                    //    orderType = "C";
                    //    break;
                    case "30":
                        orderType = "Y";
                        break;
                }
            }            
        }

        public PurchaseOrderEntryUI(string orderNo,bool edit): this()
        {
            reqToOrder = orderNo.Trim();
            IsEdit = edit;
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            settingsManager = new MasterSetupManager();
            fillControll = new DynamicControlFill();
        }

        private void PurchaseOrderEntryUI_Load(object sender, EventArgs e)
        {
            ChangeView();
            reqNoTextBox.Text = reqToOrder.Trim();
            this.vatIncCheckBox.CheckedChanged += new System.EventHandler(this.vatIncCheckBox_CheckedChanged);
        }

        private void vatIncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vatIncCheckBox.Checked)
            {
                //Set flag so vat is included with price
                IsVatIncluded = true;
            }
            else
            {
                //Set flag so vat is not included with price
                IsVatIncluded = false;
            }
        }

        private void ChangeView()
        {
            if (IsTenderOrDirect)
            {
                //fill the supplier name and code
                fillControll.fillCombo(supplierComboBox, purchaseManager.GetPruchaseOrderProcessList("1", reqToOrder, null), "Supplier", "Code");
                
                this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);

                //Tender view
                fillControll.fillListView(tenderListView, purchaseManager.GetPruchaseOrderProcessList("2", reqToOrder, null), "Supplier,", "150,");
                fillControll.BuildGroups(1, tenderListView, true);
            }
            else
            {
                //fill the supplier name and code
                fillControll.fillCombo(supplierComboBox, purchaseManager.GetPruchaseOrderProcessList("11", reqToOrder, null), "Supplier", "Code");
                this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);

                orderGroupBox.Visible = true;

                //fill the purchase order type and code
                fillControll.fillCombo(orderTypeComboBox, purchaseManager.GetPurchaseOrderTypeList("1", null), "OrderType", "Code");
                orderTypeComboBox.SelectedIndex = -1;

                splitContainer1.Panel1Collapsed = true;
                pOrdDataGridView.Columns[4].ReadOnly = false;
                cepNoTextBox.ReadOnly = true;
                ShowRequisitionItems();
                CheckedDefault();
            }
        }

        private void ShowRequisitionItems()
        {
            DataTable approvedItemDT;
            try
            {
                approvedItemDT = purchaseManager.GetPruchaseOrderProcessList("4", reqToOrder,null);
                pOrdDataGridView.Rows.Clear();

                if (approvedItemDT.Rows.Count > 0)
                {
                    //cepNoTextBox.Text = approvedItemDT.Rows[0]["CepNo"].ToString();
                    int n;
                    foreach (DataRow dr in approvedItemDT.Rows)
                    {
                        //fill the Order GridView
                        n = pOrdDataGridView.Rows.Add();
                        pOrdDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                        pOrdDataGridView.Rows[n].Cells[2].Value = dr["Unit"].ToString();
                        pOrdDataGridView.Rows[n].Cells[3].Value = dr["Required"].ToString();
                        //pOrdDataGridView.Rows[n].Cells[4].Value = dr["Rate"].ToString();
                        pOrdDataGridView.Rows[n].Cells[5].Value = dr["Required"].ToString();
                        pOrdDataGridView.Rows[n].Cells[8].Value = dr["GoodsID"].ToString();
                        pOrdDataGridView.Rows[n].Cells[9].Value = dr["PRDetID"].ToString();
                    }
                }
            }
            catch
            { }
        }

        private void ShowSupplierApprovedItems(string supplierID)
        {
            DataTable approvedItemDT;
            try
            {
                approvedItemDT = purchaseManager.GetPruchaseOrderProcessList("3", reqToOrder, supplierID);
                pOrdDataGridView.Rows.Clear();

                if (approvedItemDT.Rows.Count > 0)
                {                 
                     int n;
                    foreach (DataRow dr in approvedItemDT.Rows)
                    {
                        //fill the MRR GridView
                        n = pOrdDataGridView.Rows.Add();
                        pOrdDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                        pOrdDataGridView.Rows[n].Cells[2].Value = dr["Unit"].ToString();
                        pOrdDataGridView.Rows[n].Cells[3].Value = dr["Required"].ToString();
                        pOrdDataGridView.Rows[n].Cells[4].Value = dr["Rate"].ToString();
                        pOrdDataGridView.Rows[n].Cells[5].Value = dr["Required"].ToString();
                        pOrdDataGridView.Rows[n].Cells[8].Value = dr["GoodsID"].ToString();
                        pOrdDataGridView.Rows[n].Cells[9].Value = dr["PTDId"].ToString();
                    }
                }
            }
            catch
            { }
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseManager.PurOrdManagement(requisition))
                {
                    MessageBox.Show("Saved Successfully.");
                    ClearAllFields();
                    //this.Close();
                }
                requisition = null;
            }
        }

        //validation
        private bool IsValid()
        {
            DataTable dt = null;
            dt = purchaseManager.GetPruchaseOrderProcessList("6", purOrdNoTextBox.Text.Trim(), "");

            if (string.IsNullOrEmpty(purOrdNoTextBox.Text.Trim()))
            {
                MessageBox.Show("Enter Purchase Order No.");
                purOrdNoTextBox.Focus();
                return false;
            }
            else if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Order No. already exists.");
                purOrdNoTextBox.Focus();
                return false;
            }
            else if (!Regex.Match(purOrdNoTextBox.Text.Trim(), @"^[A-Z][A-Z.]{2,3}[-#][\s]?\d{1,10}$").Success)
            {
                MessageBox.Show("Invalid Purchase Order Format...(i.e. PPD-123 or P.O.# 123).");
                purOrdNoTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(supplierTextBox.Text.Trim()))
            {
                MessageBox.Show("Select a Supplier.");
                supplierTextBox.Focus();
                return false;
            }
            else if (!IsTenderOrDirect && string.IsNullOrEmpty(orderTypeComboBox.Text.Trim()))
            {
                MessageBox.Show("Select Order Type.");
                orderTypeComboBox.Focus();
                return false;
            }
            else if (CheckOrderItem("0",true))
            {
                MessageBox.Show("Select an order item");
                pOrdDataGridView.Focus();
                return false;
            }
            else if (CheckOrderItem("5",false))
            {
                MessageBox.Show("Enter order quantity");
                pOrdDataGridView.Focus();
                return false;
            }
            else if (CheckOrderItem("6", false))
            {
                MessageBox.Show("Enter unit price");
                pOrdDataGridView.Focus();
                return false;
            }
            else
            {
                SetValues();
            }
            return true;
        }

        private bool CheckOrderItem(string choice,bool dFlag)
        {
            bool flag = dFlag;
            try
            {
                if (pOrdDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in pOrdDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRow.Cells[0];
                        switch (choice)                        
                        {                                
                            case "0":                                
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    return false;
                                }
                                break;
                            case "5":
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    if (dgRow.Cells[5].Value != null && (Convert.ToDecimal(dgRow.Cells[5].Value.ToString().Trim()) <= 0))
                                    {
                                        return true;
                                    }
                                }
                                break;
                            case "6":
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    if (dgRow.Cells[4].Value == null || (dgRow.Cells[4].Value != null && (Convert.ToDecimal(dgRow.Cells[4].Value.ToString().Trim()) <= 0)))
                                    {
                                        return true;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return flag;
        }


        //set the input data
        private void SetValues()
        {
            if (requisition == null)
            {
                requisition = new Requisition();
            }

            requisition.PrrNo = reqNoTextBox.Text.Trim();
            requisition.CepNO = cepNoTextBox.Text.Trim();
            requisition.PurOrdNo = purOrdNoTextBox.Text.Trim();
            requisition.PurOrdDate = purOrdDate.Value;
            requisition.DeliveryDate = deliveryDate.Value;
            requisition.SupplierID = Convert.ToInt32(supplierComboBox.SelectedValue.ToString());
            requisition.TotalItem = Convert.ToDecimal(TotalItemQty());         //Convert.ToInt32(totalItemLabel.Text.Split(':')[1].Trim());
            requisition.Vat = (string.IsNullOrEmpty(vatTextBox.Text.Trim()) ? 0 : Convert.ToDecimal(vatTextBox.Text.Trim())); 
            requisition.VatIncluded = (IsVatIncluded ? "2" : "1");
            //requisition.IsEmargency = orderType.Trim();  

            //if direct purchase order or cash purchase order then set the emargency status to appropriate state
            if(!IsTenderOrDirect && !string.IsNullOrEmpty(orderTypeComboBox.Text))
            {
                requisition.IsEmargency = orderTypeComboBox.SelectedValue.ToString();
            }

            foreach (DataGridViewRow gridItem in pOrdDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    //Initialize a new PRR product
                    Product prrProduct = new Product();

                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridItem.Cells[0];
                    if (chk.Value != null && (bool)chk.Value)
                    {
                        if (IsEdit && (gridItem.Cells[8].Value != null && !string.IsNullOrEmpty(gridItem.Cells[8].Value.ToString())))
                        {
                            prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[3].Value.ToString().Trim());
                            prrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                            prrProduct.IssueQty = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            prrProduct.Vat = Convert.ToByte(((gridItem.Cells[6].Value == null || string.IsNullOrEmpty(gridItem.Cells[6].Value.ToString())) ? "0" : gridItem.Cells[6].Value.ToString().Trim()));
                            prrProduct.PID = gridItem.Cells[9].Value.ToString().Trim();
                            prrProduct.PTDId = ((gridItem.Cells[10].Value == null || string.IsNullOrEmpty(gridItem.Cells[10].Value.ToString())) ? null : gridItem.Cells[10].Value.ToString().Trim()); ;
                            prrProduct.Condition = "2";
                        }
                        else
                        {
                            prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[3].Value.ToString().Trim());
                            prrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                            prrProduct.IssueQty = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            prrProduct.Vat = Convert.ToByte(((gridItem.Cells[6].Value == null || string.IsNullOrEmpty(gridItem.Cells[6].Value.ToString())) ? "0" : gridItem.Cells[6].Value.ToString().Trim()));
                            prrProduct.PCode = gridItem.Cells[8].Value.ToString().Trim();
                            if (orderType.ToUpper().Trim() == "Y")
                            {
                                prrProduct.PRDetID = ((gridItem.Cells[9].Value == null || string.IsNullOrEmpty(gridItem.Cells[9].Value.ToString())) ? null : gridItem.Cells[9].Value.ToString().Trim());
                            }
                            else
                            {
                                prrProduct.PTDId = ((gridItem.Cells[9].Value == null || string.IsNullOrEmpty(gridItem.Cells[9].Value.ToString())) ? null : gridItem.Cells[9].Value.ToString().Trim());
                            }
                            prrProduct.PurOrdID = (IsEdit ? reqToOrder : null);
                        }
                        requisition.Products.Add(prrProduct);
                    }
                }
            }
        }

        private void yearTextBox_KeyPress(object sender, KeyPressEventArgs e)
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


        //Get the total selected items
        private string TotalItemQty()
        {
            decimal totalQty = 0;
            try
            {
                foreach (DataGridViewRow gridRow in pOrdDataGridView.Rows)
                {
                    //totalQty += Convert.ToDecimal((gridRow.Cells[7].Value == null ? "0" : gridRow.Cells[7].Value.ToString()));
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridRow.Cells[0];
                    if (chk.Value != null && (bool)chk.Value)
                    {
                        totalQty += 1;
                    }
                }
                return totalQty.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void pOrdDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal unitPrice = 0;
            Int32 totalOrdered = 0;

            switch (e.ColumnIndex)
            {
                case 0:
                    //totalItemLabel.Text = "Total Items:  " + TotalItemQty();
                    break;
                case 5:
                    if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value == null)
                    {
                        pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Selected = true;
                    }
                    else if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        unitPrice = Convert.ToDecimal((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()));
                        totalOrdered = Convert.ToInt32((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                        pOrdDataGridView.Rows[e.RowIndex].Cells[7].Value = unitPrice * totalOrdered;

                        //Calculate the total qty
                        //totalQtyLabel.Text = TotalDeliveryQty();
                    }
                    break;
            }
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

                if (IsTenderOrDirect)
                {
                    ShowSupplierApprovedItems(supplierComboBox.SelectedValue.ToString().Trim());
                    CheckedDefault();
                }
            }
        }

        //Check all item default
        private void CheckedDefault()
        {
            foreach (DataGridViewRow gridItem in pOrdDataGridView.Rows)
            {
                if (gridItem.Cells[0].Value == null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    gridItem.Cells[0].Value = true;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            purOrdNoTextBox.Clear();
            purOrdDate.Value = DateTime.Now;
            deliveryDate.Value = DateTime.Now;

            supplierTextBox.Clear();

            this.supplierComboBox.SelectedIndexChanged -= new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            if (IsTenderOrDirect)
            {
                fillControll.fillCombo(supplierComboBox, purchaseManager.GetPruchaseOrderProcessList("1", reqToOrder, null), "Supplier", "Code");
            }
            else
            {
                fillControll.fillCombo(supplierComboBox, purchaseManager.GetPruchaseOrderProcessList("11", reqToOrder, null), "Supplier", "Code");
            }
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            //SetUpdateData(reqToOrder);

            pOrdDataGridView.Rows.Clear();
            if (IsTenderOrDirect)
            {
                //Tender view
                fillControll.fillListView(tenderListView, purchaseManager.GetPruchaseOrderProcessList("2", reqToOrder, null), "Supplier,", "150,");
                fillControll.BuildGroups(1, tenderListView, true);
            }
            else
            {
                ShowRequisitionItems();
                CheckedDefault();
            }
        }

        private void pOrdDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal unitPrice = 0;
            Int32 totalOrdered = 0;
            try
            {
                if (pOrdDataGridView.CurrentRow != null)
                {
                    switch (e.ColumnIndex)
                    {
                        //case 4:
                        //    if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value == null)
                        //    {
                        //        pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;
                        //    }
                        //    else if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        //    {
                        //        unitPrice = Convert.ToDecimal((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                        //        totalOrdered = Convert.ToInt32((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString()));
                        //        pOrdDataGridView.Rows[e.RowIndex].Cells[6].Value = unitPrice * totalOrdered;

                        //        //Calculate the total qty
                        //        //totalQtyLabel.Text = TotalDeliveryQty();
                        //    }
                        //    break;
                        case 5:
                            if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value == null)
                            {
                                pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Selected = true;
                            }
                            else if (pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                unitPrice = Convert.ToDecimal((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()));
                                totalOrdered = Convert.ToInt32((string.IsNullOrEmpty(pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) ? "0" : pOrdDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                                pOrdDataGridView.Rows[e.RowIndex].Cells[7].Value = unitPrice * totalOrdered;

                                //Calculate the total qty
                                //totalQtyLabel.Text = TotalDeliveryQty();
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        private void pOrdDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (pOrdDataGridView.CurrentRow != null)
            {
                if (pOrdDataGridView.CurrentCell.ColumnIndex == 4 || pOrdDataGridView.CurrentCell.ColumnIndex == 5)
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

        private void vatTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == 13)
            {
                if(!string.IsNullOrEmpty(vatTextBox.Text.Trim()))
                {
                    FillVatWithAllItems();
                }
            }
        }

        private void FillVatWithAllItems()
        {
            try
            {
                if (pOrdDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in pOrdDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRow.Cells[0];
                        if (chk.Value != null && (bool)chk.Value)
                        {
                            //if (dgRow.Cells[6].Value != null && (Convert.ToDecimal(dgRow.Cells[6].Value.ToString().Trim()) <= 0))
                            //{

                            //}
                            dgRow.Cells[6].Value = vatTextBox.Text.Trim();
                        }
                    }
                }
            }
            catch
            {
                
            }            
        }

        

         

        
    }
}
