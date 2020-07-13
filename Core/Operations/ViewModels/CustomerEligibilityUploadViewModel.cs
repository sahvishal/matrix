using System.ComponentModel;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CustomerEligibilityUploadViewModel
    {
        [DisplayName("HIP Customer ID")]
        public string CustomerId { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("Aces ID")]
        public string AcesId { get; set; }

        public string Eligibility { get; set; }

        [DisplayName("Eligibility Year")]
        public string EligibilityYear { get; set; }

        public string DNC { get; set; }

        public string Error { get; set; }
    }
}
