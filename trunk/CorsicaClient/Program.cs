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
            string line = string.Empty;

            Callback lol = new Callback();
            CorsicaServerClient client = new CorsicaServerClient(new System.ServiceModel.InstanceContext(lol));

            do
            {
                line = Console.ReadLine();
                client.SendMessage(line);
            }
            while (line != "quit");
            client.Close();
        }
    }

    class Callback : ICorsicaServerCallback
    {
        #region ICorsicaServerCallback Members

        public void OnMessageReceived(string message)
        {
            Console.WriteLine(string.Format("Recu: {0}", message));
        }

        #endregion
    }
}
