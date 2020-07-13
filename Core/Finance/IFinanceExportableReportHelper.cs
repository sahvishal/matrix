using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IFinanceExportableReportHelper
    {
        string GiftCerificateExport(GiftCertificateReportFilter filter, long userId);
    }
}