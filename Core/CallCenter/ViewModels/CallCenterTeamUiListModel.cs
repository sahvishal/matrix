using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallCenterTeamUiListModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
