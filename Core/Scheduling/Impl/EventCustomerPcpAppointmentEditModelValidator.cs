using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EventCustomerPcpAppointmentEditModel>))]
    public class EventCustomerPcpAppointmentEditModelValidator : AbstractValidator<EventCustomerPcpAppointmentEditModel>
    {
        public EventCustomerPcpAppointmentEditModelValidator(IValidator<PrimaryCarePhysicianEditModel> primaryCarePhysician)
        {
            RuleFor(x => x.AppointmentDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(DateTime.Now).WithMessage("must be future date").When(x => !x.NotAbleToSchedule); ;

            //.Must((model, appointmentDate) =>appointmentDate.HasValue && DateMustbeAfterNumberOfDays(appointmentDate.Value, model.BookAfterNumberOfDays)).WithMessage(string.Format("provide valid date")).When(x => x.AppointmentDate.HasValue || !string.IsNullOrEmpty(x.AppointmentTime))

            RuleFor(x => x.AppointmentTime).NotEmpty().WithMessage("required").NotNull().WithMessage("required").When(x => x.AppointmentDate.HasValue).When(x => !x.NotAbleToSchedule);

            RuleFor(x => x.AppointmentDateTime).Must((x, appointmentDateTime) => appointmentDateTime >= DateTime.Now).WithMessage("must have a valid date time").When(x => x.AppointmentDate.HasValue && !string.IsNullOrEmpty(x.AppointmentTime)).When(x => !x.NotAbleToSchedule);

            RuleFor(x => x.DispositionId).Must((x, dispositionId) => dispositionId > 0).WithMessage("required").When(x => x.NotAbleToSchedule);

            RuleFor(x => x.Pcp).SetValidator(primaryCarePhysician);
        }

        private bool DateMustbeAfterNumberOfDays(DateTime appointmentTime, int numberofDays)
        {
            return DateTime.Now.Date.AddDays(numberofDays) < appointmentTime.Date;
        }
    }
}