using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynHealthAssessmentService : IKynHealthAssessmentService
    {
        private readonly IKynHealthAssessmentFactory _kynHealthAssessmentFactory;

        private readonly IBasicBiometricRepository _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IKynLabValuesRepository _kynLabValuesRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerService _customerService;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventRepository _eventRepository;

        public KynHealthAssessmentService(IKynHealthAssessmentFactory kynHealthAssessmentFactory, IBasicBiometricRepository basicBiometricRepository, IEventCustomerRepository eventCustomerRepository,
            ICustomerRepository customerRepository, IKynLabValuesRepository kynLabValuesRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            ICustomerService customerService, IEventTestRepository eventTestRepository, IEventRepository eventRepository)
        {
            _kynHealthAssessmentFactory = kynHealthAssessmentFactory;

            _basicBiometricRepository = basicBiometricRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _kynLabValuesRepository = kynLabValuesRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerService = customerService;
            _eventTestRepository = eventTestRepository;
            _eventRepository = eventRepository;
        }

        public KynHealthAssessmentEditModel GetKynHealthAssessment(long customerId, long eventId, long testId, bool isNewResultFlow)
        {
            var basicBiometric = _basicBiometricRepository.Get(eventId, customerId);

            var model = new KynHealthAssessmentEditModel
            {
                EventId = eventId,
                CustomerId = customerId,
                TestId = testId
            };

            //var lipidRepository = new LipidTestRepository();

            //var lipidresult = lipidRepository.GetTestResults(customerId, eventId);

            //var lipidTestResult = lipidresult as LipidTestResult;

            //if (lipidTestResult != null)
            //{
            //    model.HDLCholestrol = lipidTestResult.HDL != null ? lipidTestResult.HDL.Reading : string.Empty;
            //    model.TotalCholestrol = lipidTestResult.TotalCholestrol != null ? lipidTestResult.TotalCholestrol.Reading
            //        : string.Empty;
            //    model.Triglycerides = lipidTestResult.TriGlycerides != null
            //        ? lipidTestResult.TriGlycerides.Reading
            //        : string.Empty;
            //    model.Glucose = lipidTestResult.Glucose != null ? lipidTestResult.Glucose.Reading : null;
            //}
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult != null)
            {
                var kynLabValues = _kynLabValuesRepository.Get(eventCustomerResult.Id, testId);
                if (kynLabValues != null)
                {
                    model.TotalCholesterol = kynLabValues.TotalCholesterol != null ? kynLabValues.TotalCholesterol.ToString() : string.Empty;
                    model.HDLCholesterol = kynLabValues.Hdl != null ? kynLabValues.Hdl.ToString() : string.Empty;
                    model.Triglycerides = kynLabValues.Triglycerides != null ? kynLabValues.Triglycerides.ToString() : string.Empty;
                    model.Glucose = kynLabValues.Glucose ?? null;
                    model.FastingStatus = kynLabValues.FastingStatus.HasValue ? kynLabValues.FastingStatus.Value : 0;
                    model.ManualSystolic = kynLabValues.ManualSystolic;
                    model.ManualDiastolic = kynLabValues.ManualDiastolic;
                    model.A1c = kynLabValues.A1c;
                    model.BodyFat = kynLabValues.BodyFat;
                    model.BoneDensity = kynLabValues.BoneDensity;
                    model.Psa = kynLabValues.Psa;
                    model.NonHdlCholestrol = kynLabValues.NonHdlCholestrol;
                    model.Nicotine = kynLabValues.Nicotine;
                    model.Cotinine = kynLabValues.Cotinine;
                    model.Smoker = kynLabValues.Smoker;
                    model.LdlCholestrol = kynLabValues.LdlCholestrol;
                    model.Notes = kynLabValues.Notes;
                }
            }


            var testResultRepository = new TestResultRepository();
            var testresult = testResultRepository.GetTestResult(customerId, eventId, (int)testId, isNewResultFlow);

            if (testresult != null)
            {
                model.Notes = testresult.TechnicianNotes;
            }

            if (basicBiometric != null)
            {
                model.SystolicPressure = basicBiometric.SystolicPressure;
                model.DiastolicPressure = basicBiometric.DiastolicPressure;
                model.PulseRate = basicBiometric.PulseRate;
            }
            var customer = _customerRepository.GetCustomer(customerId);

            if (customer == null) return model;

            model.HeightInFeet = customer.Height != null ? customer.Height.Feet : (double?)null;
            model.HeightInInches = customer.Height != null ? customer.Height.Inches : (double?)null;
            model.KynWeight = customer.Weight != null && customer.Weight.Pounds > 0 ? customer.Weight.Pounds : (double?)null;
            model.WaistSize = customer.Waist != null ? customer.Waist.Value : (decimal?)null;

            return model;
        }

        public void SetKynHealthAssessment(KynHealthAssessmentEditModel model, long uploadedby)
        {
            UpdateCustomer(model, uploadedby);
            SaveTestResults(model, uploadedby);
        }

        private void UpdateCustomer(KynHealthAssessmentEditModel model, long uploadedby)
        {
            var customer = _customerRepository.GetCustomer(model.CustomerId);
            _kynHealthAssessmentFactory.GetCustomerDomain(model, customer, uploadedby);
            _customerService.SaveCustomerOnly(customer, uploadedby);
        }

        private long SaveEventCustomerResult(long eventId, long customerId, long uploadedBy)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null)
            {
                eventCustomerResult = new EventCustomerResult
                {
                    CustomerId = customerId,
                    EventId = eventId,
                    DataRecorderMetaData =
                        new DataRecorderMetaData(uploadedBy, DateTime.Now, null)
                };
                eventCustomerResult = _eventCustomerResultRepository.Save(eventCustomerResult);
                return eventCustomerResult.Id;
            }
            return eventCustomerResult.Id;
        }

        private void SaveTestResults(KynHealthAssessmentEditModel model, long uploadedby)
        {
            TestResultRepository testResultRepository;
            var customerId = model.CustomerId;
            var eventId = model.EventId;

            var isNewResultFlow = _eventRepository.IsEventHasNewResultFlow(eventId);

            var service = new Service.TestResultService();

            var eventCustomerResultId = SaveEventCustomerResult(eventId, customerId, uploadedby);

            //basic biometric
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var basicBiometric = _basicBiometricRepository.Get(eventId, customerId);

            basicBiometric = _kynHealthAssessmentFactory.GetBasicTestResultBiometricDomain(model, basicBiometric, uploadedby);

            if (basicBiometric != null)
            {
                basicBiometric.Id = eventCustomer.Id;
                ((IRepository<BasicBiometric>)_basicBiometricRepository).Save(basicBiometric);
            }
            long[] kynTestIds = { (long)TestType.Kyn, (long)TestType.HKYN, (long)TestType.MyBioCheckAssessment };
            var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, kynTestIds);
            //Kyn Test Result
            var isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isKynPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioCheckPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (isPurchased)
            {
                var kynTest = eventTests.First(x => x.TestId == (int)TestType.Kyn).Test;
                SaveKynLabResult(model, uploadedby, customerId, eventId, eventCustomerResultId, (int)TestType.Kyn, kynTest.IsRecordable, isNewResultFlow);
            }
            else if (isKynPurchased)
            {
                var hKynTest = eventTests.First(x => x.TestId == (int)TestType.HKYN).Test;
                SaveKynLabResult(model, uploadedby, customerId, eventId, eventCustomerResultId, (int)TestType.HKYN, hKynTest.IsRecordable, isNewResultFlow);
            }
            else if (isMyBioCheckPurchased)
            {
                var mybioCheckAssessment = eventTests.First(x => x.TestId == (int)TestType.MyBioCheckAssessment).Test;
                SaveKynLabResult(model, uploadedby, customerId, eventId, eventCustomerResultId, (int)TestType.MyBioCheckAssessment, mybioCheckAssessment.IsRecordable, isNewResultFlow);
            }

            //lipidTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Lipid);

            if (isPurchased)
            {
                testResultRepository = new LipidTestRepository(ReadingSource.Manual);
                var lipidTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                lipidTestresult = _kynHealthAssessmentFactory.GetLipidTestResultDomain(model, lipidTestresult as LipidTestResult, uploadedby, isNewResultFlow);
                if (lipidTestresult != null)
                    testResultRepository.SaveTestResults(lipidTestresult, customerId, eventId, uploadedby);
            }

            //AwvLipidTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvLipid);

            if (isPurchased)
            {
                testResultRepository = new AwvLipidTestRepository(ReadingSource.Manual);
                var awvLipidTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                awvLipidTestresult = _kynHealthAssessmentFactory.GetAwvLipidTestResultDomain(model, awvLipidTestresult as AwvLipidTestResult, uploadedby, isNewResultFlow);
                if (awvLipidTestresult != null)
                    testResultRepository.SaveTestResults(awvLipidTestresult, customerId, eventId, uploadedby);
            }

            //AwvGlucoseTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvGlucose);

            if (isPurchased)
            {
                testResultRepository = new AwvGlucoseTestRepository(ReadingSource.Manual);
                var awvGlucoseTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                awvGlucoseTestresult = _kynHealthAssessmentFactory.GetAwvGlucoseTestResultDomain(model, awvGlucoseTestresult as AwvGlucoseTestResult, uploadedby, isNewResultFlow);
                if (awvGlucoseTestresult != null)
                    testResultRepository.SaveTestResults(awvGlucoseTestresult, customerId, eventId, uploadedby);
            }

            //AwvLipidTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Cholesterol);

            if (isPurchased)
            {
                testResultRepository = new CholesterolTestRepository(ReadingSource.Manual);
                var cholesterolTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                cholesterolTestresult = _kynHealthAssessmentFactory.GetCholesterolTestResultDomain(model, cholesterolTestresult as CholesterolTestResult, uploadedby, isNewResultFlow);
                if (cholesterolTestresult != null)
                    testResultRepository.SaveTestResults(cholesterolTestresult, customerId, eventId, uploadedby);
            }

            //AwvGlucoseTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Diabetes);

            if (isPurchased)
            {
                testResultRepository = new DiabetesTestRepository(ReadingSource.Manual);
                var diabetesTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                diabetesTestresult = _kynHealthAssessmentFactory.GetDiabetesTestResultDomain(model, diabetesTestresult as DiabetesTestResult, uploadedby, isNewResultFlow);
                if (diabetesTestresult != null)
                    testResultRepository.SaveTestResults(diabetesTestresult, customerId, eventId, uploadedby);
            }

            //Hypertension Test Result
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Hypertension);
            if (isPurchased)
            {
                testResultRepository = new HypertensionTestRepository(ReadingSource.Manual);
                var hypertensionTestresult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                hypertensionTestresult = _kynHealthAssessmentFactory.GetHypertensionTestResultDomain(model, hypertensionTestresult as HypertensionTestResult, uploadedby, isNewResultFlow);
                if (hypertensionTestresult != null)
                    testResultRepository.SaveTestResults(hypertensionTestresult, customerId, eventId, uploadedby);
            }

            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.A1C);
            if (isPurchased)
            {
                testResultRepository = new HemaglobinTestRepository(ReadingSource.Manual);
                var hemaglobinTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                hemaglobinTestResult = _kynHealthAssessmentFactory.GetHemaglobinA1CTestResultDomain(model, hemaglobinTestResult as HemaglobinA1CTestResult, uploadedby, isNewResultFlow);
                if (hemaglobinTestResult != null)
                    testResultRepository.SaveTestResults(hemaglobinTestResult, customerId, eventId, uploadedby);
            }

            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvHBA1C);
            if (isPurchased)
            {
                testResultRepository = new AwvHemaglobinTestRepository(ReadingSource.Manual);
                var awvHemaglobinTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                awvHemaglobinTestResult = _kynHealthAssessmentFactory.GetAwvHemaglobinTestResultDomain(model, awvHemaglobinTestResult as AwvHemaglobinTestResult, uploadedby, isNewResultFlow);

                if (awvHemaglobinTestResult != null)
                    testResultRepository.SaveTestResults(awvHemaglobinTestResult, customerId, eventId, uploadedby);
            }

            //MyBioCheckTestresult
            isPurchased = service.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (isPurchased)
            {
                testResultRepository = new MyBioAssessmentTestRepository(ReadingSource.Manual);
                var myBioAssessmentTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                myBioAssessmentTestResult = _kynHealthAssessmentFactory.GetMyBioCheckAssessmentTestResultDomain(model, myBioAssessmentTestResult as MyBioAssessmentTestResult, uploadedby, isNewResultFlow);
                if (myBioAssessmentTestResult != null)
                    testResultRepository.SaveTestResults(myBioAssessmentTestResult, customerId, eventId, uploadedby);
            }
        }

        private void SaveKynLabResult(KynHealthAssessmentEditModel model, long uploadedby, long customerId, long eventId, long eventCustomerResultId, int testId, bool isRecordable,bool  isNewResultFlow)
        {
            if (isRecordable)
            {
                var testResultRepository = new TestResultRepository();
                var kynTestResult = testResultRepository.GetTestResult(customerId, eventId, testId, isNewResultFlow);
                kynTestResult = _kynHealthAssessmentFactory.GetKynTestResultDomain(model, kynTestResult, uploadedby, testId, isNewResultFlow);
                if (kynTestResult != null)
                    testResultRepository.SaveTestResults(kynTestResult, customerId, eventId, uploadedby);
            }

            var kynLabValues = _kynHealthAssessmentFactory.GetKynLabValues(model);
            kynLabValues.EventCustomerResultId = eventCustomerResultId;
            kynLabValues.TestId = testId;
            _kynLabValuesRepository.Save(kynLabValues, uploadedby);

            UpdateFastingStatus(model, eventCustomerResultId);
        }

        private void UpdateFastingStatus(KynHealthAssessmentEditModel model, long eventcustomerResultid)
        {
            if (model.FastingStatus == (long)FastingStatus.Fasting || model.FastingStatus == (long)FastingStatus.NonFasting)
            {
                var eventCustomerResult = _eventCustomerResultRepository.GetById(eventcustomerResultid);
                eventCustomerResult.IsFasting = model.FastingStatus == (long)FastingStatus.Fasting;
                _eventCustomerResultRepository.Save(eventCustomerResult);
            }
        }
    }
}
