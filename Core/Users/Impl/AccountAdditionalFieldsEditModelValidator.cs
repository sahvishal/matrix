using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<AccountAdditionalFieldsEditModel>))]
    public class AccountAdditionalFieldsEditModelValidator : AbstractValidator<AccountAdditionalFieldsEditModel>
    {
        public AccountAdditionalFieldsEditModelValidator()
        {
            RuleFor(x => x.DisplayName).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Length(1, 50).WithMessage("1-200 chars");
        }
    }
}
