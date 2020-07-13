using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Core.Extensions;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Lib
{
    public abstract class PaymentCharger : UserControl
    {
        # region Private Constants

        protected const string DDL_VALUE_ID = "Id";
        protected const string DDL_TEXT_NAME = "Name";
        //protected const int COUNTRY_ID = 1;
        //protected const string COUNTRY_NAME = "USA";
        protected const int CUSTOMER_SHELL_ID = 100;
        protected const string CC_ON_FILE_VALUE = "5";
        protected const string CREDIT_CARD_ON_FILE = "Credit Card on File";

        # endregion Private Constants

        # region Other Protected Properties

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

        private Order _order;
        protected Order CurrentOrder
        {
            get
            {
                if (_order == null)
                {
                    IOrderRepository orderRepository = new OrderRepository();
                    _order = orderRepository.GetOrder(OrderId);
                }
                return _order;
            }
        }

        protected abstract decimal? TotalAmountPayable { get; set; }

        protected abstract long? CustomerId { get; set; }

        private Customer _customer;
        protected Customer Customer
        {
            get
            {
                if (_customer == null && CustomerId.HasValue)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
            set
            {
                _customer = value;
                CustomerId = _customer.CustomerId;
            }
        }

        protected ProcessorResponse PaymentGatewayResponse { get; set; }

        # endregion Other Protected Properties

        # region Page Controls Properties
        protected abstract DropDownList CountryCombo { get; }
        protected abstract DropDownList StateCombo { get; }
        protected abstract DropDownList EStateCombo { get; }
        protected abstract DropDownList CreditCardTypeCombo { get; }
        protected abstract DropDownList EChequeAccountTypeCombo { get; }
        protected abstract DropDownList ChequeAccountTypeCombo { get; }

        protected abstract TextBox Address1TextBox { get; }
        protected abstract TextBox Address2TextBox { get; }
        protected abstract TextBox CityTextBox { get; }
        protected abstract TextBox ZipTextBox { get; }
        protected abstract TextBox PhoneTextBox { get; }

        protected abstract TextBox EAddress1TextBox { get; }
        protected abstract TextBox EAddress2TextBox { get; }
        protected abstract TextBox ECityTextBox { get; }
        protected abstract TextBox EZipTextBox { get; }
        protected abstract TextBox EPhoneTextBox { get; }

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

        protected abstract OrganizationRoleUser GetCreatorOrganizationRoleUser();

        protected static string GetStateCode(long stateId)
        {
            IStateRepository stateRepository = new StateRepository();
            return stateRepository.GetState(stateId).Code;
        }

        protected static string GetStateCode(string stateName)
        {
            IStateRepository stateRepository = new StateRepository();
            return stateRepository.GetState(stateName).Code;
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

        protected PaymentInstrument RefundPayment(OrganizationRoleUser organizationRoleUser, string customerReference)
        {
            string paymentMethodName = PaymentMode.SelectedItem.Text;
            var paymentAmount = TotalAmountPayable.Value * (-1);
            if (paymentMethodName == PaymentType.CreditCard.Name || paymentMethodName == CREDIT_CARD_ON_FILE)
                return ManageChargeCardPayment(customerReference, paymentAmount, Customer.Email.ToString(), organizationRoleUser);
            if (paymentMethodName == PaymentType.Check.Name)
                return ManageCheckPayment(paymentAmount, organizationRoleUser);

            return ManageCashPayment(paymentAmount, organizationRoleUser);
        }

        protected PaymentInstrument ChargePayment(OrganizationRoleUser organizationRoleUser, string customerReference)
        {
            string paymentMethodName = PaymentMode.SelectedItem.Text;

            if (paymentMethodName == PaymentType.ElectronicCheck.Name)
                return ManageECheckPayment(customerReference, TotalAmountPayable.Value, Customer,
                                           organizationRoleUser);
            if (paymentMethodName == PaymentType.CreditCard.Name || paymentMethodName == CREDIT_CARD_ON_FILE)
                return ManageChargeCardPayment(customerReference, TotalAmountPayable.Value, Customer.Email.ToString(), organizationRoleUser);
            if (paymentMethodName == PaymentType.Check.Name)
                return ManageCheckPayment(TotalAmountPayable.Value, organizationRoleUser);

            return ManageCashPayment(TotalAmountPayable.Value, organizationRoleUser);
        }

        protected void BindPageDropDowns()
        {
            BindStateDropDown();
            BindCreditCardDropDown();
            BindPaymentModeDropDown();

            if (EChequeAccountTypeCombo != null)
            {
                EChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
                EChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
                EChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());
            }
            if (ChequeAccountTypeCombo != null)
            {
                ChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
                ChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
                ChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());
            }
        }

        protected void BindStateDropDown()
        {
            IStateRepository stateRepository = new StateRepository();
            var states = stateRepository.GetAllStates();
            if (StateCombo != null)
            {
                StateCombo.DataSource = states;
                StateCombo.DataTextField = DDL_TEXT_NAME;
                StateCombo.DataValueField = DDL_VALUE_ID;
                StateCombo.DataBind();
                StateCombo.Items.Insert(0, new ListItem("Select State", "0"));
            }
            if (EStateCombo != null)
            {
                EStateCombo.DataSource = states;
                EStateCombo.DataTextField = DDL_TEXT_NAME;
                EStateCombo.DataValueField = DDL_VALUE_ID;
                EStateCombo.DataBind();
                EStateCombo.Items.Insert(0, new ListItem("Select State", "0"));
            }
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

        protected bool AddressValidation()
        {
            IAddressRepository addressRepository = new AddressRepository();
            try
            {
                addressRepository.ValidateAddress(new Address("line 1","", CityTextBox.Text, StateCombo.SelectedItem.Text, ZipTextBox.Text, "USA"));

            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage(ex.Message);
            }
            return true;
        }

        protected static bool ApplyPaymentToOrder(DomainObjectBase organizationRoleUser, DomainObjectBase order, PaymentInstrument paymentInstrument)
        {
            var paymentController = IoC.Resolve<PaymentController>();
            long paymentId = paymentController.SavePayment(paymentInstrument, "Payment", organizationRoleUser.Id);

            var orderRepository = new OrderRepository();
            orderRepository.ApplyPaymentToOrder(order.Id, paymentId);
            return true;
        }

        # endregion Protected Implemented Methods

        # region Private Helper Methods

        protected void UpdateCustomerBillingAddress(long orgRoleId)
        {
            Customer.BillingAddress = new Address
                                           {
                                               StreetAddressLine1 = Address1TextBox.Text,
                                               StreetAddressLine2 =
                                                   Address2TextBox != null ? Address2TextBox.Text : string.Empty,
                                               State = StateCombo.SelectedItem.Text,
                                               City = CityTextBox.Text,
                                               ZipCode = new ZipCode { Zip = ZipTextBox.Text },
                                               Country =CountryCombo.SelectedItem.Text 
                                           };

            var customerService = IoC.Resolve<ICustomerService>();
            customerService.SaveCustomer(_customer, orgRoleId);
        }

        //private PaymentInstrument ManageChargeCardPayment(string customerReference, decimal paymentAmount,
        //    OrganizationRoleUser organizationRoleUser)
        //{

        //    var paymentGateway = IoC.Resolve<IPaymentProcessor>();

        //    //var paymentGateway = new HealthYes.Infrastructure.Service.CyberSourcePaymentGateway();
        //    var settings = IoC.Resolve<ISettings>();
        //    if (paymentAmount > 0)
        //    {
        //        if (CurrentOrder != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
        //        {
        //            var creditCardPaymentInstrument =
        //                CurrentOrder.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
        //                ChargeCardPayment;

        //            if (creditCardPaymentInstrument != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
        //            {
        //                IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
        //                var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);

        //                var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
        //                {
        //                    CreditCardNo = existingChargeCard.Number,
        //                    SecurityCode = existingChargeCard.CVV,
        //                    ExpiryMonth = existingChargeCard.ExpirationDate.Month,
        //                    ExpiryYear = existingChargeCard.ExpirationDate.Year,
        //                    CardType = existingChargeCard.TypeId.ToString(),
        //                    Price = paymentAmount.ToString(),
        //                    FirstName = existingChargeCard.NameOnCard,
        //                    LastName = existingChargeCard.NameOnCard,
        //                    BillingAddress = Address1TextBox.Text,
        //                    BillingCity = CityTextBox.Text,
        //                    BillingState = GetStateCode(Customer.BillingAddress.State),
        //                    BillingPostalCode = ZipTextBox.Text,
        //                    BillingCountry = GetCountryCode(Convert.ToInt32(Customer.BillingAddress.CountryId)),
        //                    Email = string.IsNullOrEmpty(Customer.Email.ToString()) ? settings.SupportEmail.ToString() : Customer.Email.ToString(),
        //                    IpAddress = Request.ServerVariables["REMOTE_ADDR"],
        //                    Currency = "USD",
        //                    OrderId = customerReference
        //                };

        //                PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);

        //            }
        //        }

        //        else
        //        {
        //            string[] expiryDateParts = CreditCardExpiryDateTextBox.Text.Split("/".ToArray());
        //            int expiryMonth = int.Parse(expiryDateParts[0]);
        //            int expiryYear = int.Parse(expiryDateParts[1]);

        //            Name name = new NameParser().ParseName(CreditCardHolderNameTextBox.Text);

        //            var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
        //            {
        //                CreditCardNo = CreditCardNumberTextBox.Text,
        //                SecurityCode = CreditCardSecurityNumberTextBox.Text,
        //                ExpiryMonth = expiryMonth,
        //                ExpiryYear = expiryYear,
        //                CardType = CreditCardTypeCombo.SelectedItem.Text,
        //                Price = paymentAmount.ToString(),
        //                FirstName = name.FirstName,
        //                LastName = !string.IsNullOrEmpty(name.LastName) ? name.LastName : name.FirstName,
        //                BillingAddress = Address1TextBox.Text,
        //                BillingCity = CityTextBox.Text,
        //                BillingState = GetStateCode(Convert.ToInt32(StateCombo.SelectedItem.Value)),
        //                BillingPostalCode = ZipTextBox.Text,
        //                BillingCountry = GetCountryCode(Convert.ToInt32(CountryCombo.SelectedValue)),
        //                Email = string.IsNullOrEmpty(Customer.Email.ToString()) ? settings.SupportEmail.ToString() : Customer.Email.ToString(),
        //                IpAddress = Request.ServerVariables["REMOTE_ADDR"],
        //                Currency = "USD",
        //                OrderId = customerReference
        //            };

        //            PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);

        //        }
        //    }
        //    else
        //    {
        //        var creditCardPaymentInstrument =
        //            CurrentOrder.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
        //            ChargeCardPayment;

        //        if (creditCardPaymentInstrument != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
        //        {
        //            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
        //            var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);

        //            var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
        //            {
        //                CreditCardNo = existingChargeCard.Number,
        //                SecurityCode = existingChargeCard.CVV,
        //                ExpiryMonth = existingChargeCard.ExpirationDate.Month,
        //                ExpiryYear = existingChargeCard.ExpirationDate.Year,
        //                CardType = existingChargeCard.TypeId.ToString(),
        //                Price = ((-1) * paymentAmount).ToString(),
        //                FirstName = existingChargeCard.NameOnCard,
        //                LastName = existingChargeCard.NameOnCard,
        //                BillingAddress = Address1TextBox.Text,
        //                BillingCity = CityTextBox.Text,
        //                BillingState = GetStateCode(Customer.BillingAddress.State),
        //                BillingPostalCode = ZipTextBox.Text,
        //                BillingCountry = GetCountryCode(Convert.ToInt32(Customer.BillingAddress.CountryId)),
        //                Email = string.IsNullOrEmpty(Customer.Email.ToString()) ? settings.SupportEmail.ToString() : Customer.Email.ToString(),
        //                IpAddress = Request.ServerVariables["REMOTE_ADDR"],
        //                Currency = "USD",
        //                OrderId = customerReference
        //            };

        //            PaymentGatewayResponse = paymentGateway.RefundRequestOnOtherCreditCard(creditCardProcessorProcessingInfo);
                    
        //        }
        //        else
        //        {
        //            string[] expiryDateParts = CreditCardExpiryDateTextBox.Text.Split("/".ToArray());
        //            int expiryMonth = int.Parse(expiryDateParts[0]);
        //            int expiryYear = int.Parse(expiryDateParts[1]);

        //            Name name = new NameParser().ParseName(CreditCardHolderNameTextBox.Text);

        //            var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
        //            {
        //                CreditCardNo = CreditCardNumberTextBox.Text,
        //                SecurityCode = CreditCardSecurityNumberTextBox.Text,
        //                ExpiryMonth = expiryMonth,
        //                ExpiryYear = expiryYear,
        //                CardType = CreditCardTypeCombo.SelectedItem.Text,
        //                Price = ((-1) * paymentAmount).ToString(),
        //                FirstName = name.FirstName,
        //                LastName = !string.IsNullOrEmpty(name.LastName) ? name.LastName : name.FirstName,
        //                BillingAddress = Address1TextBox.Text,
        //                BillingCity = CityTextBox.Text,
        //                BillingState = GetStateCode(Convert.ToInt32(StateCombo.SelectedItem.Value)),
        //                BillingPostalCode = ZipTextBox.Text,
        //                BillingCountry = GetCountryCode(Convert.ToInt32(CountryCombo.SelectedValue)),
        //                Email = string.IsNullOrEmpty(Customer.Email.ToString()) ? settings.SupportEmail.ToString() : Customer.Email.ToString(),
        //                IpAddress = Request.ServerVariables["REMOTE_ADDR"],
        //                Currency = "USD",
        //                OrderId = customerReference
        //            };

        //            PaymentGatewayResponse = paymentGateway.RefundRequestOnOtherCreditCard(creditCardProcessorProcessingInfo);
        //        }
        //    }


          
        //    if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
        //    {
        //        SetAndDisplayErrorMessage
        //            ("Sorry, payment request from your credit card was rejected by our payment gateway. Please check given details.");
        //        throw new InvalidOperationException("Payment Failed.");
        //    }

        //    if (PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
        //    {
        //        if (CurrentOrder != null)
        //        {
        //            var creditCardPaymentInstrument =
        //                CurrentOrder.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
        //                ChargeCardPayment;
        //            if (creditCardPaymentInstrument != null)
        //            {
        //                return new ChargeCardPayment
        //                           {
        //                               Amount = paymentAmount,
        //                               ChargeCardId = creditCardPaymentInstrument.ChargeCardId,
        //                               ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
        //                               DataRecorderMetaData =
        //                                   new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
        //                               ProcessorResponse = PaymentGatewayResponse.RawResponse
        //                           };
        //            }
        //        }
        //    }

        //    var chargeCard = SaveChargeCard(organizationRoleUser);

        //    return new ChargeCardPayment
        //               {
        //                   Amount = paymentAmount,
        //                   ChargeCardId = chargeCard.Id,
        //                   ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
        //                   DataRecorderMetaData =
        //                       new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
        //                   ProcessorResponse = PaymentGatewayResponse.RawResponse
        //               };
        //}

        private PaymentInstrument ManageChargeCardPayment(string customerReference, decimal paymentAmount, string email,
            OrganizationRoleUser organizationRoleUser)
        {
            var order = CurrentOrder;
            var paymentGateway = IoC.Resolve<IPaymentProcessor>();
            var settings = IoC.Resolve<ISettings>();
            var nameParser = new NameParser();
            if (paymentAmount > 0)
            {
                if (order != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
                {
                    var creditCardPaymentInstrument =
                        order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
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

                    Name name = nameParser.ParseName(CreditCardHolderNameTextBox.Text);

                    var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
                    {
                        CreditCardNo = CreditCardNumberTextBox.Text,
                        SecurityCode = CreditCardSecurityNumberTextBox.Text,
                        ExpiryMonth = expiryMonth,
                        ExpiryYear = expiryYear,
                        CardType = CreditCardTypeCombo.SelectedItem.Text,
                        Price = paymentAmount.ToString(),
                        FirstName = name.FirstName,
                        LastName = !string.IsNullOrEmpty(name.LastName) ? name.LastName : name.FirstName,
                        BillingAddress = Address1TextBox.Text,
                        BillingCity = CityTextBox.Text,
                        BillingState = GetStateCode(Convert.ToInt32(StateCombo.SelectedItem.Value)),
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
            else
            {
                var creditCardPaymentInstrument =
                    order.PaymentsApplied.Where(pi => pi.PaymentType == PaymentType.CreditCard).OrderBy(
                        pi => pi.DataRecorderMetaData.DateCreated).Select(pi => (ChargeCardPayment)pi).LastOrDefault();

                if (creditCardPaymentInstrument != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
                {
                    if (creditCardPaymentInstrument.Amount == (paymentAmount < 0 ? (-1) * paymentAmount : paymentAmount))
                    {
                        var chargeCardService = IoC.Resolve<IChargeCardService>();
                        PaymentGatewayResponse = chargeCardService.VoidRequest(creditCardPaymentInstrument.ProcessorResponse);
                        if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
                        {
                            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                            var chargeCardDetail = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
                            PaymentGatewayResponse = chargeCardService.ApplyRefundtoCardonFile(paymentAmount, chargeCardDetail.Number, chargeCardDetail.ExpirationDate, creditCardPaymentInstrument.ProcessorResponse);
                        }
                    }
                    else if (creditCardPaymentInstrument.Amount > (paymentAmount < 0 ? (-1) * paymentAmount : paymentAmount))
                    {
                        var chargeCardService = IoC.Resolve<IChargeCardService>();
                        IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                        var chargeCardDetail = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
                        PaymentGatewayResponse = chargeCardService.ApplyRefundtoCardonFile(paymentAmount, chargeCardDetail.Number, chargeCardDetail.ExpirationDate, creditCardPaymentInstrument.ProcessorResponse);
                    }
                    else
                    {
                        IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                        var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);

                        Name name = nameParser.ParseName(existingChargeCard.NameOnCard);

                        if (string.IsNullOrEmpty(existingChargeCard.CVV))
                        {
                            Page.ClientScript.RegisterStartupScript(typeof(string), "jscoderefund",
                                                                    "alert('Refund can not be made on Credit card because Security Number does not exist with us.'); SetValuesafterFailedPostBack(); ",
                                                                    true);
                            return null;
                        }

                        var creditCardProcessorProcessingInfo = new CreditCardProcessorProcessingInfo
                        {
                            CreditCardNo = existingChargeCard.Number,
                            SecurityCode = existingChargeCard.CVV,
                            ExpiryMonth =
                                existingChargeCard.ExpirationDate.Month,
                            ExpiryYear =
                                existingChargeCard.ExpirationDate.Year,
                            CardType = existingChargeCard.TypeId.ToString(),
                            Price = ((-1) * paymentAmount).ToString(),
                            FirstName = name.FirstName,
                            LastName =
                                !string.IsNullOrEmpty(name.LastName)
                                    ? name.LastName
                                    : name.FirstName,
                            BillingAddress = Address1TextBox.Text,
                            BillingCity = CityTextBox.Text,
                            BillingState =
                                GetStateCode(Customer.BillingAddress.State),
                            BillingPostalCode = ZipTextBox.Text,
                            BillingCountry =
                                GetCountryCode(
                                    Convert.ToInt32(
                                        Customer.BillingAddress.CountryId)),
                            Email = string.IsNullOrEmpty(email) ? settings.SupportEmail.ToString() : email,
                            IpAddress =
                                Request.ServerVariables["REMOTE_ADDR"],
                            Currency = "USD",
                            OrderId = customerReference
                        };

                        PaymentGatewayResponse =
                            paymentGateway.RefundRequestOnOtherCreditCard(creditCardProcessorProcessingInfo);
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
                        Price = ((-1) * paymentAmount).ToString(),
                        FirstName = name.FirstName,
                        LastName = !string.IsNullOrEmpty(name.LastName) ? name.LastName : name.FirstName,
                        BillingAddress = Address1TextBox.Text,
                        BillingCity = CityTextBox.Text,
                        BillingState = GetStateCode(Convert.ToInt32(StateCombo.SelectedItem.Value)),
                        BillingPostalCode = ZipTextBox.Text,
                        BillingCountry = GetCountryCode(Convert.ToInt32(CountryCombo.SelectedItem.Value)),
                        Email = string.IsNullOrEmpty(email) ? settings.SupportEmail.ToString() : email,
                        IpAddress = Request.ServerVariables["REMOTE_ADDR"],
                        Currency = "USD",
                        OrderId = customerReference
                    };

                    PaymentGatewayResponse = paymentGateway.RefundRequestOnOtherCreditCard(creditCardProcessorProcessingInfo);
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

            if (PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
            {
                var creditCardPaymentInstrument =
                    order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
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
                                                                     EAddress1TextBox.Text,
                                                                 BillingCity =
                                                                     ECityTextBox.Text,
                                                                 BillingState =
                                                                     GetStateCode(Convert.ToInt32(EStateCombo.SelectedItem.Value)),
                                                                 BillingPostalCode =
                                                                     EZipTextBox.Text,
                                                                 BillingCountry =
                                                                     GetCountryCode(Convert.ToInt32(CountryCombo.SelectedValue)),
                                                                 Email = string.IsNullOrEmpty(customer.Email.ToString()) ? settings.SupportEmail.ToString() : customer.Email.ToString(),
                                                                 PhoneNumber =
                                                                     EPhoneTextBox != null && !string.IsNullOrEmpty(PhoneTextBox.Text) ? PhoneTextBox.Text : string.Empty,
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

        # endregion Private Helper Methods

    }
}