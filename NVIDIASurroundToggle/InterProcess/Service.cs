namespace NVIDIASurroundToggle.InterProcess
{
    using System;
    using System.Diagnostics;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private static ServiceHost serviceHost;

        private Service()
        {
            this.Status = InstanceStatus.Busy;
        }

        public InstanceStatus Status { get; set; }

        public static bool StartService()
        {
            if (serviceHost == null)
            {
                try
                {
                    Process process = Process.GetCurrentProcess();
                    var service = new Service();
                    serviceHost = new ServiceHost(
                        service,
                        new Uri(string.Format("net.pipe://localhost/NVIDIASurroundToggle_IPC{0}", process.Id)));

                    serviceHost.AddServiceEndpoint(typeof(IService), new NetNamedPipeBinding(), "Service");
                    serviceHost.Open();
                    return true;
                }
                catch (Exception)
                {
                    Utility.ContinueException(() => serviceHost.Close());
                    serviceHost = null;
                }
            }
            return false;
        }

        public static Service GetInstance()
        {
            if (serviceHost != null || StartService())
            {
                // ReSharper disable once PossibleNullReferenceException
                return serviceHost.SingletonInstance as Service;
            }
            return null;
        }
    }
}