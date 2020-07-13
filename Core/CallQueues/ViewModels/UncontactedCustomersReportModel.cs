using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class UncontactedCustomersReportModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTag { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Is Eligible")]
        public string IsEligible { get; set; }
    }
}
