using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomBorderOfForm;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.UI;
using StoreManagement.UTILITY;
using StoreManagement.Properties;



namespace StoreManagement.UI
{    
    public partial class StationerySettingsUI : Form
    {
        #region Local Varibles
            private DynamicControlFill fillControl = null;
            private MasterSetupManager masterManager = null;
            private bool IsEdit = false;
            private bool IsSCEdit = false;
            private bool IsICEdit = false;
            private bool IsISCEdit = false;
            private Stationary stationary = null;
            private string stationaryCategoryID;
            private string itemCategoryID;
            private string itemSubCategoryID;
        #endregion

        public StationerySettingsUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            fillControl = new DynamicControlFill();
            masterManager = new MasterSetupManager();
        }

        private void StationarySettingsUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            ShowData();
        }

        private void stationarySettingsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            switch (stationarySettingsTabControl.SelectedIndex)
            {
                case 0:
                    fillControl.fillListView(itemListView, masterManager.GetItemList("1", null), "Sl No.,Item,Category,SubCategory,Main Category,", "50,250,150,200,200,");
                    break;
                case 1:
                    fillControl.fillListView(stationaryCategoryListView, masterManager.GetStationaryCategoryList("1", null), "Category,", "500,");
                    break;                
            }
        }

        #region Management

        //perform the validation
        private bool IsValid(string choice)
        {
            try
            {
                switch (choice)
                {
                    case "1":
                        if (string.IsNullOrEmpty(stationaryCategoryTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter stationary category.");
                            stationaryCategoryTextBox.Focus();
                            return false;
                        }
                        break;

                    case "2":
                        if (string.IsNullOrEmpty(itemCategoryTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter item category.");
                            itemCategoryTextBox.Focus();
                            return false;
                        }

                        break;

                    case "3":
                        if (string.IsNullOrEmpty(itemSubCategoryTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter item sub category.");
                            itemSubCategoryTextBox.Focus();
                            return false;
                        }

                        break;
                }

                //if all required fields given the set the values
                SetValues(choice);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SetValues(string choice)
        {
            //set the class i.e: 1 for stationary, 2 for item and 3 for category
            if (stationary == null)
            {
                stationary = new Stationary();
            }
            
            switch (choice)
            {
                case "1":
                    stationary.Name = stationaryCategoryTextBox.Text.Trim();
                    
                    if (IsSCEdit)
                    {
                        stationary.StationaryID = Convert.ToInt16(stationaryCategoryID);
                        stationary.Condtion = "2";
                    }
                    break;
                case "2":
                    stationary.Name = itemCategoryTextBox.Text.Trim();
                    stationary.StationaryID = Convert.ToInt16(stationaryCategoryID);

                    if (IsICEdit)
                    {
                        stationary.CategoryID = Convert.ToInt16(itemCategoryID);
                        stationary.Condtion = "2";
                    }
                    break;
                case "3":
                    stationary.Name = itemSubCategoryTextBox.Text.Trim();
                    stationary.CategoryID = Convert.ToInt16(itemCategoryID);

                    if (IsISCEdit)
                    {
                        stationary.SubCategoryID = Convert.ToInt16(itemSubCategoryID);
                        stationary.Condtion = "2";
                    }
                    break;
            }                
        }

        //clear the fields
        private void ClearAllFields(string choice)
        {
            switch (choice)
            {
                case "1":
                    //clear the stationary category
                    addStationaryCategoryButton.Image = Resources.addB24;
                    stationaryCategoryTextBox.Clear();
                    fillControl.fillListView(stationaryCategoryListView, masterManager.GetStationaryCategoryList("1", null), "Category,", "500,");
                    IsSCEdit = false;
                    stationaryCategoryID = null;

                    //clear the item category
                    itemCategoryTextBox.Clear();
                    itemCategoryListView.Items.Clear();
                    addItemCategoryButton.Image = Resources.addB24;
                    itemGroupBox.Text = "Items";
                    IsICEdit = false;
                    itemCategoryID = null;

                    //clear the item subcategory
                    itemSubCategoryTextBox.Clear();
                    subCategoryListView.Items.Clear();
                    addItemSubCategoryButton.Image = Resources.addB24;
                    itemCategoryGroupBox.Text = "Item Category";
                    IsISCEdit = false;
                    itemSubCategoryID = null;
                    break;
                case "2":
                    //clear the item category
                    itemCategoryTextBox.Clear();
                    fillControl.fillListView(itemCategoryListView, masterManager.GetItemCategoryList("2", stationaryCategoryID), ",", "320,");
                    addItemCategoryButton.Image = Resources.addB24;
                    IsICEdit = false;
                    itemCategoryID = null;

                    //clear the item subcategory
                    itemSubCategoryTextBox.Clear();
                    subCategoryListView.Items.Clear();
                    addItemSubCategoryButton.Image = Resources.addB24;
                    itemCategoryGroupBox.Text = "Item Category";
                    IsISCEdit = false;
                    itemSubCategoryID = null;
                    break;
                case "3":
                    //clear the item subcategory
                    itemSubCategoryTextBox.Clear();
                    addItemSubCategoryButton.Image = Resources.addB24;
                    fillControl.fillListView(subCategoryListView, masterManager.GetItemSubCategoryList("2", itemCategoryID), ",", "320,");
                    IsISCEdit = false;
                    itemSubCategoryID = null;
                    break;
            }
        }
        #endregion


        #region Stationary Item Management

        private void addItemButton_Click(object sender, EventArgs e)
        {
            new ItemEntryUI().ShowDialog();
            //fillControl.fillListView(itemListView, masterManager.GetItemList("1", null), "Sl No.,Item,Category,SubCategory,Stationary,", "50,250,150,200,200,");
            ShowData();
        }

        private void editItemButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                new ItemEntryUI(itemListView.Items[itemListView.SelectedIndices[0]].SubItems[5].Text.Trim()).ShowDialog();
                ShowData();
            }
            else
            {
                MessageBox.Show("Select an item.");
            }
        }

        private void itemListView_DoubleClick(object sender, EventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                new ItemEntryUI(itemListView.Items[itemListView.SelectedIndices[0]].SubItems[5].Text.Trim()).ShowDialog();
                ShowData();
            }
        }

        #endregion


        #region Stationary Category and Item Category, SubCategory Management

        private void addStationaryCategoryButton_Click(object sender, EventArgs e)
        {
            if (IsValid("1"))
            {
                if (masterManager.StoreCategoryManagement(stationary))
                {
                    ClearAllFields("1");
                }
                else
                {
                    MessageBox.Show("Failed to save.");
                }
            }
            else
            {
                MessageBox.Show("Failed to save.");
            }
            stationary = null;
        }

        private void refreshStaionaryCategoryButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("1");            
        }

        private void addItemCategoryButton_Click(object sender, EventArgs e)
        {
            if (IsValid("2"))
            {
                if (masterManager.ItemCategoryManagement(stationary))
                {
                    ClearAllFields("2");  
                }
            }
        }

        private void refreshItamCategoryButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("2");
        }

        private void addItemSubCategoryButton_Click(object sender, EventArgs e)
        {
            if (IsValid("3"))
            {
                if (masterManager.ItemSubCategoryManagement(stationary))
                {
                    ClearAllFields("3");  
                }
            }
        }

        private void refreshItemSubCategoryButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("3");
        }

        private void stationaryCategoryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (stationaryCategoryListView.SelectedIndices.Count > 0)
                {
                    stationaryCategoryTextBox.Text = stationaryCategoryListView.Items[stationaryCategoryListView.SelectedIndices[0]].Text;
                    stationaryCategoryID = stationaryCategoryListView.Items[stationaryCategoryListView.SelectedIndices[0]].SubItems[1].Text;
                }
                addStationaryCategoryButton.Image = Resources.edit24;
                ClearAllFields("2"); 
                fillControl.fillListView(itemCategoryListView, masterManager.GetItemCategoryList("2", stationaryCategoryID), ",", "320,");
                IsSCEdit = true;
                itemGroupBox.Text = stationaryCategoryTextBox.Text + " " + "Items";
            }
            catch
            {
                addStationaryCategoryButton.Image = Resources.addB24;
                itemCategoryListView.Items.Clear();
                IsSCEdit = false;
            }
        }

        private void itemCategoryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (itemCategoryListView.SelectedIndices.Count > 0)
                {
                    itemCategoryTextBox.Text = itemCategoryListView.Items[itemCategoryListView.SelectedIndices[0]].Text;
                    itemCategoryID = itemCategoryListView.Items[itemCategoryListView.SelectedIndices[0]].SubItems[1].Text;
                }
                addItemCategoryButton.Image = Resources.edit24;
                fillControl.fillListView(subCategoryListView, masterManager.GetItemSubCategoryList("2", itemCategoryID), ",", "320,");
                IsICEdit = true;

                itemCategoryGroupBox.Text = itemCategoryTextBox.Text + " " + "Categories";
            }
            catch
            {
                addItemCategoryButton.Image = Resources.addB24;
                subCategoryListView.Items.Clear();
                IsICEdit = false;
            }
        }

        private void subCategoryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (subCategoryListView.SelectedIndices.Count > 0)
                {
                    itemSubCategoryTextBox.Text = subCategoryListView.Items[subCategoryListView.SelectedIndices[0]].Text;
                    itemSubCategoryID = subCategoryListView.Items[subCategoryListView.SelectedIndices[0]].SubItems[1].Text;
                }
                addItemSubCategoryButton.Image = Resources.edit24;
                IsISCEdit = true;
            }
            catch
            {
                addItemSubCategoryButton.Image = Resources.addB24;
                subCategoryListView.Items.Clear();
                IsISCEdit = false;
            }
        }

        #endregion

        private void mainCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillControl.BuildGroups(4, itemListView, false);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillControl.BuildGroups(2, itemListView, false);
        }

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillControl.BuildGroups(3, itemListView, false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            itemListView.Items.Clear();
            ShowData();
        }

        private void itemListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            fillControl.ListViewSort(itemListView, e.Column);
        }

    }
}
