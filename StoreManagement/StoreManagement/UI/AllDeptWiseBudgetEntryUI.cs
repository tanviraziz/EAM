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
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class AllDeptWiseBudgetEntryUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private Budget budget = null;
            private bool IsEdit = false;
        #endregion
        public AllDeptWiseBudgetEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
        }

        private void AllDeptWiseBudgetEntryUI_Load(object sender, EventArgs e)
        {
            SetDepartment();
        }

        private void SetDepartment()
        {
            DataTable departmentDT;
            try
            {
                departmentDT = settingsManager.GetBudgetList("1", null);

                if (departmentDT == null || departmentDT.Rows.Count <= 0)
                {
                    departmentDT = settingsManager.GetDepartmentList("5", null);
                }
                else
                {
                    IsEdit = true;
                }

                departmentGridView.Rows.Clear();

                if (departmentDT != null &&  departmentDT.Rows.Count > 0)
                {
                    int n;
                    foreach (DataRow dr in departmentDT.Rows)
                    {
                        //fill the Department GridView
                        n = departmentGridView.Rows.Add();
                        departmentGridView.Rows[n].Cells[0].Value = (n+1).ToString();
                        departmentGridView.Rows[n].Cells[1].Value = dr["Department"].ToString();

                        if (IsEdit)
                        {
                            departmentGridView.Rows[n].Cells[2].Value = dr["Budget"].ToString();
                            departmentGridView.Rows[n].Cells[4].Value = dr["BudgID"].ToString();
                        }
                        else
                        {
                            departmentGridView.Rows[n].Cells[3].Value = dr["Code"].ToString();
                        }
                        
                    }
                }
            }
            catch
            { }
        }

        private void departmentGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Control;
            if (departmentGridView.CurrentRow != null)
            {
                if (departmentGridView.CurrentCell.ColumnIndex == 2)// || departmentGridView.CurrentCell.ColumnIndex == 3 || departmentGridView.CurrentCell.ColumnIndex == 4)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (settingsManager.BudgetManagement(budget))
                {
                    MessageBox.Show("Saved Successfuly");
                }
                else
                {
                    MessageBox.Show("Falied to save");
                }
            }

            budget = null;
        }

        private bool IsValid()
        {
            if (CheckBudget())
            {
                MessageBox.Show("Enter all department budget");
                return false;
            }
            else
            {
                SetValues();
            }
            return true;
        }

        private bool CheckBudget()
        {
            try
            {
                if (departmentGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in departmentGridView.Rows)
                    {
                        if (dgRow.Cells[2].Value == null || string.IsNullOrEmpty(dgRow.Cells[2].Value.ToString().Trim())) //|| dgRow.Cells[3].Value == null || string.IsNullOrEmpty(dgRow.Cells[3].Value.ToString().Trim()) || dgRow.Cells[4].Value == null || string.IsNullOrEmpty(dgRow.Cells[4].Value.ToString().Trim()))
                        {
                            return true;
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

        private void SetValues()
        {
            if (budget == null)
            {
                budget = new Budget();
            }

            //CostHead costHead = null;
            //string deptUID;
            foreach (DataGridViewRow gridItem in departmentGridView.Rows)
            {
                //loop through the Datagrid to get all department budget
                //deptUID = null;
                if (gridItem.Cells[1].Value != null)
                {
                    CostHead costHead = new CostHead();
                    costHead.Budget = Convert.ToDecimal(gridItem.Cells[2].Value.ToString().Trim());

                    if (IsEdit)
                    {
                        costHead.Condtion = "2";
                        costHead.BudgetID = gridItem.Cells[4].Value.ToString().Trim();
                        budget.CostHeadBudget.Add(costHead.BudgetID.ToString(), costHead);  
                    }
                    else
                    {
                        costHead.CostofDeptID = Convert.ToInt32(gridItem.Cells[3].Value.ToString().Trim());
                        budget.CostHeadBudget.Add(costHead.CostofDeptID.ToString(), costHead);  
                    }

                                      

                    #region to set stationary category budget
                    //foreach (DataGridViewCell dgCell in gridItem.Cells)
                    //{
                        //loop through to get the department all category budget
                        //switch (dgCell.ColumnIndex)
                        //{
                        //    case 2:
                                //1 - Stationary Budget
                                //costHead = new CostHead();
                                //costHead.CostofDeptID = Convert.ToInt32(deptUID);
                                //costHead.CostHeadID = 1;
                                //costHead.Budget = Convert.ToDecimal(dgCell.Value.ToString().Trim());
                                //if (IsEdit)
                                //{
                                //    costHead.Condtion = "2";
                                //}
                        //        break;
                        //    case 3:
                        //        //2 - Computer Budget
                        //        costHead = new CostHead();
                        //        costHead.CostofDeptID = Convert.ToInt32(deptUID);
                        //        costHead.CostHeadID = 2;
                        //        costHead.Budget = Convert.ToDecimal(dgCell.Value.ToString().Trim());
                        //        if (IsEdit)
                        //        {
                        //            costHead.Condtion = "2";
                        //        }
                        //        break;
                        //    case 4:
                        //        //3 - Printing Budget
                        //        costHead = new CostHead();
                        //        costHead.CostofDeptID = Convert.ToInt32(deptUID);
                        //        costHead.CostHeadID = 3;
                        //        costHead.Budget = Convert.ToDecimal(dgCell.Value.ToString().Trim());
                        //        if (IsEdit)
                        //        {
                        //            costHead.Condtion = "2";
                        //        }
                        //        break;
                        //}

                        //if (costHead != null)
                        //{
                            //budget.CostHeadBudget.Add((deptUID.ToString() + costHead.CostHeadID.ToString()), costHead);
                            //costHead = null;
                        //}
                    //}
                    #endregion
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                SetDepartment();
            }
            else
            {
                ClearBudget();
            }
        }

        private bool ClearBudget()
        {
            try
            {
                if (departmentGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgRow in departmentGridView.Rows)
                    {
                        dgRow.Cells[2].Value = string.Empty;
                    }
                }
            }
            catch
            {
                return true;
            }
            return false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void departmentGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (departmentGridView.CurrentRow != null)
        //    //    {
        //    //        switch (e.ColumnIndex)
        //    //        {
        //    //            case 2:
        //    //                departmentGridView.CurrentRow.Cells[5].Value = (
        //    //                    Convert.ToDecimal((departmentGridView.CurrentRow.Cells[2].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())) ? "0":  departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[3].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[4].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())
        //    //                  ).ToString("##.00");
        //    //                break;
        //    //            case 3:
        //    //                departmentGridView.CurrentRow.Cells[5].Value = (
        //    //                    Convert.ToDecimal((departmentGridView.CurrentRow.Cells[2].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())) ? "0":  departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[3].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[4].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())
        //    //                  ).ToString("##.00");
        //    //                break;
        //    //            case 4:
        //    //                departmentGridView.CurrentRow.Cells[5].Value = (
        //    //                    Convert.ToDecimal((departmentGridView.CurrentRow.Cells[2].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[2].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[3].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[3].Value.ToString().Trim())
        //    //                  + Convert.ToDecimal((departmentGridView.CurrentRow.Cells[4].Value == null || string.IsNullOrEmpty(departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())) ? "0" : departmentGridView.CurrentRow.Cells[4].Value.ToString().Trim())
        //    //                  ).ToString("##.00");
        //    //                break;
        //    //        }
        //    //    }
        //    //}
        //    //catch { }
        //}
    }
}
