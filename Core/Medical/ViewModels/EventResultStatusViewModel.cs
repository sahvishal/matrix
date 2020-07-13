using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventResultStatusViewModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Info")]
        public string Location { get; set; }

        [DisplayName("Uploaded")]
        public bool Uploaded { get; set; }

        [DisplayName("Parsed")]
        public bool Parsed { get; set; }

        [DisplayName("Missing Results")]
        public int MissingResults { get; set; }

        [DisplayName("UnStable State")]
        public int UnStableState { get; set; }

        [DisplayName("Pre-Audits Pending")]
        public int PreAuditsPending { get; set; }

        [DisplayName("Review Pending")]
        public int ReviewPending { get; set; }

        [DisplayName("Post Audits Pending")]
        public int PostAuditsPending { get; set; }

        [DisplayName("Results Delivered")]
        public int ResultsDelivered { get; set; }

        [DisplayName("Total Screened Customers")]
        public int TotalCustomers { get; set; }

        [DisplayName("Pod")]
        public string PodName { get; set; }
    }
}
