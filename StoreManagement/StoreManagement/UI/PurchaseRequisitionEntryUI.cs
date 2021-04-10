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
using System.Text.RegularExpressions;
using StoreManagement.Properties;

namespace StoreManagement.UI
{
    public partial class PurchaseRequisitionEntryUI : Form
    {
        #region Veriables
            private bool IsEdit = false;
            private string reqToEdit;
            private Requisition requisition = null;
            private MasterSetupManager masterManager = null;
            private DynamicControlFill fillControl = null;
            private PurchaseManager purchaseReqManager = null;
            private bool IsEmargency = false;
        #endregion

        private void HeaderCheckBOx()
        {
            // customize dataviewgrid, add checkbox column
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            storeReqDataGridView.Columns.Insert(0, checkboxColumn);

            // add checkbox header
            Rectangle rect = storeReqDataGridView.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            storeReqDataGridView.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < storeReqDataGridView.RowCount; i++)
            {
                storeReqDataGridView[0, i].Value = ((CheckBox)storeReqDataGridView.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            storeReqDataGridView.EndEdit();
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            masterManager = new MasterSetupManager();
            purchaseReqManager = new PurchaseManager();
        }

        public PurchaseRequisitionEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseRequisitionEntryUI(string reqNo):this()
        {
            IsEdit = true;
            reqToEdit = reqNo;
        }

        private void PurchaseRequisitionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            fillControl.fillCombo(sCategoryComboBox, masterManager.GetStationaryCategoryList("1", null), "Category", "Code");
            sCategoryComboBox.SelectedIndex = -1;
            this.sCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.sCategoryComboBox_SelectedIndexChanged);

            fillControl.fillCombo(unitComboBox, masterManager.GetCompanyUnitList("1", null), "Unit", "Code");
            unitComboBox.SelectedIndex = -1;

            //fill the update date in form
            if (IsEdit)
            {
                SetUpdateData();
                label14.Text = "Edit Purchase Requisition : " + reqToEdit;
                label14.BackColor = Color.FromArgb(84, 64, 91);                
            }
            else
            {
                FillYearCombo();
                yearComboBox.Text = DateTime.Now.Year.ToString().Trim();
                //yearTextBox.ReadOnly = false;
            }
        }

        private void FillYearCombo()
        {
            int year = DateTime.Now.Year;
            for (int i = year ; i <= year + 1; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }
        }

