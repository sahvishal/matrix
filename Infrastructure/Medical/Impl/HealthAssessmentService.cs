using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HealthAssessmentService : IHealthAssessmentService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly IKynHealthAssessmentService _kynHealthAssessmentService;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerService _customerService;
        private readonly IFluVaccinationConsentService _fluVaccinationConsentService;
        private readonly IOperationsReportingService _operationsReportingService;
        private readonly IPatientWorksheetService _patientWorksheetService;
        private readonly ICustomerClinicalQuestionAnswerRepository _customerClinicalQuestionAnswerRepository;
        private readonly IEventCustomerPcpAppointmentService _eventCustomerPcpAppointmentService;
        private readonly ILanguageRepository _languageRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IClinicalQuestionsHealthAssessmentHelper _clinicalQuestionsHealthAssessmentHelper;
        private readonly ICustomerCheckListService _customerCheckListService;
        private readonly ILabFormService _labFormService;
        private readonly ISettings _settings;
        private readonly ILoincLabDataRepository _loincLabDataRepository;
        private readonly ILoincCrosswalkRepository _loincCrosswalkRepository;
        private readonly IEventCustomerPreApprovedPackageTestRepository _eventCustomerPreApprovedPackageTestRepository;
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IPhysicianRecordRequestSignatureRepository _physicianRecordRequestSignatureRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerGiftCardRepository _eventCustomerGiftCardRepository;
        private readonly IParticipationConsentSignatureRepository _participationConsentSignatureRepository;
        private readonly ISurveyTemplateService _surveyTemplateService;
        private readonly IFluConsentAnswerRepository _fluConsentAnswerRepository;
        private readonly IFluConsentQuestionRepository _fluConsentQuestionRepository;
        private readonly IFluConsentSignatureRepository _fluConsentSignatureRepository;

        public HealthAssessmentService(IEventRepository eventRepository, ICustomerRepository customerRepository, IHealthAssessmentRepository healthAssessmentRepository, IHostRepository hostRepository,
            IEventCustomerRepository eventCustomerRepository, IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, IKynHealthAssessmentService kynHealthAssessmentService,
            IEventPodRepository eventPodRepository, ICorporateAccountRepository corporateAccountRepository, ICustomerService customerService, IFluVaccinationConsentService fluVaccinationConsentService,
            IOperationsReportingService operationsReportingService, IPatientWorksheetService patientWorksheetService, IClinicalQuestionsHealthAssessmentHelper clinicalQuestionsHealthAssessmentHelper,
            ICustomerClinicalQuestionAnswerRepository customerClinicalQuestionAnswerRepository, IEventCustomerPcpAppointmentService eventCustomerPcpAppointmentService, ILanguageRepository languageRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICustomerCheckListService customerCheckListService, ILabFormService labFormService, ISettings settings, ILoincLabDataRepository loincLabDataRepository,
            ILoincCrosswalkRepository loincCrosswalkRepository, IEventCustomerPreApprovedPackageTestRepository eventCustomerPreApprovedPackageTestRepository,
            IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository, IPackageRepository packageRepository, IPhysicianRecordRequestSignatureRepository physicianRecordRequestSignatureRepository,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, IEventCustomerGiftCardRepository eventCustomerGiftCardRepository, IParticipationConsentSignatureRepository participationConsentSignatureRepository, 
            ISurveyTemplateService surveyTemplateService, IFluConsentAnswerRepository fluConsentAnswerRepository, IFluConsentQuestionRepository fluConsentQuestionRepository, IFluConsentSignatureRepository fluConsentSignatureRepository)
        {
            _healthAssessmentRepository = healthAssessmentRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _hostRepository = hostRepository;
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _kynHealthAssessmentService = kynHealthAssessmentService;
            _eventPodRepository = eventPodRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customerService = customerService;
            _fluVaccinationConsentService = fluVaccinationConsentService;
            _operationsReportingService = operationsReportingService;
            _patientWorksheetService = patientWorksheetService;
            _customerClinicalQuestionAnswerRepository = customerClinicalQuestionAnswerRepository;
            _eventCustomerPcpAppointmentService = eventCustomerPcpAppointmentService;
            _languageRepository = languageRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _clinicalQuestionsHealthAssessmentHelper = clinicalQuestionsHealthAssessmentHelper;
            _customerCheckListService = customerCheckListService;
            _labFormService = labFormService;
            _settings = settings;
            _loincLabDataRepository = loincLabDataRepository;
            _loincCrosswalkRepository = loincCrosswalkRepository;
            _eventCustomerPreApprovedPackageTestRepository = eventCustomerPreApprovedPackageTestRepository;
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _packageRepository = packageRepository;
            _physicianRecordRequestSignatureRepository = physicianRecordRequestSignatureRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerGiftCardRepository = eventCustomerGiftCardRepository;
            _participationConsentSignatureRepository = participationConsentSignatureRepository;
            _surveyTemplateService = surveyTemplateService;
            _fluConsentAnswerRepository = fluConsentAnswerRepository;
            _fluConsentQuestionRepository = fluConsentQuestionRepository;
            _fluConsentSignatureRepository = fluConsentSignatureRepository;
        }

        public HealthAssessmentEditModel GetHealthAssessmentEditModel(long customerId, long eventId, int versionNumber = 0, bool showKynEditModel = false)
        {
            var questions = GetQuestions(eventId, customerId);

            var eventData = _eventRepository.GetById(eventId);

            var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

            IEnumerable<HealthAssessmentAnswer> answers;
            if (versionNumber < 1)
                answers = _healthAssessmentRepository.Get(customerId, eventId);
            else
            {
                var archiveanswers = _healthAssessmentRepository.GetArchive(customerId, eventId, versionNumber);
                answers = archiveanswers.Select(aa => aa.HealthAssessmentAnswer).ToArray();
            }

            var questionModelCollection =
                Mapper.Map<IEnumerable<HealthAssessmentQuestion>, IEnumerable<HealthAssessmentQuestionEditModel>>(questions);

            if (answers != null)
            {
                foreach (var answer in answers)
                {
                    var editModel = questionModelCollection.SingleOrDefault(q => q.QuestionId == answer.QuestionId);
                    if (editModel != null)
                        editModel.Answer = answer.Answer;
                }
            }

            var customer = _customerRepository.GetCustomer(customerId);

            var eventTests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);

            var isMammoPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.Mammogram, eventTests);
            var isKynPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, eventTests);

            var isHkynPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.HKYN, eventTests);
            var isBioCheckAssessmentPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.MyBioCheckAssessment, eventTests);

            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId);
            var isPhq9Purchased = IsTestPurchasedWithHealthAssessment((long)TestType.PHQ9, eventTests);
            KynHealthAssessmentEditModel kynHealthAssessmentModel = null;

            if (showKynEditModel && isKynIntegrationEnabled)
            {
                if (isKynPurchased)
                {
                    kynHealthAssessmentModel = _kynHealthAssessmentService.GetKynHealthAssessment(customerId, eventId, (long)TestType.Kyn, isNewResultFlow);
                }
                else if (isHkynPurchased)
                {
                    kynHealthAssessmentModel = _kynHealthAssessmentService.GetKynHealthAssessment(customerId, eventId, (long)TestType.HKYN, isNewResultFlow);
                }
                else if (isBioCheckAssessmentPurchased)
                {
                    kynHealthAssessmentModel = _kynHealthAssessmentService.GetKynHealthAssessment(customerId, eventId, (long)TestType.MyBioCheckAssessment, isNewResultFlow);
                }
            }




            var model = new HealthAssessmentEditModel
                            {
                                CustomerId = customerId,
                                EventId = eventId,
                                Gender = customer.Gender,
                                QuestionEditModels = questionModelCollection,
                                IsMammoPurchased = isMammoPurchased,
                                IsKynPurchased = (isKynPurchased || isHkynPurchased) && isKynIntegrationEnabled,
                                IsHKynPurchased = isHkynPurchased,
                                KynHealthAssessmentEditModel = kynHealthAssessmentModel,
                                IsPhq9Purchased = isPhq9Purchased,
                                IsBioCheckAssessmentPurchased = isBioCheckAssessmentPurchased,
                                ShowNewHKynForm = (eventData.EventDate >= _settings.NewHkynEventDate)
                            };

            if (isMammoPurchased)
            {
                var questionOtherThanMamo = questionModelCollection.Where(x => !model.mammogramQuestionIds.Contains(x.QuestionId));
                if (questionOtherThanMamo != null && questionOtherThanMamo.Any())
                    model.ShowMammogramQuestionnarire = true;
            }

            var account = _corporateAccountRepository.GetbyEventId(eventId);
            if (account != null && account.AskClinicalQuestions && account.ClinicalQuestionTemplateId.HasValue)
            {
                _clinicalQuestionsHealthAssessmentHelper.SetRecommendationLogic(account.ClinicalQuestionTemplateId.Value, model);
            }

            return model;
        }

        public IEnumerable<HealthAssessmentQuestion> GetQuestions(long eventId, long customerId)
        {
            IEnumerable<HealthAssessmentQuestion> questions = null;

            var theEvent = _eventRepository.GetById(eventId);
            if (theEvent.HealthAssessmentTemplateId.HasValue && theEvent.HealthAssessmentTemplateId.Value > 0)
            {
                var template = _healthAssessmentTemplateRepository.GetById(theEvent.HealthAssessmentTemplateId.Value);
                var questionIds = new List<long>();
                questionIds.AddRange(template.QuestionIds);

                var order = _orderRepository.GetOrder(customerId, eventId);
                var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).FirstOrDefault();

                var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId);

                if (eventpackageId > 0)
                {
                    var eventPackage = _eventPackageRepository.GetById(eventpackageId);
                    if (eventPackage.HealthAssessmentTemplateId.HasValue && eventPackage.HealthAssessmentTemplateId.Value > 0)
                    {
                        var packageTemplate = _healthAssessmentTemplateRepository.GetById(eventPackage.HealthAssessmentTemplateId.Value);
                        questionIds.AddRange(packageTemplate.QuestionIds);
                    }

                    var eventTests = _eventTestRepository.GetbyIds(eventPackage.Tests.Select(t => t.Id));
                    eventTests = eventTests.Where(et => et.HealthAssessmentTemplateId.HasValue && et.HealthAssessmentTemplateId.Value > 0 && (et.TestId != (long)TestType.Kyn || isKynIntegrationEnabled)).Select(et => et);
                    if (!eventTests.IsNullOrEmpty())
                    {
                        var testTemplates = _healthAssessmentTemplateRepository.GetByIds(eventTests.Select(et => et.HealthAssessmentTemplateId.Value));

                        foreach (var healthAssessmentTemplate in testTemplates)
                        {

                            questionIds.AddRange(healthAssessmentTemplate.QuestionIds);
                        }
                    }
                }

                var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
                if (!eventTestIds.IsNullOrEmpty())
                {
                    var eventTests = _eventTestRepository.GetbyIds(eventTestIds);
                    eventTests = eventTests.Where(et => et.HealthAssessmentTemplateId.HasValue && et.HealthAssessmentTemplateId.Value > 0 && (et.TestId != (long)TestType.Kyn || isKynIntegrationEnabled)).Select(et => et);
                    if (!eventTests.IsNullOrEmpty())
                    {
                        if (!isKynIntegrationEnabled)
                            eventTests.ToList().RemoveAll(et => et.TestId == (long)TestType.Kyn);

                        var testTemplates = _healthAssessmentTemplateRepository.GetByIds(eventTests.Select(et => et.HealthAssessmentTemplateId.Value));

                        foreach (var healthAssessmentTemplate in testTemplates)
                        {
                            questionIds.AddRange(healthAssessmentTemplate.QuestionIds);
                        }
                    }
                }

                var account = _corporateAccountRepository.GetbyEventId(eventId);
                if (account != null && account.AskClinicalQuestions && account.ClinicalQuestionTemplateId.HasValue)
                {
                    var clinicalTemplate = _healthAssessmentTemplateRepository.GetById(account.ClinicalQuestionTemplateId.Value);
                    questionIds.AddRange(clinicalTemplate.QuestionIds);
                }

                questions = _healthAssessmentRepository.GetByIds(questionIds);
            }

            if (questions.IsNullOrEmpty())
                questions = _healthAssessmentRepository.GetAllQuestions();
            return questions;
        }

        public void Save(HealthAssessmentEditModel model, long createdByOrgRoleUserId)
        {
            if (model.QuestionEditModels == null || !model.QuestionEditModels.Any())
            {
                return;
                //var questions = GetQuestions(model.EventId, model.CustomerId);

                //var questionModel = Mapper.Map<HealthAssessmentQuestion, HealthAssessmentQuestionEditModel>(questions.First());

                //questionModel.Answer = questionModel.DefaultAnswer;

                //model.QuestionEditModels = new[] { questionModel };
            }
            var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);

            var answerCollection = model.QuestionEditModels.Select(
                m =>
                new HealthAssessmentAnswer
                    {
                        Answer = m.Answer,
                        CustomerId = model.CustomerId,
                        QuestionId = m.QuestionId,
                        DataRecorderMetaData = new DataRecorderMetaData(createdByOrgRoleUserId, DateTime.Now, null),
                        EventCustomerId = eventCustomer.Id
                    }).ToArray();

            using (var scope = new TransactionScope())
            {
                var answerCollectiontoArchive = _healthAssessmentRepository.Get(model.CustomerId, model.EventId);

                var healthAssessmentAnswers = answerCollectiontoArchive as HealthAssessmentAnswer[] ?? answerCollectiontoArchive.ToArray();
                if (answerCollectiontoArchive != null && healthAssessmentAnswers.Any())
                {
                    var versionNumber = _healthAssessmentRepository.GetLastVersionNumber(eventCustomer.Id);
                    _healthAssessmentRepository.SaveArchive(healthAssessmentAnswers, versionNumber + 1);
                    _healthAssessmentRepository.Delete(eventCustomer.Id);
                }

                _healthAssessmentRepository.Save(answerCollection);
                scope.Complete();
            }
        }

        public HealthAssessmentFormEditModel GetModel(long eventId, long customerId, bool showKynEditModel = false, bool isBulkPrint = false)
        {
            var eventData = _eventRepository.GetById(eventId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var previousAttendedDate = _eventCustomerRepository.GetPreviousAttendedEventDate(eventId, customerId, eventData.EventDate);
            var captureSsn = _eventRepository.CaptureSsn(eventId);
            var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, TestGroup.FluShotTestIds);
            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId);
            var isBloodworkFormAttached = _eventPodRepository.IsBloodworkFormAttached(eventId);
            var account = _corporateAccountRepository.GetbyEventId(eventId);
            var orderid = _orderRepository.GetOrderIdByEventCustomerId(eventCustomer.Id);
            var testsPurchasedByCustomer = _eventCustomerPackageTestDetailService.GetTestsPurchasedByOrderId(orderid);

            var physicianName = string.Empty;
            if (pcp != null && pcp.Name != null)
            {
                physicianName = pcp.Name.FullName;
            }

            var isFlushotAttachedWithEvent = (eventTests != null && eventTests.Any());

            var isMammoPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.Mammogram, testsPurchasedByCustomer);
            var isKynPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, testsPurchasedByCustomer);
            var isHkynPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.HKYN, testsPurchasedByCustomer);
            var isBioCheckAssessmentPurchased = IsTestPurchasedWithHealthAssessment((long)TestType.MyBioCheckAssessment, testsPurchasedByCustomer);
            var isPhq9Purchased = IsTestPurchasedWithHealthAssessment((long)TestType.PHQ9, testsPurchasedByCustomer);

            var isLipidPurchased = IsTestPurchasedWithoutHealthAssessment((long)TestType.Lipid, testsPurchasedByCustomer);
            var isCagePurchased = IsTestPurchasedWithoutHealthAssessment((long)TestType.Alcoholism, testsPurchasedByCustomer);

            var issQualityMeasuresPurchased = IsTestPurchasedWithoutHealthAssessment((long)TestType.QualityMeasures, testsPurchasedByCustomer);
            var isIfobtPurchased = IsTestPurchasedWithoutHealthAssessment((long)TestType.IFOBT, testsPurchasedByCustomer);
            var isUrineMicroalbuminPurchased = IsTestPurchasedWithoutHealthAssessment((long)TestType.UrineMicroalbumin, testsPurchasedByCustomer);

            Language language = null;
            if (customer.LanguageId.HasValue)
            {
                language = _languageRepository.GetById(customer.LanguageId.Value);
            }

            string physicianRecordRequestSignatureUrl = string.Empty;
            DateTime? physicianRecordRequestSignedDate = null;
            var physicianRecordRequestMediaLocation = _mediaRepository.GetPhysicianRecordRequestSignatureLocation(eventId, customerId);
            var physicianRecordRequest = _physicianRecordRequestSignatureRepository.GetByEventCustomerId(eventCustomer.Id);
            if (physicianRecordRequest != null)
            {
                var signatureFile = _fileRepository.GetById(physicianRecordRequest.SignatureFileId);
                physicianRecordRequestSignatureUrl = physicianRecordRequestMediaLocation.Url + signatureFile.Path;
                physicianRecordRequestSignedDate = physicianRecordRequest.ConsentSignedDate;
            }

            var patientGiftCardSignatureUrl = string.Empty;
            var technicianGiftCardSignatureUrl = string.Empty;
            var giftCardSignatureMediaLocation = _mediaRepository.GetGiftCardSignatureLocation(eventId, customerId);
            var giftCertificateSignature = _eventCustomerGiftCardRepository.GetByEventCustomerId(eventCustomer.Id);
            if (giftCertificateSignature != null && (giftCertificateSignature.PatientSignatureFileId.HasValue || giftCertificateSignature.TechnicianSignatureFileId.HasValue))
            {
                var signatureFileIds = new List<long>();
                if (giftCertificateSignature.PatientSignatureFileId.HasValue)
                    signatureFileIds.Add(giftCertificateSignature.PatientSignatureFileId.Value);
                if (giftCertificateSignature.TechnicianSignatureFileId.HasValue)
                    signatureFileIds.Add(giftCertificateSignature.TechnicianSignatureFileId.Value);

                var signatureFiles = _fileRepository.GetByIds(signatureFileIds);
                if (giftCertificateSignature.PatientSignatureFileId.HasValue)
                {
                    var patientFile = signatureFiles.First(x => x.Id == giftCertificateSignature.PatientSignatureFileId.Value);
                    patientGiftCardSignatureUrl = giftCardSignatureMediaLocation.Url + patientFile.Path;
                }
                if (giftCertificateSignature.TechnicianSignatureFileId.HasValue)
                {
                    var technicianFile = signatureFiles.First(x => x.Id == giftCertificateSignature.TechnicianSignatureFileId.Value);
                    technicianGiftCardSignatureUrl = giftCardSignatureMediaLocation.Url + technicianFile.Path;
                }
            }

            var participationConsent = new ParticipationConsentModel();
            var participationConsentMediaLocation = _mediaRepository.GetParticipationConsentSignatureLocation(eventId, customerId);
            var participationConsentSignature = _participationConsentSignatureRepository.GetByEventCustomerId(eventCustomer.Id);
            if (participationConsentSignature != null)
            {
                var signatureFileIds = new[] { participationConsentSignature.SignatureFileId, participationConsentSignature.InsuranceSignatureFileId };
                var signatureFiles = _fileRepository.GetByIds(signatureFileIds);

                var participationSignatreFile = signatureFiles.First(x => x.Id == participationConsentSignature.SignatureFileId);
                participationConsent.SignatureImageUrl = participationConsentMediaLocation.Url + participationSignatreFile.Path;
                participationConsent.ConsentSignedDate = participationConsentSignature.ConsentSignedDate.ToString("MM/dd/yyyy");

                var insuranceSignatureFile = signatureFiles.First(x => x.Id == participationConsentSignature.InsuranceSignatureFileId);
                participationConsent.InsuranceSignatureImageUrl = participationConsentMediaLocation.Url + insuranceSignatureFile.Path;
                participationConsent.InsuranceConsentSignedDate = participationConsentSignature.InsuranceConsentSignedDate.ToString("MM/dd/yyyy");
            }

            var headerModel = new HealthAssessmentHeaderEditModel
                                  {
                                      Address = Mapper.Map<Address, AddressEditModel>(customer.Address),
                                      AttendedPreviousScreening = previousAttendedDate != null,
                                      CustomerId = customer.CustomerId,
                                      CustomerName = customer.Name,
                                      DateofBirth = customer.DateOfBirth,
                                      DateofPreviousScreening = previousAttendedDate,
                                      Email = customer.Email != null ? customer.Email.ToString() : "",
                                      EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                                      EventDate = eventData.EventDate,
                                      EventId = eventData.Id,
                                      Gender = (int)customer.Gender,
                                      Height = customer.Height != null ? (int)customer.Height.TotalInches : 0,
                                      Weight = customer.Weight != null ? (int)customer.Weight.TotalPounds : 0,
                                      PhoneNumber = customer.HomePhoneNumber.ToString(),
                                      Race = (int)customer.Race,
                                      Laguage = language == null ? string.Empty : language.Name,
                                      MemberId = customer.InsuranceId,
                                      Ssn = customer.Ssn,
                                      CaptureSsn = captureSsn,
                                      PhysicianName = physicianName,
                                      ParticipationConsent = participationConsent
                                  };


            QualityAssuranceResultViewModel qualityAssuranceResultModel = null;

            if (account != null && (account.AttachQualityAssuranceForm || account.AttachCongitiveClockForm || account.AttachChronicEvaluationForm))
            {
                qualityAssuranceResultModel = new QualityAssuranceResultViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name,
                    DateofBirth = customer.DateOfBirth,
                    Gender = (int)customer.Gender,
                    Height = customer.Height != null ? (int)customer.Height.TotalInches : 0,
                    Weight = customer.Weight != null ? (int)customer.Weight.TotalPounds : 0,
                    Race = (int)customer.Race,
                    AlCarteTests = AlacarteTestPurchasedByCustomer(orderid),
                    EventDate = eventData.EventDate
                };
            }

            FluVaccinationConsentViewModel fluConsentViewModel = null;

            var isFlushotTestPurchased = false;
            if (isFlushotAttachedWithEvent)
            {
                if (account == null)
                {
                    isFlushotTestPurchased = IsTestPurchasedWithoutHealthAssessment(TestGroup.FluShotTestIds, testsPurchasedByCustomer);
                }
                else if (account.GenerateFluPneuConsentForm)
                {
                    isFlushotTestPurchased = true;
                }

                if (isFlushotTestPurchased)
                {
                    var answers = _fluConsentAnswerRepository.GetByEventCustomerId(eventCustomer.Id);
                    var questions = _fluConsentQuestionRepository.GetAllQuestions();

                    var signature = _fluConsentSignatureRepository.GetByEventCustomerId(eventCustomer.Id);

                    var signatureFileIds = signature != null ? new[] { signature.SignatureFileId } : null;

                    if (signature != null && signature.ClinicalProviderSignatureFileId.HasValue)
                    {
                        signatureFileIds = new[] { signature.SignatureFileId, signature.ClinicalProviderSignatureFileId.Value };
                    }

                    var signatureFiles = !signatureFileIds.IsNullOrEmpty() ? _fileRepository.GetByIds(signatureFileIds) : null;

                    fluConsentViewModel = _fluVaccinationConsentService.GetFluVaccinationConsentViewModel(eventData, customer, host, questions, answers, signature, signatureFiles);
                }
            }

            var footerModel = new HealthAssessmentFooterEditModel
                                  {
                                      ContactPhoneNumber = customer.EmergencyContactPhoneNumber != null ? customer.EmergencyContactPhoneNumber.ToString() : "",
                                      CustomerId = customerId,
                                      CustomerName = customer.Name,
                                      EmergencyContact = customer.EmergencyContactName,
                                      EventDate = eventData.EventDate,
                                      Relationship = customer.EmergencyContactRelationship
                                  };

            var pcpConsentViewModel = (account != null && account.CapturePcpConsent) ? _customerService.GetAwvPcpConsentViewModel(customer, eventData, pcp, physicianRecordRequestSignatureUrl, physicianRecordRequestSignedDate) : null;


            BloodworksLabelViewModel bloodworksLabelModel = null;
            MonarchAttestaionFormViewModel monarchAttestaionForm = null;


            if (isBulkPrint && isBloodworkFormAttached && IsBloodWorkTestPurchased(testsPurchasedByCustomer) && account != null)
            {
                bloodworksLabelModel = _operationsReportingService.GetBloodworksLabelForCustomer(eventData, customer, testsPurchasedByCustomer);
            }

            if (isBulkPrint && customer != null && account != null && account.Id == _settings.MonarchAccountId)
            {
                monarchAttestaionForm = new MonarchAttestaionFormViewModel
                {
                    MemberName = customer.Name.ToString(),
                    Dob = customer.DateOfBirth,
                    MemberId = customer.InsuranceId,
                    ScreeningDate = eventData.EventDate
                };
            }

            PatientWorksheet patientWorksheetModel = null;
            CheckListFormEditModel checkListFormModel = null;
            if (isBulkPrint)
            {
                patientWorksheetModel = _patientWorksheetService.GetPatientWorksheetModel(customer, eventData, eventCustomer);
                patientWorksheetModel.PrintScreeningInfo = (account == null || account.ScreeningInfo);
                patientWorksheetModel.PrintPatientWorkSheet = (account == null || account.PatientWorkSheet);
            }

            if (account != null && account.PrintCheckList && isBulkPrint && eventData.EventDate < _settings.ChecklistChangeDate)
            {
                checkListFormModel = _customerCheckListService.GetCustomerCheckListEdtiModel(customer, account, eventCustomer);
                checkListFormModel.IsPrintable = isBulkPrint;
            }

            var bookPcpAppointment = (account != null && account.PrintPcpAppointmentForBulkHaf);
            EventCustomerPcpAppointmentViewModel pcpAppointmentViewModel = null;
            if (bookPcpAppointment)
            {
                pcpAppointmentViewModel = _eventCustomerPcpAppointmentService.GetEventCustomerPcpAppointmentViewModel(eventData, customer, account, pcp, eventCustomer);
            }

            GiftCertificateViewModel giftCertificateViewModel = null;
            if (account != null && account.AttachGiftCard)
            {
                giftCertificateViewModel = new GiftCertificateViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name,
                    EventDate = eventData.EventDate,
                    GiftAmmount = account.GiftCardAmount ?? 0,
                    GiftCardReceived = giftCertificateSignature != null ? giftCertificateSignature.GiftCardReceived : (bool?)null,
                    PatientSignatureUrl = patientGiftCardSignatureUrl,
                    TechnicianSignatureUrl = technicianGiftCardSignatureUrl
                };
            }
            OrderRequisitionFormViewModel orderRequisitionFormViewModel = null;
            if (account != null && account.AttachOrderRequisitionForm && isIfobtPurchased)
            {
                orderRequisitionFormViewModel = new OrderRequisitionFormViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name,
                    EventDate = eventData.EventDate,
                    EventId = eventData.Id
                };
            }

            LabFormViewModel printMicroalbuminFormModel = null;
            if (account != null && account.PrintMicroalbuminForm && isBulkPrint && isUrineMicroalbuminPurchased)
            {
                printMicroalbuminFormModel = _labFormService.GetMicroalbumineLabFormViewModel(eventData, customer, host);
            }

            LabFormViewModel printIfobtFormModel = null;
            if (account != null && account.PrintIFOBTForm && isBulkPrint && isIfobtPurchased)
            {
                printIfobtFormModel = _labFormService.GetIfobtLabFormViewModel(eventData, customer, host);
            }

            LoincLabDataViewModel loincLabDataViewModel = null;
            if (account != null && account.PrintLoincLabData && isBulkPrint)
            {
                if (!string.IsNullOrEmpty(customer.InsuranceId))
                {
                    var loincLabDataLines = _loincLabDataRepository.GetByMemberId(customer.InsuranceId).OrderBy(x => x.Id);
                    var loincCrosswalkLines = _loincCrosswalkRepository.GetByLoincNumber(customer.InsuranceId);

                    if (!loincLabDataLines.IsNullOrEmpty())
                    {
                        loincLabDataViewModel = new LoincLabDataViewModel
                        {
                            CustomerId = customer.CustomerId,
                            Name = customer.Name.ToString(),
                            DateOfBirth = customer.DateOfBirth,
                            EventId = eventId,
                            Gender = customer.Gender,
                            MemberId = customer.InsuranceId,
                            Gmpi = customer.AdditionalField4,
                        };

                        var labDataList = (from loincLabData in loincLabDataLines
                                           let loincCrosswalk = loincCrosswalkLines.FirstOrDefault(x => x.LoincNumber == loincLabData.Loinc)
                                           select new LoincLabDataModel
                                           {
                                               MemberId = loincLabData.MemberId,
                                               Gmpi = loincLabData.Gmpi,
                                               Loinc = loincLabData.Loinc,
                                               LoincDescription = loincLabData.LoincDescription,
                                               ResultValue = loincLabData.ResultValue,
                                               ResultUnits = loincLabData.ResultUnits,
                                               RefRange = loincLabData.RefRange,
                                               LongDescription = loincCrosswalk != null ? loincCrosswalk.LongCommonName : "",
                                               DoS = loincLabData.DateOfService
                                           }).ToList();
                        loincLabDataViewModel.LabDataList = labDataList;
                    }
                }
            }
            var printCheckList = false;
            if (eventData.EventDate < _settings.ChecklistChangeDate)
                printCheckList = account != null && account.PrintCheckList;

            SurveyFormEditModel surveyFormEditModel = null;

            if (isBulkPrint && account != null && account.CaptureSurvey)
            {
                surveyFormEditModel = _surveyTemplateService.GetCustomerSurveyFormEditModel(customer, account, eventCustomer);
                surveyFormEditModel.IsPrintable = isBulkPrint;

            }
            var IsCorporateAccount =account != null ? _corporateAccountRepository.IsCorporateAccount(account.Id) : false;
            

            var model = new HealthAssessmentFormEditModel
                            {
                                CustomerId = customerId,
                                EventId = eventId,
                                IsMammoPurchased = isMammoPurchased,
                                IsKynPurchased = (isKynPurchased || isHkynPurchased) && isKynIntegrationEnabled,
                                IsBulkPrint = isBulkPrint,
                                HealthAssessmentEditModel = GetHealthAssessmentEditModel(customerId, eventId, 0, showKynEditModel),
                                HealthAssessmentFooterEditModel = footerModel,
                                HealthAssessmentHeaderEditModel = headerModel,
                                AbnConsentModel = (account != null && account.CaptureAbnStatus) ? new AbnConsentViewModel() { CustomerId = customerId, CustomerName = customer.Name.FullName } : null,
                                PcpConsentViewModel = pcpConsentViewModel,
                                IsPhq9Purchased = isPhq9Purchased,
                                IsFlushotTestPurchased = isFlushotTestPurchased,
                                IsQualityMeasuresPurchased = issQualityMeasuresPurchased,
                                MammogramHistoryFormViewModel = isMammoPurchased ? _customerService.GetMammogramHistoryFormViewModel(customerId) : null,
                                QualityAssuranceResultViewModel = qualityAssuranceResultModel,
                                AttachQualityAssuranceForm = account != null && account.AttachQualityAssuranceForm,
                                AttachCongitiveClockForm = account != null && account.AttachCongitiveClockForm,
                                AttachChronicEvaluationForm = account != null && account.AttachChronicEvaluationForm,
                                AttachParicipantConsentForm = account != null && account.AttachParicipantConsentForm,
                                FluVaccinationConsentViewModel = fluConsentViewModel,
                                AccountTag = account != null ? account.Tag : string.Empty,
                                PrintLipidBasicBiomertic = isKynIntegrationEnabled && !(isKynPurchased || isHkynPurchased || isBioCheckAssessmentPurchased) && isLipidPurchased,
                                PrintKynBasicBiomertic = isKynIntegrationEnabled && (isKynPurchased || isHkynPurchased || isBioCheckAssessmentPurchased),
                                BloodworksLabelModel = bloodworksLabelModel,
                                PatientWorksheetModel = patientWorksheetModel,
                                ShowHafFooter = (account == null || account.ShowHafFooter),
                                PcpAppointmentViewModel = pcpAppointmentViewModel,
                                GiftCertificateViewModel = giftCertificateViewModel,
                                IsHealthPlan = account != null && account.IsHealthPlan,
                                IsCagePurchased = isCagePurchased,
                                OrderRequisitionFormViewModel = orderRequisitionFormViewModel,
                                CheckListFormModel = checkListFormModel,
                                PrintCheckList = printCheckList,
                                PrintIFOBTForm = account != null && account.PrintIFOBTForm,
                                PrintMicroalbuminForm = account != null && account.PrintMicroalbuminForm,
                                PrintIFOBTFormModel = printIfobtFormModel,
                                PrintMicroalbuminFormModel = printMicroalbuminFormModel,
                                MonarchAttestaionForm = monarchAttestaionForm,
                                PrintLoincLabData = account != null && account.PrintLoincLabData,
                                PrintLoincLabDataModel = loincLabDataViewModel,
                                SurveyFormModel = surveyFormEditModel,
                                CaptureSurvey = account != null && account.CaptureSurvey,
                                IsCorporateAccount = IsCorporateAccount
                            };

            if (isMammoPurchased)
            {
                var questionModelCollection = model.HealthAssessmentEditModel.QuestionEditModels;

                var questionOtherThanMamo = questionModelCollection.Where(x => !model.HealthAssessmentEditModel.mammogramQuestionIds.Contains(x.QuestionId));

                if (questionOtherThanMamo != null && questionOtherThanMamo.Any())
                    model.ShowMammogramQuestionnarire = true;
            }

            return model;
        }

        public bool IsTestPurchasedWithHealthAssessment(long testId, List<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => et.Id == testId && et.HealthAssessmentTemplateId.HasValue);
            return isTestPurchased;
        }

        private bool IsTestPurchasedWithoutHealthAssessment(long testId, List<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => et.Id == testId);
            return isTestPurchased;
        }

        private bool IsBloodWorkTestPurchased(List<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => TestGroup.BloodWorkTestIds.Contains(et.Id));
            return isTestPurchased;
        }

        private bool IsTestPurchasedWithoutHealthAssessment(IEnumerable<long> testids, IEnumerable<Test> eventTests)
        {
            var isTestPurchased = eventTests.Any(et => testids.Contains(et.Id));
            return isTestPurchased;
        }
        private string AlacarteTestPurchasedByCustomer(long orderId)
        {
            var test = _eventCustomerPackageTestDetailService.GetAlaCarteTestsPurchasedByCustomer(orderId);
            return test.IsNullOrEmpty() ? string.Empty : string.Join(", ", test.Select(x => x.Alias));
        }
        //private string AlacarteTestPurchasedByCustomer(long eventId, long customerId)
        //{
        //    var test = _eventCustomerPackageTestDetailService.GetAlaCarteTestsPurchasedByCustomer(eventId, customerId);
        //    return test.IsNullOrEmpty() ? string.Empty : string.Join(", ", test.Select(x => x.Alias));
        //}
        public IEnumerable<OrderedPair<long, DateTime>> GetHealthAssesmentSavedDatePair(IEnumerable<long> eventCustomerIds)
        {
            return _healthAssessmentRepository.GetHealthAssesmentSavedDatePair(eventCustomerIds);
        }

        public bool SaveClinicalQuestions(string guid, long eventId, long customerId, long organisationUserRoleId)
        {
            var clinicalAnswers = _customerClinicalQuestionAnswerRepository.GetCustomerClinicalQuestionAnswers(guid, customerId);

            if (!clinicalAnswers.IsNullOrEmpty())
            {

                var hafQuestions = GetQuestions(eventId, customerId);
                var hafQuestionIds = hafQuestions.Select(x => x.Id);
                var clinicalAnswersToCopy = clinicalAnswers.Where(x => hafQuestionIds.Contains(x.ClinicalHealthQuestionId));
                var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
                var answers = new List<HealthAssessmentAnswer>();

                foreach (var healthAssessmentAnswer in clinicalAnswersToCopy)
                {
                    var answer = new HealthAssessmentAnswer
                    {
                        QuestionId = healthAssessmentAnswer.ClinicalHealthQuestionId,
                        CustomerId = customerId,
                        Answer = healthAssessmentAnswer.HealthQuestionAnswer,
                        EventCustomerId = eventCustomer.Id,
                        DataRecorderMetaData = new DataRecorderMetaData(organisationUserRoleId, DateTime.Now, null)
                    };
                    answers.Add(answer);
                }

                if (answers.Count > 0)
                    _healthAssessmentRepository.Save(answers);
            }
            return true;
        }

        public bool UpdateClinicalQuestions(string guid, long eventId, long customerId, long organisationUserRoleId)
        {
            var clinicalAnswers = _customerClinicalQuestionAnswerRepository.GetCustomerClinicalQuestionAnswers(guid, customerId);

            if (!clinicalAnswers.IsNullOrEmpty())
            {
                var hafQuestions = GetQuestions(eventId, customerId);
                var hafQuestionIds = hafQuestions.Select(x => x.Id);
                var clinicalAnswersToCopy = clinicalAnswers.Where(x => hafQuestionIds.Contains(x.ClinicalHealthQuestionId));
                var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);

                var answers = new List<HealthAssessmentAnswer>();

                foreach (var healthAssessmentAnswer in clinicalAnswersToCopy)
                {
                    var answer = new HealthAssessmentAnswer
                    {
                        QuestionId = healthAssessmentAnswer.ClinicalHealthQuestionId,
                        CustomerId = customerId,
                        Answer = healthAssessmentAnswer.HealthQuestionAnswer,
                        EventCustomerId = eventCustomer.Id,
                        DataRecorderMetaData = new DataRecorderMetaData(organisationUserRoleId, DateTime.Now, null)
                    };
                    answers.Add(answer);
                }


                if (answers.Count > 0)
                {
                    var answerCollectiontoArchive = _healthAssessmentRepository.Get(customerId, eventId);

                    using (var scope = new TransactionScope())
                    {
                        if (answerCollectiontoArchive.Any())
                        {
                            var questionIds = answers.Select(x => x.QuestionId);
                            var hafAnswersOtherthanClinicalQuestion = answerCollectiontoArchive.Where(x => !questionIds.Contains(x.QuestionId)).ToList();
                            hafAnswersOtherthanClinicalQuestion.AddRange(answers);

                            answers = hafAnswersOtherthanClinicalQuestion;

                            var healthAssessmentAnswers = answerCollectiontoArchive as HealthAssessmentAnswer[] ?? answerCollectiontoArchive.ToArray();

                            if (answerCollectiontoArchive != null && healthAssessmentAnswers.Any())
                            {
                                var versionNumber = _healthAssessmentRepository.GetLastVersionNumber(eventCustomer.Id);
                                _healthAssessmentRepository.SaveArchive(healthAssessmentAnswers, versionNumber + 1);
                                _healthAssessmentRepository.Delete(eventCustomer.Id);
                            }
                        }

                        _healthAssessmentRepository.Save(answers);
                        scope.Complete();
                    }
                }
            }

            return true;
        }

        public StandingOrderFormHeaderEditModel GetStandingOrderFormHeaderEditModel(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var customerPreApprovedTest = new List<string>();
            var preApprovedTest = _eventCustomerPreApprovedTestRepository.GetPreApprovedTest(eventCustomer.Id);
            if (!preApprovedTest.IsNullOrEmpty())
            {
                customerPreApprovedTest.AddRange(preApprovedTest);
            }

            var preApprovedPackageId = _eventCustomerPreApprovedPackageTestRepository.GetPreApprovedTestByEventCustomerId(eventCustomer.Id);

            if (preApprovedPackageId > 0)
            {
                var packageDetails = _packageRepository.GetById(preApprovedPackageId);
                customerPreApprovedTest.AddRange(packageDetails.Tests.Select(x => x.Name).ToList());
            }
            if (!customerPreApprovedTest.IsNullOrEmpty())
                customerPreApprovedTest = customerPreApprovedTest.Distinct().ToList();

            return new StandingOrderFormHeaderEditModel
            {
                CustomerId = customer.CustomerId,
                DoB = customer.DateOfBirth,
                EventId = eventId,
                Gender = customer.Gender,
                Name = customer.Name,
                PreApporvedTestNames = customerPreApprovedTest
            };
        }
    }
}