using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class LabReportParserPollingAgent : ILabReportParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogManager _logManager;
        private ILogger _loggerForClient;
        private readonly string _labReportTestResultPath;
        private readonly string _labReportArchivedTestResultPath;
        private readonly Service.TestResultService _testResultService;
        private const long UploadedBy = 1;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly bool _isDevEnvironment;
        private readonly IEventRepository _eventRepository;

        public LabReportParserPollingAgent(ISettings settings, ILogManager logManager, IEventCustomerRepository eventCustomerRepository, IEventRepository eventRepository)
        {
            _settings = settings;
            _logManager = logManager;
            _labReportTestResultPath = _settings.LabReportTestResultPath;
            _labReportArchivedTestResultPath = _settings.LabReportArchivedTestResultPath;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            // _logger = logManager.GetLogger("LabReportParseResult");
            _loggerForClient = logManager.GetLogger("LabReportClientLogger");
            _testResultService = new Service.TestResultService();
            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void Parse()
        {

            try
            {
                _loggerForClient = _logManager.GetLogger("LabReportClientLogger_" + DateTime.Now.ToString("yyyyMMdd"));
                _loggerForClient.Info("\n\n\n=== Lab Report Parsing - " + Directory.GetParent(_labReportTestResultPath).Name + "\\" + (new DirectoryInfo(_labReportTestResultPath)).Name + " ============\n");

                var timeOfDay = DateTime.Now;

                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(3, 0, 0))
                {
                    if (!DirectoryOperationsHelper.IsDirectoryExist(_labReportTestResultPath))
                    {
                        _loggerForClient.Info("Lab Report Parsing - Folder does not exist at location" + _labReportTestResultPath);
                        return;

                    }
                    if (!DirectoryOperationsHelper.GetFiles(_labReportTestResultPath).Any())
                    {
                        _loggerForClient.Info("Lab Report Parsing - There is not any File available for Parsing " + _labReportTestResultPath);
                        return;
                    }

                    var fileList = DirectoryOperationsHelper.GetFiles(_labReportTestResultPath);

                    if (fileList != null && fileList.Any())
                    {
                        _loggerForClient.Info("Number of Events : " + fileList.Count());

                        var labReportParser = new LabReportParser(_labReportTestResultPath, _labReportArchivedTestResultPath, _loggerForClient, _settings, _eventCustomerRepository, _logManager);
                        var customerScreeningData = labReportParser.Parse();
                        _loggerForClient.Info("----------------------------");
                        Save(customerScreeningData, UploadedBy);
                    }
                }

                //DirectoryOperationsHelper.CreateDirectoryIfNotExist(_labParseClientLoggerPath);
                //var sourcePath = _mediaRepository.GetLogFolderLocation().PhysicalPath;
                //sourcePath = Path.Combine(sourcePath, folderName);
                //var clientLoggerFiles = DirectoryOperationsHelper.GetFiles(sourcePath, "LabReportClientLogger_" + DateTime.Now.ToString("ddMMyyyy_") + "*.txt");
                //if (clientLoggerFiles.Count() > 0)
                //{
                //    foreach (var clientLogger in clientLoggerFiles)
                //    {
                //        string fileName = new FileInfo(clientLogger).Name;
                //        var sourceFile = Path.Combine(sourcePath, fileName);
                //        var destinationFile = Path.Combine(_labParseClientLoggerPath, fileName);
                //        DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);
                //        DirectoryOperationsHelper.Copy(sourceFile, destinationFile);
                //    }

                //}

            }
            catch (Exception ex)
            {
                _loggerForClient.Error("Lab Report parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
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
                try
                {
                    var eventCustomerResult = SaveEventCustomerResult(eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy);

                    foreach (var testResult in eventCustomerScreeningAggregate.TestResults)
                    {
                        var eventData = events.First(x => x.Id == eventCustomerResult.EventId);

                        var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;
                        _loggerForClient.Info(string.Format("Lab Report Parsing for Customer Id:  {0} , Event Id {1}, Result Status:  {2}", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId, (long)eventCustomerResult.ResultState));

                        testResult.IsNewResultFlow = isNewResultFlow;

                        SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, isNewResultFlow);

                        _loggerForClient.Info(string.Format("Lab Report Parsing completed for Customer Id:  {0} , Event Id {1} ", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId));
                    }
                }
                catch (Exception ex)
                {
                    _loggerForClient.Error("some Error occurred while saving data");
                    _loggerForClient.Error("message " + ex.Message);
                    _loggerForClient.Error("stack Trace " + ex.StackTrace);
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

            string labParseLogger = "LabParseLogger_" + Convert.ToString(eventId);
            var labParseEventLogger = _logManager.GetLogger(labParseLogger);

            if (isNewResultFlow)
            {
                if (resultState >= (int)NewTestResultStateNumber.PostAuditNew)
                {
                    _loggerForClient.Info("Lab Report not saved for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType + " because Result state has been either in Post Audit state or crossed Post audit state.");
                    labParseEventLogger.Info("Lab Report not saved for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType + " because Result state has been either in Post Audit state or crossed Post audit state.");
                    return;
                }

                testResult.ResultStatus = new TestResultState
                {
                    StateNumber = resultState >= (int)NewTestResultStateNumber.PreAudit ? resultState : (int)NewTestResultStateNumber.ResultEntryPartial,
                    Status = resultState > (int)NewTestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete
                };
            }
            else
            {
                if (resultState >= (int)TestResultStateNumber.PostAudit)
                {
                    _loggerForClient.Info("Lab Report not saved for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType + " because Result state has been either in Post Audit state or crossed Post audit state.");
                    labParseEventLogger.Info("Lab Report not saved for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType + " because Result state has been either in Post Audit state or crossed Post audit state.");
                    return;
                }

                testResult.ResultStatus = new TestResultState
                {
                    StateNumber = resultState >= (int)TestResultStateNumber.PreAudit ? resultState : (int)TestResultStateNumber.ResultsUploaded,
                    Status = resultState > (int)TestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete
                };
            }

            testResult.DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(uploadedBy), DateCreated = DateTime.Now };

            try
            {
                _testResultService.SaveTestResult(testResult, eventId, customerId, uploadedBy, _loggerForClient, ReadingSource.Automatic);
                _loggerForClient.Info("Lab Report saved successfully for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType);
                labParseEventLogger.Info("Lab Report saved successfully for Event Id: " + eventId + " ,Customer Id: " + customerId + " and Test type :" + testResult.TestType);
            }
            catch (Exception exception)
            {
                _loggerForClient.Error(string.Format("Lab Report ResultParser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}
