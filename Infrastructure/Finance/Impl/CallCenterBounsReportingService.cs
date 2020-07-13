using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class CallCenterBounsReportingService : ICallCenterBounsReportingService
    {
        private readonly IPayPeriodRepository _payPeriodRepository;
        private readonly IPayPeriodCriteriaRepository _payPeriodCriteriaRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IEventReportingService _eventReportingService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPayPeriodBookedCustomerFactory _payPeriodBookedCustomerFactory;
        private readonly ICallCenterBonusReportingFactory _callCenterBonusReportingFactory;

        public CallCenterBounsReportingService(IPayPeriodRepository payPeriodRepository, IPayPeriodCriteriaRepository payPeriodCriteriaRepository, IEventCustomerRepository eventCustomerRepository,
            IAppointmentRepository appointmentRepository, IEventReportingService eventReportingService, ICustomerRepository customerRepository, IOrderRepository orderRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IPayPeriodBookedCustomerFactory payPeriodBookedCustomerFactory, ICallCenterBonusReportingFactory callCenterBonusReportingFactory)
        {
            _payPeriodRepository = payPeriodRepository;
            _payPeriodCriteriaRepository = payPeriodCriteriaRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;

            _eventReportingService = eventReportingService;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _payPeriodBookedCustomerFactory = payPeriodBookedCustomerFactory;
            _callCenterBonusReportingFactory = callCenterBonusReportingFactory;
        }

        public CallCenterBonusListModel GetCallCenterBonus(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callCenterbounsFilter = filter as CallCenterBonusFilter;
            if (callCenterbounsFilter == null || callCenterbounsFilter.PayPeriodId < 1 || string.IsNullOrEmpty(callCenterbounsFilter.PayRange))
            {
                totalRecords = 0;
                return null;
            }

            var payDatesArray = callCenterbounsFilter.PayRange.Split('-');
            callCenterbounsFilter.StartDate = Convert.ToDateTime(payDatesArray[0]);
            callCenterbounsFilter.EndDate = Convert.ToDateTime(payDatesArray[1]);

            var callCenterAgents = _payPeriodRepository.GetIdNamePairofUsersByRoleOrParentRole(callCenterbounsFilter, pageNumber, pageSize, out totalRecords);
            if (callCenterAgents.IsNullOrEmpty()) return null;

            var criterias = _payPeriodCriteriaRepository.GetByPayPeriodId(callCenterbounsFilter.PayPeriodId);

            var totalCalls = _payPeriodRepository.GetTotalCallcount(callCenterbounsFilter, callCenterAgents.Select(x => x.FirstValue));

            var totalBookedAppointment = _payPeriodRepository.GetTotalBookedCustomerCount(callCenterbounsFilter.StartDate.Value, callCenterbounsFilter.EndDate.Value, callCenterAgents.Select(x => x.FirstValue));

            var collection = _callCenterBonusReportingFactory.Create(callCenterAgents, totalCalls, totalBookedAppointment, criterias);

            return new CallCenterBonusListModel { Collection = collection };
        }

        public ListModelBase<PayPeriodBookedCustomerViewModel, PayPeriodBookedCustomerFilter> GetPayPeriodAppointmentBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var payPeriodBookedCustomerFilter = filter != null ? filter as PayPeriodBookedCustomerFilter : new PayPeriodBookedCustomerFilter();
            var eventCustomers = _eventCustomerRepository.GetPayPeriodBookedCustomers(pageNumber, pageSize, payPeriodBookedCustomerFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).Distinct().ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            //var customerIds = customers.Select(x => x.CustomerId);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);

            var eventPackages = _eventPackageRepository.GetbyEventIds(eventIds);
            var eventTests = _eventTestRepository.GetByEventIds(eventIds);

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();
            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var payPeriod = _payPeriodRepository.GetById(payPeriodBookedCustomerFilter.PayPeriodId);
            payPeriodBookedCustomerFilter.EffectiveDate = payPeriod.StartDate;
            payPeriodBookedCustomerFilter.NumberOfWeek = payPeriod.NumberOfWeeks;

            var listModel = _payPeriodBookedCustomerFactory.Create(eventCustomers, appointments, orders, model, customers, eventPackages, eventTests);
            listModel.RegisteredBy = registeredbyAgentNameIdPair.Any() ? registeredbyAgentNameIdPair.First().SecondValue : "";
            listModel.Filter = payPeriodBookedCustomerFilter;
            return listModel;
        }

        public ListModelBase<AppointmentsShowedViewModel, CallCenterBonusFilter> GetAppointmentsShowed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callCenterbounsFilter = filter as CallCenterBonusFilter;
            if (callCenterbounsFilter == null || callCenterbounsFilter.StartDate == null || callCenterbounsFilter.EndDate == null || callCenterbounsFilter.StartDate.Value > callCenterbounsFilter.EndDate.Value)
            {
                totalRecords = 0;
                return null;
            }
            var callCenterAgents = _payPeriodRepository.GetIdNamePairofUsersByRoleOrParentRole(callCenterbounsFilter, pageNumber, pageSize, out totalRecords);

            if (callCenterAgents.IsNullOrEmpty()) return null;

            var agentIds = callCenterAgents.Select(s => s.FirstValue);

            var eventcustomers = _eventCustomerRepository.GetEventCustomerForBonusCalculation(callCenterbounsFilter.StartDate.Value, callCenterbounsFilter.EndDate.Value, agentIds);

            var payPeriodStartDate = eventcustomers.IsNullOrEmpty() ? null : (DateTime?)eventcustomers.OrderBy(x => x.DataRecorderMetaData.DateCreated).Select(x => x.DataRecorderMetaData.DateCreated).FirstOrDefault();
            var payPeriodEndDate = eventcustomers.IsNullOrEmpty() ? null : (DateTime?)eventcustomers.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.DataRecorderMetaData.DateCreated).FirstOrDefault();

            var payPeriods = payPeriodStartDate.HasValue && payPeriodEndDate.HasValue ? _payPeriodRepository.GetPayPeriods(payPeriodStartDate.Value, payPeriodEndDate.Value) : null;
            var payRangesCustomerBooked = new List<PayRangeCustomerBookedViewModel>();

            if (payPeriods != null)
            {
                SetEndDateforPayPeriod(payPeriods);

                foreach (var payPeriod in payPeriods)
                {
                    payRangesCustomerBooked.AddRange(GetPayRange(payPeriod,eventcustomers));
                }

                foreach (var payRange in payRangesCustomerBooked)
                {
                    var customerbookedbyAgents = _payPeriodRepository.GetTotalBookedCustomerCount(payRange.StartDate, payRange.EndDate, agentIds);
                    payRange.CustomerBookedByAgents = customerbookedbyAgents;
                }
            }

            var criterias = payPeriods.IsNullOrEmpty() ? null : _payPeriodCriteriaRepository.GetByPayPeriodId(payPeriods.Select(x => x.Id).ToArray());

            var collection = _callCenterBonusReportingFactory.Create(callCenterAgents, eventcustomers, payPeriods, criterias, payRangesCustomerBooked);

            return new AppointmentsShowedListModel { Collection = collection };
        }

        public ListModelBase<ActualCustomerShowedViewModel, PayPeriodBookedCustomerFilter> GetActualCustomerShowed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var payPeriodBookedCustomerFilter = filter != null ? filter as PayPeriodBookedCustomerFilter : new PayPeriodBookedCustomerFilter();
            var eventcustomers = _eventCustomerRepository.GetActualCustomerShowed(pageNumber, pageSize, payPeriodBookedCustomerFilter, out totalRecords);

            if (eventcustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventcustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var eventIds = eventcustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var model = _eventReportingService.GetEventVolumeModel(eventcustomers.Select(ec => ec.EventId).Distinct().ToArray());
            var customers = _customerRepository.GetCustomers(eventcustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventcustomers.Select(ec => ec.Id).ToArray(), true);

            var eventPackages = _eventPackageRepository.GetbyEventIds(eventIds);
            var eventTests = _eventTestRepository.GetByEventIds(eventIds);

            var orgRoleUserIds = eventcustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();
            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var payPeriodStartDate = (DateTime?)eventcustomers.OrderBy(x => x.DataRecorderMetaData.DateCreated).Select(x => x.DataRecorderMetaData.DateCreated).FirstOrDefault();
            var payPeriodEndDate = eventcustomers.IsNullOrEmpty() ? null : (DateTime?)eventcustomers.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.DataRecorderMetaData.DateCreated).FirstOrDefault();

            var payPeriods = payPeriodStartDate.HasValue && payPeriodEndDate.HasValue ? _payPeriodRepository.GetPayPeriods(payPeriodStartDate.Value, payPeriodEndDate.Value) : null;

            var payRangesCustomerBooked = new List<PayRangeCustomerBookedViewModel>();

            if (payPeriods != null)
            {
                SetEndDateforPayPeriod(payPeriods);

                payPeriods = payPeriods.OrderBy(s => s.StartDate);

                foreach (var payPeriod in payPeriods)
                {
                    payRangesCustomerBooked.AddRange(GetPayRange(payPeriod, eventcustomers));
                }

                foreach (var payRange in payRangesCustomerBooked)
                {
                    var customerbookedbyAgents = _payPeriodRepository.GetPayPeriodBookingCountForAgent(payRange.StartDate, payRange.EndDate, payPeriodBookedCustomerFilter.AgentId);
                    payRange.TotalCustomerBookedByAgent = customerbookedbyAgents;
                }
            }

            var criterias = payPeriods.IsNullOrEmpty() ? null : _payPeriodCriteriaRepository.GetByPayPeriodId(payPeriods.Select(x => x.Id).ToArray());

            var listModel = _payPeriodBookedCustomerFactory.CreateActualCustomerShowed(eventcustomers, appointments, orders, model, customers, eventPackages, eventTests, payPeriods, criterias, payRangesCustomerBooked);

            listModel.RegisteredBy = registeredbyAgentNameIdPair.Any() ? registeredbyAgentNameIdPair.First().SecondValue : "";
            listModel.Filter = payPeriodBookedCustomerFilter;

            return listModel;
        }

        private void SetEndDateforPayPeriod(IEnumerable<PayPeriod> payPeriods)
        {
            if (payPeriods.IsNullOrEmpty()) return;

            payPeriods = payPeriods.OrderBy(x => x.StartDate);

            var lastPayPeriod = _payPeriodRepository.GetNextPublishedPayPeriod(payPeriods.Last().StartDate);

            foreach (var payPeriod in payPeriods)
            {
                var nextPayPeriod = payPeriods.FirstOrDefault(x => x.StartDate > payPeriod.StartDate);
                payPeriod.EndDate = lastPayPeriod == null ? DateTime.Today.AddDays(1) : lastPayPeriod.StartDate;

                if (nextPayPeriod != null)
                    payPeriod.EndDate = nextPayPeriod.StartDate;
            }
        }

        private IEnumerable<PayRangeCustomerBookedViewModel> GetPayRange(PayPeriod payPeriod, IEnumerable<EventCustomer> eventcustomers)
        {
            var list = new List<PayRangeCustomerBookedViewModel>();
            var startDate = payPeriod.StartDate;

            while (startDate < payPeriod.EndDate)
            {
                var endDate = startDate.AddDays((7 * payPeriod.NumberOfWeeks) - 1);

                if (eventcustomers.Any(x => x.DataRecorderMetaData.DateCreated >= startDate && endDate <= x.DataRecorderMetaData.DateCreated))
                {
                    list.Add(new PayRangeCustomerBookedViewModel
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        PayPeriodId = payPeriod.Id
                    });
                }

                startDate = endDate.AddDays(1);
            }

            return list;
        }
    }
}
