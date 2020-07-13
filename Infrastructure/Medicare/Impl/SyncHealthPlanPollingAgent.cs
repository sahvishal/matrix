using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using System;
using System.Linq;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncHealthPlanPollingAgent : ISyncHealthPlanPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMedicareService _medicareService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ISettings _setting;
        private readonly string _medicareSyncCustomSettingsPath;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        public SyncHealthPlanPollingAgent(ILogManager logManager, ICustomSettingManager customSettingManager, ISettings settings, IMedicareApiService medicareApiService,
            IOrganizationRepository organizationRepository, ICustomerRepository customerRepository, IMedicareService medicareService, IEventCustomerRepository eventCustomerRepository, IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices)
        {
            _logger = logManager.GetLogger("SyncHealthPlanPollingAgent");
            _customSettingManager = customSettingManager;
            _setting = settings;
            _medicareApiService = medicareApiService;
            _organizationRepository = organizationRepository;
            _customerRepository = customerRepository;
            _medicareService = medicareService;
            _eventCustomerRepository = eventCustomerRepository;
            _medicareSyncCustomSettingsPath = settings.MedicareSyncCustomSettingsPath;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
        }

        /// <summary>
        /// This can be rerun any time. The service updates the last run time and will continue 
        /// </summary>
        public void Sync()
        {
            //get all tags for IsHealthPlan is true

            try
            {
                if (!_setting.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }
                var newLastTransactionDate = DateTime.Now; // i need to use the time when exporting  starts.

                var sites = _organizationRepository.GetMedicareSites();// DateModified is not being Update in Organization table
                foreach (var site in sites)
                {
                    var path = _medicareSyncCustomSettingsPath + "MedicareHealthPlanSync.xml";
                    var customSettings = _customSettingManager.Deserialize(path);
                    var orgName = _setting.OrganizationNameForHraQuestioner;

                    var questionnaireTypeResult = _accountHraChatQuestionnaireHistoryServices.GetByAccountId(site.AccountId);
                    if (questionnaireTypeResult != null && questionnaireTypeResult.Any(q => q.QuestionnaireType == (long)QuestionnaireType.HraQuestionnaire))
                    {
                        site.ShowHraQuestionnaire = false;
                        var result = questionnaireTypeResult.Where(q => q.StartDate < DateTime.Today && (q.EndDate == null || q.EndDate >= DateTime.Today)).FirstOrDefault();
                        if (result != null && result.QuestionnaireType == (long)QuestionnaireType.HraQuestionnaire)
                        {
                            site.ShowHraQuestionnaire = true;
                        }
                    }
                    else
                    {
                        _logger.Info("Medicare Sync for Health plan HRA Questionnaire Type not Set for Tag : " + site.Alias + " Date : " + DateTime.Today);
                        continue;
                    }
                    if (customSettings == null || !customSettings.LastTransactionDate.HasValue)
                    {
                        customSettings = new CustomSettings { LastTransactionDate = DateTime.Now };
                    }
                    if (customSettings.LastTransactionDate != null)
                    {
                        // Sync Site

                        try
                        {
                            site.ParentOrganizationName = orgName;
                            var result = _medicareApiService.PostAnonymous<bool>(_setting.MedicareApiUrl + MedicareApiUrl.CreateUpdateSite, site);
                            if (result)
                                _logger.Info("Medicare Sync for Health plan tag : " + site.Alias);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("Error Medicare Sync for Health plan tag : " + site.Alias + " Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
                        }

                        //Sync Customer for 
                        if (site.ShowHraQuestionnaire)
                        {
                            var exportFromTime = DateTime.Now.AddDays(-1 * _setting.NoOfDaysToPickWhenWithoutSetting);
                            var customerIds = _customerRepository.GetCustomerForMedicareSyncWithoutVisit(exportFromTime, site.Alias);
                            foreach (var customerId in customerIds)
                            {
                                var model = _medicareService.GetCustomerDetails(customerId);
                                model.Tag = site.Alias;

                                var eventDetailList = _customerRepository.GetEventDetailForMedicareSync(customerId);
                                foreach (var medicareEventEditModel in eventDetailList)
                                {
                                    try
                                    {
                                        if (medicareEventEditModel.VisitDate.Date.Year >= 2017)
                                        {
                                            model.IsAppointmentConfirmed = true;
                                            medicareEventEditModel.Tag = site.Alias;
                                            model.EventDetails = medicareEventEditModel;
                                            var res = _medicareApiService.PostAnonymous<MedicareCustomerSetupViewModel>(
                                                 _setting.MedicareApiUrl + MedicareApiUrl.CreateUpdateCustomer, model);
                                            if (res != null)
                                            {
                                                _logger.Info("Medicare Customer Sync for ShowHraQuestionnaire Setting Tag :" + site.Alias + " ,Customer: " + customerId);

                                                // Update Event Customer Event Detail
                                                IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
                                                var eventCustomer = _eventCustomerRepository.GetById(medicareEventEditModel.EventCustomerId);
                                                eventCustomer.AwvVisitId = res.PatientVisitId;
                                                itemRepository.Save(eventCustomer);
                                            }
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Error(" error occurred Medicare Customer Sync for Customer : " + customerId + " Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
                                    }
                                }
                            }
                        }
                    }
                    _customSettingManager.SerializeandSave(path, new CustomSettings { LastTransactionDate = newLastTransactionDate });
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Error occurred for SyncHealthPlanPollingAgent Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
            }
        }
    }
}
