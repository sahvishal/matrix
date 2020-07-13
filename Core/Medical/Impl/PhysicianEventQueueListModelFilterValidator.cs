using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PhysicianEventQueueListModelFilter>))]
    public class PhysicianEventQueueListModelFilterValidator : AbstractValidator<PhysicianEventQueueListModelFilter>
    {
        public PhysicianEventQueueListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue).WithMessage("From date should be less To date");

            RuleFor(x => x.DateType).GreaterThan(0).When(x => x.FromDate.HasValue || x.ToDate.HasValue)
                .WithMessage("Select date type");
        }
    }
}
