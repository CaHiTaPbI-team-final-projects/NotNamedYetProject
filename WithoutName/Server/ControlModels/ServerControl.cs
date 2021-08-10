using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;

namespace Server.ControlModels
{
    public class ServerControl
    {
        private EDM dolbaza = new EDM();       

        public decimal GETSTAT(int categoryId)
        {
            var opaList = dolbaza.Transactions.Where(x => x.CategoryId == categoryId).ToList();
            decimal res = 0;

            foreach (var item in opaList)
            {
                res += item.Amount;
            }

            return res;
        }     

    }
}
