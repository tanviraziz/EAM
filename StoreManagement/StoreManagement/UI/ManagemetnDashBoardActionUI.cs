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

namespace StoreManagement.UI
{
    public partial class ManagemetnDashBoardActionUI : Form
    {
        #region Veriables
            private SRRManager srrManager = null;
            private DynamicControlFill fillControll = null;
            private MonthYearConvertion monthYearConvert = null;
        #endregion

        public ManagemetnDashBoardActionUI()
        {
            InitializeComponent();
            SetObjets();
        }

        private void SetObjets()
        {
            fillControll = new DynamicControlFill();
            srrManager = new SRRManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void ManagemetnDashBoardUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            //fill the months
            fillControll.FillMonth(monthComboBox);

            //fillControll.fillListView(yearlyConsumptionListView, srrManager.GetAuthoritySRRList("6", LoginUser.UserDepartment, condition), "Category, Value", "80,70", false);
            ShowData(monthYearConvert.getMonthYear("2", monthComboBox.Text, yearPicker.Text));
        }

        private void ShowData(string condition)
        {
            //yearly consumption 
            fillControll.fillListView(yearlyConsumptionListView, srrManager.GetAuthoritySRRList("6", LoginUser.UserDepartment, condition), "Category, Value", "80,70", false);

            DataTable dt = null;
            try
            {
                if (string.IsNullOrEmpty(condition.Trim()))
                {
                    MessageBox.Show("Select a month");
                    monthComboBox.Focus();
                }
                else
                {
                    dt = srrManager.GetAuthoritySRRList("5", LoginUser.UserDepartment, condition);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        consumptionGroupBox.Text = "Consumption for the month of - " + monthComboBox.Text;

                        fillControll.fillListView(srrItemListView, dt, "Item,Unit,Issued Qty,Value,", "350,100,100,250,", false);
                        fillControll.BuildGroups(4, srrItemListView, true);

                        fillControll.fillListView(consumptionListView, srrManager.GetAuthoritySRRList("7", LoginUser.UserDepartment, condition), "Category, Value", "80,70", false);
                        

                    }
                    else
                    {
                        srrItemListView.Items.Clear();
                        MessageBox.Show("No data found");
                    }
                }
            }
            catch
            {
                srrItemListView.Items.Clear();
            }
        }

        private void monthlyConsumptionTaskItem_Click(object sender, EventArgs e)
        {
            ShowData(monthYearConvert.getMonthYear("2", monthComboBox.Text, yearPicker.Text));
        }
    }
}
