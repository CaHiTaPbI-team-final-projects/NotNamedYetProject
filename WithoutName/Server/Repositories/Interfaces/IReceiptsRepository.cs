using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface IReceiptsRepository
    {
        List<Receipt> GetAll();
        List<Receipt> Get(int id);
        void AddReceipt(Receipt receipt);
        void RemoveReceipt(int id);
    }
}
