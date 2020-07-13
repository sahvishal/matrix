using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ChargeCardPaymentEditModel>))]
    public class ChargeCardPaymentEditModelValidator : AbstractValidator<ChargeCardPaymentEditModel>
    {
        public ChargeCardPaymentEditModelValidator()
        {
            RuleFor(x => x.ChargeCardPayment).NotNull().NotEmpty().WithMessage("Amount inofrmation on a Card is required.");
            RuleFor(x => x.ChargeCard).NotNull().NotEmpty().WithMessage("Card Informtaion for the transaction is required.");
            RuleFor(x => x.ChargeCard).SetValidator(new ChargeCardValidator());
            RuleFor(x => x.ChargeCardPayment).SetValidator(new ChargeCardPaymentValidator());
        }
    }
}