using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corsica.Game
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }

        public void RemoveCard(Card remCard)
        {
            Cards.Remove(remCard);
        }

        public void ShuffleCards()
        {
            int nbCards = Cards.Count;
            Random rand = new Random();
            List<Card> newList = new List<Card>();

            for (int i = 0; i < nbCards; i++)
            {
                int num = rand.Next(0, nbCards - i);
                newList.Add(Cards[num]);
                Cards.RemoveAt(num);
            }

            Cards = newList;
        }
    }
}
