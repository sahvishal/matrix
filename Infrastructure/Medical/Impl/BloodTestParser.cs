using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Falcon.App.Core.Application;
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
    public class BloodTestParser : IResultArchiveParser
    {
        private readonly ILogger _logger;
        private readonly IExcelReader _excelReader;
        private readonly ICsvReader _csvReader;
        private readonly string _bloodTestFile;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;

        private List<BloodTestResultParserLog> _bloodTestResultParserLogs;

        private readonly List<EventCustomerScreeningAggregate> _eventCustomerScreeningAggregates;

        public const string ColumnThyroid = "TSHSCR";
        public const string ColumnPsa = "PSASCR";
        public const string ColumnCrp = "LCRP";
        public const string ColumnTestosterone = "TESTSCRE";
        public const string ColumnVitaminD = "CARDVITD";

        public const string ColumnBarcodeId = "BARCODE_ID";
        public const string ColumnFirstName = "FIRST_NAME";
        public const string ColumnLastname = "LAST_NAME";
        public const string ColumnDob = "DOB";
        public const string ColumnEventId = "LOCATION";
        public const string ColumnDrawDate = "DRAW_DATE";

        public readonly bool ReadDataFromNewLab;

        public BloodTestParser(string bloodTestFile, ILogger logger, IExcelReader excelReader, ICsvReader csvReader, bool readDataFromNewLab)
        {
            _logger = logger;
            _excelReader = excelReader;
            _csvReader = csvReader;
            _bloodTestFile = bloodTestFile;
            _testResultService = new Service.TestResultService();
            _eventCustomerScreeningAggregates = new List<EventCustomerScreeningAggregate>();
            _resultParserHelper = new ResultParserHelper();
            ReadDataFromNewLab = readDataFromNewLab;
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public List<BloodTestResultParserLog> BloodTestResultParserLogs
        {
            get
            {
                return _bloodTestResultParserLogs ?? (_bloodTestResultParserLogs = new List<BloodTestResultParserLog>());
            }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            try
            {
                DataTable dataTable = null;
                if (ReadDataFromNewLab)
                {
                    dataTable = GetDatatableFromCsv();
                }
                else
                {
                   dataTable = GetDatatableFromExcel();
                }
                
                if (dataTable == null) return null;

                foreach (DataRow dr in dataTable.Rows)
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
                        isMenBloodPanelPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MenBloodPanel);
                        if (isMenBloodPanelPurchased)
                            ParseDataForMenBloodPanel(dr, log, customerId, eventId);
                        else
                        {
                            var message = string.Format("Men's Blood Panel is not availed by Customer Id {0} - EventId {1}", customerId, eventId);
                            _logger.Info(message);
                        }
                    }
                    catch (Exception ex)
                    {

                        var message = "Some exception while parsing Data for Men's Blood Panel. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                    }

                    try
                    {
                        _logger.Info(string.Format("Started parsing Women's Blood Panel for CustomerId {0} EventId {1}", customerId, eventId));
                        isWomenBloodPanelPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.WomenBloodPanel);
                        if (isWomenBloodPanelPurchased)
                            ParseDataForWomenBloodPanel(dr, log, customerId, eventId);
                        else
                        {
                            var message = string.Format("Women's Blood Panel is not availed by Customer Id {0} - EventId {1}", customerId, eventId);
                            _logger.Info(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = "Some exception while parsing Data for Women's Blood Panel. Message: " + ex.Message;
                        AppendTestResultLog(log, message, false);
                        _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                    }

                    if (!isWomenBloodPanelPurchased)
                    {
                        //TSH
                        try
                        {
                            _logger.Info(string.Format("Started parsing TSH for CustomerId {0} EventId {1}", customerId, eventId));
                            ParseDataForThyroid(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var message = "Some exception while parsing Data for TSH. Message: " + ex.Message;
                            AppendTestResultLog(log, message, false);
                            _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        }
                    }


                    if (!isMenBloodPanelPurchased)
                    {
                        //PSA
                        try
                        {
                            _logger.Info(string.Format("Started parsing PSA for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForPsa(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for PSA. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }

                    if (!isMenBloodPanelPurchased && !isWomenBloodPanelPurchased)
                    {
                        //CRP
                        try
                        {
                            _logger.Info(string.Format("Started parsing CRP for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForCrp(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for CRP. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }


                    if (!isMenBloodPanelPurchased)
                    {
                        //Testosterone
                        try
                        {
                            _logger.Info(string.Format("Started parsing Testosterone for CustomerId {0}  EventId {1}", customerId, eventId));
                            ParseDataForTestosterone(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var messsage = "Some exception while parsing Data for Testosterone. Message: " + ex.Message;
                            _logger.Error(messsage + "\t strack trace : " + ex.StackTrace);
                            AppendTestResultLog(log, messsage, false);
                        }
                    }

                    if (!isWomenBloodPanelPurchased)
                    {
                        //VitaminD
                        try
                        {
                            _logger.Info(string.Format("Started parsing VitaminD for CustomerId {0} EventId {1}", customerId, eventId));
                            ParseDataForVitaminD(dr, log, customerId, eventId);
                        }
                        catch (Exception ex)
                        {
                            var message = "Some exception while parsing Data for VitaminD. Message: " + ex.Message;
                            AppendTestResultLog(log, message, false);
                            _logger.Error(message + "\t Stack Trace " + ex.StackTrace);
                        }
                    }

                    BloodTestResultParserLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured while parsing blood test(s). Message:" + ex.Message + "\n" + ex.StackTrace, ex);
            }

            return _eventCustomerScreeningAggregates;
        }

        private DataTable GetDatatableFromExcel()
        {
            var fileName = Path.GetFileName(_bloodTestFile);

            DataSet dataset = null;

            try
            {
                dataset = _excelReader.ReadfromExcelintoDataset(_bloodTestFile);
            }
            catch (Exception ex)
            {
                _logger.Error(
                    string.Format("Some error occured while extracting data from excel file {0}. Message: {1} \n {2}", fileName,
                        ex.Message, ex.StackTrace), ex);
            }

            if (dataset == null || dataset.Tables.Count < 1) return null;

            if (dataset.Tables[0].Rows.Count < 1)
            {
                _logger.Info("\nNo Rows found in the File : " + fileName);
                return null;
            }

            return dataset.Tables[0];
        }

        private DataTable GetDatatableFromCsv()
        {
            var fileName = Path.GetFileName(_bloodTestFile);

            DataTable dataTable = null;

            try
            {
                dataTable = _csvReader.ReadWithTextQualifier(_bloodTestFile);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Some error occured while extracting data from excel file {0}. Message: {1} \n {2}", fileName,ex.Message, ex.StackTrace), ex);
            }

            if (dataTable == null) return null;

            if (dataTable.Rows.Count < 1)
            {
                _logger.Info("\nNo Rows found in the File : " + fileName);
                return null;
            }

            return dataTable;
        }

        private bool IsValidEventIdCustomerId(DataRow dr, BloodTestResultParserLog log, ref long eventId, ref long customerId)
        {
            try
            {
                string message;
                var barCodeId = dr[ColumnBarcodeId].ToString();

                var location = dr[ColumnEventId].ToString();

                if (string.IsNullOrEmpty(barCodeId))
                {
                    message = "Empty Barcode id Found";
                    _logger.Error(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }

                long.TryParse(barCodeId, out customerId);
                if (string.IsNullOrEmpty(location))
                {
                    message = "Empty Location Found";
                    _logger.Error(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }
                long.TryParse(location, out eventId);

                if (customerId < 1)
                {
                    message = "No Valid Customer Id found for : " + dr[ColumnFirstName] + " " + dr[ColumnLastname];
                    _logger.Info(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }

                if (eventId < 1)
                {
                    message = "No Valid eventId Id found for : " + dr[ColumnFirstName] + " " + dr[ColumnLastname];
                    _logger.Info(message);
                    AppendTestResultLog(log, message, false);
                    return false;
                }
            }
            catch (Exception exception)
            {
                var message = "Error while extracting Barcode Id Message: " + exception.Message;
                AppendTestResultLog(log, message, false);
                _logger.Error(string.Format("Error while extracting Barcode Id Message: {0} Stack Trace{1}", exception.Message, exception.StackTrace));
                return false;

            }

            log.EventId = eventId;
            log.CustomerId = customerId;

            return true;
        }

        private static bool IsDataRowItemEmpty(Object obj)
        {
            if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                return false;

            return true;
        }

        private string DataRowValue(Object obj)
        {
            try
            {
                if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                    return obj.ToString();
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("string some error occured while parsing value Message {0} - stacktrace {1}", exception.Message, exception.StackTrace));
            }

            return string.Empty;
        }

        private void ParseDataForThyroid(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Thyroid);
            var isEmpty = IsDataRowItemEmpty(dr[ColumnThyroid]);
            string message;

            if (isEmpty && !isTestPurchasedByCustomer)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for TSH", customerId, eventId);
                _logger.Info(message);
                return;
            }

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for TSH", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("TSH is not availed by CustomerId {0} - EventId {1}.", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
            }
            else
            {
                var testResult = new ThyroidTestResult
                {
                    TSHSCR = new ResultReading<string>(ReadingLabels.TSHSCR)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnThyroid].ToString()
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }

        }

        private void ParseDataForPsa(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Psa);
            var isEmpty = IsDataRowItemEmpty(dr[ColumnPsa]);
            string message;

            if (isEmpty && !isTestPurchasedByCustomer)
            {
                _logger.Info(string.Format("For Customer Id {0} EventId {1}, no data for PSA ", customerId, eventId));
                return;
            }

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}, no data for PSA", customerId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("PSA is not availed by CustomerId {0} EventId {1}", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
            }
            else
            {
                var testResult = new PsaTestResult
                {
                    PSASCR = new ResultReading<string>(ReadingLabels.PSASCR)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnPsa].ToString()
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
            }

        }

        private void ParseDataForCrp(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Crp);
            var isEmpty = IsDataRowItemEmpty(dr[ColumnCrp]);
            string message;

            if (isEmpty && !isTestPurchasedByCustomer)
            {
                _logger.Info(string.Format("For Customer Id {0} - EventId {1}, no data for CRP", customerId, eventId));
                return;

            }

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0} - EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);

            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("CRP is not availed by CustomerId {0} - EventId {1}", customerId, eventId);
                AppendTestResultLog(log, message, false);
                _logger.Info(message);
            }
            else
            {
                var testResult = new CrpTestResult
                {
                    LCRP = new ResultReading<string>(ReadingLabels.LCRP)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnCrp].ToString()
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.Crp, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForTestosterone(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            var isEmpty = IsDataRowItemEmpty(dr[ColumnTestosterone]);
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Testosterone);
            string message;

            if (isEmpty && !isTestPurchasedByCustomer)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for Testosterone", customerId, eventId);
                _logger.Info(message);
                return;
            }

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for Testosterone", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("Testosterone is not availed by CustomerId {0} - Event id {1}", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message);
            }
            else
            {
                var testResult = new TestosteroneTestResult
                {
                    TESTSCRE = new ResultReading<string>(ReadingLabels.TESTSCRE)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnTestosterone].ToString()
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.Testosterone, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void ParseDataForVitaminD(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            var isEmpty = IsDataRowItemEmpty(dr[ColumnVitaminD]);
            var isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.VitaminD);
            string message;

            if (isEmpty && !isTestPurchasedByCustomer)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for VitaminD", customerId, eventId);
                _logger.Info(message);
                return;
            }

            if (isEmpty)
            {
                message = string.Format("For Customer Id {0}-Event Id {1}, no data for VitaminD", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else if (!isTestPurchasedByCustomer)
            {
                message = string.Format("VitaminD is not availed by CustomerId {0} - Event id {1}", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message);
            }
            else
            {
                var testResult = new VitaminDTestResult
                {
                    VitD = new ResultReading<string>(ReadingLabels.VitD)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnVitaminD].ToString()
                    }
                };
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog("", TestType.VitaminD, customerId, MedicalEquipmentTag.Bloodworks);
            }
        }

        private void AppendTestResultLog(BloodTestResultParserLog log, string message, bool isSuccessful = true)
        {
            if (!string.IsNullOrEmpty(message))
                log.Notes.Append(message).Append("\n");

            if (!isSuccessful)
                log.IsSuccessful = false;
            log.CreatedDate = DateTime.Now;

        }

        private BloodTestResultParserLog CreateBloodTestResultLog(DataRow dr)
        {
            return new BloodTestResultParserLog
            {
                CreatedDate = DateTime.Now,
                FirstName = DataRowValue(dr[ColumnFirstName]),
                LastName = DataRowValue(dr[ColumnLastname]),
                Dob = DataRowValue(dr[ColumnDob]),
                DrawDate = DataRowValue(dr[ColumnDrawDate])
            };
        }

        private void ParseDataForMenBloodPanel(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            string message;

            var isPsaEmpty = IsDataRowItemEmpty(dr[ColumnPsa]);
            ResultReading<string> psaResultReading = null;
            if (isPsaEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for PSA", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                psaResultReading = new ResultReading<string>(ReadingLabels.PSASCR)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnPsa].ToString()
                };
            }

            var isCrpEmpty = IsDataRowItemEmpty(dr[ColumnCrp]);
            ResultReading<string> crpResultResultReading = null;
            if (isCrpEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                crpResultResultReading = new ResultReading<string>(ReadingLabels.LCRP)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnCrp].ToString()
                };
            }

            var isTestosteroneEmpty = IsDataRowItemEmpty(dr[ColumnTestosterone]);
            ResultReading<string> testosteroneResultReading = null;
            if (isTestosteroneEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for Testosterone", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                testosteroneResultReading = new ResultReading<string>(ReadingLabels.TESTSCRE)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnTestosterone].ToString()
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

        private void ParseDataForWomenBloodPanel(DataRow dr, BloodTestResultParserLog log, long customerId, long eventId)
        {
            string message;

            var isThyroidEmpty = IsDataRowItemEmpty(dr[ColumnThyroid]);
            ResultReading<string> thyroidResultReading = null;
            if (isThyroidEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for TSH", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                thyroidResultReading = new ResultReading<string>(ReadingLabels.TSHSCR)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnThyroid].ToString()
                };
            }

            var isCrpEmpty = IsDataRowItemEmpty(dr[ColumnCrp]);
            ResultReading<string> crpResultResultReading = null;
            if (isCrpEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for CRP", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                crpResultResultReading = new ResultReading<string>(ReadingLabels.LCRP)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnCrp].ToString()
                };
            }

            var isVitaminDEmpty = IsDataRowItemEmpty(dr[ColumnVitaminD]);
            ResultReading<string> vitaminDResultResultReading = null;
            if (isVitaminDEmpty)
            {
                message = string.Format("For Customer Id {0} and EventId {1}, no data for VitaminD", customerId, eventId);
                _logger.Info(message);
                AppendTestResultLog(log, message, false);
            }
            else
            {
                vitaminDResultResultReading = new ResultReading<string>(ReadingLabels.VitD)
                {
                    ReadingSource = ReadingSource.Automatic,
                    Reading = dr[ColumnVitaminD].ToString()
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
    }
}
