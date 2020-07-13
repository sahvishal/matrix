using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class EkgFileParser2 : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;
        private readonly ISettings _settings;
        private readonly ITestResultRepository _testResultRepository;

        private const string StringForHeartRate = "heart_rate";
        private const string StringForPrInterval = "pd_pr";
        private const string StringForQrsDuration = "pd_qrs";
        private const string StringForQtInterval = "pd_qt";
        private const string StringForQtcInterval = "pd_qtc";

        private readonly bool _isNewResultFlow;

        public EkgFileParser2(string resultOutputPath, long eventId, ILogger logger, ISettings settings, bool isNewResultFlow)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _logger = logger;
            _mediaRepository = new MediaRepository(new Settings());
            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_logger);
            _settings = settings;
            _testResultRepository = new EKGTestRepository();

            _isNewResultFlow = isNewResultFlow;
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

            var filePathsForXml = Directory.GetFiles(directoryPath, "*.xml").OrderBy(m => m).ToArray();
            var filePathsForJpg = Directory.GetFiles(directoryPath, "*.jpg").OrderBy(m => m).ToArray();

            //var fileNameArray = filePathsForXml.Select(Path.GetFileNameWithoutExtension).ToList();
            //.AddRange(filePathsForJpg.Select(Path.GetFileNameWithoutExtension));

            if (filePathsForXml.Count() > 0)
            {
                foreach (var xmlFilePath in filePathsForXml)
                {
                    var fileName = Path.GetFileName(xmlFilePath);

                    long customerId = GetCustomerId(fileName);
                    if (customerId < 1)
                    {
                        _logger.Info("CustomerId not found on XML file " + xmlFilePath);
                        continue;
                    }

                    try
                    {
                        bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.EKG);
                        if (!isTestPurchasedByCustomer)
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
                        var imageFilePath =
                            filePathsForJpg.Where(
                                f => Path.GetFileNameWithoutExtension(f) == Path.GetFileNameWithoutExtension(xmlFilePath)).
                                FirstOrDefault();
                        if (string.IsNullOrEmpty(imageFilePath))
                        {
                            imageFilePath = filePathsForJpg.Where(f => f.Contains(customerId.ToString())).FirstOrDefault();
                            if (!string.IsNullOrEmpty(imageFilePath))
                            {
                                filePathsForJpg = filePathsForJpg.Where(f => f != imageFilePath).Select(f => f).ToArray();
                            }
                        }

                        var testResult = new EKGTestResult();

                        string folderToSaveImage =
                            _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var resultMedia = string.IsNullOrEmpty(imageFilePath)
                                              ? null
                                              : _mediaHelper.GetfromImageFile(new FileInfo(imageFilePath),
                                                                              TestType.EKG.ToString(), folderToSaveImage,
                                                                              _settings.HideEkgSection);

                        var resultData = GetDatafromXml(xmlFilePath, testResult);

                        if (!resultData && resultMedia == null)
                        {
                            _logger.Info(string.Concat("\nNo Data found for Id: ", customerId, "\n"));
                            continue;
                        }

                        testResult.ResultImage = resultMedia;

                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId,
                                                                                  customerId, testResult);
                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.EKG, customerId,
                                                                MedicalEquipmentTag.Schiller);

                        _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.EKG, customerId, MedicalEquipmentTag.Schiller, false);
                    }
                }
            }

            if (filePathsForJpg.Count() > 0)
            {
                foreach (var jpgFilePath in filePathsForJpg)
                {

                    var imageFilePath = filePathsForXml.Where(f => Path.GetFileNameWithoutExtension(f) == Path.GetFileNameWithoutExtension(jpgFilePath)).FirstOrDefault();
                    if (!string.IsNullOrEmpty(imageFilePath))
                        continue;

                    var fileName = Path.GetFileName(jpgFilePath);
                    long customerId = GetCustomerId(fileName);
                    if (customerId < 1)
                    {
                        _logger.Info("CustomerId not found on XML file " + filePathsForJpg);
                        continue;
                    }

                    try
                    {
                        bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.EKG);
                        if (!isTestPurchasedByCustomer)
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
                        EKGTestResult ekgTestResult;
                        var testResult = _testResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                        if (testResult == null)
                            ekgTestResult = new EKGTestResult();
                        else
                        {
                            ekgTestResult = (EKGTestResult)testResult;
                        }

                        string folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var resultMedia = _mediaHelper.GetfromImageFile(new FileInfo(jpgFilePath), TestType.EKG.ToString(), folderToSaveImage, _settings.HideEkgSection);
                        if (resultMedia == null)
                        {
                            _logger.Info(string.Concat("\nNo Data found for Id: ", customerId, "\n"));
                            continue;
                        }

                        ekgTestResult.ResultImage = resultMedia;

                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, ekgTestResult);
                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.EKG, customerId, MedicalEquipmentTag.Schiller);

                        _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.EKG, customerId, MedicalEquipmentTag.Schiller, false);
                    }
                }
            }

            return eventCustomerAggregates;
        }

        private static long GetCustomerId(string fileName)
        {
            var customerIdString = fileName.Substring(0, fileName.IndexOf("-"));

            long customerId;
            if (long.TryParse(customerIdString, out customerId)) return customerId;

            customerIdString = fileName.Substring(0, fileName.IndexOf("_"));
            if (long.TryParse(customerIdString, out customerId)) return customerId;

            customerIdString = fileName.IndexOf("-") != fileName.LastIndexOf("-")
                                   ? fileName.Substring(fileName.IndexOf("-") + 1, fileName.LastIndexOf("-") - fileName.IndexOf("-") - 1)
                                   : fileName.Substring(fileName.IndexOf("-") + 1, fileName.LastIndexOf(".") - fileName.IndexOf("-") - 1);

            return !long.TryParse(customerIdString, out customerId) ? 0 : customerId;
        }

        private bool GetDatafromXml(string filePath, EKGTestResult testResult)
        {
            XDocument xDoc = null;
            try
            {
                xDoc = XDocument.Load(filePath);
            }
            catch
            {
                _logger.Error(string.Format("Exception while loading XML Doc for {0}", filePath));
                return false;
            }

            if (testResult == null) testResult = new EKGTestResult();

            testResult.VentRate = GetIntObject(GetDatafromXmlNode(xDoc, StringForHeartRate), ReadingLabels.VentRate);
            testResult.PRInterval = GetDecimalObject(GetDatafromXmlNode(xDoc, StringForPrInterval), ReadingLabels.PRInterval);
            testResult.QRSDuration = GetDecimalObject(GetDatafromXmlNode(xDoc, StringForQrsDuration), ReadingLabels.QRSDuration);
            testResult.QTInterval = GetDecimalObject(GetDatafromXmlNode(xDoc, StringForQtInterval), ReadingLabels.QTInterval);
            testResult.QTcInterval = GetDecimalObject(GetDatafromXmlNode(xDoc, StringForQtcInterval), ReadingLabels.QTcInterval);

            if (testResult.VentRate == null && testResult.PRInterval == null && testResult.QRSDuration == null && testResult.QTInterval == null && testResult.QTcInterval == null)
                return false;

            return true;
        }

        private static ResultReading<int?> GetIntObject(string value, ReadingLabels readingLabel)
        {
            if (string.IsNullOrEmpty(value)) return null;

            int reading = 0;
            if (int.TryParse(value, out reading))
            {
                return new ResultReading<int?>(readingLabel) { Reading = reading, ReadingSource = ReadingSource.Automatic };
            }

            return null;
        }

        private static ResultReading<decimal?> GetDecimalObject(string value, ReadingLabels readingLabel)
        {
            if (string.IsNullOrEmpty(value)) return null;

            decimal reading = 0;
            if (decimal.TryParse(value, out reading))
            {
                return new ResultReading<decimal?>(readingLabel) { Reading = reading, ReadingSource = ReadingSource.Automatic };
            }

            return null;
        }

        private static string GetDatafromXmlNode(XDocument xDoc, string nodeType)
        {
            var query = from f in xDoc.Descendants() where f.Name.ToString().ToLower().Contains("code") select f;

            var valueNode = (from v in
                                 (from q in query
                                  where q.Attribute("code") != null && q.Attribute("code").Value.ToLower().Contains(nodeType)
                                  select q.Parent.Descendants()).FirstOrDefault()
                             where v.Name.ToString().ToLower().Contains("value")
                             select v).FirstOrDefault();

            if (valueNode == null || valueNode.Attribute("value") == null) return null;

            return valueNode.Attribute("value").Value.Trim();
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            // Need to provide a better pattern
            if (Directory.GetFiles(toFindinFolder).Any(file => Path.GetExtension(file).ToLower().Contains("jpg") || Path.GetExtension(file).ToLower().Contains("jpeg") || Path.GetExtension(file).ToLower().Contains("xml")))
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