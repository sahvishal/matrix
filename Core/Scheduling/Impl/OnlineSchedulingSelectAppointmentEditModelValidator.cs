using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OnlineSchedulingSelectAppointmentEditModel>))]
    public class OnlineSchedulingSelectAppointmentEditModelValidator : AbstractValidator<OnlineSchedulingSelectAppointmentEditModel>
    {

    }
}