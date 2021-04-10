using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.DAO
{
    class GRR
    {
        public GRR()
        {
            Products = new List<Product>();
            Items = new Dictionary<string, Product>();
            InspectionDate = DateTime.Now;
            PRecvFromHRD = DateTime.Now;
        }
        //Fields
        private string condition = "1";

        //Property
        public Int64 GrrId { get; set; }
        public Int16 UnitID { get; set; }
        public Int32 DeptUID { get; set; }
        public string GrrNo { get; set; }
        public DateTime GrrDate { get; set; }
        public Int32 SupplierID { get; set; }
        public Int32 ManufacturerID { get; set; }
        public string Acceptance { get; set; }
        public string Comments { get; set; }
        public Int64 PurchseOrdID { get; set; }
        public string PurchseOrderNo { get; set; }
        public DateTime PurchseOrderDate { get; set; }
        public string CepNo { get; set; }
        public DateTime CepDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CostCenterCode { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal TotalPay { get; set; }
        public decimal TotalVat { get; set; }
        public DateTime InspectionDate { get; set; }
        public DateTime PRecvFromHRD { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }

        public List<Product> Products { get; set; }
        public Dictionary<string, Product> Items { get; set; }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
