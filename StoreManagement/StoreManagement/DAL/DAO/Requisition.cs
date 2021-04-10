using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Requisition
    {
        public Requisition()
        {
            Products = new List<Product>();
            Items = new Dictionary<string, Product>();
            TenderTerms = new Dictionary<string, TermsCondition>();
            PurOrdDate = DateTime.Now;
            DeliveryDate = DateTime.Now;
            CepDate = DateTime.Now;
            IsEmargency = "N";
        }
        //Fields
        private string condition = "1";

        //Start: Property
        public Int16 UnitID { get; set; }
        #region Store Requisition
            public Int64 SrrId { get; set; }
            public string SrrNo { get; set; }
            public Int32 DeptId { get; set; }
            public Int64 CostHOfDeptID { get; set; }
        #endregion

        #region Purchase Requisition
            public Int64 PrrId { get; set; }
            public string PrrNo { get; set; }
            public string PRYear { get; set; }
            public string TimePeriod { get; set; }
            public Int16 SCategory { get; set; }
            public string Status { get; set; }            
        #endregion 
       
        #region Purchase Order
            public Int64 PurOrdID { get; set; }
            public string PurOrdNo { get; set; }
            public string CepNO { get; set; }
            public DateTime CepDate { get; set; }
            public Int32 SupplierID { get; set; }
            public DateTime PurOrdDate { get; set; }
            public DateTime DeliveryDate { get; set; }
            public decimal Vat { get; set; }
            public string VatIncluded { get; set; } // 1 for vat not include with price and 2 for vat included with price
        #endregion

        #region Tender Terms and Condition
            public Dictionary<string, TermsCondition> TenderTerms { get; set; }
            public string TenderReferecne { get; set; }
            public string TermsConditions { get; set; }
        #endregion

        public string IsEmargency { get; set; }
        public decimal TotalItem { get; set; }
        public List<Product> Products { get; set; }
        public Dictionary<string, Product> Items { get; set; }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        //End: Property
    }
}
