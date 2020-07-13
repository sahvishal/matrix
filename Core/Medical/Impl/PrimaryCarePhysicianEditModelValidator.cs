using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PrimaryCarePhysicianEditModel>))]
    public class PrimaryCarePhysicianEditModelValidator : AbstractValidator<PrimaryCarePhysicianEditModel>
    {
        public PrimaryCarePhysicianEditModelValidator()
        {
            RuleFor(x => x.FullName.FirstName)
                .NotNull().WithMessage("Physician First Name required")
                .NotEmpty().WithMessage("Physician First Name required")
                .Length(2, 50).WithMessage("Physician First Name should be between 2-50 characters");

            RuleFor(x => x.FullName.LastName)
                .NotNull().WithMessage("Physician Last Name required")
                .NotEmpty().WithMessage("Physician Last Name required")
                .Length(2, 50).WithMessage("Physician Last Name should be between 2-50 characters");

            RuleFor(x => x.FullName.FirstName).Must((x, firstName) => firstName != x.FullName.LastName).When(x => x.FullName.LastName != null)
                .WithMessage("Physician First Name and Physician Last Name Cannot be the same");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email").When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Address).SetValidator(new AddressEditModelValidator()).When(x => x.Address != null && !x.Address.IsEmpty());

            RuleFor(x => x.PhoneNumber).SetValidator(new PhoneNumberValidator());

            RuleFor(x => x.MailingAddress).SetValidator(new AddressEditModelValidator()).When(x => !x.HasSameAddress);
        }
    }
}
