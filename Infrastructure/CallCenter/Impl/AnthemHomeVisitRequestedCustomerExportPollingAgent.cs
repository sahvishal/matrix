using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class AnthemHomeVisitRequestedCustomerExportPollingAgent : IAnthemHomeVisitRequestedCustomerExportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IHealthPlanCustomerExportService _healthPlanCustomerExportService;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountReporsitory;
        private readonly ILogger _logger;
        private readonly DayOfWeek _dayOfWeek;

        public AnthemHomeVisitRequestedCustomerExportPollingAgent(ILogManager logManager, ISettings settings, IHealthPlanCustomerExportService healthPlanCustomerExportService, ICorporateTagRepository corporateTagRepository, 
            IUniqueItemRepository<CorporateAccount> corporateAccountReporsitory)
        {
            _settings = settings;
            _healthPlanCustomerExportService = healthPlanCustomerExportService;
            _corporateTagRepository = corporateTagRepository;
            _corporateAccountReporsitory = corporateAccountReporsitory;
            _logger = logManager.GetLogger("AntheHomeVisitRequestedExort");
            _dayOfWeek = settings.HealthPlanCustomerExportIntervalDay;
        }

        public void PollForCustomerExport()
        {
            try
            {
                _logger.Info("Stated Corporate Customer Export for Anthem Home Visit Requested.");

                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info("Day of the week is " + ((long)DateTime.Today.DayOfWeek));
                    return;
                }

                foreach (var customTag in _settings.AnthemCustomTags)
                {
                    try
                    {
                        var corporateTag = _corporateTagRepository.GetByTag(customTag);
                        if (corporateTag == null)
                        {
                            _logger.Info("No Corporate Account Found for the Tag: " + customTag);
                            continue;
                        }

                        var corporateAccount = _corporateAccountReporsitory.GetById(corporateTag.CorporateId);
                        if (corporateAccount == null)
                        {
                            _logger.Info("No Corporate Account Found for the Tag: " + customTag);
                            continue;
                        }
                        _logger.Info("running for Custom Tag: " + customTag);

                        var filter = new HealthPlanCustomerExportFilter
                        {
                            CallStatus = CallStatus.Attended,
                            CorporateTag = corporateAccount.Tag,
                            StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                            Tag = ProspectCustomerTag.HomeVisitRequested,
                            CustomTags = new[] { customTag }
                        };

                        var folderStateCode = string.Empty;

                        foreach (var stateCode in _settings.AnthemCustomTagStates)
                        {
                            if (customTag.Contains(stateCode))
                            {
                                folderStateCode = stateCode.Substring(stateCode.Length - 2);

                                break;
                            }
                        }

                        if (folderStateCode == string.Empty)
                            continue;

                        var destinationPath = string.Format(_settings.AnthemDownloadPath, folderStateCode);
                        destinationPath = Path.Combine(destinationPath, "HomeVisitRequest");

                        var fileName = string.Format("HLTHFAIR_HomeVisitRequest_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                        _healthPlanCustomerExportService.AnthemHomeVisitRequestedCustomerExport(filter, destinationPath, fileName, _logger);

                        _logger.Info("completed for Custom Tag: " + customTag);
                    }
                    catch (Exception exception)
                    {
                        _logger.Error("Message: " + exception.Message);
                        _logger.Error("Stack Trace: " + exception.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while Creating Csv Home Visit Requested list. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }

            _logger.Info("Completed Corporate Customer Export for Anthem Home Visit Requested.");
        }
    }
}