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
    public partial class PurchaseTenderFinalizeActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControl = null;
            private PurchaseManager tenderManager = null;
            private string reqNO;
            private Requisition approvedTender = null;
            private Dictionary<string,ListViewItem> listViewItem = new Dictionary<string,ListViewItem>();
            private bool IsPurchaseOrMIS = true;
        #endregion

        public PurchaseTenderFinalizeActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseTenderFinalizeActionUI(bool PurchaseOrMIS):this()
        {
            IsPurchaseOrMIS = PurchaseOrMIS;
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            tenderManager = new PurchaseManager();
            approvedTender = new Requisition();
        }

        private void PurchaseTenderFinalizeActionUI_Load(object sender, EventArgs e)
        {
            ShowTenderList();
        }

        private void ShowTenderList()
        {
            if (IsPurchaseOrMIS)
            {
                fillControl.fillListView(pendingRequisitionListView, tenderManager.GetPurchaseTenderList("1", null), "Req No.,Req Date,Requisition For,Total Item", "100,100,150,100", true);
            }
            else
            {
                fillControl.fillListView(pendingRequisitionListView, tenderManager.GetPurchaseTenderList("2", null), "Req No.,Req Date,Requisition For,Total Item", "100,100,150,100", true);
            }
        }

        private void pendingRequisitionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenderDataGridView.Rows.Clear();            
            try
            {
                if (pendingRequisitionListView.SelectedIndices.Count > 0)
                {
                    if (listViewItem.Count > 0)
                    {
                        listViewItem.Clear();
                    }

                    this.requisitionDetailListView.ItemChecked -= new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);

                    reqNO = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].Text;

                    //START : Requisition Detail
                    reqNoLabel.Text = reqNO;
                    reqDateLabel.Text = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].SubItems[1].Text;
                    reqForLabel.Text = pendingRequisitionListView.Items[pendingRequisitionListView.SelectedIndices[0]].SubItems[2].Text;
                    totalItemLabel.Text = "";
                    //End : Requisition Detail

                    requisitionDetailsGroupBox.Text = "Price Comparative of Requisition no. : " + reqNO;

                    //fill the Tender comparative
                    DataTable dt = tenderManager.GetPurchaseTenderList("8", reqNO);
                    fillControl.fillListView(requisitionDetailListView, dt, "Supplier,Unit Price,,,,,", "210,80,,,,,", false);
                    fillControl.BuildGroups(6, requisitionDetailListView, false);
                    
                    //DataTable dt1 = new DataTable();
                    //query.ToList().ForEach(row => dt.Rows.Add(row));

                    fillControl.fillListView(supplierLowestListView, getDT(dt), "Item,Unit Price,,", "210,80,,", 3,"1");
                    fillControl.BuildGroups(2, supplierLowestListView, false);

                    ColorLowestPriceSupplier();

                    this.requisitionDetailListView.ItemChecked += new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);
                }
            }
            catch { }
        }

        private DataTable getDT(DataTable pdt)
        {
            DataTable dt = null;

            var query = from dRow in pdt.AsEnumerable()
                        orderby dRow.Field<string>("Name"), dRow.Field<string>("Lowest") descending
                        select new
                        {
                            Description = dRow.Field<string>("Description").ToString(),
                            Rate = dRow.Field<decimal>("Rate").ToString(),
                            GoodsID = dRow.Field<Int64>("GoodsID").ToString(),
                            ptid = dRow.Field<Int64>("ptid").ToString(),
                            PTDId = dRow.Field<Int64>("PTDId").ToString(),
                            Lowest = dRow.Field<string>("Lowest").ToString(),
                            Name = dRow.Field<string>("Name").ToString()
                        };

            if (query.ToList().Count() > 0)
            {
                dt =new DataTable();
                dt.Columns.Add("Item", typeof(string));
                dt.Columns.Add("Rate", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Lowest", typeof(string));

                foreach (var item in query)
                {
                    dt.Rows.Add(new object[] { item.Description, item.Rate, item.Name, item.Lowest });
                }
            }

            return dt;
        }

        private void ColorLowestPriceSupplier()
        {
            int n;
            if (requisitionDetailListView.Items.Count > 0)
            {
                foreach (ListViewItem item in requisitionDetailListView.Items)
                {
                    switch (item.SubItems[5].Text.Trim())
                    {
                        case "1":
                            listViewItem.Add(item.SubItems[4].Text.Trim(), item);

                            n = tenderDataGridView.Rows.Add();
                            tenderDataGridView.Rows[n].Cells[1].Value = item.SubItems[6].Text.Trim();
                            tenderDataGridView.Rows[n].Cells[2].Value = item.Text.Trim();
                            tenderDataGridView.Rows[n].Cells[3].Value = item.SubItems[1].Text.Trim();
                            tenderDataGridView.Rows[n].Cells[4].Value = item.SubItems[4].Text.Trim();                            
                            break;
                    }
                }
                ColorItems();
            }
        }

        private void ColorItems()
        {
            foreach (var li in listViewItem)
            {
                ListViewItem item = li.Value;
                ColorRow(item,true);                
            }
        }

        private void ColorRow(ListViewItem item,bool flag)
        {
            if (flag)
            {
                item.BackColor = Color.FromArgb(87, 130, 176);
                item.ForeColor = Color.White;
                item.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                item.Checked = true;
            }
            else
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
                item.Font = new Font("Tahoma", 9F, FontStyle.Regular);
                item.Checked = false;
            }
        }

        private void tenderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.requisitionDetailListView.ItemChecked -= new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);

                    ColorRow(listViewItem[tenderDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim()], false); 
                    listViewItem.Remove(tenderDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                    tenderDataGridView.Rows.RemoveAt(e.RowIndex);

                    this.requisitionDetailListView.ItemChecked += new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);
                    break;
            }
        }

        private void tenderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Image img = Resources.close;
                e.Value = img;
            }
        }

        private void requisitionDetailListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;

            if (item != null)
            {
                if (item.Checked)
                {
                    int n = tenderDataGridView.Rows.Add();
                    tenderDataGridView.Rows[n].Cells[1].Value = item.SubItems[6].Text.Trim();
                    tenderDataGridView.Rows[n].Cells[2].Value = item.Text.Trim();
                    tenderDataGridView.Rows[n].Cells[3].Value = item.SubItems[1].Text.Trim();
                    tenderDataGridView.Rows[n].Cells[4].Value = item.SubItems[4].Text.Trim();

                    listViewItem.Add(item.SubItems[4].Text.Trim(), item);
                    ColorRow(item, true);
                }
                else
                {
                    RemoveFromGrid(item.SubItems[4].Text.Trim());
                    ColorRow(item, false);
                }
            }    
        }

        private void RemoveFromGrid(string item)
        {
            foreach (DataGridViewRow dgRow in tenderDataGridView.Rows)
            {
                if (dgRow.Cells[4].Value.ToString().Trim() == item.Trim())
                {
                    tenderDataGridView.Rows.RemoveAt(dgRow.Index);
                    listViewItem.Remove(dgRow.Cells[4].Value.ToString().Trim());
                }  
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (tenderManager.TenderApprovalManagement(approvedTender))
                {
                    MessageBox.Show("Saved successfully.");
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }
            }
            approvedTender = null;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(reqNoLabel.Text.Trim()))
            {
                MessageBox.Show("Select a requisition.");
                pendingRequisitionListView.Focus();
                return false;
            }
            else if (tenderDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("There is no quotation yet.");
                tenderDataGridView.Focus();
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
            if (approvedTender == null)
            {
                approvedTender = new Requisition();
            }

            approvedTender.PrrNo = reqNO;
            approvedTender.Condition = "3";

            int totalItem = 0;

            foreach (DataGridViewRow gridItem in tenderDataGridView.Rows)
            {
                if (gridItem.Cells[4].Value != null)
                {
                    //enter new data
                    //Initialize a new Tender product
                    Product tenderProduct = new Product();

                    tenderProduct.PID = gridItem.Cells[4].Value.ToString().Trim();
                    tenderProduct.Condition = "4";

                    approvedTender.Items.Add(gridItem.Cells[4].Value.ToString().Trim(), tenderProduct);

                    totalItem++;
                }
            }

            approvedTender.TotalItem = totalItem;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            this.requisitionDetailListView.ItemChecked -= new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);
            requisitionDetailListView.Items.Clear();
            tenderDataGridView.Rows.Clear();

            ShowTenderList();

            reqNoLabel.Text = "";
            reqDateLabel.Text = "";
            reqForLabel.Text = "";
            totalItemLabel.Text = "";
            this.requisitionDetailListView.ItemChecked += new ItemCheckedEventHandler(this.requisitionDetailListView_ItemChecked);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void requisitionDetailListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        //{
        //    ListViewItem item = e.Item as ListViewItem;

        //    if (item != null)
        //    {
        //        if (item.Checked)
        //        {
        //            ColorRow(item, false);
        //            RemoveFromGrid(item.SubItems[4].Text.Trim());
        //        }
        //        else
        //        {
        //            int n = tenderDataGridView.Rows.Add();
        //            tenderDataGridView.Rows[n].Cells[1].Value = item.SubItems[6].Text.Trim();
        //            tenderDataGridView.Rows[n].Cells[2].Value = item.Text.Trim();
        //            tenderDataGridView.Rows[n].Cells[3].Value = item.SubItems[1].Text.Trim();
        //            tenderDataGridView.Rows[n].Cells[4].Value = item.SubItems[4].Text.Trim();
        //        }
        //    }
        //}

        //private void RemoveFromGrid(string item)
        //{
        //    foreach (DataGridViewRow dgRow in tenderDataGridView.Rows)
        //    {
        //        if (dgRow.Cells[4].Value.ToString().Trim() == item.Trim())
        //        {
        //            tenderDataGridView.Rows.RemoveAt(dgRow.Index);
        //        }
        //    }
        //}
    }
}
