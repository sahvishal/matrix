using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class EventStaffAssignmentListModelFilterValidator : AbstractValidator<EventStaffAssignmentListModelFilter>
    {
        public EventStaffAssignmentListModelFilterValidator()
        {
            RuleFor(x => x.Month).InclusiveBetween(1, 12).WithMessage("month between: 1-12 only");
            RuleFor(x => x.Year).InclusiveBetween(1990, 2100).WithMessage("1990 - 2100 only");
        } 
    }
}