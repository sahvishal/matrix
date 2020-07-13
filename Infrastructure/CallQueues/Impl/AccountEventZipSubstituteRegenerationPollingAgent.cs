using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class AccountEventZipSubstituteRegenerationPollingAgent : IAccountEventZipSubstituteRegenerationPollingAgent
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IHealthPlanEventZipRepository _healthPlanEventZipRepository;
        private readonly IAccountEventZipReposiory _accountEventZipReposiory;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly IZipRadiusDistanceRepository _zipRadiusDistanceRepository;
        private readonly IHealthPlanFillEventCallQueueRepository _healthPlanFillEventCallQueueRepository;

        private readonly ILogger _logger;
        private readonly ISettings _settings;

        private readonly string _settingFilePath;

        public AccountEventZipSubstituteRegenerationPollingAgent(ILogManager logManager, ICorporateAccountRepository corporateAccountRepository, ISettings settings,
            IEventRepository eventRepository, IHostRepository hostRepository, IHealthPlanEventZipRepository healthPlanEventZipRepository,
            IAccountEventZipReposiory accountEventZipReposiory, IEventAppointmentStatsService eventAppointmentStatsService, IZipRadiusDistanceRepository zipRadiusDistanceRepository,
            IHealthPlanFillEventCallQueueRepository healthPlanFillEventCallQueueRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _healthPlanEventZipRepository = healthPlanEventZipRepository;
            _accountEventZipReposiory = accountEventZipReposiory;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _zipRadiusDistanceRepository = zipRadiusDistanceRepository;
            _healthPlanFillEventCallQueueRepository = healthPlanFillEventCallQueueRepository;

            _logger = logManager.GetLogger("AccountEventZipSubstituteRegeneration");
            _settings = settings;

            _settingFilePath = settings.AccountZipRegenerationResourcePath;
        }

        public void PollForRegeneration()
        {
            try
            {
                if (!_settings.RegenerateAccountEventZip)
                {
                    _logger.Info("Unable to start the service as Regeneration is set to false.");
                    return;
                }

                var timeOfDay = DateTime.Now;
                _logger.Info("Time of day : " + timeOfDay.ToString("HH:mm:ss"));

                var startTime = new TimeSpan(_settings.AccountZipSubstituteStartTime, 0, 0);
                var endTime = new TimeSpan(_settings.AccountZipSubstituteEndTime, 0, 0);

                if (_settings.IsDevEnvironment == false && (timeOfDay.TimeOfDay < startTime || timeOfDay.TimeOfDay > endTime))
                {
                    _logger.Info(string.Format("Account Event Zip is generated only between {0} and {1}.", startTime.ToString(), endTime.ToString()));
                    return;
                }

                _logger.Info("Starting Account Event Zip Regeneration Service.");
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                if (healthPlans.IsNullOrEmpty())
                {
                    _logger.Info("No Healthplans found for regeeration.");
                    return;
                }

                var settingFilePath = Path.Combine(_settingFilePath, "AccountEventZipRegeneration.xml");
                var generationSetting = Deserialize(settingFilePath);

                if (generationSetting.LastGeneratedTable == AccountEventZipGenerationType.AccountEventZipSubstitute.ToString())
                    _logger.Info("Regenerating for table : " + AccountEventZipGenerationType.AccountEventZip);
                else
                    _logger.Info("Regenerating for table : " + AccountEventZipGenerationType.AccountEventZipSubstitute);

                try
                {
                    foreach (var healthPlan in healthPlans)
                    {
                        _logger.Info(string.Format("Regenerating Account Event Zip for AccountID : {0} and Tag : {1}", healthPlan.Id, healthPlan.Tag));
                        InsertAccountEventZip(healthPlan.Id, healthPlan.Tag, generationSetting);
                    }

                    foreach (var healthPlan in healthPlans)
                    {
                        _logger.Info(string.Format("Deleting for AccountID : {0} and Tag : {1}", healthPlan.Id, healthPlan.Tag));
                        if (generationSetting.LastGeneratedTable == AccountEventZipGenerationType.AccountEventZipSubstitute.ToString())
                            _accountEventZipReposiory.DeleteFromSubstitute(healthPlan.Id);
                        else
                            _accountEventZipReposiory.Delete(healthPlan.Id);
                    }

                    if (generationSetting.LastGeneratedTable == AccountEventZipGenerationType.AccountEventZipSubstitute.ToString())
                        generationSetting.LastGeneratedTable = AccountEventZipGenerationType.AccountEventZip.ToString();
                    else
                        generationSetting.LastGeneratedTable = AccountEventZipGenerationType.AccountEventZipSubstitute.ToString();

                    generationSetting.LastGenerationDateTime = timeOfDay;

                    SerializeandSave(settingFilePath, generationSetting);

                    _logger.Info("Completed Account Event Zip Regeneration Service.");
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error Occured While Regenerating Account Event Zip. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error Occured While Regenerating Account Event Zip. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private void InsertAccountEventZip(long accountId, string tag, AccountEventZipSetting generationSetting)
        {
            var fromDate = DateTime.Today.AddDays(1);
            var rangeInMiles = _settings.ZipRangeInMiles;

            var events = _eventRepository.GetEventsByAccountIdAndDate(accountId, fromDate, null, true);
            var eventAppointmentStatsModels = _eventAppointmentStatsService.GetStats(events);

            var eventIds = !eventAppointmentStatsModels.IsNullOrEmpty() ? eventAppointmentStatsModels.Where(x => x.FreeSlots > 0 || x.IsDynamicScheduling).Select(x => x.EventId) : null;

            if (eventIds.IsNullOrEmpty())
            {
                _logger.Info("No events found.");
                return;
            }

            _logger.Info("Events found : " + eventIds.Count());

            var zipIds = new List<long>();
            var hostList = _hostRepository.GetEventHosts(eventIds);

            foreach (var host in hostList)
            {
                var zipcodes = _zipRadiusDistanceRepository.GetBySourceZipIdAndRadius(host.Address.ZipCode.Id, rangeInMiles);

                if (!zipcodes.IsNullOrEmpty())
                {
                    var hostZipIds = zipcodes.Select(x => x.DestinationZipId);
                    zipIds.AddRange(hostZipIds);

                    var recentlyCreatedEvents = events.Where(x => x.HostId == host.Id && x.DataRecorderMetaData.DateCreated > generationSetting.LastGenerationDateTime);

                    _logger.Info("Generating event zip for recently created events. Count : " + recentlyCreatedEvents.Count());

                    foreach (var recentlyCreatedEvent in recentlyCreatedEvents)
                    {
                        if (_healthPlanFillEventCallQueueRepository.IsEventZipAlreadyGenerated(recentlyCreatedEvent.Id))
                        {
                            _logger.Info("Event Zip already generated for EventID : " + recentlyCreatedEvent.Id);
                            continue;
                        }

                        _healthPlanFillEventCallQueueRepository.DeleteEventZipByEventId(recentlyCreatedEvent.Id);
                        foreach (var zipId in hostZipIds)
                        {
                            _healthPlanFillEventCallQueueRepository.SaveEventZips(recentlyCreatedEvent.Id, zipId);
                        }
                    }
                }
            }

            if (generationSetting.LastGeneratedTable == AccountEventZipGenerationType.AccountEventZipSubstitute.ToString())
                _accountEventZipReposiory.Save(accountId, zipIds.Distinct().ToArray());
            else
                _accountEventZipReposiory.SaveSubstitute(accountId, zipIds.Distinct().ToArray());

            //var healthPlanEventZip = new HealthPlanEventZip()
            //{
            //    AccountID = accountId,
            //    AccountTag = tag,
            //    DateCreated = DateTime.Now,
            //    IsQueueGenerated = true
            //};

            //_healthPlanEventZipRepository.Save(healthPlanEventZip);
        }

        private void SerializeandSave(string fileName, AccountEventZipSetting setting)
        {
            if (setting == null) return;

            var serializer = new XmlSerializer(setting.GetType());

            if (Path.GetDirectoryName(fileName) == null || !DirectoryOperationsHelper.IsDirectoryExist(Path.GetDirectoryName(fileName)))
            {
                DirectoryOperationsHelper.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            if (DirectoryOperationsHelper.IsFileExist(fileName)) DirectoryOperationsHelper.Delete(fileName);

            var stream = new StreamWriter(fileName);

            serializer.Serialize(stream, setting);

            stream.Close();
            stream.Dispose();
        }

        private AccountEventZipSetting Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                SerializeandSave(fileName, new AccountEventZipSetting());
            };

            var serializer = new XmlSerializer(typeof(AccountEventZipSetting));
            var stream = new StreamReader(fileName);

            var records = serializer.Deserialize(stream);

            stream.Close();
            stream.Dispose();

            if (records is AccountEventZipSetting)
                return records as AccountEventZipSetting;

            return null;
        }
    }
}
