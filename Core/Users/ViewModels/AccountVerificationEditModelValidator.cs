using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Users.ViewModels
{
    [DefaultImplementation(Interface = typeof(IValidator<AccountVerificationEditModel>))]
    public class AccountVerificationEditModelValidator : AbstractValidator<AccountVerificationEditModel>
    {
        public AccountVerificationEditModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .When(x => x.FirstNameVerification);

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .When(x => x.LastNameVerification);

            RuleFor(x => x.DateOfBirth)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .When(x => x.DateOfBirthVerification);

            RuleFor(x => x.CustomerEmail)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required").EmailAddress().WithMessage("invalid email address")
                .When(x => x.CustomerEmailVerification);

            RuleFor(x => x.MemberId)
               .NotNull().WithMessage("required")
               .NotEmpty().WithMessage("required")
               .When(x => x.MemberIdVerification);

            RuleFor(x => x.ZipCode)
               .NotNull().WithMessage("required")
               .NotEmpty().WithMessage("required")
               .When(x => x.ZipCodeVerification);
        }
    }
}