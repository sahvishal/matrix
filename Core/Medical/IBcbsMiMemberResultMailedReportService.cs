using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IBcbsMiMemberResultMailedReportService
    {
        ListModelBase<BcbsMiMemberResultMailedReportViewModel, MemberResultMailedReportFilter> GetBcbsMiMemberResultMailedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}