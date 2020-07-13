using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class MailRoundCustomersReportViewModel : ViewModelBase
    {
        public long CustomerID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DOB { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Tag { get; set; }

        [DisplayName("CustomTag(s)")]
        public string CustomTags { get; set; }

        [DisplayName("# of Outbound Calls")]
        public int TotalOutboundCallCount { get; set; }

        [DisplayName("# of Direct Mails")]
        public int TotalDirectMailCount { get; set; }

        [DisplayName("Latest Disposition")]
        public string Disposition { get; set; }

        [DisplayName("Latest Call Date")]
        //[Format("MM/dd/yyyy")]
        public string LatestCallDate { get; set; }

        [DisplayName("Latest Call Time")]
        //[Format("hh:mm tt")]
        public string LatestCallTime { get; set; }

        [DisplayName("Latest Mail Date")]
        //[Format("MM/dd/yyyy")]
        public string LatestMailDate { get; set; }
    }
}
