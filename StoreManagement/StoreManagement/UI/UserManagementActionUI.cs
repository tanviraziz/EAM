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
using StoreManagement.DAL.DAO;

namespace StoreManagement.UI
{
    public partial class UserManagementActionUI : Form
    {
        #region Local variables
            private UserManager userManager = null;
            private DynamicControlFill fillControl = null;
            private User user = null;
            private Role role = null;
            private Task task = null;
            private bool IsEdit = false;
            private string userIDtoEdit = null, roleIDtoEdit = null, tasktoEdit = null;
        #endregion

        public UserManagementActionUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            userManager = new UserManager();
            fillControl = new DynamicControlFill();
        }

        private void UserManagementActionUI_Load(object sender, EventArgs e)
        {
            fillControl.fillCombo(parentMenuComboBox, userManager.GetUserMenuList("9", null), "MenuName", "Code");
            parentMenuComboBox.SelectedIndex = -1;

            ShowList();
        }

        private void userManagementTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleViewsListView.ItemChecked -= new ItemCheckedEventHandler(roleViewsListView_ItemChecked);
            ShowList();
        }

        private void ShowList()
        {
            switch (userManagementTabControl.SelectedIndex)
            {
                case 0:
                    fillControl.fillListView(userListView, userManager.GetUserMenuList("1", null), "Emp Code,Name,", "100,200,");
                    fillControl.fillListView(userRolesListView, userManager.GetUserMenuList("3", null), "Role,Description,", "140,300,",false);
                    break;
                case 1:
                    fillControl.fillListView(rolesListView, userManager.GetUserMenuList("3", null), "Role,Description,", "140,300,");
                    fillControl.fillListView(roleViewsListView, userManager.GetUserMenuList("5", null), "Task,Short Name,Description,,", "200,200,350,,", false);
                    break;
                case 2:
                    fillControl.fillListView(viewsListView, userManager.GetUserMenuList("5", null), "Task,Short Name,Description,,", "200,200,350,,");
                    fillControl.BuildGroups(4,viewsListView, false);
                    parentMenuComboBox.SelectedIndex = -1;
                    break;
                case 3:
                    fillControl.fillListView(parentListView, userManager.GetUserMenuList("7", null), "Menu,Short Name,Description,", "200,200,350,");
                    break;
            }
        }

        #region User Settings
        private void ShowUserInfo(string userid, Label userInfoLabel, PictureBox userPicture)
        {
            DataTable dt = null;
            try
            {
                if (string.IsNullOrEmpty(userid.Trim()))
                {
                    MessageBox.Show("Enter employee code");
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            ShowUserInfo(empCodeTextBox.Text.Trim(), userInfoLabel, userPictureBox);
        }

        private void userSaveButton_Click(object sender, EventArgs e)
        {
            if (IsValid("1"))
            {
                if(userManager.ManageTheUser(user))
                {
                    ClearAllFields("1");
                }
            }
            user = null;
        }

        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            if (IsValid("1"))
            {
                user.Condition = "4";
                if (userManager.ManageTheUser(user))
                {
                    ClearAllFields("1");
                }
            }
            user = null;
        }

        private void userSettingsButton_Click(object sender, EventArgs e)
        {
            if (IsValid("2"))
            {
                if (userManager.ManageUserRoles(user))
                {
                    ClearAllFields("1");
                }
            }
            user = null;
        }

        private void userClearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("1");
        }

        private void userListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userListView.SelectedIndices.Count > 0)
            {
                IsEdit = true;
                userRolesListView.ItemChecked += new ItemCheckedEventHandler(userRolesListView_ItemChecked);

                empCodeTextBox.Text  = userListView.Items[userListView.SelectedIndices[0]].Text.Trim();
                userInfoLabel.Text = userListView.Items[userListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                userIDtoEdit = userListView.Items[userListView.SelectedIndices[0]].SubItems[2].Text.Trim();

                ShowRoleView("1", userRolesListView, userManager.GetUserMenuList("2", userIDtoEdit));
            }
        }

        private void userRolesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;

            if (item != null)
            {
                if (item.Checked)
                {
                    item.SubItems[1].Text.Trim();                    
                }
                else
                {
                    
                }
            }
        }
        
        #endregion  

        #region Role Settings
        private void roleSaveButton_Click(object sender, EventArgs e)
        {
            if (IsValid("3"))
            {
                if (userManager.RoleManagement(role))
                {
                    ClearAllFields("2");
                }
            }
            role = null;
        }

        private void groupClearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("2");
        }

        private void rolesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rolesListView.SelectedIndices.Count > 0)
            {
                IsEdit = true;
                roleViewsListView.ItemChecked -= new ItemCheckedEventHandler(roleViewsListView_ItemChecked);

                roleTextBox.Text = rolesListView.Items[rolesListView.SelectedIndices[0]].Text.Trim();
                roleDescriptionTextBox.Text = rolesListView.Items[rolesListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                roleIDtoEdit = rolesListView.Items[rolesListView.SelectedIndices[0]].SubItems[2].Text.Trim();

                if (role == null)
                {
                    role = new Role();
                } 
                ShowRoleView("2", roleViewsListView, userManager.GetUserMenuList("4", roleIDtoEdit));
                roleViewsListView.ItemChecked += new ItemCheckedEventHandler(roleViewsListView_ItemChecked);
            }
        }

        private void roleViewsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;

            if (item != null)
            {
                if (!item.Checked)
                {
                    //Change the role status to delete                              
                    Task roleTask = (Task)role.RoleTasks[item.SubItems[3].Text.Trim()];
                    roleTask.Condition = "4";                    
                }                
            }
        }
        #endregion

        #region View Settings
        private void viewSaveButton_Click(object sender, EventArgs e)
        {
            if (IsValid("4"))
            {
                if (userManager.TaskManagement(task))
                {
                    ClearAllFields("3");
                }
            }
            task = null;
        }

        private void viewClearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("3");
        }

        private void viewsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewsListView.SelectedIndices.Count > 0)
            {
                viewShowNameTextBox.Text = viewsListView.Items[viewsListView.SelectedIndices[0]].Text.Trim();
                viewShortNameTextBox.Text = viewsListView.Items[viewsListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                viewDescriptionTextBox.Text = viewsListView.Items[viewsListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                parentMenuComboBox.Text = viewsListView.Items[viewsListView.SelectedIndices[0]].SubItems[4].Text.Trim();
                tasktoEdit = viewsListView.Items[viewsListView.SelectedIndices[0]].SubItems[3].Text.Trim();
                IsEdit = true;
                //viewShortNameTextBox.ReadOnly = true;
            }
        }
        #endregion 

        #region Parent Menu Settings
        private void menuSaaveButton_Click(object sender, EventArgs e)
        {
            if (IsValid("5"))
            {
                if (userManager.ParentMenuManagement(task))
                {
                    ClearAllFields("4");
                }
            }
            task = null;
        }

        private void menuClearButton_Click(object sender, EventArgs e)
        {
            ClearAllFields("4");
        }

        private void parentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parentListView.SelectedIndices.Count > 0)
            {
                pMenuShowNameTextBox.Text = parentListView.Items[parentListView.SelectedIndices[0]].Text.Trim();
                pMenuShortNameTextBox.Text = parentListView.Items[parentListView.SelectedIndices[0]].SubItems[1].Text.Trim();
                pMenuDescriptionTextBox.Text = parentListView.Items[parentListView.SelectedIndices[0]].SubItems[2].Text.Trim();
                tasktoEdit = parentListView.Items[parentListView.SelectedIndices[0]].SubItems[3].Text.Trim();
                IsEdit = true;
                //pMenuShortNameTextBox.ReadOnly = true;
            }
        }
        #endregion


        #region Validation

        private void ClearListviewSelection(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = false;
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }
        }

        private void ShowRoleView(string choice, ListView listView, DataTable dt)
        {
            ClearListviewSelection(listView);

            if (role != null)
            {
                role.RoleTasks.Clear();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow   dr in dt.Rows)
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        switch(choice)
                        {
                            case "1":
                                if (dr["Code"].ToString().Trim() == item.SubItems[2].Text.Trim())
                                {
                                    item.Checked = true;
                                    item.BackColor = Color.Blue;
                                    item.ForeColor = Color.White;
                                }
                                break;
                            case "2":
                                if (dr["Code"].ToString().Trim() == item.SubItems[3].Text.Trim())
                                {
                                    item.Checked = true;
                                    item.BackColor = Color.Blue;
                                    item.ForeColor = Color.White;

                                    Task task = new Task();
                                    task.ID = dr["Code"].ToString().Trim();
                                    task.SlNo = dr["SlNo"].ToString().Trim();
                                    task.Condition = null;
                                    role.RoleTasks.Add(task.ID.Trim(), task);
                                }
                                break;
                        }
                    }
                }
            }
        }

        //clear all fields
        private void ClearAllFields(string choice)
        {
            switch (choice)
            {
                case "1":
                    //clear all user settings info
                    empCodeTextBox.Clear();
                    userInfoLabel.Text = "";
                    userWindowsIDTextBox.Clear();
                    userDescriptionTextBox.Clear();
                    userRolesListView.ItemChecked -= new ItemCheckedEventHandler(userRolesListView_ItemChecked);
                    user = null;
                    IsEdit = false;
                    break;
                case "2":
                    //clear all role settings info
                    roleTextBox.Clear();
                    roleDescriptionTextBox.Clear();
                    role = null;
                    IsEdit = false;
                    roleViewsListView.ItemChecked -= new ItemCheckedEventHandler(roleViewsListView_ItemChecked);
                    break;
                case "3":
                    //clear all task view settings info
                    viewShortNameTextBox.Clear();
                    viewShowNameTextBox.Clear();
                    viewDescriptionTextBox.Clear();
                    parentMenuComboBox.SelectedIndex = -1;
                    task = null;
                    IsEdit = false;
                    break;
                case "4":
                    //clear all parent menu settings info
                    pMenuShortNameTextBox.Clear();
                    pMenuShowNameTextBox.Clear();
                    pMenuDescriptionTextBox.Clear();
                    pMenuShortNameTextBox.ReadOnly = false;
                    task = null;
                    IsEdit = false;
                    break;
            }
            ShowList();
        }

        //check any item selected or no
        private bool HaveNoSelection(ListView lstView)
        {
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        //private void AddItemInRequisition()
        //{
        //    try
        //    {
        //        foreach (ListViewItem item in itemListView.Items)
        //        {
        //            if (item.Checked)
        //            {
        //                if (!itemExist(item.SubItems[3].Text.Trim()))
        //                {
        //                    int newRow = storeReqDataGridView.Rows.Add();
        //                    storeReqDataGridView.Rows[newRow].Cells[1].Value = newRow + 1;
        //                    storeReqDataGridView.Rows[newRow].Cells[2].Value = item.Text.Trim();
        //                    storeReqDataGridView.Rows[newRow].Cells[3].Value = item.SubItems[1].Text.Trim();
        //                    storeReqDataGridView.Rows[newRow].Cells[4].Value = item.SubItems[2].Text.Trim();
        //                    storeReqDataGridView.Rows[newRow].Cells[8].Value = item.SubItems[3].Text.Trim();
        //                    storeReqDataGridView.Rows[newRow].Cells[9].Value = item.SubItems[4].Text.Trim();
        //                    storeReqDataGridView.Rows[newRow].Cells[10].Value = stationaryComboBox.SelectedValue.ToString().Trim();
        //                }
        //                item.Remove();
        //            }
        //        }
        //    }
        //    catch { }
        //}        

        private bool IsValid(string choice)
        {
            try
            {
                switch (choice)
                {
                    case "1":
                        //User settings validation
                        if (string.IsNullOrEmpty(empCodeTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter Employee Code");
                            empCodeTextBox.Focus();
                            return false;
                        }
                        else
                        {
                            SetValues(choice);
                        }
                        break;
                    case "2":
                        //User settings validation
                        if (string.IsNullOrEmpty(empCodeTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter Employee Code");
                            empCodeTextBox.Focus();
                            return false;
                        }
                        else if (HaveNoSelection(userRolesListView))
                        {
                            MessageBox.Show("Select roles");
                            userRolesListView.Focus();
                            return false;
                        }
                        else
                        {
                            SetValues(choice);
                        }
                        break;
                    case "3":
                        //Reles settings validation
                        if (string.IsNullOrEmpty(roleTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter Role Name");
                            roleTextBox.Focus();
                            return false;
                        }
                        else if (HaveNoSelection(roleViewsListView))
                        {
                            MessageBox.Show("Select role task");
                            roleViewsListView.Focus();
                            return false;
                        }
                        else
                        {
                            SetValues(choice);
                        }
                        break;
                    case "4":
                        //Task settings validation
                        if (string.IsNullOrEmpty(viewShortNameTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter view name");
                            viewShortNameTextBox.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(parentMenuComboBox.Text.Trim()))
                        {
                            MessageBox.Show("Select Parent Menu");
                            parentMenuComboBox.Focus();
                            return false;
                        }
                        else
                        {
                            SetValues(choice);
                        }
                        break;
                    case "5":
                        //Task settings validation
                        if (string.IsNullOrEmpty(pMenuShortNameTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Enter Menu Eame");
                            pMenuShortNameTextBox.Focus();
                            return false;
                        }                        
                        else
                        {
                            SetValues(choice);
                        }
                        break;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SetValues(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (user == null)
                    {
                        user = new User();
                    }
                    user.EmpCode = Verification.verifyEmployeeID(empCodeTextBox.Text.Trim());
                    user.WindowsID = userWindowsIDTextBox.Text.Trim();
                    user.Description = userDescriptionTextBox.Text.Trim();                    
                    
                    if (IsEdit)
                    {
                        user.UserID = userIDtoEdit.Trim();
                        user.Condition = "2";
                    }
                    break;
                case "2":
                    if (user == null)
                    {
                        user = new User();
                    }

                    user.UserID = userIDtoEdit.Trim();

                    foreach (ListViewItem item in userRolesListView.Items)
                    {
                        if (item.Checked)
                        {
                            Role userRole = new Role();
                            userRole.ID = item.SubItems[2].Text.Trim();

                            if (IsEdit)
                            {
                                userRole.UID = userIDtoEdit.Trim();
                            }
                            user.Roles.Add(userRole.ID, userRole);
                        }
                    }
                    //if (IsEdit)
                    //{
                    //    user.Condition = "2";
                    //}
                    break;
                case "3":
                    if (role == null)
                    {
                        role = new Role();
                    }
                    role.Name = roleTextBox.Text.Trim();
                    role.Description = roleDescriptionTextBox.Text.Trim();

                    foreach (ListViewItem item in roleViewsListView.Items)
                    {       
                        //add the tasks of role
                        if (item.Checked)
                        {    
                            Task rTask = new Task();
                            rTask.ID = item.SubItems[3].Text.Trim();
                            rTask.Condition = "3";

                            if (IsEdit)
                            {
                                rTask.RoleID = roleIDtoEdit.Trim();
                                if (role.RoleTasks.ContainsKey(rTask.ID.Trim()))
                                {
                                    role.RoleTasks.Remove(rTask.ID.Trim());
                                }
                                else
                                {
                                    role.RoleTasks.Add(rTask.ID.Trim(), rTask);
                                }
                            }
                            else
                            {
                                role.RoleTasks.Add(rTask.ID, rTask);
                            }
                        }                        
                    }
                    if (IsEdit)
                    {
                        role.Condition = "2";
                    }
                    break;
                case "4":
                    if (task == null)
                    {
                        task = new Task();
                    }
                    task.ShortCode = viewShortNameTextBox.Text.Trim();
                    task.ViewName = viewShowNameTextBox.Text.Trim();
                    task.Description = viewDescriptionTextBox.Text.Trim();
                    task.ParMenuID = parentMenuComboBox.SelectedValue.ToString();
                    if (IsEdit)
                    {
                        task.ID = tasktoEdit.Trim();
                        task.Condition = "2";
                    }
                    break;
                case "5":
                    if (task == null)
                    {
                        task = new Task();
                    }
                    task.ShortCode = pMenuShortNameTextBox.Text.Trim();
                    task.ViewName = pMenuShowNameTextBox.Text.Trim();
                    task.Description = pMenuDescriptionTextBox.Text.Trim();
                    if (IsEdit)
                    {
                        task.ParMenuID = tasktoEdit.Trim();
                        task.Condition = "2";
                    }
                    break;
            }
        }
        #endregion

        

        

        

        

        

        

        

        

        

    }
}
