using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class PaymentInstrumentValidationRuleFactory : IValidationRuleFactory<PaymentInstrument>
    {
        public List<IValidationRule<PaymentInstrument>> CreateValidationRules()
        {
            return new List<IValidationRule<PaymentInstrument>>
            {
                new CannotBeNullRule<PaymentInstrument, DataRecorderMetaData>(pi => pi.DataRecorderMetaData,
                    "DataRecorderMetaData")
            };
        }
    }
}