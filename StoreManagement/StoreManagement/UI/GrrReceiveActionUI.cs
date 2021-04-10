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
using System.Globalization;

namespace StoreManagement.UI
{
    public partial class GrrReceiveActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private GRRManager grrManager = null;
            private StoreManager storeManager = null;
            private GRR grr = null;
            private string orderNo = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public GrrReceiveActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            grrManager = new GRRManager();
            monthYearConvert = new MonthYearConvertion();
            storeManager = new StoreManager();
        }

        private void GrrReceiveListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the months
            fillControll.FillMonth(monthComboBox);

            ShowList();
        }

        private void ShowList()
        {
            orderNo = null;
            switch (grrTabControl.SelectedIndex)
            {
                case 0:
                    taskPane1.Visible = false;                    
                    fillControll.fillListView(pendingOrdersListView, grrManager.GetGRRList("1", null), "Order No.,Order Date,Supplier,Total Item,", "100,80,180,100,");

                    //fill the pending grr new or verified
                    fillControll.fillListView(grrListView, grrManager.GetGRRList("33", null), "GRR No., GRR Date, Challan No., Challan Date, Total Item,Status,", "80,100,100,100,80,120,");

                    ColorListView();
                    break;
                case 1:
                    taskPane1.Visible = true;
                    fillControll.fillListView(completeListView, grrManager.GetGRRList("4", null), "GRR No., GRR Date, Challan No., Challan Date, Total Item,,,Order No", "100,100,100,100,100,,,120");
                    break;
            }
        }

        private void ColorListView()
        {
            try
            {
                if (grrListView.Items.Count > 0)
                {
                    foreach (ListViewItem lstItem in grrListView.Items)
                    {
                        //grrListView.Columns[1].TextAlign = HorizontalAlignment.Center;
                        
                        lstItem.UseItemStyleForSubItems = false;
                        if (lstItem.SubItems[5].Text.Trim().ToUpper() == "NEW")
                        {
                            lstItem.ForeColor = Color.Yellow;

                            lstItem.BackColor = Color.Red;
                            lstItem.Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            lstItem.SubItems[5].ForeColor = Color.Yellow;
                            lstItem.SubItems[5].BackColor = Color.Red;
                            lstItem.SubItems[5].Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        else
                        {
                            lstItem.ForeColor = Color.Yellow;
                            lstItem.BackColor = Color.Green;
                            lstItem.Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            lstItem.SubItems[5].ForeColor = Color.Yellow;
                            lstItem.SubItems[5].BackColor = Color.Green;
                            lstItem.SubItems[5].Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                    }
                }
            }
            catch { }
        }

        private void grrTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowList();
        }

        private void pendingOrdersListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingOrdersListView.SelectedIndices.Count > 0)
            {
                new GRREntryUI(pendingOrdersListView.Items[pendingOrdersListView.SelectedIndices[0]].SubItems[4].Text.Trim(),true,false).ShowDialog();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (pendingOrdersListView.SelectedIndices.Count > 0)
            {
                orderNo = pendingOrdersListView.Items[pendingOrdersListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                new GRREntryUI(orderNo, true, false).ShowDialog();
                ShowGrr();
            }
            else
            {
                MessageBox.Show("Select a Order No.");
            }
        }

        private void pendingOrdersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingOrdersListView.SelectedIndices.Count > 0)
            {
                orderNo = pendingOrdersListView.Items[pendingOrdersListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                ShowGrr();
            }
        }

        private void ShowGrr()
        {
            switch (grrTabControl.SelectedIndex)
            {
                case 0:
                    grrGroupBox.Text = "Pending GRR list of Order No. : " + orderNo ;
                    grrDetailListView.Items.Clear();

                    stockPostButton.Enabled = false;
                    stockPostButton.BackColor = Color.FromArgb(87, 130, 176);
                    
                    if (orderNo != null && !string.IsNullOrEmpty(orderNo.Trim()))
                    {
                        //fill the order total received qty
                        fillControll.fillListView(orderDetailListView, grrManager.GetGRRList("2", orderNo), "Code, Item,Unit,Ordered Qty,Total Received", "100,180,70,100,120");

                        //fill the pending grr of selected order
                        fillControll.fillListView(grrListView, grrManager.GetGRRList("3", orderNo), "GRR No., GRR Date, Challan No., Challan Date, Total Item,Status,", "80,100,100,100,80,120,");

                        ColorListView();
                    }
                    else
                    {
                        //fill the pending grr of selected order
                        fillControll.fillListView(grrListView, grrManager.GetGRRList("33", null), "GRR No., GRR Date, Challan No., Challan Date, Total Item,Status,", "80,100,100,100,100,100,");
                    }
                    break;
                case 1:
                    completeGroupBox.Text = "GRR No. : " + orderNo + " detail";
                    fillControll.fillListView(cDetailListView, grrManager.GetGRRList("5", orderNo), "Item, Ordered,Qty Bfr Inspection,Qty Aft Inspection,Remark", "180,80,100,100,150");
                    break;
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                orderNo = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                ShowGrr();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //clear the tab one all group box tex and detail listview
            orderDetailListView.Items.Clear();
            grrListView.Items.Clear();
            grrDetailListView.Items.Clear();

            grrGroupBox.Text = "";
            grrDetailGroupBox.Text = "";

            cDetailListView.Items.Clear();
            completeGroupBox.Text = "";
            stockPostButton.Enabled = false;
            stockPostButton.BackColor = Color.FromArgb(87, 130, 176);
            ShowList();
        }

        private void grrListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grrListView.SelectedIndices.Count > 0)
            {
                editButton.Visible = true;                
                fillControll.fillListView(grrDetailListView, grrManager.GetGRRList("5", grrListView.Items[grrListView.SelectedIndices[0]].Text.Trim()), "Item, Ordered,Qty Bfr Inspection,Qty Aft Inspection,Remark", "250,80,100,100,150");
                int mthNumber = storeManager.GetStoreClosingMonth("1");
                string yearMonth = monthYearConvert.getMonthYear("2", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber).Trim(), DateTime.Now.ToString("yyyy").Trim());
                if (grrListView.Items[grrListView.SelectedIndices[0]].SubItems[6].Text.Trim() == "2")
                {
                    string grrDate = grrListView.Items[grrListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                    grrDate = grrDate.Substring(6, 4) + grrDate.Substring(3, 2);

                    if (yearMonth.Trim() == grrDate.Trim())
                    {
                        stockPostButton.Enabled = true;
                        stockPostButton.BackColor = Color.FromArgb(64, 64, 64);
                    }
                }
                else
                {
                    stockPostButton.Enabled = false;
                    stockPostButton.BackColor = Color.FromArgb(87, 130, 176);
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (grrListView.SelectedIndices.Count > 0)
            {
                new GRREntryUI(grrListView.Items[grrListView.SelectedIndices[0]].Text.Trim(),true,true).ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a GRR from list");
            }
        }

        private void stockPostButton_Click(object sender, EventArgs e)
        {
            if (grrListView.SelectedIndices.Count > 0)
            {
                if (grrListView.Items[grrListView.SelectedIndices[0]].SubItems[6].Text.Trim() == "2")
                {
                    if(grr == null)
                    {
                        grr = new GRR();
                    }
                    grr.GrrId = Convert.ToInt64(grrListView.Items[grrListView.SelectedIndices[0]].Text.Trim());
                    if (grrManager.GrrToStock(grr))
                    {
                        MessageBox.Show("Saved successfully");

                        grrDetailListView.Items.Clear();
                        ShowGrr();
                        //orderNo = null;
                    }
                    else
                    {
                        MessageBox.Show("Failed to save");
                    }
                    grr = null;
                }
            }
            else
            {
                MessageBox.Show("Select a GRR from list");
            }
        }


        #region Search

        private void ShowSearchData(string choice, string condition1, string condition2)
        {
            DataTable dt = null;
            orderDetailListView.Items.Clear();
            try
            {
                dt = grrManager.GetGrrReport(choice, condition1, condition2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fillControll.fillListView(completeListView, dt, "GRR No., GRR Date, Challan No., Challan Date, Total Item,,", "100,100,100,100,100,,");
                }
                else
                {
                    completeListView.Items.Clear();
                    MessageBox.Show("No data found");
                }

            }
            catch (Exception ex)
            {
                completeListView.Items.Clear();
                MessageBox.Show(ex.ToString());
            }
        }

        private void grrInaMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("1", monthYearConvert.getMonthYear("2",monthComboBox.Text.Trim(),yearPicker.Text.Trim()), null);
            }
        }

        private void supplierWiseInaMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("2", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
                fillControll.BuildGroups(5, completeListView, false);
            }
        }

        private void monthWiseGrrsInaYearTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("3", monthYearConvert.getMonthYear("3", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
                fillControll.BuildGroups(6, completeListView, false);
            }
        }
        
        #endregion
       
    }
}
