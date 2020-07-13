using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerPcpAppointmentEditModel : ViewModelBase
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }

        public Name CustomerName { get; set; }
        public Email CustomerEmail { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public PrimaryCarePhysicianEditModel Pcp { get; set; }

        public long EventId { get; set; }
        public DateTime ScreeningDate { get; set; }
        public Address Location { get; set; }
        public string HostName { get; set; }

        public DateTime? AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }

        public int BookAfterNumberOfDays { get; set; }

        public bool Print { get; set; }
        public string PrintUrl { get; set; }
        public List<string> ScreenedForTest { get; set; }

        public DateTime? AppointmentDateTime
        {
            get
            {
                if (!AppointmentDate.HasValue) return null;
                DateTime appointmentDateTime;

                DateTime.TryParse(AppointmentDate.Value.Date.ToString("MM/dd/yyyy") + " " + AppointmentTime, out appointmentDateTime);
                return appointmentDateTime;
            }
        }

        public bool NotAbleToSchedule { get; set; }

        public long DispositionId { get; set; }
        public string Notes { get; set; }

        public DateTime EventDate { get; set; }

        public long? PreferredContactMethod { get; set; }
    }
}
