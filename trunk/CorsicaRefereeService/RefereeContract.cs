using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Corsica.Service
{
    [ServiceContract(
        Namespace="CorsicaWars",
        SessionMode=SessionMode.Required,
        CallbackContract = typeof(IRefereeConcractCallback))]
    interface IRefereeContract
    {
        [OperationContract(IsOneWay=true)]
        void Subscribe(string playerName);

        [OperationContract(IsInitiating=false, IsTerminating=true, IsOneWay=true)]
        void Unsubscribe();

        [OperationContract(IsInitiating=false)]
        void PlayCard();
    }

    interface IRefereeConcractCallback
    {
        [OperationContract(IsOneWay=true)]
        void OnCardPlayed();
    }
}
