using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class EventZipProductTypeService : IEventZipProductTypeService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventProductTypeRepository _eventProductTypeRepository;
        private readonly IEventZipProductTypeRepository _eventZipProductTypeRepository;
        public EventZipProductTypeService(ICorporateAccountRepository corporateAccountRepository, IEventRepository eventRepository, IHostRepository hostRepository,
            IEventProductTypeRepository eventProductTypeRepository, IEventZipProductTypeRepository eventZipProductTypeRepository)
        {

            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _eventProductTypeRepository = eventProductTypeRepository;
            _eventZipProductTypeRepository = eventZipProductTypeRepository;
        }
        public void SaveEventZipProductType(ILogger logger)
        {
            try
            {
                logger.Info("Starting Event Zip Product Type Service.");
                InsertEventZipProduct(logger);
                logger.Info("Starting Event Zip Product Type Service.");
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error Occured While Processing The Event Zip Product Type. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private void InsertEventZipProduct(ILogger logger)
        {
            var currentDate = DateTime.Today.AddDays(1);
            var events = _eventRepository.GetEventsFutureDate(currentDate);
            if (events.IsNullOrEmpty())
            {
                logger.Info("Future Events not found.");
                return;
            }
            var eventIds = events.Select(e => e.Id).Distinct();
            var hostList = _hostRepository.GetEventHosts(eventIds);
            if (hostList.IsNullOrEmpty())
            {
                logger.Info("Host Data not found.");
                return;
            }
            var eventProductList = _eventProductTypeRepository.GetByEventIds(eventIds);
            if (eventProductList.IsNullOrEmpty())
            {
                logger.Info("event Product List not found.");
                return;
            }
            if (!eventIds.IsNullOrEmpty())
            {
                try
                {
                    foreach (var eventId in events)
                    {
                        var eventProduct = eventProductList.Where(x => x.EventID == eventId.Id);
                        var hostEvents = hostList.Where(x => x.Id == eventId.HostId).FirstOrDefault();
                        var zipId = hostEvents.Address.ZipCode.Id;
                        if (eventProduct != null)
                        {
                            foreach (var item in eventProduct)
                            {
                                var EventZipProductType = new EventZipProductType()
                                {
                                    ProductTypeId = item.ProductTypeId,
                                    ZipId = zipId
                                };
                                _eventZipProductTypeRepository.SaveEventZipProductType(EventZipProductType);
                            }
                            logger.Info("Successfully Saved Event Zip Product Type Data For Event ID: " + eventId.Id);
                        }

                    }
                    _eventZipProductTypeRepository.DeleteEventZipProductTypeSubstitute();
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("Error Occurred While Saving event Data For" + ex.ToString()));
                }
            }

        }

        public void EventZipProductTypeSubstitute(ILogger logger)
        {
            try
            {
                logger.Info("Starting Event Zip Product Type Substitute Service.");
                InsertEventZipProductTypeSubstitute(logger);
                logger.Info("Starting Event Zip Product Type Substitute Service.");
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error Occured While Processing The Event Zip Product Type Substitute. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
        private void InsertEventZipProductTypeSubstitute(ILogger logger)
        {
            var currentDate = DateTime.Today.AddDays(1);
            var events = _eventRepository.GetEventsFutureDate(currentDate);
            if (events.IsNullOrEmpty())
            {
                logger.Info("Future Events not found.");
                return;
            }
            var eventIds = events.Select(e => e.Id).Distinct();
            var hostList = _hostRepository.GetEventHosts(eventIds);
            if (hostList.IsNullOrEmpty())
            {
                logger.Info("Host Data not found.");
                return;
            }
            var eventProductList = _eventProductTypeRepository.GetByEventIds(eventIds);
            if (eventProductList.IsNullOrEmpty())
            {
                logger.Info("event Product List not found.");
                return;
            }

            if (!eventIds.IsNullOrEmpty())
            {
                try
                {
                   
                    foreach (var eventId in events)
                    {
                        var eventProduct = eventProductList.Where(x => x.EventID == eventId.Id);
                        var hostEvents = hostList.Where(x => x.Id == eventId.HostId).FirstOrDefault();
                        var zipId = hostEvents.Address.ZipCode.Id;
                        if (eventProduct != null)
                        {
                            foreach (var item in eventProduct)
                            {
                                var EventZipProductType = new EventZipProductType()
                                {
                                    ProductTypeId = item.ProductTypeId,
                                    ZipId = zipId
                                };
                                _eventZipProductTypeRepository.SaveEventZipProductTypeSubstitute(EventZipProductType);
                            }
                            logger.Info("Successfully Saved Event Zip Product Type Data For Event ID: " + eventId.Id);
                        }

                    }
                    _eventZipProductTypeRepository.DeleteEventZipProductType();
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("Error Occurred While Saving event Data For" + ex.ToString()));
                }

            }
        }
    }
}
