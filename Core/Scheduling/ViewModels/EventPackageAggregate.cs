using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    // TODO: This has to be moved out of the system, instead use EventCustomerAggregate.
    public class EventPackageAggregate
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public EventStatus EventStatus { get; set; } 
        public DateTime EventDate { get; set; }
        public Address EventAddress { get; set; }

        public long AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }

        public string PackageName { get; set; }
        public decimal PackageCost { get; set; }
        public long EventCustomerId { get; set; }

        public string SourceCode { get; set; }

        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }

        public decimal PaymentNet { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal UnpaidAmount { get; set; }

        public List<string> ShippingOptions { get; set; }
    }
}


