
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IExportableReportsQueueService
    {
        ExportableReportsQueue SaveExportableReportsQueue(object filter, long reportId, long requestedBy);
        ListModelBase<ExportableReportsQueueViewModel, ExportableReportsQueueFilter> GetExportableReportQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
