using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.UTILITY
{
    class Verification
    {
        public static string verifyEmployeeID(string empID)
        {
            if (empID.Trim().Length == 1)
            {
                return "00000" + empID.Trim();
            }
            else if (empID.Trim().Length == 2)
            {
                return "0000" + empID.Trim();
            }
            else if (empID.Trim().Length == 3)
            {
                return "000" + empID.Trim();
            }
            else if (empID.Trim().Length == 4)
            {
                return "00" + empID.Trim();
            }
            else if (empID.Trim().Length == 5)
            {
                return "0" + empID.Trim();
            }
            else
            {
                return empID;
            }
        }
    }
}
