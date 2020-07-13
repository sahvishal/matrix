using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class TwilioMessagePollingAgent : ITwilioMessagePollingAgent
    {
        private readonly ISettings _settings;
        private readonly IXmlSerializer<TwillioMessageResponse> _twilioSerializer;
        private readonly ISmsReceivedNotificationService _smsReceivedNotificationService;
        private readonly ILogger _logger;
        public TwilioMessagePollingAgent(ISettings settings, ILogManager logManager,
            IXmlSerializer<TwillioMessageResponse> twilioSerializer, ISmsReceivedNotificationService smsReceivedNotificationService)
        {
            _settings = settings;
            _twilioSerializer = twilioSerializer;
            _smsReceivedNotificationService = smsReceivedNotificationService;
            _logger = logManager.GetLogger("TwilioMessgePollingAgent");
        }

        public void PollForTwilioResponse()
        {
            try
            {
                if (_settings.TwilioFilePath.IsNullOrEmpty())
                {
                    return;
                }

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.TwilioFilePath);
                var archivePath = Path.Combine(_settings.TwilioFilePath, "archive");
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(archivePath);
                var files = DirectoryOperationsHelper.GetFilesOrderByDateCreated(_settings.TwilioFilePath);
                if (files.IsNullOrEmpty())
                {
                    _logger.Info("No file found for Parse");
                    return;
                }

                foreach (var file in files)
                {
                    try
                    {
                        var filePath = Path.Combine(_settings.TwilioFilePath, file);
                        var twilioResponse = _twilioSerializer.Deserialize(filePath);
                        _smsReceivedNotificationService.SmsReceivedNotification(twilioResponse);

                        var fileName = Path.Combine(archivePath, file);

                        DirectoryOperationsHelper.Move(filePath, fileName);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some error occurred while parsing twilioResponse");
                        _logger.Error("Message " + ex.Message);
                        _logger.Error("Stack Trace " + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error occurred");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}