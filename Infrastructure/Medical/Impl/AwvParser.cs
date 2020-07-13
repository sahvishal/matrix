using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class AwvParser : IResultArchiveParser
    {
        private readonly string _resultOutputPreventionPlanPath;
        private readonly string _resultOutputSanpShotPath;
        private readonly long _eventId;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;

        public AwvParser(string resultOutputPreventionPlanPath, string resultOutputSanpShotPath, long eventId, ILogger logger)
        {
            _resultOutputPreventionPlanPath = resultOutputPreventionPlanPath;
            _resultOutputSanpShotPath = resultOutputSanpShotPath;
            _eventId = eventId;
            _logger = logger;
            _mediaRepository = new MediaRepository(new Settings());
            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_logger);
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();

            var directoryPreventionPlanPath = GetFolderPathfor(_resultOutputPreventionPlanPath);
            var directorySnapShotPath = GetFolderPathfor(_resultOutputSanpShotPath);

            if (string.IsNullOrEmpty(directoryPreventionPlanPath) && string.IsNullOrEmpty(directorySnapShotPath))
                return null;

            List<string> snapShotFiles = null;
            List<string> preventionPlanFiles = null;
            if (!string.IsNullOrEmpty(directorySnapShotPath))
            {
                snapShotFiles = GetPdfFiles(directorySnapShotPath);
            }

            if (!string.IsNullOrEmpty(directoryPreventionPlanPath))
            {
                preventionPlanFiles = GetPdfFiles(directoryPreventionPlanPath);
            }

            if (snapShotFiles != null && snapShotFiles.Any())
            {
                foreach (var filePath in snapShotFiles)
                {
                    var customerIdString = Path.GetFileNameWithoutExtension(filePath);

                    long customerId = 0;
                    if (!long.TryParse(customerIdString, out customerId))
                    {
                        _logger.Info("AWV Snap Shot: CustomerId not found on Pdf file" + filePath);
                        continue;
                    }

                    bool isAwvTestPurchasedByCustomer = false;
                    bool isMedicareTestPurchasedByCustomer = false;

                    try
                    {
                        isAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AWV);
                        if (!isAwvTestPurchasedByCustomer)
                        {
                            isMedicareTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Medicare);
                            if (!isMedicareTestPurchasedByCustomer)
                            {
                                bool isAwvSubsequentTestPurchadedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvSubsequent);
                                if (!isAwvSubsequentTestPurchadedByCustomer)
                                {
                                    _logger.Info("AWV Snap Shot: None of AWV tests is availed by CustomerId[" + customerId + "].\n");
                                    continue;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("AWV Snap Shot: None of the AWV tests is availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);

                        continue;
                    }

                    TestType testType;

                    if (isAwvTestPurchasedByCustomer)
                        testType = TestType.AWV;
                    else if (isMedicareTestPurchasedByCustomer)
                        testType = TestType.Medicare;
                    else
                        testType = TestType.AwvSubsequent;

                    try
                    {
                        string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var snapShotResultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, testType, AwvFileTypes.SnapShot);

                        var mediaFiles = new List<ResultMedia>();
                        if (snapShotResultMedia != null)
                        {
                            mediaFiles.Add(snapShotResultMedia);

                            if (preventionPlanFiles != null && preventionPlanFiles.Any())
                            {
                                var preventionPlanFile = preventionPlanFiles.Where(ppf => Path.GetFileNameWithoutExtension(ppf) == customerIdString).Select(ppf => ppf).SingleOrDefault();
                                if (!string.IsNullOrEmpty(preventionPlanFile))
                                {
                                    var preventionPlanrResultMedia = GetMediaFromPdfFile(preventionPlanFile, folderToSavePdf, testType, AwvFileTypes.PreventionPlan);
                                    mediaFiles.Add(preventionPlanrResultMedia);
                                    preventionPlanFiles.Remove(preventionPlanFile);
                                }
                            }

                            TestResult testResult = null;
                            if (testType == TestType.AWV)
                                testResult = new AwvTestResult { ResultImages = mediaFiles };
                            else if (testType == TestType.Medicare)
                                testResult = new MedicareTestResult { ResultImages = mediaFiles };
                            else if (testType == TestType.AwvSubsequent)
                                testResult = new AwvSubsequentTestResult { ResultImages = mediaFiles };

                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.AWVPP);

                            _logger.Info(string.Concat("\n AWV Snap Shot.Parsing succeeded for Customer Id: ", customerId, "\n"));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("AWV Snap Shot: System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, testType, customerId, MedicalEquipmentTag.AWVPP, false);
                    }

                }
            }

            //Prevention Plan Files
            if (preventionPlanFiles != null && preventionPlanFiles.Any())
            {
                foreach (var filePath in preventionPlanFiles)
                {
                    var customerIdString = Path.GetFileNameWithoutExtension(filePath);

                    long customerId = 0;
                    if (!long.TryParse(customerIdString, out customerId))
                    {
                        _logger.Info("AWV Prevention Plan: CustomerId not found on Pdf file" + filePath);
                        continue;
                    }

                    bool isAwvTestPurchasedByCustomer = false;
                    bool isMedicareTestPurchasedByCustomer = false;
                    bool isAwvSubsequentTestPurchadedByCustomer = false;

                    try
                    {
                        isAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AWV);
                        if (!isAwvTestPurchasedByCustomer)
                        {
                            isMedicareTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Medicare);
                            if (!isMedicareTestPurchasedByCustomer)
                            {
                                isAwvSubsequentTestPurchadedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvSubsequent);
                                if (!isAwvSubsequentTestPurchadedByCustomer)
                                {
                                    var isEAwvTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.eAWV);
                                    if (!isEAwvTestPurchasedByCustomer)
                                    {
                                        _logger.Info("AWV Prevention Plan: None of AWV tests is availed by CustomerId[" + customerId + "].\n");
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("AWV Prevention Plan: None of the AWV tests is availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);

                        continue;
                    }

                    TestType testType;

                    if (isAwvTestPurchasedByCustomer)
                        testType = TestType.AWV;
                    else if (isMedicareTestPurchasedByCustomer)
                        testType = TestType.Medicare;
                    else if (isAwvSubsequentTestPurchadedByCustomer)
                        testType = TestType.AwvSubsequent;
                    else
                        testType = TestType.eAWV;

                    try
                    {
                        string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var preventionPlanrResultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, testType, AwvFileTypes.PreventionPlan);

                        var mediaFiles = new List<ResultMedia>();
                        if (preventionPlanrResultMedia != null)
                        {
                            mediaFiles.Add(preventionPlanrResultMedia);

                            TestResult testResult = null;
                            if (testType == TestType.AWV)
                                testResult = new AwvTestResult { ResultImages = mediaFiles };
                            else if (testType == TestType.Medicare)
                                testResult = new MedicareTestResult { ResultImages = mediaFiles };
                            else if (testType == TestType.AwvSubsequent)
                                testResult = new AwvSubsequentTestResult { ResultImages = mediaFiles };
                            else if (testType == TestType.eAWV)
                                testResult = new EAwvTestResult { ResultImages = mediaFiles };

                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.AWVPP);

                            _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("AWV Prevention Plan: System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, testType, customerId, MedicalEquipmentTag.AWVPP, false);
                    }

                }
            }

            return eventCustomerAggregates;
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType, string awvFileType)
        {
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType + "_" + awvFileType);
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            if (string.IsNullOrEmpty(toFindinFolder))
                return string.Empty;
            // Need to provide a better pattern
            if (Directory.GetFiles(toFindinFolder).Any(file => Path.GetExtension(file).ToLower().IndexOf("pdf") > 0))
            {
                return toFindinFolder;
            }

            foreach (string directory in Directory.GetDirectories(toFindinFolder))
            {
                var path = GetFolderPathfor(directory);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }

        private List<string> GetPdfFiles(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);
            if (files != null && files.Any())
            {
                var pdfFiles = files.Where(f => Path.GetExtension(f).ToLower().IndexOf("pdf") > 0).Select(f => f).ToList();
                return pdfFiles;
            }
            return null;
        }
    }
}
