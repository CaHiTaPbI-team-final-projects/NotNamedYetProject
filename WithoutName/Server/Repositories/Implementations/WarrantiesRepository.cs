using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class WarrantiesRepository : IWarrantiesRepository
    {
        private List<Warranty> _Warranties = new List<Warranty>();
        void IWarrantiesRepository.AddWarranty(Warranty Warranty)
        {
            _Warranties.Add(Warranty);
        }

        List<Warranty> IWarrantiesRepository.Get(int id)
        {
            return _Warranties.Where(x => x.Id == id).ToList();
        }

        List<Warranty> IWarrantiesRepository.GetAll()
        {
            return _Warranties;
        }

        void IWarrantiesRepository.RemoveWarranty(int id)
        {
            _Warranties.Remove(_Warranties.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
