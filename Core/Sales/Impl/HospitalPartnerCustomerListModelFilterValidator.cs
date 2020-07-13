using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Sales.Impl
{
    public class HospitalPartnerCustomerListModelFilterValidator:AbstractValidator<HospitalPartnerCustomerListModelFilter>
    {
        public HospitalPartnerCustomerListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);

            RuleFor(x => x.DateType).GreaterThan(0).When(x => x.FromDate.HasValue || x.ToDate.HasValue)
                .WithMessage("Select date type");

            RuleFor(x => x.DateType).LessThanOrEqualTo(0).When(x => !x.FromDate.HasValue && !x.ToDate.HasValue)
                .WithMessage("Enter date");
        }
    }
}
