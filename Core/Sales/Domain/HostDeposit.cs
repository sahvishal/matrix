using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostDeposit : HostPayment
    {
        public DepositType DepositApplicablityMode { get; set; }
        public int? DepositFullRefundDueDays { get; set; }

    }
}