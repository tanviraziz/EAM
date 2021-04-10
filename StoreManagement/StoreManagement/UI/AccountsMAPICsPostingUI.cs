using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using StoreManagement.BLL;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class AccountsMAPICsPostingUI : Form
    {
        #region Veriables
            private StoreManager storeManager = null;
            private DynamicControlFill fillControl = null;
            private MonthYearConvertion monthYearConveriton = null;
            int mthNumber ;
        #endregion

        public AccountsMAPICsPostingUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            storeManager = new StoreManager();
            fillControl = new DynamicControlFill();
            monthYearConveriton = new MonthYearConvertion();
        }

        private void AccountsMAPICsPostingUI_Load(object sender, EventArgs e)
        {
            //fill the months
            fillControl.FillMonth(monthComboBox);
            //this.monthComboBox.SelectedIndexChanged += new EventHandler(this.monthComboBox_SelectedIndexChanged);
            monthComboBox.SelectedIndex = -1;

            mthNumber = storeManager.GetStoreClosingMonth("1");
        }

        private void createExcelButton_Click(object sender, EventArgs e)
        {
            if (consumptionGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = "consumption.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ToCsV(dataGridView, @"c:\export.xls");
                    if (ToCsV(consumptionGridView, sfd.FileName))
                    {
                        MessageBox.Show("Data export successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Data export failed.");
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no data to export.");
            }
        }

        private bool ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                for (int j = 0; j < dGV.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.
                for (int i = 0; i < dGV.RowCount; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                fs = new FileStream(filename, FileMode.Create);
                bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();
            }
            catch
            {
                bw.Flush();
                bw.Close();
                fs.Close();
                return false;
            }
            return true;
        }

        private int monthNumber(string monthName)
        {
            return DateTime.Parse(monthName + " 01, 1900").Month;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            int currentMonth = DateTime.Now.Month;
            DataTable dt = null;
            try
            {
                dt = storeManager.GetStoreDeshBoardData("5", "2", monthYearConveriton.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null); ;
                FillData(dt);
                consumptionGroupBox.Text = "Consumption for the month of " + monthComboBox.Text + ", " + yearPicker.Text;

                //if ((yearPicker.Text.Trim() == DateTime.Now.Year.ToString().Trim()) && (mthNumber == 1 && monthNumber(monthComboBox.Text.Trim()) == 12))
                //{
                //    createExcelButton.Visible = true;
                //}
                //else if ((yearPicker.Text.Trim() == DateTime.Now.Year.ToString().Trim()) && (monthNumber(monthComboBox.Text.Trim()) < mthNumber))
                //{                    
                //    createExcelButton.Visible = true;
                //}
                //else
                //{
                //    createExcelButton.Visible = false;
                //}

                if (yearPicker.Text.Trim() == DateTime.Now.Year.ToString().Trim())
                {
                    if (monthNumber(monthComboBox.Text.Trim()) < mthNumber)
                    {
                        createExcelButton.Visible = true;
                    }
                    else
                    {
                        createExcelButton.Visible = false;
                    }
                }
                else if ((Convert.ToInt16(yearPicker.Text.Trim()) < DateTime.Now.Year) )
                {
                    if (mthNumber == 12 && monthNumber(monthComboBox.Text.Trim()) == 12)
                    {
                        createExcelButton.Visible = false;
                    }
                    else
                    {
                        createExcelButton.Visible = true;
                    }
                }
                
            }
            catch
            { }
        }

        //private void GetTheClosingMonth()
        //{
        //    int currentMonth;
        //    int mthNumber = storeManager.GetStoreClosingMonth("1");
        //    currentMonth = DateTime.Now.Month;

        //    closingButton.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber) + " Closing";


        //    if (mthNumber == 12)
        //    {
        //        if (currentMonth == 1)
        //        {
        //            closingButton.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        if (currentMonth == (mthNumber + 1))
        //        {
        //            closingButton.Visible = true;
        //        }
        //        else
        //        {
        //            closingButton.Visible = false;
        //        }
        //    }
        //}


        private void FillData(DataTable dt)
        {
            try
            {
                consumptionGridView.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    int n;
                    n = consumptionGridView.Rows.Add();
                    foreach (DataRow dr in dt.Rows)
                    {
                        //fill the Order GridView
                        n = consumptionGridView.Rows.Add();
                        consumptionGridView.Rows[n].Cells[1].Value = dr["CostHead"].ToString().Replace("-","");
                        consumptionGridView.Rows[n].Cells[2].Value = dr["Department"].ToString();
                        consumptionGridView.Rows[n].Cells[4].Value = dr["Amount"].ToString();
                        //consumptionGridView.Rows[n].Cells[5].Value = dr["Amount"].ToString();
                        consumptionGridView.Rows[n].Cells[6].Value = dr["Category"].ToString();
                        consumptionGridView.Rows[n].Cells[7].Value = "CONSUMPTION " +  dr["StockMonth"].ToString().ToUpper();
                        consumptionGridView.Rows[n].Cells[8].Value = "D" ;
                    }
                }
            }
            catch { }
        }

        private void consumptionGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (consumptionGridView.CurrentRow != null)
                {
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            if (e.RowIndex == 0)
                            {
                                FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                            }
                            break;
                        case 3:
                            if (e.RowIndex == 0)
                            {
                                FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                            }
                            break;
                        case 4:
                            if (e.RowIndex == 0)
                            {
                                FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                            }
                            break;
                        case 5:
                            if (e.RowIndex == 0)
                            {
                                FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                            }
                            break;
                        //case 8:
                        //    if (e.RowIndex == 0)
                        //    {
                        //        FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                        //    }
                        //    break;
                        case 9:
                            if (e.RowIndex == 0)
                            {
                                FillDataToGrid(e.ColumnIndex, consumptionGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        private void FillDataToGrid(int choice,string value)
        {
            decimal totalAmt = 0;
            try
            {
                if (consumptionGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in consumptionGridView.Rows)
                    {
                        if (choice == 4 )
                        {
                            if (dgRow.Index == 0) continue;
                            totalAmt += Convert.ToDecimal(dgRow.Cells[choice].Value.ToString());
                        }
                        else
                        {
                            dgRow.Cells[choice].Value = value;
                        }
                    }
                }

                if (choice == 4)
                {
                    consumptionGridView.Rows[0].Cells[choice].Value = totalAmt.ToString();
                    consumptionGridView.Rows[0].Cells[choice+1].Value = totalAmt.ToString();
                }
            }
            catch { }
        }

        //private void consumptionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (consumptionGridView.CurrentRow != null)
        //        {
        //            switch (e.ColumnIndex)
        //            {
        //                case 5:
        //                    if (e.RowIndex == 0 && !string.IsNullOrEmpty(consumptionGridView.Rows[e.ColumnIndex].Cells[4].Value.ToString()))
        //                    {
        //                        consumptionGridView.Rows[e.ColumnIndex].Cells[5].Value = consumptionGridView.Rows[e.ColumnIndex].Cells[4].Value.ToString();
        //                    }
        //                    break;                        
        //            }
        //        }
        //    }
        //    catch { }
        //}

        
        
    }
}
