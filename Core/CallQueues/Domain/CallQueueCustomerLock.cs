using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueueCustomerLock : DomainObjectBase
    {
        public long CallQueueCustomerId { get; set; }
        public long? CustomerId { get; set; }
        public long? ProspectCustomerId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
