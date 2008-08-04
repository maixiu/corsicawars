using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.Service
{
    [ServiceContract(Namespace="CorsicaWars")]
    interface IRefereeContract
    {
        [OperationContract()]
        string Hello(string message);
    }
}
