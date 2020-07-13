using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class ResponseVendorReportListModel : ListModelBase<ResponseVendorReportViewModel, ResponseVendorReportFilter>
    {
        public override IEnumerable<ResponseVendorReportViewModel> Collection { get; set; }

        public override ResponseVendorReportFilter Filter { get; set; }
    }
}
