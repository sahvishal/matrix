using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCustomersReportModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTag { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
    }
}