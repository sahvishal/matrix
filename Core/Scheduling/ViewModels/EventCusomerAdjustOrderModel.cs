using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCusomerAdjustOrderViewModel
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Pre-Approved Tests Not In Order")]
        public string PreApprovedTestsToAdjust { get; set; }

        [DisplayName("Pre-Approved Package Not In Order")]
        public string PreApprovedPackageToAdjust { get; set; }
    }
}