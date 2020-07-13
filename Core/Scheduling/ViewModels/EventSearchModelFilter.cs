using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventSearchModelFilter
    {
        public long? EventId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Pod { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long StaffId { get; set; }
    }
}
