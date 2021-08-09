using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class CardsRepository : ICardsRepository
    {
        private List<Card> _Cards = new List<Card>();
        void ICardsRepository.AddCard(Card Card)
        {
            _Cards.Add(Card);
        }

        List<Card> ICardsRepository.Get(int id)
        {
            return _Cards.Where(x => x.Id == id).ToList();
        }

        List<Card> ICardsRepository.GetAll()
        {
            return _Cards;
        }

        void ICardsRepository.RemoveCard(int id)
        {
            _Cards.Remove(_Cards.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
