using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using FluentValidation;
using Product = Falcon.App.Core.Finance.Domain.Product;

namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    public class RefundRequestController : Controller
    {
        private readonly IRepository<RefundRequest> _repository;
        private readonly ISessionContext _sessionContext;
        private readonly IRefundRequestService _refundRequestService;
        private readonly IEventCustomerService _eventCustomerService;
        private readonly IPaymentController _paymentController;
        private readonly ICustomerRepository _customerRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IOrderController _orderController;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IOrganizationRoleUserRepository _orgRoleUserRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;

        private readonly int _pageSize;
        private readonly bool _isEccEnabled;
        public RefundRequestController(IRepository<RefundRequest> repository, ISessionContext sessionContext, ISettings settings, IRefundRequestService refundRequestService, IEventCustomerService eventCustomerService, ILogManager logManager,
            IPaymentController paymentController, ICustomerRepository customerRepository, IElectronicProductRepository electronicProductRepository, IOrderRepository orderRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory,
            IOrderController orderController, IChargeCardRepository chargeCardRepository, IOrganizationRoleUserRepository orgRoleUserRepository, IConfigurationSettingRepository configurationSettingRepository, INotifier notifier,
            IRefundRequestRepository refundRequestRepository, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository)
        {
            _repository = repository;
            _sessionContext = sessionContext;
            _isEccEnabled = settings.IsEccEnabled;
            _pageSize = settings.DefaultPageSizeForReports;
            _refundRequestService = refundRequestService;
            _eventCustomerService = eventCustomerService;
            _paymentController = paymentController;
            _customerRepository = customerRepository;
            _electronicProductRepository = electronicProductRepository;
            _orderRepository = orderRepository;
            _chargeCardRepository = chargeCardRepository;
            _orderController = orderController;
            _notifier = notifier;
            _configurationSettingRepository = configurationSettingRepository;
            _orgRoleUserRepository = orgRoleUserRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _logger = logManager.GetLogger<Global>();
            _refundRequestRepository = refundRequestRepository;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
        }

        public ActionResult Index(int pageNumber = 1, RefundRequestListModelFilter filter = null)
        {
            int totalRecords;
            if (filter == null) filter = new RefundRequestListModelFilter() { RefundRequestStatus = (int)RequestStatus.Pending };
            var model = _refundRequestService.GetPendingRequests(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new RefundRequestListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.CustomerName,
                                   filter.DateType,
                                   filter.FromDate,
                                   filter.ToDate,
                                   filter.RefundType,
                                   filter.RefundRequestStatus,
                                   filter.CustomerId
                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult Create(long orderId, decimal amount, RefundRequestType requestType)
        {
            var model = new RefundRequestEditModel()
                            {
                                OrderId = orderId,
                                RequestedRefundAmount = amount,
                                RefundType = (int)requestType
                            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RefundRequestEditModel model)
        {
            try
            {

                var refundRequest = Mapper.Map<RefundRequestEditModel, RefundRequest>(model);
                refundRequest.RequestedOn = DateTime.Now;
                refundRequest.RequestedByOrgRoleUserId =
                    _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                refundRequest = _repository.Save(refundRequest);
                return Content(refundRequest.Id.ToString());
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        public ActionResult Edit(long id)
        {
            Session[RefundRequest.ProcessRequestId] = null; // Used for gift certificate

            var request = ((IRefundRequestRepository)_repository).Get(id);
            var model = Mapper.Map<RefundRequest, RefundRequestResultEditModel>(request);

            var order = _orderRepository.GetOrder(request.OrderId);
            var productsInOrder = _electronicProductRepository.GetProductIdsForOrderItems(order.OrderDetails
                .Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.ProductItem)
                .Select(od => od.OrderItemId).ToArray());

            var cancellationReason = "N/A";
            if (model.RefundType == RefundRequestType.CustomerCancellation)
            {
                var appointmentCancellationLogs = _eventAppointmentCancellationLogRepository.GetByEventIdCustomerId(model.EventId, model.CustomerId);
                if (!appointmentCancellationLogs.IsNullOrEmpty())
                {
                    var appointmentCancellationLog = appointmentCancellationLogs.FirstOrDefault(x => x.DateCreated > request.RequestedOn.AddMinutes(-3) && x.DateCreated < request.RequestedOn.AddMinutes(3));
                    if (appointmentCancellationLog != null)
                        cancellationReason = ((CancelAppointmentReason)appointmentCancellationLog.ReasonId).GetDescription();
                }
            }

            model.CancellationReason = cancellationReason;

            var products = _electronicProductRepository.GetAllProducts();

            model.OfferFreeProduct = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductstoOfferModel>>(products);
            if (productsInOrder != null && productsInOrder.Count() > 0)
            {
                foreach (var product in productsInOrder)
                {
                    var temp = model.OfferFreeProduct.Where(p => p.ProductId == product.SecondValue).FirstOrDefault();
                    var orderDetail =
                        order.OrderDetails.Where(od => od.OrderItemId == product.FirstValue).FirstOrDefault();
                    temp.ProductPriceinOrder = orderDetail.Price;
                    temp.OrderItemId = orderDetail.OrderItemId;
                }
            }
            CompleteEditModel(model, request.CustomerId);
            model.PaymentEditModel.Amount = model.RequestedRefundAmount;
            var nameIdpair = _orgRoleUserRepository.GetNameIdPairofUsers(new[] { request.RequestedByOrgRoleUserId }).FirstOrDefault();
            model.RequestedBy = nameIdpair != null ? nameIdpair.SecondValue : string.Empty;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RefundRequestResultEditModel model, IEnumerable<PaymentInstrumentEditModel> payments)
        {
            var request = ((IRefundRequestRepository)_repository).Get(model.RequestId);
            try
            {
                model.PaymentEditModel.Payments = payments;

                model.PreviousProcessingNotes = request.RefundRequestResult != null ? request.RefundRequestResult.Notes : string.Empty;

                if (!IsModelValid(model, payments))
                {
                    CompleteEditModel(model, model.CustomerId);
                    model.RequestedRefundAmount = request.RequestedRefundAmount;
                    return View(model);
                }
                var notesToSave = PrepareProcessorNotesHtml(model.Notes, model.PreviousProcessingNotes);

                var requestResult = Mapper.Map<RefundRequestResultEditModel, RefundRequestResult>(model);
                requestResult.Notes = notesToSave;
                requestResult.ProcessedOn = DateTime.Now;
                requestResult.ProcessedByOrgRoleUserId =
                    _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                request.RefundRequestResult = requestResult;
                request.RequestStatus = (long)RequestStatus.Resolved;

                var currentOrgRole = _sessionContext.UserSession.CurrentOrganizationRole;

                ManagePaymentsbeforeDataSave(model);

                bool isPaymentRefunded = false;
                decimal amountRefunded = 0;

                if (model.RefundAmount > 0)
                {
                    isPaymentRefunded = true;
                    amountRefunded = model.RefundAmount;
                }

                using (var scope = new TransactionScope())
                {
                    long paymentId = 0;
                    switch (model.RequestResultType)
                    {
                        case RequestResultType.AdjustOrder: // Can't do it for Cancelled appointment Record
                            ((IRefundRequestRepository)_repository).SaveProcessorNotes(model.RequestId, notesToSave);
                            scope.Complete();
                            var guid = Guid.NewGuid();
                            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                                Response.RedirectUser("/App/Common/ChangePackage.aspx?" + RefundRequest.ProcessRequestId + "=" + model.RequestId + "&EventId=" + request.EventId + "&CustomerId=" + request.CustomerId + "&" + RefundRequest.ProcessRequest + "=true&guid=" + guid);
                            else
                                Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepChangePackage.aspx?Call=No&" + RefundRequest.ProcessRequestId + "=" + model.RequestId + "&EventId=" + request.EventId + "&CustomerId=" + request.CustomerId + "&" + RefundRequest.ProcessRequest + "=true");
                            return null;

                        case RequestResultType.RescheduleAppointment:
                            ((IRefundRequestRepository)_repository).SaveProcessorNotes(model.RequestId, notesToSave);
                            scope.Complete();

                            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                                Response.RedirectUser("/App/Franchisor/FranchisorRescheduleCustomerAppointment.aspx?resolve=true&" + RefundRequest.ProcessRequestId + "=" + model.RequestId + "&EventId=" + request.EventId + "&CustomerId=" + request.CustomerId + "&" + RefundRequest.ProcessRequest + "=true");
                            else
                                Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepRescheduleCustomerAppointment.aspx?resolve=true&Call=No&" + RefundRequest.ProcessRequestId + "=" + model.RequestId + "&EventID=" + request.EventId + "&CustomerID=" + request.CustomerId + "&" + RefundRequest.ProcessRequest + "=true");
                            return null;

                        case RequestResultType.IssueRefund:

                            if (model.RefundType == RefundRequestType.CustomerCancellation)
                            {
                                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                                var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(request.CustomerId, request.EventId);
                                var customerService = IoC.Resolve<ICustomerService>();
                                customerService.UnMarkProspectCustomerConverted(eventCustomer.Id, ProspectCustomerTag.Cancellation);
                                _eventCustomerService.CancelAppointment(request.EventId, request.CustomerId, model.PaymentEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, model.ChargeCancellationFee);
                            }
                            else
                            {
                                paymentId = _paymentController.SavePayment(model.PaymentEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                                _orderRepository.ApplyPaymentToOrder(model.OrderId, paymentId);
                            }
                            break;

                        case RequestResultType.OfferFreeAddonsAndDiscounts:
                            _orderController.ManageOrderforRefundRequestwithFreeDiscountandProduct(model, model.OrderId, request.CustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            paymentId = _paymentController.SavePayment(model.PaymentEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            _orderRepository.ApplyPaymentToOrder(model.OrderId, paymentId);
                            break;

                        case RequestResultType.IssueGiftCertificate:
                            Session[RefundRequest.ProcessRequestId] = request.Id;
                            ((IRefundRequestRepository)_repository).SaveProcessorNotes(model.RequestId, notesToSave);
                            scope.Complete();
                             Response.RedirectUser("/App/CallCenter/CallCenterRep/GiftCertificate/Details.aspx?Call=No&Amount=" + model.RequestedRefundAmount);
                            return null;
                    }

                    _repository.Save(request);

                    scope.Complete();
                }

                try
                {
                    if (isPaymentRefunded)
                    {
                        SendRefundNotification(model.CustomerId, amountRefunded);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("Refund Request: Failed to send notification. Message:" + ex.Message + "\n\tStackTrace:" + ex.StackTrace);
                }
                Response.RedirectUser("/Finance/RefundRequest");
                return null;
            }
            catch (Exception ex)
            {
                _logger.Error("Refund Request: Message:" + ex.Message + "\n\tStackTrace:" + ex.StackTrace);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure while Processing Request. Message : " + ex.Message);
                _paymentController.VoidCreditCardGatewayRequests(model.PaymentEditModel);
                CompleteEditModel(model, model.CustomerId);
                model.RequestedRefundAmount = request.RequestedRefundAmount;
            }
            return View(model);
        }

        public ActionResult SaveNotes(long requestId, string notes)
        {
            var refundRequestRepository = ((IRefundRequestRepository)_repository);
            var request = refundRequestRepository.Get(requestId);
            notes = PrepareProcessorNotesHtml(notes, request.RefundRequestResult != null ? request.RefundRequestResult.Notes : string.Empty);
            refundRequestRepository.SaveProcessorNotes(requestId, notes);
            return Json("{Message: 'Saved Succesfully'}");
        }

        [HttpPost]
        public ActionResult UndoRefundRequest(long refundRequestId)
        {
            var refundRequest = _refundRequestRepository.Get(refundRequestId);
            using (var scope = new TransactionScope())
            {
                try
                {
                    switch (refundRequest.RefundRequestType)
                    {
                        case RefundRequestType.ApplySourceCode:
                            _refundRequestService.UndoApplySourceCodeRefundRequest(refundRequest);
                            break;
                        case RefundRequestType.ManualRefund:
                            _refundRequestService.UndoManualRefundRequest(refundRequest);
                            break;
                        case RefundRequestType.CDRemoval:
                            _refundRequestService.UndoCdRemoveRequest(refundRequest);
                            break;
                        case RefundRequestType.CancelShipping:
                            _refundRequestService.UndoCancelShippingRequest(refundRequest);
                            break;
                    }

                    scope.Complete();
                    return Json(new { Message = "Refund request removed successfully.", IsSuccessful = true });
                }
                catch (Exception ex)
                {
                    return Json(new { Message = ex.Message, IsSuccessful = false });
                }
            }
        }

        #region "Private Methods"

        private void CompleteEditModel(RefundRequestResultEditModel model, long customerId)
        {
            string value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.CancellationFee);

            if (!string.IsNullOrEmpty(value))
            {
                decimal fee;
                Decimal.TryParse(value.Trim(), out fee);
                model.CancellationFee = fee;
            }

            if (model.PaymentEditModel == null)
            {
                model.PaymentEditModel = new PaymentEditModel
                                {
                                    PaymentFlow = PaymentFlow.Out
                                };
            }

            if (_isEccEnabled)
                model.PaymentEditModel.AllowedPaymentTypes = new[] { new OrderedPair<long, string>(PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name),
                                                                     new OrderedPair<long, string>(PaymentType.Cash.PersistenceLayerId, PaymentType.Cash.Name),
                                                                     new OrderedPair<long, string>(PaymentType.CreditCard.PersistenceLayerId, PaymentType.CreditCard.Name)};
            else
                model.PaymentEditModel.AllowedPaymentTypes = new[]
                                                                 {
                                                                     new OrderedPair<long, string>(PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name),
                                                                     new OrderedPair<long, string>(PaymentType.Cash.PersistenceLayerId, PaymentType.Cash.Name)
                                                                 };


            var order = _orderRepository.GetOrder(model.OrderId);
            var validCardPayment = order.PaymentsApplied.Where(pi => pi.PaymentType == PaymentType.CreditCard).OrderBy(
                pi => pi.DataRecorderMetaData.DateCreated).Select(pi => (ChargeCardPayment)pi).LastOrDefault();

            if (validCardPayment != null && (_isEccEnabled || (validCardPayment.Amount > 0 && validCardPayment.DataRecorderMetaData.DateCreated > DateTime.Now.Date.AddDays(-120) && ProcessorResponse.IsValidResponseString(validCardPayment.ProcessorResponse))))
            {
                model.PaymentEditModel.ChargeCardonFile = new ChargeCardPaymentEditModel()
                                                    {
                                                        ChargeCardPayment = validCardPayment,
                                                        ChargeCard = _chargeCardRepository.GetById(validCardPayment.ChargeCardId)
                                                    };

                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(new[]
                                                             {
                                                                 new OrderedPair<long, string>(PaymentType.CreditCardOnFile_Value, PaymentType.CreditCardOnFile_Text)
                                                             });
            }

            model.PaymentEditModel.ExistingBillingAddress =
                Mapper.Map<Address, AddressEditModel>(_customerRepository.GetCustomer(customerId).BillingAddress) ?? new AddressEditModel();
        }

        private static bool IsModelValid(RefundRequestResultEditModel model, IEnumerable<PaymentInstrumentEditModel> Payments)
        {
            bool isPaymentsValid = true;
            bool isModelValid = true;
            string result = ValidateModel(IoC.Resolve<IValidator<RefundRequestResultEditModel>>(), model);
            if (!string.IsNullOrEmpty(result))
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage(result);
                isModelValid = false;
            }

            if (Payments != null && Payments.Count() > 0)
            {
                var validator = IoC.Resolve<IValidator<PaymentInstrumentEditModel>>();
                foreach (var payment in Payments)
                {
                    result = ValidateModel(validator, payment);
                    if (!string.IsNullOrEmpty(result))
                    {
                        isPaymentsValid = false;
                        payment.FeedbackMessage =
                            FeedbackMessageModel.CreateFailureMessage(result);
                    }
                }
            }
            else
            {
                if ((model.RequestResultType == RequestResultType.IssueRefund || model.RequestResultType == RequestResultType.OfferFreeAddonsAndDiscounts) && model.RefundAmount > 0)
                {
                    result = result + " Please provide some payment information.<br />";

                    model.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(result);
                    isModelValid = false;
                }
            }

            return (isPaymentsValid && isModelValid);
        }

        private static string ValidateModel<T>(IValidator<T> validator, T objectToValidate)
        {
            var result = validator.Validate(objectToValidate);
            if (result.IsValid) return string.Empty;

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            if (htmlString.Length > 0)
            {
                return htmlString;
            }
            return string.Empty;
        }

        private string PrepareProcessorNotesHtml(string newNotes, string notesInDb)
        {
            var currentUser = _sessionContext.UserSession.FullName + " (" +
                    _sessionContext.UserSession.CurrentOrganizationRole.RoleDisplayName + ")";
            if (!string.IsNullOrEmpty(notesInDb))
                return notesInDb + "<br /><br />" + "by <b>" + currentUser + "</b> - <i> on " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + "</i> <br />" + newNotes;
            else
                return "by <b>" + currentUser + "</b> - <i> on " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + "</i> <br />" + newNotes;
        }

        private void ManagePaymentsbeforeDataSave(RefundRequestResultEditModel model)
        {
            switch (model.RequestResultType)
            {
                case RequestResultType.IssueRefund:
                    _paymentController.ManagePayment(model.PaymentEditModel, model.CustomerId, Request.UserHostAddress, "Pr_Rq_IR_" + model.RequestId);
                    break;

                case RequestResultType.OfferFreeAddonsAndDiscounts:
                    _paymentController.ManagePayment(model.PaymentEditModel, model.CustomerId, Request.UserHostAddress, "Pr_Rq_DiscAdOn_" + model.RequestId);
                    break;
            }
        }

        private void SendRefundNotification(long customerId, decimal amountRefunded)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var amountRefundModel = _emailNotificationModelsFactory.GetAmountRefundNotificationViewModel(customer.NameAsString, amountRefunded);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AmountRefundNotification, EmailTemplateAlias.AmountRefundNotification, amountRefundModel, customer.Id, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
        }

        #endregion
    }
}
