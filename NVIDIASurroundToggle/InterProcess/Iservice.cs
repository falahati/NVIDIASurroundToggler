namespace NVIDIASurroundToggle.InterProcess
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IService
    {
        InstanceStatus Status { [OperationContract] get; }
    }
}