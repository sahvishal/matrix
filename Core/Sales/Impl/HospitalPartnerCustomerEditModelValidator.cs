using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Sales.Impl
{
    public class HospitalPartnerCustomerEditModelValidator : AbstractValidator<HospitalPartnerCustomerEditModel>
    {
        public HospitalPartnerCustomerEditModelValidator()
        {
            RuleFor(x => x.Status).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.Outcome).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
        }
    }
}
