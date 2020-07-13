using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CustomerOpenOrderListModelFilter>))]
    public class CustomerOpenOrderListModelFilterValidator : AbstractValidator<CustomerOpenOrderListModelFilter>
    {
        public CustomerOpenOrderListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);
        }
    }
}
