using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class CrosswalkInboundFilter : ModelFilterBase
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long AccountId { get; set; }

        public string Tag { get; set; }

        public string[] CustomTags { get; set; }

        public DateTime? StopSendingPdftoHealthPlanDate { get; set; }
    }
}
