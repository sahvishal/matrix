using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IGiftCerificateOptumReportService
    {
        ListModelBase<GiftCertificateReportOptumViewModel, GiftCertificateReportFilter> GetGiftCertificateOptumReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}