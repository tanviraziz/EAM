using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class SRR
    {
        public SRR()
        {
            Products = new List<Product>();
            Items = new Dictionary<string, Product>();            
            SRRDate = DateTime.Now;
        }
        //Fields
        private string condition = "1";

        //Property
        public Int64 SRRID { get; set; }
        public DateTime SRRDate { get; set; }
        public Int32 DeptUID { get; set; }
        public string Purpose { get; set; }
        public string RequisitionBy { get; set; }
        public string IssuedBy { get; set; }
        public string ReceivedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public Dictionary<string, Product> Items { get; set; }        
        public List<Product> Products { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }

    
}
