using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallCenterTeamService
    {
        CallCenterTeamEditModel GetCallCenterTeamEditModel(long teamId);
        ListModelBase<CallCenterTeamViewModel, CallCenterTeamListModelFilter> GetCallCenterTeams(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
