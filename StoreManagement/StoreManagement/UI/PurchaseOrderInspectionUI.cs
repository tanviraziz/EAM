using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.DAL.DAO;
using StoreManagement.BLL;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class PurchaseOrderInspectionUI : Form
    {
        #region Veriables
            private MasterSetupManager masterManager = null;
            private PurchaseManager purchaseManager = null;
            private GRRManager grrManager = null;
            private DynamicControlFill fillControl = null;
            private GRR grr = null;
            private bool IsEdit = false, IsCompleteOrPertial = true;
            private string PurchaseOrderID;
        #endregion

        public PurchaseOrderInspectionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public PurchaseOrderInspectionUI(string ordId):this()
        {
            PurchaseOrderID = ordId;
        }

        private void SetObjects()
        {
            masterManager = new MasterSetupManager();
            purchaseManager = new PurchaseManager();
            grrManager = new GRRManager();
            fillControl = new DynamicControlFill();
        }
        
        private void GRRInspectionUI_Load(object sender, EventArgs e)
        {
            //PurchaseOrderID = "101";
            SetUpdateData(PurchaseOrderID);

            fillControl.fillCombo(departmentComboBox, masterManager.GetDepartmentList("3", null), "Department", "Code");
            departmentComboBox.SelectedIndex = -1;

            fillControl.fillCombo(noteComboBox, masterManager.GetSummeryNoteList("3", null), "Note", "Code");
            noteComboBox.SelectedIndex = -1;

            fillControl.fillCombo(acceptanceComboBox, masterManager.GetInspecAcceptanceList("1", null), "Status", "Code");
            fillControl.fillCombo(remarksComboBox, masterManager.GetInspecAcceptanceList("2", null), "Status", "Code");
            this.remarksComboBox.SelectedIndexChanged += new System.EventHandler(this.remarksComboBox_SelectedIndexChanged);
        }

        private void SetUpdateData(string orderID)
        {
            DataTable purchaseOrder;
            purchaseOrder = grrManager.GetGRRCertificate("1", orderID);

            if (purchaseOrder.Rows.Count > 0)
            {
                supplierLabel.Text = purchaseOrder.Rows[0]["Supplier"].ToString();
                purchaseOrderLabel.Text = purchaseOrder.Rows[0]["orderNo"].ToString();
                purOrdDateLabel.Text = purchaseOrder.Rows[0]["orderDate"].ToString();
                challanLabel.Text = purchaseOrder.Rows[0]["ChallanNo"].ToString();
                challanDateLabel.Text = purchaseOrder.Rows[0]["ChallanDate"].ToString();
                totalOrderValueLabel.Text = purchaseOrder.Rows[0]["TotalValue"].ToString();
                vatLabel.Text = "(+) VAT " + purchaseOrder.Rows[0]["Vat"].ToString() + " %";
                
                int n;
                foreach (DataRow dr in purchaseOrder.Rows)
                {
                    //fill the MRR GridView
                    n = pOrdDataGridView.Rows.Add();
                    pOrdDataGridView.Rows[n].Cells[1].Value = (n+1).ToString();
                    pOrdDataGridView.Rows[n].Cells[2].Value = dr["Item"].ToString();
                    pOrdDataGridView.Rows[n].Cells[3].Value = dr["Unit"].ToString();
                    pOrdDataGridView.Rows[n].Cells[4].Value = dr["OrderedQty"].ToString();
                    pOrdDataGridView.Rows[n].Cells[5].Value = dr["Item"].ToString();
                    pOrdDataGridView.Rows[n].Cells[6].Value = (string.IsNullOrEmpty(dr["TotalBfrRecv"].ToString()) ? "0" : dr["TotalBfrRecv"].ToString()) ;
                    pOrdDataGridView.Rows[n].Cells[7].Value = dr["Item"].ToString();
                    pOrdDataGridView.Rows[n].Cells[8].Value = dr["TotalRecv"].ToString();
                    pOrdDataGridView.Rows[n].Cells[10].Value = dr["Price"].ToString();
                    pOrdDataGridView.Rows[n].Cells[11].Value = dr["Vat"].ToString();
                    pOrdDataGridView.Rows[n].Cells[12].Value = dr["GoodsID"].ToString();
                    pOrdDataGridView.Rows[n].Cells[14].Value = dr["POrdDetID"].ToString();
                }

                CalculateToatal();
            }
        }

        private void CalculateToatal()
        {
            decimal totalPay = 0, totalVat = 0;

            foreach (DataGridViewRow gridItem in pOrdDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    totalPay += Convert.ToDecimal(gridItem.Cells[8].Value.ToString().Trim()) * Convert.ToDecimal(gridItem.Cells[10].Value.ToString().Trim());
                    totalVat += (((Convert.ToDecimal(gridItem.Cells[8].Value.ToString().Trim()) * Convert.ToDecimal(gridItem.Cells[10].Value.ToString().Trim())) * Convert.ToDecimal(gridItem.Cells[11].Value.ToString().Trim())) / 100);
                }
            }

            paymentValueLabel.Text = (totalPay + totalVat).ToString("#.00");
            netPayLabel.Text = totalPay.ToString("#.00");
            vatTotalLabel.Text = totalVat.ToString("#.00");
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
                if (grrManager.GRRInspecManagement(grr))
                {
                    MessageBox.Show("Saved successfully.");
                    this.Close();
                    //ClearAllFields();
                }
            }
        }

        private bool CheckRequisition(string choice, bool cFlag)
        {
            bool flag = cFlag;

            try
            {
                if (pOrdDataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in pOrdDataGridView.Rows)
                    {
                        //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRow.Cells[1];
                        if (dgRow.Cells[1].Value != null && !string.IsNullOrEmpty(dgRow.Cells[1].Value.ToString()))
                        {
                            switch (choice)
                            {
                                case "1":
                                    //check wheather all remarks is given or not
                                    if (dgRow.Cells[13].Value == null && string.IsNullOrEmpty(dgRow.Cells[13].Value.ToString()))
                                    {
                                        return true;
                                    }
                                    break;
                                case "2":
                                    //check wheather all OK or not
                                    if (dgRow.Cells[13].Value != null && dgRow.Cells[9].Value.ToString().ToUpper().Trim() != "OK")
                                    {
                                        return false;
                                    }
                                    break;
                            }
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

        private bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(departmentComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select requisition department.");
                    acceptanceComboBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(acceptanceComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select accceptance.");
                    acceptanceComboBox.Focus();
                    return false;
                }
                else if (CheckRequisition("1", false))
                {
                    MessageBox.Show("Enter all remarks.");
                    pOrdDataGridView.Focus();
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

            grr.PurchseOrdID = Convert.ToInt64(PurchaseOrderID);
            grr.GrrId = Convert.ToInt64(PurchaseOrderID);
            grr.InvoiceNo = challanLabel.Text.Trim();
            grr.Acceptance = acceptanceComboBox.SelectedValue.ToString();
            grr.Comments = commentsTextBox.Text.Trim();
            grr.DeptUID = Convert.ToInt32(departmentComboBox.SelectedValue.ToString());
            grr.TotalPay = Convert.ToDecimal(netPayLabel.Text.Trim());
            grr.TotalVat = Convert.ToDecimal(vatTotalLabel.Text.Trim());
            grr.InspectionDate = inspectionDate.Value;
            grr.PRecvFromHRD = pRecvFromHRDDate.Value;
            grr.Note = (string.IsNullOrEmpty(noteComboBox.Text.Trim()) ? null: noteComboBox.SelectedValue.ToString());
            grr.Status = (CheckRequisition("2",true) ? "4" : "3");

            foreach (DataGridViewRow gridItem in pOrdDataGridView.Rows)
            {
                if (gridItem.Cells[1].Value != null)
                {
                    if (gridItem.Cells[1].Value != null && !string.IsNullOrEmpty(gridItem.Cells[1].Value.ToString()))
                    {
                        Product grrProduct = new Product();
                        grrProduct.PCode = gridItem.Cells[12].Value.ToString();
                        grrProduct.CahallanInfo = gridItem.Cells[5].Value.ToString().Trim();                        
                        grrProduct.PhysFound = gridItem.Cells[7].Value.ToString();
                        grrProduct.Quantity = Convert.ToDecimal(gridItem.Cells[8].Value.ToString());
                        grrProduct.Remarks = gridItem.Cells[13].Value.ToString();
                        grrProduct.POrdDetID = gridItem.Cells[14].Value.ToString();

                        if (IsEdit && (gridItem.Cells[15].Value != null && !string.IsNullOrEmpty(gridItem.Cells[15].Value.ToString())))
                        {
                            //update the item
                            grrProduct.Condition = "2";
                            grrProduct.PID = gridItem.Cells[15].Value.ToString();                            
                        }
                        else
                        {
                            //new item 
                            grrProduct.Condition = "1";                           
                        }
                        grr.Products.Add(grrProduct);
                    }
                }
            }
            if (IsEdit)
            {
                grr.Condition = "2";
            }
        }

        private void ClearAllFields()
        {
            commentsTextBox.Clear();
            acceptanceComboBox.SelectedIndex = -1;
            remarksPanel.Visible = false;
        }

        private void pOrdDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowCombobox(e);
        }
            
        private void ShowCombobox(DataGridViewCellEventArgs e)
        {
            try
            {
                if (pOrdDataGridView.CurrentCell != null)
                {
                    if (e.ColumnIndex == 9)
                    {
                        Point cellLocation = this.pOrdDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                        this.remarksPanel.Location = new Point(cellLocation.X, cellLocation.Y + 5);
                        this.remarksPanel.Size = pOrdDataGridView.Rows[e.RowIndex].Cells[9].Size;

                        if (string.IsNullOrEmpty((string)pOrdDataGridView.CurrentCell.Value))
                        {
                            remarksComboBox.SelectedIndex = -1;
                        }
                        else
                        {
                            remarksComboBox.SelectedItem = pOrdDataGridView.CurrentCell.Value;
                        }
                        this.remarksPanel.Show();
                    }
                    else
                    {
                        this.remarksPanel.Hide();
                    }
                }
            }
            catch 
            {
                remarksPanel.Hide();
            }
        }

        private void remarksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remarksComboBox.SelectedIndex > -1)
            {
                if (pOrdDataGridView.CurrentRow != null)
                {
                    pOrdDataGridView.CurrentRow.Cells[9].Value = remarksComboBox.Text;
                    pOrdDataGridView.CurrentRow.Cells[13].Value = remarksComboBox.SelectedValue.ToString();
                    remarksPanel.Hide();                        
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void addRemarksLabel_Click(object sender, EventArgs e)
        {
            new FSDInspectionRemarksEntryUI().ShowDialog();
            fillControl.fillCombo(remarksComboBox, masterManager.GetInspecAcceptanceList("2", null), "Status", "Code");
        }

        private void addNoteLabel_Click(object sender, EventArgs e)
        {
            new SummeryNoteSettingsUI().ShowDialog();
            fillControl.fillCombo(noteComboBox, masterManager.GetSummeryNoteList("3", null), "Note", "Code");
        }  
    }
}
