using System.Threading.Tasks;
using Falcon.App.Core.Audit.ViewModel;

namespace Falcon.App.Core.Audit
{
    public interface IActivityLogService
    {
        Task LogViewModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false);
        Task LogEditModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false);
        Task LogListModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false);
        Task LogDeleteActivity(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false);
        Task LogFilterModelPair(ActivityLogEditModel activityLogEditModel, dynamic filter, dynamic model, bool fromAPI = false);
        Task LogRelatedModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false);
    }
}
