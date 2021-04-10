using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class SRRGateway
    {
        #region SRR Management

        //manage Store requisition(insert, update, delete)
        public Boolean SrrManagement(SRR srr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SrrManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SRRID = cmd.Parameters.Add("@SRRID", SqlDbType.BigInt);
                SRRID.Direction = ParameterDirection.Input;
                SRRID.Value = srr.SRRID;

                SqlParameter SRRDate = cmd.Parameters.Add("@SRRDate", SqlDbType.DateTime);
                SRRDate.Direction = ParameterDirection.Input;
                SRRDate.Value = (srr.SRRDate == null ? DateTime.Now : srr.SRRDate);

                SqlParameter DeptUID = cmd.Parameters.Add("@DeptUID", SqlDbType.Int);
                DeptUID.Direction = ParameterDirection.Input;
                DeptUID.Value = srr.DeptUID;

                SqlParameter Purpose = cmd.Parameters.Add("@Purpose", SqlDbType.VarChar, 250);
                Purpose.Direction = ParameterDirection.Input;
                Purpose.Value = srr.Purpose;

                SqlParameter RequisitionBy = cmd.Parameters.Add("@RequisitionBy", SqlDbType.VarChar, 10);
                RequisitionBy.Direction = ParameterDirection.Input;
                RequisitionBy.Value = LoginUser.UserID;

                SqlParameter IssuedBy = cmd.Parameters.Add("@IssuedBy", SqlDbType.VarChar, 10);
                IssuedBy.Direction = ParameterDirection.Input;
                IssuedBy.Value = LoginUser.UserID;

                SqlParameter ReceivedBy = cmd.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 10);
                ReceivedBy.Direction = ParameterDirection.Input;
                ReceivedBy.Value = LoginUser.UserID;

                SqlParameter ApprovedBy = cmd.Parameters.Add("@ApprovedBy", SqlDbType.VarChar, 10);
                ApprovedBy.Direction = ParameterDirection.Input;
                ApprovedBy.Value = LoginUser.UserID;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = srr.Status;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = srr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "Er")
                {
                    transaction.Rollback();
                    return false;
                }
                Common.ReqNo = cmd.Parameters["@Flag"].Value.ToString().Trim();
                //if (srr.Products.Count > 0)
                //{
                    //foreach (var srrItem in srr.Products)
                    //{
                    foreach (var entry in srr.Items)
                    {
                        if (!SrrDetailManagement((Product)entry.Value,Common.ReqNo, sqlConnection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                //}

                
                transaction.Commit();
            }
            catch
            {
                //return e.Message;
                Common.ReqNo = null;
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                srr = null;
            }
            return true;
        }

        public Boolean SrrDetailManagement(Product item,string srrNo, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("SrrDetailManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = item.PID;

                SqlParameter SRRID = cmd.Parameters.Add("@SRRID", SqlDbType.BigInt);
                SRRID.Direction = ParameterDirection.Input;
                SRRID.Value = srrNo;

                SqlParameter GoodsID = cmd.Parameters.Add("@GoodsID", SqlDbType.Int);
                GoodsID.Direction = ParameterDirection.Input;
                GoodsID.Value = item.PCode;

                SqlParameter SCatID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                SCatID.Direction = ParameterDirection.Input;
                SCatID.Value = item.StationaryID;

                SqlParameter Required = cmd.Parameters.Add("@Required", SqlDbType.Decimal);
                Required.Direction = ParameterDirection.Input;
                Required.Value = item.ReqQty;

                SqlParameter IssueQty = cmd.Parameters.Add("@IssueQty", SqlDbType.Decimal);
                IssueQty.Direction = ParameterDirection.Input;
                IssueQty.Value = item.IssueQty;

                SqlParameter Rate = cmd.Parameters.Add("@Rate", SqlDbType.Decimal);
                Rate.Direction = ParameterDirection.Input;
                Rate.Value = item.UnitPrice;

                SqlParameter Remarks = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500);
                Remarks.Direction = ParameterDirection.Input;
                Remarks.Value = item.Remarks;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = item.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "Er")
                {
                    return false;
                }

                string SrrDetailID = cmd.Parameters["@Flag"].Value.ToString();

                if(item.IssuedGRR.ContainsKey(item.PCode.ToString()))
                {
                    foreach (var entry in item.IssuedGRR[item.PCode])
                    {
                        if (!SRRIssueDetailFromGrr((ItemIssueFromGRR)entry.Value,srrNo, SrrDetailID, connection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                //End:inasert order information  
            }
            catch
            {
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();                
                item = null;
            }
            return true;
        }

        public Boolean SRRIssueDetailFromGrr(ItemIssueFromGRR item, string srrNo, string SrrDetailID, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("SRRIssueDetailFromGrr", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SrrFromGrrID", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = item.SrrFromGrrID;

                SqlParameter SRRID = cmd.Parameters.Add("@GRRID", SqlDbType.BigInt);
                SRRID.Direction = ParameterDirection.Input;
                SRRID.Value = item.GRRId;

                SqlParameter GrrDetailID = cmd.Parameters.Add("@GrrDetailID", SqlDbType.BigInt);
                GrrDetailID.Direction = ParameterDirection.Input;
                GrrDetailID.Value = item.GrrDetailID;

                SqlParameter SCatID = cmd.Parameters.Add("@SRRID", SqlDbType.BigInt);
                SCatID.Direction = ParameterDirection.Input;
                SCatID.Value = srrNo;

                SqlParameter Required = cmd.Parameters.Add("@SrrDetailID", SqlDbType.Decimal);
                Required.Direction = ParameterDirection.Input;
                Required.Value = SrrDetailID;

                SqlParameter GoodsID = cmd.Parameters.Add("@GoodsID", SqlDbType.BigInt);
                GoodsID.Direction = ParameterDirection.Input;
                GoodsID.Value = item.GoodsID;

                SqlParameter IssueQty = cmd.Parameters.Add("@IssueQty", SqlDbType.Decimal);
                IssueQty.Direction = ParameterDirection.Input;
                IssueQty.Value = item.IssuedQty;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = item.Condition;

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
                //return e.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                item = null;
            }
            return true;
        }

        

        //get all SRR list
        public DataTable SrrList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetSrrList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition1", SqlDbType.VarChar, 10);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition2", SqlDbType.VarChar, 10);
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

        //get all user SRR list
        public DataTable UserSrrList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetUserSrrList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition1", SqlDbType.VarChar, 10);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition2", SqlDbType.VarChar, 10);
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

        //get all Authority SRR list
        public DataTable AuthoritySrrList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetAuthoritySrrList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition1 = cmd.Parameters.Add("@Condition1", SqlDbType.VarChar, 10);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition2", SqlDbType.VarChar, 10);
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

        //get all items current stock from GRR list
        public DataTable ItemGRRList(string choice, string condition1,string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetItemGrrList";
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
