using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanEventZipService : IHealthPlanEventZipService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanEventZipRepository _healthPlanEventZipRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly ISettings _settings;
        private readonly IAccountEventZipReposiory _accountEventZipReposiory;
        private readonly IHealthPlanFillEventCallQueueRepository _healthPlanFillEventCallQueueRepository;
        private readonly IZipRadiusDistanceRepository _zipRadiusDistanceRepository;

        public HealthPlanEventZipService(ICorporateAccountRepository corporateAccountRepository, IHealthPlanEventZipRepository healthPlanEventZipRepository, 
            IEventRepository eventRepository, IHostRepository hostRepository, ISettings settings,IAccountEventZipReposiory accountEventZipReposiory,
            IHealthPlanFillEventCallQueueRepository healthPlanFillEventCallQueueRepository,IZipRadiusDistanceRepository zipRadiusDistanceRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanEventZipRepository = healthPlanEventZipRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _settings = settings;
            _accountEventZipReposiory = accountEventZipReposiory;
            _healthPlanFillEventCallQueueRepository = healthPlanFillEventCallQueueRepository;
            _zipRadiusDistanceRepository = zipRadiusDistanceRepository;
        }

        public void SaveHealthPlanEventZip(ILogger logger)
        {
            try
            {
                logger.Info("Starting Healthplan Event Zip Service.");
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                if (!healthPlans.IsNullOrEmpty())
                {
                    foreach (var healthPlan in healthPlans)
                    {
                        InsertHealthplanEventZipCode(healthPlan.Id, healthPlan.Tag, logger);
                    }

                    logger.Info("Successfully completed Healthplan Event Zip Service.");
                }

                logger.Info("Starting Healthplan Event Zip Service.");
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error Occured While Processing The Healthplan Event Zip Service. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        public void SaveHealthPlanEventZipForQueueNotGenerated(ILogger logger)
        {
            try
            {
                logger.Info("Starting Healthplan Event Zip Service For Queue Not Generated.");

                var healthPlanEventZips = _healthPlanEventZipRepository.GetByIsQueueGenerated(false);

                if (!healthPlanEventZips.IsNullOrEmpty())
                {
                    foreach (var healthPlanEventZip in healthPlanEventZips)
                    {
                        InsertHealthplanEventZipCode(healthPlanEventZip.AccountID, healthPlanEventZip.AccountTag, logger);
                    }

                    logger.Info("Successfully completed Healthplan Event Zip Service For Queue Not Generated.");
                }
                else
                {
                    logger.Info("No Record Found.");
                }

                logger.Info("Stop Healthplan Event Zip Service For Queue Not Generated.");
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error Occured While Processing The Healthplan Event Zip Service For Queue Not Generated. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private void InsertHealthplanEventZipCode(long accountId, string tag, ILogger logger)
        {
            var currentDate = DateTime.Today.AddDays(1);
            var rangeInMiles = _settings.ZipRangeInMiles;
            
            var events = _eventRepository.GetEventsByAccountIdAndDate(accountId, currentDate, null, true);
            var eventIds = events.Select(e => e.Id);

            if (!eventIds.IsNullOrEmpty())
            {
                try
                {
                    var zipIds = new List<long>();
                    var hostList = _hostRepository.GetEventHosts(eventIds);

                    foreach (var host in hostList)
                    {
                        //var zipcodes = _zipCodeRepository.GetZipCodesInRadius(host.Address.ZipCode.Zip, rangeInMiles);
                        //var hostZipIds = zipcodes.Select(x => x.Id);
                        //if (!zipcodes.IsNullOrEmpty())
                        //    zipIds.AddRange(hostZipIds);

                        //var hostEvents = events.Where(x => x.HostId == host.Id);
                        //foreach (var hostEvent in hostEvents)
                        //{
                        //    _healthPlanFillEventCallQueueRepository.DeleteEventZipByEventId(hostEvent.Id);
                        //    foreach (var zipId in hostZipIds)
                        //    {
                        //        _healthPlanFillEventCallQueueRepository.SaveEventZips(hostEvent.Id, zipId);
                        //    }
                        //}

                        var zipcodes = _zipRadiusDistanceRepository.GetBySourceZipIdAndRadius(host.Address.ZipCode.Id, rangeInMiles);
                        if (!zipcodes.IsNullOrEmpty())
                        {
                            var hostZipIds = zipcodes.Select(x => x.DestinationZipId);
                            zipIds.AddRange(hostZipIds);
                            if (!hostZipIds.IsNullOrEmpty())
                            {
                                var hostEvents = events.Where(x => x.HostId == host.Id);
                                foreach (var hostEvent in hostEvents)
                                {
                                    _healthPlanFillEventCallQueueRepository.DeleteEventZipByEventId(hostEvent.Id);
                                    foreach (var zipId in hostZipIds)
                                    {
                                        _healthPlanFillEventCallQueueRepository.SaveEventZips(hostEvent.Id, zipId);
                                    }
                                }
                            }
                        }
                    }

                    //var stringZipIds = string.Empty;

                    //if (!zipIds.IsNullOrEmpty())
                    //{
                    //    stringZipIds = string.Join(",", zipIds.Distinct().ToArray());
                    //}
                    
                    _accountEventZipReposiory.Save(accountId, zipIds.Distinct().ToArray());

                    logger.Info("Successfully Saved Healthplan Event Zip Data For Account ID: " + accountId);
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("Error Occurred While Saving Account Zip Data For Account ID: {0}.\n Message {1} \n Stack Trace {2}", accountId, ex.Message, ex.StackTrace));
                }

            }

            try
            {

                var healthPlanEventZip = new HealthPlanEventZip()
                {
                    AccountID = accountId,
                    AccountTag = tag,
                    DateCreated = currentDate,
                    IsQueueGenerated = true
                };

                _healthPlanEventZipRepository.Save(healthPlanEventZip);
            }
            catch (Exception exception)
            {
                
                logger.Error("some error occurred while saving HealthPlanEventZip");
                logger.Error("Message: " + exception.Message);
                logger.Error("Stack trace: " + exception.StackTrace);
            }

        }
    }
}
