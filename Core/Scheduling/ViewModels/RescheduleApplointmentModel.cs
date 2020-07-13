using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class RescheduleApplointmentModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Old Event Id")]
        public long OldEventId { get; set; }

        [DisplayName("Old Event Name")]
        public string OldEventName { get; set; }

        [DisplayName("Old Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime OldEventDate { get; set; }

        [DisplayName("Old Event Sponsored By")]
        public string OldEventSponsoredBy { get; set; }

        [DisplayName("Old Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? OldAppointmentTime { get; set; }

        [DisplayName("New Event Id")]
        public long NewEventId { get; set; }

        [DisplayName("New Event Name")]
        public string NewEventName { get; set; }

        [DisplayName("New Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime NewEventDate { get; set; }

        [DisplayName("New Event Sponsored By")]
        public string NewEventSponsoredBy { get; set; }

        [DisplayName("New Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime NewAppointmentTime { get; set; }

        [DisplayName("Rescheduled On")]
        [Format("MM/dd/yyyy")]
        public DateTime RescheduledOn { get; set; }

        public string RescheduledBy { get; set; }

        public string Reason { get; set; }

        public string SubReason { get; set; }

        public string Notes { get; set; }
    }
}
