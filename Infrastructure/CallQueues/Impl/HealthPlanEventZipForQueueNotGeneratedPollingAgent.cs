using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using System;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanEventZipForQueueNotGeneratedPollingAgent : IHealthPlanEventZipForQueueNotGeneratedPollingAgent
    {
        private readonly IHealthPlanEventZipService _healthPlanEventZipService;
        private readonly ILogger _logger;

        public HealthPlanEventZipForQueueNotGeneratedPollingAgent(IHealthPlanEventZipService healthPlanEventZipService, ILogManager logManager)
        {
            _healthPlanEventZipService = healthPlanEventZipService;
            _logger = logManager.GetLogger("HealthPlanEventZipForQueueNotGeneratedPollingAgent");
        }

        public void PollForHealthPlanEventZipQueueNotGenerated()
        {
            try
            {
                _logger.Info("Starting Health Plan Event Zip For Queue Not Generated Polling Agent");

                _healthPlanEventZipService.SaveHealthPlanEventZipForQueueNotGenerated(_logger);

                _logger.Info("Stop Health Plan Event Zip For Queue Not Generated Polling Agent");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error While Saving Health Plan Event Zip For Queue Not Generated. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
