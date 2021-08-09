using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetAll();
        List<Transaction> Get(int id);
        void AddTransaction(Transaction transaction);
        void RemoveTransaction(int id);
    }
}
