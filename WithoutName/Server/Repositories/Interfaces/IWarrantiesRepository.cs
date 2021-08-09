using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface IWarrantiesRepository
    {
        List<Warranty> GetAll();
        List<Warranty> Get(int id);
        void AddWarranty(Warranty warranty);
        void RemoveWarranty(int id);
    }
}
