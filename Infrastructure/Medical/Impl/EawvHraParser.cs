using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class EawvHraParser : IResultArchiveParser
    {
        private readonly IMediaRepository _mediaRepository;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IXmlSerializer<HraResultTags> _eawvHraSerializer;
        private readonly IMediaHelper _mediaHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILogger _logger;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IEventRepository _eventRepository;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        private const string HraFolderSnapshot = "Snapshot";
        private const string HraFolderPreventionPlan = "PreventionPlan";
        private const string HraFolderResultReport = "ResultReport";

        public EawvHraParser(ISettings settings, ILogger logger, ICorporateAccountRepository corporateAccountRepository, IXmlSerializer<HraResultTags> eawvHraSerializer, IMediaHelper mediaHelper, IEventCustomerRepository eventCustomerRepository)
        {
            _mediaRepository = new MediaRepository(settings);
            _corporateAccountRepository = corporateAccountRepository;
            _eawvHraSerializer = eawvHraSerializer;
            _mediaHelper = mediaHelper;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logger;
            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
            _eventRepository = new EventRepository();
            _accountHraChatQuestionnaireHistoryServices = new AccountHraChatQuestionnaireHistoryServices();
        }

        public IEnumerable<Core.Operations.Domain.ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }


        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            var mediaLocation = _mediaRepository.GetEawvHraResultMediaLocation();
            var mediaArchiveLocation = _mediaRepository.GetEawvHraResultArchiveMediaLocation();

            try
            {
                var xmlFilePaths = Directory.GetFiles(mediaLocation.PhysicalPath, "*.xml");

                foreach (var xmlfile in xmlFilePaths)
                {
                    _logger.Info("reading xml File: " + xmlfile);
                    HraResultTags eawvHraResult = null;
                    try
                    {
                        eawvHraResult = _eawvHraSerializer.Deserialize(xmlfile);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Some error occurred while reading xml. Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                        File.Move(xmlfile, Path.Combine(mediaArchiveLocation.PhysicalPath, Path.GetFileName(xmlfile)));
                    }

                    if (eawvHraResult == null)
                    {
                        _logger.Info("Some error occurred while reading xml.");
                        File.Move(xmlfile, Path.Combine(mediaArchiveLocation.PhysicalPath, Path.GetFileName(xmlfile)));
                    }

                    if (eawvHraResult.Events.IsNullOrEmpty())
                    {
                        _logger.Info("No Event Data found for Tag: " + eawvHraResult.Name);
                        File.Move(xmlfile, Path.Combine(mediaArchiveLocation.PhysicalPath, Path.GetFileName(xmlfile)));
                        continue;
                    }

                    var eventid = eawvHraResult.Events.First().EventId;

                    var account = _corporateAccountRepository.GetbyEventId(eventid);

                    if (account == null)
                    {
                        _logger.Info("No Corporate Account For Event Id: " + eventid);
                        File.Move(xmlfile, Path.Combine(mediaArchiveLocation.PhysicalPath, Path.GetFileName(xmlfile)));
                        continue;
                    }

                    _logger.Info("Running for corporate Account " + account.Tag);

                    var theEvent = _eventRepository.GetById(eventid);

                    QuestionnaireType questionnaireType = QuestionnaireType.None;
                    if (account != null && account.IsHealthPlan && theEvent != null)
                    {
                        questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                    }

                    if (questionnaireType != QuestionnaireType.HraQuestionnaire)
                    {
                        _logger.Info("HRA Questionnaire is not started");
                        continue;
                    }

                    var eawvTestNotPurchsed = new HraResultTags
                    {
                        Name = eawvHraResult.Name,
                        Events = new List<HraResultEvent>()
                    };

                    foreach (var hraResultEvent in eawvHraResult.Events)
                    {
                        var eventCustomers = _eventCustomerRepository.GetbyEventId(hraResultEvent.EventId);

                        if (eventCustomers.IsNullOrEmpty())
                        {
                            _logger.Info("No Event Cusotmer found");
                            continue;
                        }

                        var customeridNotToParse = eventCustomers.Where(x => x.NoShow || x.LeftWithoutScreeningReasonId.HasValue).Select(x => x.CustomerId);

                        var snapshotFolderPath = Path.Combine(mediaLocation.PhysicalPath, eawvHraResult.Name, hraResultEvent.EventId.ToString(), HraFolderSnapshot);
                        var preventionFolderPlan = Path.Combine(mediaLocation.PhysicalPath, eawvHraResult.Name, hraResultEvent.EventId.ToString(), HraFolderPreventionPlan);
                        var resultReportFolderPath = Path.Combine(mediaLocation.PhysicalPath, eawvHraResult.Name, hraResultEvent.EventId.ToString(), HraFolderResultReport);

                        var snapShotCustomerIds = (hraResultEvent.Snapshot != null && !hraResultEvent.Snapshot.CustomerId.IsNullOrEmpty()) ? hraResultEvent.Snapshot.CustomerId.Where(c => !customeridNotToParse.Contains(c)).Select(c => c).Distinct() : new List<long>();
                        var preventionPlanCustomerIds = (hraResultEvent.PreventionPlan != null && !hraResultEvent.PreventionPlan.CustomerId.IsNullOrEmpty()) ? hraResultEvent.PreventionPlan.CustomerId.Where(c => !customeridNotToParse.Contains(c)).Select(c => c).Distinct() : new List<long>();
                        var resultReportCustomerIds = (hraResultEvent.ResultReport != null && !hraResultEvent.ResultReport.CustomerId.IsNullOrEmpty()) ? hraResultEvent.ResultReport.CustomerId.Where(c => !customeridNotToParse.Contains(c)).Select(c => c).Distinct() : new List<long>();

                        _logger.Info(string.Format("============================Reading Snapshot for Tag:{0} EventId {1}=================================", eawvHraResult.Name, hraResultEvent.EventId));
                        _logger.Info(string.Format("snapshot folder Path: {0}", snapshotFolderPath));

                        var customerTestNotPurchased = new List<long>();
                        if (Directory.Exists(snapshotFolderPath))
                        {
                            _logger.Info("Count: "+  snapShotCustomerIds.Count());
                            foreach (var customerId in snapShotCustomerIds)
                            {
                                var snapShotFilePath = Path.Combine(snapshotFolderPath, customerId + ".pdf");

                                if (!File.Exists(snapShotFilePath))
                                {
                                    _logger.Info("SnapShot File does not exist at following location: " + snapShotFilePath);
                                    continue;
                                }

                                _logger.Info("SnapShot File exists at location: " + snapShotFilePath);

                                var isEAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(hraResultEvent.EventId, customerId, (long)TestType.eAWV);

                                if (!isEAwvTestPurchasedByCustomer)
                                {
                                    customerTestNotPurchased.Add(customerId);
                                    _logger.Info("EAWV : EAWV tests is not availed by CustomerId [" + customerId + "].\n");
                                    continue;
                                }

                                try
                                {
                                    var mediaFiles = new List<ResultMedia>();

                                    string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, hraResultEvent.EventId).PhysicalPath;
                                    _logger.Info("Get Snapshot Media");
                                    var snapShotResultMedia = GetMediaFromPdfFile(snapShotFilePath, folderToSavePdf, TestType.eAWV, AwvFileTypes.SnapShot);

                                    if (snapShotResultMedia != null)
                                    {
                                        _logger.Info("Inside SpanShot Result Media");

                                        snapShotResultMedia.ReadingSource = ReadingSource.Automatic;

                                        mediaFiles.Add(snapShotResultMedia);

                                        if (preventionPlanCustomerIds.Any(c => c == customerId))
                                        {
                                            var preventionPlanFile = Path.Combine(preventionFolderPlan,
                                                customerId + ".pdf");

                                            if (File.Exists(preventionPlanFile))
                                            {
                                                var preventionPlanMedia = GetMediaFromPdfFile(preventionPlanFile,
                                                    folderToSavePdf, TestType.eAWV, AwvFileTypes.PreventionPlan);
                                                if (preventionFolderPlan != null)
                                                {
                                                    preventionPlanMedia.ReadingSource = ReadingSource.Automatic;
                                                    mediaFiles.Add(preventionPlanMedia);
                                                    preventionPlanCustomerIds =
                                                        preventionPlanCustomerIds.Where(c => c != customerId).ToList();
                                                }
                                            }
                                            else
                                            {
                                                _logger.Info(
                                                    "Prevention Plan File does not exist at following location: " +
                                                    preventionPlanFile);
                                            }
                                        }

                                        if (resultReportCustomerIds.Any(c => c == customerId))
                                        {
                                            var resultReportFile = Path.Combine(resultReportFolderPath,
                                                customerId + ".pdf");

                                            if (File.Exists(resultReportFile))
                                            {
                                                var resultExportMedia = GetMediaFromPdfFile(resultReportFile,
                                                    folderToSavePdf, TestType.eAWV, AwvFileTypes.ResultExport);
                                                if (resultExportMedia != null)
                                                {
                                                    resultExportMedia.ReadingSource = ReadingSource.Automatic;
                                                    mediaFiles.Add(resultExportMedia);

                                                    resultReportCustomerIds =
                                                        resultReportCustomerIds.Where(c => c != customerId).ToList();
                                                }
                                            }
                                            else
                                            {
                                                _logger.Info(
                                                    "Result Report File does not exist at following location: " +
                                                    resultReportFile);
                                            }
                                        }
                                        var testResult = new EAwvTestResult {ResultImages = mediaFiles};

                                        _logger.Info("Inside SnapShot for adding Customer Aggregate");
                                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(
                                            eventCustomerAggregates, hraResultEvent.EventId, customerId, testResult);
                                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.eAWV, customerId,
                                            MedicalEquipmentTag.HRA);
                                    }
                                    else
                                    {
                                        _logger.Info("SpanShot Result Media Not Found");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("EAwv HRA: System Failure! Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                                    _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.eAWV, customerId, MedicalEquipmentTag.HRA);
                                }
                            }
                        }
                        else
                        {
                            _logger.Info("Snapshot Directory does not exit for EventId " + hraResultEvent.EventId);
                            _logger.Info("Snapshot Directory Path " + hraResultEvent.EventId);
                        }

                        _logger.Info(string.Format("============================Reading Prevention Plan for Tag:{0} EventId {1}=================================", eawvHraResult.Name, hraResultEvent.EventId));
                        _logger.Info(string.Format("Prevention Plan folder Path: {0}", preventionFolderPlan));


                        if (Directory.Exists(preventionFolderPlan))
                        {
                            foreach (var customerId in preventionPlanCustomerIds)
                            {
                                var preventionFilePath = Path.Combine(preventionFolderPlan, customerId + ".pdf");

                                if (!File.Exists(preventionFilePath))
                                {
                                    _logger.Info("Prevention Plan File does not exist at following location: " + preventionFilePath);
                                    continue;
                                }

                                var isEAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(hraResultEvent.EventId, customerId, (long)TestType.eAWV);

                                if (!isEAwvTestPurchasedByCustomer)
                                {
                                    customerTestNotPurchased.Add(customerId);
                                    _logger.Info("EAWV : EAWV tests is not availed by CustomerId [" + customerId + "].\n");
                                    continue;
                                }
                                try
                                {
                                    var mediaFiles = new List<ResultMedia>();
                                    string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, hraResultEvent.EventId).PhysicalPath;
                                    var preventionPlanResultMedia = GetMediaFromPdfFile(preventionFilePath, folderToSavePdf, TestType.eAWV, AwvFileTypes.PreventionPlan);

                                    if (preventionPlanResultMedia != null)
                                    {
                                        preventionPlanResultMedia.ReadingSource = ReadingSource.Automatic;
                                        mediaFiles.Add(preventionPlanResultMedia);

                                        if (resultReportCustomerIds.Any(c => c == customerId))
                                        {
                                            var resultReportFile = Path.Combine(resultReportFolderPath, customerId + ".pdf");

                                            if (File.Exists(resultReportFile))
                                            {
                                                var resultExportaMedia = GetMediaFromPdfFile(resultReportFile, folderToSavePdf, TestType.eAWV, AwvFileTypes.ResultExport);
                                                if (resultExportaMedia != null)
                                                {
                                                    resultExportaMedia.ReadingSource = ReadingSource.Automatic;
                                                    mediaFiles.Add(resultExportaMedia);

                                                    resultReportCustomerIds = resultReportCustomerIds.Where(c => c != customerId).ToList();
                                                }
                                            }
                                            else
                                            {
                                                _logger.Info("Result Report File does not exist at following location: " + resultReportFile);
                                            }
                                        }
                                        var testResult = new EAwvTestResult { ResultImages = mediaFiles };
                                        _logger.Info("Inside PreventionPLan for adding Customer Aggregate");
                                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, hraResultEvent.EventId, customerId, testResult);
                                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.eAWV, customerId, MedicalEquipmentTag.HRA);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("EAwv HRA: System Failure! Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                                    _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.eAWV, customerId, MedicalEquipmentTag.HRA);
                                }

                            }
                        }
                        else
                        {
                            _logger.Info("Prevention Plan Directory does not exit for EventId " + hraResultEvent.EventId);
                            _logger.Info("Prevention Plan Directory Path " + hraResultEvent.EventId);
                        }

                        _logger.Info(string.Format("============================Reading Result Report for Tag:{0} EventId {1}=================================", eawvHraResult.Name, hraResultEvent.EventId));
                        _logger.Info(string.Format("Result Report folder Path: {0}", resultReportFolderPath));


                        if (Directory.Exists(resultReportFolderPath))
                        {
                            foreach (var customerId in resultReportCustomerIds)
                            {
                                var resultReportFilePath = Path.Combine(resultReportFolderPath, customerId + ".pdf");

                                if (!File.Exists(resultReportFilePath))
                                {
                                    _logger.Info("Result Report File does not exist at following location: " + resultReportFilePath);
                                    continue;
                                }

                                var isEAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(hraResultEvent.EventId, customerId, (long)TestType.eAWV);

                                if (!isEAwvTestPurchasedByCustomer)
                                {
                                    customerTestNotPurchased.Add(customerId);
                                    _logger.Info("EAWV : EAWV tests is not availed by CustomerId [" + customerId + "].\n");
                                    continue;
                                }
                                try
                                {
                                    var mediaFiles = new List<ResultMedia>();
                                    string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, hraResultEvent.EventId).PhysicalPath;
                                    var resultExportMedia = GetMediaFromPdfFile(resultReportFilePath, folderToSavePdf, TestType.eAWV, AwvFileTypes.ResultExport);

                                    if (resultExportMedia != null)
                                    {
                                        resultExportMedia.ReadingSource = ReadingSource.Automatic;
                                        mediaFiles.Add(resultExportMedia);

                                        var testResult = new EAwvTestResult { ResultImages = mediaFiles };
                                        _logger.Info("Inside Result Report for adding Customer Aggregate");
                                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, hraResultEvent.EventId, customerId, testResult);
                                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.eAWV, customerId, MedicalEquipmentTag.HRA);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("EAwv HRA: System Failure! Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                                    _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.eAWV, customerId, MedicalEquipmentTag.HRA);
                                }

                            }
                        }
                        else
                        {
                            _logger.Info("Result Report Directory does not exit for EventId " + hraResultEvent.EventId);
                            _logger.Info("Result Report Directory Path " + hraResultEvent.EventId);
                        }

                        if (!customerTestNotPurchased.IsNullOrEmpty())
                        {
                            eawvTestNotPurchsed.Events.Add(new HraResultEvent
                            {
                                EventId = hraResultEvent.EventId,
                                PreventionPlan = new HraResultPreventionPlan { CustomerId = customerTestNotPurchased.ToList() },
                                Snapshot = new HraResultSnapshot { CustomerId = customerTestNotPurchased.ToList() },
                                ResultReport = new HraResultReport() { CustomerId = customerTestNotPurchased.ToList() }
                            });
                        }
                    }
                    if (!eawvTestNotPurchsed.Events.IsNullOrEmpty())
                    {
                        _eawvHraSerializer.SerializeandSave(Path.Combine(mediaLocation.PhysicalPath, "customerNotPurchaseTest_" + DateTime.Now.ToFileTime() + ".xml"), eawvTestNotPurchsed);
                    }

                    try
                    {
                        var archiveFileName = Path.Combine(mediaArchiveLocation.PhysicalPath, Path.GetFileName(xmlfile));
                        if (File.Exists(archiveFileName))
                            File.Delete(archiveFileName);
                        File.Move(xmlfile, archiveFileName);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while moving XML File in Archive folder");
                        _logger.Info(string.Format("Message: {0}", ex.Message));
                        _logger.Info(string.Format("stackTrace: {0}", ex.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error occurred while parsing Eawv Result");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            _logger.Info("EAWVParser eventCustomerAggregates count " + eventCustomerAggregates.Count);
            return eventCustomerAggregates;
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType, string awvFileType)
        {
            _logger.Info("pdfFilePath: " + pdfFilePath);
            _logger.Info("pdfFilePath: " + pdfFilePath);
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType + "_" + awvFileType, _logger);
        }

    }
}