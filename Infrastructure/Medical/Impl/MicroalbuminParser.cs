using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Service;
namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class MicroalbuminParser : IResultArchiveParser
    {
        private readonly string _microalbuminResultOutputPath;
        private readonly string _microalbuminResultArchivedPath;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;


        private readonly ICustomerRepository _customerRepository;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly Service.TestResultService _testResultService;

        public MicroalbuminParser(string microalbuminResultOutputPath, string microalbuminResultArchivedPath,
            ILogger logger, ISettings settings, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _microalbuminResultOutputPath = microalbuminResultOutputPath;
            _microalbuminResultArchivedPath = microalbuminResultArchivedPath;
            _logger = logger;

            _mediaRepository = new MediaRepository(settings);
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_logger);
            _customerRepository = customerRepository;

            _eventCustomerRepository = eventCustomerRepository;
            _testResultService = new Service.TestResultService();
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();

            var directoryPath = GetFolderPathfor(_microalbuminResultOutputPath);

            if (string.IsNullOrEmpty(directoryPath) && string.IsNullOrEmpty(directoryPath))
                return null;

            List<string> pdfFiles = null;

            if (!string.IsNullOrEmpty(directoryPath))
            {
                pdfFiles = GetPdfFiles(directoryPath);
            }

            var eventList = DirectoryOperationsHelper.GetDirectories(directoryPath);

            if (eventList != null && eventList.Any())
            {
                _logger.Info("Number of Events : " + eventList.Count());

                foreach (var events in eventList)
                {
                    long customerId = 0;
                    long eventId = 0;
                    string errorMessage = string.Empty;

                    if (!long.TryParse(events, out eventId))
                    {
                        _logger.Info("Event Id not found  : " + events);
                        continue;
                    }

                    List<string> pdfResults = null;
                    var eventFolder = Path.Combine(directoryPath, events);
                    if (!string.IsNullOrEmpty(eventFolder))
                    {
                        pdfResults = GetPdfFiles(eventFolder);

                        if (pdfResults != null && pdfResults.Any())
                        {
                            _logger.Info("Number of Files to Parse : " + pdfFiles.Count() + " Event Id is :" + events);

                            foreach (var filePath in pdfResults)
                            {
                                var fileNameWithExtention = Path.GetFileName(filePath);
                                if (!string.IsNullOrEmpty(fileNameWithExtention))
                                    fileNameWithExtention = fileNameWithExtention.ToLower();

                                var fileName = Path.GetFileNameWithoutExtension(filePath);
                                if (!string.IsNullOrEmpty(fileName))
                                    fileName = fileName.ToLower();

                                _logger.Info("=============== Parsing Started for file: " + fileName + " =================");

                                TestType testTypeId;
                                string testName = "";
                                try
                                {
                                    var temp = fileName.Split('_');
                                    var memberIdString = temp[0];
                                    testName = Convert.ToString(temp[1]);

                                    testTypeId = ((TestType)Enum.Parse(typeof(TestType), testName));

                                    IEnumerable<long> customerIds = _customerRepository.GetCustomerIdByInsuranceId(memberIdString);

                                    if (!customerIds.IsNullOrEmpty())
                                    {
                                        errorMessage = "Invalid member Id:  " + memberIdString + " File Path" + filePath;
                                        _logger.Info(errorMessage);
                                        continue;
                                    }

                                    var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

                                    eventCustomers = eventCustomers.Where(x => customerIds.Contains(x.CustomerId) && x.AppointmentId.HasValue);

                                    if (eventCustomers.IsNullOrEmpty())
                                    {
                                        errorMessage = "customer has not been booked for event with member Id: " + memberIdString + " EventId : " + eventId;
                                        _logger.Info(errorMessage);
                                        continue;
                                    }
                                    if (eventCustomers.Count() > 1)
                                    {
                                        errorMessage = "more than one customer has been booked for event with member Id: " + memberIdString + " EventId : " + eventId;
                                        _logger.Info(errorMessage);
                                        continue;
                                    }
                                    customerId = eventCustomers.First().CustomerId;

                                }
                                catch (Exception)
                                {
                                    errorMessage = "File name is not in correct format. ";
                                    _logger.Error(errorMessage);
                                    continue;
                                }

                                var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)testTypeId);
                                if (!isTestPurchased)
                                {
                                    errorMessage = string.Format("Customer Id :" + customerId + " Test: " + testName + " not purchased ");
                                    _logger.Info(errorMessage);
                                    continue;
                                }

                                try
                                {

                                    string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
                                    var resultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, testTypeId);

                                    MovedParsedFile(filePath, eventId);

                                    //if (resultMedia != null)
                                    //{
                                    //    TestResult testResult = new DiabeticRetinopathyTestResult { ResultImage = resultMedia };

                                    //    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                                    //    _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.DiabeticRetinopathy, customerId, MedicalEquipmentTag.Vatica);

                                    //    _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    errorMessage = " System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace;
                                    _logger.Error(errorMessage);

                                    // _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.DiabeticRetinopathy, customerId, MedicalEquipmentTag.Vatica, false);
                                }
                            }
                        }

                    }

                }
            }
            return eventCustomerAggregates;
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

        private void MovedParsedFile(string sourceFileName, long eventId)
        {
            string destinationFile = Path.Combine(_microalbuminResultArchivedPath, Convert.ToString(eventId));
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFile);
            DirectoryOperationsHelper.Move(sourceFileName, destinationFile);
        }


    }
}
