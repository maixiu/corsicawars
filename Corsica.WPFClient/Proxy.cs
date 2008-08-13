﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace = "CorsicaWars", ConfigurationName = "IRefereeContract", CallbackContract = typeof(IRefereeContractCallback), SessionMode = System.ServiceModel.SessionMode.Required)]
public interface IRefereeContract
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "CorsicaWars/IRefereeContract/Subscribe")]
    void Subscribe(string playerName);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsTerminating = true, IsInitiating = false, Action = "CorsicaWars/IRefereeContract/Unsubscribe")]
    void Unsubscribe();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IRefereeContractCallback
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "CorsicaWars/IRefereeContract/WaitForPlayer")]
    void WaitForPlayer();

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "CorsicaWars/IRefereeContract/GameStarts")]
    void GameStarts();

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "CorsicaWars/IRefereeContract/GameAborded")]
    void GameAborded();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IRefereeContractChannel : IRefereeContract, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class RefereeContractClient : System.ServiceModel.DuplexClientBase<IRefereeContract>, IRefereeContract
{

    public RefereeContractClient(System.ServiceModel.InstanceContext callbackInstance) :
        base(callbackInstance)
    {
    }

    public RefereeContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
        base(callbackInstance, endpointConfigurationName)
    {
    }

    public RefereeContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
        base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public RefereeContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public RefereeContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(callbackInstance, binding, remoteAddress)
    {
    }

    public void Subscribe(string playerName)
    {
        base.Channel.Subscribe(playerName);
    }

    public void Unsubscribe()
    {
        base.Channel.Unsubscribe();
    }
}
