using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class PhysicianEventAssignmentEditModelValidator : AbstractValidator<PhysicianEventAssignmentEditModel>
    {
        private readonly IPhysicianRepository _physicianRepository;

        public PhysicianEventAssignmentEditModelValidator(IPhysicianRepository physicianRepository)
        {
            _physicianRepository = physicianRepository;

            RuleFor(x => x.PhysicianId).GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.PhysicianId).Must((x, physicianid) => physicianid != x.OverReadPhysicianId)
                .When(x => x.OverReadPhysicianId.HasValue && x.OverReadPhysicianId.Value > 0)
                .WithMessage("Physician and OverRead Physician can not same");

            RuleFor(x=>x.PhysicianId).Must((x,physicianId)=> CheckTestSelected(physicianId, x.EventPhysicianTests))
                .WithMessage("Please select at least one test for Primary Physician").When(x => x.IsEvaluationRestricted);

            RuleFor(x => x.OverReadPhysicianId).Must((x, overReadPhysicianId) => CheckTestSelected(overReadPhysicianId.Value, x.EventPhysicianTests))
                .WithMessage("Please select at least one test for Overread Physician").When(x => x.IsEvaluationRestricted && x.OverReadPhysicianId.HasValue);

            RuleFor(x => x.PhysicianId).Must((x, physicianId) => IsValidAssignment(physicianId, x.OverReadPhysicianId, x.EventId))
                .WithMessage("Assigned physicians do not have all tests of event.").When(x => !x.IsEvaluationRestricted);

            RuleFor(x => x.PhysicianId).Must((x, physicianId) => IsValidEvaluationRestrictedAssignment(physicianId, x.OverReadPhysicianId, x.EventId, x.EventPhysicianTests))
                .WithMessage("Assigned physicians do not have all tests of event.").When(x => x.IsEvaluationRestricted);

        }

        private bool IsValidEvaluationRestrictedAssignment(long physicianId, long? overReadPhysicianId, long eventId, IEnumerable<PhsicianEventTestViewModel> physiciansTests)
        {
            //if User has not selected test;
            var valid = !physiciansTests.IsNullOrEmpty();
            if (!valid) return valid;

            var phsicianEventTestViewModels = physiciansTests as PhsicianEventTestViewModel[] ?? physiciansTests.ToArray();

            //if User test selected but physician done not contains;
            valid = phsicianEventTestViewModels.Any(x => x.PhysicianId == physicianId);
            if (!valid) return valid;

            ////if overread physician selected then test must be selected;
            //valid = !(overReadPhysicianId.HasValue && overReadPhysicianId.Value > 0) || phsicianEventTestViewModels.Any(x => x.PhysicianId == overReadPhysicianId.Value);
            //if (!valid) return valid;

            return _physicianRepository.IsValidPhysicianAssignmentForRestrictedEvaluationOnEvent(eventId, physiciansTests);
        }

        private bool IsValidAssignment(long physicianId, long? overReadPhysicianId, long eventId)
        {
            return _physicianRepository.IsValidPhysicianAssignmentForEvent(physicianId, overReadPhysicianId, eventId);
        }

        private bool CheckTestSelected(long physicianId, IEnumerable<PhsicianEventTestViewModel> physiciansTests)
        {
            if (physicianId > 0)
            {
                if (physiciansTests == null)
                    return false;

                return physiciansTests.Any(pt => pt.PhysicianId == physicianId);
            }
            return true;
        }
    }
}
