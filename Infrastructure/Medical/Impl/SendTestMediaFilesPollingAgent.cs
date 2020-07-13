using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendTestMediaFilesPollingAgent : ISendTestMediaFilesPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IEventRepository _eventRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;

        public SendTestMediaFilesPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, IMediaRepository mediaRepository, ISettings settings, ILogManager logManager, ICustomSettingManager customSettingManager, IEventRepository eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, ICustomerRepository customerRepository)
        {
            _logger = logManager.GetLogger("SendTestMediaFilesPollingAgent");
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _customSettingManager = customSettingManager;
            _eventRepository = eventRepository;
            _resultPdfDownloadHelper = resultPdfDownloadHelper;
        }

        public void PollForSendTestMediaFiles()
        {
            try
            {
                var testIds = _settings.IpSendMediaFilesForTestIds;
                if (!testIds.Any())
                {
                    _logger.Info("No Test id found in config, please provide TestIds.");
                    return;
                }

                var customSettings = _customSettingManager.Deserialize(_settings.SendTestMediaFilesSettings);

                DateTime exportToTime = DateTime.Now;
                DateTime exportFromTime = DateTime.Now;
                if (customSettings.LastTransactionDate == null)
                {
                    exportFromTime = _settings.SendTestMediaFilesCutoffDate;
                    exportToTime = DateTime.Now;
                }
                else
                {
                    exportFromTime = customSettings.LastTransactionDate.Value.AddMinutes(-20);
                    exportToTime = customSettings.LastTransactionDate.Value.AddMinutes(-10);
                }

                customSettings.LastTransactionDate = DateTime.Now;
                _customSettingManager.SerializeandSave(_settings.SendTestMediaFilesSettings, customSettings);

                var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultByTestIds(testIds, exportFromTime, exportToTime);
                if (!eventCustomerResults.Any())
                {
                    _logger.Info("No Customers found.");
                    return;
                }

                _logger.Info(string.Format("Found {0} customers for Media file copy. ", eventCustomerResults.Count()));

                foreach (var ecr in eventCustomerResults)
                {
                    _logger.Info("\n************************************************************************************************************ \n");
                    _logger.Info("**************************************** Starting for Customer Id: " + ecr.CustomerId + " and Event Id: " + ecr.EventId + " **************************************** \n");
                    var mediaFiles = _eventCustomerResultRepository.GetMediaByEventIdAndCustomerId(ecr.EventId, ecr.CustomerId, testIds);
                    if (mediaFiles.IsNullOrEmpty())
                    {
                        _logger.Info("There is not any media file availble for Customer Id: " + ecr.CustomerId + " and Event Id: " + ecr.EventId);
                        continue;
                    }
                    CopyMediaFile(ecr.CustomerId, ecr.EventId, mediaFiles);
                    _logger.Info("**************************************** Media File Copied for Customer Id: " + ecr.CustomerId + " and Event Id: " + ecr.EventId + " **************************************** \n");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }

        private void CopyMediaFile(long customerId, long eventId, IEnumerable<string> mediaFiles)
        {
            var mediaPath = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
            var destinationPath = Path.Combine(_settings.SendTestMediaFilesClientLocation, eventId.ToString(), customerId.ToString());

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);
            DirectoryOperationsHelper.DeleteFiles(destinationPath);

            foreach (var file in mediaFiles)
            {
                var sourceFileName = Path.Combine(mediaPath, file);
                if (File.Exists(sourceFileName))
                {
                    File.Copy(sourceFileName, Path.Combine(destinationPath, file));
                    _logger.Info("Media file(" + file + ") successfully copied on location @" + destinationPath + " for Customer Id: " + customerId + " Event Id: " + eventId);
                }
                else
                {
                    _logger.Info("Media file(" + file + ") does not exist on Media file Location for Customer Id: " + customerId + " Event Id: " + eventId);
                }
            }
        }

    }
}
