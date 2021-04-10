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

namespace StoreManagement.UI
{
    public partial class UnitEntryUI : Form
    {
        #region Local variables

        private MasterSetupManager setupManage = null;
        Company companyUnit = null;
        private bool IsEdit = false;

        #endregion

        private void SetObject()
        {
            setupManage = new MasterSetupManager();
        }

        public UnitEntryUI()
        {
            InitializeComponent();
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

        private void UnitEntryUI_Load(object sender, EventArgs e)
        {

        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (setupManage.CompanyUnitManagement(companyUnit))
                {
                    ClearAllFields();
                }
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(unitTextBox.Text.Trim()))
            {
                MessageBox.Show("Enter category.");
                unitTextBox.Focus();
                return false;
            }
            //else if (string.IsNullOrEmpty(mapicCodeTextBox.Text.Trim()))
            //{
            //    MessageBox.Show("Enter remarks.");
            //    remarksTextBox.Focus();
            //    return false;
            //}
            else
            {
                SetValues();
            }
            return true;
        }


        private void SetValues()
        {
            if (companyUnit == null)
            {
                companyUnit = new Company();
            }

            companyUnit.Name = unitTextBox.Text.Trim();
            companyUnit.Remarks = remarksTextBox.Text.Trim();

            //
            if (IsEdit)
            {
                companyUnit.Condtion = "";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            unitTextBox.Clear();
            remarksTextBox.Clear();
        }

        
    }
}
