using System.ServiceModel;

namespace WCF.Contracts
{
    public interface ICallbackService
    {
        [OperationContract(IsOneWay = true)]
        void NotifyClient(string msg);
    }
}
