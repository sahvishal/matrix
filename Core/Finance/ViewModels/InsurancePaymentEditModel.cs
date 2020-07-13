using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class InsurancePaymentEditModel
    {
        public long EligibilityId { get; set; }
        public decimal CoPayAmount { get; set; }
        public long ChargeCardId { get; set; }

        public InsurancePayment InsurancePayment { get; set; }
    }
}
