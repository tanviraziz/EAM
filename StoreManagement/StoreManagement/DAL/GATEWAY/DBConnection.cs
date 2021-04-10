using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreManagement.DAL.GATEWAY
{
    class DBConnection
    {
        private SqlConnection sqlConn = null;

        public DBConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["cnnString"];
                sqlConn = new SqlConnection(connectionString);
            }
            catch (Exception exceptionObj)
            {
                throw exceptionObj;
            }
        }

        public SqlConnection GetConnection
        {
            get
            {
                return sqlConn;
            }
        }
    }
}
