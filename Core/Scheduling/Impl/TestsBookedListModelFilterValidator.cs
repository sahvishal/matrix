using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<TestsBookedListModelFilter>))]
    public class TestsBookedListModelFilterValidator:AbstractValidator<TestsBookedListModelFilter>
    {
        public TestsBookedListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);
             
        }
    }
}