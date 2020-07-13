using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PaymentEditModel>))]
    public class PaymentEditModelValidator : AbstractValidator<PaymentEditModel>
    {
        public PaymentEditModelValidator()
        {
            RuleFor(d => d.Amount).Equal(d => d.AmountinProcess)
                .When(d => d.Payments != null && d.Payments.Count() > 0 && d.Payments.Where(p => p.PaymentType != PaymentType.Onsite_Value).Count() > 0)
                .WithMessage("Sum of Partial Payments should be equal to Total Amount.");

        }

    }
}