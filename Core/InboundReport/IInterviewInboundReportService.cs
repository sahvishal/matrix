using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;

namespace Falcon.App.Core.InboundReport
{
    public interface IInterviewInboundReportService
    {
        ListModelBase<InterviewInboundViewModel, InterviewInboundFilter> GetInterviewInboundReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
