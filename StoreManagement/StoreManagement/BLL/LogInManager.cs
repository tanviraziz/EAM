using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class LogInManager
    {
        private LogInGateway logInGateway = null;
        public LogInManager()
        {
            logInGateway = new LogInGateway();
        }

        public bool LogInVerification(string userid, string password)
        {
            DataTable dt = logInGateway.LogInVerification(userid, password);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    LoginUser.UID = dt.Rows[0]["UID"].ToString().Trim();
                    LoginUser.UserID = dt.Rows[0]["EmpID"].ToString().Trim();
                    LoginUser.UserDepartment = dt.Rows[0]["DeptUID"].ToString().Trim();
                    
                    //save the user entry log
                    using (UserGateway userGateway = new UserGateway())
                    {
                        userGateway.UserManagement(new User() { UserID = LoginUser.UID, Condition = "5" });
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
