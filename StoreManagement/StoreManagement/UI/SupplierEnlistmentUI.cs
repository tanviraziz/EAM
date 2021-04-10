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
using StoreManagement.Properties;


namespace StoreManagement.UI
{
    public partial class SupplierEnlistmentUI : Form
    {
        #region  Veriables
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControl = null;
            private Dictionary<string, ListViewItem> supplierItems = new Dictionary<string, ListViewItem>();
            private bool IsPurchaseOrMIS = true; //TRUE for PURCHASE and FALSE for MIS
            private DataTable storeItemsDT = null;
            private Supplier supplier = null;
            private string supplierID = null;
            private bool IsEdit = false;
        #endregion

        public SupplierEnlistmentUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            fillControl = new DynamicControlFill();
        }

        public SupplierEnlistmentUI(bool Flag):this()
        {
            IsPurchaseOrMIS = Flag;
        }

        private void SupplierEnlistmentUI_Load(object sender, EventArgs e)
        {
            fillControl.fillListView(supplierListView, settingsManager.GetSupplierEnlistmentList("1", null, null), "Supplier,,", "240,,", true);
            fillControl.fillListView(enlistedSupplierListView, settingsManager.GetSupplierEnlistmentList("2", null, null), ",Supplier,", ",240,", true);
            //fillControl.fillListView(enlistedSupplierListView, settingsManager.GetSupplierEnlistmentList("4", "2"), "Item,", "330,", true);
            

            //Cahnge the view for PURCHASE and MIS Enlistment
            ChangeView();
        }

        private void ChangeView()
        {  
            if (IsPurchaseOrMIS)
            {
                fillControl.fillCombo(stationeryComboBox, settingsManager.GetSupplierEnlistmentList("3", null, null), "Stationery", "Code");
                stationeryComboBox.SelectedIndex = -1;

                storeItemsDT = settingsManager.GetSupplierEnlistmentList("5", "1,3", null);
                this.stationeryComboBox.SelectedIndexChanged += new EventHandler(stationeryComboBox_SelectedIndexChanged);
            }
            else
            {
                fillControl.fillCombo(itemComboBox, settingsManager.GetSupplierEnlistmentList("4", "2", null), "Item", "Code");
                itemComboBox.SelectedIndex = -1;

                storeItemsDT = settingsManager.GetSupplierEnlistmentList("5", "2", null);
                fillControl.fillListView(itemListView, storeItemsDT, "Item,", "330,", false);

                this.itemComboBox.SelectedIndexChanged += new EventHandler(itemComboBox_SelectedIndexChanged);

                categoryGroupBox.Visible = false;
                filterGroupBox.Size = new Size(353,66);
                itemGroupBox.Location = new Point(5,19);
            }
        }

        private void ColorRow(ListViewItem item, bool flag)
        {
            if (flag)
            {
                itemListView.Refresh();
                itemListView.BeginUpdate();

                item.BackColor = Color.FromArgb(87, 130, 176);
                item.ForeColor = Color.White;
                item.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                item.Checked = true;

                itemListView.EndUpdate();
            }
            else
            {
                itemListView.Refresh();
                itemListView.BeginUpdate();

                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
                item.Font = new Font("Tahoma", 9F, FontStyle.Regular);
                item.Checked = false;

                itemListView.EndUpdate();
            }
        }

        private void supplierItemsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.itemListView.ItemChecked -= new ItemCheckedEventHandler(this.itemListView_ItemChecked);

                    //set the delete condition for the removed item
                    if (supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value != null && supplier.Items.ContainsKey(supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)supplier.Items[supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim()];
                        deletedItem.Condition = "3";
                        supplier.Items[supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim()] = deletedItem;
                    }

