using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<MolinaAttestationViewModel>))]
    public class MolinaAttestationViewModelValidator : AbstractValidator<MolinaAttestationViewModel>
    {
        public MolinaAttestationViewModelValidator()
        {
            RuleFor(x => x.Icd9Code).Must(CheckIfNothingFilled).WithMessage("Please enter atleast one value or else remove the panel.");
            RuleFor(x => x.WhyNoDiagnosis)
                .NotEmpty().WithMessage("Please enter explanation of why diagnosis cannot be made.")
                .NotNull().WithMessage("Please enter explanation of why diagnosis cannot be made.")
                .When(x => x.StatusId == (int)MolinaAttestationStatus.UnabletodetermineDiagnosis);
            RuleFor(x => x.DateResolved).Must((x,y)=> y.HasValue && y.Value != DateTime.MinValue).When(x => x.StatusId == (int)MolinaAttestationStatus.Resolved)
                .WithMessage("Please enter date resolved.");

        }

        private static bool CheckIfNothingFilled(MolinaAttestationViewModel model,string code)
        {
            if (string.IsNullOrEmpty(model.Icd9Code) && string.IsNullOrEmpty(model.Icd9CodeDescription) &&
                string.IsNullOrEmpty(model.Icd10Code)
                && string.IsNullOrEmpty(model.Icd10CodeDescription) && string.IsNullOrEmpty(model.Condition) &&
                model.StatusId == 0)
            {
                return false;
            }
            return true;
        }
    }
}
