using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance
{
    public interface IPrePaymentRestriction
    {
        decimal GetAllowedPrepaymentByChargeCard(ChargeCardType chargeCardType, decimal amount);
    }
}