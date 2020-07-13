using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HousecallOutreachReportModel: ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("DoB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip")]
        public string ZipCode { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("Outreach Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachDate { get; set; }

        [DisplayName("Outreach Time")]
        public string OutreachTime { get; set; }

        [DisplayName("Outcome")]
        public string Outcome { get; set; }

        [DisplayName("Disposition")]
        public string Disposition { get; set; }

        [DisplayName("Reason")]
        public string Reason { get; set; }

        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Event Time")]
        [Format("hh:mm tt")]
        public DateTime? EventTime { get; set; }
    }
}
