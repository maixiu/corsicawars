using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.WPFClient
{
    public class CorsicaClient
    {
        private RefereeContractClient client = null;
        private RefereeCallback callbackClient = null;

        public void Subscribe(string playerName)
        {
            callbackClient = new RefereeCallback();
            client = new RefereeContractClient(new InstanceContext(callbackClient));

            client.Subscribe(playerName);
        }

        public void Unsubscribe()
        {
            client.Unsubscribe();
        }
    }
}
