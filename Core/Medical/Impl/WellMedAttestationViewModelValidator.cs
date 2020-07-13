using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<WellMedAttestationViewModel>))]
    public class WellMedAttestationViewModelValidator : AbstractValidator<WellMedAttestationViewModel>
    {
        public WellMedAttestationViewModelValidator()
        {
            RuleFor(x => x.DiagnosisCode).NotNull().WithMessage("Diagnosis Code required").NotEmpty().WithMessage("Diagnosis Code required");
            RuleFor(x => x.ReferenceDate).NotNull().WithMessage("Reference Date required").NotEmpty().WithMessage("Reference Date required");
            RuleFor(x => x.ProviderSignatureImage).NotNull().WithMessage("Signature image required").NotEmpty().WithMessage("Signature image required");
            RuleFor(x => x.ProviderSignatureImage.Caption).NotNull().WithMessage("Signature image required").NotEmpty().WithMessage("Signature image required").When(x => x.ProviderSignatureImage != null);
            RuleFor(x => x.FullPrintedName).NotNull().WithMessage("Full Printed Name required").NotEmpty().WithMessage("Full Printed Name required");
            RuleFor(x => x.StatusId).NotNull().WithMessage("Status required").NotEmpty().WithMessage("Status required");
            RuleFor(x => x.DiagnosisDate).NotNull().WithMessage("Date required").NotEmpty().WithMessage("Date required");
          
        }
    }
}
