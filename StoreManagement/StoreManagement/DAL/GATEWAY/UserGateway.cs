using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class UserGateway : IDisposable
    {
        #region User Management

        public bool UserManagement(User user)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("UserManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter UID = cmd.Parameters.Add("@UID", SqlDbType.Int);
                UID.Direction = ParameterDirection.Input;
                UID.Value = user.UserID;

                SqlParameter EmpID = cmd.Parameters.Add("@EmpID", SqlDbType.VarChar, 6);
                EmpID.Direction = ParameterDirection.Input;
                EmpID.Value = user.EmpCode;

                SqlParameter WindowsID = cmd.Parameters.Add("@WindowsID", SqlDbType.VarChar, 50);
                WindowsID.Direction = ParameterDirection.Input;
                WindowsID.Value = user.WindowsID;

                SqlParameter password = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                password.Direction = ParameterDirection.Input;
                password.Value = user.Password;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
                Description.Direction = ParameterDirection.Input;
                Description.Value = user.Description;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                Status.Value = user.Status;

                SqlParameter choice = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                choice.Direction = ParameterDirection.Input;
                choice.Value = user.Condition;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                if (user.Condition.Trim() == "5")
                {
                    LoginUser.EntryLog = cmd.Parameters["@Flag"].Value.ToString().Trim();
                }
                
                transaction.Commit();
                return true;

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
                user = null;
            }
        }

        public Boolean UserSettingsManagement(User user)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("UserSettingsManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter UID = cmd.Parameters.Add("@UID", SqlDbType.Int);
                UID.Direction = ParameterDirection.Input;
                UID.Value = user.UserID;

                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                

                SqlParameter RuleID = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
                RuleID.Direction = ParameterDirection.Input;
                

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBY", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                if (user.Roles.Count > 0)
                {
                    foreach (var entry in user.Roles)
                    {
                        Role role = (Role)entry.Value;
                        SlNo.Value = role.SlNo;
                        RuleID.Value = role.ID;
                        Condition.Value = role.Condition;

                        cmd.ExecuteNonQuery();
                        if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                        {
                            transaction.Rollback();
                            return false;
                        }                        
                    }
                }

                transaction.Commit();
                return true;
                //End:inasert order information  
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
                user = null;
            }
        }

        public bool UserPasswordManagement(User user)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("UserManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter UID = cmd.Parameters.Add("@UID", SqlDbType.BigInt);
                UID.Direction = ParameterDirection.Input;
                UID.Value = user.UserID;

                SqlParameter password = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                password.Direction = ParameterDirection.Input;
                password.Value = user.Password;

                SqlParameter choice = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                choice.Direction = ParameterDirection.Input;
                choice.Value = user.Condition;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }
                
                transaction.Commit();
                return true;

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
                user = null;
            }
        }

        //Return the software Users, Roles, Task, Menu list
        public DataTable UserMenuList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetUsersRolesTasksList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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
       
        #endregion

        #region get the user list

        public DataTable UserList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetUserList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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

        #endregion
        #region get the user list

        public DataTable EmployeeInfoFromPIS(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetEmployeeInfoFromPIS";
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

        #endregion

        #region Inspector Management
        public bool InspectorManagement(User user)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("InspectorManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = user.ID;

                SqlParameter UID = cmd.Parameters.Add("@firstInspector", SqlDbType.VarChar, 6);
                UID.Direction = ParameterDirection.Input;
                UID.Value = user.EmpCode;

                SqlParameter EmpID = cmd.Parameters.Add("@secondtInspector", SqlDbType.VarChar, 6);
                EmpID.Direction = ParameterDirection.Input;
                EmpID.Value = user.EmpCode;

                SqlParameter WindowsID = cmd.Parameters.Add("@checkedBy", SqlDbType.VarChar, 6);
                WindowsID.Direction = ParameterDirection.Input;
                WindowsID.Value = user.EmpCode;

                SqlParameter Authority = cmd.Parameters.Add("@Authority", SqlDbType.VarChar, 6);
                Authority.Direction = ParameterDirection.Input;
                Authority.Value = user.EmpCode;

                SqlParameter choice = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                choice.Direction = ParameterDirection.Input;
                choice.Value = user.Condition;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;

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
                user = null;
            }
        }

        public DataTable InspectorList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetInspectorList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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
        #endregion

        #region Menu Management

        #region Parent Menu Management

        public bool ParentMenuManagement(Task parentMenu)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ParentMenuManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
               SqlParameter ParMenuID = cmd.Parameters.Add("@ParMenuID", SqlDbType.Int);
                ParMenuID.Direction = ParameterDirection.Input;
                ParMenuID.Value = parentMenu.ParMenuID;

                SqlParameter ShortCode = cmd.Parameters.Add("@ShortCode", SqlDbType.VarChar, 100);
                ShortCode.Direction = ParameterDirection.Input;
                ShortCode.Value = parentMenu.ShortCode;

                SqlParameter ViewName = cmd.Parameters.Add("@ViewName", SqlDbType.VarChar, 100);
                ViewName.Direction = ParameterDirection.Input;
                ViewName.Value = parentMenu.ViewName;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Description.Direction = ParameterDirection.Input;
                Description.Value = parentMenu.Description;                               

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter choice = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                choice.Direction = ParameterDirection.Input;
                choice.Value = parentMenu.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
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
                parentMenu = null;
            }
        }

        //Return the software Master Menu list
        public DataTable ParentMenuList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetParentMenuList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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
        #endregion

        #region View Management

        //Manage the task/view insert,update,delete
        public bool TaskManagement(Task view)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("TaskViewManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter TaskID = cmd.Parameters.Add("@TaskID", SqlDbType.Int);
                TaskID.Direction = ParameterDirection.Input;
                TaskID.Value = view.ID;

                SqlParameter ParMenuID = cmd.Parameters.Add("@ParMenuID", SqlDbType.Int);
                ParMenuID.Direction = ParameterDirection.Input;
                ParMenuID.Value = view.ParMenuID;

                SqlParameter ShortCode = cmd.Parameters.Add("@ShortCode", SqlDbType.VarChar, 100);
                ShortCode.Direction = ParameterDirection.Input;
                ShortCode.Value = view.ShortCode;

                SqlParameter ViewName = cmd.Parameters.Add("@ViewName", SqlDbType.VarChar, 100);
                ViewName.Direction = ParameterDirection.Input;
                ViewName.Value = view.ViewName;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Description.Direction = ParameterDirection.Input;
                Description.Value = view.Description;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter choice = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                choice.Direction = ParameterDirection.Input;
                choice.Value = view.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
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
                view = null;
            }
        }

        //Return the software view list
        public DataTable ViewList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetViewList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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
        #endregion

        #region Role Management

        //Manage the role insert,update,delete
        public bool RoleManagement(Role role)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("RoleManagement", sqlConnection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.Int);
                SlNo.Direction = ParameterDirection.Input;
                SlNo.Value = role.SlNo;

                SqlParameter RoleID = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
                RoleID.Direction = ParameterDirection.Input;
                
                SqlParameter TaskID = cmd.Parameters.Add("@TaskID", SqlDbType.Int);
                TaskID.Direction = ParameterDirection.Input;


                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250);
                Name.Direction = ParameterDirection.Input;
                Name.Value = role.Name;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
                Description.Direction = ParameterDirection.Input;
                Description.Value = role.Description;

                SqlParameter ShortCode = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                ShortCode.Direction = ParameterDirection.Input;
                ShortCode.Value = role.Status;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = role.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    transaction.Rollback();
                    return false;
                }

                if (role.RoleTasks.Count > 0)
                {
                    foreach (var entry in role.RoleTasks)
                    {
                        Task task = (Task)entry.Value;
                        RoleID.Value = task.RoleID;
                        TaskID.Value = task.ID;
                        SlNo.Value = (string.IsNullOrEmpty(task.SlNo) ? null: task.SlNo.Trim());
                        Condition.Value = task.Condition;

                        cmd.ExecuteNonQuery();
                        if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }

                transaction.Commit();
                return true;
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
                role = null;
            }
        }
        //Return the user role list
        public DataTable RoleList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetRoleList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@Choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 100);
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
        #endregion

        
        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }      

        ~UserGateway()
        {
            
        }
        #endregion
    }
}
