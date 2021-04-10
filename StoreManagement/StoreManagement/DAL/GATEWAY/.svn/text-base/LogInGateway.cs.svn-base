using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StoreManagement.DAL.GATEWAY
{
    class LogInGateway
    {
        public DataTable LogInVerification(string userid, string password)
        {
            DataTable dt = new DataTable();
            string queryString = "checkUser";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter userID = cmd.Parameters.Add("@userID", SqlDbType.VarChar, 6);
                userID.Direction = ParameterDirection.Input;
                userID.Value = userid;

                SqlParameter Password = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 6);
                Password.Direction = ParameterDirection.Input;
                Password.Value = password;

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
