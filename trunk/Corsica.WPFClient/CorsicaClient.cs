using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.WPFClient
{
    public class CorsicaClient : IRefereeContractCallback
    {
        private RefereeContractClient client = null;

        public event EventHandler OnWaitForPlayer;
        public event EventHandler OnGameStarts;
        public event EventHandler OnGameAborded;

        public CorsicaClient()
        {
            client = new RefereeContractClient(new InstanceContext(this));
        }

        public void Subscribe(string playerName)
        {
            client.Subscribe(playerName);
        }

        public void Unsubscribe()
        {
            client.Unsubscribe();
        }

        #region IRefereeContractCallback Members

        public void WaitForPlayer()
        {
            if (OnWaitForPlayer != null)
                OnWaitForPlayer(this, null);
        }

        public void GameStarts()
        {
            if (OnGameStarts != null)
                OnGameStarts(this, null);
        }

        public void GameAborded()
        {
            if (OnGameAborded != null)
                OnGameAborded(this, null);
        }

        #endregion
    }
}
