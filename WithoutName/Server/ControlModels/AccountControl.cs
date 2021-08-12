using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
namespace Server.ControlModels
{
    class AccountControl
    {
        private EDM edm;
        public void SetEDM(EDM edm)
        {
            this.edm = edm;
        }
        public void ADD_ACCOUNT(Account account)
        {
            edm.Accounts.Add(account);
            edm.SaveChanges();
        }

        public void DEL_ACCOUNT(Account account)
        {
            var deletedAccount = edm.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
            if(deletedAccount != null)
            {
                edm.Accounts.Remove(deletedAccount);
                edm.SaveChanges();
            }
        }

        public void UPDATE_ACCOUNT(Account account)
        {
            DEL_ACCOUNT(account);
            ADD_ACCOUNT(account);
        }
    }
}
