using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class EventStaffBasicInfoModelValidator : AbstractValidator<EventStaffBasicInfoModel>
    {
        public EventStaffBasicInfoModelValidator()
        {
            //RuleFor(x => x.ScheduledStaffOrgRoleUserId).GreaterThan(0).WithMessage("required");
        }
    }
}