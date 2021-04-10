using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;
using System.Collections;
using StoreManagement.UTILITY.CustomeControl;
using System.Diagnostics;

namespace StoreManagement.BLL
{
    class UserManager 
    {
        #region Local Variables
            private UserGateway userGateway = null;
        #endregion

        public UserManager()
        {
            userGateway = new UserGateway();
        }

        #region User Management

        public bool ManageTheUser(User user)
        {
            return userGateway.UserManagement(user);
        }

        public bool ManageUserRoles(User user)
        {
            return userGateway.UserSettingsManagement(user);
        }

        public bool UserPasswordManagement(User usrPassword)
        {
            return userGateway.UserPasswordManagement(usrPassword);
        }

        //return the application user list
        public DataTable GetUserList(string choice, string condition)
        {
            DataTable dt = null;
            try
            {
                dt = userGateway.UserList(choice, condition);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    dt = null;
                }
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        //return the login user information from PIS
        public DataTable GetUserInfoFromPIS(string choice, string condition)
        {
            DataTable dt = null;
            try
            {
                dt = userGateway.EmployeeInfoFromPIS(choice, condition);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    dt = null;
                }
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        //Return the user menus
        public DataTable GetUserMenuList(string choice, string condition)
        {
            DataTable dt = null;
            try
            {
                dt = userGateway.UserMenuList(choice, condition);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    dt = null;
                }
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        //return the user menu list
        public ArrayList GetMenuList(string userID)
        {
            DataTable dt = null;
            ArrayList userMenu = new ArrayList();
            SlidingMenu.NavItem nv = null;
            bool defaultView = true;
            
            try
            {
                dt = userGateway.UserMenuList("10", userID);
                if (dt == null || dt.Rows.Count > 0)
                {
                    List<string> parentMenu = (dt.AsEnumerable().Select(row => row.Field<string>("PrMenu")).Distinct()).ToList();

                    if (parentMenu.Count > 0)
                    {
                        foreach (var pMenu in parentMenu)
                        {
                            switch (pMenu.Trim())
                            {
                                case "mnuUserSettings":
                                    nv = new SlidingMenu.NavItem(" User Settings", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuCompanySettings":
                                    nv = new SlidingMenu.NavItem(" Company Settings", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuSettingsManagement":
                                    nv = new SlidingMenu.NavItem(" Settings", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuStoreTasks":
                                    nv = new SlidingMenu.NavItem("Store Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuPurchaseTasks":
                                    nv = new SlidingMenu.NavItem("Purchase Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuMISPurchaseTasks":
                                    nv = new SlidingMenu.NavItem("MIS Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuFSDTasks":
                                    nv = new SlidingMenu.NavItem("FSD Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuAccountsTasks":
                                    nv = new SlidingMenu.NavItem("Accounts Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuAuthorityTasks":
                                    nv = new SlidingMenu.NavItem("Authority Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuUserTasks":
                                    nv = new SlidingMenu.NavItem("User Tasks", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                default:
                                    nv = new SlidingMenu.NavItem("Personal Settings", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;
                                case "mnuSettings":
                                    nv = new SlidingMenu.NavItem("Personal Settings", pMenu.Trim(), GetSubMenu(dt, pMenu.Trim()), defaultView);
                                    userMenu.Add(nv);
                                    break;                                  
                            }
                            defaultView = false;
                        }
                    }
                }
                
            }
            catch
            {
                return null;
            }
            return userMenu;
        }

        //return the submenu of selected parent menu
        private ArrayList GetSubMenu(DataTable dt, string condition)
        {
            ArrayList subMenu = null;
            try
            {
                subMenu = new ArrayList();
                var query = from myRow in dt.AsEnumerable()
					                let taskID = myRow.Field<string>("TaskID")
                            where myRow.Field<string>("PrMenu") == condition.Trim()
					        orderby taskID 	descending								
					        select myRow;


                //fill the submenu 
                DataTable subMenuDt = query.CopyToDataTable<DataRow>();
                if (subMenuDt.Rows.Count > 0)
                {
                    subMenu = new ArrayList();
                    foreach(DataRow dr in subMenuDt.Rows)
                    {
                        subMenu.Add(new SlidingMenu.childNavItems(dr["TaskName"].ToString().Trim(), dr["Task"].ToString().Trim()));
                    }
                }
            }
            catch
            {
                return null;
            }
            //return the submenus
            return subMenu;
        }

        #endregion

        #region Menu Management

            #region Parent Menu Management

            //Manage the masete menu (insert,upate,delete)
            public bool ParentMenuManagement(Task parentMenu)
            {
                return userGateway.ParentMenuManagement(parentMenu);
            }

            //Return the parent menu list
            //public DataTable GetParentMenuList(string choice, string condition)
            //{
            //    DataTable dt = null;
            //    try
            //    {
            //        dt = userGateway.ParentMenuList(choice, condition);
            //        if (dt == null || dt.Rows.Count <= 0)
            //        {
            //            dt = null;
            //        }
            //    }
            //    catch
            //    {
            //        dt = null;
            //    }
            //    return dt;
            //}
            #endregion

            #region View Management

            //Manage the task/view (insert,upate,delete)
            public bool TaskManagement(Task view)
            {
                return userGateway.TaskManagement(view);
            }

            //Return the user task/view list
            //public DataTable GetViewList(string choice, string condition)
            //{
            //    DataTable dt = null;
            //    try
            //    {
            //        dt = userGateway.ViewList(choice, condition);
            //        if (dt == null || dt.Rows.Count <= 0)
            //        {
            //            dt = null;
            //        }
            //    }
            //    catch
            //    {
            //        dt = null;
            //    }
            //    return dt;
            //}
            #endregion

            #region User Role Management

            //Manage the task/view (insert,upate,delete)
            public bool RoleManagement(Role role)
            {
                return userGateway.RoleManagement(role);
            }

            //Return user role list
            //public DataTable GetUserRoleList(string choice, string condition)
            //{
            //    DataTable dt = null;
            //    try
            //    {
            //        dt = userGateway.RoleList(choice, condition);
            //        if (dt == null || dt.Rows.Count <= 0)
            //        {
            //            dt = null;
            //        }
            //    }
            //    catch
            //    {
            //        dt = null;
            //    }
            //    return dt;
            //}
            #endregion
        #endregion

        #region Inspector Management
        //insert, update, delete the FSD inspector
        public bool ManageTheInspector(User user)
        {
            return userGateway.InspectorManagement(user);
        }

        //return the FSD inspector list
        public DataTable GetInspectorList(string choice, string condition)
        {
            DataTable dt = null;
            try
            {
                dt = userGateway.InspectorList(choice, condition);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    dt = null;
                }
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
        #endregion

        //#region IDisposable Implementation

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}      

        //~UserManager()
        //{

        //}
        //#endregion
    }
}
