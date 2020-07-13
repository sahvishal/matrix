using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
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
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BloodResultParsePollingAgent : IBloodResultParsePollingAgent
    {
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerResultBloodLabRepository _eventCustomerResultBloodLabRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IEventCustomerResultBloodLabParserRepository _eventCustomerResultBloodLabParserRepository;

        private readonly ILogger _logger;
        private readonly ILogManager _logManager;

        private readonly string _bloodResultFolderLocation;
        private readonly string _bloodResultArchiveFolderLocation;
        private const long UploadedBy = 1;

        public BloodResultParsePollingAgent(ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICsvReader csvReader, IEventRepository eventRepository,
            IEventCustomerResultBloodLabRepository eventCustomerResultBloodLabRepository, Service.TestResultService testResultService, IEventCustomerResultBloodLabParserRepository eventCustomerResultBloodLabParserRepository)
        {
            _settings = settings;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _eventRepository = eventRepository;
            _eventCustomerResultBloodLabRepository = eventCustomerResultBloodLabRepository;
            _testResultService = testResultService;
            _logger = logManager.GetLogger("NewBloodResultParser");
            _logManager = logManager;
            _bloodResultFolderLocation = settings.BloodResultFolderLocation;
            _bloodResultArchiveFolderLocation = settings.BloodResultArchiveFolderLocation;
            _eventCustomerResultBloodLabParserRepository = eventCustomerResultBloodLabParserRepository;
        }

        public void Parse()
        {
            try
            {
                if (_settings.StopHansonResultParse)
                {
                    _logger.Info("Service has stop. If want enable please check setting.");
                    return;
                }

                _logger.Info("\n\n\n====================================== Blood Result Parsing - " + Directory.GetParent(_bloodResultFolderLocation).Name + "\\" + (new DirectoryInfo(_bloodResultFolderLocation)).Name + " ===========================================\n");

                if (!Directory.Exists(_bloodResultFolderLocation))
                {
                    _logger.Info("Blood Result Parsing - Folder does not exist at location" + _bloodResultFolderLocation);
                    return;

                }
                var files = Directory.GetFiles(_bloodResultFolderLocation).Where(x => x.Contains("csv"));

                if (files.IsNullOrEmpty())
                {
                    _logger.Info("Blood Result Parsing - No File Found For Parsing at " + _bloodResultFolderLocation);
                    return;
                }


                if (!Directory.Exists(_bloodResultArchiveFolderLocation))
                {
                    Directory.CreateDirectory(_bloodResultArchiveFolderLocation);
                }


                var mediaLocation = _mediaRepository.GetBloodResultParseMediaLocation();
                var archiveMediaLocation = Path.Combine(mediaLocation.PhysicalPath, "Archive", DateTime.Today.ToString("MMddyyyy"));
                var failedRecordsLocation = Path.Combine(mediaLocation.PhysicalPath, "Failed", DateTime.Today.ToString("MMddyyyy"));

                foreach (var file in files)
                {
                    _logger.Info("Blood Result Parsing - Files: " + file + " Started");

                    var fileName = Path.GetFileName(file);
                    if (string.IsNullOrEmpty(fileName)) return;
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(archiveMediaLocation);

                    var mediaFilePath = Path.Combine(mediaLocation.PhysicalPath, fileName);

                    DirectoryOperationsHelper.DeleteFileIfExist(mediaFilePath);
                    
                    _logger.Info("Moving file to media location : " + mediaFilePath);
                    DirectoryOperationsHelper.Move(file, mediaFilePath);
                    _logger.Info("File moved : " + fileName);

                    var newFileName = Path.GetFileNameWithoutExtension(file) + "_" + DateTime.Now.ToString("MMddyyyhhmmss");

                    var parseLogger = _logManager.GetLogger(newFileName);

                    var bloodResultParser = new BloodResultParser(mediaFilePath, parseLogger, _csvReader, _logManager);
                    var customerScreeningData = bloodResultParser.Parse();

                    _logger.Info("Blood Result Parsing - Files: " + file + " Completed");

                    if (customerScreeningData.IsNullOrEmpty())
                    {
                        DirectoryOperationsHelper.Copy(mediaFilePath, Path.Combine(_bloodResultArchiveFolderLocation, newFileName + Path.GetExtension(mediaFilePath)));
                        DirectoryOperationsHelper.Move(mediaFilePath, Path.Combine(archiveMediaLocation, newFileName + Path.GetExtension(mediaFilePath)));
                        continue;
                    }

                    Save(customerScreeningData, UploadedBy);

                    DirectoryOperationsHelper.Copy(mediaFilePath, Path.Combine(archiveMediaLocation, newFileName + Path.GetExtension(mediaFilePath)));
                    _logger.Info("Blood Result Parsing - Files: " + file + " copied on Archive location");

                    DirectoryOperationsHelper.Move(mediaFilePath, _bloodResultArchiveFolderLocation + newFileName + Path.GetExtension(mediaFilePath));
                    _logger.Info("Blood Result Parsing - Files: " + file + " moved on Client location");

                    var resultLog = bloodResultParser.BloodTestResultParserLogs;

                    if (!resultLog.IsNullOrEmpty() && resultLog.Any(x => !x.IsSuccessful))
                    {
                        var failedFileName = newFileName + "_ErrorLog.csv";
                        var failedRecordsFilePath = Path.Combine(failedRecordsLocation, failedFileName);

                        _logger.Info("Creating error log file : " + failedFileName);
                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(failedRecordsLocation);
                        UpdateFailedRecords(failedRecordsFilePath, resultLog.Where(x => !x.IsSuccessful));

                        _logger.Info("Moving error log file to archive location.");
                        DirectoryOperationsHelper.Copy(failedRecordsFilePath, Path.Combine(_bloodResultArchiveFolderLocation, failedFileName));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Blood Result parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
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

                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true);

                foreach (var testResult in eventCustomerScreeningAggregate.TestResults)
                {
                    var eventData = events.First(x => x.Id == eventCustomerResult.EventId);

                    var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                    testResult.IsNewResultFlow = isNewResultFlow;

                    SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, isNewResultFlow);
                    try
                    {
                        if (testResult.TestType == TestType.Psa)
                        {
                            var eventCustomerResultBloodLabParse = new EventCustomerResultBloodLabParser()
                            {
                                BloodLabId = (long)BloodLabsType.Hanson,
                                EventCustomerResultId = eventCustomerResult.Id,
                                IsActive = true
                            };
                            _eventCustomerResultBloodLabParserRepository.Save(eventCustomerResultBloodLabParse);
                        }
                    }
                    catch(Exception ex)
                    {
                        _logger.Error("Event Customer Result Blood Lab Parser : " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

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
                _logger.Error(string.Format("Blood Result ResultParser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }

        private void UpdateFailedRecords(string filePath, IEnumerable<BloodResultParserLogModel> failedCustomers)
        {
            var sb = new StringBuilder();
            var members = (typeof(BloodResultParserLogModel)).GetMembers();
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
    }
}
