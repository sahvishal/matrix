using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class PhysicianCustomerAssignmentEditModelValidator : AbstractValidator<PhysicianCustomerAssignmentEditModel>
    {
        private readonly IPhysicianRepository _physicianRepository;

        public PhysicianCustomerAssignmentEditModelValidator(IPhysicianRepository physicianRepository)
        {
            _physicianRepository = physicianRepository;

            RuleFor(x => x.PhysicianId).GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.PhysicianId).Must((x, physicianid) => physicianid != x.OverReadPhysicianId)
                .When(x => x.OverReadPhysicianId.HasValue && x.OverReadPhysicianId.Value > 0)
                .WithMessage("Physician and OverRead Physician can not same");

            RuleFor(x => x.PhysicianId).Must(
                (x, physicianId) => IsValidAssignment(physicianId, x.OverReadPhysicianId, x.EventCustomerId)).WithMessage(
                    "Assigned physicians do not have all tests availed by the customer.");
        }

        private bool IsValidAssignment(long physicianId, long? overReadPhysicianId, long evenCustomerId)
        {
            return _physicianRepository.IsValidPhysicianAssignmentForEventCustomer(physicianId, overReadPhysicianId, evenCustomerId);
        }
    }
}
