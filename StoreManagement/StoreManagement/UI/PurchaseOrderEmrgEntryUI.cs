using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using StoreManagement.DAL.DAO;
using StoreManagement.BLL;
using StoreManagement.UTILITY;
using StoreManagement.Properties;

namespace StoreManagement.UI
{
    public partial class PurchaseOrderEmrgEntryUI : Form
    {
        #region Local veriables
            private PurchaseManager purchaseManager = null;
            private DynamicControlFill fillContorl = null;
            private MasterSetupManager settingsManager = null;
            private Requisition requisition = null;
            private bool IsEdit = false;
            private bool orderProcessByPurchase = false; //default false and true for purchase order process
            private string orderToEdit;
        #endregion

        private void SetObjects()
        {
            fillContorl = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
            purchaseManager = new PurchaseManager();
        }

        public PurchaseOrderEmrgEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseOrderEmrgEntryUI(string orderID):this()
        {
            orderToEdit = orderID;
            IsEdit = true;
        }

        public PurchaseOrderEmrgEntryUI(string orderID, bool byPurchase): this()
        {
            orderToEdit = orderID;
            orderProcessByPurchase = byPurchase;
            IsEdit = true;
        }

        private void PurchaseOrderEmrgEntryUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillContorl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            fillContorl.fillCombo(supplierComboBox, settingsManager.GetSupplierList("3", null), "Supplier", "Code");
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);

            fillContorl.fillCombo(storeComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            storeComboBox.SelectedIndex = -1;

            //change the view 
            ChangeView();
            if (IsEdit)
            {
                SetUpdateData(orderToEdit);
            }
        }

        //change the view for purchase and store, hiding the fields not required
        private void ChangeView()
        {
            if (orderProcessByPurchase)
            {
                orderDataGridView.Columns[0].Visible = false;
                orderDataGridView.Columns[4].ReadOnly = true;
                orderDataGridView.Columns[5].Visible = true;
                orderDataGridView.Columns[6].Visible = true;
                orderDataGridView.Columns[7].Visible = true;
                taskPane1.Expandos[0].Visible = false;
            }
            else
            {
                orderDataGridView.Columns[5].Visible = false;
                orderDataGridView.Columns[7].Visible = false;
                orderDataGridView.Columns[2].Width = orderDataGridView.Columns[2].Width + 130;
                taskPane1.Expandos[1].Size = new Size(702, 395);


                suppLabel.Location = new Point(11, 18);
                supplierLabel.Location = new Point(68, 14);
                purchaseGroupBox.Visible = false;
                purchasePanel.Size = new Size(734, 72);

                if (!IsEdit)
                {                    
                    this.supplierLabel.Click += new System.EventHandler(this.supplierLabel_Click);
                }
                this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            }
        }

