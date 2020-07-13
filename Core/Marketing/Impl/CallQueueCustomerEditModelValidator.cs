using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallQueueCustomerEditModel>))]
    public class CallQueueCustomerEditModelValidator : AbstractValidator<CallQueueCustomerEditModel>
    {
        private readonly IUserRepository<User> _userRepository;

        public CallQueueCustomerEditModelValidator(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Required").NotNull().WithMessage("Required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Required").NotNull().WithMessage("Required");
            RuleFor(x => x.CallBackPhoneNumber).NotEmpty().WithMessage("Required").NotNull().WithMessage("Required");
            RuleFor(x => x.DateOfBirth).Must(dob => dob.HasValue).WithMessage("Required").When(x => x.CustomerId > 0);
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Required").NotNull().WithMessage("Required");
            RuleFor(x => x.Gender).Must(gender => gender != (int)Gender.Unspecified).When(x => x.CustomerId > 0).WithMessage("Required");
            RuleFor(x => x.DateOfBirth).Must(birthDate => birthDate < DateTime.Today).When(x => x.DateOfBirth.HasValue).WithMessage("Birth date should be less than today.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Required").NotNull().WithMessage("Required").EmailAddress().When(x => x.CustomerId > 0 && !x.IsHealthPlanQueue);
            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email, x.UserId)).WithMessage("Already in use").When(x => x.CustomerId > 0 && !string.IsNullOrEmpty(x.Email) && x.Email.Trim().Length > 0);
            RuleFor(x => x.Address).SetValidator(new AddressEditModelValidator()).When(x => x.CustomerId > 0);

            RuleFor(x => x.PrimaryCarePhysician).SetValidator(new PrimaryCarePhysicianEditModelValidator()).When(x => x.PrimaryCarePhysician != null);
            RuleFor(x => x.EnableEmail).Must((x, enableEmail) => EmailConsentValidator(enableEmail, x.Email, x.AlternateEmail)).WithMessage("Please enter email as receive email consent is set to Yes.");
        }

        private bool EmailIsUnique(string email, long exlcudedUserId)
        {
            return exlcudedUserId == 0
                       ? _userRepository.UniqueEmail(email)
                       : _userRepository.UniqueEmail(exlcudedUserId, email);
        }

        private bool EmailConsentValidator(bool enableEmail, string email, string otherEmail)
        {
            if (enableEmail && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(otherEmail))
                return false;
            return true;
        }
    }
}