using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Sales.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ContentEditModel>))]
    public class ContentEditModelValidator : AbstractValidator<ContentEditModel>
    {
        public ContentEditModelValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Length(3, 100).
                WithMessage("required, 3-100 chars");

            RuleFor(x => x.Summary).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Length(3, 500).
                WithMessage("required, 3-500 chars");

            RuleFor(x => x.Content).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
        }
    }
}