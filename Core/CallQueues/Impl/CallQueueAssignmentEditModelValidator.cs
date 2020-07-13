using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;
using Falcon.App.Core.Extensions;
using System;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallQueueAssignmentEditModel>))]
    public class CallQueueAssignmentEditModelValidator : AbstractValidator<CallQueueAssignmentEditModel>
    {
        public CallQueueAssignmentEditModelValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must((model, startDate) => startDate.HasValue && model.StartDate.HasValue && startDate.Value.Date >= DateTime.Today)
                .WithMessage("Start date should be greater than or equal to current date.").When(x => x.StartDate.HasValue && x.IsEdited);

            RuleFor(x => x.EndDate).Must((model, endDate) => endDate.HasValue && model.StartDate.HasValue && endDate.Value.Date >= model.StartDate.Value)
                .WithMessage("End date should be greater than or equal to start date.").When(x => x.EndDate.HasValue);
        }
    }
}
