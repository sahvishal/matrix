using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class GmsExcludedCustomerViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public Name Name { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTags { get; set; }

        [DisplayName("Reason")]
        public string Reason { get; set; }
    }
}
