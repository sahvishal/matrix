using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Extensions;
using System.Transactions;
using System.Web.UI.HtmlControls;
using Product = Falcon.App.Core.Enum.Product;

namespace Falcon.App.UI.App.Shipping.UserControl
{
    public partial class CancelShippingDetail : PaymentCharger
    {
        private readonly IOrderController _orderController = new OrderController();
        private readonly IShippingDetailRepository _shippingDetailRepository = new ShippingDetailRepository();
        private readonly IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository =
                            new ShippingDetailOrderDetailRepository();

        protected override long OrderId
        {
            get
            {
                if (base.OrderId == 0)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
                    {
                        long id;
                        if (Int64.TryParse(Request.QueryString["OrderId"], out id))
                            base.OrderId = id;
                    }
                }
                return base.OrderId;
            }
        }

        private string ReturnUrl
        {
            get
            {
                if (ViewState["ReturnUrl"] != null && !string.IsNullOrEmpty(ViewState["ReturnUrl"].ToString()))
                {
                    return ViewState["ReturnUrl"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState["ReturnUrl"] = value;
            }
        }

        private long OrderDetailId { get; set; }

        public decimal AmountPaid
        {
            get
            {
                var amountPaid = 0.0m;
                Decimal.TryParse(TotalPaymentAmount.Value, out amountPaid);
                return amountPaid;
            }
            set { TotalPaymentAmount.Value = value.ToString(); }
        }

        public decimal DiscountedTotal
        {
            get
            {
                var discountTotal = 0.0m;
                Decimal.TryParse(DiscountedTotalAmount.Value, out discountTotal);
                return discountTotal;
            }
            set { DiscountedTotalAmount.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDropDowns();
                SetCreditCardOnFileDetails(CurrentOrder);
                BindShippingDetailGrid();
                if (UrlValidator.IsUrlLocalToHost(Request, Request.UrlReferrer.PathAndQuery))
                    ReturnUrl = Request.UrlReferrer.PathAndQuery;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            if (UrlValidator.IsUrlLocalToHost(Request, ReturnUrl))
                Response.RedirectUser(ReturnUrl);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (BillingAddressSameRadio.Checked)
            {
                ListItem itemAlreadySelectedState = StateDropDown.Items.FindByValue(StateIdHidden.Value);
                if (itemAlreadySelectedState != null)
                    itemAlreadySelectedState.Selected = true;
                CityText.Text = CityHidden.Value;
                ZipText.Text = ZipHidden.Value;
                Address1Text.Text = Address1Hidden.Value;
            }

            bool isStatusUpdated = false;
            TotalAmountPayable = 0.0m;
            var selectedRows = GetSelectedRows();
            try
            {
                using (var transaction = new TransactionScope())
                {
                    if (PaymentMode.SelectedValue != PaymentType.CreditCard.PersistenceLayerId.ToString() ||
                        AddressValidation())
                    {
                        foreach (var row in selectedRows)
                        {
                            if (row == null) continue;

                            var orderDetailIdLiteral = row.FindControl("OrderDetailIdLiteral") as Literal;
                            var shippingDetailIdLiteral = row.FindControl("ShippingDetailIdLiteral") as Literal;
                            var actualPrice = row.FindControl("PriceLabel") as Label;

                            if (orderDetailIdLiteral != null && shippingDetailIdLiteral != null)
                            {
                                var orderDetailId = Convert.ToInt64(orderDetailIdLiteral.Text);
                                var shippingDetailId = Convert.ToInt64(shippingDetailIdLiteral.Text);

                                isStatusUpdated = _shippingDetailOrderDetailRepository.UpdateStatus(shippingDetailId, orderDetailId, false);

                                var shippingDetail = _shippingDetailRepository.GetById(shippingDetailId);
                                shippingDetail.Status = ShipmentStatus.Cancelled;
                                _shippingDetailRepository.Save(shippingDetail);

                                var resultShippingDetails = _shippingDetailRepository.GetShippingDetailsForCancellation(orderDetailId).ToList();
                                var productShippingDetails = _shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetailId).ToList();
                                if (productShippingDetails.Count > resultShippingDetails.Count)
                                {
                                    var productShippingDetail = productShippingDetails.FirstOrDefault();
                                    if (productShippingDetail != null)
                                    {
                                        _shippingDetailOrderDetailRepository.UpdateStatus(productShippingDetail.Id, orderDetailId, false);
                                        productShippingDetail.Status = ShipmentStatus.Cancelled;
                                        _shippingDetailRepository.Save(productShippingDetail);
                                        CheckEventCustomerResultStateAndDeleteCdGenTrackRecord();
                                    }
                                }

                                if (actualPrice != null && !string.IsNullOrEmpty(actualPrice.Text))
                                    TotalAmountPayable += Convert.ToDecimal(actualPrice.Text);
                            }
                        }

                        if (AmountPaid < (DiscountedTotal - TotalAmountPayable))
                            TotalAmountPayable = 0;
                        else
                            TotalAmountPayable = AmountPaid - (DiscountedTotal - TotalAmountPayable);

                        var isRefundQueueEnabled = IoC.Resolve<ISettings>().IsRefundQueueEnabled;

                        if (PaymentMode.SelectedValue == PaymentType.CreditCard.PersistenceLayerId.ToString() &&
                            BillingAddressDifferentRadio.Checked && !isRefundQueueEnabled)
                        {
                            var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();
                            UpdateCustomerBillingAddress(creatorOrganizationRoleUser.Id);
                        }

                        if (isStatusUpdated)
                        {
                            if (TotalAmountPayable > 0)
                            {
                                if (isRefundQueueEnabled)
                                {
                                    var refundRequest = PrepareRefundRequestObject();
                                    var refundRequestValidator = IoC.Resolve<RefundRequestEditModelValidator>();
                                    var result = refundRequestValidator.Validate(refundRequest);
                                    if (result.IsValid)
                                    {
                                        IoC.Resolve<IRefundRequestService>().SaveRequest(refundRequest);
                                    }
                                    else
                                    {
                                        var propertyNames = result.Errors.Select(er => er.PropertyName).Distinct();
                                        var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(er => er.PropertyName == property).FirstOrDefault().ErrorMessage + "&nbsp;&nbsp;"));
                                        MessageBox.ShowErrorMessage(htmlString);
                                        return;
                                    }
                                }
                                else
                                {
                                    var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();
                                    var paymentInstrument = RefundPayment(creatorOrganizationRoleUser,
                                                                          OrderId + "_" + CustomerId);
                                    if (paymentInstrument != null &&
                                        ApplyPaymentToOrder(creatorOrganizationRoleUser, CurrentOrder, paymentInstrument))
                                    {
                                        transaction.Complete();
                                        Response.RedirectUser(ReturnUrl);
                                    }
                                    else
                                        SetAndDisplayErrorMessage("Oops some error occured in the system please try again later.");
                                }
                            }
                            transaction.Complete();
                            if (UrlValidator.IsUrlLocalToHost(Request, ReturnUrl))
                                Response.RedirectUser(ReturnUrl);
                        }
                        else
                            SetAndDisplayErrorMessage("Oops some error occured in the system please try again later.");
                    }
                }
            }
            catch (InvalidOperationException)
            {

            }
            catch { SetAndDisplayErrorMessage("Oops some error occured in the system please try again later."); }
        }

