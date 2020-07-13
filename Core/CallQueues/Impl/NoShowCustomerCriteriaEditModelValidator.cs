using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<NoShowCustomerCriteriaEditModel>))]
    public class NoShowCustomerCriteriaEditModelValidator : AbstractValidator<NoShowCustomerCriteriaEditModel>
    {
        public NoShowCustomerCriteriaEditModelValidator()
        {
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required")
                .Must((model, startDate) => startDate.HasValue && startDate.Value.Date <= DateTime.Now.Date).WithMessage("start date must be past date.");

            RuleFor(x => x.HealthPlanId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.EndDate).Must((model, endDate) => endDate.HasValue && model.StartDate.HasValue &&
                        endDate.Value.Date >= model.StartDate.Value).WithMessage("end date must be greater than start date.")
                        .When(x => x.EndDate.HasValue);
        }
    }
}