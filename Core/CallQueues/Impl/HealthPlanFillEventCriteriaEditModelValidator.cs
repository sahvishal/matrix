using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanFillEventCriteriaEditModel>))]
    public class HealthPlanFillEventCriteriaEditModelValidator : AbstractValidator<HealthPlanFillEventCriteriaEditModel>
    {
        public HealthPlanFillEventCriteriaEditModelValidator()
        {
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.NoOfDays).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.HealthPlanId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.Percentage).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
        }
    }
}