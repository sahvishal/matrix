using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class GmsExcludedCustomerPollingAgent : IGmsExcludedCustomerPollingAgent
    {
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        
        private readonly IGmsExcludedCustomerService _gmsExcludedCustomerService;

        readonly IEnumerable<long> _healthPlanIds;

        public GmsExcludedCustomerPollingAgent(ILogManager logManager, ISettings settings, ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, IGmsExcludedCustomerService gmsExcludedCustomerService)
        {
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            
            _gmsExcludedCustomerService = gmsExcludedCustomerService;
            _logger = logManager.GetLogger("GmsExcludedCustomers");

            _healthPlanIds = settings.GmsAccountIds;
        }

        public void PollForReport()
        {
            if (_healthPlanIds.IsNullOrEmpty())
            {
                _logger.Info("No Health Plan IDs found.");
                return;
            }

            var healthPlans = _corporateAccountRepository.GetByIds(_healthPlanIds);

            var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.MailRound);

            var collection = new List<GmsExcludedCustomerViewModel>();

            foreach (var healthPlan in healthPlans)
            {
                _logger.Info("Getting excluded customers for Account ID : " + healthPlan.Id);

                var criterias = _healthPlanCallQueueCriteriaRepository.GetCriteriaForMailRoundGms(healthPlan.Id);

                if (!_settings.GmsCampaignIds.IsNullOrEmpty())
                {
                    criterias = _healthPlanCallQueueCriteriaRepository.GetByCampaignIds(_settings.GmsCampaignIds, healthPlan.Id);

                    _logger.Info(string.Format("Found {0} criterias for Campaign IDs : ", criterias.Count(), string.Join(",", _settings.GmsCampaignIds)));
                }

                foreach (var criteria in criterias)
                {
                    _logger.Info("Criteria ID : " + criteria.Id);

                    try
                    {
                        var filter = new OutboundCallQueueFilter
                        {
                            CallQueueId = callQueue.Id,
                            CriteriaId = criteria.Id,
                            CampaignId = criteria.CampaignId,
                            Tag = healthPlan.Tag,
                            HealthPlanId = healthPlan.Id,
                            UseCustomTagExclusively = false
                        };

                        if (filter.HealthPlanId == _settings.OptumUtAccountId)
                        {
                            filter.CustomCorporateTag = _settings.OptumUtCustomTagsForGms;
                        }
                        else if (filter.HealthPlanId == 1083)
                        {
                            filter.CustomCorporateTag = "UHC-TX_GMS_2018_List-1";
                        }
                        else if (filter.HealthPlanId == 1066)
                        {
                            filter.CustomCorporateTag = "Excellus_GMS_2018_List-1";
                        }
                        else if (filter.HealthPlanId == 1061)
                        {
                            filter.CustomCorporateTag = "Optum-NV_Assessments_2018_List-1_GMS,Optum-NV_Assessments_2018_List-2_GMS,Optum-NV_Assessments_2018_List-3_GMS,Optum-NV_Mammo_2018_List-2_GMS";
                        }
                        else if (filter.HealthPlanId == 1111)
                        {
                            filter.CustomCorporateTag = "Optum-NV_Assessments_2018_List-4_GMS";
                        }
                        else if (filter.HealthPlanId == 1087)
                        {
                            filter.CustomCorporateTag = "UHC-AZ_Assessments_2018_List-1_GMS";
                        }
                        else if (filter.HealthPlanId == 1093)
                        {
                            filter.CustomCorporateTag = "UHC-CT_Assessments_2018_List-1_GMS";
                        }

                        var excludedCustomerCollection = _gmsExcludedCustomerService.GetGmsExcludedCustomers(filter, callQueue);

                        var distinctCustomers = excludedCustomerCollection.Where(x => !collection.Select(c => c.CustomerId).Contains(x.CustomerId));

                        collection.AddRange(distinctCustomers);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error getting excluded customers for Account ID : " + healthPlan.Id + " Criteria ID : " + criteria.Id);
                        _logger.Error(ex);
                    }
                }

                _logger.Info("Completed for Account ID : " + healthPlan.Id);
            }

            var excludedPath = _settings.GmsExcludeReportDownloadCustomerPath;

            if (DirectoryOperationsHelper.CreateDirectoryIfNotExist(excludedPath))
            {
                var fileName = Path.Combine(excludedPath, string.Format("ExcludedPatientList_{0}.csv", DateTime.Today.ToString("yyyyMMdd")));
                WriteCsv(collection, fileName);
            }
            else
            {
                _logger.Error("Folder can not be created");
            }
        }

        private void WriteCsv(IEnumerable<GmsExcludedCustomerViewModel> modelData, string fileName)
        {
            _logger.Info("Writing CSV file " + fileName);

            if (DirectoryOperationsHelper.IsFileExist(fileName))
                DirectoryOperationsHelper.Delete(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(GmsExcludedCustomerViewModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);

                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                fileWriter.WriteLine(string.Join(",", header.ToArray()));

                var sanitizer = new CSVSanitizer();


                foreach (var model in modelData)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                                continue;
                        }
                        else
                            continue;


                        bool isHidden = false;
                        FormatAttribute formatter = null;

                        var attributes = propInfo.GetCustomAttributes(false);
                        if (!attributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in attributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    isHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));

                    }

                    fileWriter.WriteLine(string.Join(",", values.ToArray()));
                }

                _logger.Info("CSV File Export was succesful!");
            }
            catch (Exception ex)
            {
                _logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
            }
            finally
            {
                fileWriter.Close();
                fileWriter.Dispose();
            }
        }
    }
}
