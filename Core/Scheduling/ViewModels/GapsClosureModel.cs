using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class GapsClosureModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("Healthplan")]
        public string HealthPlan { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }        

        [DisplayName("Pod(s)")]
        public string PodNumber { get; set; }

        [DisplayName("Pre-approved Test")]
        public string PreApprovedTest { get; set; }

        [DisplayName("Test Performed")]
        public string ResultStatus { get; set; }

        [DisplayName("Reason")]
        public string Reason { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }
    }
}
