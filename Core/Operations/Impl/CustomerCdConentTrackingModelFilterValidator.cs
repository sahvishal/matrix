using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CustomerCdConentTrackingModelFilter>))]
    public class CustomerCdConentTrackingModelFilterValidator : AbstractValidator<CustomerCdConentTrackingModelFilter>
    {
        public CustomerCdConentTrackingModelFilterValidator()
        {
            
        }
    }
}
