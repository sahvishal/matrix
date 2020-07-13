using System;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace API.Areas.Medical.Controllers
{

    public class GiftCardController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ISessionContext _sessionContext;

        private readonly IGiftCardService _giftCardService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public GiftCardController(ILogManager logManager, IGiftCardService giftCardService, ISessionContext sessionContext, IEventCustomerRepository eventCustomerRepository, ICorporateAccountRepository corporateAccountRepository, IEventRepository eventRepository)
        {
            _giftCardService = giftCardService;
            _sessionContext = sessionContext;
            _logger = logManager.GetLogger<GiftCardController>();
            _eventCustomerRepository = eventCustomerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;
        }

        [HttpPost]
        public MobileResponseModel Save(GiftCertificateSignatureModel model)
        {
            try
            {
                var GCReasionId = model.GcNotGivenReasonId != null ? model.GcNotGivenReasonId : 0;
                _logger.Info("Gift Card (Save) : EventCustomerId Id :" + model.EventCustomerId);
                _logger.Info("Gift Card (Save) : GcNotGivenReasonId :" +GCReasionId);
                _logger.Info("Gift Card (Save) : GiftCardReceived :" + model.GiftCardReceived);

                var eventCustomer = ((IUniqueItemRepository<EventCustomer>)_eventCustomerRepository).GetById(model.EventCustomerId);

                var eventId = eventCustomer != null ? eventCustomer.EventId : 0;

                CorporateAccount account = null;

                if (eventId > 0)
                {
                    account = _corporateAccountRepository.GetbyEventId(eventId);
                }
                if (account != null)
                {
                    _logger.Info("Account Tag : " + account.Tag + "  AttachGiftCard : " + account.AttachGiftCard + "  ShowGiftCertificateOnEod : " + account.ShowGiftCertificateOnEod);
                }

                if ((account != null && account.AttachGiftCard) && !model.GiftCardReceived && (model.GcNotGivenReasonId == null || (model.GcNotGivenReasonId != null && model.GcNotGivenReasonId == 0)))
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save the Gift Card because GC not given reason Id is null"
                    };
                }

                var isSuccess = _giftCardService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                if (isSuccess)
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = true,
                        Message = "Gift Card saved successfully."
                    };
                }
                else
                {
                    return new MobileResponseModel
                    {
                        IsSuccess = false,
                        Message = "Unable to save the Gift Card."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error while saving Gift Card.");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error while saving Gift Card. Message : {0}", ex.Message)
                };
            }
        }
    }
}
