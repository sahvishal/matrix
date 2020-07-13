using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class GiftCertificateReportListModel : ListModelBase<GiftCertificateReportViewModel, GiftCertificateReportFilter>
    {
        public override IEnumerable<GiftCertificateReportViewModel> Collection { get; set; }

        public override GiftCertificateReportFilter Filter { get; set; }
    }
}
