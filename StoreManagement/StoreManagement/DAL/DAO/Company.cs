using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Company
    {
        //Start : Fields

        private string condtion = "1";  // 1 for new entry or insert as defalut, 
                                        // to update and delete need to change in 
                                        // calling portion

        //End : Fields        

        //Start: Property
        public string Name { get; set; }

        #region Company Information
            public byte ComapanyID { get; set; }
            public string Address { get; set; }
            public string PhoneNo {get;set;}
            public string Email { get; set; }
            public string Fax { get; set; }
            public Byte[] Logo { get; set; }
        #endregion

        #region Unit Information
            public Int32 UnitID { get; set; }
        #endregion

        #region Department Information
            public Int32 DeptID { get; set; }
        #endregion        
        
        public string Remarks { get; set; }
        public string Condtion
        {
            get { return condtion; }
            set { condtion = value; }
        }

        //End: Property
    }
}
