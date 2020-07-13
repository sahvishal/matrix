using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Scheduling.Services;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class KynResultParser : IResultArchiveParser
    {
        private string _kynRawDataRepositoryPath;
        private string _kynIntegrationOutputDataPath;

        private readonly string _kynDirectoryPath;
        private readonly string _eventFilesPath;
        private readonly string _corpCode;
        private readonly long _eventId;
        private readonly long _archiveId;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IKynAppLipidParser _kynAppLipidParser;

        private const string BiomarkerTagName = "biomarker";
        private const string NameAttrString = "name";
        private const string ValueAttrString = "value";

        const string BirthYearAttrNameString = "BIRTH_YEAR";
        const string BirthMonthAttrNameString = "BIRTH_MONTH";
        const string BirthDayAttrNameString = "BIRTH_DAY";

        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private List<EventCustomerScreeningAggregate> _eventCustomerScreeningAggregates;

        private readonly IRepository<BasicBiometric> _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly long _uploadedBy;
        private readonly MediaRepository _mediaRepository;
        private readonly ICustomerService _customerService;

        public KynResultParser(long eventId, string corpCode, long archiveId, string kynDirectoryPath, ISettings settings, ILogger logger, ICustomerRepository customerRepository,
            IRepository<BasicBiometric> basicBiometricRepository, IEventCustomerRepository eventCustomerRepository, long uploadedBy,
            ILipidParserHelper lipidParserHelper, ICustomerService customerService)
        {
            _kynDirectoryPath = kynDirectoryPath;
            _eventId = eventId;
            _archiveId = archiveId;
            _corpCode = corpCode;

            _testResultService = new Service.TestResultService();
            _mediaRepository = new MediaRepository(settings);

            var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId);
            _kynIntegrationOutputDataPath = location.PhysicalPath;

            location = _mediaRepository.GetScannedDocumentStorageFileLocation(eventId);
            _eventFilesPath = location.PhysicalPath;

            _resultParserHelper = new ResultParserHelper();

            _customerRepository = customerRepository;
            _logger = logger;
            _kynAppLipidParser = new KynAppLipidParser(_logger, BiomarkerTagName, NameAttrString, ValueAttrString, lipidParserHelper);

            _eventCustomerScreeningAggregates = new List<EventCustomerScreeningAggregate>();

            _basicBiometricRepository = basicBiometricRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _uploadedBy = uploadedBy;
           
            _customerService = customerService;
        }



        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            try
            {
                InitializeGlobalPathForKynVariables(_eventId);
            }
            catch (Exception ex)
            {
                _logger.Error("Some exception while Initialize Global Path. Message: " + ex.Message);
                _logger.Error("Some exception while Initialize Global Path. stack Trace: " + ex.StackTrace);
            }

            try
            {
                MoveHtmlFilestoEventFilesDirectory();
            }
            catch (Exception ex)
            {
                _logger.Error("Some exception while moving Html files. Message: " + ex.Message);
            }

            var files = Directory.GetFiles(_kynDirectoryPath, "*.xml");

            foreach (var filePath in files)
            {
                _logger.Info("----------------------- Starting for File " + filePath);
                var customerId = GetCustomerIdAndCorrectXml(filePath);
                if (customerId < 1)
                {
                    _logger.Info("CustomerId not Found.\n\n");
                    continue;
                }

                try
                {
                    SyncXmlandCustomerDatainDb(filePath, customerId);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while Syncing Customer Data from XML into HIP. Message: " + ex.Message);
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
                    ParseDataforKyn(customerId, filePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while checking Data for KYN. Message: " + ex.Message);
                }

                try
                {
                    ParseDataforLipid(customerId, filePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while checking Data for Lipid. Message: " + ex.Message);
                }

                try
                {
                    ParseDataforCholesterol(customerId, filePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while checking Data for Cholesterol. Message: " + ex.Message);
                }

                try
                {
                    ParseDataforDiabetes(customerId, filePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some exception while checking Data for Diabetes. Message: " + ex.Message);
                }
            }

            Directory.Move(_kynDirectoryPath, _kynRawDataRepositoryPath + _archiveId);

            GenerateMetadataXml();

            return _eventCustomerScreeningAggregates;
        }

        private void InitializeGlobalPathForKynVariables(long eventId)
        {
            var location = _mediaRepository.GetKynRawDataRepositoryLocation();
            _kynRawDataRepositoryPath = location.PhysicalPath;

            //location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId);
            //_kynIntegrationOutputDataPath = location.PhysicalPath;

        }

        private void MoveHtmlFilestoEventFilesDirectory()
        {
            if (!Directory.Exists(_eventFilesPath))
                Directory.CreateDirectory(_eventFilesPath);

            var directories = Directory.GetDirectories(_kynDirectoryPath);
            foreach (var directory in directories)
            {
                var dirName = Path.GetFileName(directory);
                if (Directory.Exists(_eventFilesPath + dirName)) Directory.Delete(_eventFilesPath + dirName);

                Directory.Move(directory, _eventFilesPath + dirName);
            }

            var filesHtml = Directory.GetFiles(_kynDirectoryPath, "*.html");

            foreach (var filePath in filesHtml)
            {
                if (!File.Exists(filePath)) continue;

                var fileName = Path.GetFileName(filePath);
                if (File.Exists(_eventFilesPath + fileName)) File.Delete(_eventFilesPath + fileName);

                File.Move(filePath, _eventFilesPath + fileName);
            }

            var filesHtm = Directory.GetFiles(_kynDirectoryPath, "*.htm");
            foreach (var filePath in filesHtm)
            {
                if (!File.Exists(filePath)) continue;

                var fileName = Path.GetFileName(filePath);
                if (File.Exists(_eventFilesPath + fileName)) File.Delete(_eventFilesPath + fileName);

                File.Move(filePath, _eventFilesPath + fileName);
            }

        }

        private void ParseDataforKyn(long customerId, string filePath)
        {
            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Kyn);

            if (isTestPurchased)
            {
                _logger.Info(string.Format("Found Customer : [{0}]", customerId));
                _resultParserHelper.AddResultArchiveLog("", TestType.Kyn, customerId, MedicalEquipmentTag.KynDataProcessor, true);
            }
            else
            {
                _logger.Info(string.Format("KYN is not availed by Customer : [{0}]", customerId));
                File.Delete(filePath);
            }
        }

        private void ParseDataforLipid(long customerId, string filePath)
        {
            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Lipid);

            if (isTestPurchased)
            {
                var testResult = _kynAppLipidParser.Parse(customerId, filePath, TestType.Lipid);
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog(_kynAppLipidParser.ErrorSummary, TestType.Lipid, customerId, MedicalEquipmentTag.KynDataProcessor, true);
            }
            else
            {
                _logger.Info(string.Format("Lipid is not availed by Customer : [{0}]", customerId));
            }

        }

        private long GetCustomerIdAndCorrectXml(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            long customerId;
            long.TryParse(fileName, out customerId);
            long customerIdfromFile = customerId;

            try
            {
                CorrectXml(filePath, ref customerIdfromFile);
            }
            catch (Exception ex)
            {
                _logger.Error("Error while correcting XML for file: " + filePath + ". Message: " + ex.Message);
            }

            if (customerIdfromFile > 0) customerId = customerIdfromFile;

            return customerId;
        }

        public void CorrectXml(string filePath, ref long customerId)
        {
            const string recordsTagName = "record";
            const string uniqueIdAttr = "uniqueId";
            const string participantPrimaryKey = "participantPrimaryKey";
            const string firstNameAttr = "firstName";
            const string lastNameAttr = "lastName";
            const string groupNameAttr = "groupName";

            long customerIdFromFile = 0;
            var xDoc = new XmlDocument();
            xDoc.Load(filePath);

            xDoc.InnerXml = xDoc.InnerXml.Replace("bio:records", "bio:RecordsType");
            xDoc.Save(filePath);

            xDoc.Load(filePath);

            var elementsForCustomerId = xDoc.GetElementsByTagName(recordsTagName);
            if (elementsForCustomerId.Count > 0 && elementsForCustomerId[0].Attributes != null)
            {
                var node = elementsForCustomerId[0];

                if (node.Attributes[uniqueIdAttr] != null && !string.IsNullOrEmpty(node.Attributes[uniqueIdAttr].Value))
                {
                    long.TryParse(node.Attributes[uniqueIdAttr].Value.Trim(), out customerIdFromFile);
                }

                Customer customer = null;
                if (customerIdFromFile > 0)
                {
                    customerId = customerIdFromFile;
                }

                try
                {
                    customer = _customerRepository.GetCustomer(customerId);
                }
                catch
                {
                    _logger.Error("Customer not found for ID: " + customerId);
                }

                if (node.Attributes[participantPrimaryKey] != null)
                {
                    node.Attributes[participantPrimaryKey].Value = customerId.ToString();
                }

                if (customer != null)
                {
                    if (node.Attributes[firstNameAttr] != null)
                    {
                        node.Attributes[firstNameAttr].Value = customer.Name.FirstName.ToUpper();
                    }
                    if (node.Attributes[lastNameAttr] != null)
                    {
                        node.Attributes[lastNameAttr].Value = customer.Name.LastName.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(customer.InsuranceId) && node.Attributes[uniqueIdAttr] != null)
                    {
                        node.Attributes[uniqueIdAttr].Value = customer.InsuranceId;
                    }
                }

                if (!string.IsNullOrEmpty(_corpCode) && node.Attributes[groupNameAttr] != null)
                {
                    node.Attributes[groupNameAttr].Value = _corpCode.Trim();
                }
            }

            var elements = xDoc.GetElementsByTagName(BiomarkerTagName);
            var childNodestoRemove = new List<XmlNode>();
            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null || element.Attributes.Count < 1)
                {
                    childNodestoRemove.Add(element);
                    continue;
                }

                if (element.Attributes[NameAttrString] == null || string.IsNullOrEmpty(element.Attributes[NameAttrString].Value))
                {
                    childNodestoRemove.Add(element);
                    continue;
                }

                if (element.Attributes[ValueAttrString] == null)
                {
                    var attr = xDoc.CreateAttribute(ValueAttrString);
                    element.Attributes.Append(attr);
                }

                if (string.IsNullOrEmpty(element.Attributes[ValueAttrString].Value))
                {
                    element.Attributes[ValueAttrString].Value = "0";
                }

                if (element.Attributes[ValueAttrString] != null)
                {
                    double result;
                    if (!double.TryParse(element.Attributes[ValueAttrString].Value, out result))
                    {
                        childNodestoRemove.Add(element);
                        continue;
                    }
                }
            }

            foreach (var xmlNode in childNodestoRemove)
            {
                xmlNode.ParentNode.RemoveChild(xmlNode);
            }

            xDoc.Save(filePath);
        }

        private void SyncXmlandCustomerDatainDb(string filePath, long customerId)
        {
            const string weightAttrNameString = "WEIGHT";
            const string heightAttrNameString = "HEIGHT";
            const string raceAttrNameString = "RACE";
            const string genderAttrNameString = "SEX";

            var xDoc = new XmlDocument();
            xDoc.Load(filePath);

            _logger.Info(string.Format("Values from XML for Customer [{0}] ------------------------------------------", customerId));
            var elements = xDoc.GetElementsByTagName(BiomarkerTagName);
            var customer = _customerRepository.GetCustomer(customerId);

            var dobFromFile = GetDobfromXml(elements);
            if (dobFromFile != null)
            {
                if (customer.DateOfBirth == null) customer.DateOfBirth = dobFromFile;
                else if (customer.DateOfBirth.Value.Date != dobFromFile.Value.Date)
                {
                    _logger.Info("Found different values for DOB. HIP Value: " + customer.DateOfBirth.Value.ToShortDateString() + " and XML Value: " + dobFromFile.Value.ToShortDateString());
                    UpdateDobfromXml(customer.DateOfBirth.Value.Date, elements);
                }
            }
            else if (customer.DateOfBirth != null)
            {
                UpdateDobfromXml(customer.DateOfBirth.Value.Date, elements);
            }

            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null || element.Attributes[NameAttrString] == null || element.Attributes[ValueAttrString] == null || string.IsNullOrEmpty(element.Attributes[NameAttrString].Value) ||
                    string.IsNullOrEmpty(element.Attributes[ValueAttrString].Value))
                    continue;

                var valueAttr = element.Attributes[NameAttrString].Value.ToLower();
                if (valueAttr == weightAttrNameString.ToLower())
                {
                    double s;
                    double.TryParse(element.Attributes[ValueAttrString].Value, out s);
                    s = Math.Round(s, 2);

                    if (s > 0)
                    {
                        if (customer.Weight == null || customer.Weight.TotalPounds < 1) customer.Weight = new Weight(s);
                        else if (customer.Weight.TotalPounds != s)
                        {
                            _logger.Info("Found different values for Weight. HIP Value: " + customer.Weight.TotalPounds.ToString("0.00") + " and XML Value: " + s.ToString("0.00"));
                        }
                    }
                }

                if (valueAttr == heightAttrNameString.ToLower())
                {
                    double s;
                    double.TryParse(element.Attributes[ValueAttrString].Value, out s);
                    s = Math.Round(s, 2);

                    if (s > 0)
                    {
                        if (customer.Height == null || customer.Height.TotalInches < 1)
                        {
                            customer.Height = new Height { TotalInches = s };
                        }
                        else if (customer.Height.TotalInches != s)
                        {
                            _logger.Info("Found different values for Height. HIP Value: " + customer.Height.TotalInches.ToString("0.00") + " and XML Value: " + s.ToString("0.00"));
                        }
                    }
                }

                if (valueAttr == raceAttrNameString.ToLower())
                {
                    //TODO: Need reply from Healthfair
                }

                if (valueAttr == genderAttrNameString.ToLower())
                {
                    int s;
                    if (int.TryParse(element.Attributes[ValueAttrString].Value, out s))
                    {
                        if (s >= 0 && s < 2)
                        {
                            if (customer.Gender == Gender.Unspecified)
                            {
                                customer.Gender = s == 0 ? Gender.Male : Gender.Female;
                            }
                            else if (s == 0 && customer.Gender == Gender.Female)
                            {
                                _logger.Info("Found different values for Gender. HIP Value: Female and XML Value: Male");
                            }
                            else if (s == 1 && customer.Gender == Gender.Male)
                            {
                                _logger.Info("Found different values for Gender. HIP Value: Male and XML Value: Female");
                            }
                        }
                    }
                }
            }

            _customerService.SaveCustomer(customer, _uploadedBy);
            xDoc.Save(filePath);//to update DOB from HIP
        }

        private static DateTime? GetDobfromXml(XmlNodeList elements)
        {
            int day, month, year;
            day = month = year = 0;

            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null || element.Attributes[NameAttrString] == null || element.Attributes[ValueAttrString] == null || string.IsNullOrEmpty(element.Attributes[NameAttrString].Value) || string.IsNullOrEmpty(element.Attributes[ValueAttrString].Value))
                    continue;

                var valueAttr = element.Attributes[NameAttrString].Value.ToLower();
                if (valueAttr == BirthYearAttrNameString.ToLower())
                {
                    int.TryParse(element.Attributes[ValueAttrString].Value, out year);
                }
                if (valueAttr == BirthMonthAttrNameString.ToLower())
                {
                    int.TryParse(element.Attributes[ValueAttrString].Value, out month);
                }
                if (valueAttr == BirthDayAttrNameString.ToLower())
                {
                    int.TryParse(element.Attributes[ValueAttrString].Value, out day);
                }
            }

            if (day < 1 || month < 1 || year < 1)
            {
                return null;
            }

            return new DateTime(year, month, day);
        }

        private static void UpdateDobfromXml(DateTime dobInDb, XmlNodeList elements)
        {
            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null || element.Attributes[NameAttrString] == null || element.Attributes[ValueAttrString] == null || string.IsNullOrEmpty(element.Attributes[NameAttrString].Value) || string.IsNullOrEmpty(element.Attributes[ValueAttrString].Value))
                    continue;

                var valueAttr = element.Attributes[NameAttrString].Value.ToLower();
                if (valueAttr == BirthYearAttrNameString.ToLower())
                {
                    element.Attributes[ValueAttrString].Value = dobInDb.Year.ToString();
                }
                if (valueAttr == BirthMonthAttrNameString.ToLower())
                {
                    element.Attributes[ValueAttrString].Value = dobInDb.Month.ToString();
                }
                if (valueAttr == BirthDayAttrNameString.ToLower())
                {
                    element.Attributes[ValueAttrString].Value = dobInDb.Day.ToString();
                }
            }

        }

        private void GenerateMetadataXml()
        {
            string xmlText = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <KynIntegrationMetaData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
            xmlText += "<ArchiveId>" + _archiveId + "</ArchiveId><EventId>" + _eventId + "</EventId><Status />";
            xmlText += "<DestinationFolderPath>" + _kynIntegrationOutputDataPath + "</DestinationFolderPath>";
            xmlText += "<ProcessStartTime>" + DateTime.Now.ToString("yyyy-MM-dd") + "</ProcessStartTime><ProcessEndTime>" + DateTime.Now.ToString("yyyy-MM-dd") + "</ProcessEndTime><CustomersDone/></KynIntegrationMetaData>";


            var doc = new XmlDocument();
            doc.LoadXml(xmlText);
            doc.Save(_kynRawDataRepositoryPath + _archiveId + ".xml");
        }

        private void UpdateBloodPressure(string filePath, long customerId)
        {
            const string bpDiastolicAttrNameString = "BLOOD_PRESSURE_DIASTOLIC";
            const string bpSystolicNameString = "BLOOD_PRESSURE_SYSTOLIC";
            const string bpCaptureArmAttrNameString = "BLOODPRESSURE_CAPTURE_ARM";

            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            _logger.Info(string.Format("Values from XML for BP for Customer [{0}] ------------------------------------------", customerId));

            var elements = xDoc.GetElementsByTagName(BiomarkerTagName);

            int? diastolic = null;
            int? systolic = null;
            bool isRightArmBpMeasurement = false;

            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null || element.Attributes[NameAttrString] == null || element.Attributes[ValueAttrString] == null || string.IsNullOrEmpty(element.Attributes[NameAttrString].Value) ||
                    string.IsNullOrEmpty(element.Attributes[ValueAttrString].Value))
                    continue;

                var valueAttr = element.Attributes[NameAttrString].Value.ToLower();
                if (valueAttr == bpDiastolicAttrNameString.ToLower())
                {
                    int s;
                    int.TryParse(element.Attributes[ValueAttrString].Value, out s);

                    if (s > 0)
                    {
                        diastolic = s;
                    }
                }

                if (valueAttr == bpSystolicNameString.ToLower())
                {
                    int s;
                    int.TryParse(element.Attributes[ValueAttrString].Value, out s);

                    if (s > 0)
                    {
                        systolic = s;
                    }
                }

                if (valueAttr == bpCaptureArmAttrNameString.ToLower())
                {
                    if (element.Attributes[ValueAttrString].Value.ToLower() == "right")
                        isRightArmBpMeasurement = true;
                }
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
                    _resultParserHelper.AddResultArchiveLog(_kynAppLipidParser.ErrorSummary, TestType.Hypertension, customerId, MedicalEquipmentTag.Bloodworks, true);
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

        private void ParseDataforCholesterol(long customerId, string filePath)
        {
            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Cholesterol);

            if (isTestPurchased)
            {
                var testResult = _kynAppLipidParser.Parse(customerId, filePath, TestType.Cholesterol);
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog(_kynAppLipidParser.ErrorSummary, TestType.Cholesterol, customerId, MedicalEquipmentTag.KynDataProcessor, true);
            }
            else
            {
                _logger.Info(string.Format("Cholesterol is not availed by Customer : [{0}]", customerId));
            }

        }

        private void ParseDataforDiabetes(long customerId, string filePath)
        {
            var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Diabetes);

            if (isTestPurchased)
            {
                var testResult = _kynAppLipidParser.Parse(customerId, filePath, TestType.Diabetes);
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, testResult);
                _resultParserHelper.AddResultArchiveLog(_kynAppLipidParser.ErrorSummary, TestType.Diabetes, customerId, MedicalEquipmentTag.KynDataProcessor, true);
            }
            else
            {
                _logger.Info(string.Format("Diabetes is not availed by Customer : [{0}]", customerId));
            }

        }


    }
}
