using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<RefundRequestEditModel>))]
    public class RefundRequestEditModelValidator : AbstractValidator<RefundRequestEditModel>
    {
        public RefundRequestEditModelValidator()
        {
            RuleFor(x => x.RequestedRefundAmount).NotNull().GreaterThan(0).WithMessage("Amount cannot be zero.");
            RuleFor(x => x.Reason).NotNull().NotEmpty().WithMessage("Reason cannot be left empty.").Length(3, 2000).WithMessage("Refund Reasong length is (3 - 2000) chars.");
        }
    }
}