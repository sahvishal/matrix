using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<AccountCoordinatorProfileModel>))]
    public class AccountCoordinatorProfileModelValidator : AbstractValidator<AccountCoordinatorProfileModel>
    {
        public AccountCoordinatorProfileModelValidator()
        {

        }
    }
}
