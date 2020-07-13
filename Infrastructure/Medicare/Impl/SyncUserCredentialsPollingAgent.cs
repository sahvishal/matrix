using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncUserCredentialsPollingAgent : ISyncUserCredentialsPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IUserNpiInfoRepository _userNpiInfoRepository;
        private readonly IMedicareService _medicareService;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _setting;
        private readonly string _medicareSyncCustomSettingsPath;


        public SyncUserCredentialsPollingAgent(ILogManager logManager, ICustomSettingManager customSettingManager, ISettings settings,
            ICustomerRepository customerRepository, IMedicareService medicareService, IMedicareApiService medicareApiService, ICorporateAccountRepository corporateAccountRepository,
            IUserLoginRepository userLoginRepository, IUserNpiInfoRepository userNpiInfoRepository)
        {
            _logger = logManager.GetLogger("SyncUserCredentialsPollingAgent");
            _customSettingManager = customSettingManager;
            _setting = settings;
            _customerRepository = customerRepository;
            _medicareService = medicareService;
            _medicareApiService = medicareApiService;
            _corporateAccountRepository = corporateAccountRepository;
            _userLoginRepository = userLoginRepository;
            _userNpiInfoRepository = userNpiInfoRepository;
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

                var newLastTransactionDate = DateTime.Now.AddMinutes(-1); //   use the time when exporting for this tag starts, as start date for next day.
                _logger.Info("Medicare SyncUserCredentials : " + newLastTransactionDate.ToLongDateString());
                var path = _medicareSyncCustomSettingsPath + "UserCredentialsSync.xml";
                var customSettings = _customSettingManager.Deserialize(path);

                if (customSettings == null || !customSettings.LastTransactionDate.HasValue)
                {
                    customSettings = new CustomSettings { LastTransactionDate = DateTime.Today.AddDays(-1) };
                }
                var failed = false;
                if (customSettings.LastTransactionDate != null)
                {
                    var exportFromTime = customSettings.LastTransactionDate.Value;
                    var userCredentials = _userLoginRepository.GetUserForMedicareSync(exportFromTime);
                    if (!userCredentials.Any())
                    {
                        _logger.Info("No Data found for Sync: FromTime:" + exportFromTime);
                        return;
                    }

                    const int pageSize = 25;
                    var count = userCredentials.Count();
                    var totalPages = Math.Ceiling((double)(count) / pageSize);
                    for (int i = 0; i < totalPages; i++)
                    {
                        _logger.Info("Page: " + i + 1 + ", No Of Entries to sync: " + count);
                        var listModel = new MedicareUserCredentialListModel();
                        listModel.UserCredentials = userCredentials.Skip(i * pageSize).Take(pageSize).ToList();

                        //bind Npi and Credential to MedicareUserCredentialListModel
                        var npiInfo = _userNpiInfoRepository.GetByUserIds(listModel.UserCredentials.Select(x => x.Id));
                        listModel.UserCredentials.ForEach(x =>
                        {
                            var tempNpiCredentialInfo = npiInfo.FirstOrDefault(y => y.UserId == x.Id);
                            x.Npi = tempNpiCredentialInfo == null ? null : tempNpiCredentialInfo.Npi;
                            x.Credential = tempNpiCredentialInfo == null ? null : tempNpiCredentialInfo.Credential;
                        });

                        try
                        {
                            _medicareApiService.PostAnonymous<bool>(_setting.MedicareApiUrl + MedicareApiUrl.SyncUserCredentials, listModel);
                        }
                        catch (Exception exception)
                        {
                            failed = true;
                            _logger.Error("Error occur Medicare Customer Sync for   Page : " + (i + 1) + " Message: " + exception.Message + "\nStack Trace: " + exception.StackTrace);
                        }
                    }
                }
                if (!failed)
                {
                    _logger.Info("Xml updated with Value : " + newLastTransactionDate);
                    _customSettingManager.SerializeandSave(path, new CustomSettings { LastTransactionDate = newLastTransactionDate });
                }
                _logger.Info("Exiting Polling Agent");
            }
            catch (Exception exception)
            {
                _logger.Error("Error occured SyncUserCredentialsPollingAgent , Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
            }

        }
    }
}
