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

        public void ADDTRANS(decimal sum, int categoryId, int currencyId)
        {
            dolbaza.Transactions.Add(new Transaction() { Amount = sum, CategoryId = categoryId, CurrencyId = currencyId, UserId = 0 });
        }

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

        public void ADD_USER(string login, string password)
        {
            dolbaza.Users.Add(new User() { Login = login, Password = password, Name = "default" });
        }
    }
}
