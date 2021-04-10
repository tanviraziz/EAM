using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class Budget
    {
        public Budget()
        {
           CostHeadBudget = new Dictionary<string, CostHead>();
        }
        //Fields
        private string condition = "1";


        //Propertis
        public Int32 BudgIDID { get; set; }
        public string BudgetYear { get; set; }
        public Dictionary<string, CostHead> CostHeadBudget { get; set; }
        
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
    }
}
