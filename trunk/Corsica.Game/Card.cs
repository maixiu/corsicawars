using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Corsica.Game
{
    [DataContract]
    public class Card
    {
        [DataMember]
        public CardType Type;
        [DataMember]
        public ColorType Color;

        public override string ToString()
        {
            return string.Format("{0} of {1}", Type, Color);
        }
    }

    public enum CardType
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine,
        Ten, Jack, Queen, King
    }

    public enum ColorType
    {
        Diamond, Spade, Heart, Club
    }
}
