using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.UI.Lib
{
    // TODO: PaymentInstrumentCharger, PaymentInstrumentChargerControl,PackageRegistrationPaymentCharger have to be merged to gether.
    // TODO: These files contain lot of redundant code, figure a out a way to get common code to single file.
    public abstract class PackageRegistrationPaymentCharger : BasePage
    {
        protected const string DDL_VALUE_ID = "Id";
        protected const string DDL_TEXT_NAME = "Name";

        protected abstract ViewType CurrentViewType { get; }

        protected Customer _customer;

        protected abstract long? CallId { get; set; }

        protected abstract long? PackageId { get; }

        protected abstract long? ProductId { get; }

        protected abstract List<long> TestIds { get; }

        protected abstract IEnumerable<long> AppointmentSlotIds { get; }

        protected abstract long? EventId { get; }

        protected abstract long? CustomerId { get; set; }

        protected abstract decimal? TotalAmount { get; }

        protected abstract string SourceCode { get; }

        protected abstract string MarketingSource { get; }

        protected abstract long? SourceCodeId { get; }

        protected abstract decimal SourceCodeAmount { get; }

        protected abstract decimal? AppliedGiftCertificateBalanceAmount { get; }

        protected abstract long? AppliedGiftCertificateId { get; }

        protected abstract Customer Customer { get; }

        protected abstract ShippingDetail ShippingDetail { get; set; }

        protected abstract bool IsBillingAddressSameAsHomeAddress { get; set; }

        protected ProcessorResponse PaymentGatewayResponse { get; set; }

        protected virtual bool IsOnSitePayment { get { return CurrentViewType == ViewType.CallCenterRep; } }

        protected virtual long? AwvVisitId { get { return null; } }

        // For Call Center Registeration, Partial Payment Case
        protected virtual decimal AmountTobePaid
        {
            get
            {
                if (TotalAmount.HasValue) return TotalAmount.Value;
                return 0;
            }
        }

        protected virtual bool IsRetest { get; set; }
        protected virtual bool SingleTestOverride { get; set; }

        protected abstract decimal AmountCoveredByInsurance { get; }
        protected abstract long EligibilityId { get; set; }

        protected abstract long ChargeCardId { get; set; }

        private IShippingDetailService _shippingDetailService;

        protected PackageRegistrationPaymentCharger()
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

        # region Page Events

        protected override void OnLoad(EventArgs e)
        {
            SetDisplayControls();
            if (!IsPostBack)
            {
                BindPageDropDowns();
                BindBillingAddressControls();
            }
            base.OnLoad(e);
        }

        # endregion Page Events

        # region Protected Implemented Methods

        protected abstract void SetDisplayControls();
        protected abstract void SetAndDisplayErrorMessage(string errorMessage);
        protected abstract OrganizationRoleUser GetCreatorOrganizationRoleUser();

        protected bool DataValidation()
        {
            if (!EventId.HasValue || AppointmentSlotIds.IsNullOrEmpty())
            {
                SetAndDisplayErrorMessage(GetEventAppointmentErrorMessage());
                return false;
            }
            return true;
        }

        protected bool AppointmentValidation()
        {
            var slotService = IoC.Resolve<IEventSchedulingSlotService>();
            if (slotService.IsSlotBooked(AppointmentSlotIds))
            {
                string message;
                if (Request.QueryString["ID"] != null)
                {
                    message = string.Format("This appointment slot has already been selected. Please " +
                                            "<a href=\"/Public/Customer/RegisterCustomer.aspx?User={0}&ID={1}\">click here</a> " +
                                            "to go back and choose another appointment slot.", HttpUtility.HtmlEncode(Request.QueryString["User"]), HttpUtility.HtmlEncode(Request.QueryString["ID"]));
                }
                else
                    message = "This appointment slot has already been selected. Please go back and choose another appointment slot.";
                SetAndDisplayErrorMessage(message);
                return false;
            }
            return true;
        }

        protected bool EventValidation()
        {
            if (PackageRegistrationValidators.EventValidation(CustomerId.Value, EventId.Value))
            {
                IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
                new EventCustomerRegistrationViewDataRepository();

                var data =
                    eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(CustomerId.Value, EventId.Value);

                //check dulicate event registration
                if (data != null)
                {
                    var customerRepository = IoC.Resolve<ICustomerRepository>();
                    var customer = customerRepository.GetCustomer(CustomerId.Value);

                    var packageAndTest = data.PackageName;
                    packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                         ? data.AdditinalTest
                                         : packageAndTest +
                                           (string.IsNullOrEmpty(data.AdditinalTest)
                                                ? string.Empty
                                                : ", " + data.AdditinalTest);
                    var message = customer.Name +
                                  " is already registered for this event (" + data.EventName +
                                  " ) at " +
                                  data.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                  data.AppointmentStartTime.ToString(
                                      "hh:mm tt") + " for the " +
                                  packageAndTest +
                                  ". Duplicate registrations for the same customer are not allowed.";

                    SetAndDisplayErrorMessage(message);
                }
                return false;
            }
            return true;
        }

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

        protected bool SaveRegistrationPayment()
        {
            if (!DataValidation()) return false;

            // Verification of given customer information.
            if (!AppointmentValidation()) return false;

            if (!EventValidation()) return false;

            if (Customer == null) return false;
            var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();
            try
            {
                UpdateCustomerBillingAddress(creatorOrganizationRoleUser.Id);
            }
            catch (InvalidAddressException ex)
            {
                SetAndDisplayErrorMessage(ex.Message);
                if (CurrentViewType != ViewType.CallCenterRep)
                    ClientScript.RegisterStartupScript(typeof(string), "js_maintainAfterFailedPostBack", "ShowHide();", true);
                return false;
            }

            var forOrganizationRoleUser = GetForOrganizationRoleUser();
            bool isSucess = false;
            try
            {
                var order = GetInactiveOrder();
                isSucess = ReScheduleAppointment(order, forOrganizationRoleUser, creatorOrganizationRoleUser);
            }
            catch (Exception)
            {
                isSucess = ScheduleNewAppointment(forOrganizationRoleUser, creatorOrganizationRoleUser);
            }

            try
            {
                if (isSucess && EventId.HasValue)
                {
                    var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();
                    eventSchedulingSlotService.SendEventFillingNotification(EventId.Value, creatorOrganizationRoleUser.Id);

                    if (AwvVisitId.HasValue)
                    {
                        var isEawvPurchased = TestIds.Any(x => x == (long)TestType.eAWV);

                        var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId.Value);

                        var eventRepository = IoC.Resolve<IEventRepository>();
                        var theEvent = eventRepository.GetById(EventId.Value);

                        QuestionnaireType questionnaireType = QuestionnaireType.None;
                        if (account != null && theEvent != null)
                        {
                            var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                            questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                        }

                        if (account != null && (questionnaireType == QuestionnaireType.HraQuestionnaire) && isEawvPurchased)
                        {
                            var settings = IoC.Resolve<ISettings>();
                            
                            if (settings.SyncWithHra)
                            {
                                var medicare = IoC.Resolve<IMedicareApiService>();
                                var userSession = IoC.Resolve<ISessionContext>().UserSession;
                                try
                                {
                                    medicare.Connect(userSession.UserLoginLogId);
                                }
                                catch (Exception)
                                {
                                    var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                    medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                    medicare.Connect(userSession.UserLoginLogId);
                                }

                                var visitId = medicare.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                                 new MedicareEventEditModel
                                 {
                                     EventId = EventId.Value,
                                     Tag = account.Tag,
                                     VisitId = AwvVisitId.Value,
                                     VisitDate = theEvent.EventDate
                                 });
                                medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.BookedForEvent + "&unlock=true"); 
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
            }
            return isSucess;
        }

        private Order _order;

        protected Order CurrentOrder
        {
            get { return _order; }
        }

        protected bool PlaceProductOrder()
        {
            _order = GetOrder();
            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                if (Customer == null) return false;

                var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                UpdateCustomerBillingAddress(creatorOrganizationRoleUser.Id);

                var forOrganizationRoleUser = GetForOrganizationRoleUser();

                IOrderController orderController = new OrderController();
                var orderDetail = orderController.GetActiveOrderDetail(_order);

                var orderables = new List<IOrderable>();
                //decimal totalAmount = 0;
                if (ProductId.HasValue && ProductId.Value > 0)
                {
                    var productRepository = IoC.Resolve<IElectronicProductRepository>();
                    var product = productRepository.GetById(ProductId.Value);
                    orderables.Add(product);
                    //totalAmount = product.Price;
                }

                if (orderables.IsNullOrEmpty()) return false;

                var paymentInstruments = new List<PaymentInstrument>();

                if (!IsOnSitePayment)
                {
                    var paymentAmount = AmountTobePaid;
                    var paymentInstrument = ManageGiftCertificatePayment(creatorOrganizationRoleUser, ref paymentAmount);
                    if (paymentInstrument != null)
                        paymentInstruments.Add(paymentInstrument);

                    if (paymentInstruments.IsEmpty() || paymentAmount > 0)
                        paymentInstruments.Add(ChargePayment(creatorOrganizationRoleUser, paymentAmount, EventId + "_" + ProductId.Value));
                }

                var isExclusivelyRequested = _shippingDetailService.CheckShippingIsExclusivelyRequested(EventId.Value, CustomerId.Value);
                if (ShippingDetail != null)
                {
                    var shippingDetail = ShippingDetail;
                    shippingDetail.IsExclusivelyRequested = isExclusivelyRequested;

                    IShippingController shippingController = new ShippingController();
                    ShippingDetail = shippingController.OrderShipping(shippingDetail);

                    IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository = new ShippingDetailOrderDetailRepository();

                    var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                                                        {
                                                            Amount = ShippingDetail.ActualPrice,
                                                            IsActive = true,
                                                            OrderDetailId = orderDetail.Id,
                                                            ShippingDetailId = ShippingDetail.Id
                                                        };

                    shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
                }

                foreach (var orderable in orderables)
                {
                    orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, OrderStatusState.FinalSuccess);
                }
                _order = orderController.PlaceProductOrder(_order);

                if (!IsOnSitePayment)
                    ApplyPaymentToOrder(creatorOrganizationRoleUser, paymentInstruments, _order);

                _order = GetOrder();
                SaveProductShippingDetail(_order, isExclusivelyRequested);

                try
                {
                    var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                    eventCustomerResultRepository.SetRecordforRegeneratingResultPacket(EventId.Value, CustomerId.Value, creatorOrganizationRoleUser.Id);
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                }

                try
                {
                    if (ShippingDetail != null)
                    {
                        var shippingDetailService = IoC.Resolve<IShippingDetailService>();
                        shippingDetailService.SendPurchaseShippingNotification(EventId.Value, CustomerId.Value, creatorOrganizationRoleUser.Id);
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                }
            }
            return true;
        }

        protected bool PlaceNewShippingOrder()
        {
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                var orderId = _order.Id;

                if (Customer == null) return false;

                var organizationRoleUser = GetCreatorOrganizationRoleUser();

                UpdateCustomerBillingAddress(organizationRoleUser.Id);

                IOrderController orderController = new OrderController();

                OrderDetail orderDetail = orderController.GetActiveOrderDetail(_order);

                if (orderDetail != null)
                {
                    var paymentInstruments = new List<PaymentInstrument>();

                    var paymentAmount = AmountTobePaid;
                    if (!IsOnSitePayment && paymentAmount > 0)
                    {
                        var paymentInstrument = ManageGiftCertificatePayment(organizationRoleUser, ref paymentAmount);
                        if (paymentInstrument != null)
                            paymentInstruments.Add(paymentInstrument);

                        if (paymentInstruments.IsEmpty() || paymentAmount > 0)
                            paymentInstruments.Add(ChargePayment(organizationRoleUser, paymentAmount,
                                                                 EventId + "_" + orderId));
                    }

                    if (ShippingDetail != null)
                    {
                        var shippingDetail = ShippingDetail;
                        var isexclusivelyRequested = _shippingDetailService.CheckShippingIsExclusivelyRequested(EventId.Value, CustomerId.Value);
                        shippingDetail.IsExclusivelyRequested = isexclusivelyRequested;

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
                                productShippingDetail.IsExclusivelyRequested = isexclusivelyRequested;

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

        protected static Order PlaceOrder(DomainObjectBase forOrganizationRoleUser, DomainObjectBase creatorOrganizationRoleUser, IOrderable itemToOrder)
        {
            IOrderController orderController = new OrderController();

            orderController.AddItem(itemToOrder, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                    OrderStatusState.FinalSuccess);

            return orderController.PlaceOrder(OrderType.Retail, creatorOrganizationRoleUser.Id);
        }

        protected static Order PlaceOrder(DomainObjectBase forOrganizationRoleUser, DomainObjectBase creatorOrganizationRoleUser, List<IOrderable> orderables, EventCustomer eventCustomer, SourceCode sourceCode, ShippingDetail shippingDetail)
        {
            IOrderController orderController = new OrderController();

            bool indentedLineItemsAdded = false;
            // TODO: applying hook to the system all the indented line items will be attached to the first order item.
            foreach (var orderable in orderables)
            {
                if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                {
                    orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                           sourceCode,
                                           eventCustomer, shippingDetail, OrderStatusState.FinalSuccess);
                    indentedLineItemsAdded = true;
                }
                else
                    orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                            OrderStatusState.FinalSuccess);
            }
            return orderController.PlaceOrder(OrderType.Retail, creatorOrganizationRoleUser.Id);
        }

        protected Order ActivateOrder(Order order, List<IOrderable> orderables, EventCustomer eventCustomer, DomainObjectBase creatorOrganizationRoleUser, DomainObjectBase forOrganizationRoleUser, SourceCode sourceCode)
        {
            IOrderController orderController = new OrderController();

            bool indentedLineItemsAdded = false;
            // TODO: applying hook to the system all the indented line items will be attached to the first order item.
            foreach (var orderable in orderables)
            {
                if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
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

            order = orderController.ActivateOrder(order);
            return order;
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

        private Order GetOrder()
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(CustomerId.Value, EventId.Value);
        }

        private Order GetInactiveOrder()
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetInactiveOrder(CustomerId.Value, EventId.Value);
        }

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected OrganizationRoleUser GetForOrganizationRoleUser()
        {
            if (!CustomerId.HasValue) return null;
            var repository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return repository.GetOrganizationRoleUser(CustomerId.Value);

        }

        private string GetEventAppointmentErrorMessage()
        {
            if (!EventId.HasValue && AppointmentSlotIds.IsNullOrEmpty())
            {
                return "Please select Event and Appointment";
            }
            return !EventId.HasValue ? "Please select Event" : "Please select Appointment";
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }

        private void BindPageDropDowns()
        {
            BindCountryDropDown();
            BindCreditCardDropDown();
            BindPaymentModeDropDown();
            if (EChequeAccountTypeCombo != null)
            {
                EChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
                EChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
                EChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());
            }
            if (CurrentViewType == ViewType.Technician)
            {
                ChequeAccountTypeCombo.Items.Insert(0, "Select Account Type");
                ChequeAccountTypeCombo.Items.Insert(1, AccountType.Savings.ToString());
                ChequeAccountTypeCombo.Items.Insert(2, AccountType.Checking.ToString());
            }
        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            CountryCombo.DataSource = countries;
            CountryCombo.DataTextField = DDL_TEXT_NAME;
            CountryCombo.DataValueField = DDL_VALUE_ID;
            CountryCombo.DataBind();
            //CountryCombo.Items.Insert(0, new ListItem("Select Country", "0"));
        }

        private void BindCreditCardDropDown()
        {
            CreditCardTypeCombo.Items.Clear();
            var creditCardTypes = IoC.Resolve<IChargeCardRepository>().GetAllChargeCardType();
            CreditCardTypeCombo.DataSource = creditCardTypes;
            CreditCardTypeCombo.DataTextField = "SecondValue";
            CreditCardTypeCombo.DataValueField = "FirstValue";
            CreditCardTypeCombo.DataBind();
            CreditCardTypeCombo.Items.Insert(0, (new ListItem("Select Card Type", "0")));
        }

        private void BindPaymentModeDropDown()
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
                    PaymentMode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                            PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.PayLater_Text,
                                                            PaymentType.Onsite_Value.ToString()));
                    break;
                case ViewType.CallCenterRep:
                    PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                        PaymentType.CreditCard.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                            PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                    break;
                case ViewType.PublicWebsite:
                    PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                        PaymentType.CreditCard.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                            PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                    var defaultSelectedValue = PaymentMode.Items.FindByValue(PaymentType.CreditCard.PersistenceLayerId.ToString());
                    if (defaultSelectedValue != null)
                    {
                        PaymentMode.SelectedValue = defaultSelectedValue.Value;
                    }
                    break;
                case ViewType.CustomerPortal:
                    PaymentMode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                       PaymentType.CreditCard.PersistenceLayerId.ToString()));
                    PaymentMode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                            PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
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
                CountryCombo.SelectedValue = Customer.Address.CountryId.ToString();
                IsBillingAddressSameAsHomeAddress = true;
            }
        }

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected void UpdateCustomerBillingAddress(long orgRoleId)
        {
            if (!IsBillingAddressSameAsHomeAddress)
            {
                _customer.BillingAddress = new Address
                                               {
                                                   StreetAddressLine1 = Address1TextBox.Text,
                                                   StreetAddressLine2 = Address2TextBox.Text,
                                                   State = StateHiddenField.Value,
                                                   City = CityTextBox.Text,
                                                   ZipCode = new ZipCode { Zip = ZipTextBox.Text },
                                                   Country = CountryCombo.SelectedItem.Text
                                               };
            }

            IoC.Resolve<ICustomerService>().SaveCustomer(_customer, orgRoleId);
        }

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected PaymentInstrument ChargePayment(OrganizationRoleUser organizationRoleUser, decimal paymentAmount, string customerReference)
        {
            string paymentMethodName = PaymentMode.SelectedItem.Value;

            if (paymentMethodName == PaymentType.ElectronicCheck.PersistenceLayerId.ToString())
                return ManageECheckPayment(customerReference, paymentAmount, Customer,
                                           organizationRoleUser);
            if (paymentMethodName == PaymentType.CreditCard.PersistenceLayerId.ToString() || paymentMethodName == PaymentType.CreditCardOnFile_Value.ToString())
                return ManageChargeCardPayment(customerReference, paymentAmount, Customer.Email == null ? String.Empty : Customer.Email.ToString(), organizationRoleUser);
            if (paymentMethodName == PaymentType.Check.PersistenceLayerId.ToString())
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
            var settings = IoC.Resolve<ISettings>();
            var nameParser = new NameParser();

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
                        LogAudit(ModelType.Edit, creditCardProcessorProcessingInfo, Customer.CustomerId);
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
                    LogAudit(ModelType.Edit, creditCardProcessorProcessingInfo, Customer.CustomerId);
                    PaymentGatewayResponse = paymentGateway.ChargeCreditCard(creditCardProcessorProcessingInfo);
                }
            }
            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                throw new InvalidOperationException("Payment Failed.<br />Sorry, payment request from your credit card was rejected by our payment gateway. Please check given details.");
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
            LogAudit(ModelType.Edit, electronicCheckProcessorProcessingInfo, customer.CustomerId);
            if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                throw new InvalidOperationException("Payment Failed. <br />Sorry, payment request from your eCheck is rejected by our payment gateway. Please check given details.");
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

            var instru = new CheckPayment
                       {
                           Check = check,
                           Amount = check.Amount,
                           CheckStatus = CheckPaymentStatus.Recieved,
                           DataRecorderMetaData = check.DataRecorderMetaData,
                           CheckId = check.Id
                       };
            LogAudit(ModelType.Edit, instru, Customer.CustomerId);
            return instru;
        }

        private PaymentInstrument ManageInsurancePayment(decimal paymentAmount, OrganizationRoleUser organizationRoleUser)
        {
            return new InsurancePayment
            {
                AmountToBePaid = paymentAmount,
                Amount = 0,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = organizationRoleUser,
                    DateCreated = DateTime.Now,
                    DataRecorderModifier = organizationRoleUser,
                    DateModified = DateTime.Now
                },
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

        private EventCustomer SaveEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);

            var eventCustomer = new EventCustomer
                                    {
                                        AppointmentId = appointment.Id,
                                        EventId = EventId.Value,
                                        CustomerId = Customer.CustomerId,
                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                   {
                                                                       DataRecorderCreator = organizationRoleUser,
                                                                       DateCreated = DateTime.Now
                                                                   },
                                        OnlinePayment =
                                            CurrentViewType == ViewType.PublicWebsite ||
                                            CurrentViewType == ViewType.CustomerPortal,
                                        MarketingSource = MarketingSource,
                                        NoShow = false,
                                        LeftWithoutScreeningReasonId = null,
                                        LeftWithoutScreeningNotesId = null,
                                        TestConducted = false,
                                        HIPAAStatus = RegulatoryState.Unknown,
                                        PcpConsentStatus = RegulatoryState.Unknown,
                                        AwvVisitId = (AwvVisitId.HasValue ? AwvVisitId.Value : (long?)null),
                                        EnableTexting = Customer.EnableTexting,
                                        IsForRetest = IsRetest,
                                        PreferredContactType = Customer.PreferredContactType,
                                        SingleTestOverride = SingleTestOverride
                                    };

            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            eventCustomer = itemRepository.Save(eventCustomer);

            return eventCustomer;
        }

        private EventCustomer UpdateEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            IEventCustomerRepository eventCustomerRepository = new EventCustomerRepository();
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            //try
            //{
            var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(CustomerId.Value, EventId.Value);
            var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);
            eventCustomer.AppointmentId = appointment.Id;
            eventCustomer.NoShow = false;
            eventCustomer.LeftWithoutScreeningReasonId = null;
            eventCustomer.LeftWithoutScreeningNotesId = null;

            if (AwvVisitId.HasValue)
                eventCustomer.AwvVisitId = AwvVisitId.Value;
            eventCustomer.EnableTexting = Customer.EnableTexting;
            eventCustomer.IsForRetest = IsRetest;
            eventCustomer.SingleTestOverride = SingleTestOverride;
            eventCustomer.ConfirmedBy = null;
            eventCustomer.IsAppointmentConfirmed = false;
            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            eventCustomer = itemRepository.Save(eventCustomer);

            return eventCustomer;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        private bool ScheduleNewAppointment(DomainObjectBase forOrganizationRoleUser, OrganizationRoleUser creatorOrganizationRoleUser)
        {
            var orderables = new List<IOrderable>();

            var selectedTestIds = TestIds;

            if (PackageId.HasValue && PackageId.Value > 0)
            {
                IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                orderables.Add(eventPackageRepository.GetByEventAndPackageIds(EventId.Value, PackageId.Value));

                RemoveTestsAlreadyInPackage(selectedTestIds);
            }

            if (!selectedTestIds.IsNullOrEmpty())
            {
                IEventTestRepository eventTestRepository = new EventTestRepository();
                var eventTests = eventTestRepository.GetByEventAndTestIds(EventId.Value, selectedTestIds);
                if (PackageId.HasValue && PackageId.Value > 0)
                {
                    foreach (var eventTest in eventTests)
                    {
                        eventTest.Price = eventTest.WithPackagePrice;
                    }
                }
                orderables.AddRange(eventTests);
            }

            if (ProductId.HasValue && ProductId.Value > 0)
            {
                IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                orderables.Add(itemRepository.GetById(ProductId.Value));
            }
            if (orderables.IsNullOrEmpty()) return false;

            var paymentInstruments = new List<PaymentInstrument>();

            if (EligibilityId > 0 && AmountCoveredByInsurance > 0)
            {
                paymentInstruments.Add(ManageInsurancePayment(AmountCoveredByInsurance, creatorOrganizationRoleUser));
            }

            if (AmountTobePaid > 0)
            {
                try
                {
                    var paymentAmount = AmountTobePaid;
                    var paymentInstrument = ManageGiftCertificatePayment(creatorOrganizationRoleUser, ref paymentAmount);
                    if (paymentInstrument != null)
                        paymentInstruments.Add(paymentInstrument);

                    if (!IsOnSitePayment && paymentAmount > 0)
                        paymentInstruments.Add(ChargePayment(creatorOrganizationRoleUser, paymentAmount, EventId + "_" + AppointmentSlotIds.First()));
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error(" Error while Charging Payment: ex " + ex.Message);
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error(" Error while Charging Payment: stact Trace " + ex.StackTrace);

                    throw new Exception("An Exception caused while charging Payment.", ex);
                }
            }

            int tryOut = 0;
            const int maxTryoutCount = 2;
            do
            {
                //if not first try then wait.
                if (tryOut > 0)
                    Thread.Sleep(1000);

                tryOut++;
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var eventCustomer = SaveEventCustomer(creatorOrganizationRoleUser);

                        SourceCode sourceCode;
                        if (SourceCodeId.HasValue && SourceCodeId > 0)
                            sourceCode = new SourceCode
                                {
                                    Id = SourceCodeId.Value,
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

                        if (EligibilityId > 0 && AmountCoveredByInsurance > 0)
                        {
                            var eligibilityRepository = IoC.Resolve<IEligibilityRepository>();
                            eligibilityRepository.SaveEventCustomerEligibility(eventCustomer.Id, EligibilityId, ChargeCardId);
                        }

                        Order order = PlaceOrder(forOrganizationRoleUser, creatorOrganizationRoleUser, orderables,
                                                 eventCustomer, sourceCode, ShippingDetail);

                        if (!paymentInstruments.IsNullOrEmpty())
                            ApplyPaymentToOrder(creatorOrganizationRoleUser, paymentInstruments, order);

                        SaveProductShippingDetail(order);

                        if (IsRetest)
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
                                var userSession = IoC.Resolve<ISessionContext>().UserSession;
                                eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, testIds, userSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            }
                        }

                        IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                            new AffiliateCommisionGenerationRepository();
                        bool result = affiliateCommisionGenerationRepository.SaveEventAffiliate(eventCustomer.Id, CallId);

                        scope.Complete();
                        tryOut++;
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //make payment void when max try out complete.
                    if (tryOut >= maxTryoutCount)
                    {
                        var chargeCardPayment = paymentInstruments.Find(pi => pi.PaymentType == PaymentType.CreditCard) != null
                                                    ? (ChargeCardPayment)paymentInstruments.Find(pi => pi.PaymentType == PaymentType.CreditCard)
                                                    : null;
                        if (!IsOnSitePayment && chargeCardPayment != null && AmountTobePaid > 0)
                        {
                            var paymentGateway = IoC.Resolve<IPaymentProcessor>();
                            try
                            {
                                IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Void Request Generated. Detail Processor Response" + chargeCardPayment.ProcessorResponse);
                            }
                            catch
                            {
                            }
                            paymentGateway.VoidRequestforaPreviousResponse(chargeCardPayment.ProcessorResponse);
                        }

                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                        throw new Exception("An Exception caused while saving the Order.", ex);
                    }

                    if (ShippingDetail != null)
                        ShippingDetail = new ShippingDetail();

                    if (!paymentInstruments.IsNullOrEmpty())
                    {
                        foreach (var paymentInstrument in paymentInstruments)
                        {
                            paymentInstrument.Id = 0;
                        }
                    }

                }
            } while (tryOut < maxTryoutCount);

            return true;

        }

        private void SaveProductShippingDetail(Order order, bool isExclusivelyRequested = false)
        {
            if (ProductId.HasValue && ProductId.Value > 0)
            {
                var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                var shippingOption = shippingOptionRepository.GetShippingOptionByProductId(ProductId.Value);

                if (shippingOption == null)
                    return;

                IOrderController orderController = new OrderController();
                OrderDetail orderDetail = orderController.GetActiveOrderDetail(order);

                var productShippingDetail = new ShippingDetail();

                if (ShippingDetail != null)
                {
                    if (shippingOption.Id == ShippingDetail.ShippingOption.Id)
                        return;
                    productShippingDetail = ShippingDetail;
                }
                else
                {
                    var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();

                    var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                    var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);

                    if (resultShippingDetails != null && resultShippingDetails.Count() > 0 && (cdShippingDetails == null || (cdShippingDetails.Count() < resultShippingDetails.Count())))
                    {

                        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                        productShippingDetail.ShippingAddress = Customer.Address;
                        productShippingDetail.ShippingAddress.Id = 0;
                        productShippingDetail.Status = ShipmentStatus.Processing;
                        productShippingDetail.ShippingOption = new ShippingOption();
                        productShippingDetail.DataRecorderMetaData = new DataRecorderMetaData
                                                                         {
                                                                             DataRecorderCreator = organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                                                                             DateCreated = DateTime.Now,
                                                                             DateModified = DateTime.Now
                                                                         };
                    }
                    else
                        return;
                }

                productShippingDetail.Id = 0;
                productShippingDetail.ShippingAddress.Id = 0;
                productShippingDetail.ShippingOption.Id = shippingOption.Id;
                productShippingDetail.ActualPrice = shippingOption.Price;
                productShippingDetail.IsExclusivelyRequested = isExclusivelyRequested;

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

        private void RemoveTestsAlreadyInPackage(List<long> selectedTestIds)
        {
            if (!EventId.HasValue || !PackageId.HasValue) return;

            var packageRepository = IoC.Resolve<IEventPackageRepository>();
            var eventPackage = packageRepository.GetByEventAndPackageIds(EventId.Value, PackageId.Value);
            var package = eventPackage != null ? eventPackage.Package : null;

            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);
                selectedTestIds.RemoveAll(t => packageTestIds.Contains(t));
            }
        }

        private bool ReScheduleAppointment(Order order, DomainObjectBase forOrganizationRoleUser, OrganizationRoleUser creatorOrganizationRoleUser)
        {
            if (order != null && !order.OrderDetails.IsEmpty())
            {
                var orderables = new List<IOrderable>();

                var selectedTestIds = TestIds;

                if (PackageId.HasValue && PackageId.Value > 0)
                {
                    IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                    orderables.Add(eventPackageRepository.GetByEventAndPackageIds(EventId.Value, PackageId.Value));

                    RemoveTestsAlreadyInPackage(selectedTestIds);
                }
                if (!selectedTestIds.IsNullOrEmpty())
                {
                    IEventTestRepository eventTestRepository = new EventTestRepository();
                    var eventTests = eventTestRepository.GetByEventAndTestIds(EventId.Value, selectedTestIds);
                    if (PackageId.HasValue && PackageId.Value > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }
                    orderables.AddRange(eventTests);
                }

                if (ProductId.HasValue && ProductId.Value > 0)
                {
                    IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                    orderables.Add(itemRepository.GetById(ProductId.Value));
                }

                if (orderables.IsNullOrEmpty()) return false;

                //var eventCustomer = UpdateEventCustomer(creatorOrganizationRoleUser);

                //if (eventCustomer == null) return false;

                var paymentInstruments = new List<PaymentInstrument>();

                if (EligibilityId > 0 && AmountCoveredByInsurance > 0)
                {
                    paymentInstruments.Add(ManageInsurancePayment(AmountCoveredByInsurance, creatorOrganizationRoleUser));
                }

                if (AmountTobePaid > 0)
                {
                    try
                    {
                        var paymentAmount = AmountTobePaid;
                        var paymentInstrument = ManageGiftCertificatePayment(creatorOrganizationRoleUser, ref paymentAmount);
                        if (paymentInstrument != null)
                            paymentInstruments.Add(paymentInstrument);

                        if (!IsOnSitePayment && paymentAmount > 0)
                            paymentInstruments.Add(ChargePayment(creatorOrganizationRoleUser, paymentAmount, EventId + "_" + AppointmentSlotIds.First()));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("An Exception caused while charging Payment.", ex);
                    }
                }


                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var eventCustomer = UpdateEventCustomer(creatorOrganizationRoleUser);

                        SourceCode sourceCode;
                        if (SourceCodeId.HasValue && SourceCodeId > 0)
                            sourceCode = new SourceCode
                                             {
                                                 Id = SourceCodeId.Value,
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

                        if (EligibilityId > 0 && AmountCoveredByInsurance > 0)
                        {
                            var eligibilityRepository = IoC.Resolve<IEligibilityRepository>();
                            eligibilityRepository.SaveEventCustomerEligibility(eventCustomer.Id, EligibilityId, ChargeCardId);
                        }

                        order = ActivateOrder(order, orderables, eventCustomer, creatorOrganizationRoleUser,
                                              forOrganizationRoleUser, sourceCode);

                        if (!paymentInstruments.IsNullOrEmpty())
                            ApplyPaymentToOrder(creatorOrganizationRoleUser, paymentInstruments, order);

                        SaveProductShippingDetail(order);

                        if (IsRetest)
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
                                var userSession = IoC.Resolve<ISessionContext>().UserSession;
                                eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, testIds, userSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            }
                        }

                        IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                            new AffiliateCommisionGenerationRepository();
                        bool result = affiliateCommisionGenerationRepository.SaveEventAffiliate(eventCustomer.Id, CallId);

                        scope.Complete();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    var chargeCardPayment = paymentInstruments.Find(pi => pi.PaymentType == PaymentType.CreditCard) !=
                                    null
                                        ? (ChargeCardPayment)
                                          paymentInstruments.Find(pi => pi.PaymentType == PaymentType.CreditCard)
                                        : null;
                    if (!IsOnSitePayment && chargeCardPayment != null && AmountTobePaid > 0)
                    {
                        var paymentGateway = IoC.Resolve<IPaymentProcessor>();
                        try
                        {
                            IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Void Request Generated. Detail Processor Response" + chargeCardPayment.ProcessorResponse);
                        }
                        catch
                        {
                        }
                        paymentGateway.VoidRequestforaPreviousResponse(chargeCardPayment.ProcessorResponse);
                    }
                    throw new Exception("An Exception caused while saving the Order.", ex);
                }

            }
            return true;
        }

        # endregion Private Helper Methods
    }
}
