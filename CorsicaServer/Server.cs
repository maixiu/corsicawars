using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Corsica.Common;

namespace Corsica.Server
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Reentrant, InstanceContextMode=InstanceContextMode.Single)]
    public class Server:ICorsicaServer
    {
        #region ICorsicaServer Members

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
            ICorsicaServerCallback c = OperationContext.Current.GetCallbackChannel<ICorsicaServerCallback>();
            c.OnMessageReceived("lol");

        }

        #endregion
    }
}
