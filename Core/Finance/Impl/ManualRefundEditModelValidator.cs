using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ManualRefundEditModel>))]
    public class ManualRefundEditModelValidator : AbstractValidator<ManualRefundEditModel>
    {
        public ManualRefundEditModelValidator()
        {
            RuleFor(x => x.AmountToRefund).GreaterThan(0).WithMessage("Amount cannot be zero.");
            //RuleFor(x => x.AmountToRefund).LessThanOrEqualTo(x => x.Order.TotalAmountPaid - x.TotalRefundRequestAmount).
            //    WithMessage("Amount can not be greater than $");
        }
    }
}
