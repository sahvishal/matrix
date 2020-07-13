using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PriorityInQueueEditModel>))]
    public class PriorityInQueueEditModelValidator : AbstractValidator<PriorityInQueueEditModel>
    {
        public PriorityInQueueEditModelValidator()
        {
            RuleFor(x => x.EventCustomerResultId).NotNull().WithMessage("Required");
            RuleFor(x => x.Note).NotNull().WithMessage("Required");
        }
    }
}
