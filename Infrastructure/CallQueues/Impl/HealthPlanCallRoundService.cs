using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Scheduling.Impl;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCallRoundService : IHealthPlanCallRoundService
    {
        private readonly IHealthPlanCallQueueCustomerHelper _healthPlanCallQueueCustomerHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFillEventsCallQueueService _fillEventsCallQueueService;
        private readonly IHealthPlanFillEventCallQueueRepository _healthPlanFillEventCallQueueRepository;

        private readonly ISmsHelper _smsHelper;

        private readonly int _noPastAppointmentInDays;
        private readonly int _noPastAppointmentForUncontactedCustomer;
        private readonly int _neverBeenCalledInDays;



        public HealthPlanCallRoundService(IHealthPlanCallQueueCustomerHelper healthPlanCallQueueCustomerHelper, ICustomerRepository customerRepository, IFillEventsCallQueueService fillEventsCallQueueService, ISettings settings,
            IHealthPlanFillEventCallQueueRepository healthPlanFillEventCallQueueRepository, ISmsHelper smsHelper)
        {
            _healthPlanCallQueueCustomerHelper = healthPlanCallQueueCustomerHelper;
            _customerRepository = customerRepository;
            _fillEventsCallQueueService = fillEventsCallQueueService;
            _healthPlanFillEventCallQueueRepository = healthPlanFillEventCallQueueRepository;
            _smsHelper = smsHelper;

            _noPastAppointmentInDays = settings.NoPastAppointmentInDays;
            _noPastAppointmentForUncontactedCustomer = settings.NoPastAppointmentInDaysUncontactedCustomers;
            _neverBeenCalledInDays = settings.NeverBeenCalledInDays;
        }

        public void SaveCallRoundCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-CallRoundCallQueueCustomers HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                var customersList = _customerRepository.GetCustomersByHealthPlanForCallRound(corporateAccount.Tag, _noPastAppointmentInDays, queueCriteria.RoundOfCalls, queueCriteria.NoOfDays);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed-CallRoundCallQueueCustomers HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {
                logger.Error(string.Format("error while saving data from SaveCallRoundCallQueueCustomers. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        public void SaveNoShowCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-NoShowCallQueueCustomers HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var startDate = queueCriteria.StartDate.HasValue ? queueCriteria.StartDate.Value : new DateTime(DateTime.Today.Year, 1, 1);// DateTime.Now.AddDays(-_noPastAppointmentInDays);
                var endDate = queueCriteria.EndDate.HasValue ? queueCriteria.EndDate.Value : DateTime.Now.Date;
                var customersList = _customerRepository.GetCustomersMarkedNoShowForHealthPlanCallQueue(corporateAccount.Tag, startDate, endDate);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed-NoShowCallQueueCustomers HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {
                logger.Error(string.Format("error while saving data from SaveNoShowCallQueueCustomers. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }
        }

        public void SaveHealthPlanFillEventCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-FillEventCallQueueCustomers( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var eventCustomersPair = _fillEventsCallQueueService.GetHealthPlanCallQueueCustomers(callQueue.Id, queueCriteria, corporateAccount, _noPastAppointmentInDays, logger);

                if (!eventCustomersPair.IsNullOrEmpty())
                {
                    var customerIds = eventCustomersPair.Select(x => x.SecondValue).Distinct().ToArray();

                    var eventIds = eventCustomersPair.Select(x => x.FirstValue).Distinct();

                    logger.Info("Criteria Id: " + queueCriteria.Id + " Event Count " + eventIds.Count());

                    SaveFillEventQueueCriteria(eventIds, queueCriteria.Id);
                    //var eventIdtoAttchedtoCustomer = _healthPlanFillEventCallQueueRepository.GetEventIdsByHealthPlanIds(corporateAccount.Id, callQueue.Id);
                    logger.Info("Customer Count " + customerIds.Count());

                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(eventCustomersPair, queueCriteria.Id, corporateAccount.Id, callQueue.Id, customerIds);
                }

                logger.Info(string.Format("Completed-FillEventCallQueueCustomers( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {

                logger.Error(string.Format("error while saving data from SaveHealthPlanFillEventCallQueueCustomers call queue. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message: {0} \n stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        public void SaveHealthPlanZipRadiusCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-SaveHealthPlanZipRadiusCallQueueCustomers( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var customersList = _customerRepository.GetCustomersZipCodeRadiusCallQueue(corporateAccount.Tag, queueCriteria.ZipCode, queueCriteria.Radius ?? 0, _noPastAppointmentInDays);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed-SaveHealthPlanZipRadiusCallQueueCustomers( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {

                logger.Error(string.Format("error while saving data from health plan SaveHealthPlanZipRadiusCallQueueCustomers queue. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message: {0} \n stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        public void SaveHealthPlanUncontactedCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-SaveHealthPlanUncontactedCustomerCallQueue( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var customersList = _customerRepository.GetHealthPlanUncontactedCustomers(corporateAccount.Tag, _neverBeenCalledInDays, _noPastAppointmentForUncontactedCustomer);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed-SaveHealthPlanUncontactedCustomerCallQueue( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {

                logger.Error(string.Format("error while saving data from health plan SaveHealthPlanUncontactedCallQueueCustomers queue. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message: {0} \n stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        private IEnumerable<CallQueueCustomer> GetCallQueueCustomers(IEnumerable<long> customerIds, long callQueueId, long healthPlanId, long? eventId = null, long? campaignId = null)
        {
            return customerIds.Select(customerId => new CallQueueCustomer { CallQueueId = callQueueId, CustomerId = customerId, HealthPlanId = healthPlanId, EventId = eventId, CampaignId = campaignId }).ToList();
        }

        public void SaveMailRoundCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger, Campaign campaign)
        {
            try
            {
                var customersList = _customerRepository.GetCustomersByHealthPlanForMailRound(corporateAccount.Tag, campaign.CustomTags, campaign.Id, queueCriteria.Id);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id, null, campaign.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomerForMailRound(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id, campaign.Id);
                }

            }
            catch (Exception exception)
            {
                logger.Error(string.Format("error while saving data from SaveMailRoundCallQueueCustomers. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        public void SaveHealthPlanLanguageBarrierCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Started-SaveHealthPlanLanguageBarrierCustomerCallQueue( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var customersList = _customerRepository.GetHealthPlanLanguageBarrierCustomers(corporateAccount.Tag, _noPastAppointmentInDays);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = GetCallQueueCustomers(customersList, callQueue.Id, corporateAccount.Id);
                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed-SaveHealthPlanLanguageBarrierCustomerCallQueue( HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception exception)
            {

                logger.Error(string.Format("error while saving data from health plan SaveHealthPlanLanguageBarrierCallQueueCustomers queue. HealthPlanId: {0} callQueueId: {1} callqueueCriteria: {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message: {0} \n stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

        private void SaveFillEventQueueCriteria(IEnumerable<long> eventIds, long criteriaId)
        {
            foreach (var eventId in eventIds)
            {
                _healthPlanFillEventCallQueueRepository.Save(new HealthPlanFillEventCallQueue
                {
                    EventId = eventId,
                    CriteriaId = criteriaId
                });
            }

            /*var eventList = _eventRepository.GetEventsByIdsWithHostDetails(eventIds);

            if (eventList == null || !eventList.Any())
                return;

            var hostIds = eventList.Select(x => x.HostId);

            var eventZipPairList = new List<OrderedPair<long, string>>();

            var hostIdZipCodePairs = _hostRepository.GetHostZipId(hostIds);

            foreach (var theEvent in eventList)
            {
                var host = hostIdZipCodePairs.First(h => h.FirstValue == theEvent.HostId);

                eventZipPairList.Add(new OrderedPair<long, string>(theEvent.Id, host.SecondValue));
            }

            var zipList = eventZipPairList.Select(x => x.SecondValue).Distinct().ToList();
            //var zipZipIdsPairList = new List<OrderedPair<string, string>>();
            var zipCodeZipIdsList = new List<OrderedPair<string, IEnumerable<long>>>();

            foreach (var zip in zipList)
            {
                var zipIdsInRange = _zipCodeRepository.GetZipCodesInRadius(zip, 25).Select(x => x.Id).ToArray();
                
                zipCodeZipIdsList.Add(new OrderedPair<string, IEnumerable<long>>(zip, zipIdsInRange));
            }
            
            foreach (var eventZipPair in eventZipPairList.Distinct())
            {
                _healthPlanFillEventCallQueueRepository.Save(new HealthPlanFillEventCallQueue
                {
                    EventId = eventZipPair.FirstValue,
                    CriteriaId = criteriaId
                });

                _healthPlanFillEventCallQueueRepository.DeleteEventZipByEventId(eventZipPair.FirstValue);

                var zipCodeZipListPair = zipCodeZipIdsList.FirstOrDefault(x => x.FirstValue == eventZipPair.SecondValue);
                if (zipCodeZipListPair != null)
                {
                    foreach (var zipId in zipCodeZipListPair.SecondValue.Distinct())
                    {
                        _healthPlanFillEventCallQueueRepository.SaveEventZips(eventZipPair.FirstValue, zipId);
                    }
                }
            }*/
        }

        public void SaveHealthPlanConfirmationCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger)
        {
            try
            {
                logger.Info(string.Format("Starting confirmation call queue generation for HealthPlanId: {0} CallQueueId: {1} CriteriaId : {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));

                var customersList = _customerRepository.GetHealthPlanConfirmationQueueCustomers(corporateAccount);

                if (!customersList.IsNullOrEmpty())
                {
                    var callQueueCustomerList = new List<CallQueueCustomer>();
                    foreach (var customer in customersList)
                    {
                        var appointmentTime = customer.EventDate.Date.Add(customer.AppointmentTime.TimeOfDay);
                        var callQueueCustomer = new CallQueueCustomer
                        {
                            CallQueueId = callQueue.Id,
                            CustomerId = customer.CustomerId,
                            HealthPlanId = corporateAccount.Id,
                            EventId = customer.EventId,
                            EventCustomerId = customer.EventCustomerId,
                            AppointmentDate = appointmentTime,
                            AppointmentDateTimeWithTimeZone = _smsHelper.ConvertToServerTime(appointmentTime, customer.TimeZone, !SmsHelper.DaylightSavingNotApplicableStates.Contains(customer.StateCode))
                        };

                        callQueueCustomerList.Add(callQueueCustomer);
                    }

                    logger.Info(" Count " + callQueueCustomerList.Count());
                    _healthPlanCallQueueCustomerHelper.SaveCallQueueCustomersForConfirmation(callQueueCustomerList, corporateAccount.Id, queueCriteria.Id, callQueue.Id);
                }

                logger.Info(string.Format("Completed confirmation call queue generation for HealthPlanId: {0} CallQueueId: {1} CriteriaId : {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
            }
            catch (Exception ex)
            {

                logger.Error(string.Format("Error generating confirmation queue for HealthPlanId: {0} CallQueueId: {1} CriteriaId : {2}", corporateAccount.Id, callQueue.Id, queueCriteria.Id));
                logger.Error(string.Format("Message : {0} \nStack Trace : {1}", ex.Message, ex.StackTrace));
            }

        }
    }
}