using Falcon.App.Core.Audit.ViewModel;

namespace Falcon.App.Core.Audit
{
    public interface IActivityLogViewService
    {
        ActivityLogListModel GetList(ActivityLogListFilter filter,int pageNumber,int pageSize,out int total);

        ActivityLoggedModelDetailsViewModel GetModelDetails(string logId);
    }
}
