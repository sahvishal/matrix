using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanRevenueEditModel>))]
    public class HealthPlanRevenueEditModelValidator : AbstractValidator<HealthPlanRevenueEditModel>
    {
        public HealthPlanRevenueEditModelValidator()
        {
            RuleFor(x => x.HealthPlanId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.DateFrom).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When( x=> x.HealthPlanId > 0 );
            RuleFor(x => x.RevenueItemTypeId).GreaterThan(0).WithMessage("required").When(x => x.HealthPlanId > 0);
            RuleFor(x => x.TestList).NotNull().WithMessage("requied").NotEmpty().WithMessage("requied").When(x => x.RevenueItemTypeId == (long)HealthPlanRevenueType.PerTest);
            RuleFor(x => x.PackageList).NotNull().WithMessage("requied").NotEmpty().WithMessage("requied").When(x => x.RevenueItemTypeId == (long)HealthPlanRevenueType.PerPackage);
            RuleFor(x => x.Customer).NotNull().WithMessage("requied").NotEmpty().WithMessage("requied").When(x => x.RevenueItemTypeId == (long)HealthPlanRevenueType.PerCustomer);
        }
    }
}
