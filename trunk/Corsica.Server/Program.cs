using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel;

using Corsica.Service;

namespace Corsica.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            ServiceHost service = null;

            Console.Write("Initializating service host... ");
            service = new ServiceHost(typeof(RefereeService));
            service.Open();
            Console.WriteLine("OK");
            Console.ReadLine();

            service.Close();
        }
    }
}
