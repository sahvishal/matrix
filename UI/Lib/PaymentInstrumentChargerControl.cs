using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Core.Extensions;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Finance;
using Falcon.App.UI.App.BasePageClass;

namespace Falcon.App.UI.Lib
{
    // TODO: PaymentInstrumentCharger, PaymentInstrumentChargerControl,PackageRegistrationPaymentCharger have to be merged to gether.
    // TODO: These files contain lot of redundant code, figure a out a way to get common code to single file.
    public abstract class PaymentInstrumentChargerControl : BaseUserControl
    {
        protected const string DDL_VALUE_ID = "Id";
        protected const string DDL_TEXT_NAME = "Name";

        protected const string ResponseReasonCodeForSameDayRefund = "54";

        protected abstract long? CallId { get; set; }

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

        protected virtual List<long> TestIds
        {
            get
            {
                if (ViewState["TestIds"] != null && ViewState["TestIds"] is List<long>)
                {
                    return ViewState["TestIds"] as List<long>;
                }
                return new List<long>();
            }
            set
            {
                ViewState["TestIds"] = value;
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

        protected abstract long? EventId { get; set; }

        protected abstract long? CustomerId { get; set; }

        protected virtual bool IsOnSitePayment { get { return PaymentMode.SelectedItem.Value == PaymentType.Onsite_Value.ToString(); } }

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

        protected virtual ShippingDetail ShippingDetail { get; set; }

        protected abstract decimal AmountCoveredByInsurance { get; }
        protected abstract long EligibilityId { get; set; }
        protected abstract long ChargeCardId { get; set; }

        protected ProcessorResponse PaymentGatewayResponse { get; set; }

        # region Page Controls Properties

        protected abstract DropDownList CountryCombo { get; }
        protected abstract DropDownList ECountryCombo { get; }

        protected abstract HiddenField StateHiddenField { get; }
        protected abstract HiddenField EStateHiddenField { get; }
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

        protected Order _order;

        protected Order CurrentOrder
        {
            get { return _order; }
        }

        protected bool ApplyCoupon()
        {
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;

                var organizationRoleUser = GetCreatorOrganizationRoleUser();

                IOrderController orderController = new OrderController();

                OrderDetail orderDetail = orderController.GetActiveOrderDetail(_order);

                List<PaymentInstrument> paymentInstruments = GetActivePaymentInstruments(orderDetail,
                                                                                         organizationRoleUser);
                paymentInstruments.RemoveAll(pi => pi == null);

                var sourceCode = new SourceCode(SourceCodeId) { CouponValue = SourceCodeAmount };

                _order = orderController.UpdateOrder(_order, sourceCode, organizationRoleUser.Id);

                var isRefundQueueEnabled = IoC.Resolve<ISettings>().IsRefundQueueEnabled;

                if ((!isRefundQueueEnabled) || !(TotalAmountPayable < 0 && !CheckOnOrderWhethertoprocessRefundOrdNot(0)))
                {
                    if (TotalAmountPayable >= 0 && isRefundQueueEnabled)
                        CheckifanUnresolvedRequestExistsforanOrder(_order.Id);

                    if (!IsOnSitePayment && TotalAmountPayable != 0 && !paymentInstruments.IsNullOrEmpty())
                        ApplyPaymentToOrder(organizationRoleUser, paymentInstruments, _order);
                    else if (!IsOnSitePayment && TotalAmountPayable != 0 && paymentInstruments.IsNullOrEmpty())
                        return false;
                }

                IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                    new AffiliateCommisionGenerationRepository();
                return
                    affiliateCommisionGenerationRepository.SaveEventAffiliate(
                        orderDetail.EventCustomerOrderDetail.EventCustomerId, CallId);
            }
            return true;
        }

        protected bool CancelAppointment()
        {
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;

                var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                var forOrganizationRoleUser = GetForOrganizationRoleUser();

                var orderController = new OrderController();

                OrderDetail orderDetail = orderController.GetActiveOrderDetail(_order);

                if (orderDetail == null) return false;

                if (orderDetail.EventCustomerOrderDetail == null) return false;

                var eventCustomer = UpdateEventCustomer(orderDetail, true);

                if (eventCustomer == null) return false;

                var paymentInstruments = new List<PaymentInstrument>(); //GetActivePaymentInstruments(orderDetail,creatorOrganizationRoleUser);
                if (!IsOnSitePayment && TotalAmountPayable.Value != 0)
                {
                    var paymentAmount = TotalAmountPayable.Value;

                    string paymentMode = PaymentMode.SelectedItem.Value;

                    if (paymentMode == PaymentType.CreditCard.PersistenceLayerId.ToString() || paymentMode == PaymentType.CreditCardOnFile_Value.ToString())
                    {
                        var cancellationFeeString = IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.CancellationFee);

                        decimal cancellationFee = 0;
                        if (!string.IsNullOrEmpty(cancellationFeeString))
                            decimal.TryParse(cancellationFeeString, out cancellationFee);

                        paymentAmount -= cancellationFee;
                        if (cancellationFee > 0)
                            paymentInstruments.Add(ChargePayment(creatorOrganizationRoleUser, cancellationFee, EventId + "_" + orderDetail.Id));
                    }
                    if (paymentAmount < 0)
                    {
                        paymentInstruments.Add(RefundPayment(creatorOrganizationRoleUser, paymentAmount, EventId + "_" + orderDetail.Id));
                    }

                }

                paymentInstruments.RemoveAll(pi => pi == null);
                var order = orderController.CancelOrder(_order, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id);


                if (!IsOnSitePayment && TotalAmountPayable != 0 && !paymentInstruments.IsNullOrEmpty())
                    ApplyPaymentToOrder(creatorOrganizationRoleUser, paymentInstruments, order);
                else if (!IsOnSitePayment && TotalAmountPayable != 0 && paymentInstruments.IsNullOrEmpty())
                    return false;

                IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                    new AffiliateCommisionGenerationRepository();
                return affiliateCommisionGenerationRepository.SaveEventAffiliate(eventCustomer.Id, CallId);
            }
            return true;
        }

