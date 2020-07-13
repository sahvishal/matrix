using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class GeResultParser : IResultArchiveParser
    {
        private readonly long _eventId;
        private readonly string _geDirectoryPath;
        private readonly ILogger _logger;
        private readonly IExcelReader _excelReader;
        private readonly IMediaRepository _mediaRepository;
        private readonly IDicomExtractor _dicomExtractor;
        private readonly Service.TestResultService _testResultService;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        private IGeTestParser _aaaTestParser;
        private IGeTestParser _strokeTestParser;
        private IGeTestParser _echoTestParser;

        private const string ColumnForCustomerId = "PatientId";
        private const string ColumnForTestType = "StudyDescription";
        private const string DataIdentifierforAaa = "A";
        private const string DataIdentifierforStroke = "C";
        private const string DataIdentifierforEcho = "E";

        private const string NodeNameForDataElement = "DataElement";
        private const string NodeNameForDescription = "Description";
        private const string NodeNameForValue = "Value";
        private const string NodeValueForDescription = "Study Description";
        private const string NodeValueForPatientId = "Patient ID";

        private const string TestTypeValueForEcho = "e";
        private const string TestTypeValueForAaa = "a";
        private const string TestTypeValueForStroke = "c";


        private List<ResultArchiveLog> _resultArchiveLogs;
        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultArchiveLogs; }
        }

        public GeResultParser(long eventId, string geDirectoryPath, ILogger logger, IExcelReader excelReader)
        {
            _eventId = eventId;
            _logger = logger;
            _excelReader = excelReader;
            _geDirectoryPath = geDirectoryPath;
            _resultArchiveLogs = null;
            _mediaRepository = new MediaRepository(new Settings());
            _dicomExtractor = new DicomExtractor(logger);
            _testResultService = new Service.TestResultService();
            _eventCustomerRepository = new EventCustomerRepository();
        }

        public DataSet ParseCsvintoDatatable(string filePath)
        {
            var dtCardiovision = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new[] { '\t' }))
                {
                    dtCardiovision.Columns.Add(strColumn);
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dtCardiovision.NewRow();
                    int i = 0;
                    foreach (string strValue in row.Split(new[] { '\t' }))
                    {
                        if (i >= dtCardiovision.Columns.Count)
                            break;

                        dr[i] = strValue.Replace("\"", "");
                        i++;
                    }

                    for (int j = i; j < dtCardiovision.Columns.Count; j++)
                        dr[j] = "";

                    dtCardiovision.Rows.Add(dr);
                }
            }
            var ds = new DataSet();
            ds.Tables.Add(dtCardiovision);
            return ds;
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            _resultArchiveLogs = new List<ResultArchiveLog>();

            var folderPath = GetFolderPathfor(_geDirectoryPath);
            if (!string.IsNullOrEmpty(folderPath))
            {
                ExtractDicomFiles(folderPath);

                foreach (var filePath in Directory.GetFiles(folderPath))
                {
                    if (!Path.GetExtension(filePath).ToLower().Contains("xls"))
                        continue;

                    var fileName = Path.GetFileName(filePath);
                    DataSet dataset = null;
                    try
                    {
                        dataset = _excelReader.ReadfromExcelintoDataset(filePath);
                    }
                    catch
                    {
                        try
                        {
                            dataset = ParseCsvintoDatatable(filePath);
                        }
                        catch
                        {
                            _logger.Error("\nNot Able to parse File : " + filePath);    
                        }
                    }

                    if (dataset == null || dataset.Tables.Count < 1) continue;

                    var dataTable = dataset.Tables[0];
                    if (!CheckifDatatableContainsRequiredColumns(dataTable))
                    {
                        _logger.Info("\nColumns to Identify CustomerId and Test Type are missing in File: " + fileName);
                        continue;
                    }

                    if (dataTable.Rows.Count < 1)
                    {
                        _logger.Info("\nNo Rows found in the File : " + fileName);
                        continue;
                    }

                    long customerId;
                    TestType testType;

                    GetCustomerIdandTestTypeFromDataTable(dataTable, out customerId, out testType);
                    if (customerId < 1)
                    {
                        _logger.Info("\nNo Valid Customer Id found in File : " + fileName);
                        continue;
                    }
                    if ((int)testType < 1)
                    {
                        _logger.Info("\nNo Test Identifier found in File : " + fileName);
                        continue;
                    }
                    try
                    {
                        bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)testType);
                        if (!isTestPurchasedByCustomer)
                        {
                            _logger.Info(testType + " is not availed by CustomerId[" + customerId + "].\n");
                            continue;
                        }
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(testType + " is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                        continue;
                    }

                    GetTestResultsforgivenCustomer(customerId, folderPath, testType, dataTable, eventCustomerAggregates);
                }
                
                AddTestResultsfortheCustomerMissingReadingFile(folderPath, eventCustomerAggregates);
            }

            return eventCustomerAggregates;
        }

        private void AddTestResultsfortheCustomerMissingReadingFile(string folderPath, List<EventCustomerScreeningAggregate> eventCustomerAggregates)
        {
            // Ashutosh: the below mentioned code looks for those customers who do not have the excel file in the directory
            // but just the images. Hence their tests result objects will be created with no values(readings), but just the media.

            var eventCustomers = _eventCustomerRepository.GetbyEventId(_eventId);

            var eventCustomersForAaa = eventCustomers.Where(ec => ec.AppointmentId.HasValue &&
                !eventCustomerAggregates.Where(ecr => ecr.TestResults != null && ecr.TestResults.Where(tt => tt.TestType == TestType.AAA).Count() > 0).Select(ecr => ecr.CustomerId)
                    .Contains(ec.CustomerId)).ToArray();

            var eventCustomersForStroke = eventCustomers.Where(ec => ec.AppointmentId.HasValue &&
                !eventCustomerAggregates.Where(ecr => ecr.TestResults != null && ecr.TestResults.Where(tt => tt.TestType == TestType.Stroke).Count() > 0).Select(ecr => ecr.CustomerId)
                    .Contains(ec.CustomerId)).ToArray();

            var eventCustomersForEcho = eventCustomers.Where(ec => ec.AppointmentId.HasValue &&
                !eventCustomerAggregates.Where(ecr => ecr.TestResults != null && ecr.TestResults.Where(tt => tt.TestType == TestType.Echocardiogram).Count() > 0).Select(ecr => ecr.CustomerId)
                    .Contains(ec.CustomerId)).ToArray();

            if (eventCustomersForAaa.Any())
            {
                foreach (var eventCustomer in eventCustomersForAaa)
                {
                    bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, eventCustomer.CustomerId, (long)TestType.AAA);
                    if (isTestPurchasedByCustomer) GetTestResultsforgivenCustomer(eventCustomer.CustomerId, folderPath, TestType.AAA, null, eventCustomerAggregates);
                }
            }

            if (eventCustomersForStroke.Any())
            {
                foreach (var eventCustomer in eventCustomersForStroke)
                {
                    bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, eventCustomer.CustomerId, (long)TestType.Stroke);
                    if (isTestPurchasedByCustomer) GetTestResultsforgivenCustomer(eventCustomer.CustomerId, folderPath, TestType.Stroke, null, eventCustomerAggregates);
                }
            }

            if (eventCustomersForEcho.Any())
            {
                foreach (var eventCustomer in eventCustomersForEcho)
                {
                    bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, eventCustomer.CustomerId, (long)TestType.Echocardiogram);
                    if (isTestPurchasedByCustomer) GetTestResultsforgivenCustomer(eventCustomer.CustomerId, folderPath, TestType.Echocardiogram, null, eventCustomerAggregates);
                }
            }
        }

        private void GetTestResultsforgivenCustomer(long customerId, string folderPath, TestType testType, DataTable dataTable, List<EventCustomerScreeningAggregate> eventCustomerAggregates)
        {
            TestResult testResult = null;
            string errorSummary = string.Empty;
            var mediaFilePath = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId);
            try
            {

                _logger.Info("\n\n ===================> " + testType + " Parsing for CustomerId [" + customerId + "].\n");
                IEnumerable<string> folderForMedia;
                switch (testType)
                {
                    case TestType.AAA:
                        folderForMedia = GetFolderPathcontainingImages(folderPath, customerId, TestTypeValueForAaa);
                        _aaaTestParser = new GeAaaResultParser(folderForMedia, mediaFilePath.PhysicalPath, _logger);
                        testResult = _aaaTestParser.Parse(dataTable);
                        break;

                    case TestType.Stroke:
                        folderForMedia = GetFolderPathcontainingImages(folderPath, customerId, TestTypeValueForStroke);
                        _strokeTestParser = new GeStrokeResultParser(folderForMedia, mediaFilePath.PhysicalPath, _logger);
                        testResult = _strokeTestParser.Parse(dataTable);
                        break;

                    case TestType.Echocardiogram:
                        folderForMedia = GetFolderPathcontainingImages(folderPath, customerId, TestTypeValueForEcho);
                        _echoTestParser = new GeEchoResultParser(folderForMedia, mediaFilePath.PhysicalPath, _logger);
                        testResult = _echoTestParser.Parse(dataTable);
                        break;
                }

                if (testResult != null)
                {
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                    AddResultArchiveLog(errorSummary, testType, customerId);
                }
                else
                {
                    _logger.Info("Data Not Found.\n");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                AddResultArchiveLog(ex.Message, testType, customerId, false);
            }
        }

        private static bool CheckifDatatableContainsRequiredColumns(DataTable dtSourcefromExcel)
        {
            if (dtSourcefromExcel.Columns.Count > 0 && dtSourcefromExcel.Columns.Contains(ColumnForCustomerId) && dtSourcefromExcel.Columns.Contains(ColumnForTestType))
            {
                return true;
            }
            return false;
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            if (Directory.GetFiles(toFindinFolder).Any(filePath => Path.GetExtension(filePath).ToLower().Contains("xls")))
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

        private void GetCustomerIdandTestTypeFromDataTable(DataTable dtSourceFromExcel, out long customerId, out TestType testType)
        {
            customerId = 0;
            testType = 0;

            try
            {
                dtSourceFromExcel.DefaultView.RowFilter = ColumnForCustomerId + " is not null and LEN(" + ColumnForCustomerId + ") > 0";
                if (dtSourceFromExcel.DefaultView.Count < 1)
                    return;

                if (!long.TryParse(dtSourceFromExcel.DefaultView[0][ColumnForCustomerId].ToString(), out customerId))
                {
                    return;
                }

                dtSourceFromExcel.DefaultView.RowFilter = ColumnForTestType + " is not null and LEN(" + ColumnForTestType + ") > 0";
                if (dtSourceFromExcel.DefaultView.Count < 1)
                    return;

                string testStringinTable = dtSourceFromExcel.DefaultView[0][ColumnForTestType].ToString();

                if (testStringinTable.ToLower().Equals(DataIdentifierforAaa.ToLower()))
                {
                    testType = TestType.AAA;
                }
                else if (testStringinTable.ToLower().Equals(DataIdentifierforStroke.ToLower()))
                {
                    testType = TestType.Stroke;
                }
                else if (testStringinTable.ToLower().Equals(DataIdentifierforEcho.ToLower()))
                {
                    testType = TestType.Echocardiogram;
                }
            }
            catch (Exception ex)
            {
                _logger.Info("\n\tException occured while extracting Customer Id and Test Type from Excel file. Message: " + ex.Message + " \n\t\tStack Trace" + ex.StackTrace);
                return;
            }
        }

        private void AddTestResulttoEventCustomerAggregate(List<EventCustomerScreeningAggregate> eventCustomerAggregates, long customerId, TestResult testResult)
        {
            if (testResult != null)
            {
                var eventCustomerAggregate = eventCustomerAggregates.Where(
                    ec => ec.EventId == _eventId && ec.CustomerId == customerId).SingleOrDefault() ??
                                             new EventCustomerScreeningAggregate()
                                             {
                                                 CustomerId = customerId,
                                                 EventId = _eventId,
                                                 TestResults = new List<TestResult>()
                                             };

                List<TestResult> trs = eventCustomerAggregate.TestResults.ToList();
                trs.Add(testResult);
                eventCustomerAggregate.TestResults = trs;
                if (eventCustomerAggregate.TestResults.Count() == 1)
                    eventCustomerAggregates.Add(eventCustomerAggregate);
            }
        }

        private void AddResultArchiveLog(string summary, TestType testId, long customerId, bool isSuccessful = true)
        {
            var log = _resultArchiveLogs.Where(rl => rl.CustomerId == customerId && rl.TestId == testId).SingleOrDefault();
            if (isSuccessful && summary.Trim().Length > 0) isSuccessful = false;
            if (log == null)
            {
                log = new ResultArchiveLog()
                {
                    CustomerId = customerId,
                    IsSuccessful = isSuccessful,
                    Notes = summary,
                    TestId = testId,
                    CreatedDate = DateTime.Now,
                    MedicalEquipmentTag = MedicalEquipmentTag.GE.ToString()
                };
                _resultArchiveLogs.Add(log);
            }
            else
            {
                log.Notes = summary;
                log.IsSuccessful = isSuccessful;
                log.CreatedDate = DateTime.Now;
            }
        }

        private void ExtractDicomFiles(string folderPath)
        {
            try
            {
                var directories = _dicomExtractor.GetDirectoriesContainingDicomFiles(folderPath);
                if (directories == null || directories.Count() < 1) return;

                foreach (var direcotry in directories)
                {
                    _dicomExtractor.ProcessFiles(direcotry);
                }
            }
            catch (Exception ex)
            {
                _logger.Info("\n Dicom Extraction failed in path [" + folderPath + "]. Message: " + ex.Message + " \n\tStackTrace: " + ex.StackTrace);
            }
        }

        private static IEnumerable<string> GetFolderPathcontainingImages(string folderPath, long customerId, string testType)
        {
            var folderPathForImages = new List<String>();
            if ((from filePath in Directory.GetFiles(folderPath)
                 select Path.GetExtension(filePath).ToLower()
                     into extension
                     where extension.Contains("jpg") || extension.Contains("jpeg") || extension.Contains("bmp") || extension.Contains("png")
                     select CheckIfFolderContainsXmlwithCustomerId(folderPath, customerId, testType)).Any(result => result))
            {
                folderPathForImages.Add(folderPath);
                return folderPathForImages;
            }

            foreach (var path in Directory.GetDirectories(folderPath))
            {
                var mediaLocations = GetFolderPathcontainingImages(path, customerId, testType);
                if (mediaLocations.Count() > 0) folderPathForImages.AddRange(mediaLocations);
            }

            return folderPathForImages;
        }

        private static bool CheckIfFolderContainsXmlwithCustomerId(string folderPath, long customerId, string testType)
        {
            foreach (var filePath in Directory.GetFiles(folderPath))
            {
                var extension = Path.GetExtension(filePath).ToLower();
                if (extension.Contains("xml"))
                {
                    var xDoc = XDocument.Load(filePath);
                    var resultTestType = (from element in xDoc.Descendants(NodeNameForDataElement)
                                          where
                                              element.Descendants(NodeNameForDescription).FirstOrDefault().Value.Equals(NodeValueForDescription)
                                              && element.Descendants(NodeNameForValue).FirstOrDefault().Value.ToLower().Equals(testType)
                                          select element).FirstOrDefault();

                    if (resultTestType != null)
                    {

                        var resultCustomerId = (from element in xDoc.Descendants(NodeNameForDataElement)
                                                where
                                                    element.Descendants(NodeNameForDescription).FirstOrDefault().Value.ToLower().Trim().Equals(NodeValueForPatientId.ToLower())
                                                    && element.Descendants(NodeNameForValue).FirstOrDefault().Value.Trim().Equals(customerId.ToString())
                                                select element).FirstOrDefault();

                        //var val1 = (from element in xDoc.Descendants(NodeNameForDataElement)
                        //                        where element.Descendants(NodeNameForDescription).FirstOrDefault().Value.ToLower().Trim().Equals(NodeValueForPatientId.ToLower())
                        //                        select element).FirstOrDefault();

                        //var val2 = (from element in xDoc.Descendants(NodeNameForDataElement)
                        //                        where element.Descendants(NodeNameForValue).FirstOrDefault().Value.Trim().Equals(customerId.ToString())
                        //                        select element).FirstOrDefault();

                        if (resultCustomerId != null) return true;
                    }
                }
            }
            return false;
        }

    }
}