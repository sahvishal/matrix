using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HourlyOutreachCallReportPollingAgent : IHourlyOutreachCallReportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly INotifier _notifier;
        private readonly IHourlyOutreachReportingService _hourlyOutreachReportingService;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IBaseReportService _baseReportService;

        public HourlyOutreachCallReportPollingAgent(ISettings settings, ILogManager logManager,
            IHourlyOutreachReportingService hourlyOutreachReportingService,
            IBaseReportService baseReportService, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory)
        {
            _settings = settings;
            _hourlyOutreachReportingService = hourlyOutreachReportingService;
            _baseReportService = baseReportService;
            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _logger = logManager.GetLogger("HourlyOutreachCallReportPollingAgent");
        }


        public void PollForHourlyOutreachCallReport()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info(string.Format("Time of Date {0}", timeOfDay));

                if (timeOfDay.TimeOfDay > new TimeSpan(_settings.HourlyOutreachCallReportStartTime, 0, 0))
                {
                    timeOfDay = timeOfDay.AddMinutes(10);
                    var filter = new OutreachCallReportModelFilter
                    {
                        DateFrom = timeOfDay.Date,
                        DateTo = DateTime.Now,
                        CallAttemptFilter = CallAttemptFilterStatus.All
                    };
                    if (DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.HourlyOutreachCallReportDownloadPath))
                    {
                        try
                        {
                            var files = DirectoryOperationsHelper.GetFiles(_settings.HourlyOutreachCallReportDownloadPath, string.Format("HourlyOutreachCallReport_{0}*.csv", timeOfDay.ToString("yyyyMMdd")));
                            foreach (var file in files)
                            {
                                DirectoryOperationsHelper.DeleteFileIfExist(file);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("some error occurred while deleting Hourly Report");
                            _logger.Error(string.Format("Message: {0}", ex.Message));
                            _logger.Error(string.Format("Stack Trace: {0}", ex.StackTrace));
                        }

                        var hourlyReport = Path.Combine(_settings.HourlyOutreachCallReportDownloadPath, string.Format("HourlyOutreachCallReport_{0}.csv", timeOfDay.ToString("yyyyMMddHHmm")));
                        HourlyOutreachCallReport(filter, hourlyReport);

                        var notificationModel = _emailNotificationModelsFactory.GetHourlyOutreachNotificationViewModel("HourlyOutreachCallReport", hourlyReport);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.HourlyNotificationOutreachCallReport, EmailTemplateAlias.HourlyNotificationOutreachCallReport, notificationModel, 0, 1, "Hourly Outreach Call Report");
                    }
                }
                else
                {
                    _logger.Info(string.Format("Hourly Outreach Call Report Service can not be Run as it is restricted Time {0}", timeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("some error occurred while generating Hourly Report");
                _logger.Error(string.Format("Message: {0}", ex.Message));
                _logger.Error(string.Format("Stack Trace: {0}", ex.StackTrace));
            }
        }

        private void HourlyOutreachCallReport(OutreachCallReportModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<HourlyOutreachCallReportModel>();

            while (true)
            {
                int totalRecords;
                var model = _hourlyOutreachReportingService.GetOutreachCallReport(pageNumber, pageSize, filter, out totalRecords);

                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            //if (list.Any())
            GenerateOutreachCallReportCsv(list, destinationPath);
        }

        private bool GenerateOutreachCallReportCsv(IEnumerable<HourlyOutreachCallReportModel> modelData, string csvFilePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(HourlyOutreachCallReportModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                        propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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

            header.Add("Disposition Notes");
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
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) ||
                            propInfo.PropertyType == typeof(IEnumerable<CallCenterNotes>))
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


                if (model.Notes != null && model.Notes.Count() > 0)
                {
                    var notesString = model.Notes.Aggregate("",
                        (current, note) =>
                            current + ("[ " + note.DateCreated.ToShortDateString() + " ] - Notes: " + note.Notes + "\n"));

                    values.Add(sanitizer.EscapeString(notesString));
                }
                else
                    values.Add("N/A");

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            return isGenerated;
        }
    }
}
