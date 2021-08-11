using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
namespace Server.ControlModels
{
    class TransactionControl
    {
        private EDM edm;
        public void SetEDM(EDM edm)
        {
            this.edm = edm;
        }
        public void ADD_TRANSACTION(decimal sum, int categoryId, int currencyId)
        {
            //dolbaza.Transactions.Add(new Transaction() { Amount = sum, CategoryId = categoryId, CurrencyId = currencyId, UserId = 0 });
        }

        public void DEL_TRANSACTION()
        { }

        public void UPDATE_TRANSCATION()
        { }
    }
}
