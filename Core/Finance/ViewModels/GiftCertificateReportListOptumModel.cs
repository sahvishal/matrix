using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class GiftCertificateReportListOptumModel : ListModelBase<GiftCertificateReportOptumViewModel, GiftCertificateReportFilter>
    {
        public override IEnumerable<GiftCertificateReportOptumViewModel> Collection { get; set; }

        public override GiftCertificateReportFilter Filter { get; set; }
    }
}
