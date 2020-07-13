using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestNotPerformedViewModel : ViewModelBase
    {
        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("Technician Name")]
        public string TechnicianName { get; set; }

        [DisplayName("Provider Name")]
        public string ProviderName { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Pod")]
        public string PodName { get; set; }

        [DisplayName("Test Not Performed")]
        public string TestName { get; set; }

        [DisplayName("Reason")]
        public string Reason { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        [DisplayName("Pre-Approved Test")]
        public string IsPreApprovedTest { get; set; }

        [DisplayName("Is Override")]
        public string IsOverride { get; set; }
    }
}