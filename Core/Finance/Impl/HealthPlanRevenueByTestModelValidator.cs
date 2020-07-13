using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanRevenueByTestModel>))]
    public class HealthPlanRevenueByTestModelValidator : AbstractValidator<HealthPlanRevenueByTestModel>
    {
        public HealthPlanRevenueByTestModelValidator()
        {
            RuleFor(x => x.TestId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("must not be less than 0");
        }
    }
}