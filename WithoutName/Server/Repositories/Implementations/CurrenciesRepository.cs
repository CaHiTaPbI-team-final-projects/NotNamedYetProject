using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private List<Currency> _Currencys = new List<Currency>();
        void ICurrenciesRepository.AddCurrency(Currency Currency)
        {
            _Currencys.Add(Currency);
        }

        List<Currency> ICurrenciesRepository.Get(int id)
        {
            return _Currencys.Where(x => x.Id == id).ToList();
        }

        List<Currency> ICurrenciesRepository.GetAll()
        {
            return _Currencys;
        }

        void ICurrenciesRepository.RemoveCurrency(int id)
        {
            _Currencys.Remove(_Currencys.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
