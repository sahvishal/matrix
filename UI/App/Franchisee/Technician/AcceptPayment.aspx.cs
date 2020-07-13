using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.Lib;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Extensions;
using EEventCustomer = Falcon.Entity.Other.EEventCustomer;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class AcceptPayment : PaymentInstrumentCharger
    {
        public bool IsFullfillmentOption
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["Type"]) &&
                Request.QueryString["Type"].Equals("FullfillmentOption")
                    ? true
                    : false;
            }
        }

        public string StateId
        {
            get
            {
                return ddlstate.SelectedValue;
            }
        }

        protected override long? EventId
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["EventID"])
                           ? (long?)Convert.ToInt64(Request.QueryString["EventID"])
                           : null;
            }
        }

        protected override long? CustomerId
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["CustomerID"])
                                 ? (long?)Convert.ToInt64(Request.QueryString["CustomerID"])
                                 : null;
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

        protected override bool MakePaymentsForExistingOrder()
        {
            SetSourceCodeData();

            return base.MakePaymentsForExistingOrder();
        }

        protected override OrganizationRoleUser GetOrganizationRoleUser()
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            return organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        //TODO: SRE
        protected override ShippingDetail ShippingDetail
        {
            get
            {
                if (ShippingOptionId.HasValue && ShippingAddressId.HasValue)
                {
                    var shippingDetail = GetShippingDetailData(ShippingOptionId.Value, ShippingAddressId.Value);
                    if (Session["ShippingDetailId"] != null)
                        shippingDetail.Id = Convert.ToInt64(Session["ShippingDetailId"]);
                    return shippingDetail;
                }
                return null;
            }
            set
            {
                Session["ShippingDetailId"] = value.Id;
            }
        }

        protected override bool IsBillingAddressSameAsHomeAddress
        {
            get
            {
                return rbtBilingAddressSame.Checked;
            }
            set
            {
                rbtBilingAddressSame.Checked = value;
                rbtBilingAddressDiff.Checked = !value;
            }
        }

        protected override HiddenField StateHiddenField
        {
            get
            {
                return hfstate;
            }
        }

        protected override DropDownList CountryCombo
        {
            get
            {
                if (ddlcountry.SelectedValue == "0")
                    ddlcountry.SelectedValue = hfcountryid.Value;
                return ddlcountry;
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
                if (string.IsNullOrEmpty(txtAddress1.Text))
                    txtAddress1 = new TextBox { Text = hfaddress1.Value };
                return txtAddress1;
            }
        }

        protected override TextBox Address2TextBox
        {
            get
            {
                if (string.IsNullOrEmpty(txtAddress2.Text))
                    txtAddress2 = new TextBox { Text = hfaddress2.Value };
                return txtAddress2;
            }
        }

        protected override TextBox CityTextBox
        {
            get
            {
                if (string.IsNullOrEmpty(txtCity.Text))
                    txtCity = new TextBox { Text = hfcityname.Value };
                return txtCity;
            }
        }

        protected override TextBox ZipTextBox
        {
            get
            {
                if (string.IsNullOrEmpty(txtZip.Text))
                    txtZip = new TextBox { Text = hfzipcode.Value };
                return txtZip;
            }
        }

        protected override TextBox PhoneTextBox
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

        protected override void BindPaymentModeDropDown()
        {

            hfPaymentTypeID.Value = PaymentType.Cash.PersistenceLayerId.ToString();

            ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
            //ddlpaymentmode.Items.Add(new ListItem(PaymentType.GiftCertificate.Name,
            //                                          PaymentType.GiftCertificate.PersistenceLayerId.ToString()));

            if (CurrentRole == Roles.FranchisorAdmin || CurrentRole == Roles.FranchiseeAdmin)
            {

                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                if (!IsFullfillmentOption)
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }
            else if (CurrentRole == Roles.Customer)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
            }
            else if (CurrentRole == Roles.Technician)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                if (!IsFullfillmentOption)
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }
            else if (CurrentRole == Roles.CallCenterRep)
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));

                if (!IsFullfillmentOption)
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }

            var listItems = ddlpaymentmode.Items.Cast<ListItem>().ToList().OrderBy(li => li.Text).ToList();

            if (IsFullfillmentOption)
                listItems.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));

            ddlpaymentmode.Items.Clear();
            ddlpaymentmode.Items.AddRange(listItems.ToArray());

            ddlpaymentmode.Items.Insert(0, new ListItem("Pay By:", "0"));

            ddlpaymentmode.SelectedValue = PaymentType.CreditCard.PersistenceLayerId.ToString();
        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            var strJsCloseWindow = new System.Text.StringBuilder();

            switch (ddlpaymentmode.SelectedItem.Text)
            {
                case "Credit Card":
                    if (PaymentGatewayResponse != null && PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
                        strJsCloseWindow.Append(" <script language = 'Javascript'> OpenCloseDivatSave(); alert('" + PaymentGatewayResponse.Message.Replace("'", "\\\'") + ".'); NavigateBillAddress('" + (IsBillingAddressSameAsHomeAddress ? "Yes" : "No") + "'); </script>");
                    else
                        strJsCloseWindow.Append(" <script language = 'Javascript'> OpenCloseDivatSave(); alert('" + errorMessage.Replace("'", "\\\'") + "'); NavigateBillAddress('" + (IsBillingAddressSameAsHomeAddress ? "Yes" : "No") + "'); </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode2", strJsCloseWindow.ToString());
                    break;
                case "eCheck":
                    if (PaymentGatewayResponse != null && PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
                    {
                        strJsCloseWindow.Append(" <script language = 'Javascript'> OpenCloseDivatSave(); alert('" +
                                                PaymentGatewayResponse.Message.Replace("'", "\\\'") + ".'); NavigateBillAddress('Yes'); </script>");
                    }
                    else
                        strJsCloseWindow.Append(" <script language = 'Javascript'> OpenCloseDivatSave(); alert('" + errorMessage.Replace("'", "\\\'") + "'); NavigateBillAddress('" + (IsBillingAddressSameAsHomeAddress ? "Yes" : "No") + "'); </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode2", strJsCloseWindow.ToString());
                    break;
                default:
                    strJsCloseWindow.Append(" <script language = 'Javascript'> OpenCloseDivatSave(); alert('" + errorMessage.Replace("'", "\\\'") + "'); NavigateBillAddress('" + (IsBillingAddressSameAsHomeAddress ? "Yes" : "No") + "'); </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode2", strJsCloseWindow.ToString());
                    break;
            }
        }

        protected override ViewType CurrentViewType
        {
            get
            {
                return (ViewType)Enum.Parse(typeof(ViewType), IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias);
            }
        }

        public Roles CurrentRole
        {
            get { return (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId; }

        }

        private long? ShippingOptionId
        {
            get
            {
                if (Session["ShippingOptionId"] != null && !string.IsNullOrEmpty(Session["ShippingOptionId"].ToString()))
                {
                    long shippingOptionId;
                    if (Int64.TryParse(Session["ShippingOptionId"].ToString(), out shippingOptionId))
                        return shippingOptionId;
                }
                return null;
            }
            set { Session["ShippingOptionId"] = value; }
        }

        private long? ShippingAddressId
        {
            get
            {
                if (Session["ShippingAddressId"] != null && !string.IsNullOrEmpty(Session["ShippingAddressId"].ToString()))
                {
                    long shippingOptionAddressId;
                    if (Int64.TryParse(Session["ShippingAddressId"].ToString(), out shippingOptionAddressId))
                        return shippingOptionAddressId;
                }
                return null;
            }
            set { Session["ShippingAddressId"] = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlpaymentmode.Attributes.Add("onChange", "OpenCloseDiv('" + ddlpaymentmode.ClientID + "')");

            if (!IsPostBack)
            {
                txtCashAmount.ReadOnly = true;

                BindAllDropDowns();

                if (IsFullfillmentOption)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                        ShippingOption.EventId = Convert.ToInt64(Request.QueryString["EventId"]);

                    EventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
                    DivAcceptPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
                    DivFullfillmentOption.Style.Add(HtmlTextWriterStyle.Display, "block");

                    _customer = ShippingOption.GetCustomerData();

                    FillShippingAddress();

                    ShippingOption.ShowOnlineOption = false;
                    Page.Title = "Fulfillment Option";

                    PartialPaymentDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    var orderRepository = IoC.Resolve<IOrderRepository>();
                    var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                    if (order != null && !order.OrderDetails.IsEmpty())
                    {
                        SetCreditCardOnFileDetails(order);
                    }
                }
                else
                {

                    EventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
                    DivAcceptPayment.Style.Add(HtmlTextWriterStyle.Display, "block");
                    DivFullfillmentOption.Style.Add(HtmlTextWriterStyle.Display, "none");

                    IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
                    var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
                    if (eventCustomer != null)
                    {
                        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                        var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(eventCustomer.DataRecorderMetaData.DataRecorderCreator.Id);

                        EventRegisteredBy = (Roles)Enum.Parse(typeof(Roles), orgRoleUser.RoleId.ToString());
                    }

                    if (EventCustomerId > 0 && CheckValidCoupon())
                    {
                        var orderRepository = IoC.Resolve<IOrderRepository>();
                        var orderId = orderRepository.GetOrderIdByEventCustomerId(EventCustomerId);
                        var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                        var eventPackage = eventPackageRepository.GetPackageForOrder(orderId);

                        if (eventPackage != null)
                        {
                            PackageCost = eventPackage.Package.Price;
                            hfpackagecost.Value = eventPackage.Package.Price.ToString();
                            hfeventid.Value = eventPackage.EventId.ToString();
                        }
                    }
                    else
                        divapplycoupon.Visible = false;

                    GetCustomerBillingDetail();

                    if (CurrentRole == Roles.CallCenterRep)
                        PartialPaymentDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                    else if (CurrentRole == Roles.Technician)
                        PartialPaymentDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                RegisterJavaScriptEvents();
            }

        }

        protected void ibtnAccept_Click(object sender, ImageClickEventArgs e)
        {
            if (IsFullfillmentOption)
            {
                if (Convert.ToInt64(hfResultOrderID.Value) > 0)
                {
                    SetShippingDetailData();
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            if (PlaceNewShippingOrder())
                            {
                                scope.Complete();
                                Session["ShippingDetailId"] = null;
                                Session["ShippingOptionId"] = null;
                                Session["ShippingAddressId"] = null;
                                ClientScript.RegisterStartupScript(typeof(string), "jscode6",
                                                                   " OpenCloseDivatSave(); alert('Shipping option purchased succesfully.'); ",
                                                                   true);
                            }
                            else
                                return;
                        }
                    }
                    catch (InvalidAddressException ex)
                    {
                        SetAndDisplayErrorMessage(ex.Message);
                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
                    }
                    catch (Exception exception)
                    {
                        SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + exception.Message);
                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message" + exception.Message + " \n Stack Trace: " + exception.StackTrace);
                    }
                }
                var strJsCloseWindow = new System.Text.StringBuilder();
                strJsCloseWindow.Append("<script language = 'Javascript'> window.location='blank.aspx';</script>");
                ClientScript.RegisterStartupScript(typeof(string), "JSCode_CloseWindow", strJsCloseWindow.ToString());
            }
            else
            {
                bool doEventRegistrationRedirect = false;
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        TotalAmountPayable = Convert.ToDecimal(AmountTobePaidTextbox.Text);
                        doEventRegistrationRedirect = MakePaymentsForExistingOrder();
                        scope.Complete();
                    }

                }
                catch (InvalidAddressException ex)
                {
                    SetAndDisplayErrorMessage(ex.Message);
                    doEventRegistrationRedirect = false;
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message:" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
                }
                catch (Exception ex)
                {
                    SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                    doEventRegistrationRedirect = false;
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message:" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
                }
                if (doEventRegistrationRedirect)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode6", " OpenCloseDivatSave(); alert('Payment processed successfully.'); ", true);

                    if (Request.QueryString["PageCallBackFrom"] != null && (Request.QueryString["PageCallBackFrom"].Equals("CustomerDetail") || Request.QueryString["PageCallBackFrom"].Equals("CustomerDashboard")))
                    {
                        SendReciept();
                        var strJsCloseWindow = new System.Text.StringBuilder();
                        if (Request.QueryString["PageCallBackFrom"].Equals("CustomerDashboard"))
                            strJsCloseWindow.Append("<script language = 'Javascript'> window.close();window.opener.location.reload();</script>");
                        else
                            strJsCloseWindow.Append("<script language = 'Javascript'> window.location='blank.aspx';</script>");
                        ClientScript.RegisterStartupScript(typeof(string), "JSCode_CloseWindow", strJsCloseWindow.ToString());
                    }
                    else
                    {
                        var strJsCloseWindow = new System.Text.StringBuilder();
                        strJsCloseWindow.Append("<script language = 'Javascript'> window.location='blank.aspx';</script>");
                        ClientScript.RegisterStartupScript(typeof(string), "JSCode_CloseWindow", strJsCloseWindow.ToString());
                    }
                    //Response.RedirectUser("/Config/Content/Controls/SmallPrintReciept.aspx?CustomerID=" + customerid + "&EventID=" + eventid + "&PageCallBackFrom=AcceptPayment");
                }
            }

        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var roleRepository = IoC.Resolve<IRoleRepository>();
            var role = roleRepository.GetByRoleId(roleId);

            if (role == null) return 0;

            return role.ParentId ?? 0;
        }

        protected void ibtnApplyCoupon_Click(object sender, ImageClickEventArgs e)
        {
            var signUpMode = SignUpMode.Online;
            if (EventRegisteredBy.Equals(Roles.Customer) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Customer))
                signUpMode = SignUpMode.Online;
            else if (EventRegisteredBy.Equals(Roles.Technician) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Technician))
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
                    var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, txtCoupon.Text, EventId.Value, CustomerId.Value, signUpMode, shippingAmount, (order.ProductCost.HasValue ? order.ProductCost.Value : 0));
                    var serializer = new JavaScriptSerializer();

                    string chkAddress = rbtBilingAddressSame.Checked ? "Yes" : "no";

                    var strJsCloseWindow = new System.Text.StringBuilder();
                    strJsCloseWindow.Append(" <script language = 'Javascript'>OpenCloseDivatSave();NavigateBillAddress('" +
                                            chkAddress + "');ApplyCouponAmount('" + serializer.Serialize(model) + "') </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "js_ApplyCoupon", strJsCloseWindow.ToString());
                }
            }
        }

        private void GetCustomerBillingDetail()
        {
            string shippingOptionsLabel = string.Empty;

            var orderRepository = IoC.Resolve<IOrderRepository>();
            var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);

            if (order != null && !order.OrderDetails.IsEmpty())
            {
                SetCreditCardOnFileDetails(order);
                OrderId = order.Id;
                var shippingDetailIds =
                    order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(shod => shod.ShippingDetailId)).ToList();

                if (!shippingDetailIds.IsEmpty())
                {
                    var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();

                    var shippingOptions =
                        shippingOptionRepository.GetShippingOptionsByShippingDetailIds(shippingDetailIds);

                    if (!shippingOptions.IsEmpty())
                    {
                        shippingOptionsLabel = shippingOptions
                            .Where(shippingOption => shippingOption != null && !string.IsNullOrEmpty(shippingOption.Name))
                            .Aggregate(shippingOptionsLabel, (current, shippingOption) => current + ("<u>" + shippingOption + "</u>" + ","));

                        shippingOptionsLabel = shippingOptionsLabel.Remove(shippingOptionsLabel.LastIndexOf(","));

                        if (shippingOptions.Count == 1)
                            shippingOptionsLabel = " and for Shipping option " + shippingOptionsLabel;
                        else
                            shippingOptionsLabel = " and for Shipping options " + shippingOptionsLabel;
                    }
                }
                TotalAmountPayable = order.DiscountedTotal - order.TotalAmountPaid;
                TotalAmountPaid.Value = order.TotalAmountPaid.ToString();
                spbillingamount.InnerHtml = "$" + TotalAmountPayable.Value.ToString("#.##");
                hfnetpayment.Value = TotalAmountPayable.Value.ToString("#.##");
                hftoatalcost.Value = TotalAmountPayable.Value.ToString("#.##");

                var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                var eventTestRepository = IoC.Resolve<IEventTestRepository>();

                var eventPackage = eventPackageRepository.GetPackageForOrder(order.Id);
                var eventTests = eventTestRepository.GetTestsForOrder(order.Id);

                string orderPurchaseString = "";
                if (eventPackage != null && eventPackage.Package != null)
                {
                    orderPurchaseString = eventPackage.Package.Name;
                    PackageId = eventPackage.PackageId;
                }

                if (eventTests != null && eventTests.Count() > 0)
                {
                    var tests = eventTests.Select(et => et.Test).ToArray();
                    var testString = string.Join(" + ", tests.Select(t => t.Name));
                    orderPurchaseString = orderPurchaseString.Length > 0
                                              ? orderPurchaseString + " + " + testString
                                              : testString;
                }

                if (CurrentRole == Roles.Customer)
                {
                    spancustomer.InnerHtml = "Make payment for Screening Order <u>" +  HttpUtility.HtmlEncode(orderPurchaseString) + "</u>" +  HttpUtility.HtmlEncode(shippingOptionsLabel);
                }
                else
                {
                    spancustomer.InnerHtml = "Receive payment for <u>" + HttpUtility.HtmlEncode(Customer.NameAsString) + "</u> for Screening Order <u>" +  HttpUtility.HtmlEncode(orderPurchaseString) + "</u>";
                }
            }

            if (Customer != null && Customer.Address != null)
            {
                Page.Title = Customer.NameAsString + " - Customer Payment";
                hfaddress1.Value = Customer.Address.StreetAddressLine1;
                hfaddress2.Value = Customer.Address.StreetAddressLine2;
                hfcountryid.Value = Customer.Address.CountryId.ToString();
                hfstate.Value = Customer.Address.State;
                hfcityname.Value = Customer.Address.City;
                hfzipcode.Value = Customer.Address.ZipCode.Zip;
                hfphonehome.Value = new CommonCode().FormatPhoneNumber(Customer.HomePhoneNumber.ToString());
            }
        }

        private bool CheckValidCoupon()
        {
            var masterDal = new MasterDAL();
            List<EEventCustomer> objCustomer = masterDal.GetCouponDetailByEventCustomerID(Convert.ToInt32(Request.QueryString["EventCustomerID"]));
            if (objCustomer.Count > 0)
            {
                return false;
            }
            return true;
        }

        private void SendReciept()
        {
            try
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
                {
                    var customerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
                    var eventId = Convert.ToInt64(Request.QueryString["EventID"]);

                    ICustomerRepository customerRepository = new CustomerRepository();
                    var customer = customerRepository.GetCustomer(customerId);

                    var notifier = IoC.Resolve<INotifier>();
                    var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                    var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                    var appointmentConfirmationViewModel = emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventId, customerId);
                    
                    var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                    var account = corporateAccountRepository.GetbyEventId(eventId);

                    string emailTemplateAlias = EmailTemplateAlias.AppointmentConfirmationWithEventDetails;
                    if (account != null && account.AppointmentConfirmationMailTemplateId > 0)
                    {
                        var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
                        var emailTemplate = emailTemplateRepository.GetById(account.AppointmentConfirmationMailTemplateId);
                        emailTemplateAlias = emailTemplate.Alias;
                    }

                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentConfirmationWithEventDetails, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath,useAlternateEmail:true);
                }
            }
            catch (Exception)
            {

            }
        }

        private void FillShippingAddress()
        {
            if (Customer != null && Customer.Address != null)
            {
                hfaddress1.Value = Customer.Address.StreetAddressLine1;
                hfcountryid.Value = Customer.Address.CountryId.ToString();
                hfstate.Value = Customer.Address.State;
                hfcityname.Value = Customer.Address.City;
                hfzipcode.Value = Customer.Address.ZipCode.Zip;
                hfphonehome.Value = new CommonCode().FormatPhoneNumber(Customer.HomePhoneNumber.ToString());
            }
        }

        private void SetSourceCodeData()
        {
            var signUpMode = SignUpMode.Online;
            if (EventRegisteredBy.Equals(Roles.Customer) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Customer))
                signUpMode = SignUpMode.Online;
            else if (EventRegisteredBy.Equals(Roles.Technician) || GetParentRoleIdByRoleId((long)EventRegisteredBy).Equals((long)Roles.Technician))
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
                    var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, txtCoupon.Text, EventId.Value, CustomerId.Value, signUpMode, shippingAmount, (order.ProductCost.HasValue ? order.ProductCost.Value : 0));

                    if (model.SourceCodeId > 0)
                    {
                        SourceCode = model.SourceCode;
                        SourceCodeId = model.SourceCodeId;
                        SourceCodeAmount = model.DiscountApplied;
                    }
                }
            }
        }

        private void BindAllDropDowns()
        {
            BindCountryDropDown();

            BindPageDropDowns();
        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            ddlcountry.DataSource = countryRepository.GetAll();
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataValueField = "Id";
            ddlcountry.DataBind();
            //ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlcountry.Items[0].Selected = true;
        }

        private void RegisterJavaScriptEvents()
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode3", " OpenCloseDiv('" + ddlpaymentmode.ClientID + "'); ", true);
            txtCardNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAccountNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtChequeNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtSecurityNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            //txtZip.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtRoutingNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtCashAmount.Attributes.Add("onKeyDown", "return txtkeypressdecimalallowed(event);");
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

        private void SetShippingDetailData()
        {
            if (Convert.ToInt64(hfResultOrderID.Value) > 0)
            {
                ShippingOptionId = Convert.ToInt64(hfResultOrderID.Value);
                var shippingAddress = ShippingOption.SaveShippingAddress();
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

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            var creditCardPaymentInstrument =
                order.PaymentsApplied.OrderBy(pa => pa.DataRecorderMetaData.DateCreated).LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;

            if (creditCardPaymentInstrument == null) return;

            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
            var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
            spcardholder.InnerText = existingChargeCard.NameOnCard;
            string cardnumber = existingChargeCard.Number;
            if (cardnumber.Length > 0)
            {
                string dispcardnumber = "";
                for (int jcount = 0; jcount < cardnumber.Length - 4; jcount++)
                {
                    dispcardnumber = dispcardnumber + "X";
                }

                dispcardnumber += cardnumber.Substring(cardnumber.Length - 4, 4);

                spccnumber.InnerText = dispcardnumber;
                spcctype.InnerHtml =
                    Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();

                spexpdate.InnerHtml = existingChargeCard.ExpirationDate.ToString("MM/yyyy");
                //hfCardTypeId.Value = ((int)existingChargeCard.TypeId).ToString();

                ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));
            }
        }

    }
}