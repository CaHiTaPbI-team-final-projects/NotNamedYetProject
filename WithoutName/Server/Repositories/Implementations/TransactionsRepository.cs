using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class TransactionsRepository :ITransactionsRepository
    {
        private List<Transaction> _Transactions = new List<Transaction>(); 
        void ITransactionsRepository.AddTransaction(Transaction Transaction)
        {
            _Transactions.Add(Transaction);   
        }

        List<Transaction> ITransactionsRepository.Get(int id)
        {
            return _Transactions.Where(x => x.Id == id).ToList();
        }

        List<Transaction> ITransactionsRepository.GetAll()
        {
            return _Transactions;
        }
       
        void ITransactionsRepository.RemoveTransaction(int id)
        {
            _Transactions.Remove(_Transactions.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
