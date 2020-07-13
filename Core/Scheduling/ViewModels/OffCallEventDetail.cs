using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OffCallEventDetail
    {
        public long CustomerId { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public string EventName { get; set; }

        public string PackageName { get; set; }
    }
}
