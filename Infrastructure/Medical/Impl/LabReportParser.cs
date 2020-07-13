using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class LabReportParser : IResultArchiveParser
    {
        private readonly string _labReportOutputPath;
        private readonly string _labReportArchivedPath;

        private readonly ILogManager _logManager;
        //private readonly ILogger _logger;
        private readonly ILogger _loggerForClient;

        private readonly IMediaRepository _mediaRepository;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;

        private ILogger _labParseEventLogger;
        private const long UploadedBy = 1;

        public LabReportParser(string labReportOutputPath, string labReportArchivedPath,
             ILogger loggerForClient, ISettings settings, IEventCustomerRepository eventCustomerRepository, ILogManager logManager)
        {
            _labReportOutputPath = labReportOutputPath;
            _labReportArchivedPath = labReportArchivedPath;
            _loggerForClient = loggerForClient;
            // _logger = logger;
            _mediaRepository = new MediaRepository(settings);
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(_loggerForClient);
            _eventCustomerRepository = eventCustomerRepository;
            _testResultService = new Service.TestResultService();

            _logManager = logManager;

            _pipeDelimitedReportHelper = new PipeDelimitedReportHelper();
            _standardFindingRepository = new StandardFindingRepository();
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            var pdfResults = DirectoryOperationsHelper.GetFiles(_labReportOutputPath, "*.pdf");
            var rawTxtFile = DirectoryOperationsHelper.GetFiles(_labReportOutputPath, "*.txt");
            DataTable dtRawDataTable = new DataTable();

            if (rawTxtFile != null && rawTxtFile.Count() > 0)
            {
                _loggerForClient.Info("Total " + rawTxtFile.Count() + " Text File found.");
                foreach (var file in rawTxtFile)
                {
                    string txtFilename = new FileInfo(file).Name;
                    try
                    {
                        dtRawDataTable = GetRecordsFromTextFile(file, txtFilename, dtRawDataTable);
                    }
                    catch (Exception ex)
                    {
                        _loggerForClient.Info("File name :" + txtFilename + " is blank. Exception :" + ex.Message);
                        MovedParsedFile(file);
                    }
                }

                if (dtRawDataTable != null)
                {
                    _loggerForClient.Info("Total " + dtRawDataTable.Rows.Count() + " records found from all text file ");
                }
            }
            else
            {
                _loggerForClient.Info("There is not any text file availble");
            }

            var standardFinding = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.IFOBT);

            if (pdfResults != null && pdfResults.Any())
            {
                _loggerForClient.Info("Number of Files to be Parse : " + pdfResults.Count());

                foreach (var filePath in pdfResults)
                {
                    string errorMessage = string.Empty;
                    long customerId = 0;
                    long eventId = 0;
                    TestType testTypeId;

                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    var extension = Path.GetExtension(filePath);

                    if (extension != ".pdf")
                    {
                        errorMessage = "file with pdf extension supported only";
                        _loggerForClient.Error(errorMessage);
                        MovedParsedFile(filePath);
                        continue;
                    }

                    _loggerForClient.Info("=============== Parsing Started for file: " + fileName + " =================");
                    _loggerForClient.Info("Parsing Started for File: " + fileName);

                    if (!ParseValidationCheck(fileName, filePath, out eventId, out customerId, out testTypeId))
                    {
                        continue;
                    }

                    try
                    {
                        string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
                        var resultMedia = GetMediaFromPdfFile(filePath, folderToSavePdf, testTypeId);
                        MovedParsedFile(filePath);

                        if (resultMedia != null && testTypeId == TestType.IFOBT)
                        {
                            var finding = new StandardFinding<int>();
                            finding = GetIFOBTFinding(dtRawDataTable, eventId, customerId, testTypeId, fileName, standardFinding);
                            resultMedia.ReadingSource = ReadingSource.Automatic;

                            TestResult testResult = new IFOBTTestResult { ResultImage = resultMedia, Finding = finding };
                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.IFOBT, customerId, MedicalEquipmentTag.LabReportParser);

                            _labParseEventLogger.Info(string.Concat("\nPDF Filename(" + fileName + "): Parsing successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " TestType :", TestType.IFOBT, "\n"));
                            _loggerForClient.Info(string.Concat("\nPDF Filename (" + fileName + "): parsing successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " ,TestType :", TestType.IFOBT, "\n"));
                        }
                        else if (resultMedia != null && testTypeId == TestType.UrineMicroalbumin)
                        {
                            ResultReading<string> microAlbuminValue = new ResultReading<string>();
                            microAlbuminValue = GetUrineMicroAlbuminValue(dtRawDataTable, eventId, customerId, testTypeId, fileName);
                            resultMedia.ReadingSource = ReadingSource.Automatic;

                            TestResult testResult = new UrineMicroalbuminTestResult { ResultImage = resultMedia, MicroalbuminValue = microAlbuminValue };
                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.UrineMicroalbumin, customerId, MedicalEquipmentTag.LabReportParser);

                            _labParseEventLogger.Info(string.Concat("\nFilename(" + fileName + "): Parsing successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " TestType :", TestType.UrineMicroalbumin, "\n"));
                            _loggerForClient.Info(string.Concat("\nFilename (" + fileName + "): Parsing successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " ,TestType :", TestType.UrineMicroalbumin, "\n"));
                        }
                        else
                        {
                            var message = string.Concat("\nFilename(" + fileName + "): Test(" + testTypeId + ") is an invalid test for parsing for Customer Id: ", customerId, " ,Event Id: ", eventId, " TestType :", testTypeId, "\n");
                            _labParseEventLogger.Info(message);
                            _loggerForClient.Info(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = " System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace;
                        _labParseEventLogger.Error(errorMessage);
                        _loggerForClient.Error("Parsing failed for filename :" + fileName + ".Please contact to Administrator.");

                        MovedParsedFile(filePath);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, testTypeId, customerId, MedicalEquipmentTag.LabReportParser, false);
                    }
                }
            }
            if (dtRawDataTable != null && dtRawDataTable.Columns.Count() > 0 && dtRawDataTable.Rows.Count > 0)
            {
                var rows = dtRawDataTable.Select("IsParse=false");
                if (rows != null && rows.Any())
                {
                    dtRawDataTable = rows.CopyToDataTable();

                    if (dtRawDataTable.Rows.Count > 0)
                    {
                        eventCustomerAggregates = SaveResultWithoutMedia(eventCustomerAggregates, dtRawDataTable, standardFinding);
                    }
                }
            }
            return eventCustomerAggregates;
        }

        private List<EventCustomerScreeningAggregate> SaveResultWithoutMedia(List<EventCustomerScreeningAggregate> eventCustomerAggregates, DataTable dtRawDataTable, List<StandardFinding<decimal?>> standardFinding)
        {
            try
            {
                foreach (DataRow dr in dtRawDataTable.Rows)
                {
                    long intFinding = 0;
                    long customerId = 0;
                    long eventId = 0;
                    string summaryFinding = string.Empty;
                    string txtFileName = string.Empty;
                    TestType testTypeId;
                    StandardFinding<int> finding = new StandardFinding<int>();
                    if (!ValidateDataTable(dr, out txtFileName, out eventId, out customerId, out testTypeId, out summaryFinding))
                    {
                        continue;
                    }
                    if (testTypeId == TestType.UrineMicroalbumin)
                    {
                        ResultReading<string> microAlbuminValue = new ResultReading<string>()
                        {
                            Label = ReadingLabels.MicroalbuminValue,
                            Reading = summaryFinding,
                            RecorderMetaData = new DataRecorderMetaData(UploadedBy, DateTime.Now, null),
                            ReadingSource = ReadingSource.Automatic
                        };

                        TestResult testResult = new UrineMicroalbuminTestResult { MicroalbuminValue = microAlbuminValue };
                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.UrineMicroalbumin, customerId, MedicalEquipmentTag.LabReportParser);

                    }
                    else if (testTypeId == TestType.IFOBT)
                    {
                        summaryFinding = summaryFinding.ToLower();
                        var query = standardFinding.Where(x => x.Label.ToLower() == summaryFinding).Select(x => x.Id);
                        if (query != null && query.Count() > 0)
                        {
                            intFinding = query.First();
                        }
                        if (intFinding == 0)
                        {
                            _labParseEventLogger.Info("file(" + txtFileName + "): Test result format is not correct for Customer Id :" + customerId + ",EventId :" + eventId + " and Test: " + testTypeId);
                            _loggerForClient.Info("file(" + txtFileName + "): Test result format is not correct for Customer Id :" + customerId + ",EventId :" + eventId + " and Test: " + testTypeId);
                            continue;
                        }
                        finding = new StandardFinding<int>(Convert.ToInt32(intFinding));

                        TestResult testResult = new IFOBTTestResult { Finding = finding };
                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, eventId, customerId, testResult);
                        _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.IFOBT, customerId, MedicalEquipmentTag.LabReportParser);
                    }
                    else
                    {
                        var message = "file(" + txtFileName + "): Test(" + testTypeId + ") is an invalid test for parsing for Customer Id :" + customerId + ",EventId :" + eventId;
                        _labParseEventLogger.Info(message);
                        _loggerForClient.Info(message);
                        continue;
                    }

                    _labParseEventLogger.Info(string.Concat("file(" + txtFileName + "): Result saved successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " and Test :", testTypeId, "\n"));
                    _loggerForClient.Info(string.Concat("file(" + txtFileName + "): Result saved successfully for Customer Id: ", customerId, " ,Event Id: ", eventId, " and Test :", testTypeId, "\n"));
                }
            }
            catch (Exception ex)
            {
                _labParseEventLogger.Info("\nText File: Issue on data saving. Exception: " + ex.Message + "  \n");
                _loggerForClient.Info("\nText File: Issue on data saving.Please contact to Administrator \n");
            }
            return eventCustomerAggregates;
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType)
        {
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType.ToString());
        }

        private void MovedParsedFile(string sourceFileName)
        {
            try
            {
                string destinationFile = Path.Combine(_labReportArchivedPath, DateTime.Today.ToString("ddMMyyyy"));

                string fileName = new FileInfo(sourceFileName).Name;
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFile);
                destinationFile = Path.Combine(destinationFile, Guid.NewGuid() + "_" + fileName);
                DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);
                DirectoryOperationsHelper.Move(sourceFileName, destinationFile);
            }
            catch (Exception ex)
            {
                _labParseEventLogger.Error(" Issue on File Move(" + sourceFileName + ") !  Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }

        }

        private bool ParseValidationCheck(string fileName, string filePath, out long eventId, out long customerId, out TestType testTypeId)
        {
            EventCustomer eventCustomer = null;
            string errorMessage = string.Empty;
            string testName = string.Empty;
            eventId = 0;
            customerId = 0;
            testTypeId = 0;
            try
            {

                var temp = fileName.Split('_');
                if (temp.Length < 3)
                {
                    _loggerForClient.Info("Incorrect format Name formate for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;
                }

                var customerIdString = temp[0];
                var eventIdString = temp[1];
                testName = Convert.ToString(temp[2]);


                if (!long.TryParse(eventIdString, out eventId))
                {

                    _loggerForClient.Info("Incorrect format of Event Id : " + eventIdString + " for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;
                }

                if (eventId <= 0)
                {
                    _loggerForClient.Info("Incorrect Event Id : " + customerIdString + " for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;
                }

                string labParseLogger = "LabParseLogger_" + eventIdString;
                _labParseEventLogger = _logManager.GetLogger(labParseLogger);


                if (!Enum.TryParse(testName, true, out testTypeId))
                {
                    errorMessage = "Test Name incorrect :" + testName + " for pdf filename (" + fileName + ").";
                    _labParseEventLogger.Error(errorMessage);
                    _loggerForClient.Info("Test Name incorrect :" + testName + " for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;

                }

                if (!long.TryParse(customerIdString, out customerId))
                {
                    _labParseEventLogger.Info("Incorrect format of Customer Id : " + customerIdString + " for pdf filename (" + fileName + ").");
                    _loggerForClient.Info("Incorrect format of Customer Id : " + customerIdString + " for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;
                }

                if (customerId <= 0)
                {
                    _labParseEventLogger.Info("Incorrect Customer Id : " + customerIdString + " for pdf filename (" + fileName + ").");
                    _loggerForClient.Info("Incorrect Customer Id : " + customerIdString + " for pdf filename (" + fileName + ").");
                    MovedParsedFile(filePath);
                    return false;
                }

                eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
                if (eventCustomer == null)
                {
                    var message = "customer : " + customerId + " has not been " + eventId + " booked appointment for pdf filename (" + fileName + ").";
                    _labParseEventLogger.Info(message);
                    _loggerForClient.Info(message);
                    MovedParsedFile(filePath);
                    return false;
                }

                if (eventCustomer.AppointmentId.HasValue == false)
                {
                    errorMessage = "customer appointment has been canceled Customer Id: " + customerId + ", EventId : " + eventId + " for pdf filename (" + fileName + ").";
                    _labParseEventLogger.Info(errorMessage);
                    _loggerForClient.Info(errorMessage);

                    MovedParsedFile(filePath);
                    return false;
                }

                if (eventCustomer.NoShow == true)
                {
                    errorMessage = "customer has been marked as No Show Customer Id: " + customerId + ", EventId : " + eventId + " for pdf filename (" + fileName + ").";
                    _labParseEventLogger.Info(errorMessage);
                    _loggerForClient.Info(errorMessage);

                    MovedParsedFile(filePath);
                    return false;
                }

                if (eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                {
                    errorMessage = "customer has been marked as Left without screening  Id: " + customerId + ", EventId : " + eventId + " for pdf filename (" + fileName + ").";
                    _labParseEventLogger.Info(errorMessage);
                    _loggerForClient.Info(errorMessage);

                    MovedParsedFile(filePath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "PDF File name (" + fileName + ") is incorrect format. Exception is :" + ex.Message;
                _labParseEventLogger.Error(errorMessage);

                _loggerForClient.Info("PDF File name: " + fileName + " is incorrect format.");

                MovedParsedFile(filePath);
                return false;
            }

            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)testTypeId);
            if (!isTestPurchased)
            {
                errorMessage = string.Format("Customer Id :" + customerId + " Test: " + testName + " not purchased for event Id :" + eventId + " and pdf filename (" + fileName + ")");
                _labParseEventLogger.Info(errorMessage);

                _loggerForClient.Info("Customer Id :" + customerId + " is not purchased test (" + testName + ") for event Id: " + eventId + " and pdf filename (" + fileName + ")");

                MovedParsedFile(filePath);
                return false;
            }
            return true;
        }

        private bool IsColumnNameValid(DataTable tempTable, string file, string txtFilename)
        {
            DataColumnCollection columns = tempTable.Columns;
            if (!columns.Contains("PatientID"))
            {
                _loggerForClient.Info("File(" + txtFilename + "): Column PatientID Missing.");
                MovedParsedFile(file);
                return false;
            }
            else if (!columns.Contains("EventID"))
            {
                _loggerForClient.Info("File(" + txtFilename + "): Column EventID Missing.");
                MovedParsedFile(file);
                return false;
            }
            else if ((!columns.Contains("Test_Alias")))
            {
                _loggerForClient.Info("File(" + txtFilename + "): Column Test_Alias Missing.");
                MovedParsedFile(file);
                return false;
            }
            else if ((!columns.Contains("Result")))
            {
                _loggerForClient.Info("File(" + txtFilename + "): Column Result Missing.");
                MovedParsedFile(file);
                return false;
            }
            return true;
        }
        private DataTable GetRecordsFromTextFile(string file, string txtFilename, DataTable dtRawDataTable)
        {
            DataTable tempTable = new DataTable();
            tempTable = _pipeDelimitedReportHelper.Read(file, ",");
            if (IsColumnNameValid(tempTable, file, txtFilename))
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "FileName";
                dc.DefaultValue = txtFilename;
                tempTable.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "IsParse";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                tempTable.Columns.Add(dc);
                if (tempTable.Rows.Count() > 0)
                {
                    dtRawDataTable.Merge(tempTable);
                    MovedParsedFile(file);
                    _loggerForClient.Info("Total " + tempTable.Rows.Count() + " records found from text file " + txtFilename);
                }
                else
                {
                    MovedParsedFile(file);
                    _loggerForClient.Info("There is no records found from text file " + txtFilename);
                }
            }
            return dtRawDataTable;
        }

        private bool ValidateDataTable(DataRow dr, out string txtFileName, out long eventId, out long customerId, out TestType testTypeId, out string summaryFinding)
        {
            txtFileName = Convert.ToString(dr["FileName"]);
            EventCustomer eventCustomer = null;
            StandardFinding<int> finding = new StandardFinding<int>();
            string strEventId = Convert.ToString(dr["EventID"]);
            summaryFinding = Convert.ToString(dr["Result"]);
            eventId = 0;
            customerId = 0;
            testTypeId = 0;

            if (!long.TryParse(strEventId, out eventId))
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Incorrect Event Id : " + strEventId);
                _loggerForClient.Info("file(" + txtFileName + "): Incorrect Event Id : " + strEventId);
                return false;

            }
            if (eventId <= 0)
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Incorrect Event Id : " + strEventId);
                _loggerForClient.Info("file(" + txtFileName + "): Incorrect Event Id : " + strEventId);
                return false;
            }

            string labParseLogger = "LabParseLogger_" + strEventId;
            _labParseEventLogger = _logManager.GetLogger(labParseLogger);

            string strCustomerId = Convert.ToString(dr["PatientID"]);
            if (!long.TryParse(strCustomerId, out customerId))
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Incorrect customer Id : " + strCustomerId + " for event Id " + eventId);
                _loggerForClient.Info("file(" + txtFileName + "): Incorrect customer Id : " + strCustomerId + " for event Id " + eventId);
                return false;
            }

            if (customerId <= 0)
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Incorrect customer Id : " + strCustomerId + " for event Id " + eventId);
                _loggerForClient.Info("file(" + txtFileName + "): Incorrect customer Id : " + strCustomerId + " for event Id " + eventId);
                return false;
            }

            string strTestType = Convert.ToString(dr["Test_Alias"]);
            if (!Enum.TryParse(strTestType, true, out testTypeId))
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Test Name incorrect : " + strTestType + " for event Id " + eventId + " and customer Id " + customerId);
                _loggerForClient.Info("file(" + txtFileName + "): Test Name incorrect : " + strTestType);
                return false;
            }

            eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null)
            {
                var message = "file(" + txtFileName + "): customer : " + customerId + " has not been " + eventId + " booked appointment.";
                _labParseEventLogger.Info(message);
                _loggerForClient.Info(message);
                return false;
            }

            if (eventCustomer.AppointmentId.HasValue == false)
            {
                var message = "file(" + txtFileName + "): customer appointment has been canceled for Customer Id: " + customerId + ", EventId : " + eventId + ".";
                _labParseEventLogger.Info(message);
                _loggerForClient.Info(message);
                return false;
            }

            if (eventCustomer.NoShow == true)
            {
                var message = "file(" + txtFileName + "): customer has been marked as No Show for Customer Id: " + customerId + ", EventId : " + eventId + ".";
                _labParseEventLogger.Info(message);
                _loggerForClient.Info(message);
                return false;
            }

            if (eventCustomer.LeftWithoutScreeningReasonId.HasValue)
            {
                var message = "file(" + txtFileName + "): customer has been marked as Left without screening for customer Id: " + customerId + ", EventId : " + eventId + ".";
                _labParseEventLogger.Info(message);
                _loggerForClient.Info(message);
                return false;
            }

            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)testTypeId);
            if (!isTestPurchased)
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): " + testTypeId + " test not purchased by customer Id " + customerId + " for event Id " + eventId);
                _loggerForClient.Info("file(" + txtFileName + "): " + testTypeId + " test not purchased by customer Id " + customerId + " for event Id " + eventId);
                return false;
            }

            if (summaryFinding.IsNullOrEmpty())
            {
                _labParseEventLogger.Info("file(" + txtFileName + "): Test result not found for Test: " + testTypeId + " Customer Id :" + customerId + " ,and event Id: " + eventId);
                _loggerForClient.Info("file(" + txtFileName + "): Test result not found for Test: " + testTypeId + " Customer Id :" + customerId + " ,and event Id: " + eventId);
                return false;
            }
            return true;
        }

        private StandardFinding<int> GetIFOBTFinding(DataTable dtRawDataTable, long eventId, long customerId, TestType testTypeId, string fileName, List<StandardFinding<decimal?>> standardFinding)
        {
            var finding = new StandardFinding<int>();
            decimal intFinding = 0;
            if (dtRawDataTable != null && dtRawDataTable.Rows.Count() > 0)
            {
                var dt = dtRawDataTable.Select("PatientID='" + customerId + "' AND EventID='" + eventId + "' AND Test_Alias='" + testTypeId + "' AND IsParse=false");

                if (!dt.Any())
                {
                    _labParseEventLogger.Info("Record not found from Text file for CustomerId: " + customerId + ", EventId: " + eventId + ", Test Type: " + testTypeId + " and pdf file name is " + fileName);
                    _loggerForClient.Info("Record not found from Text file for CustomerId: " + customerId + ", EventId: " + eventId + ", Test Type: " + testTypeId + " and pdf file name is " + fileName);
                }
                else
                {
                    string summaryFinding = dt.Any() ? Convert.ToString(dt[dt.Length - 1]["Result"]) : string.Empty;
                    if (summaryFinding.IsNullOrEmpty())
                    {
                        _labParseEventLogger.Info("PDF file(" + fileName + "): Test result not found for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                        _loggerForClient.Info("PDF file(" + fileName + "): Test result not found for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                    }
                    summaryFinding = summaryFinding.ToLower();
                    var query = standardFinding.Where(x => x.Label.ToLower() == summaryFinding).Select(x => x.Id);

                    if (query != null && query.Any())
                    {
                        intFinding = query.First();
                    }
                    if (intFinding == 0)
                    {
                        _labParseEventLogger.Info("PDF file(" + fileName + "): Test result format is not correct for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                        _loggerForClient.Info("PDF file(" + fileName + "): Test result format is not correct for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                    }
                    finding = new StandardFinding<int>(Convert.ToInt32(intFinding));
                    foreach (var dr in dt)
                    {
                        dr["IsParse"] = true;
                    }
                }
            }
            return finding;

        }

        private ResultReading<string> GetUrineMicroAlbuminValue(DataTable dtRawDataTable, long eventId, long customerId, TestType testTypeId, string fileName)
        {
            ResultReading<string> microAlbuminValue = new ResultReading<string>();
            if (dtRawDataTable != null && dtRawDataTable.Rows.Count() > 0)
            {
                var dt = dtRawDataTable.Select("PatientID='" + customerId + "' AND EventID='" + eventId + "' AND Test_Alias='" + testTypeId + "' AND IsParse=false");
                if (!dt.Any())
                {
                    _labParseEventLogger.Info("Record not found from Text file for CustomerId: " + customerId + ", EventId: " + eventId + ", Test Type: " + testTypeId + " and pdf file name is " + fileName);
                    _loggerForClient.Info("Record not found from Text file for CustomerId: " + customerId + ", EventId: " + eventId + ", Test Type: " + testTypeId + " and pdf file name is " + fileName);
                }
                else
                {
                    string summaryFinding = dt.Any() ? Convert.ToString(dt[dt.Length - 1]["Result"]) : string.Empty;
                    if (summaryFinding.IsNullOrEmpty())
                    {
                        _labParseEventLogger.Info("PDF file(" + fileName + "): Test result not found for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                        _loggerForClient.Info("PDF file(" + fileName + "): Test result not found for Customer Id :" + customerId + " Test: " + testTypeId + "and text file name is " + Convert.ToString(dt[0]["FileName"]));
                    }

                    microAlbuminValue = new ResultReading<string>()
                    {
                        Label = ReadingLabels.MicroalbuminValue,
                        Reading = summaryFinding,
                        RecorderMetaData = new DataRecorderMetaData(UploadedBy, DateTime.Now, null),
                        ReadingSource = ReadingSource.Automatic

                    };
                    foreach (var dr in dt)
                    {
                        dr["IsParse"] = true;
                    }
                }
            }
            return microAlbuminValue;

        }
    }
}
