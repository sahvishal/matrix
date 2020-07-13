using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ECheckPaymentEditModel>))]
    public class ECheckPaymentEditModelValidator : AbstractValidator<ECheckPaymentEditModel>
    {
        public ECheckPaymentEditModelValidator()
        {
            RuleFor(x => x.ECheckPayment).NotNull().NotEmpty().WithMessage("Amount information on a ECHeck is required.");
            RuleFor(x => x.ECheck).NotNull().NotEmpty().WithMessage("ECheck Informtaion for the transaction is required.");
            RuleFor(x => x.ECheck).SetValidator(new CheckValidator());
            RuleFor(x => x.ECheckPayment).SetValidator(new ECheckPaymentValidator());
        }
    }
}