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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorsicaWars
{
    /// <summary>
    /// Interaction logic for AnimatedGameBoard.xaml
    /// </summary>
    public partial class AnimatedGameBoard : UserControl
    {
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }
        private Deck cardBox;
        private Deck middleDeck;
        private Referee referee;
        private bool isCardsDistributed = false;

        public AnimatedGameBoard()
        {
            player1 = new Player("Masahiro");
            player2 = new Player("Miyazaki");
            referee = new Referee();
            referee.PlayerWin += new PlayerWinEventHandler(referee_PlayerWin);
            middleDeck = new Deck();

            CreateCardBox();

            InitializeComponent();
            cardPlayer1.Child = (Viewbox)Application.Current.Resources["back1"];
            cardPlayer2.Child = (Viewbox)Application.Current.Resources["back1"];
            distribCardAnim.Child = (Viewbox)Application.Current.Resources["back1"];
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
            //cardPlayer1.Child = (Viewbox)Application.Current.Resources["back1"];
            //cardPlayer2.Child = (Viewbox)Application.Current.Resources["back1"];
            //DistributeCards();
            //referee.BeginNewGame(player1, player2, middleDeck);
            //RefreshCardsCount();
        }

        private void RefreshCardsCount()
        {
            //tbPlay1NbCards.Text = player1.cardDeck.Cards.Count.ToString();
            //tbPlay2NbCards.Text = player2.cardDeck.Cards.Count.ToString();
            //tbMiddleNbCards.Text = middleDeck.Cards.Count.ToString();
        }

        private void DistributeCards()
        {
            //cardBox.ShuffleCards();
            //player1.cardDeck.Cards.Clear();
            //player2.cardDeck.Cards.Clear();

            //for (int i = 0; i < cardBox.Cards.Count - 1; i += 2)
            //{
            //    player1.cardDeck.AddCard(cardBox.Cards[i]);
            //    player2.cardDeck.AddCard(cardBox.Cards[i + 1]);
            //}
        }

        private void PlayerPlay(Player play)
        {
            //try
            //{
            //    referee.PlayCard(play);
            //    RefreshMiddleCard();
            //    RefreshCardsCount();
            //}
            //catch (RefereeWrongPlayerException)
            //{
            //    MessageBox.Show("It's not your turn !");
            //}
        }

        private void RefreshMiddleCard()
        {
            //if (middleDeck.Cards.Count > 0)
            //{
            //    Card last = middleDeck.Cards.Last();
            //    string key = string.Format("{0}_{1}", last.Color.ToString(), last.Type.ToString()).ToLower();

            //    if (Application.Current.Resources.Contains(key))
            //    {
            //        cardMiddle.Visibility = Visibility.Visible;
            //        cardMiddle.Child = (Viewbox)Application.Current.Resources[key];
            //    }
            //    else
            //    {
            //        TextBlock b = new TextBlock();
            //        b.Text = "The image doesn't exists.";
            //        b.Background = Brushes.Tomato;
            //        cardMiddle.Child = b;
            //    }
            //}
            //else
            //{
            //    cardMiddle.Visibility = Visibility.Hidden;
            //}
        }

        private void AnimateCard1()
        {
            Storyboard moveCard = new Storyboard();

            Border cardMove = new Border();
            cardMove.Width = 100;
            cardMove.Height = 100;
            cardMove.Child = (Viewbox)Application.Current.Resources["back1"];
            canvasBoard.Children.Add(cardMove);
            Canvas.SetLeft(cardMove, Canvas.GetLeft(cardPlayer1));
            Canvas.SetTop(cardMove, Canvas.GetTop(cardPlayer1));

            DoubleAnimation moveForward = new DoubleAnimation(Canvas.GetTop(cardMiddle), new Duration(TimeSpan.FromMilliseconds(500)));
            moveCard.Children.Add(moveForward);
            Storyboard.SetTargetProperty(moveForward, new PropertyPath("(Canvas.Top)"));

            DoubleAnimation shrink = new DoubleAnimation(0.5, new Duration(TimeSpan.FromMilliseconds(200)));
            shrink.BeginTime = TimeSpan.FromMilliseconds(0);
            moveCard.Children.Add(shrink);
            Storyboard.SetTargetProperty(shrink, new PropertyPath("(RenderTransform.ScaleX)"));

            //DoubleAnimation shrink = new DoubleAnimation(50, new Duration(TimeSpan.FromMilliseconds(200)));
            //shrink.BeginTime = TimeSpan.FromMilliseconds(0);
            //moveCard.Children.Add(shrink);
            //Storyboard.SetTargetProperty(shrink, new PropertyPath("Width"));

            //DoubleAnimation grow = new DoubleAnimation(100, new Duration(TimeSpan.FromMilliseconds(200)));
            //grow.BeginTime = TimeSpan.FromMilliseconds(700);
            //moveCard.Children.Add(grow);
            //Storyboard.SetTargetProperty(grow, new PropertyPath("Width"));

            cardMove.BeginStoryboard(moveCard);
        }

        private void cardPlayer1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimateCard1();
            //PlayerPlay(player1);

        }

        private void cardPlayer2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //PlayerPlay(player2);
        }

        private void distribDeck_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isCardsDistributed)
            {
                BeginStoryboard((Storyboard)this.Resources["distribCards"]);
                isCardsDistributed = true;
            }
        }
    }
}
