using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class CheckPaymentValidationRuleFactory : IValidationRuleFactory<CheckPayment>
    {
        private readonly IValidator<Check> _checkValidator;
        private readonly IValidator<PaymentInstrument> _paymentInstrumentValidator;

        public CheckPaymentValidationRuleFactory()
            : this (new Validator<Check>(new CheckValidationRuleFactory()),
                new Validator<PaymentInstrument>(new PaymentInstrumentValidationRuleFactory()))
        {}

        public CheckPaymentValidationRuleFactory(IValidator<Check> checkValidator,
            IValidator<PaymentInstrument> paymentInstrumentValidator)
        {
            _checkValidator = checkValidator;
            _paymentInstrumentValidator = paymentInstrumentValidator;
        }

        public List<IValidationRule<CheckPayment>> CreateValidationRules()
        {
            return new List<IValidationRule<CheckPayment>>
            {
                new ComposedObjectMustBeValidRule<CheckPayment, Check>(checkPayment => checkPayment.Check, _checkValidator),
                new InheritedObjectMustBeValidRule<CheckPayment, PaymentInstrument>(_paymentInstrumentValidator)
            };
        }
    }
}