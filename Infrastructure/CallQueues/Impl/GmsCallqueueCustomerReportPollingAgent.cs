using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class GmsCallQueueCustomerReportPollingAgent : IGmsCallQueueCustomerReportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly ICallQueueCustomerReportService _callQueueCustomerReportService;

        private readonly IEnumerable<long> _healthPlanIds;

        public GmsCallQueueCustomerReportPollingAgent(ISettings settings, ILogManager logManager, ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, ICallQueueCustomerReportService callQueueCustomerReportService)
        {
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _callQueueCustomerReportService = callQueueCustomerReportService;
            _logger = logManager.GetLogger("GmsCallQueueReport");

            _healthPlanIds = settings.GmsAccountIds;
        }

        public void PollForReportGeneration()
        {
            var healthPlans = !_healthPlanIds.IsNullOrEmpty() ? _corporateAccountRepository.GetByIds(_healthPlanIds) : _corporateAccountRepository.GetAllHealthPlan();

            var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.MailRound);

            var collection = new List<GmsCallQueueCustomerViewModel>();

            foreach (var healthPlan in healthPlans)
            {
                if (_settings.GmsMaxCustomerCount > 0 && collection.Count() >= _settings.GmsMaxCustomerCount)
                    break;

                _logger.Info(string.Format("Getting call queue customers for Account ID : {0} and Tag : {1}", healthPlan.Id, healthPlan.Tag));

                var criterias = _healthPlanCallQueueCriteriaRepository.GetCriteriaByHealthPlanCallQueue(healthPlan.Id, HealthPlanCallQueueCategory.MailRound);

                if (!_settings.GmsCampaignIds.IsNullOrEmpty())
                {
                    criterias = _healthPlanCallQueueCriteriaRepository.GetByCampaignIds(_settings.GmsCampaignIds, healthPlan.Id);

                    _logger.Info(string.Format("Found {0} criterias for Campaign IDs : ", criterias.Count(), string.Join(",", _settings.GmsCampaignIds)));
                }

                foreach (var criteria in criterias)
                {
                    if (_settings.GmsMaxCustomerCount > 0 && collection.Count() >= _settings.GmsMaxCustomerCount)
                        break;

                    _logger.Info(string.Format("Criteria ID : {0}", criteria.Id));

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

                        _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);

                        var dataGen = new ExportableDataGenerator<GmsCallQueueCustomerViewModel, OutboundCallQueueFilter>(_callQueueCustomerReportService.GetGmsCallQueueCustomersReport, _logger);

                        var model = dataGen.GetData(filter);

                        var distinctCustomers = model.Collection.Where(x => !collection.Select(c => c.CustomerId).Contains(x.CustomerId));

                        collection.AddRange(distinctCustomers);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error getting call queue customers for Account ID : " + healthPlan.Id + " Criteria ID : " + criteria.Id);
                        _logger.Error(ex);
                    }
                }
            }

            if (!collection.Any())
            {
                _logger.Info("No records found.");
                return;
            }

            if (_settings.GmsMaxCustomerCount > 0 && collection.Count() >= _settings.GmsMaxCustomerCount)
            {
                collection = collection.Take(_settings.GmsMaxCustomerCount).ToList();
            }

            if (!Directory.Exists(_settings.GmsCustomerReportPath)) Directory.CreateDirectory(_settings.GmsCustomerReportPath);

            var fileName = _settings.GmsCustomerReportPath + @"\" + string.Format("PatientList_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

            WriteCsv(collection, fileName);

            if (_settings.SendReportToGmsSftp)
            {
                _logger.Info("Sending Customer List to GMS sftp.");
                var sftpFolderReportDirectory = _settings.GmsSftpPath;
                var processFtp = new ProcessFtp(_logger, _settings.GmsSftpHost, _settings.GmsSftpUserName, _settings.GmsSftpPassword);

                processFtp.UploadSingleFile(fileName, sftpFolderReportDirectory, "");
                _logger.Info("Sent Customer List to GMS sftp.");
            }
            else
            {
                _logger.Info("Setting to send Customer list to sftp is OFF.");
            }
        }

        private void WriteCsv(IEnumerable<GmsCallQueueCustomerViewModel> modelData, string fileName)
        {
            _logger.Info("Writing CSV file " + fileName);
            if (File.Exists(fileName))
                File.Delete(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(GmsCallQueueCustomerViewModel)).GetMembers();

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
