using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class CorporateAccountListModelFilterValidator: AbstractValidator<CorporateAccountListModelFilter>
    {
        public CorporateAccountListModelFilterValidator()
        {
            RuleFor(x => x.Name).Length(2, 50).When(x => !string.IsNullOrEmpty(x.Name));
        }
    }
}