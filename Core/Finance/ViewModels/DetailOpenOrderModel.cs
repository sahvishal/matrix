using System;
using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DetailOpenOrdersModel : ViewModelBase
    {
        //[DisplayName("Hub")]
        //public string Territory { get; set; }
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Host")]
        public string Location { get; set; } // City, StateCode as in report
        
        public string Pod { get; set; }
        
        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        
        [DisplayName("Scheduled Appts")]
        public int ScheduledAppointments { get; set; }

        [DisplayName("Un-serviced Appts")]
        public int UnServicedAppointments { get; set; }

        [DisplayName("No Show Appts")]
        public int NoShowAppointments { get; set; }

        [DisplayName("Cancelled Appts")]
        public int CancelledAppointments { get; set; }

        [DisplayName("Open Order Total")]
        public decimal OpenOrderTotal { get; set; }

        [DisplayName("Outstanding Un serviced Revenue")]
        public decimal OutstandingUnservicedRevenue { get; set; }

        [DisplayName("Outstanding No Show Revenue")]
        public decimal OutstandingNoShowRevenue { get; set; }

        [DisplayName("Outstanding Cancelled Revenue")]
        public decimal OutstandingCancelledRevenue { get; set; }

        [DisplayName("Outstanding Total Revenue")]
        public decimal OutstandingTotalRevenue { get; set; }

        [DisplayName("UnPaid")]
        public decimal UnPaid { get; set; }

        
    }
}
