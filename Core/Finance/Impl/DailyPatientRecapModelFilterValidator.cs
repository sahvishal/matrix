using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<DailyPatientRecapModelFilter>))]
    public class DailyPatientRecapModelFilterValidator : AbstractValidator<DailyPatientRecapModelFilter>
    {
        public DailyPatientRecapModelFilterValidator()
        {
            RuleFor(x => x.EventDateFrom).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.EventDateTo).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
        }
    }
}
