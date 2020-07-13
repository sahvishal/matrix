using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ProspectCustomerListModelFilter>))]
    public class ProspectCustomerListModelFilterValidator: AbstractValidator<ProspectCustomerListModelFilter>
    {
        public ProspectCustomerListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue).WithMessage("From date should be less To date");

            RuleFor(x => x.DateType).GreaterThan(0).When(x => x.FromDate.HasValue || x.ToDate.HasValue)
                .WithMessage("Select date type");

            RuleFor(x => x.DateType).LessThanOrEqualTo(0).When(x => !x.FromDate.HasValue && !x.ToDate.HasValue)
                .WithMessage("Enter date");
        }
    }
}