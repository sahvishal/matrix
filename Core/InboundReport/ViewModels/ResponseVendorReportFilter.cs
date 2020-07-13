using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class ResponseVendorReportFilter : ModelFilterBase
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long AccountId { get; set; }

        public IEnumerable<string> CustomTags { get; set; }
    }
}
