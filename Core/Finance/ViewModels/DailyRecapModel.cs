using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyRecapModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Host Location")]
        public string Location { get; set; }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Total Appts.")]
        public int TotalRegistration { get; set; }

        [DisplayName("Attended Cust.")]
        public int CustomersAttended { get; set; }

        [DisplayName("No Show(s)")]
        public int CustomersNoShow { get; set; }

        [DisplayName("Patient Left")]
        public int LeftWithoutScreeningCustomerCount { get; set; }

        [DisplayName("Cancelled")]
        public int CustomersCancelled { get; set; }

        [DisplayName("GC Delivered")]
        public int GiftCertificateDeliveredCount { get; set; }

        [DisplayName("Event Sign Off")]
        public string EventSignOff { get; set; }

        [DisplayName("Revenue")]
        [Format("0.00")]
        public decimal Revenue { get; set; }

        [DisplayName("Avg. Rev/Cust.")]
        [Format("0.00")]
        public decimal AvgRevenue { get; set; }
    }
}
