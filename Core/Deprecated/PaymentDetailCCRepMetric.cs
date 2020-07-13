using System;

namespace Falcon.App.Core.Deprecated
{
    public class PaymentDetailCCRepMetric
    {
        public long EventCustomerId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPrePaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
