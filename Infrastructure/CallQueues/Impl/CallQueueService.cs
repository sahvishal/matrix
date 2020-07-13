using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
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
    public class CallQueueService : ICallQueueService
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueAssignmentRepository _callQueueAssignmentRepository;
        private readonly ICallQueueCriteriaRepository _callQueueCriteriaRepository;
        private readonly ICriteriaRepository _criteriaRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallQueueListModelFactory _callQueueListModelFactory;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueReportListModelFactory _callQueueReportListModelFactory;
        private readonly IOutreachCallReportListModelFactory _outreachCallReportListModelFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IScriptRepository _scriptRepository;
        private readonly IEventBasicInfoListHelper _eventBasicInfoListHelper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IUncontactedCustomersListModelFactory _uncontactedCustomersListModelFactory;
        private readonly ISettings _settings;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICallQueueExcludedCustomerReportListModelFactory _callQueueExcludedCustomerReportListModelFactory;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly ICustomerWithNoEventsInAreaReportListModelFactory _customerWithNoEventsInAreaReportListModelFactory;
        private readonly ICallCenterCallReportListModelFactory _callCenterCallReportListModelFactory;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IAccountCallQueueSettingRepository _callQueueSettingRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerTargetedRepository _customerTargetedRepository;

        public CallQueueService(ICallQueueRepository callQueueRepository, ICallQueueAssignmentRepository callQueueAssignmentRepository, ICallQueueCriteriaRepository callQueueCriteriaRepository,
            ICriteriaRepository criteriaRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICallQueueListModelFactory callQueueListModelFactory,
            ICallQueueCustomerRepository callQueueCustomerRepository, ICallQueueReportListModelFactory callQueueReportListModelFactory, IScriptRepository scriptRepository,
            IOutreachCallReportListModelFactory outreachCallReportListModelFactory, ICustomerRepository customerRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, IEventCustomerRepository eventCustomerRepository, IEventRepository eventRepository,
            ICallCenterCallRepository callCenterCallRepository, IEventBasicInfoListHelper eventBasicInfoListHelper, IAppointmentRepository appointmentRepository, ICallCenterNotesRepository callCenterNotesRepository,
            IUncontactedCustomersListModelFactory uncontactedCustomersListModelFactory, ISettings settings, IShippingDetailRepository shippingDetailRepository, IAddressRepository addressRepository,
            ICallQueueExcludedCustomerReportListModelFactory callQueueExcludedCustomerReportListModelFactory, IProspectCustomerRepository prospectCustomerRepository,
            IUserRepository<User> userRepository, ICustomerWithNoEventsInAreaReportListModelFactory customerWithNoEventsInAreaReportListModelFactory,
            ICallCenterCallReportListModelFactory callCenterCallReportListModelFactory, ICorporateAccountRepository corporateAccountRepository, IAccountCallQueueSettingRepository callQueueSettingRepository,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ICustomerEligibilityRepository customerEligibilityRepository, ICustomerTargetedRepository customerTargetedRepository)
        {
            _callQueueRepository = callQueueRepository;
            _callQueueAssignmentRepository = callQueueAssignmentRepository;
            _callQueueCriteriaRepository = callQueueCriteriaRepository;
            _criteriaRepository = criteriaRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callQueueListModelFactory = callQueueListModelFactory;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueReportListModelFactory = callQueueReportListModelFactory;
            _outreachCallReportListModelFactory = outreachCallReportListModelFactory;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _scriptRepository = scriptRepository;
            _eventBasicInfoListHelper = eventBasicInfoListHelper;
            _appointmentRepository = appointmentRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _uncontactedCustomersListModelFactory = uncontactedCustomersListModelFactory;
            _settings = settings;
            _shippingDetailRepository = shippingDetailRepository;
            _addressRepository = addressRepository;
            _callQueueExcludedCustomerReportListModelFactory = callQueueExcludedCustomerReportListModelFactory;
            _prospectCustomerRepository = prospectCustomerRepository;
            _userRepository = userRepository;
            _customerWithNoEventsInAreaReportListModelFactory = customerWithNoEventsInAreaReportListModelFactory;
            _callCenterCallReportListModelFactory = callCenterCallReportListModelFactory;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueSettingRepository = callQueueSettingRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerTargetedRepository = customerTargetedRepository;
        }

        public CallQueueEditModel SaveCallQueue(CallQueueEditModel callQueueEditModel, long orgRoleUserId)
        {
            var callQueue = Mapper.Map<CallQueueEditModel, CallQueue>(callQueueEditModel);
            if (callQueue.Id > 0)
            {
                var callQueueInDb = _callQueueRepository.GetById(callQueue.Id);
                callQueue.DataRecorderMetaData = callQueueInDb.DataRecorderMetaData;
                callQueue.LastQueueGeneratedDate = callQueueInDb.LastQueueGeneratedDate;
                callQueue.DataRecorderMetaData.DateModified = DateTime.Now;
                callQueue.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId);
            }
            else
            {
                callQueue.DataRecorderMetaData = new DataRecorderMetaData(orgRoleUserId, DateTime.Now, null);
            }
            Script script = null;
            if (callQueueEditModel.ScriptId > 0)
            {
                script = _scriptRepository.GetById(callQueueEditModel.ScriptId);
                script.ScriptText = callQueueEditModel.ScriptText;
                script.DateModified = DateTime.Now;
            }
            else
            {
                script = new Script
                {
                    Name = callQueueEditModel.Name,
                    ScriptText = callQueueEditModel.ScriptText,
                    Description = "",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ScriptTypeId = (long)ScriptType.OutboundCallQueueScript
                };
            }

            script = _scriptRepository.Save(script);
            callQueue.ScriptId = script.Id;

            callQueue = _callQueueRepository.Save(callQueue);


            foreach (var criteriaEditModel in callQueueEditModel.Criterias)
            {
                criteriaEditModel.CallQueueId = callQueue.Id;
            }
            var criterias = Mapper.Map<IEnumerable<CallQueueCriteriaEditModel>, IEnumerable<CallQueueCriteria>>(callQueueEditModel.Criterias);
            _callQueueCriteriaRepository.Save(criterias, callQueue.Id);

            foreach (var callQueueAssignmentEditModel in callQueueEditModel.Assignments)
            {
                callQueueAssignmentEditModel.CallQueueId = callQueue.Id;
            }
            var assignments = Mapper.Map<IEnumerable<CallQueueAssignmentEditModel>, IEnumerable<CallQueueAssignment>>(callQueueEditModel.Assignments);
            _callQueueAssignmentRepository.Save(assignments, callQueue.Id);

            callQueueEditModel.Id = callQueue.Id;
            callQueueEditModel.ScriptId = script.Id;

            return callQueueEditModel;
        }

        public CallQueueEditModel GetCallQueue(long callQueueId)
        {
            var callQueue = _callQueueRepository.GetById(callQueueId);

            var callQueueEditModel = Mapper.Map<CallQueue, CallQueueEditModel>(callQueue);
            if (callQueueEditModel.ScriptId > 0)
            {
                var script = _scriptRepository.GetById(callQueueEditModel.ScriptId);
                callQueueEditModel.ScriptText = script.ScriptText;
            }

            var callQueueCriterias = _callQueueCriteriaRepository.GetByCallQueueId(callQueueId);
            var criteriaEditModels = Mapper.Map<IEnumerable<CallQueueCriteria>, IEnumerable<CallQueueCriteriaEditModel>>(callQueueCriterias);
            var criterias = _criteriaRepository.GetAll();
            foreach (var callQueueCriteriaEditModel in criteriaEditModels)
            {
                callQueueCriteriaEditModel.Name = criterias.Where(c => c.Id == callQueueCriteriaEditModel.CriteriaId).Select(c => c.Name).Single();
            }
            callQueueEditModel.Criterias = criteriaEditModels;

            var assginments = _callQueueAssignmentRepository.GetByCallQueueId(callQueueId);
            var assignmentEditModels = Mapper.Map<IEnumerable<CallQueueAssignment>, IEnumerable<CallQueueAssignmentEditModel>>(assginments);
            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(assignmentEditModels.Select(a => a.AssignedOrgRoleUserId).ToArray());
            foreach (var callQueueAssignmentEditModel in assignmentEditModels)
            {
                callQueueAssignmentEditModel.Name = idNamePairs.Where(inp => inp.FirstValue == callQueueAssignmentEditModel.AssignedOrgRoleUserId).Select(inp => inp.SecondValue).Single();
            }
            callQueueEditModel.Assignments = assignmentEditModels;

            return callQueueEditModel;
        }

        public ListModelBase<CallQueueViewModel, CallQueueListModelFilter> GetCallQueueList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callQueues = _callQueueRepository.GetCallQueueList(filter as CallQueueListModelFilter, pageNumber, pageSize, out totalRecords);
            if (callQueues.IsNullOrEmpty())
                return null;

            var callQueueIds = callQueues.Select(cq => cq.Id).ToArray();

            var callQueueCriterias = _callQueueCriteriaRepository.GetByCallQueueIds(callQueueIds);

            var criterias = _criteriaRepository.GetAll();

            var callQueueAssignments = _callQueueAssignmentRepository.GetByCallQueueIds(callQueueIds);

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(callQueueAssignments.Select(a => a.AssignedOrgRoleUserId).ToArray());

            var callQueueIdTotalCustomersInQueuePairs = _callQueueCustomerRepository.GetQueueIdTotalCustomersInQueuePairs(callQueueIds);

            var callQueueIdTotalCustomersPairs = _callQueueCustomerRepository.GetQueueIdTotalCustomersPairs(callQueueIds);

            var callQueueIdTotalCustomersContactedPairs = _callQueueCustomerRepository.GetQueueIdTotalCustomersContactedPairs(callQueueIds);

            return _callQueueListModelFactory.Create(callQueues, callQueueCriterias, criterias, callQueueAssignments, idNamePairs, callQueueIdTotalCustomersInQueuePairs, callQueueIdTotalCustomersPairs, callQueueIdTotalCustomersContactedPairs);
        }

        public ListModelBase<CallQueueReportModel, CallQueueReportModelFilter> GetCallQueueReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callQueueAssignments = _callQueueAssignmentRepository.GetCallQueueAssignment(filter as CallQueueReportModelFilter, pageNumber, pageSize, out totalRecords);

            if (callQueueAssignments.IsNullOrEmpty())
                return null;

            var callQueueIds = callQueueAssignments.Select(cqa => cqa.CallQueueId).Distinct().ToArray();

            var callQueues = _callQueueRepository.GetByIds(callQueueIds);

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(callQueueAssignments.Select(a => a.AssignedOrgRoleUserId).Distinct().ToArray());

            var totalCustomerStats = _callQueueCustomerRepository.GetTotalCallQueueCustomerStats(callQueueIds);

            var contactedCustomerStats = _callQueueCustomerRepository.GetContactedCallCustomersStats(callQueueIds);

            return _callQueueReportListModelFactory.Create(callQueueAssignments, callQueues, idNamePairs, totalCustomerStats, contactedCustomerStats);
        }

        public ListModelBase<OutreachCallReportModel, OutreachCallReportModelFilter> GetOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
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

            return _outreachCallReportListModelFactory.Create(customers, customerTags, calls, eventCusomters, eventBasicInfoListModel, appointments, registeredbyAgentNameIdPair, dispositionNotes, orderedPairsCustomersShippingDetails,
                customersShippingDetails, customerAddress, callQueues, customerEligibilities);
        }

        public ListModelBase<UncontactedCustomersReportModel, UncontactedCustomersReportModelFilter> GetUncontactedCustomersReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var noPastAppointmentInDays = _settings.NoPastAppointmentInDaysUncontactedCustomers;
            var neverBeenCalledInDays = _settings.NeverBeenCalledInDays;
            var customers = _customerRepository.GetUncontactedCustomers(filter as UncontactedCustomersReportModelFilter, pageNumber, pageSize, neverBeenCalledInDays, noPastAppointmentInDays, out totalRecords);

            if (customers == null || !customers.Any()) return null;

            var customerIds = customers.Select(c => c.CustomerId).ToArray();
            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();
            var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            return _uncontactedCustomersListModelFactory.Create(customers, customTags, customerEligibilities);
        }

        public ListModelBase<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter> GetCallQueueExcludedCustomerReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callQueueFilter = filter as CallQueueExcludedCustomerReportModelFilter;
            var customers = _customerRepository.GetCallQueueExcludedCustomers(callQueueFilter, pageNumber, pageSize, out totalRecords);

            if (customers == null || !customers.Any()) return null;

            var customerIds = customers.Select(c => c.CustomerId).ToArray();

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            var prospectCustomers = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(customerIds);

            var eventCustomers = _eventCustomerRepository.GetByCustomerIds(customerIds);
            eventCustomers = eventCustomers.Where(x => x.AppointmentId.HasValue && x.NoShow == false);

            var eventIds = eventCustomers.Select(x => x.EventId).ToArray();

            var events = _eventRepository.GetEvents(eventIds);

            var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(customerIds);

            var userIds = orgRoleUsers.Select(x => x.UserId).ToList();

            var users = _userRepository.GetUsers(userIds);

            var targetedCustomers = _customerTargetedRepository.GetCustomerTargetedByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (callQueueFilter.CampaignId > 0)
            {
                var zipIds = _callQueueCustomerRepository.GetAccountZip(callQueueFilter.HealthPlanId);
                var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomersForRejectedList(customerIds, callQueueFilter.CampaignId, callQueueFilter.HealthPlanId);
                var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(callQueueFilter.HealthPlanId);

                var criterias = _healthPlanCallQueueCriteriaRepository.GetByCampaignId(callQueueFilter.CampaignId);
                var criteria = criterias.First();

                var accountCallQueueSetting = (_callQueueSettingRepository.GetByAccountIdAndCallQueueId(callQueueFilter.HealthPlanId, criteria.CallQueueId));
                return _callQueueExcludedCustomerReportListModelFactory.Create(customers, customTags, prospectCustomers, eventCustomers, events, orgRoleUsers, users, callQueueCustomers, zipIds, account, accountCallQueueSetting, customerEligibilities, targetedCustomers);
            }

            return _callQueueExcludedCustomerReportListModelFactory.Create(customers, customTags, prospectCustomers, eventCustomers, events, orgRoleUsers, users, null, null, null, null, customerEligibilities, targetedCustomers);
        }

        public IEnumerable<OutreachCallChartViewModel> GetOutreachCallChart()
        {
            return new List<OutreachCallChartViewModel>
            {
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date, DateTime.Now.Date.AddDays(1)), OutreachDate=DateTime.Now.Date.ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date), OutreachDate=DateTime.Now.AddDays(-1).ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-2), DateTime.Now.Date.AddDays(-1)), OutreachDate=DateTime.Now.AddDays(-2).ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-3), DateTime.Now.Date.AddDays(-2)), OutreachDate=DateTime.Now.AddDays(-3).ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-4), DateTime.Now.Date.AddDays(-3)), OutreachDate=DateTime.Now.AddDays(-4).ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-5), DateTime.Now.Date.AddDays(-4)), OutreachDate=DateTime.Now.AddDays(-5).ToString("MMM dd")},
                new OutreachCallChartViewModel{Calls=_callCenterCallRepository.GetOutreachCallQueueCallsForLastSevenDays(DateTime.Now.Date.AddDays(-6), DateTime.Now.Date.AddDays(-5)), OutreachDate=DateTime.Now.AddDays(-6).ToString("MMM dd")},
            };
        }

        public ListModelBase<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter> GetCustomerWithNoEventsInArea(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var customers = _customerRepository.GetCustomerWithNoEventsInArea(filter as CustomerWithNoEventsInAreaReportModelFilter, pageNumber, pageSize, out totalRecords);

            if (customers == null || !customers.Any()) return null;

            var customerIds = customers.Select(c => c.CustomerId).ToArray();

            var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            return _customerWithNoEventsInAreaReportListModelFactory.Create(customers, customTags);
        }

        public ListModelBase<CallCenterCallReportModel, CallCenterCallReportModelFilter> GetCallCenterCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var calls = _callCenterCallRepository.GetCallCenterCallQueueCustomer(filter as CallCenterCallReportModelFilter, pageNumber, pageSize, out totalRecords);

            if (calls == null || !calls.Any()) return null;

            var customerIds = calls.Select(c => c.CalledCustomerId).ToArray();

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

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            return _callCenterCallReportListModelFactory.Create(customers, customerTags, calls, eventCusomters, eventBasicInfoListModel, appointments, registeredbyAgentNameIdPair, dispositionNotes, orderedPairsCustomersShippingDetails,
            customersShippingDetails, customerAddress, callQueues, customerEligibilities);
        }

        public ListModelBase<HousecallOutreachReportModel, OutreachCallReportModelFilter> GetHousecallOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var calls = _callCenterCallRepository.GetOutreachCallQueueCustomer(filter as OutreachCallReportModelFilter, pageNumber, pageSize, out totalRecords);

            if (calls == null || !calls.Any()) return null;

            var customerIds = calls.Select(c => c.CalledCustomerId).ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);

            var eventIds = calls.Where(x => x.EventId > 0).Select(x => x.EventId);

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            EventBasicInfoListModel eventBasicInfoListModel = null;
            List<EventCustomer> eventCusomters = null;
            List<Appointment> appointments = null;

            if (events != null)
            {
                eventBasicInfoListModel = _eventBasicInfoListHelper.EventBasicInfoListForCallQueue(events);
            }

            var orderedPairsCustomersShippingDetails = _shippingDetailRepository.GetShippingDetailsIdCustomerId(customerIds);

            var customersShippingDetails = _shippingDetailRepository.GetShippingDetailsForCustomerIds(customerIds);
            var customerShippingAddressIds = customersShippingDetails.Select(x => x.ShippingAddress.Id).ToList();
            var customerAddress = _addressRepository.GetAddresses(customerShippingAddressIds);

            if (events != null && !customerIds.IsNullOrEmpty())
            {
                eventCusomters = _eventCustomerRepository.GetByCustomerIds(customerIds).Where(s => eventIds.Contains(s.EventId)).ToList();
            }

            if (!eventCusomters.IsNullOrEmpty())
            {
                var appointmentIds = eventCusomters.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
                appointments = _appointmentRepository.GetByIds(appointmentIds).ToList();
            }

            return _outreachCallReportListModelFactory.CreateHousecallModel(customers, calls, eventBasicInfoListModel, orderedPairsCustomersShippingDetails,
                customersShippingDetails, customerAddress, eventCusomters, appointments);
        }

    }
}
