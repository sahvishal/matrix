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
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BloodTestResultParserPollingAgent : IBloodTestResultParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly string _bloodTestFolder;
        private readonly string _bloodTestArchiveFolderLocation;
        private readonly Service.TestResultService _testResultService;
        private readonly IEventCustomerResultBloodLabRepository _eventCustomerResultBloodLabRepository;
        private readonly ILogManager _logManager;
        private readonly IEventRepository _eventRepository;

        private const long UploadedBy = 1;

        public BloodTestResultParserPollingAgent(ISettings settings, ILogManager logManager, IEventCustomerResultBloodLabRepository eventCustomerResultBloodLabRepository, 
            IEventRepository eventRepository)
        {
            _settings = settings;
            _bloodTestFolder = _settings.BloodTestFolderLocation;
            _bloodTestArchiveFolderLocation = _settings.BloodTestArchiveFolderLocation;
            _logManager = logManager;

            _logger = logManager.GetLogger("BloodTestResult");
            _testResultService = new Service.TestResultService();
            _eventCustomerResultBloodLabRepository = eventCustomerResultBloodLabRepository;
            _eventRepository = eventRepository;
        }

        public void Parse()
        {

            try
            {
                _logger.Info("\n\n\n====================================== Blood Test Parsing - " + Directory.GetParent(_bloodTestFolder).Name + "\\" + (new DirectoryInfo(_bloodTestFolder)).Name + " ===========================================\n");

                if (!Directory.Exists(_bloodTestFolder))
                {
                    _logger.Info("Blood Test Parsing - Folder does not exist at location" + _bloodTestFolder);
                    return;

                }
                var files = Directory.GetFiles(_bloodTestFolder).Where(x => x.Contains("xls") || x.Contains("xlsx"));

                if (files.IsNullOrEmpty())
                {
                    _logger.Info("Blood Test Parsing - No File Found For Parsing at " + _bloodTestFolder);
                    return;
                }


                if (!Directory.Exists(_bloodTestArchiveFolderLocation))
                {
                    Directory.CreateDirectory(_bloodTestArchiveFolderLocation);
                }

                foreach (var file in files)
                {
                    _logger.Info("Blood Test Parsing - Files: " + file + " Started");
                    var newFileName = Path.GetFileNameWithoutExtension(file) + "_" + DateTime.UtcNow.ToString("MMddyyyhhmmss");
                    var parseLogger = _logManager.GetLogger(newFileName);

                    var bloodTestParser = new BloodTestParser(file, parseLogger, new ExcelReader(), null, false);
                    var customerScreeningData = bloodTestParser.Parse();

                    _logger.Info("Blood Test Parsing - Files: " + file + " Completed");

                    if (customerScreeningData.IsNullOrEmpty())
                    {
                        File.Move(file, _bloodTestArchiveFolderLocation + newFileName + Path.GetExtension(file));
                        continue;
                    }

                    Save(customerScreeningData, UploadedBy);
                    File.Move(file, _bloodTestArchiveFolderLocation + newFileName + Path.GetExtension(file));
                    var resultLog = bloodTestParser.BloodTestResultParserLogs;

                    if (!resultLog.IsNullOrEmpty() && resultLog.Any(x => !x.IsSuccessful))
                    {
                        UpdateFailedRecords(_bloodTestArchiveFolderLocation + newFileName + ".csv", resultLog.Where(x => !x.IsSuccessful));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Blood Test parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
            }

        }

        private void Save(IEnumerable<EventCustomerScreeningAggregate> eventCustomerScreeningAggregates, long uploadedBy)
        {
            if (eventCustomerScreeningAggregates == null)
                return;

            var eventids = eventCustomerScreeningAggregates.Select(x => x.EventId).ToArray();

            var events = _eventRepository.GetEvents(eventids);

            foreach (var eventCustomerScreeningAggregate in eventCustomerScreeningAggregates)
            {
                var eventCustomerResult = SaveEventCustomerResult(eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy);

                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, false);

                foreach (var testResult in eventCustomerScreeningAggregate.TestResults)
                {
                    var eventData = events.First(x => x.Id == eventCustomerResult.EventId);

                    var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                    testResult.IsNewResultFlow = isNewResultFlow;

                    SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, isNewResultFlow);
                }
            }
        }

        private EventCustomerResult SaveEventCustomerResult(long eventId, long customerId, long uploadedBy)
        {
            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null)
            {
                eventCustomerResult = new EventCustomerResult
                {
                    CustomerId = customerId,
                    EventId = eventId,
                    DataRecorderMetaData =
                        new DataRecorderMetaData(uploadedBy, DateTime.Now, null)
                };
                eventCustomerResult = eventCustomerResultRepository.Save(eventCustomerResult);
            }

            return eventCustomerResult;
        }

        private void SaveTestResult(TestResult testResult, long eventId, long customerId, long uploadedBy, int resultState, bool isPartial, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                testResult.ResultStatus = new TestResultState
                {
                    StateNumber = resultState >= (int)NewTestResultStateNumber.PreAudit ? resultState : (int)NewTestResultStateNumber.ResultEntryPartial,
                    Status = resultState > (int)NewTestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete

                };
            }
            else
            {
                testResult.ResultStatus = new TestResultState
                {
                    StateNumber = resultState >= (int)TestResultStateNumber.PreAudit ? resultState : (int)TestResultStateNumber.ResultsUploaded,
                    Status = resultState > (int)TestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete

                };
            }
            
            testResult.DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(uploadedBy), DateCreated = DateTime.Now };

            try
            {
                _testResultService.SaveTestResult(testResult, eventId, customerId, uploadedBy, _logger, ReadingSource.Automatic);
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Blood Test ResultParser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }

        private void UpdateFailedRecords(string filePath, IEnumerable<BloodTestResultParserLog> failedCustomers)
        {
            var sb = new StringBuilder();
            var members = (typeof(BloodTestResultParserLog)).GetMembers();
            var sanitizer = new CSVSanitizer();


            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo == null)
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
            sb.Append(string.Join(",", header.ToArray()) + Environment.NewLine);
            foreach (var customer in failedCustomers)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo == null) continue;

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

                    var obj = propInfo.GetValue(customer, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                sb.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            File.AppendAllText(filePath, sb.ToString());
        }

        private void SaveEventCustomerResultBloodLab(long eventCustomerResulId, bool isNew)
        {
            var domain = new EventCustomerResultBloodLab
            {
                EventCustomerResultId = eventCustomerResulId,
                IsFromNewLab = isNew,
                CreatedByOrgRoleUserid = UploadedBy,
                DateCreated = DateTime.Now
            };

            _eventCustomerResultBloodLabRepository.Save(domain);
        }

    }
}
