using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace Corsica.Common
{
    [ServiceContract(
        Name="CorsicaService",
        Namespace="http://Corsica.Common",
        ProtectionLevel=ProtectionLevel.None,
        CallbackContract=typeof(ICorsicaServiceCallback))]
    public interface ICorsicaService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    public interface ICorsicaServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageReceived(string message);
    }
}
