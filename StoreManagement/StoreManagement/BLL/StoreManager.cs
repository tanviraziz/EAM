using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class StoreManager
    {
        #region Veriabls
            private StoreGateway storeGateway = null;
        #endregion

        public StoreManager()
        {
            storeGateway = new StoreGateway();
        }

        //return the current stock list in a datatable
        public DataTable GetCurrentStock(string choice, string condition)
        {
            try
            {
                DataTable dt = storeGateway.StockLIst(choice, condition);
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

        public DataTable GetStoreDeshBoardData(string choice1,string choice2,string condition1,string condition2)
        {
            try
            {
                DataTable dt = storeGateway.StoreDeshBoardData(choice1, choice2, condition1, condition2);
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

        public bool ManageMonthlyClosing(string condition)
        {
            try
            {
                return storeGateway.ManageMonthlyClosing(condition);                
            }
            catch
            {
                return false;
            }            
        }


        //get the store closing month
        public int GetStoreClosingMonth(string choice)
        {
            DataTable dt = null;
            try
            {
                dt = storeGateway.GetStockClosingMonth(choice);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt16(dt.Rows[0]["CurrentMonth"].ToString().Trim());
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

         public Int32 GetPendingGrrToPostingList(string choice, string condition)
         {
            DataTable dt = null;
            Int32 pendingGRR = 0;
            try
            {
                dt = storeGateway.PendingGrrToPosting(choice,condition);
                if (dt != null && dt.Rows.Count > 0)
                {
                    pendingGRR = Convert.ToInt32(dt.Rows[0]["PendingGrr"].ToString().Trim());
                }
            }
            catch
            {
                return 0;
            }
            return pendingGRR;
        }
    }
}
