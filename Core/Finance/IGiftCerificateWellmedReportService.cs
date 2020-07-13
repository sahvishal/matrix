using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IGiftCerificateWellmedReportService
    {
        ListModelBase<GiftCertificateReportWellmedViewModel, GiftCertificateReportFilter> GetGiftCertificateWellmedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}