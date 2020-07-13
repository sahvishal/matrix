using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IMemberResultMailedReportService
    {
        ListModelBase<MemberResultMailedReportViewModel, MemberResultMailedReportFilter> GetMemberResultMailedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}