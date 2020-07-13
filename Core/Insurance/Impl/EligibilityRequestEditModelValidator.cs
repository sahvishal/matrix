using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Insurance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EligibilityRequestEditModel>))]
    public class EligibilityRequestEditModelValidator : AbstractValidator<EligibilityRequestEditModel>
    {
        public EligibilityRequestEditModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.LastName).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.MemberId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.InsuranceCompanyId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Dob).NotNull().WithMessage("required");
            RuleFor(x => x.Dob).Must(birthDate => birthDate < DateTime.Today).When(x => x.Dob.HasValue).WithMessage("Birth date should be less than today.");
        }
    }
}
