using System;
using System.ServiceModel;
using System.ServiceProcess;
using WCF.Common;
using WCF.Contracts;
using WCF.Services;

namespace WCF.Hosting
{
    public partial class ServiceHosts : ServiceBase
    {
        private ServiceHost _serviceHost;

        public ServiceHosts()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                 const string addr = "net.pipe://localhost/47D33AEA-8024-431C-95D8-3285500CE0BF";
                _serviceHost = new ServiceHost(typeof(CalculatorService));
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                binding.ReceiveTimeout = TimeSpan.FromSeconds(30);
                _serviceHost.AddServiceEndpoint(typeof(ICalculatorService), binding, addr);
                _serviceHost.Open();

                LogHelper.Debug("service start successed");
            }
            catch (Exception ex)
            {
                LogHelper.Debug(string.Format("service start exception {0}.", ex.Message));
            }
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
                _serviceHost.Close();

            LogHelper.Debug("service stop");
            LogHelper.Debug("---------------------------------------------------------------");
        }
    }
}
