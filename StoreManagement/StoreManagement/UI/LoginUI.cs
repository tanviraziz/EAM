using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class LoginUI : Form
    {
        #region Veriables
            private LogInManager logInManager = null;
        #endregion

        public LoginUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            logInManager = new LogInManager();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (logInManager.LogInVerification(Verification.verifyEmployeeID(userIDTextBox.Text.Trim()), passwordTextBox.Text))
            {
                this.Hide();
                LoginUser.UserID = userIDTextBox.Text.Trim();
                LoginUser.UserPassword = passwordTextBox.Text;
                new MDIParent().ShowDialog();
            }
            else
            {
                passwordTextBox.Text = "";
                msgLabel.Text = "Wrong User Id or Password";
                msgLabel.ForeColor = Color.Red;
                msgLabel.BackColor = Color.Yellow;
                msgLabel.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userIDTextBox_Leave(object sender, EventArgs e)
        {
            if (userIDTextBox.Text != "")
            {
                userIDTextBox.Text = userIDTextBox.Text.PadLeft(6, '0');
            }
        }
    }
}
