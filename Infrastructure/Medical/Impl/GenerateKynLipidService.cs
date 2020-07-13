using System;
using System.IO;
using System.Linq;
using System.Xml;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;
using Falcon.App.Core.Interfaces;
using System.Collections.Generic;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class GenerateKynLipidService : IGenerateKynLipidService
    {

        #region "Kyn Lipid Report properties & const"

        private const int TotalCholesterolMaxThreshold = 400;
        private const int TotalCholesterolMinThreshold = 100;
        private const long GlucoseMaxThreshold = 600;
        private const long GlucoseMinThreshold = 20;
        private const int HDLMaxThreshold = 100;
        private const int HDLMinThreshold = 15;
        private const long TriglyceridesMaxTheshold = 500;
        private const long TriglyceridesMinThreshold = 50;

        // private const string RangeBetween = "Between {0}-{1}";
        private const string RangeGreaterThan = "Greater than {0}";
        private const string RangeLessThan = "Less than {0}";

        private const string High = "High";
        private const string Normal = "Normal";
        private const string VHigh = "Very High";
        private const string Diabetes = "Diabetes";
        private const string HyperTension = "Hypertension {0}";
        private const string Overweight = "Overweight";
        private const string Obesity = "Obesity {0}";
        private const string Prehypertension = "Prehypertension";
        private const string Prediabetes = "Prediabetes";
        private const string BorderlineHigh = "Borderline High";
        private const string Optimal = "Optimal";
        private const string NearOptimal = "Near Optimal";
        private const string Desirable = "Desirable";
        private const string Low = "Low";
        private const string BorderLine = "Borderline";


        private const int TCAlertLevelHeigh = 240;
        private const int TCDesirable = 200;

        private const int HDLNormal = 60;
        private const int HDLAlertLow = 40;

        private const int LDLAlertOptimal = 100;
        private const int LDLAlertNearOptimal = 129;
        private const int LDLBorderlineHigh = 159;
        private const int LDLHigh = 189;

        private const int TriglyceridesNormal = 150;
        private const int TriglyceridesBorderLineHigh = 199;
        private const int TriglyceridesHigh = 499;

        private const int BloodGlucoseNormal = 100;
        private const int BloodGlucoseDiabetes = 126;

        private const int BloodPressureNormalSystolic = 120;
        private const int BloodPressureNormalDiastolic = 80;

        private const int BloodpressurePrehypertensionSystolic = 139;
        private const int BloodpressureprehypertensionDiastolic = 89;

        private const int Bloodpressurehypertension1Systoclic = 159;
        private const int Bloodpressurehypertension1Diastolic = 99;


        private const decimal BodymassIndexNormal = 25;
        private const decimal BodyMassindexOverWeight = 29.9m;
        private const decimal BodyMassIndexlobesity1 = 34.9m;
        private const decimal BodyMassIndexlobesity2 = 39.9m;

        private Gender _gender = Gender.Unspecified;
        private bool _showDisclaimer;

        #endregion

        #region "kyn xml helper properies"
        private long[] _personalHealthQuestionIds = { 145, 146, 147, 148, 149, 150, 151, 152 };
        private long[] _womenOnlyQuestionIds = { 153, 154, 155, 156, 157, 158 };
        private long[] _smokingQuestionIds = { 159, 160, 161, 162, 163, 164 };
        private long[] _medicationQuestionIds = { 165, 166, 167 };
        private long[] _lifeStyleQuestionIds = { 168, 169, 170, 171 };

        private const string HaaAnswerYesValue = "1";
        private const string HaaAnswerNoValue = "0";
        private const string HaaAnswerNotEvaluatedValue = "2";

        private const string FemaleGenderValue = "1";
        private const string MaleGenderValue = "0";

        private const string HaaAnswerYes = "yes";
        private const string HaaAnswerNo = "no";

        private const string LessThenOne = "1 or less";
        private const string TwotoFour = "2 - 4";
        private const string MorethanFive = "5 or more";

        private const string NormalIntensity = "normal";
        private const string ModerateIntensity = "moderate";
        private const string HardIntensity = "hard";
        #endregion

        private string _kynRawDataRepositoryPath;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ISettings _settings;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBasicBiometricRepository _basicBiometricRepository;
        private readonly IUserService _userService;
        private readonly IKynLabValuesRepository _kynLabValuesRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IEventRepository _eventRepository;
        private readonly string _imgPath;
        private MediaLocation _location;
        private readonly MediaRepository _mediaRepository;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;


        public GenerateKynLipidService(IEventCustomerRepository eventCustomerRepository, ISettings settings, ICustomerRepository customerRepository,
            IBasicBiometricRepository basicBiometricRepository, IUserService userService, IKynLabValuesRepository kynLabValuesRepository,
            IHealthAssessmentRepository healthAssessmentRepository, IEventRepository eventRepository, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _settings = settings;
            _customerRepository = customerRepository;
            _basicBiometricRepository = basicBiometricRepository;
            _userService = userService;
            _kynLabValuesRepository = kynLabValuesRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _eventRepository = eventRepository;
            _imgPath = _settings.TemplateImageLocation;
            _mediaRepository = new MediaRepository(settings);
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;

        }

        #region "helper methods"
        #region "Reading Range Methods"
        private string CalculateTcReadingRange(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            var result = reading.ToString();

            if (reading > TotalCholesterolMaxThreshold)
            {
                result = string.Format(RangeGreaterThan, TotalCholesterolMaxThreshold);
                _showDisclaimer = true;
            }
            if (reading < TotalCholesterolMinThreshold)
            {
                result = string.Format(RangeLessThan, TotalCholesterolMinThreshold);
                _showDisclaimer = false;
            }

            return result;
        }

        private string CalculateHDLReadingRange(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            var result = reading.ToString();

            if (reading > HDLMaxThreshold)
            {
                result = string.Format(RangeGreaterThan, HDLMaxThreshold);
                _showDisclaimer = true;
            }
            if (reading < HDLMinThreshold)
            {
                result = string.Format(RangeLessThan, HDLMinThreshold);
                _showDisclaimer = true;
            }

            return result;
        }

        private string CalculateGlucoseRange(int reading)
        {
            var result = reading.ToString();

            if (reading > GlucoseMaxThreshold)
            {
                result = string.Format(RangeGreaterThan, GlucoseMaxThreshold);
                _showDisclaimer = true;
            }
            if (reading < GlucoseMinThreshold)
            {
                result = string.Format(RangeLessThan, GlucoseMinThreshold);
                _showDisclaimer = true;
            }

            return result;
        }

        private string CalculateTriglyceridesRange(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            var result = reading.ToString();

            if (reading > TriglyceridesMaxTheshold)
            {
                result = string.Format(RangeGreaterThan, TriglyceridesMaxTheshold);
                _showDisclaimer = true;
            }
            if (reading < TriglyceridesMinThreshold)
            {
                result = string.Format(RangeLessThan, TriglyceridesMinThreshold);
                _showDisclaimer = true;
            }

            return result;
        }
        #endregion

        #region "Alert Level Method"
        private string TCAlertLevel(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            if (reading < TCDesirable)
                return Desirable;

            if (reading >= TCDesirable && reading < TCAlertLevelHeigh)
                return BorderlineHigh;

            return High;
        }

        private string BloodGlucoseAlert(int reading)
        {
            if (reading < BloodGlucoseNormal)
                return Normal;
            if (reading >= BloodGlucoseNormal && reading < BloodGlucoseDiabetes)
                return Prediabetes;

            return Diabetes;
        }

        private string LDLAlertLevel(int reading)
        {
            if (reading < LDLAlertOptimal)
                return Optimal;
            if (reading >= LDLAlertOptimal && reading < LDLAlertNearOptimal)
                return NearOptimal;

            if (reading >= LDLAlertNearOptimal && reading < LDLBorderlineHigh)
                return BorderlineHigh;
            if (reading >= LDLBorderlineHigh && reading < LDLHigh)
                return High;

            return VHigh;
        }

        private string HDLAlerrtLevel(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            if (reading >= HDLNormal)
                return Normal;
            if (reading < HDLNormal && reading > HDLAlertLow)
                return BorderLine;

            return Low;

        }

        private string TriglyceridesAlertLevel(string value)
        {
            int reading;
            int.TryParse(value, out reading);

            if (reading < TriglyceridesNormal)
                return Normal;
            if (reading >= TriglyceridesNormal && reading < TriglyceridesBorderLineHigh)
                return BorderlineHigh;

            if (reading >= TriglyceridesBorderLineHigh && reading < TriglyceridesHigh)
                return High;

            return VHigh;

        }

        private string BloodPressureAlertLevel(int? systolic, int? diatolic)
        {
            if (!systolic.HasValue && !diatolic.HasValue)
                return string.Empty;

            if (systolic < BloodPressureNormalSystolic && diatolic < BloodPressureNormalDiastolic)
                return Normal;

            if (systolic < BloodpressurePrehypertensionSystolic && diatolic < BloodpressureprehypertensionDiastolic)
                return Prehypertension;

            if (systolic < BloodpressurePrehypertensionSystolic && diatolic < BloodpressureprehypertensionDiastolic)
                return Prehypertension;

            if (systolic < Bloodpressurehypertension1Systoclic && diatolic < Bloodpressurehypertension1Diastolic)
                return string.Format(HyperTension, "I");

            return string.Format(HyperTension, "II");
        }

        private string BMIAlertLevel(decimal bmiIndex)
        {
            if (bmiIndex < BodymassIndexNormal)
                return Normal;
            if (bmiIndex >= BodymassIndexNormal && bmiIndex < BodyMassindexOverWeight)
                return Overweight;
            if (bmiIndex >= BodyMassindexOverWeight && bmiIndex < BodyMassIndexlobesity1)
                return string.Format(Obesity, "I");
            if (bmiIndex >= BodyMassIndexlobesity1 && bmiIndex < BodyMassIndexlobesity2)
                return string.Format(Obesity, "II");

            return string.Format(Obesity, "III");
        }

        #endregion

        #region "KynXML helper methods"

        private int GetFastingStatus(FastingStatus value)
        {
            var result = 0;
            switch (value)
            {
                case FastingStatus.Fasting:
                    result = 1;
                    break;
                case FastingStatus.NonFasting:
                    result = 2;
                    break;
                case FastingStatus.Unknown:
                    result = 3;
                    break;
            }

            return result;
        }

        private string GetExerciseFrequency(string value)
        {
            var result = string.Empty;
            switch (value)
            {
                case LessThenOne:
                    result = "1";
                    break;

                case TwotoFour:
                    result = "2";
                    break;

                case MorethanFive:
                    result = "3";
                    break;
            }
            return result;
        }

        private string GetExerciseIntensity(string value)
        {
            var result = string.Empty;
            switch (value)
            {
                case NormalIntensity:
                    result = "1";
                    break;

                case ModerateIntensity:
                    result = "2";
                    break;

                case HardIntensity:
                    result = "3";
                    break;
            }

            return result;
        }

        private string GetRace(Race race)
        {
            var result = string.Empty;
            switch (race)
            {
                case Race.Caucasian:
                    result = "0";
                    break;
                case Race.AfricanAmerican:
                    result = "1";
                    break;
                case Race.Asian:
                    result = "2";
                    break;
                case Race.Hispanic:
                    result = "3";
                    break;
                case Race.NativeAmerican:
                    result = "4";
                    break;
                case Race.Other:
                case Race.DeclinesToReport:
                case Race.Latino:
                    result = "5";
                    break;
            }

            return result;

        }

        private string GetEkgAnswer(string anwer)
        {
            var result = HaaAnswerNotEvaluatedValue;
            switch (anwer)
            {
                case HaaAnswerYes:
                    result = HaaAnswerYesValue;
                    break;
                case HaaAnswerNo:
                    result = HaaAnswerNoValue;
                    break;
            }
            return result;
        }

        private string GetGender(Gender gender)
        {
            if (gender == Gender.Female) return FemaleGenderValue;
            if (gender == Gender.Male) return MaleGenderValue;
            return string.Empty;
        }
        #endregion

        private decimal BmiCalculator(double weightInPounds, double heightInInches)
        {
            var bmiIndex = (weightInPounds < 1 || heightInInches < 1) ? 0 : (weightInPounds / Math.Pow(heightInInches, 2)) * 703;
            return decimal.Parse(bmiIndex.ToString());
        }
        #endregion

        #region "Kyn & Lipid Only Generation Methods"
        public void GenerateLipidResult(string saveFilePath, long eventCustomerId)
        {
            if (!File.Exists(_settings.LipidTemplate)) return;
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);


            var basicBiometric = _basicBiometricRepository.Get(eventCustomerId);

            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            try
            {
                var doc = new HtmlDocument();
                doc.Load(_settings.LipidTemplate);

                var logoimgNode = doc.DocumentNode.SelectSingleNode("//img[@id='hflogo']");
                if (logoimgNode != null)
                    logoimgNode.SetAttributeValue("src", _imgPath + "hf_Logo.png");

                var seperator = doc.DocumentNode.SelectNodes("//img[@class='seperator-img']");

                if (seperator != null && seperator.Any())
                {
                    foreach (var nodes in seperator)
                    {
                        nodes.SetAttributeValue("src", _imgPath + "green_line.png");
                    }
                }

                var patientIdNode = doc.DocumentNode.SelectSingleNode("//label[@id='patientId']");
                if (patientIdNode != null) patientIdNode.InnerHtml = eventCustomer.CustomerId.ToString();

                var dateNode = doc.DocumentNode.SelectSingleNode("//label[@id='today-date']");
                if (dateNode != null) dateNode.InnerHtml = DateTime.Today.ToShortDateString();

                var patientNameNode = doc.DocumentNode.SelectSingleNode("//label[@id='patientname']");
                if (patientNameNode != null) patientNameNode.InnerHtml = customer.NameAsString;

                var bloodpressure = doc.DocumentNode.SelectSingleNode("//label[@id='blood-pressure-reading']");
                if (bloodpressure != null && basicBiometric != null && basicBiometric.DiastolicPressure.HasValue && basicBiometric.SystolicPressure.HasValue) bloodpressure.InnerHtml = basicBiometric.SystolicPressure + "/" +
                     basicBiometric.DiastolicPressure;

                FillLipidTestResult(doc, eventCustomer.CustomerId, eventCustomer.EventId, false);

                doc.Save(saveFilePath);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public void GenerateKynResult(string saveFilePath, long eventCustomerId)
        {
            if (!File.Exists(_settings.KynTemplate)) return;
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);

            var cutomerid = eventCustomer.CustomerId;
            var eventId = eventCustomer.EventId;
            var eventdetail = _eventRepository.GetById(eventId);
            var isNewResultFlow = eventdetail.EventDate >= _settings.ResultFlowChangeDate;

            var customer = _customerRepository.GetCustomer(cutomerid);

            _gender = customer.Gender;

            try
            {
                var doc = new HtmlDocument();
                doc.Load(_settings.KynTemplate);

                var logoimgNode = doc.DocumentNode.SelectSingleNode("//img[@id='hflogo']");
                if (logoimgNode != null)
                    logoimgNode.SetAttributeValue("src", _imgPath + "matrix_logo.png");

                var seperator = doc.DocumentNode.SelectNodes("//img[@class='seperator-img']");

                if (seperator != null && seperator.Any())
                {
                    foreach (var nodes in seperator)
                    {
                        nodes.SetAttributeValue("src", _imgPath + "green_line.png");
                    }
                }

                //var genderBaseQuestion = doc.DocumentNode.SelectSingleNode("//div[@id='patient-gender-type']");
                //if (genderBaseQuestion != null)
                //{
                //    genderBaseQuestion.SetAttributeValue("style", _isFemale ? "display:block" : "display:none");
                //}


                #region "Patient Basic infomartion"
                var patientNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-id']");

                foreach (var patientNode in patientNodes)
                {
                    patientNode.InnerHtml = eventCustomer.CustomerId.ToString();
                }

                patientNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-name']");

                foreach (var patientNode in patientNodes)
                {
                    patientNode.InnerHtml = customer.NameAsString;
                }

                patientNodes = doc.DocumentNode.SelectNodes("//label[@class='print-date']");

                foreach (var patientNode in patientNodes)
                {
                    patientNode.InnerHtml = DateTime.Today.ToShortDateString();
                }
                #endregion

                #region "BMIIndex height weight"

                var weight = customer.Weight;
                var height = customer.Height;

                var weighReadingNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-weight-lbs']");

                if (weighReadingNodes != null && weighReadingNodes.Any() && weight != null)
                {
                    foreach (var weighReadingNode in weighReadingNodes)
                    {
                        weighReadingNode.InnerHtml = weight.TotalPounds.ToString();
                    }
                }
                var waistNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-waist-in']");

                if (customer.Waist != null)
                {
                    foreach (var waistNode in waistNodes)
                    {
                        waistNode.InnerHtml = customer.Waist.Value.ToString("0.0");
                    }
                }

                var bmiIndexReadingCategory = doc.DocumentNode.SelectSingleNode("//img[@id='category-bmi']");
                if (bmiIndexReadingCategory != null)
                    bmiIndexReadingCategory.SetAttributeValue("src", _imgPath + "categoryBMI.png");

                if (height != null)
                {
                    var heightReadingFeetNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-h-ft']");
                    var heightReadingInchNodes = doc.DocumentNode.SelectNodes("//label[@class='patient-h-inch']");

                    foreach (var heightReadingFeetNode in heightReadingFeetNodes)
                    {
                        heightReadingFeetNode.InnerHtml = height.Feet.ToString();
                    }

                    foreach (var heightReadingInchNode in heightReadingInchNodes)
                    {
                        heightReadingInchNode.InnerHtml = height.Inches.ToString();
                    }
                }


                if (weight != null && height != null)
                {

                    var bmiIndex = BmiCalculator(weight.Pounds, height.TotalInches);

                    var bmiIndexReadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='bmi-reading']");
                    if (bmiIndexReadingNode != null) bmiIndexReadingNode.InnerHtml = bmiIndex.ToString("0.0");

                    var bmiIndexAlertReading = doc.DocumentNode.SelectSingleNode("//label[@id='bmi-alert-level']");
                    if (bmiIndexAlertReading != null) bmiIndexAlertReading.InnerHtml = BMIAlertLevel(bmiIndex);
                }



                #endregion

                #region "Personal Information"

                var dobNode = doc.DocumentNode.SelectSingleNode("//label[@id='dob-patient']");
                if (dobNode != null && customer.DateOfBirth.HasValue)
                    dobNode.InnerHtml = customer.DateOfBirth.Value.ToShortDateString();

                var genderNode = doc.DocumentNode.SelectSingleNode("//label[@id='patient-gender']");

                genderNode.InnerHtml = _gender.ToString();

                var ethnicgroupNode = doc.DocumentNode.SelectSingleNode("//label[@id='patient-ethnic-group']");

                if (ethnicgroupNode != null) ethnicgroupNode.InnerHtml = customer.Race.GetDescription();

                #endregion

                FillKynValues(doc, eventCustomerId, cutomerid, eventId, isNewResultFlow);
                // FillLipidTestResult(doc, cutomerid, eventId);
                FillBasicBiometricResult(doc, eventCustomerId);
                //FillHafQuestionResults(doc, cutomerid, eventId);
                //FillKynBaiscInfo(doc, eventCustomerId);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='kyn-disclaimer-div']");
                if (selectedNode != null && !_showDisclaimer)
                {
                    selectedNode.SetAttributeValue("style", "display:none");
                }

                doc.Save(saveFilePath);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        private void FillKynValues(HtmlDocument doc, long eventCustomerId, long customerId, long eventId, bool isNewResultFlow)
        {

            #region "set basic images"
            var bloodsugarCategory = doc.DocumentNode.SelectSingleNode("//img[@id='category-glucose']");
            if (bloodsugarCategory != null)
                bloodsugarCategory.SetAttributeValue("src", _imgPath + "categoryGlucose.png");

            var categoryTcNode = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-total']");
            if (categoryTcNode != null)
                categoryTcNode.SetAttributeValue("src", _imgPath + "categoryCholesterolTotal.png");

            var ldlCholdesterolCategoryImage = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-ldl']");
            if (ldlCholdesterolCategoryImage != null) ldlCholdesterolCategoryImage.SetAttributeValue("src", _imgPath + "categoryCholesterolLDL.png");

            var hdlCholesterolCategoryImg = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-hdl']");
            if (hdlCholesterolCategoryImg != null)
                hdlCholesterolCategoryImg.SetAttributeValue("src", _imgPath + "categoryCholesterolHDL.png");

            var triglyceridesCategoryImg = doc.DocumentNode.SelectSingleNode("//img[@id='category-triglycerides']");
            if (triglyceridesCategoryImg != null)
                triglyceridesCategoryImg.SetAttributeValue("src", _imgPath + "categoryTrig.png");

            var testResultRepository = new TestResultRepository();
            var eventTestPurchasedByCustomers = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);
            var isKynPurchsed = IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, eventTestPurchasedByCustomers.ToList());

            var isHKynPurchsed = IsTestPurchasedWithHealthAssessment((long)TestType.HKYN, eventTestPurchasedByCustomers.ToList());
            var isMyBioCheckAssessmentPurchsed = IsTestPurchasedWithHealthAssessment((long)TestType.MyBioCheckAssessment, eventTestPurchasedByCustomers.ToList());

            var labResult = isKynPurchsed ? _kynLabValuesRepository.Get(eventCustomerId, (long)TestType.Kyn) : ( isMyBioCheckAssessmentPurchsed ? _kynLabValuesRepository.Get(eventCustomerId, (long)TestType.MyBioCheckAssessment) : _kynLabValuesRepository.Get(eventCustomerId, (long)TestType.HKYN));
            if (labResult == null) return;
            TestResult testResult = null;

            if (isKynPurchsed)
            {
                testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.Kyn, isNewResultFlow);
            }
            else if (isHKynPurchsed)
            {
                testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.HKYN, isNewResultFlow);
            }
            else if (isMyBioCheckAssessmentPurchsed)
            {
                testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.MyBioCheckAssessment, isNewResultFlow);
            }

            var technicianName = string.Empty;

            var technicianNameNodes = doc.DocumentNode.SelectNodes("//label[@class='technician-name']");


            if (testResult != null && testResult.ConductedByOrgRoleUserId > 0)
            {
                var technician = _userService.GetUser(testResult.ConductedByOrgRoleUserId);
                technicianName = technician.NameAsString;
            }

            foreach (var tech in technicianNameNodes)
            {
                tech.InnerHtml = technicianName;
            }
            #endregion

            var tchol = 0;
            var hdl = 0;
            var tglycerides = 0;

            #region "Bloodsugar"

            if (labResult.Glucose != null && labResult.Glucose.HasValue)
            {
                var bloodSugarReading = doc.DocumentNode.SelectSingleNode("//label[@id='blood-sugar-reading']");
                if (bloodSugarReading != null)
                    bloodSugarReading.InnerHtml = CalculateGlucoseRange(labResult.Glucose.Value);

                var bloodSugarReadingalert = doc.DocumentNode.SelectSingleNode("//label[@id='blood-glucose-alert-level']");
                if (bloodSugarReadingalert != null)
                    bloodSugarReadingalert.InnerHtml = BloodGlucoseAlert(labResult.Glucose.Value);
            }

            #endregion

            #region "Total cholesterol"

            if (labResult.TotalCholesterol != null && labResult.TotalCholesterol.HasValue)
            {
                tchol = labResult.TotalCholesterol.Value;
                var totalCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='total-cholesterol-reading']");
                if (totalCholesterolNode != null)
                    totalCholesterolNode.InnerHtml = CalculateTcReadingRange(tchol.ToString());

                var totalCholesterolalertNode = doc.DocumentNode.SelectSingleNode("//label[@id='total-cholesterol-alert-level']");
                if (totalCholesterolalertNode != null && labResult.TotalCholesterol != null)
                    totalCholesterolalertNode.InnerHtml = TCAlertLevel(tchol.ToString());
            }


            #endregion

            #region "HDL Readings"

            if (labResult.Hdl != null && labResult.Hdl.HasValue)
            {
                hdl = labResult.Hdl.Value;
                var hdlCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='hdl-cholesterol-reading']");
                if (hdlCholesterolNode != null)
                    hdlCholesterolNode.InnerHtml = CalculateHDLReadingRange(hdl.ToString());

                var hdlCholesterolAlertNode = doc.DocumentNode.SelectSingleNode("//label[@id='hdl-cholesterol-alert-level']");
                if (hdlCholesterolAlertNode != null)
                    hdlCholesterolAlertNode.InnerHtml = HDLAlerrtLevel(hdl.ToString());
            }

            #endregion

            #region "Triglycerides"

            if (labResult.Triglycerides != null && labResult.Triglycerides.HasValue)
            {
                tglycerides = labResult.Triglycerides.Value;
                var triglycerides = doc.DocumentNode.SelectSingleNode("//label[@id='triglycerides-reading']");
                if (triglycerides != null)
                    triglycerides.InnerHtml = CalculateTriglyceridesRange(tglycerides.ToString());

                var triglyceridesAlertLevel = doc.DocumentNode.SelectSingleNode("//label[@id='triglycerides-alert-level']");
                if (triglyceridesAlertLevel != null)
                    triglyceridesAlertLevel.InnerHtml = TriglyceridesAlertLevel(tglycerides.ToString());
            }
            #endregion

            #region "LDL Cholesterol"

            var lipidTestResultRepository = new LipidTestRepository();
            var lipidTestResult = (LipidTestResult)lipidTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);

            if (lipidTestResult != null && lipidTestResult.LDL != null && lipidTestResult.LDL.Reading.HasValue)
            {
                var ldlCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-reading']");
                if (ldlCholesterolNode != null)
                    ldlCholesterolNode.InnerHtml = lipidTestResult.LDL.Reading.ToString();

                var ldlCholdesterolAlertNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-alert-level']");
                if (ldlCholdesterolAlertNode != null) ldlCholdesterolAlertNode.InnerHtml = LDLAlertLevel(lipidTestResult.LDL.Reading.Value);

                var kynldlreadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-ldl-cholesterol-reading']");
                if (kynldlreadingNode != null)
                    kynldlreadingNode.InnerHtml = lipidTestResult.LDL.Reading.Value.ToString();
            }
            else if (tchol > 0 && hdl > 0 && tglycerides > 0)
            {
                var ldl = tchol - hdl - (tglycerides / 5);

                var ldlCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-reading']");
                if (ldlCholesterolNode != null)
                    ldlCholesterolNode.InnerHtml = ldl.ToString();

                var ldlCholdesterolAlertNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-alert-level']");
                if (ldlCholdesterolAlertNode != null) ldlCholdesterolAlertNode.InnerHtml = LDLAlertLevel(ldl);

                var kynldlreadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-ldl-cholesterol-reading']");
                if (kynldlreadingNode != null)
                    kynldlreadingNode.InnerHtml = ldl.ToString();
            }

            #endregion


        }

        private void FillKynBaiscInfo(HtmlDocument doc, long eventCustomerId, long testId)
        {
            var labResult = _kynLabValuesRepository.Get(eventCustomerId, testId);
            if (labResult == null) return;

            if (labResult.FastingStatus.HasValue)
            {
                var fastingStatusNode = doc.DocumentNode.SelectSingleNode("//label[@id='fasting-status']");
                if (fastingStatusNode != null)
                    fastingStatusNode.InnerHtml = ((FastingStatus)labResult.FastingStatus).GetDescription();
            }

            if (labResult.Glucose.HasValue)
            {
                var glucoseReadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-glucose-reading']");
                if (glucoseReadingNode != null)
                    glucoseReadingNode.InnerHtml = labResult.Glucose.ToString();
            }

            if (labResult.TotalCholesterol.HasValue)
            {
                var tcReadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-total-cholesterol-reading']");
                if (tcReadingNode != null)
                    tcReadingNode.InnerHtml = labResult.TotalCholesterol.ToString();
            }

            if (labResult.Triglycerides.HasValue)
            {
                var triglyceridesNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-triglycerides-reading']");

                if (triglyceridesNode != null)
                    triglyceridesNode.InnerHtml = labResult.Triglycerides.ToString();
            }

            if (labResult.Hdl.HasValue)
            {
                var hdlNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-hdl-cholesterol-reading']");
                if (hdlNode != null)
                    hdlNode.InnerHtml = labResult.Hdl.ToString();
            }

        }

        private void FillBasicBiometricResult(HtmlDocument doc, long eventCustomerId)
        {
            var basicBiometric = _basicBiometricRepository.Get(eventCustomerId);

            var categorybloodrpressure = doc.DocumentNode.SelectSingleNode("//img[@id='category-blood-pressure']");
            if (categorybloodrpressure != null)
                categorybloodrpressure.SetAttributeValue("src", _imgPath + "categoryBP.png");

            if (basicBiometric == null)
                return;

            #region "Blood pressure reading -Basic Biometric"

            if (basicBiometric.DiastolicPressure.HasValue && basicBiometric.SystolicPressure.HasValue)
            {
                BloodPressureAlertLevel(basicBiometric.SystolicPressure, basicBiometric.DiastolicPressure);

                var bloodpressurereadings = doc.DocumentNode.SelectNodes("//label[@class='blood-pressure-reading']");

                if (bloodpressurereadings != null && bloodpressurereadings.Any())
                {
                    foreach (var bloodpressurereading in bloodpressurereadings)
                    {
                        if (bloodpressurereading != null)
                        {
                            bloodpressurereading.InnerHtml = basicBiometric.SystolicPressure + "/" + basicBiometric.DiastolicPressure;
                        }
                    }
                }

                var bloodpressureAlertReading = doc.DocumentNode.SelectSingleNode("//label[@id='blood-pressure-alert-level']");

                if (bloodpressureAlertReading != null)
                    bloodpressureAlertReading.InnerHtml = BloodPressureAlertLevel(basicBiometric.SystolicPressure, basicBiometric.DiastolicPressure);
            }



            #endregion

            var pulserateNode = doc.DocumentNode.SelectSingleNode("//label[@id='pulserate-reading']");
            if (pulserateNode != null && basicBiometric.PulseRate != null)
            {
                pulserateNode.InnerHtml = basicBiometric.PulseRate.ToString();
            }
        }

        public bool IsTestPurchasedWithHealthAssessment(long testId, List<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => et.Id == testId && et.HealthAssessmentTemplateId.HasValue);
            return isTestPurchased;
        }

        private void FillLipidTestResult(HtmlDocument doc, long customerId, long eventId, bool isForKyn = true)
        {
            var isNewResultFlow = _eventRepository.IsEventHasNewResultFlow(eventId);
            var lipidTestResultRepository = new LipidTestRepository();
            var lipidTestResult = (LipidTestResult)lipidTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);

            var testResultRepository = new TestResultRepository();

            var eventTestPurchasedByCustomers = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);

            var isKynPurchsed = IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, eventTestPurchasedByCustomers.ToList());
           
            TestResult testResult = null;

            if (isKynPurchsed)
            {
                testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.Kyn, isNewResultFlow);
            }
            else
            {
                testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.HKYN, isNewResultFlow);
            }

            var technicianName = string.Empty;

            if (isForKyn && testResult != null && testResult.ConductedByOrgRoleUserId > 0)
            {
                var technician = _userService.GetUser(testResult.ConductedByOrgRoleUserId);
                technicianName = technician.NameAsString;
            }
            if (!isForKyn && lipidTestResult != null && lipidTestResult.ConductedByOrgRoleUserId > 0)
            {
                var technician = _userService.GetUser(lipidTestResult.ConductedByOrgRoleUserId);
                technicianName = technician.NameAsString;
            }

            var technicianNameNodes = doc.DocumentNode.SelectNodes("//label[@class='technician-name']");

            foreach (var tech in technicianNameNodes)
            {
                tech.InnerHtml = technicianName;
            }

            var bloodsugarCategory = doc.DocumentNode.SelectSingleNode("//img[@id='category-glucose']");
            if (bloodsugarCategory != null)
                bloodsugarCategory.SetAttributeValue("src", _imgPath + "categoryGlucose.png");

            var categoryTcNode = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-total']");
            if (categoryTcNode != null)
                categoryTcNode.SetAttributeValue("src", _imgPath + "categoryCholesterolTotal.png");

            var ldlCholdesterolCategoryImage = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-ldl']");
            if (ldlCholdesterolCategoryImage != null) ldlCholdesterolCategoryImage.SetAttributeValue("src", _imgPath + "categoryCholesterolLDL.png");

            var hdlCholesterolCategoryImg = doc.DocumentNode.SelectSingleNode("//img[@id='category-cholesterol-hdl']");
            if (hdlCholesterolCategoryImg != null)
                hdlCholesterolCategoryImg.SetAttributeValue("src", _imgPath + "categoryCholesterolHDL.png");

            var triglyceridesCategoryImg = doc.DocumentNode.SelectSingleNode("//img[@id='category-triglycerides']");
            if (triglyceridesCategoryImg != null)
                triglyceridesCategoryImg.SetAttributeValue("src", _imgPath + "categoryTrig.png");

            if (lipidTestResult == null) return;

            #region "Bloodsugar"

            if (lipidTestResult.Glucose != null && lipidTestResult.Glucose.Reading.HasValue)
            {
                var bloodSugarReading = doc.DocumentNode.SelectSingleNode("//label[@id='blood-sugar-reading']");
                if (bloodSugarReading != null)
                    bloodSugarReading.InnerHtml = CalculateGlucoseRange(lipidTestResult.Glucose.Reading.Value);

                var bloodSugarReadingalert = doc.DocumentNode.SelectSingleNode("//label[@id='blood-glucose-alert-level']");
                if (bloodSugarReadingalert != null)
                    bloodSugarReadingalert.InnerHtml = BloodGlucoseAlert(lipidTestResult.Glucose.Reading.Value);
            }

            #endregion

            #region "Total cholesterol"

            if (lipidTestResult.TotalCholestrol != null)
            {
                var totalCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='total-cholesterol-reading']");
                if (totalCholesterolNode != null)
                    totalCholesterolNode.InnerHtml = CalculateTcReadingRange(lipidTestResult.TotalCholestrol.Reading);

                var totalCholesterolalertNode = doc.DocumentNode.SelectSingleNode("//label[@id='total-cholesterol-alert-level']");
                if (totalCholesterolalertNode != null && lipidTestResult.TotalCholestrol != null)
                    totalCholesterolalertNode.InnerHtml = TCAlertLevel(lipidTestResult.TotalCholestrol.Reading);
            }


            #endregion

            #region "LDL Cholesterol"

            if (lipidTestResult.LDL != null && lipidTestResult.LDL.Reading.HasValue)
            {
                var ldlCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-reading']");
                if (ldlCholesterolNode != null)
                    ldlCholesterolNode.InnerHtml = lipidTestResult.LDL.Reading.ToString();

                var ldlCholdesterolAlertNode = doc.DocumentNode.SelectSingleNode("//label[@id='ldl-cholesterol-alert-level']");
                if (ldlCholdesterolAlertNode != null) ldlCholdesterolAlertNode.InnerHtml = LDLAlertLevel(lipidTestResult.LDL.Reading.Value);

                var kynldlreadingNode = doc.DocumentNode.SelectSingleNode("//label[@id='kyn-ldl-cholesterol-reading']");
                if (kynldlreadingNode != null)
                    kynldlreadingNode.InnerHtml = lipidTestResult.LDL.Reading.Value.ToString();
            }

            #endregion

            #region "HDL Readings"

            if (lipidTestResult.HDL != null)
            {
                var hdlCholesterolNode = doc.DocumentNode.SelectSingleNode("//label[@id='hdl-cholesterol-reading']");
                if (hdlCholesterolNode != null)
                    hdlCholesterolNode.InnerHtml = CalculateHDLReadingRange(lipidTestResult.HDL.Reading);

                var hdlCholesterolAlertNode = doc.DocumentNode.SelectSingleNode("//label[@id='hdl-cholesterol-alert-level']");
                if (hdlCholesterolAlertNode != null)
                    hdlCholesterolAlertNode.InnerHtml = HDLAlerrtLevel(lipidTestResult.HDL.Reading);
            }



            #endregion

            #region "Triglycerides"

            if (lipidTestResult.TriGlycerides != null)
            {
                var triglycerides = doc.DocumentNode.SelectSingleNode("//label[@id='triglycerides-reading']");
                if (triglycerides != null)
                    triglycerides.InnerHtml = CalculateTriglyceridesRange(lipidTestResult.TriGlycerides.Reading);

                var triglyceridesAlertLevel = doc.DocumentNode.SelectSingleNode("//label[@id='triglycerides-alert-level']");
                if (triglyceridesAlertLevel != null)
                    triglyceridesAlertLevel.InnerHtml = TriglyceridesAlertLevel(lipidTestResult.TriGlycerides.Reading);
            }
            #endregion

        }

        private void FillHafQuestionResults(HtmlDocument document, long customerId, long eventId)
        {
            var healthAssessmentAnswers = _healthAssessmentRepository.Get(customerId, eventId);

            foreach (var haa in healthAssessmentAnswers)
            {
                var question = document.DocumentNode.SelectSingleNode("//span[@id='question-" + haa.QuestionId + "']");

                if (question != null) question.InnerHtml = haa.Answer;

            }
        }
        #endregion

        private void InitializeGlobalPathVariables(long eventId, DateTime eventDate, bool generatekynXml)
        {
            if (generatekynXml)
            {
                _location = _mediaRepository.GetKynRawDataRepositoryLocation();
                _kynRawDataRepositoryPath = _location.PhysicalPath;

                _kynRawDataRepositoryPath = string.Format("{0}{1}_{2}", _kynRawDataRepositoryPath, eventId, eventDate.ToString("yyyyMMdd"));
            }
            else
            {
                _location = _mediaRepository.GetHkynRawDataRepositoryLocation();
                _kynRawDataRepositoryPath = _location.PhysicalPath;

                _kynRawDataRepositoryPath = string.Format("{0}{1}_{2}", _kynRawDataRepositoryPath, eventId, eventDate.ToString("yyyyMMdd"));
            }

        }

        #region "haf Question For XML Generation"
        private void SetKynHealthAssessment(XmlDocument doc, long customerId, long eventId)
        {
            var healthAssessmentAnswers = _healthAssessmentRepository.Get(customerId, eventId);

            var sex = doc.SelectSingleNode("//record/biomarker[@name='SEX']");
            var isFemale = sex.Attributes["value"].Value == FemaleGenderValue;

            foreach (var haa in healthAssessmentAnswers)
            {
                if (_personalHealthQuestionIds.Contains(haa.QuestionId))
                {
                    SetPersonalHealtQuestionary(doc, haa);
                }
                if (_womenOnlyQuestionIds.Contains(haa.QuestionId) && isFemale)
                {
                    SetQuestoinForWomenOnly(doc, haa, false);
                }

                if (_lifeStyleQuestionIds.Contains(haa.QuestionId))
                {
                    SetLifeStyleQuestions(doc, haa);
                }

                if (_smokingQuestionIds.Contains(haa.QuestionId))
                {
                    ForSmokeMembersOnly(doc, haa, true);
                }

                if (_medicationQuestionIds.Contains(haa.QuestionId))
                {
                    ForMedication(doc, haa);
                }
            }
        }

        private void ForMedication(XmlDocument doc, HealthAssessmentAnswer haa)
        {
            var aspirinHalfDaily = doc.SelectSingleNode("//record/biomarker[@name='ASPIRIN_HALF_DAILY']");//167
            var lipid = doc.SelectSingleNode("//record/biomarker[@name='LIPID']");//166
            var hypertensionMedication = doc.SelectSingleNode("//record/biomarker[@name='HYPERTENSION_MEDICATION']");//165

            if (aspirinHalfDaily != null && haa.QuestionId == 167)
            {
                aspirinHalfDaily.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (lipid != null && haa.QuestionId == 166)
            {
                lipid.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (hypertensionMedication != null && haa.QuestionId == 165)
            {
                hypertensionMedication.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
        }

        private void ForSmokeMembersOnly(XmlDocument doc, HealthAssessmentAnswer haa, bool isSmoker)
        {
            var memberCigarettesAvg = doc.SelectSingleNode("//record/biomarker[@name='MEMBER_CIGARETTES_AVG']");//164
            var memberCigarettesYears = doc.SelectSingleNode("//record/biomarker[@name='MEMBER_CIGARETTES_YEARS']");//163
            var asthmaMember = doc.SelectSingleNode("//record/biomarker[@name='ASTHMA_MEMBER']");//162
            var asthmaMemberFormerly = doc.SelectSingleNode("//record/biomarker[@name='ASTHMA_MEMBER_FORMERLY']");//161
            var emphysemaMember = doc.SelectSingleNode("//record/biomarker[@name='EMPHYSEMA_MEMBER']");//160
            var lungCopdMember = doc.SelectSingleNode("//record/biomarker[@name='LUNG_COPD_MEMBER']");//159

            if (!isSmoker)
            {
                var parentNode = memberCigarettesAvg.ParentNode;
                parentNode.RemoveChild(memberCigarettesAvg);
                parentNode.RemoveChild(memberCigarettesYears);
                parentNode.RemoveChild(asthmaMember);
                parentNode.RemoveChild(asthmaMemberFormerly);
                parentNode.RemoveChild(emphysemaMember);
                parentNode.RemoveChild(lungCopdMember);
                return;
            }

            if (memberCigarettesAvg != null && haa.QuestionId == 164)
            {
                memberCigarettesAvg.Attributes["value"].Value = haa.Answer.ToLower();
            }

            if (memberCigarettesYears != null && haa.QuestionId == 163)
            {
                memberCigarettesYears.Attributes["value"].Value = haa.Answer.ToLower();
            }

            if (asthmaMember != null && haa.QuestionId == 162)
            {
                asthmaMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (asthmaMemberFormerly != null && haa.QuestionId == 161)
            {
                asthmaMemberFormerly.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (emphysemaMember != null && haa.QuestionId == 160)
            {
                emphysemaMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (lungCopdMember != null && haa.QuestionId == 159)
            {
                lungCopdMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

        }

        private void SetLifeStyleQuestions(XmlDocument doc, HealthAssessmentAnswer haa)
        {
            var memberCigarettes = doc.SelectSingleNode("//record/biomarker[@name='MEMBER_CIGARETTES']");//168
            var memberCigarettesFormerlyKyn = doc.SelectSingleNode("//record/biomarker[@name='MEMBER_CIGARETTES_FORMERLY_KYN']");//169
            var exerciseFrequency = doc.SelectSingleNode("//record/biomarker[@name='EXERCISE_FREQUENCY']");//170
            var exerciseIntensity = doc.SelectSingleNode("//record/biomarker[@name='EXERCISE_INTENSITY']");//171


            if (memberCigarettes != null && haa.QuestionId == 168)
            {
                var isSmoker = haa.Answer.ToLower() == HaaAnswerYes;
                memberCigarettes.Attributes["value"].Value = isSmoker ? HaaAnswerYesValue : HaaAnswerNoValue;

                if (!isSmoker)
                {
                    ForSmokeMembersOnly(doc, null, isSmoker);
                }

            }

            if (memberCigarettesFormerlyKyn != null && haa.QuestionId == 169)
            {
                memberCigarettesFormerlyKyn.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (exerciseFrequency != null && haa.QuestionId == 170)
            {
                exerciseFrequency.Attributes["value"].Value = GetExerciseFrequency(haa.Answer.ToLower());
            }

            if (exerciseIntensity != null && haa.QuestionId == 171)
            {
                exerciseIntensity.Attributes["value"].Value = GetExerciseIntensity(haa.Answer.ToLower());
            }
        }

        private void SetQuestoinForWomenOnly(XmlDocument doc, HealthAssessmentAnswer haa, bool isMale)
        {
            var pregnantCurrently = doc.SelectSingleNode("//record/biomarker[@name='PREGNANT_CURRENTLY']");//153
            var birthNumber = doc.SelectSingleNode("//record/biomarker[@name='BIRTH_NUMBER']");//154
            var gestationalDiabetes = doc.SelectSingleNode("//record/biomarker[@name='GESTATIONAL_DIABETES']");//155
            var yearsGestationalDiabetes = doc.SelectSingleNode("//record/biomarker[@name='YEARS_GESTATIONAL_DIABETES']");//156
            var menopauseBegun = doc.SelectSingleNode("//record/biomarker[@name='MENOPAUSE_BEGUN']");//157
            var hrtCurrent = doc.SelectSingleNode("//record/biomarker[@name='HRT_CURRENT']");//158

            if (isMale)
            {
                var parentNod = pregnantCurrently.ParentNode;
                parentNod.RemoveChild(pregnantCurrently);
                parentNod.RemoveChild(birthNumber);
                parentNod.RemoveChild(gestationalDiabetes);
                parentNod.RemoveChild(yearsGestationalDiabetes);
                parentNod.RemoveChild(menopauseBegun);
                parentNod.RemoveChild(hrtCurrent);

                return;

            }

            if (pregnantCurrently != null && haa.QuestionId == 153)
            {
                pregnantCurrently.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (birthNumber != null && haa.QuestionId == 154)
            {
                birthNumber.Attributes["value"].Value = haa.Answer.ToLower();
            }

            if (gestationalDiabetes != null && haa.QuestionId == 155)
            {
                gestationalDiabetes.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;

                if (haa.Answer.ToLower() != HaaAnswerYes)
                {
                    yearsGestationalDiabetes.Attributes["value"].Value = "0";
                }

            }

            if (yearsGestationalDiabetes != null && haa.QuestionId == 156)
            {
                yearsGestationalDiabetes.Attributes["value"].Value = haa.Answer.ToLower();
            }

            if (menopauseBegun != null && haa.QuestionId == 157)
            {
                menopauseBegun.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

            if (hrtCurrent != null && haa.QuestionId == 158)
            {
                hrtCurrent.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }

        }

        private void SetPersonalHealtQuestionary(XmlDocument doc, HealthAssessmentAnswer haa)
        {
            var ekgAtrialFibrillation = doc.SelectSingleNode("//record/biomarker[@name='EKG_ATRIAL_FIBRILLATION']");//152
            var ekgLeftVentricular = doc.SelectSingleNode("//record/biomarker[@name='EKG_LEFT_VENTRICULAR']");//151
            var cardioOther = doc.SelectSingleNode("//record/biomarker[@name='CARDIOVASCULAR_OTHER']");//150
            var valveDisease = doc.SelectSingleNode("//record/biomarker[@name='VALVE_DISEASE']");//149
            var heartFailure = doc.SelectSingleNode("//record/biomarker[@name='HEART_FAILURE']");//148
            var strokeMember = doc.SelectSingleNode("//record/biomarker[@name='STROKE_MEMBER']");//147
            var heartDiseaseMember = doc.SelectSingleNode("//record/biomarker[@name='HEART_DISEASE_MEMBER']");//146
            var diabetesMember = doc.SelectSingleNode("//record/biomarker[@name='DIABETES_MEMBER']");//145


            if (ekgAtrialFibrillation != null && haa.QuestionId == 152)
            {
                ekgAtrialFibrillation.Attributes["value"].Value = GetEkgAnswer(haa.Answer.ToLower());
            }
            if (ekgLeftVentricular != null && haa.QuestionId == 151)
            {
                ekgLeftVentricular.Attributes["value"].Value = GetEkgAnswer(haa.Answer.ToLower());
            }
            if (cardioOther != null && haa.QuestionId == 150)
            {
                cardioOther.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (valveDisease != null && haa.QuestionId == 149)
            {
                valveDisease.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (heartFailure != null && haa.QuestionId == 148)
            {
                heartFailure.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (strokeMember != null && haa.QuestionId == 147)
            {
                strokeMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (heartDiseaseMember != null && haa.QuestionId == 146)
            {
                heartDiseaseMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }
            if (diabetesMember != null && haa.QuestionId == 145)
            {
                diabetesMember.Attributes["value"].Value = haa.Answer.ToLower() == HaaAnswerYes ? HaaAnswerYesValue : HaaAnswerNoValue;
            }





        }
        #endregion

        #region "Set Basic Biometric Info KynLabValues, Test Details , Event Details, Customer Info"
        private void SetbasicBiometricInfo(XmlDocument doc, long eventCustomerId)
        {
            var basicBiometric = _basicBiometricRepository.Get(eventCustomerId);

            var bloodPressureDiastolic = doc.SelectSingleNode("//record/biomarker[@name='BLOOD_PRESSURE_DIASTOLIC']");
            var bloodPressureSystolic = doc.SelectSingleNode("//record/biomarker[@name='BLOOD_PRESSURE_SYSTOLIC']");
            var pulseRate = doc.SelectSingleNode("//record/biomarker[@name='PULSE_RATE']");

            if (basicBiometric.DiastolicPressure.HasValue && basicBiometric.SystolicPressure.HasValue)
            {
                bloodPressureDiastolic.Attributes["value"].Value = basicBiometric.DiastolicPressure.Value.ToString();
                bloodPressureSystolic.Attributes["value"].Value = basicBiometric.SystolicPressure.Value.ToString();
            }

            if (basicBiometric.PulseRate != null)
            {
                pulseRate.Attributes["value"].Value = basicBiometric.PulseRate.Value.ToString();
            }
        }

        private void SetKynLabValues(XmlDocument doc, long eventCustomerId, long testId)
        {
            var labValues = _kynLabValuesRepository.Get(eventCustomerId, testId);
            var cholesterolHdl = doc.SelectSingleNode("//record/biomarker[@name='CHOLESTEROL_HDL']");
            var cholesterolLdl = doc.SelectSingleNode("//record/biomarker[@name='CHOLESTEROL_LDL']");
            var cholesterolTotal = doc.SelectSingleNode("//record/biomarker[@name='CHOLESTEROL_TOTAL']");
            var triglycerides = doc.SelectSingleNode("//record/biomarker[@name='TRIGLYCERIDES']");
            var fastingGlucose = doc.SelectSingleNode("//record/biomarker[@name='FASTING_GLUCOSE']");
            var fastingStatus = doc.SelectSingleNode("//record/biomarker[@name='FASTING_STATUS']");
            var a1c = doc.SelectSingleNode("//record/biomarker[@name='A1C']");

            int? outputTc = null;
            int? outputHdl = null;
            int? outputTg = null;

            if (cholesterolHdl != null && labValues.Hdl.HasValue)
            {
                outputHdl = labValues.Hdl;
                cholesterolHdl.Attributes["value"].Value = outputHdl.Value.ToString();
            }

            if (cholesterolTotal != null && labValues.TotalCholesterol.HasValue)
            {
                outputTc = labValues.TotalCholesterol.Value;
                cholesterolTotal.Attributes["value"].Value = outputTc.Value.ToString();
            }

            if (triglycerides != null && labValues.Triglycerides.HasValue)
            {
                outputTg = labValues.Triglycerides;
                triglycerides.Attributes["value"].Value = outputTg.Value.ToString();
            }

            if (labValues.FastingStatus.HasValue && fastingStatus != null)
            {
                var fastingStatusEnum = (FastingStatus)labValues.FastingStatus.Value;

                fastingStatus.Attributes["value"].Value = GetFastingStatus(fastingStatusEnum).ToString();
            }

            if (outputTc.HasValue && outputHdl.HasValue && outputTg.HasValue)
            {
                var ldl = outputTc.Value - outputHdl.Value - (outputTg.Value / 5);
                cholesterolLdl.Attributes["value"].Value = Convert.ToInt32(ldl).ToString();//Convert.ToString(outputTc - outputHdl - Convert.ToInt32(decimal.Round((decimal)outputTg / 5, 0)));
            }

            if (fastingGlucose != null && labValues.Glucose.HasValue)
            {
                fastingGlucose.Attributes["value"].Value = labValues.Glucose.Value.ToString();
            }

            if (a1c != null && labValues.A1c.HasValue)
            {
                a1c.Attributes["value"].Value = labValues.A1c.Value.ToString();
            }
        }

        private void SetTestDetails(XmlDocument doc, long customerId, long eventId, bool isNewResultFlow)
        {
            var testResultRepository = new TestResultRepository();

            var eventTestPurchasedByCustomers = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);

            var isKynPurchsed = IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, eventTestPurchasedByCustomers.ToList());

            var testResult = testResultRepository.GetTestResult(customerId, eventId, (isKynPurchsed ? (int)TestType.Kyn : (int)TestType.HKYN), isNewResultFlow);

            var technician = _userService.GetUser(testResult.ConductedByOrgRoleUserId);
            var techinicianName = technician.NameAsString;

            var record = doc.SelectSingleNode("//record");
            if (record == null) return;

            record.Attributes["conductedBy"].Value = techinicianName;


        }

        private void SetEventDetails(XmlDocument doc, DateTime eventDate, string corpCode)
        {
            var record = doc.SelectSingleNode("//record");

            if (record == null) return;

            record.Attributes["groupName"].Value = corpCode;
            record.Attributes["eventDate"].Value = eventDate.ToString("yyyy-MM-dd");
        }

        private void SetCustomerInfo(XmlDocument doc, Customer customer)
        {
            var record = doc.SelectSingleNode("//record");

            if (record == null) return;

            record.Attributes["participantPrimaryKey"].Value = customer.CustomerId.ToString();
            record.Attributes["firstName"].Value = customer.Name.FirstName.ToUpper().Trim();
            record.Attributes["lastName"].Value = customer.Name.LastName.ToUpper().Trim();
            record.Attributes["sex"].Value = customer.Gender.ToString().ToUpper().Trim();

            if (!string.IsNullOrEmpty(customer.InsuranceId))
            {
                record.Attributes["uniqueId"].Value = customer.InsuranceId.Trim();
            }
            else
            {
                record.Attributes["uniqueId"].Value = customer.CustomerId.ToString();
            }

            if (customer.DateOfBirth.HasValue)
            {
                var birthYear = doc.SelectSingleNode("//record/biomarker[@name='BIRTH_YEAR']");
                birthYear.Attributes["value"].Value = customer.DateOfBirth.Value.Year.ToString();

                var birthMonth = doc.SelectSingleNode("//record/biomarker[@name='BIRTH_MONTH']");
                birthMonth.Attributes["value"].Value = customer.DateOfBirth.Value.Month.ToString();

                var birthDay = doc.SelectSingleNode("//record/biomarker[@name='BIRTH_DAY']");
                birthDay.Attributes["value"].Value = customer.DateOfBirth.Value.Day.ToString();

                var age = doc.SelectSingleNode("//record/biomarker[@name='AGE']");
                age.Attributes["value"].Value = customer.DateOfBirth.Value.GetAge().ToString();
            }

            var heightreading = customer.Height.TotalInches;
            var weightreading = customer.Weight.TotalPounds;

            var height = doc.SelectSingleNode("//record/biomarker[@name='HEIGHT']");
            height.Attributes["value"].Value = (heightreading).ToString();

            var race = doc.SelectSingleNode("//record/biomarker[@name='RACE']");
            race.Attributes["value"].Value = GetRace(customer.Race);

            if (customer.Waist.HasValue)
            {
                var waist = doc.SelectSingleNode("//record/biomarker[@name='WAIST']");
                waist.Attributes["value"].Value = customer.Waist.Value.ToString("0.0");
            }

            var weight = doc.SelectSingleNode("//record/biomarker[@name='WEIGHT']");
            weight.Attributes["value"].Value = (weightreading).ToString();

            var _isMale = customer.Gender == Gender.Male;
            var sex = doc.SelectSingleNode("//record/biomarker[@name='SEX']");
            sex.Attributes["value"].Value = GetGender(customer.Gender);

            if (_isMale)
            {
                SetQuestoinForWomenOnly(doc, null, _isMale);
            }
            var bmiIndex = doc.SelectSingleNode("//record/biomarker[@name='BODY_MASS_INDEX']");
            bmiIndex.Attributes["value"].Value = BmiCalculator(weightreading, heightreading).ToString("0.0");


        }
        #endregion

        public void GenerateKynXMlforCustomer(EventCustomer eventCustomer, long eventId, DateTime eventDate, string corpCode, bool generatekynXml = true)
        {
            var isNewResultFlow = eventDate >= _settings.ResultFlowChangeDate;
            InitializeGlobalPathVariables(eventId, eventDate, generatekynXml);

            var cutomerid = eventCustomer.CustomerId;

            var customer = _customerRepository.GetCustomer(cutomerid);

            if (!Directory.Exists(_kynRawDataRepositoryPath))
                Directory.CreateDirectory(_kynRawDataRepositoryPath);
            var desinationXml = string.Format("{0}\\{1}.xml", _kynRawDataRepositoryPath, cutomerid);

            var doc = new XmlDocument();
            doc.Load(_settings.KynDataTemplate);

            SetEventDetails(doc, eventDate, corpCode);
            SetCustomerInfo(doc, customer);
            SetTestDetails(doc, cutomerid, eventId, isNewResultFlow);
            SetKynHealthAssessment(doc, cutomerid, eventId);

            var eventTests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customer.CustomerId);

            var isKynPurchased = IsTestPurchased((long)TestType.Kyn, eventTests);
            var isHkynPurchased = IsTestPurchased((long)TestType.HKYN, eventTests);

            var test = TestType.Kyn;
            if (!isKynPurchased && isHkynPurchased)
                test = TestType.HKYN;

            SetKynLabValues(doc, eventCustomer.Id, (long)test);
            SetbasicBiometricInfo(doc, eventCustomer.Id);

            //Set lipid Test Value
            var cholesterolLdl = doc.SelectSingleNode("//record/biomarker[@name='CHOLESTEROL_LDL']");
            var lipidTestResultRepository = new LipidTestRepository();
            var lipidTestResult = (LipidTestResult)lipidTestResultRepository.GetTestResults(customer.CustomerId, eventId, isNewResultFlow);

            if (lipidTestResult != null && lipidTestResult.LDL != null && lipidTestResult.LDL.Reading.HasValue)
            {
                if (cholesterolLdl != null)
                    cholesterolLdl.Attributes["value"].Value = lipidTestResult.LDL.Reading.ToString();
            }

            doc.Save(desinationXml);

        }

        public bool IsTestPurchased(long testId, List<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => et.Id == testId && et.HealthAssessmentTemplateId.HasValue);
            return isTestPurchased;
        }


    }
}
