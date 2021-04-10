using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.DAL.DAO
{
    class OrderType
    {
        enum orderTupe
        {
            Normal = 'N',
            PostFacto = 'Y',
            CashPurchase = 'C'
        }
    }
}
