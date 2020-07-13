using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallSkippedReportService
    {
        ListModelBase<CallSkippedReportViewModel, CallSkippedReportFilter> GetCallSkippedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
