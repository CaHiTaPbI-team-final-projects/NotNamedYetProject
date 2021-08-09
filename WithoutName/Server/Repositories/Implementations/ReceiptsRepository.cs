using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private List<Receipt> _Receipts = new List<Receipt>();
        void IReceiptsRepository.AddReceipt(Receipt Receipt)
        {
            _Receipts.Add(Receipt);
        }

        List<Receipt> IReceiptsRepository.Get(int id)
        {
            return _Receipts.Where(x => x.Id == id).ToList();
        }

        List<Receipt> IReceiptsRepository.GetAll()
        {
            return _Receipts;
        }

        void IReceiptsRepository.RemoveReceipt(int id)
        {
            _Receipts.Remove(_Receipts.Where(x => x.Id == id).FirstOrDefault());
        }

    }
}
