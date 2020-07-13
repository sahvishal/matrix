using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<InsurancePaymentEditModel>))]
    public class InsurancePaymentEditModelValidator : AbstractValidator<InsurancePaymentEditModel>
    {
        public InsurancePaymentEditModelValidator()
        {
            RuleFor(x => x.EligibilityId).GreaterThan(0).WithMessage("required.");
            RuleFor(x => x.InsurancePayment).NotNull().WithMessage("required.");
        }
    }
}
