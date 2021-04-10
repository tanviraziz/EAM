using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.UTILITY;
using StoreManagement.Properties;
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class UserSRREntryUI : Form
    {
        #region Veriables
        #region form animation
        //Constants---------------------------------------------------------------
        const int AW_CENTER = 0X10;
        const int AW_HIDE = 0X10000;
        const int AW_ACTIVATE = 0X20000;
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_VER_POSITIVE = 0X4;
        const int AW_VER_NEGATIVE = 0X8;

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        //s------------------------------------------------------------------------
        #endregion

            private DynamicControlFill fillControl = null;
            private MasterSetupManager settingsManager = null;
            private SRRManager requisitionManager = null;
            private bool IsEdit = false,IsUserOrDeptAuthority = true;
            private SRR srr = null;
            private string srrToEdit;

        #endregion


        public UserSRREntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public UserSRREntryUI(bool UserOrDeptAuthority,string srrID): this()
        {
            IsEdit = true;
            srrToEdit = srrID;
            IsUserOrDeptAuthority = UserOrDeptAuthority;
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
            requisitionManager = new SRRManager();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserSRREntryUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            ChangeView();
            
            //Start:sliding animation for the form 
            AnimateWindow(this.Handle, 400, AW_SLIDE | AW_VER_POSITIVE);
            //End:sliding animation for the form 

            //Start:Fill the Combos

            fillControl.fillCombo(departmentComboBox, settingsManager.GetDepartmentList("4", null), "Department", "Code");
            departmentComboBox.SelectedIndex = -1;

            fillControl.fillCombo(stationaryComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            stationaryComboBox.SelectedIndex = -1;

            //Set Events
            //Set the department combo event
            this.departmentComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentComboBox_SelectedIndexChanged);
                
            //set the stationary combo event
            this.stationaryComboBox.SelectedIndexChanged += new System.EventHandler(this.stationaryComboBox_SelectedIndexChanged);

            //Start:Fill the Combos

            if (IsEdit)
            {
                FillData();
            }

            
        }

        private void ChangeView()
        {
            if (IsUserOrDeptAuthority)
            {
                storeReqDataGridView.Columns[4].Visible = false;
                storeReqDataGridView.Columns[6].Visible = false; 
            }
            else
            {
                storeReqDataGridView.Columns[4].Visible = true;
                storeReqDataGridView.Columns[6].Visible = true; 
            }
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptCodeLabel.Text = (departmentComboBox.SelectedValue != null ? departmentComboBox.SelectedValue.ToString().Split('-')[1].Trim() : "");
        }

        //fill the requisiton detail when edit
        private void FillData()
        {
            if (IsUserOrDeptAuthority)
            {
                headerLabel.Text = "Edit Store Requisition : " + srrToEdit;
            }
            else
            {
                headerLabel.Text = "Approved Store Requisition : " + srrToEdit;
            }

            DataTable requisitionDT;
            try
            {
                int n;
                if (IsUserOrDeptAuthority)
                {
                    requisitionDT = requisitionManager.GetUserSRRList("3", srrToEdit, null);
                }
                else
                {
                    requisitionDT = requisitionManager.GetAuthoritySRRList("3", srrToEdit, null);
                }
                if (srr == null)
                {
                    srr = new SRR();
                }

                if (requisitionDT.Rows.Count > 0)
                {
                    departmentComboBox.Text = requisitionDT.Rows[0]["Department"].ToString();
                    deptCodeLabel.Text = requisitionDT.Rows[0]["DeptCode"].ToString();
                    purposeTextBox.Text = requisitionDT.Rows[0]["Purpose"].ToString();
                    requisitionDate.Value = Convert.ToDateTime(requisitionDT.Rows[0]["ReqDate"]);

                    foreach (DataRow dr in requisitionDT.Rows)
                    {
                        n = storeReqDataGridView.Rows.Add();
                        storeReqDataGridView.Rows[n].Cells[1].Value = (n+1).ToString();
                        storeReqDataGridView.Rows[n].Cells[2].Value = dr["Item"].ToString();
                        storeReqDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                        storeReqDataGridView.Rows[n].Cells[4].Value = (Convert.ToDecimal(dr["Stock"].ToString()) <= 0 ? "0" : dr["Stock"].ToString());
                        storeReqDataGridView.Rows[n].Cells[5].Value = dr["Required"].ToString();
                        storeReqDataGridView.Rows[n].Cells[6].Value = dr["Issued"].ToString();
                        storeReqDataGridView.Rows[n].Cells[7].Value = dr["Remarks"].ToString();
                        storeReqDataGridView.Rows[n].Cells[9].Value = dr["Code"].ToString();
                        storeReqDataGridView.Rows[n].Cells[11].Value = dr["SrrDetailID"].ToString();

                        //fill the invoice items in dictionary
                        Product srrItem = new Product();
                        srrItem.ReqQty = Convert.ToDecimal((string.IsNullOrEmpty(dr["Required"].ToString()) ? "0" :dr["Required"].ToString()));
                        srrItem.IssueQty = Convert.ToDecimal((string.IsNullOrEmpty(dr["Issued"].ToString()) ? "0" : dr["Issued"].ToString()));
                        srrItem.Remarks = dr["Remarks"].ToString();
                        srrItem.PCode = dr["Code"].ToString();
                        srrItem.PID = dr["SrrDetailID"].ToString();
                        srr.Items.Add(dr["SrrDetailID"].ToString().Trim(), srrItem);                        
                    }                    
                }
            }
            catch 
            {
                IsEdit = false;
            }
        }

        private void stationaryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowItems();
        }

        private void ShowItems()
        {
            try
            {
                if (stationaryComboBox.SelectedIndex > -1)
                {
                    //unset the item combo event
                    this.itemComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemComboBox_SelectedIndexChanged);

                    fillControl.fillCombo(itemComboBox, settingsManager.GetItemCategoryList("2", stationaryComboBox.SelectedValue.ToString().Trim()), "Category", "Code");
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

                    fillControl.fillCombo(itemCategoryComboBox, settingsManager.GetItemSubCategoryList("3", itemComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
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
                fillControl.fillListView(itemListView, settingsManager.GetItemList("3", itemCategoryComboBox.SelectedValue.ToString()), "Item,,,,", "317,,,,");
            }
            catch
            {
                itemListView.Items.Clear();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (requisitionManager.SRRManagement(srr))
                {
                    MessageBox.Show("Requisition no. - " + Common.ReqNo + " saved successfully");
                    if (IsEdit)
                    {
                        srr = null;
                        this.Close();
                    }
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to save");
                }
            }
            
            srr = null;
        }

        private bool IsValid()
        {
            try
            {
                if (IsUserOrDeptAuthority && string.IsNullOrEmpty(departmentComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select a department.");
                    departmentComboBox.Focus();
                    return false;
                }
                else if (IsUserOrDeptAuthority && string.IsNullOrEmpty(purposeTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enate a requisition purpose.");
                    purposeTextBox.Focus();
                    return false;
                }
                else if (IsUserOrDeptAuthority && storeReqDataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Enate a requisition item.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (IsUserOrDeptAuthority && CheckRequisition("5"))
                {
                    MessageBox.Show("Fill all requisition quantity.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (!IsUserOrDeptAuthority &&  CheckRequisition("6"))
                {
                    MessageBox.Show("Fill all issue quantity.");
                    storeReqDataGridView.Focus();
                    return false;
                }
                else if (!IsUserOrDeptAuthority && CheckRequisition("4"))
                {
                    MessageBox.Show("issue quantity exceed stock limit.");
                    storeReqDataGridView.Focus();
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
            if (srr == null)
            {
                srr = new SRR();
            }
            srr.SRRDate = requisitionDate.Value;
            srr.DeptUID = Convert.ToInt32(departmentComboBox.SelectedValue.ToString().Split('-')[0].Trim());
            srr.Purpose = purposeTextBox.Text.Trim();

            foreach (DataGridViewRow gridItem in storeReqDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    Product srrProduct = new Product();
                    srrProduct.ReqQty = Convert.ToDecimal(gridItem.Cells[5].Value.ToString().Trim());
                    srrProduct.Remarks = (gridItem.Cells[7].Value == null ? null : gridItem.Cells[7].Value.ToString().Trim());

                    if (IsEdit && (gridItem.Cells[11].Value != null && !string.IsNullOrEmpty(gridItem.Cells[11].Value.ToString())))
                    {
                        srrProduct.PCode = srr.Items[gridItem.Cells[11].Value.ToString().Trim()].PCode;
                        srrProduct.PID = srr.Items[gridItem.Cells[11].Value.ToString().Trim()].PID;
                        if (IsUserOrDeptAuthority)
                        {
                            srrProduct.Condition = "5";
                        }
                        else
                        {
                            srrProduct.IssueQty = Convert.ToDecimal(gridItem.Cells[6].Value.ToString().Trim());
                            srrProduct.Condition = "6";
                        }
                        srr.Items[gridItem.Cells[11].Value.ToString().Trim()] = srrProduct;                        
                    }
                    else
                    {
                        //srrProduct.UnitPrice = Convert.ToDecimal((string.IsNullOrWhiteSpace(gridItem.Cells[8].Value.ToString()) ? "0" : gridItem.Cells[8].Value.ToString().Trim()));
                        srrProduct.PCode = gridItem.Cells[9].Value.ToString().Trim();
                        srrProduct.StationaryID = Convert.ToInt16(gridItem.Cells[10].Value.ToString().Trim());
                        srrProduct.Condition = "4";
                        srr.Items.Add(gridItem.Cells[9].Value.ToString().Trim(), srrProduct);
                    }
                }
            }

            if (IsEdit)
            {
                srr.SRRID = Convert.ToInt64(srrToEdit.Trim());

                if (IsUserOrDeptAuthority)
                {
                    srr.Condition = "3";
                }
                else
                {
                    srr.Condition = "6";
                }
            }
            
        }        
            
        private bool haveNoItem()
        {
            try
            {
                if (storeReqDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in storeReqDataGridView.Rows)
                    {
                        if ((bool)dgRow.Cells[1].Value == true)
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return true;
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
                                break;
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
            try
            {
                foreach (ListViewItem item in itemListView.Items)
                {
                    if (item.Checked)
                    {
                        if (!itemExist(item.SubItems[3].Text.Trim()))
                        {
                            int newRow = storeReqDataGridView.Rows.Add();
                            storeReqDataGridView.Rows[newRow].Cells[1].Value = newRow + 1;
                            storeReqDataGridView.Rows[newRow].Cells[2].Value = item.Text.Trim();
                            storeReqDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
                            storeReqDataGridView.Rows[newRow].Cells[4].Value = item.SubItems[2].Text.Trim();
                            storeReqDataGridView.Rows[newRow].Cells[8].Value = item.SubItems[3].Text.Trim();
                            storeReqDataGridView.Rows[newRow].Cells[9].Value = item.SubItems[4].Text.Trim();
                            storeReqDataGridView.Rows[newRow].Cells[10].Value = stationaryComboBox.SelectedValue.ToString().Trim();
                        }
                        item.Remove();
                    }
                }
            }
            catch { }
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
                        if (row.Cells[9].Value.ToString().Trim().ToUpper() == code.ToUpper())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void storeReqDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        private void storeReqDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (storeReqDataGridView.CurrentRow != null)
            {
                if (storeReqDataGridView.CurrentCell.ColumnIndex == 5 || storeReqDataGridView.CurrentCell.ColumnIndex == 6)
                {
                    txtEdit.KeyPress += IsNumber_Keypress;
                }
                else if (storeReqDataGridView.CurrentCell.ColumnIndex == 7)
                {
                    txtEdit.KeyPress += IsText_Keypress;
                }
            }
        }

        private void IsNumber_Keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //if (checkRequiredField(Convert.ToInt32(storeReqDataGridView.CurrentCell.ColumnIndex)))
            //{
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\x08\x2E\d]"))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
            }
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void IsText_Keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //if (checkRequiredField(Convert.ToInt32(storeReqDataGridView.CurrentCell.ColumnIndex)))
            //{
                e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private bool checkRequiredField(int cellNo)
        {
            switch (cellNo)
            {
                case 6:
                    if (storeReqDataGridView.CurrentRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Enter required qty.");
                        storeReqDataGridView.CurrentRow.Cells[5].Selected = true;
                        storeReqDataGridView.Focus();
                        return false;
                    }
                    break;
                case 7:
                    if (storeReqDataGridView.CurrentRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Enter required qty.");
                        storeReqDataGridView.CurrentRow.Cells[5].Selected = true;
                        return false;
                    }
                    else if (storeReqDataGridView.CurrentRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Enter issue qty.");
                        storeReqDataGridView.CurrentRow.Cells[5].Selected = true;
                        return false;
                    }
                    break;
            }
            return true;
        }      

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            departmentComboBox.SelectedIndex = -1;
            deptCodeLabel.Text = "";
            purposeTextBox.Clear();
            requisitionDate.Value = DateTime.Now;
            stationaryComboBox.SelectedIndex = -1;
            itemComboBox.SelectedIndex = -1;
            itemCategoryComboBox.SelectedIndex = -1;
            itemListView.Items.Clear();
            storeReqDataGridView.Rows.Clear();
        }

        private void storeReqDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (storeReqDataGridView.Rows[e.RowIndex].Cells[11].Value != null && srr.Items.ContainsKey(storeReqDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString().Trim()))
                    {
                        Product deletedItem = (Product)srr.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString().Trim()];
                        deletedItem.Condition = "3";
                        srr.Items[storeReqDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString().Trim()] = deletedItem;
                    }
                    storeReqDataGridView.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }

        
    }
}
