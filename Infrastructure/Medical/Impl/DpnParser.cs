using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebSupergoo.ABCpdf10;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class DpnParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private readonly bool _isNewResultFlow;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        public DpnParser(string resultOutputPath, long eventId, ILogger logger, bool isNewResultFlow)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _isNewResultFlow = isNewResultFlow;
            _logger = logger;
            _mediaRepository = new MediaRepository(new Settings());
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_logger);
            _eventCustomerRepository = new EventCustomerRepository();
            _eventCustomerResultRepository = new EventCustomerResultRepository();
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();

            var directoryPath = GetFolderPathfor(_resultOutputPath);

            if (string.IsNullOrEmpty(directoryPath))
                return null;

            var pdfFiles = DirectoryOperationsHelper.GetFiles(directoryPath, "*.pdf"); //GetPdfFiles(directoryPath);

            if (pdfFiles != null && pdfFiles.Any())
            {
                _logger.Info("Number of Files to Parse : " + pdfFiles.Count());

                foreach (var filePath in pdfFiles)
                {
                    var fileName = Path.GetFileName(filePath);

                    long customerId = 0;
                    string errorMessage = string.Empty;

                    _logger.Info("=============== Parsing Started for file: " + fileName + " =================");

                    var pdfText = GetTextFromPdf(filePath);
                    if (string.IsNullOrWhiteSpace(pdfText))
                    {
                        continue;
                    }

                    var lstText = pdfText.Replace("\r", "").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var customerIdString = lstText.Where(x => x.Contains("Patient ID:")).FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(customerIdString) || !long.TryParse(customerIdString.Replace("Patient ID:", "").Trim(), out customerId))
                    {
                        errorMessage = "DPN: CustomerId could be blank or not an numeric value in Pdf file @" + filePath + " and text is: " + customerIdString;
                        _logger.Info(errorMessage);
                        continue;
                    }

                    var eventCustomer = _eventCustomerRepository.Get(_eventId, customerId);

                    if (eventCustomer == null)
                    {
                        errorMessage = "DPN: Customer: " + customerId + " is not registered on Event Id :" + _eventId
                            + " for file path: " + filePath;

                        _logger.Info(errorMessage);
                        continue;
                    }

                    var isTestPurchased = _eventCustomerRepository.IsTestPurchasedByEventIdCustomerId(_eventId, customerId, (long)TestType.DPN);

                    if (!isTestPurchased)
                    {
                        errorMessage = "DPN: Test not purchased for Customer Id :" + customerId + " Event Id :" + _eventId
                            + " and file path: " + filePath;

                        _logger.Info(errorMessage);

                        continue;
                    }

                    var resultState = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, _eventId);

                    if (resultState != null && _isNewResultFlow && resultState.ResultState >= (int)NewTestResultStateNumber.PostAuditNew)
                    {
                        errorMessage = "DPN (New Result Flow): Pdf can not parsed because current result state is "
                            + NewTestResultStateNumber.PostAuditNew.ToString() + " for Customer Id :" + customerId + " Event Id :"
                            + _eventId + " and file path: " + filePath;

                        _logger.Info(errorMessage);
                        continue;
                    }

                    if (resultState != null && !_isNewResultFlow && resultState.ResultState >= (int)TestResultStateNumber.PostAudit)
                    {
                        errorMessage = "DPN (Old Result Flow): Pdf can not parsed because current result state is "
                            + TestResultStateNumber.PostAudit.ToString() + " for Customer Id :" + customerId + " Event Id :"
                            + _eventId + " and file path: " + filePath;

                        _logger.Info(errorMessage);
                        continue;
                    }

                    try
                    {
                        string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var resultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, TestType.DPN);

                        if (resultMedia != null)
                        {
                            resultMedia.ReadingSource = ReadingSource.Automatic;

                            TestResult testResult = new DpnTestResult { ResultImage = resultMedia };

                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.DPN, customerId, MedicalEquipmentTag.Vatica);

                            _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "DPN: System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace;
                        _logger.Error(errorMessage);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.DPN, customerId, MedicalEquipmentTag.Vatica, false);
                    }

                    _logger.Info("=============== Parsing Ended for file: " + fileName + " =================");
                }
            }

            return eventCustomerAggregates;
        }

        public ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType)
        {
            var highQualityRectangles = new List<RectangleDimesion>
                                         {
                                           new RectangleDimesion(52, 3200, 3200, 1200)
                                         };

            return _mediaHelper.GetOnlyHighMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType.ToString(), true, highQualityRectangles, true);
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

        private string GetTextFromPdf(string filePath)
        {
            try
            {
                var sb = new StringBuilder();

                using (var doc = new Doc())
                {
                    doc.Read(filePath);

                    for (var currentPageNumber = 1; currentPageNumber <= doc.PageCount; currentPageNumber++)
                    {
                        doc.PageNumber = currentPageNumber;
                        sb.Append(doc.GetText("Text"));
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                _logger.Error("Reading file " + filePath + " failed.");
                _logger.Error("Message: " + ex.Message + "\n\t" + ex.StackTrace);
                return string.Empty;
            }
        }
    }
}
