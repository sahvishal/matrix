using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.ViewModels;

namespace Falcon.App.Core.OutboundReport
{
    public interface IDiagnosisReportFactory
    {
        EventCustomerDiagnosis Create(DiagnosisReportViewModel model, long eventCustomerId);
    }
}
