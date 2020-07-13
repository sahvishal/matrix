using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class EligibilityUploadLogViewModel : ViewModelBase
    {
        [DisplayName("Patient ID")]
        public string CustomerId { get; set; }

        [DisplayName("Eligibility Status")]
        public string IsEligible { get; set; }

        [DisplayName("Eligibility Year")]
        public string ForYear { get; set; }

        [DisplayName("Error Message")]
        public string ErrorMessage { get; set; }
    }
}
