using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ResultPacketGeneratorAfterPhysicianEvaluationPollingAgent : IResultPacketGeneratorAfterPhysicianEvaluationPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IGenerateFinalPdf _generateFinalPdf;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerPackageTestDetailService _evenyCustomerPackageTestDetailService;
        private readonly string _contentPages;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;
        private readonly ITestResultService _testResultService;
        private readonly ISendTestMediaFilesPublisher _sendTestMediaFilesPublisher;
        private readonly string _ipResultSftpFolderLocation;
        private string _tempMediaLocation;
        private ISendMediaFileHelper _sendMediaFileHelper;
        private readonly IAppointmentRepository _appointmentRepository;

        public ResultPacketGeneratorAfterPhysicianEvaluationPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, IGenerateFinalPdf generateFinalPdf,
            ISettings settings, IMediaRepository mediaRepository, ILogManager logManager, IPdfGenerator pdfGenerator, ICustomerRepository customerRepository,
            IEventRepository eventRepository, IEventCustomerPackageTestDetailService evenyCustomerPackageTestDetailService, ICorporateAccountRepository corporateAccountRepository,
            IPhysicianEvaluationRepository physicianEvaluationRepository, ITestResultService testResultService, ISendTestMediaFilesPublisher sendTestMediaFilesPublisher, ISendMediaFileHelper sendMediaFileHelper,
            IAppointmentRepository appointmentRepository)
        {
            _logger = logManager.GetLogger("ResultPacketGeneratorAfterPhysicianEvaluationPollingAgent");
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _generateFinalPdf = generateFinalPdf;
            _pdfGenerator = pdfGenerator;
            _settings = settings;
            _customerRepository = customerRepository;
            _contentPages = settings.ContentPages;
            _eventRepository = eventRepository;
            _evenyCustomerPackageTestDetailService = evenyCustomerPackageTestDetailService;
            _corporateAccountRepository = corporateAccountRepository;
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _testResultService = testResultService;
            _ipResultSftpFolderLocation = _settings.IpResultSftpFolderLocation;
            _sendTestMediaFilesPublisher = sendTestMediaFilesPublisher;
            _sendMediaFileHelper = sendMediaFileHelper;
            _appointmentRepository = appointmentRepository;
        }

        public void PollForResultPacketGeneration()
        {
            try
            {
                _logger.Info("\n************************************Entering into the IP Result PDF Generation service********************************************** \n");

                var eventCustomers = _eventCustomerResultRepository.GetEvaluatedByPhysicianEventCustomerResult();

                var distinctEventIds = eventCustomers != null ? eventCustomers.Select(ec => ec.EventId).Distinct().ToList() : new List<long>();

                distinctEventIds = distinctEventIds.Distinct().ToList();

                if (distinctEventIds.Count < 1)
                {
                    _logger.Info("No Data found for IP Result PDF Generation.");
                    return;
                }

                var events = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(distinctEventIds);

                distinctEventIds = events.OrderByDescending(e => e.EventDate).Select(e => e.Id).ToList();

                _tempMediaLocation = _mediaRepository.GetTempMediaFileLocation().PhysicalPath;

                foreach (var eventId in distinctEventIds)
                {
                    _logger.Info("\n************************************************************************************************************ \n");
                    _logger.Info("**************************************** Starting Event Id " + eventId + " **************************************** \n");

                    var eventdata = events.First(x => x.Id == eventId);

                    var isNewResultFlow = eventdata.EventDate >= _settings.ResultFlowChangeDate;

                    if (eventCustomers != null)
                    {
                        var customersForGivenEvent = eventCustomers.Where(ec => ec.EventId == eventId).ToArray();
                        if (customersForGivenEvent.Any())
                        {
                            var eventCustomerIds = customersForGivenEvent.Select(x => x.Id);

                            var physicianEvaluationList = _physicianEvaluationRepository.GetPhysicianEvaluation(eventCustomerIds);
                            var customerSkipReviews = _physicianEvaluationRepository.GetCustomerSkipReviews(eventCustomerIds);

                            _logger.Info("\n ****************** IP Result Pdf Generation for Fresh Records \n");

                            foreach (var eventCustomer in customersForGivenEvent)
                            {
                                _logger.Info("Publishing: Send Test Media, EventID : " + eventCustomer.EventId + " CustomerId: " + eventCustomer.CustomerId);
                                _sendTestMediaFilesPublisher.PublishSendTestMediaFiles(eventCustomer.EventId, eventCustomer.CustomerId);
                                _logger.Info("Publish Successfully: Send Test Media, EventID : " + eventCustomer.EventId + " CustomerId: " + eventCustomer.CustomerId);

                                var ipResultMediaLocation = _mediaRepository.GetIpResultPdfLocation(eventCustomer.EventId, eventCustomer.CustomerId, false);
                                DirectoryOperationsHelper.DeleteDirectory(ipResultMediaLocation.PhysicalPath, true);
                                var tempIpPdfLocation = _tempMediaLocation + Guid.NewGuid() + ".pdf";

                                IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations = null;
                                if (physicianEvaluationList != null)
                                {
                                    eventCustomerPhysicianEvaluations = physicianEvaluationList.Where(x => x.EventCustomerId == eventCustomer.Id);
                                }

                                var skipPdfGeneration = false;
                                if (eventCustomerPhysicianEvaluations.IsNullOrEmpty())
                                {
                                    _logger.Info("No Physician Evaluation found for CustomerId: " + eventCustomer.CustomerId + " and EventId: " + eventCustomer.EventId);
                                    skipPdfGeneration = true;
                                }

                                if (customerSkipReviews != null && customerSkipReviews.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null)
                                {
                                    _logger.Info("Patient Test evaluation was skipped for CustomerId: " + eventCustomer.CustomerId + " and EventId: " + eventCustomer.EventId);
                                    skipPdfGeneration = true;
                                }

                                var tests = _evenyCustomerPackageTestDetailService.GetTestsPurchasedByEventCustomerId(eventCustomer.Id);
                                if (!tests.Any(x => x.IsReviewable))
                                {
                                    _logger.Info("No test is marked reviewable for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);
                                    skipPdfGeneration = true;
                                }

                                _logger.Info("Getting only IsReviewable test for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);
                                tests = tests.Where(x => x.IsReviewable && (x.ResultEntryTypeId.HasValue == false || x.ResultEntryTypeId == (long)ResultEntryType.Hip)).ToList();

                                if (tests.Count == 0)
                                {
                                    _logger.Info("All re-viewable task entry may be filled by Chat for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);
                                    skipPdfGeneration = true;
                                }

                                tests = tests.Where(x => TestGroup.TestIdForIpPdf.Contains(x.Id)).ToList();
                                if (tests.Count == 0)
                                {
                                    _logger.Info("No test is available to generate IP PDF for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);
                                    skipPdfGeneration = true;
                                }

                                var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
                                var corporateAccount = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);

                                var success = false;
                                if (!skipPdfGeneration)
                                {
                                    success = GenerateResultPacket(eventCustomer, customer, corporateAccount, eventCustomerPhysicianEvaluations, null, eventdata, isNewResultFlow, tests, tempIpPdfLocation);
                                }

                                if (skipPdfGeneration || success)
                                {
                                    _logger.Info("Updating Event Customer For IP Result Pdf Generated: EventId: " + eventCustomer.EventId + " CustomerId: " + eventCustomer.CustomerId);
                                    _eventCustomerResultRepository.UpdateIsIpResultGenerated(eventCustomer.Id, true);
                                    _testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.PdfGenerated, false, eventCustomer.DataRecorderMetaData.DataRecorderModifier.Id);
                                    _logger.Info("Updated Event Customer For IP Result Pdf Generated: EventId: " + eventCustomer.EventId + " CustomerId: " + eventCustomer.CustomerId);
                                }
                                GenerateChaperonePdf(customer, corporateAccount, eventdata, ipResultMediaLocation, eventCustomer.Id);
                                MergeMediaFiles(customer, eventdata, tempIpPdfLocation, ipResultMediaLocation.PhysicalPath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }

        private bool GenerateResultPacket(EventCustomerResult eventCustomer, Customer customer, CorporateAccount corporateAccount, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, Event eventData, bool isNewResultFlow, List<Test> tests, string tempIpPdfLocation)
        {
            try
            {
                _logger.Info("Starting Pdf Generation for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);

                //var corporateAccount = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);

                GeneratePremiumVersion(eventData, customer, tests, corporateAccount, eventCustomerPhysicianEvaluations, customerSkipReview, isNewResultFlow, tempIpPdfLocation);

                return true;

            }
            catch (Exception ex)
            {
                RevertPacketGeneration(eventCustomer);
                _logger.Error("IP Result Pdf Generation Failure! Message: " + ex.Message + " \n\t" + ex.StackTrace);
            }

            return false;
        }

        private void GeneratePremiumVersion(Event eventData, Customer customer, List<Test> eventTests, CorporateAccount corporateAccount, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, bool isNewResultFlow, string tempIpPdfLocation)
        {
            try
            {
                var eventId = eventData.Id;
                var ipResultMediaLocation = _mediaRepository.GetIpResultPdfLocation(eventId, customer.CustomerId);

                var htmlFileName = _mediaRepository.GetHtmlFileNameForIpResultPdf(customer.CustomerId, customer.AcesId, customer.Name.FirstName, customer.Name.LastName, eventData.EventDate.Year);
                //var pdfFileName = _mediaRepository.GetPdfFileNameForIpResultPdf(customer.CustomerId, customer.AcesId, customer.Name.FirstName, customer.Name.LastName, eventData.EventDate.Year);

                var htmlPathforCustomerIpResultPdf = ipResultMediaLocation.PhysicalPath + htmlFileName;
                var htmlUrlforCustomerIpResultPdf = ipResultMediaLocation.Url + htmlFileName;
                //var pdfPathforCustomerIpResultPdf = ipResultMediaLocation.PhysicalPath + pdfFileName;
                //var mediaPath = _mediaRepository.GetResultMediaFileLocation(customer.CustomerId, eventId).PhysicalPath;

                //string kynPdf = "";
                //try
                //{
                //    kynPdf = GetKynPdfforCustomer(eventId, customer.CustomerId);
                //}
                //catch (Exception ex)
                //{
                //    _logger.Error("Error while merging KYN. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                //}

                //string HkynPdf = "";
                //try
                //{
                //    HkynPdf = GetHkynPdfforCustomer(eventId, customer.CustomerId);
                //}
                //catch (Exception ex)
                //{
                //    _logger.Error("Error while merging HKYN. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                //}

                //var attachUploadedPdfTestIds = TestGroup.AttacheUploadedMediaOnIpResultPdf;
                //var uploadedPdfForCustomer = string.Empty;
                //var isTestsPurchased = false;
                //var eawvPdfReport = string.Empty;
                //var showUnreadableTest = corporateAccount != null && corporateAccount.AttachUnreadableTest;
                //var focAttestation = string.Empty;
                //var mammogram = string.Empty;
                //var ifobt = string.Empty;
                //var urineMicroalbumin = string.Empty;
                //var chlamydia = string.Empty;
                //var awvBoneMass = string.Empty;
                //var osteoporosis = string.Empty;
                //var quantaFloAbi = string.Empty;
                //var myBiocheckAssessment = string.Empty;

                try
                {
                    //isTestsPurchased = eventTests.Any(et => attachUploadedPdfTestIds.Contains(et.Id));

                    //if (isTestsPurchased)
                    //{
                    //    uploadedPdfForCustomer = GetAttachUploatedPdfForCustomer(eventId, customer.CustomerId, eventTests, showUnreadableTest, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);
                    //if (isTestsPurchased)
                    //{
                    //    eawvPdfReport = GetEawvPdfResult(eventId, customer.CustomerId, false, true, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.FocAttestation);

                    //if (isTestsPurchased)
                    //{
                    //    focAttestation = GetFocAttestationPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Mammogram);

                    //if (isTestsPurchased)
                    //{
                    //    mammogram = GetMammogramPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.IFOBT);
                    //if (isTestsPurchased)
                    //{
                    //    ifobt = GetIfobtPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.UrineMicroalbumin);
                    //if (isTestsPurchased)
                    //{
                    //    urineMicroalbumin = GetUrineMicroalbuminPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Chlamydia);
                    //if (isTestsPurchased)
                    //{
                    //    chlamydia = GetChlamydiaPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.AwvBoneMass);
                    //if (isTestsPurchased)
                    //{
                    //    awvBoneMass = GetAwvBoneMassPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Osteoporosis);
                    //if (isTestsPurchased)
                    //{
                    //    osteoporosis = GetOsteoporosisPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.QuantaFloABI);
                    //if (isTestsPurchased)
                    //{
                    //    quantaFloAbi = GetQuantaFloPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                    //isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.MyBioCheckAssessment);
                    //if (isTestsPurchased)
                    //{
                    //    myBiocheckAssessment = GetMyBioCheckPdfResult(eventId, customer.CustomerId, isNewResultFlow);
                    //}

                }
                catch (Exception ex)
                {
                    _logger.Error("Error while merging awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                }

                //var bloodLetterTestIds = TestGroup.BloodWorkTestIds;
                //string bloodLetterPdf = "";
                //isTestsPurchased = false;
                //try
                //{
                //    isTestsPurchased = eventTests.Any(et => bloodLetterTestIds.Contains(et.Id));

                //    if (isTestsPurchased && File.Exists(_settings.TemplateBloodLetterLoaction) && !(_settings.CaptureBloodTest && eventData.EventDate.Date >= _settings.BloodTestChangeDate))
                //    {
                //        bloodLetterPdf = _settings.TemplateBloodLetterLoaction;
                //    }

                //}
                //catch (Exception ex)
                //{
                //    _logger.Error("Error while generating blood letter. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                //}

                var dob = string.Empty;
                if (customer.DateOfBirth.HasValue)
                    dob = " DOB:" + customer.DateOfBirth.Value.ToString("MM/dd/yyyy");

                _logger.Info("Generating IP Result HTML file for CustomerId: " + customer.CustomerId + " and EventId: " + eventId);
                var hasSectionToDisplay = _generateFinalPdf.CreatePremiumPdf(htmlPathforCustomerIpResultPdf, customer, eventData, false, null, true, eventCustomerPhysicianEvaluations, customerSkipReview, true);


                if (hasSectionToDisplay)
                {
                    _logger.Info("Generating IP Result PDF file for CustomerId: " + customer.CustomerId +
                                 " and EventId: " + eventId);
                    _pdfGenerator.GeneratePdf(htmlUrlforCustomerIpResultPdf, tempIpPdfLocation, true,
                        customer.NameAsString + " [" + customer.CustomerId + "]" + dob + " Testing Date:" +
                        eventData.EventDate.ToShortDateString(),
                        "", "", _contentPages, "", "", "", "", false, string.Empty, false, false, "", "",
                        "", "", hasSectionToDisplay, "", "", "", "", "", "", "", "", "", "");
                    _logger.Info("Generated IP Result PDF file for CustomerId: " + customer.CustomerId + " and EventId: " + eventId);

                }
                else
                {
                    _logger.Info("No Section for display customer Id: " + customer.CustomerId + " EventId: " + eventId);
                }

                if (_settings.CleanUpHtmlFiles) // If clean up is on
                {
                    try
                    {
                        _logger.Info("Cleaning up directory for CustomerId: " + customer.CustomerId + " and EventId: " + eventId);
                        CleanUpDirectory(ipResultMediaLocation.PhysicalPath);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cleaning Up IP Result Pdf Directory path [" + ipResultMediaLocation.PhysicalPath + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error IP Result: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                throw new Exception("Error Caused while generating IP Result Pdf!", ex);
            }
        }

        //private string GetKynPdfforCustomer(long eventId, long customerId)
        //{

        //    var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, customerId);
        //    if (!Directory.Exists(location.PhysicalPath)) return null;

        //    var files = Directory.GetFiles(location.PhysicalPath, TestType.Kyn + "*.pdf");

        //    if (files.Count() < 1) return null;

        //    var fileToCreate = location.PhysicalPath + customerId + ".pdf";

        //    var letterPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.LetterWriter)).SingleOrDefault();
        //    var participantSummReportPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport)).SingleOrDefault();
        //    var physicianSummReportPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.PhysicianSummaryReport)).SingleOrDefault();

        //    if (string.IsNullOrEmpty(letterPdf) && string.IsNullOrEmpty(participantSummReportPdf) && string.IsNullOrEmpty(physicianSummReportPdf))
        //        return null;

        //    if (File.Exists(fileToCreate)) File.Delete(fileToCreate);

        //    var filesCollection = new List<string>();
        //    if (!string.IsNullOrEmpty(letterPdf)) filesCollection.Add(letterPdf);
        //    if (!string.IsNullOrEmpty(participantSummReportPdf)) filesCollection.Add(participantSummReportPdf);
        //    if (!string.IsNullOrEmpty(physicianSummReportPdf)) filesCollection.Add(physicianSummReportPdf);

        //    _pdfGenerator.Merge(fileToCreate, filesCollection);

        //    return fileToCreate;
        //}

        //private string GetHkynPdfforCustomer(long eventId, long customerId)
        //{

        //    var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, customerId);
        //    if (!Directory.Exists(location.PhysicalPath)) return null;

        //    var files = Directory.GetFiles(location.PhysicalPath, TestType.HKYN + "*.pdf");

        //    if (!files.Any()) return null;

        //    var fileToCreate = location.PhysicalPath + customerId + ".pdf";

        //    var participantSummReportPdf = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport));

        //    if (string.IsNullOrEmpty(participantSummReportPdf))
        //        return null;

        //    if (File.Exists(fileToCreate)) File.Delete(fileToCreate);

        //    var filesCollection = new List<string>();
        //    if (!string.IsNullOrEmpty(participantSummReportPdf)) filesCollection.Add(participantSummReportPdf);

        //    _pdfGenerator.Merge(fileToCreate, filesCollection);

        //    return fileToCreate;
        //}

        private void RevertPacketGeneration(EventCustomerResult eventCustomerResult)
        {
            var directory = _mediaRepository.GetIpResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId).PhysicalPath;
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            eventCustomerResult.IsIpResultGenerated = false;

            _eventCustomerResultRepository.Save(eventCustomerResult);
        }

        private static void CleanUpDirectory(string path, IEnumerable<string> fileException = null)
        {
            fileException = fileException == null ? new string[0] : fileException.Where(f => !string.IsNullOrWhiteSpace(f)).Select(f => f.ToLower()).ToArray();

            foreach (var file in Directory.GetFiles(path))
            {
                if (string.Compare(Path.GetExtension(file), ".pdf", true) == 0 || fileException.Contains(file.ToLower())) continue;
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                CleanUpDirectory(dir);
                Directory.Delete(dir);
            }
        }

        //private string GetAttachUploatedPdfForCustomer(long eventId, long customerId, IEnumerable<Test> eventTest, bool showUnreadableTest, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);
        //        var mediaResultPdfFiles = new List<string>();

        //        if (location != null && Directory.Exists(location.PhysicalPath))
        //        {
        //            TestResultRepository testRepository = null;
        //            TestResult testResult = null;
        //            List<ResultMedia> pdfFiles = null;

        //            if (eventTest.Any(et => et.Id == (long)TestType.AWV))
        //            {
        //                testRepository = new AwvTestRepository();
        //                testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvTestResult;

        //                if (testResult != null && ((AwvTestResult)testResult).ResultImages != null && ((AwvTestResult)testResult).ResultImages.Any())
        //                {
        //                    pdfFiles = ((AwvTestResult)testResult).ResultImages;

        //                    var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

        //                    mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //                }
        //            }

        //            if (eventTest.Any(et => et.Id == (long)TestType.AwvSubsequent))
        //            {

        //                testRepository = new AwvSubsequentTestRepository();
        //                testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvSubsequentTestResult;

        //                if (testResult != null && ((AwvSubsequentTestResult)testResult).ResultImages != null && ((AwvSubsequentTestResult)testResult).ResultImages.Any())
        //                {
        //                    pdfFiles = ((AwvSubsequentTestResult)testResult).ResultImages;

        //                    var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

        //                    mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //                }
        //            }

        //            if (eventTest.Any(et => et.Id == (long)TestType.Medicare))
        //            {
        //                testRepository = new MedicareTestRepository();
        //                testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MedicareTestResult;

        //                if (testResult != null && ((MedicareTestResult)testResult).ResultImages != null && ((MedicareTestResult)testResult).ResultImages.Any())
        //                {
        //                    pdfFiles = ((MedicareTestResult)testResult).ResultImages;

        //                    var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

        //                    mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
        //                    if (mediaPdf != null)
        //                        mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //                }
        //            }

        //            // GetEawvPdfResult(eventId, customerId, eventTest, isForPcp, attachEawvPreventionPlan, mediaResultPdfFiles, location);
        //            if (eventTest.Any(et => et.Id == (long)TestType.DiabeticRetinopathy))
        //            {
        //                testRepository = new DiabeticRetinopathyTestRepository();
        //                testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as DiabeticRetinopathyTestResult;

        //                if (testResult != null && ((DiabeticRetinopathyTestResult)testResult).ResultImage != null)
        //                {
        //                    var mediaPdf = ((DiabeticRetinopathyTestResult)testResult).ResultImage;
        //                    mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //                }
        //            }

        //            if (eventTest.Any(et => et.Id == (long)TestType.FloChecABI))
        //            {
        //                testRepository = new FloChecABITestRepository();
        //                var floChectestResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as FloChecABITestResult;

        //                if (floChectestResult != null && floChectestResult.ResultImage != null && (floChectestResult.UnableScreenReason == null || floChectestResult.UnableScreenReason.Count == 0)
        //                    && (showUnreadableTest || floChectestResult.RepeatStudy == null || floChectestResult.RepeatStudy.Reading == false))
        //                {
        //                    var mediaPdf = floChectestResult.ResultImage;

        //                    mediaResultPdfFiles.Add(location.PhysicalPath + Path.GetFileNameWithoutExtension(mediaPdf.File.Path) + ".pdf");
        //                }
        //            }
        //        }

        //        if (mediaResultPdfFiles.Any())
        //        {
        //            if (mediaResultPdfFiles.Count() == 1)
        //            {
        //                fileToCreate = mediaResultPdfFiles.First();
        //            }
        //            else
        //            {
        //                fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "AwvTestResults_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
        //                _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);
        //            }
        //        }

        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;

        //    }

        //    return fileToCreate;
        //}

        //private string GetIfobtPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new IFOBTTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as IFOBTTestResult;

        //        if (testResult != null && ((IFOBTTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((IFOBTTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetUrineMicroalbuminPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new UrineMicroalbuminTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as UrineMicroalbuminTestResult;

        //        if (testResult != null && ((UrineMicroalbuminTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((UrineMicroalbuminTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetChlamydiaPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new ChlamydiaTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as ChlamydiaTestResult;

        //        if (testResult != null && ((ChlamydiaTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((ChlamydiaTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetAwvBoneMassPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new AwvBoneMassTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvBoneMassTestResult;

        //        if (testResult != null && ((AwvBoneMassTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((AwvBoneMassTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetOsteoporosisPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new OsteoporosisTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as OsteoporosisTestResult;

        //        if (testResult != null && ((OsteoporosisTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((OsteoporosisTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetQuantaFloPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new QuantaFloABITestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as QuantaFloABITestResult;

        //        if (testResult != null && ((QuantaFloABITestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((QuantaFloABITestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetMyBioCheckPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new MyBioAssessmentTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MyBioAssessmentTestResult;

        //        if (testResult != null && ((MyBioAssessmentTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((MyBioAssessmentTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetEawvPdfResult(long eventId, long customerId, bool isForPcp, bool attachEawvPreventionPlan, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        TestResultRepository testRepository;
        //        TestResult testResult;
        //        List<ResultMedia> pdfFiles;

        //        var mediaResultPdfFiles = new List<string>();
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        testRepository = new EAwvTestRepository();
        //        testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as EAwvTestResult;

        //        if (testResult != null && ((EAwvTestResult)testResult).ResultImages != null && ((EAwvTestResult)testResult).ResultImages.Any())
        //        {
        //            pdfFiles = ((EAwvTestResult)testResult).ResultImages;

        //            if (isForPcp)
        //            {
        //                _logger.Info("adding Snapshot file");
        //                var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
        //                if (mediaPdf != null)
        //                    mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //            }

        //            if (isForPcp)
        //            {
        //                _logger.Info("adding Result export file");
        //                var resultExportPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.ResultExport.ToLower()));
        //                if (resultExportPdf != null)
        //                    mediaResultPdfFiles.Add(location.PhysicalPath + resultExportPdf.File.Path);
        //            }

        //            if (attachEawvPreventionPlan)
        //            {
        //                _logger.Info("adding PreventionPlan file");
        //                var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
        //                if (mediaPdf != null)
        //                    mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
        //            }
        //        }


        //        if (mediaResultPdfFiles.Any())
        //        {
        //            if (mediaResultPdfFiles.Count() == 1)
        //            {
        //                fileToCreate = mediaResultPdfFiles.First();
        //            }
        //            else
        //            {
        //                fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "EAwvTestResults_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
        //                _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetMammogramPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new MammogramTestRepository();

        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MammogramTestResult;

        //        if (testResult != null && ((MammogramTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((MammogramTestResult)testResult).ResultImage;
        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        //private string GetFocAttestationPdfResult(long eventId, long customerId, bool isNewResultFlow)
        //{
        //    var fileToCreate = string.Empty;
        //    try
        //    {
        //        var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

        //        TestResultRepository testRepository = new FocAttestationTestRepository();
        //        TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as FocAttestationTestResult;

        //        if (testResult != null && ((FocAttestationTestResult)testResult).ResultImage != null)
        //        {
        //            var pdfFiles = ((FocAttestationTestResult)testResult).ResultImage;

        //            if (pdfFiles != null)
        //            {
        //                fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
        //        throw exception;
        //    }

        //    return fileToCreate;
        //}

        private bool MergeMediaFiles(Customer customer, Event eventData, string tempIpPdfLocation, string ipPdfLocation)
        {
            try
            {
                _logger.Info("Getting media files for other Tests");

                var testIdToCopyMedia = new List<long>();
                testIdToCopyMedia.AddRange(_settings.IpSendMediaFilesForTestIds);
                testIdToCopyMedia.AddRange(_settings.AdditionalTestIdToSendMediaFiles);
                var mediaPath = _mediaRepository.GetResultMediaFileLocation(customer.CustomerId, eventData.Id).PhysicalPath;

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(ipPdfLocation);

                var pdfFileName = _mediaRepository.GetPdfFileNameForIpResultPdf(customer.CustomerId, customer.AcesId, customer.Name.FirstName, customer.Name.LastName, eventData.EventDate.Year);

                var pdfPathforCustomerIpResultPdf = ipPdfLocation + pdfFileName;

                var files = _eventCustomerResultRepository.GetMediaByEventIdAndCustomerId(eventData.Id, customer.CustomerId, testIdToCopyMedia);
                files = !files.IsNullOrEmpty() ? files.Where(x => !x.Contains("Thumb_")) : null;

                if (!files.IsNullOrEmpty())
                {
                    _logger.Info("Merging Test Files...");

                    var fileToMerge = new List<string>();

                    files.ForEach(x =>
                    {
                        if (DirectoryOperationsHelper.IsFileExist(mediaPath + x))
                            fileToMerge.Add(mediaPath + x);
                        else
                            _logger.Info(string.Format("File {0} not found for EventId: {1} and CustomerId:{2} ", x, eventData.Id, customer.CustomerId));
                    });

                    var tempPdfPath = _tempMediaLocation + Guid.NewGuid() + ".pdf";

                    _logger.Info(string.Format("Merging {0} media files in Temp Pdf", fileToMerge.Count));
                    _pdfGenerator.Merge(tempPdfPath, fileToMerge);

                    _logger.Info("Merging Temp Pdf in IP Result Pdf");

                    if (DirectoryOperationsHelper.IsFileExist(tempIpPdfLocation))
                        _pdfGenerator.Merge(pdfPathforCustomerIpResultPdf, new string[] { tempIpPdfLocation, tempPdfPath });
                    else
                        _pdfGenerator.Merge(pdfPathforCustomerIpResultPdf, new string[] { tempPdfPath });

                    _logger.Info("IP Result Pdf generated for CustomerId: " + customer.CustomerId + " and EventId: " + eventData.Id);

                }
                else
                {
                    _logger.Info("No media files found.");
                    if (DirectoryOperationsHelper.IsFileExist(tempIpPdfLocation))
                    {
                        _pdfGenerator.Merge(pdfPathforCustomerIpResultPdf, new string[] { tempIpPdfLocation });
                        _logger.Info("IP Result Pdf generated for CustomerId: " + customer.CustomerId + " and EventId: " + eventData.Id);
                    }
                    else
                        _logger.Info("No tests and no media files found for IP Pdf generation for CustomerId: " + customer.CustomerId + " and EventId: " + eventData.Id);
                }

                CopyFileToSftp(eventData, customer, ipPdfLocation, pdfFileName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred while merging files. Error : " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                return false;
            }
        }

        private void CopyFileToSftp(Event eventData, Customer customer, string dir, string fileToRenameForIpPdf)
        {
            try
            {

                var eventDate_ = eventData.EventDate;
                if (eventDate_ < _settings.StopSendingMediaFileDate)
                {
                    _logger.Info("We are not Sending media file of event which event Date is less then " + _settings.StopSendingMediaFileDate + ". Event Id " + eventData.Id + ", Customer Id " + customer.CustomerId);
                    return;
                }

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(_ipResultSftpFolderLocation);

                if (DirectoryOperationsHelper.IsDirectoryExist(dir))
                {
                    _logger.Info("Starting copy file to SFTP");

                    var pdfFiles = DirectoryOperationsHelper.GetFiles(dir, "*.pdf");
                    foreach (var pdf in pdfFiles)
                    {
                        if (DirectoryOperationsHelper.IsFileExist(pdf))
                        {
                            var fileName = Path.GetFileName(pdf);

                            if (!IsCopySinglePdfFileToSftp(customer, eventData, fileName, dir))
                            {
                                if (fileName == fileToRenameForIpPdf)
                                {
                                    fileName = GetFileNameToShare(customer, eventData);
                                }

                                var sftpFileName = Path.Combine(_ipResultSftpFolderLocation, fileName);

                                _logger.Info("Source: " + pdf);
                                _logger.Info("Destination: " + sftpFileName);

                                DirectoryOperationsHelper.DeleteFileIfExist(sftpFileName);
                                DirectoryOperationsHelper.Copy(pdf, sftpFileName);

                                _logger.Info("File posted to SFTP at " + sftpFileName + " for CustomerId: " + customer.CustomerId + " and EventId: " + eventData.Id);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred while posting file to SFTP. Error : " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
            }

        }

        private string GetFileNameToShare(Customer customer, Event eventData)
        {
            var appentAcesIdOrCustomerId = string.IsNullOrEmpty(customer.AcesId) ? "NoAcesId_" + customer.CustomerId : customer.AcesId;
            return "Screenings_" + appentAcesIdOrCustomerId + "_" + customer.Name.FirstName.Replace(" ", string.Empty) + "_" + customer.Name.LastName.Replace(" ", string.Empty) + "_" + eventData.EventDate.Year + ".pdf";
        }

        private bool IsCopySinglePdfFileToSftp(Customer customer, Event eventData, string mediaFile, string mediaPath)
        {
            try
            {
                var testType = mediaFile.Split('_')[0].ToString();

                if (TestGroup.FormType.Contains(testType))
                    return true;

                if (!TestGroup.SinglePdfTest.Contains(testType))// && !FormType.Contains(testType)
                {
                    return false;
                }

                _logger.Info("Start Copy Media file(" + mediaFile + ") for customer Id: " + customer.CustomerId + " and Event Id: " + eventData.Id);

                var corporateAccount = _corporateAccountRepository.GetbyEventId(eventData.Id);

                var fileExtention = Path.GetExtension(mediaFile);
                var fileAndFolderName = _sendMediaFileHelper.GetSftpFileAndFolder(corporateAccount, customer, eventData, testType, fileExtention);

                CopyMediaFile(mediaPath, fileAndFolderName.SecondValue, mediaFile, fileAndFolderName.FirstValue);
            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
            return true;
        }

        private void CopyMediaFile(string mediaPath, string destinationPath, string mediaFile, string newFileName)
        {
            var sourceFileName = Path.Combine(mediaPath, mediaFile);
            try
            {
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);
                if (DirectoryOperationsHelper.IsFileExist(sourceFileName))
                {
                    DirectoryOperationsHelper.DeleteFileIfExist(Path.Combine(destinationPath, newFileName));
                    DirectoryOperationsHelper.Copy(sourceFileName, Path.Combine(destinationPath, newFileName));
                    _logger.Info("Media file(" + sourceFileName + ") successfully copied with new Name " + newFileName + " on location " + destinationPath);
                }
                else
                {
                    _logger.Info("Media file(" + sourceFileName + ") does not exist on Media file Location");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: Media file(" + sourceFileName + ") does not exist on Media file Location. Exception message " + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }

        }

        private void GenerateChaperonePdf(Customer customer, CorporateAccount corporateAccount, Event eventdata, MediaLocation mediaLocation, long eventCustomerId)
        {
            try
            {

                if (!corporateAccount.ShowChaperonForm)
                {
                    _logger.Info("ShowChaperonForm setting is off at Account: " + corporateAccount.Id);
                    return;
                }

                var appointment = _appointmentRepository.GetEventCustomerAppointment(eventdata.Id, customer.CustomerId);

                if (appointment == null)
                {
                    _logger.Info("Customer is not schedule for EventId: " + eventdata.Id + ", CustomerId: " + customer.CustomerId);
                    return;
                }

                if (appointment.CheckInTime == null || appointment.CheckOutTime == null)
                {
                    _logger.Info("Appointment checkin or checkout time is not filled for EventId: " + eventdata.Id + ", CustomerId: " + customer.CustomerId);
                    return;
                }

                _logger.Info("Generating Chaperone PDF");

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(mediaLocation.PhysicalPath);
                var url = _settings.ChaperoneFormUrl + string.Format("?eventId={0}&customerId={1}", eventdata.Id, customer.CustomerId);

                var acesId = string.IsNullOrWhiteSpace(customer.AcesId) ? "NoAcesId_" + customer.CustomerId : customer.AcesId;
                string fileName = PatientFormType.Chaperone.ToString() + "_" + acesId + "_" + customer.Name.LastName + "_" + customer.Name.FirstName + "_" + eventdata.EventDate.ToString("MMddyyyy") + ".pdf";

                _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

                _logger.Info("Chaperone PDF is Generated");
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occurred while generating chaperone form.");
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
            }

        }
    }
}