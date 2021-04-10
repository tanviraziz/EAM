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
    public partial class GRREntryUI : Form
    {
        #region Local veriables
            private GRRManager grrManager = null;
            private DynamicControlFill fillContorl = null;
            private MasterSetupManager settingsManager = null;
            private GRR grr = null;
            private bool IsEdit = false, IsStoreOrFSD = false;
            private string grrOrorderidToEdit;   
        #endregion

        private void SetObjects()
        {
            fillContorl = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
            grrManager = new GRRManager();
        }

        public GRREntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public GRREntryUI(string grrOrorderid,bool storeOrFsd,bool edit):this()
        {
            grrOrorderidToEdit = grrOrorderid;
            IsStoreOrFSD = storeOrFsd;
            IsEdit = edit;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GRREntryUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillContorl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            //fillContorl.fillCombo(menufactureComboBox, settingsManager.GetMenufacturerList("3", null), "Menufacturer", "Code");
            //this.menufactureComboBox.SelectedIndexChanged += new System.EventHandler(this.menufactureComboBox_SelectedIndexChanged);

            //fillContorl.fillCombo(storeComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            //storeComboBox.SelectedIndex = -1;

            //this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            
            SetUpdateDate();
            ChangeView();
        }

        //Check all item default
        private void CheckedDefault()
        {
            foreach (DataGridViewRow gridItem in grrDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value == null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    gridItem.Cells[1].Value = true;
                }
            }
        }

        private void ChangeView()
        {
            if (IsStoreOrFSD)
            {
                grrDataGridView.Columns[5].HeaderText = "Received Qty";
                if (IsEdit)
                {
                    grrDataGridView.Columns[1].Visible = false;
                    label18.Visible = true;
                    grrNoLabel.Visible = true;
                    grrNoLabel.Text = grrOrorderidToEdit;
                }
                grrDataGridView.Columns[10].Visible = true;
                CheckedDefault();
            }
            else if (!IsStoreOrFSD)
            {
                this.Size = new Size(890, 629);
                label18.Visible = true;
                grrNoLabel.Visible = true;
                grrNoLabel.Text = grrOrorderidToEdit;
                //chnage the GridView 
                grrDataGridView.Columns[0].Visible = true;
                grrDataGridView.Columns[1].Visible = false;
                grrDataGridView.Columns[5].ReadOnly = true;
                grrDataGridView.Columns[6].Visible = true;
                grrDataGridView.Columns[7].Visible = true;
                grrDataGridView.Columns[8].Visible = true;
                grrDataGridView.Columns[10].Visible = true;

                this.grrDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(this.grrDataGridView_CellFormatting);
                this.grrDataGridView.CellEndEdit += new DataGridViewCellEventHandler(this.grrDataGridView_CellEndEdit);
            }
            
        }

        private void SetUpdateDate()
        {
            DataTable grrDT = null;
            
            try
            {
                int n;
                if (IsStoreOrFSD && !IsEdit)
                {
                    grrDT = grrManager.GetGRRList("6", grrOrorderidToEdit);
                }
                else if(!IsStoreOrFSD || IsEdit)
                {
                    grrDT = grrManager.GetGRRList("7", grrOrorderidToEdit);
                }

                if (grr == null)
                {
                    grr = new GRR();
                }

                if (grrDT != null && grrDT.Rows.Count > 0)
                {
                    supplierLabel.Text = grrDT.Rows[0]["Supplier"].ToString();
                    pOrderLabel.Text = grrDT.Rows[0]["orderNo"].ToString();
                    pOrderDateLabel.Text = grrDT.Rows[0]["orderDate"].ToString();
                    cepNoLabel.Text = grrDT.Rows[0]["CepNo"].ToString();
                    cepDateLabel.Text = grrDT.Rows[0]["cepDate"].ToString();

                    if (IsEdit)
                    {
                        invoiceTextBox.Text = grrDT.Rows[0]["ChallanNo"].ToString();
                        invoiceDate.Text = grrDT.Rows[0]["ChallanDate"].ToString();
                        cCenterCodeTextBox.Text = grrDT.Rows[0]["CostCntCode"].ToString();
                    }

                    foreach (DataRow dr in grrDT.Rows)
                    {
                        n = grrDataGridView.Rows.Add();
                        grrDataGridView.Rows[n].Cells[2].Value = dr["Item"].ToString();
                        grrDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                        grrDataGridView.Rows[n].Cells[4].Value = dr["OrderQty"].ToString();

                        grrDataGridView.Rows[n].Cells[5].Value = (((IsStoreOrFSD || !IsStoreOrFSD) && IsEdit) ? dr["QBfrRecv"].ToString() : "0");
                        if(!IsStoreOrFSD && IsEdit)
                        {
                            grrDataGridView.Rows[n].Cells[7].Value = ((Convert.ToDecimal(dr["QAftRecv"].ToString()) <= 0) ? dr["QBfrRecv"].ToString() : dr["QAftRecv"].ToString());
                        }

                        grrDataGridView.Rows[n].Cells[9].Value = dr["Rate"].ToString();
                        grrDataGridView.Rows[n].Cells[10].Value = dr["TotalRecv"].ToString();
                        grrDataGridView.Rows[n].Cells[11].Value = dr["GoodsID"].ToString();
                        grrDataGridView.Rows[n].Cells[12].Value = dr["POrdDetID"].ToString();
                        

                        if (IsEdit)
                        {
                            grrDataGridView.Rows[n].Cells[8].Value = dr["Comments"].ToString();
                            grrDataGridView.Rows[n].Cells[13].Value = dr["GrrDetailID"].ToString().Trim();

                            //fill the GRR items in dictionary
                            Product srrItem = new Product();
                            srrItem.ReqQty = Convert.ToDecimal(dr["OrderQty"].ToString());
                            srrItem.QtyBoforeInspec = Convert.ToDecimal(dr["QBfrRecv"].ToString());
                            srrItem.QtyAfterInspec = Convert.ToDecimal(dr["QBfrRecv"].ToString());
                            srrItem.Remarks = dr["Comments"].ToString();
                            srrItem.PID = dr["GrrDetailID"].ToString().Trim();
                            grr.Items.Add(dr["GrrDetailID"].ToString().Trim(), srrItem);
                        }

                    }

                }
            }
            catch
            {
                //this.Close();
                IsEdit = false;
            }
        }

        
         private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (grrManager.GRRManagement(grr))
                {
                    if (IsStoreOrFSD && !IsEdit)
                    {
                        MessageBox.Show("GRR No. " + Common.GRRNo + " saved successfully");
                    }
                    else
                    {
                        MessageBox.Show("Saved successfully");
                    }
                    this.Close();
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to save");
                }
            }
           
            grr = null;
        }

        private bool CheckRequisition(string choice,bool cFlag)
        {
            bool flag = cFlag;

            try
            {
                if (grrDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in grrDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRow.Cells[1];
                        switch (choice)                        
                        {       
                            case "1":
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    return false;
                                }
                                break;
                            case "5":
                                if (chk.Value != null && (bool)chk.Value)
                                {
                                    if (dgRow.Cells[5].Value == null || string.IsNullOrEmpty(dgRow.Cells[5].Value.ToString().Trim()) || Convert.ToDecimal(dgRow.Cells[5].Value.ToString().Trim()) <= 0)
                                    {
                                        return true;
                                    }
                                }
                                break;
                            case "6":
                                if (dgRow.Cells[6].Value == null || string.IsNullOrEmpty(dgRow.Cells[6].EditedFormattedValue.ToString().Trim()))
                                {
                                    return true;
                                }                               
                                break;
                            case "6_1":
                                if (dgRow.Cells[6].Value != null && (Convert.ToDecimal(dgRow.Cells[6].EditedFormattedValue.ToString().Trim()) > Convert.ToDecimal(dgRow.Cells[5].Value.ToString().Trim())))
                                {
                                    return true;
                                }
                                break;
                            case "7":
                                if (dgRow.Cells[7].Value == null || string.IsNullOrEmpty(dgRow.Cells[7].Value.ToString().Trim()))
                                {
                                    return true;
                                }                                
                                break;
                            case "8":
                                if (Convert.ToDecimal(dgRow.Cells[6].EditedFormattedValue.ToString().Trim()) > 0 && (dgRow.Cells[8].Value == null || string.IsNullOrEmpty(dgRow.Cells[8].Value.ToString().Trim())))
                                {
                                    return true;
                                }
                                break;
                            case "9":
                                if ((Convert.ToDecimal(dgRow.Cells[5].Value.ToString().Trim()) + Convert.ToDecimal(dgRow.Cells[10].Value.ToString().Trim())) > Convert.ToDecimal(dgRow.Cells[4].Value.ToString().Trim()))
                                {
                                    return true;
                                }
                                break;
                            case "10":
                                if ((Convert.ToDecimal(dgRow.Cells[7].Value.ToString().Trim()) + Convert.ToDecimal(dgRow.Cells[10].Value.ToString().Trim())) > Convert.ToDecimal(dgRow.Cells[4].Value.ToString().Trim()))
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
                return false;
            }
            return flag;
        }

        private bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(invoiceTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter invoice/challan no.");
                    invoiceTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(cCenterCodeTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter cost center code.");
                    cCenterCodeTextBox.Focus();
                    return false;
                }
                else if (!IsEdit && CheckRequisition("1", true))
                {
                    MessageBox.Show("Select an order item.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsEdit && CheckRequisition("5", false))
                {
                    MessageBox.Show("Enter receive qty.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (IsStoreOrFSD && CheckRequisition("9", false))
                {
                    MessageBox.Show("Received quantity exceed ordered qty.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsStoreOrFSD && CheckRequisition("6", false))
                {
                    MessageBox.Show("Fill rejected quantity.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsStoreOrFSD && CheckRequisition("6_1", false))
                {
                    MessageBox.Show("Invalid rejected quantity.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsStoreOrFSD && CheckRequisition("7", false))
                {
                    MessageBox.Show("Fill rejected quantity.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsStoreOrFSD && CheckRequisition("10", false))
                {
                    MessageBox.Show("Received quantity exceed ordered qty.");
                    grrDataGridView.Focus();
                    return false;
                }
                else if (!IsStoreOrFSD && CheckRequisition("8", false))
                {
                    MessageBox.Show("Enter remarks.");
                    grrDataGridView.Focus();
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
            if (grr == null)
            {
                grr = new GRR();
            }
            grr.GrrId = Convert.ToInt64(grrOrorderidToEdit);
            grr.PurchseOrdID = Convert.ToInt64(grrOrorderidToEdit);
            grr.GrrDate = grrDate.Value;                   
            grr.InvoiceNo = invoiceTextBox.Text.Trim();
            grr.InvoiceDate = invoiceDate.Value;
            grr.CostCenterCode = cCenterCodeTextBox.Text.Trim();

            foreach (DataGridViewRow gridItem in grrDataGridView.Rows)
            {
                if (IsStoreOrFSD)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridItem.Cells[1];
                    if (chk.Value != null && (bool)chk.Value)
                    {
                        if (gridItem.Cells[2].Value != null)
                        {
                            Product grrProduct = new Product();
                            grrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                            grrProduct.QtyBoforeInspec = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());

                            if (IsEdit && (gridItem.Cells[13].Value != null && !string.IsNullOrEmpty(gridItem.Cells[13].Value.ToString())))
                            {
                                grrProduct.PID = grr.Items[gridItem.Cells[13].Value.ToString().Trim()].PID;

                                if (IsStoreOrFSD && IsEdit)
                                {
                                    grrProduct.Condition = "2";
                                }
                                else if (!IsStoreOrFSD && IsEdit)
                                {
                                    grrProduct.QtyAfterInspec = Convert.ToDecimal((gridItem.Cells[7].Value == null ? "0" : gridItem.Cells[7].Value.ToString().Trim()));
                                    grrProduct.Remarks = (gridItem.Cells[8].Value == null ? null : gridItem.Cells[8].Value.ToString().Trim());
                                    grrProduct.Condition = "3";
                                }
                                grr.Items[gridItem.Cells[13].Value.ToString().Trim()] = grrProduct;
                            }
                            else
                            {
                                grrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[9].Value.ToString().Trim());
                                grrProduct.PCode = gridItem.Cells[11].Value.ToString().Trim();
                                grrProduct.ReqPID = gridItem.Cells[12].Value.ToString().Trim();
                                grr.Items.Add(gridItem.Cells[12].Value.ToString().Trim(), grrProduct);
                            }
                        }
                    }
                }
                else
                {
                    if (gridItem.Cells[2].Value != null)
                    {
                        Product grrProduct = new Product();
                        grrProduct.QtyBoforeInspec = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());

                        if (IsEdit && (gridItem.Cells[13].Value != null && !string.IsNullOrEmpty(gridItem.Cells[13].Value.ToString())))
                        {
                            grrProduct.PID = grr.Items[gridItem.Cells[13].Value.ToString().Trim()].PID;

                            if (IsStoreOrFSD && IsEdit)
                            {
                                grrProduct.Condition = "2";
                            }
                            else if (!IsStoreOrFSD && IsEdit)
                            {
                                grrProduct.QtyAfterInspec = Convert.ToDecimal((gridItem.Cells[7].Value == null ? "0" : gridItem.Cells[7].Value.ToString().Trim()));
                                grrProduct.Remarks = (gridItem.Cells[8].Value == null ? null : gridItem.Cells[8].Value.ToString().Trim());
                                grrProduct.Condition = "3";
                            }
                            grr.Items[gridItem.Cells[13].Value.ToString().Trim()] = grrProduct;
                        }
                        else
                        {
                            grrProduct.UnitPrice = Convert.ToDecimal(gridItem.Cells[9].Value.ToString().Trim());
                            grrProduct.PCode = gridItem.Cells[11].Value.ToString().Trim();
                            grrProduct.ReqPID = gridItem.Cells[12].Value.ToString().Trim();
                            grr.Items.Add(gridItem.Cells[12].Value.ToString().Trim(), grrProduct);
                        }
                    }
                }
            }

            if (IsStoreOrFSD && IsEdit)
            {
                grr.Condition = "2";
            }
            else if(!IsStoreOrFSD && IsEdit)
            {
                grr.Condition = "3";
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            if (IsStoreOrFSD)
            {
                grrDate.Value = DateTime.Now;
                cCenterCodeTextBox.Clear();
                ClearGrid("5");
            }
            else
            {
                ClearGrid("6");
            }
        }

        private void ClearGrid(string choice)
        {
            try
            {
                if (grrDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in grrDataGridView.Rows)
                    {
                        if(dgRow.Cells[2].Value != null)
                        {
                            switch (choice)
                            {
                                case "0":
                                    if (dgRow.Cells[5].Value != null && !string.IsNullOrEmpty(dgRow.Cells[2].Value.ToString().Trim()))
                                    {
                                        dgRow.Cells[5].Value = "";
                                    }
                                    break;
                                case "6":
                                    if (dgRow.Cells[6].Value != null && !string.IsNullOrEmpty(dgRow.Cells[6].Value.ToString().Trim()))
                                    {
                                        dgRow.Cells[6].Value = "";
                                        dgRow.Cells[7].Value = ((dgRow.Cells[7].Value != null && !string.IsNullOrEmpty(dgRow.Cells[7].Value.ToString().Trim())) ? "" : "");
                                    }
                                    break;                            
                            }
                        }
                    }
                }
            }
            catch
            {
                
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

        //wheather the item already exists or not
        private bool itemExist(string code)
        {
            if (grrDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grrDataGridView.Rows)
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

        private void grrDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (grrDataGridView.CurrentRow != null)
            {
                if (grrDataGridView.CurrentCell.ColumnIndex == 5 || grrDataGridView.CurrentCell.ColumnIndex == 6)
                {
                    txtEdit.KeyPress += IsNumber_Keypress;
                }
                else 
                {
                    txtEdit.KeyPress += IsText_Keypress;
                }
            }
        }

        private void grrDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    // delete the item from GRR list
                    if (grrDataGridView.Rows[e.RowIndex].Cells[13].Value != null && grr.Items.ContainsKey(grrDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)grr.Items[grrDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString().Trim()];
                        deletedItem.Condition = "4";
                        grr.Items[grrDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString().Trim()] = deletedItem;
                    }

                    //remove the DataGrid selectd row
                    grrDataGridView.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }

        private void grrDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }            
        }

        private void grrDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grrDataGridView.CurrentRow != null)
                {
                    switch (e.ColumnIndex)
                    {
                        case 6:
                            grrDataGridView.CurrentRow.Cells[7].Value = (Convert.ToDecimal(grrDataGridView.CurrentRow.Cells[5].Value.ToString().Trim()) - Convert.ToDecimal(grrDataGridView.CurrentRow.Cells[6].Value.ToString().Trim())).ToString();
                            break;
                    }
                }
            }
            catch { }
        }











        //check any item selected or no
        private bool HaveNoSelection()
        {
            //foreach (ListViewItem item in itemListView.Items)
            //{
            //    if (item.Checked)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        private void AddItemInRequisition()
        {
            //foreach (ListViewItem item in itemListView.Items)
            //{
            //    if (item.Checked)
            //    {
            //        if (!itemExist(item.SubItems[4].Text.Trim()))
            //        {
            //            int newRow = grrDataGridView.Rows.Add();
            //            grrDataGridView.Rows[newRow].Cells[1].Value = newRow + 1;
            //            grrDataGridView.Rows[newRow].Cells[2].Value = item.Text.Trim();
            //            grrDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
            //            grrDataGridView.Rows[newRow].Cells[6].Value = item.SubItems[3].Text.Trim();
            //            grrDataGridView.Rows[newRow].Cells[8].Value = item.SubItems[4].Text.Trim();
            //            //grrDataGridView.Rows[newRow].Cells[10].Value = storeComboBox.SelectedValue.ToString().Trim();
            //        }
            //        item.Remove();
            //    }
            //}
        }

        

        

        

        //private void menufactureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(supplierComboBox.Text))
        //    {
        //        menufacturerLabel.Text = menufactureComboBox.Text;
        //        menufacturePanel.Visible = false;
        //    }
        //}

        //private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowItems();
        //}

        //private void ShowItems()
        //{
        //    try
        //    {
        //        if (storeComboBox.SelectedIndex > -1)
        //        {
        //            //unset the item combo event
        //            this.itemComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemComboBox_SelectedIndexChanged);

        //            fillContorl.fillCombo(itemComboBox, settingsManager.GetItemCategoryList("2", storeComboBox.SelectedValue.ToString().Trim()), "Category", "Code");
        //            itemComboBox.SelectedIndex = -1;

        //            itemCategoryComboBox.DataSource = null;
        //            itemCategoryComboBox.Items.Clear();
        //            //set the item combo event
        //            this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.itemComboBox_SelectedIndexChanged);
        //        }
        //    }
        //    catch
        //    {
        //        itemComboBox.DataSource = null;
        //        itemComboBox.Items.Clear();
        //    }
        //}

        //private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowSubCategory();
        //    //itemListView.Items.Clear();
        //    //fillControl.fillListView(itemListView, settingsManager.GetItemList("3", itemComboBox.SelectedValue.ToString()), "Item,,", "317,,");
        //}

        //private void ShowSubCategory()
        //{
        //    try
        //    {
        //        if (itemComboBox.SelectedIndex > -1)
        //        {
        //            //unset the item category combo event
        //            this.itemCategoryComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);

        //            fillContorl.fillCombo(itemCategoryComboBox, settingsManager.GetItemSubCategoryList("3", itemComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
        //            itemCategoryComboBox.SelectedIndex = -1;

        //            //set the item category combo event
        //            this.itemCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);
        //        }
        //    }
        //    catch
        //    {
        //        itemCategoryComboBox.DataSource = null;
        //        itemCategoryComboBox.Items.Clear();
        //    }
        //}

        //private void itemCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        fillContorl.fillListView(itemListView, settingsManager.GetItemList("3", itemCategoryComboBox.SelectedValue.ToString()), "Item,,,,", "317,,,,");
        //    }
        //    catch
        //    {
        //        itemListView.Items.Clear();
        //    }
        //}   
        
    }
}
