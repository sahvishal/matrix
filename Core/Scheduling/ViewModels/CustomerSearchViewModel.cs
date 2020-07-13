using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerSearchViewModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string HostName { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public string PackageName { get; set; }

    }
}
