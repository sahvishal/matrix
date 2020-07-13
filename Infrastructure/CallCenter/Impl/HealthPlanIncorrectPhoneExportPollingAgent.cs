using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class HealthPlanIncorrectPhoneExportPollingAgent : IHealthPlanIncorrectPhoneExportPollingAgent
    {
        private readonly IHealthPlanCustomerExportService _healthPlanCustomerExportService;
        private readonly ILogger _logger;
        private readonly string _incorrectPhoneNumberCsvDownloadPath;
       

        public HealthPlanIncorrectPhoneExportPollingAgent(ILogManager logManager, ISettings settings, IHealthPlanCustomerExportService healthPlanCustomerExportService)
        {
            _healthPlanCustomerExportService = healthPlanCustomerExportService;
            _logger = logManager.GetLogger("HealthPlanIncorrectPhoneExportPollingAgent");
            _incorrectPhoneNumberCsvDownloadPath = settings.HealthPlanIncorrectPhoneExportDownloadPath;
            
           
        }

        public void PollForCustomerExport()
        {
            try
            {
                
                _healthPlanCustomerExportService.HealthPlanIncorrectPhoneCustomerExport(DateTime.Today.GetFirstDateOfYear(), _incorrectPhoneNumberCsvDownloadPath, _logger);

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while Creating Csv CallQueue Incorrect phone number list. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }

            _logger.Info("Completed Corporate Customer Export for Incorrect Phone Number");
        }

    }
}
