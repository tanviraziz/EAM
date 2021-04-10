using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class FSDGateway
    {
        //manage Goods Receive Inspection(insert, update, delete)
        public Boolean FSDCertificateManagement(FSDCertificate certificate)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("GrrInspecManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GRRID = cmd.Parameters.Add("@GRRSID", SqlDbType.BigInt);
                GRRID.Direction = ParameterDirection.Input;
                GRRID.Value = certificate.GrrId;

                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = certificate.PurchseOrdID;

                SqlParameter Challans = cmd.Parameters.Add("@Challans", SqlDbType.VarChar, 500);
                Challans.Direction = ParameterDirection.Input;
                Challans.Value = certificate.InvoiceNo;

                SqlParameter Acceptance = cmd.Parameters.Add("@Acceptance", SqlDbType.SmallInt);
                Acceptance.Direction = ParameterDirection.Input;
                Acceptance.Value = Convert.ToInt16(certificate.Acceptance);

                SqlParameter Comments = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
                Comments.Direction = ParameterDirection.Input;
                Comments.Value = certificate.Comments;

                SqlParameter DeptUID = cmd.Parameters.Add("@DeptUID", SqlDbType.Int);
                DeptUID.Direction = ParameterDirection.Input;
                DeptUID.Value = Convert.ToInt32(certificate.DeptUID);

                SqlParameter TotalAmt = cmd.Parameters.Add("@TotalAmt", SqlDbType.Decimal);
                TotalAmt.Direction = ParameterDirection.Input;
                TotalAmt.Value = certificate.TotalPay;

                SqlParameter TotalVat = cmd.Parameters.Add("@TotalVat", SqlDbType.Decimal);
                TotalVat.Direction = ParameterDirection.Input;
                TotalVat.Value = certificate.TotalVat;

                SqlParameter InspectionDate = cmd.Parameters.Add("@InspectionDate", SqlDbType.DateTime);
                InspectionDate.Direction = ParameterDirection.Input;
                InspectionDate.Value = certificate.InspectionDate;

                SqlParameter PRecvFromHRD = cmd.Parameters.Add("@PRecvFromHRD", SqlDbType.DateTime);
                PRecvFromHRD.Direction = ParameterDirection.Input;
                PRecvFromHRD.Value = certificate.PRecvFromHRD;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = certificate.Status;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = certificate.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                //Start:inasert certificate item information
                //if (certificate.Products.Count > 0)
                //{
                //    foreach (var certificateItem in certificate.Products)
                //    {
                //        if (!GrIDetailManagement(certificateItem, sqlConnection, transaction))
                //        {
                //            transaction.Rollback();
                //            return false;
                //        }
                //    }
                //}
                //End:inasert certificate item information  

                transaction.Commit();
            }
            catch
            {
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                certificate = null;
            }
            return true;
        }

        private Boolean GrIDetailManagement(Product grIItem, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("GrrInspecDetailManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNO = cmd.Parameters.Add("@SlNO", SqlDbType.BigInt);
                SlNO.Direction = ParameterDirection.Input;
                SlNO.Value = grIItem.PID;

                SqlParameter POrdDetID = cmd.Parameters.Add("@POrdDetID", SqlDbType.BigInt);
                POrdDetID.Direction = ParameterDirection.Input;
                POrdDetID.Value = grIItem.POrdDetID;

                SqlParameter GoodsID = cmd.Parameters.Add("@GoodsID", SqlDbType.Int);
                GoodsID.Direction = ParameterDirection.Input;
                GoodsID.Value = grIItem.PCode;

                SqlParameter ChallanItem = cmd.Parameters.Add("@ChallanInfo", SqlDbType.VarChar, 500);
                ChallanItem.Direction = ParameterDirection.Input;
                ChallanItem.Value = grIItem.CahallanInfo;

                SqlParameter QtyBfrInspection = cmd.Parameters.Add("@PhysFound", SqlDbType.VarChar, 500);
                QtyBfrInspection.Direction = ParameterDirection.Input;
                QtyBfrInspection.Value = grIItem.PhysFound;

                SqlParameter TotalRecv = cmd.Parameters.Add("@TotalRecv", SqlDbType.Decimal);
                TotalRecv.Direction = ParameterDirection.Input;
                TotalRecv.Value = grIItem.Quantity;

                SqlParameter Remark = cmd.Parameters.Add("@Remark", SqlDbType.TinyInt);
                Remark.Direction = ParameterDirection.Input;
                Remark.Value = grIItem.Remarks;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = grIItem.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                grIItem = null;
            }
            return true;
        }

        //manage monthly Inspection summery(insert, update, delete)
        public Boolean FSDCertificateSummeryManagement(FSDCertificate certificate)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("FSDInspectionSummeryManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GRRID = cmd.Parameters.Add("@InspSID", SqlDbType.BigInt);
                GRRID.Direction = ParameterDirection.Input;
                GRRID.Value = certificate.InspSID;


                SqlParameter YYMM = cmd.Parameters.Add("@YYMM", SqlDbType.VarChar, 10);
                YYMM.Direction = ParameterDirection.Input;
                YYMM.Value = certificate.YYMM;

                SqlParameter Status = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500);
                Status.Direction = ParameterDirection.Input;
                Status.Value = certificate.Remarks;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = certificate.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }                     

                transaction.Commit();
            }
            catch
            {
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                certificate = null;
            }
            return true;
        }

        public Boolean CertificateApprovalManagement(FSDCertificate certificate)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("GrrInspecManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GRRID = cmd.Parameters.Add("@GRRSID", SqlDbType.BigInt);
                GRRID.Direction = ParameterDirection.Input;
                GRRID.Value = certificate.CertificateID;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = certificate.Status;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = certificate.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                certificate = null;
            }
            return true;
        }

        //get all FSD Certificates
        public DataTable FSDCertificate(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetFSDCertificateForApproval";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition1", SqlDbType.VarChar, 100);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition2", SqlDbType.VarChar, 100);
                Condition2.Direction = ParameterDirection.Input;
                Condition2.Value = condition2;

                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(cmd);
                sqlDataAdapterObj.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
            }
        }

        //get all FSD Certificates
        public DataTable FSDSummaries(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetFSDSummery";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition1", SqlDbType.VarChar, 100);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition2", SqlDbType.VarChar, 100);
                Condition2.Direction = ParameterDirection.Input;
                Condition2.Value = condition2;

                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(cmd);
                sqlDataAdapterObj.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
            }
        }

        //get all FSD Certificates
        public DataTable FSDSummaryMonth(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetTheFSDSummeryMonth";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition;

                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(cmd);
                sqlDataAdapterObj.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
            }
        }
    }
}
