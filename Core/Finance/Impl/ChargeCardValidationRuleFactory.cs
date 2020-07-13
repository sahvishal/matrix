using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class ChargeCardValidationRuleFactory : IValidationRuleFactory<ChargeCard>
    {
        public List<IValidationRule<ChargeCard>> CreateValidationRules()
        {
            return new List<IValidationRule<ChargeCard>>
            {
                new StringCannotBeNullOrEmptyRule<ChargeCard>(chargeCard => chargeCard.NameOnCard, "Name on Card"),
                new StringLengthMustBeInRangeRule<ChargeCard>(chargeCard => chargeCard.Number, "Charge Card Number", 15, 16),
                new StringLengthMustBeInRangeRule<ChargeCard>(chargeCard => chargeCard.CVV, "CVV", 3, 4),
                new DateMustBeInRangeRule<ChargeCard>(chargeCard => chargeCard.ExpirationDate, "Expiration Date", DateTime.Today, DateTime.MaxValue, false),
                new DataRecorderMetaDataMustBeValidRule<ChargeCard>(chargeCard => chargeCard.DataRecorderMetaData)
            };
        }
    }
}