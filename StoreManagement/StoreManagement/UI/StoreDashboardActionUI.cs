using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using CrystalDecisions;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.UTILITY;
using StoreManagement.Reports.StoreDashBoard.GeneralStock;
using StoreManagement.Reports.StoreDashBoard.Consumption;
using StoreManagement.Reports.StoreDashBoard.TotalIssue;
using StoreManagement.Reports.StoreDashBoard.FinalStatement;
using StoreManagement.Reports.StoreDashBoard.Accounts;



namespace StoreManagement.UI
{
    public partial class StoreDashboardActionUI : Form
    {
        #region Variables
            private DynamicControlFill fillControll = null;
            private PurchaseManager purchaseManager = null;
            private StoreManager storeManager = null;
            private MasterSetupManager settingsManager = null;
            private bool IsState = true;
            private Int32 i = 70;
        #endregion

        public StoreDashboardActionUI()
        {
            InitializeComponent();
            SetObjets();
        }

        private void SetObjets()
        {
            fillControll = new DynamicControlFill();
            purchaseManager = new PurchaseManager();
            storeManager = new StoreManager();
            settingsManager = new MasterSetupManager();
        }

        private ListView CreateListView()
        {
            try
            {
                storeViewPanel.Dock = DockStyle.Fill;
                storeViewPanel.SuspendLayout();
                this.SuspendLayout();
                storeViewPanel.Controls.Clear();

                ListView lstView = new ListView();

                //Start:Design

                lstView.GridLines = true;
                lstView.TabIndex = 0;
                lstView.UseCompatibleStateImageBehavior = false;
                lstView.View = System.Windows.Forms.View.Details;
                lstView.FullRowSelect = true;
                //End:Design

                storeViewPanel.Controls.Add(lstView);
                storeViewPanel.ResumeLayout(false);
                this.ResumeLayout(false);
                lstView.Dock = DockStyle.Fill;


                return lstView;
            }
            catch
            {
                return null;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Font = new Font("Tahoma", 8.25F, FontStyle.Underline);
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
        }

        private void StoreDashboardUI_Load(object sender, EventArgs e)
        {
            fillControll.FillMonth(gsMonthComboBox);
            fillControll.FillMonth(bcMonthComboBox);
            fillControll.FillMonth(tiMonthComboBox);
            fillControll.FillMonth(fsMonthComboBox);
            fillControll.FillMonth(acMonthComboBox);

            //fill the department combobox
            fillControll.fillCombo(bcDepartmentComboBox, settingsManager.GetDepartmentList("3", null), "Department", "Code");
            bcDepartmentComboBox.SelectedIndex = -1;

            //fill the stationary category combobox  in bpl consumption menu
            fillControll.fillCombo(bcCategoryComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            bcCategoryComboBox.SelectedIndex = -1;

            //fill the stationary category combobox  in total issue manu
            fillControll.fillCombo(tiCategoryComboBox, settingsManager.GetStationaryCategoryList("1", null), "Category", "Code");
            tiCategoryComboBox.SelectedIndex = -1;

            //fill the department combobox in accounts menu
            fillControll.fillCombo(acDepartmentComboBox, settingsManager.GetDepartmentList("3", null), "Department", "Code");
            acDepartmentComboBox.SelectedIndex = -1;

            CreateNodes(new MasterSetupManager().GetItemList("5", null),itemTreeView);
            CreateNodes(new MasterSetupManager().GetItemList("5", null), fsItemTreeView);

            #region Events 
            //Lebel click
                //mdWiseLabel.Click += new EventHandler(Label_Click);
                //ydWiseLabel.Click += new EventHandler(Label_Click);
                //dcInaMonthLabel.Click += new EventHandler(Label_Click);
                //dcInaYearLabel.Click += new EventHandler(Label_Click);
                //cdInaMonthLabel.Click += new EventHandler(Label_Click);
            //cdInaYearLabel.Click += new EventHandler(Label_Click);
            #endregion  //End Label Click
            #region Label Mouse Over
                //Start:General Stock
                    gsMonthlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    gsYearlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                //End:General Stock

                //Start:BPL Consumption
                    bcDWiseMonthlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    bcDWiseYearlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    bcCforDInaMonthReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    bcCforDInaYearReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                //End:BPL Consumption

                //Start:Total Issue
                    tiDeptWiseMonthlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    tiDeptWiseYearlyReportLlabel.MouseHover += new EventHandler(Label_MouseHover);
                    tiCatDeptWiseInMonthlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    tiCatDeptWiseInYearReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                //End:Total Issue

                //Start:Final Statement
                    fsMonthlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    fsYearlyReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                //End:Final Statement

                //Start:Accounts
                    accMonthlyDeptWiseReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    accYearlyDeptWiseReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                    accDptMwiseInYearReportLabel.MouseHover += new EventHandler(Label_MouseHover);
                //End:Accounts
                
            #endregion  //End Label Mouse Over

            #region Label Mouse Leave 
                //Start:General Stock
                    gsMonthlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    gsYearlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                //End:General Stock
                
                //Start:BPL Consumption
                    bcDWiseMonthlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    bcDWiseYearlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    bcCforDInaMonthReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    bcCforDInaYearReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                //End:BPL Consumption

                //Start:Total Issue
                    tiDeptWiseMonthlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    tiDeptWiseYearlyReportLlabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    tiCatDeptWiseInMonthlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    tiCatDeptWiseInYearReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                //End:Total Issue

                //Start:Final Statement
                    fsMonthlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    fsYearlyReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                //End:Final Statement

                //Start: Accounts
                    accMonthlyDeptWiseReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    accYearlyDeptWiseReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                    accDptMwiseInYearReportLabel.MouseLeave += new EventHandler(Label_MouseLeave);
                //End: Accounts
            #endregion  //End Label Mouse Leave           
        }

        private void naviBar1_ActiveBandChanged(object sender, EventArgs e)
        {
            ListView lstView = null;
            Guifreaks.NavigationBar.NaviBar navBar = (Guifreaks.NavigationBar.NaviBar)sender;
            try
            {
                lstView = CreateListView();
                switch (navBar.ActiveBand.Tag.ToString().Trim())
                {
                    case "1":
                        //General stock
                        label2.Text = navBar.ActiveBand.Text + " for the month of " + gsMonthComboBox.Text.Trim() + ", " + DateTime.Now.Year;
                        //i = 175;
                        //lstView = CreateListView();
                        fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("1", "1", null,null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Balance,Rate,Amount,,,", "50,230,60,65,60,65,65,60,65,65,100,,,",false);
                        fillControll.BuildGroups(11, lstView, false);
                        closingButton.Visible = false;     
                        break;
                    case "2":
                        //BPL Consumption
                        label2.Text = navBar.ActiveBand.Text + " for the month of " + bcMonthComboBox.Text.Trim() + ", " + DateTime.Now.Year;
                        //i = 280;
                        //lstView = CreateListView();
                        fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("2", "1", null, null), "Item,Issued Qty,Unit,Amount,Category,", "230,90,60,110,100,", false);
                        fillControll.BuildGroups(5, lstView, false);
                        closingButton.Visible = false;     
                        break;
                    case "3":
                        //Total Issue
                        label2.Text = navBar.ActiveBand.Text + " for the month of " + tiMonthComboBox.Text.Trim() + ", " + DateTime.Now.Year;
                        //i = 385;
                        fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("3", "1", null, null), "Item,Issued Qty,Unit,Category,", "230,90,60,100,", false);
                        fillControll.BuildGroups(4, lstView, false);
                        closingButton.Visible = false;     
                        break;
                    case "4":
                        //Stock Statement                        
                        int mthNumber = storeManager.GetStoreClosingMonth("1");
                        label2.Text = navBar.ActiveBand.Text + " for the month of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber) + ", " + DateTime.Now.Year;

                        //i = 490;
                        //lstView = CreateListView();
                        fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("4", "1", null, null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Total,Total Value,Issued,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,60,80,60,65,60,65,65,100,", false);
                        fillControll.BuildGroups(16, lstView, false);
                        GetTheClosingMonth();
                        break;
                    case "5":
                        //Accounts
                        label2.Text = navBar.ActiveBand.Text + " for the month of " + acMonthComboBox.Text.Trim() + ", " + DateTime.Now.Year;
                        //i = 595;
                        //lstView = CreateListView();
                        fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("5", "1", null, null), "Stationary Category,Cost Head, Amount,", "150,150,200,", false);
                        fillControll.BuildGroups(3, lstView, false);
                        closingButton.Visible = false;     
                        break;
                }
            }
            finally
            {
                lstView = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNodes(new MasterSetupManager().GetItemList("5", null),itemTreeView);            
        }

        #region TreeView Fill
        //TODO: Need to work with TreeView Fill, 
        //dosen't work with third lavel, upto second level works fine

        static string noteID;     

        private void CreateNodes(DataTable dt,TreeView itemTree)
        {
            try
            {
                DataRow[] rows = new DataRow[dt.Rows.Count];
                dt.Rows.CopyTo(rows, 0);
                //doneNotes = new List<int>(9);

                // Get the TreeView ready for node creation.
                // This isn't really needed since we're using AddRange (but it's good practice).
                itemTree.BeginUpdate();
                itemTree.Nodes.Clear();

                TreeNode[] nodes = RecurseRows(dt, rows);
                itemTree.Nodes.AddRange(nodes);

                // Notify the TreeView to resume painting.
                itemTree.EndUpdate();
            }
            catch { }
        }

        private TreeNode[] RecurseRows(DataTable dt, DataRow[] rows)
        {
            string expression;
            List<TreeNode> nodeList = new List<TreeNode>();
            TreeNode node = null;

            foreach (DataRow dr in rows)
            {
                
                node = new TreeNode(dr["NodeName"].ToString());
                noteID = dr["NodeID"].ToString().Trim();

                node.Name = noteID;
                node.ToolTipText = noteID;
                node.Tag = dr["CategoryID"].ToString().Trim();

                // This method searches the "dirty node list" for already completed nodes.
                //if (!doneNotes.Contains(doneNoteID))

                // This alternate method using the Find method uses a Predicate generic delegate.
                if (nodeList.Find(FindNode) == null)
                {
                    DataRow[] childRows;
                    expression = "PNode = '" + dr["NodeID"].ToString().Trim() + "'";

                    childRows = dt.Select(expression);
                    if (childRows.Length > 0)
                    {
                        // Recursively call this function for all childRowsl
                        TreeNode[] childNodes = RecurseRows(dt, childRows);

                        // Add all childnodes to this node.
                        node.Nodes.AddRange(childNodes);
                        //nodeList.Add(node);
                    }  
                    
                    // Mark this noteID as dirty (already added).
                    //doneNotes.Add(noteID);

                    if (dr["Status"].ToString().Trim() == "0")
                        break;
                    nodeList.Add(node);
                }
            }

            // Convert this List<TreeNode> to an array so it can be added to the parent node/TreeView.
            TreeNode[] nodeArr = nodeList.ToArray();
            return nodeArr;
        }

        private static bool FindNode(TreeNode n)
        {
            if (n.Nodes.Count == 0)
                return n.Name == noteID.Trim();
            else
            {
                while (n.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in n.Nodes)
                    {
                        if (tn.Name == noteID.Trim())
                            return true;
                        else
                            n = tn;
                    }
                }
                return false;
            }
        }

        protected void ColorNodes(TreeNode root, Color firstColor, Color secondColor)
        {
            root.ForeColor = root.Index % 2 == 0 ? firstColor : secondColor;

            foreach (TreeNode childNode in root.Nodes)
            {
                Color nextColor = childNode.ForeColor = childNode.Index % 2 == 0 ? firstColor : secondColor;

                if (childNode.Nodes.Count > 0)
                {
                    // alternate colors for the next node
                    if (nextColor == firstColor)
                        ColorNodes(childNode, secondColor, firstColor);
                    else
                        ColorNodes(childNode, firstColor, secondColor);
                }
            }
        }
        #endregion

        private void itemTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ListView lstView = CreateListView();
            TreeNode tn = e.Node;
            if (tn.Nodes.Count > 0)
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("1", "2", tn.Tag.ToString().Trim(),null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,65,65,100,", false);
                fillControll.BuildGroups(11, lstView, false);
                ShowSubCategory(null);
            }
            else
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("1", "3", tn.Tag.ToString().Trim(), null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,65,65,100,", false);
                fillControll.BuildGroups(11, lstView, false);
                ShowSubCategory(tn.Tag.ToString());
                categoryLabel.Text = tn.Name.ToString() + " subcategory";
            }
        }

