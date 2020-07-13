using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<TestListModelFilter>))]
    public class TestListModelFilterValidator : AbstractValidator<TestListModelFilter>
    {
        public TestListModelFilterValidator()
        {}
    }
}
