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
    public partial class FSDInspectionSummeryEntryUI : Form
    {
        #region Veriables
            private FSDManager fsdManager = null;
            private DynamicControlFill fillControl = null;
            private MonthYearConvertion monthYearConvert = null;
            private FSDCertificate summery = null;
            private string summeryMonth;
        #endregion

        public FSDInspectionSummeryEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fsdManager = new FSDManager();
            fillControl = new DynamicControlFill();
            monthYearConvert = new MonthYearConvertion();
        }

        private void FSDInspectionSummeryEntryUI_Load(object sender, EventArgs e)
        {
            SummeryOfMonth();
        }

        private void SummeryOfMonth()
        {
            int currentMonth, mthNumber;
            try
            {
                mthNumber = Convert.ToInt16(fsdManager.GetFSDSummeryMonth("1", null).Rows[0]["mnth"].ToString().Trim());
                currentMonth = DateTime.Now.Month;//DateTime.ParseExact(DateTime.Now.Month.ToString("MMMM"), "MMMM", CultureInfo.CurrentCulture).Month;

                if (mthNumber == 0 || mthNumber > 12)
                {
                    //monthComboBox.Visible = true;
                    //fillControl.FillMonth(monthComboBox);
                    summeryMonth = monthYearConvert.getMonthYear("2", fillControl.GetMonthName(currentMonth), DateTime.Now.Year.ToString());
                }
                else
                {
                    summeryMonth = monthYearConvert.getMonthYear("2", fillControl.GetMonthName(mthNumber), DateTime.Now.Year.ToString());
                }

                fillControl.fillListView(summeryListView, fsdManager.GetFSDSummeries("2", summeryMonth, null), "Total Certificates,Total Order Value,Total Recv. Value, Difference, Total Post Order,Post Order Value,,", "100,180,180,180,180,180,,");
                fillControl.fillListView(certificateListView, fsdManager.GetFSDSummeries("3", summeryMonth, null), "PPO No.,Order Value(TK.),Payment Value(TK.),Difference,GRR No.,GRR Date,Inspc. Date,Report Type,Reference", "140,180,180,180,180,180,180,180,180,");
            }
            catch
            {
                saveButton.Visible = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (fsdManager.FSDCertificateSummeryManagement(summery))
                {
                    MessageBox.Show("Summery create successfully");
                }
                else
                {
                    MessageBox.Show("Falied to create summery");
                }
            }
            summery = null;
        }

        private bool IsValid()
        {
            try
            {
                if(string.IsNullOrEmpty(summeryMonth.ToString().Trim()))
                {
                    MessageBox.Show("No summery month");
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
            if (summery == null)
            {
                summery = new FSDCertificate();
            }

            summery.YYMM = summeryMonth.Substring(2, 4);
        }
    }
}
