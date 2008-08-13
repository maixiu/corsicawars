using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corsica.WPFClient
{
    public class RefereeCallback : IRefereeContractCallback
    {
        #region IRefereeContractCallback Members

        public void WaitForPlayer()
        {
            throw new NotImplementedException();
        }

        public void GameStarts()
        {
            throw new NotImplementedException();
        }

        public void GameAborded()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
