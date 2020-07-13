using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Deprecated.Repository;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class ApplyCoupon : PaymentInstrumentChargerControl
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

        protected Roles CurrentRole
        {
            get { return (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId; }
        }

        protected override long? CallId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                    return RegistrationFlow.CallId;
                return null;
            }
            set { RegistrationFlow.CallId = value.HasValue ? value.Value : 0; }
        }

        protected override ViewType CurrentViewType
        {
            get
            {

                return (ViewType)Enum.Parse(typeof(ViewType), IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias);
            }
        }

        protected override long? EventId
        {
            get
            {
                if (ViewState["EventId"] != null && !string.IsNullOrEmpty(ViewState["EventId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["EventId"]);
                }
                return null;
            }
            set
            {
                ViewState["EventId"] = value;
            }
        }

        protected override long? CustomerId
        {
            get
            {
                if (ViewState["CustomerId"] != null && !string.IsNullOrEmpty(ViewState["CustomerId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["CustomerId"]);
                }
                return null;
            }
            set
            {
                ViewState["CustomerId"] = value;
            }
        }

        protected override Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
        }

        protected override decimal? TotalAmountPayable
        {
            get
            {
                if (ViewState["TotalAmountPayable"] != null && !string.IsNullOrEmpty(ViewState["TotalAmountPayable"].ToString()))
                {
                    return Convert.ToDecimal(ViewState["TotalAmountPayable"]);
                }
                return null;
            }
            set
            {
                ViewState["TotalAmountPayable"] = value;
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

        protected override ShippingDetail ShippingDetail
        {
            get;
            set;
        }

        protected override DropDownList CountryCombo
        {
            get
            {
                return ddlcountry;
            }
        }

        protected override DropDownList ECountryCombo
        {
            get
            {
                return null;
            }
        }

        protected override HiddenField StateHiddenField
        {
            get
            {
                return hfstate;
            }
        }

        protected override HiddenField EStateHiddenField
        {
            get
            {
                return null;
            }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return ddlcardtype; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return null; }
        }

        protected override DropDownList ChequeAccountTypeCombo
        {
            get { return ddlaccounttype; }
        }

        protected override TextBox Address1TextBox
        {
            get
            {
                return txtAddress1;
            }
        }

        protected override TextBox Address2TextBox
        {
            get { return txtaddress2; }
        }

        protected override TextBox CityTextBox
        {
            get
            {
                return txtCity;
            }
        }

        protected override TextBox ZipTextBox
        {
            get
            {
                return txtZip;
            }
        }

        protected override TextBox PhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox EAddress1TextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EAddress2TextBox
        {
            get { return null; }
        }

        protected override TextBox ECityTextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EZipTextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EPhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox CreditCardHolderNameTextBox
        {
            get { return txtCardHolderName; }
        }

        protected override TextBox CreditCardExpiryDateTextBox
        {
            get { return txtExpirationDate; }
        }

        protected override TextBox CreditCardNumberTextBox
        {
            get { return txtCardNo; }
        }

        protected override TextBox CreditCardSecurityNumberTextBox
        {
            get { return txtSecurityNum; }
        }

        protected override TextBox EChequeRoutingNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeAccountNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeBankNameTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeAccountHolderNameTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeChequeNumberTextBox
        {
            get { return null; }
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

        protected override ListControl PaymentMode
        {
            get { return ddlpaymentmode; }
        }

        protected const string IsValidCardHiddenFieldName = "IsCardValidForRefundHiddenField";

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            if (PaymentGatewayResponse != null)
            {
                if ((ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCard.PersistenceLayerId.ToString() || ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString())
                        && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
                }
                else if (ddlpaymentmode.SelectedItem.Value == PaymentType.ElectronicCheck.PersistenceLayerId.ToString() && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
                }
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + errorMessage + "');", true);

            Page.ClientScript.RegisterStartupScript(typeof(string), "Js_MaintainAfterFailedPostback", " SetValuesafterFailedPostBack(); ", true);
            divCouponamountadjustment.Style["Display"] = "block";
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            var sessionContext = IoC.Resolve<ISessionContext>();
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(sessionContext.UserSession.CurrentOrganizationRole, sessionContext.UserSession.UserId);
        }

        private Roles EventRegisteredBy
        {
            get
            {
                if (ViewState["EventRegisteredBy"] != null && !string.IsNullOrEmpty(ViewState["EventRegisteredBy"].ToString()))
                {
                    return (Roles)Enum.Parse(typeof(Roles), ViewState["EventRegisteredBy"].ToString());
                }
                return Roles.Customer;
            }
            set
            {
                ViewState["EventRegisteredBy"] = value;
            }
        }

        protected override string SourceCode { get; set; }

        protected override long SourceCodeId { get; set; }

        protected override decimal SourceCodeAmount { get; set; }

        protected override decimal AmountCoveredByInsurance
        {
            get
            {
                return 0;
            }
        }

        protected override long EligibilityId
        {
            get
            {
                return 0;
            }
            set { }
        }

        protected override long ChargeCardId
        {
            get
            {
                return 0;
            }
            set { }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Apply Source code";
            if (!IsPostBack)
            {

                ViewState["ReferredQuery"] = Request.UrlReferrer.PathAndQuery;
                EventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
                if (!SetCustomerDetail())
                { }
                BindAllDropDowns();
                ddlpaymentmode.Attributes.Add("onChange", "OpenCloseDiv('" + ddlpaymentmode.ClientID + "')");

            }
            RegisterJavaScriptEvents();
        }

        private void RegisterJavaScriptEvents()
        {
            txtCardNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAccountNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtChequeNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtSecurityNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            //txtZip.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtRoutingNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtcashamount.Attributes.Add("ReadOnly", "ReadOnly");

        }
        private long GetParentRoleIdByRoleId(long roleId)
        {
            var roleRepository = IoC.Resolve<IRoleRepository>();
            var role = roleRepository.GetByRoleId(roleId);

            if (role == null) return 0;

            return role.ParentId ?? 0;
        }
        protected void ibtnapplycoupon_Click(object sender, ImageClickEventArgs e)
        {
            var signUpMode = SignUpMode.Online;
            if (EventRegisteredBy.Equals(Roles.Customer) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Customer))
                signUpMode = SignUpMode.Online;
            else if (EventRegisteredBy.Equals(Roles.Technician) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Technician) || EventRegisteredBy.Equals(Roles.NursePractitioner) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.NursePractitioner))
                signUpMode = SignUpMode.Walkin;
            else if (EventRegisteredBy.Equals(Roles.CallCenterRep) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.CallCenterRep))
                signUpMode = SignUpMode.CallCenter;

            if (CustomerId.HasValue && EventId.HasValue)
            {
                IOrderRepository orderRepository = new OrderRepository();
                var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                if (order != null)
                {
                    var orderTotal = order.UndiscountedTotal;

                    long packageId = 0;
                    var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = eventPackageRepository.GetPackageForOrder(order.Id);
                    if (eventPackage != null)
                        packageId = eventPackage.PackageId;

                    IEnumerable<long> testIds = null;
                    var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                    var eventTests = eventTestRepository.GetTestsForOrder(order.Id);
                    if (eventTests != null && eventTests.Count() > 0)
                        testIds = eventTests.Select(et => et.TestId).ToArray();

                    var shippingAmount =
                        order.OrderDetails.Sum(
                            od =>
                            (od.ShippingDetailOrderDetails != null && !od.ShippingDetailOrderDetails.IsEmpty()
                                 ? od.ShippingDetailOrderDetails.Sum(sdod => sdod.Amount)
                                 : 0));

                    var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
                    var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, txtcoupon.Text, EventId.Value, CustomerId.Value, signUpMode, shippingAmount, (order.ProductCost.HasValue ? order.ProductCost.Value : 0));

                    var serializer = new JavaScriptSerializer();
                    var stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.Append(" ExtractCouponData('" + serializer.Serialize(model) + "'); ");

                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", stringBuilder.ToString(), true);
                }

                if (hfPaymentMode != null && hfPaymentMode.Value == "Gift Certificate")
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCodeSetData",
                                                            "SetValuesafterFailedPostBack();", true);
                }
            }

        }

        protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();
            if (redirecturl.ToLower().IndexOf("action=package") >= 0)
                redirecturl = redirecturl.ToLower().Replace("action=package", "");

            redirecturl = redirecturl.Replace("call=no", "Call=No");
            Response.RedirectUser(redirecturl);
        }

        protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
        {
            bool coupondrorcr;
            decimal diffamount = decimal.Parse(hfdiffamount.Value);

            if (Convert.ToSingle(hfdiffamount.Value) >= 0.00)
                coupondrorcr = false;
            else
            {
                coupondrorcr = true;
                diffamount = -1 * diffamount;
            }
            SourceCodeId = Convert.ToInt64(hfcouponid.Value);
            SourceCodeAmount = Convert.ToDecimal(hfcouponamount.Value);
            SourceCode = txtcoupon.Text;


            decimal dchargeableamount = Decimal.Parse(hfcurrentpayable.Value);

            if (coupondrorcr == false)
                dchargeableamount = dchargeableamount + diffamount;
            else
                dchargeableamount = dchargeableamount - diffamount;
            TotalAmountPayable = dchargeableamount;

            bool doEventRegistrationRedirect;
            try
            {
                using (var scope = new TransactionScope())
                {
                    doEventRegistrationRedirect = ApplyCoupon();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                doEventRegistrationRedirect = false;
            }
            if (doEventRegistrationRedirect)
                SetPageReDirection();


        }


        private void SetPageReDirection()
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();

            if (CurrentRole == Roles.CallCenterRep)
            {
                if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"].ToLower() == "no"))
                {
                    if (CallId.HasValue)
                    {
                        var repository = new CallCenterCallRepository();
                        var call = repository.GetCallCenterEntity(CallId.Value);
                        EndCall();
                        StartCall(call.CalledCustomerID);
                    }

                }
            }
            Response.RedirectUser(redirecturl);
        }

        private bool SetCustomerDetail()
        {
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
            if (eventCustomer != null)
            {
                CustomerId = eventCustomer.CustomerId;
                EventId = eventCustomer.EventId;
                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(eventCustomer.DataRecorderMetaData.DataRecorderCreator.Id);

                EventRegisteredBy = (Roles)Enum.Parse(typeof(Roles), orgRoleUser.RoleId.ToString());

                speventid.InnerText = EventId.ToString();

                if (Customer != null && Customer.Address != null)
                {
                    spcustomerdetail.InnerText = " " + "-" + " " + Customer.Name + "(ID:" + Customer.CustomerId + ")";

                }
                
                var eventService = IoC.Resolve<IEventService>();
                var eventBasicInfoViewModel = eventService.GetEventBasicInfoFor(eventCustomer.EventId);

                speventid.InnerText = EventId.ToString();
                sphostname.InnerText = eventBasicInfoViewModel.HostName;
                spaddress.InnerText =
                    CommonCode.AddressSingleLine(eventBasicInfoViewModel.HostAddress.StreetAddressLine1,
                                                 eventBasicInfoViewModel.HostAddress.StreetAddressLine2,
                                                 eventBasicInfoViewModel.HostAddress.City,
                                                 eventBasicInfoViewModel.HostAddress.State,
                                                 eventBasicInfoViewModel.HostAddress.ZipCode);

                if (eventCustomer.AppointmentId.HasValue)
                {
                    var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                    var appointment = appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                    spapptime.InnerText = appointment.StartTime.ToShortTimeString();
                }
                
                speventdate.InnerText = eventBasicInfoViewModel.EventDate.ToShortDateString();
                ViewState["EventDate"] = eventBasicInfoViewModel.EventDate.ToShortDateString();


                IOrderRepository orderRepository = new OrderRepository();
                var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                if (order != null && !order.OrderDetails.IsEmpty())
                {
                    hfPackageCost.Value = order.OrderDetails.Where(od =>
                                (od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted) ||
                                (od.DetailType == OrderItemType.EventTestItem && od.IsCompleted))
                            .Sum(od => od.Price).ToString();

                    sppackagecost.InnerText =
                        order.OrderDetails.Where(od =>
                                (od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted) ||
                                (od.DetailType == OrderItemType.EventTestItem && od.IsCompleted))
                            .Sum(od => od.Price).ToString("C2");

                    OrderId = order.Id;
                    SetRefundRequestAmount(OrderId);
                    SetPaymentDetails(order);

                    IOrderController orderController = new OrderController();
                    var orderDetail = orderController.GetActiveOrderDetail(order);
                    IOrderItemRepository orderItemRepository = new OrderItemRepository();
                    var orderItem = orderItemRepository.GetOrderItem(orderDetail.OrderItemId);
                    if (orderItem is EventPackageItem)
                    {
                        var eventPackageItem = orderItem as EventPackageItem;

                        var itemRepository = IoC.Resolve<IEventPackageRepository>();
                        var eventPackage = itemRepository.GetById(eventPackageItem.ItemId);
                        PackageId = eventPackage.PackageId;
                    }
                    if (orderDetail.SourceCodeOrderDetail != null)
                    {
                        if (Customer != null) ViewState["DateApplied"] = Customer.DateCreated;

                        ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                        var sourceCode =
                            sourceCodeRepository.GetSourceCodeById(orderDetail.SourceCodeOrderDetail.SourceCodeId);
                        spcoupon.InnerText = sourceCode.CouponCode;

                        if (!string.IsNullOrEmpty(sourceCode.CouponCode))
                        {
                            rbtreplaceexisting.Checked = true;
                            hfcurrentcoupon.Value = sourceCode.CouponCode;
                            hfcurrentcouponamount.Value = orderDetail.SourceCodeOrderDetail.Amount.ToString("N2");
                        }
                        else
                            rbtapplycoupon.Checked = true;
                    }
                    else
                    {
                        spcoupon.InnerText = "N/A";
                        rbtapplycoupon.Checked = true;
                    }
                }
                return true;
            }
            return false;
        }

        private void SetRefundRequestAmount(long orderId)
        {
            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequests = refundRequestRepository.GetbyOrderId(orderId);
            if (refundRequests != null)
            {
                RefundRequestAmount.Value = refundRequests.Where(
                    rr => rr.RefundRequestType != RefundRequestType.ApplySourceCode).Sum(
                        rr => rr.RequestedRefundAmount).ToString("0.00");
            }
        }

        private void SetPaymentDetails(Core.Finance.Domain.Order order)
        {
            TotalAmountPayable = order.DiscountedTotal - order.TotalAmountPaid;
            hfcurrentpayable.Value = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");
            if (order.PaymentsApplied != null && !order.PaymentsApplied.IsEmpty())
            {
                //TODO:Currently it is removed as we don't have CC detail
                SetCreditCardOnFileDetails(order);

                bool unpaid = true;
                string paidstring = string.Empty;
                decimal paidamount = 0.00m;
                foreach (var paymentApplied in order.PaymentsApplied)
                {
                    if (paidstring.Trim().Length < 1)
                        paidstring = "Paid Amount:";

                    if (paymentApplied.Amount > 0)
                    {
                        paidamount += paymentApplied.Amount;
                        paidstring += " $" + paymentApplied.Amount.ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        unpaid = false;
                    }
                    else if (paymentApplied.Amount < 0)
                    {
                        paidamount += paymentApplied.Amount;
                        paidstring += " Refund Amount: $" + (-1 * paymentApplied.Amount).ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        unpaid = false;
                    }
                }
                if (TotalAmountPayable < 0)
                    paidstring += " | Unpaid Amount: $" + (TotalAmountPayable.Value * -1).ToString("0.00") + " <i>(To Refund) </i>";
                else
                    paidstring += " | Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");

                if (paidstring.Substring(paidstring.Length - 1, 1) == ",")
                    paidstring = paidstring.Substring(0, paidstring.Length - 1);
                hfpaidamount.Value = paidamount.ToString("N2");

                if (unpaid)
                    sppaymentdetails.InnerText = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
                else
                    sppaymentdetails.InnerHtml = paidstring;
            }
            else
                sppaymentdetails.InnerHtml = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
            if (Customer != null)
            {
                var functionToCall = "javascript:return ShowOrderDetailPopUp(" +
                   HttpUtility.HtmlEncode(order.Id) + "," + HttpUtility.HtmlEncode(order.DiscountedTotal) + "," + HttpUtility.HtmlEncode(order.TotalAmountPaid) + "," +
                                            HttpUtility.HtmlEncode(order.DiscountedTotal - order.TotalAmountPaid) + ",'" + HttpUtility.HtmlEncode(Customer.Name) + "'," +
                                            HttpUtility.HtmlEncode(Customer.CustomerId) + ");";
                _paymentLinkAnchor.Attributes.Add("onClick", functionToCall);
                _paymentLinkAnchor.HRef = "javascript:void(0);";
            }
        }

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            var creditCardPaymentInstrument =
                order.PaymentsApplied.OrderBy(pa => pa.DataRecorderMetaData.DateCreated).LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;

            if (creditCardPaymentInstrument == null) return;

            string reasonForFailure = "";

            if (!IoC.Resolve<IChargeCardService>().IsCardValidforRefund(creditCardPaymentInstrument, 0, out reasonForFailure))
                Page.ClientScript.RegisterHiddenField(IsValidCardHiddenFieldName, Boolean.FalseString);
            else
                Page.ClientScript.RegisterHiddenField(IsValidCardHiddenFieldName, Boolean.TrueString);

            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
            var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
            spcardholder.InnerText = existingChargeCard.NameOnCard;
            string cardnumber = existingChargeCard.Number;
            if (cardnumber.Length > 0)
            {
                string dispcardnumber = string.Empty;
                for (int jcount = 0; jcount < cardnumber.Length - 4; jcount++)
                {
                    dispcardnumber = dispcardnumber + "X";
                }

                dispcardnumber += cardnumber.Substring(cardnumber.Length - 4, 4);

                spccnumber.InnerText = dispcardnumber;
                spcctype.InnerText =
                    Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();
                spexpdate.InnerText = existingChargeCard.ExpirationDate.ToString("MM/yyyy");

                ddlpaymentmode.Items.Clear();
                ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));
            }
        }

        private void BindAllDropDowns()
        {
            BindCountryDropDown();
            BindPageDropDowns();
        }

        protected override void BindPaymentModeDropDown()
        {
            var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (orgUser.CheckRole((long)Roles.FranchisorAdmin) || orgUser.CheckRole((long)Roles.FranchiseeAdmin))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                DateTime eventDate = Convert.ToDateTime(ViewState["EventDate"].ToString());
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                if (eventDate > DateTime.Now)
                {
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
                }
            }
            else if (orgUser.CheckRole((long)Roles.Customer))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
            }
            else if (orgUser.CheckRole((long)Roles.Technician) || orgUser.CheckRole((long)Roles.NursePractitioner))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }
            else if (orgUser.CheckRole((long)Roles.CallCenterRep) || orgUser.CheckRole((long)Roles.CallCenterManager))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
            }

            var listItems = ddlpaymentmode.Items.Cast<ListItem>().ToList().OrderBy(li => li.Text).ToArray();
            ddlpaymentmode.Items.Clear();
            ddlpaymentmode.Items.AddRange(listItems);

            ddlpaymentmode.Items.Insert(0, new ListItem("Pay By:", "0"));

        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlcountry.DataSource = countries;
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataValueField = "Id";
            ddlcountry.DataBind();
            //ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlcountry.Items[0].Selected = true;
        }

        private void StartCall(long calledCustomerid)
        {
            var newCall = new Call();
            var repository = new CallCenterCallRepository();

            if (CallId.HasValue)
            {
                var call = repository.GetById(CallId.Value);

                newCall.CalledInNumber = call.CalledInNumber;
                newCall.CallerNumber = call.CallerNumber;
                newCall.IsIncoming = call.IsIncoming;
            }

            newCall.CreatedByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            newCall.StartTime = DateTime.Now;
            newCall.CallDateTime = DateTime.Now;
            newCall.DateCreated = DateTime.Now;
            newCall.DateModified = DateTime.Now;
            newCall.CalledCustomerId = calledCustomerid;

            if (!string.IsNullOrEmpty(Customer.Tag))
            {
                var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = accountRepository.GetByTag(Customer.Tag);
                newCall.HealthPlanId = account.Id;
            }

            newCall = repository.Save(newCall);
            CallId = newCall.Id;
        }

        private void EndCall()
        {
            if (CallId == null) return;
            var repository = new CallCenterCallRepository();
            repository.UpdateCallEnd(DateTime.Now, CallId.Value);
        }

    }
}