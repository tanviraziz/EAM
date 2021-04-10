using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class FSDManager
    {
        private FSDGateway fsdGateway = null;
        public FSDManager()
        {
            fsdGateway = new FSDGateway();
        }

        //Insert, Update and delete GRR Inspection
        public bool FSDCertificateManagement(FSDCertificate certificate)
        {
            return fsdGateway.FSDCertificateManagement(certificate);
        }

        public bool FSDCertificateSummeryManagement(FSDCertificate certificate)
        {
            return fsdGateway.FSDCertificateSummeryManagement(certificate);
        }

        //Insert, Update and delete GRR Inspection
        public bool CertificateApproved(FSDCertificate certificate)
        {
            return fsdGateway.CertificateApprovalManagement(certificate);
        }

        //get the FSD Certificates
        public DataTable GetFSDCertificateList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = fsdGateway.FSDCertificate(choice, condition1,condition2);
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

        //get the FSD Summaries
        public DataTable GetFSDSummeries(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = fsdGateway.FSDSummaries(choice, condition1, condition2);
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

        //get the FSD Summarie Month
        public DataTable GetFSDSummeryMonth(string choice, string condition)
        {
            try
            {
                DataTable dt = fsdGateway.FSDSummaryMonth(choice, condition);
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
    }
}
