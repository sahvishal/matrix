using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OnlineSelectedEventEditModel>))]
    public class OnlineSelectedEventEditModelValidator : AbstractValidator<OnlineSelectedEventEditModel>
    {
        public OnlineSelectedEventEditModelValidator()
        {
            //RuleFor(x => x.Guid).NotNull().NotEmpty().WithMessage("required");
            RuleFor(x => x.EventId).NotNull().NotEmpty().WithMessage("required");
        }
    }
}
