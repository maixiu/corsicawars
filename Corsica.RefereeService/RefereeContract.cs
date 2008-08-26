using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Corsica.Game;

namespace Corsica.Service
{
    [ServiceContract(
        Namespace="CorsicaWars",
        SessionMode=SessionMode.Required,
        CallbackContract = typeof(IRefereeConcractCallback))]
    interface IRefereeContract
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe(string playerName);

        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void Unsubscribe();

        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void PlayerPlay();
    }

    interface IRefereeConcractCallback
    {
        [OperationContract(IsOneWay = true)]
        void WaitForPlayer();

        [OperationContract(IsOneWay = true)]
        void GameStarts();

        [OperationContract(IsOneWay = true)]
        void GameAborded();

        [OperationContract(IsOneWay = true)]
        void CardPlayed(string player, Card cardPlayed);
    }
}
