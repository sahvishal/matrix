using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class GiftCertificateReportListWellmedModel : ListModelBase<GiftCertificateReportWellmedViewModel, GiftCertificateReportFilter>
    {
        public override IEnumerable<GiftCertificateReportWellmedViewModel> Collection { get; set; }

        public override GiftCertificateReportFilter Filter { get; set; }
    }
}
