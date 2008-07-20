using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel;

namespace Corsica.Server
{
    class Program
    {
        private const string CONFIG_KEY_BASEURI = "baseURI";

        static void Main(string[] args)
        {
            Uri baseAddress = null;
            string input = string.Empty;
            ServiceHost service = null;

            Console.Write("Initializating service host... ");
            baseAddress = new Uri(ConfigurationManager.AppSettings[CONFIG_KEY_BASEURI]);
            service = new ServiceHost(new Server(), baseAddress);
            service.Open();
            Console.WriteLine("OK");

            do
            {
                input = Console.ReadLine();
            }
            while (input != "quit");

            service.Abort();
            service.Close();
        }
    }
}
