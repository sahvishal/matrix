using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CustomerLockForCall : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
    }
}