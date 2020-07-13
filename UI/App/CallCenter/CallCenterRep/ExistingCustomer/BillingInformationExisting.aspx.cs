using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using System.Linq;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Infrastructure.Scheduling.Services;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class BillingInformation : PackageRegistrationPaymentCharger
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

        #region "Properties"
        protected override long? CallId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                    return RegistrationFlow.CallId;
                return null;
            }
            set
            {
                RegistrationFlow.CallId = value.HasValue ? value.Value : 0;
            }
        }


        public bool IsGiftCertificate
        {
            get
            {
                return (!string.IsNullOrEmpty(Request.QueryString["gc"]) && Request.QueryString["gc"] == "gc");
            }
        }

        protected override ViewType CurrentViewType
        {
            get { return ViewType.CallCenterRep; }
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

        protected override long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
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

        protected override bool IsOnSitePayment
        {
            get
            {
                return chkOnsitePayment.Checked;
            }
        }

        protected override long? AwvVisitId
        {
            get { return RegistrationFlow.AwvVisitId; }
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
            get { return null; }
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
            get { return null; }
        }

        protected override TextBox ChequeAccountNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox ChequeBankNameTextBox
        {
            get { return null; }
        }

        protected override TextBox ChequeAccountHolderNameTextBox
        {
            get { return null; }
        }

        protected override TextBox ChequeChequeNumberTextBox
        {
            get { return null; }
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

        private Core.Finance.Domain.GiftCertificate _giftCertificate;
        private Core.Finance.Domain.GiftCertificate GiftCertificate
        {
            get
            {
                if (IsGiftCertificate && _giftCertificate == null && Session["GiftCertificateId"] != null)
                {
                    long id = 0;
                    long.TryParse(Session["GiftCertificateId"].ToString(), out id);
                    _giftCertificate = IoC.Resolve<IGiftCertificateRepository>().GetById(id);
                }
                return _giftCertificate;
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

        protected override decimal AmountTobePaid
        {
            get
            {
                if (!string.IsNullOrEmpty(AmountTobePaidTextbox.Text))
                {
                    decimal toBepaid = 0;
                    decimal.TryParse(AmountTobePaidTextbox.Text, out toBepaid);
                    return toBepaid;
                }
                return base.AmountTobePaid;
            }
        }

        protected decimal PackageCost
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageCost : 0;
            }
        }

        private ProspectCustomer CurrentProspectCustomer
        {
            get
            {
                var prospectCustomerId = RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;

                if (prospectCustomerId > 0)
                {
                    var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                    return prospectCustomerRepository.GetById(Convert.ToInt64(prospectCustomerId));
                }
                return null;
            }
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
            Page.Title = "Payment Details ";
            var obj = (CallCenter_CallCenterMaster1)Master;

            obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            obj.hideucsearch();
            if (rbtBillingAddressN.Checked)
            {
                DVAddress.Style.Add(HtmlTextWriterStyle.Display, "block");
                DVAddress.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            }
            else
            {
                DVAddress.Style.Add(HtmlTextWriterStyle.Display, "none");
                DVAddress.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
            if (CustomerType == CustomerType.Existing)
            {
                obj.SetTitle("Existing Customer");
                StepTitleContainer.InnerText = "Existing Customer";
            }
            else
            {
                obj.SetTitle("Register New Customer");
                StepTitleContainer.InnerText = "Register New Customer";
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
                    spnRequestID.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.TransactionCode);
                    pRequestID.Visible = true;
                    spnDecision.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.Message);
                    pDecision.Visible = true;
                    spnReasonCode.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.ResponseCode);
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

        protected bool DoNotAllowPrePayment { get; set; }

        protected override bool IsRetest
        {
            get { return RegistrationFlow != null && RegistrationFlow.IsRetest; }
        }

        protected override bool SingleTestOverride
        {
            get { return RegistrationFlow != null && RegistrationFlow.SingleTestOverride; }
        }

        private UserSessionModel _userSessionModel;
        private UserSessionModel UserSessionModel
        {
            get { return _userSessionModel ?? (_userSessionModel = IoC.Resolve<ISessionContext>().UserSession); }
        }

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {

            if (EventId.HasValue && !IsGiftCertificate)
            {
                hfEventID.Value = EventId.Value.ToString();
                OrderSummaryControl.EventId = EventId.Value;
                OrderSummaryControl.RoleId = (long)Roles.CallCenterRep;
                OrderSummaryControl.PackageId = PackageId.HasValue ? PackageId.Value : 0;
                OrderSummaryControl.TestIds = TestIds;
                OrderSummaryControl.IsSourceCodeApplied = SourceCodeId > 0;
                OrderSummaryControl.SourceCodeAmount = SourceCodeAmount;


                var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                var appointments = appointmentRepository.GetAllAppointmentsForEvent(EventId.Value);
                DateTime? maxBookedSlotTime;
                try
                {
                    maxBookedSlotTime =
                    appointments.Select(ap => ap.StartTime).Max();
                }
                catch
                {
                    maxBookedSlotTime = null;
                }


                if (!AppointmentSlotIds.IsNullOrEmpty())
                {
                    var slotService = IoC.Resolve<IEventSchedulingSlotService>();
                    var slot = slotService.GetHeadSlotintheChain(AppointmentSlotIds);
                    OrderSummaryControl.AppointmentTime = slot.StartTime.ToString("hh:mm tt");

                    if (maxBookedSlotTime.HasValue && maxBookedSlotTime.Value.AddHours(1) < slot.StartTime)
                    {
                        PrepayDiv.Style.Add(HtmlTextWriterStyle.Display, "block");

                        PrepayTooltipText.InnerHtml = "The last booked appointment for this event is at  " + HttpUtility.HtmlEncode(maxBookedSlotTime.Value.ToShortTimeString()) + ". It is recommend that the customer should pre pay for this appointment, or you can go back and select another appointment slot.";
                    }
                    else
                    {
                        PrepayDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
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

                OrderSummaryDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                TotalBillingAmountP.Style.Add(HtmlTextWriterStyle.Display, "none");

                var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = accountRepository.GetbyEventId(EventId.Value);
                //var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                //var awvTests = eventTestRepository.GetByEventAndTestIds(EventId.Value, new[] { (long)TestType.AWV, (long)TestType.Medicare, (long)TestType.AwvSubsequent });
                if (account != null && !account.AllowPrePayment)
                {
                    DoNotAllowPrePayment = !account.AllowPrePayment;
                    chkOnsitePayment.Checked = !account.AllowPrePayment;
                }
            }

            if (!IsPostBack)
            {

                if (SourceCodeId > 0 && !string.IsNullOrEmpty(SourceCode))
                {
                    txtCouponCode.Text = SourceCode;
                }

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId.Value);
                }

                if (IsGiftCertificate)
                {
                    chkOnsitePayment.Visible = false;
                    var giftCertificate = GiftCertificate;

                    dvTotalAmount.InnerText = giftCertificate.Price.ToString("0.00");
                    GiftCertificateAmount.InnerText = giftCertificate.Price.ToString("0.00");
                    FillBillingAddressforGiftCertificate();
                    GCApply.Visible = false;
                    // TODO: TO implement Back Button Functionality.
                    imgBack.Visible = false;
                    StepTitleContainer.InnerText = "Step 3: Gift Certificate Check out - Payment";
                    StepSymbolDiv.Style[HtmlTextWriterStyle.Display] = "none";
                    OrderSummaryDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    PrepayDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    TotalBillingAmountP.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                else
                {
                    dvTotalAmount.InnerText = TotalAmount.ToString();
                    chkOnsitePayment.Attributes["onClick"] = "return OnsitePayment()";
                    EligibilityIdHiddenField.Value = EligibilityId.ToString();
                    ChargeCardIdHiddenField.Value = ChargeCardId.ToString();
                    if (ChargeCardId > 0)
                        GetCreditCardDataByChargeCardId(ChargeCardId);
                }
                BindJavaScriptEvents();
                GetCreditCardDataFromSession();
            }
            else
            {
                if (PostBackAction())
                {
                    if (Request.QueryString["gc"] == "gc")
                        SaveGiftCertificateOrder();
                    else
                    {
                        EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
                        ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);

                        if (!string.IsNullOrEmpty(txtCouponCode.Text))
                        {
                            SetSourceCodeData(OrderTotal);
                            RegistrationFlow.TotalAmount = OrderTotal - SourceCodeAmount - AmountCoveredByInsurance + CoPayAmount;

                            SaveProspectCustomer();
                        }
                        else
                        {
                            RegistrationFlow.SourceCodeId = 0;
                            RegistrationFlow.SourceCode = string.Empty;
                            RegistrationFlow.SourceCodeAmount = 0;
                            RegistrationFlow.TotalAmount = OrderTotal - SourceCodeAmount - AmountCoveredByInsurance + CoPayAmount;
                        }
                        if (AmountPercentageSelect.SelectedIndex == AmountPercentageSelect.Items.Count - 1)
                        {
                            AmountTobePaidTextbox.Text = AmountPercentageSelect.Value;
                        }
                        else
                        {
                            var amountPayable = TotalAmount.HasValue ? ((TotalAmount.Value * Convert.ToInt32(AmountPercentageSelect.Value)) / 100) : 0;
                            AmountTobePaidTextbox.Text = amountPayable.ToString("0.00");
                        }

                        PersistPaymentData();
                    }
                }
            }

        }

        protected decimal OrderTotal
        {
            get
            {
                IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                return PackageCost + (ProductId.HasValue && ProductId.Value > 0 ? itemRepository.GetById(ProductId.Value).Price : 0m) +
                 (ShippingDetail != null ? ShippingDetail.ActualPrice : 0m);
            }
        }
        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
            ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                    Response.RedirectUser("SelectAppointment.aspx?Back=true&CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId);
                else if (Request.QueryString["CustomerID"] != null)
                    Response.RedirectUser("SelectAppointment.aspx?Back=true&CustomerID=" + Request.QueryString["CustomerID"] + "&Call=No" + "&guid=" + GuId);
                else
                    Response.RedirectUser("SelectAppointment.aspx?Back=true&Call=No" + "&guid=" + GuId);
            }
            else
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                    Response.RedirectUser("SelectAppointment.aspx?Back=true&CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                else if (Request.QueryString["CustomerID"] != null)
                    Response.RedirectUser("SelectAppointment.aspx?Back=true&CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId);
                else
                    Response.RedirectUser("SelectAppointment.aspx?Back=true" + "&guid=" + GuId);
            }

        }

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        { }

        /// <summary>
        /// End the call without saving the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {
            var commoncode = new CommonCode();
            commoncode.EndCCRepCall(Page);
        }

        #endregion

        #region Methods

        // TODO: This method contains Repeated code. Need to be removed from here
        private void FillBillingAddressforGiftCertificate()
        {

            var customer = Customer;

            txtAddress1.Text = customer.Address.StreetAddressLine1;
            txtAddress2.Text = customer.Address.StreetAddressLine2;
            ListItem itemSelectedState = ddlState.Items.FindByText(customer.Address.State);
            if (itemSelectedState != null)
            {
                ddlState.SelectedIndex = -1;
                itemSelectedState.Selected = true;
            }

            txtCity.Text = customer.Address.City;

            var commonCode = new CommonCode();

            txtHPhone.Text = commonCode.FormatPhoneNumberGet(customer.HomePhoneNumber.DomesticPhoneNumber);
            txtZip.Text = customer.Address.ZipCode.Zip;

            rbtBillingAddressY.Checked = true;
            rbtBillingAddressN.Checked = false;


        }

        // TODO: This method contains Repeated code. Need to be removed from here
        private void SaveGiftCertificateOrder()
        {
            bool isSaveSuccessful;

            if (rbtBillingAddressN.Checked)
            {
                Customer.BillingAddress = new Address
                                              {
                                                  StreetAddressLine1 = txtAddress1.Text,
                                                  StreetAddressLine2 = txtAddress2.Text,
                                                  State = StateHiddenField.Value,
                                                  City = txtCity.Text,
                                                  ZipCode = new ZipCode { Zip = txtZip.Text },
                                                  Country = "USA"
                                              };
            }
            var creatorOrganizationRoleUser =
               IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                   IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                   IoC.Resolve<ISessionContext>().UserSession.UserId);

            var customerService = IoC.Resolve<ICustomerService>();
            isSaveSuccessful = customerService.SaveCustomer(Customer, creatorOrganizationRoleUser.Id);

            if (!isSaveSuccessful)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return;
            }


            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var forOrganizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(Customer.CustomerId);

            GiftCertificate.DataRecorderMetaData = new DataRecorderMetaData
                                                       {
                                                           DataRecorderCreator = creatorOrganizationRoleUser,
                                                           DateCreated = DateTime.Now
                                                       };

            IGiftCertificateRepository giftCertificateRepository = new GiftCertificateRepository();

            try
            {

                giftCertificateRepository.Save(GiftCertificate);
                giftCertificateRepository.ActivateGiftCertificate(GiftCertificate.Id);
            }
            catch (Exception)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return;
            }

            IOrderController orderController = new OrderController();
            orderController.AddItem(GiftCertificate, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id);
            var order = orderController.PlaceOrder(OrderType.Retail, creatorOrganizationRoleUser.Id);

            if (order == null || order.Id < 1)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return;
            }

            // TODO: To Implement in this a Service Class in Core.
            string customerReference = GiftCertificate.ClaimCode;

            long paymentId = 0;

            if (ddlPayMode.SelectedItem.Value == PaymentType.ElectronicCheck.PersistenceLayerId.ToString())
                paymentId = ManageCheckPayment(customerReference, GiftCertificate.Price, Customer, creatorOrganizationRoleUser);
            else
                paymentId = ManageChargeCardPayment(customerReference, GiftCertificate.Price, Customer.Email != null ? Customer.Email.ToString() : string.Empty, creatorOrganizationRoleUser);


            if (paymentId < 1)
            {
                return;
            }

            IOrderItemStatusFactory orderItemStatusFactory = new OrderItemStatusFactory();

            IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
            order.OrderDetails.ForEach(
                orderDetail =>
                orderDetail.OrderItemStatus =
                orderItemStatusFactory.CreateOrderItemStatus(GiftCertificate.OrderItemType,
                                                             (int)OrderStatusState.Initial));

            orderDetailRepository.SaveOrderDetails(order.OrderDetails);

            var orderRepository = new OrderRepository();
            orderRepository.ApplyPaymentToOrder(order.Id, paymentId);

            var notifier = IoC.Resolve<INotifier>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            var acknowledgmentmail = emailNotificationModelsFactory.GetGiftCertificateNotificationModel(GiftCertificate.ClaimCode, GiftCertificate.FromName, GiftCertificate.ToName, GiftCertificate.Message, GiftCertificate.Price);
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.GiftCertificateAcknowledgmentEmail, EmailTemplateAlias.GiftCertificateAcknowledgmentEmail, acknowledgmentmail, Customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

            Response.RedirectUser("/App/CallCenter/CallCenterRep/GiftCertificate/EmailSample.aspx?guid=" + GuId);
        }

        // TODO: This method contains Repeated code. Need to be removed from here
        private long ManageChargeCardPayment(string customerReference, decimal amount, string email,
                                             OrganizationRoleUser organizationRoleUser)
        {
            var paymentGateway = IoC.Resolve<IPaymentProcessor>();

            string[] expiryDateParts = txtExpirationDate.Text.Split("/".ToArray());
            int expiryMonth = int.Parse(expiryDateParts[0]);
            int expiryYear = int.Parse(expiryDateParts[1]);

            string countrycode = GetCountryCode(Convert.ToInt32(ddlCountry.SelectedItem.Value));
            string statecode = GetStateCode(hfstate.Value);

            Name name = new NameParser().ParseName(txtCName.Text);

            var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
            {
                CreditCardNo = txtCCNo.Text,
                SecurityCode = txtSequrityNo.Text,
                ExpiryMonth = expiryMonth,
                ExpiryYear = expiryYear,
                CardType = ddlCCType.SelectedItem.Text,
                Price = amount.ToString(),
                FirstName = name.FirstName,
                LastName = name.LastName,
                BillingAddress = txtAddress1.Text,
                BillingCity = txtCity.Text,
                BillingState = statecode,
                BillingPostalCode = txtZip.Text,
                BillingCountry = countrycode,
                Email = email,
                IpAddress = Request.ServerVariables["REMOTE_ADDR"],
                Currency = "USD",
                OrderId = customerReference
            };

            PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);

            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                errordiv.InnerText = "Sorry, payment request from your credit card was rejected by our payment gateway. Please check given details.";
                errordiv.Visible = true;
                return 0;
            }

            // TODO: To implement it in a controller class
            var chargeCard = new ChargeCard
                                 {
                                     TypeId = GetSelectedChargeCard(),
                                     NameOnCard = txtCName.Text,
                                     CVV = txtSequrityNo.Text,
                                     Number = txtCCNo.Text,
                                     DataRecorderMetaData =
                                         new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
                                     ExpirationDate = Convert.ToDateTime(txtExpirationDate.Text),
                                     IsDebit = false
                                 };

            var cardPayment = new ChargeCardPayment
                                  {
                                      Amount = amount,
                                      ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
                                      DataRecorderMetaData =
                                          new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
                                      ProcessorResponse = PaymentGatewayResponse.RawResponse
                                  };

            //TODO: Pull this code to PaymentController. 
            IPaymentRepository paymentRepository = new PaymentRepository();
            var payment = new Payment
                              {
                                  Notes = "Payment",
                                  DataRecorderMetaData =
                                      new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now }
                              };
            payment = paymentRepository.Save(payment);

            if (payment == null || payment.Id < 1)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return 0;
            }

            cardPayment.PaymentId = payment.Id;

            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
            chargeCard = chargeCardRepository.Save(chargeCard);

            if (chargeCard == null || chargeCard.Id < 1)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return 0;
            }

            cardPayment.ChargeCardId = chargeCard.Id;

            ICombinedPaymentInstrumentRepository combinedPaymentInstrumentRepository =
                new Infrastructure.Repositories.Payment.CombinedPaymentInstrumentRepository();

            combinedPaymentInstrumentRepository.SavePaymentInstrument(cardPayment);
            LogAudit(ModelType.Edit, creditCardProcessorProcessingInfo, Customer.CustomerId);
            return payment.Id;
        }

        // TODO: This method contains Repeated code. Need to be removed from here
        private long ManageCheckPayment(string customerReference, decimal amount, Core.Users.Domain.Customer customer,
                                        OrganizationRoleUser organizationRoleUser)
        {
            var paymentGateway = IoC.Resolve<IPaymentProcessor>();

            var electronicCheckProcessorProcessingInfo = new ElectronicCheckProcessorProcessingInfo
            {
                OrderId =
                    customerReference,
                CustomerId = customer.CustomerId.ToString(),
                BankRoutingNumber = EChequeRoutingNumberTextBox.Text,
                BankAccountNumber = EChequeAccountNumberTextBox.Text,
                BankAccountType = EChequeAccountTypeCombo.SelectedItem.Text,
                BankAccountName = EChequeAccountHolderNameTextBox.Text,
                BankName = EChequeBankNameTextBox.Text,
                CheckType = "Web",
                CheckNumber = EChequeChequeNumberTextBox.Text,
                Price = amount.ToString(),
                FirstName =
                    customer.Name.FirstName,
                LastName =
                    customer.Name.LastName,
                BillingAddress =
                   Address1TextBox.Text,
                BillingCity =
                   CityTextBox.Text,
                BillingState =
                    GetStateCode(hfstate.Value),
                BillingPostalCode =
                    ZipTextBox.Text,
                BillingCountry =
                    GetCountryCode(Convert.ToInt32(ddlCountry.SelectedItem.Value)),
                Email =
                    customer.Email != null ? customer.Email.ToString() : string.Empty,
                PhoneNumber =
                    PhoneTextBox == null ? string.Empty : PhoneTextBox.Text,
                IpAddress =
                    Request.ServerVariables["REMOTE_ADDR"],
                Currency = "USD"
            };

            PaymentGatewayResponse = paymentGateway.ChargeECheck(electronicCheckProcessorProcessingInfo);

            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MaintainAfterFailedPostBack", "SetValuesafterFailedPostBack();", true);
                errordiv.InnerText = "Sorry, payment request from your eCheck is rejected by our payment gateway. Please check given details.";
                errordiv.Visible = true;
                return 0;
            }


            IPaymentRepository paymentRepository = new PaymentRepository();
            var payment = new Payment
                              {
                                  Notes = "Payment",
                                  DataRecorderMetaData =
                                      new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now }
                              };
            payment = paymentRepository.Save(payment);

            if (payment == null || payment.Id < 1)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return 0;
            }

            var check = new Check
                            {
                                AccountNumber = txtEAccountNo.Text,
                                Amount = amount,
                                BankName = txtEBankName.Text,
                                CheckNumber = txtECheckNo.Text,
                                DataRecorderMetaData =
                                    new DataRecorderMetaData
                                        {
                                            DataRecorderCreator = organizationRoleUser,
                                            DateCreated = DateTime.Now,
                                            DataRecorderModifier = organizationRoleUser,
                                            DateModified = DateTime.Now
                                        },
                                CheckDate = DateTime.Today,
                                RoutingNumber = txtERoutingNo.Text,
                                PayableTo = IoC.Resolve<ISettings>().CompanyName
                            };

            var echeckPayment = new ECheckPayment
                                    {
                                        Amount = amount,
                                        ECheck = check,
                                        PaymentId = payment.Id,
                                        ProcessorResponse = PaymentGatewayResponse.RawResponse,
                                        ECheckPaymentStatus = ECheckPaymentStatus.Accepted,
                                        DataRecorderMetaData =
                                            new DataRecorderMetaData
                                                {
                                                    DataRecorderCreator = organizationRoleUser,
                                                    DateCreated = DateTime.Now,
                                                    DataRecorderModifier = organizationRoleUser,
                                                    DateModified = DateTime.Now
                                                }

                                    };
            IECheckPaymentRepository echeckPaymentRepository = new ECheckPaymentRepository();
            echeckPayment = (ECheckPayment)echeckPaymentRepository.SavePaymentInstrument(echeckPayment);

            if (echeckPayment == null || echeckPayment.ECheckId < 1)
            {
                errordiv.InnerText = "OOPS! Some error occured while saving details.";
                errordiv.Visible = true;
                return 0;
            }
            LogAudit(ModelType.Edit, electronicCheckProcessorProcessingInfo, customer.CustomerId);
            return payment.Id;
        }

        private void BindJavaScriptEvents()
        {
            ddlPayMode.Attributes.Add("onChange", "checkPaymentMode()");
            rbtBillingAddressY.Attributes["onClick"] = "return CheckBillingAddress()";
            rbtBillingAddressN.Attributes["onClick"] = "return CheckBillingAddress()";
            txtCCNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
            txtSequrityNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
        }

        private void GetCreditCardDataFromSession()
        {
            txtCName.Text = RegistrationFlow.CreditCardName;
            txtCCNo.Text = RegistrationFlow.CreditCardNo;
            ddlCCType.SelectedValue = RegistrationFlow.CreditCardType.ToString();
            txtExpirationDate.Text = RegistrationFlow.CreditCardExpiry;
            txtSequrityNo.Text = RegistrationFlow.CreditCardCvv;
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

        private void SetCreditCardDataIntoSession()
        {
            RegistrationFlow.CreditCardName = txtCName.Text;
            RegistrationFlow.CreditCardNo = txtCCNo.Text;
            RegistrationFlow.CreditCardType = Convert.ToInt32(ddlCCType.SelectedValue);
            RegistrationFlow.CreditCardExpiry = txtExpirationDate.Text;
            RegistrationFlow.CreditCardCvv = txtSequrityNo.Text;
        }

        private bool PostBackAction()
        {
            return Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "save";
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
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details.");

                try
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
                }
                catch
                {

                }


                doEventRegistrationRedirect = false;
            }
            if (doEventRegistrationRedirect)
            {
                if (!CustomerId.HasValue || !EventId.HasValue)
                    return;

                Mail();
                SendMailOnRegistrationOfMammoPatientOnNonMammoEvent();
                SendMailForIneligibleCustomer();

                UpdateProspectCustomer(CustomerId.Value);

                UpdateEventCustomerPreApprovedTest(EventId.Value, CustomerId.Value);

                try
                {
                    var eventData = EventData;

                    var customerService = IoC.Resolve<ICustomerService>();
                    var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                    var previousTag = customerService.SetCustomerTag(Customer, EventId.Value, creatorOrganizationRoleUser.Id, eventData.EventDate);
                    //var previousTag = Customer.Tag;
                    TagUpdatedMail(previousTag);

                    var futureAppointment = new FutureAppointmentFlagViewModel
                    {
                        CustomerId = CustomerId.Value,
                        HasFutureAppointment = true,
                        FutureAppointmentDate = eventData.EventDate
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

                UpdateEventCustomerIcdAndMedication(EventId.Value, CustomerId.Value);
                SendMailForNonTargetedMember();

                SavePreQualificationQuestionAnswer();

                if (CallId.HasValue && CallId.Value > 0)
                {
                    var callCenterCallRepository = IoC.Resolve<Falcon.App.Core.Deprecated.ICallCenterCallRepository>();
                    callCenterCallRepository.SaveCallDispositionAndIsContacted(CallId.Value, ProspectCustomerTag.BookedAppointment.ToString(), RegistrationFlow.CallQueueCustomerId);
                }

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

                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                var healthAssessmentService = IoC.Resolve<IHealthAssessmentService>();
                healthAssessmentService.SaveClinicalQuestions(GuId, EventId.Value, CustomerId.Value, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if ((ddlPayMode.SelectedItem.Text == PaymentType.CreditCard.Name) && (chkOnsitePayment.Checked == false))
                    SetCreditCardDataIntoSession();
                var setting = IoC.Resolve<ISettings>();
                if (setting.CapturePrimaryCarePhysician)
                {
                    if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    {
                        if (Request.QueryString["CustomerID"] != null)
                            Response.RedirectUser("PrimaryCarePhysician.aspx?CustomerType=" + CustomerType + "&CustomerID=" + Request.QueryString["CustomerID"] + "&Call=No" + "&guid=" + GuId);
                        else
                            Response.RedirectUser("PrimaryCarePhysician.aspx?CustomerType=" + CustomerType + "&Call=No" + "&guid=" + GuId);
                    }
                    else
                    {
                        UpdateCallStatus(EventId.Value);
                        if (Request.QueryString["CustomerID"] != null)
                            Response.RedirectUser("PrimaryCarePhysician.aspx?CustomerType=" + CustomerType + "&CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId);
                        else
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
                        UpdateCallStatus(EventId.Value);

                        if (Request.QueryString["CustomerID"] != null)
                        {
                            Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=yes &CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                        }
                        else
                        {
                            Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=yes" + "&guid=" + GuId);
                        }
                    }
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
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerTagUpdated, EmailTemplateAlias.CustomerTagUpdated, emailNotification, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "CallCenter Event Registration");
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
                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();

                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(Customer.CustomerId, DateTime.Today.Year);
                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                if (customerEligibility != null && customerEligibility.IsEligible.HasValue && !customerEligibility.IsEligible.Value)
                {
                    var inEligibleCustomerAppointmentNotificationViewModel = emailNotificationModelsFactory.GetIneligibleCustomerAppointmentNotificationViewModel(Customer, EventData);
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

                //var customerRepository = IoC.Resolve<ICustomerRepository>();
                //var customer = customerRepository.GetCustomer(CustomerId.Value);

                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();



                var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
                customerRegistrationService.SendAppointmentConfirmationMail(Customer, EventData, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath, AccountByEventId);

                //If somebody registered within 24 hours of the event Date then send notification.
                if (EventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
                {
                    var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(EventId.Value, CustomerId.Value);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                }

                if (RegistrationFlow.CallId <= 0)
                {
                    var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                    callQueueCustomerRepository.UpdateOtherCustomerStatus(CustomerId.Value, RegistrationFlow.ProspectCustomerId, CallQueueStatus.Completed, UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);
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



        private void UpdateCallStatus(long eventid)
        {
            var repository = new CallCenterCallRepository();
            if (CallId == null) return;
            ECall objCall = repository.GetCallCenterEntity(CallId.Value);

            objCall.TimeEnd = DateTime.Now.ToString();
            objCall.EventID = eventid;
            var callcenterDal = new CallCenterDAL();
            callcenterDal.UpdateCall(objCall);
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

        private void SetSourceCodeData(decimal orderTotal)
        {
            var testIds = OrderSummaryControl.SelectedAddOnTests.Select(t => t.Id);
            var productAmount = OrderSummaryControl.ProductPrice;
            var shippingAmount = ShippingDetail != null ? ShippingDetail.ActualPrice : 0m;
            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(PackageId.HasValue ? PackageId.Value : 0, testIds,
                                                              orderTotal, txtCouponCode.Text,
                                                              EventId.HasValue ? EventId.Value : 0,
                                                              CustomerId.HasValue ? CustomerId.Value : 0,
                                                              SignUpMode.CallCenter, shippingAmount, productAmount);

            if (model.SourceCodeId < 1 && model.FeedbackMessage != null)
            {
                RegistrationFlow.SourceCodeId = 0;
                RegistrationFlow.SourceCode = string.Empty;
                RegistrationFlow.SourceCodeAmount = 0;
            }
            else
            {
                RegistrationFlow.SourceCodeId = model.SourceCodeId;
                RegistrationFlow.SourceCode = model.SourceCode;
                RegistrationFlow.SourceCodeAmount = model.DiscountApplied;
            }
        }

        [WebMethod(EnableSession = true)]
        public static SourceCodeApplyEditModel GetCoupon(long packageId, string addOnTestIds, string couponCode, long eventId, long customerId, decimal orderTotal, decimal shippingAmount, decimal productAmount)
        {
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, SignUpMode.CallCenter, shippingAmount, productAmount);
            return model;
        }

        private void SaveProspectCustomer()
        {
            if (CurrentProspectCustomer == null || CurrentProspectCustomer.Id < 1) return;

            IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
            bool isAWorkshopProspect = prospectCustomerRepository.IsProspectAWorkshopProspect(CurrentProspectCustomer.Id);

            if (isAWorkshopProspect)
            {
                CurrentProspectCustomer.Source = ProspectCustomerSource.SalesRep;
                CurrentProspectCustomer.Tag = ProspectCustomerTag.WellnessSeminar;
                CurrentProspectCustomer.TagUpdateDate = DateTime.Now;

                IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
                uniqueItemRepository.Save(CurrentProspectCustomer);
                return;
            }

            if (!string.IsNullOrEmpty(txtCouponCode.Text))
            {
                ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                bool isAWorkshopSourceCode;
                try
                {
                    isAWorkshopSourceCode =
                        sourceCodeRepository.IsSourceCodeAWorkshopSourceCode(txtCouponCode.Text.Trim());

                }
                catch (Exception)
                {
                    isAWorkshopSourceCode = false;
                }

                if (isAWorkshopSourceCode)
                {
                    CurrentProspectCustomer.SourceCodeId = SourceCodeId;
                    CurrentProspectCustomer.Source = ProspectCustomerSource.SalesRep;
                    CurrentProspectCustomer.Tag = ProspectCustomerTag.WellnessSeminar;
                    CurrentProspectCustomer.TagUpdateDate = DateTime.Now;

                    IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
                    uniqueItemRepository.Save(CurrentProspectCustomer);
                }
            }
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
                    var customerTargeted = customerTargetedRepository.GetByCustomerIdAndYear(Customer.CustomerId, EventData.EventDate.Year);

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
            if (RegistrationFlow != null && !string.IsNullOrEmpty(RegistrationFlow.QuestionIdAnswerTestId) && CustomerId.HasValue && CustomerId.Value > 0 && EventId.HasValue && EventId.Value > 0)
            {
                var eventCsutomer = IoC.Resolve<IEventCustomerRepository>().Get(EventId.Value, CustomerId.Value);
                var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(RegistrationFlow.QuestionIdAnswerTestId, RegistrationFlow.DisqualifiedTest, eventCsutomer.Id, CustomerId.Value, EventId.Value,
                    UserSessionModel.CurrentOrganizationRole.OrganizationRoleUserId);
            }
        }

        #endregion
    }
}