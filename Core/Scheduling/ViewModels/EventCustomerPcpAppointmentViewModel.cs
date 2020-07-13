using System;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerPcpAppointmentViewModel
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }

        public PrimaryCarePhysician Pcp { get; set; }

        public string AccountLogoUrl { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public int BookAfterNumberOfDays { get; set; }

        public DateTime EventDate { get; set; }
    }
}