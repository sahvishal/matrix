using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    [NoValidationRequired]
    public class MergeCustomerEditModel : ViewModelBase
    {
        public string UploadCsvMediaUrl { get; set; }
    }
}
