using System.ServiceModel;

namespace NVIDIASurroundToggle.InterProcess
{
    [ServiceContract]
    internal interface IService
    {
        InstanceStatus Status { [OperationContract] get; }
    }
}