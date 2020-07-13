using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class GiftCertificateReportFilter : ModelFilterBase
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public string MemberId { get; set; }
        public long HealthPlanId { get; set; }
        public DateTime? EventFrom { get; set; }
        public DateTime? EventTo { get; set; }
        public string Pod { get; set; }
        public string Tag { get; set; }
    }
}
