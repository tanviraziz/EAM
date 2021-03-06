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
    public partial class ManufactEntryUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private Menufacture menufacturer = null;
            private bool IsEdit;
            private string mefacturerIdToEdit;
        #endregion

        public ManufactEntryUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
        }

        public ManufactEntryUI(string mID):this()
        {
            IsEdit = true;
            mefacturerIdToEdit = mID;
            label1.Text = "Edit Manufacturer";
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

        private void ManufactEntryUI_Load(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                FillSupplerInformation();
            }
        }

        private void FillSupplerInformation()
        {
            DataTable dt = null;
            dt = settingsManager.GetMenufacturerList("2", mefacturerIdToEdit);
            if (dt.Rows.Count > 0)
            {
                nameTextBox.Text = dt.Rows[0]["Name"].ToString().Trim();
                contactPersonTextBox.Text = dt.Rows[0]["Contact"].ToString().Trim();
                addressTextBox.Text = dt.Rows[0]["Address"].ToString().Trim();
                phoneNoTextBox.Text = dt.Rows[0]["PhoneNo"].ToString().Trim();
                faxTextBox.Text = dt.Rows[0]["Fax"].ToString().Trim();
                emailTextBox.Text = dt.Rows[0]["Email"].ToString().Trim();
            }
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
                if (settingsManager.MenufacturerManagement(menufacturer))
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
            menufacturer = null;
        }

        private bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(nameTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter manufacturer name.");
                    nameTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(contactPersonTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter contact person.");
                    contactPersonTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(addressTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter manufacturer address.");
                    addressTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(phoneNoTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter manufacturer phone no.");
                    phoneNoTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(faxTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter manufacturer fax no.");
                    faxTextBox.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(emailTextBox.Text.Trim()) && !EmailValidator.IsValid(emailTextBox.Text.Trim()))
                {
                    MessageBox.Show("Invaid email address.");
                    emailTextBox.Focus();
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
            if (menufacturer == null)
            {
                menufacturer = new Menufacture();
            }

            menufacturer.Name = nameTextBox.Text.Trim();
            menufacturer.ContactPerson = contactPersonTextBox.Text.Trim();
            menufacturer.Address = addressTextBox.Text.Trim();
            menufacturer.PhoneNo = phoneNoTextBox.Text.Trim();
            menufacturer.Fax = faxTextBox.Text.Trim();
            menufacturer.Email = emailTextBox.Text.Trim();

            if (IsEdit)
            {
                menufacturer.ManufacturerID = Convert.ToInt32(mefacturerIdToEdit);
                menufacturer.Condition = "2";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            nameTextBox.Clear();
            contactPersonTextBox.Clear();
            addressTextBox.Clear();
            phoneNoTextBox.Clear();
            faxTextBox.Clear();
            emailTextBox.Clear();
        }
    }
}
