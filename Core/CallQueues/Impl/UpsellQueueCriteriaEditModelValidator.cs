using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<UpsellQueueCriteriaEditModel>))]
    public class UpsellQueueCriteriaEditModelValidator : AbstractValidator<UpsellQueueCriteriaEditModel>
    {
        public UpsellQueueCriteriaEditModelValidator()
        {
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.NoOfDays).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.Amount).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
        }
    }
}
