using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using System;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanEventZipPollingAgent : IHealthPlanEventZipPollingAgent
    {
        private readonly IHealthPlanEventZipService _healthPlanEventZipService;
        private readonly ILogger _logger;

        public HealthPlanEventZipPollingAgent(IHealthPlanEventZipService healthPlanEventZipService, ILogManager logManager)
        {
            _healthPlanEventZipService = healthPlanEventZipService;
            _logger = logManager.GetLogger("HealthPlanEventZipPollingAgent");
        }

        public void PollForHealthPlanEventZip()
        {
            try
            {
                _logger.Info("Starting Health Plan Event Zip Polling Agent");

                _healthPlanEventZipService.SaveHealthPlanEventZip(_logger);

                _logger.Info("Stop Health Plan Event Zip Polling Agent");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error While Saving Health Plan Event Zip. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
