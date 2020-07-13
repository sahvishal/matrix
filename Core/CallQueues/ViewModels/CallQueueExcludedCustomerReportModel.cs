
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.ValueTypes;
using System;
using System.ComponentModel;
namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueExcludedCustomerReportModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public Name Name { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTags { get; set; } 

        [DisplayName("Reason")]
        public string Reason { get; set; }                         
    }
}
