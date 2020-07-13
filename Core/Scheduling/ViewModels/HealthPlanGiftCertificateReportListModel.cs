using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HealthPlanGiftCertificateReportListModel : ListModelBase<HealthPlanGiftCertificateReportViewModel, HealthPlanGiftCertificateReportFilter>
    {
        public override IEnumerable<HealthPlanGiftCertificateReportViewModel> Collection { get; set; }

        public override HealthPlanGiftCertificateReportFilter Filter { get; set; }
    }
}
