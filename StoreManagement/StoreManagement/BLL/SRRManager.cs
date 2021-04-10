using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;


namespace StoreManagement.BLL
{
    class SRRManager
    {
        private SRRGateway srrGateway = null;
        public SRRManager()
        {
            srrGateway = new SRRGateway();
        }

        #region SRR Managememt

        //Insert, Update and delete GRR
        public bool SRRManagement(SRR srr)
        {
            return srrGateway.SrrManagement(srr);
        }

        //return the item stock from GRR list
        public DataTable GetItemGRRList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = srrGateway.ItemGRRList(choice, condition1, condition2);
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

        //return the SRR list in a datatable
        public DataTable GetSRRList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = srrGateway.SrrList(choice, condition1,condition2);
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

        //return the User SRR list in a datatable
        public DataTable GetUserSRRList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = srrGateway.UserSrrList(choice, condition1, condition2);
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

        //return the Authority SRR list in a datatable
        public DataTable GetAuthoritySRRList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = srrGateway.AuthoritySrrList(choice, condition1, condition2);
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
