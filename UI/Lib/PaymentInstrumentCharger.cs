using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Lib
{
    // TODO: PaymentInstrumentCharger, PaymentInstrumentChargerControl,PackageRegistrationPaymentCharger have to be merged to gether.
    // TODO: These files contain lot of redundant code, figure a out a way to get common code to single file.
    public abstract class PaymentInstrumentCharger : Page
    {
        protected const string DDL_VALUE_ID = "Id";
        protected const string DDL_TEXT_NAME = "Name";

        protected const int CUSTOMER_SHELL_ID = 100;

        protected virtual ViewType CurrentViewType
        {
            get
            {
                if (ViewState["CurrentViewType"] != null && !string.IsNullOrEmpty(ViewState["CurrentViewType"].ToString()))
                {
                    return (ViewType)Enum.Parse(typeof(ViewType), ViewState["CurrentViewType"].ToString());
                }
                return ViewType.CustomerPortal;
            }
            set
            {
                ViewState["CurrentViewType"] = value;
            }
        }

        protected virtual long OrderId
        {
            get
            {
                if (ViewState["OrderId"] != null && !string.IsNullOrEmpty(ViewState["OrderId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["OrderId"]);
                }
                return 0;
            }
            set
            {
                ViewState["OrderId"] = value;
            }
        }

        protected Customer _customer;

        protected abstract Customer Customer { get; }

        protected virtual long PackageId
        {
            get
            {
                if (ViewState["PackageId"] != null && !string.IsNullOrEmpty(ViewState["PackageId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["PackageId"]);
                }
                return 0;
            }
            set
            {
                ViewState["PackageId"] = value;
            }
        }

        protected virtual long EventCustomerId
        {
            get
            {
                if (ViewState["EventCustomerId"] != null && !string.IsNullOrEmpty(ViewState["EventCustomerId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["EventCustomerId"]);
                }
                return 0;
            }
            set
            {
                ViewState["EventCustomerId"] = value;
            }
        }

        protected abstract long? EventId { get; }

        protected abstract long? CustomerId { get; }

        protected virtual decimal PackageCost
        {
            get
            {
                if (ViewState["PackageCost"] != null && !string.IsNullOrEmpty(ViewState["PackageCost"].ToString()))
                {
                    return Convert.ToDecimal(ViewState["PackageCost"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["PackageCost"] = value;
            }
        }

        protected abstract decimal? TotalAmountPayable { get; set; }

        protected virtual string SourceCode { get; set; }

        protected virtual long SourceCodeId { get; set; }

        protected virtual decimal SourceCodeAmount { get; set; }

        protected abstract decimal? AppliedGiftCertificateBalanceAmount { get; }

        protected abstract long? AppliedGiftCertificateId { get; }

        protected abstract ShippingDetail ShippingDetail { get; set; }

        protected abstract bool IsBillingAddressSameAsHomeAddress { get; set; }

        protected ProcessorResponse PaymentGatewayResponse { get; set; }

        private IShippingDetailService _shippingDetailService;

        protected PaymentInstrumentCharger()
        {
            _shippingDetailService = IoC.Resolve<IShippingDetailService>();
        }

        # region Page Controls Properties

        protected abstract DropDownList CountryCombo { get; }
        protected abstract HiddenField StateHiddenField { get; }
        protected abstract DropDownList CreditCardTypeCombo { get; }
        protected abstract DropDownList EChequeAccountTypeCombo { get; }
        protected abstract DropDownList ChequeAccountTypeCombo { get; }

        protected abstract TextBox Address1TextBox { get; }
        protected abstract TextBox Address2TextBox { get; }
        protected abstract TextBox CityTextBox { get; }
        protected abstract TextBox ZipTextBox { get; }
        protected abstract TextBox PhoneTextBox { get; }
        protected abstract TextBox CreditCardHolderNameTextBox { get; }
        protected abstract TextBox CreditCardExpiryDateTextBox { get; }
        protected abstract TextBox CreditCardNumberTextBox { get; }
        protected abstract TextBox CreditCardSecurityNumberTextBox { get; }
        protected abstract TextBox EChequeRoutingNumberTextBox { get; }
        protected abstract TextBox EChequeAccountNumberTextBox { get; }
        protected abstract TextBox EChequeBankNameTextBox { get; }
        protected abstract TextBox EChequeAccountHolderNameTextBox { get; }
        protected abstract TextBox EChequeChequeNumberTextBox { get; }
        protected abstract TextBox ChequeRoutingNumberTextBox { get; }
        protected abstract TextBox ChequeAccountNumberTextBox { get; }
        protected abstract TextBox ChequeBankNameTextBox { get; }
        protected abstract TextBox ChequeAccountHolderNameTextBox { get; }
        protected abstract TextBox ChequeChequeNumberTextBox { get; }

        protected abstract ListControl PaymentMode { get; }

        # endregion Page Controls Properties

        # region Protected Implemented Methods

        protected abstract void SetAndDisplayErrorMessage(string errorMessage);

        protected abstract OrganizationRoleUser GetOrganizationRoleUser();

        protected static string GetStateCode(string state)
        {
            IStateRepository stateRepository = new StateRepository();
            return stateRepository.GetState(state).Code;
        }

        protected static string GetCountryCode(int countryId)
        {
            ICountryRepository countryRepository = new CountryRepository();
            return countryRepository.GetCountryCode(countryId);
        }

        protected ChargeCardType GetSelectedChargeCard()
        {
            if (CreditCardTypeCombo.SelectedItem.Text == ChargeCardType.Visa.ToString())
                return ChargeCardType.Visa;
            if (CreditCardTypeCombo.SelectedItem.Text == ChargeCardType.MasterCard.ToString())
                return ChargeCardType.MasterCard;
            if (CreditCardTypeCombo.SelectedItem.Text == ChargeCardType.AmericanExpress.ToString())
                return ChargeCardType.AmericanExpress;
            if (CreditCardTypeCombo.SelectedItem.Text == ChargeCardType.Discover.ToString())
                return ChargeCardType.Discover;

            return ChargeCardType.Visa;
        }

        private Order _order;

        protected Order CurrentOrder
        {
            get { return _order; }
        }

        protected bool PlaceNewShippingOrder()
        {
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;
                var organizationRoleUser = GetOrganizationRoleUser();

                UpdateCustomerBillingAddress(organizationRoleUser.Id);

                IOrderController orderController = new OrderController();

                OrderDetail orderDetail = orderController.GetActiveOrderDetail(_order);

                if (orderDetail != null)
                {
                    var paymentInstruments = new List<PaymentInstrument>();

                    var paymentAmount = ShippingDetail.ActualPrice;
                    if (paymentAmount > 0 && (PaymentMode.SelectedItem.Value != PaymentType.Onsite_Value.ToString()))
                    {
                        var paymentInstrument = ManageGiftCertificatePayment(organizationRoleUser, ref paymentAmount);
                        if (paymentInstrument != null)
                            paymentInstruments.Add(paymentInstrument);

                        if (paymentInstruments.IsEmpty() || paymentAmount > 0)
                            paymentInstruments.Add(ChargePayment(organizationRoleUser, paymentAmount,
                                                                 EventId + "_" + OrderId));
                    }

                    if (ShippingDetail != null)
                    {
                        var shippingDetail = ShippingDetail;
                        shippingDetail.IsExclusivelyRequested = _shippingDetailService.CheckShippingIsExclusivelyRequested(EventId.Value, CustomerId.Value);

                        IShippingController shippingController = new ShippingController();
                        ShippingDetail = shippingController.OrderShipping(shippingDetail);

                        IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository =
                            new ShippingDetailOrderDetailRepository();

                        var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                                                            {
                                                                Amount = ShippingDetail.ActualPrice,
                                                                IsActive = true,
                                                                OrderDetailId = orderDetail.Id,
                                                                ShippingDetailId = ShippingDetail.Id
                                                            };

                        shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);

                        if (!paymentInstruments.IsEmpty() && paymentInstruments.Sum(pi => pi.Amount) > 0)
                            ApplyPaymentToOrder(organizationRoleUser, paymentInstruments, _order);

                        var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();
                        var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                        var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);

                        var productPurchasedCount = _order.OrderDetails.Where(od => (od.DetailType == OrderItemType.ProductItem) && od.IsCompleted).Count();

                        if (resultShippingDetails != null && resultShippingDetails.Count() > 0 && productPurchasedCount > 0 && (cdShippingDetails == null || (productPurchasedCount > cdShippingDetails.Count() && cdShippingDetails.Count() < resultShippingDetails.Count())))
                        {
                            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                            var shippingOption = shippingOptionRepository.GetShippingOptionByProductId((long)Core.Enum.Product.UltraSoundImages);

                            if (shippingOption != null && shippingOption.Id != ShippingDetail.ShippingOption.Id)
                            {
                                var productShippingDetail = ShippingDetail;
                                productShippingDetail.Id = 0;
                                productShippingDetail.ShippingAddress.Id = 0;
                                productShippingDetail.ShippingOption.Id = shippingOption.Id;
                                productShippingDetail.ActualPrice = shippingOption.Price;
                                productShippingDetail.IsExclusivelyRequested = shippingDetail.IsExclusivelyRequested;

                                productShippingDetail = shippingController.OrderShipping(productShippingDetail);

                                var productShippingDetailOrderDetail = new ShippingDetailOrderDetail
                                {
                                    Amount = productShippingDetail.ActualPrice,
                                    IsActive = true,
                                    OrderDetailId = orderDetail.Id,
                                    ShippingDetailId = productShippingDetail.Id
                                };

                                shippingDetailOrderDetailRepository.Save(productShippingDetailOrderDetail);
                            }
                        }
                        try
                        {
                            var shippingDetailService = IoC.Resolve<IShippingDetailService>();
                            shippingDetailService.SendPurchaseShippingNotification(EventId.Value, CustomerId.Value, organizationRoleUser.Id);
                        }
                        catch (Exception ex)
                        {
                            IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                        }
                    }
                }
            }
            return true;
        }

        protected virtual bool MakePaymentsForExistingOrder()
        {
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;

                var organizationRoleUser = GetOrganizationRoleUser();
                UpdateCustomerBillingAddress(organizationRoleUser.Id);

                IOrderController orderController = new OrderController();

                OrderDetail orderDetail = orderController.GetActiveOrderDetail(_order);

                if (orderDetail == null) return false;

                if (!string.IsNullOrEmpty(SourceCode))
                {
                    var sourceCodeOrderDetail = new SourceCodeOrderDetail
                                                    {
                                                        Amount = SourceCodeAmount,
                                                        IsActive = true,
                                                        OrderDetailId = orderDetail.Id,
                                                        OrganizationRoleUserCreatorId = organizationRoleUser.Id,
                                                        SourceCodeId = SourceCodeId
                                                    };
                    orderDetail.SourceCodeOrderDetail = sourceCodeOrderDetail;
                }
                decimal paymentAmount = TotalAmountPayable.HasValue ? TotalAmountPayable.Value : 0;
                //if (orderDetail.SourceCodeOrderDetail != null)
                //    paymentAmount = order.UndiscountedTotal - orderDetail.SourceCodeOrderDetail.Amount -
                //                    order.TotalAmountPaid;
                //else
                //    paymentAmount = order.DiscountedTotal - order.TotalAmountPaid;

                var paymentInstruments = new List<PaymentInstrument>();
                var paymentInstrument = ManageGiftCertificatePayment(organizationRoleUser, ref paymentAmount);
                if (paymentInstrument != null)
                    paymentInstruments.Add(paymentInstrument);

                if (paymentAmount > 0 && (PaymentMode.SelectedItem.Value != PaymentType.Onsite_Value.ToString()))
                    paymentInstruments.Add(ChargePayment(organizationRoleUser, paymentAmount, EventId + "_" + OrderId));

                IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
                orderDetailRepository.SaveOrderDetail(orderDetail);
                if (!paymentInstruments.IsNullOrEmpty())
                    ApplyPaymentToOrder(organizationRoleUser, paymentInstruments, _order);
            }
            return true;
        }

        protected static void ApplyPaymentToOrder(DomainObjectBase organizationRoleUser, IEnumerable<PaymentInstrument> paymentInstruments, DomainObjectBase order)
        {
            var paymentController = IoC.Resolve<PaymentController>();
            long paymentId = paymentController.SavePayment(paymentInstruments, "Payment", organizationRoleUser.Id);

            var orderRepository = new OrderRepository();
            orderRepository.ApplyPaymentToOrder(order.Id, paymentId);
        }

        # endregion Protected Implemented Methods

        # region Private Helper Methods

        protected void BindPageDropDowns()
        {
            BindCreditCardDropDown();
            BindPaymentModeDropDown();

            EChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
            EChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
            EChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());

            ChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
            ChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
            ChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }

        protected void BindCreditCardDropDown()
        {
            CreditCardTypeCombo.Items.Clear();
            var creditCardTypes = IoC.Resolve<IChargeCardRepository>().GetAllChargeCardType();
            CreditCardTypeCombo.DataSource = creditCardTypes;
            CreditCardTypeCombo.DataTextField = "SecondValue";
            CreditCardTypeCombo.DataValueField = "FirstValue";
            CreditCardTypeCombo.DataBind();
            CreditCardTypeCombo.Items.Insert(0, (new ListItem("Select Card Type", "0")));
        }

        protected virtual void BindPaymentModeDropDown()
        {
            switch (CurrentViewType)
            {
                case ViewType.Technician:
                    PaymentMode.Items.Insert(0, (new ListItem("Select Payment Mode", "0")));
                    PaymentMode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                            PaymentType.Cash.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                            PaymentType.Check.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                            PaymentType.CreditCard.PersistenceLayerId.ToString()));
                    break;
                case ViewType.CallCenterRep:
                    PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                        PaymentType.CreditCard.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                            PaymentType.Check.PersistenceLayerId.ToString()));
                    break;
            }
        }

        private void BindBillingAddressControls()
        {
            if (Customer != null)
            {
                Address1TextBox.Text = Customer.Address.StreetAddressLine1;
                Address2TextBox.Text = Customer.Address.StreetAddressLine2;
                StateHiddenField.Value = Customer.Address.State;
                CityTextBox.Text = Customer.Address.City;
                var commonCode = new CommonCode();
                PhoneTextBox.Text = commonCode.FormatPhoneNumberGet(Customer.HomePhoneNumber.ToString());
                ZipTextBox.Text = Customer.Address.ZipCode.Zip;

                IsBillingAddressSameAsHomeAddress = true;
            }
        }

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected void UpdateCustomerBillingAddress(long orgRoleId)
        {
            var billingAddress = new Address
            {
                StreetAddressLine1 = Address1TextBox.Text,
                StreetAddressLine2 =
                    Address2TextBox != null ? Address2TextBox.Text : string.Empty,
                State = StateHiddenField.Value,
                City = CityTextBox.Text,
                ZipCode = new ZipCode { Zip = ZipTextBox.Text },
                Country = CountryCombo.SelectedItem.Text
            };

            if (!IsBillingAddressSameAsHomeAddress)//&& !AddressValidation(billingAddress)
            {
                Customer.BillingAddress = billingAddress;
            }

            IoC.Resolve<ICustomerService>().SaveCustomer(Customer, orgRoleId);
        }

        protected bool AddressValidation(Address billingAddress)
        {
            var addressRepository = IoC.Resolve<IAddressRepository>();
            try
            {
                addressRepository.ValidateAddress(billingAddress);
            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage(ex.Message);
                ClientScript.RegisterStartupScript(typeof(string), "js_maintainAfterFailedPostBack", "ShowHide();", true);
                return false;
            }
            return true;
        }

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected PaymentInstrument ChargePayment(OrganizationRoleUser organizationRoleUser, decimal paymentAmount, string customerReference)
        {
            string paymentMode = PaymentMode.SelectedItem.Value;

            if (paymentMode == PaymentType.ElectronicCheck.PersistenceLayerId.ToString())
                return ManageECheckPayment(customerReference, paymentAmount, Customer,
                                           organizationRoleUser);
            if (paymentMode == PaymentType.CreditCard.PersistenceLayerId.ToString() || paymentMode == PaymentType.CreditCardOnFile_Value.ToString())
                return ManageChargeCardPayment(customerReference, paymentAmount,
                                               Customer.Email == null
                                                   ? String.Empty
                                                   : Customer.Email.ToString(), organizationRoleUser);
            if (paymentMode == PaymentType.Check.PersistenceLayerId.ToString())
                return ManageCheckPayment(paymentAmount, organizationRoleUser);

            return ManageCashPayment(paymentAmount, organizationRoleUser);
        }

        private PaymentInstrument ManageGiftCertificatePayment(OrganizationRoleUser organizationRoleUser, ref decimal paymentAmount)
        {
            if (AppliedGiftCertificateId.HasValue && AppliedGiftCertificateId.Value > 0 && AppliedGiftCertificateBalanceAmount.HasValue)
            {
                IGiftCertificateController giftCertificateController = new Controllers.GiftCertificateController();
                try
                {
                    var giftCertificate = giftCertificateController.GetGiftCertificateById(AppliedGiftCertificateId.Value);
                    if (AppliedGiftCertificateBalanceAmount.Value != giftCertificate.BalanceAmount)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "js_CheckGiftCertificate", "alert('This Gift Certificate has been applied in another event registration. Please apply it again.');", true);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "js_CheckGiftCertificate", "alert('" + ex.Message + "');", true);
                    return null;
                }
                decimal giftCertificateAppliedAmount;
                if (AppliedGiftCertificateBalanceAmount.Value >= paymentAmount)
                {
                    giftCertificateAppliedAmount = paymentAmount;
                    paymentAmount = 0;
                }
                else
                {
                    giftCertificateAppliedAmount = AppliedGiftCertificateBalanceAmount.Value;
                    paymentAmount = paymentAmount - AppliedGiftCertificateBalanceAmount.Value;
                }
                return new GiftCertificatePayment
                {
                    Amount = giftCertificateAppliedAmount,
                    GiftCertificateId = AppliedGiftCertificateId.Value,
                    DataRecorderMetaData =
                        new DataRecorderMetaData
                        {
                            DataRecorderCreator = organizationRoleUser,
                            DateCreated = DateTime.Now,
                            DataRecorderModifier = organizationRoleUser,
                            DateModified = DateTime.Now
                        }
                };
            }
            return null;
        }

        private PaymentInstrument ManageChargeCardPayment(string customerReference, decimal paymentAmount, string email,
            OrganizationRoleUser organizationRoleUser)
        {
            var paymentGateway = IoC.Resolve<IPaymentProcessor>();
            var nameParser = new NameParser();
            var settings = IoC.Resolve<ISettings>();

            if (paymentAmount > 0)
            {
                if (_order != null && PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString())
                {
                    var creditCardPaymentInstrument =
                        _order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                        ChargeCardPayment;

                    if (creditCardPaymentInstrument != null)
                    {
                        IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                        var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);

                        Name name = nameParser.ParseName(existingChargeCard.NameOnCard);

                        if (string.IsNullOrEmpty(existingChargeCard.CVV))
                        {
                            Page.ClientScript.RegisterStartupScript(typeof(string), "jscoderefund",
                                                                    "alert('Credit card can not be charged because Security Number does not exist with us.'); SetValuesafterFailedPostBack(); ",
                                                                    true);
                            return null;
                        }

                        var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
                        {
                            CreditCardNo = existingChargeCard.Number,
                            SecurityCode = existingChargeCard.CVV,
                            ExpiryMonth = existingChargeCard.ExpirationDate.Month,
                            ExpiryYear = existingChargeCard.ExpirationDate.Year,
                            CardType = existingChargeCard.TypeId.ToString(),
                            Price = paymentAmount.ToString(),
                            FirstName = name.FirstName,
                            LastName = !string.IsNullOrEmpty(name.LastName) ? name.LastName : name.FirstName,
                            BillingAddress = Address1TextBox.Text,
                            BillingCity = CityTextBox.Text,
                            BillingState = GetStateCode(Customer.BillingAddress.State),
                            BillingPostalCode = ZipTextBox.Text,
                            BillingCountry = GetCountryCode(Convert.ToInt32(Customer.BillingAddress.CountryId)),
                            Email = string.IsNullOrEmpty(email) ? settings.SupportEmail.ToString() : email,
                            IpAddress = Request.ServerVariables["REMOTE_ADDR"],
                            Currency = "USD",
                            OrderId = customerReference
                        };

                        PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);

                    }
                }
                else
                {
                    string[] expiryDateParts = CreditCardExpiryDateTextBox.Text.Split("/".ToArray());
                    int expiryMonth = int.Parse(expiryDateParts[0]);
                    int expiryYear = int.Parse(expiryDateParts[1]);

                    Name name = new NameParser().ParseName(CreditCardHolderNameTextBox.Text);

                    var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
                    {
                        CreditCardNo = CreditCardNumberTextBox.Text,
                        SecurityCode = CreditCardSecurityNumberTextBox.Text,
                        ExpiryMonth = expiryMonth,
                        ExpiryYear = expiryYear,
                        CardType = CreditCardTypeCombo.SelectedItem.Text,
                        Price = paymentAmount.ToString(),
                        FirstName = name.FirstName,
                        LastName = name.LastName,
                        BillingAddress = Address1TextBox.Text,
                        BillingCity = CityTextBox.Text,
                        BillingState = GetStateCode(StateHiddenField.Value),
                        BillingPostalCode = ZipTextBox.Text,
                        BillingCountry = GetCountryCode(Convert.ToInt32(CountryCombo.SelectedItem.Value)),
                        Email = string.IsNullOrEmpty(email) ? settings.SupportEmail.ToString() : email,
                        IpAddress = Request.ServerVariables["REMOTE_ADDR"],
                        Currency = "USD",
                        OrderId = customerReference
                    };
                    PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);
                }
            }

            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                try
                {
                    new NLogLogManager().GetLogger<PaymentController>().Info("CC Transaction - Details [RawResponse: " + PaymentGatewayResponse.RawResponse + "]");
                }
                catch
                {
                }
                SetAndDisplayErrorMessage
                    ("Sorry, payment request from your credit card was rejected by our payment gateway. Please check given details.");
                throw new InvalidOperationException("Payment Failed.");
            }

            if (PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString())
            {
                var creditCardPaymentInstrument =
                    CurrentOrder.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                    ChargeCardPayment;
                if (creditCardPaymentInstrument != null)
                {
                    return new ChargeCardPayment
                    {
                        Amount = paymentAmount,
                        ChargeCardId = creditCardPaymentInstrument.ChargeCardId,
                        ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
                        DataRecorderMetaData =
                            new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
                        ProcessorResponse = PaymentGatewayResponse.RawResponse
                    };
                }
            }

            var chargeCard = SaveChargeCard(organizationRoleUser);
            return new ChargeCardPayment
            {
                Amount = paymentAmount,
                ChargeCardId = chargeCard.Id,
                ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
                DataRecorderMetaData =
                    new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
                ProcessorResponse = PaymentGatewayResponse.RawResponse
            };
        }


        private PaymentInstrument ManageECheckPayment(string customerReference, decimal paymentAmount, Customer customer,
            OrganizationRoleUser organizationRoleUser)
        {
            var authorizeNetPaymentGateway = new AuthorizeNetECheckPaymentGateway();
            var settings = IoC.Resolve<ISettings>();
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
                Price = paymentAmount.ToString(),
                FirstName =
                    customer.Name.FirstName,
                LastName =
                    customer.Name.LastName,
                BillingAddress =
                   Address1TextBox.Text,
                BillingCity =
                   CityTextBox.Text,
                BillingState =
                    GetStateCode(StateHiddenField.Value),
                BillingPostalCode =
                    ZipTextBox.Text,
                BillingCountry =
                    GetCountryCode(Convert.ToInt32(CountryCombo.SelectedItem.Value)),
                Email = string.IsNullOrEmpty(customer.Email.ToString()) ? settings.SupportEmail.ToString() : customer.Email.ToString(),
                PhoneNumber =
                    PhoneTextBox == null ? string.Empty : PhoneTextBox.Text,
                IpAddress =
                    Request.ServerVariables["REMOTE_ADDR"],
                Currency = "USD"
            };

            PaymentGatewayResponse = authorizeNetPaymentGateway.ChargeECheck(electronicCheckProcessorProcessingInfo);

            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                SetAndDisplayErrorMessage
                       ("Sorry, payment request from your eCheck is rejected by our payment gateway. Please check given details.");
                throw new InvalidOperationException("Payment Failed.");
            }

            var check = new Check
                            {
                                AccountNumber = EChequeAccountNumberTextBox.Text,
                                Amount = paymentAmount,
                                BankName = EChequeBankNameTextBox.Text,
                                CheckNumber = EChequeChequeNumberTextBox.Text,
                                DataRecorderMetaData =
                                    new DataRecorderMetaData
                                        {
                                            DataRecorderCreator = organizationRoleUser,
                                            DateCreated = DateTime.Now,
                                            DataRecorderModifier = organizationRoleUser,
                                            DateModified = DateTime.Now
                                        },
                                CheckDate = DateTime.Today,
                                RoutingNumber = EChequeRoutingNumberTextBox.Text,
                                PayableTo = IoC.Resolve<ISettings>().CompanyName,
                                AcountHolderName = EChequeAccountHolderNameTextBox.Text,
                                IsElectronicCheck = true
                            };

            var echeckPayment = new ECheckPayment
                                    {
                                        Amount = paymentAmount,
                                        ECheck = check,
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
            return echeckPayment;
        }

        private PaymentInstrument ManageCheckPayment(decimal paymentAmount, OrganizationRoleUser organizationRoleUser)
        {
            var check = new Check
                            {
                                AccountNumber = ChequeAccountNumberTextBox.Text,
                                Amount = paymentAmount,
                                BankName = ChequeBankNameTextBox.Text,
                                CheckNumber = ChequeChequeNumberTextBox.Text,
                                DataRecorderMetaData =
                                    new DataRecorderMetaData
                                        {
                                            DataRecorderCreator = organizationRoleUser,
                                            DateCreated = DateTime.Now,
                                            DataRecorderModifier = organizationRoleUser,
                                            DateModified = DateTime.Now
                                        },
                                CheckDate = DateTime.Today,
                                RoutingNumber = ChequeRoutingNumberTextBox.Text,
                                PayableTo = IoC.Resolve<ISettings>().CompanyName,
                                AcountHolderName = ChequeAccountHolderNameTextBox.Text
                            };

            return new CheckPayment
                       {
                           Check = check,
                           Amount = check.Amount,
                           CheckStatus = CheckPaymentStatus.Recieved,
                           DataRecorderMetaData = check.DataRecorderMetaData,
                           CheckId = check.Id
                       };
        }

        private static PaymentInstrument ManageCashPayment(decimal paymentAmount, OrganizationRoleUser organizationRoleUser)
        {
            return new CashPayment
                       {
                           Amount = paymentAmount,
                           DataRecorderMetaData =
                               new DataRecorderMetaData
                                   {
                                       DataRecorderCreator = organizationRoleUser,
                                       DateCreated = DateTime.Now,
                                       DataRecorderModifier = organizationRoleUser,
                                       DateModified = DateTime.Now
                                   }
                       };
        }

        private ChargeCard SaveChargeCard(OrganizationRoleUser organizationRoleUser)
        {
            // TODO: To implement it in a controller class
            var chargeCard = new ChargeCard
                                 {
                                     TypeId = GetSelectedChargeCard(),
                                     NameOnCard = CreditCardHolderNameTextBox.Text,
                                     CVV = CreditCardSecurityNumberTextBox.Text,
                                     Number = CreditCardNumberTextBox.Text,
                                     DataRecorderMetaData =
                                         new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
                                     ExpirationDate = Convert.ToDateTime(CreditCardExpiryDateTextBox.Text),
                                     IsDebit = false
                                 };

            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
            chargeCard = chargeCardRepository.Save(chargeCard);

            return chargeCard;
        }

        private Order GetOrder()
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(CustomerId.Value, EventId.Value);
        }

        # endregion Private Helper Methods
    }
}