using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class FillEventsCallQueueService : IFillEventsCallQueueService
    {
        private readonly IHostRepository _hostRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IFillEventsCallQueueHelper _fillEventsCallQueueHelper;
        private readonly ISettings _settings;

        public FillEventsCallQueueService(IEventRepository eventRepository, IHostRepository hostRepository, ICustomerRepository customerRepository,
            IProspectCustomerRepository prospectCustomerRepository, IZipCodeRepository zipCodeRepository, IFillEventsCallQueueHelper fillEventsCallQueueHelper, ISettings settings)
        {
            _hostRepository = hostRepository;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _zipCodeRepository = zipCodeRepository;
            _eventRepository = eventRepository;
            _fillEventsCallQueueHelper = fillEventsCallQueueHelper;
            _settings = settings;
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, SystemGeneratedCallQueueCriteria criteria)
        {
            var days = criteria.NoOfDays;
            var percentage = criteria.Percentage;

            var endDate = DateTime.Today.AddDays(days);

            var eventList = _eventRepository.GetEventsForFillEventsCallQueue(endDate);
            if (eventList == null || !eventList.Any())
                return null;

            eventList = _fillEventsCallQueueHelper.GetAllTheEventFilledUnderPecentage(eventList, percentage);
            if (eventList == null || !eventList.Any())
                return null;

            var eventIds = eventList.Select(x => x.Id);

            var eventZipPairList = new List<OrderedPair<long, string>>();

            var hostList = _hostRepository.GetEventHosts(eventIds);
            foreach (var theEvent in eventList)
            {
                var host = hostList.FirstOrDefault(h => h.Id == theEvent.HostId);
                if (host != null)
                {
                    eventZipPairList.Add(new OrderedPair<long, string>(theEvent.Id, host.Address.ZipCode.Zip));
                }
            }

            var zipList = eventZipPairList.Select(x => x.SecondValue).Distinct().ToList();
            var zipZipStringPairList = new List<OrderedPair<string, string>>();
            foreach (var zip in zipList)
            {
                var zipCodesInRange = _zipCodeRepository.GetZipCodesInRadius(zip, 10) ??
                                          new List<ZipCode>();
                if (!zipCodesInRange.Any())
                    zipZipStringPairList.Add(new OrderedPair<string, string>(zip, "," + zip + ","));
                else
                {
                    var zipCodestring = "," + string.Join(",", zipCodesInRange) + ",";
                    zipZipStringPairList.Add(new OrderedPair<string, string>(zip, zipCodestring));
                }
            }
            var customers = _customerRepository.GetCustomerForFillEventCallQueue(eventZipPairList, zipZipStringPairList);

            var pcustomers = _prospectCustomerRepository.GetProspectCustomerForFillEventCallQueue(eventZipPairList, zipZipStringPairList);

            if ((customers == null || !customers.Any()) && (pcustomers == null || !pcustomers.Any()))
                return null;

            var callQueueCustomerList = new List<CallQueueCustomer>();
            if (customers != null && customers.Any())
            {
                foreach (var customer in customers)
                {
                    callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, EventId = customer.FirstValue, CustomerId = customer.SecondValue });
                }
            }

            if (pcustomers != null && pcustomers.Any())
            {
                foreach (var pcustomer in pcustomers)
                {
                    if (callQueueCustomerList.Any(cqcl => cqcl.CustomerId == pcustomer.CustomerId && cqcl.EventId == pcustomer.EventId))
                        continue;
                    callQueueCustomerList.Add(new CallQueueCustomer { CallQueueId = callQueueId, ProspectCustomerId = pcustomer.ProspectCustomerId, CustomerId = pcustomer.CustomerId, EventId = pcustomer.EventId });
                }
            }


            return callQueueCustomerList;
        }

        public IEnumerable<OrderedPair<long, long>> GetHealthPlanCallQueueCustomers(long callQueueId, HealthPlanCallQueueCriteria criteria, CorporateAccount healthPlan, int pastAppointmentDays, ILogger logger)
        {
            var days = criteria.NoOfDays;
            var percentage = criteria.Percentage;

            var endDate = DateTime.Today.AddDays(days);

            logger.Info(string.Format("HealthPlanId: {0}, CallQueueId: {1}, CriteriaId: {2}", healthPlan.Id, callQueueId, criteria.Id));
            logger.Info(string.Format("Percentage: {0}, NoOfDays: {1}, EndDate: {2}", percentage, days, endDate));

            IEnumerable<Event> eventList = null;

            var eventForNonMammoPatient = _eventRepository.GetEventsForHealthPlanFillEventsCallQueue(endDate, healthPlan.Id, true);
            var eventForMammoPatient = _eventRepository.GetEventsForHealthPlanFillEventsCallQueue(endDate, healthPlan.Id, false);
            
            eventList = eventForNonMammoPatient;

            if (eventList != null)
                eventList = eventList.Concat(eventForMammoPatient);
            else
                eventList = eventForMammoPatient;

            if (eventList == null || !eventList.Any())
                return null;

            eventList = _fillEventsCallQueueHelper.GetAllTheEventFilledUnderPecentage(eventList, percentage);
            if (eventList == null || !eventList.Any())
                return null;

            if (eventForMammoPatient != null && eventForMammoPatient.Any())
                logger.Info("Mammo Event count: " + eventForMammoPatient.Count());
            else
                logger.Info("No Mammo Event found");

            if (eventForNonMammoPatient != null && eventForNonMammoPatient.Any())
                logger.Info("Non-Mammo Event count: " + eventForNonMammoPatient.Count());
            else
                logger.Info("No Non-Mammo Event found");

            var hostIds = eventList.Select(x => x.HostId);

            var eventZipMammoListModel = new List<EventZipMammoModel>();

            var hostIdZipCodePairs = _hostRepository.GetHostZipId(hostIds);

            foreach (var theEvent in eventList)
            {
                var host = hostIdZipCodePairs.First(h => h.FirstValue == theEvent.HostId);

                eventZipMammoListModel.Add(new EventZipMammoModel
                {
                    EventId = theEvent.Id,
                    ZipId = host.SecondValue,
                    IsNonMammoEvent = (eventForNonMammoPatient != null && eventForNonMammoPatient.Any(x => x.Id == theEvent.Id))
                });
            }

            var customers = _customerRepository.GetCustomerForHealthPlanFillEventCallQueue(eventZipMammoListModel, healthPlan.Tag, _settings.FillEventZipRadius, logger);

            return customers;
        }
    }
}
