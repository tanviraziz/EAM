using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class StoreGateway
    {
        #region Stock Management

        //Manage the stock closing
        public Boolean ManageMonthlyClosing(string yymm)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ManageMonthlyClosing", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = yymm.Trim();

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();                
            }
            return true;
        }

        public DataTable GetStockClosingMonth(string choice)
        {
            DataTable dt = new DataTable();
            string queryString = "GetStockClosingMonth";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

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

        //get the current stock list
        public DataTable StockLIst(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetStockList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@condition", SqlDbType.VarChar, 300);
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

        public DataTable StoreDeshBoardData(string choice1, string choice2, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetStoreDeshBoardData";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice1 = cmd.Parameters.Add("@choice1", SqlDbType.VarChar, 10);
                Choice1.Direction = ParameterDirection.Input;
                Choice1.Value = choice1;

                SqlParameter Choice2 = cmd.Parameters.Add("@choice2", SqlDbType.VarChar, 10);
                Choice2.Direction = ParameterDirection.Input;
                Choice2.Value = choice2;

                SqlParameter Condition1 = cmd.Parameters.Add("@condition1", SqlDbType.VarChar, 100);
                Condition1.Direction = ParameterDirection.Input;
                Condition1.Value = condition1;

                SqlParameter Condition2 = cmd.Parameters.Add("@condition2", SqlDbType.VarChar, 100);
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

        public DataTable PendingGrrToPosting(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetPendingGrrToPostingList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice1 = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice1.Direction = ParameterDirection.Input;
                Choice1.Value = choice;

                SqlParameter Condition2 = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
                Condition2.Direction = ParameterDirection.Input;
                Condition2.Value = condition;

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