        private void CheckEventCustomerResultStateAndDeleteCdGenTrackRecord()
        {
            var electronicProductRepository = IoC.Resolve<IElectronicProductRepository>();
            var cdContentGeneratorTrackingRepository = IoC.Resolve<ICdContentGeneratorTrackingRepository>();
            var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();

            var eventCustomer = eventCustomerRepository.GetEventCustomerByOrderId(OrderId);
            if (eventCustomer == null)
                return;

            var isCdPurchased = electronicProductRepository.IsProductPurchased(eventCustomer.EventId, eventCustomer.CustomerId, Product.UltraSoundImages);
            if (isCdPurchased) return;

            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(eventCustomer.CustomerId, eventCustomer.EventId);
            if (eventCustomerResult == null) return;
            try
            {
                var cdContent = cdContentGeneratorTrackingRepository.GetCdContentGeneratedforEventCustomerIds(new[] { eventCustomerResult.Id }).FirstOrDefault();
                if (cdContent != null)
                {
                    cdContentGeneratorTrackingRepository.Delete(cdContent.Id);
                }
            }
            catch
            {

            }
        }

        protected RefundRequestEditModel PrepareRefundRequestObject()
        {
            var model = new RefundRequestEditModel();
            var members = typeof(RefundRequestEditModel).GetMembers();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                        continue;
                }
                else
                    continue;

