using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Order
    {
        public Order()
        {
            Products = new List<Product>();
            Items = new Dictionary<string, Product>();
            PurOrdDate = DateTime.Now;
            CepDate = DateTime.Now;
            DeliveryDate = DateTime.Now;
        }

        //Fields
        private string condition = "1";


        #region Purchase Order
            public Int64 PurOrdID { get; set; }
            public string PurOrdNo { get; set; }
            public string CepNO { get; set; }
            public DateTime CepDate { get; set; }
            public Int32 SupplierID { get; set; }
            public DateTime PurOrdDate { get; set; }
            public DateTime DeliveryDate { get; set; }

        #endregion

        #region Purchase Order Print
            public string ReqRaisedBy { get; set; }
            public string EndUser { get; set; }
            public string PurchaseRef { get; set; }
            public decimal AdvanceAmt { get; set; }
            public decimal Discount { get; set; }
            public string TermsAndConditions { get; set; }
        #endregion
        
        public decimal TotalItem { get; set; }
        public List<Product> Products { get; set; }
        public Dictionary<string, Product> Items { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
