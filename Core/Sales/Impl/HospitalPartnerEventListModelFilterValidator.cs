using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Sales.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HospitalPartnerEventListModelFilter>))]
    public class HospitalPartnerEventListModelFilterValidator : AbstractValidator<HospitalPartnerEventListModelFilter>
    {
        public HospitalPartnerEventListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);
        }
    }
}
