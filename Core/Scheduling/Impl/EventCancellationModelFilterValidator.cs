using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EventCancellationModelFilter>))]
    public class EventCancellationModelFilterValidator : AbstractValidator<EventCancellationModelFilter>
    {
        public EventCancellationModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).WithMessage("To date must be after from date").When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);
            
        }
    }
}
