using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class WellmedMemberStatusReportPollingAgent : IWellmedMemberStatusReportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;
        private readonly IBaseReportService _baseReportService;
        private readonly ISettings _settings;

        private readonly string _wellmedMemberStatusDestinationPath;
        private readonly long _accountId;
        private readonly int _dayOfMonth;

        public WellmedMemberStatusReportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ILogManager logManager, ISettings settings, IBaseReportService baseReportService)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseReportService = baseReportService;
            _logger = logManager.GetLogger("Wellmed Member Status Report");
            _accountId = settings.WellmedAccountId;
            _wellmedMemberStatusDestinationPath = settings.WellmedMemberStatusReportPath;
            _dayOfMonth = settings.WellmedMemberStatusReportDayOfMonth;
            _settings = settings;
        }

        public void PollForMemberStatusReport()
        {
            try
            {
                if (_accountId <= 0)
                {
                    _logger.Info("Corporate Account Id Not found");
                    return;
                }
                var today = DateTime.Today;
                var dayOfMonth = new DateTime(today.Year, today.Month, _dayOfMonth);

                if (dayOfMonth != today)
                {
                    _logger.Info("Report is schedule to run on " + _dayOfMonth + " of every month");
                    _logger.Info("Today is " + today);
                    _logger.Info(string.Format("Set day of month to {0} to run today ", _dayOfMonth));
                    return;
                }

                var account = _corporateAccountRepository.GetById(_accountId);

                if (account == null)
                {
                    _logger.Info("Corporate Account Not found");
                    return;
                }

                _logger.Info("Starting Member Status Report for " + account.Tag);

                var filter = new MemberStatusListModelFilter
                {
                    EligibleStatus = EligibleFilterStatus.OnlyEligible,
                    IncludeDoNotContact = true,
                    DoNotContactOnly = false,
                    Tag = account.Tag,
                    Year = today.Year,
                    CallAttemptFilter = CallAttemptFilterStatus.All,
                    ConsiderEligibiltyFromHistory = true
                };

                GenerateMemberStatusListCsvByFilter(filter, account);

                _logger.Info("Completed Member Status Report for " + account.Tag);

            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured on Member status Report account Id " + _accountId);
                _logger.Error("Exception: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void GenerateMemberStatusListCsvByFilter(MemberStatusListModelFilter filter, CorporateAccount account)
        {
            _logger.Info(string.Format("Generating Member Status Report for {0}", account.Tag));

            var dataGen = new ExportableDataGenerator<MemberStatusModel, MemberStatusListModelFilter>(_eventCustomerReportingService.GetMemberStatusReport, _logger);
            var model = dataGen.GetData(filter);

            if (model != null && model.Collection != null && model.Collection.Any())
            {
                var fileName = string.Format("WellMed_Monthly_Cumulative_Status_Report_{0}.csv", DateTime.Now.ToString("yyyyMM"));

                var csvFileName = GetCsvFileName(account, fileName);
                WriteCsv(csvFileName, model.Collection);
                if (_settings.WellmedMemberStatusReportSendToSftp)
                {
                    if (ExportReportOnWellMedSftp(fileName, csvFileName))
                        _logger.Info("File posted on client SFTP");
                    else
                        _logger.Info("File didn't posted,some error occurred.");
                }
            }
            else
            {
                _logger.Info("No records found");
            }
        }

        private string GetCsvFileName(CorporateAccount account, string fileName)
        {
            var folderLocation = string.Format(_wellmedMemberStatusDestinationPath, account.FolderName, DateTime.Today.Year);

            if (!DirectoryOperationsHelper.IsDirectoryExist(folderLocation))
                DirectoryOperationsHelper.CreateDirectory(folderLocation);

            var destinationFileName = Path.Combine(folderLocation, fileName);

            if (DirectoryOperationsHelper.IsFileExist(destinationFileName))
                DirectoryOperationsHelper.Delete(destinationFileName);

            return destinationFileName;
        }

        private string WriteCsv(string fileName, IEnumerable<MemberStatusModel> modelData)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(MemberStatusModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, int>>))
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
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (model.AdditionalFields != null && model.AdditionalFields.Any())
                            {
                                string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                                    (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                                values.Add(sanitizer.EscapeString(additionFiledString));
                            }
                            else
                                values.Add(string.Empty);
                            continue;
                        }
                        else if (propInfo.PropertyType == typeof(FeedbackMessageModel))
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

            var request = new GenericReportRequest { CsvFilePath = fileName, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";
            return fileName;
        }

        private bool ExportReportOnWellMedSftp(string fileName, string sourcePath)
        {
            var destinationPathOnSftp = _settings.WellmedMemberStatusReportSftpPath;

            destinationPathOnSftp = destinationPathOnSftp.Replace("/", "\\");

            _logger.Info("Destination Path:  " + destinationPathOnSftp);
            _logger.Info("File Name:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _settings.WellmedSftpHost, _settings.WellmedSftpUserName, _settings.WellmedSftpPassword);
            return processFtp.UploadSingleFile(sourcePath, destinationPathOnSftp, fileName);
        }
    }
}
