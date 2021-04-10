using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Supplier
    {
        public Supplier()
        {
            Items = new Dictionary<string, Product>();
        }
        //Fields
        private string condition = "1";


        //Propertis
        public Int32 SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Dictionary<string, Product> Items { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
