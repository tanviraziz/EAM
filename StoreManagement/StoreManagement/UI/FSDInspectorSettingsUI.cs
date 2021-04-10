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
    public partial class FSDInspectorSettingsUI : Form
    {
        #region Local variables
            private UserManager userManager = null;
            private DynamicControlFill fillControl = null;
            private User inspector = null;
        #endregion

        public FSDInspectorSettingsUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            userManager = new UserManager();
            fillControl = new DynamicControlFill();
        }

        private void FSDInspectorSettingsUI_Load(object sender, EventArgs e)
        {
            ShowInspectors();
        }

        private void ShowInspectors()
        {
            DataTable dt = null;
            try
            {
                dt = userManager.GetInspectorList("1", null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //Authority 
                    authorityTextBox.Text = dt.Rows[0]["Authority"].ToString();
                    ShowUserInfo(dt.Rows[0]["Authority"].ToString(), authorityInfoLabel, authorityPictureBox);

                    //First Inspector
                    firstInspectorTextBox.Text = dt.Rows[0]["firstInspector"].ToString();
                    ShowUserInfo(dt.Rows[0]["firstInspector"].ToString(), firstInspectorInfoLabel, firstInspectorPictureBox);

                    //Second Inspector
                    secondInspectorTextBox.Text = dt.Rows[0]["secondInspector"].ToString();
                    ShowUserInfo(dt.Rows[0]["secondInspector"].ToString(), secondInspectorInfoLabel, secondInspectorPictureBox);

                    //Checked by
                    checkedByTextBox.Text = dt.Rows[0]["checkedBy"].ToString();
                    ShowUserInfo(dt.Rows[0]["checkedBy"].ToString(), checkedByInfoLabel, checkedByPictureBox);
                }
            }
            catch
            {

            }
        }

        #region Search
        private void ShowUserInfo(string userid,Label userInfoLabel,PictureBox userPicture)
        {
            DataTable dt = null;
            try
            {
                if(string.IsNullOrEmpty(userid.Trim()))
                {
                    MessageBox.Show("Enter employee id");
                }
                else
                {
                    dt = userManager.GetUserInfoFromPIS("1", Verification.verifyEmployeeID(userid));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                       userInfoLabel.Text = "Code : " + dt.Rows[0]["EmpID"].ToString() + Environment.NewLine +
                       dt.Rows[0]["Name"].ToString();
                        if ((dt.Rows[0]["Picture"]) != DBNull.Value)
                        {
                            fillControl.fillPictureBox(dt.Rows[0]["Picture"], userPicture);
                        }
                    }
                }
            }
            catch
            {
                userInfoLabel.Text = "";
                userPicture.Image = null;
            }
        }

        private void authoritySearchButton_Click(object sender, EventArgs e)
        {
            ShowUserInfo(authorityTextBox.Text.Trim(), authorityInfoLabel, authorityPictureBox);
        }

        private void firstInspSearchButton_Click(object sender, EventArgs e)
        {
            ShowUserInfo(firstInspectorTextBox.Text.Trim(), firstInspectorInfoLabel, firstInspectorPictureBox);            
        }

        private void secondInspSearchButton_Click(object sender, EventArgs e)
        {
            ShowUserInfo(secondInspectorTextBox.Text.Trim(), secondInspectorInfoLabel, secondInspectorPictureBox);
        }

        private void checkedBySearchButton_Click(object sender, EventArgs e)
        {
            ShowUserInfo(checkedByTextBox.Text.Trim(), checkedByInfoLabel, checkedByPictureBox);
        }
        #endregion


        #region Change inspectors

        //manage FSD authority
        private void authorityChangeButton_Click(object sender, EventArgs e)
        {
            if (IsValid("4", authorityTextBox.Text.Trim()))
            {
                if (userManager.ManageTheInspector(inspector))
                {
                    MessageBox.Show("Save successfully");
                }
            }
            inspector = null;
        }

        //manage the first Inspector
        private void firstInsChangeButton_Click(object sender, EventArgs e)
        {
            if(IsValid("1",firstInspectorTextBox.Text.Trim()))
            {
                if (userManager.ManageTheInspector(inspector))
                {
                    MessageBox.Show("Save successfully");
                }
            }
            inspector = null;
        }

        private void secondInsChangeButton_Click(object sender, EventArgs e)
        {
            if (IsValid("2", secondInspectorTextBox.Text.Trim()))
            {
                if (userManager.ManageTheInspector(inspector))
                {
                    MessageBox.Show("Save successfully");
                }
            }
            inspector = null;
        }

        private void checkedByChangeButton_Click(object sender, EventArgs e)
        {
            if (IsValid("3", checkedByTextBox.Text.Trim()))
            {
                if (userManager.ManageTheInspector(inspector))
                {
                    MessageBox.Show("Save successfully");
                }
            }
            inspector = null;
        }


        //Validation
        private bool IsValid(string choice, string empID)
        {
            try
            {
                if (string.IsNullOrEmpty(empID.Trim()))
                {
                    MessageBox.Show("Enter employee code");
                    switch (choice)
                    {
                        case "1":
                            inspector.Condition = "3";
                            break;
                        case "2":
                            inspector.Condition = "4";
                            break;
                        case "3":
                            inspector.Condition = "5";
                            break;
                        case "4":
                            inspector.Condition = "6";
                            break;
                    }
                    return false;
                }
                else
                {
                    SetValues(choice, empID);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        //set data
        private void SetValues(string choice, string empCode)
        {
            if (inspector == null)
            {
                inspector = new User();
            }
            inspector.EmpCode = Verification.verifyEmployeeID(empCode);
            switch (choice)
            {
                case "1":
                    inspector.Condition = "3";
                    break;
                case "2":
                    inspector.Condition = "4";
                    break;
                case "3":
                    inspector.Condition = "5";
                    break;
                case "4":
                    inspector.Condition = "6";
                    break;
            }
        }
        #endregion

       

       

        

    }
}
