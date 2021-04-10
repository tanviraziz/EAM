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
    public partial class DeptBudgetSettingsActionUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private MasterSetupManager settingsManager = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public DeptBudgetSettingsActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void allDeptBudget_Click(object sender, EventArgs e)
        {
            new AllDeptWiseBudgetEntryUI().ShowDialog();
            ShowData();
        }

        private void DeptBudgetSettingsActionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowData();
        }

        private void ShowData()
        {
            fillControll.fillListView(budgetListView, settingsManager.GetBudgetList("1", null), "Department,Budget,,", "250,150,,");
            GetTheClosingMonth();
        }

        //Dysplay the Current stock month
        private void GetTheClosingMonth()
        {
            string closingYear,currentYear;
            closingYear = settingsManager.GetBudgetClosingYear("1");
            currentYear = DateTime.Now.Year.ToString();

            if (string.IsNullOrEmpty(closingYear))
            {
                budgetLabel.Text = "No Budget";
            }
            else
            {
                budgetLabel.Text = "All Department Yearly Budget of " + closingYear;

                if ((Convert.ToInt16(closingYear.Trim()) + 1) == (Convert.ToInt16(currentYear)))
                {
                    budgetCloseButton.Visible = true;
                    allDeptBudget.Visible = false;
                    budgetCloseButton.Text = "Close " + closingYear + " Budget";
                }
                else
                {
                    budgetCloseButton.Visible = false;
                    allDeptBudget.Visible = true;
                    allDeptBudget.Image = (string.IsNullOrEmpty(closingYear) ? Resources.add : Resources.edit24);
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new DeptWiseBudgetUI().ShowDialog();
        }

        private void budgetCloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to do closing ?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (settingsManager.BudgetClosingManagement(new Budget() { Condition = "3" }))
                {
                    MessageBox.Show("Closing complete");
                    ShowData();
                }
                else
                {
                    MessageBox.Show("Closing failed");
                }
                
            }
        }

        
    }
}
