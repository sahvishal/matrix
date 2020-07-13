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
    public class HealthPlanHomeVisitRequestedCustomerExportPollingAgent : IHealthPlanHomeVisitRequestedCustomerExportPollingAgent
    {
        private readonly IHealthPlanCustomerExportService _healthPlanCustomerExportService;
        private readonly ILogger _logger;
        private readonly string _homeVisitRequestExportDownloadPath;

        private readonly DayOfWeek _dayOfWeek;

        public HealthPlanHomeVisitRequestedCustomerExportPollingAgent(ILogManager logManager, ISettings settings, IHealthPlanCustomerExportService healthPlanCustomerExportService)
        {
            _healthPlanCustomerExportService = healthPlanCustomerExportService;
            _logger = logManager.GetLogger("HealthPlanHomeVisitRequestedCustomerExport");

            _homeVisitRequestExportDownloadPath = settings.HealthPlanHomeVisitRequestExportDownloadPath;

            _dayOfWeek = settings.HealthPlanCustomerExportIntervalDay;
        }

        public void PollForCustomerExport()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info("Day of the week is " + ((long)DateTime.Today.DayOfWeek));
                    return;
                }

                _healthPlanCustomerExportService.HealthPlanHomeVisitRequestedCustomerExport(DateTime.Today.GetFirstDateOfYear(), _homeVisitRequestExportDownloadPath, _logger);

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while Creating Csv Home Visit Requested list. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }

            _logger.Info("Completed Corporate Customer Export for Home Visit Requested.");
        }

    }
}