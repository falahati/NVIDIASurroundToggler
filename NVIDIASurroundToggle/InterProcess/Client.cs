using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace NVIDIASurroundToggle.InterProcess
{
    internal class Client : ClientBase<IService>, IService
    {
        public Client(Process process)
            : base(
                new ServiceEndpoint(
                    ContractDescription.GetContract(typeof (IService)),
                    new NetNamedPipeBinding(),
                    new EndpointAddress(
                        $"net.pipe://localhost/NVIDIASurroundToggle_IPC{process.Id}/Service")))
        {
        }

        public InstanceStatus Status => Channel.Status;
    }
}