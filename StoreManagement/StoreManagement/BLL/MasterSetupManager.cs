using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;

namespace StoreManagement.BLL
{
    class MasterSetupManager
    {
        private MasterSetupGateway masterGateway = null;
        public MasterSetupManager()
        {
            masterGateway = new MasterSetupGateway();
        }
        #region Server Date Time
        //get the store closing month
        public string GetServerDateTime(string choice)
        {
            DataTable dt = null;
            try
            {
                dt = masterGateway.ServerDateTime(choice);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ServerDateTime"].ToString().Trim();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Company Managememt

        //Insert, Update and delete Company information
        public bool CompanyManagement(Company unit)
        {
            return masterGateway.CompanyManagement(unit);
        }

        //return the company information
        public DataTable GetCompanyInfo(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.CompanyInformation(choice, condition);
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
        #endregion

        #region Company Unit Managememt

        //Insert, Update and delete Company Unit
        public bool CompanyUnitManagement(Company unit)
        {
            return masterGateway.CompanyUnitManagement(unit);
        }

        //return the unit list in a datatable
        public DataTable GetCompanyUnitList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.CompanyUnitList(choice, condition);
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

        #endregion

        #region Department Managememt

        //Insert, Update and delete department wise budget
        public bool DepartmentManagement(Company department)
        {
            return masterGateway.DepartmentManagement(department);
        }

        //return the category list in a datatable
        public DataTable GetDepartmentList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.DepartmentList(choice, condition);
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

        #endregion

        #region Stationary Category Managememt

        //Insert, Update and delete the category
        public bool StoreCategoryManagement(Stationary category)
        {
            return masterGateway.StoreCategoryManagement(category);
        }


        //return the category list in a datatable
        public DataTable GetStationaryCategoryList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.StationaryCategoryList(choice, condition);
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

        #endregion

        #region MAPIC CODE management

        //Insert, Update and delete the MAPIC CODE
        public bool MapicsCodeManagement(CostHead mapicCode)
        {
            return masterGateway.MapicsCodeManagement(mapicCode);
        }

        public DataTable GetMapicsCodeList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.MapicsCodeList(choice, condition);
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

        #endregion

        #region Budget Managememt

        //Insert, Update and delete department wise budget
        public bool BudgetManagement(Budget budget)
        {
            return masterGateway.BudgetManagement(budget);
        }

        //Manage the budget closing
        public bool BudgetClosingManagement(Budget budget)
        {
            return masterGateway.BudgetClosingManagement(budget);
        }

        //return the category list in a datatable
        public DataTable GetBudgetList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.BudgetList(choice, condition);
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

        //return the budget closing year
        public string GetBudgetClosingYear(string choice)
        {
            try
            {
                DataTable dt = masterGateway.BudgetClosingYear(choice);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["BudgetYear"].ToString().Trim();
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        #endregion     

        #region Goods/Category/Dimension Management

        #region Product/Goods Management

        //Insert, Update and delete Product/Goods
        public bool ItemManagement(Stationary item)
        {
            return masterGateway.ItemManagement(item);
        }

        //return the Product/Goods list in a datatable
        public DataTable GetItemList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.ItemList(choice, condition);
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
        #endregion

        #region Product Category Management

        //Insert, Update and delete Product/Goods category
        public bool ItemCategoryManagement(Stationary category)
        {
            return masterGateway.ItemCategoryManagement(category);
        }

        //return the list Product/Goods category in a datatable
        public DataTable GetItemCategoryList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.ItemCategoryList(choice, condition);
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
        #endregion

        #region Product Sub Category management
        //Insert, Update and delete Product/Goods dimension of category
        public bool ItemSubCategoryManagement(Stationary subCategory)
        {
            return masterGateway.ItemSubCategoryManagement(subCategory);
        }

        //return the list of dimension of category in a datatable
        public DataTable GetItemSubCategoryList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.ItemSubCategoryList(choice, condition);
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
        #endregion       

        #endregion

        #region Menufacturer management
        //Insert, Update and delete department wise budget
        public bool MenufacturerManagement(Menufacture manufacturer)
        {
            return masterGateway.MenufacturerManagement(manufacturer);
        }


        //return the category list in a datatable
        public DataTable GetMenufacturerList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.MenufacturerList(choice, condition);
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
        #endregion

        #region Supplier management
        //Insert, Update and delete supplier information 
        public bool SupplierManagement(Supplier supplier)
        {
            return masterGateway.SupplierManagement(supplier);
        }

        //return the supplier list in a datatable
        public DataTable GetSupplierList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.SupplierList(choice, condition);
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

        //Insert, Update and delete supplier enlistment information 
        public bool SupplierEnlistmentManagement(Supplier supplier)
        {
            return masterGateway.SupplierEnlistmentManagement(supplier);
        }


        //return the enlisted supplier list in a datatable
        public DataTable GetSupplierEnlistmentList(string choice, string condition1, string condition2)
        {
            try
            {
                DataTable dt = masterGateway.SupplierEnlistmentList(choice, condition1,condition2);
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
        #endregion

        #region Time Period management
        //Insert, Update and delete department wise budget
        public bool TimePeriodManagement(Supplier supplier)
        {
            return masterGateway.SupplierManagement(supplier);
        }


        //return the category list in a datatable
        public DataTable GetTimePeriod(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.TimePeriodList(choice, condition);
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
        #endregion

        #region Inspection Acceptance Managememt

        //Insert, Update and delete the category
        public bool InspecAcceptanceManagement(object obj)
        {
            return masterGateway.InspectionAcceptanceManagement(obj);
        }        

        //return the category list in a datatable
        public DataTable GetInspecAcceptanceList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.InspectionAcceptanceList(choice, condition);
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

        #endregion

        #region Remarks Management
        //Insert, Update and delete the category
        public bool InspecRemarksManagement(InspectionRemarks obj)
        {
            return masterGateway.InspectionRemarksManagement(obj);
        } 

        //return the Inspection Remarks List in a datatable
        public DataTable GetInspectionRemarksList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.InspectionRemarksList(choice, condition);
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
        #endregion

        #region Summery Note Management
        //Insert, Update and delete the category
        public bool SummeryNoteManagement(InspectionNotes summery)
        {
            return masterGateway.SummeryNoteManagement(summery);
        }

        //return the Inspection Remarks List in a datatable
        public DataTable GetSummeryNoteList(string choice, string condition)
        {
            try
            {
                DataTable dt = masterGateway.SummeryNoteList(choice, condition);
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
        #endregion

    }
}
