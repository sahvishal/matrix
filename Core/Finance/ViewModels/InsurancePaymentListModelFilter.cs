using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class InsurancePaymentListModelFilter : ModelFilterBase
    {
        public DateTime? EventFrom { get; set; }
        public DateTime? EventTo { get; set; }

        public long EventId { get; set; }

        public int Status { get; set; }
    }
}
