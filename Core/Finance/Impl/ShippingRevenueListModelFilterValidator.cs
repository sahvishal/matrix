using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ShippingRevenueListModelFilter>))]
    public class ShippingRevenueListModelFilterValidator:AbstractValidator<ShippingRevenueListModelFilter>
    {
        public ShippingRevenueListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);
        }
    }
}
