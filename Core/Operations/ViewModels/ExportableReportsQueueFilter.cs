using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    [NoValidationRequired]
    public class ExportableReportsQueueFilter : ModelFilterBase
    {
        public long ReportId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long RequestedBy { get; set; }
    }
}
