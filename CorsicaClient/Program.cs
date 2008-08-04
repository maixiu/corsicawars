using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corsica.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;

            RefereeContractClient client = new RefereeContractClient();

            do
            {
                line = Console.ReadLine();
                client.Hello(line);
            }
            while (line != "quit");
            client.Close();
        }
    }
}
