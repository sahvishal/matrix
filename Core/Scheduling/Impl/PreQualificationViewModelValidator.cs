using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PreQualificationViewModel>))]
    public class PreQualificationViewModelValidator : AbstractValidator<PreQualificationViewModel>
    {
        public PreQualificationViewModelValidator()
        {
            RuleFor(x => x.Dob).NotNull().NotEmpty();
            RuleFor(x => x.Gender).NotNull().NotEmpty();
            RuleFor(x => x.Guid).NotNull().WithMessage("required");
        }
    }
}
