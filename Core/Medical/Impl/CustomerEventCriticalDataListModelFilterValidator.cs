using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CustomerEventCriticalDataListModelFilter>))]
    public class CustomerEventCriticalDataListModelFilterValidator : AbstractValidator<CustomerEventCriticalDataListModelFilter>
    {
        public CustomerEventCriticalDataListModelFilterValidator()
        {}
    }
}
