using System;
using System.Diagnostics;
using System.ServiceModel;

namespace NVIDIASurroundToggle.InterProcess
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private static ServiceHost _serviceHost;

        private Service()
        {
            Status = InstanceStatus.Busy;
        }

        public InstanceStatus Status { get; set; }

        public static bool StartService()
        {
            if (_serviceHost == null)
            {
                try
                {
                    var process = Process.GetCurrentProcess();
                    var service = new Service();
                    _serviceHost = new ServiceHost(
                        service,
                        new Uri($"net.pipe://localhost/NVIDIASurroundToggle_IPC{process.Id}"));

                    _serviceHost.AddServiceEndpoint(typeof (IService), new NetNamedPipeBinding(), "Service");
                    _serviceHost.Open();
                    return true;
                }
                catch (Exception)
                {
                    Utility.ContinueException(() => _serviceHost.Close());
                    _serviceHost = null;
                }
            }
            return false;
        }

        public static Service GetInstance()
        {
            if (_serviceHost != null || StartService())
            {
                // ReSharper disable once PossibleNullReferenceException
                return _serviceHost.SingletonInstance as Service;
            }
            return null;
        }
    }
}