        private void SetUpdateData(string orderID)
        {
            DataTable purchaseReq = null;
            //purchaseReq = purchaseManager.GetEmargencyPurchaseOrderList("4", orderID);

            if (requisition == null)
            {
                requisition = new Requisition();
            }

            if (purchaseReq.Rows.Count > 0)
            {
                //reqNoTextBox.Text = purchaseReq.Rows[0]["ReqNo"].ToString();
                int n;
                supplierLabel.Text = purchaseReq.Rows[0]["Supplier"].ToString();

                if (orderProcessByPurchase)
                {
                    purOrdNoTextBox.Text = purchaseReq.Rows[0]["orderNo"].ToString();
                    purOrdDatePicker.Value = Convert.ToDateTime(purchaseReq.Rows[0]["orderDate"]);
                    cepNoTextBox.Text = purchaseReq.Rows[0]["CepNo"].ToString();
                }
                else
                {
                    storeComboBox.Text = purchaseReq.Rows[0]["Stationary"].ToString();
                    this.storeComboBox.SelectedIndexChanged -= new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
                    storeComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    ShowItems();
                }

                foreach (DataRow dr in purchaseReq.Rows)
                {
                    //fill the MRR GridView
                    n = orderDataGridView.Rows.Add();
                    orderDataGridView.Rows[n].Cells[1].Value = n + 1;
                    orderDataGridView.Rows[n].Cells[2].Value = dr["Item"].ToString();
                    orderDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                    orderDataGridView.Rows[n].Cells[4].Value = dr["Required"].ToString();
                    orderDataGridView.Rows[n].Cells[5].Value = dr["Price"].ToString();
                    orderDataGridView.Rows[n].Cells[6].Value = dr["Vat"].ToString();
                    orderDataGridView.Rows[n].Cells[7].Value = (Convert.ToInt32(dr["OrderedQty"].ToString()) > 0 ? dr["OrderedQty"].ToString() : dr["Required"].ToString()) ;
                    orderDataGridView.Rows[n].Cells[8].Value = dr["GoodsID"].ToString();
                    orderDataGridView.Rows[n].Cells[10].Value = dr["POrdDetID"].ToString();
                    //orderDataGridView.Rows[n].Cells[9].Value = dr["ReqID"].ToString();

                    //fill the order item in dictionery
                    Product prrProduct = new Product();
                    prrProduct.ReqQty = Convert.ToDecimal(dr["Required"].ToString());
                    prrProduct.PID = dr["POrdDetID"].ToString();

                    requisition.Items.Add(dr["POrdDetID"].ToString(), prrProduct);
                }
            }
        }


        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplierComboBox.Text))
            {
                supplierLabel.Text = supplierComboBox.Text;
                supplierPanel.Visible = false;
            }
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowItems();
        }

        private void ShowItems()
        {
            try
            {
                if (storeComboBox.SelectedIndex > -1)
                {
                    //unset the item combo event
                    this.itemComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemComboBox_SelectedIndexChanged);

                    fillContorl.fillCombo(itemComboBox, settingsManager.GetItemCategoryList("2", storeComboBox.SelectedValue.ToString().Trim()), "Category", "Code");
                    itemComboBox.SelectedIndex = -1;

                    itemCategoryComboBox.DataSource = null;
                    itemCategoryComboBox.Items.Clear();
                    orderDataGridView.Rows.Clear();
                    //set the item combo event
                    this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.itemComboBox_SelectedIndexChanged);
                }
            }
            catch
            {
                itemComboBox.DataSource = null;
                itemComboBox.Items.Clear();
            }
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSubCategory();
            itemListView.Items.Clear();
            //fillControl.fillListView(itemListView, settingsManager.GetItemList("3", itemComboBox.SelectedValue.ToString()), "Item,,", "317,,");
        }

        private void ShowSubCategory()
        {
            try
            {
                if (itemComboBox.SelectedIndex > -1)
                {
                    //unset the item category combo event
                    this.itemCategoryComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);

                    fillContorl.fillCombo(itemCategoryComboBox, settingsManager.GetItemSubCategoryList("3", itemComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
                    itemCategoryComboBox.SelectedIndex = -1;

                    //set the item category combo event
                    this.itemCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);
                }
            }
            catch
            {
                itemCategoryComboBox.DataSource = null;
                itemCategoryComboBox.Items.Clear();
            }
        }

        private void itemCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillContorl.fillListView(itemListView, settingsManager.GetItemList("3", itemCategoryComboBox.SelectedValue.ToString()), "Item,,,,", "317,,,,");
            }
            catch
            {
                itemListView.Items.Clear();
            }
        }  

        
        private void supplierLabel_Click(object sender, EventArgs e)
        {
            this.supplierPanel.Location = new Point(71, 20);
            supplierPanel.Visible = true;
        }

        private void addSupplierLabel_Click(object sender, EventArgs e)
        {
            supplierPanel.Visible = true;
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
            foreach (ListViewItem item in itemListView.Items)
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
            foreach (ListViewItem item in itemListView.Items)
            {
                if (item.Checked)
                {
                    if (!itemExist(item.SubItems[4].Text.Trim()))
                    {
                        int newRow = orderDataGridView.Rows.Add();
                        orderDataGridView.Rows[newRow].Cells[1].Value = newRow + 1;
                        orderDataGridView.Rows[newRow].Cells[2].Value = item.Text.Trim();
                        orderDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
                        orderDataGridView.Rows[newRow].Cells[7].Value = item.SubItems[4].Text.Trim();
                        //orderDataGridView.Rows[newRow].Cells[8].Value = storeComboBox.SelectedValue.ToString().Trim();
                    }
                    item.Remove();
                }
            }
        }

        //wheather the item already exists or not
        private bool itemExist(string code)
        {
            if (orderDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in orderDataGridView.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[7].Value.ToString().Trim().ToUpper() == code.ToUpper())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void orderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        //check for keypress      
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

        private void orderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (orderDataGridView.CurrentRow != null)
            {
                if (orderDataGridView.CurrentCell.ColumnIndex == 4 || orderDataGridView.CurrentCell.ColumnIndex == 5 || orderDataGridView.CurrentCell.ColumnIndex == 6)
                {
                    txtEdit.KeyPress += IsNumber_Keypress;
                }
                else 
                {
                    txtEdit.KeyPress += IsText_Keypress;
                }
            }
        }

        

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseManager.EmargencyPurchaseOrdManagement(requisition))
                {
                    MessageBox.Show("Saved Successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }
            }
            else
            {
                MessageBox.Show("Failed to save.");
            }
            requisition = null;
        }

        //validation
        private bool IsValid()
        {
            try
            {
                if (!orderProcessByPurchase && string.IsNullOrEmpty(supplierLabel.Text.Trim()))
                {
                    MessageBox.Show("Select a Supplier.");
                    supplierLabel.Focus();
                    return false;
                }
                else if (!orderProcessByPurchase && CheckOrderItem("", false))
                {
                    MessageBox.Show("Enter an order item.");
                    orderDataGridView.Focus();
                    return false;
                }
                else if (!orderProcessByPurchase && CheckOrderItem("4", false))
                {
                    MessageBox.Show("Enter required quantity.");
                    orderDataGridView.Focus();
                    return false;
                }
                else if (orderProcessByPurchase && string.IsNullOrEmpty(cepNoTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter CEP No.");
                    cepNoTextBox.Focus();
                    return false;
                }
                else if (orderProcessByPurchase && string.IsNullOrEmpty(purOrdNoTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter Purchase Order No.");
                    purOrdNoTextBox.Focus();
                    return false;
                }
                else if (!orderProcessByPurchase && CheckOrderItem("5", false))
                {
                    MessageBox.Show("Enter unit price.");
                    orderDataGridView.Focus();
                    return false;
                }
                //else if (!orderProcessByPurchase && CheckOrderItem("6", false))
                //{
                //    MessageBox.Show("Enter required quantity.");
                //    orderDataGridView.Focus();
                //    return false;
                //}
                else if (!orderProcessByPurchase && CheckOrderItem("7", false))
                {
                    MessageBox.Show("Enter ordered quantity.");
                    orderDataGridView.Focus();
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

        //private bool HaveNoItem()
        //{
        //    try
        //    {
        //        if (orderDataGridView.Rows.Count > 0)
        //        {
        //            foreach (DataGridViewRow dgRow in orderDataGridView.Rows)
        //            {
        //                if (dgRow.Cells[1].Value == null)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private bool CheckOrderItem(string choice, bool dFlag)
        {
            bool flag = dFlag;
            try
            {
                if (orderDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in orderDataGridView.Rows)
                    {
                        switch (choice)
                        {
                            case "1":
                                if (dgRow.Cells[1].Value == null)
                                {
                                    return true;
                                }
                                break;
                            case "4":
                                if (string.IsNullOrEmpty(dgRow.Cells[4].Value.ToString().Trim()) || Convert.ToInt32(dgRow.Cells[4].Value.ToString().Trim()) <= 0)
                                {
                                    return true;
                                }
                                break;
                            case "5":
                                if (string.IsNullOrEmpty(dgRow.Cells[5].Value.ToString().Trim()) || Convert.ToDecimal(dgRow.Cells[5].Value.ToString().Trim()) <= 0)
                                {
                                    return true;
                                }
                                break;

                            case "6":
                                if (string.IsNullOrEmpty(dgRow.Cells[6].Value.ToString().Trim()) || Convert.ToInt32(dgRow.Cells[6].Value.ToString().Trim()) <= 0)
                                {
                                    return true;
                                }
                                break;
                            case "7":
                                if (string.IsNullOrEmpty(dgRow.Cells[7].Value.ToString().Trim()) || Convert.ToInt32(dgRow.Cells[7].Value.ToString().Trim()) <= 0)
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

            //requisition.PrrNo = reqNoTextBox.Text.Trim();
            if (orderProcessByPurchase)
            {
                requisition.CepNO = cepNoTextBox.Text.Trim();
                requisition.PurOrdNo = purOrdNoTextBox.Text.Trim();
                requisition.PurOrdDate = purOrdDatePicker.Value;
                requisition.DeliveryDate = deliveryDatePicker.Value;
                requisition.Condition = "3";
                requisition.PurOrdID = Convert.ToInt64(orderToEdit);
            }
            else
            {
                requisition.SupplierID = Convert.ToInt32(supplierComboBox.SelectedValue.ToString());
                requisition.SCategory = Convert.ToInt16(storeComboBox.SelectedValue.ToString());
                requisition.TotalItem = Convert.ToDecimal(TotalItemQty());

                if (IsEdit)
                {
                    requisition.Condition = "2";
                    requisition.PurOrdID = Convert.ToInt64(orderToEdit);
                }
            }

            foreach (DataGridViewRow gridItem in orderDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    //Initialize a new PRR product
                    Product prrProduct = new Product();

                    if (IsEdit && (gridItem.Cells[10].Value != null && !string.IsNullOrEmpty(gridItem.Cells[10].Value.ToString())))
                    {
                        prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                        //Start:data given by purchase

                        if (orderProcessByPurchase)
                        {
                            prrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            prrProduct.Vat = Convert.ToByte(gridItem.Cells[6].Value.ToString().Trim());
                            prrProduct.IssueQty = Convert.ToDecimal(gridItem.Cells[7].Value.ToString().Trim());
                        }

                        //End:data given by purchase

                        prrProduct.PID = gridItem.Cells[10].Value.ToString().Trim();
                        if (orderProcessByPurchase)
                        {
                            prrProduct.Condition = "4";
                        }
                        else
                        {
                            prrProduct.Condition = "3";
                        }
                        requisition.Items[gridItem.Cells[10].Value.ToString().Trim()] = prrProduct;
                    }
                    else
                    {
                        prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                        //Start:data given by purchase
                        if (orderProcessByPurchase)
                        {
                            prrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                            prrProduct.Vat = Convert.ToByte(gridItem.Cells[6].Value.ToString().Trim());
                            prrProduct.IssueQty = Convert.ToDecimal(gridItem.Cells[7].Value.ToString().Trim());
                        }
                        //End:data given by purchase
                        prrProduct.PCode = gridItem.Cells[8].Value.ToString().Trim();
                        prrProduct.PurOrdID = (IsEdit ? orderToEdit : null);
                        requisition.Items.Add(gridItem.Cells[8].Value.ToString().Trim(),prrProduct);
                    }                                        
                }
            }
        }
        
        //Get the total selected items
        private string TotalItemQty()
        {
            decimal totalQty = 0;
            try
            {
                foreach (DataGridViewRow gridRow in orderDataGridView.Rows)                
                {                    
                    if (gridRow.Cells[1].Value != null)
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

        private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (orderDataGridView.Rows[e.RowIndex].Cells[9].Value != null && requisition.Items.ContainsKey(orderDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)requisition.Items[orderDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString().Trim()];
                        deletedItem.Condition = "5";
                        requisition.Items[orderDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString().Trim()] = deletedItem;
                    }
                    orderDataGridView.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            if (orderProcessByPurchase)
            {
                cepNoTextBox.Clear();
                purOrdNoTextBox.Clear(); ;
                deliveryDatePicker.Value = DateTime.Now;
                purOrdDatePicker.Value = DateTime.Now;
            }
            else
            {
                supplierLabel.Text = "";
                storeComboBox.SelectedIndex = -1;
                orderDataGridView.Rows.Clear();
            }

            if (IsEdit)
            {
                SetUpdateData(orderToEdit);
            }
        }
        
    }
}
