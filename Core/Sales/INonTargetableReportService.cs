using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface INonTargetableReportService
    {
        ListModelBase<NonTargetableReportModel, NonTargetableReportModelFilter> GetCustomersForNonTargetableService(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