                string propertyName = memberInfo.Name;
                if (Request.Form[propertyName] != null)
                {
                    SetValue(propInfo, model, propertyName);
                }

            }
            return model;
        }

        private RefundRequestEditModel SetValue(PropertyInfo propInfo, RefundRequestEditModel model, string propertyName)
        {
            if (Request.Form[propertyName] != null && !string.IsNullOrEmpty(Request.Form[propertyName]))
            {
                if (propInfo.PropertyType == typeof(Int32))
                {
                    propInfo.SetValue(model, Convert.ToInt32(Request.Form[propertyName]), null);
                }
                else if (propInfo.PropertyType == typeof(Int64))
                {
                    propInfo.SetValue(model, Convert.ToInt64(Request.Form[propertyName]), null);
                }
                else if (propInfo.PropertyType == typeof(Int16))
                {
                    propInfo.SetValue(model, Convert.ToInt16(Request.Form[propertyName]), null);
                }
                else if (propInfo.PropertyType == typeof(DateTime))
                {
                    propInfo.SetValue(model, Convert.ToDateTime(Request.Form[propertyName]), null);
                }
                else if (propInfo.PropertyType == typeof(decimal))
                {
                    propInfo.SetValue(model, Convert.ToDecimal(Request.Form[propertyName]), null);
                }
                else if (propInfo.PropertyType.BaseType == typeof(Enum))
                {
                    if (Enum.IsDefined(propInfo.PropertyType, Request.Form[propertyName]))
                    {
                        var value = Enum.Parse(propInfo.PropertyType, Request.Form[propertyName]);
                        propInfo.SetValue(model, value, null);
                    }
                }
                else
                {
                    propInfo.SetValue(model, Request.Form[propertyName], null);
                }
            }
            return model;
        }

        protected void AvailableShippingDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var currentShippingDetail = e.Row.DataItem as ShippingDetail;
                if (currentShippingDetail != null)
                {
                    var checkSelect = e.Row.FindControl("chkSelect") as CheckBox;
                    if (checkSelect != null && currentShippingDetail.Status != ShipmentStatus.Processing)
                    {
                        checkSelect.Enabled = false;
                        checkSelect.CssClass += " not-clickable";
                        var beyondProcessingStatusSpan =
                            e.Row.FindControl("BeyondProcessingStatusSpan") as HtmlContainerControl;
                        if (beyondProcessingStatusSpan != null)
                            beyondProcessingStatusSpan.Visible = true;
                    }

                    var orderDetailIdLiteral = e.Row.FindControl("OrderDetailIdLiteral") as Literal;
                    if (orderDetailIdLiteral != null)
                        orderDetailIdLiteral.Text = OrderDetailId.ToString();
                }
            }
        }

        private void BindShippingDetailGrid()
        {
            var activeOrderDetail = _orderController.GetActiveOrderDetail(OrderId);

            if (activeOrderDetail == null)
            {
                ShowData(false);
                return;
            }

            GetCustomer(activeOrderDetail);
            BindCustomerBillingAddressDetails();
            SetRefundRequestAmount(OrderId);
            SetTotalPaymentAmount(OrderId);
            var activeShippingDetails = _shippingDetailRepository.GetShippingDetailsForCancellation(activeOrderDetail.Id);
            if (!activeShippingDetails.IsNullOrEmpty())
            {
                ShowData(true);
                OrderDetailId = activeOrderDetail.Id;
                AvailableShippingDetailsGrid.DataSource = activeShippingDetails;
                AvailableShippingDetailsGrid.DataBind();
            }
            else
            {
                ShowData(false);
            }
        }

        private void SetRefundRequestAmount(long orderId)
        {
            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequests = refundRequestRepository.GetbyOrderId(orderId);
            if (refundRequests != null)
            {
                RefundRequestAmount.Value = refundRequests.Where(
                    rr => rr.RefundRequestType != RefundRequestType.CancelShipping).Sum(
                        rr => rr.RequestedRefundAmount).ToString("0.00");
            }
        }

        private void SetTotalPaymentAmount(long orderId)
        {
            var orderRepository = IoC.Resolve<IOrderRepository>();
            var order = orderRepository.GetOrder(orderId);
            //var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            //var refundRequests = refundRequestRepository.GetbyOrderId(orderId);
            //var refundReuestAmount = 0.0m;
            //if (refundRequests != null)
            //{
            //    refundReuestAmount = refundRequests.Where(rr => !rr.IsResolved).Sum(rr => rr.RequestedRefundAmount);
            //}
            var paidAmount = order.TotalAmountPaid;
            TotalPaymentAmount.Value = paidAmount.ToString("0.00");
            DiscountedTotalAmount.Value = order.DiscountedTotal.ToString("0.00");
        }

        private void GetCustomer(OrderDetail activeOrderDetail)
        {
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var forOrganizationRoleUser =
                organizationRoleUserRepository.GetOrganizationRoleUser(activeOrderDetail.ForOrganizationRoleUserId);
            ICustomerRepository customerRepository = new CustomerRepository();
            Customer = customerRepository.GetCustomerByUserId(forOrganizationRoleUser.UserId);
            CustomerId = Customer.CustomerId;

        }

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            var creditCardPaymentInstrument =
                order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;

            if (creditCardPaymentInstrument != null)
            {
                IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
                CreditCardHolderName.Text = HttpUtility.HtmlEncode(existingChargeCard.NameOnCard);
                string cardNumber = existingChargeCard.Number;
                if (cardNumber.Length > 0)
                {
                    string displayCardNumber = string.Empty;
                    for (int jcount = 0; jcount < cardNumber.Length - 4; jcount++)
                    {
                        displayCardNumber += "X";
                    }

                    displayCardNumber += cardNumber.Substring(cardNumber.Length - 4, 4);

                    CreditCardNumberLabel.Text = HttpUtility.HtmlEncode(displayCardNumber);
                    CreditCardTypeLabel.Text =
                        Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();
                    ExpirationDateLabel.Text = existingChargeCard.ExpirationDate.ToString("MM/yyyy");

                    ListItem listItem = PaymentModeCombo.Items.FindByText("Credit Card");
                    if (listItem != null)
                    {
                        PaymentModeCombo.Items.Insert(PaymentModeCombo.Items.Count, new ListItem("Credit Card on File", CC_ON_FILE_VALUE));
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCODE",
                        "alert('The credit card number supplied is invalid.So you have to enter new credit card information if you wish to refund via credit card');",
                        true);
                }
            }
        }

        private void BindCustomerBillingAddressDetails()
        {
            Address1Hidden.Value = Customer.BillingAddress.StreetAddressLine1;
            if (CountryCombo.Items.Count > 0 && CountryCombo.Items.FindByValue(Customer.BillingAddress.CountryId.ToString()) != null)
                CountryIdHidden.Value = Customer.BillingAddress.CountryId.ToString();
            if (StateDropDown.Items.Count > 0 && StateDropDown.Items.FindByText(Customer.BillingAddress.State) != null)
                StateIdHidden.Value = StateDropDown.Items.FindByText(Customer.BillingAddress.State).Value;
            CityHidden.Value = Customer.BillingAddress.City;
            ZipHidden.Value = Customer.BillingAddress.ZipCode != null ? Customer.BillingAddress.ZipCode.Zip : string.Empty;
        }

        private IEnumerable<GridViewRow> GetSelectedRows()
        {
            return AvailableShippingDetailsGrid.Rows.Cast<GridViewRow>().Where(IsCheckBoxSelected);
        }

        private bool IsCheckBoxSelected(Control row)
        {
            var chekBoxSelect = row.FindControl("chkSelect") as CheckBox;
            return (chekBoxSelect != null && chekBoxSelect.Checked && chekBoxSelect.Enabled);
        }

        private void ShowData(bool show)
        {
            dvNoQueueItemFound.Visible = !show;
            DataGridDiv.Visible = show;
        }

        private void BindAllDropDowns()
        {
            BindCountryDropDown();
            BindPageDropDowns();
        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var country = countryRepository.GetAll();
            CountryDropDown.DataSource = country;
            CountryDropDown.DataTextField = DDL_TEXT_NAME;
            CountryDropDown.DataValueField = DDL_VALUE_ID;
            CountryDropDown.DataBind();
            CountryDropDown.Items.Insert(0, new ListItem("Select Country", "0"));
        }

        protected override decimal? TotalAmountPayable
        {
            get
            {
                if (ViewState["TotalAmountPayable"] != null && !string.IsNullOrEmpty(ViewState["TotalAmountPayable"].ToString()))
                {
                    return Convert.ToDecimal(ViewState["TotalAmountPayable"]);
                }
                return 0;
            }
            set
            {
                ViewState["TotalAmountPayable"] = value;
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
                return 0;
            }
            set
            {
                ViewState["CustomerId"] = value;
            }
        }

        protected override DropDownList CountryCombo
        {
            get { return CountryDropDown; }
        }

        protected override DropDownList StateCombo
        {
            get { return StateDropDown; }
        }

        protected override DropDownList EStateCombo
        {
            get { return null; }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return CreditCardTypeDropDown; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return null; }
        }

        protected override DropDownList ChequeAccountTypeCombo
        {
            get { return AccountTypeCombo; }
        }

        protected override TextBox Address1TextBox
        {
            get { return Address1Text; }
        }

        protected override TextBox Address2TextBox
        {
            get { return null; }
        }

        protected override TextBox CityTextBox
        {
            get { return CityText; }
        }

        protected override TextBox ZipTextBox
        {
            get { return ZipText; }
        }

        protected override TextBox PhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox EAddress1TextBox
        {
            get { return null; }
        }

        protected override TextBox EAddress2TextBox
        {
            get { return null; }
        }

        protected override TextBox ECityTextBox
        {
            get { return null; }
        }

        protected override TextBox EZipTextBox
        {
            get { return null; }
        }

        protected override TextBox EPhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox CreditCardHolderNameTextBox
        {
            get { return CreditCardHolderNameText; }
        }

        protected override TextBox CreditCardExpiryDateTextBox
        {
            get { return CreditCardExpirationDateText; }
        }

        protected override TextBox CreditCardNumberTextBox
        {
            get { return CreditCardNumberText; }
        }

        protected override TextBox CreditCardSecurityNumberTextBox
        {
            get { return CreditCardSecurityNumberText; }
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
            get { return RoutingNumberText; }
        }

        protected override TextBox ChequeAccountNumberTextBox
        {
            get { return AccountNumberText; }
        }

        protected override TextBox ChequeBankNameTextBox
        {
            get { return BankNameText; }
        }

        protected override TextBox ChequeAccountHolderNameTextBox
        {
            get { return AccountHolderNameText; }
        }

        protected override TextBox ChequeChequeNumberTextBox
        {
            get { return ChequeNumberText; }
        }

        protected override ListControl PaymentMode
        {
            get { return PaymentModeCombo; }
        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            MessageBox.ShowErrorMessage(errorMessage);
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        protected override void BindPaymentModeDropDown()
        {
            PaymentMode.Items.Clear();
            PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
            PaymentMode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                  PaymentType.Check.PersistenceLayerId.ToString()));
            PaymentMode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                  PaymentType.Cash.PersistenceLayerId.ToString()));
            if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep))
            {
                PaymentMode.Items.Remove(PaymentMode.Items.FindByText(PaymentType.Cash.Name));
                PaymentMode.Items.Remove(PaymentMode.Items.FindByText(PaymentType.Check.Name));
            }
            PaymentMode.Items.Insert(0, new ListItem("Pay By:", "0"));

        }
    }
}