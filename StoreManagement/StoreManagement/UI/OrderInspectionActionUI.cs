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
using StoreManagement.Reports.FSD;
using StoreManagement.Reports.Purchase.Order;

namespace StoreManagement.UI
{
    public partial class OrderInspectionActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private GRRManager orderManager = null;
            private MasterSetupManager settingsManager = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public OrderInspectionActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            orderManager = new GRRManager();
            settingsManager = new MasterSetupManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void OrderInspectionListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the months
            fillControll.FillMonth(monthComboBox);

            fillControll.fillCombo(supplierComboBox, settingsManager.GetSupplierList("3", null), "Supplier", "Code");

            ShowList();            
        }

        private void ShowList()
        {
            switch (inspectionTabControl.SelectedIndex)
            {
                case 0:
                    taskPane1.Visible = false;
                    addButton.Visible = false;
                    certificateButton.Visible = true;
                    printOrderButton.Visible = true;
                    fillControll.fillListView(pendingOrderListView, orderManager.GetOrderInspeectionList("1", null), "Order No.,Date,Supplier,Total Item,Toatal Received,", "100,100,250,100,100,");
                    ShowGRRs(null);
                    break;
                case 1:
                    taskPane1.Visible = true;
                    addButton.Visible = false;
                    certificateButton.Visible = false;
                    printOrderButton.Visible = false;
                    fillControll.fillListView(completeListView, orderManager.GetOrderInspeectionList("2", null), "Certificate No.,Order No.,Inspection Date,Supplier,Total Item,Toatal Received,", "100,100,100,250,100,,");
                    break;
            }
        }

        private void inspectionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowList();
        }
               

        private void addButton_Click(object sender, EventArgs e)
        {
            if (grrListView.SelectedIndices.Count > 0)
            {
                string selectedGRR = grrListView.Items[grrListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                new GRREntryUI(selectedGRR, false, true).ShowDialog();

                ShowGRRs(null);
                //ShowGRRDetails(selectedGRR);
            }
            else
            {
                MessageBox.Show("Select GRR from list.");
                grrListView.Focus();
            }
        }

        private void grrListView_DoubleClick(object sender, EventArgs e)
        {
            if (grrListView.SelectedIndices.Count > 0)
            {
                string selectedGRR = grrListView.Items[grrListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                new GRREntryUI(selectedGRR, false, true).ShowDialog();

                ShowGRRs(null);
                //ShowGRRDetails(selectedGRR);
            }            
        }


        private void certificateButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                new PurchaseOrderInspectionUI(pendingOrderListView.Items[pendingOrderListView.SelectedIndices[0]].SubItems[5].Text.Trim()).ShowDialog();
                ShowList();
            } 
        }

        private bool IsValid()
        {
            if (pendingOrderListView.SelectedIndices.Count < 0)
            {
                MessageBox.Show("Select an order.");
                pendingOrderListView.Focus();
                return false;
            }
            else if (!IsAllGrrVerified())
            {
                MessageBox.Show("Verify all pending GRR.");
                return false;
            }
            else if (!IsAllOrderQtyReceived())
            {
                if (MessageBox.Show("All ordered item not delivered yet, do you want to issue certificate? ", "Issue Certificate", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }                
            }
            return true;
        }

        private bool IsAllGrrVerified()
        {
            try
            {
                foreach (ListViewItem lstItem in grrListView.Items)
                {
                    if (lstItem.Text.Trim().ToUpper() == "NEW")
                    {
                        return false;
                    }
                }                
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool IsAllOrderQtyReceived()
        {
            try
            {
                foreach (ListViewItem lstItem in orderDetailListView.Items)
                {
                    if (Convert.ToInt32(lstItem.SubItems[2].Text.Trim()) > Convert.ToInt32(lstItem.SubItems[4].Text.Trim()))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void pendingOrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pendingOrderListView.SelectedIndices.Count > 0)
                {
                    string orderID = pendingOrderListView.Items[pendingOrderListView.SelectedIndices[0]].SubItems[5].Text.Trim();

                    orderDetailGroupBox.Text = "Order No. : " + pendingOrderListView.Items[pendingOrderListView.SelectedIndices[0]].Text.Trim() + " detail";
                    fillControll.fillListView(orderDetailListView, orderManager.GetOrderInspeectionList("3", orderID), "Item,Unit,Ord. Qty,Unit Price,Toatal Rec.,Total Value", "180,50,70,60,100,100");

                    ShowGRRs(orderID);

                    ColorOrderListView();
                    //clear the GRR details
                    grrDetailListView.Items.Clear();
                }
            }
            catch { }
        }

        private void ColorOrderListView()
        {
            try
            {
                if (orderDetailListView.Items.Count > 0)
                {
                    foreach (ListViewItem lstItem in orderDetailListView.Items)
                    {
                        //Align column 4 text to center
                        orderDetailListView.Columns[4].TextAlign = HorizontalAlignment.Center;
                        //set false to change cell forecolor and backcolor
                        lstItem.UseItemStyleForSubItems = false;
                        if (Convert.ToInt32(lstItem.SubItems[2].Text.Trim()) > Convert.ToInt32(lstItem.SubItems[4].Text.Trim()))
                        {
                            lstItem.SubItems[4].ForeColor = Color.White;
                            lstItem.SubItems[4].BackColor = Color.Green;
                            lstItem.Font = new Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        else
                        {
                            lstItem.SubItems[4].ForeColor = Color.Yellow;
                            lstItem.SubItems[4].BackColor = Color.Red;
                            lstItem.Font = new Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                    }
                }
            }
            catch { }
        }

        private void ShowGRRs(string orderID)
        {
            switch (inspectionTabControl.SelectedIndex)
            {
                case 0:
                    if (string.IsNullOrEmpty(orderID))
                    {
                        fillControll.fillListView(grrListView, orderManager.GetOrderInspeectionList("44", null), "Status,GRR No.,Received Date,Challan No,Challan Date,Toatal Item", "70,100,100,100,100,100");
                    }
                    else
                    {
                        if (pendingOrderListView.SelectedIndices.Count > 0)
                        {
                            grrGroupBox.Text = "Order No.: " + pendingOrderListView.Items[pendingOrderListView.SelectedIndices[0]].Text.Trim() + " all GRR list";
                        }
                        fillControll.fillListView(grrListView, orderManager.GetOrderInspeectionList("4", orderID), "Status,GRR No.,Received Date,Challan No,Challan Date,Toatal Item", "70,100,100,100,100,100");
                    }
                    ColorListView();
                    break;
                case 1:
                    cGrrGroupBox.Text = "Order No.: " + completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim() + " all GRR list";
                    fillControll.fillListView(cGrrListView, orderManager.GetOrderInspeectionList("5", orderID), "GRR No.,Received Date,Challan No,Challan Date,Toatal Item,Status", "100,100,100,100,100,120");
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
                        lstItem.UseItemStyleForSubItems = false;
                        if (lstItem.Text.Trim().ToUpper() == "NEW")
                        {
                            lstItem.ForeColor = Color.Red;
                            lstItem.Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        else
                        {
                            lstItem.ForeColor = Color.Green;
                            lstItem.Font = new Font("Tahoma", 10.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                    }
                }
            }
            catch { }
        }

        private void grrListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grrListView.SelectedIndices.Count > 0)
                {
                    addButton.Visible = true;
                    string selectedGRR = grrListView.Items[grrListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                    grrDetailGroupBox.Text = "GRR No.: " + selectedGRR + " detail";
                    ShowGRRDetails(selectedGRR);                   
                }
            }
            catch { }
        }

        private void ShowGRRDetails(string grrNo)
        {
            fillControll.fillListView(grrDetailListView, orderManager.GetOrderInspeectionList("6", grrNo), "Item, Stock,Ordered,Qty Bfr Inspection,Qty Aft Inspection,Remark", "250,100,80,100,100,150");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            orderDetailListView.Items.Clear();
            grrListView.Items.Clear();
            grrDetailListView.Items.Clear();

            orderDetailGroupBox.Text = "";
            grrGroupBox.Text = "";
            grrDetailGroupBox.Text = "";

            ShowList();
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (completeListView.SelectedIndices.Count > 0)
                {
                    string orderID = completeListView.Items[completeListView.SelectedIndices[0]].SubItems[6].Text.Trim();

                    cOrderDetailGroupBox.Text = "Order No. : " + completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim() + " detail";
                    fillControll.fillListView(cOrderDetailListView, orderManager.GetOrderInspeectionList("3", orderID), "Item,Unit,Ordered Qty,Unit Price,Toatal Received,Total Value", "180,50,70,60,100,100");

                    ShowGRRs(orderID);

                    //clear the GRR details
                    grrDetailListView.Items.Clear();
                }
            }
            catch { }

        }

        private void cGrrListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cGrrListView.SelectedIndices.Count > 0)
                {
                    cGrrDetailGroupBox.Text = "GRR No.: " + cGrrListView.Items[cGrrListView.SelectedIndices[0]].Text.Trim() + " detail";
                    fillControll.fillListView(cGrrDetailListView, orderManager.GetOrderInspeectionList("6", cGrrListView.Items[cGrrListView.SelectedIndices[0]].Text.Trim()), "Item, ,Ordered,Qty Bfr Inspection,Qty Aft Inspection,Remark", "250,,80,100,100,150");
                }
            }
            catch { }
        }

        

        #region Search

        private void ShowSearchData(string choice,string condition1, string condition2)
        {
            DataTable dt = null;
            orderDetailListView.Items.Clear();
            try
            {
                dt = orderManager.GetOrderInspectionReport(choice,condition1, condition2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fillControll.fillListView(completeListView, dt, "Certificate No.,Order No.,Inspection Date,Supplier,Total Item,Toatal Received,,", "100,100,100,250,100,,,");
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

        private void orderInaMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("1", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
            }
        }

        private void supplierWiseOrdInaMonthTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("2", monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
                fillControll.BuildGroups(3, completeListView, false);
            }
        }

        private void monthWiseOrdInaYearTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else
            {
                ShowSearchData("3", monthYearConvert.getMonthYear("3", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
                fillControll.BuildGroups(7, completeListView, false);
            }
        }

        private void supplierMonthWiseOrdInaYearTaskItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(monthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month");
                monthComboBox.Focus();
            }
            else if (string.IsNullOrEmpty(supplierComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a supplier");
                supplierComboBox.Focus();
            }
            else
            {
                ShowSearchData("4", monthYearConvert.getMonthYear("3", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), supplierComboBox.SelectedValue.ToString());
                fillControll.BuildGroups(7, completeListView, false);
            }
        }

        private void printCertificateTaskItem_Click(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                string certifcateID = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                ReportViwer reportViewer = new ReportViwer(orderManager.GetGRRCertificate("3", certifcateID), new FSDCertificateReport());
                reportViewer.Show();                
            }
            else
            {
                MessageBox.Show("Select a certificate from list");
            }
        }
        #endregion

        private void printOrderButton_Click(object sender, EventArgs e)
        {
            if (pendingOrderListView.SelectedIndices.Count > 0)
            {
                new ReportViwer(purchaseManager.GetPruchaseOrderPrint("1", pendingOrderListView.Items[pendingOrderListView.SelectedIndices[0]].SubItems[5].Text.Trim()), new PurOrderPrintReport()).ShowDialog();
            }
        }

        private void summeryNoteTskItem_Click(object sender, EventArgs e)
        {
            new SummeryNoteSettingsUI().ShowDialog();
        }

        
       

        

    }
}
