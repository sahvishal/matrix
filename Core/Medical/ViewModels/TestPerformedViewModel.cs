using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestPerformedViewModel : ViewModelBase
    {
        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("TechnicianName")]
        public string TechnicianName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("EventDate")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Pod")]
        public string PodName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Date Of Birth")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string HICN { get; set; }

        [DisplayName("Test Performed")]
        public string TestName { get; set; }

        [DisplayName("Pre-Approved Test")]
        public string IsPreApprovedTest { get; set; }

        [DisplayName("Is Billable To Health Plan")]
        public string IsBillableToHealthPlan { get; set; }

        [DisplayName("Physician")]
        public string Physician { get; set; }

        [DisplayName("Over Read Physician")]
        public string OverReadPhysician { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Additional Fields")]
        public IEnumerable<OrderedPair<string, string>> AdditionalFields { get; set; }

        [DisplayName("Is PDF Generated")]
        public string IsPdfGenerated { get; set; }

        [DisplayName("Is Retest")]
        public string IsRetest { get; set; }

        [DisplayName("Is Override")]
        public string IsOverride { get; set; }
    }
}
