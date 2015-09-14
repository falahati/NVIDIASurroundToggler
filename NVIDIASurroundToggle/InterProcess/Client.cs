namespace NVIDIASurroundToggle.InterProcess
{
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    internal class Client : ClientBase<IService>, IService
    {
        public Client(Process process)
            : base(
                new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(IService)),
                    new NetNamedPipeBinding(),
                    new EndpointAddress(
                        string.Format("net.pipe://localhost/NVIDIASurroundToggle_IPC{0}/Service", process.Id))))
        {
        }

        public InstanceStatus Status
        {
            get
            {
                return this.Channel.Status;
            }
        }
    }
}