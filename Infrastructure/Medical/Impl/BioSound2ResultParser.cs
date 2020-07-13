using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSound2ResultParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private ILogger _logger;

        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;

        private const string ReportKindAaa = "abdominal";
        private const string ReportKindStroke = "vascular";
        private const string ReportKindEcho = "cardiac";
        private const string ReportKindThyroid = "thyroide";

        private const string ReportKindImt = "imt_qimt"; // fake one

        private const string ReportKindLead = "ids_vasc_car_l"; 

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public BioSound2ResultParser(string resultOutputPath, long eventId, ILogger logger)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _mediaRepository = new MediaRepository(new Settings());
            _logger = logger;
            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();

            foreach (var directory in Directory.GetDirectories(_resultOutputPath))
            {
                var filePaths = GetFolderPathfor(directory);

                long customerId = GetCustomerId(directory);

                foreach (var filePath in filePaths)
                {
                    try
                    {

                        ParseforFilePath(filePath, eventCustomerAggregates, customerId);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Bissound Parsing Error for xml file Name: " + filePath + "\n\t Message: " + ex.Message + " \n\t " + ex.StackTrace);
                    }

                }
            }

            return eventCustomerAggregates;
        }

        private string GetHeaderTypeFromFile(string reportXmlFilePath)
        {
            var xDoc = XDocument.Load(reportXmlFilePath);

            var headerNode = (from node in xDoc.Descendants("Report") select node).FirstOrDefault();
            if (headerNode != null && headerNode.Attribute("ReportKind") != null)
            {
                var reportKind = headerNode.Attribute("ReportKind").Value;
                if (!reportKind.ToLower().Contains(ReportKindStroke))
                    return reportKind;

                var countQimt = (from node in xDoc.Descendants("Page")
                                 where node.Attribute("Name") != null && node.Attribute("Name").Value.ToLower().Contains("qimt") && node.Attribute("isValid").Value.ToLower().Contains("true")
                                 select node).Count();

                if (countQimt > 0)
                {
                    return ReportKindImt;
                }

                var lead = (from node in xDoc.Descendants("Page")
                            where node.Attribute("ID") != null && node.Attribute("ID").Value.ToLower().Contains(ReportKindLead) && node.Attribute("isValid") != null && node.Attribute("isValid").Value.ToLower().Contains("false")
                            select node).ToArray();

                var countLead = lead.Count();

                if (countLead > 0)
                {
                    return ReportKindLead;
                }


                return reportKind;
            }

            return string.Empty;
        }

        private void ParseforFilePath(string filePath, List<EventCustomerScreeningAggregate> eventCustomerAggregates, long customerId)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var headerType = GetHeaderTypeFromFile(filePath).ToLower();

                var reportKind = "";

                if (headerType.Contains(ReportKindAaa)) reportKind = ReportKindAaa;
                else if (headerType.Contains(ReportKindStroke)) reportKind = ReportKindStroke;
                else if (headerType.Contains(ReportKindEcho)) reportKind = ReportKindEcho;
                else if (headerType.Contains(ReportKindThyroid)) reportKind = ReportKindThyroid;
                else if (headerType.Contains(ReportKindImt)) reportKind = ReportKindImt;
                else if (headerType.Contains(ReportKindLead)) reportKind = ReportKindLead;

                if (!string.IsNullOrEmpty(headerType) && customerId > 0)
                {
                    var mediaFilePath = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId);
                    switch (reportKind)
                    {
                        case ReportKindAaa:

                            bool isPpAaaPurchased = false;
                            bool isHcpAaaPurchased = false;
                            bool isAwvAaaPurchased = false;
                            try
                            {
                                _logger.Info("\n\n ===================> AAA Parsing for CustomerId : " + customerId + "\n");

                                bool isAaaPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AAA);
                                isPpAaaPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.PPAAA);
                                isHcpAaaPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.HCPAAA);
                                isAwvAaaPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvAAA);

                                if (!isAaaPurchased && !isPpAaaPurchased && !isHcpAaaPurchased && !isAwvAaaPurchased)
                                {
                                    _logger.Info("AAA is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }
                                ITestParser aaaParser = null;
                                if (isPpAaaPurchased)
                                {
                                    aaaParser = new BioSound2PpAaaParser(filePath, mediaFilePath.PhysicalPath, _logger);

                                    var ppAaaTestResult = aaaParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, ppAaaTestResult);
                                    _resultParserHelper.AddResultArchiveLog(aaaParser.ErrorSummary, TestType.PPAAA, customerId, MedicalEquipmentTag.BioSound2);
                                }
                                else if (isHcpAaaPurchased)
                                {
                                    aaaParser = new BioSound2HcpAaaParser(filePath, mediaFilePath.PhysicalPath, _logger);

                                    var hcpAaaTestResult = aaaParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, hcpAaaTestResult);
                                    _resultParserHelper.AddResultArchiveLog(aaaParser.ErrorSummary, TestType.HCPAAA, customerId, MedicalEquipmentTag.BioSound2);
                                }
                                else if (isAwvAaaPurchased)
                                {
                                    aaaParser = new BioSound2AwvAaaParser(filePath, mediaFilePath.PhysicalPath, _logger, _eventId, customerId);

                                    var awvAaaTestResult = aaaParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, awvAaaTestResult);
                                    _resultParserHelper.AddResultArchiveLog(aaaParser.ErrorSummary, TestType.AwvAAA, customerId, MedicalEquipmentTag.BioSound2);
                                }

                                if (isAaaPurchased)
                                {
                                    aaaParser = new BioSound2AaaParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                    var aaaTestResult = aaaParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, aaaTestResult);
                                    _resultParserHelper.AddResultArchiveLog(aaaParser.ErrorSummary, TestType.AAA, customerId, MedicalEquipmentTag.BioSound2);
                                }

                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, (isPpAaaPurchased ? TestType.PPAAA :
                                                    (isHcpAaaPurchased ? TestType.HCPAAA :
                                                    (isAwvAaaPurchased ? TestType.AwvAAA : TestType.AAA))), customerId, MedicalEquipmentTag.BioSound2, false);
                            }
                            break;

                        case ReportKindEcho:
                            var testEchoType = TestType.Echocardiogram;
                            try
                            {
                                _logger.Info("\n\n ===================> Echo Parsing for CustomerId : " + customerId + "\n");

                                var isEchoPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Echocardiogram);
                                var isPpEchoPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.PPEcho);
                                var isHcpEchoPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.HCPEcho);
                                var isAwvEchoPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvEcho);


                                if (!isEchoPurchasedByCustomer && !isPpEchoPurchasedByCustomer && !isHcpEchoPurchasedByCustomer && !isAwvEchoPurchasedByCustomer)
                                {
                                    _logger.Info("Echocardiogram is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }

                                if (isPpEchoPurchasedByCustomer)
                                {
                                    testEchoType = TestType.PPEcho;
                                }
                                else if (isHcpEchoPurchasedByCustomer)
                                {
                                    testEchoType = TestType.HCPEcho;
                                }
                                else if (isAwvEchoPurchasedByCustomer)
                                {
                                    testEchoType = TestType.AwvEcho;
                                }

                                ITestParser echoParser = new BioSound2EchoParser(filePath, mediaFilePath.PhysicalPath, _logger, testEchoType);
                                var echoTestResult = echoParser.Parse();
                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, echoTestResult);
                                _resultParserHelper.AddResultArchiveLog(echoParser.ErrorSummary, testEchoType, customerId, MedicalEquipmentTag.BioSound2);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, testEchoType, customerId, MedicalEquipmentTag.BioSound2, false);
                            }
                            break;

                        case ReportKindStroke:

                            bool isHcpCarotidPurchased = false;
                            bool isAwvCarotidPurchased = false;
                            try
                            {
                                _logger.Info("\n\n ===================> Stroke Parsing for CustomerId : " + customerId + "\n");
                                bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Stroke);
                                isHcpCarotidPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.HCPCarotid);
                                isAwvCarotidPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AwvCarotid);
                                if (!isTestPurchasedByCustomer && !isHcpCarotidPurchased && !isAwvCarotidPurchased)
                                {
                                    _logger.Info("Stroke is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }

                                if (isHcpCarotidPurchased)
                                {
                                    ITestParser hcpCarotidParser = new BioSound2HcpCarotidParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                    var hcpCarotidTestResult = hcpCarotidParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, hcpCarotidTestResult);
                                    _resultParserHelper.AddResultArchiveLog(hcpCarotidParser.ErrorSummary, TestType.HCPCarotid, customerId, MedicalEquipmentTag.BioSound2);
                                }
                                else if (isAwvCarotidPurchased)
                                {
                                    ITestParser awvCarotidParser = new BioSound2AwvCarotidParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                    var hcpCarotidTestResult = awvCarotidParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, hcpCarotidTestResult);
                                    _resultParserHelper.AddResultArchiveLog(awvCarotidParser.ErrorSummary, TestType.AwvCarotid, customerId, MedicalEquipmentTag.BioSound2);
                                }
                                else
                                {
                                    ITestParser strokeParser = new BioSound2StrokeParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                    var strokeTestResult = strokeParser.Parse();
                                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, strokeTestResult);
                                    _resultParserHelper.AddResultArchiveLog(strokeParser.ErrorSummary, TestType.Stroke, customerId, MedicalEquipmentTag.BioSound2);
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, isHcpCarotidPurchased ? TestType.HCPCarotid : (isAwvCarotidPurchased ? TestType.AwvCarotid : TestType.Stroke), customerId, MedicalEquipmentTag.BioSound2, false);
                            }
                            break;
                        case ReportKindLead:
                            try
                            {
                                _logger.Info("\n\n ===================> Lead Parsing for CustomerId : " + customerId + "\n");
                                bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Lead);
                                if (!isTestPurchasedByCustomer)
                                {
                                    _logger.Info("Lead is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }

                                ITestParser leadParser = new BioSound2LeadParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                var leadTestResult = leadParser.Parse();
                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, leadTestResult);
                                _resultParserHelper.AddResultArchiveLog(leadParser.ErrorSummary, TestType.Lead, customerId, MedicalEquipmentTag.BioSound2);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.Lead, customerId, MedicalEquipmentTag.BioSound2, false);
                            }
                            break;
                        case ReportKindThyroid:
                            try
                            {
                                _logger.Info("\n\n ===================> Thyroid Parsing for CustomerId : " + customerId + "\n");
                                bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Thyroid);
                                if (!isTestPurchasedByCustomer)
                                {
                                    _logger.Info("Thyroid is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }

                                ITestParser thyroidParser = new BioSound2ThyroidParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                var thyroidTestResult = thyroidParser.Parse();
                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, thyroidTestResult);
                                _resultParserHelper.AddResultArchiveLog(thyroidParser.ErrorSummary, TestType.Thyroid, customerId, MedicalEquipmentTag.BioSound);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.Thyroid, customerId, MedicalEquipmentTag.BioSound, false);
                            }
                            break;


                        case ReportKindImt:
                            try
                            {
                                _logger.Info("\n\n ===================> IMT Parsing for CustomerId : " + customerId + "\n");
                                bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.IMT);
                                if (!isTestPurchasedByCustomer)
                                {
                                    _logger.Info("IMT is not availed by CustomerId[" + customerId + "]. But is recorded for. Not parsing the record. \n");
                                    break;
                                }

                                ITestParser imtParser = new BioSound2ImtParser(filePath, mediaFilePath.PhysicalPath, _logger);
                                var imtTestResult = imtParser.Parse();
                                _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, imtTestResult);
                                _resultParserHelper.AddResultArchiveLog(imtParser.ErrorSummary, TestType.IMT, customerId, MedicalEquipmentTag.BioSound);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("System Failure! Error: " + ex.Message + " \n\t " + ex.StackTrace);
                                _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.IMT, customerId, MedicalEquipmentTag.BioSound, false);
                            }
                            break;
                    }
                }
            }
        }

        private static IEnumerable<string> GetFolderPathfor(string toFindinFolder)
        {
            var files = Directory.GetFiles(toFindinFolder, "measure.xml");
            if (files.Length > 0) return files;

            foreach (string directory in Directory.GetDirectories(toFindinFolder))
            {
                var path = GetFolderPathfor(directory);
                if (path.Any()) files = files.Concat(path).ToArray();
            }

            return files;
        }

        private long GetCustomerId(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) return 0;

            var dInfo = new DirectoryInfo(directoryPath.ToLower()).Name.ToLower();
            var temp = dInfo.Substring(dInfo.IndexOf("_id_") + 4);

            var customerIdString = temp.Substring(0, temp.IndexOf("_"));

            long customerId;

            long.TryParse(customerIdString, out customerId);

            return customerId;
        }

    }
}