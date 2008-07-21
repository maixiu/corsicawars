using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Corsica.Common;

namespace Corsica.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Callback lol = new Callback();
            CorsicaServerClient client = new CorsicaServerClient(new System.ServiceModel.InstanceContext(lol));
            client.SendMessage("Helllo dude.");
            Console.ReadKey();
            client.Close();
        }
    }

    class Callback : ICorsicaServerCallback
    {

        #region ICorsicaServerCallback Members

        public void OnMessageReceived(string message)
        {
            Console.WriteLine("J'ai recu: " + message);
        }

        #endregion
    }
}
