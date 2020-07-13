using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SetupViewModel>))]
    public class SetupViewModelValidator : AbstractValidator<SetupViewModel>
    {
        private readonly IUserRepository<User> _userRepository;
        public SetupViewModelValidator(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Email).EmailAddress().When(x => x.UseEmail).NotEmpty().When(x => x.UseEmail);
            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email, x.UserLoginId)).WithMessage("Already in use").When(x => x.UseEmail);
            RuleFor(x => x.PhoneCell).NotEmpty().When(x => x.UseSms);
            RuleFor(x => x.Pin).NotEmpty().When(x => x.IsPinRequired);
        }
        private bool EmailIsUnique(string email, long exlcudedUserId)
        {
            return exlcudedUserId == 0
                       ? _userRepository.UniqueEmail(email)
                       : _userRepository.UniqueEmail(exlcudedUserId, email);
        }
    }
}
