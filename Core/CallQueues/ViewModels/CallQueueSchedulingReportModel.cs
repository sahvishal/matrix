using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueSchedulingReportModel : ViewModelBase
    {
        [DisplayName("Call Queue")]
        public string CallQueue { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public Name Name { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }
       
        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Call Date")]
        [Format("MM/dd/yyyy")]
        public DateTime CallDate { get; set; }

        [DisplayName("Call Start Time")]
        public string CallTime { get; set; }
        
        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }
        
        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTags { get; set; }

        [DisplayName("Agent Name")]
        public string Agent { get; set; }
    }
}