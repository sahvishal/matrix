using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerEligibilityUploadEditModel : ViewModelBase
    {
        public long CorporateAccountId { get; set; }
        public string SampleCsvMediaUrl { get; set; }
    }
}
