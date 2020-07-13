using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<MarketingSourceEditModel>))]
    public class MarketingSourceEditModelValidator : AbstractValidator<MarketingSourceEditModel>
    {
        public MarketingSourceEditModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("required").Length(4, 100).WithMessage("4 - 100 Chars");
        }
    }
}