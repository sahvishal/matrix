using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Communication.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CustomEventNotificationEditModel>))]
    public class CustomEventNotificationEditModelValidator : AbstractValidator<CustomEventNotificationEditModel>
    {
        public CustomEventNotificationEditModelValidator()
        {
            RuleFor(x => x.Message).NotNull().WithMessage("Message required").NotEmpty().WithMessage("Message required");
        }
    }
}
