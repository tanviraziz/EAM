using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class GRRManager
    {
        private GRRGateway grrGateway = null;
        public GRRManager()
        {
            grrGateway = new GRRGateway();
        }

        #region GRR Managememt
        //Temporary Start: have to remove after purchase and fsd module integration

        //Insert, Update and delete GRR 
        public bool GRRManagement(GRR grr)
        {
            return grrGateway.GrrManagement(grr);
        }
        //Temporary End: have to remove after purchase and fsd module integration

        //Insert, Update and delete GRR Inspection
        public bool GRRInspecManagement(GRR grr)
        {
            return grrGateway.GrrIManagement(grr);
        }

        //Insert, Update and delete GRR in stock
        public bool GrrToStock(GRR grr)
        {
            return grrGateway.GrrToStock(grr);
        }

        //return theGRR list in a datatable
        public DataTable GetOrderInspeectionList(string choice, string condition)
        {
            try
            {
                DataTable dt = grrGateway.OrderInspectionList(choice, condition);
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

        //return the search list for fsd
        public DataTable GetOrderInspectionReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = grrGateway.OrderInspectionReport(choice, condition1, condition2);
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

        //return theGRR list in a datatable
        public DataTable GetGRRCertificate(string choice, string condition)
        {
            try
            {
                DataTable dt = grrGateway.FSDCertificate(choice, condition);
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

        //return theGRR list in a datatable
        public DataTable GetGRRList(string choice, string condition)
        {
            try
            {
                DataTable dt = grrGateway.GrrList(choice, condition);
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

        //return the GRR Search data
        public DataTable GetGrrReport(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = grrGateway.GrrReport(choice, condition1, condition2);
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
