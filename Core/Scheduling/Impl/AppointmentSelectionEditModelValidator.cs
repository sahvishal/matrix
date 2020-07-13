using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<AppointmentSelectionEditModel>))]
    public class AppointmentSelectionEditModelValidator : AbstractValidator<AppointmentSelectionEditModel>
    {
        public AppointmentSelectionEditModelValidator()
        {
            RuleFor(m => m.SelectedAppointmentIds).NotNull().NotEmpty().WithMessage("Please select an Appointment.");
        }
    }
}