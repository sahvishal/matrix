using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Customer = Falcon.App.Core.Users.Domain.Customer;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCallQueueCustomerHelper : IHealthPlanCallQueueCustomerHelper
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;
        private readonly ICallCenterCallRepository _centerCallRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IAccountCallQueueSettingRepository _callQueueSettingRepository;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerTargetedRepository _customerTargetedRepository;
        private ILogger logger;

        public HealthPlanCallQueueCustomerHelper(ICallQueueCustomerRepository callQueueCustomerRepository,
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository, ICallCenterCallRepository centerCallRepository,
            ICustomerRepository customerRepository, IProspectCustomerRepository prospectCustomerRepository, IAccountCallQueueSettingRepository callQueueSettingRepository,
            IEventCustomerRepository eventCustomerRepository, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository,
            IAppointmentRepository appointmentRepository, ILogManager logManager, ICustomerEligibilityRepository customerEligibilityRepository, ICustomerTargetedRepository customerTargetedRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
            _centerCallRepository = centerCallRepository;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _callQueueSettingRepository = callQueueSettingRepository;

            _eventCustomerRepository = eventCustomerRepository;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;

            _appointmentRepository = appointmentRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerTargetedRepository = customerTargetedRepository;

            logger = logManager.GetLogger("healthPlanCallqueueHelper");
        }

        public void SaveCallQueueCustomer(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long criteriaId, long callQueueId)
        {
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                var customerIds = callQueueCustomers.Where(x => x.CustomerId.HasValue).Select(x => x.CustomerId.Value).Distinct();
                var existingCustomers = _callQueueCustomerRepository.GetCallQueueCustomerByHealthPlanId(healthPlanId, callQueueId).ToList();
                SaveCallQueueCustomerAndAssignment(callQueueCustomers, existingCustomers, criteriaId, healthPlanId, callQueueId, customerIds);//, null

            }
        }

        private CallQueueCustomer CreateCustomerCallQueueCustomerModel(CallQueueCustomer existingCallQueueCustomer, CallQueueCustomer callQueueCustomer, Customer customer,
            IEnumerable<Call> customerCalls, int callAttempts, Appointment futureAppointment, ProspectCustomer prospectCustomer, EventAppointmentCancellationLog eacl,
            bool isConfirmationCallQueue, CustomerEligibility customerEligibility, IEnumerable<EventCustomer> eventCustomers, CustomerTargeted customerTargeted)
        {
            var lastCall = (from cc in customerCalls
                            where cc.Status != (long)CallStatus.CallSkipped
                            && (isConfirmationCallQueue == false || cc.CallQueueId == callQueueCustomer.CallQueueId)
                            orderby cc.DateCreated descending
                            select cc).FirstOrDefault();

            if (existingCallQueueCustomer == null)
            {
                existingCallQueueCustomer = callQueueCustomer;
                existingCallQueueCustomer.DateCreated = DateTime.Now;
                existingCallQueueCustomer.CallDate = DateTime.Now;
            }
            else
            {
                existingCallQueueCustomer.CallDate = DateTime.Now;
            }

            existingCallQueueCustomer.IsActive = true;
            existingCallQueueCustomer.Status = CallQueueStatus.Initial;

            existingCallQueueCustomer.FirstName = customer.Name.FirstName;
            existingCallQueueCustomer.LastName = customer.Name.LastName;
            existingCallQueueCustomer.MiddleName = customer.Name.MiddleName;

            existingCallQueueCustomer.PhoneHome = customer.HomePhoneNumber;
            existingCallQueueCustomer.PhoneCell = customer.MobilePhoneNumber;
            existingCallQueueCustomer.PhoneOffice = customer.OfficePhoneNumber;

            existingCallQueueCustomer.ZipId = customer.Address.ZipCode.Id;
            existingCallQueueCustomer.ZipCode = customer.Address.ZipCode.Zip;
            existingCallQueueCustomer.Tag = customer.Tag;
            existingCallQueueCustomer.IsEligble = customerEligibility != null ? customerEligibility.IsEligible : null;
            existingCallQueueCustomer.IsIncorrectPhoneNumber = customer.IsIncorrectPhoneNumber;
            existingCallQueueCustomer.IsLanguageBarrier = customer.IsLanguageBarrier;
            existingCallQueueCustomer.ActivityId = customer.ActivityId;
            existingCallQueueCustomer.DoNotContactTypeId = customer.DoNotContactTypeId;
            existingCallQueueCustomer.DoNotContactUpdateDate = customer.DoNotContactUpdateDate;

            existingCallQueueCustomer.AppointmentDate = futureAppointment != null ? futureAppointment.StartTime : (DateTime?)null;
            existingCallQueueCustomer.NoShowDate = futureAppointment == null ? (eventCustomers.Any() ? eventCustomers.OrderByDescending(x => x.NoShowDate).First().NoShowDate : null) : null;

            if (!isConfirmationCallQueue)
            {
                existingCallQueueCustomer.CallCount = customerCalls.Count(x => x.IsContacted.HasValue && x.IsContacted.Value);
                existingCallQueueCustomer.Attempts = callAttempts;

                existingCallQueueCustomer.CallStatus = lastCall != null ? lastCall.Status : (long?)null;
                existingCallQueueCustomer.Disposition = lastCall != null ? lastCall.Disposition : string.Empty;
            }
            //confirm call queue - called then registered for another event, and queue regenerated
            existingCallQueueCustomer.ContactedDate = lastCall != null ? lastCall.DateCreated : (DateTime?)null;

            existingCallQueueCustomer.CallBackRequestedDate = null;
            if (prospectCustomer != null && lastCall != null && lastCall.Status == (long)CallStatus.Attended && lastCall.Disposition == ProspectCustomerTag.CallBackLater.ToString())
            {
                existingCallQueueCustomer.CallBackRequestedDate = prospectCustomer.CallBackRequestedDate;
            }

            existingCallQueueCustomer.AppointmentCancellationDate = (DateTime?)null;
            if (eacl != null && (lastCall == null || lastCall.DateCreated < eacl.DateCreated))
                existingCallQueueCustomer.AppointmentCancellationDate = eacl.DateCreated;

            existingCallQueueCustomer.DoNotContactUpdateSource = customer.DoNotContactUpdateSource;
            existingCallQueueCustomer.LanguageBarrierMarkedDate = customer.LanguageBarrierMarkedDate;
            existingCallQueueCustomer.IncorrectPhoneNumberMarkedDate = customer.IncorrectPhoneNumberMarkedDate;
            existingCallQueueCustomer.LanguageId = customer.LanguageId;

            if (customerTargeted != null)
            {
                existingCallQueueCustomer.TargetedYear = customerTargeted.ForYear;
                existingCallQueueCustomer.IsTargeted = customerTargeted.IsTargated;
            }
            
            existingCallQueueCustomer.ProductTypeId = customer.ProductTypeId;

            return existingCallQueueCustomer;
        }

        private IEnumerable<CallQueueCustomer> GetCallQueueCustomers(IEnumerable<long> customerIds, long callQueueId, long healthPlanId, long? eventId = null, long? campaignId = null, DateTime? noShowDate = null)
        {
            return customerIds.Select(customerId => new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = customerId, HealthPlanId = healthPlanId, EventId = eventId, CampaignId = campaignId, NoShowDate = noShowDate }).ToList();
        }

        public void SaveCallQueueCustomerForFillEvent(IEnumerable<OrderedPair<long, long>> eventCustomersPairs, long criteriaId, long healthPlanId, long callQueueId, IEnumerable<long> customerIds)//, IEnumerable<long> eventids
        {
            if (customerIds != null && customerIds.Any())
            {
                var callQueueCustomers = GetCallQueueCustomers(customerIds, callQueueId, healthPlanId, null, null);
                var existingCustomers = _callQueueCustomerRepository.GetCallQueueCustomerByHealthPlanId(healthPlanId, callQueueId).ToList();

                SaveCallQueueCustomerAndAssignment(callQueueCustomers, existingCustomers, criteriaId, healthPlanId, callQueueId, customerIds);//, eventids
            }
        }

        private void SaveCallQueueCustomerAndAssignment(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<CallQueueCustomer> existingCustomers, long criteriaId, long healthPlanId, long callQueueId,
            IEnumerable<long> customerIds)//, IEnumerable<long> eventids
        {
            int totalRecords = customerIds.Count();
            var pageNumber = 1;
            const int PageSize = 100;
            var firstDateOfYear = new DateTime(DateTime.Today.Year, 1, 1);

            var accountSetting = _callQueueSettingRepository.GetByAccountIdAndCallQueueId(healthPlanId, callQueueId);
            var maxDayCount = (from asetting in accountSetting
                               where asetting.SuppressionTypeId == (long)CallQueueSuppressionType.Others
                               select asetting.NoOfDays).FirstOrDefault();

            try
            {
                while (true)
                {
                    var pagedCusotmerIds = customerIds.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToArray();
                    var pagedcallQueueCusomers = callQueueCustomers.Where(x => pagedCusotmerIds.Contains(x.CustomerId.Value));

                    var callDetails = _centerCallRepository.GetCallByCustomerId(pagedCusotmerIds, firstDateOfYear, true);

                    var customers = _customerRepository.GetCustomers(pagedCusotmerIds);
                    var prospectCustomers = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(pagedCusotmerIds);

                    var eventCustomers = _eventCustomerRepository.GetByEventIdsOrCustomerIds(firstDateOfYear, pagedCusotmerIds);

                    var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(pagedCusotmerIds, DateTime.Today.Year);

                    var targetedCustomers = _customerTargetedRepository.GetCustomerTargetedByCustomerIdsAndYear(pagedCusotmerIds, DateTime.Today.Year);

                    eventCustomers = eventCustomers ?? new List<EventCustomer>();

                    var cancelledCustomersLog = (_eventAppointmentCancellationLogRepository.GetCancellationByCusomerIds(pagedCusotmerIds, DateTime.Today.AddDays(-maxDayCount)));


                    var appointmentIds = (from ec in eventCustomers
                                          where ec.AppointmentId.HasValue
                                          select ec.AppointmentId.Value).ToArray();

                    var appointments = _appointmentRepository.GetByIds(appointmentIds);

                    foreach (var callQueueCustomer in pagedcallQueueCusomers)
                    {
                        try
                        {
                            var customerId = callQueueCustomer.CustomerId;
                            var existingCallQueueCustomer = existingCustomers.FirstOrDefault(cq => (cq.CustomerId == customerId));
                            var customer = customers.First(x => x.CustomerId == callQueueCustomer.CustomerId);

                            var prospectCustomer = prospectCustomers.FirstOrDefault(p => p.CustomerId.Value == customerId);

                            var customerCalls = (from cd in callDetails
                                                 where cd.CalledCustomerId == customerId && cd.Status != (long)CallStatus.CallSkipped
                                                 select cd).ToArray();

                            var callAttempts = (from cd in callDetails
                                                where cd.CalledCustomerId == customerId && cd.CallQueueId.Value == callQueueId && cd.Status != (long)CallStatus.CallSkipped
                                                && (cd.IsContacted.HasValue && cd.IsContacted.Value)
                                                select cd).Count();

                            var customerswithAppointment = (from ec in eventCustomers
                                                            where ec.AppointmentId.HasValue
                                                            select ec).ToArray();

                            var appointmentDate = (from ec in customerswithAppointment
                                                   join a in appointments on ec.AppointmentId.Value equals a.Id
                                                   where ec.AppointmentId.HasValue && ec.CustomerId == customerId /*&& ec.AppointmentId.HasValue*/
                                                   && ec.NoShow == false
                                                   orderby a.StartTime descending
                                                   select a).FirstOrDefault();


                            var eacl = (from ccl in cancelledCustomersLog
                                        join ec in eventCustomers on ccl.EventCustomerId equals ec.Id
                                        where ec.AppointmentId == null && ec.CustomerId == customerId
                                        orderby ccl.DateCreated descending
                                        select ccl).FirstOrDefault();

                            var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customerId);

                            var targetedCustomer = targetedCustomers != null ? targetedCustomers.FirstOrDefault(x => x.CustomerId == customerId) : null;

                            var noShowMarkedEventCustomer = eventCustomers.Where(x => x.CustomerId == customerId);

                            existingCallQueueCustomer = CreateCustomerCallQueueCustomerModel(existingCallQueueCustomer, callQueueCustomer, customer, customerCalls,
                                callAttempts, appointmentDate, prospectCustomer, eacl, false, customerEligibility, noShowMarkedEventCustomer, targetedCustomer);

                            /*if (!eventids.IsNullOrEmpty())
                            {
                                existingCallQueueCustomer.EventIds = string.Join(",", eventids.ToArray()) + ",";
                            }*/
                            existingCallQueueCustomer.LastUpdatedOn = DateTime.Today;

                            var isNew = !(existingCallQueueCustomer.Id > 0);

                            existingCallQueueCustomer = _callQueueCustomerRepository.Save(existingCallQueueCustomer, isNew);

                            _healthPlanCallQueueAssignmentRepository.Save(new HealthPlanCallQueueCriteriaAssignment
                            {
                                CallQueueCustomerId = existingCallQueueCustomer.Id,
                                CallQueueId = callQueueCustomer.CallQueueId,
                                CriteriaId = criteriaId
                            });
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format("Error saving Call Queue Customer. \nMessage : {0} \nStack Trace : {1}", ex.Message, ex.StackTrace));
                        }
                    }

                    if ((pageNumber * PageSize) >= totalRecords)
                        break;

                    pageNumber++;
                }
            }
            catch (Exception)
            {
            }

        }

        public void SaveCallQueueCustomerForMailRound(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long callQueueCriteriaId, long callQueueId, long campaignId)
        {
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                var existingCustomers = _callQueueCustomerRepository.GetCallQueueCustomerByCampaignIdAndHealthPlanId(campaignId, healthPlanId, callQueueId);

                SaveCallQueueCustomerAndAssignment(callQueueCustomers, existingCustomers, callQueueCriteriaId, healthPlanId, callQueueId, callQueueCustomers.Select(x => x.CustomerId.Value));//, null
            }
        }

        public void SaveCallQueueCustomersForConfirmation(IEnumerable<CallQueueCustomer> callQueueCustomers, long healthPlanId, long callQueueCriteriaId, long callQueueId)
        {
            if (!callQueueCustomers.IsNullOrEmpty())
            {
                var existingCustomers = _callQueueCustomerRepository.GetByHealthPlanIdAndCallQueueId(healthPlanId, callQueueId).ToList();

                SaveConfirmationCallQueueCustomerAndAssignment(callQueueCustomers, existingCustomers, callQueueCriteriaId, healthPlanId, callQueueId, callQueueCustomers.Select(x => x.CustomerId.Value));
            }
        }

        private void SaveConfirmationCallQueueCustomerAndAssignment(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<CallQueueCustomer> existingCustomers, long criteriaId, long healthPlanId, long callQueueId,
            IEnumerable<long> customerIds)
        {
            int totalRecords = customerIds.Count();
            var pageNumber = 1;
            const int PageSize = 100;
            var firstDateOfYear = new DateTime(DateTime.Today.Year, 1, 1);

            try
            {
                while (true)
                {
                    var pagedCustomerIds = customerIds.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToArray();
                    var pagedcallQueueCusomers = callQueueCustomers.Where(x => pagedCustomerIds.Contains(x.CustomerId.Value));

                    var callDetails = _centerCallRepository.GetCallByCustomerId(pagedCustomerIds, firstDateOfYear, false);

                    var customers = _customerRepository.GetCustomers(pagedCustomerIds);

                    var eventCustomers = _eventCustomerRepository.GetByEventIdsOrCustomerIds(firstDateOfYear, pagedCustomerIds);

                    var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(pagedCustomerIds, DateTime.Today.Year);

                    var targetedCustomers = _customerTargetedRepository.GetCustomerTargetedByCustomerIdsAndYear(pagedCustomerIds, DateTime.Today.Year);

                    eventCustomers = eventCustomers ?? new List<EventCustomer>();


                    var appointmentIds = (from ec in eventCustomers
                                          where ec.AppointmentId.HasValue
                                          select ec.AppointmentId.Value).ToArray();

                    var appointments = _appointmentRepository.GetByIds(appointmentIds);

                    foreach (var callQueueCustomer in pagedcallQueueCusomers)
                    {
                        try
                        {
                            var customerId = callQueueCustomer.CustomerId;

                            var eventCustomerId = callQueueCustomer.EventCustomerId;

                            var existingCallQueueCustomer = existingCustomers.FirstOrDefault(cq => (cq.CustomerId == customerId && cq.EventCustomerId == eventCustomerId));

                            if (existingCallQueueCustomer != null && existingCallQueueCustomer.Disposition == ProspectCustomerTag.ConfirmLanguageBarrier.ToString())
                                continue;

                            var customer = customers.First(x => x.CustomerId == callQueueCustomer.CustomerId);

                            var customerCalls = (from cd in callDetails
                                                 where cd.CalledCustomerId == customerId && cd.Status != (long)CallStatus.CallSkipped
                                                 select cd).ToArray();

                            var callAttempts = (from cd in callDetails
                                                where cd.CalledCustomerId == customerId && cd.CallQueueId.Value == callQueueId
                                                && cd.Status != (long)CallStatus.CallSkipped
                                                select cd).Count();

                            var customerswithAppointment = (from ec in eventCustomers
                                                            where ec.AppointmentId.HasValue
                                                            select ec).ToArray();

                            var appointmentDate = (from ec in customerswithAppointment
                                                   join a in appointments on ec.AppointmentId.Value equals a.Id
                                                   where ec.AppointmentId.HasValue && ec.CustomerId == customerId && ec.AppointmentId.HasValue
                                                   orderby a.StartTime descending
                                                   select a).FirstOrDefault();

                            var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customerId);
                            var eventCustomersForCustomerId = eventCustomers.Where(x => x.CustomerId == customerId);

                            var eventCustomer = eventCustomers.FirstOrDefault(x => x.Id == eventCustomerId);

                            var targetedCustomer = targetedCustomers != null ? targetedCustomers.FirstOrDefault(x => x.CustomerId == customerId) : null;

                            existingCallQueueCustomer = CreateCustomerCallQueueCustomerModel(existingCallQueueCustomer, callQueueCustomer, customer, customerCalls,
                                callAttempts, appointmentDate, null, null, true, customerEligibility, eventCustomersForCustomerId, targetedCustomer);

                            existingCallQueueCustomer.EventId = callQueueCustomer.EventId;
                            existingCallQueueCustomer.EventCustomerId = callQueueCustomer.EventCustomerId;
                            existingCallQueueCustomer.AppointmentDate = callQueueCustomer.AppointmentDate;
                            existingCallQueueCustomer.AppointmentDateTimeWithTimeZone = callQueueCustomer.AppointmentDateTimeWithTimeZone;

                            if (eventCustomer != null && !eventCustomer.IsAppointmentConfirmed && existingCallQueueCustomer.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                            {
                                existingCallQueueCustomer.Disposition = null;
                            }

                            existingCallQueueCustomer.LastUpdatedOn = DateTime.Today;

                            var isNew = !(existingCallQueueCustomer.Id > 0);

                            existingCallQueueCustomer = _callQueueCustomerRepository.Save(existingCallQueueCustomer, isNew);

                            _healthPlanCallQueueAssignmentRepository.Save(new HealthPlanCallQueueCriteriaAssignment
                            {
                                CallQueueCustomerId = existingCallQueueCustomer.Id,
                                CallQueueId = existingCallQueueCustomer.CallQueueId,
                                CriteriaId = criteriaId
                            });
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format("Error saving Call Queue Customer. \nMessage : {0} \nStack Trace : {1}", ex.Message, ex.StackTrace));
                        }
                    }


                    if ((pageNumber * PageSize) >= totalRecords)
                        break;
                    pageNumber++;
                }
            }
            catch (Exception)
            {
            }

        }
    }
}