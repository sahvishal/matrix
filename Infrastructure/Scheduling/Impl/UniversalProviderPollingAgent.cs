using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class UniversalProviderPollingAgent : IUniversalProviderPollingAgent
    {
        private readonly IUniversalProviderReportService _universalProviderReportService;
        private readonly ILogger _logger;

        public UniversalProviderPollingAgent(IUniversalProviderReportService universalProviderReportService, ILogManager logManager)
        {
            _universalProviderReportService = universalProviderReportService;
            _logger = logManager.GetLogger("UniversalProviderReport");
        }

        public void PollforUniversalProviders()
        {
            try
            {
                _logger.Info("starting Polling Agent");
                _universalProviderReportService.GetUniversalProviderReport();
                _logger.Info("polling for universal member Report completed");

            }
            catch (Exception exception)
            {
                _logger.Error("Message : " + exception.Message);
                _logger.Error("stack trace : " + exception.StackTrace);
            }
        }
    }
}