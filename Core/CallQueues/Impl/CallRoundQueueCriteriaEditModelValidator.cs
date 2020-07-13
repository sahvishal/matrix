using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallRoundQueueCriteriaEditModel>))]
    public class CallRoundQueueCriteriaEditModelValidator : AbstractValidator<CallRoundQueueCriteriaEditModel>
    {
        public CallRoundQueueCriteriaEditModelValidator()
        {
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.NoOfDays).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.HealthPlanId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
        }
    }
}