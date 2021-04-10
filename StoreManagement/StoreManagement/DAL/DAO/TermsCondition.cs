using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class TermsCondition
    {
        //Fields
        private string condition = "1";

        //Property
        public string ID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
