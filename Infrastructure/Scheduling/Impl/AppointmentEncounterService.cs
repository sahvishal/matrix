using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AppointmentEncounterService : IAppointmentEncounterService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;

        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppointmentEncounterFactory _appointmentEncounterFactory;

        public AppointmentEncounterService(IEventCustomerRepository eventCustomerRepository,
            IPcpAppointmentRepository pcpAppointmentRepository, IAppointmentRepository appointmentRepository,
            IEventRepository eventRepository, ICustomerRepository customerRepository,
            IAppointmentEncounterFactory appointmentEncounterFactory)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _appointmentRepository = appointmentRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _appointmentEncounterFactory = appointmentEncounterFactory;
        }

        public ListModelBase<AppointmentEncounterModel, AppointmentEncounterFilter> GetAppointmentEncounterReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetAppointmentEncounterReport(pageNumber, pageSize, filter as AppointmentEncounterFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return null;
            var customerids = eventCustomers.Select(x => x.CustomerId).Distinct().ToArray();

            var eventCustomerIds = eventCustomers.Select(x => x.Id).ToArray();
            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
            var eventIds = eventCustomers.Select(x => x.EventId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomers(customerids);

            var eventsCollection = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(eventIds);

            var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomerIds);

            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            return _appointmentEncounterFactory.Create(eventCustomers, customers, pcpAppointment, appointments, eventsCollection);
        }
    }
}
