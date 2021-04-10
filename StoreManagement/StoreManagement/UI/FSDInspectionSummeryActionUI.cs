using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.UTILITY;
using StoreManagement.Reports.FSD;

namespace StoreManagement.UI
{
    public partial class FSDInspectionSummeryActionUI : Form
    {
        #region Veriables
            private FSDManager fsdManager = null;
            private DynamicControlFill fillControl = null;
            private MonthYearConvertion monthYearConvert = null;
            private SummeryReport summeryReport = null;
            private SummeryMainPageReport summeryManiPage = null;
            private SummeryDetailPageReport summeryDetailPage = null;
        #endregion

        public FSDInspectionSummeryActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fsdManager = new FSDManager();
            fillControl = new DynamicControlFill();
        }

        private void FSDInspectionSummeryActionUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowData();
            ShowTheSummeryButton();
        }

        private void ShowData()
        {
            fillControl.fillListView(summeryListView, fsdManager.GetFSDSummeries("1", null, null), "Summery No.,Prepare Date,YYMM,Total Certificate, Total Order Val.,Total Recv. Val.,Total Post Order, Post Order Val.,Remarks", "100,140,140,140,140,140,140,140,140");
        }

        private void ShowTheSummeryButton()
        {
            int currentMonth, mthNumber;
            try
            {
                mthNumber = Convert.ToInt16(fsdManager.GetFSDSummeryMonth("1", null).Rows[0]["mnth"].ToString().Trim());
                currentMonth = DateTime.Now.Month;//DateTime.ParseExact(DateTime.Now.Month.ToString("MMMM"), "MMMM", CultureInfo.CurrentCulture).Month;

                if (mthNumber == 0)
                {
                    createSummeryButton.Visible = true;
                    createSummeryButton.Text = "Create " + fillControl.GetMonthName(currentMonth) + " Summery";
                }
                else
                {
                    if (mthNumber == 12)
                    {
                        if (currentMonth == 1)
                        {
                            createSummeryButton.Visible = true;
                            createSummeryButton.Text = "Create " + fillControl.GetMonthName(currentMonth) + " Summery";
                        }
                    }
                    else
                    {
                        if (currentMonth == (mthNumber + 1))
                        {
                            createSummeryButton.Visible = true;
                            createSummeryButton.Text = "Create " + fillControl.GetMonthName(mthNumber+1) + " Summery";
                        }
                    }
                }
            }
            catch
            {
                createSummeryButton.Visible = false;
            }
        }

        private void createSummeryButton_Click(object sender, EventArgs e)
        {
            //string month = fsdManager.GetFSDSummeryMonth("1", null).Rows[0]["YYMM"].ToString();
            new FSDInspectionSummeryEntryUI().ShowDialog();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        //Print Summery
        private void printSummeryTaskItem_Click(object sender, EventArgs e)
        {
            if(summeryListView.SelectedIndices.Count > 0)
            {
                string strYYMM = summeryListView.Items[summeryListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                SummeryMainPageReport rpt = new SummeryMainPageReport();                
                //summeryReport.Subreports["SummeryMainPageReport.rpt"].SetDataSource(fsdManager.GetFSDSummeries("2", "20" + strYYMM, null));
                //summeryReport.Subreports["SummeryDetailPageReport.rpt"].SetDataSource(fsdManager.GetFSDSummeries("3", "20" + strYYMM, null));

                new ReportViwer(fsdManager.GetFSDSummeries("2", "20" + strYYMM, null), rpt).Show();
            }
            else
            {
                MessageBox.Show("Select a summery from list");
            }
        }


        //Print Summery Detail
        private void printSummeryDetailTaskItem_Click(object sender, EventArgs e)
        {
            if (summeryListView.SelectedIndices.Count > 0)
            {
                string strYYMM = summeryListView.Items[summeryListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                SummeryDetailPageReport rpt = new SummeryDetailPageReport();
                new ReportViwer(fsdManager.GetFSDSummeries("3", "20" + strYYMM, null), rpt).Show();
            }
            else
            {
                MessageBox.Show("Select a summery from list");
            }
        }

        private void summeryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (summeryListView.SelectedIndices.Count > 0)
            {
                string strYYMM = "20" + summeryListView.Items[summeryListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                fillControl.fillListView(detailListView, fsdManager.GetFSDSummeries("4", strYYMM, null), ",PPO No.,Order Value(TK.),Payment Value(TK.),Difference,GRR No.,GRR Date,Inspc. Date,Report Type,Report Ref", ",200,120,140,80,80,180,80,140,320");
            }
        }

        private void printCertificateTaskItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (detailListView.SelectedIndices.Count > 0)
                {
                    string certifcateID = detailListView.Items[detailListView.SelectedIndices[0]].Text.Trim();
                    ReportViwer reportViewer = new ReportViwer(new GRRManager().GetGRRCertificate("3", certifcateID), new FSDCertificateReport());
                    reportViewer.Show();
                }
                else
                {
                    MessageBox.Show("Select a certificate from list");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        

        
    }
}