        private void ShowSubCategory(string itemID)
        {
            try
            {
                //unset the item category combo event
                this.itemCategoryComboBox.SelectedIndexChanged -= new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);

                fillControll.fillCombo(itemCategoryComboBox, settingsManager.GetItemSubCategoryList("3", itemID), "SubCategory", "Code");
                itemCategoryComboBox.SelectedIndex = -1;

                //set the item category combo event
                this.itemCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.itemCategoryComboBox_SelectedIndexChanged);
            }
            catch
            {
                itemCategoryComboBox.DataSource = null;
                itemCategoryComboBox.Items.Clear();
            }
        }

        private void itemCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lstView = CreateListView();
            try
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("1", "4", itemCategoryComboBox.SelectedValue.ToString(), null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,65,65,100,", false);
                fillControll.BuildGroups(11, lstView, false);
            }
            catch
            {
                lstView = null;
            }
        }

        #region Report Management

        #region Get Month/Year
        private string getMonthYear(string choice,string month, string year)
        {
            string strMonth = null, strYear = null,yearMonth = null;

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
                    strYear = DateTime.Now.ToString("yy");
                }
                else if (year.Length < 4)
                {
                    strYear = DateTime.Now.ToString("yy");
                }
                else
                {
                    strYear = year.Trim().Substring(2);
                }

                switch (choice.Trim())
                {
                    case "1":
                        //format yymm(1308)
                        yearMonth = strYear + strMonth;
                        break;
                    case "2":
                        //format yyyymm (201308)
                        yearMonth = year + strMonth;
                        break;
                    case "3":
                        //format yyyy (2013)
                        yearMonth = year;
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

        //show reports
        private void ShowReport(string choice,string condition)
        {
            CrystalReportViewer reportViewer = CreateReportView();
            ReportClass dashBoardReport = null;
            DataTable Dt = null;
            try
            {
                switch (choice.Trim())
                {
                    //Start: General Stock
                    case "1":
                        //monthly categorywise report
                        label2.Text = gsMonthlyReportLabel.Text + "report for the month of " + gsMonthComboBox.Text.Trim() + ", " + gsYearPicker.Text;

                        dashBoardReport = new MonthlyGeneralStockReport();
                        Dt = storeManager.GetStoreDeshBoardData("1", "5", getMonthYear("1",gsMonthComboBox.Text.Trim(), gsYearPicker.Text.Trim()), null);
                        break;
                    case "2":
                        //yarly categorywise report
                        label2.Text = gsYearlyReportLabel.Text + "report for the year of " + gsYearPicker.Text;

                        dashBoardReport = new YearlyGeneralStockReport();
                        Dt = storeManager.GetStoreDeshBoardData("1", "6", getMonthYear("1", gsMonthComboBox.Text.Trim(), gsYearPicker.Text.Trim()), null);
                        break;
                    //End: General Stock

                    //Start:BPL Consumption
                    case "3":
                        //monthly departmentwise consumption 
                        label2.Text = "Department wise consumption for the month of " + bcMonthComboBox.Text.Trim() + ", " + bcYearPicker.Text;

                        dashBoardReport = new monthlyDeptWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "2", getMonthYear("2", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), null);
                        break;
                    case "4":
                        //yearly departmentwise consumption
                        label2.Text = "Department wise consumption for the year of " + bcYearPicker.Text;

                        dashBoardReport = new yearlyDeptWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "3", getMonthYear("3", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), null);;
                        break;
                    case "5":
                        //monthley category consumption of departmentwise report
                        label2.Text = bcCategoryComboBox.Text + " category department wise consumption for the month of " + bcMonthComboBox.Text.Trim() + ", " + bcYearPicker.Text;
                        
                        dashBoardReport = new monthlyCatDepartWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "4", getMonthYear("2", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), condition);
                        break;
                    case "6":
                        //yarly category consumption of departmentwise report
                        label2.Text = bcCategoryComboBox.Text + " category department wise consumption for the year of " + bcYearPicker.Text;

                        dashBoardReport = new yearlyCatDepartmentWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "5", getMonthYear("3", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), condition);
                        break;
                    case "7":
                        // department monthly categorywise report 
                        label2.Text = "Department category wise consumption for the month of " + bcMonthComboBox.Text.Trim() + ", " + bcYearPicker.Text;

                        dashBoardReport = new monthlyDeptWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "6", getMonthYear("2", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), condition);
                        break;
                    case "8":
                        //department yearly categorywise report
                        label2.Text = "Department category wise consumption for the year of " + bcYearPicker.Text;

                        dashBoardReport = new yearlyDeptWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "7", getMonthYear("3", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), condition); ;
                        break;
                    case "88":
                        //department yearly categorywise report
                        label2.Text = "Item department wise consumption for the month of " + bcMonthComboBox.Text.Trim() + ", " + bcYearPicker.Text;

                        dashBoardReport = new monthlyCatItemDepartWiseConsumption();
                        Dt = storeManager.GetStoreDeshBoardData("2", "8", getMonthYear("2", bcMonthComboBox.Text.Trim(), bcYearPicker.Text.Trim()), condition); ;
                        break;
                    //End:BPL Consumption

                    //Start:Total Issue
                    case "9":
                        //departmentwise monthly total issue report
                        label2.Text = "Department total issue for the month of " + tiMonthComboBox.Text.Trim() + ", " + tiYearPicker.Text;

                        dashBoardReport = new monthlyDeptWiseIssue();
                        Dt = storeManager.GetStoreDeshBoardData("3", "2", getMonthYear("2", tiMonthComboBox.Text.Trim(), tiYearPicker.Text.Trim()), condition); ;
                        break;
                    case "10":
                        //departmentwise yearly total issue report
                        label2.Text = "Department total issue for the year of " + tiYearPicker.Text;

                        dashBoardReport = new yearlyDeptWiseIssue();
                        Dt = storeManager.GetStoreDeshBoardData("3", "3", getMonthYear("3", tiMonthComboBox.Text.Trim(), tiYearPicker.Text.Trim()), condition); ;
                        break;
                    case "11":
                        //selected category departmentwise monthly total issue report
                        label2.Text = tiCategoryComboBox.Text + " category department wise total issue for the month of " + tiMonthComboBox.Text.Trim() + ", " + tiYearPicker.Text;

                        dashBoardReport = new monthlyCategoryDeptWiseIssue();
                        Dt = storeManager.GetStoreDeshBoardData("3", "4", getMonthYear("2", tiMonthComboBox.Text.Trim(), tiYearPicker.Text.Trim()), condition); ;
                        break;
                    case "12":
                        //selected category departmentwise yearly total issue report
                        label2.Text = tiCategoryComboBox.Text + " category department wise total issue for the year of " + tiYearPicker.Text;
                        
                        dashBoardReport = new yearlyCategoryDeptWiseIssue();
                        Dt = storeManager.GetStoreDeshBoardData("3", "5", getMonthYear("3", tiMonthComboBox.Text.Trim(), tiYearPicker.Text.Trim()), condition); ;
                        break;
                    //End:Total Issue

                    //Start:Final Statements
                    case "13":
                        //selected category departmentwise monthly final statement report
                        label2.Text = " Department wise final statement for the month of " + fsMonthComboBox.Text.Trim() + ", " + fsYearPicker.Text;

                        dashBoardReport = new MonthlyFinalStatementReport();
                        Dt = storeManager.GetStoreDeshBoardData("4", "5", getMonthYear("2", fsMonthComboBox.Text.Trim(), fsYearPicker.Text.Trim()), condition); ;
                        break;
                    case "14":
                        //selected category departmentwise yearly total issue report
                        //dashBoardReport = new yearlyCategoryDeptWiseIssue();
                        //Dt = storeManager.GetStoreDeshBoardData("4", "3", getMonthYear("3", fsMonthComboBox.Text.Trim(), fsYearPicker.Text.Trim()), condition); ;
                        break;
                    //End:Final Statements

                    //Start:Accouts
                    case "15":
                        //Monthly departmentwise accouts report
                        label2.Text = " Department wise accounts for the month of " + acMonthComboBox.Text.Trim() + ", " + acYearPicker.Text;

                        dashBoardReport = new MonthlyDeptWiseAccountsReport();
                        Dt = storeManager.GetStoreDeshBoardData("5", "2", getMonthYear("2", acMonthComboBox.Text.Trim(), acYearPicker.Text.Trim()), condition); ;
                        break;
                    case "16":
                        //Yearly departmentwise accouts report
                        label2.Text = " Department wise accounts for the year of " + acYearPicker.Text;

                        dashBoardReport = new YearlyDeptWiseAccountsReport();
                        Dt = storeManager.GetStoreDeshBoardData("5", "3", getMonthYear("3", acMonthComboBox.Text.Trim(), acYearPicker.Text.Trim()), condition); ;
                        break;
                    case "17":
                        //Yearly departments monthwise accouts report
                        label2.Text = " Yearly Departments month wise accounts ";

                        dashBoardReport = new YearlyDeptMonthWiseAccountsReport();
                        Dt = storeManager.GetStoreDeshBoardData("5", "4", getMonthYear("3", acMonthComboBox.Text.Trim(), acYearPicker.Text.Trim()), condition); ;
                        break;
                    //End:Total Issue
                }

                if (Dt != null && Dt.Rows.Count > 0)
                {
                    //reportViewer = CreateReportView();
                    dashBoardReport.Database.Tables[0].SetDataSource(Dt);
                    reportViewer.ReportSource = dashBoardReport;
                    reportViewer.Refresh();
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
            catch { }
        }

        //create the ReportViewer
        private CrystalReportViewer CreateReportView()
        {
            try
            {
                storeViewPanel.Dock = DockStyle.Fill;
                storeViewPanel.SuspendLayout();
                this.SuspendLayout();
                storeViewPanel.Controls.Clear();

                CrystalReportViewer reportViewer = new CrystalReportViewer();

                //Start:Design
                reportViewer.ActiveViewIndex = -1;
                reportViewer.BorderStyle = BorderStyle.FixedSingle;
                reportViewer.Cursor = Cursors.Default;
                reportViewer.Location = new Point(21, 252);
                reportViewer.Name = "reportViewer";
                reportViewer.ShowGroupTreeButton = false;
                reportViewer.ShowParameterPanelButton = false;
                reportViewer.ShowZoomButton = false;
                reportViewer.Size = new System.Drawing.Size(590, 253);
                reportViewer.TabIndex = 6;
                reportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //End:Design

                storeViewPanel.Controls.Add(reportViewer);
                storeViewPanel.ResumeLayout(false);
                this.ResumeLayout(false);
                reportViewer.Dock = DockStyle.Fill;

                //reportViewer.RefreshReport();

                return reportViewer;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region General Stock Report

        private void gsMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gsMonthComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a month.");
                gsMonthComboBox.Focus();
            }
            else
            {
                ShowReport("1",null);
            }
        }

        private void gsYearlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("2",null);
        }

        #endregion

        #region Consumption Report

        private void bcDWiseMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("3",null);            
        }

        private void bcDWiseYearlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("4",null);
        }

        private void bcCforDInaMonthReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcCategoryComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a category.");
                bcCategoryComboBox.Focus();
            }
            else
            {
                ShowReport("5",bcCategoryComboBox.SelectedValue.ToString().Trim());
            }
        }

        private void bcCforDInaYearReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcCategoryComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a category.");
                bcCategoryComboBox.Focus();
            }
            else
            {
                ShowReport("6", bcCategoryComboBox.SelectedValue.ToString().Trim());
            }
        }

        private void bcDeptMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcDepartmentComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a department.");
                bcDepartmentComboBox.Focus();
            }
            else
            {
                ShowReport("7", bcDepartmentComboBox.SelectedValue.ToString().Trim());
            }
        }

        private void bcDeptYearlyReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcDepartmentComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a department.");
                bcDepartmentComboBox.Focus();
            }
            else
            {
                ShowReport("8", bcDepartmentComboBox.SelectedValue.ToString().Trim());
            }
        }

        private void bcCItemforDInaMonthReportLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcCategoryComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a category.");
                bcCategoryComboBox.Focus();
            }
            else
            {
                ShowReport("88", bcCategoryComboBox.SelectedValue.ToString().Trim());
            }
        }

        #endregion

        #region Total Issue

        private void tiDeptWiseMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("9", null);
        }

        private void tiDeptWiseYearlyReportLlabel_Click(object sender, EventArgs e)
        {
            ShowReport("10", null);
        }

        private void tiCatDeptWiseInMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tiCategoryComboBox.Text))
            {
                ShowReport("11", tiCategoryComboBox.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Select a category.");
                tiCategoryComboBox.Focus();
            }
        }

        private void tiCatDeptWiseInYearLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tiCategoryComboBox.Text))
            {
                ShowReport("12", tiCategoryComboBox.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Select a category.");
                tiCategoryComboBox.Focus();
            }
        }

        #endregion

        #region Final Statement

        private void fsMonthlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("13", null);
        }

        private void fsYearlyReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("14", null);
        }

        private void fsItemTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ListView lstView = CreateListView();
            TreeNode tn = e.Node;
            if (tn.Nodes.Count > 0)
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("4", "2", tn.Tag.ToString().Trim(), null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Total,Total Value,Issued,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,60,80,60,65,60,65,65,100,", false);
                fillControll.BuildGroups(16, lstView, false);
                ShowFsSubCategory(null);
            }
            else
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("4", "3", tn.Tag.ToString().Trim(), null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Total,Total Value,Issued,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,60,80,60,65,60,65,65,100,", false);
                fillControll.BuildGroups(16, lstView, false);
                ShowFsSubCategory(tn.Tag.ToString());
                fsCategoryLabel.Text = tn.Name.ToString() + " subcategory";
            }
        }

        private void ShowFsSubCategory(string itemID)
        {
            try
            {
                //unset the item category combo event
                this.fsItemCategoryComboBox.SelectedIndexChanged -= new System.EventHandler(this.fsItemCategoryComboBox_SelectedIndexChanged);

                fillControll.fillCombo(fsItemCategoryComboBox, settingsManager.GetItemSubCategoryList("3", itemID), "SubCategory", "Code");
                fsItemCategoryComboBox.SelectedIndex = -1;

                //set the item category combo event
                this.fsItemCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.fsItemCategoryComboBox_SelectedIndexChanged);
            }
            catch
            {
                fsItemCategoryComboBox.DataSource = null;
                fsItemCategoryComboBox.Items.Clear();
            }
        }

        private void fsItemCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lstView = CreateListView();
            try
            {
                fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("4", "4", fsItemCategoryComboBox.SelectedValue.ToString(), null), "Code,Item,Opening,Rate,Amount,Received,Rate,Amount,Total,Total Value,Issued,Rate,Amount,Balance,Rate,Amount,", "50,230,60,65,60,65,65,60,60,80,60,65,60,65,65,100,", false);
                fillControll.BuildGroups(16, lstView, false);
            }
            catch
            {
                lstView = null;
            }
        }
        #endregion

        #region Accounts Report

        private void accMonthlyDeptWiseReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("15", null);
        }

        private void accYearlyDeptWiseReportLabel_Click(object sender, EventArgs e)
        {
            ShowReport("16", null);
        }

        private void accDptMwiseInYearReportLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(acDepartmentComboBox.Text))
            {
                ShowReport("17", acDepartmentComboBox.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Select a department.");
                acDepartmentComboBox.Focus();
            }
        }

        #endregion

        private void gStockNaviBand_Click(object sender, EventArgs e)
        {

        }

        private void bplConsumNaviBand_Click(object sender, EventArgs e)
        {

        }

        private void closingButton_Click(object sender, EventArgs e)
        {
            ListView lstView = null;
            try
            {
                if (IsValid())
                {
                    if (MessageBox.Show("Closing....?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (storeManager.ManageMonthlyClosing(DateTime.Now.ToString("yyMM")))
                        {
                            GetTheClosingMonth();
                            lstView = CreateListView();

                            fillControll.fillListView(lstView, storeManager.GetStoreDeshBoardData("3", "1", null, null), "Item,Issued Qty,Unit,Category,", "230,90,60,100,", false);
                            fillControll.BuildGroups(4, lstView, false);
                        }
                    }
                }
            }
            finally
            {
                lstView = null;
            }
        }

        private bool IsValid()
        {
            try
            {
                int mthNumber = storeManager.GetStoreClosingMonth("1");
                string yearMonth = getMonthYear("2", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber).Trim(), DateTime.Now.ToString("yyyy").Trim());
                Int32 count = storeManager.GetPendingGrrToPostingList("1", yearMonth);

                if (count > 0)
                {
                    MessageBox.Show("There are pending GRR of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber).Trim() + " for stock posting, please try again after GRR posting");
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        //Dysplay the Current stock month
        private void GetTheClosingMonth()
        {
            int currentMonth;
            int mthNumber = storeManager.GetStoreClosingMonth("1");
            currentMonth = DateTime.Now.Month;

            closingButton.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mthNumber) + " Closing";           


            if (mthNumber == 12)
            {
                if (currentMonth == 1)
                {
                    closingButton.Visible = true;  
                }
            }
            else
            {
                if (currentMonth == (mthNumber + 1))
                {
                    closingButton.Visible = true;                    
                }
                else
                {
                    closingButton.Visible = false;                    
                }
            }
        }

        

        

        

        

        
        






















    }
}
