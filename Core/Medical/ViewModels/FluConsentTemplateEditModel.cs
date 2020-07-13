using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class FluConsentTemplateEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public FluConsentQuestionEditModel[] Questions { get; set; }
    }
}