using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.Service
{
    public class RefereeService : IRefereeContract
    {
        #region IRefereeContract Members

        public string Hello(string message)
        {
            return "you sent :" + message;
        }

        #endregion
    }
}
