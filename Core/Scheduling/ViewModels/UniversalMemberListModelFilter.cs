using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class UniversalMemberListModelFilter : ModelFilterBase
    {
        public long AccountId { get; set; }
        public string Tag { get; set; }
    }
}