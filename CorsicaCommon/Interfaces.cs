using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Corsica.Common
{
    [ServiceContract(CallbackContract=typeof(ICorsicaServerCallback))]
    public interface ICorsicaServer
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    public interface ICorsicaServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageReceived(string message);
    }
}
