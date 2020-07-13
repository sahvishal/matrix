using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanRevenueByPackageModel>))]
    public class HealthPlanRevenueByPackageModelValidator : AbstractValidator<HealthPlanRevenueByPackageModel>
    {
        public HealthPlanRevenueByPackageModelValidator()
        {
            RuleFor(x => x.PackageId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("must not be less than 0");
        }
    }
}