using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ConfirmationReportViewModel:ViewModelBase
    {
        [DisplayName("Patient ID")]
        public long PatientId { get; set; }

        [DisplayName("Patient Name")]
        public string Name { get; set; }

        [DisplayName("Event ID")]
        public long EventID { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Address")]
        public AddressViewModel EventAddress { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        [DisplayName("Booking Date")]
        public DateTime? BookingDate { get; set; }

        [DisplayName("Called By")]
        public string CalledBy { get; set; }

        [DisplayName("Last Call Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? LastContactedDate { get; set; }

        [DisplayName("Outcome")]
        public string Outcome { get; set; }

        [DisplayName("Disposition")]
        public string Disposition { get; set; }

        [DisplayName("No. of Calls")]
        public int CallCount { get; set; }

        [DisplayName("Plan Restricted?")]
        public string IsRestricted { get; set; }

        [DisplayName("Restricted To")]
        public string RestrictedTo { get; set; }
    }
}
