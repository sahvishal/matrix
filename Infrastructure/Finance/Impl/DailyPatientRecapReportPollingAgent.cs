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
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class DailyPatientRecapReportPollingAgent : IDailyPatientRecapReportPollingAgent
    {
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IDailyPatientRecapReportingService _dailyPatientRecapReportingService;

        private readonly IEnumerable<long> _accountIds;
        private readonly IEnumerable<DayOfWeek> _daysOfWeek;
        private readonly string _dailyPatientRecapReportDestinationPathSettings;


        public DailyPatientRecapReportPollingAgent(ILogManager logManager, ISettings settings, ICorporateAccountRepository corporateAccountRepository,
            IDailyPatientRecapReportingService dailyPatientRecapReportingService)
        {
            _logger = logManager.GetLogger("DailyPatientRecapReport");
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _dailyPatientRecapReportingService = dailyPatientRecapReportingService;

            _accountIds = settings.DailyPatientRecapReportDownloadAccountIds;
            _daysOfWeek = settings.DaysOfWeekToRunDailyPatientRecapReport;
            _dailyPatientRecapReportDestinationPathSettings = settings.DailyPatientRecapReportDestinationPath;
        }

        public void PollForDailyPatientRecapReport()
        {
            try
            {
                /*if (!_daysOfWeek.Contains(DateTime.Today.DayOfWeek))
                {
                    _logger.Info(string.Format("todays day : {0}, export set to run on {1}", DateTime.Today.DayOfWeek, string.Join(", ", _daysOfWeek)));
                    return;
                }*/

                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating Daily Patient Recap Report for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        var fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                        var toDate = DateTime.Now.Date;

                        var destinationPath = string.Format(_dailyPatientRecapReportDestinationPathSettings, account.FolderName);

                        try
                        {
                            var files = Directory.GetFiles(destinationPath);
                            if (files.Any())
                            {
                                foreach (var file in files)
                                {
                                    File.Delete(file);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error deleting files from : " + destinationPath);
                            _logger.Error(string.Format("Error {0} \n Trace: {1} \n", ex.Message, ex.StackTrace));
                        }

                        _logger.Info(string.Format("Generating Daily Patient Recap Report Date From. {0} To Date {1}", fromDate.Date.ToShortDateString(), toDate.ToShortDateString()));

                        DailyPatientRecapReport(new DailyPatientRecapModelFilter { EventDateFrom = fromDate, EventDateTo = toDate.Date, CorporateAccountId = account.Id, Tag = account.Tag }, destinationPath);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Exception For AccountId {0} and Account Tag {1} : \n Error {2} \n Trace: {3} \n\n\n", account.Id, account.Tag, ex.Message, ex.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void DailyPatientRecapReport(DailyPatientRecapModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<DailyPatientRecapCustomModel>();

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);


            var fileName = string.Format(@"\DailyPatientRecapReport_{0}.csv", filter.EventDateTo.Value.ToString("yyyyMMdd"));

            if (filter.CorporateAccountId == _settings.ConnecticareAccountId)
            {
                fileName = "Comm Daily Patient Recap " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
            }
            else if (filter.CorporateAccountId == _settings.ConnecticareMaAccountId)
            {
                fileName = "MCR Daily Patient Recap " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
            }

            var destinationFileName = Path.Combine(destinationPath, fileName);

            while (true)
            {
                int totalRecords;
                var model = _dailyPatientRecapReportingService.GetDailyPatientReapCustomModel(pageNumber, pageSize, filter, out totalRecords);
                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }
            if (list.Any())
                WriteCsvDailyPatientRecap(list, destinationFileName);
        }

        private void WriteCsvDailyPatientRecap(IEnumerable<DailyPatientRecapCustomModel> modelData, string fileName)
        {
            DirectoryOperationsHelper.DeleteFileIfExist(fileName);

            var fileWriter = new StreamWriter(fileName);
            try
            {
                var members = (typeof(DailyPatientRecapCustomModel)).GetMembers();

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


            _logger.Info("CSV File Export was succesful!");

            _logger.Info("file Path: " + fileName);
        }

    }
}
