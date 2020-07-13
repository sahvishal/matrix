using Falcon.App.Core.ValueTypes;
using FluentValidation;

namespace Falcon.App.Core.Application.Impl
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.AreaCode)
                .Length(3, 3).WithMessage("3 digits area code")
                .Matches(@"\d\d\d").WithMessage("numbers only")
                .When(x => (!string.IsNullOrEmpty(x.AreaCode) || !string.IsNullOrEmpty(x.Number)));

            RuleFor(x => x.Number).
                Length(3, 10).WithMessage("3-10 digits only")
                .Matches("^[0-9]*$").WithMessage("(numbers only)")
                .When(x => (!string.IsNullOrEmpty(x.Number) || !string.IsNullOrEmpty(x.AreaCode)));
        }
    }

    public class PhoneNumberRequiredValidator : AbstractValidator<PhoneNumber>
    {
        public PhoneNumberRequiredValidator()
        {
            RuleFor(x => x.AreaCode).NotNull().WithMessage("area code required").NotEmpty().WithMessage("area code required")
                .Length(3, 3).WithMessage("3 digits area code")
                .Matches(@"\d\d\d").WithMessage("numbers only");


            RuleFor(x => x.Number).NotNull().WithMessage("number required").NotEmpty().WithMessage("number required")
                .Length(7, 10).WithMessage("7-10 digits only")
                .Matches("^[0-9]*$").WithMessage("(numbers only)").When(x => !string.IsNullOrEmpty(x.AreaCode));
        }
    }

}