using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PreQualifiedQuestionEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public bool IsSelected { get; set; }
    }
}
