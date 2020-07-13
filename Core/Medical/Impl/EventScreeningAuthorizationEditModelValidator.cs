using System.Linq;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    public class EventScreeningAuthorizationEditModelValidator : AbstractValidator<EventScreeningAuthorizationEditModel>
    {
        public EventScreeningAuthorizationEditModelValidator()
        {
            RuleFor(x => x.Customers).Must(customers => (customers.Where(c => c.IsAuthorized).Count() > 0))
                .When(x => x.Customers != null).WithMessage("Select atleast one customer to authorize.");
        }
    }
}
