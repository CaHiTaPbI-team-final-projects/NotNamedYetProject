using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface IAccountsRepositry
    {
        List<Account> GetAll();
        List<Account> Get(int id);
        void AddAccount(Account account);
        void RemoveAccount(int id);
    }
}
