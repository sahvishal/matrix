using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OnlineProductShippingEditModel>))]
    public class OnlineProductShippingEditModelValidator : AbstractValidator<OnlineProductShippingEditModel>
    {
        public OnlineProductShippingEditModelValidator()
        {
            RuleFor(m => m.SelectedShippingOptionId).GreaterThanOrEqualTo(0).WithMessage("Please select a shipping option for results");
        }
    }
}
