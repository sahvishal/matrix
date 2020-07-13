using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterTeamListModel : ListModelBase<CallCenterTeamViewModel, CallCenterTeamListModelFilter>
    {
        public override IEnumerable<CallCenterTeamViewModel> Collection { get; set; }
        public override CallCenterTeamListModelFilter Filter { get; set; }
    }
}
