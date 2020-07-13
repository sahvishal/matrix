using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
     [DefaultImplementation(Interface = typeof(IValidator<ProfileEditModel>))]
    public class ProfileEditModelValidator : AbstractValidator<ProfileEditModel>
    {
        private readonly IUserRepository<User> _userRepository;

        public ProfileEditModelValidator(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Password).Length(8, 64).When(x => x.Password != null && x.Password.Length != 0).WithMessage("Between 8-64 char, or leave blank.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("password should match confirm password").When(x=>x.ChangePassword);
            
            RuleFor(x => x.Email).NotNull();
            
            RuleFor(x => x.Email).EmailAddress();
            
            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(x.Id,email)).WithMessage("Already in use");

            RuleFor(x => x.FullName).SetValidator(new NameValidator());

            RuleFor(x => x.HomeNumber).SetValidator(new PhoneNumberValidator());
            RuleFor(x => x.OfficeNumber).SetValidator(new PhoneNumberValidator());
            RuleFor(x => x.CellNumber).SetValidator(new PhoneNumberValidator());

            RuleFor(x => x.DateOfBirth).Must(birthDate => birthDate < DateTime.Today)
                .When(x => x.DateOfBirth.HasValue).WithMessage("Birth date should be less than today.") ; //Yasir: dependency on datetime. will not pass unit test maybe we should use ICalendar??

        }

        private bool EmailIsUnique(long excludedUserId, string email)
        {
            return _userRepository.UniqueEmail(excludedUserId, email);
        }
    }
}