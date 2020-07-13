using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
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
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using CallType = Falcon.App.Core.CallCenter.Enum.CallType;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcChangeAppointmentPayment : PaymentInstrumentChargerControl
    {
        protected const string IsValidCardHiddenFieldName = "IsCardValidForRefundHiddenField";
        protected readonly Roles _currentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;

        #region "Inherited Members"
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

        protected override decimal AmountCoveredByInsurance
        {
            get { throw new NotImplementedException(); }
        }

        protected override long EligibilityId { get; set; }

        protected override long ChargeCardId { get; set; }

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
                return ddlEcountry;
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
                return hfEstate;
            }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return ddlcardtype; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return ddlEAccountType; }
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
            get { return null; }
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
                return txtEAddress1;
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
                return txtECity;
            }
        }

        protected override TextBox EZipTextBox
        {
            get
            {
                return txtEZip;
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

        protected override ListControl PaymentMode
        {
            get { return ddlpaymentmode; }
        }
        #endregion

        public bool IsFailedPostBack { get; set; }
        public bool IsProcessRequest
        {
            get
            {
                if (Request.QueryString[RefundRequest.ProcessRequest] != null)
                    return true;
                return false;
            }
        }
        public Roles CurrentRole
        {
            get
            {
                return (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
            }
        }

        public OrganizationRoleUserModel CurrentOrgRole
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            }
        }
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
        protected long? CallQueueCustomerId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallQueueCustomerId > 0)
                    return RegistrationFlow.CallQueueCustomerId;
                return null;
            }
        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            if (PaymentGatewayResponse != null)
            {
                if ((ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCard.PersistenceLayerId.ToString() || ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()) && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
                else if (ddlpaymentmode.SelectedItem.Value == PaymentType.ElectronicCheck.PersistenceLayerId.ToString() && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + errorMessage + "');", true);

            var testIds = new List<long>();
            TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
            //ItemCartControl.TestIds = testIds;
            //ItemCartControl.PackageId = PackageId;
            IsFailedPostBack = true;
            Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode_MaintainAfterFailedPostback", "SetValuesafterFailedPostBack(); ", true);
            divChangePackage.Style["Display"] = "block";
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole, IoC.Resolve<ISessionContext>().UserSession.UserId);
        }
        protected Roles EventRegisteredBy
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ReferredQuery"] = Request.UrlReferrer.PathAndQuery;
                if (Request.QueryString["CustomerList"] != null)
                    ViewState["CustomerList"] = true;
            }
        }

        public void SetIntialData(long newEventId, long customerId, long eventCustomerId, long oldEventId)
        {
            IsFailedPostBack = true;
            EventId = oldEventId;

            oldEventIdHiddenControl.Value = oldEventId.ToString();
            CustomerId = customerId;
            EventCustomerId = eventCustomerId;

            if (ViewState["EventDate"] == null)
            {
                var eventRepository = IoC.Resolve<EventRepository>();
                var theEventData = eventRepository.GetById(newEventId);
                ViewState["EventDate"] = theEventData.EventDate;
            }

            SetCustomerDetail(newEventId);
            BindAllDropDowns();
            RegisterJavaScriptEvents();

        }

        private void RegisterJavaScriptEvents()
        {
            txtamount.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtChequeNum.Attributes.Add("onKeyDown", "return txtkeypress_NumericAlphanumeric(event);");

            ddlpaymentmode.Attributes.Add("onChange", "OpenCloseDiv('" + ddlpaymentmode.ClientID + "')");

            txtCardNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtSecurityNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        }
        private void BindAllDropDowns()
        {
            ddlpaymentmode.Items.Clear();
            BindCountryDropDown();
            BindPageDropDowns();
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

            ddlEcountry.DataSource = countries;
            ddlEcountry.DataTextField = "Name";
            ddlEcountry.DataValueField = "Id";
            ddlEcountry.DataBind();
            //ddlEcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlEcountry.Items[0].Selected = true;
        }

        #region "Values to be set from Change Appointment"
        public string SelectedPackageId
        {
            get { return PackageIdHiddenControl.Value; }
            set { PackageIdHiddenControl.Value = value; }
        }

        public string SelectedTestIds
        {
            get { return TestIdsHiddenControl.Value; }
            set { TestIdsHiddenControl.Value = value; }
        }

        public string SelectedIndependentTestIds
        {
            get { return IndependentTestIdsHiddenControl.Value; }
            set { IndependentTestIdsHiddenControl.Value = value; }
        }

        public string CurrentOrderPrice
        {
            get { return CurrentOrderPriceHiddenControl.Value; }
            set { CurrentOrderPriceHiddenControl.Value = value; }
        }

        public string PaidAmount
        {
            get { return PaidAmountHiddenControl.Value; }
            set { PaidAmountHiddenControl.Value = value; }
        }

        public string UnpaidAmount
        {
            get { return UnpaidAmountHiddenControl.Value; }
            set { UnpaidAmountHiddenControl.Value = value; }
        }

        public string NewEventId
        {
            get { return EventIdHiddenControl.Value; }
            set { EventIdHiddenControl.Value = value; }
        }

        public string ExistingCouponCode
        {
            get { return ExistingCouponCodeHiddenControl.Value; }
            set { ExistingCouponCodeHiddenControl.Value = value; }
        }

        public string NewHfSlotIds
        {
            get { return hfSlotIds.Value; }
            set { hfSlotIds.Value = value; }
        }

        protected override void BindPaymentModeDropDown()
        {
            if (_currentRole == Roles.FranchisorAdmin || _currentRole == Roles.FranchiseeAdmin)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                DateTime eventDate = Convert.ToDateTime(ViewState["EventDate"].ToString());
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                if (eventDate > DateTime.Now)
                {
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
                }
            }
            else if (_currentRole == Roles.Customer)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
            }
            else if (_currentRole == Roles.Technician || _currentRole == Roles.NursePractitioner)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }
            else if (_currentRole == Roles.CallCenterRep || _currentRole == Roles.CallCenterManager)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
            }

            var listItems = ddlpaymentmode.Items.Cast<ListItem>().ToList().OrderBy(li => li.Text).ToArray();
            ddlpaymentmode.Items.Clear();
            ddlpaymentmode.Items.AddRange(listItems);

            ddlpaymentmode.Items.Insert(0, new ListItem("Pay By:", "0"));
        }

        #endregion

        private void SetCustomerDetail(long newEventId)
        {
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);

            var hostRepository = IoC.Resolve<HostRepository>();
            if (eventCustomer != null)
            {
                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(eventCustomer.DataRecorderMetaData.DataRecorderCreator.Id);

                var currentEventId = eventCustomer.EventId;

                EventRegisteredBy = (Roles)Enum.Parse(typeof(Roles), orgRoleUser.RoleId.ToString());
                EventIdHiddenControl.Value = newEventId.ToString();
                speventid.InnerText = currentEventId.ToString();

                var host = hostRepository.GetHostForEvent(currentEventId);
                sphostname.InnerText = host.OrganizationName;
                spaddress.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(host.Address.ToString(), true);

                IOrderRepository orderRepository = new OrderRepository();
                var order = orderRepository.GetOrder(CustomerId.Value, currentEventId);
                if (order != null && !order.OrderDetails.IsEmpty())
                {
                    OrderId = order.Id;
                    SetOrderDetails(order);
                    SetRefundRequestAmount(OrderId);
                    SetPaymentDetails(order);

                    var testIds = new List<long>();
                    var additionalTestIds = new List<long>();
                    var testsName = string.Empty;
                    foreach (var orderDetail in order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess))
                    {
                        IOrderItemRepository orderItemRepository = new OrderItemRepository();
                        var orderItem = orderItemRepository.GetOrderItem(orderDetail.OrderItemId);

                        if (orderItem.OrderItemType == OrderItemType.EventPackageItem)
                        {
                            var eventPackageItem = orderItem as EventPackageItem;

                            var itemRepository = IoC.Resolve<IEventPackageRepository>();
                            var eventPackage = itemRepository.GetById(eventPackageItem.ItemId);
                            PackageId = eventPackage.PackageId;

                            var package = eventPackage.Package;
                            sppackagename.InnerText = package.Name;
                            testIds.AddRange(package.Tests.Select(t => t.Id));
                        }
                        else if (orderItem.OrderItemType == OrderItemType.EventTestItem)
                        {
                            var eventTestItem = orderItem as EventTestItem;

                            var itemRepository = IoC.Resolve<IEventTestRepository>();
                            var eventTest = itemRepository.GetbyId(eventTestItem.ItemId);
                            testIds.Add(eventTest.TestId);
                            additionalTestIds.Add(eventTest.TestId);

                            testsName += string.IsNullOrEmpty(testsName) ? eventTest.Test.Name : ", " + eventTest.Test.Name;
                        }
                    }

                    sppackagename.InnerText += string.IsNullOrEmpty(sppackagename.InnerText) ? testsName : ", " + testsName;

                    TestIds = testIds;


                    var eligibilityService = IoC.Resolve<IEligibilityService>();
                    var isTestCoveredByInsurance = eligibilityService.CheckTestCoveredByinsurance(EventId.Value, PackageId, additionalTestIds);
                    IsTestCoveredByInsuranceHiddenField.Value = isTestCoveredByInsurance ? Boolean.TrueString : Boolean.FalseString;

                    var eligibilityRepository = IoC.Resolve<IEligibilityRepository>();
                    var eligibility = eligibilityRepository.GetEventCustomerEligibilityIdByEventCustomerId(eventCustomer.Id);
                    if (eligibility != null)
                    {
                        EligibilityId = eligibility.EligibilityId;
                        ChargeCardId = eligibility.ChargeCardId.HasValue && eligibility.ChargeCardId.Value > 0 ? eligibility.ChargeCardId.Value : 0;
                    }
                    else
                    {
                        EligibilityId = 0;
                        ChargeCardId = 0;
                    }
                    IOrderController orderController = new OrderController();
                    var activeOrderDetail = orderController.GetActiveOrderDetail(order);
                    if (activeOrderDetail.SourceCodeOrderDetail != null)
                    {
                        ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                        var sourceCode =
                            sourceCodeRepository.GetSourceCodeById(activeOrderDetail.SourceCodeOrderDetail.SourceCodeId);
                        spcoupon.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(sourceCode.CouponCode, true);
                    }
                    else
                        spcoupon.InnerHtml = "N/A";
                    SetSourceCodeDetail(order);
                }
            }
            SetNewOrderDetails(newEventId);
        }

        private void SetNewOrderDetails(long newEventId)
        {
            var hostRepository = IoC.Resolve<HostRepository>();
            var host = hostRepository.GetHostForEvent(newEventId);
            var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();

            var eventTestRepository = IoC.Resolve<EventTestRepository>();
            spnewEventId.InnerText = newEventId.ToString();
            spNewHostname.InnerText = host.OrganizationName;
            spnewAddress.InnerText = host.Address.ToString();
            var order = string.Empty;
            decimal orderPrice = 0m;
            var packageId = ParseIntoLong(SelectedPackageId);

            if (packageId > 0)
            {
                var eventPacakge = eventPackageRepository.GetByEventAndPackageIds(newEventId, packageId);

                order = eventPacakge.Package.Name;
                orderPrice = eventPacakge.Price;
            }

            if (!string.IsNullOrEmpty(IndependentTestIdsHiddenControl.Value.Trim()))
            {
                var aditionalTests = IndependentTestIdsHiddenControl.Value.Trim().Split(',');

                aditionalTests = aditionalTests.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (!aditionalTests.IsNullOrEmpty())
                {
                    var testIds = aditionalTests.Select(long.Parse);
                    var eventTest = eventTestRepository.GetByEventAndTestIds(newEventId, testIds);

                    if (!eventTest.IsNullOrEmpty())
                    {
                        if (string.IsNullOrEmpty(order))
                        {
                            order = string.Join(", ", eventTest.Select(x => x.Test.Name));
                        }
                        else
                        {
                            order = order + ", " + string.Join(", ", eventTest.Select(x => x.Test.Name));
                        }
                        if (packageId > 0)
                            orderPrice += eventTest.Sum(test => test.WithPackagePrice);
                        else
                            orderPrice += eventTest.Sum(test => test.Price);
                    }
                }
            }
            spNewpackagename.InnerText = order;
            spNewPackagecost.InnerText = orderPrice.ToString("0.00");
        }

        private void SetRefundRequestAmount(long orderId)
        {
            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequests = refundRequestRepository.GetbyOrderId(orderId);
            if (refundRequests != null)
            {
                RefundRequestAmount.Value = refundRequests.Where(
                    rr => rr.RefundRequestType != RefundRequestType.ChangePackage).Sum(
                        rr => rr.RequestedRefundAmount).ToString("0.00");
            }
        }

        private void SetOrderDetails(Core.Finance.Domain.Order order)
        {
            var totalPrice = order.OrderValue;
            txtamount.Text = totalPrice.ToString("0.00");
            hfCurrentPackagePrice.Value = totalPrice.ToString("0.00");
            sppackagecost.InnerHtml = "$" + totalPrice.ToString("0.00");
            hfPackageCost.Value = totalPrice.ToString("0.00");
        }

        private void SetSourceCodeDetail(Core.Finance.Domain.Order order)
        {
            IOrderController orderController = new OrderController();
            var orderDetail = orderController.GetActiveOrderDetail(order);
            if (orderDetail != null && orderDetail.SourceCodeOrderDetail != null)
            {
                if (orderDetail.SourceCodeOrderDetail.SourceCodeId > 0)
                {
                    Page.ClientScript.RegisterHiddenField("ExistingCouponCodeInputHidden", spcoupon.InnerHtml.Trim());
                    hfcurrentcouponamount.Value = orderDetail.SourceCodeOrderDetail.Amount.ToString("0.00");
                    spApplySCodeTitle.InnerHtml = "Replace Existing Source Code";
                    hfIsAppliedCoupon.Value = Convert.ToString(true).ToLower();

                    var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
                    var coupon = sourceCodeRepository.GetSourceCodeById(orderDetail.SourceCodeOrderDetail.SourceCodeId);
                    if (coupon != null)
                    {
                        hfAppliedCouponID.Value = coupon.Id.ToString();
                        hfAppliedMinPurchaseAmount.Value = coupon.MinimumPurchaseAmount.ToString();
                        ExistingCouponCodeHiddenControl.Value = coupon.CouponCode;
                        if (!(coupon.PackageDiscounts != null && coupon.PackageDiscounts.Count() > 0))
                        {
                            hfAppliedCouponPercentage.Value = coupon.DiscountValueType == DiscountValueType.Percent
                                                                  ? "true"
                                                                  : "false";
                            hfAppliedCouponValue.Value = coupon.CouponValue.ToString();
                        }
                        else
                        {
                            hfAppliedCouponDiscountTypePackageWise.Value = "true";
                            hfAppliedCouponPercentage.Value = false.ToString().ToLower();
                        }
                    }
                }
            }
        }

        private void SetPaymentDetails(Core.Finance.Domain.Order order)
        {
            TotalAmountPayable = order.DiscountedTotal - order.TotalAmountPaid;
            UnpaidAmountHiddenControl.Value = TotalAmountPayable.Value.ToString("0.00");
            PaidAmountHiddenControl.Value = order.TotalAmountPaid.ToString("0.00");
            hfamountpayable.Value = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");

            if (order.PaymentsApplied != null && !order.PaymentsApplied.IsEmpty())
            {
                SetCreditCardOnFileDetails(order);

                bool isUnpaid = true;
                string paidString = string.Empty;
                //decimal paidAmount = 0.00m;
                foreach (var paymentApplied in order.PaymentsApplied)
                {
                    if (string.IsNullOrEmpty(paidString))
                        paidString = "Paid Amount:";

                    if (paymentApplied.Amount > 0)
                    {
                        //paidAmount += paymentApplied.Amount;
                        paidString += " $" + paymentApplied.Amount.ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        isUnpaid = false;
                    }
                    else if (paymentApplied.Amount < 0)
                    {
                        //paidAmount += paymentApplied.Amount;
                        paidString += " Refund Amount: $" + (-1 * paymentApplied.Amount).ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        isUnpaid = false;
                    }
                }
                if (TotalAmountPayable < 0)
                    paidString += " | Unpaid Amount: $" + (TotalAmountPayable.Value * -1).ToString("0.00") + " <i>(To Refund) </i>";
                else
                    paidString += " | Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");

                if (paidString.Substring(paidString.Length - 1, 1) == ",")
                    paidString = paidString.Substring(0, paidString.Length - 1);
                //hfpaidamount.Value = paidAmount.ToString("N2");

                if (isUnpaid)
                    sppaymentdetails.InnerHtml = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
                else
                    sppaymentdetails.InnerHtml = paidString;
            }
            else
                sppaymentdetails.InnerHtml = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
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
            spcardholder.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(existingChargeCard.NameOnCard, true);
            string cardnumber = existingChargeCard.Number;
            if (cardnumber.Length > 0)
            {
                string dispcardnumber = "";
                for (int jcount = 0; jcount < cardnumber.Length - 4; jcount++)
                {
                    dispcardnumber = dispcardnumber + "X";
                }

                dispcardnumber += cardnumber.Substring(cardnumber.Length - 4, 4);

                spccnumber.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(dispcardnumber, true);
                spcctype.InnerHtml =
                    Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();

                spexpdate.InnerHtml = existingChargeCard.ExpirationDate.ToString("MM/yyyy");
                hfCardTypeId.Value = ((int)existingChargeCard.TypeId).ToString();
                ddlpaymentmode.Items.Clear();
                ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));
                ExistingChargeCardId.Value = existingChargeCard.Id.ToString();
            }
        }

        protected void ibtnchangepackage_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(hfcouponid.Value) && Convert.ToInt32(hfcouponid.Value) > 0)
            {
                SourceCodeId = Convert.ToInt32(hfcouponid.Value);
                SourceCode = (!string.IsNullOrEmpty(hfAppliedCouponID.Value) && Convert.ToInt32(hfAppliedCouponID.Value) > 0) ? spcoupon.InnerHtml.Trim() : txtcoupon.Text;
                SourceCodeAmount = Convert.ToDecimal(hfcouponamount.Value) < 0 ? -1 * Convert.ToDecimal(hfcouponamount.Value) : Convert.ToDecimal(hfcouponamount.Value);
            }
            else
            {
                SourceCodeId = 0;
                SourceCode = string.Empty;
                SourceCodeAmount = 0;
            }
            TotalAmountPayable = Convert.ToDecimal(hfamountpayable.Value);
            if (_currentRole == Roles.FranchisorAdmin || _currentRole == Roles.FranchiseeAdmin || _currentRole == Roles.CallCenterRep)
            {
                if (TotalAmountPayable.Value > 0)
                {
                    var paymentRestriction = IoC.Resolve<IPrePaymentRestriction>();
                    if (Convert.ToDecimal(PaidAmountHiddenControl.Value) > 0)
                    {
                        var currentPackagePrice = Convert.ToDecimal(hfCurrentPackagePrice.Value);
                        var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

                        TotalAmountPayable =
                            paymentRestriction.GetAllowedPrepaymentByChargeCard(
                                PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
                                    ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
                                    : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
                                    TotalAmountPayable.Value);
                        //newPackagePrice - currentPackagePrice - Convert.ToDecimal(hfcouponamount.Value));
                    }
                    else
                    {
                        TotalAmountPayable = paymentRestriction.GetAllowedPrepaymentByChargeCard(
                            PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
                                ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
                                : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
                            TotalAmountPayable.Value);
                    }
                }
            }
            var testIds = new List<long>();

            if (!string.IsNullOrWhiteSpace(TestIdsHiddenControl.Value))
                TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            TestIds = testIds;
            PackageId = Convert.ToInt64(PackageIdHiddenControl.Value);
            var newEventId = ParseIntoLong(NewEventId);

            var addOnTestIds = new List<long>();
            if (!string.IsNullOrWhiteSpace(IndependentTestIdsHiddenControl.Value))
            {
                IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => addOnTestIds.Add(Convert.ToInt64(t)));
            }

            var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
            var screeningTime = eventPackageSelectorService.GetScreeningTime(newEventId, PackageId, addOnTestIds);

            var tempraryBookedSlotsIds = new List<long>();
            if (!string.IsNullOrEmpty(hfSlotIds.Value))
            {
                hfSlotIds.Value.Split(',').ToList().ForEach(t => tempraryBookedSlotsIds.Add(Convert.ToInt64(t)));
            }
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();

            var orgRoleId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            bool doEventRegistrationRedirect = false;
            try
            {
                using (var scope = new TransactionScope())
                {
                    if (doEventRegistrationRedirect = RescheduleCustomerEventPackage())
                    {
                        if ((_currentRole != Roles.Technician && _currentRole != Roles.NursePractitioner) || Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value) < Convert.ToDecimal(hfCurrentPackagePrice.Value))
                            eventAppointmentService.AdjustAppointment(EventCustomerId, screeningTime, tempraryBookedSlotsIds, true);
                        var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

                        if (CallQueueCustomerId.HasValue)
                        {
                            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                            var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId.Value);
                            var criteriaRepository = IoC.Resolve<ISystemGeneratedCallQueueCriteriaRepository>();
                            var criteria = criteriaRepository.GetQueueCriteria(callQueueCustomer.CallQueueId,
                                IoC.Resolve<ISessionContext>()
                                    .UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            if (newPackagePrice > criteria.Amount)
                            {
                                callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(CallQueueCustomerId.Value, CallQueueStatus.Completed);
                                // incase upsale is done from Confirmation Queue update the upsellQueue

                                var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
                                var callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Confirmation);
                                if (callQueueCustomer.CallQueueId == callQueue.Id)
                                {
                                    callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Upsell);
                                    var upsellCallQueueCustomer = callQueueCustomerRepository.GetByCallQueueIdCustomerIdEventId(callQueue.Id, callQueueCustomer.ProspectCustomerId ?? 0, callQueueCustomer.CustomerId ?? 0, callQueueCustomer.EventId ?? 0);
                                    callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(upsellCallQueueCustomer.Id, CallQueueStatus.Completed);
                                }
                            }
                        }

                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while Changing appointment with payment. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                doEventRegistrationRedirect = false;
            }

            if (doEventRegistrationRedirect)
            {
                var eventRepository = IoC.Resolve<IEventRepository>();
                var eventData = eventRepository.GetById(newEventId);

                try
                {
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

                try
                {
                    IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
                    var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
                    if (eventCustomer.AwvVisitId.HasValue)
                    {
                        var testResultService = IoC.Resolve<TestResultService>();
                        var isEawvPurchased = testResultService.IsTestPurchasedByCustomer(eventCustomer.EventId, eventCustomer.CustomerId, (long)TestType.eAWV);

                        var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventCustomer.EventId);
                        var theEvent = eventRepository.GetById(eventCustomer.EventId);

                        var medicare = IoC.Resolve<IMedicareApiService>();
                        var userSession = IoC.Resolve<ISessionContext>().UserSession;
                        var settings = IoC.Resolve<ISettings>();

                        if (settings.SyncWithHra)
                        {
                            if (userSession != null)
                            {
                                var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();


                                try
                                {
                                    medicare.Connect(userSession.UserLoginLogId);
                                }
                                catch (Exception)
                                {
                                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                    medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                    medicare.Connect(userSession.UserLoginLogId);
                                }

                                if (isEawvPurchased)
                                {
                                    var visitId = medicare.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                                     new MedicareEventEditModel
                                     {
                                         EventId = eventCustomer.EventId,
                                         Tag = account != null ? account.Tag : null,
                                         VisitId = eventCustomer.AwvVisitId.Value,
                                         VisitDate = theEvent.EventDate,
                                         IsFromReschedule = true
                                     });
                                    if (visitId != eventCustomer.AwvVisitId.Value)
                                    {
                                        eventCustomer.AwvVisitId = visitId;
                                        eventCustomerRepository.Save(eventCustomer);
                                    }
                                }
                                else
                                {
                                    var isSuccess = medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Initiated + "&unlock=true");
                                }
                            }
                        }
                        

                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while Updating Event to Medicare. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                }
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                try
                {
                    UpdateEventCustomerPreApprovedTest(newEventId, CustomerId.Value);

                    DeleteEventCustomerCheckListAnswers(newEventId, CustomerId.Value);

                    SavePreQualificationQuestionAnswer(EventCustomerId, orgRoleId);

                    SendMail(CustomerId.Value, newEventId, currentSession);

                    if (!IsProcessRequest)
                    {
                        var reasonId = ParseIntoLong(reasonIdHiddenControl.Value);
                        var subReasonId = ParseIntoLong(subReasonIdHiddenControl.Value);

                        var cancelAppointmentNotificationServcie = IoC.Resolve<ICancellationRescheduleAppointmentNotificationService>();

                        var rescheduleReason = ((RescheduleAppointmentReason)reasonId).GetDescription();
                        var rescheduleSubReason = subReasonId > 0 ? ((RescheduleAppointmentSubReason)subReasonId).GetDescription() : "N/A";

                        cancelAppointmentNotificationServcie.SendCancellationRescheduleAppointmentMail(false, CustomerId.Value, EventId.Value, newEventId, rescheduleReason, orgRoleId, "System: Change Appointment", rescheduleSubReason);
                    }
                }
                catch (Exception)
                {
                }

                SendMailOnRegistrationOfMammoPatientOnNonMammoEvent(eventData, currentSession);

                Page.ClientScript.RegisterStartupScript(typeof(string), "JSCODE", "alert('Appointment change successfully.');", true);

                if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment"));
                }
                else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment"));
                }
                else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment"));
                }
                else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
                {
                    if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    {
                        if (Request.QueryString["CallQueueId"] == "154")
                        {
                            try
                            {
                                var callCenterCall = IoC.Resolve<ICallCenterCallRepository>();
                                if (Request.QueryString["CallID"] != "")
                                {
                                    long callId = Convert.ToInt64(Request.QueryString["CallID"]);
                                    callCenterCall.UpdateCallCenterCallEvent(newEventId, callId);
                                }
                                var setting = IoC.Resolve<ISettings>();
                                Response.RedirectUser(setting.AppUrl + "/CallCenter/PreAssessmentCallQueue/PreAssessmentCall?customerId=" + Request.QueryString["CustomerID"] +
                                                      "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"]);
                            }catch(Exception)
                            {
                               
                            }
                        }
                        else
                        {
                            Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment&Call=No" + "&guid=" + GuId));
                        }
                        
                    }
                    else
                    {
                        if (CallId.HasValue)
                        {
                            var repository = new CallCenterCallRepository();
                            var call = repository.GetCallCenterEntity(CallId.Value);

                            call.CallStatus = CallType.Reschedule.ToString();
                            call.EventID = newEventId;

                            EndCall(call);
                            StartCall(call.CalledCustomerID);

                        }
                        Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment" + "&guid=" + GuId));

                    }
                }
                else if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
                {
                    if (ViewState["CustomerList"] == null)
                        Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" +
                                       CustomerId + "&Action=Appointment"));
                    else
                        Response.RedirectUser(ViewState["ReferredQuery"].ToString());
                }
                else if (CurrentOrgRole.CheckRole((long)Roles.Customer))
                {
                    Response.RedirectUser(ResolveUrl("/App/Customer/HomePage.aspx?Action=Appointment"));
                }
            }
        }

        private bool CheckPreApprovedTest()
        {
            var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
            return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId.Value, TestGroup.BreastCancer);
        }

        private void SendMailOnRegistrationOfMammoPatientOnNonMammoEvent(Event eventData, UserSessionModel currentSession)
        {
            try
            {
                if (Customer != null && eventData != null)
                {
                    var customerHasMammo = CheckPreApprovedTest();
                    if (customerHasMammo)
                    {
                        var eventhasMammoTest = IoC.Resolve<IEventTestRepository>().EventHasMammoTests(eventData.Id);

                        if (!eventhasMammoTest)
                        {
                            var notifier = IoC.Resolve<INotifier>();
                            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                            var mammoNotificationModel = emailNotificationModelsFactory.GetMammoPatientRegestrationOnNonMammoEventViewModel(Customer, eventData);
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.MammoPatientRegistrationOnNonMammoEventNotification, EmailTemplateAlias.MammoPatientRegistrationOnNonMammoEvent, mammoNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
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

        private void EndCall(ECall call)
        {
            call.TimeEnd = DateTime.Now.ToString();
            var callcenterDal = new CallCenterDAL();
            callcenterDal.UpdateCall(call);
        }

        private long ParseIntoLong(string stringToParse)
        {

            long tempValue;
            long.TryParse(stringToParse, out tempValue);

            return tempValue;
        }

        protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();
            Response.RedirectUser(redirecturl);
        }

        private bool RescheduleCustomerEventPackage()
        {
            var result = false;

            try
            {
                result = ChangeAppointment();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while Changing appointment with payment. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_AppointmentAlreadyBooked", " alert('The slot selected is no longer temporarily booked for you. Please choose the slot again.');", true);
            }

            if (result)
            {
                result = ChangeAppointmentPackage();
                //var previousTag = customerService.SetCustomerTag(CustomerId.Value, ParseIntoLong(NewEventId));
                var previousTag = Customer.Tag;
                if (previousTag.Trim() != string.Empty && ParseIntoLong(oldEventIdHiddenControl.Value) != ParseIntoLong(NewEventId))
                {
                    try
                    {

                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var emailNotification = emailNotificationModelsFactory.GetCustomerTagChangeNotificationViewModel(ParseIntoLong(oldEventIdHiddenControl.Value), ParseIntoLong(NewEventId), CustomerId.Value, previousTag);
                        var notifier = IoC.Resolve<INotifier>();
                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                        if (emailNotification.PreviousTag != emailNotification.NewTag)
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerTagUpdated, EmailTemplateAlias.CustomerTagUpdated, emailNotification, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "Change Appointment");
                    }
                    catch (Exception ex)
                    {
                        IoC.Resolve<ILogManager>()
                            .GetLogger<Global>()
                            .Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                    }
                }

            }

            return result;
        }

        private bool ChangeAppointment()
        {
            var slotService = IoC.Resolve<IEventSchedulingSlotService>();

            var tempraryBookedSlotsIds = new List<long>();
            long newEventId = ParseIntoLong(NewEventId);

            if (!string.IsNullOrEmpty(hfSlotIds.Value))
            {
                hfSlotIds.Value.Split(',').ToList().ForEach(t => tempraryBookedSlotsIds.Add(Convert.ToInt64(t)));
            }

            if (slotService.IsSlotBooked(tempraryBookedSlotsIds))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_AppointmentAlreadyBooked", " alert('This appointment slot has already been booked. Please choose another appointment slot.');", true);
                return false;
            }

            var eventCustomerId = EventCustomerId;

            var itemRepository = IoC.Resolve<IUniqueItemRepository<EventCustomer>>();
            var eventCustomerRepository = (IEventCustomerRepository)itemRepository;

            var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();

            var eventCustomer = itemRepository.GetById(eventCustomerId);
            long appointmentIdOld = eventCustomer.AppointmentId.HasValue ? eventCustomer.AppointmentId.Value : 0;
            var currentEventId = eventCustomer.EventId;

            EventCustomerResult eventCustomerResult = null;
            try
            {
                eventCustomerResult = eventCustomerResultRepository.GetById(eventCustomerId);

                if (eventCustomerResult != null && (eventCustomerResult.ResultState > (int)TestResultStateNumber.ManualEntry || eventCustomerResult.ResultState == (int)NewTestResultStateNumber.ResultEntryCompleted) && newEventId != currentEventId)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_RecordPastPreAudit", " alert('Can not reschedule appointment. Record/Result has moved past Pre Audit.');", true);
                    return false;
                }
            }
            catch (ObjectNotFoundInPersistenceException<EventCustomerResult>) { }

            EventCustomer cancelledEventCustomer = null;

            try
            {
                cancelledEventCustomer = eventCustomerRepository.GetCancelledEventForUser(eventCustomer.CustomerId, newEventId);
            }
            catch (ObjectNotFoundInPersistenceException<EventCustomer>)
            { }

            IOrderRepository orderRepository = new OrderRepository();
            var currentOrder = orderRepository.GetOrderByEventCustomerId(eventCustomerId);


            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            var appointment = eventAppointmentService.CreateAppointment(tempraryBookedSlotsIds, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

            eventCustomer.EventId = newEventId;
            eventCustomer.AppointmentId = appointment.Id;
            eventCustomer.NoShow = false;
            eventCustomer.LeftWithoutScreeningReasonId = null;
            eventCustomer.LeftWithoutScreeningNotesId = null;

            itemRepository.Save(eventCustomer);

            var reasonId = ParseIntoLong(reasonIdHiddenControl.Value);
            var subReasonId = ParseIntoLong(subReasonIdHiddenControl.Value);

            eventAppointmentService.SaveChangeAppointmentLog(eventCustomerId, currentEventId, appointmentIdOld, newEventId, appointment.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, reasonId, reasonNotesHiddenControl.Value, subReasonId > 0 ? subReasonId : (long?)null);

            if (appointmentIdOld > 0)
            {
                eventAppointmentService.DeleteAppointment(appointmentIdOld);
            }

            MarkProspectCustomerConverted(eventCustomerId, eventCustomer.CustomerId);

            var customerNotesRepository = IoC.Resolve<ICustomerCallNotesRepository>();
            var eventNotes = customerNotesRepository.GetEventCustomerAppointmentNotes(eventCustomer.CustomerId, currentEventId);
            if (eventNotes != null && eventNotes.Count() > 0)
            {
                foreach (var customerCallNotese in eventNotes)
                {
                    customerCallNotese.EventId = newEventId;
                }

                customerNotesRepository.Update(eventNotes);
            }

            if (eventCustomerResult != null)
            {
                eventCustomerResult.EventId = newEventId;
                eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;
                eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
                eventCustomerResultRepository.Save(eventCustomerResult);
            }

            try
            {
                var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();
                eventSchedulingSlotService.SendEventFillingNotification(newEventId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
            }

            if (cancelledEventCustomer != null)
            {
                var cancelledOrder = orderRepository.GetInactiveOrder(cancelledEventCustomer.CustomerId, cancelledEventCustomer.EventId);
                IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
                orderDetailRepository.UpdateOrderDetail(cancelledOrder.Id, currentOrder.Id);
                eventCustomerRepository.DeleteEventCustomer(cancelledEventCustomer.Id);

                var paymentRepository = IoC.Resolve<IPaymentRepository>();
                var payments = paymentRepository.GetByOrderId(cancelledOrder.Id);
                if (payments != null && payments.Count > 0)
                {
                    paymentRepository.UpdatePayment(payments, currentOrder.Id);
                }
            }
            return true;
        }

        protected void RemoveTestsInPackage(List<long> selectedTestIds, long eventId)
        {
            if (!EventId.HasValue) return;

            var packageRepository = IoC.Resolve<IEventPackageRepository>();
            var eventPackage = packageRepository.GetByEventAndPackageIds(eventId, PackageId);
            var package = eventPackage != null ? eventPackage.Package : null;


            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);
                selectedTestIds.RemoveAll(t => packageTestIds.Contains(t));
            }
        }

        private bool ChangeAppointmentPackage()
        {
            long newEventId = ParseIntoLong(NewEventId);
            IOrderRepository orderRepository = new OrderRepository();

            _order = orderRepository.GetOrder(CustomerId.Value, newEventId);

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;

                var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                var forOrganizationRoleUser = GetForOrganizationRoleUser();

                IOrderController orderController = new OrderController();
                var orderDetail = orderController.GetActiveOrderDetail(_order);

                var orderables = new List<IOrderable>();

                var selectedTestIds = TestIds;

                if (PackageId > 0)
                {
                    IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                    orderables.Add(eventPackageRepository.GetByEventAndPackageIds(newEventId, PackageId));

                    RemoveTestsInPackage(selectedTestIds, newEventId);
                }

                if (!selectedTestIds.IsNullOrEmpty())
                {
                    IEventTestRepository eventTestRepository = new EventTestRepository();
                    var eventTests = eventTestRepository.GetByEventAndTestIds(newEventId, selectedTestIds);
                    if (PackageId > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }
                    orderables.AddRange(eventTests);
                }

                if (orderables.IsNullOrEmpty()) return false;

                var eventCustomer = UpdateEventCustomer(orderDetail, false);

                if (eventCustomer == null) return false;

                List<PaymentInstrument> paymentInstruments = GetActivePaymentInstruments(orderDetail, creatorOrganizationRoleUser);

                var insurancePayment = _order.PaymentsApplied.Where(pi => pi.PaymentType == PaymentType.Insurance).Select(pi => pi).SingleOrDefault();
                if (insurancePayment != null)
                {
                    var insurancePaymentRepository = IoC.Resolve<IInsurancePaymentRepository>();
                    insurancePaymentRepository.Delete(insurancePayment.Id);
                }

                if (EligibilityId > 0 && AmountCoveredByInsurance > 0)
                {
                    paymentInstruments.Add(ManageInsurancePayment(AmountCoveredByInsurance, creatorOrganizationRoleUser));

                    var eligibilityRepository = IoC.Resolve<IEligibilityRepository>();
                    eligibilityRepository.SaveEventCustomerEligibility(eventCustomer.Id, EligibilityId, ChargeCardId);
                }

                paymentInstruments.RemoveAll(pi => pi == null);
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

                bool indentedLineItemsAdded = false;
                // TODO: applying hook to the system all the indented line items will be attached to the first order item.
                foreach (var orderable in orderables)
                {
                    if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                    {
                        orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                               sourceCode,
                                               null, null, OrderStatusState.FinalSuccess);
                        indentedLineItemsAdded = true;
                    }
                    else
                        orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                                OrderStatusState.FinalSuccess);
                }

                Core.Finance.Domain.Order order = orderController.PlaceOrder(_order);
                var isRefundQueueEnabled = IoC.Resolve<ISettings>().IsRefundQueueEnabled;

                long requestId = 0;
                if (Request.QueryString[RefundRequest.ProcessRequestId] != null)
                    long.TryParse(Request.QueryString[RefundRequest.ProcessRequestId], out requestId);

                bool toProcessOrder = (!isRefundQueueEnabled || !(TotalAmountPayable < 0)) || CheckOnOrderWhethertoprocessRefundOrdNot(requestId, (int)RequestResultType.AdjustOrder);

                if ((!isRefundQueueEnabled) || toProcessOrder)
                {
                    if (TotalAmountPayable >= 0 && isRefundQueueEnabled)
                        CheckifanUnresolvedRequestExistsforanOrder(order.Id);

                    if (!paymentInstruments.IsNullOrEmpty())//!IsOnSitePayment && TotalAmountPayable != 0 &&
                        ApplyPaymentToOrder(creatorOrganizationRoleUser, paymentInstruments, order);
                    else if (!IsOnSitePayment && TotalAmountPayable != 0 && paymentInstruments.IsNullOrEmpty())
                        return false;
                }

                IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                    new AffiliateCommisionGenerationRepository();
                return affiliateCommisionGenerationRepository.SaveEventAffiliate(eventCustomer.Id, CallId);
            }

            return true;
        }

        private void MarkProspectCustomerConverted(long eventCustomerId, long customerId)
        {
            var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
            var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
            if (prospectCustomer != null)
            {
                var customerService = IoC.Resolve<ICustomerService>();
                customerService.MarkProspectCustomerConverted(eventCustomerId);
            }
        }

        private void SendMail(long customerId, long eventId, UserSessionModel currentSession)
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var theEvent = eventRepository.GetById(eventId);
            var settings = IoC.Resolve<ISettings>();
            var daysIntervalBeforeEvent = settings.DaysBeforeScreeningReminder;

            if (DateTime.Now.AddDays(daysIntervalBeforeEvent).Date >= theEvent.EventDate.Date)
            {
                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var notifier = IoC.Resolve<INotifier>();
                var customer = customerRepository.GetCustomer(customerId);
                var appointmentConfirmationViewModel = emailNotificationModelsFactory.GetAppointmentConfirmationModel(theEvent.Id, customerId);

                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(eventId);

                string emailTemplateAlias = EmailTemplateAlias.ScreeningReminderMail;
                if (account != null && account.AppointmentReminderMailTemplateId > 0)
                {
                    var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
                    var emailTemplate = emailTemplateRepository.GetById(account.AppointmentReminderMailTemplateId);
                    emailTemplateAlias = emailTemplate.Alias;
                }

                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ScreeningReminderMail, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "Change Appointment", useAlternateEmail: true);
            }
        }

        private void UpdateEventCustomerPreApprovedTest(long eventId, long customerId)
        {
            IoC.Resolve<IEventCustomerPreApprovedTestService>().UpdateEventCustomerPreApprovedTest(eventId, customerId);
        }

        private void DeleteEventCustomerCheckListAnswers(long eventId, long customerId)
        {
            var eventCustomer = IoC.Resolve<EventCustomerRepository>().Get(eventId, customerId);
            if (eventCustomer != null)
                IoC.Resolve<ICheckListAnswerRepository>().DeleteEventCustomerCheckListAnswers(eventCustomer.Id);
        }

        private void SavePreQualificationQuestionAnswer(long eventCustomerId, long organizationRoleUserId)
        {
            if (eventCustomerId > 0 && !string.IsNullOrEmpty(hfQuestionAnsTestId.Value) && CustomerId.HasValue && CustomerId.Value > 0 && EventId.HasValue && EventId.Value > 0)
            {
                var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(hfQuestionAnsTestId.Value, hfDisqualifedTest.Value, eventCustomerId, CustomerId.Value, EventId.Value, organizationRoleUserId);
            }
        }
    }
}