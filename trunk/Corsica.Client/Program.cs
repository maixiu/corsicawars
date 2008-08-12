using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            lol l = new lol();
            RefereeContractClient client = new RefereeContractClient(new InstanceContext(l));

            try
            {
                client.Subscribe("Player1");
                client.Unsubscribe();
            }
            catch { }
            finally
            {
                client.Close();
            }
        }
    }

    class lol : IRefereeContractCallback
    {

        #region IRefereeContractCallback Members

        public void OnCardPlayed(string user)
        {
            Console.WriteLine("received oncardplaycallback.");
        }

        #endregion
    }
}
