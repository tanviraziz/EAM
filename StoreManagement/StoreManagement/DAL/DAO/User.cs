using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class User
    {
        public User()
        {
            Password = "123";
            Roles = new Dictionary<string, Role>();
        }
        //Fields
        private string condition = "1";

        //Property
        public string ID { get; set; }
        public string UserID { get; set; }
        public string EmpCode { get; set; }
        public string Password { get; set; }
        public string WindowsID { get; set; }
        public string AccessLabel { get; set; }
        public string Description { get; set; }
        public Int32 OwnDepartment { get; set; }
        public string AuthorityFlag { get; set; }
        public string Status { get; set; }
        public Dictionary<string, Role> Roles { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        } 
    }

    public class Role
    {
        public Role()
        {
            RoleTasks = new Dictionary<string, Task>();
        }
        //Fields
        private string condition = "1";

        //Property
        public Int64 SlNo { get; set; }
        public string UID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Dictionary<string, Task> RoleTasks { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }

    public class Task
    {
        //Fields
        private string condition = "1";

        //Property
        public string SlNo { get; set; }
        public string ID { get; set; }
        public string RoleID { get; set; }
        public string ParMenuID { get; set; }
        public string ViewName { get; set; }
        public string Description { get; set; }
        public string ShortCode { get; set; }
        public string Status { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        } 
    }
}
