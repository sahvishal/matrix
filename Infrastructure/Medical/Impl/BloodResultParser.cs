using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodResultParser : IResultArchiveParser
    {
        private readonly ILogger _logger;
        private readonly ILogger _parsingLogger;
        private readonly ICsvReader _csvReader;
        private readonly string _bloodTestFile;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;

        private List<BloodResultParserLogModel> _bloodTestResultParserLogs;

        private readonly List<EventCustomerScreeningAggregate> _eventCustomerScreeningAggregates;

        public BloodResultParser(string bloodTestFile, ILogger logger, ICsvReader csvReader, ILogManager logManager)
        {
            _logger = logger;
            _parsingLogger = logManager.GetLogger("NewBloodResultParser");
            _csvReader = csvReader;
            _bloodTestFile = bloodTestFile;
            _testResultService = new Service.TestResultService();
            _eventCustomerScreeningAggregates = new List<EventCustomerScreeningAggregate>();
            _resultParserHelper = new ResultParserHelper();
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public List<BloodResultParserLogModel> BloodTestResultParserLogs
        {
            get
            {
                return _bloodTestResultParserLogs ?? (_bloodTestResultParserLogs = new List<BloodResultParserLogModel>());
            }
        }


        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            try
            {
                if (!DirectoryOperationsHelper.IsFileExist(_bloodTestFile))
                {
                    _logger.Info("File not found : " + _bloodTestFile);
                    _parsingLogger.Info("File not found : " + _bloodTestFile);
                    return null;
                }

                var filename = Path.GetFileName(_bloodTestFile);

                _logger.Info("Importing File : " + filename);
                _parsingLogger.Info("Importing File : " + filename);

                DataTable table = _csvReader.Read(_bloodTestFile);

                if (table.Rows.Count <= 0)
                {
                    _logger.Info("No rows found.");
                    _parsingLogger.Info("No rows found.");
                    return null;
                }

                foreach (DataRow dr in table.Rows)
                {
                    long customerId = 0;
                    long eventId = 0;
                    var log = CreateBloodTestResultLog(dr);

                    if (!IsValidEventIdCustomerId(dr, log, ref eventId, ref customerId))
                    {
                        BloodTestResultParserLogs.Add(log); continue;
                    }

                    bool isMenBloodPanelPurchased = false;
                    bool isWomenBloodPanelPurchased = false;

                    //Men Blood Panel
                    try
                    {
                        _logger.Info(string.Format("Started parsing Men's Blood Panel for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Men's Blood Panel for CustomerId {0} EventId {1}", customerId, eventId));
                        isMenBloodPanelPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MenBloodPanel);
                        if (isMenBloodPanelPurchased)
                            ParseDataForMenBloodPanel(dr, log, customerId, eventId);
                        else
                        {
                            var message = string.Format("Men's Blood Panel is not availed by Customer Id {0} - EventId {1}", customerId, eventId);
                            _logger.Info(message);
                            _parsingLogger.Info(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Men's Blood Panel. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    try
                    {
                        _logger.Info(string.Format("Started parsing Women's Blood Panel for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Women's Blood Panel for CustomerId {0} EventId {1}", customerId, eventId));
                        isWomenBloodPanelPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.WomenBloodPanel);
                        if (isWomenBloodPanelPurchased)
                            ParseDataForWomenBloodPanel(dr, log, customerId, eventId);
                        else
                        {
                            var message = string.Format("Women's Blood Panel is not availed by Customer Id {0} - EventId {1}", customerId, eventId);
                            _logger.Info(message);
                            _parsingLogger.Info(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Women's Blood Panel. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    if (!isWomenBloodPanelPurchased)
                    {
                        //TSH
                        try
                        {
                            _logger.Info(string.Format("Started parsing TSH for CustomerId {0} EventId {1}", customerId, eventId));
                            _parsingLogger.Info(string.Format("Started parsing TSH for CustomerId {0} EventId {1}", customerId, eventId));
                            ParseDataForThyroid(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var message = "Some exception while parsing Data for TSH. Message: " + ex.Message;
                            AppendTestResultLog(log, message, false);
                            _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                            _parsingLogger.Error(message);
                        }
                    }


                    if (!isMenBloodPanelPurchased)
                    {
                        //PSA
                        try
                        {
                            _logger.Info(string.Format("Started parsing PSA for CustomerId {0}  EventId {1}", customerId, eventId));
                            _parsingLogger.Info(string.Format("Started parsing PSA for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForPsa(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for PSA. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            _parsingLogger.Error(messsage);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }

                    if (!isMenBloodPanelPurchased && !isWomenBloodPanelPurchased)
                    {
                        //CRP
                        try
                        {
                            _logger.Info(string.Format("Started parsing CRP for CustomerId {0}  EventId {1}", customerId, eventId));
                            _parsingLogger.Info(string.Format("Started parsing CRP for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForCrp(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for CRP. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            _parsingLogger.Error(messsage);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }


                    if (!isMenBloodPanelPurchased)
                    {
                        //Testosterone
                        try
                        {
                            _logger.Info(string.Format("Started parsing Testosterone for CustomerId {0}  EventId {1}", customerId, eventId));
                            _parsingLogger.Info(string.Format("Started parsing Testosterone for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForTestosterone(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for Testosterone. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            _parsingLogger.Error(messsage);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }

                    if (!isWomenBloodPanelPurchased)
                    {
                        //VitaminD
                        try
                        {
                            _logger.Info(string.Format("Started parsing VitaminD for CustomerId {0} EventId {1}", customerId, eventId));
                            _parsingLogger.Info(string.Format("Started parsing VitaminD for CustomerId {0} EventId {1}", customerId, eventId));
                            ParseDataForVitaminD(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var message = "Some exception while parsing Data for VitaminD. Message: " + ex.Message;
                            AppendTestResultLog(log, message, false);
                            _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                            _parsingLogger.Error(message);
                        }
                    }

                    //A1C
                    try
                    {
                        _logger.Info(string.Format("Started parsing A1C for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing A1C for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForA1C(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for A1C. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //AwvHbA1C
                    try
                    {
                        _logger.Info(string.Format("Started parsing AWV HBA1C for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing AWV HBA1C for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForAwvHbA1C(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for AWV HBA1C. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Cholestrol Screening
                    try
                    {
                        _logger.Info(string.Format("Started parsing Cholesterol Screening for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Cholesterol Screening for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForCholestrol(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Cholesterol Screening. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Lipid
                    try
                    {
                        _logger.Info(string.Format("Started parsing Lipid for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Lipid for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForLipid(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Lipid. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Awv Lipid
                    try
                    {
                        _logger.Info(string.Format("Started parsing Awv Lipid for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Awv Lipid for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForAwvLipid(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Awv Lipid. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Awv Glucose
                    try
                    {
                        _logger.Info(string.Format("Started parsing Awv Glucose for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Awv Glucose for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForAwvGlucose(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Awv Glucose. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Diabetes
                    try
                    {
                        _logger.Info(string.Format("Started parsing Diabetes for CustomerId {0} EventId {1}", customerId, eventId));
                        _parsingLogger.Info(string.Format("Started parsing Diabetes for CustomerId {0} EventId {1}", customerId, eventId));
                        ParseDataForDiabetes(dr, log, customerId, eventId);
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Diabetes. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        _parsingLogger.Error(message);
                    }

                    //Liver
                    //try
                    //{
                    //    _logger.Info(string.Format("Started parsing Lipid for CustomerId {0} EventId {1}", customerId, eventId));
                    //    _parsingLogger.Info(string.Format("Started parsing Liver for CustomerId {0} EventId {1}", customerId, eventId));
                    //    ParseDataForLiver(dr, log, customerId, eventId);
                    //}
                    //catch (Exception ex)
                    //{
                    //    var message = "Some exception while parsing Data for Liver. Message: " + ex.Message;
                    //    AppendTestResultLog(log, message, false);
                    //    _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                    //    _parsingLogger.Error(message);
                    //}

                    BloodTestResultParserLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured while parsing blood test(s). Message:" + ex.Message + "\n" + ex.StackTrace, ex);
                _parsingLogger.Error("Some error occured while parsing blood test(s). Message:" + ex.Message);
            }


            return _eventCustomerScreeningAggregates;
        }

        private bool IsValidEventIdCustomerId(DataRow dr, BloodResultParserLogModel log, ref long eventId, ref long customerId)
        {
            try
            {
                string message;
                var barCodeId = GetRowValue(dr, BloodParserColumns.BarcodeId);

                var location = GetRowValue(dr, BloodParserColumns.EventId);

                if (string.IsNullOrEmpty(barCodeId))
                {
                    message = "Empty Barcode ID Found";
                    _logger.Error(message);
                    _parsingLogger.Error(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }

                long.TryParse(barCodeId, out customerId);
                if (string.IsNullOrEmpty(location))
                {
                    message = "Empty Event ID Found";
                    _logger.Error(message);
                    _parsingLogger.Error(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }
                long.TryParse(location, out eventId);

                if (customerId < 1)
                {
                    message = "No Valid Customer Id found for : " + GetRowValue(dr, BloodParserColumns.FirstName) + " " + GetRowValue(dr, BloodParserColumns.LastName);
                    _logger.Info(message);
                    _parsingLogger.Info(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }

                if (eventId < 1)
                {
                    message = "No Valid Event ID found for : " + GetRowValue(dr, BloodParserColumns.FirstName) + " " + GetRowValue(dr, BloodParserColumns.LastName);
                    _logger.Info(message);
                    _parsingLogger.Info(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }
            }
            catch (Exception exception)
            {
                var message = "Error while extracting Barcode Id. Message: " + exception.Message;
                AppendTestResultLog(log, message, false);
                _logger.Error(string.Format("Error while extracting Barcode Id. Message: {0} Stack Trace{1}", exception.Message, exception.StackTrace));
                _parsingLogger.Error(string.Format("Error while extracting Barcode Id. Message: {0}", exception.Message));
                return false;

            }

            log.EventId = eventId;
            log.CustomerId = customerId;

            return true;
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = true)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            if (format)
                return FormatSentence(row[fieldName].ToString().Trim());
            return row[fieldName].ToString().Trim();
        }

        private static string FormatSentence(string source)
        {
            var words = source.Split(' ').Select(t => t.ToCharArray()).ToList();
            words.ForEach(t =>
            {
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = i.Equals(0) ? char.ToUpper(t[i]) : char.ToLower(t[i]);
                }
            });
            return string.Join(" ", words.Select(t => new string(t)));
        }

        private void AppendTestResultLog(BloodResultParserLogModel log, string message, bool isSuccessful = true)
        {
            if (!string.IsNullOrEmpty(message))
                log.Notes.Append(message).Append("\n");

            if (!isSuccessful)
                log.IsSuccessful = false;

        }

        private BloodResultParserLogModel CreateBloodTestResultLog(DataRow dr)
        {
            return new BloodResultParserLogModel
            {
                EventId = Int64.Parse(GetRowValue(dr, BloodParserColumns.EventId)),
                MedicalId = GetRowValue(dr, BloodParserColumns.MedicalId),
                CustomerId = Int64.Parse(GetRowValue(dr, BloodParserColumns.BarcodeId)),
                FirstName = GetRowValue(dr, BloodParserColumns.FirstName),
                LastName = GetRowValue(dr, BloodParserColumns.LastName),
                Dob = GetRowValue(dr, BloodParserColumns.Dob),
                Gender = GetRowValue(dr, BloodParserColumns.Gender),
                CollectionDate = GetRowValue(dr, BloodParserColumns.CollectionDate),
                ReceiptDate = GetRowValue(dr, BloodParserColumns.ReceiptDate),
                TestingDate = GetRowValue(dr, BloodParserColumns.TestingDate),
                ReportDate = GetRowValue(dr, BloodParserColumns.ReportDate)
            };
        }

        private void ParseDataForThyroid(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Thyroid);
            var dsTshValue = GetRowValue(dr, BloodParserColumns.DsTsh);
            var dbTshValue = GetRowValue(dr, BloodParserColumns.DbTsh);
            var isEmpty = string.IsNullOrWhiteSpace(dsTshValue) && string.IsNullOrWhiteSpace(dbTshValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Thyroid", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Thyroid is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new ThyroidTestResult
                {
                    TSHSCR = new ResultReading<string>(ReadingLabels.TSHSCR)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = !string.IsNullOrWhiteSpace(dsTshValue) ? dsTshValue : dbTshValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForPsa(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Psa);
            var dsPsaValue = GetRowValue(dr, BloodParserColumns.DsPsa);
            var dbPsaValue = GetRowValue(dr, BloodParserColumns.DbPsa);
            var isEmpty = string.IsNullOrWhiteSpace(dsPsaValue) && string.IsNullOrWhiteSpace(dbPsaValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}, no data for PSA", customerId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("PSA is not availed by CustomerId {0} EventId {1}", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new PsaTestResult
                {
                    PSASCR = new ResultReading<string>(ReadingLabels.PSASCR)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = !string.IsNullOrWhiteSpace(dsPsaValue) ? dsPsaValue : dbPsaValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }

        }

        private void ParseDataForCrp(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Crp);
            var crpValue = GetRowValue(dr, BloodParserColumns.DsCrp);
            var isEmpty = string.IsNullOrWhiteSpace(crpValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);

            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("CRP is not availed by CustomerId {0} - EventId {1}", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new CrpTestResult
                {
                    LCRP = new ResultReading<string>(ReadingLabels.LCRP)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = crpValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.Crp, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForTestosterone(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Testosterone);
            var testosteroneValue = GetRowValue(dr, BloodParserColumns.DsCre);
            var isEmpty = string.IsNullOrWhiteSpace(testosteroneValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for Testosterone", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Testosterone is not availed by CustomerId {0} - Event id {1}", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message);
            }
            else
            {
                var testResult = new TestosteroneTestResult
                {
                    TESTSCRE = new ResultReading<string>(ReadingLabels.TESTSCRE)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = testosteroneValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.Testosterone, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForVitaminD(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.VitaminD);
            var vitaminDValue = GetRowValue(dr, BloodParserColumns.DsVtd);
            var isEmpty = string.IsNullOrWhiteSpace(vitaminDValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for VitaminD", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("VitaminD is not availed by CustomerId {0} - Event id {1}", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message);
            }
            else
            {
                var testResult = new VitaminDTestResult
                {
                    VitD = new ResultReading<string>(ReadingLabels.VitD)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = vitaminDValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.VitaminD, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForMenBloodPanel(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            string message;

            var dsPsaValue = GetRowValue(dr, BloodParserColumns.DsPsa);
            var dbPsaValue = GetRowValue(dr, BloodParserColumns.DbPsa);
            var isPsaEmpty = string.IsNullOrWhiteSpace(dsPsaValue) && string.IsNullOrWhiteSpace(dbPsaValue);
            ResultReading<string> psaResultReading = null;
            if (isPsaEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for PSA", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                psaResultReading = new ResultReading<string>(ReadingLabels.PSASCR)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = !string.IsNullOrWhiteSpace(dsPsaValue) ? dsPsaValue : dbPsaValue
                };
            }

            var crpValue = GetRowValue(dr, BloodParserColumns.DsCrp);
            var isCrpEmpty = string.IsNullOrWhiteSpace(crpValue);
            ResultReading<string> crpResultResultReading = null;
            if (isCrpEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                crpResultResultReading = new ResultReading<string>(ReadingLabels.LCRP)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = crpValue
                };
            }

            var testosteroneValue = GetRowValue(dr, BloodParserColumns.DsCre);
            var isTestosteroneEmpty = string.IsNullOrWhiteSpace(testosteroneValue);
            ResultReading<string> testosteroneResultReading = null;
            if (isTestosteroneEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for Testosterone", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                testosteroneResultReading = new ResultReading<string>(ReadingLabels.TESTSCRE)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = testosteroneValue
                };
            }

            if (psaResultReading != null || crpResultResultReading != null || testosteroneResultReading != null)
            {
                var testResult = new MenBloodPanelTestResult
                {
                    PSASCR = psaResultReading,
                    LCRP = crpResultResultReading,
                    TESTSCRE = testosteroneResultReading
                };

                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.MenBloodPanel, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForWomenBloodPanel(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            string message;

            var dsTshValue = GetRowValue(dr, BloodParserColumns.DsTsh);
            var dbTshValue = GetRowValue(dr, BloodParserColumns.DbTsh);
            var isThyroidEmpty = string.IsNullOrWhiteSpace(dsTshValue) && string.IsNullOrWhiteSpace(dbTshValue);
            ResultReading<string> thyroidResultReading = null;
            if (isThyroidEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for TSH", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                thyroidResultReading = new ResultReading<string>(ReadingLabels.TSHSCR)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = !string.IsNullOrWhiteSpace(dsTshValue) ? dsTshValue : dbTshValue
                };
            }

            var crpValue = GetRowValue(dr, BloodParserColumns.DsCrp);
            var isCrpEmpty = string.IsNullOrWhiteSpace(crpValue);
            ResultReading<string> crpResultResultReading = null;
            if (isCrpEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                crpResultResultReading = new ResultReading<string>(ReadingLabels.LCRP)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = crpValue
                };
            }

            var vitaminDValue = GetRowValue(dr, BloodParserColumns.DsVtd);
            var isVitaminDEmpty = string.IsNullOrWhiteSpace(vitaminDValue);
            ResultReading<string> vitaminDResultResultReading = null;
            if (isVitaminDEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for VitaminD", customerId, eventId);
                _logger.Info(message);
                _parsingLogger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                vitaminDResultResultReading = new ResultReading<string>(ReadingLabels.VitD)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = vitaminDValue
                };
            }


            if (thyroidResultReading != null || crpResultResultReading != null || vitaminDResultResultReading != null)
            {
                var testResult = new WomenBloodPanelTestResult
                {
                    TSHSCR = thyroidResultReading,
                    LCRP = crpResultResultReading,
                    VitD = vitaminDResultResultReading
                };

                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.WomenBloodPanel, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForA1C(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.A1C);
            var dsA1CValue = GetRowValue(dr, BloodParserColumns.DsA1C);
            var dbA1CValue = GetRowValue(dr, BloodParserColumns.DbA1C);
            var isEmpty = string.IsNullOrWhiteSpace(dsA1CValue) && string.IsNullOrWhiteSpace(dbA1CValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for A1C", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("A1C is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new HemaglobinA1CTestResult
                {
                    Hba1c = new ResultReading<string>(ReadingLabels.Hba1c)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = !string.IsNullOrWhiteSpace(dsA1CValue) ? dsA1CValue : dbA1CValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForAwvHbA1C(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvHBA1C);
            var dsA1CValue = GetRowValue(dr, BloodParserColumns.DsA1C);
            var dbA1CValue = GetRowValue(dr, BloodParserColumns.DbA1C);
            var isEmpty = string.IsNullOrWhiteSpace(dsA1CValue) && string.IsNullOrWhiteSpace(dbA1CValue);
            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for AWV HBA1C", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("AWV HBA1C is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new AwvHemaglobinTestResult
                {
                    Hba1c = new ResultReading<string>(ReadingLabels.Hba1c)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = !string.IsNullOrWhiteSpace(dsA1CValue) ? dsA1CValue : dbA1CValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForCholestrol(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Cholesterol);
            var dsChoValue = GetRowValue(dr, BloodParserColumns.DsCho);
            var dsHdlValue = GetRowValue(dr, BloodParserColumns.DsHdl);
            var dsLdlValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsLdl)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsLdl)) : (int?)null;
            var dsTrgValue = GetRowValue(dr, BloodParserColumns.DsTrg);
            var tcHdlRatio = !string.IsNullOrWhiteSpace(dsChoValue) && !string.IsNullOrWhiteSpace(dsHdlValue)
                ? CalculateTCHDLRatio(dsChoValue, dsHdlValue)
                : null;

            var isEmpty = string.IsNullOrWhiteSpace(dsChoValue) && string.IsNullOrWhiteSpace(dsHdlValue) && dsLdlValue == null
                && string.IsNullOrWhiteSpace(dsTrgValue);

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Cholesterol Screening", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Cholesterol Screening is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new CholesterolTestResult
                {
                    TotalCholesterol = new CompoundResultReading<string>(ReadingLabels.TotalCholestrol)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsChoValue
                    },
                    HDL = new CompoundResultReading<string>(ReadingLabels.HDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsHdlValue
                    },
                    LDL = new CompoundResultReading<int?>(ReadingLabels.LDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsLdlValue
                    },
                    TriGlycerides = new CompoundResultReading<string>(ReadingLabels.TriGlycerides)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsTrgValue
                    },
                    TCHDLRatio = new CompoundResultReading<decimal?>(ReadingLabels.TCHDLRatio)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = tcHdlRatio
                    },

                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForLipid(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Lipid);
            var dsChoValue = GetRowValue(dr, BloodParserColumns.DsCho);
            var dsHdlValue = GetRowValue(dr, BloodParserColumns.DsHdl);
            var dsGluValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsGlu)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsGlu)) : (int?)null;
            var dsLdlValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsLdl)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsLdl)) : (int?)null;
            var dsTrgValue = GetRowValue(dr, BloodParserColumns.DsTrg);
            var tcHdlRatio = !string.IsNullOrWhiteSpace(dsChoValue) && !string.IsNullOrWhiteSpace(dsHdlValue)
                ? CalculateTCHDLRatio(dsChoValue, dsHdlValue)
                : null;

            var dsAltValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsAlt)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsAlt)) : (int?)null;
            var dsAstValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsAst)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsAst)) : (int?)null;

            var isEmpty = string.IsNullOrWhiteSpace(dsChoValue) && string.IsNullOrWhiteSpace(dsHdlValue) && dsGluValue == null && dsLdlValue == null
                && string.IsNullOrWhiteSpace(dsTrgValue) && dsAltValue == null && dsAstValue == null;

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Lipid", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Lipid is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new LipidTestResult
                {
                    TotalCholestrol = new CompoundResultReading<string>(ReadingLabels.TotalCholestrol)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsChoValue
                    },
                    HDL = new CompoundResultReading<string>(ReadingLabels.HDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsHdlValue
                    },
                    Glucose = new CompoundResultReading<int?>(ReadingLabels.Glucose)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsGluValue
                    },
                    LDL = new CompoundResultReading<int?>(ReadingLabels.LDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsLdlValue
                    },
                    TriGlycerides = new CompoundResultReading<string>(ReadingLabels.TriGlycerides)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsTrgValue
                    },
                    TCHDLRatio = new CompoundResultReading<decimal?>(ReadingLabels.TCHDLRatio)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = tcHdlRatio
                    },
                    ALT = new CompoundResultReading<int?>(ReadingLabels.ALT)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsAltValue
                    },
                    AST = new CompoundResultReading<int?>(ReadingLabels.AST)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsAstValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForAwvLipid(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvLipid);
            var dsChoValue = GetRowValue(dr, BloodParserColumns.DsCho);
            var dsHdlValue = GetRowValue(dr, BloodParserColumns.DsHdl);
            var dsLdlValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsLdl)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsLdl)) : (int?)null;
            var dsTrgValue = GetRowValue(dr, BloodParserColumns.DsTrg);
            var tcHdlRatio = !string.IsNullOrWhiteSpace(dsChoValue) && !string.IsNullOrWhiteSpace(dsHdlValue)
                ? CalculateTCHDLRatio(dsChoValue, dsHdlValue)
                : null;

            var isEmpty = string.IsNullOrWhiteSpace(dsChoValue) && string.IsNullOrWhiteSpace(dsHdlValue) && dsLdlValue == null && string.IsNullOrWhiteSpace(dsTrgValue);

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Awv Lipid", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Awv Lipid is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new AwvLipidTestResult
                {
                    TotalCholestrol = new CompoundResultReading<string>(ReadingLabels.TotalCholestrol)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsChoValue
                    },
                    HDL = new CompoundResultReading<string>(ReadingLabels.HDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsHdlValue
                    },
                    LDL = new CompoundResultReading<int?>(ReadingLabels.LDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsLdlValue
                    },
                    TriGlycerides = new CompoundResultReading<string>(ReadingLabels.TriGlycerides)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsTrgValue
                    },
                    TCHDLRatio = new CompoundResultReading<decimal?>(ReadingLabels.TCHDLRatio)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = tcHdlRatio
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForAwvGlucose(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvGlucose);
            var dsGluValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsGlu)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsGlu)) : (int?)null;
            var isEmpty = dsGluValue == null;

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Awv Lipid", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Awv Lipid is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new AwvGlucoseTestResult
                {
                    Glucose = new CompoundResultReading<int?>(ReadingLabels.Glucose)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsGluValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForDiabetes(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Diabetes);
            var dsGluValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsGlu)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsGlu)) : (int?)null;
            var isEmpty = dsGluValue == null;

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Diabetes", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Diabetes is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new DiabetesTestResult
                {
                    Glucose = new CompoundResultReading<int?>(ReadingLabels.Glucose)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsGluValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private void ParseDataForLiver(DataRow dr, BloodResultParserLogModel log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Liver);

            var dsAltValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsAlt)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsAlt)) : (int?)null;
            var dsAstValue = !string.IsNullOrWhiteSpace(GetRowValue(dr, BloodParserColumns.DsAst)) ? Convert.ToInt32(GetRowValue(dr, BloodParserColumns.DsAst)) : (int?)null;

            var isEmpty = dsAltValue == null && dsAstValue == null;

            string message;

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for Liver", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Liver is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
                _parsingLogger.Info(message);
            }
            else
            {
                var testResult = new LiverTestResult
                {
                    ALT = new CompoundResultReading<int?>(ReadingLabels.ALT)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsAltValue
                    },
                    AST = new CompoundResultReading<int?>(ReadingLabels.AST)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dsAstValue
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }
        }

        private decimal? CalculateTCHDLRatio(string totalCholestrol, string hdl)
        {
            var intTotalCholestrol = Convert.ToDecimal(totalCholestrol);
            var intHdl = Convert.ToDecimal(hdl);

            var result = intHdl > 0 ? intTotalCholestrol / intHdl : 0;

            return result > 0 ? decimal.Round(result, 1) : (decimal?)null;
        }
    }
}
