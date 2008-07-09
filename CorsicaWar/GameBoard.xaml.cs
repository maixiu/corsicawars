using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace CorsicaWars
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : UserControl
    {
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }
        private Deck cardBox;
        private Deck middleDeck;
        private Referee referee;

        public GameBoard()
        {
            player1 = new Player("Masahiro");
            player2 = new Player("Miyazaki");
            referee = new Referee();
            referee.PlayerWin += new PlayerEventHandler(referee_PlayerWin);
            middleDeck = new Deck();

            CreateCardBox();

            InitializeComponent();
        }

        void referee_PlayerWin(Player winPlayer)
        {
            MessageBox.Show(string.Format("The player: {0} win this game!!!", winPlayer.Name));
        }

        public void CreateCardBox()
        {
            cardBox = new Deck();
            foreach (CardType card in Enum.GetValues(typeof(CardType)))
            {
                foreach (ColorType color in Enum.GetValues(typeof(ColorType)))
                {
                    cardBox.AddCard(new Card() { Type = card, Color = color });
                }
            }
        }

        public void BeginGame()
        {
            DistributeCards();
            referee.BeginNewGame(player1, player2, middleDeck);
            RefreshCardsCount();
        }

        private void PlayerPlay(Player play)
        {
            try
            {
                referee.PlayCard(play);
                RefreshCardsCount();
            }
            catch (RefereeWrongPlayerException)
            {
                MessageBox.Show("It's not your turn !");
            }
        }

        private void RefreshCardsCount()
        {
            tbNbCardsPlayer1.Text = player1.cardDeck.Cards.Count.ToString();
            tbNbCardsPlayer2.Text = player2.cardDeck.Cards.Count.ToString();
            tbNbCardsMiddle.Text = middleDeck.Cards.Count.ToString();
            lstCardHistory.Items.Clear();
            foreach (Card card in middleDeck.Cards)
            {
                lstCardHistory.Items.Insert(0, card);
            }
        }

        private void DistributeCards()
        {
            cardBox.ShuffleCards();
            player1.cardDeck.Cards.Clear();
            player2.cardDeck.Cards.Clear();

            for (int i = 0; i < cardBox.Cards.Count - 1; i += 2)
            {
                player1.cardDeck.AddCard(cardBox.Cards[i]);
                player2.cardDeck.AddCard(cardBox.Cards[i + 1]);
            }
        }

        private void bPlayer1Play_Click(object sender, RoutedEventArgs e)
        {
            PlayerPlay(player1);
        }

        private void bPlayer2Play_Click(object sender, RoutedEventArgs e)
        {
            PlayerPlay(player2);
        }

        private void bPlayer1Tap_Click(object sender, RoutedEventArgs e)
        {
            referee.TapDeck(player1);
            RefreshCardsCount();
        }

        private void bPlayer2Tap_Click(object sender, RoutedEventArgs e)
        {
            referee.TapDeck(player2);
            RefreshCardsCount();
        }
    }
}
