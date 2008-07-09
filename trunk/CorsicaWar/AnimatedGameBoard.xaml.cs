﻿using System;
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
        private Player playerwin = null;
        private Deck cardBox;
        private Deck middleDeck;
        private Referee referee;
        private bool isCardsDistributed = false;
        private Border disapBorder = null;

        public AnimatedGameBoard()
        {
            player1 = new Player("Masahiro");
            player2 = new Player("Miyazaki");
            referee = new Referee();
            referee.PlayerWin += new PlayerEventHandler(referee_PlayerWin);
            referee.PlayerGetMiddle += new PlayerEventHandler(referee_PlayerGetMiddle);
            middleDeck = new Deck();

            CreateCardBox();

            InitializeComponent();
            cardPlayer1.Child = (Viewbox)Application.Current.Resources["back1"];
            cardPlayer2.Child = (Viewbox)Application.Current.Resources["back1"];
            distribCardAnim.Child = (Viewbox)Application.Current.Resources["back1"];
        }

        void referee_PlayerGetMiddle(Player winPlayer)
        {
            playerwin = winPlayer;
            btnGetMiddle.Visibility = Visibility.Visible;
            btnGetMiddle.BeginStoryboard((Storyboard)btnGetMiddle.Resources["show"]);
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
            cardPlayer1.Child = (Viewbox)Application.Current.Resources["back1"];
            cardPlayer2.Child = (Viewbox)Application.Current.Resources["back1"];
            DistributeCards();
            referee.BeginNewGame(player1, player2, middleDeck);
            RefreshCardsCount();
        }

        private void RefreshCardsCount()
        {
            //tbPlay1NbCards.Text = player1.cardDeck.Cards.Count.ToString();
            //tbPlay2NbCards.Text = player2.cardDeck.Cards.Count.ToString();
            //tbMiddleNbCards.Text = middleDeck.Cards.Count.ToString();
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

        private bool PlayerPlay(Player play)
        {
            try
            {
                referee.PlayCard(play);
                //RefreshCardsCount();
                return true;
            }
            catch (RefereeWrongPlayerException)
            {
                MessageBox.Show("It's not your turn !");
            }

            return false;
        }

        private Viewbox GetLastMiddleCard()
        {
            if (middleDeck.Cards.Count > 0)
            {
                Card last = middleDeck.Cards.Last();
                string key = string.Format("{0}_{1}", last.Color.ToString(), last.Type.ToString()).ToLower();

                return (Viewbox)Application.Current.Resources[key];
            }
            return null;
        }

        private void AnimateCard(Border player)
        {
            Random rand = new Random();
            int angle = rand.Next(0, 46);

            RotateTransform rotateTrans = new RotateTransform(0);

            Border cardMove = new Border();
            cardMove.Width = player.Width;
            cardMove.Height = player.Height;
            cardMove.RenderTransformOrigin = new Point(0.5, 0.5);
            cardMove.RenderTransform = rotateTrans;
            cardMove.Child = (Viewbox)Application.Current.Resources["back1"];
            canvasBoard.Children.Add(cardMove);
            Canvas.SetLeft(cardMove, Canvas.GetLeft(player));
            Canvas.SetTop(cardMove, Canvas.GetTop(player));

            Border newCard = new Border();
            newCard.Width = cardMiddle.Width;
            newCard.Height = cardMiddle.Height;
            newCard.Opacity = 0;
            newCard.RenderTransformOrigin = new Point(0.5, 0.5);
            newCard.RenderTransform = new RotateTransform(angle);
            newCard.Child = GetLastMiddleCard();
            cardMiddle.Children.Add(newCard);
            Canvas.SetLeft(newCard, 0);
            Canvas.SetTop(newCard, 0);

            disapBorder = cardMove;

            DoubleAnimation moveForward = new DoubleAnimation(Canvas.GetTop(cardMiddle), new Duration(TimeSpan.FromMilliseconds(200)));
            moveForward.DecelerationRatio = 1;
            DoubleAnimation rotate = new DoubleAnimation(angle, new Duration(TimeSpan.FromMilliseconds(200)));
            rotate.DecelerationRatio = 1;
            
            DoubleAnimation disappear = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)));
            disappear.BeginTime = TimeSpan.FromMilliseconds(0200);
            disappear.Completed += new EventHandler(disappear_Completed);

            DoubleAnimation appear = new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100)));
            appear.BeginTime = TimeSpan.FromMilliseconds(400);

            cardMove.BeginAnimation(Canvas.TopProperty, moveForward);
            rotateTrans.BeginAnimation(RotateTransform.AngleProperty, rotate);
            if (middleDeck.Cards.Count > 0)
            {
                cardMove.BeginAnimation(Border.OpacityProperty, disappear);
                newCard.BeginAnimation(Border.OpacityProperty, appear);
            }
        }

        void disappear_Completed(object sender, EventArgs e)
        {
            canvasBoard.Children.Remove(disapBorder);
        }

        private void cardPlayer1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PlayerPlay(player1))
            {
                AnimateCard(cardPlayer1);
            }

        }

        private void cardPlayer2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PlayerPlay(player2))
            {
                AnimateCard(cardPlayer2);
            }
        }

        private void distribDeck_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isCardsDistributed)
            {
                BeginGame();
                BeginStoryboard((Storyboard)this.Resources["distribCards"]);
                isCardsDistributed = true;
            }
        }

        private void DeleteMiddleCards()
        {
            double begin = 0;
            UIElement elem;
            DoubleAnimation anim;
            DoubleAnimation anim2;
            double top;

            if (playerwin == player1)
            {
                top = Canvas.GetTop(cardPlayer1) - Canvas.GetTop(cardMiddle);
            }
            else
            {
                top = Canvas.GetTop(cardPlayer2) - Canvas.GetTop(cardMiddle);
            }

            for (int i = cardMiddle.Children.Count - 1; i >= 0; i--)
            {
                elem = cardMiddle.Children[i];
                anim = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(100)));
                anim2 = new DoubleAnimation(top, new Duration(TimeSpan.FromMilliseconds(100)));
                anim.BeginTime = TimeSpan.FromMilliseconds(begin);
                anim2.BeginTime = TimeSpan.FromMilliseconds(begin);
                elem.BeginAnimation(UIElement.OpacityProperty, anim);
                elem.BeginAnimation(Canvas.TopProperty, anim2);
                begin += 100;
            }

            elem = cardMiddle.Children[0];
            anim = new DoubleAnimation(0, 0, new Duration(TimeSpan.FromMilliseconds(1000)));
            anim.BeginTime = TimeSpan.FromMilliseconds(begin);
            anim.Completed += new EventHandler(anim_Completed);
            elem.BeginAnimation(Canvas.LeftProperty, anim);
        }

        void anim_Completed(object sender, EventArgs e)
        {
            cardMiddle.Children.Clear();
        }

        private void btnGetMiddle_Click(object sender, RoutedEventArgs e)
        {
            DeleteMiddleCards();
            referee.GetMiddleCards();
            btnGetMiddle.BeginStoryboard((Storyboard)btnGetMiddle.Resources["hide"]);
            btnGetMiddle.Visibility = Visibility.Hidden;
        }
    }
}
