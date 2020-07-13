using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Repositories.Screening;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{

    [DefaultImplementation]
    public class GenerateBioCheckJsonPollingAgent : IGenerateBioCheckJsonPollingAgent
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILogManager _logManager;

        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IKynLabValuesRepository _kynLabValuesRepository;
        private readonly IBasicBiometricRepository _basicBiometricRepository;
        private readonly ITraleApiService _trailApiService;
        private readonly IMediaRepository _mediaRepository;
        private readonly IMediaHelper _mediaHelper;
        private readonly ILogger _logger;

        private readonly string _profileId;
        private readonly Service.TestResultService _testResultService;
        private readonly TestResultRepository _bioCheckAssessmentTestResultRepository; // to be used for only Bio check Assessment 
        private TestResultRepository _testResultRepository;// to be used to Get Other Test Result;
        private const string FemaleGender = "F";
        private const string MaleGender = "M";
        private const string Nonsmoker = "Nonsmoker";
        private const string Smoker = "Smoker";
        private readonly bool _isDevEnvironment;
        private const long UploadedBy = 1;


        private static readonly List<OrderedPair<long, string>> LifeStyleDataQuestion =
            new List<OrderedPair<long, string>>
            {
                new OrderedPair<long, string>(1049, "Q1_1"),
                new OrderedPair<long, string>(1050, "Q1_2"),
                new OrderedPair<long, string>(1051, "Q1_3"),
                new OrderedPair<long, string>(1052, "Q1_4"),
                new OrderedPair<long, string>(1053, "Q2_1"),
                new OrderedPair<long, string>(1054, "Q2_2"),
                new OrderedPair<long, string>(1055, "Q2_3"),
                new OrderedPair<long, string>(1056, "Q2_4"),
                new OrderedPair<long, string>(1057, "Q2_5"),
                new OrderedPair<long, string>(1058, "Q2_6"),
                new OrderedPair<long, string>(1059, "Q3_1"),
                new OrderedPair<long, string>(1060, "Q3_2"),
                new OrderedPair<long, string>(1061, "Q3_3"),
                new OrderedPair<long, string>(1062, "Q3_4"),
                new OrderedPair<long, string>(1063, "Q3_5"),
                new OrderedPair<long, string>(1064, "Q4"),
                new OrderedPair<long, string>(1065, "Q5"),
                new OrderedPair<long, string>(1066, "Q6"),
                new OrderedPair<long, string>(1067, "Q7"),
                new OrderedPair<long, string>(1068, "Q8_1"),
                new OrderedPair<long, string>(1069, "Q8_2"),
                new OrderedPair<long, string>(1070, "Q8_3"),
                new OrderedPair<long, string>(1071, "Q8_4"),
            };



        public GenerateBioCheckJsonPollingAgent(IEventCustomerRepository eventCustomerRepository, ILogManager logManager,
             ICustomerRepository customerRepository, IEventRepository eventRepository,
            IHealthAssessmentRepository healthAssessmentRepository, IKynLabValuesRepository kynLabValuesRepository,
            IBasicBiometricRepository basicBiometricRepository, ISettings settings, ITraleApiService trailApiService, IMediaRepository mediaRepository, IMediaHelper mediaHelper)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _logManager = logManager;

            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _kynLabValuesRepository = kynLabValuesRepository;
            _basicBiometricRepository = basicBiometricRepository;
            _trailApiService = trailApiService;
            _mediaRepository = mediaRepository;
            _mediaHelper = mediaHelper;
            _logger = logManager.GetLogger("GenerateBIoCheckJsonPollingAgent");

            _bioCheckAssessmentTestResultRepository = new MyBioAssessmentTestRepository();
            _profileId = settings.ProfileId;
            _isDevEnvironment = settings.IsDevEnvironment;
            _testResultService = new Service.TestResultService();
        }

        public void PollForBiomassEvents()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    _logger.Info("Initialising xml generation.....");

                    var eventsReadyToMyBioMass = _eventRepository.GetEventsForGenerateMyBioCheckAssessment();

                    if (eventsReadyToMyBioMass == null || !eventsReadyToMyBioMass.Any()) return;

                    foreach (var eventdetail in eventsReadyToMyBioMass)
                    {
                        try
                        {
                            var eventlogger = _logManager.GetLogger("BioCheckJson" + eventdetail.Id);

                            _eventRepository.UpateGeneratehkynXmlStatusField(eventdetail.Id, GenerateKynXmlStatus.InProcess);

                            GenerateJsonforEventCustomers(eventdetail, eventlogger);

                            _eventRepository.UpateGeneratehkynXmlStatusField(eventdetail.Id, GenerateKynXmlStatus.Generated);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("Error while generating kyn xml for EventId {0} Message: {1} , StackTrace {2}", eventdetail.Id, exception.Message, exception.StackTrace));
                        }

                    }
                }
                else
                {
                    _logger.Info(string.Format("Generate Kyn Xml Polling can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some Error Occured. Message: {0} , StackTrace {1}", exception.Message, exception.StackTrace));
            }

        }

        private void GenerateJsonforEventCustomers(Event eventData, ILogger logger)
        {
            int totalrecords;

            logger.Info("Getting event customers......");

            var eventCusomters = _eventCustomerRepository.GetMyBioCheckEventCustomers(1, 400, new MyBioCheckCustomerModelFilter { EventId = eventData.Id }, out totalrecords);

            if (eventCusomters == null || !eventCusomters.Any())
            {
                logger.Info(string.Format("No event customers found for Event Id {0} EventDate {1}", eventData.Id, eventData.EventDate));
                return;
            }

            logger.Info(string.Format("{0} event customers found.", eventCusomters.Count()));

            var customers = _customerRepository.GetCustomers(eventCusomters.Select(x => x.CustomerId).ToArray());
            var healthAssessmentAnswer = _healthAssessmentRepository.GetCustomerHealthInfoByEventCustomerIds(eventCusomters.Select(ec => ec.Id).ToArray());

            foreach (var ec in eventCusomters)
            {
                try
                {
                    var customer = customers.Single(c => c.CustomerId == ec.CustomerId);
                    var hafAnswer = healthAssessmentAnswer.Where(c => c.EventCustomerId == ec.Id);

                    logger.Info("Started For EventId: " + ec.EventId + " customerId: " + ec.CustomerId);

                    var bioCheckJsonViewModel = GenerateBioCheckResponseModel(ec, customer, hafAnswer, eventData, logger);

                    if (bioCheckJsonViewModel != null)
                    {
                        bioCheckJsonViewModel.ProfileId = _profileId;
                        logger.Info("Saving Request JSON For eventId: " + ec.EventId + " customerId: " + ec.CustomerId);
                        SaveRequestJson(bioCheckJsonViewModel, ec.EventId, ec.CustomerId);

                        logger.Info("Submitting Post Request For eventId: " + ec.EventId + " customerId: " + ec.CustomerId);
                        var response = _trailApiService.Post<BioCheckJsonViewModel>(bioCheckJsonViewModel);

                        if (response != null)
                        {
                            logger.Info("Saving response For EventId: " + ec.EventId + " customerId: " + ec.CustomerId);
                            SaveReports(response, ec.EventId, ec.CustomerId, logger);
                        }
                        else
                        {
                            logger.Info("No Response found for EventId: " + ec.EventId + " customerId: " + ec.CustomerId);
                        }
                    }
                    logger.Info("Complete For EventId: " + ec.EventId + " customerId: " + ec.CustomerId);
                }
                catch (Exception exception)
                {
                    logger.Error(string.Format("Error while generating My Bio-Check Assessment Data for customer Id: {0} and EventId {1} Message: {2}, StackTrace {3}", ec.CustomerId, ec.EventId, exception.Message, exception.StackTrace));
                }
            }

        }

        private BioCheckJsonViewModel GenerateBioCheckResponseModel(EventCustomer eventCustomer, Customer customer, IEnumerable<HealthAssessmentAnswer> customerHealth, Event eventData, ILogger logger)
        {
            var testResult = _bioCheckAssessmentTestResultRepository.GetTestResults(customer.CustomerId, eventCustomer.EventId);
            var kynLabValues = _kynLabValuesRepository.Get(eventCustomer.Id, (long)TestType.MyBioCheckAssessment);
            var basicBioMeric = _basicBiometricRepository.Get(eventCustomer.EventId, eventCustomer.CustomerId);

            var myBioCheck = testResult as MyBioAssessmentTestResult;

            if (myBioCheck != null && (myBioCheck.TestNotPerformed == null || myBioCheck.TestNotPerformed.TestNotPerformedReasonId <= 0) && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count <= 0))
            {
                var biocheckResponse = new List<BioCheckResponseModel>();
                SetCustomerHafResponse(customerHealth, biocheckResponse); //Q1_1 to Q8_4
                SetCustomerBioMetricResponse(customer, biocheckResponse);//Q9 to Q10
                SetLabValus(biocheckResponse, myBioCheck, kynLabValues, basicBioMeric, customer);//Q11 to Q21
                SetA1CTestData(biocheckResponse, eventCustomer);//Q22
                SetAwvBoneMassTestData(biocheckResponse, eventCustomer); // Q23
                SetPsaTestData(biocheckResponse, eventCustomer); // Q24
                SetNicotineTestData(biocheckResponse); // Q25-27
                SetBmiData(biocheckResponse, customer);// Q28
                SetSmokerData(biocheckResponse, kynLabValues);//Q60

                var bioCheckJsonViewModel = new BioCheckJsonViewModel
                {
                    //ResponseId = Guid.NewGuid().ToString(),
                    UserId = customer.CustomerId.ToString(),
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    DoB = customer.DateOfBirth,
                    CreatedAt = DateTime.Now,
                    CompletedAt = eventData.EventDate,
                    Email = (customer.Email == null || string.IsNullOrEmpty(customer.Email.ToString()))
                            ? string.Empty
                            : customer.Email.ToString(),

                    Gender = customer.Gender == Gender.Female
                            ? FemaleGender
                            : customer.Gender == Gender.Male ? MaleGender : string.Empty,

                    Responses = biocheckResponse.ToArray()
                };
                return bioCheckJsonViewModel;
            }
            //Todo: create XML for Customers JSON Not Created;
            logger.Info("Customer's My bio-check Result not Found");

            return null;
        }

        private void SetCustomerHafResponse(IEnumerable<HealthAssessmentAnswer> customerHealth, List<BioCheckResponseModel> bioCheckResponse)
        {
            bioCheckResponse = bioCheckResponse ?? new List<BioCheckResponseModel>();
            if (customerHealth.IsNullOrEmpty())
            {
                bioCheckResponse.AddRange(LifeStyleDataQuestion.Select(
                      x => new BioCheckResponseModel
                      {
                          Question = x.SecondValue,
                          Value = ((int)LifeStyleDataDictionaryAnswerType.NotAnswered).ToString()
                      }).ToList());
            }


            foreach (var lsd in LifeStyleDataQuestion)
            {
                var answer = customerHealth.FirstOrDefault(x => x.QuestionId == lsd.FirstValue);
                var answerValue = answer == null || string.IsNullOrEmpty(answer.Answer) ? (int)LifeStyleDataDictionaryAnswerType.NotAnswered : BioHafAnswer(answer.Answer);
                bioCheckResponse.Add(new BioCheckResponseModel { Question = lsd.SecondValue, Value = answerValue.ToString() });
            }
        }

        private void SetCustomerBioMetricResponse(Customer customer, List<BioCheckResponseModel> bioCheckResponse)
        {
            double weightInPonds = customer.Weight != null ? customer.Weight.Pounds : 0;
            double heightInInches = customer.Height != null ? customer.Height.TotalInches : 0;


            bioCheckResponse.Add(new BioCheckResponseModel { Question = "Q9", Value = weightInPonds.ToString() });
            bioCheckResponse.Add(new BioCheckResponseModel { Question = "Q10", Value = heightInInches.ToString() });

        }

        private void SetLabValus(List<BioCheckResponseModel> bioCheckResponse, MyBioAssessmentTestResult testResult, KynLabValues kynLabValues, BasicBiometric basicBiometric, Customer customer)
        {
            if (testResult.TotalCholestrol != null)
            {
                if (testResult.TotalCholestrol.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q11", testResult.TotalCholestrol.Reading)); //;
            }
            if (testResult.Hdl != null)
            {
                if (testResult.Hdl.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q12", testResult.Hdl.Reading));
                // testResult.HDL.Reading;
            }

            if (testResult.Ldl != null)
            {
                if (testResult.Ldl.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q13", testResult.Ldl.Reading.Value.ToString()));
                // testResult.LDL.Reading.ToString();
            }

            if (testResult.TcHdlRatio != null)
            {
                if (testResult.TcHdlRatio.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q14", testResult.TcHdlRatio.Reading.Value.ToString()));
                // testResult.LDL.Reading.ToString();
            }

            if (testResult.Glucose != null)
            {
                if (testResult.Glucose.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q15", testResult.Glucose.Reading.Value.ToString()));
                // testResult.LDL.Reading.ToString();
            }

            if (testResult.TriGlycerides != null)
            {
                if (testResult.TriGlycerides.Reading != null)
                    bioCheckResponse.Add(new BioCheckResponseModel("Q16", testResult.TriGlycerides.Reading));
                // testResult.TriGlycerides.Reading;
            }

            if (basicBiometric != null)
            {
                if (basicBiometric.SystolicPressure != null)
                {
                    bioCheckResponse.Add(new BioCheckResponseModel("Q17", basicBiometric.SystolicPressure.Value.ToString()));
                }

                if (basicBiometric.DiastolicPressure != null)
                {
                    bioCheckResponse.Add(new BioCheckResponseModel("Q18", basicBiometric.DiastolicPressure.Value.ToString()));
                }
            }
            bioCheckResponse.Add(new BioCheckResponseModel("Q19", string.Empty));

            if (kynLabValues != null && kynLabValues.FastingStatus != null && kynLabValues.FastingStatus.Value == (long)FastingStatus.Fasting)
                bioCheckResponse.Add(new BioCheckResponseModel("Q20", "true"));
            else
                bioCheckResponse.Add(new BioCheckResponseModel("Q20", "false"));

            decimal waist = customer.Waist != null ? customer.Waist.Value : 0;
            bioCheckResponse.Add(new BioCheckResponseModel { Question = "Q21", Value = waist.ToString() });
        }

        private void SetA1CTestData(List<BioCheckResponseModel> bioCheckResponse, EventCustomer eventCustomer)
        {
            _testResultRepository = new AwvHemaglobinTestRepository();

            var testResult = _testResultRepository.GetTestResults(eventCustomer.CustomerId, eventCustomer.EventId);
            if (testResult != null)
            {
                var a1cTestResult = testResult as AwvHemaglobinTestResult;
                if (a1cTestResult.Hba1c != null)
                {
                    if (a1cTestResult.Hba1c.Reading != null)
                        bioCheckResponse.Add(new BioCheckResponseModel("Q22", a1cTestResult.Hba1c.Reading));
                }
            }
            else
            {
                _testResultRepository = new HemoglobinTestRepository();
                testResult = _testResultRepository.GetTestResults(eventCustomer.CustomerId, eventCustomer.EventId);
                if (testResult != null)
                {
                    var a1cTestResult = testResult as HemaglobinA1CTestResult;
                    if (a1cTestResult.Hba1c != null)
                    {
                        if (a1cTestResult.Hba1c.Reading != null)
                            bioCheckResponse.Add(new BioCheckResponseModel("Q22", a1cTestResult.Hba1c.Reading));
                    }
                }
            }
        }

        private void SetAwvBoneMassTestData(List<BioCheckResponseModel> bioCheckResponse, EventCustomer eventCustomer)
        {
            _testResultRepository = new AwvBoneMassTestRepository();

            var testResult = _testResultRepository.GetTestResults(eventCustomer.CustomerId, eventCustomer.EventId);
            if (testResult != null)
            {
                var awvBoneMassTestResult = testResult as AwvBoneMassTestResult;
                if (awvBoneMassTestResult.EstimatedTScore != null)
                {
                    if (awvBoneMassTestResult.EstimatedTScore.Reading != null)
                        bioCheckResponse.Add(new BioCheckResponseModel("Q23", awvBoneMassTestResult.EstimatedTScore.Reading.Value.ToString()));
                }
            }
            else
            {
                testResult = _testResultRepository.GetTestResults(eventCustomer.CustomerId, eventCustomer.EventId);
                _testResultRepository = new OsteoporosisTestRepository();
                if (testResult != null)
                {
                    var osteoporosisTestResult = testResult as OsteoporosisTestResult;
                    if (osteoporosisTestResult.EstimatedTScore != null)
                    {
                        if (osteoporosisTestResult.EstimatedTScore.Reading != null)
                            bioCheckResponse.Add(new BioCheckResponseModel("Q23", osteoporosisTestResult.EstimatedTScore.Reading.Value.ToString()));
                    }
                }
            }
        }

        private void SetPsaTestData(List<BioCheckResponseModel> bioCheckResponse, EventCustomer eventCustomer)
        {
            _testResultRepository = new PsaTestRepository();

            var testResult = _testResultRepository.GetTestResults(eventCustomer.CustomerId, eventCustomer.EventId);
            if (testResult != null)
            {
                var psaTestResult = testResult as PsaTestResult;
                if (psaTestResult.PSASCR != null)
                {
                    if (psaTestResult.PSASCR.Reading != null)
                        bioCheckResponse.Add(new BioCheckResponseModel("Q24", psaTestResult.PSASCR.Reading));
                }
            }
        }
        private void SetNicotineTestData(List<BioCheckResponseModel> biocheckResponse)
        {
            biocheckResponse.Add(new BioCheckResponseModel("Q25", ""));
            biocheckResponse.Add(new BioCheckResponseModel("Q26", ""));
            biocheckResponse.Add(new BioCheckResponseModel("Q27", ""));
        }

        private void SetBmiData(List<BioCheckResponseModel> biocheckResponse, Customer customer)
        {
            double weightInPounds = customer.Weight != null ? customer.Weight.Pounds : 0;
            double heightInInches = customer.Height != null ? customer.Height.TotalInches : 0;
            var bmiIndex = (weightInPounds < 1 || heightInInches < 1) ? 0 : (weightInPounds / Math.Pow(heightInInches, 2)) * 703;
            biocheckResponse.Add(new BioCheckResponseModel("Q28", bmiIndex.ToString("0.0")));
        }
        private void SetSmokerData(List<BioCheckResponseModel> biocheckResponse, KynLabValues kynLabValues)
        {
            if (kynLabValues != null && kynLabValues.Smoker != null && string.IsNullOrEmpty(kynLabValues.Smoker) && kynLabValues.Smoker == Smoker)
                biocheckResponse.Add(new BioCheckResponseModel("Q60", "true"));
            else
                biocheckResponse.Add(new BioCheckResponseModel("Q60", "false"));
        }

        private int BioHafAnswer(string answer)
        {
            var pair = LifeStyleDataDictionaryAnswerType.NotAnswered.GetNameValuePairs();

            var answerPair = pair.FirstOrDefault(x => x.SecondValue == answer);

            return answerPair == null ? (int)LifeStyleDataDictionaryAnswerType.NotAnswered : answerPair.FirstValue;
        }

        private void SaveRequestJson(BioCheckJsonViewModel request, long eventid, long customerid)
        {
            var mybioCheckMedia = _mediaRepository.GetBioCheckAssessmentLocation(eventid, customerid);
            DirectoryOperationsHelper.SaveFile(mybioCheckMedia.PhysicalPath, customerid + "requestJSON.json", JsonConvert.SerializeObject(request));
        }

        private void SaveReports(BioCheckJsonViewModel repsponse, long eventid, long customerid, ILogger logger)
        {
            var mybioCheckMedia = _mediaRepository.GetBioCheckAssessmentLocation(eventid, customerid);
            var ticks = DateTime.Now.Ticks;
            if (repsponse != null)
            {

                if (!String.IsNullOrEmpty(repsponse.reportSvg))
                {
                    DirectoryOperationsHelper.SaveFile(mybioCheckMedia.PhysicalPath, customerid + "_" + ticks + "_ReportSVG.html", repsponse.reportSvg);
                }

                if (!String.IsNullOrEmpty(repsponse.reportPdf))
                {
                    var filePath = String.Format("{0}\\{1}", mybioCheckMedia.PhysicalPath, customerid + "_" + ticks + "_ReportPDF.PDF");
                    logger.Info("Saving Report pdf at Path" + filePath);
                    DirectoryOperationsHelper.SaveFileBase64Text(mybioCheckMedia.PhysicalPath, customerid + "_" + ticks + "_ReportPDF.PDF", repsponse.reportPdf);

                    logger.Info("Updating Test Result for EventId: " + eventid + " CustomerId: " + customerid + " Report pdf at Path" + filePath);
                    UpdateCustomerResultMedia(filePath, customerid, eventid, logger);
                }

                DirectoryOperationsHelper.SaveFile(mybioCheckMedia.PhysicalPath, customerid + "_" + ticks + "_ResponseJSON.json", JsonConvert.SerializeObject(repsponse));
            }
        }

        private void UpdateCustomerResultMedia(string pdfFilePath, long customerId, long eventid, ILogger logger)
        {
            string folderToSavePdf = _mediaRepository.GetResultMediaFileLocation(customerId, eventid).PhysicalPath;
            var mediaFiles = GetMediaFromPdfFile(pdfFilePath, folderToSavePdf, TestType.MyBioCheckAssessment);
            mediaFiles.ReadingSource = ReadingSource.Automatic;

            var testResult = new MyBioAssessmentTestResult { ResultImage = mediaFiles };

            var eventCustomerResult = SaveEventCustomerResult(eventid, customerId);

            SaveTestResult(testResult, eventid, customerId, eventCustomerResult.ResultState, eventCustomerResult.IsPartial, logger);
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, TestType testType)
        {
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testType.ToString());
        }

        private EventCustomerResult SaveEventCustomerResult(long eventId, long customerId)
        {
            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

            return eventCustomerResult;
        }

        private void SaveTestResult(TestResult testResult, long eventId, long customerId, int resultState, bool isPartial, ILogger logger)
        {
            testResult.ResultStatus = new TestResultState
            {
                StateNumber = resultState >= (int)TestResultStateNumber.PreAudit ? (TestResultStateNumber)resultState : TestResultStateNumber.ResultsUploaded,
                Status = resultState > (int)TestResultStateNumber.PreAudit && isPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete

            };
            testResult.DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(UploadedBy), DateCreated = DateTime.Now };

            try
            {
                _testResultService.SaveTestResult(testResult, eventId, customerId, UploadedBy, logger, ReadingSource.Automatic);
            }
            catch (Exception exception)
            {
                logger.Error(string.Format("Eawv HRA Result Parser SaveTestResult:  exceptions- {0}\n StackTrace{1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}