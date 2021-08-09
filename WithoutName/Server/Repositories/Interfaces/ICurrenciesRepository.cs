using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface ICurrenciesRepository
    {
        List<Currency> GetAll();
        List<Currency> Get(int id);
        void AddCurrency(Currency currency);
        void RemoveCurrency(int id);
    }
}
