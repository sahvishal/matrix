using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    public class CallQueueCustomerEqualityComparer : IEqualityComparer<CallQueueCustomer>
    {

        public bool Equals(CallQueueCustomer x, CallQueueCustomer y)
        {
            //no null check here, you might want to do that, or correct that to compare just one part of your object
            return x.CallQueueId == y.CallQueueId && x.CustomerId == y.CustomerId && x.ProspectCustomerId == y.ProspectCustomerId;
        }


        public int GetHashCode(CallQueueCustomer obj)
        {
            return 0;
        }
    }
}