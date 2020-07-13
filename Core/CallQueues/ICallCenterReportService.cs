using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallCenterReportService
    {
        ListModelBase<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter> GetHealthPlanCallQueueReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<AgentConversionReportViewModel, AgentConversionReportFilter> GetAgentConversionReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}