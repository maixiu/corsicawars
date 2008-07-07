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

        private void cardPlayer1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //PlayerPlay(player1);
        }

        private void cardPlayer2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //PlayerPlay(player2);
        }

        private void distribDeck_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BeginStoryboard((Storyboard)this.Resources["distribCards"]);

            //Border bDistrib = new Border();
            //Canvas.SetLeft(bDistrib, (double)distribDeck.GetValue(Canvas.LeftProperty));
            //Canvas.SetTop(bDistrib, (double)distribDeck.GetValue(Canvas.TopProperty));
            //bDistrib.Width = distribDeck.Width;
            //bDistrib.Height = distribDeck.Height;
            //bDistrib.Child = (Viewbox)Application.Current.Resources["back1"];
            //canvasBoard.Children.Add(bDistrib);

            //Storyboard moveCards = new Storyboard();
            //moveCards.RepeatBehavior = new RepeatBehavior(10);
            //DoubleAnimation moveLeft1 = new DoubleAnimation((double)cardPlayer1.GetValue(Canvas.LeftProperty),
            //    TimeSpan.FromMilliseconds(300), FillBehavior.Stop);
            //DoubleAnimation moveTop1 = new DoubleAnimation((double)cardPlayer1.GetValue(Canvas.TopProperty),
            //    TimeSpan.FromMilliseconds(300), FillBehavior.Stop);
            //DoubleAnimation moveLeft2 = new DoubleAnimation((double)cardPlayer2.GetValue(Canvas.LeftProperty),
            //    TimeSpan.FromMilliseconds(300), FillBehavior.Stop);
            //moveLeft2.BeginTime = TimeSpan.FromMilliseconds(300);
            //DoubleAnimation moveTop2 = new DoubleAnimation((double)cardPlayer2.GetValue(Canvas.TopProperty), TimeSpan.FromMilliseconds(300),
            //    FillBehavior.Stop);
            //moveTop2.BeginTime = TimeSpan.FromMilliseconds(300);
            //moveCards.Children.Add(moveLeft1);
            //moveCards.Children.Add(moveTop1);
            //moveCards.Children.Add(moveLeft2);
            //moveCards.Children.Add(moveTop2);
            //Storyboard.SetTargetProperty(moveLeft1, new PropertyPath("(Canvas.Left)"));
            //Storyboard.SetTargetProperty(moveTop1, new PropertyPath("(Canvas.Top)"));
            //Storyboard.SetTargetProperty(moveLeft2, new PropertyPath("(Canvas.Left)"));
            //Storyboard.SetTargetProperty(moveTop2, new PropertyPath("(Canvas.Top)"));

            //bDistrib.BeginStoryboard(moveCards);
        }
    }
}
