using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    public class DailyRecapModelFilterValidator : AbstractValidator<DailyRecapModelFilter>
    {
        public DailyRecapModelFilterValidator()
        {
            RuleFor(x => x.EventDateFrom).NotNull();
            RuleFor(x => x.EventDateTo).NotEmpty();
        }
    }
}
