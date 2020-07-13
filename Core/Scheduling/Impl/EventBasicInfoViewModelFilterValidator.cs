using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EventBasicInfoViewModelFilter>))]
    public class EventBasicInfoViewModelFilterValidator : AbstractValidator<EventBasicInfoViewModelFilter>
    {
        public EventBasicInfoViewModelFilterValidator()
        {
            RuleFor(x => x.DateFrom.Value).LessThanOrEqualTo(x => x.DateTo.Value).When(
                x => x.DateFrom.HasValue && x.DateTo.HasValue).WithMessage("Date To can not be less than Date From");
        }
    }
}