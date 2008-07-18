using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Corsica.Common
{
    [ServiceContract(CallbackContract=ICorsicaCallback)]
    public interface ICorsica
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    public interface ICorsicaCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageReceived(string message);
    }
}
