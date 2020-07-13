using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<RefundRequestListModelFilter>))]
    public class RefundRequestListModelFilterValidator : AbstractValidator<RefundRequestListModelFilter>
    {
        public RefundRequestListModelFilterValidator()
        {
            RuleFor(x => x.CustomerName).Length(3, 200).When(x => !string.IsNullOrEmpty(x.CustomerName)).WithMessage("(3 - 200) chars");
        }
    }
}