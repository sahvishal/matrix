using Falcon.App.Core.ValueTypes;
using FluentValidation;

namespace Falcon.App.Core.Application.Impl
{
    public class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .Length(2, 50).WithMessage("between 2-50 charaters")
                .Matches("^[a-zA-Z0-9'\"_][a-zA-Z0-9'\"_.\\s]*[a-zA-Z0-9'\"_.]$").WithMessage("alhpa numeric only");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .Length(2, 50).WithMessage("between 2-50 charaters")
                .Matches("^[a-zA-Z0-9'\"_][a-zA-Z0-9'\"_.\\s]*[a-zA-Z0-9'\"_.]$").WithMessage("alhpa numeric only");

            RuleFor(x => x.FirstName).Must((x, firstName) => firstName != x.LastName).When(x => x.LastName != null)
                .WithMessage("First Name and Last Name Cannot be the same");

            RuleFor(x => x.MiddleName)
                .Length(1, 25).When(x => !string.IsNullOrEmpty(x.MiddleName)).WithMessage("between 1-25 charaters")
                .Matches("^[a-zA-Z0-9'\"_]*[a-zA-Z0-9'\"_.]$").When(x => !string.IsNullOrEmpty(x.MiddleName)).WithMessage("alhpa numeric only");
        }

    }
}