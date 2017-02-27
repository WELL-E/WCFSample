using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using WCF.Common;
using WCF.Contracts;

namespace WCF.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculatorService
    {
        private readonly ICallbackService _callback;
        private string _version;

        public CalculatorService()
        {
             _callback = OperationContext.Current.GetCallbackChannel<ICallbackService>();
        }

        public void SetVersion(string version)
        {
           
            LogHelper.Debug("SetVersion");
            _version = version;
        }

        public double Add(double x, double y)
        {
            LogHelper.Debug("Add Operation");
            return x+y;
        }

        public double Subtract(double x, double y)
        {
            LogHelper.Debug("Subtract Operation");
            return x-y;
        }

        public double Multiply(double x, double y)
        {
            LogHelper.Debug("Multiply Operation");
            return x*y;
        }

        public double Divide(double x, double y)
        {
            LogHelper.Debug("Divide Operation");
            return x/y;
        }

        public void TestDelegate(Action<byte[]> onResult)
        {
            onResult(new byte[] { 1, 1, 1, 1 });
            LogHelper.Debug("TestDelegate");
        }


        public void GetVersion(out string version)
        {
            version = _version;
            LogHelper.Debug("GetVersion");
        }


        public void TestBytes(out byte[] bytes)
        {
            bytes = new byte[] { 1, 0, 0, 1 };
            LogHelper.Debug("TestBytes");
        }

        public async Task<string> TestTask()
        {
            return await Task.Run(()=>
            {
                LogHelper.Debug("TestTask");
                Thread.Sleep(1000*30);
                return "Test Task";
            });
        }

        public void TestNotify()
        {
            LogHelper.Debug("TestNotify");

            ThreadPool.QueueUserWorkItem(_ =>
            {
                _callback.NotifyClient("Test Notify");
            });
        }
    }
}
