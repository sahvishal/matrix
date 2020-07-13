using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportFactory : IPcpResultExportFactory
    {
        private readonly TestResultService _testResultService;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IOrganizationRepository _organizationRepository;

        private readonly IPcpResultExportAwvAaaFactory _awvAaaFactory;
        private readonly IPcpResultExportAwvEchoFactory _awvEchoFactory;
        private readonly IPcpResultExportAwvCarotidFactory _awvCarotidFactory;
        private readonly IPcpResultExportAwvSpiroFactory _awvSpiroFactory;
        private readonly IPcpResultExportAwvAbiFactory _awvAbiFactory;
        private readonly IPcpResultExportAwvEkgFactory _awvEkgFactory;
        private readonly IPcpResultExportVisionFactory _visionFactory;

        private readonly IPcpResultExportQualityMeasuresFactory _qualityMeasuresFactory;
        private readonly IPcpResultExportPhq9Factory _phq9Factory;
        private readonly IPcpResultExportBoneMassFactory _awvBoneMassFactory;
        private readonly IPcpResultExportOsteoporosisFactory _osteoporosisFactory;
        private readonly IPcpResultExportMammographyFactory _mammographyFactory;
        private readonly IPcpResultExportLeadFactory _leadFactory;
        private readonly IPcpResultExportUrineMicroalbuminFactory _urineMicroalbuminFactory;

        private readonly IPcpResultExportHemoglobinA1CFactory _hemoglobinA1CFactory;
        private readonly IPcpResultExportAwvHemoglobinFactory _awvHemoglobinFactory;
        private readonly IPcpResultExportIfobtFactory _ifobtFactory;
        private readonly IPcpResultExportFlushotFactory _flushotFactory;
        private readonly IPcpResultExportDpnFactory _dpnFactory;

        private readonly IPcpResultExportAwvLipidFactory _awvLipidFactory;

        private readonly IPcpResultExportDiabeticNeuropathyFactory _diabeticNeuropathyFactory;
        private readonly IPcpResultExportQuantaFloABIFactory _quantaFloAbiFactory;
        private readonly DateTime basicBiometricCutOfDate;

        private IEnumerable<OrderedPair<long, string>> _questions;
        private readonly ISettings _settings;
        public PcpResultExportFactory(ILogger logger)
        {
            _logger = logger;
            _testResultService = new TestResultService();
            _eventRepository = new EventRepository();
            _hostRepository = new HostRepository();
            _organizationRepository = new OrganizationRepository();

            _awvAaaFactory = new PcpResultExportAwvAaaFactory();
            _awvEchoFactory = new PcpResultExportAwvEchoFactory();
            _awvCarotidFactory = new PcpResultExportAwvCarotidFactory();
            _awvSpiroFactory = new PcpResultExportAwvSpiroFactory();
            _awvAbiFactory = new PcpResultExportAwvAbiFactory();
            _awvEkgFactory = new PcpResultExportAwvEkgFactory();
            _visionFactory = new PcpResultExportVisionFactory();


            _qualityMeasuresFactory = new PcpResultExportQualityMeasuresFactory();
            _phq9Factory = new PcpResultExportPhq9Factory();
            _awvBoneMassFactory = new PcpResultExportBoneMassFactory();
            _osteoporosisFactory = new PcpResultExportOsteoporosisFactory();
            _mammographyFactory = new PcpResultExportMammographyFactory();
            _leadFactory = new PcpResultExportLeadFactory();

            _urineMicroalbuminFactory = new PcpResultExportUrineMicroalbuminFactory();

            _hemoglobinA1CFactory = new PcpResultExportHemoglobinA1CFactory();
            _awvHemoglobinFactory = new PcpResultExportAwvHemoglobinFactory();

            _ifobtFactory = new PcpResultExportIfobtFactory();
            _flushotFactory = new PcpResultExportFlushotFactory();

            _dpnFactory = new PcpResultExportDpnFactory();

            _awvLipidFactory = new PcpResultExportAwvLipidFactory();
            _diabeticNeuropathyFactory = new PcpResultExportDiabeticNeuropathyFactory();
            _quantaFloAbiFactory = new PcpResultExportQuantaFloABIFactory();

            _settings = new Settings();

            basicBiometricCutOfDate = _settings.BasicBiometricCutOfDate;
        }

        public void Create(IEnumerable<EventCustomerResultEntity> eventCustomerResultEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs, IEnumerable<UserEntity> userEntities,
            IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities, IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities,
            IEnumerable<OrderedPair<long, long>> eventIdPodIdPairs, IEnumerable<PodDetailsEntity> podDetailsEntities, IEnumerable<OrderedPair<long, long>> eventIdHospitalPartnerIdPairs,
            IEnumerable<OrderedPair<long, string>> hospitalPartnerIdNamePairs, IEnumerable<EventCustomerBasicBioMetricEntity> basicBioMetricEntities, IEnumerable<EventCustomersEntity> eventCustomersEntities,
            IEnumerable<EventAppointmentEntity> eventAppointmentEntities, IEnumerable<HospitalPartnerCustomerEntity> hospitalPartnerCustomerEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair,
            IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities, string destinationDirectory, IEnumerable<long> hafQuestionIds, bool useBlankValue, string resultExportfileName = "",
            string[] showHiddenColumns = null, IEnumerable<OrderedPair<string, string>> additionalFields = null)
        {
            long totalRecords = eventCustomerResultEntities.Count();
            long counter = 1;

            _questions = PcpResultExportHelper.AllQuestions.Where(aq => hafQuestionIds.Contains(aq.FirstValue)).Select(aq => aq).ToArray();

            _logger.Info("Total Records : " + totalRecords);

            var fileName = destinationDirectory + string.Format(@"\ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));

            if (!string.IsNullOrEmpty(resultExportfileName))
            {
                fileName = Path.Combine(destinationDirectory, resultExportfileName);
            }

            _logger.Info("Generating File at: " + fileName);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            WriteCsvHeader(fileName, showHiddenColumns, additionalFields);

            foreach (var eventCustomerResultEntity in eventCustomerResultEntities)
            {
                try
                {
                    _logger.Info(string.Format("Creating Model for event {0} and customer {1}", eventCustomerResultEntity.EventId, eventCustomerResultEntity.CustomerId));

                    var userId = orgRoleUserIdUserIdPairs.Where(oru => oru.FirstValue == eventCustomerResultEntity.CustomerId).Select(oru => oru.SecondValue).Single();

                    var user = userEntities.Where(u => u.UserId == userId).Select(u => u).Single();

                    var address = addresses.Where(a => a.Id == user.HomeAddressId).Select(a => a).Single();

                    var customer = customerProfileEntities.Where(cp => cp.CustomerId == eventCustomerResultEntity.CustomerId).Select(cp => cp).Single();

                    var eventData = eventsEntities.Where(e => e.EventId == eventCustomerResultEntity.EventId).Select(e => e).Single();

                    var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                    var podIds = eventIdPodIdPairs.Where(ep => ep.FirstValue == eventData.EventId).Select(ep => ep.SecondValue).ToArray();

                    var podName = string.Join(",", podDetailsEntities.Where(pd => podIds.Contains(pd.PodId)).Select(pd => pd.Name).ToArray());

                    var hospitalPartnerId = eventIdHospitalPartnerIdPairs.Where(ehp => ehp.FirstValue == eventData.EventId).Select(ehp => ehp.SecondValue).SingleOrDefault();

                    var hopitalPartnerName = hospitalPartnerIdNamePairs.Where(hp => hp.FirstValue == hospitalPartnerId).Select(hp => hp.SecondValue).SingleOrDefault();

                    var eventCustomer = eventCustomersEntities.Where(ec => ec.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(ec => ec).Single();

                    var eventAppointment = eventAppointmentEntities.Where(ea => ea.AppointmentId == eventCustomer.AppointmentId).Select(ea => ea).Single();

                    var primaryCarePhysician = primaryCarePhysicianEntities.Where(pcp => pcp.CustomerId == eventCustomerResultEntity.CustomerId).Select(pcp => pcp).FirstOrDefault();

                    var basicBimetric = basicBioMetricEntities.Where(bb => bb.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(bb => bb).FirstOrDefault();

                    var hafAnswers = customerHealthInfoEntities.Where(chi => chi.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(chi => chi).ToArray();

                    var answers = new List<OrderedPair<long, string>>();

                    foreach (var question in _questions)
                    {
                        var hafAnswer = hafAnswers.Where(ha => ha.CustomerHealthQuestionId == question.FirstValue).Select(ha => ha).FirstOrDefault();

                        if (hafAnswer != null)
                        {
                            answers.Add(new OrderedPair<long, string>(question.FirstValue, hafAnswer.HealthQuestionAnswer));
                        }
                        else
                        {
                            answers.Add(new OrderedPair<long, string>(question.FirstValue, ""));
                        }
                    }

                    var age = string.Empty;
                    if (user.Dob.HasValue)
                    {
                        var now = DateTime.Now;
                        var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
                        var birth = user.Dob.Value;
                        var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

                        var currentDayOfYear = now.DayOfYear;
                        if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                            currentDayOfYear = now.DayOfYear - 1;
                        else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                            currentDayOfYear = now.DayOfYear + 1;

                        var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
                        var months = (12 + now.Month - birth.Month - ((now.Day < birth.Day) ? 1 : 0)) % 12;
                        var days = now.Day - birth.Day;
                        if (days < 0)
                            days = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddDays(days).Day;

                        age = years.ToString();
                    }
                    var ssn = "N/A";
                    if (!string.IsNullOrEmpty(user.Ssn))
                    {
                        ssn = _cryptographyService.Decrypt(user.Ssn);
                        if (ssn.Length >= 9)
                        {
                            ssn = ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(ssn.Length - 4);
                        }
                    }

                    var height = !string.IsNullOrEmpty(customer.Height) ? Convert.ToDouble(customer.Height) : 0;
                    Height customerHeight = null;

                    if (height > 0)
                    {
                        var inches = height % 12;
                        var feet = (height - inches) / 12;
                        customerHeight = new Height(feet, inches);
                    }

                    var weight = new Weight(customer.Weight ?? 0);
                    var bmiIndex = string.Empty;

                    if (weight != null && weight.Pounds > 1 && customerHeight != null && customerHeight.TotalInches > 1)
                    {
                        var bmi = BmiCalculator(weight.Pounds, customerHeight.TotalInches);
                        bmiIndex = bmi.ToString("0.0");
                    }

                    var model = new PcpResultExportModel
                    {
                        CustomerId = customer.CustomerId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address1 = address.StreetAddressLine1,
                        City = address.City,
                        State = address.State,
                        Zip = address.ZipCode.Zip,
                        Dob = user.Dob,
                        Age = age,
                        Height = customer.Height,
                        Weight = customer.Weight > 0 ? customer.Weight.ToString() : "",
                        BMIndex = bmiIndex,
                        Gender = customer.Gender,
                        Race = customer.Race != "-1" ? customer.Race : "",
                        Email = user.Email1,
                        Phone = user.PhoneHome,
                        Ssn = ssn,
                        MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId,
                        Hicn = string.IsNullOrEmpty(customer.Hicn) ? "" : customer.Hicn,
                        EventId = eventData.EventId,
                        EventDate = eventData.EventDate,
                        Pod = podName,
                        HospitalPartner = hopitalPartnerName,
                        Hipaa = ((RegulatoryState)eventCustomer.Hipaastatus).GetDescription(),
                        CheckinTime = eventAppointment.CheckinTime.HasValue ? eventAppointment.CheckinTime.Value.ToShortTimeString() : "",
                        CheckoutTime = eventAppointment.CheckoutTime.HasValue ? eventAppointment.CheckoutTime.Value.ToShortTimeString() : "",
                        HealthAssesmentAnswer = answers,
                        ResultSummary = eventCustomerResultEntity.ResultSummary.HasValue ? ((ResultInterpretation)eventCustomerResultEntity.ResultSummary).GetDescription() : "",
                        Mrn = string.IsNullOrEmpty(customer.Mrn) ? string.Empty : customer.Mrn,
                        GroupName = string.IsNullOrEmpty(customer.GroupName) ? string.Empty : customer.GroupName,
                        AdditionalField1 = customer.AdditionalField1,
                        AdditionalField2 = customer.AdditionalField2,
                        AdditionalField3 = customer.AdditionalField3,
                        AdditionalField4 = customer.AdditionalField4,
                    };

                    if (primaryCarePhysician != null)
                    {
                        model.PrimaryPhysicianName = new Name(primaryCarePhysician.FirstName, primaryCarePhysician.MiddleName, primaryCarePhysician.LastName).FullName;
                    }
                    if (hospitalPartnerId > 0)
                    {
                        model.PartnerRelease = eventCustomer.PartnerRelease > 0 ? ((RegulatoryState)eventCustomer.PartnerRelease).GetDescription() : "";
                        var hospitalPartnerCustomer = hospitalPartnerCustomerEntities.LastOrDefault(hpc => hpc.EventId == eventCustomerResultEntity.EventId && hpc.CustomerId == eventCustomerResultEntity.CustomerId);

                        model.CareCoordinatorStatus = hospitalPartnerCustomer != null
                            ? ((HospitalPartnerCustomerStatus)hospitalPartnerCustomer.Status).GetDescription()
                            : HospitalPartnerCustomerStatus.NotCalled.GetDescription();
                        model.CareCoordinatorOutcome = hospitalPartnerCustomer != null
                            ? ((HospitalPartnerCustomerOutcome)hospitalPartnerCustomer.Outcome).GetDescription()
                            : HospitalPartnerCustomerOutcome.NotScheduledNotInterested.GetDescription();
                        model.CareCoordinator = hospitalPartnerCustomer != null
                            ? careCoordinatorIdNamePair.First(cc => cc.FirstValue == hospitalPartnerCustomer.CareCoordinatorOrgRoleUserId).SecondValue
                            : "N/A";
                        model.CareCoordinatorNotes = hospitalPartnerCustomer != null
                            ? hospitalPartnerCustomer.Notes
                            : "";
                    }
                    else
                    {
                        model.PartnerRelease = "N/A";
                        model.CareCoordinatorStatus = "N/A";
                        model.CareCoordinatorOutcome = "N/A";
                        model.CareCoordinator = "N/A";
                        model.CareCoordinatorNotes = "N/A";
                    }
                    var showHyperTensionTestResult = false;
                    if (model.EventId > 0)
                    {
                        var theEvent = _eventRepository.GetById(model.EventId);
                        if (theEvent.AccountId.HasValue && theEvent.AccountId > 0)
                        {
                            var organization = _organizationRepository.GetOrganizationbyId(theEvent.AccountId.Value);
                            model.CorporateAccount = organization.Name;
                        }

                        if (theEvent.HostId > 0)
                        {
                            var host = _hostRepository.GetHostForEvent(theEvent.Id);
                            model.EventLocation = host.OrganizationName + " @ " + host.Address;
                        }

                        showHyperTensionTestResult = (theEvent.EventDate.Date >= basicBiometricCutOfDate);
                    }
                    ITestResultRepository testResultRepository;
                    var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Hypertension);

                    if (showHyperTensionTestResult && isTestPurchased)
                    {
                        testResultRepository = new HypertensionTestRepository();
                        var hyperTenstionTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (hyperTenstionTestResult != null && (hyperTenstionTestResult.TestNotPerformed == null || hyperTenstionTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model.BloodPressure = (basicBimetric.SystolicPressure.HasValue ? basicBimetric.SystolicPressure.Value.ToString() : "0") + "/" + (basicBimetric.DiastolicPressure.HasValue ? basicBimetric.DiastolicPressure.Value.ToString() : "0");

                            model.PulseRate = basicBimetric.PulseRate.HasValue ? basicBimetric.PulseRate.Value.ToString() : "";

                            model.IsAbnormalBloodPressure = basicBimetric.IsBloodPressureElevated.HasValue && basicBimetric.IsBloodPressureElevated.Value ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                        }
                    }
                    else if (!showHyperTensionTestResult && basicBimetric != null)
                    {
                        model.BloodPressure = (basicBimetric.SystolicPressure.HasValue ? basicBimetric.SystolicPressure.Value.ToString() : "0") + "/" + (basicBimetric.DiastolicPressure.HasValue ? basicBimetric.DiastolicPressure.Value.ToString() : "0");

                        model.PulseRate = basicBimetric.PulseRate.HasValue ? basicBimetric.PulseRate.Value.ToString() : "";

                        model.IsAbnormalBloodPressure = basicBimetric.IsBloodPressureElevated.HasValue && basicBimetric.IsBloodPressureElevated.Value ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                    }


                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvAAA);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Aaa  data.");

                        testResultRepository = new AwvAaaTestRepository();
                        var awvAaaTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvAaaTestResult != null && (awvAaaTestResult.TestNotPerformed == null || awvAaaTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvAaaFactory.SetAwvAaaData(model, awvAaaTestResult as AwvAaaTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvEcho);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Echo  data.");

                        testResultRepository = new AwvEchocardiogramTestRepository();
                        var awvEchoTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvEchoTestResult != null && (awvEchoTestResult.TestNotPerformed == null || awvEchoTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvEchoFactory.SetAwvEchoData(model, awvEchoTestResult as AwvEchocardiogramTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvCarotid);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Carotid data.");

                        testResultRepository = new AwvCarotidTestRepository();
                        var awvCarotidTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvCarotidTestResult != null && (awvCarotidTestResult.TestNotPerformed == null || awvCarotidTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvCarotidFactory.SetAwvCarotidData(model, awvCarotidTestResult as AwvCarotidTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvSpiro);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AWV Spiro data.");

                        testResultRepository = new AwvSpiroTestRepository();
                        var awvSpiroTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvSpiroTestResult != null && (awvSpiroTestResult.TestNotPerformed == null || awvSpiroTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvSpiroFactory.SetAwvSpiroData(model, awvSpiroTestResult as AwvSpiroTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvABI);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv ABI data.");

                        testResultRepository = new AwvAbiTestRepository();
                        var awvAbiTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvAbiTestResult != null && (awvAbiTestResult.TestNotPerformed == null || awvAbiTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvAbiFactory.SetAwvAbiData(model, awvAbiTestResult as AwvAbiTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvEkg);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv EKG data.");

                        testResultRepository = new AwvEkgTestRepository();
                        var awvEkgTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvEkgTestResult != null && (awvEkgTestResult.TestNotPerformed == null || awvEkgTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvEkgFactory.SetAwvEkgData(model, awvEkgTestResult as AwvEkgTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Vision);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Vision data.");

                        testResultRepository = new VisionTestRepository();
                        var visionTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (visionTestResult != null && (visionTestResult.TestNotPerformed == null || visionTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _visionFactory.SetVisionData(model, visionTestResult as VisionTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.QualityMeasures);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Quality Measures data.");

                        testResultRepository = new QualityMeasuresTestRepository();
                        var qualityMeasures = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (qualityMeasures != null && (qualityMeasures.TestNotPerformed == null || qualityMeasures.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _qualityMeasuresFactory.SetQualityMeasuresData(model, qualityMeasures as QualityMeasuresTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.PHQ9);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting PHQ9 data.");

                        testResultRepository = new Phq9TestRepository();
                        var phq9 = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (phq9 != null && (phq9.TestNotPerformed == null || phq9.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _phq9Factory.SetPhq9Data(model, phq9 as Phq9TestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvBoneMass);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AWV Bone Mass data.");

                        testResultRepository = new AwvBoneMassTestRepository();
                        var awvBoneMassTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (awvBoneMassTestResult != null && (awvBoneMassTestResult.TestNotPerformed == null || awvBoneMassTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvBoneMassFactory.SetBoneMassData(model, awvBoneMassTestResult as AwvBoneMassTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Osteoporosis);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Osteoporosis data.");

                        testResultRepository = new OsteoporosisTestRepository();
                        var osteoporosisTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (osteoporosisTestResult != null && (osteoporosisTestResult.TestNotPerformed == null || osteoporosisTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _osteoporosisFactory.SetOsteoporosisData(model, osteoporosisTestResult as OsteoporosisTestResult, useBlankValue);
                        }
                    }


                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Mammogram);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Mammogram data");

                        testResultRepository = new MammogramTestRepository();
                        var mammogramTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (mammogramTestResult != null && (mammogramTestResult.TestNotPerformed == null || mammogramTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _mammographyFactory.SetMammographyData(model, mammogramTestResult as MammogramTestResult, useBlankValue);
                        }
                    }

                    if (_settings.ChangeLeadReadingDate.HasValue && eventData.EventDate >= _settings.ChangeLeadReadingDate.Value)
                    {
                        isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Lead);
                        if (isTestPurchased)
                        {
                            _logger.Info("Setting Lead data");

                            testResultRepository = new LeadTestRepository();
                            var leadTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                            var reading = testResultRepository.GetAllReadings((int)TestType.Lead);

                            if (leadTestResult != null && (leadTestResult.TestNotPerformed == null || leadTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                            {
                                model = _leadFactory.SetLeadData(model, leadTestResult as LeadTestResult, reading, useBlankValue);
                            }
                        }
                    }

                    if (_settings.UrineMicroalbuminChangeDate.HasValue && eventData.EventDate >= _settings.UrineMicroalbuminChangeDate.Value)
                    {
                        isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.UrineMicroalbumin);
                        if (isTestPurchased)
                        {
                            _logger.Info("Setting Urine Microalbumin");

                            testResultRepository = new UrineMicroalbuminTestRepository();
                            var urineMicroalbuminTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                            if (urineMicroalbuminTestResult != null && (urineMicroalbuminTestResult.TestNotPerformed == null || urineMicroalbuminTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                            {
                                model = _urineMicroalbuminFactory.SetUrineMicroalbuminData(model, urineMicroalbuminTestResult as UrineMicroalbuminTestResult, useBlankValue);
                            }
                        }
                    }


                    //isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.DiabeticRetinopathy);
                    //if (isTestPurchased)
                    //{
                    //    _logger.Info("Setting Diabetic Retinopathy");

                    //    testResultRepository = new DiabeticRetinopathyTestRepository();
                    //    var diabeticRetinopathyTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);

                    //    if (diabeticRetinopathyTestResult != null && (diabeticRetinopathyTestResult.TestNotPerformed == null || diabeticRetinopathyTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    //    {
                    //        model = _diabeticRetinopathyFactory.SetDiabeticRetinopathyData(model, diabeticRetinopathyTestResult as DiabeticRetinopathyTestResult, useBlankValue);
                    //    }
                    //}

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvHBA1C);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AwvHBA1C");

                        testResultRepository = new AwvHemaglobinTestRepository();
                        var awvHemaglobinTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (awvHemaglobinTestResult != null && (awvHemaglobinTestResult.TestNotPerformed == null || awvHemaglobinTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvHemoglobinFactory.SetAwvHemoglobinData(model, awvHemaglobinTestResult as AwvHemaglobinTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.A1C);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting A1C");

                        testResultRepository = new HemaglobinTestRepository();
                        var hemoglobinA1CTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (hemoglobinA1CTestResult != null && (hemoglobinA1CTestResult.TestNotPerformed == null || hemoglobinA1CTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _hemoglobinA1CFactory.SetHemoglobinA1CData(model, hemoglobinA1CTestResult as HemaglobinA1CTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.IFOBT);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting IFOBT");

                        testResultRepository = new IFOBTTestRepository();
                        var ifobtTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (ifobtTestResult != null && (ifobtTestResult.TestNotPerformed == null || ifobtTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _ifobtFactory.SetIfobtlobinData(model, ifobtTestResult as IFOBTTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvFluShot);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AwvFluShot");

                        testResultRepository = new AwvFluShotTestRepository();
                        var awvflushotTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (awvflushotTestResult != null && (awvflushotTestResult.TestNotPerformed == null || awvflushotTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _flushotFactory.SetAwvFluShotData(model, awvflushotTestResult as AwvFluShotTestResult, useBlankValue);
                        }
                    }


                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.FluShot);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting FluShot");

                        testResultRepository = new FluShotTestRepository();
                        var flushotTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (flushotTestResult != null && (flushotTestResult.TestNotPerformed == null || flushotTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _flushotFactory.SetFluShotData(model, flushotTestResult as FluShotTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.DPN);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting DPN");

                        testResultRepository = new DpnTestRepository();
                        var dpnTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (dpnTestResult != null && (dpnTestResult.TestNotPerformed == null || dpnTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _dpnFactory.SetDpnData(model, dpnTestResult as DpnTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvLipid);

                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AwvLipid");

                        testResultRepository = new AwvLipidTestRepository();
                        var awvLipidTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (awvLipidTestResult != null && (awvLipidTestResult.TestNotPerformed == null || awvLipidTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _awvLipidFactory.SetAwvLipidData(model, awvLipidTestResult as AwvLipidTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.DiabeticNeuropathy);

                    if (isTestPurchased)
                    {
                        _logger.Info("Setting DiabeticNeuropathy");

                        testResultRepository = new DiabeticNeuropathyTestRepository();
                        var diabeticNeuropathyTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (diabeticNeuropathyTestResult != null && (diabeticNeuropathyTestResult.TestNotPerformed == null || diabeticNeuropathyTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _diabeticNeuropathyFactory.SetDiabeticNeuropathyData(model, diabeticNeuropathyTestResult as DiabeticNeuropathyTestResult, useBlankValue);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.QuantaFloABI);

                    if (isTestPurchased)
                    {
                        _logger.Info("Setting QuantaFloABI");

                        testResultRepository = new QuantaFloABITestRepository();
                        var quantaFloAbiTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);

                        if (quantaFloAbiTestResult != null && (quantaFloAbiTestResult.TestNotPerformed == null || quantaFloAbiTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        {
                            model = _quantaFloAbiFactory.SetQuantaFloABIData(model, quantaFloAbiTestResult as QuantaFloABITestResult, useBlankValue);
                        }
                    }

                    WriteCsv(model, fileName, showHiddenColumns, additionalFields);
                    _logger.Info(counter + " completed out of " + totalRecords);

                    //if (counter > 10)
                    //    break;
                    counter++;

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("\n\nFor Event {0} and Customer {1} \n Error:{2}", eventCustomerResultEntity.EventId, eventCustomerResultEntity.CustomerId, ex.Message));
                }
            }
        }


        public void WriteCsvHeader(string fileName, string[] showHiddenColumns = null, IEnumerable<OrderedPair<string, string>> additionalFields = null)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(PcpResultExportModel)).GetMembers();

                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>) && _questions != null)
                        {
                            header.AddRange(_questions.Select(q => EscapeString(q.SecondValue)).ToArray());
                            continue;
                        }
                    }
                    else
                        continue;

                    string propertyName = memberInfo.Name;
                    bool isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        var additionalField = additionalFields != null ? additionalFields.FirstOrDefault(x => x.FirstValue == propertyName) : null;
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute && additionalField != null)
                            {
                                propertyName = additionalField.SecondValue;
                                break;
                            }
                            else if (attribute is HiddenAttribute && (showHiddenColumns.IsNullOrEmpty() || !showHiddenColumns.Contains(propertyName)))
                            {
                                isHidden = true;
                                break;
                            }
                            else if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(EscapeString(propertyName));
                }

                streamWriter.Write(string.Join(PcpResultExportHelper.Delimiter, header.ToArray()) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File header: " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private void WriteCsv(PcpResultExportModel model, string fileName, string[] showHiddenColumns = null, IEnumerable<OrderedPair<string, string>> additionalFields = null)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(PcpResultExportModel)).GetMembers();
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>))
                        {
                            foreach (var question in _questions)
                            {
                                if (model.HealthAssesmentAnswer != null && model.HealthAssesmentAnswer.Any())
                                {
                                    var answer = model.HealthAssesmentAnswer.Where(a => a.FirstValue == question.FirstValue).FirstOrDefault();

                                    values.Add(EscapeString(answer.SecondValue));
                                }
                                else
                                    values.Add(string.Empty);
                            }
                            continue;
                        }
                    }
                    else
                        continue;


                    bool isHidden = false;
                    FormatAttribute formatter = null;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        var additionalField = additionalFields != null ? additionalFields.FirstOrDefault(x => x.FirstValue == memberInfo.Name) : null;
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute && additionalField != null)
                            {
                                break;
                            }
                            else if (attribute is HiddenAttribute && (showHiddenColumns.IsNullOrEmpty() || !showHiddenColumns.Contains(memberInfo.Name)))
                            {
                                isHidden = true;
                                break;
                            }
                            else if (attribute is FormatAttribute)
                            {
                                formatter = (FormatAttribute)attribute;
                            }
                        }
                    }

                    if (isHidden) continue;
                    var obj = propInfo.GetValue(model, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(EscapeString(formatter.ToString(obj)));
                    else
                        values.Add(EscapeString(obj.ToString()));

                }

                streamWriter.Write(string.Join(PcpResultExportHelper.Delimiter, values.ToArray()) + Environment.NewLine);


            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File : " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private static string EscapeString(string toEscape)
        {
            if (toEscape == null)
            {
                return "";
            }
            return '"' + toEscape.Replace("\"", @"""""") + '"';
        }

        private static decimal BmiCalculator(double weightInPounds, double heightInInches)
        {
            var bmiIndex = (weightInPounds < 1 || heightInInches < 1) ? 0 : (weightInPounds / Math.Pow(heightInInches, 2)) * 703;
            return decimal.Parse(bmiIndex.ToString());
        }
    }

}