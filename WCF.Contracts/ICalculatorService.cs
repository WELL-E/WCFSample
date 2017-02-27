using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF.Contracts
{
    [ServiceContract(CallbackContract = typeof(ICallbackService))]
    public interface ICalculatorService
    {
        [OperationContract]
        void SetVersion(string version);

        [OperationContract]
        void GetVersion(out string version);

        [OperationContract]
        double Add(double x, double y);
     
        [OperationContract]
        double Subtract(double x, double y);

        [OperationContract]
        double Multiply(double x, double y);
  
       [OperationContract]
        double Divide(double x, double y);

        [OperationContract]
        void TestDelegate(Action<byte[]> onResult);

        [OperationContract]
        void TestBytes(out byte[] bytes);

        [OperationContract]
        Task<string> TestTask();

        [OperationContract]
        void TestNotify();
    }
}
