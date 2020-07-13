using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class CheckValidationRuleFactory : IValidationRuleFactory<Check>
    {
        private readonly IValidator<PaymentInstrument> _validator;

        public CheckValidationRuleFactory()
            : this (new Validator<PaymentInstrument>(new PaymentInstrumentValidationRuleFactory()))
        {}

        public CheckValidationRuleFactory(IValidator<PaymentInstrument> validator)
        {
            _validator = validator;
        }

        public List<IValidationRule<Check>> CreateValidationRules()
        {
            return new List<IValidationRule<Check>>
            {
                new StringLengthMustBeInRangeRule<Check>(c => c.PayableTo, "Payable To", 1),
                new InheritedObjectMustBeValidRule<Check, PaymentInstrument>(_validator)
            };
        }
    }
}