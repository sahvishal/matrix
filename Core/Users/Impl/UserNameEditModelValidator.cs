using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<UserNameEditModel>))]
    public class UserNameEditModelValidator : AbstractValidator<UserNameEditModel>
    {
        private readonly IUserRepository<User> _userRepository;

        public UserNameEditModelValidator(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.UserName).NotNull().NotEmpty().Length(5, 20).Matches(@"^\w+(\.\w+)?(\@\w+\.\w+)?(\.\w+)?$");
            RuleFor(x => x.UserName).Must((x, userName) => UserNameIsUnique(userName, x.UserId)).WithMessage("Already in use");
        }

        private bool UserNameIsUnique(string userName, long excludedUserId)
        {
            return excludedUserId == 0
                       ? !_userRepository.UserNameExists(userName)
                       : !_userRepository.UserNameExists(excludedUserId, userName);
        }
    }
}
