using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class DiabeticRetinopathyParserPollingAgent : IDiabeticRetinopathyParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly string _diabeticRetinopathyFolderLocation;
        private readonly string _diabeticRetinopathyArchiveFolderLocation;
        private readonly Service.TestResultService _testResultService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private const long UploadedBy = 1;
        private readonly IDiabeticRetinopathyParserlogRepository _diabeticRetinopathyParserlogRepository;
        private readonly IEventRepository _eventRepository;

        public DiabeticRetinopathyParserPollingAgent(ISettings settings, ILogManager logManager, IEventCustomerRepository eventCustomerRepository, IDiabeticRetinopathyParserlogRepository diabeticRetinopathyParserlogRepository, IEventRepository eventRepository)
        {
            _settings = settings;
            _diabeticRetinopathyFolderLocation = _settings.DiabeticRetinopathyFolderLocation;
            _diabeticRetinopathyArchiveFolderLocation = _settings.DiabeticRetinopathyArchiveFolderLocation;
            _diabeticRetinopathyParserlogRepository = diabeticRetinopathyParserlogRepository;
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger("DiabeticRetinopathyTestResult");
            _testResultService = new Service.TestResultService();
            _eventCustomerRepository = eventCustomerRepository;
        }

        public void Parse()
        {

            try
            {
                _logger.Info("\n\n\n====================================== Diabetic Retinopathy Parsing - " + Directory.GetParent(_diabeticRetinopathyFolderLocation).Name + "\\" + (new DirectoryInfo(_diabeticRetinopathyFolderLocation)).Name + " ===========================================\n");

                if (!Directory.Exists(_diabeticRetinopathyFolderLocation))
                {
                    _logger.Info("Diabetic Retinopathy Parsing - Folder does not exist at location" + _diabeticRetinopathyFolderLocation);
                    return;

                }
                var files = Directory.GetFiles(_diabeticRetinopathyFolderLocation).Where(x => x.Contains("pdf"));

                if (files.IsNullOrEmpty())
                {
                    _logger.Info("Diabetic Retinopathy Parsing - No File Found For Parsing at " + _diabeticRetinopathyFolderLocation);
                    return;
                }

                var diabeticRetinopathyParser = new DiabeticRetinopathyParser(_diabeticRetinopathyFolderLocation, _logger, _eventCustomerRepository, _settings, _diabeticRetinopathyParserlogRepository);
                var customerScreeningData = diabeticRetinopathyParser.Parse();
                Save(customerScreeningData, UploadedBy);

                if (!Directory.Exists(_diabeticRetinopathyArchiveFolderLocation))
                {
                    Directory.CreateDirectory(_diabeticRetinopathyArchiveFolderLocation);
                }

                foreach (var file in files)
                {
                    try
                    {
                        var newFileName = Path.GetFileName(file);
                        var destinationFilePath = _diabeticRetinopathyArchiveFolderLocation + newFileName;
                        if (File.Exists(_diabeticRetinopathyArchiveFolderLocation + newFileName))
                            File.Delete(destinationFilePath);

                        File.Move(file, destinationFilePath);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Diabetic Retinopathy parsing: Error while moving to archive location. File name: " + file + "Message" + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.Error("Diabetic Retinopathy parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
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

                        testResult.IsNewResultFlow = isNewResultFlow;

                        SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, isNewResultFlow);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("some Error occurred while saving data");
                    _logger.Error("message " + ex.Message);
                    _logger.Error("stack Trace " + ex.StackTrace);
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
                _logger.Error(string.Format("Diabetic Retinopathy ResultParser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}
