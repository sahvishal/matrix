using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IConfirmationReportingService
    {
        ListModelBase<ConfirmationReportViewModel, ConfirmationReportFilter> GetConfirmationReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
