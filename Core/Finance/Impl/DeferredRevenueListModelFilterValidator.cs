using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
     [DefaultImplementation(Interface = typeof(IValidator<DeferredRevenueListModelFilter>))]
    public class DeferredRevenueListModelFilterValidator : AbstractValidator<DeferredRevenueListModelFilter>
    {
         public DeferredRevenueListModelFilterValidator()
         {
             RuleFor(x => x.FromEventDate.Value).LessThanOrEqualTo(x => x.ToEventDate.Value).When(
                x => x.FromEventDate.HasValue && x.ToEventDate.HasValue).WithMessage("From date should be less To date");

             //RuleFor(x => x.DateType).GreaterThan(0).When(x => x.FromEventDate.HasValue || x.ToEventDate.HasValue)
             //    .WithMessage("Select date type");

             //RuleFor(x => x.DateType).LessThanOrEqualTo(0).When(x => !x.FromEventDate.HasValue && !x.ToEventDate.HasValue)
             //    .WithMessage("Enter date");
         }
    }
}
