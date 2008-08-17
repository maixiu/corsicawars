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

        //public new static App Current
        //{
        //    get { return (App)Application.Current; }
        //}
    }
}
