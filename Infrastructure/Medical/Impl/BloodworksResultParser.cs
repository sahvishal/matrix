using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodworksResultParser : IResultArchiveParser
    {
        private ILogger _logger;
        private const string ColumnforCustomerId = "PID";

        private const string ColumnforTshPerformed = "TSHPERFORMED";
        private const string ColumnforPsaPerformed = "PSAPERFORMED";
        private const string ColumnforCrpPerformed = "CRPPERFORMED";
        private const string ColumnforColorectalPerformed = "COLORECTALPERFORMED";
        private const string ColumnforKynPerformed = "KYN";

        private const string ColumnforEchoNotPerformed = "ECHONOTPERFORMED";
        private const string ColumnforStrokeNotPerformed = "CAROTIDNOTPERFORMED";
        private const string ColumnforAaaNotPerformed = "AAANOTPERFORMED";
        private const string ColumnforPadNotPerformed = "ABINOTPERFORMED";
        private const string ColumnforAsiNotPerformed = "ASINOTPERFORMED";
        private const string ColumnforEkgNotPerformed = "EKGNOTPERFORMED";

        private const string ColumnforEchoNotes = "ECHONOTES";
        private const string ColumnforStrokeNotes = "CAROTIDNOTES";
        private const string ColumnforAaaNotes = "AAANOTES";
        private const string ColumnforPadNotes = "ABINOTES";
        private const string ColumnforAsiNotes = "ASINOTES";
        private const string ColumnforEkgNotes = "EKGNOTES";

        private ICsvTestParser _lipidParser;
        private ICsvTestParser _hba1CParser;
        private Service.TestResultService _testResultService;
        private IBloodPressureSynchronizer _bloodPressureSynchronizer;
        private readonly long _updatedBy;

        private ITestResultRepository _ekgTestResultRepository;
        private ITestResultRepository _echoTestResultRepository;
        private ITestResultRepository _strokeTestResultRepository;
        private ITestResultRepository _aaaTestResultRepository;
        private ITestResultRepository _padTestResultRepository;
        private ITestResultRepository _asiTestResultRepository;
        private IUnableToScreenStatusRepository _unableToScreenRepository;

        private readonly string _resultOutputPath;
        private readonly long _eventId;

        private List<ResultArchiveLog> _resultArchiveLogs;
        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultArchiveLogs; }
        }

        private readonly bool _isNewResultFlow;

        public BloodworksResultParser(string resultOutputPath, long eventId, ILogger logger, long updateBy, bool isNewResultFlow)
        {
            _resultOutputPath = resultOutputPath;
            _logger = logger;
            _eventId = eventId;
            _lipidParser = new BloodworksLipidParser(logger);
            _hba1CParser = new BloodworksHemaglobinParser(logger);
            _testResultService = new Service.TestResultService();
            _updatedBy = updateBy;

            _ekgTestResultRepository = new EKGTestRepository();
            _echoTestResultRepository = new EchocardiogramTestRepository();
            _strokeTestResultRepository = new StrokeTestRepository();
            _padTestResultRepository = new PadTestRepository();
            _aaaTestResultRepository = new AAATestRepository();
            _asiTestResultRepository = new ASITestRepository();
            _unableToScreenRepository = new UnableToScreenStatusRepository();

            _isNewResultFlow = isNewResultFlow;
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            _resultArchiveLogs = new List<ResultArchiveLog>();

            var filePath = GetFolderPathfor(_resultOutputPath);
            if (string.IsNullOrEmpty(filePath)) return null;

            var dtBloodworks = ParseCsvintoDatatable(filePath);
            var isColumnsForLipidValid = BloodworksLipidParser.IsDatatableConversionfromCsvValid(dtBloodworks);

            if (!dtBloodworks.Columns.Contains(ColumnforCustomerId) || !isColumnsForLipidValid)
            {
                _logger.Error("Bloodworks File provided is an Invalid File!");
                return null;
            }

            foreach (DataRow dr in dtBloodworks.Rows)
            {
                long customerId = 0;
                if (dr[ColumnforCustomerId] != null && dr[ColumnforCustomerId] != DBNull.Value && !string.IsNullOrEmpty(dr[ColumnforCustomerId].ToString()))
                {
                    long.TryParse(dr[ColumnforCustomerId].ToString(), out customerId);
                }
                if (customerId < 1)
                {
                    _logger.Error("Customer Id not found in the row number " + (dtBloodworks.Rows.IndexOf(dr) + 1));
                    continue;
                }

                _logger.Info("\n\n ===================> Lipid Parsing for CustomerId : " + customerId + "\n");
                try
                {
                    bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Lipid);
                    if (!isTestPurchasedByCustomer)
                    {
                        _logger.Info("Lipid is not availed by CustomerId[" + customerId + "].\n");
                    }
                    else
                    {
                        var testResult = _lipidParser.Parse(dr);
                        AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                        AddResultArchiveLog(_lipidParser.ErrorSummary, TestType.Lipid, customerId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                    AddResultArchiveLog(ex.Message, TestType.Lipid, customerId, false);
                }

                _logger.Info("\n\n ===================> Blood Pressure Parsing for CustomerId : " + customerId + "\n");
                try
                {
                    _bloodPressureSynchronizer = new BloodPressureSynchronizer(_logger, customerId, _eventId, _updatedBy, _isNewResultFlow);

                    var testResults = _bloodPressureSynchronizer.Parse(dr);
                    if (testResults != null)
                    {
                        foreach (var testResult in testResults)
                        {
                            AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                            AddResultArchiveLog(_bloodPressureSynchronizer.ErrorSummary, testResult is ASITestResult ? TestType.ASI : TestType.PAD, customerId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                }

                _logger.Info("\n\n ===================> Hba1c Parsing for CustomerId : " + customerId + "\n");
                try
                {
                    bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.A1C);
                    if (!isTestPurchasedByCustomer)
                    {
                        _logger.Info("Hba1c is not availed by CustomerId[" + customerId + "]. \n");
                    }
                    else
                    {
                        var testResult = _hba1CParser.Parse(dr);
                        AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                        AddResultArchiveLog(_hba1CParser.ErrorSummary, TestType.A1C, customerId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                    AddResultArchiveLog(ex.Message, TestType.A1C, customerId, false);
                }

                try
                {
                    _logger.Info("\n\n ===================> Section for Not Recordable, but Performed Tests - for CustomerId : " + customerId + "\n");
                    AddTestResultListforOtherRecordables(ColumnforTshPerformed, customerId, TestType.Thyroid, dr, eventCustomerAggregates);
                    AddTestResultListforOtherRecordables(ColumnforPsaPerformed, customerId, TestType.Psa, dr, eventCustomerAggregates);
                    AddTestResultListforOtherRecordables(ColumnforCrpPerformed, customerId, TestType.Crp, dr, eventCustomerAggregates);
                    AddTestResultListforOtherRecordables(ColumnforColorectalPerformed, customerId, TestType.Colorectal, dr, eventCustomerAggregates);
                    AddTestResultListforOtherRecordables(ColumnforKynPerformed, customerId, TestType.Kyn, dr, eventCustomerAggregates);

                    var testResult = GetTestResultforRecordables(customerId, ColumnforEchoNotPerformed, ColumnforEchoNotes, dr, TestType.Echocardiogram);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);

                    testResult = GetTestResultforRecordables(customerId, ColumnforAaaNotPerformed, ColumnforAaaNotes, dr, TestType.AAA);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);

                    testResult = GetTestResultforRecordables(customerId, ColumnforAsiNotPerformed, ColumnforAsiNotes, dr, TestType.ASI);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);

                    testResult = GetTestResultforRecordables(customerId, ColumnforEkgNotPerformed, ColumnforEkgNotes, dr, TestType.EKG);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);

                    testResult = GetTestResultforRecordables(customerId, ColumnforPadNotPerformed, ColumnforPadNotes, dr, TestType.PAD);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);

                    testResult = GetTestResultforRecordables(customerId, ColumnforStrokeNotPerformed, ColumnforStrokeNotes, dr, TestType.Stroke);
                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                }

            }
            return eventCustomerAggregates;
        }

        private void AddTestResultListforOtherRecordables(string columnName, long customerId, TestType testType, DataRow dr, List<EventCustomerScreeningAggregate> eventCustomerAggregates)
        {
            bool isAvailed = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (int)testType);
            bool isTestPerformed;

            if (isAvailed && dr.Table.Columns.Contains(columnName) && dr[columnName] != null && dr[columnName] != DBNull.Value && bool.TryParse(dr[columnName].ToString(), out isTestPerformed))
            {
                if (!isTestPerformed)
                {
                    var testResult = new TestResult(testType)
                    {
                        UnableScreenReason = new List<UnableScreenReason>
                        {
                            new UnableScreenReason{Reason = UnableToScreenReason.Other}
                        }
                    };

                    AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                    AddResultArchiveLog(string.Empty, testType, customerId);
                }
            }
        }

        private TestResult GetTestResultforRecordables(long customerId, string columnForNotPerformed, string columnNotes, DataRow dr, TestType testType)
        {
            try
            {
                bool isAvailed = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (int)testType);
                if (!isAvailed) return null;

                if (!dr.Table.Columns.Contains(columnForNotPerformed) || !dr.Table.Columns.Contains(columnNotes))
                {
                    return null;
                }

                if (dr[columnForNotPerformed] == DBNull.Value || dr[columnNotes] == DBNull.Value)
                    return null;

                var testResult = GetInstanceforTestType(testType, customerId);
                bool testNotPerformed;
                if (bool.TryParse(dr[columnForNotPerformed].ToString(), out testNotPerformed) && testNotPerformed)
                {
                    var unableScreenReasons = _unableToScreenRepository.GetAllUnableToScreenReasons((long)testType) ??
                                              new List<UnableScreenReason>();

                    if (unableScreenReasons.Count < 1)
                        unableScreenReasons.Add(new UnableScreenReason(0)
                                                    {
                                                        DisplayName = "Unable to Screen",
                                                        Reason = UnableToScreenReason.Other
                                                    });

                    unableScreenReasons.First().ReadingSource = ReadingSource.Automatic;
                    testResult.UnableScreenReason = new List<UnableScreenReason> { unableScreenReasons.First() };
                }

                string techNotes = dr[columnNotes].ToString().Trim();
                if (!string.IsNullOrEmpty(techNotes))
                {
                    testResult.TechNotesSource = ReadingSource.Automatic;
                    testResult.TechnicianNotes = techNotes;
                }

                if (!testNotPerformed && string.IsNullOrEmpty(techNotes)) return null;

                return testResult;
            }
            catch (Exception ex)
            {
                _logger.Error("System Failure! While recording notes for " + testType + ". Message: " + ex.Message + " \n\t" + ex.StackTrace);
                return null;
            }
        }

        private TestResult GetInstanceforTestType(TestType testType, long customerId)
        {
            TestResult testResult = null;
            switch (testType)
            {
                case TestType.Echocardiogram:
                    testResult = _echoTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new EchocardiogramTestResult();
                    break;

                case TestType.AAA:
                    testResult = _aaaTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new AAATestResult();
                    break;

                case TestType.ASI:
                    testResult = _asiTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new ASITestResult();
                    break;

                case TestType.PAD:
                    testResult = _padTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new PADTestResult();
                    break;

                case TestType.Stroke:
                    testResult = _strokeTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new StrokeTestResult();
                    break;

                case TestType.EKG:
                    testResult = _ekgTestResultRepository.GetTestResults(customerId, _eventId, _isNewResultFlow);
                    if (testResult == null)
                        return new EKGTestResult();
                    break;
            }
            return testResult;
        }

        public string GetFolderPathfor(string toFindinFolder)
        {
            // Need to provide a better pattern
            var files = Directory.GetFiles(toFindinFolder, "db.txt");
            if (files.Length == 1) return files[0];

            foreach (string directory in Directory.GetDirectories(toFindinFolder))
            {
                var path = GetFolderPathfor(directory);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }

        public DataTable ParseCsvintoDatatable(string filePath)
        {
            var dtCardiovision = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new [] { ',' }))
                {
                    dtCardiovision.Columns.Add(strColumn);
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dtCardiovision.NewRow();
                    int i = 0;
                    foreach (string strValue in row.Split(new [] { ',' }))
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
            return dtCardiovision;
        }

        private void AddTestResulttoEventCustomerAggregate(List<EventCustomerScreeningAggregate> eventCustomerAggregates, long customerId, TestResult testResult)
        {
            if (testResult != null)
            {
                var eventCustomerAggregate = eventCustomerAggregates.Where(
                    ec => ec.EventId == _eventId && ec.CustomerId == customerId).SingleOrDefault() ??
                                             new EventCustomerScreeningAggregate
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
                log = new ResultArchiveLog
                {
                    CustomerId = customerId,
                    IsSuccessful = isSuccessful,
                    Notes = summary,
                    TestId = testId,
                    CreatedDate = DateTime.Now,
                    MedicalEquipmentTag = MedicalEquipmentTag.Bloodworks.ToString()
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

    }
}