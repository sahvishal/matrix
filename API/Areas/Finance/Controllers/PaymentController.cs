using System;
using System.Web.Http;
using API.Areas.Finance.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Scheduling.Impl;

namespace API.Areas.Finance.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly ICustomerPaymentService _customerPaymentService;
        private readonly ISessionContext _sessionContext;
        private readonly IRepository<RefundRequest> _refundRequestRepository;
        private readonly IGiftCertificateService _giftCertificateService;
        private readonly IGiftCertificateFactory _giftCertificateFactory;
        private readonly EventSchedulerService _eventSchedulerService;
        private readonly ILogger _logger;
        public PaymentController(ILogManager logManager, ICustomerPaymentService customerPaymentService, ISessionContext sessionContext, IRepository<RefundRequest> refundRequestRepository, IGiftCertificateService giftCertificateService, IGiftCertificateFactory giftCertificateFactory, EventSchedulerService eventSchedulerService)
        {
            if (eventSchedulerService == null) throw new ArgumentNullException("eventSchedulerService");
            _customerPaymentService = customerPaymentService;
            _sessionContext = sessionContext;
            _refundRequestRepository = refundRequestRepository;
            _giftCertificateService = giftCertificateService;
            _giftCertificateFactory = giftCertificateFactory;
            _eventSchedulerService = eventSchedulerService;
            _logger = logManager.GetLogger<PaymentController>();
        }

        [HttpGet]
        public PaymentViewModel Get([FromUri]long customerId, [FromUri]long eventId)
        {
            try
            {
                var model = _customerPaymentService.Get(customerId, eventId) ?? new PaymentViewModel();
                model.IsSuccess = true;
                model.Message = "Success";
                model.StatusCode = 200;
                return model;
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while geting payment model Message:{0}, stack Trace {1}", exception.Message, exception.StackTrace));
                return new PaymentViewModel { IsSuccess = false, StatusCode = 500, Message = exception.Message };
            }
        }

        [HttpPost]
        public ResponseBaseModel RefundPayment([FromBody] CustomerRefundRequest model)
        {
            try
            {
                var rmodel = new RefundRequest
                {
                    CustomerId = model.CustomerId,
                    EventId = model.EventId,
                    OrderId = model.OrderId,
                    Reason = model.Reason,
                    RefundRequestType = (RefundRequestType)model.RefundRequestType,
                    RequestedByOrgRoleUserId =
                        _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    RequestedOn = DateTime.Now,
                    RequestedRefundAmount = model.RequestedRefundAmount,
                    RequestStatus = (long)RequestStatus.Pending
                };
                var refundRequest = _refundRequestRepository.Save(rmodel);

                return new ResponseBaseModel
                {
                    Id = refundRequest.OrderId,
                    IsSuccess = true,
                    Message = "Refund requested Successfully",
                    StatusCode = 200
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while saving refund request by client. Stack tace: {0}", exception.StackTrace), exception);

                return new ResponseBaseModel
                {
                    Id = 0,
                    IsSuccess = false,
                    Message = "Refund requested fails",
                    StatusCode = 500
                };
            }

        }

        [HttpGet]
        public GiftCertificateModel ValidateGiftCertificate([FromUri]string claimCode)
        {
            try
            {
                var gCmodel = _giftCertificateService.GetGiftCertificatebyClaimCode(claimCode);
                return _giftCertificateFactory.GetModel(gCmodel);
            }
            catch (InvalidOperationException exception)
            {
                _logger.Error("Validate gift Certification Invalid Operation", exception);
                return new GiftCertificateModel { Id = 0, IsSuccess = false, Message = exception.Message, StatusCode = 422 };
            }
            catch (ObjectDeactivatedException<GiftCertificate> exception)
            {
                _logger.Error("Validate gift Certification deactivated Exceptoin", exception);
                return new GiftCertificateModel { Id = 0, IsSuccess = false, Message = exception.Message, StatusCode = 422 };
            }
            catch (Exception exception)
            {
                _logger.Error("Some System Error", exception);
                return new GiftCertificateModel { Id = 0, IsSuccess = false, Message = "Some System Error", StatusCode = 500 };
            }
        }

        [HttpPost]
        public SourceCodeApplyEditModel ValidateSourceCode([FromBody] SourceCodeApplyEditModel model)
        {
            if (model != null) model.SignUpMode = (int)SignUpMode.Walkin;
            try
            {
                return _eventSchedulerService.ApplySourceCode(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format(" message: {0} \n stack Trace {1} ", ex.Message, ex.StackTrace));

            }
            return null;
        }
    }
}
