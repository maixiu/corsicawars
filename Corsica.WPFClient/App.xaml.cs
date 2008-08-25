using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Corsica.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CorsicaClient Client { get; private set; }

        public static CorsicaClient CreateNewClient()
        {
            Client = new CorsicaClient();
            return Client;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (Client != null)
            {
                Client.Unsubscribe();
            }
        }
    }
}
