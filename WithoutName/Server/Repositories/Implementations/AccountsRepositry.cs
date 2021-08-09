using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class AccountsRepositry : IAccountsRepositry
    {
        private List<Account> _Accounts = new List<Account>();
        void IAccountsRepositry.AddAccount(Account Account)
        {
            _Accounts.Add(Account);
        }

        List<Account> IAccountsRepositry.Get(int id)
        {
            return _Accounts.Where(x => x.Id == id).ToList();
        }

        List<Account> IAccountsRepositry.GetAll()
        {
            return _Accounts;
        }

        void IAccountsRepositry.RemoveAccount(int id)
        {
            _Accounts.Remove(_Accounts.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
