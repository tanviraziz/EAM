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
using StoreManagement.UI;
using StoreManagement.Reports.Store.StoreRequisition;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;

namespace StoreManagement.UI
{
    public partial class PendingRequisitionActionUI : Form
    {
        #region Veriables
        private MasterSetupManager settingsManager = null;
        private SRRManager srrManager = null;
        private StoreManager storeManager = null;
        private DynamicControlFill fillControll = null;
        #endregion

        public PendingRequisitionActionUI()
        {
            InitializeComponent();   
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            srrManager = new SRRManager();
            fillControll = new DynamicControlFill();
            storeManager = new StoreManager();
        }

        private void PendingRequisitionListUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");

            //fill the department name in combo
            fillControll.fillCombo(departmentComboBox, settingsManager.GetDepartmentList("3", null), "Department", "Code");
            departmentComboBox.SelectedIndex = -1;

            //fill the month combo wiht month name
            fillControll.FillMonth(monthComboBox);
            monthComboBox.Text = DateTime.Now.ToString("MMMM");

            //fill the current year
            yearDatePicker.Value = DateTime.Now;

            //show the pending requisition list
            ChangeView();
            ManageIssueState();
        }

        //Manage the issue button 
        private void ManageIssueState()
        {
            int currentMonth;
            int mthNumber = storeManager.GetStoreClosingMonth("1");
            currentMonth = DateTime.Now.Month;
            

            
            if (mthNumber == 12)
            {
                if (currentMonth == 1)
                {
                    issueButton.Enabled = false;

                    msgToolStripLabel.Visible = true;
                    msgToolStripLabel.Text = "      Cannot issue any user requisition before monthly stock closing of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber) + " , " + DateTime.Now.Year.ToString();  
                }
                else if (currentMonth == mthNumber)
                {
                    issueButton.Enabled = true;
                } 
            }
            else
            {
                if (currentMonth == (mthNumber + 1))
                {
                    issueButton.Enabled = false;

                    msgToolStripLabel.Visible = true;
                    msgToolStripLabel.Text = "      Cannot issue any user requisition before monthly stock closing of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber) + " , " + DateTime.Now.Year.ToString();  
                }
                else if (currentMonth == mthNumber)
                {
                    issueButton.Enabled = true;
                }                
            }
        }

