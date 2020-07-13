using System;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Users;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Filters;
using FluentValidation;
using Product = Falcon.App.Core.Enum.Product;


namespace Falcon.App.UI.Areas.Finance.Controllers
{
    [RoleBasedAuthorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IOrderController _orderController;
        private readonly ISessionContext _sessionContext;
        private readonly IRefundRequestService _refundRequestService;
        private readonly IPaymentController _paymentController;
        private readonly ISettings _settings;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;

        public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository, IOrderController orderController, ISessionContext sessionContext, IRefundRequestService refundRequestService,
            ISettings settings, IPaymentController paymentController, IChargeCardRepository chargeCardRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IElectronicProductRepository electronicProductRepository, ICdContentGeneratorTrackingRepository cdContentGeneratorTrackingRepository, IRefundRequestRepository refundRequestRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderController = orderController;
            _sessionContext = sessionContext;
            _refundRequestService = refundRequestService;
            _settings = settings;
            _paymentController = paymentController;
            _chargeCardRepository = chargeCardRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _cdContentGeneratorTrackingRepository = cdContentGeneratorTrackingRepository;
            _electronicProductRepository = electronicProductRepository;
            _refundRequestRepository = refundRequestRepository;
        }


        public ActionResult RemoveProduct(long eventId, long customerId)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);
            var customer = _customerRepository.GetCustomer(customerId);

            var model = new ProductOrderItemEditModel()
                            {
                                CustomerId = customerId,
                                EventId = eventId,
                                CustomerName = customer.NameAsString,
                                Order = order,
                                RefundRequest = new RefundRequestEditModel()
                                                    {
                                                        OrderId = order.Id,
                                                        RefundType = (int)RefundRequestType.CDRemoval
                                                    },
                                Payments = new PaymentEditModel()
                                               {
                                                   PaymentFlow = PaymentFlow.Out,
                                                   AllowedPaymentTypes = new[] { new OrderedPair<long, string>(PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name) }
                                               }
                            };

            CompleteModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult RemoveProduct(ProductOrderItemEditModel model, PaymentEditModel paymentModel)
        {
            try
            {
                model.Order = _orderRepository.GetOrder(model.CustomerId, model.EventId);
                model.Payments = paymentModel;
                var result = IsModelValid(model);
                if (!result)
                {
                    CompleteModel(model);
                    return View(model);
                }

                if (_settings.IsRefundQueueEnabled)
                {
                    using (var scope = new TransactionScope())
                    {
                        SaveOrderforProductRemove(model);
                        CheckEventCustomerResultStateAndDeleteCdGenTrackRecord(model.EventId, model.CustomerId);
                        if (model.RefundRequest != null && model.RefundRequest.RequestedRefundAmount > 0)
                            _refundRequestService.SaveRequest(model.RefundRequest);

                        scope.Complete();
                    }
                }
                else
                {
                    if (paymentModel != null && paymentModel.Payments != null && paymentModel.Payments.Count() > 0)
                    {
                        try
                        {
                            _paymentController.ManagePayment(paymentModel, model.CustomerId, Request.UserHostAddress, "Product_Removal_" + model.CustomerId + "_" + model.ProductOrderDetailIds.FirstOrDefault());


                        }
                        catch (Exception)
                        {
                            model.FeedbackMessage =
                                FeedbackMessageModel.CreateFailureMessage(
                                    "System Failure! Payments were not processed for Customer: " + model.CustomerName + " [Id = " + model.CustomerId + "]. Please contact system administrator at " + _settings.SupportEmail);
                            return View(model);
                        }
                    }
                    using (var scope = new TransactionScope())
                    {
                        SaveOrderforProductRemove(model);
                        if (paymentModel != null && paymentModel.Payments != null && paymentModel.Payments.Count() > 0)
                        {
                            var paymentId = _paymentController.SavePayment(paymentModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                            _orderRepository.ApplyPaymentToOrder(model.Order.Id, paymentId);
                        }
                        CheckEventCustomerResultStateAndDeleteCdGenTrackRecord(model.EventId, model.CustomerId);
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                model.Order = _orderRepository.GetOrder(model.CustomerId, model.EventId);
                CompleteModel(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure! " + ex.Message);
                return View(model);
            }

            model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Product removed from order successfully!");
            return View(model);
        }

        private void CheckEventCustomerResultStateAndDeleteCdGenTrackRecord(long eventId, long customerId)
        {
            var isCdPurchased = _electronicProductRepository.IsProductPurchased(eventId, customerId, Product.UltraSoundImages);
            if (isCdPurchased) return;

            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null) return;
            try
            {
                var cdContent = _cdContentGeneratorTrackingRepository.GetCdContentGeneratedforEventCustomerIds(new[] { eventCustomerResult.Id }).FirstOrDefault();
                if (cdContent != null)
                {
                    _cdContentGeneratorTrackingRepository.Delete(cdContent.Id);
                }
            }
            catch
            {

            }
        }

        private bool IsModelValid(ProductOrderItemEditModel model)
        {
            var amount =
                model.Order.OrderDetails.Where(
                    od =>
                    od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                    model.ProductOrderDetailIds.Contains(od.Id)).Sum(od => od.Price);

            if (_settings.IsRefundQueueEnabled)
            {
                if ((model.Order.DiscountedTotal - amount) < model.Order.TotalAmountPaid)
                {
                    var validator = IoC.Resolve<IValidator<RefundRequestEditModel>>();
                    var result = ValidateModel(validator, model.RefundRequest);

                    if (!string.IsNullOrEmpty(result))
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                        return false;
                    }
                }
            }
            else
            {
                if ((model.Order.DiscountedTotal - amount) < model.Order.TotalAmountPaid)
                {
                    var validator = IoC.Resolve<IValidator<PaymentEditModel>>();
                    var result = ValidateModel(validator, model.Payments);

                    if (!string.IsNullOrEmpty(result))
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                        return false;
                    }

                    if (model.Payments.Payments == null || model.Payments.Payments.Count() < 1 || model.Payments.Payments.Sum(p => p.Amount) < model.Payments.Amount)
                    {
                        result = "Please provide the complete payment information";
                        model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                        return false;
                    }
                }
            }
            return true;
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

        private void SaveOrderforProductRemove(ProductOrderItemEditModel model)
        {
            var order = model.Order;
            _orderController.NegateOrderLineItems(model.ProductOrderDetailIds, order, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            model.Order = order;
        }

        private void CompleteModel(ProductOrderItemEditModel model)
        {
            if (model.Payments != null)
                model.Payments = new PaymentEditModel
                                     {
                                         PaymentFlow = PaymentFlow.Out,
                                         AllowedPaymentTypes =
                                             new[]
                                                 {
                                                     new OrderedPair<long, string>(
                                                         PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name)
                                                 }
                                     };
            else
            {
                model.Payments.PaymentFlow = PaymentFlow.Out;
                model.Payments.AllowedPaymentTypes =
                    new[]
                        {
                            new OrderedPair<long, string>(
                                PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name)
                        };
            }

            var order = model.Order;
            if (order.PaymentsApplied != null && order.PaymentsApplied.Count > 0 && order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard && pa.Amount > 0).Count() > 0)
            {
                var cardPayment = (ChargeCardPayment)order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard).OrderByDescending(
                    pa => pa.DataRecorderMetaData.DateCreated).FirstOrDefault();

                string reasonForFailure;
                if (IoC.Resolve<IChargeCardService>().IsCardValidforRefund(cardPayment, 0, out reasonForFailure))
                {
                    model.Payments.ChargeCardonFile = new ChargeCardPaymentEditModel()
                    {
                        ChargeCardPayment = cardPayment,
                        ChargeCard = _chargeCardRepository.GetById(cardPayment.ChargeCardId)
                    };

                    model.Payments.AllowedPaymentTypes = model.Payments.AllowedPaymentTypes.Concat(new[]
                                                                  {
                                                                      new OrderedPair<long, string>(
                                                                          PaymentType.CreditCardOnFile_Value,
                                                                          PaymentType.CreditCardOnFile_Text)
                                                                  });
                }
            }

            model.Payments.ExistingBillingAddress =
                Mapper.Map<Address, AddressEditModel>(_customerRepository.GetCustomer(model.CustomerId).BillingAddress) ?? new AddressEditModel();
        }

        public ActionResult ManualRefund(long eventId, long customerId)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var refundRequests = IoC.Resolve<IRefundRequestRepository>().GetbyOrderId(order.Id);
            decimal requestSum = 0;
            if (refundRequests != null)
            {
                requestSum = refundRequests.Sum(rr => rr.RequestedRefundAmount);
            }
            var model = new ManualRefundEditModel
                            {
                                CustomerId = customerId,
                                EventId = eventId,
                                CustomerName = customer.NameAsString,
                                Order = order,
                                TotalRefundRequestAmount = requestSum,
                                RefundRequest = new RefundRequestEditModel()
                                                    {
                                                        OrderId = order.Id,
                                                        RefundType = (int)RefundRequestType.ManualRefund
                                                    },
                                Payments = new PaymentEditModel
                                               {
                                                   PaymentFlow = PaymentFlow.Out,
                                                   AllowedPaymentTypes =
                                                       new[]
                                                           {
                                                               new OrderedPair<long, string>(
                                                                   PaymentType.Check.PersistenceLayerId,
                                                                   PaymentType.Check.Name)
                                                           }
                                               }
                            };
            CompleteModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult ManualRefund(ManualRefundEditModel model, PaymentEditModel paymentModel)
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            try
            {
                model.Order = _orderRepository.GetOrder(model.CustomerId, model.EventId);
                model.Payments = paymentModel;
                var result = IsModelValid(model);
                if (!result)
                {
                    CompleteModel(model);
                    return View(model);
                }
                if ((_settings.IsRefundQueueEnabled) && (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager) || currentOrgRole.CheckRole((long)Roles.Technician)))
                {
                    using (var scope = new TransactionScope())
                    {
                        SaveRefundOrder(model);
                        if (model.RefundRequest != null && model.RefundRequest.RequestedRefundAmount > 0)
                        {
                            var refundRequests = _refundRequestRepository.GetbyOrderId(model.Order.Id);
                            if (!refundRequests.IsNullOrEmpty())
                            {
                                var requestSum = refundRequests.Where(rr => rr.RefundRequestType == RefundRequestType.ManualRefund && rr.RequestStatus == (long)RequestStatus.Pending).Sum(rr => rr.RequestedRefundAmount);
                                model.RefundRequest.RequestedRefundAmount += requestSum;
                            }
                            _refundRequestService.SaveRequest(model.RefundRequest);
                        }

                        scope.Complete();
                    }
                }
                else
                {
                    if (paymentModel != null && paymentModel.Payments != null && paymentModel.Payments.Count() > 0)
                    {
                        try
                        {
                            _paymentController.ManagePayment(paymentModel, model.CustomerId, Request.UserHostAddress, "Manual_Refund_" + model.CustomerId + "_" + model.EventId);
                        }
                        catch (Exception)
                        {
                            model.FeedbackMessage =
                                FeedbackMessageModel.CreateFailureMessage(
                                    "System Failure! Your order was saved succesfully. Payments were not processed for Customer: " + model.CustomerName + " [Id = " + model.CustomerId + "]. Please contact system administrator at " + _settings.SupportEmail);
                            return View(model);
                        }
                    }
                    using (var scope = new TransactionScope())
                    {
                        SaveRefundOrder(model);
                        if (paymentModel != null && paymentModel.Payments != null && paymentModel.Payments.Count() > 0)
                        {
                            var paymentId = _paymentController.SavePayment(paymentModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                            _orderRepository.ApplyPaymentToOrder(model.Order.Id, paymentId);
                        }
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                model.Order = _orderRepository.GetOrder(model.CustomerId, model.EventId);
                CompleteModel(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure! " + ex.Message);
                return View(model);
            }
            model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Amount refunded successfully.");
            return View(model);
        }

        private void CompleteModel(ManualRefundEditModel model)
        {
            if (model.Payments != null)
                model.Payments = new PaymentEditModel
                {
                    PaymentFlow = PaymentFlow.Out,
                    AllowedPaymentTypes =
                        new[]
                                                 {
                                                     new OrderedPair<long, string>(
                                                         PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name)
                                                 }
                };
            else
            {
                model.Payments.PaymentFlow = PaymentFlow.Out;
                model.Payments.AllowedPaymentTypes =
                    new[]
                        {
                            new OrderedPair<long, string>(
                                PaymentType.Check.PersistenceLayerId, PaymentType.Check.Name)
                        };
            }

            var order = model.Order;
            if (order.PaymentsApplied != null && order.PaymentsApplied.Count > 0 && order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard && pa.Amount > 0).Count() > 0)
            {
                var cardPayment = (ChargeCardPayment)order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard).OrderByDescending(
                    pa => pa.DataRecorderMetaData.DateCreated).FirstOrDefault();

                string reasonForFailure;
                if (IoC.Resolve<IChargeCardService>().IsCardValidforRefund(cardPayment, 0, out reasonForFailure))
                {
                    model.Payments.ChargeCardonFile = new ChargeCardPaymentEditModel()
                                                          {
                                                              ChargeCardPayment = cardPayment,
                                                              ChargeCard =
                                                                  _chargeCardRepository.GetById(cardPayment.ChargeCardId)
                                                          };

                    model.Payments.AllowedPaymentTypes = model.Payments.AllowedPaymentTypes.Concat(new[]
                                                                  {
                                                                      new OrderedPair<long, string>(
                                                                          PaymentType.CreditCardOnFile_Value,
                                                                          PaymentType.CreditCardOnFile_Text)
                                                                  });
                }
            }

            model.Payments.ExistingBillingAddress =
                Mapper.Map<Address, AddressEditModel>(_customerRepository.GetCustomer(model.CustomerId).BillingAddress) ?? new AddressEditModel();
        }

        private bool IsModelValid(ManualRefundEditModel model)
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            if (model.AmountToRefund > (model.Order.TotalAmountPaid - model.TotalRefundRequestAmount))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Refund Amount can not be greater than $" + (model.Order.TotalAmountPaid - model.TotalRefundRequestAmount).ToString("0.00"));
                return false;
            }

            var refundValidator = IoC.Resolve<IValidator<ManualRefundEditModel>>();
            var validationresult = ValidateModel(refundValidator, model);

            if (!string.IsNullOrEmpty(validationresult))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(validationresult);
                return false;
            }

            if ((_settings.IsRefundQueueEnabled) && (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager) || currentOrgRole.CheckRole((long)Roles.Technician)))
            {
                var validator = IoC.Resolve<IValidator<RefundRequestEditModel>>();
                var result = ValidateModel(validator, model.RefundRequest);

                if (!string.IsNullOrEmpty(result))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    return false;
                }
            }
            else
            {
                var validator = IoC.Resolve<IValidator<PaymentEditModel>>();
                var result = ValidateModel(validator, model.Payments);

                if (!string.IsNullOrEmpty(result))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    return false;
                }

                if (model.Payments.Payments == null || model.Payments.Payments.Count() < 1 ||
                    model.Payments.Payments.Sum(p => p.Amount) < model.Payments.Amount)
                {
                    result = "Please provide the complete payment information";
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    return false;
                }
            }
            return true;
        }

        private void SaveRefundOrder(ManualRefundEditModel model)
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            var customer = _customerRepository.GetCustomer(model.CustomerId);

            OrganizationRoleUser forOrganizationRoleUser;
            OrganizationRoleUser creatorOrganizationRoleUser = GetOrganizationRoleUsers(customer, IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, out forOrganizationRoleUser);

            var notes = (_settings.IsRefundQueueEnabled) &&
                        (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager) ||
                         currentOrgRole.CheckRole((long)Roles.Technician))
                            ? model.RefundRequest.Reason
                            : "Refund payment";
            var amount = (_settings.IsRefundQueueEnabled) &&
                         (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager) ||
                          currentOrgRole.CheckRole((long)Roles.Technician))
                             ? model.AmountToRefund
                             : model.Payments.Amount;
            var orderService = IoC.Resolve<IOrderService>();
            var refundOrderItem = orderService.SaveRefundOrderItem(creatorOrganizationRoleUser, notes, amount);

            orderService.RefundOrder(refundOrderItem, model.Order, creatorOrganizationRoleUser,
                                                   forOrganizationRoleUser);

        }

        private static OrganizationRoleUser GetOrganizationRoleUsers(DomainObjectBase customer, long organizationRoleUserId, out OrganizationRoleUser forOrganizationRoleUser)
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var creatorOrganizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);

            forOrganizationRoleUser = null;
            var orgRoleUsers = organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(customer.Id);
            if (!orgRoleUsers.IsNullOrEmpty())
            {
                forOrganizationRoleUser = orgRoleUsers.Where(org => org.RoleId == (long)Roles.Customer).FirstOrDefault();
            }

            return creatorOrganizationRoleUser;
        }
    }
}
