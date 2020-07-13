using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class UserListModelFilterValidator : AbstractValidator<UserListModelFilter>
    {
        public UserListModelFilterValidator()
        {
            RuleFor(x => x.Keyword).Length(1, 50).When(x => x != null);
        }
    }
}