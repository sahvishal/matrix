using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HospitalFacilityEditModel>))]
    public class HospitalFacilityEditModelValidator : AbstractValidator<HospitalFacilityEditModel>
    {
        public HospitalFacilityEditModelValidator()
        {
            RuleFor(x => x.ContractId).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.OrganizationEditModel).SetValidator(new OrganizationEditModelValidator());
            RuleFor(x => x.HospitalPartnerId).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
        }
    }
}
