using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class FSDCertificate
    {
        public FSDCertificate()
        {
            Items = new Dictionary<string, Product>();
            InspectionDate = DateTime.Now;
            PRecvFromHRD = DateTime.Now;
            ApprovedDate = DateTime.Now;
        }
        //Fields
        private string condition = "1";

        //Property
        public Int64 GrrId { get; set; }
        public string CertificateID { get; set; }
        public Int16 UnitID { get; set; }
        public Int32 DeptUID { get; set; }       
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
        public DateTime ApprovedDate { get; set; }
        public DateTime PRecvFromHRD { get; set; }
        public string Status { get; set; }

        #region Summery
        public Int64 InspSID { get; set; }
        public string YYMM { get; set; }
        public string Remarks { get; set; }
        #endregion

        public Dictionary<string, Product> Items { get; set; }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }

    class InspectionRemarks
    {
        //Fields
        private string condition = "1";

        //Property
        public string RemarksID { get; set; }
        public string Remarks { get; set; }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }

    class InspectionNotes
    {
        //Fields
        private string condition = "1";

        //Property
        public string refNoteID { get; set; }
        public string RefID { get; set; }
        public string Note { get; set; }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
