using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class MedicalVendorEditModelValidator : AbstractValidator<MedicalVendorEditModel>
    {
        public MedicalVendorEditModelValidator(IValidator<HospitalPartnerEditModel> hospitalPartnerValidator)
        {
            RuleFor(x => x.MedicalVendorType).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.ContractId).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");

            RuleFor(x => x.OrganizationEditModel).SetValidator(new OrganizationEditModelValidator());
            RuleFor(x => x.HospitalPartnerEditModel).SetValidator(hospitalPartnerValidator).When(
                x => x.IsHospitalPartner);
        }

        
    }

}
