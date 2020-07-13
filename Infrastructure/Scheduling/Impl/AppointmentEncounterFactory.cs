using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{

    [DefaultImplementation]
    public class AppointmentEncounterFactory : IAppointmentEncounterFactory
    {
        public AppointmentEncounterListModel Create(IEnumerable<EventCustomer> evnetEventCustomers, IEnumerable<Customer> customers,
             IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<Appointment> appointments, IEnumerable<Event> eventsCollection)
        {
            var model = new AppointmentEncounterListModel();
            var appointmentEncounterModel = new List<AppointmentEncounterModel>();

            foreach (var eventCustomer in evnetEventCustomers)
            {
                Appointment appointment = null;

                if (eventCustomer.AppointmentId.HasValue)
                    appointment = appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value);


                var eventData = eventsCollection.Single(x => x.Id == eventCustomer.EventId);

                var customer = customers.Single(x => x.CustomerId == eventCustomer.CustomerId);

                PcpAppointment pcpAppointment = null;

                if (!pcpAppointments.IsNullOrEmpty())
                {
                    pcpAppointment = pcpAppointments.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);
                }

                appointmentEncounterModel.Add(new AppointmentEncounterModel
                {
                    CustomerId = eventCustomer.CustomerId,
                    EventId = eventCustomer.EventId,
                    ArrivedStatus = GetStatusCode(eventCustomer, appointment, eventData),
                    ScheduledDate = eventData.EventDate,
                    Hicn = customer.Hicn,
                    Mrn = string.IsNullOrEmpty(customer.Mrn) ? string.Empty : customer.Mrn,
                    PcpAppointmentDate = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null
                });
            }
            model.Collection = appointmentEncounterModel;

            return model;
        }

        private string GetStatusCode(EventCustomer eventCustomer, Appointment appointment, Event eventData)
        {
            if (eventCustomer.NoShow || eventCustomer.LeftWithoutScreeningReasonId.HasValue || (eventData.EventDate < DateTime.Today && (appointment != null && (appointment.CheckInTime == null || appointment.CheckOutTime == null))))
                return "N";

            if (!eventCustomer.AppointmentId.HasValue)
                return "C";

            if (appointment != null && appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue)
                return "A";

            if (eventData.EventDate >= DateTime.Today)
                return "P";

            return string.Empty;
        }
    }



}