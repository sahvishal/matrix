using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(FluentValidation.IValidator<AccountCheckoutPhoneNumberEditModel>))]
    public class AccountCheckoutPhoneNumberEditModelValidator : AbstractValidator<AccountCheckoutPhoneNumberEditModel>
    {
        public AccountCheckoutPhoneNumberEditModelValidator()
        {
            RuleFor(x => x.CheckoutPhoneNumber).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Length(1, 14).WithMessage("1-10 chars");
        }
    }
}
