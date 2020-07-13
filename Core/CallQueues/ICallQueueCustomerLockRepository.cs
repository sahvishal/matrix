using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerLockRepository
    {
        CallQueueCustomerLock GetCallQueueCustomerLock(CallQueueCustomer callqueueCustomer);
        CallQueueCustomerLock SaveCallQueueCustomerLock(CallQueueCustomerLock callQueueCustomerLock);
        void RelaseCallQueueCustomerLock(long callQueueCustomerId);
        void ReleaseIdleCallQuequeCustomerLock(int interval);
        bool CheckCustomerLockByCustomerId(long customerId);
        void UpdateCallQueueCustomerLock(CallQueueCustomerLock callQueueCustomerLock);
    }
}