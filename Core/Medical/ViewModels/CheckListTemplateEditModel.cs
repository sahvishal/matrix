using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CheckListTemplateEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long HealthPlanId { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public CheckListGroupQuestionEditModel[] Questions { get; set; }
        public long Type { get; set; }
    }
}