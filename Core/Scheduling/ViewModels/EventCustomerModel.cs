using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerModel : ViewModelBase
    {
        public long EventId { get; set; } // This is displayed as Event Code in the report
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public Address Address { get; set; }
        public string Territory { get; set; }
        public string Vehicle { get; set; }
        public string Physician { get; set; } // For an event ??
        public int CustomerCount { get; set; }

        public IEnumerable<CustomerScheduleModel> Customers { get; set; }
    }
}
