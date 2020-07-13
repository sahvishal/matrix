using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHourlyOutreachReportingService
    {
        ListModelBase<HourlyOutreachCallReportModel, HourlyOutreachCallReportModelFilter> GetOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}