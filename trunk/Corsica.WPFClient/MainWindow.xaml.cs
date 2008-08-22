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
        CorsicaClient client = App.Client;

        public MainWindow()
        {
            InitializeComponent();
            client.OnWaitForPlayer += new EventHandler(client_OnWaitForPlayer);
        }

        void client_OnWaitForPlayer(object sender, EventArgs e)
        {
            mainBoard.Visibility = Visibility.Visible;
            mainBoard.ShowMessage("Wait for a player", false);
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
            client = new CorsicaClient();
            client.Subscribe(Guid.NewGuid().ToString("N").Remove(5));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Unsubscribe();
            }
        }
    }
}
