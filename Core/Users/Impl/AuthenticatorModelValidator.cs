using Falcon.App.Core.Application.Attributes; 
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<AuthenticatorModel>))]
    public class AuthenticatorModelValidator : AbstractValidator<AuthenticatorModel>
    {
        public AuthenticatorModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().When(x=>!x.UseSms);
        }
    }
}
