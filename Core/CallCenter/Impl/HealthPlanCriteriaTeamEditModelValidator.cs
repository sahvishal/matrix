using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallCenter.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanCriteriaTeamEditModel>))]
    public class HealthPlanCriteriaTeamEditModelValidator : AbstractValidator<HealthPlanCriteriaTeamEditModel>
    {
        private readonly IHealthPlanCriteriaTeamAssignmentRepository _healthPlanCriteriaTeamAssignmentRepository;

        public HealthPlanCriteriaTeamEditModelValidator(IHealthPlanCriteriaTeamAssignmentRepository healthPlanCriteriaTeamAssignmentRepository)
        {
            _healthPlanCriteriaTeamAssignmentRepository = healthPlanCriteriaTeamAssignmentRepository;
            RuleFor(x => x.Id).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must((x, y) => y >= DateTime.Today).WithMessage("Future date required").When(x => x.IsStartDateEditable && x.IsEdited);
            RuleFor(x => x.EndDate).Must((x, enddate) => (enddate == null) || (enddate.Value >= DateTime.Today && enddate.Value >= x.StartDate)).WithMessage("Future date required").Must((x, y) => IsTeamDateOverLaped(x)).WithMessage("Overlapping date with another criteria").When(x => x.IsEdited);

        }

        private bool IsTeamDateOverLaped(HealthPlanCriteriaTeamEditModel model)
        {
            if (model.IsFillEventCallQueue)
            {
                return _healthPlanCriteriaTeamAssignmentRepository.IsTeamOverlapped(model);
            }

            return true;
        }

    }
}
