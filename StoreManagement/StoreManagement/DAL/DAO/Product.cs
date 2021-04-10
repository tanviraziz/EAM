using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Product
    {
        public Product()
        {
            IssuedGRR = new Dictionary<string, Dictionary<string, ItemIssueFromGRR>>();  
        }
        //Field
        private string condition = "1";

        //Property
        public string PID { get; set; }
        public Int16 StationaryID { get; set; }
        public string PCode { get; set; }
        public string ReqPID { get; set; }
        public string PTDId { get; set; }
        public string PRDetID { get; set; }
        public string PurOrdID { get; set; }
        public string POrdDetID { get; set; }
        public string Pname { get; set; }
        public decimal StockQty { get; set; }
        public decimal ReqQty { get; set; }
        public decimal IssueQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal QtyBoforeInspec { get; set; }
        public decimal QtyAfterInspec { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Vat { get; set; }
        public string Remarks { get; set; }
        public byte InspecRemarks { get; set; }
        public string CahallanInfo { get; set; }
        public string PhysFound { get; set; }
        public Dictionary<string, Dictionary<string, ItemIssueFromGRR>> IssuedGRR { get; set; }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }

    //  Item Issue from GRR 
    class ItemIssueFromGRR
    {
        //Fields
        private string condition = "1";

        //propertis
        public string SrrFromGrrID { get; set; } //  table row id
        public string GRRId { get; set; }        //  GRR ID
        public string SRRId { get; set; }        //  SRR iD
        public string GrrDetailID { get; set; }  //  Grr Chiled table id
        public string SrrDetailID { get; set; }  //  Srr Chield table id
        public string GoodsID { get; set; }      //  Item Code
        public decimal IssuedQty { get; set; }   //  Item Issued qty from GRR
        public string Status { get; set; }       //  Row Status

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
