using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
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
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using MongoDB.Driver.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EawvHraParserPollingAgent : IEawvHraParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IXmlSerializer<HraResultTags> _eawvHraSerializer;
        private readonly IMediaHelper _mediaHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILogger _logger;
        private readonly Service.TestResultService _testResultService;
        private const long UploadedBy = 1;
        private readonly IEventRepository _eventRepository;
        private readonly ITestResultService _testResultServiceForResultState;
        private readonly bool _isDevEnvironment;

        public EawvHraParserPollingAgent(ISettings settings, ILogManager logManager, IMediaRepository mediaRepository,
            ICorporateAccountRepository corporateAccountRepository, IXmlSerializer<HraResultTags> eawvHraSerializer,
            IMediaHelper mediaHelper, IEventCustomerRepository eventCustomerRepository, IEventRepository eventRepository, ITestResultService testResultServiceForResultState)
        {
            _settings = settings;
            _mediaRepository = mediaRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eawvHraSerializer = eawvHraSerializer;
            _mediaHelper = mediaHelper;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _testResultServiceForResultState = testResultServiceForResultState;

            _testResultService = new Service.TestResultService();

            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("EawhraParser");
        }

        public void PollforParsing()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    _logger.Info("========================= Eawv Result Parser HRA===============");
                    var mediaLocation = _mediaRepository.GetEawvHraResultMediaLocation();
                    var xmlFilePaths = Directory.GetFiles(mediaLocation.PhysicalPath, "*.xml");

                    if (xmlFilePaths.IsNullOrEmpty())
                    {
                        _logger.Info("No xml file found for Parsing at location:" + mediaLocation.PhysicalPath);
                        return;
                    }

                    var eawvHraResultParser = new EawvHraParser(_settings, _logger, _corporateAccountRepository, _eawvHraSerializer, _mediaHelper, _eventCustomerRepository);
                    var customerScreeningData = eawvHraResultParser.Parse();

                    Save(customerScreeningData, UploadedBy);

                    _logger.Info("After Save in Poll method");
                }
                else
                {
                    _logger.Info(string.Format("Eawv Result Parser HRA can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error Occurred with Eawv Hra Parser");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void Save(IEnumerable<EventCustomerScreeningAggregate> eventCustomerScreeningAggregates, long uploadedBy)
        {
            _logger.Info("In Save Method");
            _logger.Info("EAWV HRA ParserPolling Agent eventCustomerScreeningAggregates count " + eventCustomerScreeningAggregates.Count());
            if (eventCustomerScreeningAggregates.IsNullOrEmpty())
                return;

            var eventids = eventCustomerScreeningAggregates.Select(x => x.EventId).ToArray();

            var events = _eventRepository.GetEvents(eventids);

            _logger.Info("EAWV HRA ParserPolling Agent After getting events");

            foreach (var eventCustomerScreeningAggregate in eventCustomerScreeningAggregates)
            {
                try
                {
                    _logger.Info(string.Format("running for Customer Id:  {0} , Event Id {1} ", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId));

                    var eventCustomerResult = SaveEventCustomerResult(eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy);

                    foreach (var testResult in eventCustomerScreeningAggregate.TestResults)
                    {
                        var eventData = events.First(x => x.Id == eventCustomerResult.EventId);

                        var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;
                        _logger.Info(string.Format("Customer Id:  {0} , Event Id {1}, Result Status:  {2}", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId, (long)eventCustomerResult.ResultState));

                        testResult.IsNewResultFlow = isNewResultFlow;

                        SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, isNewResultFlow);
                    }

                    _logger.Info(string.Format("completed for Customer Id:  {0} , Event Id {1} ", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId));
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error for Customer Id:  {0} , Event Id {1} ", eventCustomerScreeningAggregate.CustomerId, eventCustomerScreeningAggregate.EventId));
                    _logger.Error("message: " + ex.Message);
                    _logger.Error("message: " + ex.StackTrace);
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
            bool isArtifactSynced = false;
            if (isNewResultFlow)
            {
                var eawvTestResult = testResult as EAwvTestResult;

                if (resultState >= (int)NewTestResultStateNumber.PostAuditNew)
                {
                    _logger.Info("file can be parsed as result state is on or above " + NewTestResultStateLabel.PostAudit);
                    return;
                }

                if (resultState == (int)NewTestResultStateNumber.CodingCompleted && !CheckMediaNotCompleted(eawvTestResult.ResultImages))
                {
                    resultState = (int)NewTestResultStateNumber.ArtifactSynced;
                    isArtifactSynced = true;
                }
                else if (resultState < (int)NewTestResultStateNumber.PreAudit)
                {
                    resultState = (int)NewTestResultStateNumber.ResultEntryPartial;
                }

                testResult.ResultStatus = new TestResultState
                {
                    StateNumber = resultState,
                    Status = resultState > (int)NewTestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete
                };
            }
            else
            {
                if (resultState >= (int)TestResultStateNumber.PostAudit)
                {
                    _logger.Info("file can be parsed as result state is on or above " + TestResultStateLabel.PostAudit);
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
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        _testResultService.SaveTestResult(testResult, eventId, customerId, uploadedBy, _logger, ReadingSource.Automatic);
                        if (isArtifactSynced)
                        {
                            _testResultServiceForResultState.SetResultstoState(eventId, customerId, resultState, false, uploadedBy);
                        }
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some error occurred while saving result ");
                        _logger.Error("message: " + ex.Message);
                        scope.Dispose();
                        _logger.Error("Stack trace: " + ex.StackTrace);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Eawv HRA Result Parser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }

        private bool CheckMediaNotCompleted(IEnumerable<ResultMedia> resultImages)
        {
            if (resultImages.IsNullOrEmpty()) return true;
            var containSnapshot = resultImages.Any(item => item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.SnapShot));
            var containPreventionPlan = resultImages.Any(item => item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.PreventionPlan));
            var containResultExport = resultImages.Any(item => item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.ResultExport));
            if (containSnapshot && containPreventionPlan && containResultExport) return false;

            return true;
        }

    }
}