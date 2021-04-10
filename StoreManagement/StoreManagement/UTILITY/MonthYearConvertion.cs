using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace StoreManagement.UTILITY
{
    class MonthYearConvertion
    {
        #region Get Month/Year
        /// <summary>
        /// choice 1 for yymm(1401), 2 for yyyymm(201401) and 3 for yyyy(2014)
        /// </summary>
        /// <param name="choice">month year format</param>
        /// <param name="month">month name</param>
        /// <param name="year">year</param>
        /// <returns></returns>
        public string getMonthYear(string choice, string month, string year)
        {
            string strMonth = null, strYear = null, yearMonth = null;

            try
            {
                //get the month
                if (string.IsNullOrEmpty(month))
                {
                    strMonth = monthToNumber(DateTime.Now.ToString("MMMM").Trim());
                }
                else
                {
                    strMonth = monthToNumber(month);
                }

                //get the year
                if (string.IsNullOrEmpty(year))
                {
                    strYear = DateTime.Now.ToString("yy");
                }
                else if (year.Length < 4)
                {
                    strYear = DateTime.Now.ToString("yy");
                }
                else
                {
                    strYear = year.Trim().Substring(2);
                }

                switch (choice.Trim())
                {
                    case "1":
                        //format yymm(1308)
                        yearMonth = strYear + strMonth;
                        break;
                    case "2":
                        //format yyyymm (201308)
                        yearMonth = year + strMonth;
                        break;
                    case "3":
                        //format yyyy (2013)
                        yearMonth = year;
                        break;
                }
            }
            catch
            {
                return null;
            }
            return yearMonth;
        }

        private string monthToNumber(string str_Month)
        {
            string monthNo = DateTime.ParseExact(str_Month, "MMMM", CultureInfo.CurrentCulture).Month.ToString();
            try
            {
                if (monthNo.Length == 1)
                {
                    return "0" + monthNo;
                }
                else if (monthNo.Length > 1)
                {
                    return monthNo;
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
