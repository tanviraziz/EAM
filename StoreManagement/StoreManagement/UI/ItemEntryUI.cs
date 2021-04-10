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
using System.Text.RegularExpressions;

namespace StoreManagement.UI
{
    public partial class ItemEntryUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControl = null;
            private Stationary item = null;
            private string itemToEdit = null;
            private bool IsEdit = false;
        #endregion

        public ItemEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        public ItemEntryUI(string itemID):this()
        {
            IsEdit = true;
            itemToEdit = itemID;
            label1.Text = "Edit Item";
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            fillControl = new DynamicControlFill();
        }

        #region Form custom border

        int borderRadius = 30;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            int height = Height;
            int width = Width;
            // 4 Border Lines
            // x1,y1 -----> x2 y2 Left Border Line
            // x3y3  -----> x4,y4 Bottom Border Line
            // x5,y5 -----> x6,y6 Right Border Line
            // x7,y7 -----> x8,y8 Top Border Line

            // x1,y1 ( Left Top), x2,y2 ( Left Bottom of Left Border), x3,y3 (Left Bottom of Bottom Border),  x4,y4 (Right Bottom of Bottom Border)
            int x1 = 0, y1 = 0, x2 = 0, y2 = Height, x3 = 0, y3 = Height, x4 = Width, y4 = Height;
            // x5,y5 ( Bottom Right) x6,y6 (Top Right) x7,y7 Right Top
            int x5 = Width, y5 = Height, x6 = Width, y6 = 0, x7 = Width, y7 = 0, x8 = 0, y8 = 0;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            y1 = borderRadius / 2;
            x8 = borderRadius / 2;
            y2 = height - (borderRadius / 2);
            x3 = borderRadius / 2;
            x4 = Width - (borderRadius / 2);
            y5 = Height - (borderRadius / 2);
            y6 = borderRadius / 2;
            x7 = Width - (borderRadius / 2);
            // Top Left Arc
            gp.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            // Left Border
            gp.AddLine(new Point(x1, y1), new Point(x2, y2));
            // Bottom Left Arc
            gp.AddArc(new Rectangle(0, height - borderRadius, borderRadius, borderRadius), 90, 90);
            // Bottom Line
            gp.AddLine(new Point(x3, y3), new Point(x4, y4));
            // Bottom Right Arc
            gp.AddArc(new Rectangle(width - borderRadius, height - borderRadius, borderRadius, borderRadius), 0, 90);
            // Right Border
            gp.AddLine(new Point(x5, y5), new Point(x6, y6));
            // Top Right Border
            gp.AddArc(width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            // Top Border
            gp.AddLine(new Point(x7, y7), new Point(x8, y8));
            gp.CloseFigure();
            this.Region = new Region(gp);
        }

        #endregion

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void ItemEntryUI_Load(object sender, EventArgs e)
        {
            fillControl.fillCombo(categoryComboBox, settingsManager.GetItemCategoryList("1",null), "Category","Code");
            categoryComboBox.SelectedIndex = -1;

            if (IsEdit)
            {
                FillItemInformation();
            }
        }

        private void FillItemInformation()
        {
            try
            {
                DataTable dt = settingsManager.GetItemList("4", itemToEdit);
                if (dt.Rows.Count > 0)
                {
                    descriptionTextBox.Text = dt.Rows[0]["Item"].ToString().Trim();
                    categoryComboBox.Text = dt.Rows[0]["Category"].ToString().Trim();
                    subCategoruComboBox.Text = dt.Rows[0]["SubCategory"].ToString().Trim();
                    unitTextBox.Text = dt.Rows[0]["Unit"].ToString().Trim();
                    reorderLevelTextBox.Text = dt.Rows[0]["ReOrderLevel"].ToString().Trim();
                }
            }
            catch
            {
                
            }

        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            new ItemCategoryEntryUI().ShowDialog();

            fillControl.fillCombo(categoryComboBox, settingsManager.GetItemCategoryList("1", null), "Category", "Code");
            categoryComboBox.SelectedIndex = -1;
        }

        private void addSubCategoryButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryComboBox.Text.Trim()))
            {
                MessageBox.Show("Select a category.");
            }
            else
            {
                new ItemSubCategoryEntryUI(categoryComboBox.SelectedValue.ToString().Trim(), categoryComboBox.Text).ShowDialog();
                ShowSubCategory();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (settingsManager.ItemManagement(item))
                {
                    MessageBox.Show("Saved successfully.");
                    if (IsEdit)
                    {
                        this.Close();
                    }
                    ClearAllFields();
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
            item = null;
        }

        private bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(descriptionTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter item description.");
                    descriptionTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(categoryComboBox.Text.Trim()))
                {
                    MessageBox.Show("Select a category.");
                    categoryComboBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(unitTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter item unit.");
                    unitTextBox.Focus();
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
            if (item == null)
            {
                item = new Stationary();
            }

            item.Description = descriptionTextBox.Text.Trim();
            item.CategoryID = Convert.ToInt16(categoryComboBox.SelectedValue.ToString());
            if (subCategoruComboBox.SelectedValue != null)
            {
                item.SubCategoryID = Convert.ToInt16(subCategoruComboBox.SelectedValue.ToString());
            }
            item.Unit = unitTextBox.Text.Trim();
            item.ReOrderLevel = Convert.ToDecimal(reorderLevelTextBox.Text.Trim());
            
            if (IsEdit)
            {
                item.Condtion = "2";
                item.ItemID = Convert.ToInt64(itemToEdit);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            descriptionTextBox.Clear();
            categoryComboBox.SelectedIndex = -1;
            subCategoruComboBox.DataSource = null;
            subCategoruComboBox.Items.Clear();
            unitTextBox.Clear();
            reorderLevelTextBox.Clear();            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (categoryComboBox.SelectedIndex > -1)
            //    {
            //        fillControl.fillCombo(subCategoruComboBox, settingsManager.GetItemSubCategoryList("3", categoryComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
            //        subCategoruComboBox.SelectedIndex = -1;
            //    }
            //}
            //catch
            //{
            //    subCategoruComboBox.DataSource = null;
            //    subCategoruComboBox.Items.Clear();
            //}
            ShowSubCategory();
        }

        private void ShowSubCategory()
        {
            try
            {
                if (categoryComboBox.SelectedIndex > -1)
                {
                    fillControl.fillCombo(subCategoruComboBox, settingsManager.GetItemSubCategoryList("3", categoryComboBox.SelectedValue.ToString().Trim()), "SubCategory", "Code");
                    subCategoruComboBox.SelectedIndex = -1;
                }
            }
            catch
            {
                subCategoruComboBox.DataSource = null;
                subCategoruComboBox.Items.Clear();
            }
        }

        private void reorderLevelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\x08\x2E\d]"))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
            }
        }
        

       
    }
}
