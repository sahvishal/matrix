using System;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CustomerCallAttempts
    {
        public long CustomerId { get; set; }
        public long Attempt { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedBy { get; set; }
    }
}