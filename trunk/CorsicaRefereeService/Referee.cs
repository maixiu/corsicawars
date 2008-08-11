using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorsicaWars
{
    public delegate void PlayerEventHandler(Player winPlayer);

    public class Referee
    {
        public event PlayerEventHandler PlayerWin;
        public event PlayerEventHandler PlayerGetMiddle;

        public static Dictionary<CardType, short> PowerCardList { get; private set; }
        private Player player1 = null;
        private Player player2 = null;
        private Deck middleDeck = null;
        private Player currentPlayer = null;
        private Card? lastCard = null;
        private short? nextNbChance = null;

        public Referee()
        {
            PowerCardList = new Dictionary<CardType, short>()
            {
                { CardType.Ace, 4 },
                { CardType.King, 3 },
                { CardType.Queen, 2 },
                { CardType.Jack, 1 }
            };
        }

        public void BeginNewGame(Player newPlayer1, Player newPlayer2, Deck newMiddleDeck)
        {
            player1 = newPlayer1;
            player2 = newPlayer2;
            middleDeck = newMiddleDeck;

            currentPlayer = null;
            lastCard = null;
            nextNbChance = null;
        }

        public void PlayCard(Player player)
        {
            if (currentPlayer == player)
            {
                throw new RefereeWrongPlayerException();
            }
            if (player.cardDeck.Cards.Count == 0)
            {
                OnPlayerWin(currentPlayer);
                return;
            }

            lastCard = PlayerTakeCard(player);
            middleDeck.AddCard(lastCard.Value);

            if (PowerCardList.ContainsKey(lastCard.Value.Type))
            {
                nextNbChance = PowerCardList[lastCard.Value.Type];
                currentPlayer = player;
            }
            else if (nextNbChance == null)
            {
                currentPlayer = player;
            }
            else
            {
                nextNbChance--;
            }

            if (nextNbChance == 0)
            {
                OnPlayerGetMiddle(currentPlayer);
            }
        }

        public void GetMiddleCards()
        {
            PlayerGetMiddleDeck(currentPlayer);
        }

        public bool TapDeck(Player playerAttack)
        {
            if (middleDeck.Cards.Count >= 2 &&
                middleDeck.Cards.Last().Type == middleDeck.Cards[middleDeck.Cards.Count - 2].Type)
            {
                PlayerGetMiddleDeck(playerAttack);
                return true;
            }
            else
            {
                PunishPlayer(playerAttack);
                return false;
            }
        }

        private Card PlayerTakeCard(Player play)
        {
            Card takeCard = play.cardDeck.Cards.Last();
            play.cardDeck.Cards.Remove(takeCard);

            return takeCard;
        }

        private void PunishPlayer(Player misPlayer)
        {
            Card lostCard = PlayerTakeCard(misPlayer);
            middleDeck.Cards.Insert(0, lostCard);
        }

        private void PlayerGetMiddleDeck(Player playWinner)
        {
            foreach (Card card in middleDeck.Cards)
            {
                playWinner.cardDeck.Cards.Insert(0, card);
            }
            currentPlayer = null;
            middleDeck.Cards.Clear();

            if (player1.cardDeck.Cards.Count == 0)
            {
                OnPlayerWin(player2);
            }
            else if (player2.cardDeck.Cards.Count == 0)
            {
                OnPlayerWin(player1);
            }
        }

        protected virtual void OnPlayerWin(Player winPlayer)
        {
            if (PlayerWin != null)
            {
                PlayerWin(winPlayer);
            }
        }

        protected virtual void OnPlayerGetMiddle(Player winPlayer)
        {
            if (PlayerGetMiddle != null)
            {
                PlayerGetMiddle(winPlayer);
            }
        }
    }

    public class RefereeWrongPlayerException : Exception
    {
        public RefereeWrongPlayerException() : base() { }
    }
}
