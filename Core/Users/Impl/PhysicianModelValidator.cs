using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Falcon.App.Core.Users.Impl
{
    public class PhysicianModelValidator : AbstractValidator<PhysicianModel>
    {
        private readonly IPhysicianRepository _physicianRepository;

        public PhysicianModelValidator(IPhysicianRepository physicianRepository)
        {
            _physicianRepository = physicianRepository;

            RuleFor(x => x.SpecializationId).NotNull().NotEmpty().GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.PermittedTests).NotNull().WithMessage("Atleast one test needs to be selected.");
            //RuleFor(x => x.AssignedPodIds).NotNull().WithMessage("Atleast one pod needs to be selected.");
            //RuleFor(x => x.StandardRate).GreaterThan(0).WithMessage("(should be greater than zero)");
            //RuleFor(x => x.OverReadRate).GreaterThan(0).WithMessage("(should be greater than zero)");
            RuleFor(x => x.Licenses).NotNull().WithMessage("Atleast one lincense requird.");
            RuleFor(x => x.SignatureFile).SetValidator(new FileValidator_ForRequired()).When(x => x.SignatureFile.Id < 1);

            RuleFor(x => x.IsDefault).Must((x, isDefault) => IsDefaultPhysicianAssigned(x.Licenses, x.PhysicianId))
                .When(x => x.IsDefault && x.Licenses != null && x.Licenses.Count() > 0)
                .WithMessage("(already assigned.)");
        }
        public override FluentValidation.Results.ValidationResult Validate(PhysicianModel instance)
        {
            if (instance != null)
                return base.Validate(instance);
            return new ValidationResult();
        }

        private bool IsDefaultPhysicianAssigned(IEnumerable<PhysicianLicenseModel> licenses, long physicianId)
        {
            var stateIds = licenses.Select(l => l.StateId).ToList();
            return !_physicianRepository.IsDefaultPhysicianAssignedForStates(stateIds, physicianId);
        }
    }
}
