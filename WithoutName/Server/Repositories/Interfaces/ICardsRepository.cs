using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface ICardsRepository
    {
        List<Card> GetAll();
        List<Card> Get(int id);
        void AddCard(Card card);
        void RemoveCard(int id);
    }
}
