using System;
using System.Linq;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class UserEditModelValidator : AbstractValidator<UserEditModel>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IUserNpiInfoRepository _userNpiInfoRepository;
        private readonly ISystemUserInfoRepository _systemUserInfoRepository;

        public UserEditModelValidator(IUserRepository<User> userRepository, IValidator<PhysicianModel> physicianValidator, IUserNpiInfoRepository userNpiInfoRepository, ISystemUserInfoRepository systemUserInfoRepository)
        {
            _userRepository = userRepository;
            _userNpiInfoRepository = userNpiInfoRepository;
            _systemUserInfoRepository = systemUserInfoRepository;

            RuleFor(x => x.UserName).NotNull().NotEmpty().Length(5, 100).Matches(@"^[a-zA-Z0-9\@_.]+$");
            //.Matches(@"^\w+(\.\w+)?$");

            RuleFor(x => x.UserName).Must((x, userName) => UserNameIsUnique(userName, x.Id)).WithMessage("Already in use");

            RuleFor(x => x.Password).NotNull().When(x => x.Id < 1).NotEmpty().When(x => x.Id < 1);
            RuleFor(x => x.Password)
                .Length(8, 64)
                .When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage("reqired, 8-64 chars");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("password should match confirm password");

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email, x.Id)).WithMessage("Already in use");

            RuleFor(x => x.FullName).SetValidator(new NameValidator());

            RuleFor(x => x.HomeNumber).SetValidator(new PhoneNumberValidator());
            RuleFor(x => x.OfficeNumber).SetValidator(new PhoneNumberValidator());
            RuleFor(x => x.CellNumber).SetValidator(new PhoneNumberValidator());

            RuleFor(x => x.DateOfBirth).Must(birthDate => birthDate < DateTime.Today)
                .When(x => x.DateOfBirth.HasValue).WithMessage("Birth date should be less than today."); //Yasir: dependency on datetime. will not pass unit test maybe we should use ICalendar??

            RuleFor(x => x.UsersRoles)
                .NotNull().WithMessage("Atleast one role needs to be defined.");
            RuleFor(x => x.UsersRoles).Must(userRoles => (userRoles.Where(ur => ur.IsDefault).Count() == 1))
                .When(x => x.UsersRoles != null).WithMessage("One Default Role Required");

            RuleFor(x => x.Address).SetValidator(new AddressEditModelValidator());
            RuleFor(x => x.PhysicianProfile).SetValidator(physicianValidator);

            RuleFor(x => x.Npi).Length(1, 10).WithMessage("Max NPI length can be 10").Matches(@"^[a-zA-Z0-9\@]+$").WithMessage("Only alphanumerics are allowed.").When(x => !string.IsNullOrEmpty(x.Npi));

            RuleFor(x => x.Credential).Length(1, 20).WithMessage("Max Credential length can be 20").Matches(@"^[a-zA-Z0-9\@\-,.]+$").WithMessage("Only alphanumerics are allowed.").When(x => !string.IsNullOrEmpty(x.Credential));

            RuleFor(x => x.Npi).Must((x, npi) => IsNpiUnique(npi, x.Id)).WithMessage("Npi already in use").When(x => !string.IsNullOrEmpty(x.Npi));

            //RuleFor(x => x.Credential).Must((x, credential) => IsCredentialUnique(credential, x.Id)).WithMessage("Credential already in use").When(x => !string.IsNullOrEmpty(x.Credential));

            RuleFor(x => x.EmployeeId).Length(3, 16).Matches(@"^[a-zA-Z0-9/-]*$");
            RuleFor(x => x.EmployeeId).Must((x, employeeId) => IsEmployeeIdExist(employeeId, x.Id)).WithMessage("Employee Id already in use.");
        }


        private bool UserNameIsUnique(string userName, long excludedUserId)
        {
            return excludedUserId == 0
                       ? !_userRepository.UserNameExists(userName)
                       : !_userRepository.UserNameExists(excludedUserId, userName);
        }

        private bool EmailIsUnique(string email, long exlcudedUserId)
        {
            return exlcudedUserId == 0
                       ? _userRepository.UniqueEmail(email)
                       : _userRepository.UniqueEmail(exlcudedUserId, email);
        }

        private bool IsNpiUnique(string npi, long excludedUserId)
        {
            return !_userNpiInfoRepository.IsNpiExist(npi, excludedUserId);
        }

        private bool IsCredentialUnique(string credential, long excludedUserId)
        {
            return !_userNpiInfoRepository.IsCredentialExist(credential, excludedUserId);
        }

        private bool IsEmployeeIdExist(string employeeId, long userId)
        {
            return !_systemUserInfoRepository.IsEmployeeExist(userId, employeeId);
        }
    }
}
