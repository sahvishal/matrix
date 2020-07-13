using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class EkgCardioCardFileParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private readonly ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;

        private const string EkgFilePrefix = "ecg";
        private const string SpiroFilePrefix = "spiro";

        public EkgCardioCardFileParser(string resultOutputPath, long eventId, ILogger logger)
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

            foreach (var filePath in DirectoryOperationsHelper.GetFiles(directoryPath))
            {
                if (Path.GetExtension(filePath).ToLower().Contains("pdf"))
                {
                    _logger.Info("Parsing file : " + filePath);
                    var fileName = Path.GetFileName(filePath);
                    bool isSpiro = false;
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    isSpiro = fileNameWithoutExtension.ToLower().EndsWith(SpiroFilePrefix);


                    var searchPattern = fileName.Substring(0, GetIndexOfNthOccurence(fileName, '_', 5)) + "*" + (isSpiro ? "_spiro.pdf" : "_ecg.pdf");

                    var versionedFiles = DirectoryOperationsHelper.GetFiles(directoryPath, searchPattern).Select(Path.GetFileName); ;

                    var latestVersion = versionedFiles.OrderByDescending(x => x).First();

                    if (Path.GetFileName(filePath) != latestVersion)
                    {
                        _logger.Info("A more recent version of this file is present : " + latestVersion);
                        continue;
                    }

                    var customerIdString = fileName.IndexOf("_") > 0 ? fileName.Substring(0, fileName.IndexOf("_")) : fileName;

                    long customerId;

                    if (!long.TryParse(customerIdString, out customerId))
                    {
                        _logger.Info("Customer ID not found on Pdf file : " + filePath);
                        continue;
                    }

                    if (!isSpiro)
                    {
                        bool isEkgTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.EKG);
                        bool isAwvEkgTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvEkg);
                        bool isAwvEkgIppeTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvEkgIPPE);

                        try
                        {
                            if (!isEkgTestPurchasedByCustomer && !isAwvEkgTestPurchasedByCustomer && !isAwvEkgIppeTestPurchasedByCustomer)
                            {
                                _logger.Info("EKG/ECG is not availed by CustomerId[" + customerId + "].\n");
                                continue;
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Info("EKG/ECG is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                            continue;
                        }

                        try
                        {
                            TestResult testResult = null;
                            var testType = TestType.EKG;

                            if (isAwvEkgIppeTestPurchasedByCustomer) //&& IsEkgIppeFile 
                                testType = TestType.AwvEkgIPPE;
                            else if (isAwvEkgTestPurchasedByCustomer)
                                testType = TestType.AwvEkg;

                            var folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                            var resultMedia = GetMediaFromPdfFile(filePath, folderToSaveImage, testType.ToString());
                            resultMedia.ReadingSource = ReadingSource.Automatic;

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
                                _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.CardioCard);

                                _logger.Info(string.Concat("\nParsing succeeded for EKG  for Customer Id: ", customerId, "\n"));
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                            _resultParserHelper.AddResultArchiveLog(ex.Message, isAwvEkgIppeTestPurchasedByCustomer ? TestType.AwvEkgIPPE : isAwvEkgTestPurchasedByCustomer ? TestType.AwvEkg : TestType.EKG, customerId, MedicalEquipmentTag.CardioCard, false);
                        }
                    }
                    else if (isSpiro)
                    {
                        bool isSpiroTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Spiro);
                        bool isAwvSpiroTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvSpiro);

                        try
                        {
                            if (!isSpiroTestPurchasedByCustomer && !isAwvSpiroTestPurchasedByCustomer)
                            {
                                _logger.Info("SPIRO/AWVSPIRO is not availed by CustomerId[" + customerId + "].\n");
                                continue;
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Info("SPIRO/AWVSPIRO is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                            continue;
                        }

                        try
                        {
                            TestResult testResult = null;
                            var testType = TestType.Spiro;

                            if (isAwvSpiroTestPurchasedByCustomer)
                                testType = TestType.AwvSpiro;

                            var folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                            var resultMedia = GetMediaFromPdfFile(filePath, folderToSaveImage, testType.ToString(), false);
                            resultMedia.ReadingSource = ReadingSource.Automatic;

                            if (resultMedia != null)
                            {
                                switch (testType)
                                {
                                    case TestType.Spiro:
                                        testResult = new SpiroTestResult
                                        {
                                            ResultImage = resultMedia
                                        };
                                        break;
                                    case TestType.AwvSpiro:
                                        testResult = new AwvSpiroTestResult
                                        {
                                            ResultImage = resultMedia
                                        };
                                        break;
                                }

                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                                _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.CardioCard);

                                _logger.Info(string.Concat("\nParsing succeeded for SPIRO/AWVSPIRO  for Customer Id: ", customerId, "\n"));
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                            _resultParserHelper.AddResultArchiveLog(ex.Message, isSpiroTestPurchasedByCustomer ? TestType.Spiro : TestType.AwvSpiro, customerId, MedicalEquipmentTag.CardioCard, false);
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
                                             new RectangleDimesion(0, 230, 1050, 270)
                                         };

            var highQualityRectangles = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(0, 1250, 6000, 1500)
                                         };

            return _mediaHelper.GetMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testName, hideSection, rectangles, highQualityRectangles);
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            // Need to provide a better pattern
            if (DirectoryOperationsHelper.GetFiles(toFindinFolder).Any(file => Path.GetExtension(file).ToLower().IndexOf("pdf") > 0))
            {
                return toFindinFolder;
            }

            foreach (string directory in DirectoryOperationsHelper.GetDirectories(toFindinFolder))
            {
                var path = GetFolderPathfor(directory);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }

        private int GetIndexOfNthOccurence(string text, char character, int occurence)
        {
            var index = 0;
            for (var i = 0; i < occurence; i++)
            {
                var remainingIndex = text.IndexOf(character) + 1;
                index += remainingIndex;
                text = text.Substring(remainingIndex);
            }
            return index;
        }
    }
}