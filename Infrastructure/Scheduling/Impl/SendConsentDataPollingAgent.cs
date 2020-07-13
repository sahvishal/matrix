using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using System;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class SendConsentDataPollingAgent : ISendConsentDataPollingAgent
    {
        private readonly ILogger _logger;
        private readonly ICustomerConsentDataReportService _customerConsentDataReportService;

        public SendConsentDataPollingAgent(ILogManager logManager, ICustomerConsentDataReportService customerConsentDataReportService)
        {
            _logger = logManager.GetLogger("SendConsentDataPollingAgent");
            _customerConsentDataReportService = customerConsentDataReportService;
        }

        public void PollForSendConsentData()
        {
            try
            {
                _logger.Info("starting Send Consent Data Polling Agent");
                _customerConsentDataReportService.GetCustomerConsentDataReport();
                _logger.Info("Polling For Send Consent Data Report Completed");

            }
            catch (Exception exception)
            {
                _logger.Error("Message : " + exception.Message);
                _logger.Error("stack trace : " + exception.StackTrace);
            }
        }
    }
}