        protected bool ChangePackage(out string newOrderString)
        {
            newOrderString = "";
            _order = GetOrder();

            if (_order != null && !_order.OrderDetails.IsEmpty())
            {
                OrderId = _order.Id;

                var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                var forOrganizationRoleUser = GetForOrganizationRoleUser();

                IOrderController orderController = new OrderController();
                var orderDetail = orderController.GetActiveOrderDetail(_order);

                var orderables = new List<IOrderable>();

                var selectedTestIds = TestIds;
                var newOrderTestIds = new List<long>();
                newOrderTestIds.AddRange(TestIds);
                if (PackageId > 0)
                {
                    IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                    var eventPackage = eventPackageRepository.GetByEventAndPackageIds(EventId.Value, PackageId);
                    orderables.Add(eventPackage);
                    newOrderString = eventPackage.Package.Name;
                    RemoveTestsAlreadyInPackage(selectedTestIds);
                    newOrderTestIds.AddRange(eventPackage.Tests.Select(x => x.TestId));
                }

                if (!selectedTestIds.IsNullOrEmpty())
                {
                    IEventTestRepository eventTestRepository = new EventTestRepository();
                    var eventTests = eventTestRepository.GetByEventAndTestIds(EventId.Value, selectedTestIds);
                    if (PackageId > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                            newOrderString = newOrderString + ", " + eventTest.Test.Name;
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

                Order order = orderController.PlaceOrder(_order);

                if (eventCustomer.IsForRetest)
                {
                    var eventCustomerRetestRepository = IoC.Resolve<IEventCustomerRetestRepository>();
                    eventCustomerRetestRepository.DeleteByEventCustomerId(eventCustomer.Id);

                    var testIds = newOrderTestIds.Distinct().ToArray();

                    if (!testIds.IsNullOrEmpty())
                    {
                        var userSession = IoC.Resolve<ISessionContext>().UserSession;
                        eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, testIds, userSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    }
                }

                var isRefundQueueEnabled = IoC.Resolve<ISettings>().IsRefundQueueEnabled;
                long requestId = 0;
                if (Request.QueryString[RefundRequest.ProcessRequestId] != null)
                    long.TryParse(Request.QueryString[RefundRequest.ProcessRequestId], out requestId);

                bool toProcessOrder = (isRefundQueueEnabled && TotalAmountPayable < 0) ? CheckOnOrderWhethertoprocessRefundOrdNot(requestId, (int)RequestResultType.AdjustOrder) : true;

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

        protected void CheckifanUnresolvedRequestExistsforanOrder(long orderId)
        {
            var repository = IoC.Resolve<IRefundRequestRepository>();
            var requests = repository.GetbyOrderId(orderId);
            if (requests != null && requests.Count() > 0)
            {
                ((IRepository<RefundRequest>)repository).Delete(requests);
            }
        }

        public bool CheckOnOrderWhethertoprocessRefundOrdNot(long requestId, int resultType = 0)
        {
            if (Request.QueryString[RefundRequest.ProcessRequest] != null)
            {
                var repository = IoC.Resolve<IRefundRequestRepository>();
                var request = repository.Get(requestId);
                request.RefundRequestResult.ProcessedByOrgRoleUserId =
                    IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                request.RefundRequestResult.RequestResultType = (RequestResultType)resultType;
                request.RefundRequestResult.ProcessedByOrgRoleUserId =
                    IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                request.RefundRequestResult.RequestResultType = (RequestResultType)resultType;
                request.RefundRequestResult.ProcessedByOrgRoleUserId =
                    IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                request.RefundRequestResult.RequestResultType = (RequestResultType)resultType;
                request.RefundRequestResult.ProcessedOn = DateTime.Now;
                request.RefundRequestResult.RefundAmount = TotalAmountPayable.Value * -1;
                request.RequestStatus = (long)RequestStatus.Resolved;
                ((IRepository<RefundRequest>)repository).Save(request);
                return true;
            }

            var refundRequest = PrepareRefundRequestObject();
            IoC.Resolve<IRefundRequestService>().SaveRequest(refundRequest);
            return false;
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

        protected void RemoveTestsAlreadyInPackage(List<long> selectedTestIds)
        {
            if (!EventId.HasValue) return;

            var packageRepository = IoC.Resolve<IEventPackageRepository>();
            var eventPackage = packageRepository.GetByEventAndPackageIds(EventId.Value, PackageId);
            var package = eventPackage != null ? eventPackage.Package : null;


            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);
                selectedTestIds.RemoveAll(t => packageTestIds.Contains(t));
            }
        }

        protected List<PaymentInstrument> GetActivePaymentInstruments(DomainObjectBase orderDetail, OrganizationRoleUser organizationRoleUser)
        {
            var paymentInstruments = new List<PaymentInstrument>();

            if (!IsOnSitePayment && TotalAmountPayable.Value != 0)
            {
                var paymentAmount = TotalAmountPayable.Value;
                var paymentInstrument = ManageGiftCertificatePayment(organizationRoleUser, ref paymentAmount);
                if (paymentInstrument != null)
                    paymentInstruments.Add(paymentInstrument);

                if (paymentAmount > 0)
                    paymentInstruments.Add(ChargePayment(organizationRoleUser, paymentAmount, EventId + "_" + orderDetail.Id));
                else if (paymentAmount < 0)
                {
                    try
                    {
                        paymentInstruments.Add(RefundPayment(organizationRoleUser, paymentAmount, EventId + "_" + orderDetail.Id));
                    }
                    catch (InvalidOperationException ex)
                    {
                        string paymentMode = PaymentMode.SelectedItem.Value;

                        var creditCardPaymentInstrument = _order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as ChargeCardPayment;

                        if (PaymentGatewayResponse != null && PaymentGatewayResponse.ProcessorResult == ProcessorResponseResult.ProcessorError && PaymentGatewayResponse.ResponseCode == ResponseReasonCodeForSameDayRefund
                            && paymentMode == PaymentType.CreditCardOnFile_Value.ToString() && creditCardPaymentInstrument != null && creditCardPaymentInstrument.Amount > (paymentAmount < 0 ? (-1) * paymentAmount : paymentAmount))
                        {
                            paymentInstruments.Add(RefundPayment(organizationRoleUser, (-1) * creditCardPaymentInstrument.Amount, EventId + "_" + orderDetail.Id));

                            paymentInstruments.Add(ChargePayment(organizationRoleUser, creditCardPaymentInstrument.Amount + paymentAmount, EventId + "_" + orderDetail.Id));
                        }
                        else
                            throw new InvalidOperationException(ex.Message);
                    }

                }
            }
            return paymentInstruments;
        }

        protected static EventCustomer UpdateEventCustomer(OrderDetail orderDetail, bool isOrderCancelled)
        {
            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            var eventCustomer = itemRepository.GetById(orderDetail.EventCustomerOrderDetail.EventCustomerId);

            if (eventCustomer == null) return null;

            if (isOrderCancelled)
            {
                var eventCustomerRepository = new EventCustomerRepository();
                eventCustomerRepository.UpdateAppointmentId(orderDetail.EventCustomerOrderDetail.EventCustomerId);

                var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
                eventAppointmentService.DeleteAppointment(eventCustomer.AppointmentId.Value);
            }
            //TODO: UniqueItemRepository Update enetity not working properly.
            //eventCustomer = itemRepository.Save(eventCustomer);
            return eventCustomer;
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

            if (!AddressValidation(billingAddress))
            {
                Customer.BillingAddress = billingAddress;
            }

            var customerService = IoC.Resolve<ICustomerService>();
            customerService.SaveCustomer(Customer, orgRoleId);
        }

        protected bool AddressValidation(Address address)
        {
            var addressRepository = IoC.Resolve<IAddressRepository>();
            try
            {
                addressRepository.ValidateAddress(address);
            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage(ex.Message);
                Page.ClientScript.RegisterStartupScript(typeof(string), "js_maintainAfterFailedPostBack", "ShowHide();", true);
                return false;
            }
            return true;
        }

        protected PaymentInstrument RefundPayment(OrganizationRoleUser organizationRoleUser, decimal paymentAmount, string customerReference)
        {
            string paymentMode = PaymentMode.SelectedItem.Value;

            if (paymentMode == PaymentType.CreditCard.PersistenceLayerId.ToString() || paymentMode == PaymentType.CreditCardOnFile_Value.ToString())
                return ManageChargeCardPayment(customerReference, paymentAmount, Customer.Email == null ? String.Empty : Customer.Email.ToString(), organizationRoleUser);

            if (paymentMode == PaymentType.Check.PersistenceLayerId.ToString())
                return ManageCheckPayment(paymentAmount, organizationRoleUser);

            return ManageCashPayment(paymentAmount, organizationRoleUser);
        }

        //protected PaymentInstrument VoidRequest(OrganizationRoleUser organizationRoleUser, decimal paymentAmount)
        //{
        //    var paymentGateway = IoC.Resolve<IPaymentProcessor>();
        //    var creditCardPaymentInstrument =
        //            _order.PaymentsApplied.FirstOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
        //            ChargeCardPayment;

        //    if (creditCardPaymentInstrument != null && PaymentMode.SelectedItem.Text == CREDIT_CARD_ON_FILE)
        //    {
        //        string[] processorResponse = creditCardPaymentInstrument.ProcessorResponse.Split(new[] { ',' });

        //        if (processorResponse.Length < 4)
        //        {
        //            Page.ClientScript.RegisterStartupScript(typeof(string), "jscoderefund",
        //                                                    "alert('Credit card refund is not possible because TokenId does not exist with us.'); SetValuesafterFailedPostBack(); ",
        //                                                    true);
        //            return null;
        //        }

        //        PaymentGatewayResponse = paymentGateway.VoidRequest(processorResponse[2], processorResponse[3]);

        //        const string paymentAcceptedPrefix = "P";

        //        if (!PaymentGatewayResponse.StartsWith(paymentAcceptedPrefix))
        //        {
        //            SetAndDisplayErrorMessage
        //                ("Sorry, payment request from your credit card was rejected by our payment gateway. Please check given details.");
        //            throw new InvalidOperationException("Payment Failed.");
        //        }

        //        if (creditCardPaymentInstrument != null)
        //        {
        //            return new ChargeCardPayment
        //            {
        //                Amount = paymentAmount,
        //                ChargeCardId = creditCardPaymentInstrument.ChargeCardId,
        //                ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
        //                DataRecorderMetaData =
        //                    new DataRecorderMetaData { DataRecorderCreator = organizationRoleUser, DateCreated = DateTime.Now },
        //                ProcessorResponse = PaymentGatewayResponse
        //            };
        //        }
        //    }
        //    return null;
        //}

        // TODO: Making it protected since it is used in persisting Gift Certificate.
        // It has to be private.
        protected PaymentInstrument ChargePayment(OrganizationRoleUser organizationRoleUser, decimal paymentAmount, string customerReference)
        {
            string paymentMode = PaymentMode.SelectedItem.Value;

            if (paymentMode == PaymentType.ElectronicCheck.PersistenceLayerId.ToString())
                return ManageECheckPayment(customerReference, paymentAmount, Customer, organizationRoleUser);

            if (paymentMode == PaymentType.CreditCard.PersistenceLayerId.ToString() || paymentMode == PaymentType.CreditCardOnFile_Value.ToString())
                return ManageChargeCardPayment(customerReference, paymentAmount, Customer.Email == null ? String.Empty : Customer.Email.ToString(), organizationRoleUser);

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
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_CheckGiftCertificate", "alert('This Gift Certificate has been applied in another event registration. Please apply it again.');", true);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "js_CheckGiftCertificate", "alert('" + ex.Message + "');", true);
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
            else
            {
                var creditCardPaymentInstrument =
                    _order.PaymentsApplied.Where(pi => pi.PaymentType == PaymentType.CreditCard).OrderBy(
                        pi => pi.DataRecorderMetaData.DateCreated).Select(pi => (ChargeCardPayment)pi).LastOrDefault();

                if (creditCardPaymentInstrument != null && PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString())
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
                        BillingState = GetStateCode(StateHiddenField.Value),
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
                   EAddress1TextBox.Text,
                BillingCity =
                   ECityTextBox.Text,
                BillingState =
                    GetStateCode(EStateHiddenField.Value),
                BillingPostalCode =
                    EZipTextBox.Text,
                BillingCountry =
                    GetCountryCode(Convert.ToInt32(ECountryCombo.SelectedItem.Value)),
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

        protected PaymentInstrument ManageInsurancePayment(decimal paymentAmount, OrganizationRoleUser organizationRoleUser)
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

        protected OrganizationRoleUser GetForOrganizationRoleUser()
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var orgRolesUsers = organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(Customer.Id);
            if (!orgRolesUsers.IsNullOrEmpty())
                return orgRolesUsers.Where(org => org.RoleId == (long)Roles.Customer).FirstOrDefault();

            return null;
        }

        # endregion Private Helper Methods
    }
}