using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IResultPacketGeneratorPollingAgent))]
    public class ResultPacketGeneratorPollingAgent : IResultPacketGeneratorPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IGenerateFinalPdf _generateFinalPdf;
        private readonly IMediaRepository _mediaRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly ICdContentCreator _cdContentCreator;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly ITestResultRepository _testResultRepository;
        private readonly IZipHelper _zipHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMedicalVendorRepository _medicalVendorRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IEventCustomerPackageTestDetailService _evenyCustomerPackageTestDetailService;

        //        private readonly string _companyCustomizedLetter;
        private readonly string _contentPages;
        private string _doctorLetter;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IPcpShippingService _pcpShippingService;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;
        private readonly IAttestationFormService _attestationFormService;
        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICustomerShippingService _customerShippingService;


        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailTemplateFormatter _emailTemplateFormatter;
        private readonly INotificationSubscriberRepository _notificationSubscriberRepository;
        private readonly ITestNotPerformedRepository _testNotPerformedRepository;

        public ResultPacketGeneratorPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, IGenerateFinalPdf generateFinalPdf, IElectronicProductRepository electronicProductRepository, ISettings settings,
                                                IMediaRepository mediaRepository, ICdContentCreator cdContentCreator, ILogManager logManager, IPdfGenerator pdfGenerator, IZipHelper zipHelper, ICustomerRepository customerRepository,
                                                IEventRepository eventRepository, IMedicalVendorRepository medicalVendorRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
                                                IHospitalPartnerRepository hospitalPartnerRepository, IShippingDetailRepository shippingDetailRepository, IEventCustomerPackageTestDetailService evenyCustomerPackageTestDetailService,
                                                ICorporateAccountRepository corporateAccountRepository, IEventCustomerRepository eventCustomerRepository, IHospitalFacilityRepository hospitalFacilityRepository,
                                                IPcpShippingService pcpShippingService, IPhysicianEvaluationRepository physicianEvaluationRepository, IAttestationFormService attestationFormService,
                                                IPcpAppointmentRepository pcpAppointmentRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICustomerShippingService customerShippingService, IEmailNotificationModelsFactory emailNotificationModelsFactory, IEmailTemplateRepository emailTemplateRepository, IEmailTemplateFormatter emailTemplateFormatter, INotificationSubscriberRepository notificationSubscriberRepository, ITestNotPerformedRepository testNotPerformedRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _electronicProductRepository = electronicProductRepository;
            _mediaRepository = mediaRepository;
            _generateFinalPdf = generateFinalPdf;
            _cdContentCreator = cdContentCreator;
            _pdfGenerator = pdfGenerator;
            _zipHelper = zipHelper;
            _settings = settings;
            _customerRepository = customerRepository;
            _testResultRepository = new TestResultRepository();
            _logger = logManager.GetLogger("ResultPacketGenerator");
            //_companyCustomizedLetter = settings.CompanyCustomizedLetter;
            _contentPages = settings.ContentPages;
            //_doctorLetter = settings.DoctorLetter;
            _eventRepository = eventRepository;
            _medicalVendorRepository = medicalVendorRepository;
            _fileRepository = fileRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _evenyCustomerPackageTestDetailService = evenyCustomerPackageTestDetailService;
            _corporateAccountRepository = corporateAccountRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _pcpShippingService = pcpShippingService;
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _attestationFormService = attestationFormService;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _customerShippingService = customerShippingService;

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _emailTemplateRepository = emailTemplateRepository;
            _emailTemplateFormatter = emailTemplateFormatter;
            _notificationSubscriberRepository = notificationSubscriberRepository;
            _testNotPerformedRepository = testNotPerformedRepository;
        }

        public void PollForResultPacketGeneration()
        {
            try
            {
                var eventCustomers = _eventCustomerResultRepository.GetEventCustomerResults((int)TestResultStateNumber.PostAudit, true, (int)NewTestResultStateNumber.PdfGenerated);
                var regenrationRecords = _eventCustomerResultRepository.GetRecordsforRegeneration();

                var distinctEventIds = eventCustomers != null ? eventCustomers.Select(ec => ec.EventId).Distinct().ToList() : new List<long>();
                if (regenrationRecords != null)
                    distinctEventIds.AddRange(regenrationRecords.Select(ec => ec.EventId).Distinct());

                distinctEventIds = distinctEventIds.Distinct().ToList();

                if (distinctEventIds.Count < 1) return;

                var events = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(distinctEventIds);

                distinctEventIds = events.OrderByDescending(e => e.EventDate).Select(e => e.Id).ToList();

                var distinctEventCustomerIds = eventCustomers != null ? eventCustomers.Select(ec => ec.Id).Distinct().ToList() : new List<long>();

                if (regenrationRecords != null)
                    distinctEventCustomerIds.AddRange(regenrationRecords.Select(ec => ec.Id).Distinct());

                var physicianEvaluationList = _physicianEvaluationRepository.GetPhysicianEvaluation(distinctEventCustomerIds);

                var customerSkipReviews = _physicianEvaluationRepository.GetCustomerSkipReviews(distinctEventCustomerIds);

                foreach (var eventId in distinctEventIds)
                {
                    _doctorLetter = _settings.DoctorLetter;
                    try
                    {
                        var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
                        if (hospitalPartnerId > 0)
                        {
                            var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                            if (hospitalPartner.AttachDoctorLetter)
                            {
                                var medicalVendor = _medicalVendorRepository.GetMedicalVendor(hospitalPartnerId);
                                if (medicalVendor.DoctorLetterFileId.HasValue && medicalVendor.DoctorLetterFileId.Value > 0)
                                {
                                    var fileName = _fileRepository.GetById(medicalVendor.DoctorLetterFileId.Value);
                                    _doctorLetter = _mediaRepository.GetOrganizationDoctorLetterFolderLocation().PhysicalPath + fileName.Path;
                                }
                            }
                            else
                            {
                                _doctorLetter = string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error while setting Doctor Letter: {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                    }



                    _logger.Info("\n************************************************************************************************************ \n");
                    _logger.Info("**************************************** Starting Event Id " + eventId + " **************************************** \n");
                    bool generateCdforEvent = false;

                    int countGenerated = 0;
                    var eventdata = events.FirstOrDefault(x => x.Id == eventId);

                    var isNewResultFlow = eventdata.EventDate >= _settings.ResultFlowChangeDate;

                    if (eventCustomers != null)
                    {
                        var customersForGivenEvent = eventCustomers.Where(ec => ec.EventId == eventId).ToArray();
                        if (customersForGivenEvent.Count() > 0)
                        {
                            _logger.Info("\n ****************** Result Packet Generation for Fresh Records \n");

                            foreach (var eventCustomer in customersForGivenEvent)
                            {
                                bool isCdPurchased = false;
                                IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations = null;
                                if (physicianEvaluationList != null)
                                {
                                    eventCustomerPhysicianEvaluations = physicianEvaluationList.Where(x => x.EventCustomerId == eventCustomer.Id);
                                }

                                CustomerSkipReview customerSkipReview = null;
                                if (customerSkipReviews != null)
                                {
                                    customerSkipReview = customerSkipReviews.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);
                                }

                                GenerateResultPacket(eventCustomer, eventCustomerPhysicianEvaluations, customerSkipReview, out isCdPurchased, eventdata, isNewResultFlow, true);
                                if (isCdPurchased) generateCdforEvent = true;

                                countGenerated++;
                            }
                        }
                    }

                    if (regenrationRecords != null)
                    {
                        var customersForGivenEvent = regenrationRecords.Where(ec => ec.EventId == eventId).ToArray();
                        if (customersForGivenEvent.Count() > 0)
                        {
                            _logger.Info("\n ****************** Result Packet Generation for Regenerate Records \n");

                            foreach (var eventCustomer in customersForGivenEvent)
                            {
                                var customerId = eventCustomer.CustomerId;

                                try
                                {
                                    var premiumPdf = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId);
                                    if (Directory.Exists(premiumPdf.PhysicalPath)) Directory.Delete(premiumPdf.PhysicalPath, true);

                                    var cdContent = _mediaRepository.GetCdContentFolderLocation(eventId, customerId);
                                    if (Directory.Exists(cdContent.PhysicalPath))
                                    {
                                        Directory.Delete(cdContent.PhysicalPath, true);
                                        cdContent = _mediaRepository.GetCdContentFolderLocation(eventId);
                                        var path = cdContent.PhysicalPath + customerId + ".zip";

                                        if (File.Exists(path))
                                        {
                                            DirectoryOperationsHelper.Delete(path);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.Info("\nFailed while cleaning up directories for regeneration of CustomerId: " + customerId + "! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                                    continue;
                                }

                                bool isCdPurchased = false;
                                IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations = null;
                                if (physicianEvaluationList != null)
                                {
                                    eventCustomerPhysicianEvaluations = physicianEvaluationList.Where(x => x.EventCustomerId == eventCustomer.Id);
                                }

                                CustomerSkipReview customerSkipReview = null;
                                if (customerSkipReviews != null)
                                {
                                    customerSkipReview = customerSkipReviews.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);
                                }
                                GenerateResultPacket(eventCustomer, eventCustomerPhysicianEvaluations, customerSkipReview, out isCdPurchased, eventdata, isNewResultFlow);

                                if (isCdPurchased) generateCdforEvent = true;
                                countGenerated++;
                            }
                        }
                    }

                    if (countGenerated == 0)
                    {
                        continue;
                    }

                    if (generateCdforEvent)
                    {
                        try
                        {
                            _logger.Info("\n ****************** CD Content Generation ********************\n");
                            _cdContentCreator.ZipCdContentsPerEvent(eventId);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Cd Content failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }
                    }

                    var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);

                    if (eventCustomerResults == null || !eventCustomerResults.Any())
                    {
                        _logger.Info("\n ****************** No Event Customer REsult Found ********************\n");
                    }
                    else
                    {
                        if (isNewResultFlow)
                            eventCustomerResults = eventCustomerResults.Where(x => x.ResultState >= (int)NewTestResultStateNumber.PostAuditNew);
                        else
                            eventCustomerResults = eventCustomerResults.Where(ecr => ecr.ResultState >= (long)TestResultStateNumber.PostAudit && !ecr.IsPartial);

                        try
                        {
                            _logger.Info("\n ****************** All Result PDF Generation ********************\n");
                            GenerateAllResultPdfZip(eventId, eventCustomerResults);

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }

                        try
                        {
                            _logger.Info("\n ****************** All Result PDF Paper Only Generation ********************\n");
                            GenerateAllResultPdfPaperCopyOnlyZip(eventId, eventCustomerResults);

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf Paper Only failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }

                        try
                        {
                            _logger.Info("\n ****************** All Result PDF Online Only Generation ********************\n");
                            GenerateAllResultPdfOnlineOnlyZip(eventId, eventCustomerResults);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf Online Only failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }

                        try
                        {
                            _logger.Info("\n ****************** All Result PDF Pcp Only Generation ********************\n");
                            GenerateAllResultPdfPcpOnlyZip(eventId, eventCustomerResults);

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf Pcp Only failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }

                        try
                        {
                            _logger.Info("\n **************** All Result PDF For Eawv Reports Generation *******************\n");
                            GenerateAllEawvResultReportPdfOnlyZip(eventId, eventCustomerResults);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf Eawv Reports Only failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        }
                        try
                        {
                            _logger.Info("\n **************** All Result PDF For Eawv Reports Generation *******************\n");
                            GenerateAllHealthPlanResultReportPdfOnlyZip(eventId, eventCustomerResults);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("\nZip Premium Pdf Eawv Reports Only failed for Event: " + eventId + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
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

        //public void GeneratePremiumPdfZipforpendingEvents()
        //{
        //    try
        //    {
        //        var eventIds = _eventCustomerResultRepository.GetEventWithResultDeliveredRecords();

        //        foreach (var eventId in eventIds)
        //        {
        //            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
        //            if (File.Exists(location.PhysicalPath + _mediaRepository.GetAllPremiumPdfName(eventId) + ".zip"))
        //                continue;

        //            var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);
        //            GenerateAllResultPdfZip(eventId, eventCustomerResults);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("\nError occured while generating Downloadable Zip for Result Report for Pending Events. Message: " + ex.Message + "\n\tStack Trace: " + ex.StackTrace);
        //    }
        //}

        private bool IsCdContentRequired(long eventId, long customerId, EventCustomerResult eventCustomer)
        {
            if (eventCustomer.ResultSummary.HasValue && eventCustomer.ResultSummary != (long)ResultInterpretation.Normal)
            {
                var customerResultStatus = _eventCustomerResultRepository.GetTestResultStatusforEventCustomer(eventId, customerId);
                if (customerResultStatus != null && customerResultStatus.TestResults != null)
                    return customerResultStatus.TestResults.Any(x => TestGroup.UltraSoundImageTestIds.Contains(x.TestId) && x.TestInterpretation.HasValue && x.TestInterpretation.Value != (long)ResultInterpretation.Normal);
            }

            return false;
        }

        private void GenerateResultPacket(EventCustomerResult eventCustomer, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, out bool isCdPurchased, Event eventData, bool isNewResultFlow, bool updateState = false)
        {
            isCdPurchased = false;
            try
            {
                _logger.Info("Starting Pdf Generation for Customer " + eventCustomer.CustomerId + " & Event: " + eventCustomer.EventId);

                var tests = _evenyCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventCustomer.EventId, eventCustomer.CustomerId);
                var corporateAccount = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);

                if (corporateAccount != null && corporateAccount.IsHealthPlan)
                {
                    tests = tests.Where(t => t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip).ToList();
                }

                if (tests.Count == 0)
                {
                    _logger.Info("Test not available for Result PDF generation.may be result entry done by CHAT for Customer @" + eventCustomer.CustomerId + " & Event @" + eventCustomer.EventId);

                    eventCustomer.IsClinicalFormGenerated = true;
                    eventCustomer.IsResultPdfGenerated = true;

                    _eventCustomerResultRepository.Save(eventCustomer);

                    _testResultRepository.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.ResultDelivered, false, eventCustomer.DataRecorderMetaData.DataRecorderModifier.Id);
                    _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomer.EventId, eventCustomer.CustomerId);

                    return;
                }

                isCdPurchased = _electronicProductRepository.IsProductPurchased(eventCustomer.EventId, eventCustomer.CustomerId, Product.UltraSoundImages);

                if (corporateAccount != null && corporateAccount.AddImagesForAbnormal && !isCdPurchased && tests.Any(x => TestGroup.UltraSoundImageTestIds.Contains(x.Id)))
                {
                    var isCdContentRequired = IsCdContentRequired(eventCustomer.EventId, eventCustomer.CustomerId, eventCustomer);
                    if (isCdContentRequired)
                    {
                        isCdPurchased = _pcpShippingService.AddPcpProductShipping(eventCustomer.CustomerId, eventCustomer.EventId);
                    }
                }

                var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
                GeneratePremiumVersion(eventData, customer, tests, corporateAccount, eventCustomerPhysicianEvaluations, customerSkipReview, isNewResultFlow);

                eventCustomer.IsClinicalFormGenerated = true;
                eventCustomer.IsResultPdfGenerated = true;

                _eventCustomerResultRepository.Save(eventCustomer);

                if (isCdPurchased)
                {
                    var mediaLocationIndexPage = _mediaRepository.GetCdContentFolderLocation(eventCustomer.EventId, eventCustomer.CustomerId);

                    _generateFinalPdf.CreatePacketIndexPage(mediaLocationIndexPage.PhysicalPath + _mediaRepository.GetHtmlFileNameForResultReport(), customer, eventData);
                    _cdContentCreator.GenerateCdContent(eventCustomer.EventId, eventCustomer.CustomerId, corporateAccount);

                }
                else
                {
                    try
                    {
                        var mediaLocationIndexPage = _mediaRepository.GetCdContentFolderLocation(eventCustomer.EventId, eventCustomer.CustomerId);
                        if (Directory.Exists(mediaLocationIndexPage.PhysicalPath))
                            Directory.Delete(mediaLocationIndexPage.PhysicalPath, true);

                        var destinationDir = Directory.GetParent(mediaLocationIndexPage.PhysicalPath).FullName;
                        var outputPath = destinationDir + ".zip";

                        if (File.Exists(outputPath))
                            File.Delete(outputPath);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("\nSome Exception while removing CD Folder for Product not Purchased. Message: " + ex.Message);
                    }
                }

                if (updateState)
                {
                    if (isNewResultFlow)
                    {
                        //var resultState = (int)NewTestResultStateNumber.PdfGenerated;

                        //var isEawvTestNotPerformed = _testNotPerformedRepository.IsTestNotPerformed(eventCustomer.Id, (long)TestType.eAWV);


                        //if (corporateAccount == null || corporateAccount.IsHealthPlan == false || isEawvTestNotPerformed || (eventCustomer.AcesApprovedOn.HasValue && eventCustomer.AcesApprovedOn.Value.Date <= DateTime.Now.Date))
                        //{
                        //    resultState = (int)NewTestResultStateNumber.ResultDelivered;
                        //}

                        _testResultRepository.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.ResultDelivered, false, eventCustomer.DataRecorderMetaData.DataRecorderModifier.Id);
                        _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomer.EventId, eventCustomer.CustomerId);
                    }
                    else
                    {
                        _testResultRepository.UpdateStateforPacketGenerated(eventCustomer.Id);
                        _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomer.EventId, eventCustomer.CustomerId);
                    }
                }
            }
            catch (Exception ex)
            {
                RevertPacketGeneration(eventCustomer);
                _logger.Error("Result Packet Generation Failure! Message: " + ex.Message + " \n\t" + ex.StackTrace);
            }
        }

        private void GeneratePremiumVersion(Event eventData, Customer customer, List<Test> eventTests, CorporateAccount corporateAccount, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, bool isNewResultFlow)
        {
            try
            {
                var eventId = eventData.Id;
                var customerId = customer.CustomerId;
                var mediaLocationPremiumVersion = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId);

                var htmlPathforCustomerPremiumPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForResultReport();
                var htmlUrlforCustomerPremiumPdf = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForResultReport();
                var pdfPathforCustomerPremiumPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForResultReport();

                var htmlPathForCoverLetterForCustomerResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForCoverLetter();
                var htmlUrlForCoverLetterForCustomerResult = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForCoverLetter();
                var pdfPathForCoverLetterForCustomerResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForCoverLetter();

                var eventTestsIds = eventTests.Select(et => et.Id).ToArray();

                string corporateFluffLetter = "";

                if (corporateAccount != null && corporateAccount.GenerateCustomerResult && corporateAccount.CorporateWhiteLabeling)
                {
                    try
                    {
                        _generateFinalPdf.CreateCorporateCoverLetterForPremiumPdf(customerId, corporateAccount.Id, htmlPathForCoverLetterForCustomerResult);

                        if (corporateAccount.FluffLetterFileId > 0)
                        {
                            var fileName = _fileRepository.GetById(corporateAccount.FluffLetterFileId).Path;
                            var filePath = _mediaRepository.GetCorporateFluffLetterFolderLocation().PhysicalPath + fileName;
                            corporateFluffLetter = File.Exists(filePath) ? filePath : "";
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while generating corporate cover letter: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        throw ex;
                    }
                }
                else if (corporateAccount == null || (corporateAccount.GenerateCustomerResult || corporateAccount.GenerateEawvPreventionPlanReport))
                {
                    if (_settings.CheckShippingPurchase)
                    {
                        var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventId, customerId);
                        if (shippingDetails != null && shippingDetails.Any())
                            _generateFinalPdf.CreateCoverLetterForCustomerResultReport(customerId, htmlPathForCoverLetterForCustomerResult);
                    }
                    else
                    {
                        _generateFinalPdf.CreateCoverLetterForCustomerResultReport(customerId, htmlPathForCoverLetterForCustomerResult);
                    }
                }
                var scannedDocuments = string.Empty;
                if (corporateAccount != null && corporateAccount.AttachScannedDoc)
                {
                    if (corporateAccount.Id == _settings.NammAccountId)
                    {
                        scannedDocuments = GetAttestationFormForNammAccount(customerId, corporateAccount, eventData);
                    }
                    else
                    {
                        scannedDocuments = GetAttachScannedDocumentPdf(eventData.Id, customerId, eventData.EventDate);
                    }
                }


                //participant Letter
                var participantLetter = string.Empty;
                if (corporateAccount != null && corporateAccount.ParticipantLetterId > 0)
                {
                    try
                    {
                        var fileName = _fileRepository.GetById(corporateAccount.ParticipantLetterId).Path;
                        var filePath = _mediaRepository.GetCorporateParticipantLetterFolderLocation().PhysicalPath + fileName;
                        participantLetter = DirectoryOperationsHelper.IsFileExist(filePath) ? filePath : "";
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while generating participant Letter : " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        throw ex;
                    }
                }

                var attestationForm = GetAttestationForm(customerId, corporateAccount, eventData);

                //Member Letter 
                var memberLetter = string.Empty;
                if (corporateAccount != null && corporateAccount.IncludeMemberLetter && corporateAccount.MemberCoverLetterTemplateId.HasValue && corporateAccount.MemberCoverLetterTemplateId > 0)
                {
                    var emailTemplate = _emailTemplateRepository.GetById(corporateAccount.MemberCoverLetterTemplateId.Value);
                    //var emailTemplate = _emailTemplateRepository.GetByAlias("BCBSMIMemberLetterTemplate");
                    var doctorSignatureFilePath = _settings.SignatureForCoverLetterRelativePath;
                    var memberLetterModel = _emailNotificationModelsFactory.GetCoverLetterTemplateViewModel(customer.Name.FullName, doctorSignatureFilePath, string.Empty, DateTime.Today);
                    var formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, memberLetterModel, "", "", "", emailTemplate.Id).Body;
                    string memberLetterhtmlPath = mediaLocationPremiumVersion.PhysicalPath + "MemberLetter.html";
                    string memberLetterpdfPath = mediaLocationPremiumVersion.PhysicalPath + "MemberLetter.pdf";
                    string memberLetterHtmlUrl = mediaLocationPremiumVersion.Url + "MemberLetter.html";

                    _pdfGenerator.GenerateHtml(formatMessage, memberLetterhtmlPath, memberLetterHtmlUrl, memberLetterpdfPath);
                    memberLetter = memberLetterpdfPath;
                }
                else if (corporateAccount != null && corporateAccount.IncludeMemberLetter && corporateAccount.MemberLetterFileId > 0)
                {
                    try
                    {
                        var fileName = _fileRepository.GetById(corporateAccount.MemberLetterFileId).Path;
                        var filePath = _mediaRepository.GetCorporateMemberLetterPdfFolderLocation().PhysicalPath + fileName;
                        memberLetter = DirectoryOperationsHelper.IsFileExist(filePath) ? filePath : "";
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while generating Member Letter : " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        throw ex;
                    }
                }

                var customerDoctorLetter = (corporateAccount != null && corporateAccount.IsHealthPlan) ? string.Empty : _doctorLetter;


                var showHeaderImageInReport = (corporateAccount == null) || (corporateAccount.UseHeaderImage);

                var customizedLetter = string.Empty;
                var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);

                if (_eventRepository.AttachHospitalMaterial(eventId))
                {
                    var fileId = _medicalVendorRepository.GetMedicalVendor(_hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId)).ResultLetterCoBrandingFileId;

                    if (eventCustomer.HospitalFacilityId.HasValue && eventCustomer.HospitalFacilityId.Value > 0)
                    {
                        var hospitalFacility = _hospitalFacilityRepository.GetHospitalFacility(eventCustomer.HospitalFacilityId.Value);
                        if (hospitalFacility.ResultLetterFileId.HasValue && hospitalFacility.ResultLetterFileId.Value > 0)
                            fileId = hospitalFacility.ResultLetterFileId.Value;
                    }

                    try
                    {
                        var fileName = _fileRepository.GetById(fileId ?? 0);
                        customizedLetter = _mediaRepository.GetOrganizationResultLetterFolderLocation().PhysicalPath + fileName.Path;
                    }
                    catch (ObjectNotFoundInPersistenceException<Core.Application.Domain.File> ex)
                    {
                        _logger.Error("Hospital Partner customized letter not found. Details - Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        throw ex;
                    }
                }

                string kynPdf = "";
                try
                {
                    kynPdf = GetKynPdfforCustomer(eventId, customerId);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error while merging KYN. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                }

                string HkynPdf = "";
                try
                {
                    HkynPdf = GetHkynPdfforCustomer(eventId, customerId);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error while merging HKYN. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                }

                var attachUploadedPdfTestIds = TestGroup.AttachUploadedPdfTestIds;
                var uploadedPdfForCustomer = string.Empty;
                var isTestsPurchased = false;
                var eawvPdfReport = string.Empty;
                var showUnreadableTest = corporateAccount != null && corporateAccount.AttachUnreadableTest;
                var focAttestation = string.Empty;
                var mammogram = string.Empty;
                var ifobt = string.Empty;
                var urineMicroalbumin = string.Empty;
                var chlamydia = string.Empty;
                var awvBoneMass = string.Empty;
                var osteoporosis = string.Empty;
                var quantaFloAbi = string.Empty;
                var myBiocheckAssessment = string.Empty;

                var dpn = string.Empty;

                if (corporateAccount == null || (corporateAccount.GenerateCustomerResult && !corporateAccount.IsCustomerResultsTestDependent))
                {
                    try
                    {
                        isTestsPurchased = eventTests.Any(et => attachUploadedPdfTestIds.Contains(et.Id));

                        if (isTestsPurchased)
                        {
                            uploadedPdfForCustomer = GetAttachUploatedPdfForCustomer(eventId, customerId, eventTests, showUnreadableTest, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);
                        if (isTestsPurchased)
                        {
                            eawvPdfReport = GetEawvPdfResult(eventId, customerId, false, true, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.FocAttestation);

                        if (isTestsPurchased)
                        {
                            focAttestation = GetFocAttestationPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Mammogram);

                        if (isTestsPurchased)
                        {
                            mammogram = GetMammogramPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.IFOBT);
                        if (isTestsPurchased)
                        {
                            ifobt = GetIfobtPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.UrineMicroalbumin);
                        if (isTestsPurchased)
                        {
                            urineMicroalbumin = GetUrineMicroalbuminPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Chlamydia);
                        if (isTestsPurchased)
                        {
                            chlamydia = GetChlamydiaPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.AwvBoneMass);
                        if (isTestsPurchased)
                        {
                            awvBoneMass = GetAwvBoneMassPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Osteoporosis);
                        if (isTestsPurchased)
                        {
                            osteoporosis = GetOsteoporosisPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.QuantaFloABI);
                        if (isTestsPurchased)
                        {
                            quantaFloAbi = GetQuantaFloPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.MyBioCheckAssessment);
                        if (isTestsPurchased)
                        {
                            myBiocheckAssessment = GetMyBioCheckPdfResult(eventId, customerId, isNewResultFlow);
                        }

                        isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.DPN);
                        if (isTestsPurchased)
                        {
                            dpn = GetDpnPdfResult(eventId, customerId, isNewResultFlow);
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while merging awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }
                }

                var isEawvTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);

                var bloodLetterTestIds = TestGroup.BloodWorkTestIds;
                string bloodLetterPdf = "";
                isTestsPurchased = false;
                try
                {
                    isTestsPurchased = eventTests.Any(et => bloodLetterTestIds.Contains(et.Id));

                    if (isTestsPurchased && File.Exists(_settings.TemplateBloodLetterLoaction) && !(_settings.CaptureBloodTest && eventData.EventDate.Date >= _settings.BloodTestChangeDate))
                    {
                        bloodLetterPdf = _settings.TemplateBloodLetterLoaction;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("Error while generating blood letter. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                }

                var dob = string.Empty;
                if (customer.DateOfBirth.HasValue)
                    dob = " DOB:" + customer.DateOfBirth.Value.ToString("MM/dd/yyyy");

                var copyMedia = true;
                var copySupportMedia = true;
                string eawvGeneratedFileName = "";

                //Customer Report
                IEnumerable<long> customerResultTestIds = null;
                if (corporateAccount != null && corporateAccount.GenerateCustomerResult && corporateAccount.IsCustomerResultsTestDependent)
                {
                    eawvPdfReport = string.Empty;
                    focAttestation = string.Empty;
                    customerResultTestIds = _corporateAccountRepository.GetAccountCustomerResultTestDependency(corporateAccount.Id);

                    if (customerResultTestIds != null && eventTests.Any(et => customerResultTestIds.Contains(et.Id) && et.IsRecordable))
                    {
                        uploadedPdfForCustomer = string.Empty;
                        try
                        {
                            var pdfTests = eventTests.Where(et => attachUploadedPdfTestIds.Contains(et.Id) && customerResultTestIds.Contains(et.Id)).Select(et => et).ToArray();

                            if (pdfTests.Any())
                            {
                                uploadedPdfForCustomer = GetAttachUploatedPdfForCustomer(eventId, customerId, pdfTests, showUnreadableTest, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);

                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.eAWV))
                            {
                                eawvPdfReport = GetEawvPdfResult(eventId, customerId, false, true, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging eawv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.FocAttestation);

                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.FocAttestation))
                            {
                                focAttestation = GetFocAttestationPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Foc Attestation result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Mammogram);
                            mammogram = string.Empty;
                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.Mammogram))
                            {
                                mammogram = GetMammogramPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Mammogram result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.IFOBT);
                            ifobt = string.Empty;
                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.IFOBT))
                            {
                                ifobt = GetIfobtPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging IFOBT result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.UrineMicroalbumin);
                            urineMicroalbumin = string.Empty;
                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.UrineMicroalbumin))
                            {
                                urineMicroalbumin = GetUrineMicroalbuminPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging UrineMicroalbumin result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Chlamydia);
                            chlamydia = string.Empty;
                            if (isTestsPurchased && customerResultTestIds.Contains((long)TestType.Chlamydia))
                            {
                                chlamydia = GetChlamydiaPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging chlamydia result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.AwvBoneMass);
                            if (isTestsPurchased)
                            {
                                awvBoneMass = GetAwvBoneMassPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging AwvBoneMass result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }


                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Osteoporosis);
                            if (isTestsPurchased)
                            {
                                osteoporosis = GetOsteoporosisPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Osteoporosis result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.QuantaFloABI);
                            if (isTestsPurchased)
                            {
                                quantaFloAbi = GetQuantaFloPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging QuantaFloAbi result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.MyBioCheckAssessment);
                            if (isTestsPurchased)
                            {
                                myBiocheckAssessment = GetMyBioCheckPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging myBiocheckAssessment result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.DPN);
                            dpn = string.Empty;
                            if (isTestsPurchased)
                            {
                                dpn = GetDpnPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging DPN result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        var awvpdfPath = uploadedPdfForCustomer;
                        var hasAwvTestInCustomerResultSetting = customerResultTestIds.Any(t => attachUploadedPdfTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasAwvTestInCustomerResultSetting)
                            awvpdfPath = string.Empty;

                        var bloodLetterPdfPath = bloodLetterPdf;
                        var hasBloodLetterTestInCustomerResultSetting = customerResultTestIds.Any(t => bloodLetterTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasBloodLetterTestInCustomerResultSetting)
                            bloodLetterPdfPath = string.Empty;

                        var hasSectionToDisplay = _generateFinalPdf.CreatePremiumPdf(htmlPathforCustomerPremiumPdf, customer, eventData, true, customerResultTestIds, showHeaderImageInReport, eventCustomerPhysicianEvaluations, customerSkipReview);

                        if (File.Exists(htmlPathForCoverLetterForCustomerResult))
                            _pdfGenerator.GeneratePdf(htmlUrlForCoverLetterForCustomerResult, pdfPathForCoverLetterForCustomerResult);
                        else
                            pdfPathForCoverLetterForCustomerResult = "";

                        _pdfGenerator.GeneratePdf(htmlUrlforCustomerPremiumPdf, pdfPathforCustomerPremiumPdf, true, customer.NameAsString + " [" + customerId + "]" + dob + " Testing Date:" + eventData.EventDate.ToShortDateString(),
                            pdfPathForCoverLetterForCustomerResult, customizedLetter, _contentPages, kynPdf, bloodLetterPdfPath, customerDoctorLetter, corporateFluffLetter, false, awvpdfPath, false, false, scannedDocuments, eawvPdfReport,
                            focAttestation, "", hasSectionToDisplay, mammogram, ifobt, urineMicroalbumin, participantLetter, chlamydia, awvBoneMass, osteoporosis, quantaFloAbi, hkyn: HkynPdf, mybioCheckAssessment: myBiocheckAssessment, memberLetter: memberLetter, greenFormAttestation: attestationForm, dpn: dpn);
                        copyMedia = false;
                    }
                }
                else if (corporateAccount != null && corporateAccount.GenerateEawvPreventionPlanReport)
                {
                    if (isEawvTestsPurchased)
                    {
                        copySupportMedia = false;
                        _logger.Info("Entering- EAWV Prevention Plan Report");
                        eawvGeneratedFileName = GenerateEawvPreventionPlanReport(customerId, corporateAccount, eventId, eventCustomer, participantLetter, isNewResultFlow, memberLetter: memberLetter);
                        _logger.Info("Completed- EAWV Prevention Plan Report");
                    }
                    else
                    {
                        _logger.Info("EAWV Test Not Availed");
                    }
                }
                else if (corporateAccount == null || corporateAccount.GenerateCustomerResult)
                {
                    var hasSectionToDisplay = _generateFinalPdf.CreatePremiumPdf(htmlPathforCustomerPremiumPdf, customer, eventData, false, null, showHeaderImageInReport, eventCustomerPhysicianEvaluations, customerSkipReview);

                    if (File.Exists(htmlPathForCoverLetterForCustomerResult))
                        _pdfGenerator.GeneratePdf(htmlUrlForCoverLetterForCustomerResult, pdfPathForCoverLetterForCustomerResult);
                    else
                        pdfPathForCoverLetterForCustomerResult = "";

                    _pdfGenerator.GeneratePdf(htmlUrlforCustomerPremiumPdf, pdfPathforCustomerPremiumPdf, true, customer.NameAsString + " [" + customerId + "]" + dob + " Testing Date:" + eventData.EventDate.ToShortDateString(),
                        pdfPathForCoverLetterForCustomerResult, customizedLetter, _contentPages, kynPdf, bloodLetterPdf, customerDoctorLetter, corporateFluffLetter, false, uploadedPdfForCustomer, false, false, scannedDocuments, eawvPdfReport,
                        focAttestation, "", hasSectionToDisplay, mammogram, ifobt, urineMicroalbumin, participantLetter, chlamydia, awvBoneMass, osteoporosis, quantaFloAbi, hkyn: HkynPdf, mybioCheckAssessment: myBiocheckAssessment, memberLetter: memberLetter, dpn: dpn);

                    copyMedia = false;

                }

                ////PCP Report
                var htmlPathforPcpResultPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForPcpResultReport();
                var htmlUrlforPcpResultPdf = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForPcpResultReport();
                var pdfPathforPcpResultPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForPcpResultReport();
                var attachEawvPreventionPlan = corporateAccount == null || corporateAccount.AttachEawvPreventionPlan;

                var pcpLetter = string.Empty;

                if (corporateAccount != null && corporateAccount.GeneratePcpResult)
                {
                    eawvPdfReport = string.Empty;
                    focAttestation = string.Empty;

                    var pcpResultTestIds = _corporateAccountRepository.GetAccountPcpResultTestDependency(corporateAccount.Id);

                    if (pcpResultTestIds != null && eventTests.Any(et => pcpResultTestIds.Contains(et.Id) && et.IsRecordable))
                    {
                        var htmlPathforCoverLetterForPcpResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForPcpCoverLetter();
                        var htmlUrlforCoverLetterForPcpResult = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForPcpCoverLetter();
                        var pdfPathforCoverLetterForPcpResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForPcpCoverLetter();

                        var footerText = string.Empty;
                        var doctorLetter = string.Empty;//_doctorLetter;

                        if (corporateAccount.PrintPcpAppointmentForResult)
                        {
                            var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerId(eventCustomer.Id);
                            if (pcpAppointment != null && eventCustomer.PcpConsentStatus == RegulatoryState.Signed)
                            {
                                try
                                {
                                    var fileName = "PcpAppointment_" + Guid.NewGuid() + ".pdf";
                                    var mediaLocation = _pcpShippingService.PrintEventCustomerPcpAppointmentForm(eventCustomer.EventId, eventCustomer.CustomerId, fileName);
                                    doctorLetter = mediaLocation.PhysicalPath + fileName;
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("Error while generating Pcp Appointment letter. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                                }
                            }
                        }

                        if (corporateAccount.GeneratePcpLetterWithDiagnosisCode)
                        {
                            _generateFinalPdf.CreateCoverLetterForPcpResultReportWithDiagnosisCode(customerId, htmlPathforCoverLetterForPcpResult, eventData, eventTests.Select(x => x.Id).ToArray());
                            //doctorLetter = string.Empty;
                        }
                        else
                        {
                            footerText = customer.NameAsString + " [" + customerId + "]" + dob + " Testing Date:" + eventData.EventDate.ToShortDateString();

                            _generateFinalPdf.CreateCoverLetterForPcpResultReport(customerId, htmlPathforCoverLetterForPcpResult, corporateAccount.Id, corporateAccount.GeneratePcpLetter
                                , (corporateAccount.PcpLetterPdfFileId > 0 || corporateAccount.PcpCoverLetterTemplateId > 0), true);
                        }

                        var hasSectionToDisplay = _generateFinalPdf.CreatePcpResultPdf(htmlPathforPcpResultPdf, customer, eventData, true, pcpResultTestIds, copyMedia, copySupportMedia, showHeaderImageInReport,
                            eventCustomerPhysicianEvaluations, customerSkipReview);

                        if (corporateAccount.GeneratePcpLetter && corporateAccount.PcpCoverLetterTemplateId.HasValue && corporateAccount.PcpCoverLetterTemplateId > 0)
                        {
                            var emailTemplate = _emailTemplateRepository.GetById(corporateAccount.PcpCoverLetterTemplateId.Value);
                            //var emailTemplate = _emailTemplateRepository.GetByAlias("BCBSMIPCPLetterTemplate");
                            var pcpName = _primaryCarePhysicianRepository.Get(customerId);
                            var pcpFullName = pcpName != null && pcpName.Name != null ? pcpName.Name.FullName : string.Empty;
                            var doctorSignatureFilePath = _settings.SignatureForCoverLetterRelativePath;

                            var pcpLetterModel = _emailNotificationModelsFactory.GetCoverLetterTemplateViewModel(string.Empty, doctorSignatureFilePath, pcpFullName, DateTime.Today);
                            var formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, pcpLetterModel, "", "", "", emailTemplate.Id).Body;
                            string pcpLetterhtmlPath = mediaLocationPremiumVersion.PhysicalPath + "PcpLetter.html";
                            string pcpLetterpdfPath = mediaLocationPremiumVersion.PhysicalPath + "PcpLetter.pdf";
                            string pcpLetterHtmlUrl = mediaLocationPremiumVersion.Url + "PcpLetter.html";
                            _pdfGenerator.GenerateHtml(formatMessage, pcpLetterhtmlPath, pcpLetterHtmlUrl, pcpLetterpdfPath);
                            pcpLetter = pcpLetterpdfPath;
                        }
                        else if (corporateAccount.GeneratePcpLetter && corporateAccount.PcpLetterPdfFileId > 0)
                        {
                            var pcfileName = _fileRepository.GetById(corporateAccount.PcpLetterPdfFileId);
                            pcpLetter = _mediaRepository.GetCorporatePcpLetterPdfFolderLocation().PhysicalPath + pcfileName.Path;
                        }

                        _pdfGenerator.GeneratePdf(htmlUrlforCoverLetterForPcpResult, pdfPathforCoverLetterForPcpResult, false, "", "", "", "", pcpLetter);

                        var upLoadedPdfForPcp = string.Empty;
                        try
                        {
                            var pdfTests = eventTests.Where(et => attachUploadedPdfTestIds.Contains(et.Id) && pcpResultTestIds.Contains(et.Id)).Select(et => et).ToArray();

                            if (pdfTests.Any())
                            {
                                upLoadedPdfForPcp = GetAttachUploatedPdfForCustomer(eventId, customerId, pdfTests, showUnreadableTest, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }
                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.eAWV))
                            {
                                eawvPdfReport = GetEawvPdfResult(eventId, customerId, true, attachEawvPreventionPlan, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {

                            _logger.Error("Error while merging e-awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.FocAttestation);
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.FocAttestation))
                            {
                                focAttestation = GetFocAttestationPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Foc Attestation result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Mammogram);
                            mammogram = string.Empty;
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.Mammogram))
                            {
                                mammogram = GetMammogramPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Mammogram result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.IFOBT);
                            ifobt = string.Empty;
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.IFOBT))
                            {
                                ifobt = GetIfobtPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging IFOBT result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.UrineMicroalbumin);
                            urineMicroalbumin = string.Empty;
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.UrineMicroalbumin))
                            {
                                urineMicroalbumin = GetUrineMicroalbuminPdfResult(eventId, customerId, isNewResultFlow);
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging urineMicroalbumin result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Chlamydia);
                            chlamydia = string.Empty;
                            if (isTestsPurchased && pcpResultTestIds.Contains((long)TestType.Chlamydia))
                            {
                                chlamydia = GetChlamydiaPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging chlamydia result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.AwvBoneMass);
                            if (isTestsPurchased)
                            {
                                awvBoneMass = GetAwvBoneMassPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging AwvBoneMass result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }


                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Osteoporosis);
                            if (isTestsPurchased)
                            {
                                osteoporosis = GetOsteoporosisPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Osteoporosis result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }
                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.QuantaFloABI);
                            if (isTestsPurchased)
                            {
                                quantaFloAbi = GetQuantaFloPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging QuantaFloAbi result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.MyBioCheckAssessment);
                            if (isTestsPurchased)
                            {
                                myBiocheckAssessment = GetMyBioCheckPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging myBiocheckAssessment result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.DPN);
                            dpn = string.Empty;
                            if (isTestsPurchased)
                            {
                                dpn = GetDpnPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging DPN result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        var awvpdfPath = upLoadedPdfForPcp;
                        var hasAwvTestInPcpResultSetting = pcpResultTestIds.Any(t => attachUploadedPdfTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasAwvTestInPcpResultSetting)
                            awvpdfPath = string.Empty;

                        var bloodLetterPdfPath = bloodLetterPdf;
                        var hasBloodLetterTestInCustomerResultSetting = pcpResultTestIds.Any(t => bloodLetterTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasBloodLetterTestInCustomerResultSetting)
                            bloodLetterPdfPath = string.Empty;

                        _pdfGenerator.GeneratePdf(htmlUrlforPcpResultPdf, pdfPathforPcpResultPdf, true, footerText, pdfPathforCoverLetterForPcpResult, customizedLetter, _contentPages, kynPdf, bloodLetterPdfPath, doctorLetter, corporateFluffLetter,
                            corporateAccount.GeneratePcpLetterWithDiagnosisCode, awvpdfPath, true, corporateAccount.GeneratePcpLetter, scannedDocuments, eawvPdfReport, focAttestation, "", hasSectionToDisplay, mammogram, ifobt, urineMicroalbumin,
                            "", chlamydia, awvBoneMass, osteoporosis, quantaFloAbi, hkyn: HkynPdf, mybioCheckAssessment: myBiocheckAssessment, greenFormAttestation: attestationForm, dpn: dpn);

                        var pcp = _primaryCarePhysicianRepository.Get(customerId);

                        if (pcp != null && pcp.Address != null)
                        {
                            _pcpShippingService.AddShippingForPcp(customerId, eventId, pcp);
                        }
                        else
                        {
                            _customerShippingService.AddFreeShippingForCustomer(customerId, eventId);
                        }

                        copyMedia = false;
                    }

                }

                //Health Plan Report
                var htmlPathforHealthPlanResultPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForHealthPlanResultReport();
                var htmlUrlforHealthPlanResultPdf = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForHealthPlanResultReport();
                var pdfPathforHealthPlanResultPdf = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForHealthPlanResultReport();


                if (corporateAccount != null && corporateAccount.GenerateHealthPlanReport)
                {
                    eawvPdfReport = string.Empty;
                    focAttestation = string.Empty;
                    var healthPlanResultTestIds = _corporateAccountRepository.GetAccountHealthPlanResultTestDependency(corporateAccount.Id);

                    if (healthPlanResultTestIds != null && eventTests.Any(et => healthPlanResultTestIds.Contains(et.Id) && et.IsRecordable))
                    {
                        var htmlPathforCoverLetterForHealthPlanResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForPcpCoverLetter();
                        var htmlUrlforCoverLetterForHealthPlanResult = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForPcpCoverLetter();
                        var pdfPathforCoverLetterForHealthPlanResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForPcpCoverLetter();

                        var footerText = string.Empty;
                        var doctorLetter = string.Empty;//_doctorLetter;
                        if (corporateAccount.PrintPcpAppointmentForResult)
                        {
                            var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerId(eventCustomer.Id);

                            if (pcpAppointment != null && eventCustomer.PcpConsentStatus == RegulatoryState.Signed)
                            {
                                try
                                {
                                    var fileName = "PcpAppointment_" + Guid.NewGuid() + ".pdf";
                                    var mediaLocation = _pcpShippingService.PrintEventCustomerPcpAppointmentForm(eventCustomer.EventId, eventCustomer.CustomerId, fileName);
                                    doctorLetter = mediaLocation.PhysicalPath + fileName;
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("Error while generating Pcp Appointment letter. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                                }
                            }
                        }

                        if (corporateAccount.GeneratePcpLetterWithDiagnosisCode)
                        {
                            _generateFinalPdf.CreateCoverLetterForPcpResultReportWithDiagnosisCode(customerId, htmlPathforCoverLetterForHealthPlanResult, eventData, eventTests.Select(x => x.Id).ToArray());
                        }
                        else
                        {
                            footerText = customer.NameAsString + " [" + customerId + "]" + dob + " Testing Date:" + eventData.EventDate.ToShortDateString();

                            _generateFinalPdf.CreateCoverLetterForPcpResultReport(customerId, htmlPathforCoverLetterForHealthPlanResult, corporateAccount.Id, corporateAccount.GeneratePcpLetter, (corporateAccount.PcpLetterPdfFileId > 0 || corporateAccount.PcpCoverLetterTemplateId > 0), false);
                        }

                        var hasSectionToDisplay = _generateFinalPdf.CreatePcpResultPdf(htmlPathforHealthPlanResultPdf, customer, eventData, true, healthPlanResultTestIds, copyMedia, copySupportMedia, showHeaderImageInReport,
                            eventCustomerPhysicianEvaluations, customerSkipReview);

                        if (string.IsNullOrWhiteSpace(pcpLetter))
                        {
                            if (corporateAccount.GeneratePcpLetter && corporateAccount.PcpCoverLetterTemplateId.HasValue && corporateAccount.PcpCoverLetterTemplateId > 0)
                            {
                                var emailTemplate = _emailTemplateRepository.GetById(corporateAccount.PcpCoverLetterTemplateId.Value);
                                //var emailTemplate = _emailTemplateRepository.GetByAlias("BCBSMIPCPLetterTemplate");
                                var pcpName = _primaryCarePhysicianRepository.Get(customerId);
                                var pcpFullName = pcpName != null && pcpName.Name != null ? pcpName.Name.FullName : string.Empty;
                                var doctorSignatureFilePath = _settings.SignatureForCoverLetterRelativePath;
                                var pcpLetterModel = _emailNotificationModelsFactory.GetCoverLetterTemplateViewModel(string.Empty, doctorSignatureFilePath, pcpFullName, DateTime.Today);
                                var formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, pcpLetterModel, "", "", "", emailTemplate.Id).Body;
                                string pcpLetterhtmlPath = mediaLocationPremiumVersion.PhysicalPath + "PcpLetter.html";
                                string pcpLetterpdfPath = mediaLocationPremiumVersion.PhysicalPath + "PcpLetter.pdf";
                                string pcpLetterHtmlUrl = mediaLocationPremiumVersion.Url + "PcpLetter.html";
                                _pdfGenerator.GenerateHtml(formatMessage, pcpLetterhtmlPath, pcpLetterHtmlUrl, pcpLetterpdfPath);
                                pcpLetter = pcpLetterpdfPath;
                            }
                            else if (corporateAccount.GeneratePcpLetter && corporateAccount.PcpLetterPdfFileId > 0)
                            {
                                var pcfileName = _fileRepository.GetById(corporateAccount.PcpLetterPdfFileId);
                                pcpLetter = _mediaRepository.GetCorporatePcpLetterPdfFolderLocation().PhysicalPath + pcfileName.Path;
                            }

                        }

                        _pdfGenerator.GeneratePdf(htmlUrlforCoverLetterForHealthPlanResult, pdfPathforCoverLetterForHealthPlanResult, false, "", "", "", "", pcpLetter);

                        var upLoadedPdfForPcp = string.Empty;
                        try
                        {
                            var pdfTests = eventTests.Where(et => attachUploadedPdfTestIds.Contains(et.Id) && healthPlanResultTestIds.Contains(et.Id)).Select(et => et).ToArray();

                            if (pdfTests.Any())
                            {
                                upLoadedPdfForPcp = GetAttachUploatedPdfForCustomer(eventId, customerId, pdfTests, showUnreadableTest, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }
                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.eAWV);

                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.eAWV))
                            {
                                eawvPdfReport = GetEawvPdfResult(eventId, customerId, true, attachEawvPreventionPlan, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging e-awv result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.FocAttestation);

                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.FocAttestation))
                            {
                                focAttestation = GetFocAttestationPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Foc Attestation result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Mammogram);
                            mammogram = string.Empty;
                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.Mammogram))
                            {
                                mammogram = GetMammogramPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Mammogram result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.IFOBT);
                            ifobt = string.Empty;
                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.IFOBT))
                            {
                                ifobt = GetIfobtPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging IFOBT result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.UrineMicroalbumin);
                            urineMicroalbumin = string.Empty;
                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.UrineMicroalbumin))
                            {
                                urineMicroalbumin = GetUrineMicroalbuminPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging UrineMicroalbumin result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Chlamydia);
                            chlamydia = string.Empty;
                            if (isTestsPurchased && healthPlanResultTestIds.Contains((long)TestType.Chlamydia))
                            {
                                chlamydia = GetChlamydiaPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging chlamydia result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.AwvBoneMass);
                            if (isTestsPurchased)
                            {
                                awvBoneMass = GetAwvBoneMassPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging AwvBoneMass result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.Osteoporosis);
                            if (isTestsPurchased)
                            {
                                osteoporosis = GetOsteoporosisPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging Osteoporosis result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }
                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.QuantaFloABI);
                            if (isTestsPurchased)
                            {
                                quantaFloAbi = GetQuantaFloPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging QuantaFloAbi result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }
                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.MyBioCheckAssessment);
                            if (isTestsPurchased)
                            {
                                myBiocheckAssessment = GetMyBioCheckPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging myBiocheckAssessment result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        try
                        {
                            isTestsPurchased = eventTests.Any(et => et.Id == (long)TestType.DPN);
                            dpn = string.Empty;
                            if (isTestsPurchased)
                            {
                                dpn = GetDpnPdfResult(eventId, customerId, isNewResultFlow);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while merging DPN result PDF(s). Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                        }

                        var attestationFormPdf = string.Empty;

                        if (corporateAccount.AttachAttestationForm && (_settings.AttachAttestationFormDate.HasValue && eventData.EventDate.Date >= _settings.AttachAttestationFormDate.Value.Date))
                        {
                            try
                            {
                                attestationFormPdf = _attestationFormService.PrintAttestationPdf(corporateAccount.Id, customerId, eventId);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("Error while generating Attestation Form. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                            }
                        }

                        var awvpdfPath = upLoadedPdfForPcp;
                        var hasAwvTestInPcpResultSetting = healthPlanResultTestIds.Any(t => attachUploadedPdfTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasAwvTestInPcpResultSetting)
                            awvpdfPath = string.Empty;

                        var bloodLetterPdfPath = bloodLetterPdf;
                        var hasBloodLetterTestInCustomerResultSetting = healthPlanResultTestIds.Any(t => bloodLetterTestIds.Contains(t) && eventTestsIds.Contains(t));
                        if (!hasBloodLetterTestInCustomerResultSetting)
                            bloodLetterPdfPath = string.Empty;

                        _pdfGenerator.GeneratePdf(htmlUrlforHealthPlanResultPdf, pdfPathforHealthPlanResultPdf, true, footerText, pdfPathforCoverLetterForHealthPlanResult, customizedLetter, _contentPages, kynPdf, bloodLetterPdfPath, doctorLetter,
                            corporateFluffLetter, corporateAccount.GeneratePcpLetterWithDiagnosisCode, awvpdfPath, true, corporateAccount.GeneratePcpLetter, scannedDocuments, eawvPdfReport, focAttestation, attestationFormPdf, hasSectionToDisplay,
                            mammogram, ifobt, urineMicroalbumin, "", chlamydia, awvBoneMass, osteoporosis, quantaFloAbi, hkyn: HkynPdf, mybioCheckAssessment: myBiocheckAssessment, greenFormAttestation: attestationForm, dpn: dpn);


                        var pcp = _primaryCarePhysicianRepository.Get(customerId);

                        if (pcp != null && pcp.Address != null)
                        {
                            _pcpShippingService.AddShippingForPcp(customerId, eventId, pcp);
                        }
                    }

                }


                if (_settings.CleanUpHtmlFiles) // If clean up is on
                {
                    try
                    {
                        CleanUpDirectory(mediaLocationPremiumVersion.PhysicalPath, new[] { pdfPathforCustomerPremiumPdf, pdfPathforPcpResultPdf, eawvGeneratedFileName, pdfPathforHealthPlanResultPdf });
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cleaning Up Premium Version Pdf Directory path [" + mediaLocationPremiumVersion.PhysicalPath + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error Premium Version:" + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                throw new Exception("Error Caused while generating Premium Version Pdf!", ex);
            }
        }

        private string GetAttestationForm(long customerId, CorporateAccount corporateAccount, Event eventdata)
        {
            if (corporateAccount != null && corporateAccount.Id == _settings.AppleCareAccountId)
            {
                try
                {
                    var mediaLocScannedDocs = _mediaRepository.GetScannedDocumentStorageFileLocation(eventdata.Id);
                    if (!Directory.Exists(mediaLocScannedDocs.PhysicalPath))
                    {
                        _logger.Info(string.Format("No Directory found for the event Id {0} at path {1}", eventdata.Id, mediaLocScannedDocs.PhysicalPath));
                        return string.Empty;
                    }

                    var filesScannedDocs = DirectoryOperationsHelper.GetFiles(mediaLocScannedDocs.PhysicalPath, "*.pdf");

                    if (!filesScannedDocs.Any())
                    {
                        _logger.Info("No Scanned Pdf found for the event Id " + eventdata.Id);
                        return string.Empty;
                    }

                    var fileNameStartWith = "Foc_" + customerId + eventdata.EventDate.ToString("MMddyyyy");

                    var mediaResultPdfFiles = new List<string>();

                    var filenames = filesScannedDocs.Where(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileName(fsd.ToLower()).StartsWith(fileNameStartWith.ToLower())).Select(Path.GetFileName);

                    if (!filenames.IsNullOrEmpty())
                    {
                        mediaResultPdfFiles.AddRange(filenames.Select(filename => mediaLocScannedDocs.PhysicalPath + filename));
                    }

                    if (!mediaResultPdfFiles.Any())
                    {
                        _logger.Info(string.Format("No Scanned Pdf found for the event Id {0} and customer id {1} that start with {2} ", eventdata.Id, customerId, fileNameStartWith));
                        return string.Empty;
                    }

                    if (mediaResultPdfFiles.Count() == 1)
                    {
                        return mediaResultPdfFiles.First();
                    }

                    var fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "FocScannedDocuments_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                    _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);

                    return fileToCreate;

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                    throw;
                }
            }

            return string.Empty;
        }

        private string GenerateEawvPreventionPlanReport(long customerId, CorporateAccount corporateAccount, long eventId, EventCustomer eventCustomer,
            string participantLetter, bool isNewResultFlow, string memberLetter = "", string greenAttestationForm = "")
        {
            var mediaLocationPremiumVersion = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId);
            var eawvPreventionPlanReport = _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();
            var preventionPlanReportFiles = new List<string>();
            var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

            var htmlPathForCoverLetterForCustomerResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetHtmlFileNameForCoverLetter();
            var htmlUrlForCoverLetterForCustomerResult = mediaLocationPremiumVersion.Url + _mediaRepository.GetHtmlFileNameForCoverLetter();
            var pdfPathForCoverLetterForCustomerResult = mediaLocationPremiumVersion.PhysicalPath + _mediaRepository.GetPdfFileNameForCoverLetter();

            _generateFinalPdf.CopySupportMediaFiles(htmlPathForCoverLetterForCustomerResult, true);

            if (File.Exists(htmlPathForCoverLetterForCustomerResult))
                _pdfGenerator.GeneratePdf(htmlUrlForCoverLetterForCustomerResult, pdfPathForCoverLetterForCustomerResult);
            else
                pdfPathForCoverLetterForCustomerResult = "";

            if (!string.IsNullOrEmpty(pdfPathForCoverLetterForCustomerResult))
            {
                preventionPlanReportFiles.Add(pdfPathForCoverLetterForCustomerResult);
            }

            if (!string.IsNullOrWhiteSpace(greenAttestationForm))
            {
                preventionPlanReportFiles.Add(greenAttestationForm);
            }

            if (!string.IsNullOrEmpty(memberLetter))
            {
                preventionPlanReportFiles.Add(memberLetter);
            }

            if (!string.IsNullOrEmpty(participantLetter))
            {
                preventionPlanReportFiles.Add(participantLetter);
            }

            var testRepository = new EAwvTestRepository();
            var testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as EAwvTestResult;

            if (corporateAccount.PrintPcpAppointmentForResult)
            {
                var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerId(eventCustomer.Id);

                if (pcpAppointment != null && eventCustomer.PcpConsentStatus == RegulatoryState.Signed)
                {
                    try
                    {
                        var fileName = "PcpAppointment_" + Guid.NewGuid() + ".pdf";
                        var mediaLocation = _pcpShippingService.PrintEventCustomerPcpAppointmentForm(eventCustomer.EventId,
                            eventCustomer.CustomerId, fileName);
                        preventionPlanReportFiles.Add(mediaLocation.PhysicalPath + fileName);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while generating Pcp Appointment letter. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }
                }
            }

            if (testResult != null && testResult.ResultImages != null && testResult.ResultImages.Any())
            {
                var pdfFiles = testResult.ResultImages;

                /*var resultExportPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.ResultExport.ToLower()));
                if (resultExportPdf != null)
                    preventionPlanReportFiles.Add(location.PhysicalPath + resultExportPdf.File.Path);*/

                var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
                if (mediaPdf != null)
                    preventionPlanReportFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
            }
            string eawvGenFileName = mediaLocationPremiumVersion.PhysicalPath + eawvPreventionPlanReport;

            _pdfGenerator.Merge(eawvGenFileName, preventionPlanReportFiles);

            return eawvGenFileName;

        }

        private string GetKynPdfforCustomer(long eventId, long customerId)
        {

            var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, customerId);
            if (!Directory.Exists(location.PhysicalPath)) return null;

            var files = Directory.GetFiles(location.PhysicalPath, TestType.Kyn + "*.pdf");

            if (files.Count() < 1) return null;

            var fileToCreate = location.PhysicalPath + customerId + ".pdf";

            var letterPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.LetterWriter)).SingleOrDefault();
            var participantSummReportPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport)).SingleOrDefault();
            var physicianSummReportPdf = files.Where(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.PhysicianSummaryReport)).SingleOrDefault();

            if (string.IsNullOrEmpty(letterPdf) && string.IsNullOrEmpty(participantSummReportPdf) && string.IsNullOrEmpty(physicianSummReportPdf))
                return null;

            if (File.Exists(fileToCreate)) File.Delete(fileToCreate);

            var filesCollection = new List<string>();
            if (!string.IsNullOrEmpty(letterPdf)) filesCollection.Add(letterPdf);
            if (!string.IsNullOrEmpty(participantSummReportPdf)) filesCollection.Add(participantSummReportPdf);
            if (!string.IsNullOrEmpty(physicianSummReportPdf)) filesCollection.Add(physicianSummReportPdf);

            _pdfGenerator.Merge(fileToCreate, filesCollection);

            return fileToCreate;
        }

        private string GetHkynPdfforCustomer(long eventId, long customerId)
        {

            var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, customerId);
            if (!Directory.Exists(location.PhysicalPath)) return null;

            var files = Directory.GetFiles(location.PhysicalPath, TestType.HKYN + "*.pdf");

            if (!files.Any()) return null;

            var fileToCreate = location.PhysicalPath + customerId + ".pdf";

            var participantSummReportPdf = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport));

            if (string.IsNullOrEmpty(participantSummReportPdf))
                return null;

            if (File.Exists(fileToCreate)) File.Delete(fileToCreate);

            var filesCollection = new List<string>();
            if (!string.IsNullOrEmpty(participantSummReportPdf)) filesCollection.Add(participantSummReportPdf);

            _pdfGenerator.Merge(fileToCreate, filesCollection);

            return fileToCreate;
        }

        private void RevertPacketGeneration(EventCustomerResult eventCustomerResult)
        {
            long eventId = eventCustomerResult.EventId;
            long customerId = eventCustomerResult.CustomerId;

            var directory = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).PhysicalPath;
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            directory = _mediaRepository.GetCdContentFolderLocation(eventId, customerId).PhysicalPath;
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            eventCustomerResult.IsClinicalFormGenerated = false;
            eventCustomerResult.IsResultPdfGenerated = false;

            _eventCustomerResultRepository.Save(eventCustomerResult);
        }

        private void CleanUpAllResultPdfZipFile(long eventId)
        {
            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            string allDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfName(eventId);
            if (Directory.Exists(location.PhysicalPath + allDownloadPdfDirectoryName))
                Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);

            if (File.Exists(location.PhysicalPath + allDownloadPdfDirectoryName + ".zip"))
                File.Delete(location.PhysicalPath + allDownloadPdfDirectoryName + ".zip");
        }

        private void GenerateAllResultPdfZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {

            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            if (filteredList.Count() < 1) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string allDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfName(eventId);
            CleanUpAllResultPdfZipFile(eventId);

            Directory.CreateDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
            var fileName = _mediaRepository.GetPdfFileNameForResultReport();
            var fileNamePaperback = _mediaRepository.GetPdfFileNameForResultReportPaperBack();
            var fileNameWithImages = _mediaRepository.GetPdfFileNameForResultReportWithImages();
            var fileNameforPcp = _mediaRepository.GetPdfFileNameForPcpResultReport();
            var fileNameForEawvReport = _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();
            var fileNameForHealthPlanReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                var isPremiumVersionPurchased = _electronicProductRepository.IsProductPurchased(eventCustomerResult.EventId, eventCustomerResult.CustomerId, Product.PremiumVersionPdf);
                if (isPremiumVersionPurchased)
                {
                    //if (!File.Exists(pdfLocation.PhysicalPath + fileNameWithImages))
                    //    continue;

                    if (File.Exists(pdfLocation.PhysicalPath + fileNameWithImages))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameWithImages, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameWithImages);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameWithImages, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForHealthPlanReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForHealthPlanReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Healthplan.pdf");
                    }
                }
                else
                {
                    //if (!File.Exists(pdfLocation.PhysicalPath + fileName))
                    //    continue;

                    if (File.Exists(pdfLocation.PhysicalPath + fileNamePaperback))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }

                    if (File.Exists(pdfLocation.PhysicalPath + fileName))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }

                    if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForHealthPlanReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForHealthPlanReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Healthplan.pdf");
                    }
                }
            }

            _zipHelper.CreateZipFiles(location.PhysicalPath + allDownloadPdfDirectoryName, location.PhysicalPath + allDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for All Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private void GenerateAllResultPdfPaperCopyOnlyZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            //var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);

            //if (eventCustomerResults == null || eventCustomerResults.Count() < 1) return;

            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            var eventCustomerResultIdsToBeRemoved = (from eventCustomerResult in filteredList
                                                     let shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventCustomerResult.EventId, eventCustomerResult.CustomerId)
                                                     where shippingDetails == null || shippingDetails.Count() < 1
                                                     select eventCustomerResult.Id).ToList();

            //eventCustomerResultIdsToBeRemoved.AddRange(from eventCustomerResult in filteredList
            //                                           let isPremiumPdfPurchased = _electronicProductRepository.IsProductPurchased(eventCustomerResult.EventId, eventCustomerResult.CustomerId, Product.PremiumVersionPdf)
            //                                           where isPremiumPdfPurchased
            //                                           select eventCustomerResult.Id);

            filteredList = filteredList.Where(fl => !eventCustomerResultIdsToBeRemoved.Contains(fl.Id)).Select(fl => fl).ToArray();

            if (filteredList.Count() < 1) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string allDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfPaperCopyOnly(eventId);


            if (Directory.Exists(location.PhysicalPath + allDownloadPdfDirectoryName))
            {
                try
                {
                    CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                    Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
                }
                catch (Exception ex)
                {
                    _logger.Error("\nCleaning Up failed for All Result With Images Pdf. Event: " + eventId + ". Message: " + ex.Message);
                }
            }

            Directory.CreateDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);

            var fileName = _mediaRepository.GetPdfFileNameForResultReport();
            var fileNamePaperback = _mediaRepository.GetPdfFileNameForResultReportPaperBack();
            var fileNameWithImages = _mediaRepository.GetPdfFileNameForResultReportWithImages();
            var fileNameforPcp = _mediaRepository.GetPdfFileNameForPcpResultReport();
            var fileNameForEawvReport = _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();

            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                var isPremiumVersionPurchased = _electronicProductRepository.IsProductPurchased(eventCustomerResult.EventId, eventCustomerResult.CustomerId, Product.PremiumVersionPdf);
                if (isPremiumVersionPurchased)
                {
                    //if (!File.Exists(pdfLocation.PhysicalPath + fileNameWithImages))
                    //    continue;

                    if (File.Exists(pdfLocation.PhysicalPath + fileNameWithImages))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameWithImages, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameWithImages);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameWithImages, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                    }
                }
                else
                {
                    //if (!File.Exists(pdfLocation.PhysicalPath + fileName))
                    //    continue;

                    if (File.Exists(pdfLocation.PhysicalPath + fileNamePaperback))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }

                    if (File.Exists(pdfLocation.PhysicalPath + fileName))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                    }

                    if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                    }
                    if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                    {
                        File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport);
                        File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                    }
                }
            }

            _zipHelper.CreateZipFiles(location.PhysicalPath + allDownloadPdfDirectoryName, location.PhysicalPath + allDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for All Result With Images Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private void GenerateAllResultPdfOnlineOnlyZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            //var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);

            //if (eventCustomerResults == null || eventCustomerResults.Count() < 1) return;

            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            var eventCustomerResultIdsToBeRemoved = (from eventCustomerResult in filteredList
                                                     let shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventCustomerResult.EventId, eventCustomerResult.CustomerId)
                                                     where shippingDetails != null && shippingDetails.Count() > 0
                                                     select eventCustomerResult.Id).ToList();

            filteredList = filteredList.Where(fl => !eventCustomerResultIdsToBeRemoved.Contains(fl.Id)).Select(fl => fl).ToArray();

            if (filteredList.Count() < 1) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string allDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfOnlineOnly(eventId);


            if (Directory.Exists(location.PhysicalPath + allDownloadPdfDirectoryName))
            {
                try
                {
                    CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                    Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
                }
                catch (Exception ex)
                {
                    _logger.Error("\nCleaning Up failed for All Result With Images Pdf. Event: " + eventId + ". Message: " + ex.Message);
                }
            }

            Directory.CreateDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);

            var fileName = _mediaRepository.GetPdfFileNameForResultReport();
            var fileNamePaperback = _mediaRepository.GetPdfFileNameForResultReportPaperBack();
            var fileNameforPcp = _mediaRepository.GetPdfFileNameForPcpResultReport();
            var fileNameForEawvReport = _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();

            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                //if (!File.Exists(pdfLocation.PhysicalPath + fileName))
                //    continue;

                if (File.Exists(pdfLocation.PhysicalPath + fileNamePaperback))
                {
                    File.Copy(pdfLocation.PhysicalPath + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback);
                    File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNamePaperback, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                }

                if (File.Exists(pdfLocation.PhysicalPath + fileName))
                {
                    File.Copy(pdfLocation.PhysicalPath + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName);
                    File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileName, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + ".pdf");
                }

                if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                {
                    File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                    File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                }
                if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                {
                    File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport);
                    File.Move(location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + allDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                }
            }

            _zipHelper.CreateZipFiles(location.PhysicalPath + allDownloadPdfDirectoryName, location.PhysicalPath + allDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for All Result With Images Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private void GenerateAllResultPdfPcpOnlyZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            //var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);
            //if (eventCustomerResults == null || eventCustomerResults.Count() < 1) return;

            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            if (filteredList.Count() < 1) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string pcpDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfPcpOnly(eventId);

            if (Directory.Exists(location.PhysicalPath + pcpDownloadPdfDirectoryName))
            {
                try
                {
                    CleanUpDirectory(location.PhysicalPath + pcpDownloadPdfDirectoryName);
                    Directory.Delete(location.PhysicalPath + pcpDownloadPdfDirectoryName, true);
                }
                catch (Exception ex)
                {
                    _logger.Error("\nCleaning Up failed for Pcp Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
                }
            }

            Directory.CreateDirectory(location.PhysicalPath + pcpDownloadPdfDirectoryName);

            var fileNameforPcp = _mediaRepository.GetPdfFileNameForPcpResultReport();
            var isAnyFilePresent = false;
            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                if (File.Exists(pdfLocation.PhysicalPath + fileNameforPcp))
                {
                    isAnyFilePresent = true;
                    File.Copy(pdfLocation.PhysicalPath + fileNameforPcp, location.PhysicalPath + pcpDownloadPdfDirectoryName + "\\" + fileNameforPcp);
                    File.Move(location.PhysicalPath + pcpDownloadPdfDirectoryName + "\\" + fileNameforPcp, location.PhysicalPath + pcpDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                }

            }
            if (isAnyFilePresent)
                _zipHelper.CreateZipFiles(location.PhysicalPath + pcpDownloadPdfDirectoryName, location.PhysicalPath + pcpDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + pcpDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + pcpDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for Pcp Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private void GenerateAllEawvResultReportPdfOnlyZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            if (filteredList.Count() < 1) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string eawvReportDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfEawvReportOnly(eventId);

            if (Directory.Exists(location.PhysicalPath + eawvReportDownloadPdfDirectoryName))
            {
                try
                {
                    CleanUpDirectory(location.PhysicalPath + eawvReportDownloadPdfDirectoryName);
                    Directory.Delete(location.PhysicalPath + eawvReportDownloadPdfDirectoryName, true);
                }
                catch (Exception ex)
                {
                    _logger.Error("\nCleaning Up failed for Eawv Report Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
                }
            }

            Directory.CreateDirectory(location.PhysicalPath + eawvReportDownloadPdfDirectoryName);

            var fileNameForEawvReport = _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();
            var isAnyFilePresent = false;
            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                if (File.Exists(pdfLocation.PhysicalPath + fileNameForEawvReport))
                {
                    isAnyFilePresent = true;
                    File.Copy(pdfLocation.PhysicalPath + fileNameForEawvReport, location.PhysicalPath + eawvReportDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_Eawv.pdf");
                    //File.Move(location.PhysicalPath + eawvReportDownloadPdfDirectoryName + "\\" + fileNameForEawvReport, location.PhysicalPath + eawvReportDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_PCP.pdf");
                }

            }
            if (isAnyFilePresent)
                _zipHelper.CreateZipFiles(location.PhysicalPath + eawvReportDownloadPdfDirectoryName, location.PhysicalPath + eawvReportDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + eawvReportDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + eawvReportDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for Eawv Report Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private static void CleanUpDirectory(string path, IEnumerable<string> fileException = null)
        {
            fileException = fileException == null ? new string[0] : fileException.Where(f => !string.IsNullOrWhiteSpace(f)).Select(f => f.ToLower()).ToArray();

            foreach (var file in Directory.GetFiles(path))
            {
                if (fileException.Contains(file.ToLower())) continue;
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                CleanUpDirectory(dir);
                Directory.Delete(dir);
            }
        }

        private string GetAttachUploatedPdfForCustomer(long eventId, long customerId, IEnumerable<Test> eventTest, bool showUnreadableTest, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);
                var mediaResultPdfFiles = new List<string>();

                if (location != null && Directory.Exists(location.PhysicalPath))
                {
                    TestResultRepository testRepository = null;
                    TestResult testResult = null;
                    List<ResultMedia> pdfFiles = null;

                    if (eventTest.Any(et => et.Id == (long)TestType.AWV))
                    {
                        testRepository = new AwvTestRepository();
                        testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvTestResult;

                        if (testResult != null && ((AwvTestResult)testResult).ResultImages != null && ((AwvTestResult)testResult).ResultImages.Any())
                        {
                            pdfFiles = ((AwvTestResult)testResult).ResultImages;

                            var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

                            mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                        }
                    }

                    if (eventTest.Any(et => et.Id == (long)TestType.AwvSubsequent))
                    {

                        testRepository = new AwvSubsequentTestRepository();
                        testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvSubsequentTestResult;

                        if (testResult != null && ((AwvSubsequentTestResult)testResult).ResultImages != null && ((AwvSubsequentTestResult)testResult).ResultImages.Any())
                        {
                            pdfFiles = ((AwvSubsequentTestResult)testResult).ResultImages;

                            var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

                            mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                        }
                    }

                    if (eventTest.Any(et => et.Id == (long)TestType.Medicare))
                    {
                        testRepository = new MedicareTestRepository();
                        testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MedicareTestResult;

                        if (testResult != null && ((MedicareTestResult)testResult).ResultImages != null && ((MedicareTestResult)testResult).ResultImages.Any())
                        {
                            pdfFiles = ((MedicareTestResult)testResult).ResultImages;

                            var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);

                            mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
                            if (mediaPdf != null)
                                mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                        }
                    }

                    // GetEawvPdfResult(eventId, customerId, eventTest, isForPcp, attachEawvPreventionPlan, mediaResultPdfFiles, location);
                    if (eventTest.Any(et => et.Id == (long)TestType.DiabeticRetinopathy))
                    {
                        testRepository = new DiabeticRetinopathyTestRepository();
                        testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as DiabeticRetinopathyTestResult;

                        if (testResult != null && ((DiabeticRetinopathyTestResult)testResult).ResultImage != null)
                        {
                            var mediaPdf = ((DiabeticRetinopathyTestResult)testResult).ResultImage;
                            mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                        }
                    }

                    if (eventTest.Any(et => et.Id == (long)TestType.FloChecABI))
                    {
                        testRepository = new FloChecABITestRepository();
                        var floChectestResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as FloChecABITestResult;

                        if (floChectestResult != null && floChectestResult.ResultImage != null && (floChectestResult.UnableScreenReason == null || floChectestResult.UnableScreenReason.Count == 0)
                            && (showUnreadableTest || floChectestResult.RepeatStudy == null || floChectestResult.RepeatStudy.Reading == false))
                        {
                            var mediaPdf = floChectestResult.ResultImage;

                            mediaResultPdfFiles.Add(location.PhysicalPath + Path.GetFileNameWithoutExtension(mediaPdf.File.Path) + ".pdf");
                        }
                    }
                }

                if (mediaResultPdfFiles.Any())
                {
                    if (mediaResultPdfFiles.Count() == 1)
                    {
                        fileToCreate = mediaResultPdfFiles.First();
                    }
                    else
                    {
                        fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "AwvTestResults_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                        _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;

            }

            return fileToCreate;
        }

        private string GetEawvPdfResult(long eventId, long customerId, bool isForPcp, bool attachEawvPreventionPlan, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                TestResultRepository testRepository;
                TestResult testResult;
                List<ResultMedia> pdfFiles;

                var mediaResultPdfFiles = new List<string>();
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                testRepository = new EAwvTestRepository();
                testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as EAwvTestResult;

                if (testResult != null && ((EAwvTestResult)testResult).ResultImages != null && ((EAwvTestResult)testResult).ResultImages.Any())
                {
                    pdfFiles = ((EAwvTestResult)testResult).ResultImages;

                    if (isForPcp)
                    {
                        _logger.Info("adding Snapshot file");
                        var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.SnapShot.ToLower()));
                        if (mediaPdf != null)
                            mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                    }

                    if (isForPcp)
                    {
                        _logger.Info("adding Result export file");
                        var resultExportPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.ResultExport.ToLower()));
                        if (resultExportPdf != null)
                            mediaResultPdfFiles.Add(location.PhysicalPath + resultExportPdf.File.Path);
                    }

                    if (attachEawvPreventionPlan)
                    {
                        _logger.Info("adding PreventionPlan file");
                        var mediaPdf = pdfFiles.SingleOrDefault(x => x.File.Path.ToLower().Contains(AwvFileTypes.PreventionPlan.ToLower()));
                        if (mediaPdf != null)
                            mediaResultPdfFiles.Add(location.PhysicalPath + mediaPdf.File.Path);
                    }
                }


                if (mediaResultPdfFiles.Any())
                {
                    if (mediaResultPdfFiles.Count() == 1)
                    {
                        fileToCreate = mediaResultPdfFiles.First();
                    }
                    else
                    {
                        fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "EAwvTestResults_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                        _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetMammogramPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new MammogramTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MammogramTestResult;

                if (testResult != null && ((MammogramTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((MammogramTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetFocAttestationPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new FocAttestationTestRepository();
                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as FocAttestationTestResult;

                if (testResult != null && ((FocAttestationTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((FocAttestationTestResult)testResult).ResultImage;

                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetAttachScannedDocumentPdf(long eventId, long customerId, DateTime eventDate)
        {
            var fileToCreate = string.Empty;
            try
            {
                var mediaLocScannedDocs = _mediaRepository.GetScannedDocumentStorageFileLocation(eventId);
                if (!Directory.Exists(mediaLocScannedDocs.PhysicalPath))
                {
                    _logger.Info(string.Format("No Directory found for the event Id {0} at path {1}", eventId, mediaLocScannedDocs.PhysicalPath));
                    return fileToCreate;
                }

                var filesScannedDocs = Directory.GetFiles(mediaLocScannedDocs.PhysicalPath, "*.pdf");
                var fileNameStartWith = customerId + eventDate.ToString("MMddyyyy");

                if (!filesScannedDocs.Any())
                {
                    _logger.Info("No Scanned Pdf found for the event Id " + eventId);
                    return fileToCreate;
                }

                var mediaResultPdfFiles = new List<string>();

                var filenames = filesScannedDocs.Where(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileName(fsd).StartsWith(fileNameStartWith)).Select(Path.GetFileName);
                if (!filenames.IsNullOrEmpty())
                {
                    mediaResultPdfFiles.AddRange(filenames.Select(filename => mediaLocScannedDocs.PhysicalPath + filename));
                }

                if (!mediaResultPdfFiles.Any())
                {
                    _logger.Info(string.Format("No Scanned Pdf found for the event Id {0} and customer id {1} that start with {2} ", eventId, customerId, fileNameStartWith));
                    return fileToCreate;
                }


                if (mediaResultPdfFiles.Count() == 1)
                {
                    fileToCreate = mediaResultPdfFiles.First();
                }
                else
                {
                    fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "ScannedDocuments_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                    _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                throw;
            }

            return fileToCreate;
        }

        private void GenerateAllHealthPlanResultReportPdfOnlyZip(long eventId, IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            var filteredList = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated).ToArray();

            if (!filteredList.Any()) return;

            var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
            if (!Directory.Exists(location.PhysicalPath))
                return;

            string healthPlanReportDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfHealthPlanReportOnly(eventId);

            if (Directory.Exists(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName))
            {
                try
                {
                    CleanUpDirectory(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName);
                    Directory.Delete(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName, true);
                }
                catch (Exception ex)
                {
                    _logger.Error("\nCleaning Up failed for Health Plan Report Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
                }
            }

            Directory.CreateDirectory(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName);

            var fileNameForHealthPlanReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();
            var isAnyFilePresent = false;
            foreach (var eventCustomerResult in filteredList)
            {
                var pdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);

                if (File.Exists(pdfLocation.PhysicalPath + fileNameForHealthPlanReport))
                {
                    isAnyFilePresent = true;
                    File.Copy(pdfLocation.PhysicalPath + fileNameForHealthPlanReport, location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName + "\\" + eventCustomerResult.CustomerId + "_HealthPlan.pdf");
                }

            }
            if (isAnyFilePresent)
                _zipHelper.CreateZipFiles(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName, location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName + ".zip", true);

            try
            {
                CleanUpDirectory(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName);
                Directory.Delete(location.PhysicalPath + healthPlanReportDownloadPdfDirectoryName, true);
            }
            catch (Exception ex)
            {
                _logger.Error("\nCleaning Up failed for Health Plan Report Only Result Pdf. Event: " + eventId + ". Message: " + ex.Message);
            }
        }

        private string GetIfobtPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new IFOBTTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as IFOBTTestResult;

                if (testResult != null && ((IFOBTTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((IFOBTTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetUrineMicroalbuminPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new UrineMicroalbuminTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as UrineMicroalbuminTestResult;

                if (testResult != null && ((UrineMicroalbuminTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((UrineMicroalbuminTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }


        private string GetChlamydiaPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new ChlamydiaTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as ChlamydiaTestResult;

                if (testResult != null && ((ChlamydiaTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((ChlamydiaTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetAwvBoneMassPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new AwvBoneMassTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as AwvBoneMassTestResult;

                if (testResult != null && ((AwvBoneMassTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((AwvBoneMassTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetOsteoporosisPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new OsteoporosisTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as OsteoporosisTestResult;

                if (testResult != null && ((OsteoporosisTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((OsteoporosisTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }
        private string GetQuantaFloPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new QuantaFloABITestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as QuantaFloABITestResult;

                if (testResult != null && ((QuantaFloABITestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((QuantaFloABITestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }


        private string GetMyBioCheckPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new MyBioAssessmentTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as MyBioAssessmentTestResult;

                if (testResult != null && ((MyBioAssessmentTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((MyBioAssessmentTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }

        private string GetAttestationFormForNammAccount(long customerId, CorporateAccount corporateAccount, Event eventdata)
        {
            try
            {
                var mediaLocScannedDocs = _mediaRepository.GetScannedDocumentStorageFileLocation(eventdata.Id);
                if (!Directory.Exists(mediaLocScannedDocs.PhysicalPath))
                {
                    _logger.Info(string.Format("No Directory found for the event Id {0} at path {1}", eventdata.Id, mediaLocScannedDocs.PhysicalPath));
                    return string.Empty;
                }

                var filesScannedDocs = DirectoryOperationsHelper.GetFiles(mediaLocScannedDocs.PhysicalPath, "*.pdf");

                if (!filesScannedDocs.Any())
                {
                    _logger.Info("No Scanned Pdf found for the event Id " + eventdata.Id);
                    return string.Empty;
                }

                var fileNameStartWith = "Foc_" + customerId + eventdata.EventDate.ToString("MMddyyyy");

                var mediaResultPdfFiles = new List<string>();

                var filenames = filesScannedDocs.Where(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileName(fsd.ToLower()).StartsWith(fileNameStartWith.ToLower())).Select(Path.GetFileName);

                if (!filenames.IsNullOrEmpty())
                {
                    mediaResultPdfFiles.AddRange(filenames.Select(filename => mediaLocScannedDocs.PhysicalPath + filename));
                }

                if (!mediaResultPdfFiles.Any())
                {
                    _logger.Info(string.Format("No Scanned Pdf found for the event Id {0} and customer id {1} that start with {2} ", eventdata.Id, customerId, fileNameStartWith));
                    return string.Empty;
                }

                if (mediaResultPdfFiles.Count() == 1)
                {
                    return mediaResultPdfFiles.First();
                }

                var fileToCreate = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + "FocScannedDocuments_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                _pdfGenerator.Merge(fileToCreate, mediaResultPdfFiles);

                return fileToCreate;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                throw;
            }

        }

        private string GetDpnPdfResult(long eventId, long customerId, bool isNewResultFlow)
        {
            var fileToCreate = string.Empty;
            try
            {
                var location = _mediaRepository.GetResultMediaFileLocation(customerId, eventId);

                TestResultRepository testRepository = new DpnTestRepository();

                TestResult testResult = testRepository.GetTestResults(customerId, eventId, isNewResultFlow) as DpnTestResult;

                if (testResult != null && ((DpnTestResult)testResult).ResultImage != null)
                {
                    var pdfFiles = ((DpnTestResult)testResult).ResultImage;
                    if (pdfFiles != null)
                    {
                        fileToCreate = location.PhysicalPath + pdfFiles.File.Path;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message : {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                throw exception;
            }

            return fileToCreate;
        }
    }
}