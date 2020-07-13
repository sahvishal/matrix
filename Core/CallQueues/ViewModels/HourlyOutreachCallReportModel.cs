using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HourlyOutreachCallReportModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("Call Queue")]
        public string CallQueue { get; set; }

        [DisplayName("Outreach Type")]
        public string OutreachType { get; set; }

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

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Appointment Time")]
        [Format("MM/dd/yyyy hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Appointment Booked Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? AppointmentBookedDate { get; set; }

        [DisplayName("Sponsored By")]
        public string SponsoredBy { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTags { get; set; }

        [DisplayName("Called Custom Tag(s)")]
        public string CalledCustomTags { get; set; }

        [DisplayName("Agent Name")]
        public string Agent { get; set; }

        [DisplayName("Member State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Is Eligible")]
        public string IsEligible { get; set; }

        [DisplayName("Disposition Notes")]
        public IEnumerable<CallCenterNotes> Notes { get; set; }
    }
}