        private void SetUpdateData()
        {
            DataTable dt;
            int n;

            try
            {                
                dt = purchaseReqManager.GetPurchaseRequistionList("4", reqToEdit);

                //initialize the requisition 
                if (requisition == null)
                {
                    requisition = new Requisition();
                }

                storeReqDataGridView.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    this.sCategoryComboBox.SelectedIndexChanged -= new System.EventHandler(this.sCategoryComboBox_SelectedIndexChanged);
                    sCategoryComboBox.Text = dt.Rows[0]["Category"].ToString();
                    sCategoryComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    ShowItems();

                    timePeriodComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    timePeriodComboBox.Text = dt.Rows[0]["TimePeriod"].ToString();
                    //timePeriodComboBox.DropDownStyle = ComboBoxStyle.Simple;

                    yearComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    yearComboBox.Text = dt.Rows[0]["PRYear"].ToString();

                    unitComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    unitComboBox.Text = dt.Rows[0]["CompanyUnit"].ToString();

                    emargencyCheckBox.Checked = ((!string.IsNullOrEmpty(dt.Rows[0]["isEmargency"].ToString().Trim()) &&  dt.Rows[0]["isEmargency"].ToString().Trim().ToUpper() == "Y") ? true : false);
                    

                    foreach (DataRow dr in dt.Rows)
                    {
                        //fill the Requisition  GridView
                        n = storeReqDataGridView.Rows.Add();
                        storeReqDataGridView.Rows[n].Cells[1].Value = dr["Item"].ToString();
                        storeReqDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                        storeReqDataGridView.Rows[n].Cells[4].Value = dr["CurrentStock"].ToString();
                        storeReqDataGridView.Rows[n].Cells[5].Value = dr["Required"].ToString();
                        storeReqDataGridView.Rows[n].Cells[6].Value = dr["Remarks"].ToString();
                        storeReqDataGridView.Rows[n].Cells[7].Value = dr["GoodsID"].ToString();
                        storeReqDataGridView.Rows[n].Cells[8].Value = dr["ReqID"].ToString();

                        //fill the requisition item in dictionery
                        Product prrProduct = new Product();
                        prrProduct.StockQty = Convert.ToDecimal(dr["Stock"].ToString());
                        prrProduct.ReqQty = Convert.ToDecimal(dr["Required"].ToString());
                        prrProduct.Remarks = dr["Remarks"].ToString();
                        prrProduct.PID = dr["ReqID"].ToString();

                        requisition.Items.Add(dr["ReqID"].ToString(), prrProduct);
                    }
                }
            }
            catch
            {

            }
        }

        //fill the required item below reorder level
        private void ShowRequiredItem(string choice, string condition)
        {
            try
            {
                DataTable currentStock;
                currentStock = new StoreManager().GetCurrentStock(choice, condition);
                storeReqDataGridView.Rows.Clear();

                if (currentStock.Rows.Count > 0)
                {
                    int n;

                    foreach (DataRow dr in currentStock.Rows)
                    {
                        //fill the MRR GridView
                        n = storeReqDataGridView.Rows.Add();
                        storeReqDataGridView.Rows[n].Cells[1].Value = dr["Material"].ToString();
                        storeReqDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                        storeReqDataGridView.Rows[n].Cells[4].Value = (Convert.ToDecimal(dr["Stock"].ToString()) <= 0 ? "0" : dr["Stock"].ToString());
                        storeReqDataGridView.Rows[n].Cells[7].Value = dr["Code"].ToString();
                    }
                }
            }
            catch
            {

            }
        }

        #region Radio Button

        //private void singleRadioButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void doubleRadioButton_Click(object sender, EventArgs e)
        //{
        //    if (doubleRadioButton.Checked)
        //    {
        //        new DynamicControlFill().fillCombo(timePeriodComboBox, new MasterSetupManager().GetTimePeriod("2", "12"), "Period", "Code");
        //    }
        //}

        //private void tripleRadioButton_Click(object sender, EventArgs e)
        //{
        //    if (tripleRadioButton.Checked)
        //    {
        //        new DynamicControlFill().fillCombo(timePeriodComboBox, new MasterSetupManager().GetTimePeriod("3", "13"), "Period", "Code");
        //    }
        //}

        //private void quarterRadioButton_Click(object sender, EventArgs e)
        //{
        //    if (quarterRadioButton.Checked)
        //    {
        //        new DynamicControlFill().fillCombo(timePeriodComboBox, new MasterSetupManager().GetTimePeriod("4", "14"), "Period", "Code");
        //    }
        //}

        #endregion

        //savae the requisition
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (purchaseReqManager.PrrManagement(requisition))
                {
                    MessageBox.Show("Saved Successfully.");

                    if (IsEdit)
                    {
                        this.Close();
                    }
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }

            }            
            requisition = null;
        }

        //validation
        private bool IsValid()
        {
            DataTable dt = null;
            try
            {
                if (!IsEdit && !IsEmargency)
                {
                    dt = purchaseReqManager.GetPurchaseRequistionList("5", sCategoryComboBox.SelectedValue.ToString().Trim() + timePeriodComboBox.SelectedValue.ToString().Trim() + yearComboBox.Text.Trim() + unitComboBox.SelectedValue.ToString().Trim());
                }


                if (string.IsNullOrEmpty(sCategoryComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select a category.");
                    sCategoryComboBox.Focus();
                    return false;
                }
                else if (!IsEmargency &&  string.IsNullOrEmpty(timePeriodComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select a month.");
                    timePeriodComboBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(yearComboBox.Text.Trim()))
                {
                    MessageBox.Show("Enter year.");
                    yearComboBox.Focus();
                    return false;
                }
                else if (yearComboBox.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Invalid year.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(unitComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select a unit");
                    unitComboBox.Focus();
                    return false;
                }
                else if (storeReqDataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Enter a requisition item.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (CheckRequisition("5"))
                {
                    MessageBox.Show("Fill all required quantity.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (dt != null && dt.Rows.Count >= 1)
                {
                    MessageBox.Show(unitComboBox.Text + " unit, already have a requisition of " + sCategoryComboBox.Text + " for the month of " + timePeriodComboBox.Text.Trim());
                    return false;
                } 
                else
                {
                    SetValues();
                }
            }
            catch
            {
                MessageBox.Show("Failed to save");
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
                            case "5":
                                if (string.IsNullOrEmpty(dgRow.Cells[5].Value.ToString().Trim()))
                                {
                                    return true;
                                }
                                break;

                            case "6":
                                if (string.IsNullOrEmpty(dgRow.Cells[6].Value.ToString().Trim()))
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

        private bool HaveNoItem()
        {
            foreach (DataGridViewRow gridItem in storeReqDataGridView.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridItem.Cells[1];
                if (chk.Value != null && (bool)chk.Value)
                {
                    return false;
                }
            }
            return true;
        }


        //set the input data
        private void SetValues()
        {
            if (requisition == null)
            {
                requisition = new Requisition();
            }

            if(!IsEdit)
            {
                //for new requisition those data are requiried
                requisition.SCategory = Convert.ToInt16(sCategoryComboBox.SelectedValue.ToString());
                requisition.TimePeriod = (string.IsNullOrEmpty(timePeriodComboBox.Text.ToString().Trim()) ? null : timePeriodComboBox.SelectedValue.ToString().Trim());
                requisition.PRYear = yearComboBox.Text.Trim();
                requisition.UnitID = Convert.ToInt16(unitComboBox.SelectedValue.ToString().Trim());
                requisition.IsEmargency = (emargencyCheckBox.Checked ? "Y" : "N");
            }

            int totalItems = 0;
            foreach (DataGridViewRow gridItem in storeReqDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {   
                    //Initialize a new PRR product
                    Product prrProduct = new Product();   
                 
                    if (IsEdit && (gridItem.Cells[8].Value != null && !string.IsNullOrEmpty(gridItem.Cells[8].Value.ToString())))
                    {                        
                        prrProduct.PID = requisition.Items[gridItem.Cells[8].Value.ToString()].PID;
                        prrProduct.StockQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                        prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                        prrProduct.Remarks = gridItem.Cells[6].Value.ToString().Trim();
                        prrProduct.Condition = "2";
                        requisition.Items[gridItem.Cells[8].Value.ToString().Trim()] = prrProduct;
                    }
                    else
                    {
                        prrProduct.PCode = gridItem.Cells[7].Value.ToString().Trim();
                        prrProduct.StockQty = Convert.ToDecimal(gridItem.Cells[4].Value.ToString().Trim());
                        prrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                        prrProduct.Remarks = (gridItem.Cells[6].Value == null ? string.Empty : gridItem.Cells[6].Value.ToString().Trim());
                        requisition.Items.Add(gridItem.Cells[7].Value.ToString().Trim(),prrProduct);     
                    }
                    totalItems++;               
                }
            }

            requisition.TotalItem = totalItems;
            if (IsEdit)
            {
                requisition.PrrNo = reqToEdit;
                requisition.Condition = "2";
            }
        }


        private void sCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sCategoryComboBox.SelectedIndex >= 0)
            {
                switch (sCategoryComboBox.Text.Trim().ToUpper())
                {
                    case "COMPUTER":
                        fillControl.fillCombo(timePeriodComboBox, masterManager.GetTimePeriod("2", "2"), "Period", "Code");
                        break;
                    default:
                        fillControl.fillCombo(timePeriodComboBox, masterManager.GetTimePeriod("1", "1"), "Period", "Code");
                        break;
                }
                //fill the items below the reorder level
                ShowRequiredItem("2", sCategoryComboBox.SelectedValue.ToString().Trim());

                timePeriodComboBox.SelectedIndex = -1;

                ShowItems();
            }
        }

        private void ShowItems()
        {
            try
            {
                if (sCategoryComboBox.SelectedIndex > -1)
                {
                    //unset the item combo event
                    this.itemComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemComboBox_SelectedIndexChanged);

                    fillControl.fillCombo(itemComboBox, masterManager.GetItemCategoryList("2", sCategoryComboBox.SelectedValue.ToString().Trim()), "Category", "Code");
                    itemComboBox.SelectedIndex = -1;

                    itemCategoryComboBox.DataSource = null;
                    itemCategoryComboBox.Items.Clear();
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

                    fillControl.fillCombo(itemCategoryComboBox, masterManager.GetItemSubCategoryList("3", itemComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
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
                fillControl.fillListView(itemListView, masterManager.GetItemList("3", itemCategoryComboBox.SelectedValue.ToString()), "Item,,,,", "317,,,,");
            }
            catch
            {
                itemListView.Items.Clear();
            }
        } 

        //private void yearTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\x08\x2E\d]"))
        //    {
        //        e.Handled = true;
        //    }

        //    if (e.KeyChar == 46)
        //    {
        //        if ((sender as TextBox).Text.Contains("."))
        //            e.Handled = true;
        //    }  
        //}

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void storeReqDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        private void ClearAllFields()
        {
            sCategoryComboBox.SelectedIndex = -1;
            timePeriodComboBox.SelectedIndex = -1;
            unitComboBox.SelectedIndex = -1;
            yearComboBox.Text = DateTime.Now.Year.ToString().Trim();
            storeReqDataGridView.Rows.Clear();
            consumpLabel.Text = "";
            consumpLabel.BackColor = Color.FromArgb(148, 161, 169);
            consumpListView.Items.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        int newRow = storeReqDataGridView.Rows.Add();
                        storeReqDataGridView.Rows[newRow].Cells[1].Value = item.Text.Trim();
                        storeReqDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
                        storeReqDataGridView.Rows[newRow].Cells[4].Value = (Convert.ToDecimal(item.SubItems[2].Text.Trim()) <= 0 ? "0" : item.SubItems[2].Text.Trim());
                        storeReqDataGridView.Rows[newRow].Cells[7].Value = item.SubItems[4].Text.Trim();                        
                    }
                    item.Remove();
                }
            }
        }

        //wheather the item already exists or not
        private bool itemExist(string code)
        {
            if (storeReqDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in storeReqDataGridView.Rows)
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

        private void storeReqDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string goodsID, goodsName;
            try
            {
                goodsID = storeReqDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                goodsName = storeReqDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                
                ShowItemConsumotion(goodsID, goodsName);
            }
            catch
            {
                consumpLabel.BackColor = Color.FromArgb(148, 161, 169);
                consumpListView.Items.Clear();
            }
        } 

        private void storeReqDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {               
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (storeReqDataGridView.Rows[e.RowIndex].Cells[8].Value != null && requisition.Items.ContainsKey(storeReqDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString().Trim()))
                        {
                            Product deletedItem = (Product)requisition.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString().Trim()];
                            deletedItem.Condition = "3";
                            requisition.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString().Trim()] = deletedItem;
                        }
                        storeReqDataGridView.Rows.RemoveAt(e.RowIndex);
                        break;
                    case 7:
                        
                        break;
                }                
            }
            catch
            {
            }
        }

        private void ShowItemConsumotion(string goodID,string item)
        {
            consumpLabel.Text = "Last 6 months consumption of : " + Environment.NewLine + item.Trim();
            consumpLabel.BackColor = Color.FromArgb(64, 64, 64);
            fillControl.fillListView(consumpListView, masterManager.GetItemList("31", goodID.Trim()), "Month,Consumption", "90,125");
        }

        private void storeReqDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (storeReqDataGridView.CurrentRow != null)
            {
                if (storeReqDataGridView.CurrentCell.ColumnIndex == 5 )
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

        private void emargencyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (emargencyCheckBox.Checked)
            {
                IsEmargency = true;
            }
            else
            {
                IsEmargency = false;
            }
        }

               
        
    }
}
