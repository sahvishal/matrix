using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Impl
{
    public class PrePaymentRestrictions : IPrePaymentRestriction
    {
        private readonly ISettings _settings ;
        public PrePaymentRestrictions(ISettings settings)
        {
            _settings = settings;
        }

        public decimal GetAllowedPrepaymentByChargeCard(ChargeCardType chargeCardType, decimal amount)
        {
            var discountPercentage = _settings.PrePayPercentage;

            if (chargeCardType == ChargeCardType.AmericanExpress)
            {
                return decimal.Round(amount*discountPercentage, 2);
            }
            return amount;
        }
    }
}