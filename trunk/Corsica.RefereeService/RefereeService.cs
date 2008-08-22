using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Corsica.Game;

namespace Corsica.Service
{
    [ServiceBehavior(
        InstanceContextMode=InstanceContextMode.PerSession,
        ConcurrencyMode=ConcurrencyMode.Single)]
    public class RefereeService : IRefereeContract
    {
        private static Dictionary<string, IRefereeConcractCallback> clientList = new Dictionary<string, IRefereeConcractCallback>();
        private String playerName = null;

        #region IRefereeContract Members

        public void Subscribe(string playerName)
        {
            if (!clientList.ContainsKey(playerName))
            {
                this.playerName = playerName;
                IRefereeConcractCallback callback = OperationContext.Current.GetCallbackChannel<IRefereeConcractCallback>();
                RefereeService.clientList.Add(playerName, callback);

                Console.WriteLine("Player subscribe: " + playerName);

                if (RefereeService.clientList.Count > 1)
                {
                    foreach (IRefereeConcractCallback call in RefereeService.clientList.Values)
                    {
                        call.GameStarts();
                    }
                }
                else
                {
                    callback.WaitForPlayer();
                }
            }
            else
            {
                throw new FaultException<CorsicaPlayerExists>(new CorsicaPlayerExists());
            }
        }

        public void Unsubscribe()
        {
            clientList.Remove(this.playerName);
            Console.WriteLine("Player unsubscribe: " + playerName);
        }


        #endregion
    }
}
