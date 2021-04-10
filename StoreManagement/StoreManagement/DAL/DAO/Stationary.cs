using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Stationary
    {
        //Start : Fields

        private string condtion = "1"; // 1 for new entry or insert as defalut, 
        // to update and delete need to change in 
        // calling portion

        //End : Fields        

        //Start: Property
        public Int16 StationaryID { get; set; }
        public Int64 ItemID { get; set; }
        public Int16 CategoryID { get; set; }
        public Int16 SubCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal ReOrderLevel { get; set; }
        public string Condtion
        {
            get { return condtion; }
            set { condtion = value; }
        }

        //End: Property
    }
}
