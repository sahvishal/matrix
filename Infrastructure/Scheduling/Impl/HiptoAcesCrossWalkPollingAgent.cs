using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using System;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class HiptoAcesCrossWalkPollingAgent : IHiptoAcesCrossWalkPollingAgent
    {
        private readonly IHiptoAcesCrossWalkService _hiptoAcesCrossWalkService;
        private readonly ILogger _logger;

        public HiptoAcesCrossWalkPollingAgent(IHiptoAcesCrossWalkService hiptoAcesCrossWalkService, ILogManager logManager)
        {
            _hiptoAcesCrossWalkService = hiptoAcesCrossWalkService;
            _logger = logManager.GetLogger("HealthPlanReportsService");
        }

        public void PollforHiptoAcesCrossWalk()
        {
         try
            {
                _logger.Info("starting Polling Agent");
                _hiptoAcesCrossWalkService.GetHiptoAcesCrossWalkCustomerReport();
                _logger.Info("polling for Hip to Aces Cross Walk Report completed");
            }
            catch (Exception exception)
            {
                _logger.Error("Message : " + exception.Message);
                _logger.Error("stack trace : " + exception.StackTrace);
            }
        }
    }
}
