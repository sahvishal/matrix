using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    //[RoleBasedAuthorize]
    public class ResultsController : Controller
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ITestResultService _testResultService;
        private readonly ICustomerService _customerService;
        private readonly IHealthAssessmentService _healthAssessmentService;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private int _pageSize;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IKynHealthAssessmentService _kynHealthAssessmentService;
        private readonly IGenerateKynLipidService _generateKynLipidService;
        private readonly IFluVaccinationConsentService _vaccinationConsentService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPriorityInQueueService _priorityInQueueService;
        private readonly ICustomerEventPriorityInQueueDataRepository _priorityInQueueRepository;
        private readonly IEventRepository _eventRepository;
        private readonly INewResultFlowStateService _newResultFlowStateService;
        private readonly IGiftCardService _giftCardService;
        private readonly IParticipationConsentService _participationConsentService;
        private readonly IChaperoneService _chaperoneService;

        public ResultsController(ITestResultService testResultService, IEventCustomerResultRepository eventCustomerResultRepository, IHealthAssessmentService healthAssessmentService, ISessionContext sessionContext,
            ISettings settings, ICustomerService customerService, ILogManager logManager, IPdfGenerator pdfGenerator, IMediaRepository mediaRepository, IConfigurationSettingRepository configurationSettingRepository,
            IKynHealthAssessmentService kynHealthAssessmentService, IGenerateKynLipidService generateKynLipidService, IFluVaccinationConsentService vaccinationConsentService, IEventCustomerRepository eventCustomerRepository
            , IPriorityInQueueService priorityInQueueService, ICustomerEventPriorityInQueueDataRepository priorityInQueueRepository, IEventRepository eventRepository, INewResultFlowStateService newResultFlowStateService,
            IGiftCardService giftCardService, IParticipationConsentService participationConsentService, IChaperoneService chaperoneService)
        {
            _customerService = customerService;
            _testResultService = testResultService;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _healthAssessmentService = healthAssessmentService;
            _sessionContext = sessionContext;
            _pageSize = settings.DefaultPageSizeForReports;
            _logger = logManager.GetLogger<Global>();
            _pdfGenerator = pdfGenerator;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _configurationSettingRepository = configurationSettingRepository;
            _kynHealthAssessmentService = kynHealthAssessmentService;
            _generateKynLipidService = generateKynLipidService;
            _vaccinationConsentService = vaccinationConsentService;
            _eventCustomerRepository = eventCustomerRepository;
            _priorityInQueueService = priorityInQueueService;
            _priorityInQueueRepository = priorityInQueueRepository;
            _eventRepository = eventRepository;
            _newResultFlowStateService = newResultFlowStateService;
            _giftCardService = giftCardService;
            _participationConsentService = participationConsentService;
            _chaperoneService = chaperoneService;
        }

        [RoleBasedAuthorize]
        public ActionResult ResultStatusList(EventCustomerResultStatusListModelFilter filter = null)
        {
            try
            {
                long accountId = 0;
                //if (filter != null && _sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner))
                //{
                //    accountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
                //    if (filter.EventId > 0)
                //    {
                //        var isValidEvent = _eventRepository.ValidateEventForAccount(filter.EventId, accountId);
                //        if (!isValidEvent)
                //            Response.RedirectUser("/Home/UnauthorizeAccess");
                //    }
                //}

                var model = filter != null ? _testResultService.GetEventCustomerResultStatusList(filter, accountId) : null;
                if (model != null)
                {
                    model.Filter = filter;
                    model.RoleId = _sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error("Error while loading Result Status List for " + (filter != null ? "[" + filter + "]" : "") + ". Message: " + ex.Message + " \n\t Stack Trace:" + ex.StackTrace);
                return View();
            }
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult UndoPreAudit(long eventId, long customerId, bool isNewResultFlow)
        {
            var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            _testResultService.UndoPreAudit(eventId, customerId, orgId, isNewResultFlow);

            if (isNewResultFlow)
            {
                var canUnsignModel = new MedicareCanUnsignViewModel
                {
                    EventId = eventId,
                    HfCustomerId = customerId,
                    CanUnsign = true,
                };

                _newResultFlowStateService.RunTaskSyncHraCanUnsignForVisit(canUnsignModel, orgId, "UndoPreAudit");
            }
            return Content("");
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult UndoEvaluation(long eventId, long customerId)
        {
            _testResultService.UndoEvaluation(eventId, customerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return Content("");
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult RegeneratePacket(long eventId, long customerId)
        {
            _eventCustomerResultRepository.SetRecordforRegeneratingResultPacket(eventId, customerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return Content("");
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult RollbackToPreviousState(long eventId, long customerId, TestResultStateLabel stateToRevertAt)
        {
            bool isPartial;
            bool isChartSignedOff = true;

            var number = 0;
            var isNewResultFlow = _eventRepository.IsEventHasNewResultFlow(eventId);

            if (isNewResultFlow)
            {
                number = (int)((stateToRevertAt).GetNewResultStatefromPresentation(out isPartial, out isChartSignedOff));
            }
            else
            {
                number = (int)((stateToRevertAt).GetResultStatefromPresentation(out isPartial));
            }

            _testResultService.SetResultstoState(eventId, customerId, number, isPartial, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, isChartSignedOff);
            return Content("");
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult SetGeneratedRecordtoEvaluatedRecords(long eventId, long customerId)
        {
            var previousEventCustomerResultState = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId).ResultState;
            _testResultService.SetResultstoState(eventId, customerId, (int)TestResultStateNumber.Evaluated, false, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            eventCustomerResult.IsResultPdfGenerated = false;
            eventCustomerResult.IsClinicalFormGenerated = false;

            if (previousEventCustomerResultState == (long)TestResultStateNumber.ResultDelivered)
            {
                eventCustomerResult.IsRevertedToEvaluation = true;
                eventCustomerResult.IsPennedBack = false;
            }

            _eventCustomerResultRepository.Save(eventCustomerResult);

            return Content("");
        }

        [RoleBasedAuthorize]
        public ActionResult GetCustomerResultStatus(long customerId)
        {
            var model = _testResultService.GetCustomerResultStatus(customerId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult TechnicalLimitedScreening(TechnicalLimitedScreeningCustomerListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null) filter = new TechnicalLimitedScreeningCustomerListModelFilter();
            var model = _testResultService.GetCustomerwithTechnicallimitedScreening(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new TechnicalLimitedScreeningCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.CustomerName, filter.Test, filter.FromDate, filter.ToDate, filter.ResultState });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, (int)totalRecords, urlFunc);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult GetHealthAssessment(long eventId, long customerId)
        {
            return RedirectToAction("HealthAssessment", new { eventId, customerId });
        }

        public ActionResult HealthAssessment(long eventId, long customerId, bool print = false, bool printBlank = false, bool LoadLayout = true, bool showKynEditModel = true, bool bulkPrint = false, bool isOnlineUser = false)
        {
            var model = _healthAssessmentService.GetModel(eventId, customerId, showKynEditModel, bulkPrint);

            if (printBlank)
            {
                model.Print = true;
                model.PrintBlank = true;
            }
            else if (print)
            {
                model.Print = true;
                model.PrintBlank = false;
            }
            //if (bulkPrint)
            //{
            //    model.PrintBlank = true;
            //}
            model.ShowConsentForm = !isOnlineUser;
            model.LoadLayout = LoadLayout;
            model.RefrrerUrl = Request.UrlReferrer != null ? Request.UrlReferrer.PathAndQuery : "";

            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult HealthAssessment(HealthAssessmentFormEditModel model, HealthAssessmentHeaderEditModel headerModel, HealthAssessmentEditModel assessmentEditModel, HealthAssessmentFooterEditModel footerEditModel, KynHealthAssessmentEditModel kynHealthAssessmentEditModel)
        {
            try
            {
                if (!model.PrintBlank)
                {
                    _customerService.SaveCustomer(headerModel, footerEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                    _healthAssessmentService.Save(assessmentEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    if ((model.IsKynPurchased || assessmentEditModel.IsBioCheckAssessmentPurchased || assessmentEditModel.IsHKynPurchased) && (kynHealthAssessmentEditModel != null))
                        _kynHealthAssessmentService.SetKynHealthAssessment(kynHealthAssessmentEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }

                model.RefrrerUrl = "/Scheduling/EventCustomerList/Index?id=" + model.EventId;
                if (model.RedirecttoPrevious && !model.Print)
                {
                    Response.RedirectUser(model.RefrrerUrl + "&hId=" + model.CustomerId);
                    return null;
                }

                var newModel = _healthAssessmentService.GetModel(model.EventId, model.CustomerId, true);

                newModel.Print = model.Print;
                newModel.PrintBlank = model.PrintBlank;
                newModel.OpenforPrint = model.OpenforPrint;
                newModel.RedirecttoPrevious = model.RedirecttoPrevious;
                newModel.RefrrerUrl = model.RefrrerUrl;
                newModel.IsBulkPrint = model.IsBulkPrint;

                if (newModel.Print || newModel.PrintBlank)
                {
                    newModel.PrintUrl = PrintHealthAssessmentForm(newModel);
                }

                return View(newModel);
            }
            catch (Exception ex)
            {
                var newModel = _healthAssessmentService.GetModel(model.EventId, model.CustomerId, true);
                newModel.Print = model.Print;
                newModel.PrintBlank = model.PrintBlank;
                newModel.OpenforPrint = model.OpenforPrint;
                newModel.RedirecttoPrevious = model.RedirecttoPrevious;
                newModel.RefrrerUrl = model.RefrrerUrl;
                newModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
                _logger.Error("Error Message : " + ex.Message + " \n stack Trace : " + ex.StackTrace);
                return View(newModel);
            }
        }

        private string PrintHealthAssessmentForm(HealthAssessmentFormEditModel model)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = model.EventId + "_" + model.CustomerId + ".pdf";

            var url = _settings.AppUrl + "/Medical/Results/HealthAssessment?customerId=" + model.CustomerId + "&eventId=" + model.EventId + "&Print=" + model.Print + "&PrintBlank=" + model.PrintBlank + "&LoadLayout=false";

            var basicBiometricFile = string.Empty;
            if (model.PrintKynBasicBiomertic && model.IsKynPurchased)
            {
                var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);
                var kynBasicBiometricPdf = PrintKynBasicBiometric(eventCustomer.Id, mediaLocation);
                basicBiometricFile = mediaLocation.PhysicalPath + kynBasicBiometricPdf;
            }
            else if (model.PrintLipidBasicBiomertic)
            {
                var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);
                var lipidBasicBiometricPdf = PrintLipidBasicBiometric(eventCustomer.Id, mediaLocation);
                basicBiometricFile = mediaLocation.PhysicalPath + lipidBasicBiometricPdf;
            }

            _pdfGenerator.GeneratePdfForHaf(url, mediaLocation.PhysicalPath + fileName, "", basicBiometricFile, "");
            _pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);

            return mediaLocation.Url + fileName;
        }

        [RoleBasedAuthorize]
        public ActionResult HealthAssessmentForm(long customerId, long eventId, int version = 0, bool showkyn = false)
        {
            return View(_healthAssessmentService.GetHealthAssessmentEditModel(customerId, eventId, version, showkyn));
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult SaveHealthAssessmentForm(HealthAssessmentEditModel model, KynHealthAssessmentEditModel kynModel)
        {
            if (model == null)
                return Json(new { Result = false, Message = "Model can't be null!" });


            if ((model.IsKynPurchased || model.IsBioCheckAssessmentPurchased || model.IsHKynPurchased) && kynModel != null)
                _kynHealthAssessmentService.SetKynHealthAssessment(kynModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            _healthAssessmentService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return Json(new { Result = true, Message = "" });
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult SetPriorityInQueue(PriorityInQueueEditModel priorityInQueueModel)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetById(priorityInQueueModel.EventCustomerResultId);
            if (eventCustomerResult == null)
            {
                return Json(new { Message = "You cannot mark the customer as priority in queue as there is no result data for the customer.", IsSuccess = false, IsTestSaved = false });
            }
            if (!priorityInQueueModel.IsPriorityInQueue)
            {
                var priorityInQueueTests = _priorityInQueueRepository.GetByEventCustomerResultId(priorityInQueueModel.EventCustomerResultId);
                if (priorityInQueueTests != null && priorityInQueueTests.Any())
                {
                    return Json(new { Message = "Customer can not be removed from priority list as some tests are marked as Proirity in queue.", IsSuccess = false, IsTestSaved = true });
                }
            }
            _priorityInQueueService.UpdatePriorityinQueue(priorityInQueueModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return Json(new { Message = "Priority In queue marked successfully", IsSuccess = true, IsTestSaved = true });
        }

        public ActionResult MammoConsent(long customerId, long eventId, bool print = false)
        {
            var model = _customerService.GetClientNoticeEditModel(customerId);
            model.EventId = eventId;
            model.RefrrerUrl = Request.UrlReferrer != null ? Request.UrlReferrer.PathAndQuery : "";
            model.Print = print;
            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult MammoConsent(MammoConsentEditModel model)
        {
            try
            {
                if (model.Print)
                    model.PrintUrl = GenerateMammoConsent(model);
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
                return View(model);
            }
        }

        [RoleBasedAuthorize]
        public ActionResult PrintMammoConsent(long customerId, long eventId)
        {
            var model = new MammoConsentEditModel { EventId = eventId, CustomerId = customerId, Print = true };
            var printUrl = GenerateMammoConsent(model);
            Response.RedirectUser(printUrl);
            return null;
        }

        private string GenerateMammoConsent(MammoConsentEditModel model)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = "MammoConsent_" + model.EventId + "_" + model.CustomerId + ".pdf";

            var url = _settings.AppUrl + "/Medical/Results/MammoConsent?customerId=" + model.CustomerId + "&eventId=" + model.EventId + "&print=" + model.Print;

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            return mediaLocation.Url + fileName;
        }

        [RoleBasedAuthorize]
        public ActionResult PrintKyn(long eventCustomerId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var pdfFileName = PrintKynBasicBiometric(eventCustomerId, mediaLocation);

            Response.RedirectUser(mediaLocation.Url + pdfFileName);
            return null;

        }

        private string PrintKynBasicBiometric(long eventCustomerId, MediaLocation mediaLocation)
        {
            var guid = Guid.NewGuid().ToString();

            var pdfFileName = "BasicBiometric_" + guid + ".pdf";
            var htmlFileName = "Kyn_" + guid + ".html";

            _generateKynLipidService.GenerateKynResult(mediaLocation.PhysicalPath + htmlFileName, eventCustomerId);

            //_pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);
            _pdfGenerator.GeneratePdf(mediaLocation.Url + htmlFileName, mediaLocation.PhysicalPath + pdfFileName);
            return pdfFileName;
        }

        [RoleBasedAuthorize]
        public ActionResult PrintLipid(long eventCustomerId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var pdfFileName = PrintLipidBasicBiometric(eventCustomerId, mediaLocation);

            Response.RedirectUser(mediaLocation.Url + pdfFileName);
            return null;
        }

        private string PrintLipidBasicBiometric(long eventCustomerId, MediaLocation mediaLocation)
        {
            var guid = Guid.NewGuid().ToString();

            var pdfFileName = "Lipid_" + guid + ".pdf";
            var htmlFileName = "Lipid_" + guid + ".html";

            _generateKynLipidService.GenerateLipidResult(mediaLocation.PhysicalPath + htmlFileName, eventCustomerId);

            //_pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);
            _pdfGenerator.GeneratePdf(mediaLocation.Url + htmlFileName, mediaLocation.PhysicalPath + pdfFileName);
            return pdfFileName;
        }

        public ActionResult AbnConsent(long eventCustomerId)
        {
            var model = _customerService.GetAbnModel(eventCustomerId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult PrintAbnConsent(long eventCustomerId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = "ABN_" + eventCustomerId + ".pdf";

            var url = _settings.AppUrl + "/Medical/Results/AbnConsent?eventCustomerId=" + eventCustomerId;

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);


            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult AwvPcpConsent(long customerId, long eventId)
        {
            var model = _customerService.GetAwvPcpConsentViewModel(customerId, eventId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult PrintAwvPcpConsent(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

            var fileName = string.Format("AwvPcpConsent_{0}_{1}.pdf", customerId, eventId);

            var url = string.Format("{0}/Medical/Results/AwvPcpConsent?customerId={1}&eventId={2}", _settings.AppUrl, customerId, eventId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult MammogramHistoryForm(long customerId)
        {
            var model = _customerService.GetMammogramHistoryFormViewModel(customerId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult PrintMammogramHistoryForm(long customerId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = _settings.AppUrl + "/Medical/Results/MammogramHistoryForm?customerId=" + customerId;

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        [RoleBasedAuthorize]
        public ActionResult PrintSeasonalInfluenzaVaccinationConsentForm(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = string.Format("{0}/Medical/Results/SeasonalInfluenzaVaccinationConsentForm?customerId={1}&eventId={2}", _settings.AppUrl, customerId, eventId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult SeasonalInfluenzaVaccinationConsentForm(long customerId, long eventId)
        {
            var model = _vaccinationConsentService.GetFluVaccinationConsentViewModel(eventId, customerId);

            return View(model);
        }

        public ActionResult PrintFluPneumoniaConsent(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = string.Format("{0}/Medical/Results/FluPneumoniaConsent?customerId={1}&eventId={2}", _settings.AppUrl, customerId, eventId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult FluPneumoniaConsent(long customerId, long eventId)
        {
            var model = _vaccinationConsentService.GetFluVaccinationConsentViewModel(eventId, customerId);

            return PartialView(model);
        }

        public ActionResult StandingOrderHeader(long customerId, long eventId)
        {
            var model = _healthAssessmentService.GetStandingOrderFormHeaderEditModel(customerId, eventId);

            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult SetGeneratedRecordtoPostAudit(long eventId, long customerId)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            eventCustomerResult.IsResultPdfGenerated = false;
            eventCustomerResult.IsClinicalFormGenerated = false;
            eventCustomerResult.AcesApprovedOn = null;
            eventCustomerResult.InvoiceDateUpdatedBy = null;

            if (eventCustomerResult.ResultState == (int)NewTestResultStateNumber.ResultDelivered)
            {
                eventCustomerResult.IsRevertedToEvaluation = true;
                eventCustomerResult.IsPennedBack = false;
            }

            _eventCustomerResultRepository.Save(eventCustomerResult);

            _testResultService.SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.ArtifactSynced, false, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return Content("");
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult RevertToCoding(long eventId, long customerId)
        {
            _testResultService.SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.NpSigned, false, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return Content("");
        }

        [HttpPost]
        [RoleBasedAuthorize]
        public JsonResult ResultInvoice(ResultInvoiceEditModel resultInvoice)
        {
            try
            {
                _logger.Info("Called Method: ResultInvoice  Updating Invoice Date for Customer Id " + resultInvoice.CustomerId + " EventId " + resultInvoice.EventId);
                var orgRoleId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var result = _testResultService.UpdateInvoiceInformationDetail(resultInvoice, orgRoleId);

                _logger.Info("Called Method: ResultInvoice Updated Successfully Invoice Date for Customer Id " + resultInvoice.CustomerId + " EventId " + resultInvoice.EventId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Info("Called Method: ResultInvoice Error while updating Invoice Date for Customer Id " + resultInvoice.CustomerId + " EventId " + resultInvoice.EventId);
                _logger.Error("Ex Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            return Json(resultInvoice, JsonRequestBehavior.DenyGet);
        }

        public ActionResult PrintGiftCard(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = string.Format("{0}/Medical/Results/GiftCard?customerId={1}&eventId={2}", _settings.AppUrl, customerId, eventId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult GiftCard(long customerId, long eventId)
        {
            var model = _giftCardService.GetModel(eventId, customerId);

            return PartialView("GiftCertificateForAccount", model);
        }

        public ActionResult PrintParticipationConsent(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = string.Format("{0}/Medical/Results/ParticipationConsent?customerId={1}&eventId={2}", _settings.AppUrl, customerId, eventId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult ParticipationConsent(long customerId, long eventId)
        {
            var model = _participationConsentService.GetModel(eventId, customerId);

            return PartialView("HealthplanParticipationConsentFrom", model);
        }

        public ActionResult PrintChaperoneForm(long customerId, long eventId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = Guid.NewGuid() + ".pdf";

            var url = string.Format("{0}/Medical/Results/ChaperoneForm?eventId={1}&customerId={2}", _settings.AppUrl, eventId, customerId);

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ActionResult ChaperoneForm(long eventId, long customerId)
        {
            var model = _chaperoneService.GetModel(eventId, customerId);

            return PartialView("ChaperoneForm", model);
        }
    }
}
