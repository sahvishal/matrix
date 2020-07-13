using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CheckPaymentEditModel>))]
    public class CheckPaymentEditModelValidator : AbstractValidator<CheckPaymentEditModel>
    {
        public CheckPaymentEditModelValidator()
        {
            RuleFor(x => x.CheckPayment).NotNull().NotEmpty().WithMessage("Amount information for the Check is required.");
            RuleFor(x => x.Check).NotNull().NotEmpty().WithMessage("Check Informtaion for the transaction is required.");
            RuleFor(x => x.Check).SetValidator(new CheckValidator());
            RuleFor(x => x.CheckPayment).SetValidator(new CheckPaymentValidator());
        }
    }
}