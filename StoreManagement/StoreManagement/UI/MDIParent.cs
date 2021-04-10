using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.UI;
using StoreManagement.DAL.DAO;
using StoreManagement.UTILITY;
using StoreManagement.UTILITY.CustomeControl;
using System.Collections;
using CustomBorderOfForm;
using Timer = System.Timers.Timer;

namespace StoreManagement.UI
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MDIParent : LonghornForm
    {
        #region variables & objects
            private Form commonForm = null;
            private LoginUI loginUser = null;
            private UserManager userManager = null;
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControl = null;
            private bool logoutFlag = false;
            private Timer timer = null;
            private long syncPoint;
        #endregion
        
        public MDIParent()
        {
            InitializeComponent();
            SetObjects();
        }

        //intialize the global variables
        private void SetObjects()
        {
            userManager = new UserManager();
            fillControl = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
        }

        private void UserInformation()
        {
            DataTable dt = userManager.GetUserInfoFromPIS("2", Verification.verifyEmployeeID(LoginUser.UserID));
            if (dt != null && dt.Rows.Count > 0)
            {
                userInfoLabel.Text = "Account owner" + Environment.NewLine +
                                      dt.Rows[0]["Name"].ToString();
                if ((dt.Rows[0]["Picture"]) != DBNull.Value)
                {
                    fillControl.fillPictureBox(dt.Rows[0]["Picture"], userPictureBox);
                }
            }

            //dt = settingsManager.GetDepartmentList("2", LoginUser.DepartmentOfUnit.ToString());
            //if (dt.Rows.Count > 0)
            //{
            //    departmentToolStripStatusLabel.Text = "Department : " + dt.Rows[0]["Dept"].ToString();
            //}
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            UserInformation();

            LoginUser.ServerDateTime = settingsManager.GetServerDateTime("1");

            if (string.Compare(DateTime.Now.Date.ToString("yyyyMMdd").Trim(), LoginUser.ServerDateTime.Trim()) == 0)
            {
                CreateLeftMenu();
            }
            else
            {
                LockSoftwareOnDateChange("1");
            }
            
            //ProcessFlowUI processFlow = new ProcessFlowUI();
            //processFlow.MdiParent = this;
            //processFlow.Show();
        }

        private void LockSoftwareOnDateChange(string choice)
        {
            processFlowPanel.Visible = true;
            errorLabel.BackColor = Color.Yellow;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Font = new Font("Tahoma", 20F, FontStyle.Bold);

            switch(choice)
            {
                case "1":
                    errorLabel.Text = "System date and server date mismatched, please fix your system date, then login again.";
                    break;

                case "2":
                    errorLabel.Text = "System date and server date mismatched, please fix your system date, then try again.";
                    break;
            }

            timer = new Timer();
            timer.Interval = 1000; //1 sec
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            syncPoint = 0;
            timer.Start();
        }

        #region System Time Mismatched with Server  
        /*help LInk : http://www.daniweb.com/software-development/csharp/threads/221584/how-do-i-make-a-label-blink */

        delegate void Blink();
        private bool boolState = true;
        private void BlinkLabel()
        {
            Blink del = (Blink)delegate 
            { 
                //errorLabel.Visible = !errorLabel.Visible; 
                if (boolState)
                {
                    errorLabel.ForeColor = Color.Green;
                }
                else
                {                    
                    errorLabel.ForeColor = Color.Red;
                }
                boolState = !boolState;
            };
            if (errorLabel.InvokeRequired)
                errorLabel.Invoke(del);
            else
                del();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            long sync = System.Threading.Interlocked.CompareExchange(ref syncPoint, 1, 0);
            if (sync == 0)
            {
                try
                {
                    BlinkLabel();
                }
                finally
                {
                    syncPoint = 0;
                }
            }
        }
        #endregion

        private void CreateLeftMenu()
        {
            //ArrayList NavItems = new ArrayList();
            //ArrayList childNavItems = new ArrayList();
            //SlidingMenu.NavItem nv = null;

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Users", "mnuUsers"));
            //nv = new SlidingMenu.NavItem(" User Settings", "mnuUserSettings", childNavItems, true);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Company && Departments", "mnuCompanyDepartment"));
            //nv = new SlidingMenu.NavItem(" Company Settings", "mnuCompanySettings", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Supplier", "mnuSupplier"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Manufacturer", "mnuManufacturer"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Store Items", "mnuStoreItems"));
            //nv = new SlidingMenu.NavItem(" Settings", "mnuSettingsManagement", childNavItems, true);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Pending Requisition", "mnuPendingRequisition"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Store Dashboard", "mnuStoreDashboard"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Purchase Requisition", "mnuPurchaseRequisition"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Emergency Order", "mnuEmergencyOrder"));
            //childNavItems.Add(new SlidingMenu.childNavItems("GRR Receive", "mnuGRRReceive"));
            //nv = new SlidingMenu.NavItem("Store Tasks", "mnuStoreTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Supplier Enlistment", "mnuPurchaseSupplierEnlistment"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Requisition Process", "mnuPurchaseRequisitionProcess"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Quotation Management", "mnuPurchaseQuotationManagement"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Tender Finalize", "mnuPurchaseTenderFinalize"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Purchase Order", "mnuPurchaseOrder"));
            //nv = new SlidingMenu.NavItem("Purchase Tasks", "mnuPurchaseTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Supplier Enlistment", "mnuMISSupplierEnlistment"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Requisition Process", "mnuMISPurchaseRequisitionProcess"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Quotation Management", "mnuMISQuotationManagement"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Tender Finalize", "mnuMisTenderFinalize"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Purchase Order", "mnuMISPurchaseOrder"));
            //nv = new SlidingMenu.NavItem("MIS Tasks", "mnuMISPurchaseTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Order Inspection", "mnuOrderInspection"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Inspection Summery", "mnuInspectionSummery"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Certificate Approval", "mnuCertificateApproval"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Inspector Settings", "mnuInspectorSetting"));
            //nv = new SlidingMenu.NavItem("FSD Tasks", "mnuFSDTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Requisition Approval", "mnuRequisitionApproval"));
            //childNavItems.Add(new SlidingMenu.childNavItems("Management Dashboard", "mnuManagementDashboard"));
            //nv = new SlidingMenu.NavItem("Authority Tasks", "mnuAuthorityTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Store Requisition", "mnuStoreRequisition"));
            //nv = new SlidingMenu.NavItem("User Tasks", "mnuUserTasks", childNavItems);
            //NavItems.Add(nv);

            //childNavItems = new ArrayList();
            //childNavItems.Add(new SlidingMenu.childNavItems("Password Change", "mnuPasswordChange"));
            //nv = new SlidingMenu.NavItem("Personal Settings", "mnuSettings", childNavItems);
            //NavItems.Add(nv);

            //leftMenu.MenuItems = NavItems;


            leftMenu.MenuItems = userManager.GetMenuList(LoginUser.UID);
            leftMenu.RenderMenu();
        }

        private void ShowForm(string choice, Button btn)
        {
            switch (choice)
            {
                //START: Settings Menus
                case "mnuUsers":
                    //User management 
                    formLabel.Text = "   User Settings";
                    ShowForm(new UserManagementActionUI());
                    break;
                case "mnuCompanyDepartment":
                    //Company settings
                    formLabel.Text = "   Company Settings";
                    ShowForm(new CompanySettingsUI());
                    break;
                case "mnuSupplier":
                    //Supplier Settings
                    formLabel.Text = "   Supplier Settings";
                    ShowForm(new SupplierSettingsUI());
                    break;
                case "mnuManufacturer":
                    //Menufacturer Settings
                    formLabel.Text = "   Manufacturer Settings";
                    ShowForm(new ManufacturerSettingsUI());
                    break;
                case "mnuStoreItems":
                    //Item Settings
                    formLabel.Text = "   Stationary Items Settings";
                    ShowForm(new StationerySettingsUI());
                    break;
                //END : Settings Menus

                //START : Store Menus
                case "mnuBudgetManagement":
                    //Budget Settings
                    formLabel.Text = "   Budget Management";
                    ShowForm(new DeptBudgetSettingsActionUI());
                    break;
                case "mnuPendingRequisition":
                    //Store User requisition management
                    formLabel.Text = "   Pending Requisitions";
                    ShowForm(new PendingRequisitionActionUI());
                    break;
                case "mnuStoreDashboard":
                    //Store Deshboard for report
                    formLabel.Text = "   Store Dashboard";
                    ShowForm(new StoreDashboardActionUI());
                    break;
                case "mnuPurchaseRequisition":
                    //Store Purchse requisition
                    formLabel.Text = "   Purchase Requisition";
                    ShowForm(new PurchaseRequisitionActionUI());
                    break;
                case "mnuEmergencyOrder":
                    //Store Emargency requisition(Cash purchase)
                    formLabel.Text = "   Emergency Orders";
                    ShowForm(new CashPurchaseOrderActionUI());
                    break;
                case "mnuGRRReceive":
                    //Store GRR Receive
                    formLabel.Text = "   GRR Receive";
                    ShowForm(new GrrReceiveActionUI());
                    break;
                case "mnuStoreAuthority_1":
                    //Store First Authority
                    formLabel.Text = "   Purchase Requisiton";
                    ShowForm(new PurchaseRequisitionApprovActionUI("1"));
                    break;
                case "mnuStoreAuthority_2":
                    //Store GRR Receive
                    formLabel.Text = "   Purchase Requisiton";
                    ShowForm(new PurchaseRequisitionApprovActionUI("2"));
                    break;
                case "mnuStorePaymentConfirm":
                    //Purchase Order Confirmation for payment processing
                    formLabel.Text = "   Cash Purchase Orders Confirmed for Payment";
                    ShowForm(new PurchaseOrderPayamentConfirmActionUI("3"));
                    break;
                //END  : Store Menus

                //START : Purchase Menus
                case "mnuPurchaseSupplierEnlistment":
                    //Purchase Supplier Enlistment
                    formLabel.Text = "   Supplier Enlistment";
                    ShowForm(new SupplierEnlistmentUI(true));
                    break;
                case "mnuPurchaseRequisitionProcess":
                    //Purchase requisiton Process
                    formLabel.Text = "   Purchase Requisition Process";
                    ShowForm(new PurchaseRequisitonProcessActionUI(true));
                    break;
                case  "mnuPurchaseQuotationManagement":
                    //Tender quotation Management
                    formLabel.Text = "   Quotation Management";
                    ShowForm(new PurchaseTenderQuotationActionUI());
                    break;
                case "mnuPurchaseTenderFinalize":
                    //Tender finalize/ apporval
                    formLabel.Text = "   Tender Finalize";
                    ShowForm(new PurchaseTenderFinalizeActionUI(true));
                    break;
                case "mnuPurchaseOrder":
                    //Purchase Order
                    formLabel.Text = "   Purchase Orders";
                    ShowForm(new PurchaseOrderActionUI());
                    break;
                case "mnuPurchasePaymentConfirm":
                    //Purchase Order Confirmation for payment processing
                    formLabel.Text = "   Purchase Orders Confirmed for Payment";
                    ShowForm(new PurchaseOrderPayamentConfirmActionUI("1"));
                    break;
                //END : Purchase Menus

                //Start: MIS Menus
                case "mnuMISSupplierEnlistment":
                    //MIS Suppier Management
                    formLabel.Text = "   Supplier Enlistment";
                    ShowForm(new SupplierEnlistmentUI(false));
                    break;
                case "mnuMISPurchaseRequisitionProcess":
                    //MIS Purchase Requisition Process
                    formLabel.Text = "   Purchase Requisition Process";
                    ShowForm(new PurchaseRequisitonProcessActionUI(false));
                    break;
                case "mnuMISQuotationManagement":
                    //Tender Ouotation Management
                    formLabel.Text = "   Quotation Management";
                    ShowForm(new MISTenderQuotationActionUI());
                    break;
                case "mnuMisTenderFinalize":
                    //Tender Approval/ Finalize
                    formLabel.Text = "   Tender Finalize";
                    ShowForm(new PurchaseTenderFinalizeActionUI(false));
                    break;
                case "mnuMISPurchaseOrder":
                    //Purchase Order
                    formLabel.Text = "   Purchase Orders";
                    ShowForm(new MISPurchaseOrderActionUI());
                    break;
                case "mnuMISePaymentConfirm":
                    //Purchase Order Confirmation for payment processing
                    formLabel.Text = "   Purchase Orders Confirmed for Payment";
                    ShowForm(new PurchaseOrderPayamentConfirmActionUI("2"));
                    break;
                //END : MIS Menus

                //Start: FSD Menus
                case "mnuOrderInspection":
                    //FSD Order Inspection
                    formLabel.Text = "   Order Inspection";
                    ShowForm(new OrderInspectionActionUI());
                    break;
                case "mnuInspectionSummery":
                    //FSD Inspection Summery
                    formLabel.Text = "   Inspection Summery";
                    ShowForm(new FSDInspectionSummeryActionUI());
                    break;
                case "mnuCertificateApproval":
                    //FSD Certificate Approval
                    formLabel.Text = "   Certificate Approval";
                    ShowForm(new FSDCertificateApprovalUI());
                    break;
                case "mnuInspectorSetting":
                    //FSD Inspector Settings
                    new FSDInspectorSettingsUI().ShowDialog();
                    break;
                //End : FSD Menus   

                //Start: Accounts Menu
                case "mnuAccoutsPaymentConfirm":
                    //Accouts Payment Confirmation
                    formLabel.Text = "   Purchase Order Payment Approval";
                    ShowForm(new AccountsOrderPaymentConfirmActionUI());
                    break;
                case "mnuAccoutsMapicsUpload":
                    //Accouts Mapics Upload
                    formLabel.Text = "   MAPICS Upload";
                    ShowForm(new AccountsMAPICsPostingUI());
                    break;
                //End : Accouts Menu
            
                //Start : Department Head Menus
                case "mnuRequisitionApproval":
                    //Department User Requisiton Management
                    formLabel.Text = "   Requisition Approval";
                    ShowForm(new RequisitoinApprovalActionUI());
                    break;
                case "mnuManagementDashboard":
                    //Deshboard for Department Head Reportingg
                    formLabel.Text = "   Management Dashboard";
                    ShowForm(new ManagemetnDashBoardActionUI());
                    break;
                //END : Department Head Menus

                //START : User Menus
                case "mnuStoreRequisition":
                    //User Store Requisition 
                    formLabel.Text = "   Store Requisition";
                    ShowForm(new StoreRequisitionActionUI());
                    break;                             
                case "mnuPasswordChange":
                    //User Password Change
                    new PasswordChangeUI().ShowDialog();
                    btn.Image = null;
                    break;
                //END  : User Menus
            }
        }

        private void ShowForm(Form frm)
        {
            if (commonForm != null)
            {
                commonForm.Close();
                commonForm = null;
            }
            if (string.Compare(DateTime.Now.Date.ToString("yyyyMMdd").Trim(), LoginUser.ServerDateTime.Trim()) == 0)
            {
                commonForm = frm;
                commonForm.MdiParent = this;
                commonForm.WindowState = FormWindowState.Maximized;
                commonForm.Show();
            }
            else
            {
                LockSoftwareOnDateChange("2");
            }
        }

        private void leftMenu_OnMenuSelection(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ShowForm(btn.Name.Trim(), btn);
        }
         
        private void menuBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftMenu.Visible = menuBarToolStripMenuItem.Checked;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!logoutFlag)
            {
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                logoutFlag = true;
                this.Close();

                if (timer != null && timer.Enabled)
                {
                    timer.Stop();
                }

                if (loginUser != null)
                {
                    loginUser.Close();
                    loginUser = new LoginUI();
                    loginUser.Show();
                }
                else
                {
                    loginUser = new LoginUI();
                    loginUser.Show();
                }
            }
            catch
            {
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save the user exit log
            try
            {
                userManager.ManageTheUser(new User() { UserID = LoginUser.EntryLog, Condition = "6" });
            }
            catch
            {
            }
            finally
            {

            }
        }

        
    }
}
