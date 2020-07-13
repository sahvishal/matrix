using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class EventVoulmeListModelFilterValidator : AbstractValidator<EventVolumeListModelFilter>
    {
        public EventVoulmeListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue); 
        }
    }
}