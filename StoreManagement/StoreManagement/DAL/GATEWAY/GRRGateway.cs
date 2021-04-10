using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class GRRGateway
    {
        #region GRR Management

        //manage Goods Receive Inspection(insert, update, delete)
        public Boolean GrrIManagement(GRR grr)
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
                GRRID.Value = grr.GrrId;

                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = grr.PurchseOrdID;

                SqlParameter Challans = cmd.Parameters.Add("@Challans", SqlDbType.VarChar, 500);
                Challans.Direction = ParameterDirection.Input;
                Challans.Value = grr.InvoiceNo;

                SqlParameter Acceptance = cmd.Parameters.Add("@Acceptance", SqlDbType.SmallInt);
                Acceptance.Direction = ParameterDirection.Input;
                Acceptance.Value = Convert.ToInt16(grr.Acceptance);

                SqlParameter Comments = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
                Comments.Direction = ParameterDirection.Input;
                Comments.Value = grr.Comments;

                SqlParameter DeptUID = cmd.Parameters.Add("@DeptUID", SqlDbType.Int);
                DeptUID.Direction = ParameterDirection.Input;
                DeptUID.Value = Convert.ToInt32(grr.DeptUID);

                SqlParameter TotalAmt = cmd.Parameters.Add("@TotalAmt", SqlDbType.Decimal);
                TotalAmt.Direction = ParameterDirection.Input;
                TotalAmt.Value = grr.TotalPay;

                SqlParameter TotalVat = cmd.Parameters.Add("@TotalVat", SqlDbType.Decimal);
                TotalVat.Direction = ParameterDirection.Input;
                TotalVat.Value = grr.TotalVat;

                SqlParameter InspectionDate = cmd.Parameters.Add("@InspectionDate", SqlDbType.DateTime);
                InspectionDate.Direction = ParameterDirection.Input;
                InspectionDate.Value = grr.InspectionDate;

                SqlParameter PRecvFromHRD = cmd.Parameters.Add("@PRecvFromHRD", SqlDbType.DateTime);
                PRecvFromHRD.Direction = ParameterDirection.Input;
                PRecvFromHRD.Value = grr.PRecvFromHRD;

                SqlParameter Note = cmd.Parameters.Add("@NoteID", SqlDbType.Int);
                Note.Direction = ParameterDirection.Input;
                Note.Value = grr.Note;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = grr.Status;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = grr.Condition;               

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

                //Start:inasert grr item information
                if (grr.Products.Count > 0)
                {
                    foreach (var grrItem in grr.Products)
                    {
                        if (!GrIDetailManagement(grrItem, sqlConnection, transaction))
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
                grr = null;
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

                SqlParameter QtyBfrInspection = cmd.Parameters.Add("@PhysFound", SqlDbType.VarChar,500);
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

        #region GRR Management (for temporary purpose have to delete after Purchase and FSD Module integration)

        public Boolean GrrManagement(GRR grr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("GrrManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GRRID = cmd.Parameters.Add("@GRRID", SqlDbType.BigInt);
                GRRID.Direction = ParameterDirection.Input;
                GRRID.Value = grr.GrrId;

                SqlParameter PurOrdID = cmd.Parameters.Add("@PurOrdID", SqlDbType.BigInt);
                PurOrdID.Direction = ParameterDirection.Input;
                PurOrdID.Value = grr.PurchseOrdID;

                SqlParameter ManufacID = cmd.Parameters.Add("@ManufacID", SqlDbType.Int);
                ManufacID.Direction = ParameterDirection.Input;
                ManufacID.Value = grr.ManufacturerID;

               SqlParameter GrrDate = cmd.Parameters.Add("@GrrDate", SqlDbType.DateTime);
                GrrDate.Direction = ParameterDirection.Input;
                GrrDate.Value = grr.GrrDate;

                SqlParameter ChallanNo = cmd.Parameters.Add("@ChallanNo", SqlDbType.VarChar, 100);
                ChallanNo.Direction = ParameterDirection.Input;
                ChallanNo.Value = grr.InvoiceNo;

                SqlParameter ChallanDate = cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime);
                ChallanDate.Direction = ParameterDirection.Input;
                ChallanDate.Value = grr.InvoiceDate;

                SqlParameter CostCntCode = cmd.Parameters.Add("@CostCntCode", SqlDbType.VarChar, 100);
                CostCntCode.Direction = ParameterDirection.Input;
                CostCntCode.Value = grr.CostCenterCode;
                
                SqlParameter CheckedBy = cmd.Parameters.Add("@CheckedBy", SqlDbType.VarChar, 10);
                CheckedBy.Direction = ParameterDirection.Input;
                CheckedBy.Value = LoginUser.UserID;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = grr.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim().ToUpper()== "Er")
                {
                    transaction.Rollback();
                    return false;
                }
                Common.GRRNo = cmd.Parameters["@Flag"].Value.ToString().Trim();
                //End:inasert order information 

                //Start:inasert grr item information

                foreach (var grrItem in grr.Items)
                {
                    if (!GrrDetailManagement((Product)grrItem.Value, sqlConnection, transaction))
                    {
                        transaction.Rollback();
                        return false;
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
                grr = null;
            }
            return true;
        }

        private Boolean GrrDetailManagement(Product grIItem, SqlConnection connection, SqlTransaction transaction)
        {
            SqlConnection sqlConnection = connection;
            SqlCommand cmd = new SqlCommand("GrrDetailManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter SlNO = cmd.Parameters.Add("@SlNO", SqlDbType.BigInt);
                SlNO.Direction = ParameterDirection.Input;
                SlNO.Value = grIItem.PID;

                SqlParameter ChallanItem = cmd.Parameters.Add("@GoodsID", SqlDbType.BigInt);
                ChallanItem.Direction = ParameterDirection.Input;
                ChallanItem.Value = Convert.ToInt64(grIItem.PCode);

                SqlParameter Ordered = cmd.Parameters.Add("@Ordered", SqlDbType.Decimal);
                Ordered.Direction = ParameterDirection.Input;
                Ordered.Value = grIItem.ReqQty;

                SqlParameter QtyBfrInspection = cmd.Parameters.Add("@QtyBfrInspection", SqlDbType.Decimal);
                QtyBfrInspection.Direction = ParameterDirection.Input;
                QtyBfrInspection.Value = grIItem.QtyBoforeInspec;

                SqlParameter QtyAftInspection = cmd.Parameters.Add("@QtyAftInspection", SqlDbType.Decimal);
                QtyAftInspection.Direction = ParameterDirection.Input;
                QtyAftInspection.Value = grIItem.QtyAfterInspec;

                SqlParameter Rate = cmd.Parameters.Add("@Rate", SqlDbType.Decimal);
                Rate.Direction = ParameterDirection.Input;
                Rate.Value = grIItem.UnitPrice;

                SqlParameter Remarks = cmd.Parameters.Add("@Remark", SqlDbType.VarChar,500);
                Remarks.Direction = ParameterDirection.Input;
                Remarks.Value = grIItem.Remarks;

                SqlParameter POrdDetID = cmd.Parameters.Add("@POrdDetID", SqlDbType.BigInt);
                POrdDetID.Direction = ParameterDirection.Input;
                POrdDetID.Value = grIItem.ReqPID;

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
        #endregion

        //Send the GRR in stock
        public Boolean GrrToStock(GRR grr)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SendtoStock", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GRRID = cmd.Parameters.Add("@GRRID", SqlDbType.BigInt);
                GRRID.Direction = ParameterDirection.Input;
                GRRID.Value = grr.GrrId;

                SqlParameter CostCntCode = cmd.Parameters.Add("@CostCntCode", SqlDbType.VarChar, 100);
                CostCntCode.Direction = ParameterDirection.Input;
                CostCntCode.Value = grr.CostCenterCode;

                SqlParameter UnitID = cmd.Parameters.Add("@UnitID", SqlDbType.SmallInt);
                UnitID.Direction = ParameterDirection.Input;
                UnitID.Value = grr.UnitID;  

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
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                grr = null;
            }
            return true;
        }

        //get all order list
        public DataTable OrderInspectionList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetOrderInspectionList";
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

        //get all order list for FSD search
        public DataTable OrderInspectionReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetOrderInspectionReport";
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

        //get all GRR Certificate 
        public DataTable FSDCertificate(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetFSDCertificate";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 10);
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

        //get all company unit list
        public DataTable GrrList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetGrrList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 10);
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

        //get all company unit list
        public DataTable GrrReport(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetGrrReport";
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
