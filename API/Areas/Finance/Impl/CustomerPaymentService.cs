using System;
using System.Collections.Generic;
using System.Linq;
using API.Areas.Finance.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using PaymentEditModel = API.Areas.Finance.Models.PaymentEditModel;
using PaymentModel = Falcon.App.Core.Finance.ViewModels.PaymentEditModel;
namespace API.Areas.Finance.Impl
{
    public class CustomerPaymentService : ICustomerPaymentService
    {
        private readonly ISettings _settings;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISessionContext _sessionContext;

        private readonly IGiftCertificateService _giftCertificateService;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPaymentController _paymentController;

        private Order _order;
        protected const string ResponseReasonCodeForSameDayRefund = "54";

        protected ProcessorResponse PaymentGatewayResponse { get; set; }

        public CustomerPaymentService(ISettings settings, IOrderRepository orderRepository, ICustomerRepository customerRepository,
            ISessionContext sessionContext, IGiftCertificateService giftCertificateService, IEventSchedulerService eventSchedulerService,
            IEventCustomerRepository eventCustomerRepository, IPaymentController paymentController)
        {
            _settings = settings;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _sessionContext = sessionContext;


            _giftCertificateService = giftCertificateService;
            _eventSchedulerService = eventSchedulerService;
            _eventCustomerRepository = eventCustomerRepository;
            _paymentController = paymentController;

        }

        public PaymentViewModel Get(long customerId, long eventId)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);
            if (order == null) return null;

            return new PaymentViewModel
              {
                  AmountPaid = order.TotalAmountPaid,
                  TotalAmount = order.DiscountedTotal,
                  IsRefundEnabled = _settings.IsRefundQueueEnabled,
                  CustomerId = customerId,
                  EventId = eventId,
                  OrderId = order.Id
              };
        }

        public bool ProcessPayment(PaymentEditModel model)
        {
            var customer = _customerRepository.GetCustomer(model.CustomerId);
            var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);
            var instruments = new List<PaymentInstrumentEditModel>();
            var paymentEditModel = new PaymentModel();

            if (model.GcPayment != null && !string.IsNullOrEmpty(model.GcPayment.ClaimCode))
            {
                var giftCertificate = _giftCertificateService.GetGiftCertificatebyClaimCode(model.GcPayment.ClaimCode);

                instruments.Add(new PaymentInstrumentEditModel { Amount = model.GcPayment.Amount, PaymentType = PaymentType.GiftCertificate.PersistenceLayerId, GiftCertificate = new GiftCertificatePaymentEditModel { GiftCertificate = giftCertificate, GiftCertificatePayment = new GiftCertificatePayment { GiftCertificateId = giftCertificate.Id, Amount = model.GcPayment.Amount } } });
            }
            if (model.Payments != null)
            {
                model.Payments.BillingAddress = model.BillingAddress;
                CreatePaymentModels(model);
                instruments.Add(model.Payments);
            }

            paymentEditModel.Amount = model.UnPaidAmount;
            paymentEditModel.IsModeMultiple = false;
            paymentEditModel.PaymentFlow = PaymentFlow.In;
            paymentEditModel.Payments = instruments;
            paymentEditModel.ExistingBillingAddress = model.BillingAddress;
            paymentEditModel.ExistingShippingAddress = model.BillingAddress;

            _eventSchedulerService.ProcessPayment(paymentEditModel, eventCustomer.Id, model.CustomerId, true);

            try
            {
                _order = _orderRepository.GetOrder(model.CustomerId, model.EventId);

                if (paymentEditModel.Payments != null && paymentEditModel.Payments.Any(p => p.ChargeCard != null || p.ECheck != null || p.GiftCertificate != null || p.Check != null || p.PaymentType == PaymentType.Cash.PersistenceLayerId))
                {
                    var paymentId = _paymentController.SavePayment(paymentEditModel, model.CustomerId);
                    _orderRepository.ApplyPaymentToOrder(_order.Id, paymentId);
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception("Some error occured while saving payment detail",exception);
            }

            

            return true;
        }

        private void CreatePaymentModels(PaymentEditModel model)
        {
            if (model == null || model.Payments == null) return;

            if (model.Payments.ChargeCard != null && model.Payments.ChargeCard.ChargeCard != null)
            {
                model.Payments.ChargeCard.ChargeCardPayment = new ChargeCardPayment
                {

                    Amount = model.Payments.Amount,
                    ChargeCardId = 0,
                    PaymentId = 0,
                    DataRecorderMetaData = new DataRecorderMetaData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, DateTime.Now)
                };
            }
            if (model.Payments.Check != null && model.Payments.Check.Check != null)
            {
                model.Payments.Check.Check.PayableTo = _settings.CompanyName;
                model.Payments.Check.Check.CheckDate = DateTime.Today.Date;
                model.Payments.Check.CheckPayment = new CheckPayment
                {
                    Amount = model.Payments.Amount,
                    Check = model.Payments.Check.Check,
                    CheckId = model.Payments.Check.Check.Id,
                    CheckStatus = CheckPaymentStatus.Recieved,
                    DataRecorderMetaData = new DataRecorderMetaData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, DateTime.Now),
                    PaymentId = 0
                };
            }

            if (model.Payments.ECheck != null && model.Payments.ECheck.ECheck != null)
            {
                model.Payments.ECheck.ECheck.PayableTo = _settings.CompanyName;
                model.Payments.ECheck.ECheck.CheckDate = DateTime.Today.Date;

                model.Payments.ECheck.ECheckPayment = new ECheckPayment
                {
                    Amount = model.Payments.Amount,
                    ECheck = model.Payments.ECheck.ECheck,
                    ECheckId = model.Payments.ECheck.ECheck.Id,
                    DataRecorderMetaData = new DataRecorderMetaData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, DateTime.Now),
                    PaymentId = 0
                };
            }



        }
    }
}
