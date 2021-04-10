using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    public static class LoginUser
    {
        public static string UID { get; set; }
        public static string UserID { get; set; }
        public static string UserDepartment { get; set; }
        public static string UserPassword { get; set; }
        public static int UserAccessLevel { get; set; }
        public static string CommonDate { get; set; }
        public static string EntryLog { get; set; }
        public static string ServerDateTime { get; set; }
    }
}
