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
using StoreManagement.UI;

namespace StoreManagement.UI
{
    public partial class ManufacturerSettingsUI : Form
    {
        #region Veriables
            private DynamicControlFill fillControl = null;
            private MasterSetupManager settingsManager = null;
        #endregion

        public ManufacturerSettingsUI()
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

        private void addButton_Click(object sender, EventArgs e)
        {
            new ManufactEntryUI().ShowDialog();
            ShowList();
        }

        private void ManufacturerSettingsUI_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            fillControl.fillListView(manufacturerListView, settingsManager.GetMenufacturerList("1", null), "Name,Contact Person,Address,Phone No, Fax No, Email,", "250,200,250,100,100,150,");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (manufacturerListView.SelectedIndices.Count > 0)
            {
                new ManufactEntryUI(manufacturerListView.Items[manufacturerListView.SelectedIndices[0]].SubItems[6].Text.Trim()).ShowDialog();
                ShowList();
            }
            else
            {
                MessageBox.Show("Select a manufacturer from list.");
            }
        }

        private void manufacturerListView_DoubleClick(object sender, EventArgs e)
        {
            if (manufacturerListView.SelectedIndices.Count > 0)
            {
                new ManufactEntryUI(manufacturerListView.Items[manufacturerListView.SelectedIndices[0]].SubItems[6].Text.Trim()).ShowDialog();
            } 
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        
    }
}
