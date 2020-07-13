using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;


namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class UniversalMemberPollingAgent : IUniversalMemberPollingAgent
    {
        private readonly IUniversalMemberReportService _universalMemberReportService;
        private readonly ILogger _logger;

        public UniversalMemberPollingAgent(IUniversalMemberReportService universalMemberReportService, ILogManager logManager)
        {
            _universalMemberReportService = universalMemberReportService;
            _logger = logManager.GetLogger("UniversalMemberReport");
        }

        public void PollforUniversalMembers()
        {
            try
            {
                _logger.Info("starting Polling Agent");
                _universalMemberReportService.GetUniversalMemberCustomerReport();
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
