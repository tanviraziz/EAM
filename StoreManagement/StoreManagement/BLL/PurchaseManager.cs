using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class PurchaseManager
    {
        #region Veriables
            PurchaseGateway purchaseGateway = null;
        #endregion

        public PurchaseManager()
        {
            purchaseGateway = new PurchaseGateway();
        }

        #region Purchase Requisition Management

        //Manage the purchase requisition(Insert,update,delete)
        public bool PrrManagement(Requisition prr)
        {
            return purchaseGateway.PrrManagement(prr);
        }

        public bool PrrConfirmedAndVerified(Requisition prr)
        {
            return purchaseGateway.PrrConfirmetionManagement(prr);
        }

        //return the Purchase Requisition list in a datatable
        public DataTable GetPurchaseRequistionList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseRequistion(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase Requisition list in a datatable for store Authority
        public DataTable GetPurchaseRequisitonApprovalList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseRequisitonApproval(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase Requisition list in a datatable for store Authority report
        public DataTable GetStoreAuthorityReportList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.StoreAuthorityReport(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase Requisition list in a datatable   
        public DataTable GetPurchaseRequistionProcessList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseRequistionProcessList(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase Requisition list in a datatable   
        public DataTable GetPurchaseRequistionProcessReport(string choice, string condition1,string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseRequistionProcessReport(choice, condition1,condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

        #region Purchase Tander Management
        //Manage the purchase tender(Insert,update,delete)
        public bool TenderManagement(Requisition prr)
        {
            return purchaseGateway.TenderManagement(prr);
        }

        public bool TenderSchedulePrintManagement(Requisition requisition)
        {
            return purchaseGateway.TenderSchedulePrintManagement(requisition);
        }

        //Manage the (Tender & Purchase Order) Terms and Condition(Insert,update,delete)
        public bool TermsConditionsManagement(Requisition requisition)
        {
            return purchaseGateway.TermsConditionsManagement(requisition);
        }

        //Manage the tender approval 
        public bool TenderApprovalManagement(Requisition prr)
        {
            return purchaseGateway.TenderApprovalManagement(prr);
        }

        //return the Purchase requisition and tender list in a datatable
        public DataTable GetTermsConditionsList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.TermsConditionsList(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase requisition and tender list in a datatable
        public DataTable GetPurchaseTenderList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseTender(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase requisition and tender list in a datatable
        public DataTable GetTenderReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.TenderReport(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Purchase requisition and tender list in a datatable
        public DataTable GetPurchaseRequisitionReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseRequisitionReport(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

        #region PUrchase Order Management
        //Manage the purchase Order(Insert,update,delete)
        public bool PurOrdManagement(Requisition prr)
        {
            return purchaseGateway.PurOrdManagement(prr);
        }

        //Manage the emargency purchase Order(Insert,update,delete)
        public bool EmargencyPurchaseOrdManagement(Requisition prr)
        {
            return purchaseGateway.EmargencyPurchaseOrdManagement(prr);
        }

        public bool PurOrderPrintManagement(Order purchaseOrder)
        {
            return purchaseGateway.PurOrdPrintManagement(purchaseOrder);
        }

        //return the purchase order type list in a datatable
        public DataTable GetPurchaseOrderTypeList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseOrderType(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Order list in a datatable
        public DataTable GetPurchaseOrderList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseOrder(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the Order search list in a datatable
        public DataTable GetPurchaseOrderReport(string choice1, string choice2, string condition1, string condition2)
        {
            try
            {
                DataTable dt = null;
                switch(choice1.Trim())
                {
                    case "1":
                        //return the search date for PurchaseOrderActionUI
                        dt = purchaseGateway.PurchaseOrderReport("GetPruchaseOrderReport", choice2, condition1, condition2);
                        break;
                    case "2":
                        //return the search date for MISPurchaseOrderActionUI
                        dt = purchaseGateway.PurchaseOrderReport("GetMISOrderReport", choice2, condition1, condition2);
                        break;
                }
                
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return the emargency order list in a datatable
        public DataTable GetCashPruchaseOrderList(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.CashPruchaseOrderList(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public DataTable GetEmargencyPurchaseOrderReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.EmargencyPurchaseOrderReport(choice, condition1,condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return purchase order process list in a datatable
        public DataTable GetPruchaseOrderProcessList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.PruchaseOrderProcessList(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return purchase order process list in a datatable
        public DataTable GetPruchaseOrderPrint(string choice, string condition)
        {
            try
            {
                DataTable dt = purchaseGateway.PruchaseOrderPrint(choice, condition);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return purchase order for Procurement pending for payment process list in a datatable
        public DataTable GetPurchaseOrderPaymentList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseOrderPaymentList(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return purchase order for Procurement confirmed for payment process list in a datatable
        public DataTable GetPurchaseOrderPaymentReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.PurchaseOrderPaymentReport(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //return purchase order list pending for accounts payment process in a datatable
        public DataTable GetAccountsPurchaseOrderPaymentList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = purchaseGateway.AccountsPurchaseOrderPaymentList(choice, condition1, condition2);
                if (dt != null)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

    }
}