                    //add the removed item in Global DataTable "storeItemsDT"
                    if (IsEdit)
                    {
                        AddRemovedItemInListview(supplierItemsDataGridView.Rows[e.RowIndex]);
                        //refresh the listview with the removed item
                        //fillControl.fillListView(itemListView, storeItemsDT, "Item,,,", "330,,,", false);
                        //fillControl.BuildGroups(1, itemListView, false);
                        //ColorRow(supplierItems[supplierItemsDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim()], false);
                    }
                    //ColorRow 
                    if (supplierItems.Count > 0)
                    {
                        ColorRow(supplierItems[supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim()], false);

                        //remove the selected item from the DataGridView
                        supplierItems.Remove(supplierItemsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                    }
                    supplierItemsDataGridView.Rows.RemoveAt(e.RowIndex);

                    //ColorItemsSelected();                  

                    this.itemListView.ItemChecked += new ItemCheckedEventHandler(this.itemListView_ItemChecked);
                    break;
            }
        }

        //add the removed item in Global Datatable "storeItemsDT"
        private void AddRemovedItemInListview(DataGridViewRow dr)
        {
            //ListViewItem itemX = null;
            int count = 0;

            //itemListView.BeginUpdate();
            try
            {
                if (!HaveItemInDataTatble(dr.Cells[3].Value.ToString().Trim()))
                {
                    DataRow newDRow = storeItemsDT.NewRow();
                    foreach (DataGridViewCell dc in dr.Cells)
                    {
                        switch (count)
                        {
                            case 1:
                                //itemX = itemListView.Items.Add(dc.Value.ToString());                       
                                newDRow["Item"] = dc.Value.ToString().Trim();
                                break;
                            case 2:
                                //itemX.SubItems.Add(dc.Value.ToString());
                                newDRow["Category"] = dc.Value.ToString().Trim();
                                break;
                            case 3:
                                //itemX.SubItems.Add(dc.Value.ToString());
                                newDRow["GoodsID"] = dc.Value.ToString().Trim();
                                break;
                            case 5:
                                //itemX.SubItems.Add(dc.Value.ToString());
                                newDRow["Stationery"] = dc.Value.ToString().Trim();
                                break;

                        }
                        count++;
                    }
                    storeItemsDT.Rows.Add(newDRow);
                }
            }
            catch
            {
            }            
            //itemListView.EndUpdate();
        }

        private void itemListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;

            try
            {
                if (item != null)
                {
                    if (item.Checked)
                    {
                        supplierItems.Add(item.SubItems[3].Text.Trim(), item);
                        ColorRow(item, true);

                        int n = supplierItemsDataGridView.Rows.Add();
                        supplierItemsDataGridView.Rows[n].Cells[1].Value = item.Text.Trim();
                        supplierItemsDataGridView.Rows[n].Cells[2].Value = item.SubItems[1].Text.Trim();
                        supplierItemsDataGridView.Rows[n].Cells[3].Value = item.SubItems[3].Text.Trim();                       
                    }
                    else
                    {
                        RemoveFromGrid(item.SubItems[3].Text.Trim());
                        ColorRow(item, false);
                    }
                }
            }
            catch
            {
                MessageBox.Show("This item already exist.");
            }
        }

        private void RemoveFromGrid(string item)
        {
            foreach (DataGridViewRow dgRow in supplierItemsDataGridView.Rows)
            {
                if (dgRow.Cells[3].Value.ToString().Trim() == item.Trim())
                {
                    supplierItemsDataGridView.Rows.RemoveAt(dgRow.Index);
                    supplierItems.Remove(dgRow.Cells[3].Value.ToString().Trim());
                }
            }
        }

        private void stationeryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(stationeryComboBox.Text.Trim()))
                {
                    this.stationeryComboBox.SelectedIndexChanged -= new EventHandler(stationeryComboBox_SelectedIndexChanged);
                    this.itemComboBox.SelectedIndexChanged -= new EventHandler(itemComboBox_SelectedIndexChanged);
                    this.itemListView.ItemChecked -= new ItemCheckedEventHandler(this.itemListView_ItemChecked);

                    fillControl.fillListView(itemListView, GetItemsOfStationary(stationeryComboBox.Text.Trim()), "Item,,,", "330,,,", true);
                    fillControl.BuildGroups(1, itemListView, false);

                    fillControl.fillCombo(itemComboBox, settingsManager.GetSupplierEnlistmentList("4", stationeryComboBox.SelectedValue.ToString().Trim(), null), "Item", "Code");
                    itemComboBox.SelectedIndex = -1;

                    this.stationeryComboBox.SelectedIndexChanged += new EventHandler(stationeryComboBox_SelectedIndexChanged);
                    this.itemComboBox.SelectedIndexChanged += new EventHandler(itemComboBox_SelectedIndexChanged);
                    
                }
            }
            catch { }
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(itemComboBox.Text.Trim()))
                {
                    itemListView.ItemChecked -= new ItemCheckedEventHandler(itemListView_ItemChecked);

                    //fillControl.fillListView(itemListView, settingsManager.GetSupplierEnlistmentList("5", itemComboBox.SelectedValue.ToString().Trim()), "Item,", "330,", false);
                    fillControl.fillListView(itemListView, GetItemsOfCategory(itemComboBox.Text.Trim()), "Item,,,", "330,,,", false);
                    fillControl.BuildGroups(1, itemListView, false);                  

                    if (supplierItems.Keys.Count > 0)
                    {
                        ColorItemsSelected();
                    }

                    itemListView.ItemChecked += new ItemCheckedEventHandler(itemListView_ItemChecked);
                }
            }
            catch { }
        }

        //Color the selected items
        private void ColorItemsSelected()
        {
            foreach (var li in supplierItems)
            {
                ListViewItem item = li.Value;
                foreach (ListViewItem cItem in itemListView.Items)
                {
                    if (item.SubItems[3].Text.Trim() == cItem.SubItems[3].Text.Trim())
                    {
                        ColorRow(cItem, true);
                    }
                    //else
                    //{
                    //    ColorRow(cItem, false);
                    //}
                }
            }
        }

        private bool HaveItemInDataTatble(string str)
        {
            bool flag = false;
            try
            {
                //IEnumerable<DataRow> query = from n in storeItemsDT.AsEnumerable()
                //            where n.Field<string>("GoodsID").ToUpper() == str.ToUpper().Trim()
                //            select n;

                //string dt = query.ToString();
                foreach (DataRow dr in storeItemsDT.Rows)
                {
                    if (dr["GoodsID"].ToString().Trim() == str.Trim())
                    {
                        flag = true;
                        break;
                    }
                }

                return flag;
            }
            catch
            {
                return false;
            }
        
        }

        private DataTable GetItemsOfStationary(string choice)
        {
            DataTable dt = null;
            try
            {
                IEnumerable<DataRow> query = from n in storeItemsDT.AsEnumerable()
                                             where n.Field<string>("Stationery").ToUpper() == choice.ToUpper().Trim()
                                             select n;

                dt = query.CopyToDataTable<DataRow>();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        private DataTable GetItemsOfCategory(string choice)
        {
            DataTable dt = null;
            try
            {
                IEnumerable<DataRow> query = from n in storeItemsDT.AsEnumerable()
                                             where n.Field<string>("Category").ToUpper() == choice.ToUpper().Trim()
                             select n;

                dt = query.CopyToDataTable<DataRow>();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        //Color the selected items
        private void ColorItems()
        {
            foreach (var li in supplierItems)
            {
                ListViewItem item = li.Value;
                ColorRow(item, true);
            }
        }

        private void supplierItemsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (settingsManager.SupplierEnlistmentManagement(supplier))
                {
                    MessageBox.Show("Saved successfully");
                    ClearAllFields();
                }
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(supplierLabel.Text.Trim()))
            {
                MessageBox.Show("Select a supplier");
                return false;
            }
            else if (supplierItemsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Select supplier items");
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
            if (supplier == null)
            {
                supplier = new Supplier();
            }
            supplier.SupplierID = Convert.ToInt32(supplierID);

            int totalItem = 0;

            foreach (DataGridViewRow gridItem in supplierItemsDataGridView.Rows)
            {
                if (gridItem.Cells[3].Value != null)
                {
                    //enter new data
                    //Initialize a new supplier product
                    Product supplierProduct = new Product();

                    if (IsEdit && ((gridItem.Cells[4].Value != null && !string.IsNullOrEmpty(gridItem.Cells[4].Value.ToString())) || supplier.Items.ContainsKey(gridItem.Cells[3].Value.ToString().Trim())))
                    {
                        supplierProduct.PCode =  gridItem.Cells[3].Value.ToString().Trim();
                        //supplierProduct.PID = supplier.Items[gridItem.Cells[4].Value.ToString().Trim()].PID;
                        supplierProduct.Condition = "2";
                        supplier.Items[gridItem.Cells[3].Value.ToString().Trim()] = supplierProduct;
                    }
                    else
                    {
                        supplierProduct.PCode = gridItem.Cells[3].Value.ToString().Trim();                        
                        supplier.Items.Add(gridItem.Cells[3].Value.ToString().Trim(), supplierProduct);
                    }

                    totalItem++;
                }
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            //remove all event handler
            this.stationeryComboBox.SelectedIndexChanged -= new EventHandler(stationeryComboBox_SelectedIndexChanged);
            this.itemComboBox.SelectedIndexChanged -= new EventHandler(itemComboBox_SelectedIndexChanged);
            this.itemListView.ItemChecked -= new ItemCheckedEventHandler(this.itemListView_ItemChecked);

            //clear all text
            supplierLabel.Text = "";
            addressLabel.Text = "";
            //clear all combo
            stationeryComboBox.SelectedIndex = -1;
            itemComboBox.SelectedIndex = -1;

            //clear the datagridview
            supplierItemsDataGridView.Rows.Clear();
            //clear the item listview
            itemListView.Items.Clear();

            ChangeView();

            //fill all supplier and enlisted supplier list
            fillControl.fillListView(supplierListView, settingsManager.GetSupplierEnlistmentList("1", null, null), "Supplier,,", "240,,", true);
            fillControl.fillListView(enlistedSupplierListView, settingsManager.GetSupplierEnlistmentList("2", null, null), ",Supplier,", ",240,", true);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplierListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierListView.SelectedIndices.Count > 0)
            {
                supplierLabel.Text = supplierListView.Items[supplierListView.SelectedIndices[0]].Text.Trim();
                addressLabel.Text = supplierListView.Items[supplierListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                supplierID = supplierListView.Items[supplierListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                if (supplier != null)
                {
                    supplier = null;
                }
                supplierItemsDataGridView.Rows.Clear();
            }
        }

        private void enlistedSupplierListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enlistedSupplierListView.SelectedIndices.Count > 0)
            {
                supplierID = enlistedSupplierListView.Items[enlistedSupplierListView.SelectedIndices[0]].Text.Trim();
                supplierLabel.Text = enlistedSupplierListView.Items[enlistedSupplierListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                addressLabel.Text = enlistedSupplierListView.Items[enlistedSupplierListView.SelectedIndices[0]].SubItems[2].Text.Trim();

                if (storeItemsDT != null)
                {
                    storeItemsDT = null;
                }
                
                IsEdit = true;
                this.stationeryComboBox.SelectedIndexChanged -= new EventHandler(stationeryComboBox_SelectedIndexChanged);
                this.itemComboBox.SelectedIndexChanged -= new EventHandler(itemComboBox_SelectedIndexChanged);
                this.itemListView.ItemChecked -= new ItemCheckedEventHandler(this.itemListView_ItemChecked);

                if (IsPurchaseOrMIS)
                {
                    storeItemsDT = settingsManager.GetSupplierEnlistmentList("6", "1,3", supplierID);
                    stationeryComboBox.SelectedIndex = -1;
                    itemComboBox.SelectedIndex = -1;
                    itemListView.Items.Clear();
                }
                else
                {
                    storeItemsDT = settingsManager.GetSupplierEnlistmentList("6", "2", supplierID);
                    itemComboBox.SelectedIndex = -1;
                    itemListView.Items.Clear();
                }

                this.stationeryComboBox.SelectedIndexChanged += new EventHandler(stationeryComboBox_SelectedIndexChanged);
                

                FillSupplierItems();
            }
        }

        private void FillSupplierItems()
        {
            if (supplier == null)
            {
                supplier = new Supplier();
            }
            else
            {
                supplier.Items.Clear();
            }

            supplierItemsDataGridView.Rows.Clear();
            DataTable dt = null;
            int n = 0;
            try
            {
                dt = settingsManager.GetSupplierEnlistmentList("7", supplierID, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        n = supplierItemsDataGridView.Rows.Add();
                        supplierItemsDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                        supplierItemsDataGridView.Rows[n].Cells[2].Value = dr["Category"].ToString();
                        supplierItemsDataGridView.Rows[n].Cells[3].Value = dr["GoodsID"].ToString();
                        supplierItemsDataGridView.Rows[n].Cells[4].Value = dr["SlNo"].ToString();
                        supplierItemsDataGridView.Rows[n].Cells[5].Value = dr["Stationery"].ToString();

                        Product supplierProduct = new Product();
                        supplierProduct.PID = dr["SlNo"].ToString();
                        supplierProduct.PCode = dr["GoodsID"].ToString();
                        supplier.Items.Add(dr["GoodsID"].ToString(), supplierProduct);

                        supplierItems.Clear(); //clear all items
                        //foreach (ListViewItem li in itemListView.Items)
                        //{
                        //    if (li.SubItems[3].ToString().Trim() == dr["GoodsID"].ToString().Trim())
                        //    {
                        //        supplierItems.Add(li.SubItems[3].Text.Trim(), li);
                        //        ColorRow(li, true);
                        //    }
                        //}
                    }
                }
            }
            catch
            { 

            }

        }
    }
}
