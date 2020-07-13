using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HousecallOutreachCallReportPollingAgent : IHousecallOutreachCallReportPollingAgent
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICallQueueService _callQueueService;
        private readonly IBaseReportService _baseReportService;

        private readonly ILogger _logger;
        private readonly string _housecallOutreachReportExportDownloadPath;
        private readonly DateTime _cutOfDate;
        private readonly IEnumerable<long> _healthPlanIds;
        private readonly string _outreachSettings;

        public HousecallOutreachCallReportPollingAgent(ICorporateAccountRepository corporateAccountRepository, ILogManager logManager, ISettings settings,
            ICustomSettingManager customSettingManager, ICallQueueService callQueueService, IBaseReportService baseReportService)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _callQueueService = callQueueService;
            _baseReportService = baseReportService;
            _logger = logManager.GetLogger("HousecallOutreachReport");

            _housecallOutreachReportExportDownloadPath = settings.HousecallOutreachReportExportDownloadPath;
            _cutOfDate = settings.HousecallOutreachReportCutOfDate;
            _healthPlanIds = settings.HousecallPlanOutreachReportAccountIds;
            _outreachSettings = settings.HousecallOutreachSettings;
        }

        public void PollForOutreachReport()
        {
            try
            {
                _logger.Info("Polling for Out reach report started");

                var healthPlans = _corporateAccountRepository.GetAllHealthPlan().Where(hp => _healthPlanIds.Contains(hp.Id));

                foreach (var healthPlan in healthPlans)
                {
                    _logger.Info(string.Format("Polling for Out reach report started for Account Id {0} ", healthPlan.Id));

                    try
                    {
                        var outreachSettings = string.Format(_outreachSettings, healthPlan.Tag);
                        var customSettings = _customSettingManager.Deserialize(outreachSettings);

                        var fromDate = customSettings.LastTransactionDate == null ? _cutOfDate : customSettings.LastTransactionDate.Value.AddDays(1);
                        var toDate = DateTime.Today.AddDays(-1);

                        _logger.Info(string.Format("Generating report for From Date : {0} To Date : {1}", fromDate, toDate));

                        var filter = new OutreachCallReportModelFilter
                        {
                            HealthPlanId = healthPlan.Id,
                            DateFrom = fromDate,
                            DateTo = toDate,
                            CallAttemptFilter = CallAttemptFilterStatus.All,
                        };

                        var filePath = GetOutreachFilePath(healthPlan, fromDate.Year, toDate);

                        //_callCenterExportableReportHelper.HousecallOutreachCallReportExport(filter, filePath, _logger);
                        HousecallOutreachCallReport(filter, filePath);

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(outreachSettings, customSettings);

                        _logger.Info(string.Format("Completed Out reach report for Account Id {0} ", healthPlan.Id));
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("Exception occured while polling for outreach report for Account Id {0}.  Exception Message : {1}, Stack  Trace {2}", healthPlan.Id, exception.Message, exception.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occured while polling for outreach report.  Exception Message : {0}, Stack  Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private string GetOutreachFilePath(CorporateAccount healthPlan, int year, DateTime toDate)
        {
            var folderLocation = string.Format(_housecallOutreachReportExportDownloadPath, healthPlan.FolderName, year);

            if (!Directory.Exists(folderLocation))
                Directory.CreateDirectory(folderLocation);

            var filePath = folderLocation + "\\" + "DailyOutreachCalls_" + toDate.ToString("yyyyMMdd") + ".csv";

            if (File.Exists(filePath))
                File.Delete(filePath);

            return filePath;
        }

        private void HousecallOutreachCallReport(OutreachCallReportModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<HousecallOutreachReportModel>();

            while (true)
            {
                int totalRecords;
                var model = _callQueueService.GetHousecallOutreachCallReport(pageNumber, pageSize, filter, out totalRecords);

                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            GenerateOutreachCallReportCsv(list, destinationPath);
        }

        private bool GenerateOutreachCallReportCsv(IEnumerable<HousecallOutreachReportModel> modelData, string csvFilePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(HousecallOutreachReportModel)).GetMembers();

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

                string propertyName = memberInfo.Name;
                bool isHidden = false;

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

            csvStringBuilder.Append(string.Join(",", header.ToArray()) + Environment.NewLine);

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


                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            return isGenerated;
        }
    }
}
