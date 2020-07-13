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
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class DiabeticRetinopathyParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ISettings _settings;
        private readonly IDiabeticRetinopathyParserlogRepository _diabeticRetinopathyParserlogRepository;

        public DiabeticRetinopathyParser(string resultOutputPath, ILogger logger, IEventCustomerRepository eventCustomerRepository, ISettings settings, IDiabeticRetinopathyParserlogRepository diabeticRetinopathyParserlogRepository)
        {
            _resultOutputPath = resultOutputPath;
            _logger = logger;
            _settings = settings;
            _mediaRepository = new MediaRepository(settings);
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_logger);
            _eventCustomerRepository = eventCustomerRepository;
            _diabeticRetinopathyParserlogRepository = diabeticRetinopathyParserlogRepository;
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();

            var directoryPath = GetFolderPathfor(_resultOutputPath);

            if (string.IsNullOrEmpty(directoryPath) && string.IsNullOrEmpty(directoryPath))
                return null;


            List<string> pdfFiles = null;

            if (!string.IsNullOrEmpty(directoryPath))
            {
                pdfFiles = GetPdfFiles(directoryPath);
            }

            if (pdfFiles != null && pdfFiles.Any())
            {
                _logger.Info("Number of Files to Parse : " + pdfFiles.Count());

                foreach (var filePath in pdfFiles)
                {
                    var fileNameWithExtention =Path.GetFileName(filePath);
                    if (!string.IsNullOrEmpty(fileNameWithExtention))
                        fileNameWithExtention = fileNameWithExtention.ToLower();

                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    if (!string.IsNullOrEmpty(fileName))
                        fileName = fileName.ToLower();

                    long customerId = 0;
                    long eventId = 0;
                    string errorMessage = string.Empty;
                   
                    _logger.Info("=============== Parsing Started for file: " + fileName + " =================");

                    try
                    {
                        var temp = fileName.Substring(fileName.IndexOf("_mrn_") + 5);
                        var customerIdString = temp.Substring(0, temp.IndexOf("_"));

                        if (!long.TryParse(customerIdString, out customerId))
                        {
                            errorMessage = "Diabetic Retinopathy: CustomerId not found on Pdf file" + filePath;
                            _logger.Info(errorMessage);
                            SaveDiabeticRetinopathyParserlog(fileNameWithExtention, customerId, eventId, errorMessage);
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        errorMessage = "File name is not in correct formate. ";
                        _logger.Error(errorMessage);
                        SaveDiabeticRetinopathyParserlog(fileNameWithExtention, customerId, eventId, errorMessage);
                        continue;
                    }

                   
                    try
                    {
                        eventId = _eventCustomerRepository.GetEventIdAttendedByCustomerForTest(customerId, (long)TestType.DiabeticRetinopathy, _settings.DiabeticRetinopathyNoOfDaysToCheckForEvent);
                        if (eventId <= 0)
                        {
                            errorMessage = string.Format("Diabetic Retinopathy: No Event attended by customer {0} in last {1} days.", customerId, _settings.DiabeticRetinopathyNoOfDaysToCheckForEvent);
                            _logger.Info(errorMessage);
                            SaveDiabeticRetinopathyParserlog(fileNameWithExtention, customerId, eventId, errorMessage);
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "Diabetic Retinopathy:  CustomerId [" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace;
                        _logger.Info(errorMessage);
                        SaveDiabeticRetinopathyParserlog(fileNameWithExtention, customerId, eventId, errorMessage);

                        continue;
                    }

                    try
                    {                        

                        string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
                        var resultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, TestType.DiabeticRetinopathy);

                        if (resultMedia != null)
                        {
                            TestResult testResult = new DiabeticRetinopathyTestResult { ResultImage = resultMedia };

                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.DiabeticRetinopathy, customerId, MedicalEquipmentTag.Vatica);

                            _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "Diabetic Retinopathy: System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace;
                        _logger.Error(errorMessage);
                        SaveDiabeticRetinopathyParserlog(fileNameWithExtention, customerId, eventId, errorMessage);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.DiabeticRetinopathy, customerId, MedicalEquipmentTag.Vatica, false);
                    }

                   
                    _logger.Info("=============== Parsing Ended for file: " + fileName + " =================");
                }
            }

            return eventCustomerAggregates;
        }
        private void SaveDiabeticRetinopathyParserlog(string fileNameWithExtention, long customerId, long eventId, string errorMessage)
        {
            var diabeticRetinopathyParserlog = new DiabeticRetinopathyParserlog();
            diabeticRetinopathyParserlog.FileName = fileNameWithExtention;
            diabeticRetinopathyParserlog.DateCreated = DateTime.Now;
            diabeticRetinopathyParserlog.CustomerId = customerId;
            diabeticRetinopathyParserlog.EventId = eventId;
            diabeticRetinopathyParserlog.ErrorMessage = errorMessage;
            _diabeticRetinopathyParserlogRepository.Save(diabeticRetinopathyParserlog);
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType)
        {
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType.ToString());
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
