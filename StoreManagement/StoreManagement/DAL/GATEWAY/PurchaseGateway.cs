using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class PurchaseGateway
    {
        #region Purchase Requisition
        //manage Goods Receive(insert, update, delete)
        public Boolean PrrManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("PrrManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prr.PrrNo;

                SqlParameter SCatID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                SCatID.Direction = ParameterDirection.Input;
                SCatID.Value = prr.SCategory;

                SqlParameter UnitID = cmd.Parameters.Add("@UnitID", SqlDbType.SmallInt);
                UnitID.Direction = ParameterDirection.Input;
                UnitID.Value = prr.UnitID;

                SqlParameter TimePeriod = cmd.Parameters.Add("@TimePeriod", SqlDbType.VarChar, 10);
                TimePeriod.Direction = ParameterDirection.Input;
                TimePeriod.Value = prr.TimePeriod;

                SqlParameter RequisitionYear = cmd.Parameters.Add("@PRYear", SqlDbType.VarChar,10);
                RequisitionYear.Direction = ParameterDirection.Input;
                RequisitionYear.Value = prr.PRYear;

                SqlParameter TotalItem = cmd.Parameters.Add("@TotalItem", SqlDbType.Decimal);
                TotalItem.Direction = ParameterDirection.Input;
                TotalItem.Value = prr.TotalItem;

                SqlParameter CepNo = cmd.Parameters.Add("@CepNo", SqlDbType.VarChar, 100);
                CepNo.Direction = ParameterDirection.Input;
                CepNo.Value = prr.CepNO;

                SqlParameter CepDate = cmd.Parameters.Add("@CepDate", SqlDbType.DateTime);
                CepDate.Direction = ParameterDirection.Input;
                CepDate.Value = prr.CepDate;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = prr.Status;

                SqlParameter IsEmargency = cmd.Parameters.Add("@isEmargency", SqlDbType.VarChar, 10);
                IsEmargency.Direction = ParameterDirection.Input;
                IsEmargency.Value = prr.IsEmargency;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                //Start:inasert grr item information
                if (prr.Items.Count > 0)
                {
                    foreach (var prrItem in prr.Items)
                    {
                        if (!PRRDetailManagement((Product)prrItem.Value, prr.PrrNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                //End:inasert grr item information  

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
                prr = null;
            }
            return true;
        }

        private Boolean PRRDetailManagement(Product prrItem, string prrNo, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("PrrDetailManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = prrItem.PID;

                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prrNo;

                SqlParameter OrderNo = cmd.Parameters.Add("@GoodsID", SqlDbType.Int);
                OrderNo.Direction = ParameterDirection.Input;
                OrderNo.Value = prrItem.PCode;

                SqlParameter Ordered = cmd.Parameters.Add("@Stock", SqlDbType.Decimal);
                Ordered.Direction = ParameterDirection.Input;
                Ordered.Value = prrItem.StockQty;

                SqlParameter QtyBfrInspection = cmd.Parameters.Add("@Required", SqlDbType.Decimal);
                QtyBfrInspection.Direction = ParameterDirection.Input;
                QtyBfrInspection.Value = prrItem.ReqQty;

                SqlParameter QtyAftInspection = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,500);
                QtyAftInspection.Direction = ParameterDirection.Input;
                QtyAftInspection.Value = prrItem.Remarks;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prrItem.Condition;

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
                prrItem = null;
            }
            return true;
        }

        //Confirmed Purchase requisition by Store for tender processing 
        public Boolean PrrConfirmetionManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("PrrManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prr.PrrNo;                

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
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
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                prr = null;
            }
            return true;
        }

        public DataTable PurchaseRequistion(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseRequisitionList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable PurchaseRequisitonApproval(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPurchaseRequisitonApprovalList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable StoreAuthorityReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetStoreAuthorityReport";
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

        public DataTable PurchaseRequistionProcessList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPurRequisitionProcessList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable PurchaseRequistionProcessReport(string choice, string condition1,string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseRequisitionProcessReport";
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
        #endregion

        #region Tender Management

        public Boolean TenderManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("TenderManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter TenderID = cmd.Parameters.Add("@PTId", SqlDbType.BigInt);
                TenderID.Direction = ParameterDirection.Input;
                TenderID.Value = prr.PrrId;

                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prr.PrrNo;

                SqlParameter SupplierID = cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = prr.SupplierID;

                SqlParameter TotalItem = cmd.Parameters.Add("@TotalItem", SqlDbType.Int);
                TotalItem.Direction = ParameterDirection.Input;
                TotalItem.Value = Convert.ToInt32(prr.TotalItem);

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = null;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                //Start:inasert grr item information
                if (prr.Items.Count > 0)
                {                
                  foreach (var prrItem in prr.Items)
                    {
                        if (!TenderDetailManagement((Product)prrItem.Value, prr.PrrNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                //End:inasert grr item information  

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
                prr = null;
            }
            return true;
        }

        private Boolean TenderDetailManagement(Product prrItem, string prrNo, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("TenderDetailManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = prrItem.PID;

                SqlParameter PTId = cmd.Parameters.Add("@PTId", SqlDbType.BigInt);
                PTId.Direction = ParameterDirection.Input;
                PTId.Value = prrItem.PTDId;

                SqlParameter OrderNo = cmd.Parameters.Add("@PRDetID", SqlDbType.BigInt);
                OrderNo.Direction = ParameterDirection.Input;
                OrderNo.Value = prrItem.ReqPID;

                SqlParameter Ordered = cmd.Parameters.Add("@Rate", SqlDbType.Decimal);
                Ordered.Direction = ParameterDirection.Input;
                Ordered.Value = prrItem.UnitPrice;

                SqlParameter QtyAftInspection = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 350);
                QtyAftInspection.Direction = ParameterDirection.Input;
                QtyAftInspection.Value = prrItem.Remarks;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = null;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prrItem.Condition;

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
                prrItem = null;
            }
            return true;
        }

        //manage Purchase Order(insert, update, delete)
        public Boolean TenderSchedulePrintManagement(Requisition requisition)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("TenderSchedulePrintManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PurOrdID = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = requisition.PrrId;

                SqlParameter PurchaseRef = cmd.Parameters.Add("@TenderRef", SqlDbType.VarChar, 250);
                PurchaseRef.Direction = ParameterDirection.Input;
                PurchaseRef.Value = requisition.TenderReferecne;

                SqlParameter TermsCondition = cmd.Parameters.Add("@TermsCondition", SqlDbType.Text);
                TermsCondition.Direction = ParameterDirection.Input;
                TermsCondition.Value = requisition.TermsConditions;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = requisition.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
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
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                requisition = null;
            }
            return true;
        }

        public Boolean TermsConditionsManagement(Requisition requisition)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("TermsConditionsManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter TermCID = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                TermCID.Direction = ParameterDirection.Input;
               // TenderID.Value = prr.PrrId;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 1000);
                Description.Direction = ParameterDirection.Input;
                //Description.Value = prr.PrrNo;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                //Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
                
                //End:inasert order information 

                //Start:inasert grr item information
                //if (requisition.TenderTerms.Count> 0)
                //{
                    foreach (var entry in requisition.TenderTerms)
                    {
                        TermsCondition terms = (TermsCondition)entry.Value;

                        TermCID.Value = Convert.ToInt64((terms.ID == null ? "0" : terms.ID.ToString().Trim()));
                        Description.Value = terms.Description.Trim();
                        Status.Value = (terms.Status == null ? "" : terms.Status.Trim());
                        Condition.Value = terms.Condition.Trim();

                        cmd.ExecuteNonQuery();
                        if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                //}
                //End:inasert grr item information  

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
                requisition = null;
            }
            return true;
        }

        public Boolean TenderApprovalManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("PrrManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prr.PrrNo;

                SqlParameter TotalItem = cmd.Parameters.Add("@TotalItem", SqlDbType.Decimal);
                TotalItem.Direction = ParameterDirection.Input;
                TotalItem.Value = prr.TotalItem;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start : Update Purchase requisition information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End : Update Purchase requisition information 


                if (prr.Items.Count > 0)
                {
                    foreach (var prrItem in prr.Items)
                    {
                        if (!TenderDetailManagement((Product)prrItem.Value, prr.PrrNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }

                transaction.Commit();
            }
            catch
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                prr = null;
            }
            return true;
        }

        public DataTable TermsConditionsList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetTermsConditionsList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable PurchaseTender(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseTenderList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable TenderReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetTenderReport";
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

        public DataTable PurchaseRequisitionReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseRequisitionReport";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
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
        #endregion

        #region Purchase Order

        //manage Purchase Order(insert, update, delete)
        public Boolean PurOrdManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("PurOrdManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = prr.PurOrdID;

                SqlParameter PurOrdNo = cmd.Parameters.Add("@PurOrdNo", SqlDbType.VarChar, 100);
                PurOrdNo.Direction = ParameterDirection.Input;
                PurOrdNo.Value = prr.PurOrdNo;

                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                PReqNo.Value = prr.PrrNo;

                SqlParameter CepNO = cmd.Parameters.Add("@CepNO", SqlDbType.VarChar, 100);
                CepNO.Direction = ParameterDirection.Input;
                CepNO.Value = prr.CepNO;

                SqlParameter SupplierID = cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = prr.SupplierID;

                SqlParameter PurOrdDate = cmd.Parameters.Add("@PurOrdDate", SqlDbType.DateTime);
                PurOrdDate.Direction = ParameterDirection.Input;
                PurOrdDate.Value = prr.PurOrdDate;

                SqlParameter DeliveryDate = cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                DeliveryDate.Direction = ParameterDirection.Input;
                DeliveryDate.Value = prr.DeliveryDate;

                SqlParameter TotalItem = cmd.Parameters.Add("@TotalItem", SqlDbType.Decimal);
                TotalItem.Direction = ParameterDirection.Input;
                TotalItem.Value = prr.TotalItem;

                SqlParameter Vat = cmd.Parameters.Add("@Vat", SqlDbType.Decimal);
                Vat.Direction = ParameterDirection.Input;
                Vat.Value = prr.Vat;

                SqlParameter IsVatIncluded = cmd.Parameters.Add("@isVatIncluded", SqlDbType.VarChar,10);
                IsVatIncluded.Direction = ParameterDirection.Input;
                IsVatIncluded.Value = prr.VatIncluded;

                SqlParameter IsEmargency = cmd.Parameters.Add("@isEmargency", SqlDbType.VarChar, 10);
                IsEmargency.Direction = ParameterDirection.Input;
                IsEmargency.Value = prr.IsEmargency;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                //Start:inasert grr item information
                if (prr.Products.Count > 0)
                {
                    foreach (var prrItem in prr.Products)
                    {
                        if (!PurOrdDetailManagement(prrItem, prr.PrrNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                //End:inasert grr item information  

                //Start: Change the Purchase Requisition Status
                if (!PurchaseRequisitonStatusManagement(prr.PrrNo, "1", sqlConnection, transaction))
                {
                    transaction.Rollback();
                    return false;
                }
                //End : Change the Purchase Requisiton Status

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
                prr = null;
            }
            return true;
        }

        private Boolean PurOrdDetailManagement(Product prrItem, string purOrdNo, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("PurOrdDetailManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = prrItem.PID;

                SqlParameter ReqPSlNo = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                ReqPSlNo.Direction = ParameterDirection.Input;
                ReqPSlNo.Value = prrItem.PurOrdID;

                SqlParameter PurOrdNo = cmd.Parameters.Add("@PTDId", SqlDbType.BigInt);
                PurOrdNo.Direction = ParameterDirection.Input;
                PurOrdNo.Value = prrItem.PTDId;

                SqlParameter PRDetID = cmd.Parameters.Add("@PRDetID", SqlDbType.BigInt);
                PRDetID.Direction = ParameterDirection.Input;
                PRDetID.Value = prrItem.PRDetID;

                SqlParameter OrderNo = cmd.Parameters.Add("@GoodsID", SqlDbType.Int);
                OrderNo.Direction = ParameterDirection.Input;
                OrderNo.Value = prrItem.PCode;
                
                SqlParameter QtyBfrInspection = cmd.Parameters.Add("@Required", SqlDbType.Decimal);
                QtyBfrInspection.Direction = ParameterDirection.Input;
                QtyBfrInspection.Value = prrItem.ReqQty;

                SqlParameter Ordered = cmd.Parameters.Add("@OrderedQty", SqlDbType.Decimal);
                Ordered.Direction = ParameterDirection.Input;
                Ordered.Value = prrItem.IssueQty;

                SqlParameter UnitPrice = cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
                UnitPrice.Direction = ParameterDirection.Input;
                UnitPrice.Value = prrItem.UnitPrice;

                SqlParameter Vat = cmd.Parameters.Add("@Vat", SqlDbType.TinyInt);
                Vat.Direction = ParameterDirection.Input;
                Vat.Value = prrItem.Vat;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prrItem.Condition;

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
                prrItem = null;
            }
            return true;
        }

        private bool PurchaseRequisitonStatusManagement(string ReqNO, String Condition,SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("PrrStatusManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = ReqNO ;             

                SqlParameter condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                condition.Direction = ParameterDirection.Input;
                condition.Value = Condition;

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
            }
            return true;        

        }

        //manage Emargency Purchase Order(insert, update, delete)
        public Boolean EmargencyPurchaseOrdManagement(Requisition prr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("EmrgPurchaseOrdManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = prr.PurOrdID;

                SqlParameter PurOrdNo = cmd.Parameters.Add("@PurOrdNo", SqlDbType.VarChar, 100);
                PurOrdNo.Direction = ParameterDirection.Input;
                PurOrdNo.Value = prr.PurOrdNo;

                SqlParameter PReqNo = cmd.Parameters.Add("@PReqNo", SqlDbType.BigInt);
                PReqNo.Direction = ParameterDirection.Input;
                //PReqNo.Value = prr.PrrNo;

                SqlParameter CepNO = cmd.Parameters.Add("@CepNO", SqlDbType.VarChar, 100);
                CepNO.Direction = ParameterDirection.Input;
                CepNO.Value = prr.CepNO;

                SqlParameter SCatID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                SCatID.Direction = ParameterDirection.Input;
                SCatID.Value = prr.SCategory;

                SqlParameter SupplierID = cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = prr.SupplierID;

                SqlParameter PurOrdDate = cmd.Parameters.Add("@PurOrdDate", SqlDbType.DateTime);
                PurOrdDate.Direction = ParameterDirection.Input;
                PurOrdDate.Value = prr.PurOrdDate;

                SqlParameter DeliveryDate = cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                DeliveryDate.Direction = ParameterDirection.Input;
                DeliveryDate.Value = prr.DeliveryDate;

                SqlParameter TotalItem = cmd.Parameters.Add("@TotalItem", SqlDbType.Decimal);
                TotalItem.Direction = ParameterDirection.Input;
                TotalItem.Value = prr.TotalItem;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = prr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Emargency Purchase order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                //End:inasert order information 

                //Start:inasert order item information
                if (prr.Items.Count > 0)
                {
                    foreach (var prrItem in prr.Items)
                    {
                        if (!PurOrdDetailManagement((Product)prrItem.Value, prr.PrrNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                //End:inasert order item information  

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
                prr = null;
            }
            return true;
        }

        //manage Purchase Order(insert, update, delete)
        public Boolean PurOrdPrintManagement(Order purchaseOrder)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("PurOrdPrintManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = purchaseOrder.PurOrdID;


                SqlParameter ReqRaisedBy = cmd.Parameters.Add("@ReqRaisedBy", SqlDbType.VarChar, 250);
                ReqRaisedBy.Direction = ParameterDirection.Input;
                ReqRaisedBy.Value = purchaseOrder.ReqRaisedBy;

                SqlParameter EndUser = cmd.Parameters.Add("@EndUser", SqlDbType.VarChar, 250);
                EndUser.Direction = ParameterDirection.Input;
                EndUser.Value = purchaseOrder.EndUser;

                SqlParameter PurchaseRef = cmd.Parameters.Add("@PurchaseRef", SqlDbType.VarChar, 100);
                PurchaseRef.Direction = ParameterDirection.Input;
                PurchaseRef.Value = purchaseOrder.PurchaseRef;

                SqlParameter AdvanceAmt = cmd.Parameters.Add("@AdvanceAmt", SqlDbType.Decimal);
                AdvanceAmt.Direction = ParameterDirection.Input;
                AdvanceAmt.Value = purchaseOrder.AdvanceAmt;

                SqlParameter Discount = cmd.Parameters.Add("@Discount", SqlDbType.Decimal);
                Discount.Direction = ParameterDirection.Input;
                Discount.Value = purchaseOrder.Discount;

                SqlParameter TermsCondition = cmd.Parameters.Add("@TermsCondition", SqlDbType.VarChar, 1000);
                TermsCondition.Direction = ParameterDirection.Input;
                TermsCondition.Value = purchaseOrder.TermsAndConditions;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = purchaseOrder.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert Purchase requisition information                
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
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                purchaseOrder = null;
            }
            return true;
        }

        public DataTable PurchaseOrder(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseOrderList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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


        //Return the purchase Order Type
        public DataTable PurchaseOrderType(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPurchaseOrderType";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable PurchaseOrderReport(string QueryString, string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = QueryString;
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

        public DataTable CashPruchaseOrderList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetCashPruchaseOrderList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 100);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = condition;

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

        public DataTable EmargencyPurchaseOrderReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetEmargencyOrderReport";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
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

        public DataTable PruchaseOrderProcessList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseOrderProcessList";
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

        public DataTable PruchaseOrderPrint(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPurchaseOrderPrint";
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

        //Return the purchase order Confirmed and veryfied by FSD 
        public DataTable PurchaseOrderPaymentList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseOrderPaymentList";
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

        //Return the purchase order Confirmed and veryfied by FSD 
        public DataTable PurchaseOrderPaymentReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPruchaseOrderPaymentReport";
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

        //Return the purchase order list panding for accounts payment processing
        public DataTable AccountsPurchaseOrderPaymentList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetAccountsOrderPaymentList";
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
        #endregion
    }
}
