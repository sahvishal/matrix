using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class OutboundCallQueueService : IOutboundCallQueueService
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IOutboundCallQueueListModelFactory _outboundCallQueueListModelFactory;
        private readonly INotesRepository _notesRepository;
        private readonly ICallQueueCriteriaRepository _callQueueCriteriaRepository;
        private readonly ICriteriaRepository _criteriaRepository;
        private readonly ICustomerCallNotesRepository _customerCallNotesRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ISettings _settings;

        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDirectMailRepository _directMailRepository;
        private readonly IDirectMailTypeRepository _directMailTypeRepository;

        public OutboundCallQueueService(ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerRepository customerRepository, IProspectCustomerRepository prospectCustomerRepository,
            ICallQueueCustomerCallRepository callQueueCustomerCallRepository, ICallCenterCallRepository callCenterCallRepository, ICallCenterNotesRepository callCenterNotesRepository,
            IOutboundCallQueueListModelFactory outboundCallQueueListModelFactory, INotesRepository notesRepository, ICallQueueCriteriaRepository callQueueCriteriaRepository, ICriteriaRepository criteriaRepository,
            ICustomerCallNotesRepository customerCallNotesRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ISettings settings, IEventRepository eventRepository, IHostRepository hostRepository,
            IPodRepository podRepository, IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository, IRoleRepository roleRepository, IRefundRequestRepository refundRequestRepository,
            IOrderRepository orderRepository, IDirectMailRepository directMailRepository, IDirectMailTypeRepository directMailTypeRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _outboundCallQueueListModelFactory = outboundCallQueueListModelFactory;
            _notesRepository = notesRepository;
            _callQueueCriteriaRepository = callQueueCriteriaRepository;
            _criteriaRepository = criteriaRepository;
            _customerCallNotesRepository = customerCallNotesRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _settings = settings;

            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _podRepository = podRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _roleRepository = roleRepository;
            _refundRequestRepository = refundRequestRepository;
            _orderRepository = orderRepository;
            _directMailRepository = directMailRepository;
            _directMailTypeRepository = directMailTypeRepository;
        }


        public OutboundCallQueueListModel GetOutboundCallQueueList(long callQueueId, long assignedToOrgRoleUserId, int pageNumber, int pageSize, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomers(callQueueId, assignedToOrgRoleUserId, pageNumber, pageSize, out totalRecords);
            if (callQueueCustomers.IsNullOrEmpty())
                return null;

            var customerIds = callQueueCustomers.Where(cqc => cqc.CustomerId.HasValue && cqc.CustomerId.Value > 0).Select(cqc => cqc.CustomerId.Value).ToArray();
            IEnumerable<Customer> customers = null;

            if (customerIds.Any())
                customers = _customerRepository.GetCustomers(customerIds);

            var prospectCustomerIds = callQueueCustomers.Where(cqc => cqc.ProspectCustomerId.HasValue && cqc.ProspectCustomerId.Value > 0).Select(cqc => cqc.ProspectCustomerId.Value).ToArray();//&& !cqc.CustomerId.HasValue

            var prospectCustomers = _prospectCustomerRepository.GetProspectCustomers(prospectCustomerIds);


            var prospectCustomerNotes = _customerCallNotesRepository.GetProspectCustomerNotes(prospectCustomers.Select(pc => pc.Id).ToArray());

            var callQueueCriterias = _callQueueCriteriaRepository.GetAllByCallQueueId(callQueueId);
            var criterias = _criteriaRepository.GetAll();


            var callQueueCustomerCalls = _callQueueCustomerCallRepository.GetByCallQueueCustomerIds(callQueueCustomers.Select(cqc => cqc.Id).ToArray());
            IEnumerable<Call> calls = null;
            IEnumerable<CallCenterNotes> callCenterNotes = null;

            if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
            {
                var callIds = callQueueCustomerCalls.Select(cqcc => cqcc.CallId).ToArray();
                calls = _callCenterCallRepository.GetByIds(callIds);
                callCenterNotes = _callCenterNotesRepository.GetByCallIds(callIds);
            }
            var idNamePair = GetIdNamePairs(prospectCustomerNotes);

            return _outboundCallQueueListModelFactory.Create(callQueueCustomers, customers, prospectCustomers, callQueueCriterias, criterias, callQueueCustomerCalls, calls, callCenterNotes, prospectCustomerNotes, idNamePair);
        }

        private IEnumerable<OrderedPair<long, string>> GetIdNamePairs(IEnumerable<CustomerCallNotes> prospectCustomerNotes)
        {
            var orgRoleUserIds = prospectCustomerNotes.Select(pcn => pcn.DataRecorderMetaData.DataRecorderCreator.Id);

            orgRoleUserIds = orgRoleUserIds.Distinct().ToList();

            return _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());
        }

        public Notes RemoveFromQueue(CallQueueCustomer callQueueCustomer, Notes notes)
        {
            notes = ((IRepository<Notes>)_notesRepository).Save(notes);

            callQueueCustomer.NotesId = notes.Id;
            _callQueueCustomerRepository.Save(callQueueCustomer);
            return notes;
        }

        public List<CallQueueCustomer> GetCallQueueCustomers(CallQueue queue)
        {
            var callQueuesCriterias = _callQueueCriteriaRepository.GetByCallQueueId(queue.Id);

            var callCriterias = (from qc in callQueuesCriterias
                                 orderby qc.Sequence
                                 select new
                                 {
                                     Id = qc.Id,
                                     CriteriaId = qc.CriteriaId,
                                     CallQueueId = qc.CallQueueId,
                                     qc.Condition,
                                     qc.Radius,
                                     qc.Zipcode,
                                     CustomerTempList = new List<CallQueueCustomer>()
                                 }).ToList();

            var customerList = new List<CallQueueCustomer>();

            for (int i = 0; i < callCriterias.Count(); i++)
            {
                if (callCriterias[i].CriteriaId == (long)QueueCriteria.AllCustomers)
                {
                    var customers = _customerRepository.GetCustomerBasedOnGeography(callCriterias[i].Zipcode, callCriterias[i].Radius, false);
                    if (customers == null || !customers.Any())
                        continue;
                    foreach (long customerId in customers)
                    {
                        callCriterias[i].CustomerTempList.Add(new CallQueueCustomer { CallQueueId = queue.Id, CustomerId = customerId, CallQueueCriteriaId = callCriterias[i].Id });
                    }
                }
                else if (callCriterias[i].CriteriaId == (long)QueueCriteria.AllCustomersOlderThanOneYear)
                {
                    var customers = _customerRepository.GetCustomerBasedOnGeography(callCriterias[i].Zipcode, callCriterias[i].Radius, true);
                    if (customers == null || !customers.Any())
                        continue;
                    foreach (long customerId in customers)
                    {
                        callCriterias[i].CustomerTempList.Add(new CallQueueCustomer { CallQueueId = queue.Id, CustomerId = customerId, CallQueueCriteriaId = callCriterias[i].Id });
                    }
                }
                else if (callCriterias[i].CriteriaId == (long)QueueCriteria.PhysicianPartner)
                {
                    var customers = _customerRepository.GetPhysicianPartnerCustomerBasedOnGeography(callCriterias[i].Zipcode, callCriterias[i].Radius, _settings.PhysicianPartnerAccountId);
                    if (customers == null || !customers.Any())
                        continue;
                    foreach (long customerId in customers)
                    {
                        callCriterias[i].CustomerTempList.Add(new CallQueueCustomer { CallQueueId = queue.Id, CustomerId = customerId, CallQueueCriteriaId = callCriterias[i].Id });
                    }
                }
                else
                {
                    var prospects = _prospectCustomerRepository.GetProspectsBasedOnGeography(callCriterias[i].Zipcode, callCriterias[i].Radius, ((QueueCriteria)callCriterias[i].CriteriaId).ToString());
                    if (prospects == null || !prospects.Any())
                        continue;
                    foreach (var pc in prospects)
                    {
                        callCriterias[i].CustomerTempList.Add(new CallQueueCustomer { CallQueueId = queue.Id, CustomerId = pc.SecondValue, ProspectCustomerId = pc.FirstValue, CallQueueCriteriaId = callCriterias[i].Id });
                    }
                }
            }

            //creating master list from individual call criterias
            for (int i = 0; i < callCriterias.Count(); i++)
            {
                if (callCriterias.Count() == 1)
                    customerList = callCriterias[0].CustomerTempList;
                else
                {
                    //putting list in 0th element in the master list
                    if (i == 0)
                        customerList = callCriterias[0].CustomerTempList;
                    else
                    {
                        //comparing condition between (AND/Or) current and previows element
                        if (!callCriterias[i].Condition)
                        {
                            customerList.AddRange(callCriterias[i - 1].CustomerTempList.AsEnumerable().Intersect(callCriterias[i].CustomerTempList.AsEnumerable(), new CallQueueCustomerEqualityComparer()).ToList());
                        }
                        else
                        {
                            customerList.AddRange(callCriterias[i].CustomerTempList);
                        }
                    }
                }
            }

            var finalList = (from c in customerList
                             group c by new { c.CallQueueId, c.CustomerId, c.ProspectCustomerId }
                                 into g
                                 select new CallQueueCustomer { CallQueueId = g.Key.CallQueueId, CustomerId = g.Key.CustomerId, ProspectCustomerId = g.Key.ProspectCustomerId, CallQueueCriteriaId = g.Min(c => c.CallQueueCriteriaId) }).ToList();

            return finalList;
        }

        public void ChangeAssignmentOfExistingQueue(CallQueue queue, IEnumerable<CallQueueAssignment> callQueueAssignments)
        {
            var callQueueCustomerIds = _callQueueCustomerRepository.GetCallQueueCustomerIdsByCallQueueIdAndStatus(queue.Id, CallQueueStatus.Initial);
            if (callQueueCustomerIds != null && callQueueCustomerIds.Any())
            {
                var totalRecords = callQueueCustomerIds.Count();

                var callDivisions = (from ca in callQueueAssignments
                                     let count = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords * ca.Percentage) / 100))
                                     select new
                                     {
                                         AssignedTo = ca.AssignedOrgRoleUserId,
                                         callCount = count > 0 ? count : 1
                                     }).ToList();

                int endCount = 0;
                foreach (var callDivision in callDivisions)
                {
                    var queuecustomerIds = callQueueCustomerIds.Skip(endCount).Take(callDivision.callCount).ToArray();
                    const int pageSize = 50;
                    int pageNumber = 1;
                    while (true)
                    {
                        var assignedCallQueueCustomerIds = queuecustomerIds.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                        _callQueueCustomerRepository.UpdateAssignment(assignedCallQueueCustomerIds, callDivision.AssignedTo);

                        if ((pageNumber * pageSize) >= callDivision.callCount)
                            break;

                        pageNumber++;
                    }
                    endCount = endCount + callDivision.callCount;
                }
            }
        }

        public OutboundCallQueueListModel GetOutboundCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            IEnumerable<CallQueueCustomer> callQueueCustomers;
            if (callQueue.Category == CallQueueCategory.FillEvents)
            {
                callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomerForFillEvents(filter, filter.PageNumber, pageSize, criteriaId, out totalRecords);
            }
            else
            {
                callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomerForZipCode(filter, filter.PageNumber, pageSize, out totalRecords);
            }


            if (callQueueCustomers.IsNullOrEmpty())
                return null;

            var customerIds = callQueueCustomers.Where(cqc => cqc.CustomerId.HasValue && cqc.CustomerId.Value > 0).Select(cqc => cqc.CustomerId.Value).ToArray();
            IEnumerable<Customer> customers = null;

            if (customerIds.Any())
            {
                customerIds = customerIds.Distinct().ToArray();
                customers = _customerRepository.GetCustomers(customerIds);
            }

            var prospectCustomerIds = callQueueCustomers.Where(cqc => cqc.ProspectCustomerId.HasValue && cqc.ProspectCustomerId.Value > 0).Select(cqc => cqc.ProspectCustomerId.Value).Distinct().ToArray();//&& !cqc.CustomerId.HasValue

            var prospectCustomers = _prospectCustomerRepository.GetProspectCustomers(prospectCustomerIds);

            var callQueueCustomerCalls = _callCenterCallRepository.GetCallForCallQueueCustomerList(customerIds, prospectCustomerIds);
            IEnumerable<CallCenterNotes> callCenterNotes = null;

            if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
            {
                callCenterNotes = _callCenterNotesRepository.GetByCallIds(callQueueCustomerCalls.Select(s => s.CallId));
            }

            return _outboundCallQueueListModelFactory.SystemGeneratedCallQueueCustomers(callQueueCustomers, customers, prospectCustomers, callQueueCustomerCalls, callCenterNotes, null, null, null);

        }

        public long SetCallDetail(long organizationRoleUserId, long calledCustomerId = 0, string calledInNumber = "", string callerNumber = "", string callStatus = "", long? campaignId = null, long? healthPlanId = null, string customTags = "",
            long? callQueueId = null, long callId = 0, bool readAndUnderstood = false, long eventId = 0, string callQueueCategory = "", long? dialerType = null ,long? ProductTypeId = null)
        {
            var objCcRepCall = new Call
            {
                Id = callId,
                CreatedByOrgRoleUserId = organizationRoleUserId,
                StartTime = DateTime.Now,
                CalledInNumber = calledInNumber,
                CallerNumber = callerNumber,
                CallBackNumber = callerNumber,
                CallStatus = callStatus,
                IsIncoming = false,
                CalledCustomerId = calledCustomerId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CampaignId = campaignId,
                HealthPlanId = healthPlanId,
                CustomTags = !string.IsNullOrEmpty(customTags) ? customTags : null,
                CallQueueId = callQueueId,
                ReadAndUnderstood = readAndUnderstood,
                EventId = eventId,
                IsContacted = !string.IsNullOrEmpty(callQueueCategory) && (callQueueCategory != HealthPlanCallQueueCategory.AppointmentConfirmation) ? false : (bool?)null,
                DialerType = dialerType,
                ProductTypeId = ProductTypeId
            };
            var call = _callCenterCallRepository.Save(objCcRepCall);

            return call.Id;
        }

        public OutboundCallQueueListModel GetOutboundCallQueueUpsellAndConfirmation(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomerForUpsellAndConfirmation(filter, filter.PageNumber, pageSize, callQueue, criteriaId, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
                return null;

            var eventIds = callQueueCustomers.Where(x => x.EventId.HasValue).Select(x => x.EventId.Value).Distinct();
            var customerIds = callQueueCustomers.Where(cqc => cqc.CustomerId.HasValue && cqc.CustomerId.Value > 0).Select(cqc => cqc.CustomerId.Value).Distinct().ToArray();

            var eventCustomers = _eventCustomerRepository.GetByEventIds(eventIds);
            eventCustomers = eventCustomers.Where(ec => customerIds.Contains(ec.CustomerId));

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var roles = _roleRepository.GetAll();

            // var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var appointment = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value));

            var events = _eventRepository.GetEventswithPodbyIds(eventIds).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds).ToList();
            var pods = _podRepository.GetPodsForEvents(eventIds);

            IEnumerable<Customer> customers = _customerRepository.GetCustomers(customerIds);

            var callQueueCustomerCalls = _callCenterCallRepository.GetCallForCallQueueCustomerList(customerIds, null);
            IEnumerable<CallCenterNotes> callCenterNotes = null;

            if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
            {
                callCenterNotes = _callCenterNotesRepository.GetByCallIds(callQueueCustomerCalls.Select(s => s.CallId));
            }

            return _outboundCallQueueListModelFactory.CallQueueCustomersForUpsellAndConfimration(callQueueCustomers, customers, callQueueCustomerCalls, callCenterNotes, events, hosts, pods, appointment, eventCustomers, registeredbyAgent, roles);

        }

        public void SetReadAndUnderstoodNotes(long callId)
        {
            var call = _callCenterCallRepository.GetById(callId);
            call.ReadAndUnderstood = true;

            _callCenterCallRepository.Save(call);
        }

        public CallQueueCustomerNotesViewModel GetCustomerNotes(long callId, long callQueueCustomerId)
        {
            var callHistoryModel = new List<CallHistoryViewModel>();

            CallQueueCustomer callQueueCustomer = null;
            long customerId = 0;
            long prospectCustomerId = 0;

            if (callQueueCustomerId > 0)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
                customerId = callQueueCustomer.CustomerId ?? 0;
                prospectCustomerId = callQueueCustomer.ProspectCustomerId ?? 0;
            }
            else
            {
                var call = _callCenterCallRepository.GetById(callId);
                customerId = call != null ? call.CalledCustomerId : 0;
            }

            var calls = _callCenterCallRepository.GetCallsForCallQueueCustomer(callId, customerId, prospectCustomerId);

            if (calls != null && calls.Any())
            {
                var callCenterNotes = _callCenterNotesRepository.GetByCallIds(calls.Select(x => x.CallId));
                var agentNameIds = _organizationRoleUserRepository.GetNameIdPairofUsers(calls.Select(x => x.CreatedByOrgRoleUserId).ToArray());

                var callHistoryList = new List<CallHistoryViewModel>();

                foreach (var customerCall in calls)
                {
                    var agentNameId = agentNameIds.First(c => c.FirstValue == customerCall.CreatedByOrgRoleUserId);

                    var dispositionValue = "N/A";

                    if (!string.IsNullOrEmpty(customerCall.Disposition))
                    {
                        ProspectCustomerTag disposition;
                        Enum.TryParse(customerCall.Disposition, out disposition);

                        if (Enum.IsDefined(typeof(ProspectCustomerTag), disposition))
                        {
                            dispositionValue = disposition.GetDescription();
                        }
                    }

                    var callHistory = new CallHistoryViewModel()
                    {
                        CallId = customerCall.CallId,
                        DateCreated = customerCall.CallDateTime,
                        CallOutcome = ((CallStatus)customerCall.Status).GetDescription(),
                        RequestedCallBack = callQueueCustomer != null ? callQueueCustomer.CallDate : (DateTime?)null,
                        CreatedBy = agentNameId.SecondValue,
                        Disposition = dispositionValue,
                        NotInterestedReason = customerCall.NotInterestedReasonId.HasValue ? ((NotInterestedReason)customerCall.NotInterestedReasonId).GetDescription() : "N/A"
                    };

                    if (callCenterNotes != null && callCenterNotes.Any())
                    {
                        var customerNotes = callCenterNotes.Where(ccn => ccn.CallId == customerCall.CallId).Select(ccn => ccn).ToArray();
                        callHistory.Notes = customerNotes.Select(cn => new NotesViewModel() { Note = cn.Notes, EnteredOn = cn.DateCreated }).OrderByDescending(x => x.EnteredOn);
                    }

                    callHistoryList.Add(callHistory);
                }

                callHistoryModel.AddRange(callHistoryList.OrderByDescending(x => x.DateCreated).ToList());
            }
            var mailHistoryList = new List<DirectMailViewModel>();

            if (customerId > 0)
            {
                var directMails = _directMailRepository.GetByCustomerId(customerId);

                if (directMails != null && directMails.Any())
                {
                    var agentNameIds = _organizationRoleUserRepository.GetNameIdPairofUsers(directMails.Select(x => x.Mailedby).ToArray());
                    var directMailTypes = _directMailTypeRepository.GetAll();

                    foreach (var directMail in directMails)
                    {
                        var agentNameId = agentNameIds.First(c => c.FirstValue == directMail.Mailedby);
                        var directMailSentToCustomer = "N/A";

                        if (directMail.DirectMailTypeId.HasValue)
                        {
                            directMailSentToCustomer = directMailTypes.Single(x => x.Id == directMail.DirectMailTypeId.Value).Name;
                        }
                        mailHistoryList.Add(new DirectMailViewModel()
                        {
                            DateCreated = directMail.MailDate,
                            CreatedBy = agentNameId.SecondValue,
                            DirectMailType = directMailSentToCustomer,
                            Notes = directMail.IsInvalidAddress ? directMail.Notes : "N/A"
                        });
                    }
                }

            }

            var customerCallNotesViewModel = new List<CustomerCallNotesViewModel>();

            if (customerId > 0)
            {
                var customerCallNotes = _customerCallNotesRepository.GetCustomerNotes(customerId).ToList();

                var orders = _orderRepository.GetAllOrdersForCustomer(customerId);
                if (orders != null && orders.Count() > 0)
                {
                    var refundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(oec => oec.Id).ToArray(), RefundRequestType.CustomerCancellation);

                    if (refundRequests != null && refundRequests.Count() > 0)
                    {
                        var refundRequestNotes = new List<CustomerCallNotes>();
                        foreach (var refundRequest in refundRequests)
                        {
                            refundRequestNotes.Add(new CustomerCallNotes
                            {
                                CustomerId = customerId,
                                Notes = refundRequest.Reason,
                                NotesType = CustomerRegistrationNotesType.CancellationNote,
                                DataRecorderMetaData = new DataRecorderMetaData(refundRequest.RequestedByOrgRoleUserId, refundRequest.RequestedOn, null)
                            });
                        }
                        customerCallNotes = customerCallNotes.Concat(refundRequestNotes).ToList();
                    }
                }

                if (!customerCallNotes.IsNullOrEmpty())
                {
                    customerCallNotes = customerCallNotes.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).ToList();
                    var orgRoleUserIds = customerCallNotes.Select(x => x.DataRecorderMetaData.DataRecorderCreator.Id).ToArray();
                    orgRoleUserIds = orgRoleUserIds.Distinct().ToArray();

                    var agentNameIds = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

                    customerCallNotesViewModel.AddRange(from notes in customerCallNotes
                                                        let createdBy = agentNameIds.First(x => x.FirstValue == notes.DataRecorderMetaData.DataRecorderCreator.Id).SecondValue
                                                        select GetCustomerCallNotesViewModel(notes, createdBy));
                }
            }

            var notesViewModel = new CallQueueCustomerNotesViewModel
            {
                CallHistory = callHistoryModel,
                CustomerCallNotes = customerCallNotesViewModel,
                DirectMail = mailHistoryList
            };

            return notesViewModel;
        }

        private CustomerCallNotesViewModel GetCustomerCallNotesViewModel(CustomerCallNotes notes, string createdBy)
        {
            return new CustomerCallNotesViewModel
            {
                CreatedBy = createdBy,
                DateCreated = notes.DataRecorderMetaData.DateCreated,
                Notes = notes.Notes,
                EventId = notes.EventId,
                NotesType = notes.NotesType,
                Reason = notes.ReasonId.HasValue ? ((LeftWithoutScreeningReason)notes.ReasonId.Value).GetDescription() : string.Empty
            };
        }
    }
}
