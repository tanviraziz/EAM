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
    public partial class FSDCertificateApprovalUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControll = null;
            private FSDManager fsdManager = null;
            private MonthYearConvertion monthYearConvert = null;
            private FSDCertificate certificate = null;
        #endregion


        public FSDCertificateApprovalUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControll = new DynamicControlFill();
            fsdManager = new FSDManager();
            monthYearConvert = new MonthYearConvertion();
        }

        private void FSDCertificateApprovalUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControll.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            fillControll.FillMonth(monthComboBox);
            ShowData("1",monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()),null);
        }

        private void ShowData(string choice,string condtion1,string condition2)
        {
            //Fill all pending certificate in list
            fillControll.fillListView(pendingListView, fsdManager.GetFSDCertificateList(choice, condtion1, condition2), "Certificate No.,Inspection Date,Order No.,Order Date, Delivery Date,Challan No.,Challan Date,Supplier,Total Item,Total Order Amt,Total Pay Amt,", "100,100,100,100,100,200,200,250,100,100,100,");
            detailListView.Items.Clear();
        }

        private void pendingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                string cerNo = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                detailGroupBox.Text = "Detail of certificate no. : " + cerNo;
                fillControll.fillListView(detailListView, fsdManager.GetFSDCertificateList("2", cerNo, null), "Code, Item, Unit, Order Qty, Qty Before Insp,Qty After Insp.", "100,250,100,120,150,150");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (pendingListView.SelectedIndices.Count > 0)
            {
                if(certificate == null)
                {
                    certificate = new FSDCertificate();
                }
                certificate.CertificateID = pendingListView.Items[pendingListView.SelectedIndices[0]].Text.Trim();
                certificate.Condition = "3";

                if (fsdManager.CertificateApproved(certificate))
                {
                    ShowData("1",monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()),null);

                }
                certificate = null;
            }
            else
            {
                MessageBox.Show("Select a certificate from list");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowData("1",monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
            addButton.Visible = true;
        }

        private void certificateInaMonthTaskItem_Click(object sender, EventArgs e)
        {
            ShowData("3",monthYearConvert.getMonthYear("2", monthComboBox.Text.Trim(), yearPicker.Text.Trim()), null);
            addButton.Visible = false;
        }
    }
}
