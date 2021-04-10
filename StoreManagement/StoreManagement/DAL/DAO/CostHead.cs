using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class CostHead
    {
        //Start : Fields

        private string condtion = "1"; // 1 for new entry or insert as defalut, 
                                       // to update and delete need to change in 
                                       // calling portion

        //End : Fields        

        //Start: Property
        public string BudgetID { get; set; }
        public Int16 CostHeadID { get; set; }
        public Int32 CostofDeptID  { get; set;}
        public string MapicCode { get; set; }
        public decimal Budget { get; set; }
        public string BudgerYear { get; set; }
        public string Remarks { get; set; }
        public string Condtion
        {
            get { return condtion; }
            set { condtion = value; }
        }

        //End: Property
    }
}
