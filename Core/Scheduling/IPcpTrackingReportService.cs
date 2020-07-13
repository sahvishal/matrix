using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IPcpTrackingReportService
    {
        ListModelBase<PcpTrackingReportViewModel, PcpTrackingReportFilter> GetPcpTrackingReport(int pageNumber,
            int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
