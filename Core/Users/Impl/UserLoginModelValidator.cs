using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().Length(5, 50).WithMessage("Length of email must be between 5- 50 characters");
            RuleFor(x => x.Password).NotNull().NotNull().Length(5, 50).WithMessage("Length of password must be between 5 to 50 characters");

        }
    }
}