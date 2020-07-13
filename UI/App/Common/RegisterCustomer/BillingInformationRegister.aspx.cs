using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical.ValueType;
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
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Scheduling.Services;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;

namespace Falcon.App.UI.App.Common.RegisterCustomer
{
    public partial class BillingInformation : PackageRegistrationPaymentCharger
    {
        #region "Properties"

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

        protected override long? CallId
        {
            get
            {
                return null;
            }
            set { }
        }

        protected override ViewType CurrentViewType
        {
            get { return ViewType.Technician; }
        }

        protected override long? PackageId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.PackageId > 0)
                    return RegistrationFlow.PackageId;
                return null;
            }
        }

        protected override long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
                return null;
            }
        }

        protected override List<long> TestIds
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

        protected override IEnumerable<long> AppointmentSlotIds
        {
            get
            {
                if (RegistrationFlow != null && !RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty())
                    return RegistrationFlow.AppointmentSlotIds;
                return null;
            }
        }

        protected override long? EventId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.EventId > 0)
                    return RegistrationFlow.EventId;
                return null;
            }
        }

        protected override long? CustomerId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                    return RegistrationFlow.CustomerId;
                return null;
            }
            set
            {
                RegistrationFlow.CustomerId = value.HasValue ? value.Value : 0;
            }
        }

        protected override decimal? TotalAmount
        {
            get
            {
                if (RegistrationFlow != null)
                    return RegistrationFlow.TotalAmount;
                return null;
            }
        }

        protected override string SourceCode
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCode : string.Empty;
            }
        }

        protected override long? SourceCodeId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.SourceCodeId > 0)
                    return RegistrationFlow.SourceCodeId;
                return null;
            }
        }

        protected override decimal SourceCodeAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeAmount : 0;
            }
        }

        protected override string MarketingSource
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.MarketingSource : string.Empty;
            }
        }

        protected override long? AppliedGiftCertificateId
        {
            get
            {
                long giftCertificateId;
                if (long.TryParse(GCApply.GiftCertificateId, out giftCertificateId))
                    return giftCertificateId;
                return null;
            }
        }

        protected override decimal? AppliedGiftCertificateBalanceAmount
        {
            get
            {
                decimal giftCertificateAppliedAmount;
                if (decimal.TryParse(GCApply.GiftCertificateBalanceAmount, out giftCertificateAppliedAmount))
                    return giftCertificateAppliedAmount;
                return null;
            }
        }

        protected override bool IsBillingAddressSameAsHomeAddress
        {
            get
            {
                return rbtBillingAddressY.Checked;
            }
            set
            {
                rbtBillingAddressY.Checked = value;
                rbtBillingAddressN.Checked = !value;
            }
        }


        protected override Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    if (!CustomerId.HasValue)
                        return null;
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                CustomerId = _customer.CustomerId;
                return _customer;
            }
        }

        protected override ShippingDetail ShippingDetail
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

        protected override DropDownList CountryCombo
        {
            get { return ddlCountry; }
        }

        protected override HiddenField StateHiddenField
        {
            get { return hfstate; }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return ddlCCType; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return ddlEAccountType; }
        }

        protected override DropDownList ChequeAccountTypeCombo
        {
            get { return ddlaccounttype; }
        }

        protected override ListControl PaymentMode
        {
            get { return ddlPayMode; }
        }

        protected override TextBox Address1TextBox
        {
            get { return txtAddress1; }
        }

        protected override TextBox Address2TextBox
        {
            get { return txtAddress2; }
        }

        protected override TextBox CityTextBox
        {
            get { return txtCity; }
        }

        protected override TextBox ZipTextBox
        {
            get { return txtZip; }
        }

        protected override TextBox PhoneTextBox
        {
            get { return txtHPhone; }
        }

        protected override TextBox CreditCardHolderNameTextBox
        {
            get { return txtCName; }
        }

        protected override TextBox CreditCardExpiryDateTextBox
        {
            get { return txtExpirationDate; }
        }

        protected override TextBox CreditCardNumberTextBox
        {
            get { return txtCCNo; }
        }

        protected override TextBox CreditCardSecurityNumberTextBox
        {
            get { return txtSequrityNo; }
        }

        protected override TextBox EChequeRoutingNumberTextBox
        {
            get { return txtERoutingNo; }
        }

        protected override TextBox EChequeAccountNumberTextBox
        {
            get { return txtEAccountNo; }
        }

        protected override TextBox EChequeBankNameTextBox
        {
            get { return txtEBankName; }
        }

        protected override TextBox EChequeAccountHolderNameTextBox
        {
            get { return txtEAccHolderName; }
        }

        protected override TextBox EChequeChequeNumberTextBox
        {
            get { return txtECheckNo; }
        }

        protected override TextBox ChequeRoutingNumberTextBox
        {
            get { return txtRoutingNum; }
        }

        protected override TextBox ChequeAccountNumberTextBox
        {
            get { return txtAccountNum; }
        }

        protected override TextBox ChequeBankNameTextBox
        {
            get { return txtBankName; }
        }

        protected override TextBox ChequeAccountHolderNameTextBox
        {
            get { return txtAccHolderName; }
        }

        protected override TextBox ChequeChequeNumberTextBox
        {
            get { return txtChequeNum; }
        }

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Customer"]))
                {
                    switch (Request.QueryString["Customer"])
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

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
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
        }

        protected override long? AwvVisitId
        {
            get { return RegistrationFlow.AwvVisitId; }
        }

        protected override decimal AmountTobePaid
        {
            get
            {
                if (AmountCoveredByInsurance > 0 && EligibilityId > 0 && RegistrationFlow != null)
                {
                    return RegistrationFlow.TotalAmount - AmountCoveredByInsurance + CoPayAmount;
                }
                return base.AmountTobePaid;
            }
        }

        protected override decimal AmountCoveredByInsurance
        {
            get
            {
                if (!string.IsNullOrEmpty(InsuranceAmountHiddenField.Value))
                {
                    decimal toBepaid = 0;
                    decimal.TryParse(InsuranceAmountHiddenField.Value, out toBepaid);
                    return toBepaid;
                }
                return 0;
            }
        }

        protected decimal CoPayAmount
        {
            get
            {
                if (!string.IsNullOrEmpty(CoPayAmountHiddenField.Value))
                {
                    decimal toBepaid = 0;
                    decimal.TryParse(CoPayAmountHiddenField.Value, out toBepaid);
                    return toBepaid;
                }
                return 0;
            }
        }

        protected override long EligibilityId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EligibilityId : 0;
            }
            set { RegistrationFlow.EligibilityId = value; }
        }

        protected bool IsTestCoveredByInsurance
        {
            get
            {
                return RegistrationFlow != null && RegistrationFlow.IsTestCoveredByInsurance;
            }
        }

        protected override long ChargeCardId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ChargeCardId : 0;
            }
            set { RegistrationFlow.ChargeCardId = value; }
        }

        protected override bool IsRetest
        {
            get { return RegistrationFlow != null && RegistrationFlow.IsRetest; }
        }

        protected override bool SingleTestOverride
        {
            get { return RegistrationFlow != null && RegistrationFlow.SingleTestOverride; }
        }

        private CorporateAccount _accountByEventId;
        private CorporateAccount AccountByEventId
        {
            get
            {
                if (_accountByEventId == null && EventId.HasValue && EventId > 0)
                {
                    _accountByEventId = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId.Value);
                }

                return _accountByEventId;
            }
        }

        private UserSessionModel _userSessionModel;
        private UserSessionModel UserSessionModel
        {
            get { return _userSessionModel ?? (_userSessionModel = IoC.Resolve<ISessionContext>().UserSession); }
        }

        private IEventRepository _eventRepository;
        private IEventRepository EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = IoC.Resolve<IEventRepository>());
            }
        }

        private Event _eventData = null;
        private Event EventData
        {
            get
            {
                if (EventId.HasValue)
                    return _eventData ?? (_eventData = EventRepository.GetById(EventId.Value));
                return null;
            }
        }
        #endregion

        protected override void SetDisplayControls()
        {
            var franchiseeTechnicianMasterPage = Master as Franchisee_Technician_TechnicianMaster;
            if (franchiseeTechnicianMasterPage != null)
            {
                franchiseeTechnicianMasterPage.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";

                if (CustomerType == CustomerType.Existing)
                {
                    franchiseeTechnicianMasterPage.settitle("Existing Customer");
                    dvTitle.InnerText = "Technician Existing Customer";
                }
                else
                {
                    imgSymbol.Src = "../../Images/CCRep/page4symbol.gif";
                    franchiseeTechnicianMasterPage.settitle("Register New Customer");
                    dvTitle.InnerText = "Technician Register Customer";
                }
            }
        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            errordiv.InnerHtml = errorMessage;
            errordiv.Visible = true;
            if (PaymentGatewayResponse != null)
            {
                if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
                {
                    spnRequestID.InnerText = PaymentGatewayResponse.TransactionCode;
                    pRequestID.Visible = true;
                    spnDecision.InnerText = PaymentGatewayResponse.Message;
                    pDecision.Visible = true;
                    spnReasonCode.InnerText = PaymentGatewayResponse.ResponseCode;
                    pReasonCode.Visible = true;
                }
            }
            ClientScript.RegisterStartupScript(typeof(string), "jscode_MaintainAfterFailedPostBack", "SetValuesafterFailedPostBack();", true);
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        protected override bool IsOnSitePayment
        {
            get { return PaymentMode.SelectedItem.Value == PaymentType.Onsite_Value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EventId.HasValue)
            {
                OrderSummaryControl.EventId = EventId.Value;
                OrderSummaryControl.RoleId = (long)Roles.Technician;
                OrderSummaryControl.PackageId = PackageId.HasValue ? PackageId.Value : 0;
                OrderSummaryControl.TestIds = TestIds;
                OrderSummaryControl.IsSourceCodeApplied = SourceCodeId > 0;
                OrderSummaryControl.SourceCodeAmount = SourceCodeAmount;
                if (!AppointmentSlotIds.IsNullOrEmpty())
                {
                    var slotService = IoC.Resolve<IEventSchedulingSlotService>();
                    var slot = slotService.GetHeadSlotintheChain(AppointmentSlotIds);
                    OrderSummaryControl.AppointmentTime = slot.StartTime.ToString("hh:mm tt");
                }
                if (ProductId.HasValue && ProductId.Value > 0)
                {
                    IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                    var product = itemRepository.GetById(ProductId.Value);
                    OrderSummaryControl.ProductName = product.Name;
                    OrderSummaryControl.ProductPrice = product.Price;
                }
                if (ShippingDetail != null && ShippingDetail.ShippingOption != null && ShippingDetail.ShippingOption.Id > 0)
                {
                    IUniqueItemRepository<ShippingOption> itemRepository = new ShippingOptionRepository();
                    var shippingOption = itemRepository.GetById(ShippingDetail.ShippingOption.Id);
                    OrderSummaryControl.ShippingOption = shippingOption.Name;
                    OrderSummaryControl.ShippingOptionPrice = ShippingDetail.ActualPrice;
                }
            }
            if (!IsPostBack)
            {
                if (EventId.HasValue)
                    hfEventID.Value = EventId.Value.ToString();
                else
                {
                    SetAndDisplayErrorMessage("OOPS! Some error occured while saving details.");
                    return;
                }
                if (TotalAmount.HasValue)
                    hfNetPayableAmount.Value = TotalAmount.ToString();
                else
                {
                    SetAndDisplayErrorMessage("OOPS! Some error occured while saving details.");
                    return;
                }
                EligibilityIdHiddenField.Value = EligibilityId.ToString();
                ChargeCardIdHiddenField.Value = ChargeCardId.ToString();
                if (ChargeCardId > 0)
                    GetCreditCardDataByChargeCardId(ChargeCardId);
                BindJavaScriptEvents();
            }
            else
            {
                if (PostBackAction())
                {
                    EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
                    ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);
                    PersistPaymentData();
                }
            }
        }

        private ShippingDetail GetShippingDetailData(long shippingOptionId, long shippingAddressId)
        {
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var addressRepository = IoC.Resolve<IAddressRepository>();

            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(),
                DataRecorderMetaData =
                    new DataRecorderMetaData
                    {
                        DataRecorderCreator =
                            organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                        ,
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

        private bool PostBackAction()
        {
            return Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "save";
        }

        private void BindJavaScriptEvents()
        {
            rbtBillingAddressY.Attributes["onClick"] = "return CheckBillingAddress()";
            rbtBillingAddressN.Attributes["onClick"] = "return CheckBillingAddress()";
            ddlPayMode.Attributes["onChange"] = "return ShowHide();";
            txtCCNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
            txtSequrityNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
        }

        private void PersistPaymentData()
        {
            bool doEventRegistrationRedirect = false;
            try
            {
                doEventRegistrationRedirect = SaveRegistrationPayment();
            }
            catch (Exception ex)
            {
                if (RegistrationFlow != null)
                    RegistrationFlow.ShippingDetailId = 0;
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                doEventRegistrationRedirect = false;
            }

            if (doEventRegistrationRedirect)
            {
                if (!CustomerId.HasValue || !EventId.HasValue)
                    return;

                Mail();

                SendMailForIneligibleCustomer();

                UpdateProspectCustomer(CustomerId.Value);

                UpdateEventCustomerPreApprovedTest(EventId.Value, CustomerId.Value);

                UpdateEventCustomerIcdAndMedication(EventId.Value, CustomerId.Value);
                SendMailOnRegistrationOfMammoPatientOnNonMammoEvent();
                try
                {
                    //var eventRepository = IoC.Resolve<IEventRepository>();
                    //var eventData = eventRepository.GetById(EventId.Value);

                    var customerService = IoC.Resolve<ICustomerService>();
                    var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                    var previousTag = customerService.SetCustomerTag(Customer, EventId.Value, creatorOrganizationRoleUser.Id, EventData.EventDate);
                    //var previousTag = Customer.Tag;
                    TagUpdatedMail(previousTag);

                    var futureAppointment = new FutureAppointmentFlagViewModel
                    {
                        CustomerId = CustomerId.Value,
                        HasFutureAppointment = true,
                        FutureAppointmentDate = EventData.EventDate
                    };

                    IoC.Resolve<ICallQueueCustomerPublisher>().UpdateFutreAppointmentFlag(futureAppointment);
                }
                catch (Exception ex)
                {

                    var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                    logger.Error("some Error Occurred While Updating future Customers");
                    logger.Error("Message: " + ex.Message);
                    logger.Error("Stack Trace: " + ex.StackTrace);
                }
                SendMailForNonTargetedMember();

                SavePreQualificationQuestionAnswer();

                if (CallId.HasValue && CallId.Value > 0)
                {
                    var callCenterCallRepository = IoC.Resolve<Falcon.App.Core.Deprecated.ICallCenterCallRepository>();
                    callCenterCallRepository.SaveCallDispositionAndIsContacted(CallId.Value, ProspectCustomerTag.BookedAppointment.ToString(), RegistrationFlow.CallQueueCustomerId);
                }

                Session["PCPSearchCustomerState"] = Customer.Address.State;
                var eventService = IoC.Resolve<IEventService>();
                var selectedEvent = eventService.GetById(EventId.Value);
                if (selectedEvent != null)
                    Session["PCPSearchEventState"] = selectedEvent.State;

                RegistrationFlow.SourceCodeId = 0;
                RegistrationFlow.SourceCode = string.Empty;
                RegistrationFlow.SourceCodeAmount = 0;
                RegistrationFlow.ProductId = 0;
                RegistrationFlow.ShippingDetailId = 0;
                RegistrationFlow.ShippingOptionId = 0;
                RegistrationFlow.ShippingAddressId = 0;

                var setting = IoC.Resolve<ISettings>();
                if (setting.CapturePrimaryCarePhysician)
                {
                    Response.RedirectUser(CustomerType == CustomerType.Existing
                                          ? "PrimaryCarePhysician.aspx?Customer=Existing" + "&guid=" + GuId
                                          : "PrimaryCarePhysician.aspx?guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser(CustomerType == CustomerType.Existing
                                          ? "../AddNotes.aspx?Customer=Existing" + "&guid=" + GuId
                                          : "../AddNotes.aspx?guid=" + GuId);
                }
            }
        }

        private void TagUpdatedMail(string previousTag)
        {
            if (previousTag.Trim() == string.Empty)
                return;
            try
            {
                IEventCustomerRepository itemRepository = new EventCustomerRepository();
                var eventCustomer = itemRepository.GetCustomersPreviousEventId(EventId.Value, CustomerId.Value);
                var oldEventId = eventCustomer != null ? eventCustomer.EventId : 0;
                if (oldEventId != EventId.Value)
                {
                    var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                    var emailNotification = emailNotificationModelsFactory.GetCustomerTagChangeNotificationViewModel(oldEventId, EventId.Value, CustomerId.Value, previousTag);
                    var notifier = IoC.Resolve<INotifier>();
                    var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                    if (emailNotification.PreviousTag != emailNotification.NewTag)
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerTagUpdated, EmailTemplateAlias.CustomerTagUpdated, emailNotification, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "Technician Event Registration");
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
            }
        }

        private void SendMailForIneligibleCustomer()
        {
            try
            {
                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customer = customerRepository.GetCustomer(CustomerId.Value);
                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();
                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);

                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                //var eventRepository = IoC.Resolve<IEventRepository>();

                if (customerEligibility != null && customerEligibility.IsEligible.HasValue && !customerEligibility.IsEligible.Value)
                {
                    //var eventData = eventRepository.GetById(EventId.Value);
                    var inEligibleCustomerAppointmentNotificationViewModel = emailNotificationModelsFactory.GetIneligibleCustomerAppointmentNotificationViewModel(customer, EventData);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.IneligibleCustomerAppointmentNotification, EmailTemplateAlias.IneligibleCustomerAppointment, inEligibleCustomerAppointmentNotificationViewModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }
        }

        private void Mail()
        {
            try
            {
                if (!EventId.HasValue || EventId.Value == 0 || !CustomerId.HasValue || CustomerId.Value == 0)
                    return;

                //var eventRepository = IoC.Resolve<IEventRepository>();
                //var eventData = eventRepository.GetById(EventId.Value);

                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customer = customerRepository.GetCustomer(CustomerId.Value);

                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
                customerRegistrationService.SendAppointmentConfirmationMail(customer, EventData, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath, AccountByEventId);

                //If somebody registered within 24 hours of the event Date then send notification.
                if (EventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
                {
                    var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(EventId.Value, CustomerId.Value);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
                }
                catch
                {

                }
            }

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
            ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);

            Response.RedirectUser("SelectAppointment.aspx?Back=true&" + (EventId.HasValue
                                                           ? "EventID=" + EventId.Value
                                                           : CustomerType == CustomerType.Existing
                                                                 ? "Customer=Existing"
                                                                 : string.Empty) + "&guid=" + GuId);
        }

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
            // This button click event code was moved in javascript postback function.
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

                prospectCustomerRepository.Save(prospectCustomer);
            }
        }

        private void GetCreditCardDataByChargeCardId(long chargeCardId)
        {
            var chargeCardRepository = IoC.Resolve<IChargeCardRepository>();
            var chargeCard = chargeCardRepository.GetById(chargeCardId);

            txtCName.Text = chargeCard.NameOnCard;
            txtCCNo.Text = chargeCard.Number;
            ddlCCType.SelectedValue = ((int)chargeCard.TypeId).ToString();
            txtExpirationDate.Text = chargeCard.ExpirationDate.ToString("MM/yyyy");
            txtSequrityNo.Text = chargeCard.CVV;
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
                if (Customer != null && EventData != null)
                {
                    var customerTargetedRepository = IoC.Resolve<ICustomerTargetedRepository>();
                    var customerTargeted = customerTargetedRepository.GetByCustomerIdAndYear(Customer.CustomerId, DateTime.Today.Year);

                    if (AccountByEventId != null && (customerTargeted == null || !customerTargeted.IsTargated.HasValue || customerTargeted.IsTargated == false))
                    {
                        var notifier = IoC.Resolve<INotifier>();
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                        var nonTargetedMemberRegistrationNotificationViewModel = emailNotificationModelsFactory.GetNonTargetedMemberRegistrationNotificationViewModel(Customer, EventData, AccountByEventId);
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
            return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId.Value, TestGroup.BreastCancer);
        }

        private void SendMailOnRegistrationOfMammoPatientOnNonMammoEvent()
        {
            try
            {
                if (Customer != null && EventData != null)
                {
                    var customerHasMammo = CheckPreApprovedTest();
                    if (customerHasMammo)
                    {
                        var eventhasMammoTest = IoC.Resolve<IEventTestRepository>().EventHasMammoTests(EventData.Id);

                        if (!eventhasMammoTest)
                        {
                            var notifier = IoC.Resolve<INotifier>();
                            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                            var mammoNotificationModel = emailNotificationModelsFactory.GetMammoPatientRegestrationOnNonMammoEventViewModel(Customer, EventData);
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.MammoPatientRegistrationOnNonMammoEventNotification, EmailTemplateAlias.MammoPatientRegistrationOnNonMammoEvent, mammoNotificationModel, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }
        }

        private void SavePreQualificationQuestionAnswer()
        {
            if (RegistrationFlow != null && !string.IsNullOrEmpty(RegistrationFlow.QuestionIdAnswerTestId) && CustomerId != null && EventId != null)
            {
                var eventCsutomer = IoC.Resolve<IEventCustomerRepository>().Get(EventId.Value, CustomerId.Value);
                var eventCustomerQuestionAnswerService = IoC.Resolve<Core.Medical.IEventCustomerQuestionAnswerService>();
                eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(RegistrationFlow.QuestionIdAnswerTestId, RegistrationFlow.DisqualifiedTest, eventCsutomer.Id, CustomerId.Value, EventId.Value,
                    UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);
            }
        }
    }
}