using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentEncounterModel : ViewModelBase
    {
        [DisplayName("Encounter ID")]
        public long CustomerId { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("MRN")]
        public string Mrn { get; set; }

        [DisplayName("Event ID")]
        public long EventId { get; set; }
        
        [DisplayName("Scheduled Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ScheduledDate { get; set; }

        [DisplayName("Arrived Status")]
        public string ArrivedStatus { get; set; }

        [DisplayName("PCP Appointment Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? PcpAppointmentDate { get; set; }
    }
}
