using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<InsurancePayment>))]
    public class InsurancePaymentValidator : AbstractValidator<InsurancePayment>
    {
        public InsurancePaymentValidator()
        {
            RuleFor(x => x.AmountToBePaid).GreaterThan(0).WithMessage("Insurance amount with value 0 is invalid!");
        }
    }
}
