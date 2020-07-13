using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanRevenueByCustomerModel>))]
    public class HealthPlanRevenueByCustomerModelValidator : AbstractValidator<HealthPlanRevenueByCustomerModel>
    {
        public HealthPlanRevenueByCustomerModelValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("must not be less than 0");
        }
    }
}