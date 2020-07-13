using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HourlyOutreachReportingService : IHourlyOutreachReportingService
    {
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventBasicInfoListHelper _eventBasicInfoListHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOutreachCallReportListModelFactory _outreachCallReportListModelFactory;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;

        public HourlyOutreachReportingService(ICallCenterCallRepository callCenterCallRepository, ICallQueueRepository callQueueRepository,
            ICustomerRepository customerRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            IEventRepository eventRepository, IEventBasicInfoListHelper eventBasicInfoListHelper, IEventCustomerRepository eventCustomerRepository,
            IAppointmentRepository appointmentRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICallCenterNotesRepository callCenterNotesRepository,
            IShippingDetailRepository shippingDetailRepository, IAddressRepository addressRepository, IOutreachCallReportListModelFactory outreachCallReportListModelFactory,
            ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _callCenterCallRepository = callCenterCallRepository;
            _callQueueRepository = callQueueRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _eventRepository = eventRepository;
            _eventBasicInfoListHelper = eventBasicInfoListHelper;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _addressRepository = addressRepository;
            _outreachCallReportListModelFactory = outreachCallReportListModelFactory;
            _customerEligibilityRepository = customerEligibilityRepository;
        }

        public ListModelBase<HourlyOutreachCallReportModel, HourlyOutreachCallReportModelFilter> GetOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var calls = _callCenterCallRepository.GetOutreachCallQueueCustomer(filter as OutreachCallReportModelFilter, pageNumber, pageSize, out totalRecords);

            if (calls == null || !calls.Any()) return null;

            var customerIds = calls.Select(c => c.CalledCustomerId).ToArray();

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            var callQueueIds = calls.Where(x => x.CallQueueId.HasValue).Select(x => x.CallQueueId.Value).ToArray();

            var callQueues = _callQueueRepository.GetByIds(callQueueIds, false, true);

            var customers = _customerRepository.GetCustomers(customerIds);

            var customerTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            var eventIds = calls.Where(x => x.EventId > 0).Select(x => x.EventId);

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            var organisationRoleIds = calls.Select(c => c.CreatedByOrgRoleUserId).ToArray();

            var callIds = calls.Select(c => c.Id).ToArray();

            EventBasicInfoListModel eventBasicInfoListModel = null;
            List<EventCustomer> eventCusomters = null;
            List<Appointment> appointments = null;
            IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair = null;

            if (events != null)
            {
                eventBasicInfoListModel = _eventBasicInfoListHelper.EventBasicInfoListForCallQueue(events);
            }

            if (events != null && !customerIds.IsNullOrEmpty())
            {
                eventCusomters = _eventCustomerRepository.GetByCustomerIds(customerIds).Where(s => eventIds.Contains(s.EventId)).ToList();
            }

            if (!eventCusomters.IsNullOrEmpty())
            {
                var appointmentIds = eventCusomters.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
                appointments = _appointmentRepository.GetByIds(appointmentIds).ToList();
            }

            if (organisationRoleIds != null && !organisationRoleIds.IsNullOrEmpty())
            {
                registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(organisationRoleIds).ToArray();
            }

            var dispositionNotes = _callCenterNotesRepository.GetByCallIds(callIds.ToArray());

            var orderedPairsCustomersShippingDetails = _shippingDetailRepository.GetShippingDetailsIdCustomerId(customerIds);

            var customersShippingDetails = _shippingDetailRepository.GetShippingDetailsForCustomerIds(customerIds);
            var customerShippingAddressIds = customersShippingDetails.Select(x => x.ShippingAddress.Id).ToList();
            var customerAddress = _addressRepository.GetAddresses(customerShippingAddressIds);

            return _outreachCallReportListModelFactory.CreateHourlyModel(customers, customerTags, calls, eventCusomters, eventBasicInfoListModel, appointments, registeredbyAgentNameIdPair, dispositionNotes, orderedPairsCustomersShippingDetails,
                customersShippingDetails, customerAddress, callQueues, customerEligibilities);
        }
    }
}