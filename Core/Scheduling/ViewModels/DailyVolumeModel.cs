using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class DailyVolumeModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventCode { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Corporate Sponsor")]
        public string CorporateAccount { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Zip { get; set; }
        
        [DisplayName("Total Slots")]
        public int TotalSlots { get; set; }

        [DisplayName("Vacant Slots")]
        public int VacantSlots { get; set; }

        [DisplayName("Available Slots")]
        [Hidden]
        public int AvailableSlots { get; set; }

        [DisplayName("Slots Booked")]
        public int SlotsBooked { get; set; }

        [DisplayName("Same-Day Cancels")]
        public int SameDayCancels { get; set; }

        [DisplayName("Same-Day Reschedules")]
        public int SameDayReschedules { get; set; }

        [DisplayName("Patients Booked")]
        public int PatientsBooked { get; set; }

        [DisplayName("No Show(s)")]
        public int CustomersNoShow { get; set; }

        [DisplayName("Patient Left(s)")]
        public int PatientLeft { get; set; }

        [DisplayName("Attended Cust.")]
        public int CustomersAttended { get; set; }

    }
}