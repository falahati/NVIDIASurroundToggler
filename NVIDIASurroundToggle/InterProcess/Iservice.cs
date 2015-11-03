using System.ServiceModel;

namespace NVIDIASurroundToggle.InterProcess
{
    [ServiceContract]
    public interface IService
    {
        InstanceStatus Status { [OperationContract] get; }
    }
}