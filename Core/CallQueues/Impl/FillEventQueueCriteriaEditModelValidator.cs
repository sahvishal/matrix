using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<FillEventQueueCriteriaEditModel>))]
    public class FillEventQueueCriteriaEditModelValidator : AbstractValidator<FillEventQueueCriteriaEditModel>
    {
        public FillEventQueueCriteriaEditModelValidator()
        {
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.NoOfDays).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.Percentage).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must((x, y) => y > 0 && y < 100).WithMessage("must be between 0 and 100");
        }
    }
}