        private void pendingListView_DoubleClick(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                new SRREntryUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new SRREntryUI().ShowDialog();
            ShowData("1", null, null);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                new SRREntryUI(pendingListView.Items[pendingListView.SelectedIndices[0]].Text).ShowDialog();
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ChangeView();
            switch (requisitionTabControl.SelectedIndex)
            {
                case 0:
                    ShowData("1", null, null);
                    break;
                case 1:
                    ShowData("2", null, null);
                    break;
            }
            pendingGroupBox.Text = "";
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim());
                editButton.Visible = true;
            }
        }

        private void ShowRequisitonDetail(string srrNo)
        {
            switch(requisitionTabControl.SelectedIndex)
            {
                case 0:
                    pendingGroupBox.Text = "Requistion No. : " + srrNo + " detail";
                    fillControll.fillListView(pDetailListView, srrManager.GetSRRList("4", srrNo, null), "Item,Unit,Req Qty,Issued,Remarks", "250,60,60,60,400");

                    fillControll.fillListView(pGRRListView, srrManager.GetSRRList("13", srrNo, null), "GRR No.,Issued Qty,", "150,160,");
                    fillControll.BuildGroups(2, pGRRListView, false);
                    break;
                case 1:
                    completeGroupBox.Text = "Requistion No. : " + srrNo + " detail";
                    fillControll.fillListView(cDetailListView, srrManager.GetSRRList("4", srrNo, null), "Item,Unit,Req Qty,Issued,Remarks", "250,60,60,60,400");

                    fillControll.fillListView(cGRRListView, srrManager.GetSRRList("13", srrNo, null), "GRR No.,Issued Qty,", "150,160,");
                    fillControll.BuildGroups(2, cGRRListView, false);
                break;
            }
        }

        private void ChangeView()
        {
            switch (requisitionTabControl.SelectedIndex)
            {
                case 0:
                    //fillControll.fillListView(pendingListView, srrManager.GetSRRList("1", null), "Requisition No, Date,Purpose,Department", "100,100,250,250");
                    ShowData("1", null, null);
                    addButton.Visible = true;
                    editButton.Visible = false;
                    issueButton.Visible = true;
                    printButton.Visible = true;
                    monthlyRequisitionButton.Visible = false;
                    monthlyDeptwiseReqButton.Visible = false;
                    yearlyRequisitionButton.Visible = false;
                    departmentalYearlyRequisitionButton.Visible = false;
                    departmentalMonthlyRequisitionButton.Visible = false;
                    departmentalPendingRequisitionButton.Visible = true;
                    pendingGroupBox.Text = "";
                    pDetailListView.Items.Clear();
                    break;
                case 1:
                    //fillControll.fillListView(completeListView, srrManager.GetSRRList("2", null), "Requisition No, Date,Purpose,Department", "100,100,250,250");
                    ShowData("2", null, null);
                    addButton.Visible = false;
                    editButton.Visible = false;
                    issueButton.Visible = false;
                    printButton.Visible = true;
                    monthlyRequisitionButton.Visible = true;
                    monthlyDeptwiseReqButton.Visible = true;
                    yearlyRequisitionButton.Visible = true;
                    departmentalMonthlyRequisitionButton.Visible = true;
                    departmentalYearlyRequisitionButton.Visible = true;
                    departmentalPendingRequisitionButton.Visible = false;
                    completeGroupBox.Text = "";
                    cDetailListView.Items.Clear();
                    break;

            }

            monthComboBox.Text = DateTime.Now.ToString("MMMM");
            yearDatePicker.Value = DateTime.Now;
            departmentComboBox.SelectedIndex = -1;
            requisitionNoTextBox.Clear();
        }

        private void requisitionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeView();            
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string reqNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text;
                if (MessageBox.Show("Do you want to issue requisition no.- " + reqNo.ToString() + " ? ", "Issue confirmation....", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    SRR issuedSrr = new SRR();
                    issuedSrr.IssuedBy = LoginUser.UserID;
                    issuedSrr.SRRID = Convert.ToInt64(reqNo);
                    issuedSrr.Condition = "4";

                    if (srrManager.SRRManagement(issuedSrr))
                    {
                        MessageBox.Show("Requisition no. " + reqNo + " issued");
                        ShowData("1", null, null);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a requisition from list");
            }
        }

        private void completeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completeListView.SelectedIndices.Count > 0)
            {
                ShowRequisitonDetail(completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim());
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            string reqNO = null;
            SrrReport rpt = new SrrReport();

            //Start:instentiate the report formula fields
            FormulaFieldDefinitions ffds = rpt.DataDefinition.FormulaFields;

            //get the formula definition
            FormulaFieldDefinition ffd1 = ffds["FormulaCompanyName"];
            FormulaFieldDefinition ffd2 = ffds["FormulaCompanyAddress"];

            //set the formula with value
            ffd1.Text = '"' + "BEXIMCO CHEMICAL DIVISION" + '"'; //company name
            ffd2.Text = '"' + "19 DHANMONDI R/A ROAD NO. 7 DHAKA-1205" + '"';   //company address

            //End:instentiate the report formula fields

            switch (requisitionTabControl.SelectedIndex)
            {
                case 0:
                    //get the selected pending requisiton no
                    reqNO = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();                    
                    break;
                case 1:
                    //get the selected complete requisiton no
                    reqNO = completeListView.Items[completeListView.SelectedIndices[0]].Text.Trim();
                    break;
            }

            if (string.IsNullOrEmpty(reqNO))
            {
                MessageBox.Show("Select a requisition from list.");
            }
            else
            {
                //show the requisiton to print view
                new ReportViwer(srrManager.GetSRRList("5", reqNO.Trim(), null), rpt).Show();
            }
            
        }

        private void ShowData(string choice,string condition1, string condition2)
        {
            switch (choice.Trim())
            {
                case "1":
                    //fill the pending requisition in pending listview
                    fillControll.fillListView(pendingListView, srrManager.GetSRRList("1",condition1,condition2), "Requisition No, Req. Date,Purpose,Department", "100,100,250,250");                    
                    break;
                case "2":
                    //fill the issued requisition in complete listview
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("2", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,120,100,250,250");
                    break;
                case "3":
                    //fill the selected department pending requisition in listview
                    fillControll.fillListView(pendingListView, srrManager.GetSRRList("6", condition1, condition2), "Requisition No, Req. Date,Purpose,Department", "100,100,250,250");
                    break;
                case "4":
                    //fill the selected requisition (pending)
                    fillControll.fillListView(pendingListView, srrManager.GetSRRList("7", condition1, condition2), "Requisition No, Req. Date,Purpose,Department", "100,100,250,250");
                    break;
                case "5":
                    //fill the selected requisition (issued)
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("8", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,100,100,250,250");
                    break;
                case "6":
                    //fill the Issued requisiton in selected month 
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("9", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,100,100,250,250");
                    break;
                case "7":
                    //fill the Issued requisiton in selected month deparmtmentwise
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("9", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,100,100,250,250");
                    fillControll.BuildGroups(4, completeListView, true);
                    break;
                case "8":
                    //fill the Issued requisiton in selected month for the deparmtment
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("10", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department", "100,100,100,250,250");
                    break;
                case "9":
                    //fill the Issued requisiton in selected year monthwise
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("11", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department,", "100,100,100,250,250,");
                    fillControll.BuildGroups(4, completeListView, true);
                    break;
                case "10":
                    //fill the Issued requisiton in selected year of deparmtmentwise in monthwise
                    fillControll.fillListView(completeListView, srrManager.GetSRRList("12", condition1, condition2), "Requisition No, Req. Date,Issue Date,Purpose,Department,", "100,100,100,250,250,");
                    fillControll.BuildGroups(4, completeListView, true);
                    break;
            }
        }

        //Show the Selected department all pending requisition
        private void departmentalPendingRequisitionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(departmentComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a deparmtment.");
                departmentComboBox.Focus();
            }
            else
            {
                ShowData("3", departmentComboBox.SelectedValue.ToString(), null);
            }
        }

        //Show the all issued requisition in selected month
        private void monthlyRequisitionButton_Click(object sender, EventArgs e)
        {
            ShowData("6", getMonthYear("2", monthComboBox.Text.Trim(), yearDatePicker.Text.Trim()), null);           
        }

        //Show departmentwise all issued requistion in selected month 
        private void monthlyDeptwiseReqButton_Click(object sender, EventArgs e)
        {
            ShowData("7", getMonthYear("2", monthComboBox.Text.Trim(), yearDatePicker.Text.Trim()), null);               
        }

        //Show all issued requisiton of department in selected month
        private void departmentalRequisitionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(departmentComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a deparmtment.");
                departmentComboBox.Focus();
            }
            else
            {
                ShowData("8", getMonthYear("2", monthComboBox.Text.Trim(), yearDatePicker.Text.Trim()), departmentComboBox.SelectedValue.ToString());   
            }
            
        }

        //show the yearly monthwise issued requisition
        private void yearlyRequisitionButton_Click(object sender, EventArgs e)
        {
            ShowData("9", getMonthYear("3", null, yearDatePicker.Text.Trim()), null);   
        }        

        //Show the yearly selected department issued requisition monthwise
        private void departmentalYearlyRequisitionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(departmentComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a deparmtment.");
                departmentComboBox.Focus();
            }
            else
            {
                ShowData("10", getMonthYear("3", null, yearDatePicker.Text.Trim()), departmentComboBox.SelectedValue.ToString());
            }
        }        

        //Show the selected requisition 
        private void searchRequisitionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(requisitionNoTextBox.Text.Trim()))
            {
                MessageBox.Show("Enter a requisition");
                requisitionNoTextBox.Focus();
            }
            else
            {
                switch (requisitionTabControl.SelectedIndex)
                {
                    case 0: //pending
                        ShowData("4", requisitionNoTextBox.Text.Trim(),null);
                        break;
                    case 1: //issued
                        ShowData("5", requisitionNoTextBox.Text.Trim(), null);
                        break;
                }
            }
        }

        #region Get Month/Year
        private string getMonthYear(string choice, string month, string year)
        {
            string strMonth = null, strYear = null, yearMonth = null;

            try
            {
                //get the month
                if (string.IsNullOrEmpty(month))
                {
                    strMonth = monthToNumber(DateTime.Now.ToString("MMMM").Trim());
                }
                else
                {
                    strMonth = monthToNumber(month);
                }

                //get the year
                if (string.IsNullOrEmpty(year))
                {
                    strYear = DateTime.Now.ToString("yyyy");
                }
                else if (year.Length < 4)
                {
                    strYear = DateTime.Now.ToString("yyyy");
                }
                else
                {
                    strYear = year.Trim();
                }

                switch (choice.Trim())
                {
                    case "1":
                        //format yymm(1308)
                        yearMonth = strYear.Trim().Substring(2) + strMonth;
                        break;
                    case "2":
                        //format yyyymm (201308)
                        yearMonth = strYear + strMonth;
                        break;
                    case "3":
                        //format yyyy (2013)
                        yearMonth = strYear;
                        break;
                }
            }
            catch
            {
                return null;
            }
            return yearMonth;
        }

        private string monthToNumber(string str_Month)
        {
            string monthNo = DateTime.ParseExact(str_Month, "MMMM", CultureInfo.CurrentCulture).Month.ToString();
            try
            {
                if (monthNo.Length == 1)
                {
                    return "0" + monthNo;
                }
                else if (monthNo.Length > 1)
                {
                    return monthNo;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

        

        

        
    }
}
