using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncEventTestPollingAgent : ISyncEventTestPollingAgent
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _settings;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ILogger _logger;
        private readonly IXmlSerializer<CustomSettings> _customSettingXmlSerializer;

        public SyncEventTestPollingAgent(ILogManager logManager, ICorporateAccountRepository corporateAccountRepository, ISettings settings, IXmlSerializer<CustomSettings> customSettingXmlSerializer,
            IMedicareApiService medicareApiService, IEventTestRepository eventTestRepository, IEventRepository eventRepository)
        {
            _logger = logManager.GetLogger("SyncEventTestPollingAgent");
            _corporateAccountRepository = corporateAccountRepository;
            _settings = settings;
            _medicareApiService = medicareApiService;
            _eventTestRepository = eventTestRepository;
            _eventRepository = eventRepository;
            _customSettingXmlSerializer = customSettingXmlSerializer;
        }

        public void Sync()
        {
            if (!_settings.SyncWithHra)
            {
                _logger.Info("Syncing with HRA is off ");
                return;
            }
            var reportGenerationConfigurationFilePath = _settings.MedicareSyncCustomSettingsPath + "EventTestSync.xml";
            var customSettings = _customSettingXmlSerializer.Deserialize(reportGenerationConfigurationFilePath);
            if (customSettings == null || !customSettings.LastTransactionDate.HasValue)
            {
                customSettings = new CustomSettings { LastTransactionDate = DateTime.Today };
            }
            var fromTime = customSettings.LastTransactionDate ?? DateTime.Today;
            //get all tags for IsHealthPlan is true
            var orgName = _settings.OrganizationNameForHraQuestioner;
            var tags = _corporateAccountRepository.GetHealthPlanTags();

            if (tags != null && tags.Any())
            {
                foreach (var tag in tags)
                {
                    _logger.Info("Medicare Event Test Sync for tag : " + tag);

                    // get todays Events For the Tag

                    var eventIds = _eventRepository.GetEventsByTag(fromTime, tag);
                    if (eventIds.Any())
                    {
                        _logger.Info("Medicare Event Count  : " + eventIds.Count + " " + String.Join(",", eventIds));
                        var pairs = _eventTestRepository.GetTestAliasesByEventIds(eventIds).ToList();
                        var model = new MedicareEventTestSyncModel { Tag = tag, EventTestAliases = pairs, OrganizationName = orgName, TimeToken = DateTime.UtcNow.ToLongTimeString().Encrypt() };
                        try
                        {
                            var result = _medicareApiService.PostAnonymous<bool>(_settings.MedicareApiUrl + MedicareApiUrl.SyncEventTest, model);
                            if (!result)
                                _logger.Info("Medicare Event Test Sync FAILED for tag : " + tag);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error(" error occur Medicare Event Test Sync for tag: " + tag +
                                          " Message: " + exception.Message + "\n stack Trace: " +
                                          exception.StackTrace);
                        }
                    }

                }
            }
            customSettings.LastTransactionDate = DateTime.Today;
            _customSettingXmlSerializer.SerializeandSave(reportGenerationConfigurationFilePath, customSettings);
        }
    }
}
