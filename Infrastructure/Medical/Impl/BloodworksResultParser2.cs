using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodworksResultParser2 : IResultArchiveParser
    {
        private readonly string _bloodworkDirectoryPath;
        private readonly long _eventId;

        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IBloodworkAppLipidParser _bloodworkAppLipidParser;

        private readonly ILogger _logger;

        private List<EventCustomerScreeningAggregate> _eventCustomerScreeningAggregates;

        private readonly IRepository<BasicBiometric> _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly long _uploadedBy;

        public BloodworksResultParser2(long eventId, string bloodworkDirectoryPath, ILogger logger, IRepository<BasicBiometric> basicBiometricRepository, IEventCustomerRepository eventCustomerRepository, long uploadedBy, ILipidParserHelper lipidParserHelper)
        {
            _bloodworkDirectoryPath = bloodworkDirectoryPath;
            _eventId = eventId;
            _logger = logger;

            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
            _bloodworkAppLipidParser = new BloodworkAppLipidParser(_logger, lipidParserHelper);

            _eventCustomerScreeningAggregates = new List<EventCustomerScreeningAggregate>();

            _basicBiometricRepository = basicBiometricRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _uploadedBy = uploadedBy;
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var files = Directory.GetFiles(_bloodworkDirectoryPath, "*.xml");

            foreach (var filePath in files)
            {
                _logger.Info("----------------------- Starting for File " + filePath);
                long customerId = 0;
                try
                {
                    customerId = GetCustomerId(filePath);
                }
                catch (Exception ex)
                {
                    _logger.Info(ex.Message + "\n\n");
                    continue;
                }

                if (customerId < 1)
                {
                    _logger.Info("CustomerId not Found.\n\n");
                    continue;
                }

                try
                {
                    UpdateBloodPressure(filePath, customerId);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while Blood Pressure Data from XML into HIP. Message: " + ex.Message);
                }

                try
                {
                    ParseDataforLipid(customerId, filePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while checking Data for Lipid. Message: " + ex.Message);
                }

            }

            return _eventCustomerScreeningAggregates;
        }

        private long GetCustomerId(string filePath)
        {
            const string customerIdTagName = "patientid";

            var fileName = Path.GetFileNameWithoutExtension(filePath);

            long customerId;
            long.TryParse(fileName, out customerId);

            long customerIdFromFile = 0;
            var xDoc = new XmlDocument();
            xDoc.Load(filePath);

            var elementsForCustomerId = xDoc.GetElementsByTagName(customerIdTagName);
            if (elementsForCustomerId.Count > 0)
            {
                long.TryParse(elementsForCustomerId[0].InnerXml, out customerIdFromFile);
            }
            if (customerId == customerIdFromFile)
                return customerId;

            throw new Exception(string.Format("Customer Id mismatch between filename and patientid tag in the xml file for {0}.", customerId));
        }

        private void UpdateBloodPressure(string filePath, long customerId)
        {
            const string bpDiastolicTagNameString = "diastolic_bloodpressure";
            const string bpSystolicTagNameString = "systolic_bloodpressure";
            const string bpCaptureArmTagNameString = "arm_bloodpressure";

            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            _logger.Info(string.Format("Values from XML for BP for Customer [{0}] ------------------------------------------", customerId));



            int? diastolic = null;
            int? systolic = null;
            bool isRightArmBpMeasurement = false;

            var element = xDoc.GetElementsByTagName(bpDiastolicTagNameString);
            if (element.Count > 0)
            {
                int s;
                int.TryParse(element[0].InnerXml, out s);

                if (s > 0)
                {
                    diastolic = s;
                }
            }

            element = xDoc.GetElementsByTagName(bpSystolicTagNameString);
            if (element.Count > 0)
            {
                int s;
                int.TryParse(element[0].InnerXml, out s);

                if (s > 0)
                {
                    systolic = s;
                }
            }

            element = xDoc.GetElementsByTagName(bpCaptureArmTagNameString);
            if (element.Count > 0)
            {
                if (element[0].InnerXml.ToLower() == "right")
                    isRightArmBpMeasurement = true;

            }

            if (systolic.HasValue && diastolic.HasValue)
            {
                var eventCustomer = _eventCustomerRepository.Get(_eventId, customerId);

                var biometric = new BasicBiometric
                {
                    Id = eventCustomer.Id,
                    SystolicPressure = systolic,
                    DiastolicPressure = diastolic,
                    IsRightArmBpMeasurement = isRightArmBpMeasurement,
                    CreatedByOrgRoleUserId = _uploadedBy,
                    CreatedOn = DateTime.Now,
                    IsBloodPressureElevated = (systolic.Value >= 140 || diastolic.Value >= 90)
                };

                _basicBiometricRepository.Save(biometric);

                ParseDataForHypertension(customerId, biometric);
            }
        }

        private void ParseDataForHypertension(long customerId, BasicBiometric basicBiometric)
        {
            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Hypertension);

            try
            {
                if (isTestPurchased)
                {
                    var testResult = new HypertensionTestResult
                    {
                        Systolic = new ResultReading<int?> { Reading = basicBiometric.SystolicPressure },
                        Diastolic = new ResultReading<int?> { Reading = basicBiometric.DiastolicPressure },
                        RightArmBpMeasurement = new ResultReading<bool> { Reading = basicBiometric.IsRightArmBpMeasurement },
                        BloodPressureElevated = new ResultReading<bool> { Reading = basicBiometric.SystolicPressure >= 140 || basicBiometric.DiastolicPressure >= 90 }
                    };

                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                    _resultParserHelper.AddResultArchiveLog(_bloodworkAppLipidParser.ErrorSummary, TestType.Hypertension, customerId, MedicalEquipmentTag.Bloodworks, true);
                }
                else
                {
                    _logger.Info(string.Format("Hypertension is not availed by Customer : [{0}]", customerId));
                }
            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("Some error occured while parsing data of Hypertension Test for customerId {0} and event Id {1} \nMessage:{2} \nStack Trace: {3}", customerId, _eventId, exception.Message, exception.StackTrace));
            }
        }

        private void ParseDataforLipid(long customerId, string filePath)
        {

            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Lipid);
            try
            {
                if (isTestPurchased)
                {
                    var testResult = _bloodworkAppLipidParser.Parse(customerId, filePath, TestType.Lipid);
                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                    _resultParserHelper.AddResultArchiveLog(_bloodworkAppLipidParser.ErrorSummary, TestType.Lipid, customerId, MedicalEquipmentTag.Bloodworks, true);
                }
                else
                {
                    _logger.Info(string.Format("Lipid is not availed by Customer : [{0}]", customerId));
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some error occured while parsing data of Lipid Test for customerId {0} and event Id {1} \nMessage:{2} \nStack Trace: {3}", customerId, _eventId, exception.Message, exception.StackTrace));
            }


            isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Cholesterol);
            try
            {
                if (isTestPurchased)
                {
                    var testResult = _bloodworkAppLipidParser.Parse(customerId, filePath, TestType.Cholesterol);
                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                    _resultParserHelper.AddResultArchiveLog(_bloodworkAppLipidParser.ErrorSummary, TestType.Cholesterol, customerId, MedicalEquipmentTag.Bloodworks, true);
                }
                else
                {
                    _logger.Info(string.Format("Cholesterol is not availed by Customer : [{0}]", customerId));
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some error occured while parsing data of Cholesterol Test for customerId {0} and event Id {1} \nMessage:{2} \nStack Trace: {3}", customerId, _eventId, exception.Message, exception.StackTrace));
            }


            isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Diabetes);

            try
            {
                if (isTestPurchased)
                {
                    var testResult = _bloodworkAppLipidParser.Parse(customerId, filePath, TestType.Diabetes);
                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                    _resultParserHelper.AddResultArchiveLog(_bloodworkAppLipidParser.ErrorSummary, TestType.Diabetes, customerId, MedicalEquipmentTag.Bloodworks, true);
                }
                else
                {
                    _logger.Info(string.Format("Diabetes is not availed by Customer : [{0}]", customerId));
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some error occured while parsing data of Diabetes Test for customerId {0} and event Id {1} \nMessage:{2} \nStack Trace: {3}", customerId, _eventId, exception.Message, exception.StackTrace));
            }


        }
    }
}
