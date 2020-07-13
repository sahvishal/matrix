using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallCenterTeamListModelFilter: ModelFilterBase
    {
        public string Name { get; set; }
    }
}
