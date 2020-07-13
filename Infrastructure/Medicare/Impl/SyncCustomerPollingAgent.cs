using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncCustomerPollingAgent : ISyncCustomerPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMedicareService _medicareService;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _setting;
        private readonly string _medicareSyncCustomSettingsPath;


        public SyncCustomerPollingAgent(ILogManager logManager, ICustomSettingManager customSettingManager, ISettings settings,
            ICustomerRepository customerRepository, IMedicareService medicareService, IMedicareApiService medicareApiService, ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger("SyncCustomerPollingAgent");
            _customSettingManager = customSettingManager;
            _setting = settings;
            _customerRepository = customerRepository;
            _medicareService = medicareService;
            _medicareApiService = medicareApiService;
            _corporateAccountRepository = corporateAccountRepository;
            _medicareSyncCustomSettingsPath = settings.MedicareSyncCustomSettingsPath;
        }
        /// <summary>
        /// This can be rerun any time. The service updates the last run time and will continue 
        /// </summary>
        public void Sync()
        {
            try
            {
                if (!_setting.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }

                //get all tags for IsHealthPlan is true
                var tags = _corporateAccountRepository.GetHealthPlanTags();
                if (tags != null && tags.Any())
                {
                    foreach (var tag in tags)
                    {
                        var newLastTransactionDate = DateTime.Now; //   use the time when exporting for this tag starts, as start date for next day.
                        _logger.Info("Medicare Customer Sync for tag : " + tag);
                        var path = _medicareSyncCustomSettingsPath + "MedicareCustomerSync" + tag + ".xml";
                        var customSettings = _customSettingManager.Deserialize(path);

                        if (customSettings == null || !customSettings.LastTransactionDate.HasValue)
                        {
                            customSettings = new CustomSettings { LastTransactionDate = DateTime.Now.AddMonths(-3) };
                        }
                        
                        if (customSettings.LastTransactionDate != null)
                        {
                            try
                            {
                                var exportFromTime = customSettings.LastTransactionDate.Value;
                                var customerIds = _customerRepository.GetCustomerForMedicareSync(exportFromTime, tag);
                                foreach (var customerId in customerIds)
                                {
                                    var model = _medicareService.GetCustomerDetails(customerId);
                                    model.Tag = tag;
                                    model.IsRequestUpdateOnly = true;
                                    try
                                    {
                                        var result = _medicareApiService.PostAnonymous<MedicareCustomerSetupViewModel>(
                                             _setting.MedicareApiUrl + MedicareApiUrl.CreateUpdateCustomer, model);
                                        if (result != null)
                                            _logger.Info("Medicare Customer Sync for tag: " + tag + " Customer : " + customerId);
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Error(" error occur Medicare Customer Sync for tag: " + tag + " Customer : " + customerId +
                                                      " Message: " + exception.Message + "\n stack Trace: " +
                                                      exception.StackTrace);
                                    }
                                }

                            }
                            catch (Exception exception)
                            {
                                _logger.Error(" error occur SyncCustomerPollingAgent: " + tag + " exportFromTime : " + customSettings.LastTransactionDate.Value +
                                              " Message: " + exception.Message + "\n stack Trace: " +
                                              exception.StackTrace);
                            }
                        }
                        _customSettingManager.SerializeandSave(path, new CustomSettings { LastTransactionDate = newLastTransactionDate });
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error("Error occurred for SyncCustomerPollingAgent Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
            }
        }
    }
}
