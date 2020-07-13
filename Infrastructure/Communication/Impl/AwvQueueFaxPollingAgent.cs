using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Medical.Impl;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    public class AwvQueueFaxPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ILogger _logger;
        private readonly int _faxInterval;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IQueueCustomerFaxResultNotificationService _queueCustomerFaxResult;

        public AwvQueueFaxPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository,
            ILogManager logManager, ISettings settings, IConfigurationSettingRepository configurationSettingRepository, IQueueCustomerFaxResultNotificationService queueCustomerFaxResult)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _faxInterval = settings.AwvFaxServiceInvokeInterval;
            _logger = logManager.GetLogger<ResultNotificationPollingAgent>();
            _configurationSettingRepository = configurationSettingRepository;
            _queueCustomerFaxResult = queueCustomerFaxResult;
        }

        public void PollForQueueAwvResults()
        {
            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAWVCustomerResultFaxNotification);

            if (value.ToLower() != bool.TrueString.ToLower()) return;

            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, false, DateTime.Now, DateTime.Now.AddHours(-_faxInterval), 0);//Need to pass RiteAid AccountId

            var eventCustomerResult = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

            if (eventCustomerResults == null && !eventCustomerResult.Any())
            {
                _logger.Info("No event customer result list found for Fax queue.");
                return;
            }
            _logger.Info(string.Format("{0} Number of Event customers For Found for Result to be Queue", eventCustomerResult.Count()));

            _queueCustomerFaxResult.QueueFaxResultNotification(eventCustomerResult, NotificationTypeAlias.AwvCustomerResultFaxNotification);
        }
    }
}
