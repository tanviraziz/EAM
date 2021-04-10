using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StoreManagement.DAL.DAO;

namespace StoreManagement.DAL.GATEWAY
{
    class MasterSetupGateway
    {
        #region Server Date Time
        //get server date time
        public DataTable ServerDateTime(string choice)
        {
            DataTable dt = new DataTable();
            string queryString = "GetServerDateTime";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
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
        #endregion
        #region Company Management

        //manage company information(insert, update, delete)
        public Boolean CompanyManagement(Company company)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ComapanyManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 300);
                Name.Direction = ParameterDirection.Input;
                Name.Value = company.Name;

                SqlParameter Address = cmd.Parameters.Add("@Address", SqlDbType.VarChar, 500);
                Address.Direction = ParameterDirection.Input;
                Address.Value = company.Address;

                SqlParameter PhoneNo = cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 100);
                PhoneNo.Direction = ParameterDirection.Input;
                PhoneNo.Value = company.PhoneNo;

                SqlParameter Email = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                Email.Direction = ParameterDirection.Input;
                Email.Value = company.Email;

                SqlParameter Fax = cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 100);
                Fax.Direction = ParameterDirection.Input;
                Fax.Value = company.Fax;

                if (company.Logo != null)
                {
                    SqlParameter prm = new SqlParameter("@Logo", SqlDbType.Image, company.Logo.Length, ParameterDirection.Input, true,
                    0, 0, null, DataRowVersion.Current, company.Logo);

                    cmd.Parameters.Add(prm);
                }                

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = company.Condtion;

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
                company = null;
            }
            return true;
        }

        //get company information
        public DataTable CompanyInformation(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetCompanyInfo";
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

        #region Company Unit Management

        //manage company unit(insert, update, delete)
        public Boolean CompanyUnitManagement(Company department)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("CompanyUnitManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start:order info parameters
                //SqlParameter CostID = cmd.Parameters.Add("@CostID", SqlDbType.SmallInt);
                //CostID.Direction = ParameterDirection.Input;
                //CostID.Value = mapicsCode.CostID;

                //SqlParameter MapicCOde = cmd.Parameters.Add("@MapicCOde", SqlDbType.VarChar, 50);
                //MapicCOde.Direction = ParameterDirection.Input;
                //MapicCOde.Value = mapicsCode.MapicCode;

                //SqlParameter Remarks = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250);
                //Remarks.Direction = ParameterDirection.Input;
                //Remarks.Value = mapicsCode.Remarks;

                //SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                //EntryBy.Direction = ParameterDirection.Input;
                //EntryBy.Value = LoginUser.UserID;

                //SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                //Condition.Direction = ParameterDirection.Input;
                //Condition.Value = mapicsCode.Condtion;

                //SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                //Flag.Direction = ParameterDirection.Output;


                //End:order items parameter                

                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    return false;
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
                sqlConnection.Close();
                sqlConnection.Dispose();
                department = null;
            }
            return true;
        }

        //get all company unit list
        public DataTable CompanyUnitList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetCompanyUnitList";
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

        #region Department Management

        //manage stationary category(insert, update, delete)
        public Boolean DepartmentManagement(Company department)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("DepartmentManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start:order info parameters
                //SqlParameter CostID = cmd.Parameters.Add("@CostID", SqlDbType.SmallInt);
                //CostID.Direction = ParameterDirection.Input;
                //CostID.Value = mapicsCode.CostID;

                //SqlParameter MapicCOde = cmd.Parameters.Add("@MapicCOde", SqlDbType.VarChar, 50);
                //MapicCOde.Direction = ParameterDirection.Input;
                //MapicCOde.Value = mapicsCode.MapicCode;

                //SqlParameter Remarks = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250);
                //Remarks.Direction = ParameterDirection.Input;
                //Remarks.Value = mapicsCode.Remarks;

                //SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                //EntryBy.Direction = ParameterDirection.Input;
                //EntryBy.Value = LoginUser.UserID;

                //SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                //Condition.Direction = ParameterDirection.Input;
                //Condition.Value = mapicsCode.Condtion;

                //SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                //Flag.Direction = ParameterDirection.Output;


                //End:order items parameter                

                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    return false;
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
                sqlConnection.Close();
                sqlConnection.Dispose();
                department = null;
            }
            return true;
        }

        //get all category list
        public DataTable DepartmentList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetCompanyDepartmentList";
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

       #region Mapics Code management

        public Boolean MapicsCodeManagement(CostHead mapicsCode)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("MapicsCodeManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start:order info parameters
                SqlParameter CostID = cmd.Parameters.Add("@CostID", SqlDbType.SmallInt);
                CostID.Direction = ParameterDirection.Input;
                CostID.Value = mapicsCode.CostHeadID;

                SqlParameter MapicCOde = cmd.Parameters.Add("@MapicCOde", SqlDbType.VarChar, 50);
                MapicCOde.Direction = ParameterDirection.Input;
                MapicCOde.Value = mapicsCode.MapicCode;


                SqlParameter Remarks = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250);
                Remarks.Direction = ParameterDirection.Input;
                Remarks.Value = mapicsCode.Remarks;               

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value =mapicsCode.Condtion;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;
                

                //End:order items parameter                

                //Start:inasert order information                
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                {
                    return false;
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
                sqlConnection.Close();
                sqlConnection.Dispose();
                mapicsCode = null;
            }
            return true;
        }

        
        public DataTable MapicsCodeList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetMapicsCodeList";
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

        #endregion

        #region Budget management

        //Manage the departmentm wise budget(insert,update,delete)
        public Boolean BudgetManagement(Budget budget)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("BudgetManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter CostID = cmd.Parameters.Add("@BudgID", SqlDbType.BigInt);
                CostID.Direction = ParameterDirection.Input;


                SqlParameter DeptUID = cmd.Parameters.Add("@DeptUID", SqlDbType.Int);
                DeptUID.Direction = ParameterDirection.Input;
                //DeptUID.Value = ;

                SqlParameter SCatID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                SCatID.Direction = ParameterDirection.Input;
                //SCatID.Value = ;

                SqlParameter Budget = cmd.Parameters.Add("@Budget", SqlDbType.Decimal);
                Budget.Direction = ParameterDirection.Input;
                //Budget.Value = ;

                SqlParameter BudgetYear = cmd.Parameters.Add("@BudgetYear", SqlDbType.VarChar, 50);
                BudgetYear.Direction = ParameterDirection.Input;
                //BudgetYear.Value = ;

                SqlParameter Remarks = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50);
                Remarks.Direction = ParameterDirection.Input;
                //Remarks.Value = ;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                //Condition.Value = budget.Condtion;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                foreach (var entry in budget.CostHeadBudget)
                {
                    CostHead deptBudget = (CostHead)entry.Value;

                    CostID.Value = deptBudget.BudgetID;
                    DeptUID.Value = deptBudget.CostofDeptID;
                    SCatID.Value = deptBudget.CostHeadID;
                    Budget.Value = deptBudget.Budget;
                    BudgetYear.Value = deptBudget.BudgerYear;
                    Remarks.Value = deptBudget.Remarks;
                    Condition.Value = deptBudget.Condtion;

                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                    {
                        transaction.Rollback();
                        return false;
                    } 
                }

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
                budget = null;
            }
            return true;
        }

        //Manage the departmentm wise budget(insert,update,delete)
        public Boolean BudgetClosingManagement(Budget budget)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("BudgetManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = budget.Condition;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                budget = null;
            }
            return true;
        }

        //get all budget list
        public DataTable BudgetList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetBudgetList";
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

        
        //get budget closing year
        public DataTable BudgetClosingYear(string choice)
        {
            DataTable dt = new DataTable();
            string queryString = "GetBudgetClosingYear";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
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

        #endregion        

        #region Item/Material/Product Management

        #region Stationary Category Management

        //manage stationary category(insert, update, delete)
        public Boolean StoreCategoryManagement(Stationary category)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("StoreCategoryManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter CostID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                CostID.Direction = ParameterDirection.Input;
                CostID.Value = category.StationaryID;

                SqlParameter MapicCOde = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
                MapicCOde.Direction = ParameterDirection.Input;
                MapicCOde.Value = category.Name;

                SqlParameter Remarks = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Remarks.Direction = ParameterDirection.Input;
                Remarks.Value = category.Description;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = category.Condtion;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;


                //inasert the categiry information                
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
                transaction.Rollback();
                return false;                
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                category = null;
            }
            return true;
        }

        //get all category list
        public DataTable StationaryCategoryList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetStationaryCategory";
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

        #region Item/Product

        //manage the Product(insert,update,delete)
        public Boolean ItemManagement(Stationary item)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ItemManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter GoodsID = cmd.Parameters.Add("@GoodsID", SqlDbType.BigInt);
                GoodsID.Direction = ParameterDirection.Input;
                GoodsID.Value = item.ItemID;

                SqlParameter ItemID = cmd.Parameters.Add("@ItemID", SqlDbType.SmallInt);
                ItemID.Direction = ParameterDirection.Input;
                ItemID.Value = item.CategoryID;

                SqlParameter ICatID = cmd.Parameters.Add("@ICatID", SqlDbType.SmallInt);
                ICatID.Direction = ParameterDirection.Input;
                ICatID.Value = item.SubCategoryID;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Description.Direction = ParameterDirection.Input;
                Description.Value = item.Description;

                SqlParameter Unit = cmd.Parameters.Add("@Unit", SqlDbType.VarChar,50);
                Unit.Direction = ParameterDirection.Input;
                Unit.Value = item.Unit;

                SqlParameter Rate = cmd.Parameters.Add("@Rate", SqlDbType.Decimal);
                Rate.Direction = ParameterDirection.Input;
                Rate.Value = item.Rate;

                SqlParameter ReOrderLevel = cmd.Parameters.Add("@ReOrderLevel", SqlDbType.Decimal);
                ReOrderLevel.Direction = ParameterDirection.Input;
                ReOrderLevel.Value = item.ReOrderLevel;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = item.Condtion;

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
                transaction.Rollback();
                return false;
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                item = null;
            }
            return true;
        }

        //get all budget list
        public DataTable ItemList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetItemList";
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

        #region Item/Product Category

        //manage the Item category(insert,update,delete)
        public Boolean ItemCategoryManagement(Stationary category)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ItemCategoryManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter ICatID = cmd.Parameters.Add("@ItemID", SqlDbType.SmallInt);
                ICatID.Direction = ParameterDirection.Input;
                ICatID.Value = category.CategoryID;

                SqlParameter ItemID = cmd.Parameters.Add("@SCatID", SqlDbType.SmallInt);
                ItemID.Direction = ParameterDirection.Input;
                ItemID.Value = category.StationaryID;

                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250);
                Name.Direction = ParameterDirection.Input;
                Name.Value = category.Name;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Description.Direction = ParameterDirection.Input;
                Description.Value = category.Description;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = category.Condtion;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                category = null;
            }
            return true;
        }

        //get all Product category
        public DataTable ItemCategoryList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetItemCategoryList";
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

        #region Item/Product Sub Category

        //manage the Product Sub category(insert,update,delete)
        public Boolean ItemSubCategoryManagement(Stationary subCategory)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ItemSubCategoryManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter ICatID = cmd.Parameters.Add("@ICatID", SqlDbType.SmallInt);
                ICatID.Direction = ParameterDirection.Input;
                ICatID.Value = subCategory.SubCategoryID;

                SqlParameter ItemID = cmd.Parameters.Add("@ItemID", SqlDbType.SmallInt);
                ItemID.Direction = ParameterDirection.Input;
                ItemID.Value = subCategory.CategoryID;

                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250);
                Name.Direction = ParameterDirection.Input;
                Name.Value = subCategory.Name;

                SqlParameter Description = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 250);
                Description.Direction = ParameterDirection.Input;
                Description.Value = subCategory.Description;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = subCategory.Condtion;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                subCategory = null;
            }
            return true;
        }

        //get all Dimension list
        public DataTable ItemSubCategoryList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetItemSubCategoryList";
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

        #endregion

        #region Menufacturer Management
        //manage the Manufacturer(insert,update,delete)
        public Boolean MenufacturerManagement(Menufacture manufacturer)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("ManufacturerManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SupplierID = cmd.Parameters.Add("@ManufacID", SqlDbType.SmallInt);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = manufacturer.ManufacturerID;

                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250);
                Name.Direction = ParameterDirection.Input;
                Name.Value = manufacturer.Name;

                SqlParameter ContactPerson = cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 300);
                ContactPerson.Direction = ParameterDirection.Input;
                ContactPerson.Value = manufacturer.ContactPerson;

                SqlParameter Address = cmd.Parameters.Add("@Address", SqlDbType.VarChar, 300);
                Address.Direction = ParameterDirection.Input;
                Address.Value = manufacturer.Address;

                SqlParameter PhoneNo = cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 100);
                PhoneNo.Direction = ParameterDirection.Input;
                PhoneNo.Value = manufacturer.PhoneNo;

                SqlParameter Fax = cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 100);
                Fax.Direction = ParameterDirection.Input;
                Fax.Value = manufacturer.Fax;

                SqlParameter Email = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200);
                Email.Direction = ParameterDirection.Input;
                Email.Value = manufacturer.Email;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = manufacturer.Condition;

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
                manufacturer = null;
            }
            return true;
        }

        //get all budget list
        public DataTable MenufacturerList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetManufacturerList";
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

        #region Supplier Management
        //manage the supplier information(insert,update,delete)
        public Boolean SupplierManagement(Supplier supplier)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SupplierManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SupplierID = cmd.Parameters.Add("@SupplierID", SqlDbType.SmallInt);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = supplier.SupplierID;

                SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250);
                Name.Direction = ParameterDirection.Input;
                Name.Value = supplier.Name;

                SqlParameter ContactPerson = cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 300);
                ContactPerson.Direction = ParameterDirection.Input;
                ContactPerson.Value = supplier.ContactPerson;

                SqlParameter Address = cmd.Parameters.Add("@Address", SqlDbType.VarChar, 300);
                Address.Direction = ParameterDirection.Input;
                Address.Value = supplier.Address;

                SqlParameter PhoneNo = cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 100);
                PhoneNo.Direction = ParameterDirection.Input;
                PhoneNo.Value = supplier.PhoneNo;

                SqlParameter Fax = cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 100);
                Fax.Direction = ParameterDirection.Input;
                Fax.Value = supplier.Fax;

                SqlParameter Email = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200);
                Email.Direction = ParameterDirection.Input;
                Email.Value = supplier.Email;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = supplier.Condition;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                supplier = null;
            }
            return true;
        }

        //get all supplier list
        public DataTable SupplierList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetSupplerList";
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

        #region Supplier Enlistment
        //manage the supplier enlistment information(insert,update,delete)
        public Boolean SupplierEnlistmentManagement(Supplier supplier)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SuplierEnlistmentManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter SlNo = cmd.Parameters.Add("@SlNo", SqlDbType.BigInt);
                SlNo.Direction = ParameterDirection.Input;
                //SlNo.Value = supplier.SupplierID;

                SqlParameter SupplierID = cmd.Parameters.Add("@SupplierID", SqlDbType.SmallInt);
                SupplierID.Direction = ParameterDirection.Input;
                SupplierID.Value = supplier.SupplierID;

                SqlParameter GoodsID = cmd.Parameters.Add("@GoodsID", SqlDbType.BigInt);
                GoodsID.Direction = ParameterDirection.Input;
                //GoodsID.Value = supplier.Name;

                SqlParameter Status = cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                Status.Direction = ParameterDirection.Input;
                //Status.Value = supplier.st;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                //Condition.Value = supplier.Condition;

                SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                Flag.Direction = ParameterDirection.Output;

                foreach (var item in supplier.Items)
                {
                    Product supplierItem = (Product)item.Value;

                    SlNo.Value = supplierItem.PID;
                    GoodsID.Value = supplierItem.PCode;
                    Condition.Value = supplierItem.Condition;
                    //Status.Value = supplierItem.st

                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters["@Flag"].Value.ToString().Trim() == "1")
                    {
                        transaction.Rollback();
                        return false;
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
                supplier = null;
            }
            return true;

        }

        //get all supplier list
        public DataTable SupplierEnlistmentList(string choice, string condition1, string condition2)
        {
            DataTable dt = new DataTable();
            string queryString = "GetSupplerEnlistmentList";
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter Choice = cmd.Parameters.Add("@choice", SqlDbType.VarChar, 10);
                Choice.Direction = ParameterDirection.Input;
                Choice.Value = choice;

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
        #endregion
       

        #region Time Period Management
        //manage the departmentm wise budget(insert,update,delete)
        public Boolean TimePeriodManagement(Supplier supplier)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SupplierManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //SqlParameter CostID = cmd.Parameters.Add("@BudgID", SqlDbType.SmallInt);
                //CostID.Direction = ParameterDirection.Input;
                //CostID.Value = costHeadBudget.CostHeadID;

                //SqlParameter CHofDID = cmd.Parameters.Add("@CHofDID", SqlDbType.Int);
                //CHofDID.Direction = ParameterDirection.Input;
                //CHofDID.Value = costHeadBudget.MapicCode;

                //SqlParameter Budget = cmd.Parameters.Add("@Budget", SqlDbType.Decimal);
                //Budget.Direction = ParameterDirection.Input;
                //Budget.Value = costHeadBudget.Remarks;

                //SqlParameter BudgetYear = cmd.Parameters.Add("@BudgetYear", SqlDbType.VarChar, 50);
                //BudgetYear.Direction = ParameterDirection.Input;
                //BudgetYear.Value = costHeadBudget.BudgerYear;

                //SqlParameter Condition = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                //Condition.Direction = ParameterDirection.Input;
                //Condition.Value = costHeadBudget.Condtion;

                //SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                //Flag.Direction = ParameterDirection.Output;

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
                sqlConnection.Close();
                sqlConnection.Dispose();
                supplier = null;
            }
            return true;
        }

        //get all supplier list
        public DataTable TimePeriodList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetTimePeriod";
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
        #endregion

        
        #region Time Period Management
        //manage the departmentm wise budget(insert,update,delete)
        public Boolean InspectionAcceptanceManagement(Object obj)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SupplierManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //SqlParameter CostID = cmd.Parameters.Add("@BudgID", SqlDbType.SmallInt);
                //CostID.Direction = ParameterDirection.Input;
                //CostID.Value = costHeadBudget.CostHeadID;

                //SqlParameter CHofDID = cmd.Parameters.Add("@CHofDID", SqlDbType.Int);
                //CHofDID.Direction = ParameterDirection.Input;
                //CHofDID.Value = costHeadBudget.MapicCode;

                //SqlParameter Budget = cmd.Parameters.Add("@Budget", SqlDbType.Decimal);
                //Budget.Direction = ParameterDirection.Input;
                //Budget.Value = costHeadBudget.Remarks;

                //SqlParameter BudgetYear = cmd.Parameters.Add("@BudgetYear", SqlDbType.VarChar, 50);
                //BudgetYear.Direction = ParameterDirection.Input;
                //BudgetYear.Value = costHeadBudget.BudgerYear;

                //SqlParameter Condition = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                //Condition.Direction = ParameterDirection.Input;
                //Condition.Value = costHeadBudget.Condtion;

                //SqlParameter Flag = cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10);
                //Flag.Direction = ParameterDirection.Output;

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
                sqlConnection.Close();
                sqlConnection.Dispose();
                obj = null;
            }
            return true;
        }        

        //get all supplier list
        public DataTable InspectionAcceptanceList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetInspectionStatus";
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

        #region Remarks Management

        //manage the FSD remarks(insert,update,delete)
        public Boolean InspectionRemarksManagement(InspectionRemarks  remark)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("InspectionRemarksManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter CostID = cmd.Parameters.Add("@RemarksID", SqlDbType.TinyInt);
                CostID.Direction = ParameterDirection.Input;
                CostID.Value = remark.RemarksID;

                SqlParameter CHofDID = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,250);
                CHofDID.Direction = ParameterDirection.Input;
                CHofDID.Value = remark.Remarks;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = remark.Condition;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                remark = null;
            }
            return true;
        }   

        //get all Inspection RemarksList list
        public DataTable InspectionRemarksList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetInspectionRemarksList";
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

        #region Summery Note Management

        //manage the FSD Summery Note(insert,update,delete)
        public Boolean SummeryNoteManagement(InspectionNotes summery)
        {
            SqlTransaction transaction;
            DBConnection dbConnection = new DBConnection();
            SqlConnection sqlConnection = dbConnection.GetConnection;

            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand("SummeryNoteManagement", sqlConnection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter ID = cmd.Parameters.Add("@ID", SqlDbType.Int);
                ID.Direction = ParameterDirection.Input;
                ID.Value = summery.refNoteID;

                SqlParameter RefID = cmd.Parameters.Add("@RefID", SqlDbType.Int);
                RefID.Direction = ParameterDirection.Input;
                RefID.Value = summery.RefID;

                SqlParameter SummeryName = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 500);
                SummeryName.Direction = ParameterDirection.Input;
                SummeryName.Value = summery.Note;

                SqlParameter EntryBy = cmd.Parameters.Add("@EntryBy", SqlDbType.VarChar, 10);
                EntryBy.Direction = ParameterDirection.Input;
                EntryBy.Value = LoginUser.UserID;

                SqlParameter Condition = cmd.Parameters.Add("@Condition", SqlDbType.VarChar, 10);
                Condition.Direction = ParameterDirection.Input;
                Condition.Value = summery.Condition;

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
                transaction.Rollback();
                return false;
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                summery = null;
            }
            return true;
        }

        //get all Summery Note list
        public DataTable SummeryNoteList(string choice, string condition)
        {
            DataTable dt = new DataTable();
            string queryString = "GetSummeryNoteList";
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
    }
}
