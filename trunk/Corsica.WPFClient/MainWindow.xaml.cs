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
using System.ServiceModel;

namespace Corsica.WPFClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CorsicaClient client = null;

        public MainWindow()
        {
            InitializeComponent();
            client = App.CreateNewClient();
            client.OnWaitForPlayer += new EventHandler(client_OnWaitForPlayer);
            client.OnGameStarts += new EventHandler(client_OnGameStarts);
        }

        void client_OnGameStarts(object sender, EventArgs e)
        {
            mainBoard.HideMessage();
        }

        void client_OnWaitForPlayer(object sender, EventArgs e)
        {
            mainBoard.Visibility = Visibility.Visible;
            mainBoard.ShowMessage("Wait for a player...", false);
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutCorsica about = new AboutCorsica();
            about.ShowDialog();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miNew_Click(object sender, RoutedEventArgs e)
        {
            client.Subscribe(Guid.NewGuid().ToString("N").Remove(5));
        }
    }
}
