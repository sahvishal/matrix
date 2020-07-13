using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class CardiovisionResultParser : IResultArchiveParser
    {
        private ILogger _logger;
        private const string ColumnforCustomerId = "Ins. or Other ID No";

        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private readonly CardiovisionAsiParser _asiParser;
        private readonly CardiovisionPadParser _padParser;
        private readonly CardiovisionAwvAbiParser _awvAbiParser;
        private readonly Service.TestResultService _testResultService;
        private IBloodPressureSynchronizer _bloodPressureSynchronizer;

        private List<ResultArchiveLog> _resultArchiveLogs;
        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultArchiveLogs; }
        }

        private readonly bool _isNewResultFlow;

        public CardiovisionResultParser(string resultOutputPath, long eventId, ILogger logger, bool isNewResultFlow)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _logger = logger;

            _asiParser = new CardiovisionAsiParser(logger);
            _padParser = new CardiovisionPadParser(logger);
            _awvAbiParser = new CardiovisionAwvAbiParser(logger);
            _testResultService = new Service.TestResultService();
            _isNewResultFlow = isNewResultFlow;
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            _resultArchiveLogs = new List<ResultArchiveLog>();

            var csvFilePath = GetFolderPathfor(_resultOutputPath);
            if (csvFilePath != null && csvFilePath.Count() > 0)
            {
                foreach (string filePath in csvFilePath)
                {
                    ParseCsv(filePath, eventCustomerAggregates);
                }
            }

            return eventCustomerAggregates;
        }

        private void ParseCsv(string csvFilePath, List<EventCustomerScreeningAggregate> eventCustomerAggregates)
        {

            var dtCardiovision = ParseCsvintoDatatable(csvFilePath);

            var isColumnsForPadValid = CardiovisionPadParser.IsDatatableConversionfromCsvValid(dtCardiovision);
            var isColumnsForAsiValid = CardiovisionAsiParser.IsDatatableConversionfromCsvValid(dtCardiovision);

            var isColumnsForAwvAbiValid = CardiovisionAwvAbiParser.IsDatatableConversionfromCsvValid(dtCardiovision);

            if (!dtCardiovision.Columns.Contains(ColumnforCustomerId) || (!isColumnsForAsiValid && !isColumnsForPadValid && !isColumnsForAwvAbiValid))
            {
                _logger.Error("Cardiovision File provided is an Invalid File!");
                return;
            }

            foreach (DataRow dr in dtCardiovision.Rows)
            {
                long customerId = 0;
                if (dr[ColumnforCustomerId] != null && dr[ColumnforCustomerId] != DBNull.Value && !string.IsNullOrEmpty(dr[ColumnforCustomerId].ToString()))
                {
                    long.TryParse(dr[ColumnforCustomerId].ToString(), out customerId);
                }
                if (customerId < 1)
                {
                    _logger.Error("Customer Id not found in the row number " + (dtCardiovision.Rows.IndexOf(dr) + 1));
                    continue;
                }


                if (isColumnsForPadValid || isColumnsForAwvAbiValid)
                {
                    _logger.Info("\n\n ===================> PAD Parsing for CustomerId : " + customerId + "\n");


                    var isPadTestPurchasedByCustomer = false;
                    try
                    {
                        isPadTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.PAD);
                        var isAwvAbiTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvABI);

                        if (!isPadTestPurchasedByCustomer && !isAwvAbiTestPurchasedByCustomer)
                        {
                            _logger.Info("PAD is not availed by CustomerId[" + customerId + "]. \n");
                        }
                        else if (isPadTestPurchasedByCustomer)
                        {
                            var testResult = _padParser.Parse(dr);
                            AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                            AddResultArchiveLog(_padParser.ErrorSummary, TestType.PAD, customerId);
                        }
                        else if (isAwvAbiTestPurchasedByCustomer)
                        {
                            var testResult = _awvAbiParser.Parse(dr);
                            AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                            AddResultArchiveLog(_awvAbiParser.ErrorSummary, TestType.AwvABI, customerId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                        AddResultArchiveLog(ex.Message, (isPadTestPurchasedByCustomer ? TestType.PAD : TestType.AwvABI), customerId, false);
                    }

                }

                _bloodPressureSynchronizer = new BloodPressureSynchronizer(_logger, customerId, _eventId, 0, _isNewResultFlow);
                if (isColumnsForAsiValid)
                {
                    _logger.Info("\n\n ===================> ASI Parsing for CustomerId : " + customerId + "\n");
                    try
                    {
                        bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.ASI);
                        if (!isTestPurchasedByCustomer)
                        {
                            _logger.Info("ASI is not availed by CustomerId[" + customerId + "]. \n");
                        }
                        else
                        {
                            var testResult = _asiParser.Parse(dr);
                            var pressureReadings = _bloodPressureSynchronizer.GetReadingsinDb();
                            if (testResult != null && pressureReadings != null && testResult is ASITestResult)
                            {
                                var asiTestResult = (testResult as ASITestResult);
                                if (asiTestResult.PressureReadings == null)
                                    asiTestResult.PressureReadings = pressureReadings;
                            }

                            AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, customerId, testResult);
                            AddResultArchiveLog(_asiParser.ErrorSummary, TestType.ASI, customerId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("System Failure! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                        AddResultArchiveLog(ex.Message, TestType.ASI, customerId, false);
                    }
                }
            }
        }

        public IEnumerable<string> GetFolderPathfor(string toFindinFolder)
        {
            var files = Directory.GetFiles(toFindinFolder, "*.txt").AsEnumerable();

            foreach (string directory in Directory.GetDirectories(toFindinFolder))
            {
                var inFiles = GetFolderPathfor(directory);
                if (inFiles != null && inFiles.Count() > 0) files = files.Concat(inFiles);
            }

            return files;
        }

        public DataTable ParseCsvintoDatatable(string filePath)
        {
            var dtCardiovision = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new char[] { ',' }))
                {
                    dtCardiovision.Columns.Add(strColumn);
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dtCardiovision.NewRow();
                    int i = 0;
                    foreach (string strValue in row.Split(new char[] { ',' }))
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
                    MedicalEquipmentTag = MedicalEquipmentTag.Cardiovascular.ToString()
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
