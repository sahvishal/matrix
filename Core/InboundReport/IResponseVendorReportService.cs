using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;

namespace Falcon.App.Core.InboundReport
{
    public interface IResponseVendorReportService
    {
        ListModelBase<ResponseVendorReportViewModel, ResponseVendorReportFilter> GetResponseVendorReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
