using Falcon.App.Core.Operations.Domain;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class EventStaffAssignmentValidator : AbstractValidator<EventStaffAssignment>
    {
        public EventStaffAssignmentValidator()
        {
            RuleFor(x => x.EventId).NotNull().NotEmpty().GreaterThan(0).WithMessage("EventId Required");
            RuleFor(x => x.PodId).NotNull().NotNull().GreaterThan(0).WithMessage("Pod/Vehicle Required");
            RuleFor(x => x.ScheduledStaffOrgRoleUserId).NotNull().NotEmpty().GreaterThan(0).WithMessage("Staff Assignement Required");
            RuleFor(x => x.StaffEventRoleId).NotNull().NotEmpty().GreaterThan(0).WithMessage("Event Role Required");            
        }
    }
}