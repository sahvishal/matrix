using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OrderPlaceEditModel>))]
    public class OrderPlaceEditModelValidator : AbstractValidator<OrderPlaceEditModel>
    {
        public OrderPlaceEditModelValidator()
        {
            RuleFor(m => m.SelectedPackageId).GreaterThan(0).WithMessage("Please select a Package/Test.").When(m => m.SelectedTestIds == null || m.SelectedTestIds.Count() < 1);
            RuleFor(m => m.SelectedTestIds).NotNull().WithMessage("Please select a Package/Test.").NotEmpty().WithMessage("Please select a Package/Test.").When(m => m.SelectedPackageId == 0);
            RuleFor(m => m.SelectedShippingOptionId).GreaterThanOrEqualTo(0).WithMessage("Please select a shipping option for results");
        }   
    }
}