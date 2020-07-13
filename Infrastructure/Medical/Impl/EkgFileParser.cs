using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class EkgFileParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private readonly ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;

        private bool _isSpiroFile = false;
        //private bool IsEkgIppeFile = false;
        private const string EkgFilePrefix = "EKG";
        private const string SpiroFilePrefix = "LUF";
       // private const string EkgIppeFilePreFix = "EKGIPPE";

        public EkgFileParser(string resultOutputPath, long eventId, ILogger logger)
        {
            _resultOutputPath = resultOutputPath;
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

            var directoryPath = GetFolderPathfor(_resultOutputPath);
            if (string.IsNullOrEmpty(directoryPath)) return null;

            foreach (var filePath in Directory.GetFiles(directoryPath))
            {
                _isSpiroFile = false;
               // IsEkgIppeFile = false;

                if (Path.GetExtension(filePath).ToLower().Contains("pdf"))
                {
                    var fileName = Path.GetFileName(filePath);

                    if (fileName.ToLower().StartsWith(SpiroFilePrefix.ToLower()))
                        _isSpiroFile = true;

                    //if (fileName.ToLower().StartsWith(EkgIppeFilePreFix.ToLower()))
                    //    IsEkgIppeFile = true;

                    var customerIdString = "";

                    if (_isSpiroFile)
                    {
                        var tempFileName = fileName.Substring(fileName.IndexOf("_") + 1);
                        customerIdString = tempFileName.Substring(0, tempFileName.IndexOf("_"));
                    }
                    //else if (IsEkgIppeFile)
                    //{
                    //    if (fileName.ToLower().StartsWith(EkgIppeFilePreFix.ToLower()))
                    //    {
                    //        var tempFileName = fileName.Substring(fileName.IndexOf("_") + 1);
                    //        customerIdString = tempFileName.Substring(0, tempFileName.IndexOf("_"));
                    //    }
                    //    else
                    //        customerIdString = fileName.Substring(0, fileName.IndexOf("_"));
                    //}
                    else
                    {
                        if (fileName.ToLower().StartsWith(EkgFilePrefix.ToLower()))
                        {
                            var tempFileName = fileName.Substring(fileName.IndexOf("_") + 1);
                            customerIdString = tempFileName.Substring(0, tempFileName.IndexOf("_"));
                        }
                        else
                            customerIdString = fileName.Substring(0, fileName.IndexOf("_"));
                    }

                    long customerId = 0;
                    if (!long.TryParse(customerIdString, out customerId))
                    {
                        _logger.Info("CustomerId not found on Pdf file" + filePath);
                        continue;
                    }

                    bool isSpiroTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Spiro);
                    bool isAwvSpiroTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvSpiro);

                    bool isEkgTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.EKG);
                    bool isAwvEkgTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvEkg);
                    bool isAwvEkgIppeTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvEkgIPPE);

                    try
                    {
                        if (_isSpiroFile)
                        {

                            if (!isSpiroTestPurchasedByCustomer && !isAwvSpiroTestPurchasedByCustomer)
                            {
                                _logger.Info("Spiro is not availed by CustomerId[" + customerId + "].\n");
                                continue;
                            }
                        }
                        else
                        {

                            if (!isEkgTestPurchasedByCustomer && !isAwvEkgTestPurchasedByCustomer && !isAwvEkgIppeTestPurchasedByCustomer)
                            {
                                _logger.Info("EKG/ECG is not availed by CustomerId[" + customerId + "].\n");
                                continue;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        if (_isSpiroFile)
                        {
                            _logger.Info("Spiro is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                        }
                        else
                        {
                            _logger.Info("EKG/ECG is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                        }
                        continue;
                    }
                    
                    try
                    {
                        TestType testType;
                        TestResult testResult = null;
                        if (_isSpiroFile)
                        {
                            testType = TestType.Spiro;

                            if (isAwvSpiroTestPurchasedByCustomer)
                            {
                                testType = TestType.AwvSpiro;
                            }

                            string folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                            var resultMedia = GetMediaFromPdfFile(filePath, folderToSaveImage, testType.ToString(), false);

                            if (resultMedia != null)
                            {
                                if (isAwvSpiroTestPurchasedByCustomer)
                                {
                                    testResult = new AwvSpiroTestResult
                                    {
                                        ResultImage = resultMedia
                                    };
                                }
                                else if (isSpiroTestPurchasedByCustomer)
                                {
                                    testResult = new SpiroTestResult
                                    {
                                        ResultImage = resultMedia
                                    };
                                }
                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);

                                _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.Schiller);

                                _logger.Info(string.Concat("\nParsing succeeded for Spiro for Customer Id: ", customerId, "\n"));
                            }
                        }
                        else
                        {
                            testType = TestType.EKG;

                            if (isAwvEkgIppeTestPurchasedByCustomer) //&& IsEkgIppeFile 
                                testType = TestType.AwvEkgIPPE;
                            else if (isAwvEkgTestPurchasedByCustomer)
                                testType = TestType.AwvEkg;

                            string folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                            var resultMedia = GetMediaFromPdfFile(filePath, folderToSaveImage, testType.ToString());

                            if (resultMedia != null)
                            {
                                switch (testType)
                                {
                                    case TestType.EKG:
                                        testResult = new EKGTestResult
                                        {
                                            ResultImage = resultMedia
                                        };
                                        break;
                                    case TestType.AwvEkg:
                                        testResult = new AwvEkgTestResult
                                        {
                                            ResultImage = resultMedia
                                        };
                                        break;
                                    case TestType.AwvEkgIPPE:
                                        testResult = new AwvEkgIppeTestResult
                                        {
                                            ResultImage = resultMedia
                                        };
                                        break;
                                }

                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                                _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.Schiller);

                                _logger.Info(string.Concat("\nParsing succeeded for EKG  for Customer Id: ", customerId, "\n"));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        if (_isSpiroFile)
                        {
                            _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                            _resultParserHelper.AddResultArchiveLog(ex.Message, isAwvSpiroTestPurchasedByCustomer ? TestType.AwvSpiro : TestType.Spiro, customerId, MedicalEquipmentTag.Schiller, false);
                        }
                        else
                        {
                            _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                            _resultParserHelper.AddResultArchiveLog(ex.Message, isAwvEkgIppeTestPurchasedByCustomer ? TestType.AwvEkgIPPE : isAwvEkgTestPurchasedByCustomer ? TestType.AwvEkg : TestType.EKG, customerId, MedicalEquipmentTag.Schiller, false);
                        }
                    }
                }
            }
            return eventCustomerAggregates;
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testName, bool hideSection = true)
        {
            var rectangles = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(390, 15, 325, 100),
                                             new RectangleDimesion(10, 15, 175, 100)
                                         };
            var highQualityImage = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(390, 15, 325, 100),
                                             new RectangleDimesion(10, 15, 175, 100)
                                         };

            return _mediaHelper.GetMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testName, hideSection,rectangles, highQualityImage);
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
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

    }
}