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

namespace CorsicaWars
{
    /// <summary>
    /// Interaction logic for PrettyGameBoard.xaml
    /// </summary>
    public partial class PrettyGameBoard : UserControl
    {
        public PrettyGameBoard()
        {
            InitializeComponent();

            cardPlayer1.Child = (Viewbox)Application.Current.Resources["back1"];
            cardPlayer2.Child = (Viewbox)Application.Current.Resources["back2"];
        }

        public void BeginGame()
        {

        }
    }
}
