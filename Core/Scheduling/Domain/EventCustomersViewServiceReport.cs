using System;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventCustomersViewServiceReport
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public DateTime DateCreated { get; set; }
        public long AccountId { get; set; }

        public DateTime EventDate { get; set; }
    }
}
