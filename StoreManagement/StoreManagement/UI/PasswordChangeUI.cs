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
using StoreManagement.Properties;

namespace StoreManagement.UI
{
    public partial class PasswordChangeUI : Form
    {
        #region Local variables
            private UserManager userManager = null;
            private DynamicControlFill fillControl = null;
            private User user = null;
        #endregion

        public PasswordChangeUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            userManager = new UserManager();
            fillControl = new DynamicControlFill();
        }

        private void PasswordChangeUI_Load(object sender, EventArgs e)
        {
            UserInformation();
        }

        private void UserInformation()
        {
            DataTable dt = userManager.GetUserInfoFromPIS("1", Verification.verifyEmployeeID(LoginUser.UserID));
            if (dt != null && dt.Rows.Count > 0)
            {
                userInfoLabel.Text = "Code : " + dt.Rows[0]["EmpID"].ToString() + Environment.NewLine +
               dt.Rows[0]["Name"].ToString();
                if ((dt.Rows[0]["Picture"]) != DBNull.Value)
                {
                    fillControl.fillPictureBox(dt.Rows[0]["Picture"], userPictureBox);
                }
            }
            else
            {
                userPictureBox.Image = Resources.UserPic;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (userManager.ManageTheUser(user))
                {
                    MessageBox.Show("Saved successfully.");
                }
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(newTextBox.Text.Trim()))
            {
                newTextBox.Focus();
                MessageBox.Show("Enter new password", "New password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(confirmTextBox.Text.Trim()))
            {
                confirmTextBox.Focus();
                MessageBox.Show("Enter confirm password", "Confirm password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!newTextBox.Text.Trim().Equals(confirmTextBox.Text.Trim(), StringComparison.CurrentCulture))
            {
                MessageBox.Show("New password and confirm new password do not match", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                SetValues();
            }
            return true;
        }

        private void SetValues()
        {
            if (user == null)
            {
                user = new User();
            }

            user.UserID = LoginUser.UID;
            user.Password = confirmTextBox.Text.Trim();
            user.Condition = "3";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            newTextBox.Clear();
            confirmTextBox.Clear();
        }

        
    }
}
