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
    public partial class SupplierSettingsUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControl = null;
            private MasterSetupManager settingsManager = null;  
        #endregion

        public SupplierSettingsUI()
        {
            InitializeComponent();
            SetObjectes();
        }

        //intialize the Objects
        private void SetObjectes()
        {
            fillControl = new DynamicControlFill();
            settingsManager = new MasterSetupManager();
        }

        private void SupplierSettingsUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowList();
        }

        private void ShowList()
        {
            fillControl.fillListView(suppliersListView, settingsManager.GetSupplierList("1", null), "Name,Contact Person,Address,Phone No, Fax No, Email,", "250,200,250,100,100,150,");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (suppliersListView.SelectedIndices.Count > 0)
            {
                new SupplierEntryUI(suppliersListView.Items[suppliersListView.SelectedIndices[0]].SubItems[6].Text.Trim()).ShowDialog();
                ShowList();
            }
            else
            {
                MessageBox.Show("Select a suppler from list.");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new SupplierEntryUI().ShowDialog();
            ShowList();
        }

        private void suppliersListView_DoubleClick(object sender, EventArgs e)
        {
            if (suppliersListView.SelectedIndices.Count > 0)
            {
                new SupplierEntryUI(suppliersListView.Items[suppliersListView.SelectedIndices[0]].SubItems[6].Text.Trim()).ShowDialog();
            }            
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}
