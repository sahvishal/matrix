using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Scheduling.Services;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Roles = Falcon.App.Core.Enum.Roles;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class SelectAppointment : Page
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerType"]))
                {
                    switch (Request.QueryString["CustomerType"])
                    {
                        case "Existing":
                            return CustomerType.Existing;
                        default:
                            return CustomerType.New;
                    }
                }
                return CustomerType.New;
            }
        }

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        private long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        private long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        private long PackageId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageId : 0;
            }
        }

        private long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
                return null;
            }
            set
            {
                RegistrationFlow.ProductId = value.HasValue ? value.Value : 0;
            }
        }

        private List<long> TestIds
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.TestIds != null)
                {
                    return RegistrationFlow.TestIds.ToList();
                }
                return null;
            }
        }

        private List<long> AddOnTestIds
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.AddOnTestIds != null)
                {
                    return RegistrationFlow.AddOnTestIds.ToList();
                }
                return null;
            }
        }

        private decimal PackageCost
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageCost : 0;
            }
        }

        private IEnumerable<long> AppointmentSlotIds
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.AppointmentSlotIds : null;
            }
            set { RegistrationFlow.AppointmentSlotIds = value; }
        }

        private string SourceCode
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCode : string.Empty;
            }
        }

        private long SourceCodeId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeId : 0;
            }
        }

        private decimal SourceCodeAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeAmount : 0;
            }
            set { RegistrationFlow.SourceCodeAmount = value; }
        }

        private ShippingDetail ShippingDetail
        {
            get
            {
                if (ShippingOptionId.HasValue && ShippingAddressId.HasValue)
                {
                    var shippingDetail = GetShippingDetailData(ShippingOptionId.Value, ShippingAddressId.Value);
                    if (RegistrationFlow != null)
                        shippingDetail.Id = RegistrationFlow.ShippingDetailId;
                    return shippingDetail;
                }
                return null;
            }
            set
            {
                RegistrationFlow.ShippingDetailId = value.Id;
            }
        }

        private ShippingDetail GetShippingDetailData(long shippingOptionId, long shippingAddressId)
        {
            var addressRepository = IoC.Resolve<IAddressRepository>();

            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(),
                DataRecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                Status = ShipmentStatus.Processing,
                ShippingAddress = addressRepository.GetAddress(shippingAddressId)
            };
            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
            var shippingOption = shippingOptionRepository.GetById(shippingOptionId);
            shippingDetail.ShippingOption.Id = shippingOption.Id;
            shippingDetail.ActualPrice = shippingOption.Price;

            return shippingDetail;
        }

        protected decimal TotalAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.TotalAmount : 0;
            }
            set { RegistrationFlow.TotalAmount = value; }
        }

        private string MarketingSource
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.MarketingSource : string.Empty;
            }
        }

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingOptionId = value.HasValue ? value.Value : 0;
            }
        }

        private long? ShippingAddressId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingAddressId > 0)
                    return RegistrationFlow.ShippingAddressId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingAddressId = value.HasValue ? value.Value : 0;
            }
        }

        private bool BackAgaininFlow
        {
            get
            {
                if (Request.QueryString["Back"] != null)
                    return true;
                return false;
            }
        }

        private Core.Users.Domain.Customer _customer;

        private Core.Users.Domain.Customer CurrentCustomer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId);
                }
                return _customer;
            }
        }

        private EventCustomer _eventCustomer = null;
        private EventCustomer EventCustomer
        {
            get
            {
                if (_eventCustomer == null)
                {
                    var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                    _eventCustomer = eventCustomerRepository.Get(EventId, CustomerId);

                }
                return _eventCustomer;
            }
        }

        private IEventCustomerPackageTestDetailService _packageTestDetailService;
        private IEventCustomerPackageTestDetailService PackageTestDetailService
        {
            get
            {
                return _packageTestDetailService ?? (_packageTestDetailService = IoC.Resolve<IEventCustomerPackageTestDetailService>());
            }
        }

        private IEventRepository _eventRepository;
        private IEventRepository EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = IoC.Resolve<IEventRepository>());
            }
        }

        private Event _eventData;
        private Event EventData
        {
            get
            {
                if (_eventData == null && EventId > 0)
                {
                    _eventData = EventRepository.GetById(EventId);
                }
                return _eventData;
            }
        }

        private ILogger _logger;

        private ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = IoC.Resolve<ILogManager>().GetLogger<Global>();

                }
                return _logger;
            }
        }

        private UserSessionModel _userSessionModel;

        private UserSessionModel UserSessionModel
        {
            get { return _userSessionModel ?? (_userSessionModel = IoC.Resolve<ISessionContext>().UserSession); }
        }

        private CorporateAccount _accountByEventId;
        private CorporateAccount AccountByEventId
        {
            get
            {
                if (_accountByEventId == null && EventId > 0)
                {
                    _accountByEventId = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId);
                }

                return _accountByEventId;
            }
        }

        protected EventType EventType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = false;
            SetTitle();
            //Event eventData = null;
            if (EventId != 0)
            {
                ProductOption.EventId = EventId;
                OrderSummaryControl.EventId = EventId;
                OrderSummaryControl.RoleId = (long)Roles.CallCenterRep;
                OrderSummaryControl.PackageId = PackageId;
                OrderSummaryControl.TestIds = TestIds;
                OrderSummaryControl.IsSourceCodeApplied = SourceCodeId > 0;
                OrderSummaryControl.SourceCodeAmount = SourceCodeAmount;

                EventType = EventData.EventType;

                ResultOption.TestIds = TestIds;
                ResultOption.EventId = EventId;
            }
            var settings = IoC.Resolve<ISettings>();
            if (EventData != null && EventData.EventType == EventType.Corporate)
            {
                ResultOption.EventType = EventType.Corporate;
                ResultOption.AccountId = EventData.AccountId.HasValue ? EventData.AccountId.Value : 0;
            }
            else if (settings.HideShippingOption)
            {
                ResultOption.ShowOnlineOption = true;
                ResultOption.ShowFreeOption = false;
                ResultOption.RemovePaidOption = false;
            }
            _ucEventAppointment1.PackageId = PackageId;
            _ucEventAppointment1.TestIds = AddOnTestIds.IsNullOrEmpty() ? "" : string.Join(",", AddOnTestIds);
            if (!IsPostBack)
            {
                TotalAmount = PackageCost - SourceCodeAmount;

                if (EventId != 0)
                {
                    FillEventDetails();

                    _ucEventAppointment1.EventId = EventId;
                    _ucEventAppointment1.CurrentViewType = ViewType.CallCenterRep;
                    //_ucEventAppointment1.FillAppointmentSlots();
                    _ucEventAppointment1.SetAppointmentIds(AppointmentSlotIds);
                    _ucEventAppointment1.ScreeningTime = RegistrationFlow.ScreeningTime;

                    //if (BackAgaininFlow)
                    //{
                    if (!AppointmentSlotIds.IsNullOrEmpty())
                    {
                        var slotService = IoC.Resolve<IEventSchedulingSlotService>();
                        var slot = slotService.GetHeadSlotintheChain(AppointmentSlotIds);
                        OrderSummaryControl.AppointmentTime = slot.StartTime.ToString("hh:mm tt");
                        txtSlot.Text = "You have Selected: " + OrderSummaryControl.AppointmentTime;
                    }
                    else
                    {
                        AppointmentSlotIds = null;
                        txtSlot.Text = string.Empty;
                    }
                    if (ShippingDetail != null && ShippingDetail.ShippingOption != null && ShippingDetail.ShippingOption.Id > 0)
                    {
                        IUniqueItemRepository<ShippingOption> itemRepository = new ShippingOptionRepository();
                        var shippingOption = itemRepository.GetById(ShippingDetail.ShippingOption.Id);
                        OrderSummaryControl.ShippingOption = shippingOption.Name;
                        OrderSummaryControl.ShippingOptionPrice = ShippingDetail.ActualPrice;
                    }
                    //}


                }
                else
                {
                    const string message = "Sorry, Event detail not found. <a href=\"RegCustomerSearchEvent.aspx\">Click here</a> to search event again ";
                    DisplayErrorMessage(message);
                }
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId);
                }
            }
            else
            {
                if (Request.Params["__EVENTTARGET"] == "NextButton" && Request.Params["__EVENTARGUMENT"] == "Click")
                    NextButtonClick();
            }
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            AppointmentSlotIds = _ucEventAppointment1.GetAppointmentIds();
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                    Response.RedirectUser("SelectPackage.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId);
                else if (Request.QueryString["CustomerID"] != null)
                    Response.RedirectUser("SelectPackage.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Call=No" + "&guid=" + GuId);
                else
                    Response.RedirectUser("SelectPackage.aspx?Call=No" + "&guid=" + GuId);
            }
            else
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                    Response.RedirectUser("SelectPackage.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                else if (Request.QueryString["CustomerID"] != null)
                    Response.RedirectUser("SelectPackage.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId);
                else
                    Response.RedirectUser("SelectPackage.aspx?guid=" + GuId);
            }
        }

        private void NextButtonClick()
        {
            Logger.Info("NextButtonClick for customerId " + CustomerId + " and EventId " + EventId);
            AppointmentSlotIds = _ucEventAppointment1.GetAppointmentIds();

            if (!EventValidation())
            {
                Logger.Info("Returned from event validation for customerId " + CustomerId + " and EventId " + EventId);
                return;
            }
            if (!AppointmentValidation())
            {
                Logger.Info("Returned from appointment validation validation for customerId " + CustomerId + " and EventId " + EventId);
                return;
            }

            SetShippingDetailData();
            Logger.Info("After setting shipping detail data  for customerId " + CustomerId + " and EventId " + EventId);
            SetProductDetail();
            Logger.Info("After setting product detail data");
            var orderTotal = PackageCost + (ProductId.HasValue && ProductId.Value > 0 ? ProductOption.ProductPrice : 0m) +
                             (ShippingDetail != null ? ShippingDetail.ActualPrice : 0m);

            if (!string.IsNullOrEmpty(SourceCode))
                SetSourceCodeData(orderTotal);

            Logger.Info("After setting source code detail data  for customerId " + CustomerId + " and EventId " + EventId);
            string previousTag = string.Empty;
            TotalAmount = orderTotal - SourceCodeAmount;
            if (TotalAmount == 0m)
            {
                bool eventRegistrationSuccessful = false;
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        Logger.Info("in event registration  for customerId " + CustomerId + " and EventId " + EventId);

                        eventRegistrationSuccessful = PaymentViaSourceCode();

                        Logger.Info("after event registration  for customerId " + CustomerId + " and EventId " + EventId);

                        scope.Complete();

                        Logger.Info("after event registration scopr complete for customerId " + CustomerId + " and EventId " + EventId);
                    }
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                    Logger.Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                    if (RegistrationFlow != null)
                        RegistrationFlow.ShippingDetailId = 0;

                    eventRegistrationSuccessful = false;
                }


                if (eventRegistrationSuccessful)
                {
                    try
                    {
                        previousTag = SetCustomerTag(EventId, EventData.EventDate);
                        //previousTag = CurrentCustomer.Tag;

                        var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                        var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();
                        eventSchedulingSlotService.SendEventFillingNotification(EventId, creatorOrganizationRoleUser.Id);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                    }

                    TagUpdatedMail(previousTag);
                    Mail();
                    SendMailForIneligibleCustomer();
                    SendMailForNonTargetedMember();

                    if (RegistrationFlow != null && RegistrationFlow.SingleTestOverride)
                        SendSingleTestOverrideNotification(CustomerId, EventId);

                    UpdateProspectCustomer(CustomerId);
                    SendMailOnRegistrationOfMammoPatientOnNonMammoEvent();
                    UpdateEventCustomerPreApprovedTest(EventId, CustomerId);

                    // Event Customer Medication and ICD codes
                    UpdateEventCustomerIcdAndMedication(EventId, CustomerId);

                    var callCenterCallRepository = IoC.Resolve<Falcon.App.Core.Deprecated.ICallCenterCallRepository>();
                    callCenterCallRepository.SaveCallDispositionAndIsContacted(CallId, ProspectCustomerTag.BookedAppointment.ToString(), RegistrationFlow.CallQueueCustomerId);

                    /*try
                    {
                        var eventCustomer = IoC.Resolve<IEventCustomerRepository>().Get(EventId, CustomerId);
                        SavePreQualificationQuestionAnswer(eventCustomer.Id);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                    }*/

                    try
                    {
                        var futureAppointment = new FutureAppointmentFlagViewModel
                         {
                             CustomerId = CustomerId,
                             HasFutureAppointment = true,
                             FutureAppointmentDate = EventData.EventDate
                         };

                        IoC.Resolve<ICallQueueCustomerPublisher>().UpdateFutreAppointmentFlag(futureAppointment);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("some Error Occurred While Updating future Customers");
                        Logger.Error("Message: " + ex.Message);
                        Logger.Error("Stack Trace: " + ex.StackTrace);
                    }

                    if (RegistrationFlow != null)
                    {
                        RegistrationFlow.SourceCodeId = 0;
                        RegistrationFlow.SourceCode = string.Empty;
                        RegistrationFlow.SourceCodeAmount = 0;
                        RegistrationFlow.ProductId = 0;
                        RegistrationFlow.ShippingDetailId = 0;
                        RegistrationFlow.ShippingOptionId = 0;
                        RegistrationFlow.ShippingAddressId = 0;

                        try
                        {
                            if (RegistrationFlow.AwvVisitId.HasValue)
                            {
                                var isEawvPurchased = (TestIds.Any(x => x == (long)TestType.eAWV) || AddOnTestIds.Any(x => x == (long)TestType.eAWV));

                                if (AccountByEventId != null && isEawvPurchased)
                                {
                                    var settings = IoC.Resolve<ISettings>();
                                    
                                    if (settings.SyncWithHra)
                                    {
                                        var medicare = IoC.Resolve<IMedicareApiService>();

                                        try
                                        {
                                            medicare.Connect(UserSessionModel.UserLoginLogId);
                                        }
                                        catch (Exception)
                                        {
                                            var token = (Session.SessionID + "_" + UserSessionModel.UserId + "_" + UserSessionModel.CurrentOrganizationRole.RoleId + "_" + UserSessionModel.CurrentOrganizationRole.OrganizationId).Encrypt();

                                            var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                            medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                            medicare.Connect(UserSessionModel.UserLoginLogId);
                                        }

                                        var visitId = medicare.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                                             new MedicareEventEditModel
                                             {
                                                 EventId = RegistrationFlow.EventId,
                                                 Tag = AccountByEventId.Tag,
                                                 VisitId = RegistrationFlow.AwvVisitId.Value,
                                                 VisitDate = EventData.EventDate
                                             });
                                        medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + visitId + "&status=" + (int)MedicareVisitStatus.BookedForEvent + "&unlock=true");
                                    }
                                    
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Error While creating the customer from Select Appointment, EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                        }

                    }

                    var healthAssessmentService = IoC.Resolve<IHealthAssessmentService>();
                    healthAssessmentService.SaveClinicalQuestions(GuId, EventId, CustomerId, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);

                    var setting = IoC.Resolve<ISettings>();
                    if (setting.CapturePrimaryCarePhysician)
                    {
                        if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                            Response.RedirectUser("PrimaryCarePhysician.aspx?CustomerType=" + CustomerType + "&Call=No" + "&guid=" + GuId);
                        else
                        {
                            UpdateCallStatus(EventId);
                            Response.RedirectUser("PrimaryCarePhysician.aspx?CustomerType=" + CustomerType + "&guid=" + GuId);
                        }

                    }
                    else
                    {
                        if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                        {
                            if (Request.QueryString["CustomerID"] != null)
                            {
                                Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=no&CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No&EventRegistered=Yes" + "&guid=" + GuId);
                            }
                            else
                            {
                                Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=no&Call=No&EventRegistered=Yes" + "&guid=" + GuId);
                            }
                        }
                        else
                        {
                            UpdateCallStatus(EventId);
                            if (Request.QueryString["CustomerID"] != null)
                            {
                                Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=yes &CustomerID=" + Request.QueryString["CustomerID"] + (!string.IsNullOrEmpty(Request.QueryString["Name"]) ? "&Name=" + Request.QueryString["Name"] : "") + "&guid=" + GuId);
                            }
                            else
                            {
                                Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=yes" + "&guid=" + GuId);
                            }
                        }
                    }
                }
            }
            else
            {
                SetPageRedirect();
            }
        }

        private void TagUpdatedMail(string previousTag)
        {
            if (previousTag.Trim() == string.Empty)
                return;
            try
            {
                IEventCustomerRepository itemRepository = new EventCustomerRepository();
                var eventCustomer = itemRepository.GetCustomersPreviousEventId(EventId, CustomerId);
                var oldEventId = eventCustomer != null ? eventCustomer.EventId : 0;
                if (oldEventId != EventId)
                {
                    var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                    var emailNotification = emailNotificationModelsFactory.GetCustomerTagChangeNotificationViewModel(oldEventId, EventId, CustomerId, previousTag);
                    var notifier = IoC.Resolve<INotifier>();

                    if (emailNotification.PreviousTag != emailNotification.NewTag)
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerTagUpdated, EmailTemplateAlias.CustomerTagUpdated, emailNotification, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, "CallCenter Event Registration");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
            }
        }

        private void SendMailForIneligibleCustomer()
        {
            try
            {
                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();
                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(CurrentCustomer.CustomerId, DateTime.Today.Year);

                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                if (CurrentCustomer != null && customerEligibility != null && customerEligibility.IsEligible.HasValue && !customerEligibility.IsEligible.Value)
                {
                    var eventData = EventData;
                    var inEligibleCustomerAppointmentNotificationViewModel = emailNotificationModelsFactory.GetIneligibleCustomerAppointmentNotificationViewModel(CurrentCustomer, eventData);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.IneligibleCustomerAppointmentNotification, EmailTemplateAlias.IneligibleCustomerAppointment, inEligibleCustomerAppointmentNotificationViewModel, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }
        }


        private void Mail()
        {
            var notifier = IoC.Resolve<INotifier>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

            var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
            customerRegistrationService.SendAppointmentConfirmationMail(CurrentCustomer, EventData, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath, AccountByEventId);

            //If somebody registered within 24 hours of the event Date then send notification.
            if (EventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
            {
                var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(EventId, CustomerId);
                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
            }


        }

        private void SetProductDetail()
        {
            if (ProductOption.IsProductSelected && ProductOption.ProductId > 0)
                ProductId = ProductOption.ProductId;
            else
                ProductId = null;
        }

        private void SetTitle()
        {
            var callCenterMasterPage = (CallCenter_CallCenterMaster1)Master;
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            callCenterMasterPage.hideucsearch();
            if (CustomerType == CustomerType.Existing)
            {
                callCenterMasterPage.SetTitle("Existing Customer");
                StepTitleContainer.InnerText = "Existing Customer";
            }
            else
            {
                callCenterMasterPage.SetTitle("Register New Customer");
                StepTitleContainer.InnerText = "Register New Customer";
            }
        }

        private void FillEventDetails()
        {
            IEventService eventService = IoC.Resolve<IEventService>();
            var eventData = eventService.GetById(EventId);

            if (eventData != null)
            {
                lblTimeZone.Text = eventData.EventTimeZone;
            }
            else
            {
                ErrorDiv.InnerText = "Sorry, Event detail not found. <a href=\"RegCustomerSearchEvent.aspx\">Click here</a> to search event again ";
                ErrorDiv.Visible = true;
            }

        }

        private void DisplayErrorMessage(string errorMessage)
        {
            ErrorDiv.InnerHtml = errorMessage;
            ErrorDiv.Visible = true;
            ClientScript.RegisterStartupScript(typeof(string), "js_MaintainAfterFailedPostback", "MaintainAfterFailedPostBack();", true);
        }

        private bool EventValidation()
        {

            if (EventCustomer != null && EventCustomer.AppointmentId.HasValue)
            {
                var packageTestDetail = PackageTestDetailService.GetEventPackageDetails(EventCustomer.Id);

                var appointment = IoC.Resolve<IAppointmentRepository>().GetById(EventCustomer.AppointmentId.Value);

                if (packageTestDetail != null)
                {
                    var packageAndTest = packageTestDetail.Package != null ? packageTestDetail.Package.Name : string.Empty;
                    var additinalTest = packageTestDetail.Tests.IsNullOrEmpty() ? string.Empty : string.Join(",", packageTestDetail.Tests.Select(x => x.Name).ToArray());

                    packageAndTest = string.IsNullOrEmpty(packageAndTest) ? additinalTest : packageAndTest + (string.IsNullOrEmpty(additinalTest) ? string.Empty : ", " + additinalTest);

                    var message = CurrentCustomer.NameAsString + " is already registered for this event (" + EventData.Name + " ) at " +
                                            EventData.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                            appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
                                            ". Duplicate registrations for the same customer are not allowed.";

                    DisplayErrorMessage(message);
                }

                return false;
            }

            return true;
        }

        private bool AppointmentValidation()
        {
            //Check for duplicate appointment slot
            if (AppointmentSlotIds.IsNullOrEmpty())
            {
                const string message = "Please select an appointment.";
                DisplayErrorMessage(message);
            }

            var slotService = IoC.Resolve<IEventSchedulingSlotService>();
            if (slotService.IsSlotBooked(AppointmentSlotIds))
            {
                AppointmentSlotIds = null;
                const string message =
                    "This appointment slot has already been selected. Please choose another appointment slot.";
                DisplayErrorMessage(message);
            }
            return true;
        }

        private void SetShippingDetailData()
        {
            if (rbtReportMailY.Checked && Convert.ToInt64(hfResultOrderID.Value) > 0)
            {
                ShippingOptionId = Convert.ToInt64(hfResultOrderID.Value);
                var shippingAddress = ResultOption.SaveShippingAddress();
                if (shippingAddress != null)
                    ShippingAddressId = shippingAddress.Id;
                else
                    return;
            }
            else
            {
                ShippingAddressId = null;
                ShippingOptionId = null;
            }
        }

        private void SetPageRedirect()
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&Call=No" + "&guid=" + GuId);
                }
            }
            else
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&Name=" +
                                      Request.QueryString["Name"] + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser("BillingInformationExisting.aspx?CustomerType=" + CustomerType + "&guid=" + GuId);
                }

            }
        }

        private bool PaymentViaSourceCode()
        {
            var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();
            var forOrganizationRoleUser = GetForOrganizationRoleUser();

            var orderables = new List<IOrderable>();
            var packageTestIds = new List<long>();
            if (PackageId > 0)
            {
                var packageRepository = IoC.Resolve<IEventPackageRepository>();
                var package = packageRepository.GetByEventAndPackageIds(EventId, PackageId);
                if (package != null)
                    packageTestIds = package.Tests.Select(t => t.Test.Id).ToList();

                orderables.Add(package);
            }

            var independentTestIds = !packageTestIds.IsNullOrEmpty() ? TestIds.Where(t => !packageTestIds.Contains(t)).Select(t => t).ToList() : TestIds;

            if (!independentTestIds.IsNullOrEmpty())
            {
                var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                orderables.AddRange(eventTestRepository.GetByEventAndTestIds(EventId, independentTestIds));
            }
            if (ProductId.HasValue && ProductId.Value > 0)
            {
                IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                orderables.Add(itemRepository.GetById(ProductId.Value));
            }
            if (orderables.IsNullOrEmpty()) return false;
            Core.Finance.Domain.Order order = null;
            EventCustomer eventCustomer;
            try
            {
                order = GetOrder();
                if (order == null)
                    eventCustomer = SaveEventCustomer(creatorOrganizationRoleUser);
                else
                    eventCustomer = UpdateEventCustomer(creatorOrganizationRoleUser);
            }
            catch
            {
                eventCustomer = SaveEventCustomer(creatorOrganizationRoleUser);
            }

            SourceCode sourceCode;
            if (SourceCodeId > 0)
                sourceCode = new SourceCode
                {
                    Id = SourceCodeId,
                    CouponCode = SourceCode,
                    CouponValue = SourceCodeAmount
                };
            else
                sourceCode = null;

            if (ShippingDetail != null)
            {
                IShippingController shippingController = new ShippingController();
                ShippingDetail = shippingController.OrderShipping(ShippingDetail);
            }

            IOrderController orderController = new OrderController();
            bool indentedLineItemsAdded = false;
            // TODO: applying hook to the system all the indented line items will be attached to the first order item.
            foreach (var orderable in orderables)
            {
                if (!indentedLineItemsAdded)
                {
                    orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                           sourceCode,
                                           eventCustomer, ShippingDetail, OrderStatusState.FinalSuccess);
                    indentedLineItemsAdded = true;
                }
                else
                    orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                            OrderStatusState.FinalSuccess);
            }

            if (order == null)
                order = orderController.PlaceOrder(OrderType.Retail, creatorOrganizationRoleUser.Id);
            else
                order = orderController.ActivateOrder(order);
            SaveProductShippingDetail(order);

            if (RegistrationFlow.IsRetest)
            {
                var eventCustomerRetestRepository = IoC.Resolve<IEventCustomerRetestRepository>();
                eventCustomerRetestRepository.DeleteByEventCustomerId(eventCustomer.Id);

                var package = IoC.Resolve<IEventPackageRepository>().GetPackageForOrder(order.Id);
                var eventTests = IoC.Resolve<IEventTestRepository>().GetTestsForOrder(order.Id);

                if (package != null)
                    eventTests = eventTests.Concat(package.Tests.ToArray());

                var testIds = eventTests.Select(et => et.TestId).Distinct().ToArray();

                if (!testIds.IsNullOrEmpty())
                {
                    eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, testIds, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);
                }
            }

            return true;
        }

        private void SaveProductShippingDetail(Core.Finance.Domain.Order order)
        {
            if (ProductId.HasValue && ProductId.Value > 0)
            {
                var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                var shippingOption = shippingOptionRepository.GetShippingOptionByProductId(ProductId.Value);

                if (shippingOption == null || ShippingDetail == null)
                    return;

                IOrderController orderController = new OrderController();
                OrderDetail orderDetail = orderController.GetActiveOrderDetail(order);

                if (shippingOption.Id == ShippingDetail.ShippingOption.Id)
                    return;
                var productShippingDetail = ShippingDetail;

                productShippingDetail.Id = 0;
                productShippingDetail.ShippingAddress.Id = 0;
                productShippingDetail.ShippingOption.Id = shippingOption.Id;
                productShippingDetail.ActualPrice = shippingOption.Price;

                if (orderDetail != null)
                {
                    IShippingController shippingController = new ShippingController();
                    productShippingDetail = shippingController.OrderShipping(productShippingDetail);

                    IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository =
                        new ShippingDetailOrderDetailRepository();

                    var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                    {
                        Amount = productShippingDetail.ActualPrice,
                        IsActive = true,
                        OrderDetailId = orderDetail.Id,
                        ShippingDetailId = productShippingDetail.Id
                    };

                    shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
                }

            }
        }

        private OrganizationRoleUser GetForOrganizationRoleUser()
        {
            return new OrganizationRoleUser(CustomerId);
        }

        private OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(UserSessionModel.CurrentOrganizationRole, UserSessionModel.UserId);
        }

        private EventCustomer SaveEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);

            var eventCustomer = new EventCustomer
                                    {
                                        AppointmentId = appointment.Id,
                                        EventId = EventId,
                                        CustomerId = CustomerId,
                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                   {
                                                                       DataRecorderCreator = organizationRoleUser,
                                                                       DateCreated = DateTime.Now
                                                                   },
                                        OnlinePayment = false,
                                        MarketingSource = MarketingSource,
                                        NoShow = false,
                                        LeftWithoutScreeningReasonId = null,
                                        LeftWithoutScreeningNotesId = null,
                                        TestConducted = false,
                                        HIPAAStatus = RegulatoryState.Unknown,
                                        PcpConsentStatus = RegulatoryState.Unknown,
                                        AwvVisitId = (RegistrationFlow.AwvVisitId.HasValue ? RegistrationFlow.AwvVisitId.Value : (long?)null),
                                        EnableTexting = CurrentCustomer.EnableTexting,
                                        IsForRetest = RegistrationFlow.IsRetest,
                                        PreferredContactType = CurrentCustomer.PreferredContactType,
                                        SingleTestOverride = RegistrationFlow.SingleTestOverride
                                    };

            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            eventCustomer = itemRepository.Save(eventCustomer);

            return eventCustomer;
        }

        private EventCustomer UpdateEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            IEventCustomerRepository eventCustomerRepository = new EventCustomerRepository();
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            try
            {
                var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(CustomerId, EventId);
                var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);
                eventCustomer.AppointmentId = appointment.Id;
                eventCustomer.NoShow = false;
                eventCustomer.LeftWithoutScreeningReasonId = null;
                eventCustomer.LeftWithoutScreeningNotesId = null;
                eventCustomer.IsForRetest = RegistrationFlow.IsRetest;
                eventCustomer.SingleTestOverride = RegistrationFlow.SingleTestOverride;

                if (RegistrationFlow.AwvVisitId.HasValue && !eventCustomer.AwvVisitId.HasValue)
                    eventCustomer.AwvVisitId = RegistrationFlow.AwvVisitId.Value;
                eventCustomer.EnableTexting = CurrentCustomer.EnableTexting;
                eventCustomer.PreferredContactType = CurrentCustomer.PreferredContactType;
                eventCustomer.ConfirmedBy = null;
                eventCustomer.IsAppointmentConfirmed = false;
                IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
                eventCustomer = itemRepository.Save(eventCustomer);

                return eventCustomer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Core.Finance.Domain.Order GetOrder()
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(CustomerId, EventId);
        }

        private void SetSourceCodeData(decimal orderTotal)
        {
            var testIds = OrderSummaryControl.SelectedAddOnTests.Select(t => t.Id);
            var productAmount = ProductId.HasValue && ProductId.Value > 0 ? ProductOption.ProductPrice : 0m;
            var shippingAmount = ShippingDetail != null ? ShippingDetail.ActualPrice : 0m;
            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(PackageId, testIds, orderTotal, SourceCode, EventId, CustomerId, SignUpMode.CallCenter, shippingAmount, productAmount);

            if (model.SourceCodeId < 1 && model.FeedbackMessage != null)
                SourceCodeAmount = decimal.Zero;
            else
                SourceCodeAmount = model.DiscountApplied;
        }

        private void UpdateProspectCustomer(long customerId)
        {
            var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
            var prospectCustomer = ((IProspectCustomerRepository)prospectCustomerRepository).GetProspectCustomerByCustomerId(customerId);
            if (prospectCustomer != null)
            {
                prospectCustomer.CustomerId = customerId;
                prospectCustomer.IsConverted = true;
                prospectCustomer.ConvertedOnDate = DateTime.Now;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                prospectCustomer.Tag = ProspectCustomerTag.CallCenterSignup;
                prospectCustomer.TagUpdateDate = DateTime.Now;

                prospectCustomerRepository.Save(prospectCustomer);
            }
        }

        private string SetCustomerTag(long eventId, DateTime eventDate)
        {
            var createdByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var customerService = IoC.Resolve<ICustomerService>();
            return customerService.SetCustomerTag(CurrentCustomer, eventId, createdByOrgRoleUserId, eventDate);

            //var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            //var account = corporateAccountRepository.GetbyEventId(EventId);
            //if (account != null && account.AllowPreQualifiedTestOnly)
            //{
            //    var createdByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            //    var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
            //    preApprovedTestRepository.SavePreApprovedTests(customerId, TestIds, createdByOrgRoleUserId);
            //}
        }

        private void UpdateCallStatus(long eventid)
        {
            var repository = new CallCenterCallRepository();
            if (CallId <= 0) return;

            ECall objCall = repository.GetCallCenterEntity(CallId);

            objCall.TimeEnd = DateTime.Now.ToString();
            objCall.EventID = eventid;
            var callcenterDal = new CallCenterDAL();
            callcenterDal.UpdateCall(objCall);
        }

        private void UpdateEventCustomerPreApprovedTest(long eventId, long customerId)
        {
            IoC.Resolve<IEventCustomerPreApprovedTestService>().UpdateEventCustomerPreApprovedTest(eventId, customerId);
        }

        private void UpdateEventCustomerIcdAndMedication(long eventId, long customerId)
        {
            IoC.Resolve<CustomerRegistrationService>().ExistingCustomerEventRegistrationTasks(eventId, customerId);
        }

        private void SendMailForNonTargetedMember()
        {
            try
            {
                if (CurrentCustomer != null && EventData != null)
                {
                    var customerTargetedRepository = IoC.Resolve<ICustomerTargetedRepository>();
                    var customerTargeted = customerTargetedRepository.GetByCustomerIdAndYear(CurrentCustomer.CustomerId, EventData.EventDate.Year);

                    if (AccountByEventId != null && (customerTargeted == null || !customerTargeted.IsTargated.HasValue || customerTargeted.IsTargated == false))
                    {
                        var notifier = IoC.Resolve<INotifier>();
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                        var nonTargetedMemberRegistrationNotificationViewModel = emailNotificationModelsFactory.GetNonTargetedMemberRegistrationNotificationViewModel(CurrentCustomer, EventData, AccountByEventId);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.NonTargetedMemberRegistrationNotification, EmailTemplateAlias.NonTargetedMemberRegistrationNotification, nonTargetedMemberRegistrationNotificationViewModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }
        }

        private bool CheckPreApprovedTest()
        {
            var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
            return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId, TestGroup.BreastCancer);
        }

        private void SendMailOnRegistrationOfMammoPatientOnNonMammoEvent()
        {
            try
            {
                if (CurrentCustomer != null && EventData != null)
                {
                    var customerHasMammo = CheckPreApprovedTest();
                    if (customerHasMammo)
                    {
                        var eventhasMammoTest = IoC.Resolve<IEventTestRepository>().EventHasMammoTests(EventData.Id);

                        if (!eventhasMammoTest)
                        {
                            var notifier = IoC.Resolve<INotifier>();
                            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                            var mammoNotificationModel = emailNotificationModelsFactory.GetMammoPatientRegestrationOnNonMammoEventViewModel(CurrentCustomer, EventData);
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.MammoPatientRegistrationOnNonMammoEventNotification, EmailTemplateAlias.MammoPatientRegistrationOnNonMammoEvent, mammoNotificationModel, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }
        }

        private void SendSingleTestOverrideNotification(long customerId, long eventId)
        {
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var notifier = IoC.Resolve<INotifier>();
            var singleTestOverrideNotificationModel = emailNotificationModelsFactory.GetSingleTestOverrideNotificationViewModel(customerId, eventId);

            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.SingleTestOverrideNotification, EmailTemplateAlias.SingleTestOverrideNotification, singleTestOverrideNotificationModel, 0, 1, Request.Url.AbsolutePath);
        }

        /*private void SavePreQualificationQuestionAnswer(long eventCustomerId)
        {
            if (RegistrationFlow != null && !string.IsNullOrEmpty(RegistrationFlow.QuestionIdAnswerTestId) && eventCustomerId > 0 && CustomerId > 0 && EventId > 0)
            {
                var _eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                _eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(RegistrationFlow.QuestionIdAnswerTestId, RegistrationFlow.DisqualifiedTest, eventCustomerId, CustomerId, EventId,
+                    UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);
            }
        }*/
    }
}
