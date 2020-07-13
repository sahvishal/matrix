using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using FluentValidation;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [IgnoreAudit]
    public class OnlineController : Controller
    {
        private readonly ITempCartRepository _tempCartRepository;
        private readonly IEventService _eventService;
        private readonly IEventPackageSelectorService _eventPackageSelectorService;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IUniqueItemRepository<ProspectCustomer> _prospectCustomerRepository;
        private readonly IProspectCustomerService _prospectCustomerService;
        private readonly IGiftCertificateService _giftCertificateService;

        private readonly IEligibilityService _eligibilityService;

        private readonly IAddressService _addressService;
        private readonly IStateRepository _stateRepository;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IValidator<OrderPlaceEditModel> _placeOrderValidator;
        private readonly IValidator<SchedulingCustomerEditModel> _customerEditModelValidator;
        private readonly IValidator<PaymentInstrumentEditModel> _paymentValidator;
        private readonly IValidator<PrimaryCarePhysicianEditModel> _pcpValidator;

        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IHealthAssessmentService _healthAssessmentService;

        private readonly IToolTipRepository _toolTipRepository;

        private readonly IGoogleAnalyticsReportingDataService _googleAnalyticalService;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IEventSchedulingSlotService _slotService;
        private readonly IEventSchedulingSlotRepository _slotRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPaymentController _paymentController;
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IMediaRepository _mediaRepository;
        private readonly IConfigurationSettingRepository _configRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPreQualificationResultRepository _preQualificationResultRepository;

        private readonly int _pageSize;
        private readonly int _maxApoointmentSlotstoShow;
        private readonly int _maxNumberOfEventstoFetch;
        private readonly int _cutOffhoursbeforeEventSelection;
        private readonly bool _askPreQualifierQuestionSetting;

        private const string OnlineAddress1 = "Online Address";
        private readonly string _onlineCity = "Winter Park";
        private readonly string _onlineState = "Florida";
        private readonly string _onlineZip = "32792";
        private readonly bool _enableTexting;
        public OnlineController(IEventService eventService, IEventPackageSelectorService eventPackageSelectorService, ITempCartRepository tempCartRepository, IEventSchedulerService eventSchedulerService, IGiftCertificateService giftCertificateService,
            ISettings settings, ICustomerRepository customerRepository, ICustomerService customerService, IUniqueItemRepository<ProspectCustomer> prospectCustomerRepository, IProspectCustomerService prospectCustomerService,
            IAddressService addressService, IValidator<OrderPlaceEditModel> placeOrderValidator, IValidator<SchedulingCustomerEditModel> customerEditModelValidator,
            INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory, IValidator<PaymentInstrumentEditModel> paymentValidator, IStateRepository stateRepository,
            ILogManager logManager, IHealthAssessmentService healthAssessmentService, IConfigurationSettingRepository configurationSettingRepository,
            IToolTipRepository toolTipRepository, IGoogleAnalyticsReportingDataService googleAnalyticalService, ISourceCodeRepository sourceCodeRepository,
            IEventSchedulingSlotService slotService, IEventSchedulingSlotRepository slotRepository, IEventRepository eventRepository, IPaymentController paymentController, IEventSchedulingSlotService eventSchedulingSlotService,
            IHealthAssessmentRepository healthAssessmentRepository, IPdfGenerator pdfGenerator, IMediaRepository mediaRepository, IConfigurationSettingRepository configRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IValidator<PrimaryCarePhysicianEditModel> pcpValidator, IHospitalPartnerRepository hospitalPartnerRepository, IEligibilityService eligibilityService, IChargeCardRepository chargeCardRepository,
            ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerRegistrationService customerRegistrationService, ICorporateAccountRepository corporateAccountRepository, IPreQualificationResultRepository preQualificationResultRepository)
        {
            _pageSize = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EventListPageSizeOnline));
            _maxApoointmentSlotstoShow = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.MaxNoOfAppointmentSlotsToShowOnline));
            _maxNumberOfEventstoFetch = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.MaxNoOfEventToShowOnline));
            _cutOffhoursbeforeEventSelection = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.CutOffHourNumberforOnlineEventSelection));
            _enableTexting = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
            _pageSize = _pageSize > 0 ? _pageSize : 5;
            _maxApoointmentSlotstoShow = _maxApoointmentSlotstoShow > 0 ? _maxApoointmentSlotstoShow : 12;
            _maxNumberOfEventstoFetch = _maxNumberOfEventstoFetch > 0 ? _maxNumberOfEventstoFetch : 25;
            var value = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            _askPreQualifierQuestionSetting = value.ToLower() == bool.TrueString.ToLower();

            _settings = settings;
            _googleAnalyticalService = googleAnalyticalService;
            _eventPackageSelectorService = eventPackageSelectorService;
            _eventSchedulerService = eventSchedulerService;
            _eventService = eventService;
            _tempCartRepository = tempCartRepository;
            _customerRepository = customerRepository;
            _customerService = customerService;
            _prospectCustomerRepository = prospectCustomerRepository;
            _addressService = addressService;
            _prospectCustomerService = prospectCustomerService;
            _giftCertificateService = giftCertificateService;

            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _stateRepository = stateRepository;
            _healthAssessmentService = healthAssessmentService;

            _toolTipRepository = toolTipRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _slotService = slotService;
            _slotRepository = slotRepository;
            _eventRepository = eventRepository;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _healthAssessmentRepository = healthAssessmentRepository;
            _pdfGenerator = pdfGenerator;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
            _mediaRepository = mediaRepository;
            _configRepository = configRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _eligibilityService = eligibilityService;
            _chargeCardRepository = chargeCardRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;

            _paymentController = paymentController;

            _placeOrderValidator = placeOrderValidator;
            _paymentValidator = paymentValidator;
            _customerEditModelValidator = customerEditModelValidator;
            _pcpValidator = pcpValidator;

            _logger = logManager.GetLogger<Global>();

            _onlineCity = _settings.City;
            _onlineState = _settings.State;
            _onlineZip = _settings.ZipCode;
            _customerRegistrationService = customerRegistrationService;
            _corporateAccountRepository = corporateAccountRepository;
            _preQualificationResultRepository = preQualificationResultRepository;
        }

        public ActionResult LocationAndAppointmentSlot(OnlineSchedulingEventListModelFilter filter, int SortOrderBy = (int)SortOrderBy.Distance, int pageNumber = 1, string guid = "", string cpncd = "", int v = 1)
        {


            ////var url = string.Format(_settings.ApplicatoinDomainUrl + "#/SearchEvent/{0}/{1}/{2}", filter.ZipCode, filter.Radius, SortOrderBy);
            var url = string.Format(_settings.ApplicatoinDomainUrl + "#/SearchEvent/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                string.IsNullOrWhiteSpace(filter.ZipCode) ? "null" : filter.ZipCode,
                filter.Radius.HasValue ? filter.Radius.Value.ToString() : "null",
                 SortOrderBy,
                 string.IsNullOrWhiteSpace(guid) ? "null" : guid,
                 filter.EventId,
                 (string.IsNullOrWhiteSpace(cpncd) ? "null" : cpncd),
                 (string.IsNullOrWhiteSpace(filter.InvitationCode) ? "null" : filter.InvitationCode),
                 (string.IsNullOrWhiteSpace(filter.CorpCode) ? "null" : filter.CorpCode));

            return RedirectPermanent(url);

            //var url = GetUrltoRedirectifCartisCompleteorInvalid(guid);
            //if (!string.IsNullOrEmpty(url)) return Redirect(url);

            ////filter.Radius = !string.IsNullOrEmpty(filter.InvitationCode) && !string.IsNullOrEmpty(filter.ZipCode) && !filter.Radius.HasValue ? 0 : filter.Radius;

            //var model = new OnlineSchedulingLocationAndAppointmentEditModel();

            //if (!string.IsNullOrEmpty(guid))
            //{
            //    var tempCart = _tempCartRepository.Get(guid);
            //    CheckCartForAppointment(tempCart);
            //    if (tempCart.EventId != null && tempCart.EventId.Value > 0)
            //    {
            //        model.SelectedEvent = _eventService.GetSelectedEvent(tempCart.EventId.Value);
            //    }

            //    if (model.SelectedEvent == null)
            //    {
            //        model.Events = GetModel(filter, SortOrderBy, pageNumber, guid);
            //        tempCart.EventId = null;
            //    }
            //    else
            //    {
            //        model.Events = new OnlineSchedulingEventListModel
            //                           {
            //                               Filter = CompleteFilter(tempCart, filter),
            //                               SortOrderBy = SortOrderBy
            //                           };
            //        model.SelectedEvent.PreliminarySelectedTime = tempCart.PreliminarySelectedTime;
            //    }

            //    UpdateTempCartExitPage(guid, tempCart);
            //    model.ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart);
            //}
            //else
            //{
            //    model.Events = GetModel(filter, SortOrderBy, pageNumber, guid);
            //    model.CouponCode = cpncd;
            //    model.Version = v;
            //    if (string.IsNullOrWhiteSpace(filter.InvitationCode)) return View(model);

            //    var theEvent = _eventRepository.GetEventByInvitationCode(filter.InvitationCode);
            //    if (theEvent == null) return View(model);

            //    var account = _corporateAccountRepository.GetbyEventId(theEvent.Id);
            //    if (account != null && account.CheckoutPhoneNumber != null && !string.IsNullOrWhiteSpace(account.CheckoutPhoneNumber.DomesticPhoneNumber))
            //    {
            //        model.ProcessAndCartViewModel.CheckoutPhoneNumber = account.CheckoutPhoneNumber.FormatPhoneNumber;
            //    }
            //}

            //return View(model);
        }

        public ActionResult AvailableLocations(OnlineSchedulingEventListModelFilter filter, int SortOrderBy = (int)SortOrderBy.Distance, int pageNumber = 1, string guid = "")
        {
            return PartialView(GetModel(filter, SortOrderBy, pageNumber, guid));
        }

        public ActionResult SelectedLocation(long eventId)
        {
            return PartialView(_eventService.GetSelectedEvent(eventId));
        }

        private static OnlineSchedulingEventListModelFilter CompleteFilter(TempCart tempCart, OnlineSchedulingEventListModelFilter filter)
        {
            if (tempCart == null) return filter;
            if (filter == null) filter = new OnlineSchedulingEventListModelFilter();


            filter.ZipCode = !string.IsNullOrEmpty(filter.ZipCode) ? filter.ZipCode : tempCart.ZipCode;
            filter.Radius = tempCart.Radius.HasValue ? (int)tempCart.Radius.Value : 0;
            filter.EventId = tempCart.EventId.HasValue ? tempCart.EventId.Value : 0;
            filter.InvitationCode = !string.IsNullOrEmpty(filter.InvitationCode) ? filter.InvitationCode : tempCart.InvitationCode;

            return filter;
        }

        private OnlineSchedulingEventListModel GetModel(OnlineSchedulingEventListModelFilter filter, int SortOrderBy = (int)SortOrderBy.Distance, int pageNumber = 1, string guid = "")
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new OnlineSchedulingEventListModelFilter();

            if (!string.IsNullOrEmpty(guid))
            {
                var tempCart = _tempCartRepository.Get(guid);
                filter = CompleteFilter(tempCart, filter);
            }

            filter.CutOffHourstoMarkEventforOnlineSelection = _cutOffhoursbeforeEventSelection;
            OnlineSchedulingEventListModel model = null;
            if (!string.IsNullOrEmpty(filter.ZipCode) || !string.IsNullOrEmpty(filter.InvitationCode))
            {
                model = _eventService.GetOnlineSchedulingEventCollection(filter, (SortOrderBy)SortOrderBy, SortOrderType.Ascending, _maxNumberOfEventstoFetch, pageNumber, _pageSize, out totalRecords);
            }

            if (model == null) model = new OnlineSchedulingEventListModel();

            model.Filter = filter;

            const string currentAction = "AvailableLocations";
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.ZipCode, filter.InvitationCode, filter.DateFrom, filter.DateTo, filter.Radius, SortOrderBy, guid });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            model.SortOrderBy = SortOrderBy;
            return model;
        }


        [HttpPost]
        public ActionResult SaveTempCartforSelectLocation(string guid, long eventId, string zipCode, string invitationCode, string corpCode, decimal? radius, string couponCode, int v = 1)
        {
            long sourceCodeId = 0;
            if (!string.IsNullOrEmpty(couponCode))
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeByCode(couponCode);
                if (sourceCode != null)
                    sourceCodeId = sourceCode.Id;
            }

            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart == null)
            {
                tempCart = new TempCart
                {
                    ZipCode = zipCode,
                    EventId = eventId,
                    InvitationCode = invitationCode,
                    CorpCode = corpCode,
                    Radius = radius,
                    Guid = guid,
                    EntryPage = Request.UrlReferrer.PathAndQuery,
                    ExitPage = Request.UrlReferrer.PathAndQuery,
                    SourceCodeId = sourceCodeId > 0 ? (long?)sourceCodeId : null,
                    Version = v
                };
            }
            else
            {
                tempCart.ZipCode = string.IsNullOrEmpty(zipCode) ? tempCart.ZipCode : zipCode;
                tempCart.Radius = radius.HasValue ? radius : tempCart.Radius;
                tempCart.EventId = eventId;
                tempCart.ExitPage = Request.UrlReferrer.PathAndQuery;
                tempCart.EventPackageId = null;
                tempCart.TestId = null;
                tempCart.ShippingId = null;
                tempCart.ProductId = null;
                tempCart.PreliminarySelectedTime = null;

                if (tempCart.AppointmentId.HasValue)
                {
                    UpdateCartAndReleaseSlot(guid);
                }
            }

            SaveTempCart(tempCart);
            return Json(new { Result = true, CartGuid = guid });
        }

        [HttpPost]
        public ActionResult LocationAndAppointmentSlot(OnlineSchedulingLocationAndAppointmentEditModel model, OnlineSchedulingProcessAndCartViewModel cartModel)
        {
            if (!string.IsNullOrEmpty(cartModel.CartGuid))
            {
                try
                {
                    var isComplete = CheckifCartisComplete(cartModel.CartGuid);
                    if (isComplete)
                    {
                        Response.RedirectUser("/Scheduling/Online/ThankYou?guid=" + cartModel.CartGuid);
                        return null;
                    }
                }
                catch (NullReferenceException)
                {
                    model.Events = GetModel(model.Events.Filter, model.Events.SortOrderBy);
                    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Please select an Event to continue!");
                    return View(model);
                }
                catch
                {
                    Response.RedirectUser(_settings.SiteUrl);
                    return null;
                }
            }

            if (!ModelState.IsValid)
            {
                var tempCart = _tempCartRepository.Get(cartModel.CartGuid);
                if (tempCart != null)
                {
                    model.ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart);
                    model.Events = GetModel(model.Events.Filter, model.Events.SortOrderBy, 1, cartModel.CartGuid);
                    if (tempCart.EventId != null && tempCart.EventId.Value > 0)
                    {
                        model.SelectedEvent = _eventService.GetSelectedEvent(tempCart.EventId.Value);
                    }
                }
                else
                {
                    model.Events = GetModel(model.Events.Filter, model.Events.SortOrderBy, 1, "");
                }

                if (tempCart == null || !tempCart.EventId.HasValue)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Please select an Event to continue!");
                }

                return View(model);
            }
            else
            {
                var tempCart = _tempCartRepository.Get(cartModel.CartGuid);
                tempCart.ScreenResolution = cartModel.ScreenResolution;
                _tempCartRepository.Save(tempCart);
            }
            Response.RedirectUser("/Scheduling/Online/Package?guid=" + cartModel.CartGuid);
            return null;
        }

        public ActionResult Package(string guid)
        {
            var url = GetUrltoRedirectifCartisCompleteorInvalid(guid);
            if (!string.IsNullOrEmpty(url))
            {
                Response.RedirectUser(url);
                return null;
            }

            var tempCart = _tempCartRepository.Get(guid);
            var preQualificationResult = _preQualificationResultRepository.Get(tempCart.Id);

            if (tempCart == null || tempCart.EventId == null)
            {
                Response.RedirectUser(_settings.SiteUrl);
                return null;
            }

            if (preQualificationResult == null)
            {
                preQualificationResult = new PreQualificationResult();
            }

            CheckCartForAppointment(tempCart);

            UpdateTempCartExitPage(guid, tempCart);

            long eventId = tempCart.EventId.Value;
            var theEvent = _eventRepository.GetById(eventId);

            var model = new OnlineSchedulingSelectPackageEditModel
            {
                PackageSelectionEditModel = _eventPackageSelectorService.GetEventPackage(tempCart, eventId, Roles.Customer),
                ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                //EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart),
                SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart),
                Appointments = _eventSchedulerService.GetAppointmentmentSelectionEditModel(tempCart),
                PackageSelectionInfo = _eventSchedulerService.GetPackageSelectionInfoEditModel(tempCart, preQualificationResult),
                PackageSelectionVersion = tempCart.Version,
                AgreedWithPrequalificationQuestion = preQualificationResult.AgreedWithPrequalificationQuestion,
                SkipPreQualificationQuestion = preQualificationResult.SkipPreQualificationQuestion,
                AskPreQualificationQuestion = _askPreQualifierQuestionSetting && theEvent.AskPreQualifierQuestion
            };

            model.PackageSelectionInfo.ShowPreQualifiedQuestion = theEvent.AskPreQualifierQuestion;

            model.IsDynamicScheduling = theEvent.IsDynamicScheduling;
            model.PreliminarySelectedTime = tempCart.PreliminarySelectedTime;
            model.HasPackages = model.PackageSelectionEditModel.AllEventPackages != null && model.PackageSelectionEditModel.AllEventPackages.Any();

            var packageSelectionInfo = Convert.ToBoolean(_configRepository.GetConfigurationValue(ConfigurationSettingName.PackageSelectionInfo));

            model.RecommendPackage = packageSelectionInfo && theEvent.RecommendPackage;

            if (model.RecommendPackage || model.AskPreQualificationQuestion)
            {
                SetPackage(model, tempCart, preQualificationResult);
            }

            //SetPackage(model, tempCart);

            model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart);

            if (model.PackageSelectionEditModel.SelectedPackageId > 0)
            {
                var package = model.PackageSelectionEditModel.AllEventPackages.Where(ep => ep.EventPackageId == model.PackageSelectionEditModel.SelectedPackageId && ep.NotAvailable).Select(ep => ep).SingleOrDefault();

                if (package != null)
                {
                    model.PackageSelectionEditModel.SelectedPackageId = 0;
                    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Package you have selected earlier " + package.NotAvailabilityMessage);
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Package(OrderPlaceEditModel orderPlaceModel, OnlineSchedulingProcessAndCartViewModel cartModel, AppointmentSelectionEditModel appointmentModel)
        {
            var url = GetUrltoRedirectifCartisCompleteorInvalid(cartModel.CartGuid);
            if (!string.IsNullOrEmpty(url))
            {
                Response.RedirectUser(url);
                return null;
            }

            var tempCart = _tempCartRepository.Get(cartModel.CartGuid);
            var preQualificationResult = _preQualificationResultRepository.Get(tempCart.Id);
            if (preQualificationResult == null)
            {
                preQualificationResult = new PreQualificationResult();
            }
            tempCart.ScreenResolution = cartModel.ScreenResolution;


            //if (tempCart.EventId.HasValue && appointmentModel != null && !appointmentModel.SelectedAppointmentIds.IsNullOrEmpty() && tempCart.AppointmentId.HasValue)
            //{
            //    var screeningTime = _eventPackageSelectorService.GetScreeningTime(orderPlaceModel.SelectedPackageId, orderPlaceModel.SelectedTestIds);
            //    var slots = _slotService.AdjustAppointmentSlot(tempCart.EventId.Value, screeningTime, appointmentModel.SelectedAppointmentIds);

            //    if (slots == null)
            //    {
            //        tempCart.AppointmentId = null;
            //        tempCart.InChainAppointmentSlots = string.Empty;
            //        _tempCartRepository.Save(tempCart);
            //        appointmentModel.SelectedAppointmentIds = null;
            //    }
            //    else
            //    {
            //        var slotIds = slots.Select(s => s.Id);
            //        tempCart.InChainAppointmentSlots = string.Join(",", slotIds);
            //        _tempCartRepository.Save(tempCart);
            //        appointmentModel.SelectedAppointmentIds = slotIds;
            //    }
            //}

            var validationResult = _placeOrderValidator.Validate(orderPlaceModel);
            if (!validationResult.IsValid || (appointmentModel == null || appointmentModel.SelectedAppointmentIds.IsNullOrEmpty() || !tempCart.AppointmentId.HasValue))
            {
                var model = new OnlineSchedulingSelectPackageEditModel
                {
                    PackageSelectionEditModel = _eventPackageSelectorService.GetEventPackage(orderPlaceModel, tempCart.EventId.Value, Roles.Customer, (tempCart.CustomerId.HasValue ? tempCart.CustomerId.Value : 0), tempCart),
                    ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                    FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(!validationResult.IsValid ? validationResult.Errors.First().ErrorMessage : "Please select Appointment.")
                };
                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                model.IsDynamicScheduling = theEvent.IsDynamicScheduling;
                model.Appointments = _eventSchedulerService.GetAppointmentmentSelectionEditModel(tempCart);
                model.SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart);
                model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart, model.SourceCodeApplyEditModel);
                model.PackageSelectionInfo = _eventSchedulerService.GetPackageSelectionInfoEditModel(tempCart, preQualificationResult);
                model.PackageSelectionVersion = tempCart.Version;

                var packageSelectionInfo = Convert.ToBoolean(_configRepository.GetConfigurationValue(ConfigurationSettingName.PackageSelectionInfo));
                model.RecommendPackage = packageSelectionInfo && theEvent.RecommendPackage;

                return View(model);
            }

            tempCart.EventPackageId = orderPlaceModel.SelectedPackageId > 0 ? (long?)orderPlaceModel.SelectedPackageId : null;
            tempCart.TestId = orderPlaceModel.SelectedTestIds != null ? string.Join(",", orderPlaceModel.SelectedTestIds) : string.Empty;
            tempCart.InChainAppointmentSlots = string.Join(",", appointmentModel.SelectedAppointmentIds);

            tempCart.ProductId = orderPlaceModel.SelectedProductIds != null ? string.Join(",", orderPlaceModel.SelectedProductIds) : string.Empty;
            //tempCart.ShippingId = orderPlaceModel.SelectedShippingOptionId == 0 ? null : (long?)orderPlaceModel.SelectedShippingOptionId;
            tempCart.ShippingId = orderPlaceModel.SelectedShippingOptionId < 0 ? null : (long?)orderPlaceModel.SelectedShippingOptionId;


            SaveTempCart(tempCart);
            Response.RedirectUser("/Scheduling/Online/Info?guid=" + cartModel.CartGuid);
            return null;
        }

        public ActionResult Info(string guid)
        {
            var url = GetUrltoRedirectifCartisCompleteorInvalid(guid);
            if (!string.IsNullOrEmpty(url))
            {
                Response.RedirectUser(url);
                return null;
            }

            var tempCart = _tempCartRepository.Get(guid);
            CheckCartForAppointment(tempCart);
            UpdateTempCartExitPage(guid, tempCart);

            var model = new OnlineSchedulingCustomerInfoEditModel
                            {
                                ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                                EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(guid),
                                CustomerEditModel = new SchedulingCustomerEditModel { EnableTexting = _enableTexting },
                                SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart),
                                RequestForNewsLetterDescription = _toolTipRepository.GetToolTipContentByTag(ToolTipType.OnlineNewsletterDescription)
                            };


            var customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;
            if (customer == null && tempCart.ProspectCustomerId.HasValue && tempCart.ProspectCustomerId.Value > 0)
            {
                model.CustomerEditModel = _prospectCustomerService.GetforProspectCustomerId(tempCart.ProspectCustomerId.Value);
            }
            else if (customer != null)
            {
                model.CustomerEditModel = Mapper.Map<Customer, SchedulingCustomerEditModel>(customer);
                model.CustomerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.Address);
                model.CustomerEditModel.ConfirmationToEnablTexting = customer.EnableTexting;

                //model.CustomerEditModel.ShippingAddress.Id = tempCart.ShippingAddressId.HasValue ? tempCart.ShippingAddressId.Value : 0;
            }
            model.CustomerEditModel.EnableTexting = _enableTexting;
            model.CustomerEditModel.MarketingSource = tempCart.MarketingSource;
            if (tempCart.Dob.HasValue && !model.CustomerEditModel.DateofBirth.HasValue)
                model.CustomerEditModel.DateofBirth = tempCart.Dob.Value;

            if (!string.IsNullOrEmpty(tempCart.Gender) && !(model.CustomerEditModel.Gender.HasValue && model.CustomerEditModel.Gender.Value > 0))
                model.CustomerEditModel.Gender = (int)((Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true));

            //payment
            if (model.PaymentEditModel == null)
            {
                model.PaymentEditModel = new PaymentEditModel
                {
                    PaymentFlow = PaymentFlow.In,
                    Amount = model.EventCustomerOrderSummaryModel.AmountDue.HasValue ? model.EventCustomerOrderSummaryModel.AmountDue.Value : 0,
                    ShippingAddressSameAsBillingAddress = true
                };
            }


            if (customer != null && ((customer.BillingAddress != null && customer.BillingAddress.StreetAddressLine1 != OnlineAddress1) || (customer.Address != null && customer.Address.StreetAddressLine1 != OnlineAddress1)))
            {
                model.PaymentEditModel.ExistingBillingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
                model.PaymentEditModel.ExistingBillingAddress.Id = customer.BillingAddress != null ? customer.BillingAddress.Id : 0;

                model.PaymentEditModel.ExistingShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
                model.PaymentEditModel.ExistingShippingAddress.Id = customer.Address != null ? customer.Address.Id : 0;
            }


            model.RequestForNewsLetter = model.EventCustomerOrderSummaryModel != null && model.EventCustomerOrderSummaryModel.EventType == EventType.Retail;

            model.PaymentEditModel.AllowedPaymentTypes = new[] {
                                             new OrderedPair<long, string>(PaymentType.CreditCard.PersistenceLayerId, PaymentType.CreditCard.Name),
                                             new OrderedPair<long, string>(PaymentType.ElectronicCheck.PersistenceLayerId, PaymentType.ElectronicCheck.Name),
                                             new OrderedPair<long, string>(PaymentType.GiftCertificate.PersistenceLayerId, PaymentType.GiftCertificate.Name)
                                         };

            var payLaterOnlineRegistration = Convert.ToBoolean(IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.PayLaterOnlineRegistration));
            if (payLaterOnlineRegistration)
            {
                var payLaterOption = new[] { new OrderedPair<long, string>(PaymentType.Onsite_Value, PaymentType.PayLater_Text) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(payLaterOption);

            }

            var eventId = model.EventCustomerOrderSummaryModel.EventId.HasValue ? model.EventCustomerOrderSummaryModel.EventId.Value : 0;
            var packageId = model.SourceCodeApplyEditModel.Package != null ? model.SourceCodeApplyEditModel.Package.FirstValue : 0;
            var addOnTestIds = model.SourceCodeApplyEditModel.SelectedTests != null ? model.SourceCodeApplyEditModel.SelectedTests.Select(st => st.FirstValue).ToArray() : null;

            var testCoveredByInsurance = _eligibilityService.CheckTestCoveredByinsurance(eventId, packageId, addOnTestIds);
            if (testCoveredByInsurance)
            {
                var insurancePaymentOption = new[] { new OrderedPair<long, string>(PaymentType.Insurance.PersistenceLayerId, PaymentType.Insurance.Name) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(insurancePaymentOption);
            }

            if (model.EventCustomerOrderSummaryModel.AmountDue != null && model.EventCustomerOrderSummaryModel.AmountDue > 0)
            {
                if (payLaterOnlineRegistration)
                {
                    model.PaymentEditModel.Payments = new[]
                                                          {
                                                              new PaymentInstrumentEditModel
                                                                  {
                                                                      Amount = model.EventCustomerOrderSummaryModel.AmountDue.Value,
                                                                      PaymentType = Convert.ToInt32(PaymentType.Onsite_Value)
                                                                  }
                                                          };
                }
                else
                {

                    model.PaymentEditModel.Payments = new[]
                                                          {
                                                              new PaymentInstrumentEditModel
                                                                  {
                                                                      Amount = model.EventCustomerOrderSummaryModel.AmountDue.Value,
                                                                      ChargeCard = new ChargeCardPaymentEditModel()
                                                                      {
                                                                          ChargeCard = (tempCart.ChargeCardId.HasValue && tempCart.ChargeCardId.Value > 0)
                                                                          ?_chargeCardRepository.GetById(tempCart.ChargeCardId.Value)
                                                                          :new ChargeCard()
                                                                      }
                                                                  }
                                                          };


                    if (testCoveredByInsurance && tempCart.EligibilityId.HasValue && tempCart.EligibilityId.Value > 0 && tempCart.ChargeCardId.HasValue && tempCart.ChargeCardId.Value > 0)
                    {
                        var insurancePayment = new[]
                        {
                            new PaymentInstrumentEditModel
                            {
                                Insurance = new InsurancePaymentEditModel
                                {
                                    EligibilityId = tempCart.EligibilityId.Value,
                                    ChargeCardId = tempCart.ChargeCardId.Value
                                }
                            }
                        };
                        model.PaymentEditModel.Payments = model.PaymentEditModel.Payments.Concat(insurancePayment);
                    }
                }
            }
            else
            {
                model.PaymentEditModel.ShippingAddressSameAsBillingAddress = false;
            }
            if (tempCart.EventId.HasValue && tempCart.EventId.Value > 0)
            {
                var eventData = _eventRepository.GetById(tempCart.EventId.Value);

                if (eventData.AccountId.HasValue && eventData.AccountId.Value > 0)
                {
                    var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);
                    model.CustomerEditModel.InsuranceIdLabel = (account != null && !string.IsNullOrEmpty(account.MemberIdLabel)) ? account.MemberIdLabel : string.Empty;
                }

                model.CustomerEditModel.InsuranceIdRequired = eventData.InsuranceIdRequired;
                var eventHospitalPartner = _hospitalPartnerRepository.GetEventHospitalPartnersByEventId(tempCart.EventId.Value);
                if (eventHospitalPartner != null)
                    model.CustomerEditModel.CaptureSsn = eventHospitalPartner.CaptureSsn;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Info(OnlineSchedulingCustomerInfoEditModel model, SchedulingCustomerEditModel customerEditModel, OnlineSchedulingProcessAndCartViewModel cartModel, SourceCodeApplyEditModel sourceCodeModel, PaymentEditModel paymentModel)
        {
            if (!string.IsNullOrEmpty(customerEditModel.HomeNumber))// To eliminate masking
                customerEditModel.HomeNumber = customerEditModel.HomeNumber.Replace("-", "").Replace("(", "").Replace(")", "");

            var tempCart = _tempCartRepository.Get(cartModel.CartGuid);

            tempCart.MarketingSource = customerEditModel.MarketingSource;

            var validationResult = _customerEditModelValidator.Validate(customerEditModel);
            if (!validationResult.IsValid)
            {
                return View(GetInfoModel("Customer Data is not valid!", model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
            }

            if (tempCart.EventId.HasValue)
            {
                //var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(tempCart.EventId.Value, (long)Roles.Customer);
                //var eventTests = _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer);
                //var hasAgeLimitation = false;

                //if (eventPackages != null && eventPackages.Count() > 0)
                //{
                //    foreach (var eventPackage in eventPackages)
                //    {
                //        hasAgeLimitation = eventPackage.Tests.Where(t => ((t.Test.MinAge.HasValue && t.Test.MinAge.Value > 0) || (t.Test.MaxAge.HasValue && t.Test.MaxAge.Value > 0))).Any();
                //        if (hasAgeLimitation)
                //            break;
                //    }
                //}

                if (!customerEditModel.DateofBirth.HasValue)
                    return View(GetInfoModel("Please enter Date of Birth!", model, tempCart, customerEditModel, sourceCodeModel, paymentModel));

                if (customerEditModel.DateofBirth.Value.GetAge() < _settings.MinimumAgeForScreening)
                    return View(GetInfoModel(string.Format("Customers below {0} years of age are not allowed for screening.In case of any queries, please call us at {1}", _settings.MinimumAgeForScreening, _settings.PhoneTollFree), model, tempCart, customerEditModel, sourceCodeModel, paymentModel));

                //if (!hasAgeLimitation && eventTests != null && eventTests.Count() > 0)
                //{
                //    hasAgeLimitation = eventTests.Where(t => ((t.Test.MinAge.HasValue && t.Test.MinAge.Value > 0) || (t.Test.MaxAge.HasValue && t.Test.MaxAge.Value > 0))).Any();
                //}

                //if (hasAgeLimitation && !customerEditModel.DateofBirth.HasValue)
                //    return View(GetInfoModel("Please enter Date of Birth!", model, tempCart, customerEditModel, sourceCodeModel, paymentModel));

                //payment
                var summarymodel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart);

                var couponAmount = sourceCodeModel != null ? sourceCodeModel.DiscountApplied : 0;
                if ((summarymodel.TotalPrice != null && summarymodel.TotalPrice.Value != (paymentModel.Amount + couponAmount)) || (summarymodel.TotalPrice == null && paymentModel.Amount > 0))
                {
                    return View(GetInfoModel("Seems like you changed your order. Please go back to the Package screen, and confirm!", model, tempCart, customerEditModel, sourceCodeModel, paymentModel, true));
                }

                var result = ValidatePaymentModel(paymentModel);
                if (!result)
                {
                    return View(GetInfoModel("Payment error - Please re-enter your payment information or contact our customer care line at " + _settings.PhoneTollFree, model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
                }

                var isAppointmentBooked = _slotService.IsSlotBooked(tempCart.InChainAppointmentSlotIds);
                if (isAppointmentBooked)
                    return View(GetInfoModel("The appointment slot selected by you seems to have exhausted. Please re-select another slot!", model, tempCart, customerEditModel, sourceCodeModel, paymentModel));

                var doesEventCustomerAlreadyExists = tempCart.CustomerId.HasValue ? _eventSchedulerService.DoesEventCustomerAlreadyExists(tempCart.CustomerId.Value, tempCart.EventId.Value) : null;

                if (doesEventCustomerAlreadyExists != null && doesEventCustomerAlreadyExists.FirstValue)
                {
                    return View(GetInfoModel(doesEventCustomerAlreadyExists.SecondValue, model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
                }
            }
            bool? paymentSucceded = null;
            Customer customer;

            try
            {
                using (var scope = new TransactionScope())
                {
                    customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;

                    var address = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);

                    address = _addressService.SaveAfterSanitizing(address, true);

                    var customerAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);
                    customerAddress = _addressService.SaveAfterSanitizing(customerAddress, true);

                    customerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customerAddress);
                    customer = _customerService.SaveCustomer(customerEditModel, tempCart.IsExistingCustomer);

                    if (customer == null)
                    {
                        return View(GetInfoModel("System Failure! Data not saved. Please try again.", model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
                    }

                    customer.RequestForNewsLetter = model.RequestForNewsLetter;

                    if (paymentModel.Payments != null && paymentModel.Payments.Where(p => p.PaymentType != PaymentType.Onsite_Value && p.PaymentType != PaymentType.GiftCertificate.PersistenceLayerId).Count() > 0)
                    {
                        if (paymentModel.ExistingBillingAddress != null)
                        {
                            if (customer.BillingAddress != null && customer.BillingAddress.Id > 0)
                                paymentModel.ExistingBillingAddress.Id = customer.BillingAddress.Id;

                            var billingAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingBillingAddress);
                            billingAddress = _addressService.SaveAfterSanitizing(billingAddress, true);

                            customer.BillingAddress = billingAddress;
                        }
                    }
                    else
                    {
                        var billingAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);
                        billingAddress = _addressService.SaveAfterSanitizing(billingAddress, true);

                        customer.BillingAddress = billingAddress;
                    }

                    _customerService.SaveCustomer(customer, customer.CustomerId);

                    tempCart.SourceCodeId = sourceCodeModel == null || sourceCodeModel.SourceCodeId < 1
                                                ? null
                                                : (long?)sourceCodeModel.SourceCodeId;

                    tempCart.CustomerId = customer.CustomerId;
                    tempCart.ShippingAddressId = address.Id;
                    tempCart.ScreenResolution = cartModel.ScreenResolution;

                    if (tempCart.ProspectCustomerId.HasValue)
                    {
                        var prospectCustomer = _prospectCustomerRepository.GetById(tempCart.ProspectCustomerId.Value);
                        prospectCustomer.CustomerId = customer.CustomerId;
                        prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                        prospectCustomer.IsConverted = true;
                        prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                        prospectCustomer.ConvertedOnDate = DateTime.Now;
                        prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                        prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                        prospectCustomer.Address.City = customer.Address.City;
                        prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                        prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                        prospectCustomer.TagUpdateDate = DateTime.Now;

                        _prospectCustomerRepository.Save(prospectCustomer);
                    }
                    else
                    {
                        var prospectCustomer = ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomerByCustomerId(customer.CustomerId);
                        if (prospectCustomer != null)
                        {
                            prospectCustomer.CustomerId = customer.CustomerId;
                            prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                            prospectCustomer.IsConverted = true;
                            prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                            prospectCustomer.ConvertedOnDate = DateTime.Now;
                            prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                            prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                            prospectCustomer.Address.City = customer.Address.City;
                            prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                            prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                            prospectCustomer.TagUpdateDate = DateTime.Now;

                            _prospectCustomerRepository.Save(prospectCustomer);
                        }
                    }

                    if (paymentModel.Payments != null)
                    {
                        tempCart.PaymentMode = "";

                        if (paymentModel.Payments.Any(p => p.ChargeCard != null))
                            tempCart.PaymentMode += PaymentType.CreditCard.Name + ",";

                        if (paymentModel.Payments.Where(p => p.ECheck != null).Count() > 0)
                            tempCart.PaymentMode += PaymentType.ElectronicCheck.Name + ",";

                        if (paymentModel.Payments.Where(p => p.GiftCertificate != null).Count() > 0)
                            tempCart.PaymentMode += PaymentType.GiftCertificate.Name + ",";

                        if (paymentModel.Payments.Where(p => p.PaymentType == (int)PaymentType.Onsite_Value).Count() > 0)
                            tempCart.PaymentMode += PaymentType.PayLater_Text + ",";

                        tempCart.PaymentMode = tempCart.PaymentMode.Substring(0, tempCart.PaymentMode.LastIndexOf(","));
                    }

                    tempCart.PaymentAmount = paymentModel.Amount;
                    try
                    {
                        _eventSchedulerService.CreateOrder(tempCart, paymentModel);
                        paymentSucceded = true;
                    }
                    catch (Exception ex)
                    {
                        _paymentController.VoidCreditCardGatewayRequests(paymentModel);
                        paymentSucceded = false;
                        _logger.Error("\nOnline Payment. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                        throw;
                    }

                    tempCart.IsPaymentSuccessful = true;
                    tempCart.IsCompleted = true;
                    SaveTempCart(tempCart);

                    scope.Complete();
                }

                try
                {

                    var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);

                    if (account == null || account.SendWelcomeEmail)
                    {
                        var welcomeEmailViewModel = _emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(customer.UserLogin.UserName, customer.Name.FullName, customer.DateCreated);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, customer.Id, customer.CustomerId, Request.Url.AbsolutePath);

                        //var welcomePasswordViewModel = _emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(customer.Name.FullName, customer.UserLogin.Password);
                        //_notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithPassword, EmailTemplateAlias.CustomerWelcomeEmailWithPassword, welcomePasswordViewModel, customer.Id, customer.CustomerId, Request.Url.AbsolutePath);
                    }


                    var eventData = _eventRepository.GetById(tempCart.EventId.Value);

                    _customerRegistrationService.SendAppointmentConfirmationMail(customer, eventData, customer.CustomerId, Request.Url.AbsolutePath, account);

                    //If somebody registered within 24 hours of the event Date then send notification.
                    if (eventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
                    {
                        var appointmentBookedInTwentyFourHoursNotificationModel = _emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(tempCart.EventId.Value, tempCart.CustomerId.Value);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, customer.CustomerId, Request.Url.AbsolutePath);
                    }

                    _callQueueCustomerRepository.UpdateOtherCustomerStatus(customer.CustomerId, tempCart.ProspectCustomerId.HasValue ? tempCart.ProspectCustomerId.Value : 0, CallQueueStatus.Completed, customer.CustomerId);

                    _eventSchedulingSlotService.SendEventFillingNotification(tempCart.EventId.Value, customer.CustomerId);

                }
                catch (Exception ex)
                {
                    _logger.Error("\nOnline Payment. Exception caused while sending notification. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                    Response.RedirectUser("/Scheduling/Online/ThankYou?guid=" + cartModel.CartGuid);
                    return null;
                }
            }
            catch (InvalidAddressException ex)
            {
                _logger.Error("\nCustomer Info (ONLINE). Address Validation Failure! Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                return View(GetInfoModel("Address provided by you is not a valid address. " + ex.Message, model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
            }
            catch (Exception ex)
            {
                if (paymentSucceded != null && paymentSucceded == false)
                {
                    tempCart.IsPaymentSuccessful = false;
                    tempCart.IsCompleted = false;
                    tempCart.PaymentMode = "";
                    tempCart.SourceCodeId = 0;
                    tempCart.CustomerId = null;
                    tempCart.ShippingAddressId = null;
                    SaveTempCart(tempCart);
                    return View(GetInfoModel("OOPS! Payment could not be settled. Please try again or Call our Care Agent at " + _settings.PhoneTollFree, model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
                }

                _logger.Error("\nOnline Payment. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                return View(GetInfoModel("OOPS! Some error while generating the Order. Please try again or Call our Care Agent at " + _settings.PhoneTollFree, model, tempCart, customerEditModel, sourceCodeModel, paymentModel));
            }
            Response.RedirectUser("/Scheduling/Online/ThankYou?guid=" + cartModel.CartGuid);
            return null;
        }

        private OnlineSchedulingCustomerInfoEditModel GetInfoModel(string message, OnlineSchedulingCustomerInfoEditModel model, TempCart tempCart, SchedulingCustomerEditModel customerEditModel, SourceCodeApplyEditModel sourceCodeModel, PaymentEditModel paymentModel, bool renewPaymentModel = false)
        {
            if (model == null)
            {
                model = new OnlineSchedulingCustomerInfoEditModel
                                {
                                    ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                                    EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart, sourceCodeModel),
                                    CustomerEditModel = customerEditModel,
                                    FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(message),
                                    SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart, sourceCodeModel),
                                    PaymentEditModel = paymentModel,
                                    RequestForNewsLetterDescription = _toolTipRepository.GetToolTipContentByTag(ToolTipType.OnlineNewsletterDescription)
                                };
            }
            else
            {
                model.ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart);
                model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart, sourceCodeModel);
                model.CustomerEditModel = customerEditModel;
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(message);
                model.SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart, sourceCodeModel);
                model.PaymentEditModel = paymentModel;
                model.RequestForNewsLetterDescription = _toolTipRepository.GetToolTipContentByTag(ToolTipType.OnlineNewsletterDescription);
            }

            model.PaymentEditModel.AllowedPaymentTypes = new[] {
                                             new OrderedPair<long, string>(PaymentType.CreditCard.PersistenceLayerId, PaymentType.CreditCard.Name),
                                             new OrderedPair<long, string>(PaymentType.ElectronicCheck.PersistenceLayerId, PaymentType.ElectronicCheck.Name),
                                             new OrderedPair<long, string>(PaymentType.GiftCertificate.PersistenceLayerId, PaymentType.GiftCertificate.Name)
                                         };


            var payLaterOnlineRegistration = Convert.ToBoolean(IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.PayLaterOnlineRegistration));
            if (payLaterOnlineRegistration)
            {
                var payLaterOption = new[] { new OrderedPair<long, string>(PaymentType.Onsite_Value, PaymentType.PayLater_Text) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(payLaterOption);

            }

            var eventId = model.EventCustomerOrderSummaryModel.EventId.HasValue ? model.EventCustomerOrderSummaryModel.EventId.Value : 0;
            var packageId = model.SourceCodeApplyEditModel.Package != null ? model.SourceCodeApplyEditModel.Package.FirstValue : 0;
            var addOnTestIds = model.SourceCodeApplyEditModel.SelectedTests != null ? model.SourceCodeApplyEditModel.SelectedTests.Select(st => st.FirstValue).ToArray() : null;

            var testCoveredByInsurance = _eligibilityService.CheckTestCoveredByinsurance(eventId, packageId, addOnTestIds);
            if (testCoveredByInsurance)
            {
                var insurancePaymentOption = new[] { new OrderedPair<long, string>(PaymentType.Insurance.PersistenceLayerId, PaymentType.Insurance.Name) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(insurancePaymentOption);
            }

            model.PaymentEditModel.IsModeMultiple = false;

            if (renewPaymentModel)
            {
                if (payLaterOnlineRegistration)
                    model.PaymentEditModel.Payments = new[]
                    {
                        new PaymentInstrumentEditModel {PaymentType = Convert.ToInt32(PaymentType.Onsite_Value)}
                    };
                else
                {
                    model.PaymentEditModel.Payments = new[]
                    {
                        new PaymentInstrumentEditModel {ChargeCard = new ChargeCardPaymentEditModel()}
                    };
                    if (testCoveredByInsurance && tempCart.EligibilityId.HasValue && tempCart.EligibilityId.Value > 0 && tempCart.ChargeCardId.HasValue && tempCart.ChargeCardId.Value > 0)
                    {
                        var insurancePayment = new[]
                        {
                            new PaymentInstrumentEditModel
                            {
                                Insurance = new InsurancePaymentEditModel
                                {
                                    EligibilityId = tempCart.EligibilityId.Value,
                                    ChargeCardId = tempCart.ChargeCardId.Value
                                }
                            }
                        };
                        model.PaymentEditModel.Payments = model.PaymentEditModel.Payments.Concat(insurancePayment);
                    }
                }
                model.PaymentEditModel.Amount = model.EventCustomerOrderSummaryModel.AmountDue.HasValue
                                                    ? model.EventCustomerOrderSummaryModel.AmountDue.Value
                                                    : 0;
            }
            model.PaymentEditModel.ShippingAddressSameAsBillingAddress = model.PaymentEditModel.Amount > 0;

            if (tempCart.EventId.HasValue && tempCart.EventId.Value > 0)
            {
                var eventData = _eventRepository.GetById(tempCart.EventId.Value);
                model.CustomerEditModel.InsuranceIdRequired = eventData.InsuranceIdRequired;
                var eventHospitalPartner = _hospitalPartnerRepository.GetEventHospitalPartnersByEventId(tempCart.EventId.Value);
                if (eventHospitalPartner != null)
                    model.CustomerEditModel.CaptureSsn = eventHospitalPartner.CaptureSsn;
            }

            return model;
        }

        public ActionResult UpdateCartwithReturningCustomer(string guid, long customerId)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart != null)
            {
                tempCart.CustomerId = customerId;
                tempCart.IsExistingCustomer = true;
                tempCart.ProspectCustomerId = null;

                _tempCartRepository.Save(tempCart);
            }

            var customer = _customerRepository.GetCustomer(customerId);
            var customerEditModel = Mapper.Map<Customer, SchedulingCustomerEditModel>(customer);
            customerEditModel.PhoneCell = PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString());
            customerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
            //if (customerEditModel.ShippingAddress != null) customerEditModel.ShippingAddress.Id = 0;

            return Json(customerEditModel, JsonRequestBehavior.AllowGet);
        }

        private bool ValidatePaymentModel(PaymentEditModel model)
        {
            bool isValid = true;

            if (model.Payments == null)
            {
                if (model.Amount > 0)
                {
                    isValid = false;
                }
            }
            else
            {
                foreach (var payment in model.Payments)
                {

                    var validationResult = _paymentValidator.Validate(payment);
                    if (!validationResult.IsValid)
                    {
                        isValid = false;

                        var propertyNames = validationResult.Errors.Select(e => e.PropertyName).Distinct();
                        var htmlString = propertyNames.Aggregate("", (current, property) => current + (validationResult.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

                        payment.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString);
                    }
                }
            }

            return isValid;
        }

        [HttpPost]
        public ActionResult ApplySourceCode(SourceCodeApplyEditModel model, string guid)
        {
            model = _eventSchedulerService.ApplySourceCode(model);

            var tempCart = _tempCartRepository.Get(guid);
            if (model.SourceCodeId > 0)
                tempCart.SourceCodeId = model.SourceCodeId;
            else
                tempCart.SourceCodeId = null;

            SaveTempCart(tempCart);

            return Json(model);
        }

        private void SaveTempCart(TempCart tempCart)
        {
            tempCart.IPAddress = Request.UserHostAddress;
            tempCart.Browser = Request.Browser.Type;

            if (tempCart.Id > 0)
                tempCart.DateModified = DateTime.Now;
            else
            {
                tempCart.DateCreated = DateTime.Now;
            }

            _tempCartRepository.Save(tempCart);

        }

        private void UpdateTempCartExitPage(string guid, TempCart tempCart = null)
        {
            // Not to set complete/incomplete status here
            if (tempCart == null)
            {
                tempCart = _tempCartRepository.Get(guid);
                if (tempCart == null || tempCart.EventId == null)
                {
                    Response.RedirectUser(_settings.SiteUrl);
                    return;
                }
            }

            tempCart.ExitPage = Request.Url.PathAndQuery;
            _tempCartRepository.Save(tempCart);
        }

        [HttpPost]
        public ActionResult ApplyGiftCertificate(string claimCode)
        {
            try
            {
                var giftCertificate = _giftCertificateService.GetGiftCertificatebyClaimCode(claimCode);
                return Json(new { Result = true, Message = "", GiftCertificate = giftCertificate });
            }
            catch (ObjectDeactivatedException<GiftCertificate> ex)
            {
                return Json(new { Result = false, ex.Message, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { Result = false, ex.Message, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } });
            }
            catch (Exception ex)
            {
                _logger.Error(string.Concat("Online Scheduling! System Error Occured while Applying Gift Certificate for Code: [", claimCode, "]. Message: ", ex.Message, "\n\t Stack Trace: ", ex.StackTrace));
                return Json(new { Result = false, Message = "Some system error occured! Please call our Care Agent for any assistence, at " + _settings.PhoneTollFree, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } });
            }
        }

        [HttpPost]
        public ActionResult UpdateCartWithAppointment(string guid, IEnumerable<long> selectedSlotIds)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart == null)
            {
                return Json(new { IsBooked = false, IsSuccess = false, AppointmentId = 0, AppointmentTime = "", Message = " Invalid Request! " }, JsonRequestBehavior.AllowGet);
            }

            if (selectedSlotIds == null || selectedSlotIds.Count() < 1)
            {
                tempCart.AppointmentId = null;
                tempCart.InChainAppointmentSlots = string.Empty;
                tempCart.IsUsedAppointmentSlotExpiryExtension = null;
                SaveTempCart(tempCart);
                return Json(new { IsBooked = false, IsSuccess = true, AppointmentId = 0, AppointmentTime = "", Message = "" }, JsonRequestBehavior.AllowGet);
            }

            var slot = _slotService.GetHeadSlotintheChain(selectedSlotIds);

            tempCart.AppointmentId = slot.Id;
            tempCart.InChainAppointmentSlots = string.Join(",", selectedSlotIds);
            tempCart.IsUsedAppointmentSlotExpiryExtension = null;
            SaveTempCart(tempCart);

            return Json(new { IsBooked = true, IsSuccess = true, AppointmentId = slot.Id, AppointmentTime = slot.StartTime.ToString("h:mm tt"), Message = "" }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ExtendAppointment(string guid, long appointmentId)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart == null)
            {
                return Json(new { IsBooked = false, IsSuccess = false, AppointmentId = 0, AppointmentTime = "", Message = " Invalid Request! " }, JsonRequestBehavior.AllowGet);
            }

            _slotRepository.ExtendTemporarilyBookAppointmentExpiryTime(appointmentId);

            tempCart.AppointmentId = appointmentId;
            tempCart.IsUsedAppointmentSlotExpiryExtension = null;
            SaveTempCart(tempCart);

            var appointmentSlot = _slotRepository.GetbyId(appointmentId);

            return Json(new { IsBooked = true, IsSuccess = true, AppointmentId = appointmentSlot.Id, AppointmentTime = appointmentSlot.StartTime.ToString("h:mm tt"), Message = "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAppointmentTimeExpirationTime(string cartGuid, long appointmentId)
        {
            if (appointmentId < 1)
                return Json(new { IsBooked = false, AppointmentTime = "", Minutes = 0, Seconds = 0, Message = "Please book an appointment!" }, JsonRequestBehavior.AllowGet);

            var timespan = _slotRepository.GetAppointmentTimeExpirationTime(appointmentId);
            if (timespan.HasValue)
            {
                string message = "Appointment Slot you booked earlier, has expired! Please select another one.";
                var appointmentSlot = _slotRepository.GetbyId(appointmentId);

                if (timespan.Value.TotalSeconds > 0)
                {
                    if (appointmentSlot.Status == AppointmentStatus.TemporarilyBooked)
                        return Json(new { IsBooked = true, AppointmentTime = appointmentSlot.StartTime.ToString("h:mm tt"), timespan.Value.Minutes, timespan.Value.Seconds, Message = "" }, JsonRequestBehavior.AllowGet);
                }

                if (appointmentSlot.Status == AppointmentStatus.Booked)
                {
                    message = "The slot you booked earlier got through its time limit, and has been been taken by some other user. Please select another one.";
                    UpdateCartAndReleaseSlot(cartGuid, false, true);
                }
                else
                {
                    UpdateCartAndReleaseSlot(cartGuid, true, true);
                }

                return Json(new { IsBooked = false, AppointmentTime = "", Minutes = 0, Seconds = 0, Message = message }, JsonRequestBehavior.AllowGet);
            }

            UpdateCartAndReleaseSlot(cartGuid);
            return Json(new { IsBooked = false, AppointmentTime = "", Minutes = 0, Seconds = 0, Message = "Please book an appointment!" }, JsonRequestBehavior.AllowGet);
        }

        private void UpdateCartAndReleaseSlot(string cartGuid, bool releaseSlot = true, bool updateExpiryTimeUsage = false)
        {
            if (string.IsNullOrEmpty(cartGuid)) return;

            var tempCart = _tempCartRepository.Get(cartGuid);

            if (releaseSlot)
                _slotRepository.ReleaseSlots(tempCart.InChainAppointmentSlotIds);

            tempCart.AppointmentId = null;
            tempCart.InChainAppointmentSlots = null;

            if (updateExpiryTimeUsage)
                tempCart.IsUsedAppointmentSlotExpiryExtension = true;

            SaveTempCart(tempCart);
        }

        [HttpPost]
        public ActionResult SaveProspectCustomerAndUpdateCart(string guid, ProspectCustomerEditModel prospectCustomerEditModel)
        {
            var url = GetUrltoRedirectifCartisCompleteorInvalid(guid);
            if (!string.IsNullOrEmpty(url)) return Content("");

            var prospectCustomer = Mapper.Map<ProspectCustomerEditModel, ProspectCustomer>(prospectCustomerEditModel);

            prospectCustomer.FirstName = prospectCustomer.FirstName.ToUppercaseInitalLetter();
            prospectCustomer.LastName = prospectCustomer.LastName.ToUppercaseInitalLetter();

            var tempCart = _tempCartRepository.Get(guid);

            if (prospectCustomerEditModel.Address != null)
            {
                prospectCustomer.Address.StreetAddressLine1 = prospectCustomer.Address.StreetAddressLine1.ToUppercaseInitalLetter(false);
                prospectCustomer.Address.StreetAddressLine2 = prospectCustomer.Address.StreetAddressLine2.ToUppercaseInitalLetter(false);

                if (prospectCustomerEditModel.Address.StateId > 0)
                {
                    var state = _stateRepository.GetState(prospectCustomerEditModel.Address.StateId);
                    prospectCustomer.Address.State = state.Name;
                }
                prospectCustomer.Address.ZipCode = new ZipCode(tempCart.ZipCode);
            }
            else
            {
                prospectCustomer.Address = new Address
                {
                    ZipCode = new ZipCode(tempCart.ZipCode)
                };
            }

            var inDb =
                ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomermatchingConditions(
                    prospectCustomer.FirstName, prospectCustomer.LastName,
                    prospectCustomer.Email != null ? prospectCustomer.Email.ToString() : "",
                    prospectCustomer.CallBackPhoneNumber != null ? prospectCustomer.CallBackPhoneNumber.ToString() : "");



            if (tempCart.CustomerId > 0) return Content("");

            if (tempCart.ProspectCustomerId != null && tempCart.ProspectCustomerId > 0)
            {
                var prospectCustomerinDb = _prospectCustomerRepository.GetById(tempCart.ProspectCustomerId.Value);
                prospectCustomer.CreatedOn = prospectCustomerinDb.CreatedOn;
                prospectCustomer.Id = prospectCustomerinDb.Id;
            }
            else if (inDb != null)
            {
                inDb.Email = prospectCustomer.Email ?? inDb.Email;
                inDb.CustomerId = null;
                inDb.IsConverted = false;
                inDb.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                inDb.CallBackPhoneNumber = prospectCustomer.CallBackPhoneNumber ?? inDb.CallBackPhoneNumber;
                inDb.BirthDate = prospectCustomer.BirthDate ?? inDb.BirthDate;
                inDb.Address = prospectCustomer.Address != null && !prospectCustomer.Address.IsEmpty() ? prospectCustomer.Address : inDb.Address;
                inDb.MarketingSource = prospectCustomer.MarketingSource;
                inDb.Gender = prospectCustomer.Gender;
                prospectCustomer = inDb;
            }
            else
            {
                prospectCustomer.CreatedOn = DateTime.Now;
                prospectCustomer.IsConverted = false;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
            }

            prospectCustomer = _prospectCustomerRepository.Save(prospectCustomer);
            if (prospectCustomer.Id > 0)
            {
                if (!string.IsNullOrEmpty(prospectCustomer.MarketingSource))
                    tempCart.MarketingSource = prospectCustomer.MarketingSource;
                tempCart.ProspectCustomerId = prospectCustomer.Id;
                _tempCartRepository.Save(tempCart);
            }

            return Content("");
        }

        public ActionResult ThankYou(string guid)
        {
            var tempCart = _tempCartRepository.Get(guid, true);
            var customer = _customerRepository.GetCustomer(tempCart.CustomerId.Value);
            UpdateTempCartExitPage(guid, tempCart);

            var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);

            var model = new OnlineSchedulingThankYouAndAdditionalInfo
                            {
                                EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart),
                                ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                                GoogleAnalyticsReportingDataModel = _googleAnalyticalService.GetGoogleAnalyticsViewModel(tempCart),
                                AssessmentQuestionEditModel = _healthAssessmentService.GetHealthAssessmentEditModel(tempCart.CustomerId.Value, tempCart.EventId.Value),
                                Height = customer.Height != null ? (int)customer.Height.TotalInches : 0,
                                Weight = customer.Weight != null ? (int)customer.Weight.Pounds : 0,
                                DateofBirth = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value : (DateTime?)null,
                                Gender = (int)customer.Gender,
                                Race = (int)customer.Race,
                                Waist = customer.Waist,
                                CaptureHafOnline = (account == null || account.CaptureHafOnline)
                            };

            var pcp = _primaryCarePhysicianRepository.Get(customer.CustomerId);
            if (pcp != null)
            {
                model.Pcp = Mapper.Map<PrimaryCarePhysician, PrimaryCarePhysicianEditModel>(pcp);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ThankYou(OnlineSchedulingThankYouAndAdditionalInfo model, HealthAssessmentEditModel assessmentEditModel)
        {
            model.AssessmentQuestionEditModel = assessmentEditModel;

            var tempCart = _tempCartRepository.Get(model.ProcessAndCartViewModel.CartGuid, true);

            if (model.AssessmentQuestionEditModel.QuestionEditModels != null && model.AssessmentQuestionEditModel.QuestionEditModels.Any())
                _healthAssessmentService.Save(model.AssessmentQuestionEditModel, tempCart.CustomerId.Value);


            model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart);
            model.ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart);
            model.GoogleAnalyticsReportingDataModel = _googleAnalyticalService.GetGoogleAnalyticsViewModel(tempCart);
            model.AssessmentQuestionEditModel = _healthAssessmentService.GetHealthAssessmentEditModel(tempCart.CustomerId.Value, tempCart.EventId.Value);

            if (!model.DateofBirth.HasValue || model.DateofBirth.Value.GetAge() < _settings.MinimumAgeForScreening)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage(model.DateofBirth.HasValue
                        ? string.Format("Age cannot be below {0} years.", _settings.MinimumAgeForScreening)
                        : string.Format("Date of Birth can not be left blank."));

                return View(model);
            }

            if (model.EnterPcpDetail)
            {
                var pcpValidationResult = _pcpValidator.Validate(model.Pcp);

                if (!pcpValidationResult.IsValid)
                {
                    var propertyNames = pcpValidationResult.Errors.Select(e => e.PropertyName).Distinct();
                    var htmlString = propertyNames.Aggregate("", (current, property) => current + (pcpValidationResult.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

                    model.Pcp.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString);

                    return View(model);
                }
            }

            try
            {
                var customer = _customerRepository.GetCustomer(model.ProcessAndCartViewModel.CustomerId.Value);
                customer.Height = model.Height > 0 ? new Height { TotalInches = model.Height } : null;
                customer.Weight = model.Weight > 0 ? new Weight(model.Weight) : null;

                if (model.Gender.HasValue)
                    customer.Gender = (Gender)model.Gender.Value;

                customer.DateOfBirth = model.DateofBirth;
                customer.Race = (Race)model.Race;
                customer.Waist = model.Waist;

                _customerService.SaveCustomer(customer, customer.CustomerId);

                if (model.EnterPcpDetail)
                    _customerService.SavePrimaryCarePhysician(model.Pcp, customer.CustomerId);
            }
            catch (Exception ex)
            {
                model.Pcp.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
                _logger.Error("\nOnline ThankYou. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                return View(model);
            }

            Response.RedirectUser("/Scheduling/Online/Confirmation?guid=" + model.ProcessAndCartViewModel.CartGuid);
            return null;
        }

        public ActionResult EventRequest(string zipCode, string radius = "")
        {
            return View();
        }

        public bool CheckifCartisComplete(string guid)
        {
            if (string.IsNullOrEmpty(guid)) return false;

            var cart = _tempCartRepository.Get(guid);
            if (cart != null)
            {
                if (cart.DateCreated.AddDays(1) < DateTime.Now)
                    throw new InvalidOperationException();
                return false;
            }
            cart = _tempCartRepository.Get(guid, true);
            if (cart != null) return true;

            throw new NullReferenceException("This temp cart doesn't exist");
        }

        public string GetUrltoRedirectifCartisCompleteorInvalid(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                try
                {
                    var isComplete = CheckifCartisComplete(guid);
                    if (isComplete)
                    {
                        var cart = _tempCartRepository.Get(guid, true);
                        // return cart.ExitPage; 
                    }
                }
                catch (InvalidOperationException)
                {
                    var cart = _tempCartRepository.Get(guid);
                    //return cart.EntryPage;
                }
                catch (Exception)
                {
                    return _settings.SiteUrl;
                }
            }

            return null;
        }

        private void CheckCartForAppointment(TempCart tempCart)
        {
            if (!tempCart.EventPackageId.HasValue && tempCart.TestId.IsNullOrEmpty() && !tempCart.InChainAppointmentSlotIds.IsNullOrEmpty())
            {
                _slotRepository.ReleaseSlots(tempCart.InChainAppointmentSlotIds);
                tempCart.AppointmentId = null;
                tempCart.InChainAppointmentSlots = string.Empty;
                _tempCartRepository.Save(tempCart);
            }
        }

        [HttpPost]
        public int GetScreeningTime(long eventId, long packageId, IEnumerable<long> testIds)
        {
            return _eventPackageSelectorService.GetScreeningTime(eventId, packageId, testIds);
        }

        public ActionResult AnnualReminderCheckout(OnlineSchedulingEventListModelFilter filter, long eventId, string cpncd = "")
        {
            var selectedEvent = _eventService.GetSelectedEvent(eventId);

            if (selectedEvent == null)
            {
                //return Redirect("/Scheduling/Online/LocationAndAppointmentSlot?Radius=" + filter.Radius + "&ZipCode=" + filter.ZipCode + "&cpncd=" + cpncd);
                return RedirectToAction("LocationAndAppointmentSlot", "Online", new { Area = "Scheduling", Radius = filter.Radius, ZipCode = filter.ZipCode, cpncd });
            }

            long sourceCodeId = 0;
            if (!string.IsNullOrEmpty(cpncd))
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeByCode(cpncd);
                if (sourceCode != null)
                    sourceCodeId = sourceCode.Id;
            }

            var tempCart = new TempCart
                               {
                                   ZipCode = filter.ZipCode,
                                   EventId = eventId,
                                   Radius = filter.Radius,
                                   Guid = Guid.NewGuid().ToString(),
                                   EntryPage = Request.Url.PathAndQuery,
                                   ExitPage = Request.Url.PathAndQuery,
                                   SourceCodeId = sourceCodeId > 0 ? (long?)sourceCodeId : null
                               };
            SaveTempCart(tempCart);
            //return Redirect("/Scheduling/Online/LocationAndAppointmentSlot?guid=" + tempCart.Guid);
            return RedirectToAction("LocationAndAppointmentSlot", "Online", new { Area = "Scheduling", guid = tempCart.Guid });
        }

        public ActionResult Confirmation(string guid)
        {
            var tempCart = _tempCartRepository.Get(guid, true);

            UpdateTempCartExitPage(guid, tempCart);

            var customerHealthInfo = _healthAssessmentRepository.Get(tempCart.CustomerId.Value, tempCart.EventId.Value);

            var eventData = _eventRepository.GetById(tempCart.EventId.Value);

            var model = new OnlineSchedulingConfirmationInfo
                            {
                                ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                                ConfirmationViewModel = _emailNotificationModelsFactory.GetAppointmentConfirmationModel(tempCart.EventId.Value, tempCart.CustomerId.Value),
                                Zipcode = tempCart.ZipCode,
                                Radius = tempCart.Radius.HasValue ? tempCart.Radius.Value : 25,
                                EventId = tempCart.EventId.Value,
                                CustomerId = tempCart.CustomerId.Value,
                                IsHaffilled = customerHealthInfo != null && customerHealthInfo.Any(),
                                EventType = eventData.EventType
                            };
            //if (model.IsHaffilled)
            //    model.PrintUrl = PrintHealthAssessmentForm(guid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Confirmation(OnlineSchedulingConfirmationInfo model)
        {
            var oldTempCart = _tempCartRepository.Get(model.ProcessAndCartViewModel.CartGuid, true);
            var tempCart = new TempCart
            {
                ZipCode = oldTempCart.ZipCode,
                EventId = oldTempCart.EventId,
                Radius = oldTempCart.Radius,
                Guid = Guid.NewGuid().ToString(),
                EntryPage = Request.Url.PathAndQuery,
                ExitPage = Request.Url.PathAndQuery,
                Version = oldTempCart.Version
            };
            SaveTempCart(tempCart);

            Response.RedirectUser("/Scheduling/Online/Package?guid=" + tempCart.Guid);
            return null;
        }

        //public string PrintHealthAssessmentForm(string guid)
        //{
        //    var tempCart = _tempCartRepository.Get(guid, true);

        //    var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
        //    var fileName = Guid.NewGuid() + ".pdf";

        //    var url = _settings.AppUrl + "/Medical/Results/HealthAssessment?customerId=" + tempCart.CustomerId.Value + "&eventId=" + tempCart.EventId.Value + "&Print=" + Boolean.TrueString + "&PrintBlank=" + Boolean.FalseString + "&LoadLayout=false&showKynEditModel=false&bulkPrint=true&isOnlineUser=true";
        //    _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);
        //    return mediaLocation.Url + fileName;
        //}

        [HttpPost]
        public ActionResult SaveTempCartforPreliminarySelectedTime(string guid, DateTime? selectedTimeRange)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart != null)
            {
                tempCart.PreliminarySelectedTime = selectedTimeRange;
                SaveTempCart(tempCart);
                return Json(new { Result = true, CartGuid = guid });
            }
            return Json(new { Result = false, CartGuid = guid });
        }

        [HttpPost]
        public ActionResult SavePackageSelectionInfo(string guid, PackageSelectionInfoEditModel packageSelectionInfoEditModel)
        {
            var tempCart = _tempCartRepository.Get(guid);
            var preQualificationResult = _preQualificationResultRepository.Get(tempCart.Id) ?? new PreQualificationResult();

            if (tempCart == null || !tempCart.EventId.HasValue) return Json(new { Result = false, CartGuid = guid });

            int customerAge = packageSelectionInfoEditModel.Dob.HasValue ? packageSelectionInfoEditModel.Dob.Value.GetAge() : 0;

            if (packageSelectionInfoEditModel.SkipPreQualificationQuestion)
            {
                tempCart.Gender = packageSelectionInfoEditModel.Gender.HasValue && packageSelectionInfoEditModel.Gender.Value > 0 ? ((Gender)packageSelectionInfoEditModel.Gender.Value).ToString() : null;
                tempCart.Dob = packageSelectionInfoEditModel.Dob;
                preQualificationResult.SkipPreQualificationQuestion = packageSelectionInfoEditModel.SkipPreQualificationQuestion;
                preQualificationResult.TempCartId = tempCart.Id;
                preQualificationResult.EventId = tempCart.EventId.Value;

                SaveTempCart(tempCart);

                if (tempCart.EventId != null)
                    SavePreQualificationResult(preQualificationResult);

            }
            else
            {
                if (packageSelectionInfoEditModel.IsValueFilled)
                {
                    tempCart.Gender = packageSelectionInfoEditModel.Gender.HasValue && packageSelectionInfoEditModel.Gender.Value > 0 ? ((Gender)packageSelectionInfoEditModel.Gender.Value).ToString() : null;
                    tempCart.Dob = packageSelectionInfoEditModel.Dob;

                    if (packageSelectionInfoEditModel.ShowPreQualifiedQuestion)
                    {
                        preQualificationResult.ChestPain = packageSelectionInfoEditModel.ChestPain;
                        preQualificationResult.HeartDisease = packageSelectionInfoEditModel.HeartDisease;
                        preQualificationResult.HighBloodPressure = packageSelectionInfoEditModel.HighBloodPressure;
                        preQualificationResult.Smoker = packageSelectionInfoEditModel.Smoker;
                        preQualificationResult.Diabetic = packageSelectionInfoEditModel.Diabetic;
                        preQualificationResult.DiagnosedHeartProblem = packageSelectionInfoEditModel.DiagnosedHeartProblem;
                        preQualificationResult.HighCholestrol = packageSelectionInfoEditModel.HighCholestrol;
                        preQualificationResult.OverWeight = packageSelectionInfoEditModel.OverWeight;
                    }

                    preQualificationResult.SkipPreQualificationQuestion = packageSelectionInfoEditModel.SkipPreQualificationQuestion;
                    preQualificationResult.TempCartId = tempCart.Id;
                    preQualificationResult.EventId = tempCart.EventId.Value;

                    SaveTempCart(tempCart);
                    SavePreQualificationResult(preQualificationResult);
                }
            }

            return Json(new { Result = true, CartGuid = guid });
        }

        private void SavePreQualificationResult(PreQualificationResult preQualificationResult)
        {
            preQualificationResult.DateCreated = DateTime.Now;
            preQualificationResult.IsActive = true;
            preQualificationResult.SignUpModeId = (int)SignUpMode.Online;
            _preQualificationResultRepository.Save(preQualificationResult);
        }

        private void SetPackage(OnlineSchedulingSelectPackageEditModel model, TempCart tempCart, PreQualificationResult preQualificationResult)
        {
            if (model.PackageSelectionEditModel.SelectedPackageId > 0 || model.PackageSelectionEditModel.AllEventPackages == null || model.PackageSelectionEditModel.AllEventPackages.Count() < 1)
                return;

            if ((model.PackageSelectionInfo.IsValueFilled && preQualificationResult.AgreedWithPrequalificationQuestion) || (preQualificationResult.SkipPreQualificationQuestion && model.PackageSelectionInfo.IsBasicInfoFilled))
            {
                if (model.RecommendPackage && model.PackageSelectionEditModel.SelectedPackageId < 1)
                {
                    var package = model.PackageSelectionEditModel.AllEventPackages.Where(p => p.IsRecommended && !p.NotAvailable).Select(p => p).FirstOrDefault();
                    if (package != null)
                    {
                        tempCart.EventPackageId = package.EventPackageId;
                        model.PackageSelectionEditModel.SelectedPackageId = package.EventPackageId;

                        SaveTempCart(tempCart);
                    }
                }

            }
            else
            {
                model.PackageSelectionEditModel.AllEventPackages = null;
                model.PackageSelectionEditModel.AllEventTests = null;
                model.PackageSelectionEditModel.AllProducts = null;
                model.PackageSelectionEditModel.AllShippingOptions = null;
            }

        }

        [HttpPost]
        public ActionResult SaveTempCartforEligibility(string guid, long eligibilityId, long chargeCardId)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart == null) return Json(new { Result = false, CartGuid = guid });

            tempCart.EligibilityId = eligibilityId > 0 ? (long?)eligibilityId : null;
            tempCart.ChargeCardId = chargeCardId > 0 ? (long?)chargeCardId : null;
            SaveTempCart(tempCart);

            return Json(new { Result = true, CartGuid = guid });
        }

        [HttpPost]
        public ActionResult UpdateUserPrefrenceWithPrequalificationQuestion(string guid)
        {
            var tempCart = _tempCartRepository.Get(guid);

            if (tempCart == null) return Json(new { Result = false, CartGuid = guid });

            var preQualificationResult = _preQualificationResultRepository.Get(tempCart.Id);

            preQualificationResult.AgreedWithPrequalificationQuestion = true;
            if (tempCart.EventId != null)
                SavePreQualificationResult(preQualificationResult);

            return Json(new { Result = true, CartGuid = guid });
        }

        public ActionResult OnlineCheckoutPrintHaf(string guid)
        {
            return View();// Redirect(PrintHealthAssessmentForm(guid));
        }

    }
}
