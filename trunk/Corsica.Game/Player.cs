using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corsica.Game
{
    public class Player
    {
        public string Name { get; private set; }
        public Deck cardDeck { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            cardDeck = new Deck();
        }
    }
}
