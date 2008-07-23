using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Corsica.Common;

namespace Corsica.Server
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Reentrant, InstanceContextMode=InstanceContextMode.Single)]
    public class Server:ICorsicaService
    {
        private List<ICorsicaServiceCallback> _list = new List<ICorsicaServiceCallback>();

        #region ICorsicaServer Members

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
            ICorsicaServiceCallback c = OperationContext.Current.GetCallbackChannel<ICorsicaServiceCallback>();
            if (message == "hello")
            {
                _list.Add(c);
            }
            else
            {
                foreach (ICorsicaServiceCallback item in _list)
                {
                    if (item != c)
                    {
                        item.OnMessageReceived(message);
                    }
                }
            }
        }

        #endregion
    }
}
